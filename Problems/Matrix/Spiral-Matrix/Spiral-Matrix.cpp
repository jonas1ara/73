#include <iostream>
#include <vector>

// Using spiral iterative traversals - Time: O(m⋅n)

class Solution {
public:
    std::vector<int> spiralOrder(std::vector<std::vector<int>> &matrix)
    {
        std::vector<int> ans;

        if (matrix.empty() || matrix[0].empty())
        {
            return ans;
        }

        int m = matrix.size();
        int n = matrix[0].size();

        for (int i = 0; ans.size() < m * n; i++)
        {
            for (int j = i; j < n - i; j++)
            {
                ans.push_back(matrix[i][j]);
            }

            for (int j = i + 1; j < m - i; j++)
            {
                ans.push_back(matrix[j][n - i - 1]);
            }

            if (m - i - 1 != i)
            {
                for (int j = n - i - 2; j >= i; j--)
                {
                    ans.push_back(matrix[m - i - 1][j]);
                }
            }

            if (n - i - 1 != i)
            {
                for (int j = m - i - 2; j > i; j--)
                {
                    ans.push_back(matrix[j][i]);
                }
            }
        }

        return ans;
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
    for (std::vector<int> row : matrix)
    {
        for (int num : row)
        {
            std::cout << num << " ";
        }
        std::cout << std::endl;
    }
    std::cout << std::endl;

    Solution sol;
    std::vector<int> result = sol.spiralOrder(matrix);

    std::cout << "Output: ";
    for (int num : result)
    {
        std::cout << "" << num;
        if (num != result.back())
        {
            std::cout << ", ";
        }
    }
    std::cout << std::endl;

    return 0;
}
