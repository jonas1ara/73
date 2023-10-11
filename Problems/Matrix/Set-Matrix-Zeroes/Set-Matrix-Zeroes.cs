using System;
public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        int M = matrix.Length;
        int N = matrix[0].Length;

        bool[] row = new bool[M];
        bool[] col = new bool[N];

        for (int i = 0; i < M; ++i)
        {
            for (int j = 0; j < N; ++j)
            {
                row[i] = row[i] || matrix[i][j] == 0;
                col[j] = col[j] || matrix[i][j] == 0;
            }
        }

        for (int i = 0; i < M; ++i)
        {
            for (int j = 0; j < N; ++j)
            {
                if (row[i] || col[j])
                {
                    matrix[i][j] = 0;
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        // Crear una instancia de la clase Solution
        Solution solution = new Solution();

        // Definir una matriz de ejemplo
        int[][] matrix = new int[][]
        {
            new int[] { 1, 2, 3 },
            new int[] { 4, 0, 6 },
            new int[] { 7, 8, 9 }
        };

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
        
        Console.WriteLine();

        // Llamar al método SetZeroes para establecer los ceros
        solution.SetZeroes(matrix);

        // Imprimir la matriz modificada
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
