using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Contrib.HttpClient;
using Xunit;

namespace Meetup.Api.UnitTests.Services
{
    public class MeetupClientTests
    {
        private readonly Mock<HttpMessageHandler> _handlerMock;
        private readonly MeetupClient _client;

        public MeetupClientTests()
        {
            _handlerMock = new Mock<HttpMessageHandler>();
            var httpClient = _handlerMock.CreateClient();
            httpClient.BaseAddress = new Uri("https://api.meetup.com");
            _client = new MeetupClient(httpClient);
        }

        [Fact]
        public async Task GetStatusAsync_ReturnsTrue_WhenStatusIsOk()
        {
            _handlerMock.SetupRequest(HttpMethod.Get, "https://api.meetup.com/status/")
                        .ReturnsResponse(HttpStatusCode.OK, "{\"status\": \"ok\"}", "application/json");

            var result = await _client.GetStatusAsync();

            Assert.True(result);
        }

        [Fact]
        public async Task GetStatusAsync_ReturnsFalse_WhenStatusIsNotOk()
        {
            _handlerMock.SetupRequest(HttpMethod.Get, "https://api.meetup.com/status/")
                        .ReturnsResponse(HttpStatusCode.OK, "{\"status\": \"error\"}", "application/json");

            var result = await _client.GetStatusAsync();

            Assert.False(result);
        }

        [Fact]
        public async Task GetStatusAsync_ReturnsFalse_WhenExceptionOccurs()
        {
            _handlerMock.SetupRequest(HttpMethod.Get, "https://api.meetup.com/status/")
                        .Throws(new HttpRequestException());

            var result = await _client.GetStatusAsync();

            Assert.False(result);
        }
    }
}
