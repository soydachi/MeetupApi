using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Meetup.Api.GraphQL
{
    // Root response for groupByUrlname query
    public class GroupByUrlnameResponse
    {
        [JsonPropertyName("groupByUrlname")]
        public GroupData? GroupByUrlname { get; set; }
    }

    public class GroupData
    {
        [JsonPropertyName("upcomingEvents")]
        public UpcomingEventsConnection? UpcomingEvents { get; set; }
    }

    public class UpcomingEventsConnection
    {
        [JsonPropertyName("edges")]
        public List<EventEdge>? Edges { get; set; }

        [JsonPropertyName("pageInfo")]
        public PageInfo? PageInfo { get; set; }
    }

    public class EventEdge
    {
        [JsonPropertyName("node")]
        public GraphQLEvent? Node { get; set; }

        [JsonPropertyName("cursor")]
        public string? Cursor { get; set; }
    }

    public class GraphQLEvent
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("dateTime")]
        public string? DateTime { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("eventUrl")]
        public string? EventUrl { get; set; }

        [JsonPropertyName("duration")]
        public string? Duration { get; set; }

        [JsonPropertyName("going")]
        public int Going { get; set; }

        [JsonPropertyName("venue")]
        public GraphQLVenue? Venue { get; set; }
    }

    public class GraphQLVenue
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("lat")]
        public double? Lat { get; set; }

        [JsonPropertyName("lng")]
        public double? Lng { get; set; }
    }

    public class PageInfo
    {
        [JsonPropertyName("hasNextPage")]
        public bool HasNextPage { get; set; }

        [JsonPropertyName("endCursor")]
        public string? EndCursor { get; set; }
    }
}
