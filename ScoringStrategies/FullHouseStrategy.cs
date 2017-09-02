using System.Linq;
using Yahtnet.Models;

namespace Yahtnet.ScoringStrategies
{
    public class FullHouseStrategy : IScoringStrategy
    {
        public ScoreType ScoreType => ScoreType.FullHouse;

        public int GetPoints(ThrowResult throwResult)
        {
            var grouped = throwResult.Values.GroupBy(x => x).OrderByDescending(y => y.Count());
            var firstGroup = grouped.First();
            var lastGroup = grouped.Last();

            // If a default number of 5 dices are in the game, Ceiling(5 / 2) == 3
            var largestGroupNumber = System.Math.Ceiling(throwResult.Values.Count() / 2m);
            // If a default number of 5 dices are in the game, Floor(5 / 2) == 2
            var smallestGroupNumber = System.Math.Floor(throwResult.Values.Count() / 2m);

            if (firstGroup.Count() == largestGroupNumber && lastGroup.Count() == smallestGroupNumber)
            {
                return 25;
            }

            return 0;
        }
    }
}