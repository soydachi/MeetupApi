using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Discusssions
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("board")]
        public Board Board { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("started_by")]
        public StartedBy StartedBy { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("last_post")]
        public LastPost LastPost { get; set; }

        [JsonProperty("reply_count")]
        public int ReplyCount { get; set; }
    }
}