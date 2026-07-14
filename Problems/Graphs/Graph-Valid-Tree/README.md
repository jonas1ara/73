# Graph Valid Tree:

This directory contains an implementation of the "Graph Valid Tree" problem in C#. The implementation uses DFS cycle detection and connectivity checks with temporal complexity `O(n + e)`.

> Premium problem (LintCode / LeetCode 261). Description included for offline study.

## Problem description

Given `n` nodes labeled from `0` to `n - 1` and a list of undirected edges (each edge is a pair of nodes), write a function to check whether these edges make up a valid tree.

- Example 1:

```
Input: n = 5, edges = [[0,1],[0,2],[0,3],[1,4]]
Output: true
```

- Example 2:

```
Input: n = 5, edges = [[0,1],[1,2],[2,3],[1,3],[1,4]]
Output: false
```

## Solution:

An undirected graph is a tree iff:

1. It is **connected** (exactly one component)
2. It is **acyclic**

DFS coloring:

- `-1` unvisited, `0` visiting, `1` visited
- Skip the parent edge when scanning neighbors (undirected)
- Reaching a non-parent node that is still “visiting” or invalid means a cycle
- Count how many times a new DFS starts; must be exactly `1`

Equivalent checks: `edges.length == n - 1` and the graph is connected (or Union-Find with no redundant unions and one component).

## Implementations:

### C# :

```csharp
// Using depth-first search - Time: O(n)

public class Solution
{
    private List<List<int>> graph;
    private List<int> state; // -1 unvisited, 0 visiting, 1 visited

    private bool dfs(int u, int prev = -1)
    {
        if (state[u] != -1) return state[u] == 1;

        state[u] = 0;
        foreach (int v in graph[u])
        {
            if (prev == v) continue;
            if (!dfs(v, u)) return false;
        }

        state[u] = 1;
        return true;
    }

    public bool ValidTree(int n, int[][] edges)
    {
        graph = new List<List<int>>();
        state = new List<int>();

        for (int i = 0; i < n; i++)
        {
            graph.Add(new List<int>());
            state.Add(-1);
        }

        foreach (var e in edges)
        {
            graph[e[0]].Add(e[1]);
            graph[e[1]].Add(e[0]);
        }

        int cnt = 0;

        for (int i = 0; i < n; i++)
        {
            if (state[i] == 1)
                continue;
            if (!dfs(i))
                return false;
            cnt++;
        }

        return cnt == 1;
    }
}
```

1. Bidirectional edges model the undirected graph.

2. `cnt == 1` enforces a single connected component without cycles.
