using NUnit.Framework;
using Should;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class GameTests_rolling_a_spare_to_start_the_game
    {
        Game game;

        [TestFixtureSetUp]
        public void When_rolling_to_start_the_game()
        {
            var miss = new Roll(3);
            var spare = new Roll(7);

            game = new Game();

            game.AddRoll(miss);
            game.AddRoll(spare);
        }

        [Test]
        public void The_score_should_be_10()
        {
            game.GetScore().ShouldEqual(10);
        }

        [Test]
        public void Frame_status_should_be_frame_complete()
        {
            game.GetFrameStatus().ShouldEqual(FrameStatus.FrameComplete);
        }
    }
}