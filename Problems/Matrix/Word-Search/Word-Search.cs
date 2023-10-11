public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        int M = board.Length;
        int N = board[0].Length;
        int[][] dirs = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

        bool DFS(int x, int y, int i)
        {
            if (x < 0 || x >= M || y < 0 || y >= N || board[x][y] != word[i]) return false;
            if (i + 1 == word.Length) return true;
          
          	char c = board[x][y];
            board[x][y] = '0'; // Mark as visited
          
            foreach (var dir in dirs)
            {
                int dx = dir[0];
                int dy = dir[1];
            
              	if (DFS(x + dx, y + dy, i + 1)) return true;
            }
            
          	board[x][y] = c; // Restore original value
            return false;
        }

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (DFS(i, j, 0)) return true;
            }
        }

        return false;
    }
}
