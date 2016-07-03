using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Meetup.Api.IntegrationTests.Services.Intern
{
    [TestFixture]
    public class MeetupEventIntegrationTests
    {
        [Test]
        public async Task ByIdAsync()
        {
            var urlName = "CrossDevelopment-Madrid";
            var id = "231590907";

            var result = await MeetupApi.Events.ByIdAsync(urlName, id, CancellationToken.None);

            Assert.That(result.Id == id && result.Group.UrlName == urlName);
        }
    }
}
