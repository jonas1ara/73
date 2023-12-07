using System;

// Using in-place algorithm - Time: O(n^2)
public class Solution
{
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;

        // Transpose matrix
        for (int i = 0; i < n / 2; i++)
        {
            // Swap rows to rotate clockwise
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
        int[][] matrix = {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
        };

        Console.WriteLine("Input: matrix =");
        foreach (int[] row in matrix)
        {
            foreach (int col in row)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        
        Solution sol = new Solution();
        sol.Rotate(matrix);

        Console.WriteLine("Output: ");  
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