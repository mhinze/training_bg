namespace BowlingGame
{
    public class Frame
    {
        readonly Roll _roll1;
        readonly Roll _roll2;

        public Frame(Roll roll1, Roll roll2 = null)
        {
            _roll1 = roll1;
            _roll2 = roll2;
        }

        public Roll Roll1
        {
            get { return _roll1; }
        }

        public Roll Roll2
        {
            get { return _roll2; }
        }

        int getEffectivePinsForRoll(Roll roll)
        {
            if (roll == null) return 0;
            return roll.GetPins();
        }

        public bool IsFrameComplete()
        {
            return GetFramePins() == 10 || (Roll1 != null && Roll2 != null);
        }

        public int GetFramePins()
        {
            return getEffectivePinsForRoll(Roll1) + getEffectivePinsForRoll(Roll2);
        }


        public bool IsStrike()
        {
            return Roll1.IsStrike();
        }

        public virtual int GetScore()
        {
            return GetFramePins();
        }
    }

    class ScoredFrame : Frame
    {
        readonly int _totalScore;

        public ScoredFrame(Frame frame, int totalScore) : base(frame.Roll1, frame.Roll2)
        {
            _totalScore = totalScore;
        }

        public override int GetScore()
        {
            return _totalScore;
        }
    }
}