#include <iostream>
#include <vector>

class Solution
{
    int m, n;
    int dirs[4][2] = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};
    
    void dfs(std::vector<std::vector<char>> &grid, int x, int y)
    {
        if (x < 0 || y < 0 || x >= m || y >= n || grid[x][y] != '1')
            return;
        grid[x][y] = 'x';
        for (auto &dir : dirs)
            dfs(grid, x + dir[0], y + dir[1]);
    }

public:
    int numIslands(std::vector<std::vector<char>> &grid)
    {
        if (grid.empty() || grid[0].empty())
            return 0;
        int ans = 0;
        m = grid.size(), n = grid[0].size();
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (grid[i][j] != '1')
                    continue;
                ++ans;
                dfs(grid, i, j);
            }
        }

        return ans;
    }
};

int main()
{
    // Constructing the grid
    std::vector<std::vector<char>> grid = {
        {'1', '1', '0', '0', '0'},
        {'1', '1', '0', '0', '0'},
        {'0', '0', '1', '0', '0'},
        {'0', '0', '0', '1', '1'}
    };

    // Print grid
    std::cout << "Grid:" << std::endl;
    for (const auto &row : grid)
    {
        for (char cell : row)
        {
            std::cout << cell << " ";
        }
        std::cout << std::endl;
    }

    // Create an instance of the Solution class
    Solution solution;

    // Call the numIslands function
    int numIslands = solution.numIslands(grid);

    // Print answer
    std::cout << "Output: " << numIslands << std::endl;

    return 0;
}