# Unique Paths:

This directory contains an implementation of the "Unique Paths" problem in C#. The implementation uses bottom-up DP tabulation with temporal complexity `O(m·n)`. A combinatorial `O(n)` alternative is commented in the source files.

## Problem description

There is a robot on an `m x n` grid. The robot is initially located at the top-left corner (i.e., `grid[0][0]`). The robot tries to move to the bottom-right corner (i.e., `grid[m - 1][n - 1]`). The robot can only move either down or right at any point in time.

Given the two integers `m` and `n`, return the number of possible unique paths that the robot can take to reach the bottom-right corner.

- Example 1:

```
Input: m = 3, n = 7
Output: 28
```

- Example 2:

```
Input: m = 3, n = 2
Output: 3
Explanation: right→down→down, down→down→right, down→right→down.
```

## Solution:

Paths into cell `(i, j)` equal paths from left + paths from above.

This implementation walks from the bottom-right backwards using a 1D array `dp` of size `n + 1`:

- Seed `dp[n - 1] = 1` (destination has one trivial "empty" path)
- For each row from bottom to top, for each column from right to left:
  `dp[j] += dp[j + 1]`

After processing all rows, `dp[0]` is the number of paths from the start.

Combinatorial view (commented): choose `n-1` rights among `(m-1)+(n-1)` moves → `C(m+n-2, n-1)`.

For `m = 3`, `n = 2`:

1. Fill DP bottom-up
2. Result: `3`

## Implementations:

### C# :

```csharp
// Using tabulation - Time: O(m*n)

public class Solution
{
    public int UniquePaths(int m, int n)
    {
        int[] dp = new int[n + 1];
        dp[n - 1] = 1;

        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                dp[j] += dp[j + 1];
            }
        }

        return dp[0];
    }
}
```

1. 1D DP where `dp[j]` accumulates paths for column `j`.

2. Nested reverse loops fill the grid implicitly.

3. `return dp[0];` paths from top-left.
