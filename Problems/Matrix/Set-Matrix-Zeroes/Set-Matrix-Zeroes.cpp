#include <iostream>
#include <vector>

// Using in-place algorithm - Time: O(m⋅n)

class Solution {
public:
    void setZeroes(std::vector<std::vector<int>> &matrix)
    {
        int m = matrix.size();
        int n = matrix[0].size();

        std::vector<bool> row(m), col(n);

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
                    matrix[i][j] = 0;
            }
        }
    }
};

int main()
{
    std::vector<std::vector<int>> matrix = {
        {1, 2, 3},
        {4, 0, 6},
        {7, 8, 9}
    };

    std::cout << "Input: matrix =" << std::endl;
    for (const auto &row : matrix)
    {
        for (int value : row)
        {
            std::cout << value << " ";
        }
        std::cout << std::endl;
    }

    Solution sol;
    sol.setZeroes(matrix);

    std::cout << "\nOutput:" << std::endl;
    for (const auto &row : matrix)
    {
        for (int value : row)
        {
            std::cout << value << " ";
        }
        std::cout << std::endl;
    }

    return 0;
}
