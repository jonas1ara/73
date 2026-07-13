# Longest Substring Without Repeating Characters:

This directory contains implementations of the "Longest Substring Without Repeating Characters" problem in the C, C++, and C# languages. Each implementation uses a hash map of last-seen indices to track a sliding window and maintain a temporal complexity of `O(n)`.

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

### C++ :

```cpp
// Using hash map - Time: O(n)

class Solution {
public:
    int lengthOfLongestSubstring(std::string s)
    {
        if (s.empty())
            return 0;

        std::unordered_map<char, int> map;
        int maxLen = 0;
        int lastRepeatPos = -1;

        for (int i = 0; i < s.length(); i++)
        {
            if (map.find(s[i]) != map.end() && lastRepeatPos < map[s[i]])
                lastRepeatPos = map[s[i]];
            if (maxLen < i - lastRepeatPos)
                maxLen = i - lastRepeatPos;
            map[s[i]] = i;
        }

        return maxLen;
    }
};
```

1. `class Solution {public: ...};` : Define a public class called `Solution`.

2. `int lengthOfLongestSubstring(std::string s)` : Define a function that returns the longest substring length without repeats.

3. Track last-seen indices in an unordered map and maintain `lastRepeatPos` / `maxLen` as above.

4. `return maxLen;` : Return the best length found.

### C:

```c
// Using hash map - Time: O(n)

int lengthOfLongestSubstring(char *s)
{
    if (s == NULL || *s == '\0')
        return 0;

    int map[256];
    memset(map, -1, sizeof(map));
    int maxLen = 0;
    int lastRepeatPos = -1;

    for (int i = 0; i < strlen(s); i++)
    {
        if (map[s[i]] != -1 && lastRepeatPos < map[s[i]])
            lastRepeatPos = map[s[i]];
        if (maxLen < i - lastRepeatPos)
            maxLen = i - lastRepeatPos;
        map[s[i]] = i;
    }

    return maxLen;
}
```

1. Use a fixed array `map[256]` as a last-seen index table for all character codes.

2. Initialize every entry to `-1` with `memset`.

3. Apply the same window logic as in C# / C++.

4. `return maxLen;` : Return the best length found.
