using Newtonsoft.Json;


// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Fee
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("accepts")]
        public string Accepts { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("required")]
        public string Required { get; set; }
    }
}
