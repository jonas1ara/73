using System;

// Using bottom-up approach - Time: O(n * amount)

public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        int n = coins.Length;
        int inf = 0x3f3f3f3f; // inf = 1061109567
        int[] dp = new int[10001];
        Array.Fill(dp, inf);
        dp[0] = 0;

        for (int t = 1; t <= amount; t++)
        {
            for (int i = 0; i < n; i++)
            {
                dp[t] = Math.Min(dp[t], t - coins[i] >= 0 ? 1 + dp[t - coins[i]] : inf);
            }
        }

        return dp[amount] == inf ? -1 : dp[amount];
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] coins = { 1, 2, 5 };
        int amount = 11;

        Console.WriteLine("Input: coins = [" + string.Join(", ", coins) + "], amout = " + amount);

        Solution sol = new Solution();
        int result = sol.CoinChange(coins, amount);


        Console.WriteLine("Output: "+ result);
    }
}
