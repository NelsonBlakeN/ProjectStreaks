namespace GithubActivityTracker.BusinessFlow
{
    using GithubActivityTracker.DataAccess;
    using GithubActivityTracker.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CommitStreakFlow
    {
        private RepositoryData RepositoryData { get; set; }
        private CommitInfoData CommitInfoData { get; set; }
        private EventFlow EventFlow { get; set; }

        public CommitStreakFlow()
        {
            this.RepositoryData = new RepositoryData();
            this.CommitInfoData = new CommitInfoData();
            this.EventFlow = new EventFlow();
        }

        public async Task<int> GetStreak()
        {
            var endStreak = false;
            var currentPage = 1;
            var events = new List<Event>();

            while (!endStreak)
            {
                // 1 - Get commit events for current page number
                var eventsPage = (await this.EventFlow.GetPushEventsAsync(currentPage)).ToList();
                eventsPage = eventsPage.GroupBy(e => e.CreatedAt.DayOfYear).Select(f => f.FirstOrDefault()).ToList();

                // 2 - While the streak is still going at the end of the page, get the next page
                // and merge with previous results
                var yesterday = DateTime.Now.AddDays(-1);
                if (eventsPage.Count == 0)
                {
                    endStreak = true;
                }
                else if (currentPage == 1 && eventsPage[0].CreatedAt.DayOfYear < yesterday.DayOfYear)
                {
                    endStreak = true;
                }
                else
                {
                    events.Add(eventsPage[0]);
                    int b;
                    for (b = 1; b < eventsPage.Count && (eventsPage[b-1].CreatedAt - eventsPage[b].CreatedAt).TotalDays <= 1; b++)
                    {
                        events.Add(eventsPage[b]);
                    }

                    if (b != eventsPage.Count)
                    {
                        // Streak was ended before all events in the page were processed
                        endStreak = true;
                    }
                    else
                    {
                        // Streak continues past the end of the page
                        // Get next page number and continue
                        currentPage++;
                    }
                }
            }

            // 3 - Finally, return the count
            return events.Count;
        }
    }
}
