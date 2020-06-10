namespace GithubActivityTracker.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using GithubActivityTracker.Models;
    using Newtonsoft.Json;
    using GithubActivityTracker.DataAccess.HttpClient;

    public class CommitInfoData
    {
        private GithubActivityTracker.DataAccess.HttpClient.IHttpClientFactory ClientFactory;
        private System.Net.Http.HttpClient Client;

        public CommitInfoData()
        {
            this.ClientFactory = new HttpClientFactory();
            this.Client = this.ClientFactory.GetClient("https://api.github.com");
        }

        public async Task<IEnumerable<CommitInfo>> GetCommits(string repo, string date = null)
        {
            var url = $"repos/NelsonBlakeN/{repo}/commits";

            if (date != null)
            {
                url += "?since=" + date;
            }

            HttpResponseMessage response = await this.Client.GetAsync(url);
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine(exception);
            }
            var resp = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<CommitInfo>>(resp);
        }
    }
}
