# Longest Palindromic Substring:

This directory contains implementations of the "Longest Palindromic Substring" problem in the C++ and C# languages. Each implementation uses Manacher's algorithm to find the longest palindromic substring in linear time `O(n)`.

## Problem description

Given a string `s`, return the longest palindromic substring in `s`.

- Example 1:

```
Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.
```

- Example 2:

```
Input: s = "cbbd"
Output: "bb"
```

## Solution:

Expanding around every center is `O(n^2)`. Manacher's algorithm achieves `O(n)` by transforming the string and reusing previously computed palindrome radii.

Main ideas:

1. Build an expanded string with separators (`#`) so odd and even palindromes are handled uniformly
2. Maintain the rightmost palindrome boundary (`rangeMax`) and its center
3. For each new center, initialize its radius from its mirror when possible, then expand
4. Track the center with the largest radius and map it back to the original string

Let's go through `s = "babad"` conceptually:

1. Expanded form looks like `#b#a#b#a#d#`
2. Radii around centers corresponding to `"bab"` / `"aba"` reach length 3
3. Map the best center back → substring `"bab"` (or `"aba"` depending on ties)

## Implementations:

### C# :

```csharp
// Using Manacher's algorithm - Time: O(n)

public class Solution
{
    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrWhiteSpace(s) || s.Length == 1) 
            return s;

        int n2 = s.Length * 2 + 1;
        var s2 = new char[n2];

        for (int i = 0; i < s.Length; i++)
        {
            s2[i * 2] = '#';
            s2[i * 2 + 1] = s[i];
        }
        s2[n2 - 1] = '#';

        var p = new int[n2];
        int rangeMax = 0, center = 0;
        var longestCenter = 0;

        for (int i = 1; i < n2 - 1; i++)
        {
            if (rangeMax > i)
                p[i] = Math.Min(p[center * 2 - i], rangeMax - i);

            while (i - 1 - p[i] >= 0 && i + 1 + p[i] < n2 && s2[i - 1 - p[i]] == s2[i + 1 + p[i]])
                p[i]++;

            if (i + p[i] > rangeMax)
            {
                center = i;
                rangeMax = i + p[i];
            }

            if (p[i] > p[longestCenter])
                longestCenter = i;
        }

        var range = p[longestCenter];
        return s.Substring((longestCenter - range) / 2, range);
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public string LongestPalindrome(string s)` : Define a public method that returns the longest palindromic substring.

3. Early return for empty / single-character strings.

4. Build `s2` by inserting `#` separators around every character.

5. `p[i]` stores the palindrome radius around center `i` in `s2`.

6. Reuse the mirror radius when `i` is inside the current right boundary.

7. Expand while characters on both sides match.

8. Update `center` / `rangeMax` when a farther boundary is found.

9. Track `longestCenter` and convert its range back with `Substring((longestCenter - range) / 2, range)`.

### C++ :

```cpp
// Using Manacher's algorithm - Time: O(n)

class Solution {
public:
    std::string longestPalindrome(std::string s)
    {
        if (s.empty() || s.length() == 1)
            return s;

        int n2 = s.length() * 2 + 1;
        std::vector<char> s2(n2);

        for (int i = 0; i < s.length(); i++)
        {
            s2[i * 2] = '#';
            s2[i * 2 + 1] = s[i];
        }
        s2[n2 - 1] = '#';

        std::vector<int> p(n2, 0);
        int rangeMax = 0, center = 0;
        int longestCenter = 0;

        for (int i = 1; i < n2 - 1; i++)
        {
            if (rangeMax > i)
                p[i] = std::min(p[2 * center - i], rangeMax - i);

            while (i - 1 - p[i] >= 0 && i + 1 + p[i] < n2 && s2[i - 1 - p[i]] == s2[i + 1 + p[i]])
                p[i]++;

            if (i + p[i] > rangeMax)
            {
                center = i;
                rangeMax = i + p[i];
            }

            if (p[i] > p[longestCenter])
                longestCenter = i;
        }

        int range = p[longestCenter];
        return s.substr((longestCenter - range) / 2, range);
    }
};
```

1. `class Solution {public: ...};` : Define a public class called `Solution`.

2. `std::string longestPalindrome(std::string s)` : Define a function that returns the longest palindromic substring.

3. Transform the string, compute radii with Manacher, and map the best center back to `s`.

4. `return s.substr(...);` with the longest range found.
