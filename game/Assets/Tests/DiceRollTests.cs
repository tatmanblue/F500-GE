using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using F500;
using F500.RulesEngine;


namespace F500Tests
{
    public class DiceRollTests
    {
        [Test]
        public void SingleDiceRoll()
        {
            DiceRoll roll = new DiceRoll();
            // the default dice settings is 1 dice, 6 sides
            int result = roll.Generate();
            Assert.IsTrue(result > 0);
            Assert.IsTrue(result <= 6);
        }

        /// <summary>
        /// this test runs many generates and ensures the results are always as expected
        /// </summary>
        [Test]
        public void One6SidedDiceAssurances()
        {
            DiceRoll roll = new DiceRoll();
            for (int count = 0; count < 500; count++)
            {
                int result = roll.Generate();
                Assert.IsTrue(result > 0);
                Assert.IsTrue(result <= 6);
            }
        }
        
        [Test]
        public void Two6SidedDiceAssurances()
        {
            DiceRoll roll = new DiceRoll();
            for (int count = 0; count < 500; count++)
            {
                int result = roll.Generate(2, 6);
                Assert.IsTrue(result >= 2);
                Assert.IsTrue(result <= 12);
            }
        }

        [Test]
        public void Three10SidedDiceAssurances()
        {
            // Use the Assert class to test conditions
            DiceRoll roll = new DiceRoll();
            for (int count = 0; count < 500; count++)
            {
                int result = roll.Generate(3, 10);
                Assert.IsTrue(result >= 3);
                Assert.IsTrue(result <= 30);
            }
        }
        
        [Test]
        public void InvalidDiceCount()
        {
            DiceRoll roll = new DiceRoll();
            Assert.Throws<RulesException>(delegate { roll.Generate(-5, 6); });
        }
        
        [Test]
        public void InvalidSidesCount()
        {
            DiceRoll roll = new DiceRoll();
            Assert.Throws<RulesException>(delegate { roll.Generate(1, 2); });
        }
    }
}
