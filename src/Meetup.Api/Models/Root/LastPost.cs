using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class LastPost
    {
        [JsonProperty("created")]
        public long Created { get; set; }
        [JsonProperty("member")]
        public Member Member { get; set; }
    }
}
