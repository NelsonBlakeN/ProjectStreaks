namespace GithubActivityTracker.DataAccess.HttpClient
{
    using System.Net.Http;

    public interface IHttpClientFactory
    {
        public HttpClient GetClient(string baseAddress);
    }
}
