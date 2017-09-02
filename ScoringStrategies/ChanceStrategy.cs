using System;
using System.Linq;
using Yahtnet.Models;

namespace Yahtnet.ScoringStrategies
{
    public class ChanceStrategy : IScoringStrategy
    {
        public ScoreType ScoreType { get => ScoreType.Chance; }
        
        public int GetPoints(ThrowResult throwResult)
        {
            var points = throwResult.Values.Sum();
            return points;
        }
    }
}