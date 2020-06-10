using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GithubActivityTracker.DataAccess;
using GithubActivityTracker.Models;

namespace GithubActivityTracker.BusinessFlow
{
    public class EventFlow
    {
        private EventData EventData;
        public EventFlow() 
        {
            this.EventData = new EventData();
        }

        public async Task<IEnumerable<Event>> GetPushEventsAsync(int page = 0)
        {
            return await this.EventData.GetPushEventsAsync(page);
        }
    }
}
