using System;
using System.Collections;
using System.Collections.Generic;
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
        public static OauthSettings OauthSettings { get; set; }

        public static TokenRoot TokenSettings { get; set; }

        public static MeetupEvent Events { get; } = new MeetupEvent();

        public static  MeetupBoards Boards { get; } = new MeetupBoards();

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

            OauthSettings = new OauthSettings
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            if (!string.IsNullOrEmpty(redirectUrl) || !string.IsNullOrWhiteSpace(redirectUrl))
                OauthSettings.RedirectUrl = redirectUrl;
        }

        /// <summary>
        /// Returns the current API service status
        /// </summary>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public static async Task<bool> GetStatus()
        {
            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
            queryUrl.Append("/status/");

            var response =
                await MeetupBase.ExecuteQueryAsync<StatusInfo>(queryUrl, CancellationToken.None);

            return response?.status == "ok";
        }

        /// <summary>
        /// [Authentication required] Returns a list of Meetup group categories
        /// </summary>
        /// <returns>Task&lt;IList&lt;Categories&gt;&gt;</returns>
        public static async Task<Categories> Categories()
        {
            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
#if DEBUG
            queryUrl.Append($"/2/categories?{SecretKeys.ApiKeyUrl}");
#else
            queryUrl.Append("/2/categories");
#endif
            var response =
                await
                    MeetupBase.ExecuteQueryAsync<Categories>(queryUrl, CancellationToken.None);

            if (response == null)
                throw new HttpRequestException(Resources.ErrorMessage);
            return response;
        }

        /// <summary>
        /// Returns Meetup cities. This method supports search by latitude/longitude/radius, by country/state, by query term/zip, or a 
        /// combination of all of these. Location-only searches by lat and lon return all cities within a radius of the provided coordinates. 
        /// Searches with a query return up to 10 cities matching the term, and can be sorted by size or distance to a given coordinate. 
        /// 'smart' ordering can be used to return the match(es) with the highest member_count, unless a smaller size match exists nearby the given 
        /// coordinates. Query searches are supported for country but not country and state
        /// </summary>
        /// <param name="country">A valid country code</param>
        /// <param name="lat">Latitude to search</param>
        /// <param name="lon">Longitude to search</param>
        /// <param name="radius">When searching by lat/lon only, specify a radius to search (default 50 miles)</param>
        /// <returns>Task&lt;IList&lt;Cities&gt;&gt;</returns>
        public static async Task<Cities> Cities(string country, double lat, double lon, int radius)
        {
            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
            queryUrl.Append($"/2/cities?&country={country}&lon={lon}&radius={radius}&lat={lat}");

            var response =
                await
                    MeetupBase.ExecuteQueryAsync<Cities>(queryUrl, CancellationToken.None);

            if (response == null)
                throw new HttpRequestException(Resources.ErrorMessage);
            return response;
        }
    }
}