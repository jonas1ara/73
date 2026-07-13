# Encode and Decode Strings:

This directory contains implementations of the "Encode and Decode Strings" problem in the C++ and C# languages. Each implementation serializes a list of strings into one string and deserializes it back using escaping, with temporal complexity `O(n)` over the total number of characters.

## Problem description

Design an algorithm to encode a list of strings to a string. The encoded string is then sent over the network and is decoded back to the original list of strings.

Implement the `encode` and `decode` methods.

Note: The string may contain any possible characters out of 256 valid ASCII characters. Your algorithm should be general enough to work on any possible characters.

- Example 1:

```
Input: ["lint","code","love","you"]
Output: ["lint","code","love","you"]
Explanation: One possible encode result is "lint$code$xcode$...". Decode must recover the original list.
```

- Example 2:

```
Input: ["we", "say", ":", "yes"]
Output: ["we", "say", ":", "yes"]
```

## Solution:

The hard part is choosing a delimiter that cannot be confused with real string content. This solution uses:

- `$x` as an end-of-string marker
- Escaping: a real `$` character is written as `$$`

**Encode:** for each string, write every character, doubling `$` when it appears, then append `$x`.

**Decode:** scan characters:

- Normal character → append to the current string
- `$$` → one literal `$`
- `$` followed by something else (the `$x` marker) → finish the current string

Let's go through `["we", "say"]`:

1. Encode `"we"` → `we$x`
2. Encode `"say"` → `say$x`
3. Full payload: `we$xsay$x`
4. Decode splits on each `$x` → `["we", "say"]`

If a string contains `$`, e.g. `"a$b"`:

1. Encode becomes `a$$b$x`
2. Decode sees `$$` as one `$`, then finishes at `$x` → `"a$b"`

## Implementations:

### C# :

```csharp
// Using string manipulation - Time: O(n)

public class Solution
{
    public string Encode(List<string> strs)
    {
        string ans = string.Empty;
        foreach (string str in strs)
        {
            foreach (char c in str)
            {
                if (c == '$')
                    ans += c;
                ans += c;
            }
            ans += '$';
            ans += 'x';
        }
        return ans;
    }

    public List<string> Decode(string str)
    {
        List<string> ans = new List<string>();
        int i = 0;
        int n = str.Length;

        while (i < n)
        {
            string s = string.Empty;

            for (; i < n; i++)
            {
                if (str[i] != '$')
                {
                    s += str[i];
                }
                else if (i + 1 < n && str[i + 1] == '$')
                {
                    s += str[i++];
                }
                else
                {
                    i += 2;
                    break;
                }
            }
            ans.Add(s);
        }

        return ans;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `Encode(List<string> strs)` : Serialize every string with `$` escaping and `$x` terminators.

3. For each character, if it is `$`, write it twice; always write the character itself.

4. Append `$x` after each string.

5. `Decode(string str)` : Parse the payload back into a list.

6. Non-`$` characters append to the current string.

7. `$$` becomes one `$`.

8. Other `$...` (the `$x` marker) ends the current string (`i += 2` skips `$x`).

9. `return ans;` : Return the reconstructed list.

### C++ :

```cpp
// Using string manipulation - Time: O(n)

class Solution {
public:
    std::string encode(std::vector<std::string> &strs)
    {
        std::string ans;
        for (std::string &str : strs)
        {
            for (char c : str)
            {
                if (c == '$')
                    ans.push_back(c);
                ans.push_back(c);
            }
            ans.push_back('$');
            ans.push_back('x');
        }
        return ans;
    }
    std::vector<std::string> decode(std::string str)
    {
        std::vector<std::string> ans;
        int i = 0, n = str.size();

        while (i < n)
        {
            std::string s;

            for (; i < n; i++)
            {
                if (str[i] != '$')
                    s.push_back(str[i]);
                else if (i + 1 < n && str[i + 1] == '$')
                    s.push_back(str[i++]);
                else
                {
                    i += 2;
                    break;
                }
            }
            ans.push_back(s);
        }

        return ans;
    }
};
```

1. `class Solution {public: ...};` : Define a public class called `Solution`.

2. `encode` writes escaped strings ending with `$x`.

3. `decode` reconstructs each original string by undoing escaping and splitting on `$x`.

4. Return the decoded vector of strings.
