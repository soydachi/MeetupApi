using System;
using System.Threading;
using Xunit;

namespace Meetup.Api.UnitTests.Services.Intern
{
    public class MeetupBoardsTest
    {
        [Fact]
        public void All_NoUrlNameProvided_ShouldThrowArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await MeetupApi.Boards.All("", CancellationToken.None));
        }

        [Fact]
        public void Discussions_NoUrlNameProvided_ShouldThrowArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await MeetupApi.Boards.Discussions("", "20671181", CancellationToken.None));
        }

        [Fact]
        public void Discussions_NoBidProvided_ShouldThrowArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await MeetupApi.Boards.Discussions("CrossDevelopment-Madrid", "", CancellationToken.None));
        }

        [Fact]
        public void Discussion_NoUrlNameProvided_ShouldThrowArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await MeetupApi.Boards.Discussion("", "20671181", "49893227", CancellationToken.None));
        }

        [Fact]
        public void Discussion_NoBidProvided_ShouldThrowArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await MeetupApi.Boards.Discussion("CrossDevelopment-Madrid", "", "49893227", CancellationToken.None));
        }

        [Fact]
        public void Discussion_NoDidProvided_ShouldThrowArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await MeetupApi.Boards.Discussion("CrossDevelopment-Madrid", "20671181", "", CancellationToken.None));
        }
    }
}
