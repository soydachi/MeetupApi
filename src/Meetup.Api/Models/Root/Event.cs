using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Event
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("visibility")]
        public string? Visibility { get; set; }

        [JsonPropertyName("maybe_rsvp_count")]
        public int MaybeRSVPCount { get; set; }

        [JsonPropertyName("venue")]
        public Venue? Venue { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("utc_offset")]
        public int UTCOffset { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonPropertyName("waitlist_count")]
        public int WaitlistCount { get; set; }

        [JsonPropertyName("announced")]
        public bool Announced { get; set; }

        [JsonPropertyName("updated")]
        public long Updated { get; set; }

        [JsonPropertyName("yes_rsvp_count")]
        public int YesRSVPCount { get; set; }

        [JsonPropertyName("created")]
        public long Created { get; set; }

        [JsonPropertyName("event_url")]
        public string? EventUrl { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("how_to_find_us")]
        public string? HowToFindUs { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("headcount")]
        public int HeadCount { get; set; }

        [JsonPropertyName("group")]
        public Group? Group { get; set; }
    }
}