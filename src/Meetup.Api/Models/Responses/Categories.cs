using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Categories
    {
        public Categories()
        {
            Results = new List<Category>();
            Meta = new Meta();
        }

        [JsonProperty("results")]
        public List<Category> Results { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}