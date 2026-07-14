# Palindromic Substrings:

This directory contains an implementation of the "Palindromic Substrings" problem in C#. The implementation uses Manacher's algorithm to count every palindromic substring in linear time `O(n)`.

## Problem description

Given a string `s`, return the number of palindromic substrings in it.

A string is a palindrome when it reads the same backward as forward.

A substring is a contiguous sequence of characters within the string.

- Example 1:

```
Input: s = "abc"
Output: 3
Explanation: Three palindromic strings: "a", "b", "c".
```

- Example 2:

```
Input: s = "aaa"
Output: 6
Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".
```

## Solution:

Expanding around every center counts all palindromes in `O(n^2)`. Manacher reuses previous expansions to reach `O(n)`.

This version builds a transformed string `t = "^*" + c + "*" ... + "$"` so odd and even lengths share one framework, then:

1. Computes the radius `r[i]` of the palindrome centered at each position
2. Adds `r[i] / 2` to the answer, which converts expanded radii into the count of original-string palindromes centered there

Let's go through `s = "abc"`:

1. Transformed centers only cover single letters (no multi-character palindrome)
2. Each letter contributes `1`
3. Total = `3`

For `s = "aaa"`, larger radii contribute extra substrings like `"aa"` and `"aaa"`, totaling `6`.

## Implementations:

### C# :

```csharp
// Using Manacher's algorithm - Time: O(n)

public class Solution
{
    public int CountSubstrings(string s)
    {
        string t = "^*";
        foreach (char c in s)
        {
            t += c;
            t += '*';
        }
        t += '$';

        int n = s.Length;
        int m = t.Length;
        List<int> r = new List<int>(new int[m]);
        r[1] = 1;
        int j = 1;
        int ans = 0;

        for (int i = 2; i <= 2 * n; i++)
        {
            int cur = j + r[j] > i ? Math.Min(r[2 * j - i], j + r[j] - i) : 1;

            while (t[i - cur] == t[i + cur])
                cur++;

            if (i + cur > j + r[j])
                j = i;

            r[i] = cur;
            ans += r[i] / 2;
        }

        return ans;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public int CountSubstrings(string s)` : Define a public method that returns how many palindromic substrings exist.

3. Build transformed string `t` with sentinels `^`, `$` and separators `*`.

4. `r[i]` stores the radius around center `i`.

5. Initialize from the mirror when inside the current right boundary, then expand.

6. Update the active center `j` when a farther boundary is found.

7. `ans += r[i] / 2;` : Convert radius into the count of original palindromes for that center.

8. `return ans;` : Return the total number of palindromic substrings.

### F# :

```fsharp
open System

type Solution() =
    member this.CountSubstrings(s: string) =
        let mutable t = "^*"
        for c in s do
            t <- t + string c + "*"
        t <- t + "$"

        let n = s.Length
        let m = t.Length
        let r = Array.zeroCreate<int> m
        r.[1] <- 1
        let mutable j = 1
        let mutable ans = 0

        for i in 2..2 * n do
            let cur = 
                if j + r.[j] > i then
                    Math.Min(r.[2 * j - i], j + r.[j] - i)
                else
                    1

            let mutable curVar = cur
            while t.[i - curVar] = t.[i + curVar] do
                curVar <- curVar + 1

            if i + curVar > j + r.[j] then
                j <- i

            r.[i] <- curVar
            ans <- ans + r.[i] / 2

        ans
```

1. `type Solution() =` : Define a class-like type called `Solution`.

2. `let mutable t = "^*"` : Build the transformed string with sentinels `^`, `$` and separators `*`, using `<-` to append inside the loop.

3. `let r = Array.zeroCreate<int> m` : `r.[i]` stores the radius around center `i`, same role as the C# `List<int>`.

4. `for i in 2..2 * n do` : Inclusive range walks every transformed center.

5. `let cur = if ... then ... else 1` : Initialize from the mirror when inside the current right boundary, then expand from there.

6. `let mutable curVar = cur` : Named `curVar` to avoid clashing with the `cur` binding; expanded with a `while` loop instead of a C-style `for`.

7. `if i + curVar > j + r.[j] then j <- i` : Update the active center `j` when a farther boundary is found.

8. `ans` : Last expression of the member, returned implicitly as the total number of palindromic substrings.
