# Alien Dictionary:

This directory contains an implementation of the "Alien Dictionary" problem in C#. Letter order constraints form a directed graph; DFS topological sort recovers a valid order with temporal complexity `O(V + E)`.

> Premium problem (LeetCode 269). Description included for offline study.

## Problem description

There is a new alien language that uses the English alphabet. However, the order among the letters is unknown to you.

You are given a list of strings `words` from the alien language's dictionary, where the strings in `words` are sorted lexicographically by the rules of this new language.

Return a string of the unique letters in the new alien language sorted in lexicographically increasing order by the new language's rules. If there is no solution, return `""`. If there are multiple solutions, return any of them.

- Example 1:

```
Input: words = ["wrt","wrf","er","ett","rftt"]
Output: "wertf"
```

- Example 2:

```
Input: words = ["z","x"]
Output: "zx"
```

- Example 3:

```
Input: words = ["z","x","z"]
Output: ""
Explanation: The order is invalid because of a cycle.
```

## Solution:

1. **Collect all unique letters** as graph nodes
2. **Compare consecutive words** to find the first differing character pair:
   - `words[i-1][j] → words[i][j]` means the earlier letter comes **before** the later one
   - If a longer word is a prefix of a shorter previous word (invalid dictionary), return `""`
3. **DFS topological sort** with states: `-1` not visited, `0` visiting, `1` done
   - Cycle (revisit a `0` node) → invalid → `""`
   - Append letter after exploring neighbors (post-order), then reverse for correct order

For `["wrt","wrf","er","ett","rftt"]` sample constraints include `t→f`, `w→e`, `r→t`, `e→r`, yielding an order such as `wertf`.

## Implementations:

### C# :

```csharp
// Using topological sort - Time: O(V + E)

public class Solution
{
    private Dictionary<int, HashSet<int>> graph;
    private int[] state;
    private string ans;

    private bool dfs(int u)
    {
        if (state[u] == 0) return false; // cycle
        if (state[u] == 1) return true;  // done

        state[u] = 0;
        foreach (int v in graph[u])
        {
            if (!dfs(v)) return false;
        }

        ans += (char)('a' + u);
        state[u] = 1;
        return true;
    }

    public Solution()
    {
        state = Enumerable.Repeat(-1, 26).ToArray();
        graph = new Dictionary<int, HashSet<int>>();
    }

    public string AlienOrder(string[] words)
    {
        foreach (var s in words)
            foreach (char c in s)
                graph[c - 'a'] = new HashSet<int>();

        for (int i = 1; i < words.Length; i++)
        {
            int j = 0;
            for (; j < Math.Min(words[i - 1].Length, words[i].Length); j++)
            {
                if (words[i - 1][j] == words[i][j]) continue;
                graph[words[i - 1][j] - 'a'].Add(words[i][j] - 'a');
                break;
            }
            if (j == words[i].Length && j < words[i - 1].Length) return "";
        }

        foreach (var entry in graph)
        {
            if (!dfs(entry.Key)) return "";
        }

        char[] ansArray = ans.ToCharArray();
        Array.Reverse(ansArray);

        return ansArray.Length == graph.Count ? new string(ansArray) : "";
    }
}
```

1. Edges encode “must come before” between letters.

2. Post-order append + reverse is classic DFS topological order.
