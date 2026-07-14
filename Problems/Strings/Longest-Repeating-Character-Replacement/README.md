# Longest Repeating Character Replacement:

This directory contains an implementation of the "Longest Repeating Character Replacement" problem in C#. The implementation uses a sliding window with character frequency counts and maintain a temporal complexity of `O(n)`.

## Problem description

You are given a string `s` and an integer `k`. You can choose any character of the string and change it to any other uppercase English character. You can perform this operation at most `k` times.

Return the length of the longest substring containing the same letter you can get after performing the above operations.

- Example 1:

```
Input: s = "ABAB", k = 2
Output: 4
Explanation: Replace the two 'A's with two 'B's or vice versa.
```

- Example 2:

```
Input: s = "AABABBA", k = 1
Output: 4
Explanation: Replace the one 'A' in the middle with 'B' and form "AABBBBA".
The substring "BBBB" has the longest repeating letters, which is 4.
```

## Solution:

For a window `[i, j)`, the number of replacements needed is:

`windowLength - countOfMostFrequentCharacter`

If that value exceeds `k`, the window is invalid and we shrink from the left.

The algorithm grows `j` continuously and only advances `i` when the window needs more than `k` replacements. The final window length `j - i` is the answer (the maximum valid length seen is preserved because `j` never decreases and `i` only moves when needed).

Let's go through `s = "ABAB"`, `k = 2`:

1. Expand until the whole string is in the window: length `4`, most frequent count `2`
2. Replacements needed: `4 - 2 = 2 <= k`
3. Result length: `4`

## Implementations:

### C# :

```csharp
// Using sliding window technique - Time: O(n)

public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        int i = 0;
        int j = 0;
        int[] cnt = new int[26];
        int n = s.Length;
        
        while (j < n)
        {
            cnt[s[j] - 'A']++;
            j++;
            
            if (j - i - maxElement(cnt, 26) > k)
            {
                cnt[s[i] - 'A']--;
                i++;
            }
        }
        
        return j - i;
    }
    private int maxElement(int[] arr, int length)
    {
        int max = arr[0];
        for (int i = 1; i < length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public int CharacterReplacement(string s, int k)` : Define a public method that returns the longest length after at most `k` replacements.

3. `int[] cnt = new int[26];` : Frequency counts for uppercase letters in the current window.

4. Expand `j`, increment the count of `s[j]`.

5. `if (j - i - maxElement(cnt, 26) > k)` : Window needs more than `k` replacements → shrink from `i`.

6. `return j - i;` : Length of the largest valid window maintained by the pointers.

7. `maxElement` finds the highest frequency in `cnt`.
