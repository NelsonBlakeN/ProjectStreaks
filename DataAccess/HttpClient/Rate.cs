using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubActivityTracker.DataAccess.HttpClient
{
    public class Rate
    {
        [JsonProperty("reset")]
        public long Reset { get; set; }
        public Rate() { }
    }
}
