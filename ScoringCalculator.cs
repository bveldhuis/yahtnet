using Yahtnet.Models;
using System.Linq;
using System.Collections.Generic;
using Yahtnet.ScoringStrategies;

namespace Yahtnet
{
    public class ScoringCalculator
    {
        private List<IScoringStrategy> _scoringStrategies = new List<IScoringStrategy>()
        {
            new YahtnetStrategy(),
            new FullHouseStrategy(),
            new FourOfAKindStrategy(),
            new ThreeOfAKindStrategy(),
            new LargeStreetStrategy(),
            new SmallStreetStrategy(),
            new SixesStrategy(),
            new FivesStrategy(),
            new FoursStrategy(),
            new ThreesStrategy(),
            new TwosStrategy(),
            new OnesStrategy(),
            new ChanceStrategy(),
        };

        public void RemoveScoringStrategy(ScoreType scoreType)
        {
            var scoreStrategyToRemove = _scoringStrategies.Single(s => s.ScoreType == scoreType);
            _scoringStrategies.Remove(scoreStrategyToRemove);
        }

        public Score CalculateMaxScore(ThrowResult throwResult)
        {
            foreach (var strategy in _scoringStrategies)
            {
                var points = strategy.GetPoints(throwResult);
                if (points > 0)
                {
                    return new Score
                    {
                        ScoreType = strategy.ScoreType,
                        Points = points
                    };
                }
            }

            // No result
            return new Score 
            {
                ScoreType = _scoringStrategies.Last().ScoreType,
                Points = 0
            };
        } 
    }
}