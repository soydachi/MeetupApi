using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Meetup.Api.IntegrationTests.Services.Intern
{
    public class MeetupEventIntegrationTests
    {
        [Fact]
        public async Task ByIdAsync()
        {
            var urlName = "CrossDvlup";
            var id = "231590907";

            var result = await MeetupApi.Events.Event(urlName, id, CancellationToken.None);

            Assert.True(result.Id == id && result.Group.UrlName == urlName);
        }
    }
}
