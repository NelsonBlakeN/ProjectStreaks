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
        public string Type { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        public Event() { }
    }
}
