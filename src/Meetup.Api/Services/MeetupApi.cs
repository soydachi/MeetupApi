using System;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.Api
{
    public static class MeetupApiExtensions
    {
        public static IHttpClientBuilder AddMeetupApi(this IServiceCollection services, Action<HttpClient>? configureClient = null)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            return services.AddHttpClient<IMeetupClient, MeetupClient>(client =>
            {
                client.BaseAddress = new Uri("https://api.meetup.com");
                configureClient?.Invoke(client);
            });
        }
    }
}