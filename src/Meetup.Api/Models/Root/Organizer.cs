using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Organizer
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("member_id")]
        public int MemberId { get; set; }
    }
}