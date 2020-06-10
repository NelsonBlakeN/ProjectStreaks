namespace GithubActivityTracker.Models
{
    public class CommitInfo
    {
        public string Sha { get; set; }

        public Commit Commit { get; set; }

        public override string ToString()
        {

            return $"{Sha}: {Commit.Author.Name}";
        }
    }
}
