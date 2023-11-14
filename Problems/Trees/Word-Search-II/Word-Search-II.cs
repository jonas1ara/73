using System;
using System.Collections.Generic;

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

    public IList<string> FindWords(char[][] A, string[] words)
    {
        foreach (string s in words)
            AddWord(root, s);

        int M = A.Length;
        int N = A[0].Length;
        int[][] dirs = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
        List<string> ans = new List<string>();
        string tmp = "";

        Func<int, int, TrieNode, int> dfs = null;
        dfs = (int x, int y, TrieNode node) =>
        {
            int c = A[x][y] - 'a';
            int cnt = 0;
            if (node.Next[c] == null || node.Next[c].Cnt == 0)
                return 0;
            node = node.Next[c];
            tmp += A[x][y];
            if (node.End)
            {
                ans.Add(tmp);
                cnt++;
                node.End = false;
            }
            A[x][y] = '0';
            for (int i = 0; i < 4; i++)
            {
                int a = x + dirs[i][0];
                int b = y + dirs[i][1];
                if (a < 0 || a >= M || b < 0 || b >= N || A[a][b] == '0')
                    continue;
                cnt += dfs(a, b, node);
            }
            A[x][y] = (char)('a' + c);
            tmp = tmp.Substring(0, tmp.Length - 1);
            node.Cnt -= cnt;
            return cnt;
        };

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                dfs(i, j, root);
            }
        }

        return ans;
    }
}
