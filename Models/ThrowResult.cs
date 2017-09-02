using System.Collections.Generic;

namespace Yahtnet.Models
{
    public class ThrowResult
    {
        public List<Dice> Dices { get; private set; }

        public ThrowResult(List<Dice> dices)
        {
            Dices = dices;
        }

        public IEnumerable<int> Values
        {
            get 
            {
                foreach (var dice in Dices)
                {
                    yield return dice.GetValue();
                }
            }
        }
    }
}