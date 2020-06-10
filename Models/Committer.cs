
namespace GithubActivityTracker.Models
{
    using System.Text.Json.Serialization;

    public class Committer
    {
        [JsonPropertyName("date")]
        private string Date { get; set; }

        [JsonPropertyName("name")]
        private string Name { get; set; }

        [JsonPropertyName("email")]
        private string Email { get; set; }
    }
}
