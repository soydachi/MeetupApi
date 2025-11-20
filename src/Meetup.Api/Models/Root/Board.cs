using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Board
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("created")]
        public long Created { get; set; }

        [JsonPropertyName("updated")]
        public long Updated { get; set; }

        [JsonPropertyName("group")]
        public Group? Group { get; set; }

        [JsonPropertyName("post_count")]
        public int Post_count { get; set; }

        [JsonPropertyName("discussion_count")]
        public int Discussion_count { get; set; }

        [JsonPropertyName("latest_reply")]
        public LatestReply? LatestReply { get; set; }
    }
}