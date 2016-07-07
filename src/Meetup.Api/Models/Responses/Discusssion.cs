using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Discussion
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("in_reply_to")]
        public int InReplyTo { get; set; }

        [JsonProperty("discussion")]
        public Discussion DiscussionId { get; set; }

        [JsonProperty("member")]
        public Member Member { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }
    }
}
