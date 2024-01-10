using System;
using System.Collections.Generic;

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
        {
            for (int j = 0; j < N; j++)
            {
                if (pacific[i][j] == 1 && atlantic[i][j] == 1)
                {
                    ans.Add(new List<int> { i, j });
                }
            }
        }

        return ans;
    }
}

class Program
{
    static void Main()
    {
        int[][] heights = {
            new int[] {1,2,2,3,5},
            new int[] {3,2,3,4,4},
            new int[] {2,4,5,3,1},
            new int[] {6,7,1,4,5},
            new int[] {5,1,1,2,4}
        };

        Console.Write("Input: [");
        foreach (var row in heights)
        {
            Console.Write("[");
            foreach (var point in row)
            {
                Console.Write($"{point}");
                if (point != row[row.Length - 1])
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]");
            if (row != heights[heights.Length - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        IList<IList<int>> result = sol.PacificAtlantic(heights);

        Console.Write("Output: [");
        foreach (var point in result)
        {
            Console.Write($"[{point[0]}, {point[1]}]");
            if (point != result[result.Count - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");
    }
}
