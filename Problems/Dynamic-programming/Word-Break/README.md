# Word Break:

This directory contains an implementation of the "Word Break" problem in C#. The implementation uses bottom-up DP with a dictionary set and temporal complexity `O(n^2)` (with dictionary lookup roughly `O(1)` average).

## Problem description

Given a string `s` and a dictionary of strings `wordDict`, return `true` if `s` can be segmented into a space-separated sequence of one or more dictionary words.

Note that the same word in the dictionary may be reused multiple times in the segmentation.

- Example 1:

```
Input: s = "leetcode", wordDict = ["leet","code"]
Output: true
Explanation: Return true because "leetcode" can be segmented as "leet code".
```

- Example 2:

```
Input: s = "applepenapple", wordDict = ["apple","pen"]
Output: true
```

- Example 3:

```
Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
Output: false
```

## Solution:

Let `dp[i] = true` if the prefix `s[0..i)` can be segmented using the dictionary.

Base: `dp[0] = true` (empty prefix).

For each end position `i`, try every length between `minLen` and `maxLen` of dictionary words:

`dp[i] = true` if `dp[i - len]` and `s[i-len .. i)` is in the set.

Using min/max word lengths prunes useless substring checks.

For `s = "leetcode"`, dict `["leet","code"]`:

1. `dp[0] = true`
2. At `i = 4`, substring `"leet"` matches → `dp[4] = true`
3. At `i = 8`, substring `"code"` matches with `dp[4]` → `dp[8] = true`
4. Answer: `true`

## Implementations:

### C# :

```csharp
// Using bottom-up approach - Time: O(n^2)

public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        HashSet<string> st = new HashSet<string>(wordDict);
        int n = s.Length, minLen = int.MaxValue, maxLen = 0;

        foreach (string w in wordDict)
        {
            minLen = Math.Min(minLen, w.Length);
            maxLen = Math.Max(maxLen, w.Length);
        }

        bool[] dp = new bool[n + 1];
        dp[0] = true;

        for (int i = 1; i <= n; i++)
        {
            for (int len = minLen; len <= maxLen && i - len >= 0 && !dp[i]; len++)
            {
                dp[i] = dp[i - len] && st.Contains(s.Substring(i - len, len));
            }
        }

        return dp[n];
    }
}
```

1. Put dictionary words in a `HashSet` for fast lookup.

2. Track min/max word lengths to bound the inner loop.

3. Fill `dp` left to right; stop early for an `i` once true.

4. `return dp[n];` whether the whole string can be segmented.

## Suggested practice 🎯

Same string-segmentation DP pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Word Break II](https://leetcode.com/problems/word-break-ii/)
- [Concatenated Words](https://leetcode.com/problems/concatenated-words/)
- [Palindrome Partitioning](https://leetcode.com/problems/palindrome-partitioning/)
