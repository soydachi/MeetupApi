using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonPropertyName("results")]
        public List<Category> Results { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }
}