# Decode Ways:

This directory contains implementations of the "Decode Ways" problem in the C++ and C# languages. Each implementation uses bottom-up DP with two rolling variables and temporal complexity `O(n)`.

## Problem description

A message containing letters from `A-Z` can be encoded into numbers using:

`'A' -> "1"`, `'B' -> "2"`, ..., `'Z' -> "26"`.

Given a string `s` containing only digits, return the number of ways to decode it.

- Example 1:

```
Input: s = "12"
Output: 2
Explanation: "AB" (1 2) or "L" (12).
```

- Example 2:

```
Input: s = "226"
Output: 3
Explanation: "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).
```

- Example 3:

```
Input: s = "06"
Output: 0
```

## Solution:

Let `pre1` = ways to decode up to previous position, `pre2` = ways two positions back.

For each index `i`:

1. If `s[i] != '0'`, you can take a single digit → add `pre1`
2. If `s[i-1..i]` forms a number in `10..26`, you can take two digits → add `pre2`
3. Roll: `pre2 = pre1`, `pre1 = cur`

If at any point `pre1` becomes 0, further decoding is impossible.

For `s = "226"`:

1. After '2': 1 way
2. After '22': single + double → 2 ways
3. After '226': single + double → 3 ways

## Implementations:

### C# :

```csharp
// Using bottom-up approach - Time: O(n)

public class Solution
{
    public int NumDecodings(string s)
    {
        int pre2 = 0, pre1 = 1;

        for (int i = 0; i < s.Length && pre1 != 0; i++)
        {
            int cur = 0;

            if (s[i] != '0')
            {
                cur += pre1;
            }

            if (i != 0 && s[i - 1] != '0' && (s[i - 1] - '0') * 10 + s[i] - '0' <= 26)
            {
                cur += pre2;
            }

            pre2 = pre1;
            pre1 = cur;
        }

        return pre1;
    }
}
```

1. `pre1` starts at 1 (empty prefix has one way).

2. Single-digit and two-digit transitions update `cur`.

3. Early stop if `pre1` hits 0 (dead encoding).

4. `return pre1;` number of decodings.

### C++ :

```cpp
// Using bottom-up approach - Time: O(n)

class Solution {
public:
    int numDecodings(std::string s)
    {
        int pre2 = 0, pre1 = 1;

        for (int i = 0; i < s.size() && pre1; i++)
        {
            int cur = 0;
            if (s[i] != '0')
                cur += pre1;

            if (i != 0 && s[i - 1] != '0' && (s[i - 1] - '0') * 10 + s[i] - '0' <= 26)
                cur += pre2;

            pre2 = pre1;
            pre1 = cur;
        }

        return pre1;
    }
};
```

1. Same two-state DP as C#.

2. Handles leading zeros by forbidding single-digit `'0'` and invalid two-digit pairs.
