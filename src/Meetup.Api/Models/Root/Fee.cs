using System.Text.Json.Serialization;


// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Fee
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("accepts")]
        public string? Accepts { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("label")]
        public string? Label { get; set; }

        [JsonPropertyName("required")]
        public string? Required { get; set; }
    }
}
