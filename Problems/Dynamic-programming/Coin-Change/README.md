# Coin Change:

This directory contains an implementation of the "Coin Change" problem in C#. The implementation uses bottom-up dynamic programming to find the fewest coins needed with temporal complexity `O(n · amount)`.

## Problem description

You are given an integer array `coins` representing coins of different denominations and an integer `amount` representing a total amount of money.

Return the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return `-1`.

You may assume that you have an infinite number of each kind of coin.

- Example 1:

```
Input: coins = [1,2,5], amount = 11
Output: 3
Explanation: 11 = 5 + 5 + 1
```

- Example 2:

```
Input: coins = [2], amount = 3
Output: -1
```

- Example 3:

```
Input: coins = [1], amount = 0
Output: 0
```

## Solution:

Define `dp[t]` = minimum coins to make amount `t`.

Transition:

`dp[t] = min over coin c of (1 + dp[t - c])` when `t >= c`

Base: `dp[0] = 0`. Unreachable amounts stay at a large sentinel (`inf`).

The C# solution uses a 1D DP array over amounts.

Let's go through `coins = [1,2,5]`, `amount = 11`:

1. `dp[0] = 0`
2. Fill amounts 1..11 choosing best coin
3. `dp[11] = 3` (e.g. 5+5+1)

## Implementations:

### C# :

```csharp
// Using bottom-up approach - Time: O(n * amount)

public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        int n = coins.Length;
        int inf = 0x3f3f3f3f;
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
```

1. Initialize all amounts to `inf`, except `dp[0] = 0`.

2. For each target `t`, try every coin and take the minimum.

3. Return `-1` if `dp[amount]` is still `inf`.
