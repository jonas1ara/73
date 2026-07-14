# Word Search:

This directory contains an implementation of the "Word Search" problem in C#. The implementation uses DFS backtracking on the board with temporal complexity `O(m·n·4^k)` where `k` is the word length.

## Problem description

Given an `m x n` grid of characters `board` and a string `word`, return `true` if `word` exists in the grid.

The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.

- Example 1:

```
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
Output: true
```

- Example 2:

```
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
Output: true
```

- Example 3:

```
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
Output: false
```

## Solution:

Try every cell as a possible start. From a matching cell, DFS in four directions for the next character.

To avoid reusing a cell, temporarily mark it as visited (overwrite with a sentinel), recurse, then restore it (backtracking).

Base cases:

- Out of bounds or letter mismatch → fail
- Index reaches the last character of the word → success

Let's go through finding `"SEE"`:

1. Start at board `[1][3] = 'S'`
2. Move left/up/down/right looking for `'E'`
3. Continue to next `'E'` without reusing cells
4. Full word matched → `true`

## Implementations:

### C# :

```csharp
// Using Depth-First Search - Time: O(m⋅n⋅4^k)

public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        int m = board.Length;
        int n = board[0].Length;
        int[][] dirs = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

        bool DFS(int x, int y, int i)
        {
            if (x < 0 || x >= m || y < 0 || y >= n || board[x][y] != word[i]) return false;
            if (i + 1 == word.Length) return true;

            char c = board[x][y];
            board[x][y] = '0';

            foreach (var dir in dirs)
            {
                if (DFS(x + dir[0], y + dir[1], i + 1)) return true;
            }

            board[x][y] = c;
            return false;
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (DFS(i, j, 0)) return true;
            }
        }

        return false;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public bool Exist(char[][] board, string word)` : Return whether `word` exists on the board.

3. `dirs` : Four adjacency directions (right, left, down, up).

4. `DFS(x, y, i)` : Try to match `word[i]` at cell `(x, y)`.

5. Mark cell visited, recurse on neighbors for `i + 1`, then restore.

6. Try every start cell; return `true` on the first successful path.

### F# :

```fsharp
open System

type Solution() =
    member this.Exist(board: char[][], word: string) =
        let m = Array.length board
        let n = Array.length board.[0]
        let dirs = [| [| 0; 1 |]; [| 0; -1 |]; [| 1; 0 |]; [| -1; 0 |] |]

        let found = ref false // Mutable flag indicating whether the word was found

        let rec dfs x y i =
            if x < 0 || x >= m || y < 0 || y >= n || board.[x].[y] <> word.[i] then false
            else if i + 1 = word.Length then
                found := true
                true
            else
                let c = board.[x].[y]
                board.[x].[y] <- '0' // Mark as visited

                for dir in dirs do
                    let dx, dy = dir.[0], dir.[1]
                    if not !found && dfs (x + dx) (y + dy) (i + 1) then ()

                board.[x].[y] <- c // Restore original value
                false

        for i = 0 to m - 1 do
            for j = 0 to n - 1 do
                if not !found && dfs i j 0 then ()

        !found
```

1. `type Solution() =` : Define a class-like type called `Solution`.

2. `let dirs = [| [| 0; 1 |]; ... |]` : Four adjacency directions stored as an array of arrays.

3. `let found = ref false` : A `ref` cell gives a mutable box that can be shared and updated from the recursive `dfs` closure.

4. `let rec dfs x y i =` : `rec` is required for a function to call itself; matches the C# local `DFS`.

5. `board.[x].[y] <- '0'` : Mark the cell visited by mutating the board array, then restore it with `<-` after backtracking.

6. `if not !found && dfs (x + dx) (y + dy) (i + 1) then ()` : `!found` dereferences the ref cell; short-circuits remaining directions once the word is found.

7. `!found` : Last expression of the member, returned implicitly as whether `word` exists on the board.

## Suggested practice 🎯

Same DFS backtracking on a grid pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Path with Maximum Gold](https://leetcode.com/problems/path-with-maximum-gold/)
- [Sudoku Solver](https://leetcode.com/problems/sudoku-solver/)
- [N-Queens](https://leetcode.com/problems/n-queens/)
