# Group Anagrams:

This directory contains an implementation of the "Group Anagrams" problem in C#. The implementation sorts each word to build a canonical key and groups words with the same key using a hash map, with overall complexity `O(N K log K)` where `N` is the number of strings and `K` is the maximum string length.

## Problem description

Given an array of strings `strs`, group the anagrams together. You can return the answer in any order.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

- Example 1:

```
Input: strs = ["eat","tea","tan","ate","nat","bat"]
Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
```

- Example 2:

```
Input: strs = [""]
Output: [[""]]
```

- Example 3:

```
Input: strs = ["a"]
Output: [["a"]]
```

## Solution:

Two strings are anagrams if and only if they contain the same characters with the same frequencies. Sorting a string produces a stable key for that multiset of characters.

Algorithm:

1. For each string, create a key by sorting its characters
2. Use a map from key → group index
3. Append the original string to the corresponding group

Let's go through `["eat","tea","tan","ate","nat","bat"]`:

1. `"eat"` → key `"aet"` → new group 0 → `[["eat"]]`
2. `"tea"` → key `"aet"` → group 0 → `[["eat","tea"]]`
3. `"tan"` → key `"ant"` → new group 1
4. `"ate"` → key `"aet"` → group 0
5. `"nat"` → key `"ant"` → group 1
6. `"bat"` → key `"abt"` → new group 2

Result groups: anagrams are clustered together.

## Implementations:

### C# :

```csharp
// Using hash map - Time complexity: O(NKlogK)

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, int> m = new Dictionary<string, int>();
        List<IList<string>> ans = new List<IList<string>>();

        for (int i = 0; i < strs.Length; i++)
        {
            string s = strs[i];
            string key = new string(s.ToCharArray());
            char[] keyChars = key.ToCharArray();
            Array.Sort(keyChars);
            key = new string(keyChars);

            if (!m.ContainsKey(key))
            {
                m[key] = ans.Count;
                ans.Add(new List<string>());
            }

            ans[m[key]].Add(s);
        }

        ans.Reverse();
        return ans;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public IList<IList<string>> GroupAnagrams(string[] strs)` : Define a public method that groups anagrams together.

3. `Dictionary<string, int> m` : Maps a sorted key to the index of its group in `ans`.

4. Sort the characters of each string to obtain `key`.

5. If the key is new, create a new group and store its index in the dictionary.

6. `ans[m[key]].Add(s);` : Append the original string to its group.

7. `ans.Reverse(); return ans;` : Reverse groups (order does not matter for correctness) and return.

## Suggested practice 🎯

Same hashing by sorted/counted signature pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Find All Anagrams in a String](https://leetcode.com/problems/find-all-anagrams-in-a-string/)
- [Group Shifted Strings](https://leetcode.com/problems/group-shifted-strings/)
- [Valid Anagram](https://leetcode.com/problems/valid-anagram/)
