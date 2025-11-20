using System.Threading;
using System.Threading.Tasks;

namespace Meetup.Api
{
    public interface IMeetupClient
    {
        Task<bool> GetStatusAsync(CancellationToken cancellationToken = default);
        Task<Categories> GetCategoriesAsync(CancellationToken cancellationToken = default);
        Task<Cities> GetCitiesAsync(string country, double lat, double lon, int radius, CancellationToken cancellationToken = default);
        Task<IEnumerable<Board>> GetBoardsAsync(string urlName, CancellationToken cancellationToken = default);
        Task<IEnumerable<Discusssions>> GetDiscussionsAsync(string urlName, string bid, CancellationToken cancellationToken = default);
        Task<IEnumerable<Discussion>> GetDiscussionAsync(string urlName, string bid, string did, CancellationToken cancellationToken = default);
        Task<Events> GetOpenEventsAsync(string topic, string lat, string lon, CancellationToken cancellationToken = default);
        Task<Events> GetConciergeAsync(string lat, string lon, CancellationToken cancellationToken = default);
        Task<Events> GetEventsAsync(string groupUrl, CancellationToken cancellationToken = default);
        Task<Event> GetEventAsync(string urlName, string id, CancellationToken cancellationToken = default);
        Task<Events> CreateEventAsync(string groupUrl, string name, CreateEventModel content, CancellationToken cancellationToken = default);
        Task<T> ExecuteQueryAsync<T>(string query, object? variables = null, CancellationToken cancellationToken = default) where T : class;
        
        // New GraphQL methods
        Task<Group?> GetGroupAsync(string urlName, CancellationToken cancellationToken = default);
        Task<Event?> GetEventByIdAsync(string eventId, CancellationToken cancellationToken = default);
        Task<Member?> GetSelfAsync(CancellationToken cancellationToken = default);
    }
}
