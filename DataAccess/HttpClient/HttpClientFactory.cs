namespace GithubActivityTracker.DataAccess.HttpClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    
    public class HttpClientFactory : IHttpClientFactory
    {
        private HttpClient Client;

        public HttpClientFactory() { }

        public HttpClient GetClient(string baseAddress)
        {
            Client = new HttpClient();

            Client.BaseAddress = new Uri(baseAddress);
            Client.DefaultRequestHeaders.Add("User-Agent", "Project Productivity Tracker");
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return Client;
        }
    }
}
