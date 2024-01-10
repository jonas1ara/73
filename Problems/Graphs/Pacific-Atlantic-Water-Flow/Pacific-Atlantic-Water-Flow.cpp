#include <iostream>
#include <vector>

// Using depth-first search - Time: O(mn)

class Solution {
private:
    std::vector<std::vector<int>> dirs = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};
    int M, N;

    void dfs(std::vector<std::vector<int>> &heights, int x, int y, std::vector<std::vector<int>> &m)
    {
        if (m[x][y] == 1)
            return;
        
        m[x][y] = 1;

        for (auto &dir : dirs)
        {
            int a = x + dir[0], b = y + dir[1];

            if (a < 0 || a >= M || b < 0 || b >= N || heights[a][b] < heights[x][y])
                continue;

            dfs(heights, a, b, m);
        }
    }

public:
    std::vector<std::vector<int>> pacificAtlantic(std::vector<std::vector<int>> &heights)
    {
        std::vector<std::vector<int>> ans;
        
        if (heights.empty() || heights[0].empty())
            return ans;
        
        M = heights.size(), N = heights[0].size();
        
        std::vector<std::vector<int>> pacific(M, std::vector<int>(N)), atlantic(M, std::vector<int>(N));
        
        for (int i = 0; i < M; i++)
        {
            dfs(heights, i, 0, pacific);
            dfs(heights, i, N - 1, atlantic);
        }
        
        for (int j = 0; j < N; j++)
        {
            dfs(heights, 0, j, pacific);
            dfs(heights, M - 1, j, atlantic);
        }
        
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (pacific[i][j] == 1 && atlantic[i][j] == 1)
                {
                    ans.push_back({i, j});
                }
            }
        }

        return ans;
    }
};

int main()
{
    std::vector<std::vector<int>> input = {
        {1, 2, 2, 3, 5},
        {3, 2, 3, 4, 4},
        {2, 4, 5, 3, 1},
        {6, 7, 1, 4, 5},
        {5, 1, 1, 2, 4}   
    };
    
    std::cout << "Input: [";
    for (auto &row : input)
    {
        std::cout << "[";
        for (auto &col : row)
        {
            std::cout << col;
            if (&col != &row.back())
                std::cout << ", ";
        }
        std::cout << "]";
        if (&row != &input.back())
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    Solution sol;
    std::vector<std::vector<int>> result = sol.pacificAtlantic(input);

    std::cout << "Output: [";
    for (auto &point : result)
    {
        std::cout << "[" << point[0] << ", " << point[1] << "]";
        if (&point != &result.back())
            std::cout << ", ";
    }
    std::cout  << "]" << std::endl;

    return 0;
}
