using System;

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
            board[x][y] = '0'; // Mark as visited

            foreach (var dir in dirs)
            {
                int dx = dir[0];
                int dy = dir[1];

                if (DFS(x + dx, y + dy, i + 1)) return true;
            }

            board[x][y] = c; // Restore original value
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

class Program
{
    public static void Main(string[] args)
    {
        char[][] board = new char[][] {
            new char[] { 'A', 'B', 'C', 'E' },
            new char[] { 'S', 'F', 'C', 'S' },
            new char[] { 'A', 'D', 'E', 'E' }
        };

        string word = "ABCCED";

        Console.WriteLine("Input: board = ");
        foreach (char[] row in board)
        {
            foreach (char col in row)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nInput: word = " + word + "\n");
 
        Solution sol = new Solution();
        bool result = sol.Exist(board, word);

        if (result)
        {
            Console.WriteLine("Output: true");
        }
        else
        {
            Console.WriteLine("Output: false");
        }
    }
}
