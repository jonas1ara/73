using System;
using System.Collections.Generic;

public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0)
        {
            return new List<int>();
        }

        List<int> ans = new List<int>();
        int M = matrix.Length, N = matrix[0].Length;
        for (int i = 0; ans.Count < M * N; ++i)
        {
            for (int j = i; j < N - i; ++j)
            {
                ans.Add(matrix[i][j]);
            }

            for (int j = i + 1; j < M - i; ++j)
            {
                ans.Add(matrix[j][N - i - 1]);
            }

            if (M - i - 1 != i)
            {
                for (int j = N - i - 2; j >= i; --j)
                {
                    ans.Add(matrix[M - i - 1][j]);
                }
            }

            if (N - i - 1 != i)
            {
                for (int j = M - i - 2; j > i; --j)
                {
                    ans.Add(matrix[j][i]);
                }
            }
        }
        return ans;
    }

    public  static void Main(string [] args)
    {
        Console.WriteLine("Spiral Matrix");
        int[][] matrix = new int[][] {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
        };
        Console.WriteLine("matrix = ");
        for (int i = 0; i < matrix.Length; ++i)
        {
            Console.WriteLine(string.Join(", ", matrix[i]));
        }

        IList<int> ans = new Solution().SpiralOrder(matrix);

        Console.WriteLine("ans = " + string.Join(", ", ans));

    }
}

