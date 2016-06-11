using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Topic
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("urlkey")]
        public string UrlKey { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}