using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubActivityTracker.Models
{
    public class Event
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        public Event() { }
    }
}
