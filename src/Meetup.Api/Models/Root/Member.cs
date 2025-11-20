using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Member
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("member_id")]
        public int MemberId { get; set; }

        [JsonPropertyName("photo")]
        public Photo? Photo { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }
    }
}