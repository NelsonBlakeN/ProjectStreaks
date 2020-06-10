using GithubActivityTracker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GithubActivityTracker.DataAccess.HttpClient;

namespace GithubActivityTracker.DataAccess
{
    public class RepositoryData
    {
        private GithubClient GithubClient => new GithubClient();

        public RepositoryData() 
        {
        }

        public async Task<IEnumerable<Repository>> GetAllAsync()
        {
            return await GithubClient.GetRepository();
        }
    }
}
