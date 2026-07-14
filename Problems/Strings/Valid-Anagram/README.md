# Valid Anagram:

This directory contains an implementation of the "Valid Anagram" problem in C#. The implementation uses a frequency count array to check if two strings are anagrams and maintain a temporal complexity of `O(n)`.

## Problem description

Given two strings `s` and `t`, return `true` if `t` is an anagram of `s`, and `false` otherwise.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

- Example 1:

```
Input: s = "anagram", t = "nagaram"
Output: true
```

- Example 2:

```
Input: s = "rat", t = "car"
Output: false
```

## Solution:

One intuitive way is to sort both strings and compare them, which costs `O(n log n)`.

Since the inputs use lowercase English letters, we can count character frequencies with an array of size 26:

1. Increment the count for every character in `s`
2. Decrement the count for every character in `t`
3. If every count ends at zero, both strings use the same letters with the same frequencies

Let's go through `s = "anagram"`, `t = "nagaram"`:

1. After counting `s`: `a:3, n:1, g:1, r:1, m:1`
2. After subtracting `t`: all counts return to `0`
3. Result: `true`

## Implementations:

### C# :

```csharp
// Using an array - Time: O(n)

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        int[] cnt = new int[26];

        foreach (char c in s)
            cnt[c - 'a']++;

        foreach (char c in t)
            cnt[c - 'a']--;

        foreach (int n in cnt)
        {
            if (n != 0)
            {
                return false;
            }
        }

        return true;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public bool IsAnagram(string s, string t)` : Define a public method that returns whether `t` is an anagram of `s`.

3. `int[] cnt = new int[26];` : Create a frequency array for letters `a` to `z`.

4. `foreach (char c in s) cnt[c - 'a']++;` : Count characters from `s`.

5. `foreach (char c in t) cnt[c - 'a']--;` : Subtract characters from `t`.

6. `if (n != 0) return false;` : Any non-zero count means the frequencies do not match.

7. `return true;` : All counts are zero, so the strings are anagrams.

## Suggested practice 🎯

Same character frequency counting pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Find All Anagrams in a String](https://leetcode.com/problems/find-all-anagrams-in-a-string/)
- [Ransom Note](https://leetcode.com/problems/ransom-note/)
- [Isomorphic Strings](https://leetcode.com/problems/isomorphic-strings/)
