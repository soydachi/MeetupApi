using System.Text.Json;
using Xunit;

namespace Meetup.Api.UnitTests.Models
{
    public class ModelTests
    {
        [Fact]
        public void Event_DeserializesCorrectly()
        {
            var json = @"
            {
                ""id"": ""123"",
                ""name"": ""Test Event"",
                ""time"": 1698422400000,
                ""venue"": {
                    ""name"": ""Test Venue""
                }
            }";

            var evt = JsonSerializer.Deserialize<Event>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Assert.NotNull(evt);
            Assert.Equal("123", evt.Id);
            Assert.Equal("Test Event", evt.Name);
            Assert.Equal("Test Venue", evt.Venue.Name);
        }

        [Fact]
        public void Group_DeserializesCorrectly()
        {
            var json = @"
            {
                ""id"": 100,
                ""name"": ""Test Group"",
                ""members"": 50
            }";

            var group = JsonSerializer.Deserialize<Group>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Assert.NotNull(group);
            Assert.Equal(100, group.Id);
            Assert.Equal("Test Group", group.Name);
            Assert.Equal(50, group.Members);
        }
    }
}
