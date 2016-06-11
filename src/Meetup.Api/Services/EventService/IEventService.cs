using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    interface IEventService
    {
        Task<Event> GetEventAsync(string urlName, string id, CancellationTokenSource cancellationTokenSource);
        Task<Event> GetEventAttendanceAsync(string urlName, string id, CancellationTokenSource cancellationTokenSource);
        Task<bool> PostEventAttendanceAsync(string urlName, string id, CancellationTokenSource cancellationTokenSource);
    }
}
