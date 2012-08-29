using NUnit.Framework;
using Should;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class GameTests_rolling_20_incomplete_rolls_to_finish_game
    {
        Game game;

        [TestFixtureSetUp]
        public void Rolling_20_incomplete_rolls()
        {
            game = new Game();

            for (int i = 0; i < 20; i++)
            {
                game.AddRoll(new Roll(2));
            }
        }

        [Test]
        public void Score_should_be_total_of_frame_scores()
        {
            game.GetScore().ShouldEqual(40);
        }

        [Test]
        public void Frame_status_should_be_game_complete()
        {
            game.GetFrameStatus().ShouldEqual(FrameStatus.GameComplete);
        }
    }
}
