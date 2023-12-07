using System;
using System.Collections.Generic;

// Using spiral iterative traversals - Time: O(m⋅n)
public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0)
        {
            return new List<int>();
        }

        List<int> ans = new List<int>();

        int m = matrix.Length; 
        int n = matrix[0].Length;

        for (int i = 0; ans.Count < m * n; i++)
        {
            for (int j = i; j < n - i; j++)
            {
                ans.Add(matrix[i][j]);
            }

            for (int j = i + 1; j < m - i; j++)
            {
                ans.Add(matrix[j][n - i - 1]);
            }

            if (m - i - 1 != i)
            {
                for (int j = n - i - 2; j >= i; j--)
                {
                    ans.Add(matrix[m - i - 1][j]);
                }
            }

            if (n - i - 1 != i)
            {
                for (int j = m - i - 2; j > i; j--)
                {
                    ans.Add(matrix[j][i]);
                }
            }
        }

        return ans;
    }
}

class Program
{
    static void Main(string [] args)
    {
        int[][] matrix = new int[][] {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
        };

        Console.WriteLine("Input: matrix =");
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        Solution sol = new Solution();
        IList<int> ans = sol.SpiralOrder(matrix);

        Console.WriteLine("Output: " + string.Join(", ", ans));
    }
}

