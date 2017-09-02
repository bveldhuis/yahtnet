using System;
using System.Linq;
using Yahtnet.Models;

namespace Yahtnet.ScoringStrategies
{
    public class FourOfAKindStrategy : IScoringStrategy
    {
        public ScoreType ScoreType => ScoreType.FourOfAKind;

        public int GetPoints(ThrowResult throwResult)
        {
            var grouped = throwResult.Values.GroupBy(x => x).OrderByDescending(y => y.Count());
            var firstGroup = grouped.First();
            
            if (firstGroup.Count() >= 4)
            {
                return throwResult.Values.Sum();
            }

            return 0;
        }
    }
}