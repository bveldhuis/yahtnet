using System.Linq;
using Yahtnet.Models;

namespace Yahtnet.ScoringStrategies
{
    public class TwosStrategy : IScoringStrategy
    {
        public ScoreType ScoreType => ScoreType.Twos;

        public int GetPoints(ThrowResult throwResult)
        {
            return throwResult.Values.Where(score => score == 2).Sum();
        }
    }
}