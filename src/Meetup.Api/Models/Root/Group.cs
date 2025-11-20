using System.Collections.Generic;
using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Group
    {
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("visibility")]
        public string? Visibility { get; set; }

        [JsonPropertyName("organizer")]
        public Organizer? Organizer { get; set; }

        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("join_mode")]
        public string? JoinMode { get; set; }

        [JsonPropertyName("who")]
        public string? Who { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("category")]
        public Category? category { get; set; }

        [JsonPropertyName("topics")]
        public List<Topic>? Topics { get; set; }

        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }

        [JsonPropertyName("created")]
        public double? Created { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("urlname")]
        public string? UrlName { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("members")]
        public int Members { get; set; }

        [JsonPropertyName("group_photo")]
        public GroupPhoto? GroupPhoto { get; set; }

        [JsonPropertyName("group_lon")]
        public double GroupLongitude { get; set; }

        [JsonPropertyName("group_lat")]
        public double GroupLatitude { get; set; }

    }
}