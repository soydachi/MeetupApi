// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    internal class SettingsOauth
    {
        internal string ClientId { get; set; }
        internal string ClientSecret { get; set; }
        internal string AuthorizeUrl { get; set; } = "https://secure.meetup.com/oauth2/authorize";
        internal string RedirectUrl { get; set; } = "http://soydachi.com";
        internal string AccessTokenUrl { get; set; } = "https://secure.meetup.com/oauth2/access";
    }
}
