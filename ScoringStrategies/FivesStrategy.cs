using System.Linq;
using Yahtnet.Models;

namespace Yahtnet.ScoringStrategies
{
    public class FivesStrategy : IScoringStrategy
    {
        public ScoreType ScoreType => ScoreType.Fives;

        public int GetPoints(ThrowResult throwResult)
        {
            return throwResult.Values.Where(score => score == 5).Sum();
        }
    }
}