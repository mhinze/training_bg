using System.Collections.Generic;
using System.Linq;

namespace BowlingGame
{
    public class Game
    {
        const int GameLength = 10;
        readonly List<Frame> frames = new List<Frame>();
        Roll firstRollForAFrame;

        public void AddRoll(Roll roll)
        {
            if (roll.IsStrike())
            {
                frames.Add(new Frame(roll));
            }
            else if (firstRollForAFrame == null)
            {
                firstRollForAFrame = roll;
            }
            else
            {
                frames.Add(new Frame(firstRollForAFrame, roll));
                firstRollForAFrame = null;    
            }
        }

        public int GetScore()
        {
            return GetFrames().Sum(x => x.GetScore());
        }

        public FrameStatus GetFrameStatus()
        {
            if (frames.Count == GameLength) return FrameStatus.GameComplete;
            if (!frames.Any()) return FrameStatus.RollAgainNow;
            if (frames.Last().IsFrameComplete())
                if (firstRollForAFrame != null)
                {
                    return FrameStatus.RollAgainNow;
                }
                return FrameStatus.FrameComplete;
            return FrameStatus.RollAgainNow;
        }

        private IEnumerable<int> GetScores()
        {
            if (GetFrameStatus() == FrameStatus.RollAgainNow)
            {
                yield return firstRollForAFrame.GetPins();
            }
            for (var i = 0; i < frames.Count; i++)
            {
                yield return frames[i].GetFramePins();
                if (frames[i].IsStrike())
                {
                    var next = i + 1;
                    if (next < frames.Count)
                    {
                        yield return frames[next].GetFramePins();    
                    }
                }
            }
        }
        
        public IEnumerable<Frame> GetFrames()
        {
            for (int i = 0; i < frames.Count; i++)
            {
                var frame = frames[i];

                if (frame.IsStrike())
                {
                    var nextFrameScore = GetEffectiveFramePins(frames.ElementAtOrDefault(i + 1));
                    var nextNextFrameScore = GetEffectiveFramePins(frames.ElementAtOrDefault(i + 2));

                    yield return new ScoredFrame(frame, frame.GetFramePins() + nextFrameScore + nextNextFrameScore);
                }
                else
                {
                    yield return frame;
                }
            }
            if (firstRollForAFrame != null)
            {
                yield return new Frame(firstRollForAFrame);
            }
        }

        int GetEffectiveFramePins(Frame frame)
        {
            if (frame == null) return 0;
            return frame.GetFramePins();
        }

        public IEnumerable<Frame> GetCompleteFrames()
        {
            return frames.Where(x => x.IsFrameComplete());
        }
    }
}