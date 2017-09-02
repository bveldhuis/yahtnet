using System;
using System.Linq;
using Yahtnet.Models;

namespace Yahtnet.ScoringStrategies
{
    public class OnesStrategy : IScoringStrategy
    {
        public ScoreType ScoreType => ScoreType.Ones;

        public int GetPoints(ThrowResult throwResult)
        {
            return throwResult.Values.Where(score => score == 1).Sum();
        }
    }
}