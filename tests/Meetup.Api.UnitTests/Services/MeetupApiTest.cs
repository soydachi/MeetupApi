using System;
using Xunit;

namespace Meetup.Api.UnitTests.Services
{
    public class MeetupApiTest
    {
        [Fact]
        public void ConfigureOauth_NoClientIdProvided_ShouldThrowArgumentException() => Assert.Throws(typeof(ArgumentException), delegate { MeetupApi.ConfigureOauth("", "ClientSecrect", "RedirectUrl"); });

        [Fact]
        public void ConfigureOauth_NoClientSecretProvided_ShouldThrowArgumentException() => Assert.Throws(typeof(ArgumentException), delegate { MeetupApi.ConfigureOauth("ClientId", "", "RedirectUrl"); });

        [Fact]
        public void ConfigureOauth_NoRedirectUrlProvided_ShouldReturnDefaultValue()
        {
            MeetupApi.ConfigureOauth("ClientId", "ClientSecrect");
            Assert.Same("https://soydachi.com", MeetupApi.OauthSettings.RedirectUrl);
        }

        [Fact]
        public void ConfigureOauth_RedirectUrlProvided_ShouldReturnSameValue()
        {
            MeetupApi.ConfigureOauth("ClientId", "ClientSecrect", "http://customUrlForTest.com");
            Assert.Same("http://customUrlForTest.com", MeetupApi.OauthSettings.RedirectUrl);
        }
    }
}
