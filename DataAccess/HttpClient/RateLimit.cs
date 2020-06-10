using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubActivityTracker.DataAccess.HttpClient
{
    public class RateLimit
    {
        [JsonProperty("rate")]
        public Rate Rate { get; set; }

        public RateLimit() { }
    }
}
