namespace GithubActivityTracker
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using GithubActivityTracker.BusinessFlow;
    using GithubActivityTracker.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class CommitStreakController : ControllerBase
    {
        private CommitStreakFlow CommitStreakFlow { get; set; }
        public CommitStreakController()
        {
            this.CommitStreakFlow = new CommitStreakFlow();
        }

        [HttpGet]
        public async Task<int> Get()
        {
            return await this.CommitStreakFlow.GetStreak();
        }
    }
}