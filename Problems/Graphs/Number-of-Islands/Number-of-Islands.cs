using System;
using System.Collections.Generic;

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
    // grid
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

class Program
{
    static void Main()
    {
        char[][] grid = new char[][]
        {
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'0', '0', '1', '0', '0'},
            new char[] {'0', '0', '0', '1', '1'}
        };

        Console.WriteLine("Input: grid = [");
        foreach (var row in grid)
        {
            foreach (var cell in row)
            {
                Console.Write(cell + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        int numIslands = sol.NumIslands(grid);

        Console.WriteLine("Output: " + numIslands);
    }
}
