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
    }
}
