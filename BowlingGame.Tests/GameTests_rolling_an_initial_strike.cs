using NUnit.Framework;
using Should;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class GameTests_rolling_an_initial_strike
    {
        Game game;

        [TestFixtureSetUp]
        public void When_rolling_a_strike_to_start_the_game()
        {
            Roll strike = new Roll(10);

            game = new Game();

            game.AddRoll(strike);
        }

        [Test]
        public void The_score_should_be_ten()
        {
            game.GetScore().ShouldEqual(10);
        }

        [Test]
        public void Turn_status_should_be_frame_complete()
        {
            game.GetFrameStatus().ShouldEqual(FrameStatus.FrameComplete);
        }
    }

    [TestFixture]
    public class GameTests_rolling_two_strikes_to_start_the_game
    {
        Game game;

        [TestFixtureSetUp]
        public void When_rolling_a_strike_to_start_the_game()
        {
            Roll strike = new Roll(10);
            Roll anotherStrike = new Roll(10);

            game = new Game();

            game.AddRoll(strike);
            game.AddRoll(anotherStrike);
        }

        [Test]
        public void The_score_should_be_30()
        {
            game.GetScore().ShouldEqual(30);
        }

        [Test]
        public void Turn_status_should_be_frame_complete()
        {
            game.GetFrameStatus().ShouldEqual(FrameStatus.FrameComplete);
        }
    }
}
