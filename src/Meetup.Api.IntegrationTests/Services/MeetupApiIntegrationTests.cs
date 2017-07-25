using System.Threading.Tasks;
using Xunit;

namespace Meetup.Api.IntegrationTests.Services
{
    public class MeetupApiIntegrationTests
    {
        [Fact]
        public async Task GetStatus_ReturnTrue()
        {
            var result = await MeetupApi.GetStatus();

            Assert.True(result);
        }

		[Fact]
        public async Task Categories_ReturnData()
        {
            var result = await MeetupApi.Categories();

            Assert.NotNull(result);
        }

		[Fact]
        public async Task Cities()
        {
            var result = await MeetupApi.Cities("es", 40.416881, -3.703435, 25);

            Assert.NotNull(result);
        }
    }
}
