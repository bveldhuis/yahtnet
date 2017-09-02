using System.Linq;
using Yahtnet.Models;

namespace Yahtnet.ScoringStrategies
{
    public class ThreesStrategy : IScoringStrategy
    {
        public ScoreType ScoreType => ScoreType.Threes;

        public int GetPoints(ThrowResult throwResult)
        {
            return throwResult.Values.Where(score => score == 3).Sum();
        }
    }
}