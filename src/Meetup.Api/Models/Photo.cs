
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Photo
    {
        [JsonProperty("thumb")]
        public string Thumb { get; set; }
    }
}
