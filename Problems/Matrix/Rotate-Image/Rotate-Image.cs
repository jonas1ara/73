using System;
public class Solution
{
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;

        for (int i = 0; i < n / 2; i++)
        {
            for (int j = i; j < n - i - 1; j++)
            {
                int tmp = matrix[i][j];
                matrix[i][j] = matrix[n - j - 1][i];
                matrix[n - j - 1][i] = matrix[n - i - 1][n - j - 1];
                matrix[n - i - 1][n - j - 1] = matrix[j][n - i - 1];
                matrix[j][n - i - 1] = tmp;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Jagged array
        int[][] matrix = {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
        };

        Console.WriteLine("Before rotate:");

        foreach (int[] row in matrix)
        {
            foreach (int col in row)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("After rotate:");

        new Solution().Rotate(matrix);
        foreach (int[] row in matrix)
        {
            foreach (int col in row)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }
    }
}