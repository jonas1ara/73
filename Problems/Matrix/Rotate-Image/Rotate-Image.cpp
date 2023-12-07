#include <iostream>
#include <vector>

// Using in-place algorithm - Time: O(n^2)

class Solution {
public:
    void rotate(std::vector<std::vector<int>> &matrix)
    {
        int n = matrix.size();

        // Transpose
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
};

int main()
{
    std::vector<std::vector<int>> matrix = {
        {1, 2, 3}, 
        {4, 5, 6}, 
        {7, 8, 9}
    };

    std::cout << "Input: matrix =" << std::endl;
    for (auto row : matrix)
    {
        for (auto col : row)
        {
            std::cout << col << " ";
        }
        std::cout << std::endl;
    }
    std::cout << std::endl;

    Solution sol;
    sol.rotate(matrix);

    std::cout << "Output: " << std::endl;

    for (auto row : matrix)
    {
        for (auto col : row)
        {
            std::cout << col << " ";
        }
        std::cout << std::endl;
    }
}