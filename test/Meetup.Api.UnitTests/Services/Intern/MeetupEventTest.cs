using System;
using System.Threading;
using Xunit;

namespace Meetup.Api.UnitTests.Services.Intern
{
    public class MeetupEventTest
    {
        [Fact]
        public void ByIdAsync_NoUrlNameProvided_ShouldThrowArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await MeetupApi.Events.Event("", "231590907", CancellationToken.None));
        }

        [Fact]
        public void ByIdAsync_NoIdProvided_ShouldThrowArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await MeetupApi.Events.Event("CrossDevelopment-Madrid", "", CancellationToken.None));
        }
    }
}
