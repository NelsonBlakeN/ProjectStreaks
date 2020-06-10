namespace GithubActivityTracker.Models
{
    using System.Text.Json.Serialization;

    public class Commit
    {
        public string Message { get; set; }

        public int Comment_count { get; set; }

        public Author Author { get; set; }

    }
}