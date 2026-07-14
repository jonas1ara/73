# Number of Islands:

This directory contains an implementation of the "Number of Islands" problem in C#. The implementation uses depth-first search to flood-fill land cells with temporal complexity `O(m · n)`.

## Problem description

Given an `m x n` 2D binary grid `grid` which represents a map of `'1'`s (land) and `'0'`s (water), return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

- Example 1:

```
Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1
```

- Example 2:

```
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
```

## Solution:

Scan every cell. When you find a `'1'`:

1. Increment the island count
2. DFS from that cell: mark the cell visited (set to `'x'`), then recurse to the 4 neighbors
3. DFS stops on water, out of bounds, or already-visited cells

Each land cell is visited a constant number of times → `O(m · n)`.

For the 3-island example:

1. Top-left block of four `'1'`s → island 1 (all marked)
2. Middle lone `'1'` → island 2
3. Bottom-right two `'1'`s → island 3

## Implementations:

### C# :

```csharp
// Using depth-first search - Time: O(m * n)

public class Solution
{
    private int m, n;
    private int[][] dirs = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

    private void dfs(char[][] grid, int x, int y)
    {
        if (x < 0 || y < 0 || x >= m || y >= n || grid[x][y] != '1')
        {
            return;
        }

        grid[x][y] = 'x';

        foreach (var dir in dirs)
        {
            dfs(grid, x + dir[0], y + dir[1]);
        }
    }

    public int NumIslands(char[][] grid)
    {
        if (grid == null || grid.Length == 0 || grid[0].Length == 0)
        {
            return 0;
        }

        int ans = 0;
        m = grid.Length;
        n = grid[0].Length;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] != '1')
                {
                    continue;
                }

                ans++;
                dfs(grid, i, j);
            }
        }

        return ans;
    }
}
```

1. In-place marking avoids a separate visited matrix.

2. Each new unvisited `'1'` starts a new island.

## Suggested practice 🎯

Same grid flood-fill pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Number of Islands II](https://leetcode.com/problems/number-of-islands-ii/)
- [Max Area of Island](https://leetcode.com/problems/max-area-of-island/)
- [Surrounded Regions](https://leetcode.com/problems/surrounded-regions/)
