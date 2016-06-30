using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    internal class MeetupBase
    {
        internal static string BASE_URL = "https://api.meetup.com";
        internal static int SERVER_TIMEOUT = 30000;

        /// <summary>
        ///     Executes HttpClient query asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryUrl">The query URL.</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <param name="content">The content.</param>
        /// <param name="method">The method .</param>
        /// <returns>Task&lt;T&gt;.</returns>
        internal static async Task<T> ExecuteQueryAsync<T>(StringBuilder queryUrl, CancellationToken cancellationToken, 
            HttpContent content = null, HttpMethodTypes method = HttpMethodTypes.POST)
        {
            var authClient = new HttpClient();
            HttpResponseMessage result;

            var timeoutCancellationToken = new CancellationTokenSource(SERVER_TIMEOUT);

            using (CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCancellationToken.Token))
            {
                switch (method)
                {
                    case HttpMethodTypes.GET:
                        result =
                            await
                                authClient.GetAsync(new Uri(queryUrl.ToString()), cancellationToken);
                        break;
                    case HttpMethodTypes.POST:
                        result =
                            await
                                authClient.PostAsync(new Uri(queryUrl.ToString()), content, cancellationToken);
                        break;
                    case HttpMethodTypes.PUT:
                        result =
                            await
                                authClient.PutAsync(new Uri(queryUrl.ToString()), content, cancellationToken);
                        break;
                    case HttpMethodTypes.DELETE:
                        result =
                            await
                                authClient.DeleteAsync(new Uri(queryUrl.ToString()), cancellationToken);
                        break;
                    default:
                        result = null;
                        break;
                }

                if (result != null && !result.StatusCode.ToString().ToLower().Equals("badgateway") &&
                    !result.StatusCode.ToString().ToLower().Equals("badrequest") &&
                    !result.StatusCode.ToString().ToLower().Equals("serviceunavailable"))
                {
                    var data = await ProcessJson<T>(result.Content);
                    return data;
                }

                return default(T);
            }
        }

        /// <summary>
        ///     Processes the json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content">The content.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        private static async Task<T> ProcessJson<T>(HttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            if (json.StartsWith("<!DOCTYPE html>"))
            {
                return default(T);
            }

            var result = ProcessJson<T>(json);
            return result;
        }

        /// <summary>
        ///     Processes the json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content">The content.</param>
        /// <returns>T</returns>
        private static T ProcessJson<T>(string content)
        {
            var deserializedData = JsonConvert.DeserializeObject<T>(content,
                new IsoDateTimeConverter {DateTimeFormat = "dd/MM/yyyy"});
            return deserializedData;
        }
    }
}