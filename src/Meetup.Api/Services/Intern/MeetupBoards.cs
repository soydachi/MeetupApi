using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class MeetupBoards
    {
        /// <summary>
        /// [Authentication required] Listings of Group discussion boards
        /// </summary>
        /// <param name="urlName">The urlName path element may be any valid group urlname or domain name.</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Task&lt;IEnumerable&lt;Board&gt;&gt;</returns>
        /// <exception cref="HttpRequestException">
        ///     Ops! Something went wrong :S. Please try again, if the error persist contact
        ///     with the developer to fix the issue.
        /// </exception>
        public async Task<IEnumerable<Board>> All(string urlName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(urlName)) throw new ArgumentException("Argument is null or empty", nameof(urlName));
            if (string.IsNullOrWhiteSpace(urlName)) throw new ArgumentException("Argument is null or whitespace", nameof(urlName));

            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
            queryUrl.Append($"/{urlName}/boards");

            var response =
                await
                    MeetupBase.ExecuteQueryAsync<IEnumerable<Board>>(queryUrl, cancellationToken);

            if (response == null)
                throw new HttpRequestException(
                    "Ops! Something went wrong :S. Please try again, if the error persist contact with the developer to fix the issue.");
            return response;
        }
    }
}