using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeJune.Tasks
{
    public static class CoinChangeCalculator
    {
        public static int CalculateNumberOfChangeCombinations(int amount, int[] coins)
        {
            var dp = new int[amount + 1];
            dp[0] = 1;
            foreach (var coin in coins)
                for (var i = coin; i <= amount; i++)
                    dp[i] += dp[i - coin];

            return dp[amount];
        }
    }

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