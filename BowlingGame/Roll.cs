namespace BowlingGame
{
    public class Roll
    {
        readonly int _pins;

        public Roll(int pins)
        {
            _pins = pins;
        }

        public int GetPins()
        {
            return _pins;
        }

        public bool IsStrike()
        {
            return (_pins == 10);
        }
    }
}