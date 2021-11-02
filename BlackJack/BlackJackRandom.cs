using System;

namespace BlackJack
{
    public class BlackJackRandom : IRandom
    {
        private Random random = new();

        public int Next(int max_value) => random.Next(max_value);
    }
}