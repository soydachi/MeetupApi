using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class StartedBy
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
