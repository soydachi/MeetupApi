using System.Collections.Generic;
using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Cities
    {
        public Cities()
        {
            Results = new List<City>();
            Meta = new Meta();
        }

        [JsonPropertyName("results")]
        public List<City> Results { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }
}