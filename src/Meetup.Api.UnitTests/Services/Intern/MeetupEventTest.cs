using System.Threading;
using NUnit.Framework;

namespace Meetup.Api.UnitTests.Services.Intern
{
    [TestFixture]
    public class MeetupEventTest
    {
        [Test]
        public void ByIdAsync_NoUrlNameProvided_ShouldThrowArgumentException()
        {
            Assert.That(async () => await MeetupApi.Events.Event("", "231590907", CancellationToken.None), Throws.ArgumentException);
        }

        [Test]
        public void ByIdAsync_NoIdProvided_ShouldThrowArgumentException()
        {
            Assert.That(async () => await MeetupApi.Events.Event("CrossDevelopment-Madrid", "", CancellationToken.None), Throws.ArgumentException);
        }
    }
}
