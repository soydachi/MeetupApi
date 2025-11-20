using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class LastPost
    {
        [JsonPropertyName("created")]
        public long Created { get; set; }
        [JsonPropertyName("member")]
        public Member? Member { get; set; }
    }
}
