using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class StartedBy
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
