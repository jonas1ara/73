# Valid Palindrome:

This directory contains an implementation of the "Valid Palindrome" problem in C#. The implementation uses the two-pointer technique to verify a palindrome while ignoring non-alphanumeric characters and maintain a temporal complexity of `O(n)`.

## Problem description

A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string `s`, return `true` if it is a palindrome, or `false` otherwise.

- Example 1:

```
Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.
```

- Example 2:

```
Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.
```

- Example 3:

```
Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
```

## Solution:

You could build a cleaned string and reverse it, but that uses extra space.

Two pointers are enough:

1. Start `i` at the beginning and `j` at the end
2. Skip characters that are not letters or digits
3. Compare the remaining characters in lowercase
4. If any pair differs, return `false`; if the pointers cross, return `true`

Let's go through `s = "A man, a plan, a canal, Panama!"`:

1. Skip spaces and punctuation from both sides
2. Compare `A`/`a`, `m`/`m`, `a`/`a`, ... until the center
3. All matching pairs succeed → `true`

## Implementations:

### C# :

```csharp
// Using two pointers technique - Time: O(n)

public class Solution
{
    public bool IsPalindrome(string s)
    {
        int i = 0, j = s.Length - 1;
        
        while (i < j)
        {
            while (i < j && !char.IsLetterOrDigit(s[i]))
                i++;
            while (i < j && !char.IsLetterOrDigit(s[j]))
                j--;
            if (i < j && char.ToLower(s[i]) != char.ToLower(s[j]))
                return false;

            i++;
            j--;
        }

        return true;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public bool IsPalindrome(string s)` : Define a public method that returns whether `s` is a valid palindrome.

3. `int i = 0, j = s.Length - 1;` : Initialize left and right pointers.

4. Inner while loops skip non-alphanumeric characters on both sides.

5. `char.ToLower(s[i]) != char.ToLower(s[j])` : Case-insensitive comparison of the current pair.

6. Advance both pointers after a successful match.

7. `return true;` : The string is a palindrome.

## Suggested practice 🎯

Same two-pointer scan pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Valid Palindrome II](https://leetcode.com/problems/valid-palindrome-ii/)
- [Palindrome Linked List](https://leetcode.com/problems/palindrome-linked-list/)
- [Shortest Palindrome](https://leetcode.com/problems/shortest-palindrome/)
