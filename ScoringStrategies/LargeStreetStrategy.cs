using System.Linq;
using Yahtnet.Models;

namespace Yahtnet.ScoringStrategies
{
    public class LargeStreetStrategy : IScoringStrategy
    {
        public ScoreType ScoreType => ScoreType.LargeStreet;

        public int GetPoints(ThrowResult throwResult)
        {
            var distinctNumbers = throwResult.Values.Distinct().Count();
            if (distinctNumbers == 5)
            {
                var orderedValues = throwResult.Values.OrderBy(x => x);
                var firstValue = orderedValues.First();
                var lastValue = orderedValues.Last();
                if (firstValue != 1 || lastValue != 6)
                {
                    return 40;
                }
            }

            return 0;
        }
    }
}