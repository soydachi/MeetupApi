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
    }
}
