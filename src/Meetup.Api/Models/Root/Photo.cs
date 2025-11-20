
using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Photo
    {
        [JsonPropertyName("thumb")]
        public string? Thumb { get; set; }
    }
}
