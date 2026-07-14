# Pacific Atlantic Water Flow:

This directory contains an implementation of the "Pacific Atlantic Water Flow" problem in C#. The implementation runs multi-source DFS from both oceans with temporal complexity `O(m · n)`.

## Problem description

There is an `m x n` rectangular island that borders both the Pacific Ocean and Atlantic Ocean. The Pacific Ocean touches the island's left and top edges, and the Atlantic Ocean touches the island's right and bottom edges.

The island is partitioned into a grid of square cells. You are given an `m x n` integer matrix `heights` where `heights[r][c]` represents the height above sea level of the cell at coordinate `(r, c)`.

The island receives a lot of rain, and the rain water can flow to neighboring cells directly north, south, east, and west if the neighboring cell's height is less than or equal to the current cell's height. Water can flow from any cell adjacent to an ocean into the ocean.

Return a 2D list of grid coordinates `result` where `result[i] = [ri, ci]` denotes that rain water can flow from cell `(ri, ci)` to both the Pacific and Atlantic oceans.

- Example 1:

```
Input: heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]
Output: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]
```

- Example 2:

```
Input: heights = [[1]]
Output: [[0,0]]
```

## Solution:

Instead of flowing water *downhill to the ocean*, reverse the problem: start from ocean borders and flow *uphill* (to cells with height ≥ current).

1. DFS/BFS from all Pacific-border cells → mark cells reachable from the Pacific
2. DFS/BFS from all Atlantic-border cells → mark cells reachable from the Atlantic
3. Cells marked by **both** can reach both oceans

Pacific borders: left column + top row. Atlantic borders: right column + bottom row.

Neighbor rule when expanding inland: only move to a cell if `heights[next] >= heights[curr]`.

## Implementations:

### C# :

```csharp
// Using depth-first search - Time: O(mn)

public class Solution
{
    private int[][] dirs = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
    private int M, N;

    private void dfs(int[][] heights, int x, int y, int[][] m)
    {
        if (m[x][y] == 1)
            return;

        m[x][y] = 1;

        foreach (var dir in dirs)
        {
            int a = x + dir[0], b = y + dir[1];

            if (a < 0 || a >= M || b < 0 || b >= N || heights[a][b] < heights[x][y])
                continue;

            dfs(heights, a, b, m);
        }
    }

    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        IList<IList<int>> ans = new List<IList<int>>();
        if (heights == null || heights.Length == 0 || heights[0].Length == 0) return ans;
        M = heights.Length;
        N = heights[0].Length;

        int[][] pacific = new int[M][];
        int[][] atlantic = new int[M][];
        for (int i = 0; i < M; i++)
        {
            pacific[i] = new int[N];
            atlantic[i] = new int[N];
        }

        for (int i = 0; i < M; i++)
        {
            dfs(heights, i, 0, pacific);
            dfs(heights, i, N - 1, atlantic);
        }
        for (int j = 0; j < N; j++)
        {
            dfs(heights, 0, j, pacific);
            dfs(heights, M - 1, j, atlantic);
        }

        for (int i = 0; i < M; i++)
            for (int j = 0; j < N; j++)
                if (pacific[i][j] == 1 && atlantic[i][j] == 1)
                    ans.Add(new List<int> { i, j });

        return ans;
    }
}
```

1. Two reachability matrices; intersection is the answer.

2. Reverse-flow DFS only steps to equal-or-higher neighbors.

### F# :

```fsharp
open System

// Using depth-first search - Time: O(mn)

type Solution() =
    let dirs = [| (0, 1); (0, -1); (1, 0); (-1, 0) |]

    let rec dfs (heights: int[][]) (visited: bool[][]) x y m n =
        visited.[x].[y] <- true
        for (dx, dy) in dirs do
            let a, b = x + dx, y + dy
            if a >= 0 && a < m && b >= 0 && b < n && not visited.[a].[b] && heights.[a].[b] >= heights.[x].[y] then
                dfs heights visited a b m n

    member this.PacificAtlantic(heights: int[][]) =
        if isNull heights || heights.Length = 0 || heights.[0].Length = 0 then
            []
        else
            let m = heights.Length
            let n = heights.[0].Length

            let pacific = Array.init m (fun _ -> Array.create n false)
            let atlantic = Array.init m (fun _ -> Array.create n false)

            for i in 0 .. m - 1 do
                dfs heights pacific i 0 m n
                dfs heights atlantic i (n - 1) m n

            for j in 0 .. n - 1 do
                dfs heights pacific 0 j m n
                dfs heights atlantic (m - 1) j m n

            [ for i in 0 .. m - 1 do
                for j in 0 .. n - 1 do
                    if pacific.[i].[j] && atlantic.[i].[j] then
                        yield [ i; j ] ]
```

1. `visited: bool[][]` replaces the C# `int[][] m` sentinel matrix (`0`/`1`) with an explicit `bool`, avoiding the magic-number comparison `m[x][y] == 1`.

2. `dirs = [| (0, 1); (0, -1); (1, 0); (-1, 0) |]` : Directions as tuples instead of `int[]` pairs, destructured directly in the `for (dx, dy) in dirs` loop.

3. `dfs` is a module-level `let rec` closed over nothing external — `m` and `n` are threaded as explicit parameters instead of being private fields (`M`, `N` in C#).

4. The final `[ for i in ... do for j in ... do if ... then yield [i; j] ]` : A list comprehension replaces the nested `for` loops with `ans.Add(...)`, building the result list declaratively.

## Suggested practice 🎯

Same multi-source flood-fill pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Trapping Rain Water II](https://leetcode.com/problems/trapping-rain-water-ii/)
- [Surrounded Regions](https://leetcode.com/problems/surrounded-regions/)
- [Making A Large Island](https://leetcode.com/problems/making-a-large-island/)
