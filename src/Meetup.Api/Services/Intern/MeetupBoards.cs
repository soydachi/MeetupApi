using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Meetup.Api.Annotations;

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
        public async Task<IEnumerable<Board>> All([NotNull]string urlName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(urlName)) throw new ArgumentException("Argument is null or empty", nameof(urlName));
            if (string.IsNullOrWhiteSpace(urlName)) throw new ArgumentException("Argument is null or whitespace", nameof(urlName));

            if (!await MeetupBase.RenewAccessToken())
            {
                throw new HttpRequestException(Resources.ErrorMessage);
            }

            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
#if DEBUG
            queryUrl.Append($"/{urlName}/boards?{SecretKeys.ApiKeyUrl}");
#else
            queryUrl.Append($"/{urlName}/boards");
#endif
            var response =
                await
                    MeetupBase.ExecuteQueryAsync<IEnumerable<Board>>(queryUrl, cancellationToken);

            if (response == null)
                throw new HttpRequestException(Resources.ErrorMessage);
            return response;
        }

        /// <summary>
        /// [Authentication required] Listings of group discussions
        /// </summary>
        /// <param name="urlName">The urlName path element may be any valid group urlname or domain name.</param>
        /// <param name="bid">he bid path element may be any valid board ID for this group.</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Task&lt;IEnumerable&lt;Discusssion&gt;&gt;</returns>
        /// <exception cref="HttpRequestException">
        ///     Ops! Something went wrong :S. Please try again, if the error persist contact
        ///     with the developer to fix the issue.
        /// </exception>
        public async Task<IEnumerable<Discusssions>> Discussions([NotNull] string urlName, [NotNull] string bid,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(urlName)) throw new ArgumentException("Argument is null or empty", nameof(urlName));
            if (string.IsNullOrWhiteSpace(urlName)) throw new ArgumentException("Argument is null or whitespace", nameof(urlName));
            if (string.IsNullOrEmpty(bid)) throw new ArgumentException("Argument is null or empty", nameof(bid));
            if (string.IsNullOrWhiteSpace(bid)) throw new ArgumentException("Argument is null or whitespace", nameof(bid));

            if (!await MeetupBase.RenewAccessToken())
            {
                throw new HttpRequestException(Resources.ErrorMessage);
            }

            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
#if DEBUG
            queryUrl.Append($"/{urlName}/boards/{bid}/discussions?{SecretKeys.ApiKeyUrl}");
#else
            queryUrl.Append($"/{urlName}/boards/{bid}/discussions");
#endif


            var response =
                await
                    MeetupBase.ExecuteQueryAsync<IEnumerable<Discusssions>>(queryUrl, cancellationToken);

            if (response == null)
                throw new HttpRequestException(Resources.ErrorMessage);
            return response;
        }

        /// <summary>
        /// [Authentication required] Listing Group discussion posts
        /// </summary>
        /// <param name="urlName">The urlName path element may be any valid group urlname or domain name.</param>
        /// <param name="bid">he bid path element may be any valid board ID for this group.</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Task&lt;IEnumerable&lt;Discusssion&gt;&gt;</returns>
        /// <exception cref="HttpRequestException">
        ///     Ops! Something went wrong :S. Please try again, if the error persist contact
        ///     with the developer to fix the issue.
        /// </exception>
        public async Task<IEnumerable<Discussion>> Discussion([NotNull] string urlName, [NotNull] string bid,
            [NotNull] string did, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(urlName)) throw new ArgumentException("Argument is null or empty", nameof(urlName));
            if (string.IsNullOrWhiteSpace(urlName)) throw new ArgumentException("Argument is null or whitespace", nameof(urlName));
            if (string.IsNullOrEmpty(bid)) throw new ArgumentException("Argument is null or empty", nameof(bid));
            if (string.IsNullOrWhiteSpace(bid)) throw new ArgumentException("Argument is null or whitespace", nameof(bid));
            if (string.IsNullOrEmpty(did)) throw new ArgumentException("Argument is null or empty", nameof(did));
            if (string.IsNullOrWhiteSpace(did)) throw new ArgumentException("Argument is null or whitespace", nameof(did));

            if (!await MeetupBase.RenewAccessToken())
            {
                throw new HttpRequestException(Resources.ErrorMessage);
            }

            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
#if DEBUG
            queryUrl.Append($"/{urlName}/boards/{bid}/discussions/{did}?{SecretKeys.ApiKeyUrl}");
#else
            queryUrl.Append($"/{urlName}/boards/{bid}/discussions/{did}");
#endif
            var response =
                await
                    MeetupBase.ExecuteQueryAsync<IEnumerable<Discussion>>(queryUrl, cancellationToken);

            if (response == null)
                throw new HttpRequestException(Resources.ErrorMessage);
            return response;
        }
    }
}