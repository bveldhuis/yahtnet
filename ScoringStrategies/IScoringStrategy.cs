using Yahtnet.Models;

namespace Yahtnet.ScoringStrategies
{
    public interface IScoringStrategy
    {
        ScoreType ScoreType { get; }
        int GetPoints(ThrowResult throwResult);
    }
}