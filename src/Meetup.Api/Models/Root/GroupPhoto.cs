using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class GroupPhoto
    {
        [JsonPropertyName("photo_link")]
        public string? PhotoLink { get; set; }

        [JsonPropertyName("highres_link")]
        public string? HighResLink { get; set; }

        [JsonPropertyName("thumb_link")]
        public string? ThumbLink { get; set; }

        [JsonPropertyName("photo_id")]
        public int PhotoId { get; set; }
    }
}