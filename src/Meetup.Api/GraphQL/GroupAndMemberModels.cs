using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Meetup.Api.GraphQL
{
    // Response for groupByUrlname query (group details)
    public class GroupDetailsResponse
    {
        [JsonPropertyName("groupByUrlname")]
        public GraphQLGroup? GroupByUrlname { get; set; }
    }

    public class GraphQLGroup
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("urlname")]
        public string? Urlname { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }

        [JsonPropertyName("memberships")]
        public MembershipsConnection? Memberships { get; set; }

        [JsonPropertyName("groupPhoto")]
        public GraphQLGroupPhoto? GroupPhoto { get; set; }
    }

    public class GraphQLGroupPhoto
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("baseUrl")]
        public string? BaseUrl { get; set; }
    }

    public class MembershipsConnection
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }

    // Response for self query (authenticated user)
    public class SelfResponse
    {
        [JsonPropertyName("self")]
        public GraphQLMember? Self { get; set; }
    }

    public class GraphQLMember
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("bio")]
        public string? Bio { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("memberPhoto")]
        public GraphQLMemberPhoto? MemberPhoto { get; set; }
    }

    public class GraphQLMemberPhoto
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("baseUrl")]
        public string? BaseUrl { get; set; }
    }

    // Response for single event query
    public class EventByIdResponse
    {
        [JsonPropertyName("event")]
        public GraphQLEvent? Event { get; set; }
    }
}
