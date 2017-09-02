using System;
using System.Collections.Generic;

namespace Yahtnet.Models
{
    public class Game
    {
        private readonly ThrowingBucket _throwingBucket = new ThrowingBucket();
        private readonly ScoreBoard _scoreBoard = new ScoreBoard();
        private readonly ScoringCalculator _scoringCalculator = new ScoringCalculator();

        private readonly List<Dice> _dices = new List<Dice>();

        private int _round = 1;
        private int _throw = 1;

        public ScoreBoard ScoreBoard { get => _scoreBoard; }

        public bool CanRethrow { get => _throw < 3; }
        public bool GameEnded { get => _round >= 14; }

        public IReadOnlyList<Dice> Dices 
        {
            get => _dices;
        }

        public Game()
        {
            for (var i = 0; i < 5; i++)
            {
                _dices.Add(new Dice());
            }
        }

        public void Throw()
        {
            if (CanRethrow)
            {
                _throwingBucket.Throw();
                _throw++;
            }
            else 
            {
                throw new InvalidOperationException("You are only allowed three throws each round.");
            }
        }

        public Score GetMaxScore()
        {
            var throwResult = new ThrowResult(_dices);
            return _scoringCalculator.CalculateMaxScore(throwResult);
        }

        public void AddDiceToThrowingBucket(Dice dice)
        {
            _throwingBucket.AddDice(dice);
        }

        public void EndRound()
        {
            var score = GetMaxScore();
            _scoreBoard.AddScore(score);
            _scoringCalculator.RemoveScoringStrategy(score.ScoreType);
            _round++;
            _throw = 0;

            if (!GameEnded)
            {
                foreach (var dice in Dices)
                {
                    _throwingBucket.AddDice(dice);
                }
            }
        }
    }
}