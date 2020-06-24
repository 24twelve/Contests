using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeJune.Task7
{
    public class CoinChangeCalculatorTests
    {
        [Test]
        public void TestExample()
        {
            const int amount = 5;
            var coins = new[] {1, 2, 5};
            CoinChangeCalculator.CalculateNumberOfChangeCombinations(amount, coins).Should().Be(4);
        }

        [Test]
        public void TestSimple()
        {
            const int amount = 2;
            var coins = new[] {1, 2};
            CoinChangeCalculator.CalculateNumberOfChangeCombinations(amount, coins).Should().Be(2);
        }

        [Test]
        public void TestDuplicates()
        {
            const int amount = 3;
            var coins = new[] {1, 2};
            CoinChangeCalculator.CalculateNumberOfChangeCombinations(amount, coins).Should().Be(2);
        }
    }
}