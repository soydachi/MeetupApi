using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class City
    {
        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("localized_country_name")]
        public string LocalizedCountryName { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("city")]
        public string CityName { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("ranking")]
        public int Ranking { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
