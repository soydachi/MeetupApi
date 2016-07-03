using System.Threading;
using NUnit.Framework;

namespace Meetup.Api.UnitTests.Services.Intern
{
    [TestFixture]
    public class MeetupBoardsTest
    {
        [Test]
        public void All_NoUrlNameProvided_ShouldThrowArgumentException()
        {
            Assert.That(async () => await MeetupApi.Boards.All("", CancellationToken.None), Throws.ArgumentException);
        }

        [Test]
        public void Discussions_NoUrlNameProvided_ShouldThrowArgumentException()
        {
            Assert.That(async () => await MeetupApi.Boards.Discussions("", "20671181", CancellationToken.None), Throws.ArgumentException);
        }

        [Test]
        public void Discussions_NoBidProvided_ShouldThrowArgumentException()
        {
            Assert.That(async () => await MeetupApi.Boards.Discussions("CrossDevelopment-Madrid", "", CancellationToken.None), Throws.ArgumentException);
        }

        [Test]
        public void Discussion_NoUrlNameProvided_ShouldThrowArgumentException()
        {
            Assert.That(async () => await MeetupApi.Boards.Discussion("", "20671181", "49893227", CancellationToken.None), Throws.ArgumentException);
        }

        [Test]
        public void Discussion_NoBidProvided_ShouldThrowArgumentException()
        {
            Assert.That(async () => await MeetupApi.Boards.Discussion("CrossDevelopment-Madrid", "", "49893227", CancellationToken.None), Throws.ArgumentException);
        }

        [Test]
        public void Discussion_NoDidProvided_ShouldThrowArgumentException()
        {
            Assert.That(async () => await MeetupApi.Boards.Discussion("CrossDevelopment-Madrid", "20671181", "", CancellationToken.None), Throws.ArgumentException);
        }
    }
}
