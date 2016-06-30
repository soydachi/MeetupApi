using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Meetup.Api.Annotations;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class MeetupApi : IMeetupApi
    {
        private static SettingsOauth settings { get; set; }

        public static MeetupEvent Events { get; set; } = new MeetupEvent();

        public static  MeetupBoards Boards { get; set; } = new MeetupBoards();

        public static void ConfigureOauth([NotNull] string clientId, [NotNull] string clientSecret,
            [CanBeNull] string redirectUrl)
        {
            settings = new SettingsOauth
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                RedirectUrl = redirectUrl
            };
        }

        /// <summary>
        ///     Returns the current API service status
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <exception cref="HttpRequestException">
        ///     Ops! Something went wrong :S. Please try again, if the error persist contact
        ///     with the developer to fix the issue.
        /// </exception>
        public async Task<bool> GetStatus(CancellationToken cancellationToken)
        {
            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
            queryUrl.Append("/status/");

            var response =
                await MeetupBase.ExecuteQueryAsync<Meta>(queryUrl, cancellationToken, null, HttpMethodTypes.GET);

            return response.status == "ok";
        }
    }
}