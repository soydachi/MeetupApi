using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Board
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("group")]
        public Group Group { get; set; }

        [JsonProperty("post_count")]
        public int Post_count { get; set; }

        [JsonProperty("discussion_count")]
        public int Discussion_count { get; set; }

        [JsonProperty("latest_reply")]
        public LatestReply LatestReply { get; set; }
    }
}