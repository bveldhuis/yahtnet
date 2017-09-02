using System.Collections.Generic;
using System.Linq;

namespace Yahtnet.Models
{    
    public class ThrowingBucket
    {
        private readonly List<Dice> _dices = new List<Dice>();

        public void AddDice(Dice dice)
        {
            if (!_dices.Contains(dice))
            {
                _dices.Add(dice);
            }
        }

        public void RemoveDice(Dice dice)
        {
            if (_dices.Contains(dice))
            {
                _dices.Remove(dice);
            }
        }

        public void Clear()
        {
            _dices.Clear();
        }

        public void Throw()
        {
            foreach (var dice in _dices)
            {
                var oldVal = dice.GetValue();
                dice.Throw();
            }

            _dices.Clear();
        }
    }
}