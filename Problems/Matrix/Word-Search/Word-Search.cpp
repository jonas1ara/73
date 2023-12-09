#include <iostream>
#include <vector>
#include <functional>

// Using Depth-First Search - Time: O(m⋅n⋅4^k)

class Solution {
public:
    bool exist(std::vector<std::vector<char>> &board, std::string word)
    {
        int m = board.size();
        int n = board[0].size();
        int dirs[4][2] = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};

        std::function<bool(int, int, int)> dfs = [&](int x, int y, int i)
        {
            if (x < 0 || x >= m || y < 0 || y >= n || board[x][y] != word[i])
                return false;
            if (i + 1 == static_cast<int>(word.size()))
                return true;

            char c = board[x][y];
            board[x][y] = 0;

            for (auto &[dx, dy] : dirs)
            {
                if (dfs(x + dx, y + dy, i + 1))
                    return true;
            }

            board[x][y] = c;
            return false;
        };

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (dfs(i, j, 0))
                    return true;
            }
        }
        return false;
    }
};

int main()
{
    std::vector<std::vector<char>> board = {
        {'A', 'B', 'C', 'E'},
        {'S', 'F', 'C', 'S'},
        {'A', 'D', 'E', 'E'}
    };

    std::string word = "ABCCED";
    
    Solution sol;
    if (sol.exist(board, word)) {
        std::cout << "Output: true " << std::endl;
    } else {
        std::cout << "Output: false" << std::endl;
    }

    return 0;
}
