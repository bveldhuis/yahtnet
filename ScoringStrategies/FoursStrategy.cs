using System.Linq;
using Yahtnet.Models;

namespace Yahtnet.ScoringStrategies
{
    public class FoursStrategy : IScoringStrategy
    {
        public ScoreType ScoreType => ScoreType.Fours;

        public int GetPoints(ThrowResult throwResult)
        {
            return throwResult.Values.Where(score => score == 4).Sum();
        }
    }
}