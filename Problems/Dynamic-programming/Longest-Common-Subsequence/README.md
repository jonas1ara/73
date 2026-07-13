# Longest Common Subsequence:

This directory contains implementations of the "Longest Common Subsequence" problem in the C++ and C# languages. Each implementation uses 1D rolling DP tabulation with temporal complexity `O(m·n)` and space `O(min(m,n))`.

## Problem description

Given two strings `text1` and `text2`, return the length of their longest common subsequence. If there is no common subsequence, return `0`.

A subsequence of a string is a new string generated from the original string with some characters (can be none) deleted without changing the relative order of the remaining characters.

- Example 1:

```
Input: text1 = "abcde", text2 = "ace"
Output: 3
Explanation: The longest common subsequence is "ace".
```

- Example 2:

```
Input: text1 = "abc", text2 = "abc"
Output: 3
```

- Example 3:

```
Input: text1 = "abc", text2 = "def"
Output: 0
```

## Solution:

Classic LCS recurrence:

- If `text1[i] == text2[j]`: `dp[i+1][j+1] = dp[i][j] + 1`
- Else: `dp[i+1][j+1] = max(dp[i][j+1], dp[i+1][j])`

This code compresses the 2D table into one array of size `n+1`, ensuring `text2` is the shorter string for less memory. `prev` stores the diagonal value `dp[i][j]` needed when characters match.

For `"abcde"` vs `"ace"`:

1. Matches accumulate for a, c, e
2. Final length = 3

## Implementations:

### C# :

```csharp
// Using tabulation - Time: O(m*n)

public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int m = text1.Length;
        int n = text2.Length;

        if (m < n)
        {
            (m, n) = (n, m);
            (text1, text2) = (text2, text1);
        }

        int[] dp = new int[n + 1];

        for (int i = 0; i < m; i++)
        {
            int prev = 0;

            for (int j = 0; j < n; j++)
            {
                int cur = dp[j + 1];
                if (text1[i] == text2[j])
                {
                    dp[j + 1] = prev + 1;
                }
                else
                {
                    dp[j + 1] = Math.Max(dp[j], dp[j + 1]);
                }
                prev = cur;
            }
        }

        return dp[n];
    }
}
```

1. Swap so `text2` is shorter → smaller DP array.

2. Outer loop over `text1`, inner over `text2`.

3. `prev` is the previous diagonal; `cur` saves the old `dp[j+1]` before overwrite.

4. `return dp[n];` LCS length.

### C++ :

```cpp
// Using tabulation - Time: O(m*n)

class Solution {
public:
    int longestCommonSubsequence(std::string text1, std::string text2)
    {
        int m = text1.size(), n = text2.size();

        if (m < n)
            std::swap(m, n), swap(text1, text2);

        std::vector<int> dp(n + 1);

        for (int i = 0; i < m; i++)
        {
            int prev = 0;

            for (int j = 0; j < n; j++)
            {
                int cur = dp[j + 1];
                if (text1[i] == text2[j])
                {
                    dp[j + 1] = prev + 1;
                }
                else
                {
                    dp[j + 1] = std::max(dp[j], dp[j + 1]);
                }
                prev = cur;
            }
        }

        return dp[n];
    }
};
```

1. Same 1D LCS optimization as C#.

2. Returns the length of the longest common subsequence.
