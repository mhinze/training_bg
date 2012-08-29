using NUnit.Framework;
using Should;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class GameTests_rolling_the_first_roll
    {
        Game game;

        [TestFixtureSetUp]
        public void When_rolling_to_start_the_game()
        {
            var roll = new Roll(5);

            game = new Game();

            game.AddRoll(roll);
        }

        [Test]
        public void The_score_should_be_the_number_of_pins_in_that_roll()
        {
            game.GetScore().ShouldEqual(5);
        }

        [Test]
        public void Frame_status_should_be_roll_again_now()
        {
            game.GetFrameStatus().ShouldEqual(FrameStatus.RollAgainNow);
        }
    }
}