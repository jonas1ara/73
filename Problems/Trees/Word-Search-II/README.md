# Word Search II:

This directory contains an implementation of the "Word Search II" problem in C#. Words are inserted into a trie; the board is explored with DFS pruning using reference counts, with worst-case temporal complexity `O(m · n · 4^L)` where `L` is the maximum word length.

## Problem description

Given an `m x n` `board` of characters and a list of strings `words`, return all words on the board.

Each word must be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once in a word.

- Example 1:

```
Input: board = [["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f","l","v"]], words = ["oath","pea","eat","rain"]
Output: ["eat","oath"]
```

- Example 2:

```
Input: board = [["a","b"],["c","d"]], words = ["abcb"]
Output: []
```

## Solution:

1. **Build a trie** of all words. Each node stores:
   - children for `a`–`z`
   - `End` — a word finishes here
   - `Cnt` — how many words still use this prefix (for pruning)

2. **DFS from every board cell:**
   - If the current letter has no useful trie edge (`null` or `Cnt == 0`), stop
   - Mark the cell as visited (overwrite with a sentinel)
   - If `End` is true, record the word and clear `End` (avoid duplicates)
   - Explore 4 directions
   - Backtrack cell and path string; subtract how many words were found under this node from `Cnt`

3. Return the collected words

For the sample board, paths spelling `oath` and `eat` succeed; `pea` and `rain` do not exist as adjacent paths.

## Implementations:

### C# :

```csharp
// Using Trie - Time: O(m * n * 4^l)

public class TrieNode
{
    public TrieNode[] Next = new TrieNode[26];
    public int Cnt = 0;
    public bool End = false;
}

public class Solution
{
    private TrieNode root = new TrieNode();

    private void AddWord(TrieNode node, string s)
    {
        foreach (char c in s)
        {
            if (node.Next[c - 'a'] == null)
                node.Next[c - 'a'] = new TrieNode();
            node = node.Next[c - 'a'];
            node.Cnt++;
        }
        node.End = true;
    }

    public IList<string> FindWords(char[][] board, string[] words)
    {
        foreach (string s in words)
        {
            AddWord(root, s);
        }

        int m = board.Length, n = board[0].Length;
        int[][] dirs = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
        List<string> ans = new List<string>();
        string tmp = "";

        Func<int, int, TrieNode, int> dfs = null;
        dfs = (int x, int y, TrieNode node) =>
        {
            int c = board[x][y] - 'a';
            int cnt = 0;

            if (node.Next[c] == null || node.Next[c].Cnt == 0)
                return 0;

            node = node.Next[c];
            tmp += board[x][y];

            if (node.End)
            {
                ans.Add(tmp);
                cnt++;
                node.End = false;
            }

            board[x][y] = '0';
            for (int i = 0; i < 4; i++)
            {
                int a = x + dirs[i][0], b = y + dirs[i][1];
                if (a < 0 || a >= m || b < 0 || b >= n || board[a][b] == '0')
                    continue;
                cnt += dfs(a, b, node);
            }

            board[x][y] = (char)('a' + c);
            tmp = tmp.Substring(0, tmp.Length - 1);
            node.Cnt -= cnt;
            return cnt;
        };

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                dfs(i, j, root);

        ans.Reverse();
        return ans;
    }
}
```

1. Trie avoids re-searching dead prefixes.

2. `Cnt` prunes branches after all words under them have been found.
