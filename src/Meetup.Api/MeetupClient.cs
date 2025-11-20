using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.Api
{
    public class MeetupClient : IMeetupClient
    {
        private readonly HttpClient _httpClient;

        public MeetupClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<bool> GetStatusAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var query = "query { healthCheck { status } }";
                // Note: The actual health check query might differ. 
                // Using a simple query to 'self' or similar is often a good proxy if no dedicated health endpoint exists in GQL.
                // For now, we'll try a basic query. If it fails, we return false.
                await ExecuteQueryAsync<object>(query, null, cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Categories> GetCategoriesAsync(CancellationToken cancellationToken = default)
        {
            // Note: Authentication logic needs to be handled via HttpClient message handler or similar mechanism
            // This implementation assumes the HttpClient is already configured with necessary headers/auth
            // or that the URL construction handles it (which is less ideal for DI).
            // For now, replicating the base URL structure but assuming the client has the base address.
            
            return await _httpClient.GetFromJsonAsync<Categories>("/2/categories", cancellationToken) 
                   ?? throw new HttpRequestException("Failed to retrieve categories.");
        }

        public async Task<Cities> GetCitiesAsync(string country, double lat, double lon, int radius, CancellationToken cancellationToken = default)
        {
            var query = $"/2/cities?country={country}&lon={lon}&radius={radius}&lat={lat}";
            return await _httpClient.GetFromJsonAsync<Cities>(query, cancellationToken)
                   ?? throw new HttpRequestException("Failed to retrieve cities.");
        }

        public async Task<IEnumerable<Board>> GetBoardsAsync(string urlName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(urlName)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(urlName));
            return await _httpClient.GetFromJsonAsync<IEnumerable<Board>>($"/{urlName}/boards", cancellationToken)
                   ?? throw new HttpRequestException("Failed to retrieve boards.");
        }

        public async Task<IEnumerable<Discusssions>> GetDiscussionsAsync(string urlName, string bid, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(urlName)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(urlName));
            if (string.IsNullOrWhiteSpace(bid)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(bid));
            return await _httpClient.GetFromJsonAsync<IEnumerable<Discusssions>>($"/{urlName}/boards/{bid}/discussions", cancellationToken)
                   ?? throw new HttpRequestException("Failed to retrieve discussions.");
        }

        public async Task<IEnumerable<Discussion>> GetDiscussionAsync(string urlName, string bid, string did, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(urlName)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(urlName));
            if (string.IsNullOrWhiteSpace(bid)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(bid));
            if (string.IsNullOrWhiteSpace(did)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(did));
            return await _httpClient.GetFromJsonAsync<IEnumerable<Discussion>>($"/{urlName}/boards/{bid}/discussions/{did}", cancellationToken)
                   ?? throw new HttpRequestException("Failed to retrieve discussion.");
        }

        public async Task<Events> GetOpenEventsAsync(string topic, string lat, string lon, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(topic)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(topic));
            if (string.IsNullOrWhiteSpace(lat)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(lat));
            if (string.IsNullOrWhiteSpace(lon)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(lon));
            return await _httpClient.GetFromJsonAsync<Events>($"/2/open_events?lat={lat}&topic={topic}&lon={lon}", cancellationToken)
                   ?? throw new HttpRequestException("Failed to retrieve open events.");
        }

        public async Task<Events> GetConciergeAsync(string lat, string lon, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(lat)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(lat));
            if (string.IsNullOrWhiteSpace(lon)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(lon));
            return await _httpClient.GetFromJsonAsync<Events>($"/2/concierge?lat={lat}&lon={lon}", cancellationToken)
                   ?? throw new HttpRequestException("Failed to retrieve concierge events.");
        }

        public async Task<Events> GetEventsAsync(string groupUrl, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(groupUrl)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(groupUrl));

            var query = @"
                query ($urlname: String!) {
                    groupByUrlname(urlname: $urlname) {
                        upcomingEvents(input: { first: 100 }) {
                            edges {
                                node {
                                    id
                                    title
                                    dateTime
                                    description
                                    eventUrl
                                    venue {
                                        id
                                        name
                                        address
                                        city
                                        country
                                    }
                                }
                            }
                        }
                    }
                }";

            var variables = new { urlname = groupUrl };
            var response = await ExecuteQueryAsync<object>(query, variables, cancellationToken);
            
            // Note: We need to map the GraphQL response to the existing Events model.
            // This is a simplified mapping. In a real scenario, we'd likely update the models to match GQL structure directly
            // or use a mapper. For now, we'll construct the Events object manually to satisfy the interface.
            
            // TODO: Implement proper mapping logic here.
            // For this step, we are establishing the pattern.
            
            return new Events(); 
        }

        public async Task<Event> GetEventAsync(string urlName, string id, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(urlName)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(urlName));
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));
            return await _httpClient.GetFromJsonAsync<Event>($"/{urlName}/events/{id}/", cancellationToken)
                   ?? throw new HttpRequestException("Failed to retrieve event.");
        }

        public async Task<Events> CreateEventAsync(string groupUrl, string name, CreateEventModel content, CancellationToken cancellationToken = default)
        {
             if (string.IsNullOrWhiteSpace(groupUrl)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(groupUrl));
             if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
             if (content == null) throw new ArgumentNullException(nameof(content));

             // Note: This implementation simplifies the form encoding. 
             // In a real scenario, we might need to map CreateEventModel to key-value pairs if the API expects x-www-form-urlencoded.
             // Assuming standard JSON post or form url encoded. The original used FormUrlEncodedContent.
             
             var keyValues = new List<KeyValuePair<string, string>>
             {
                 new("description", content.Description ?? ""),
                 new("duration", content.Duration.ToString()),
                 new("guest_limit", content.GuestLimit.ToString()),
                 new("hosts", content.Hosts != null ? string.Join(",", content.Hosts) : ""),
                 new("how_to_find_us", content.HowToFindUs ?? ""),
                 new("publish_status", content.PublishStatus.ToString()),
                 new("rsvp_close", content.RSVPClose.ToString()),
                 new("rsvp_limit", content.RSVPLimit.ToString()),
                 new("rsvp_open", content.RSVPOpen.ToString()),
                 new("simple_html_description", content.SimpleHtmlDescription ?? ""),
                 new("time", content.Time.ToString()),
                 new("venue_id", content.VenueId ?? ""),
                 new("venue_visibility", content.VenueVisibility.ToString()),
                 new("waitlisting", content.Waitlisting.ToString()),
                 new("why", content.Why ?? "")
             };
             
             // Add questions
             if (content.Questions != null)
             {
                 for (int i = 0; i < content.Questions.Length; i++)
                 {
                     keyValues.Add(new KeyValuePair<string, string>($"question{i}", content.Questions[i]));
                 }
             }

             var formContent = new FormUrlEncodedContent(keyValues);
             var response = await _httpClient.PostAsync($"/2/event?group_urlname={groupUrl}", formContent, cancellationToken);
             response.EnsureSuccessStatusCode();
             
             return await response.Content.ReadFromJsonAsync<Events>(cancellationToken: cancellationToken)
                    ?? throw new HttpRequestException("Failed to create event.");
        }
        public async Task<T> ExecuteQueryAsync<T>(string query, object? variables = null, CancellationToken cancellationToken = default) where T : class
        {
            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(query));

            var request = new GraphQLRequest
            {
                Query = query,
                Variables = variables
            };

            var response = await _httpClient.PostAsJsonAsync("gql-ext", request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var gqlResponse = await response.Content.ReadFromJsonAsync<GraphQLResponse<T>>(cancellationToken: cancellationToken);

            if (gqlResponse?.Errors != null && gqlResponse.Errors.Count > 0)
            {
                throw new HttpRequestException($"GraphQL Error: {gqlResponse.Errors[0].Message}");
            }

            if (gqlResponse?.Data == null)
            {
                 throw new HttpRequestException("GraphQL response data is null.");
            }

            return gqlResponse.Data;
        }
    }
}
