namespace LeetCodeJune.Task7
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
}