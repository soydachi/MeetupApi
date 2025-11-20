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
            _handlerMock.SetupRequest(HttpMethod.Post, "https://api.meetup.com/gql-ext")
                        .ReturnsResponse(HttpStatusCode.OK, "{\"data\": {\"healthCheck\": {\"status\": \"ok\"}}}", "application/json");

            var result = await _client.GetStatusAsync();

            Assert.True(result);
        }

        [Fact]
        public async Task GetStatusAsync_ReturnsFalse_WhenExceptionOccurs()
        {
            _handlerMock.SetupRequest(HttpMethod.Post, "https://api.meetup.com/gql-ext")
                        .Throws(new HttpRequestException());

            var result = await _client.GetStatusAsync();

            Assert.False(result);
        }

        [Fact]
        public async Task GetStatusAsync_ReturnsFalse_WhenGraphQLErrorOccurs()
        {
            _handlerMock.SetupRequest(HttpMethod.Post, "https://api.meetup.com/gql-ext")
                        .ReturnsResponse(HttpStatusCode.OK, "{\"errors\": [{\"message\": \"error\"}]}", "application/json");

            var result = await _client.GetStatusAsync();

            Assert.False(result);
        }
    }
}
