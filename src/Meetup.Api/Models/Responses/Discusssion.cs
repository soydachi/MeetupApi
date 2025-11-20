using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Discussion
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("in_reply_to")]
        public int? InReplyTo { get; set; }

        [JsonPropertyName("discussion")]
        public string? DiscussionId { get; set; }

        [JsonPropertyName("member")]
        public Member? Member { get; set; }

        [JsonPropertyName("subject")]
        public string? Subject { get; set; }

        [JsonPropertyName("body")]
        public string? Body { get; set; }

        [JsonPropertyName("created")]
        public long Created { get; set; }

        [JsonPropertyName("updated")]
        public long Updated { get; set; }
    }
}
