using System;

public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        int N = coins.Length;
        int INF = 0x3f3f3f3f;
        int[] dp = new int[10001];
        Array.Fill(dp, INF);
        dp[0] = 0;

        for (int t = 1; t <= amount; t++)
        {
            for (int i = 0; i < N; i++)
            {
                dp[t] = Math.Min(dp[t], t - coins[i] >= 0 ? 1 + dp[t - coins[i]] : INF);
            }
        }

        return dp[amount] == INF ? -1 : dp[amount];
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] coins = { 1, 2, 5 };
        int target = 11;
        int result = solution.CoinChange(coins, target);
        Console.WriteLine("Minimum number of coins to make " + target + " is: " + result);
    }
}
