using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Meetup.Api.IntegrationTests.Services.Intern
{
    [TestFixture]
    public class MeetupBoardsIntegrationTests
    {
        [Test]
        public async Task All()
        {
            var urlName = "CrossDevelopment-Madrid";

            var result = await MeetupApi.Boards.All(urlName, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Test]
        public async Task Discussion()
        {
            var urlName = "CrossDevelopment-Madrid";
            var bid = "20671181";
            var did = "49893227";

            var result = await MeetupApi.Boards.Discussion(urlName, bid, did, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Test]
        public async Task Discussions()
        {
            var urlName = "CrossDevelopment-Madrid";
            var bid = "20671181";

            var result = await MeetupApi.Boards.Discussions(urlName, bid, CancellationToken.None);

            Assert.NotNull(result);
        }
    }
}
