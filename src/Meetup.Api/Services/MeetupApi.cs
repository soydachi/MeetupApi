// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    using Annotations;

    public class MeetupApi : IMeetupApi
    {
        static SettingsOauth settings { get; set; }

        public static void ConfigureOauth([NotNull]string clientId, [NotNull]string clientSecret, [CanBeNull]string redirectUrl)
        {
            settings = new SettingsOauth
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                RedirectUrl = redirectUrl
            };
        }

        public static MeetupEvent Event { get; set; } = new MeetupEvent();

    }
}
