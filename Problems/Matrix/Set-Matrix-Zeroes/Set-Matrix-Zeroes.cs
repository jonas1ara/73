public class Solution 
{
    public void SetZeroes(int[][] matrix) 
    {
        int M = matrix.Length;
        int N = matrix[0].Length;

        bool[] row = new bool[M];
        bool[] col = new bool[N];

        for (int i = 0; i < M; ++i) {
            for (int j = 0; j < N; ++j) {
                row[i] = row[i] || matrix[i][j] == 0;
                col[j] = col[j] || matrix[i][j] == 0;
            }
        }

        for (int i = 0; i < M; ++i) {
            for (int j = 0; j < N; ++j) {
                if (row[i] || col[j]) {
                    matrix[i][j] = 0;
                }
            }
        }
    }
}
