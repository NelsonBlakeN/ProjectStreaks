
namespace GithubActivityTracker.DataAccess.HttpClient
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using GithubActivityTracker.Models;

    public class GithubClient
    {
        private HttpClient Client;
        private HttpClientFactory HttpClientFactory => new HttpClientFactory();
        private string repoUrl => "users/NelsonBlakeN/repos";

        public GithubClient()
        {
            this.Client = this.HttpClientFactory.GetClient("https://api.github.com/");
        }

        public async Task<IEnumerable<Repository>> GetRepository(string name = null)
        {
            string url = repoUrl;
            if (name != null)
            {
                url = repoUrl;
            }

            string resp = null;
            long limitExpiration = 0;
            long currentTime = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();

            while (resp == null)
            {
                // If the current time is past the limit expiration, 
                // attempt to get the repositories
                if (currentTime > limitExpiration)
                {
                    HttpResponseMessage response = await this.Client.GetAsync(url);
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        limitExpiration = await this.GetRateLimit();
                    }
                    else
                    {
                        response.EnsureSuccessStatusCode();
                        resp = await response.Content.ReadAsStringAsync();
                    }
                }

                // Current time needs to be reset
                currentTime = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }

            return JsonConvert.DeserializeObject<List<Repository>>(resp);
        }

        public async Task<IEnumerable<Event>> GetEvents(int page)
        {
            var url = "users/NelsonBlakeN/events?page=" + page.ToString();
            var events = await this.GetAsync<List<Event>>(url);
            
            return events;
        }

        private async Task<long> GetRateLimit()
        {
            var url = "rate_limit";
            var rateLimit = await this.GetAsync<RateLimit>(url);

            return rateLimit.Rate.Reset;
        }

        // TODO: Put this in base client / interface
        private async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await this.Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(resp);
        }
    }
}
