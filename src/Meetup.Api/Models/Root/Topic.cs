using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Topic
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("urlkey")]
        public string? UrlKey { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}