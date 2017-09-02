using Yahtnet.Models;
using System.Linq;

namespace Yahtnet.ScoringStrategies
{
    public class YahtnetStrategy : IScoringStrategy
    {
        public ScoreType ScoreType { get => ScoreType.Yahtnet; }
        public int GetPoints(ThrowResult throwResult)
        {
            var firstResult = throwResult.Values.First();
            var isEveryValueTheSame = throwResult.Values.All(val => val == firstResult);

            if (isEveryValueTheSame)
            {
                return 50;
            }

            return 0;
        }
    }
}