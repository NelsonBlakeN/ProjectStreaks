using GithubActivityTracker.DataAccess.HttpClient;
using GithubActivityTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubActivityTracker.DataAccess
{
    public class EventData
    {
        private GithubClient GithubClient => new GithubClient();

        public EventData() { }

        public async Task<IEnumerable<Event>> GetPushEventsAsync(int page)
        {
            var events = await GithubClient.GetEvents(page);
            List<Event> pushEvents = new List<Event>(events.Where(e => e.Type == "PushEvent"));

            return pushEvents;
        }
    }
}
