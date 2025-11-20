using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Moq.Contrib.HttpClient;
using Xunit;

namespace Meetup.Api.UnitTests.Services
{
    public class MeetupClientTests
    {
        private readonly Mock<HttpMessageHandler> _handlerMock;
        private readonly MeetupClient _client;
        private const string BaseUrl = "https://api.meetup.com";

        public MeetupClientTests()
        {
            _handlerMock = new Mock<HttpMessageHandler>();
            var httpClient = _handlerMock.CreateClient();
            httpClient.BaseAddress = new Uri(BaseUrl);
            _client = new MeetupClient(httpClient);
        }

        [Fact]
        public async Task GetStatusAsync_ReturnsTrue_WhenStatusIsOk()
        {
            _handlerMock.SetupRequest(HttpMethod.Post, $"{BaseUrl}/gql-ext")
                        .ReturnsResponse(HttpStatusCode.OK, "{\"data\": {\"healthCheck\": {\"status\": \"ok\"}}}", "application/json");

            var result = await _client.GetStatusAsync();

            Assert.True(result);
        }

        [Fact]
        public async Task GetStatusAsync_ReturnsFalse_WhenExceptionOccurs()
        {
            _handlerMock.SetupRequest(HttpMethod.Post, $"{BaseUrl}/gql-ext")
                        .Throws(new HttpRequestException());

            var result = await _client.GetStatusAsync();

            Assert.False(result);
        }



        [Fact]
        public async Task GetCitiesAsync_ReturnsCities_WhenSuccess()
        {
            var json = "{ \"results\": [ { \"city\": \"Madrid\", \"country\": \"es\" } ] }";
            _handlerMock.SetupRequest(HttpMethod.Get, $"{BaseUrl}/2/cities?country=es&lon=-3.7&radius=25&lat=40.4")
                        .ReturnsResponse(HttpStatusCode.OK, json, "application/json");

            var result = await _client.GetCitiesAsync("es", 40.4, -3.7, 25);

            Assert.NotNull(result);
        }











        [Fact]
        public async Task GetEventsAsync_GraphQL_ReturnsMappedEvents()
        {
            var gqlResponse = @"
            {
                ""data"": {
                    ""groupByUrlname"": {
                        ""upcomingEvents"": {
                            ""edges"": [
                                {
                                    ""node"": {
                                        ""id"": ""123"",
                                        ""title"": ""Test Event"",
                                        ""dateTime"": ""2023-10-27T18:00:00+02:00"",
                                        ""description"": ""Desc"",
                                        ""eventUrl"": ""http://meetup.com/e/123"",
                                        ""duration"": ""PT2H"",
                                        ""going"": 10,
                                        ""venue"": {
                                            ""id"": ""999"",
                                            ""name"": ""Venue Name"",
                                            ""address"": ""Street 1"",
                                            ""city"": ""Madrid"",
                                            ""state"": ""MD"",
                                            ""country"": ""es"",
                                            ""lat"": 40.0,
                                            ""lng"": -3.0
                                        }
                                    }
                                }
                            ]
                        }
                    }
                }
            }";

            _handlerMock.SetupRequest(HttpMethod.Post, $"{BaseUrl}/gql-ext")
                        .ReturnsResponse(HttpStatusCode.OK, gqlResponse, "application/json");

            var result = await _client.GetEventsAsync("my-group");

            Assert.NotNull(result);
            Assert.Single(result.results); // Fixed: lowercase 'results'
            var evt = result.results.First();
            Assert.Equal("Test Event", evt.Name);
            Assert.Equal(10, evt.YesRSVPCount);
            Assert.Equal("Venue Name", evt.Venue.Name);
        }

        [Fact]
        public async Task GetGroupAsync_GraphQL_ReturnsMappedGroup()
        {
            var gqlResponse = @"
            {
                ""data"": {
                    ""groupByUrlname"": {
                        ""id"": ""100"",
                        ""name"": ""My Group"",
                        ""urlname"": ""my-group"",
                        ""description"": ""Desc"",
                        ""city"": ""Madrid"",
                        ""memberships"": { ""count"": 50 },
                        ""groupPhoto"": { ""id"": ""1"", ""baseUrl"": ""http://photo.com"" }
                    }
                }
            }";

            _handlerMock.SetupRequest(HttpMethod.Post, $"{BaseUrl}/gql-ext")
                        .ReturnsResponse(HttpStatusCode.OK, gqlResponse, "application/json");

            var result = await _client.GetGroupAsync("my-group");

            Assert.NotNull(result);
            Assert.Equal("My Group", result.Name);
            Assert.Equal(50, result.Members);
            Assert.Equal("http://photo.com", result.GroupPhoto.PhotoLink);
        }

        [Fact]
        public async Task GetEventByIdAsync_GraphQL_ReturnsMappedEvent()
        {
            var gqlResponse = @"
            {
                ""data"": {
                    ""event"": {
                        ""id"": ""123"",
                        ""title"": ""Single Event"",
                        ""dateTime"": ""2023-10-27T18:00:00+02:00"",
                        ""venue"": { ""name"": ""Venue"" }
                    }
                }
            }";

            _handlerMock.SetupRequest(HttpMethod.Post, $"{BaseUrl}/gql-ext")
                        .ReturnsResponse(HttpStatusCode.OK, gqlResponse, "application/json");

            var result = await _client.GetEventByIdAsync("123");

            Assert.NotNull(result);
            Assert.Equal("Single Event", result.Name);
        }

        [Fact]
        public async Task GetSelfAsync_GraphQL_ReturnsMappedMember()
        {
            var gqlResponse = @"
            {
                ""data"": {
                    ""self"": {
                        ""id"": ""777"",
                        ""name"": ""John Doe"",
                        ""city"": ""Madrid"",
                        ""memberPhoto"": { ""baseUrl"": ""http://me.com/pic.jpg"" }
                    }
                }
            }";

            _handlerMock.SetupRequest(HttpMethod.Post, $"{BaseUrl}/gql-ext")
                        .ReturnsResponse(HttpStatusCode.OK, gqlResponse, "application/json");

            var result = await _client.GetSelfAsync();

            Assert.NotNull(result);
            Assert.Equal("John Doe", result.Name);
            Assert.Equal("http://me.com/pic.jpg", result.Photo.Thumb);
        }

        [Fact]
        public async Task CreateEventAsync_SendsCorrectData_AndReturnsEvent()
        {
            var jsonResponse = "{ \"results\": [ { \"name\": \"New Event\" } ] }";
            
            _handlerMock.SetupRequest(HttpMethod.Post, $"{BaseUrl}/2/event?group_urlname=my-group")
                        .ReturnsResponse(HttpStatusCode.OK, jsonResponse, "application/json");

            var eventModel = new CreateEventModel
            {
                Description = "Desc",
                Duration = 3600000,
                GuestLimit = 10,
                Time = 1234567890
            };

            var result = await _client.CreateEventAsync("my-group", "New Event", eventModel);

            Assert.NotNull(result);

            // Verify request content
            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req => CheckCreateEventContent(req, "Desc", "3600000", "10")),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        private bool CheckCreateEventContent(HttpRequestMessage req, string desc, string duration, string guestLimit)
        {
            var content = req.Content.ReadAsStringAsync().Result;
            return content.Contains($"description={desc}") &&
                   content.Contains($"duration={duration}") &&
                   content.Contains($"guest_limit={guestLimit}") &&
                   content.Contains("name=New+Event");
        }
    }
}
