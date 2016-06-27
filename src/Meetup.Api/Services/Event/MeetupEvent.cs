// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class MeetupEvent
    {
        /// <summary>
        /// Get Event
        /// </summary>
        /// <param name="record">The record.</param>
        /// <param name="cancellationTokenSource"></param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <exception cref="HttpRequestException">Ops! Something went wrong :S. Please try again, if the error persist contact with the developer to fix the issue.</exception>
        public async Task<Event> ByIdAsync(string urlName, string id, CancellationTokenSource cancellationTokenSource)
        {
            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
            queryUrl.Append($"/{urlName}/events/{id}/");

            var response = await MeetupBase.ExecuteQueryAsync<Event>(queryUrl, null, HttpMethodTypes.GET, cancellationTokenSource);

            if (response == null)
                throw new HttpRequestException("Ops! Something went wrong :S. Please try again, if the error persist contact with the developer to fix the issue.");
            return response;
        }

        /// <summary>
        /// Get all attendance of an specific event
        /// </summary>
        /// <param name="record">The record.</param>
        /// <param name="cancellationTokenSource"></param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <exception cref="HttpRequestException">Ops! Something went wrong :S. Please try again, if the error persist contact with the developer to fix the issue.</exception>
        public async Task<Event> AttendanceAsync(string urlName, string id, CancellationTokenSource cancellationTokenSource)
        {
            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
            queryUrl.Append($"/{urlName}/events/{id}/attendance");
            
            var response = await MeetupBase.ExecuteQueryAsync<Event>(queryUrl, null, HttpMethodTypes.GET, cancellationTokenSource);

            if (response == null)
                throw new HttpRequestException("Ops! Something went wrong :S. Please try again, if the error persist contact with the developer to fix the issue.");
            return response;
        }

        ///// <summary>
        ///// Post all attendance of an specific event
        ///// </summary>
        ///// <param name="record">The record.</param>
        ///// <param name="cancellationTokenSource"></param>
        ///// <returns>Task&lt;System.Boolean&gt;.</returns>
        ///// <exception cref="HttpRequestException">Ops! Something went wrong :S. Please try again, if the error persist contact with the developer to fix the issue.</exception>
        //internal static async Task<bool> PostEventAttendanceAsync(string urlName, string id, CancellationTokenSource cancellationTokenSource)
        //{
        //    var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
        //    queryUrl.Append($"/{urlName}/events/{id}/attendance");

        //    //var content = new StringContent(message, Encoding.UTF8, "application/json");

        //    var response = await MeetupBase.ExecuteQueryAsync<object>(queryUrl, null, HttpMethodTypes.GET, cancellationTokenSource);

        //    if (response == null)
        //        throw new HttpRequestException("Ops! Something went wrong :S. Please try again, if the error persist contact with the developer to fix the issue.");
        //    return true;
        //}
    }
}
