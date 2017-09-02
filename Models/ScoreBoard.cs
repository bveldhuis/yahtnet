using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtnet.Models
{
    public class ScoreBoard
    {
        public readonly List<Score> _scores = new List<Score>();

        private readonly ScoreType[] _topHalfTypes = new [] 
        {
            ScoreType.Ones,
            ScoreType.Twos,
            ScoreType.Threes,
            ScoreType.Fours,
            ScoreType.Fives,
            ScoreType.Sixes,
        };

        private readonly ScoreType[] _lowerHalfTypes = new [] 
        {
            ScoreType.ThreeOfAKind,
            ScoreType.FourOfAKind,
            ScoreType.FullHouse,
            ScoreType.SmallStreet,
            ScoreType.LargeStreet,
            ScoreType.Yahtnet,
            ScoreType.Chance,
        };

        public void AddScore(Score score)
        {
            if (_scores.Any(s => s.ScoreType == score.ScoreType))
            {
                throw new InvalidOperationException($"You cannot add two scores of ScoreType {score.ScoreType} to the ScoreBoard");
            }

            _scores.Add(score);
        }

        public int? GetPoints(ScoreType scoreType)
        {
            return _scores.FirstOrDefault(s => s.ScoreType == scoreType)?.Points;
        }
        public int GetTopHalfSubScore()
        {
            var subTotal = _scores
                .Where(score => _topHalfTypes.Contains(score.ScoreType))
                .Sum(score => score.Points);

            var bonusPoints = GetBonusPoints();
            if (bonusPoints != null)
            {
                // Add bonus
                subTotal += bonusPoints.Value;
            }

            return subTotal;
        }

        public int GetLowerHalfSubScore()
        {
            return _scores
                .Where(score => _lowerHalfTypes.Contains(score.ScoreType))
                .Sum(score => score.Points);
        }

        public int? GetBonusPoints()
        {
            var topHalfScores = _scores
                .Where(score => _topHalfTypes.Contains(score.ScoreType))
                .ToArray();

            if (topHalfScores.Length == 6)
            {
                return topHalfScores.Sum(score => score.Points) >= 63 ? 35 : 0;
            }

            return null;
        }

        public int GetTotalScore()
        {
            return GetTopHalfSubScore() + GetLowerHalfSubScore();
        }
    }
}