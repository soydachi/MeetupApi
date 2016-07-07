using System.Collections.Generic;
using Newtonsoft.Json;

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

        [JsonProperty("results")]
        public List<City> Results { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}