using System.Linq;
using NUnit.Framework;
using Should;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class GameTest_rolling_19_incomplete_rolls
    {
        Game game;

        [TestFixtureSetUp]
        public void Rolling_19_incomplete_rolls()
        {
            game = new Game();

            for (int i = 0; i < 19; i++)
            {
                game.AddRoll(new Roll(2));
            }
        }

        [Test]
        public void Score_should_be_total_of_frame_scores()
        {
            game.GetScore().ShouldEqual(38);
        }

        [Test]
        public void Frame_status_should_be_game_complete()
        {
            game.GetFrameStatus().ShouldEqual(FrameStatus.RollAgainNow);
        }

        [Test]
        public void Should_have_9_complete_frames()
        {
            game.GetCompleteFrames().Count().ShouldEqual(9);
        }
    }
}