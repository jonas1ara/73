using System;
using System.Collections.Generic;

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

        int m = board.Length;
        int n = board[0].Length;
        int[][] dirs = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

        List<string> ans = new List<string>();
        string tmp = "";

        Func<int, int, TrieNode, int> dfs = null;

        dfs = (int x, int y, TrieNode node) =>
        {
            int c = board[x][y] - 'a';
            int cnt = 0;

            if (node.Next[c] == null || node.Next[c].Cnt == 0)
            {
                return 0;
            }

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
                int a = x + dirs[i][0];
                int b = y + dirs[i][1];
                if (a < 0 || a >= m || b < 0 || b >= n || board[a][b] == '0')
                {
                    continue;
                }
                cnt += dfs(a, b, node);
            }

            board[x][y] = (char)('a' + c);
            tmp = tmp.Substring(0, tmp.Length - 1);
            node.Cnt -= cnt;
            
            return cnt;
        };

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dfs(i, j, root);
            }
        }

        ans.Reverse();
        return ans;
    }
}

class Program
{
    static void PrintBoard(char[][] board)
    {
        foreach (var row in board)
        {
            Console.Write("[");
            foreach (var c in row)
            {
                Console.Write(c);
                if (c != row[row.Length - 1])
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]");
            if (row != board[board.Length - 1])
            {
                Console.Write(", ");
            }
        }
    }

    static void PrintWords(string[] words)
    {
        foreach (var word in words)
        {
            Console.Write(word);
            if (word != words[words.Length - 1])
            {
                Console.Write(", ");
            }
        }
    }
    static void Main()
    {
        char[][] board = {
            new char[] { 'o', 'a', 'a', 'n' },
            new char[] { 'e', 't', 'a', 'e' },
            new char[] { 'i', 'h', 'k', 'r' },
            new char[] { 'i', 'f', 'l', 'v' }
        };
        string[] words = { "oath", "pea", "eat", "rain" };

        Console.Write("Input: board = [");
        PrintBoard(board);
        Console.Write("], words = [");
        PrintWords(words);
        Console.WriteLine("]");

        Solution sol = new Solution();
        IList<string> ans = sol.FindWords(board, words);

        Console.Write("Output: [");
        foreach (var word in ans)
        {
            Console.Write(word);
            if (word != ans[ans.Count - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");
    }
}
