// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class OauthSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthorizeUrl { get; set; } = "https://secure.meetup.com/oauth2/authorize";
        public string RedirectUrl { get; set; } = "https://soydachi.com";
        public string AccessTokenUrl { get; set; } = "https://secure.meetup.com/oauth2/access";
    }
}