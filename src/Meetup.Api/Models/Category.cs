using Newtonsoft.Json;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortname")]
        public string Shortname { get; set; }
    }

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