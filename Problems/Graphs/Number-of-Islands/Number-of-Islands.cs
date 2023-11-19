public class Solution
{
    private int M, N;
    private int[][] dirs = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

    private void DFS(char[][] grid, int x, int y)
    {
        if (x < 0 || y < 0 || x >= M || y >= N || grid[x][y] != '1') return;

        grid[x][y] = 'x';

        foreach (var dir in dirs)
        {
            DFS(grid, x + dir[0], y + dir[1]);
        }
    }
    // grid
    public int NumIslands(char[][] grid)
    {
        if (grid == null || grid.Length == 0 || grid[0].Length == 0) return 0;

        int ans = 0;
        M = grid.Length;
        N = grid[0].Length;

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (grid[i][j] != '1') continue;
                ans++;
                DFS(grid, i, j);
            }
        }

        return ans;
    }
}
