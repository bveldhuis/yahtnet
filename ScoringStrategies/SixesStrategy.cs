using System.Linq;
using Yahtnet.Models;

namespace Yahtnet.ScoringStrategies
{
    public class SixesStrategy : IScoringStrategy
    {
        public ScoreType ScoreType => ScoreType.Sixes;

        public int GetPoints(ThrowResult throwResult)
        {
            return throwResult.Values.Where(score => score == 6).Sum();
        }
    }
}