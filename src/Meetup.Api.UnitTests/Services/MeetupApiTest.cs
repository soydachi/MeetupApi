using System;
using NUnit.Framework;

namespace Meetup.Api.UnitTests.Services
{
    [TestFixture]
    public class MeetupApiTest
    {
        [Test]
        public void ConfigureOauth_NoClientIdProvided_ShouldThrowArgumentException()
        {
            Assert.Throws(typeof(ArgumentException), delegate { MeetupApi.ConfigureOauth("", "ClientSecrect", "RedirectUrl"); });
        }

        [Test]
        public void ConfigureOauth_NoClientSecretProvided_ShouldThrowArgumentException()
        {
            Assert.Throws(typeof(ArgumentException), delegate { MeetupApi.ConfigureOauth("ClientId", "", "RedirectUrl"); });
        }

        [Test]
        public void ConfigureOauth_NoRedirectUrlProvided_ShouldReturnDefaultValue()
        {
            MeetupApi.ConfigureOauth("ClientId", "ClientSecrect");
            Assert.AreSame("http://soydachi.com", MeetupApi.OauthSettings.RedirectUrl);
        }

        [Test]
        public void ConfigureOauth_RedirectUrlProvided_ShouldReturnSameValue()
        {
            MeetupApi.ConfigureOauth("ClientId", "ClientSecrect", "http://customUrlForTest.com");
            Assert.AreSame("http://customUrlForTest.com", MeetupApi.OauthSettings.RedirectUrl);
        }
    }
}
