using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Meetup.Api.Annotations;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public interface IMeetupApi
    {
    }

    public class MeetupApi : IMeetupApi
    {
        public static SettingsOauth settings { get; set; }

        public static MeetupEvent Events { get; set; } = new MeetupEvent();

        public static  MeetupBoards Boards { get; set; } = new MeetupBoards();

        /// <summary>
        /// Should be the first call of the <code>MeetupApi</code>. It configures the intern OauthSettings.
        /// </summary>
        /// <param name="clientId">Client Id of your meetup app.</param>
        /// <param name="clientSecret">Client Secret of your meetup app.</param>
        /// <param name="redirectUrl">Redirect url when the Oauth was sucessfully.</param>
        public static void ConfigureOauth([NotNull]string clientId, [NotNull]string clientSecret,
            [CanBeNull]string redirectUrl = null)
        {
            if (string.IsNullOrEmpty(clientId)) throw new ArgumentException("Argument is null or empty", nameof(clientId));
            if (string.IsNullOrEmpty(clientSecret)) throw new ArgumentException("Argument is null or empty", nameof(clientSecret));
            if (string.IsNullOrWhiteSpace(clientId)) throw new ArgumentException("Argument is null or whitespace", nameof(clientId));
            if (string.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentException("Argument is null or whitespace", nameof(clientSecret));

            settings = new SettingsOauth
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            if (!string.IsNullOrEmpty(redirectUrl) || !string.IsNullOrWhiteSpace(redirectUrl))
                settings.RedirectUrl = redirectUrl;
        }

        /// <summary>
        ///     Returns the current API service status
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> GetStatus()
        {
            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
            queryUrl.Append("/status/");

            var response =
                await MeetupBase.ExecuteQueryAsync<Meta>(queryUrl, CancellationToken.None);

            return response?.status == "ok";
        }
    }
}