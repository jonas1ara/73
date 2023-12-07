using System;

// Using in-place algorithm - Time: O(m⋅n)
public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        bool[] row = new bool[m];
        bool[] col = new bool[n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                row[i] = row[i] || matrix[i][j] == 0;
                col[j] = col[j] || matrix[i][j] == 0;
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (row[i] || col[j])
                {
                    matrix[i][j] = 0;
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[][] matrix = new int[][] {
            new int[] { 1, 2, 3 },
            new int[] { 4, 0, 6 },
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
        sol.SetZeroes(matrix);

        Console.WriteLine("Output: ");
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}
