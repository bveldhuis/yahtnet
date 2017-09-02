using System;

namespace Yahtnet.Models
{
    public class Dice
    {
        private static readonly Random _random = new Random();
        private int _value;

        public Dice()
        {
            _value = _random.Next(1, 7);
        }

        public void Throw() 
        {
            _value = _random.Next(1, 7);
        }

        public int GetValue()
        {
            return _value;
        }
    }
}