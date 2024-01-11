using System;
using System.Collections.Generic;

public class Solution
{
    private int m, n;
    private int[][] dirs = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

    private void dfs(char[][] grid, int x, int y)
    {
        if (x < 0 || y < 0 || x >= m || y >= n || grid[x][y] != '1') return;

        grid[x][y] = 'x';

        foreach (var dir in dirs)
        {
            dfs(grid, x + dir[0], y + dir[1]);
        }
    }
    // grid
    public int NumIslands(char[][] grid)
    {
        if (grid == null || grid.Length == 0 || grid[0].Length == 0) return 0;

        int ans = 0;
        m = grid.Length;
        n = grid[0].Length;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] != '1') continue;
                ans++;
                dfs(grid, i, j);
            }
        }

        return ans;
    }
}

class Program
{
    static void Main()
    {
        // Constructing the grid
        char[][] grid = new char[][]
        {
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'0', '0', '1', '0', '0'},
            new char[] {'0', '0', '0', '1', '1'}
        };

        // Print grid
        Console.WriteLine("Grid:");
        PrintGrid(grid);

        // Create an instance of the Solution class
        Solution solution = new Solution();

        // Call the NumIslands function
        int numIslands = solution.NumIslands(grid);

        // Print answer
        Console.WriteLine("Number of Islands: " + numIslands);
    }

    // Helper method to print the grid
    static void PrintGrid(char[][] grid)
    {
        foreach (var row in grid)
        {
            foreach (var cell in row)
            {
                Console.Write(cell + " ");
            }
            Console.WriteLine();
        }
    }
}
