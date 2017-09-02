using System.Linq;
using Yahtnet.Models;

namespace Yahtnet.ScoringStrategies
{
    public class SmallStreetStrategy : IScoringStrategy
    {
        public ScoreType ScoreType => ScoreType.SmallStreet;

        public int GetPoints(ThrowResult throwResult)
        {
            var distinctNumbers = throwResult.Values.Distinct().Count();
            if (distinctNumbers >= 4)
            {
                var orderedValues = throwResult.Values.OrderBy(x => x).ToList();
                var firstValue = orderedValues.First();
                
                // Allowed rows:
                // 1, 2, 3, 4
                // 2, 3, 4, 5
                // 3, 4, 5, 6

                switch (firstValue)
                {
                    case 1:
                        if (orderedValues.Contains(2) && orderedValues.Contains(3) && orderedValues.Contains(4))
                        {
                            return 30;
                        }
                        break;
                    case 2:
                        if (orderedValues.Contains(3) && orderedValues.Contains(4) && orderedValues.Contains(5))
                        {
                            return 30;
                        }
                        break;
                    case 3:
                        if (orderedValues.Contains(4) && orderedValues.Contains(5) && orderedValues.Contains(6))
                        {
                            return 30;
                        }
                        break;
                }
            }

            return 0;
        }
    }
}