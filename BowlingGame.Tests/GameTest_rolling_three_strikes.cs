using System.Linq;
using NUnit.Framework;
using Should;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class GameTest_rolling_three_strikes
    {
        Game game;

        [TestFixtureSetUp]
        public void Rolling_3_strikes()
        {
            game = new Game();

            game.AddRoll(new Roll(10));
            game.AddRoll(new Roll(10));
            game.AddRoll(new Roll(10));
        }

        [Test]
        public void Score_for_first_frame_should_equal_30()
        {
            game.GetFrames().First().GetScore().ShouldEqual(30);
        }

        [Test]
        public void Score_for_second_frame_should_be_20()
        {
            game.GetFrames().ElementAt(1).GetScore().ShouldEqual(20);
        }

        [Test]
        public void Score_for_third_frame_should_be_10()
        {
            game.GetFrames().ElementAt(2).GetScore().ShouldEqual(10);
        }

        [Test]
        public void Total_score_should_be_60()
        {
            game.GetScore().ShouldEqual(60);
        }
    }

    [TestFixture]
    public class GameTest_rolling_three_spares
    {
        Game game;

        [TestFixtureSetUp]
        public void Rolling_3_spares()
        {
            game = new Game();

            game.AddRoll(new Roll(6));
            game.AddRoll(new Roll(4));

            game.AddRoll(new Roll(5));
            game.AddRoll(new Roll(5));

            game.AddRoll(new Roll(8));
            game.AddRoll(new Roll(2));
        }

        [Test]
        public void Score_for_first_frame_should_equal_the_frame_score_plus_pins_in_next_roll()
        {
            game.GetFrames().First().GetScore().ShouldEqual(15);
        }

        [Test]
        public void Score_for_second_frame_should_be_the_frame_score_plus_pins_in_next_roll()
        {
            game.GetFrames().ElementAt(1).GetScore().ShouldEqual(18);
        }

        [Test]
        public void Score_for_third_frame_should_be_the_frame_score()
        {
            game.GetFrames().ElementAt(2).GetScore().ShouldEqual(10);
        }
    }
}