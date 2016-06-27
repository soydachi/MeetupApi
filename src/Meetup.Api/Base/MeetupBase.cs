// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    internal class MeetupBase
    {
        internal static string BASE_URL = "https://api.meetup.com";
        internal static int SERVER_TIMEOUT = 30000;

        /// <summary>
        /// Executes HttpClient query asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryUrl">The query URL.</param>
        /// <param name="content">The content.</param>
        /// <param name="method">The method .</param>
        /// <param name="cancellationTokenSource">Cancellation token</param>
        /// <returns>Task&lt;T&gt;.</returns>
        /// <exception cref="HttpRequestException">Http request failed for some reason..</exception>
        internal static async Task<T> ExecuteQueryAsync<T>(StringBuilder queryUrl, HttpContent content = null,
            HttpMethodTypes method = HttpMethodTypes.POST, CancellationTokenSource cancellationTokenSource = null)
        {
            var authClient = new HttpClient();

            if (cancellationTokenSource == null)
                cancellationTokenSource = new CancellationTokenSource();

            try
            {
                cancellationTokenSource.CancelAfter(SERVER_TIMEOUT);
                HttpResponseMessage result;
                switch (method)
                {
                    case HttpMethodTypes.GET:
                        result =
                            await
                                authClient.GetAsync(new Uri(queryUrl.ToString()),
                                    cancellationTokenSource.Token);
                        break;
                    case HttpMethodTypes.POST:
                        result =
                            await
                                authClient.PostAsync(new Uri(queryUrl.ToString()), content,
                                    cancellationTokenSource.Token);
                        break;
                    case HttpMethodTypes.PUT:
                        result =
                            await
                                authClient.PutAsync(new Uri(queryUrl.ToString()), content,
                                    cancellationTokenSource.Token);
                        break;
                    case HttpMethodTypes.DELETE:
                        result =
                            await
                                authClient.DeleteAsync(new Uri(queryUrl.ToString()),
                                    cancellationTokenSource.Token);
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
            }
            catch (TaskCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new HttpRequestException(ex.Message, ex);
#else
                throw new HttpRequestException("Ops! Something went wrong :S. Please try again, if the error persist contact with the developer to fix the issue.", ex);
#endif
            }

            return default(T);
        }

        /// <summary>
        /// Processes the json.
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
        /// Processes the json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content">The content.</param>
        /// <returns>T</returns>
        private static T ProcessJson<T>(string content)
        {
            var deserializedData = JsonConvert.DeserializeObject<T>(content, new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" });
            return deserializedData;
        }
    }
}
