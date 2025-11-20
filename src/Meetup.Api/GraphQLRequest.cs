using System.Text.Json.Serialization;

namespace Meetup.Api
{
    public class GraphQLRequest
    {
        [JsonPropertyName("query")]
        public string Query { get; set; } = string.Empty;

        [JsonPropertyName("variables")]
        public object? Variables { get; set; }
    }
}
