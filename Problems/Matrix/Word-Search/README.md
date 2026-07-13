# Word Search:

This directory contains implementations of the "Word Search" problem in the C++ and C# languages. Each implementation uses DFS backtracking on the board with temporal complexity `O(m·n·4^k)` where `k` is the word length.

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

### C++ :

```cpp
// Using Depth-First Search - Time: O(m⋅n⋅4^k)

class Solution {
public:
    bool exist(std::vector<std::vector<char>> &board, std::string word)
    {
        int m = board.size();
        int n = board[0].size();
        int dirs[4][2] = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};

        std::function<bool(int, int, int)> dfs = [&](int x, int y, int i)
        {
            if (x < 0 || x >= m || y < 0 || y >= n || board[x][y] != word[i])
                return false;
            if (i + 1 == static_cast<int>(word.size()))
                return true;

            char c = board[x][y];
            board[x][y] = 0;

            for (auto &[dx, dy] : dirs)
            {
                if (dfs(x + dx, y + dy, i + 1))
                    return true;
            }

            board[x][y] = c;
            return false;
        };

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (dfs(i, j, 0))
                    return true;
            }
        }
        return false;
    }
};
```

1. `class Solution {public: ...};` : Define a public class called `Solution`.

2. Lambda `dfs` performs the same backtracking search as C#.

3. Mark with `0`, explore neighbors, restore original char.

4. `return false;` if no starting cell leads to a full match.
