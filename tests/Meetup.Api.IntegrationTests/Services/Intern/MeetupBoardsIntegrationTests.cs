using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Meetup.Api.IntegrationTests.Services.Intern
{
    public class MeetupBoardsIntegrationTests
    {
		[Fact]
        public async Task All()
        {
            var urlName = "CrossDvlup";

            var result = await MeetupApi.Boards.All(urlName, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Discussion()
        {
            var urlName = "CrossDvlup";
            var bid = "20671181";
            var did = "49893227";

            var result = await MeetupApi.Boards.Discussion(urlName, bid, did, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Discussions()
        {
            var urlName = "CrossDvlup";
            var bid = "20671181";

            var result = await MeetupApi.Boards.Discussions(urlName, bid, CancellationToken.None);

            Assert.NotNull(result);
        }
    }
}
