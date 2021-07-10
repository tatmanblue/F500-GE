using System;

namespace F500.RulesEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class DiceRoll
    {
        private readonly Random _generator;

        public DiceRoll()
        {
            // randomly generate some kind of seed to manipulate the randomization a bit more
            Random start = new Random();
            int seed = (int) start.NextDouble() * 100;
            _generator = new Random(seed);
        }
        
        public int Generate(int dice = 1, int sides = 6)
        {
            int result = 0;
            // check that input is valid
            if (dice < 1) throw new RulesException("invalid number of dice used");
            if (sides < 3) throw new RulesException("invalid number of sides used");

            for (int count = 1; count <= dice; count++)
            {
                int diceValue = _generator.Next(1, sides + 1);
                // Next is known to fail once in a while
                if (diceValue > sides) throw new RulesException("internal error");
                result += diceValue;
            }

            // this error would never occur:  TODO: remove
            // if (result > sides * dice) throw new RulesException("internal error");

            return result;
        }
    }
}