using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Discusssions
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("board")]
        public Board? Board { get; set; }

        [JsonPropertyName("created")]
        public long Created { get; set; }

        [JsonPropertyName("updated")]
        public long Updated { get; set; }

        [JsonPropertyName("started_by")]
        public StartedBy? StartedBy { get; set; }

        [JsonPropertyName("subject")]
        public string? Subject { get; set; }

        [JsonPropertyName("body")]
        public string? Body { get; set; }

        [JsonPropertyName("last_post")]
        public LastPost? LastPost { get; set; }

        [JsonPropertyName("reply_count")]
        public int ReplyCount { get; set; }
    }
}