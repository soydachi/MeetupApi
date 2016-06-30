using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.String;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class MeetupBoards
    {
        /// <summary>
        ///  Listings of Group discussion boards
        /// </summary>
        /// <param name="urlName">
        ///     The urlName path element may be any valid group urlname or domain name
        /// </param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <exception cref="HttpRequestException">
        ///     Ops! Something went wrong :S. Please try again, if the error persist contact
        ///     with the developer to fix the issue.
        /// </exception>
        public async Task<IEnumerable<Board>> All(string urlName, CancellationToken cancellationToken)
        {
            if (IsNullOrEmpty(urlName)) throw new ArgumentException("Argument is null or empty", nameof(urlName));

            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
            queryUrl.Append($"/{urlName}/boards");

            var response =
                await
                    MeetupBase.ExecuteQueryAsync<IEnumerable<Board>>(queryUrl, cancellationToken, null, HttpMethodTypes.GET);

            if (response == null)
                throw new HttpRequestException(
                    "Ops! Something went wrong :S. Please try again, if the error persist contact with the developer to fix the issue.");
            return response;
        }
    }
}