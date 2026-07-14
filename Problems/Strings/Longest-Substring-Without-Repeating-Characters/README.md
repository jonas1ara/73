# Longest Substring Without Repeating Characters:

This directory contains an implementation of the "Longest Substring Without Repeating Characters" problem in C#. The implementation uses a hash map of last-seen indices to track a sliding window and maintain a temporal complexity of `O(n)`.

## Problem description

Given a string `s`, find the length of the longest substring without repeating characters.

- Example 1:

```
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
```

- Example 2:

```
Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
```

- Example 3:

```
Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
```

## Solution:

A nested-loop search of every substring is `O(n^2)`.

Instead, scan once while remembering the last index where each character appeared:

- `lastRepeatPos` is the rightmost previous index of a repeated character that still affects the current window
- The current valid window is from `lastRepeatPos + 1` to `i`
- Its length is `i - lastRepeatPos`

Whenever a character repeats inside the current window, move `lastRepeatPos` forward to that previous occurrence.

Let's go through `s = "abcabcbb"`:

1. `a` at 0 → length 1
2. `b` at 1 → length 2
3. `c` at 2 → length 3 (`"abc"`)
4. `a` at 3 repeats index 0 → `lastRepeatPos = 0`, length stays 3 (`"bca"`)
5. Continue similarly; best length remains `3`

## Implementations:

### C# :

```csharp
// Using hash map - Time: O(n)

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        var map = new Dictionary<int, int>();
        var maxLen = 0;
        var lastRepeatPos = -1;

        for (int i = 0; i < s.Length; i++)
        {
            if (map.ContainsKey(s[i]) && lastRepeatPos < map[s[i]])
                lastRepeatPos = map[s[i]];
            if (maxLen < i - lastRepeatPos)
                maxLen = i - lastRepeatPos;
            map[s[i]] = i;
        }

        return maxLen;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public int LengthOfLongestSubstring(string s)` : Define a public method that returns the longest substring length without repeating characters.

3. `if (string.IsNullOrEmpty(s)) return 0;` : Handle empty input.

4. `var map = new Dictionary<int, int>();` : Map each character to its last seen index.

5. `lastRepeatPos` tracks the start of the invalid region before the current window.

6. If the current character was seen after `lastRepeatPos`, update `lastRepeatPos`.

7. Update `maxLen` with `i - lastRepeatPos`.

8. Store the current index for `s[i]` and continue.

9. `return maxLen;` : Return the best length found.

## Suggested practice 🎯

Same sliding window pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Longest Substring with At Most Two Distinct Characters](https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/)
- [Fruit Into Baskets](https://leetcode.com/problems/fruit-into-baskets/)
- [Permutation in String](https://leetcode.com/problems/permutation-in-string/)
