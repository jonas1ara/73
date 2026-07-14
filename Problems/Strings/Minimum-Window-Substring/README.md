# Minimum Window Substring:

This directory contains an implementation of the "Minimum Window Substring" problem in C#. The implementation uses a sliding window with character need-counts and maintain a temporal complexity of `O(n)`.

## Problem description

Given two strings `s` and `t` of lengths `m` and `n` respectively, return the minimum window substring of `s` such that every character in `t` (including duplicates) is included in the window. If there is no such substring, return the empty string `""`.

The testcases will be generated such that the answer is unique.

- Example 1:

```
Input: s = "ADOBECODEBANC", t = "ABC"
Output: "BANC"
Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.
```

- Example 2:

```
Input: s = "a", t = "a"
Output: "a"
```

- Example 3:

```
Input: s = "a", t = "aa"
Output: ""
Explanation: Both 'a's from t must be included, so no valid window exists.
```

## Solution:

We need the smallest window in `s` that covers all characters of `t`.

Sliding window approach:

1. Count required characters from `t` into `cnt`
2. Expand `j` until the window contains every required character (`matched == t.Length`)
3. While valid, record the window if it is the shortest so far, then shrink from `i`
4. Continue until `j` reaches the end

`cnt` is used as a residual need array: positive means still needed, zero or negative means satisfied / extra.

Let's go through `s = "ADOBECODEBANC"`, `t = "ABC"`:

1. Expand until first covering window appears (e.g. `"ADOBEC"`)
2. Shrink and re-expand, tracking shorter covering windows
3. Best becomes `"BANC"` of length `4`

## Implementations:

### C# :

```csharp
// Using sliding window technique - Time: O(n)

public class Solution
{
    public string MinWindow(string s, string t)
    {
        int[] cnt = new int[128];
        foreach (char c in t)
        {
            cnt[c]++;
        }

        int n = s.Length;
        int i = 0, j = 0, start = -1, minLen = int.MaxValue, matched = 0;

        while (j < n)
        {
            if (cnt[s[j]] > 0)
            {
                matched++;
            }
            cnt[s[j]]--;
            j++;

            while (matched == t.Length)
            {
                if (j - i < minLen)
                {
                    minLen = j - i;
                    start = i;
                }

                if (cnt[s[i]] == 0)
                {
                    matched--;
                }
                cnt[s[i]]++;
                i++;
            }
        }

        return start == -1 ? "" : s.Substring(start, minLen);
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public string MinWindow(string s, string t)` : Define a public method that returns the minimum covering window of `t` inside `s`.

3. `int[] cnt = new int[128];` : ASCII frequency / residual-need array.

4. Count every character of `t`.

5. Expand `j`: if `cnt[s[j]] > 0` before decrement, this character still helps `matched`.

6. When `matched == t.Length`, the window is valid: update `start` / `minLen` if smaller.

7. Shrink from `i`: if `cnt[s[i]]` returns to `0` after increment prep, lose one match.

8. `return start == -1 ? "" : s.Substring(start, minLen);` : Empty string if no window, otherwise the best substring.

## Suggested practice 🎯

Same sliding window with a need/have count pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Permutation in String](https://leetcode.com/problems/permutation-in-string/)
- [Find All Anagrams in a String](https://leetcode.com/problems/find-all-anagrams-in-a-string/)
- [Substring with Concatenation of All Words](https://leetcode.com/problems/substring-with-concatenation-of-all-words/)
