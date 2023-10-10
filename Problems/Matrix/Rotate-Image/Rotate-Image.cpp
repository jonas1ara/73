#include <iostream>
#include <vector>

class Solution {
public:
    void rotate(std::vector<std::vector<int>>& matrix) {
        int N = matrix.size();
        for (int i = 0; i < N / 2; ++i) {
            for (int j = i; j < N - i - 1; ++j) {
                int tmp = matrix[i][j];
                matrix[i][j] = matrix[N - j - 1][i];
                matrix[N - j - 1][i] = matrix[N - i - 1][N - j - 1];
                matrix[N - i - 1][N - j - 1] = matrix[j][N - i - 1];
                matrix[j][N - i - 1] = tmp;
            }
        }
    }
};

int main()
{
    std::vector<std::vector<int>> matrix = {{1,2,3},{4,5,6},{7,8,9}};

    Solution  solution;

    std::cout << "Before rotate:" << std::endl;

    for (auto row : matrix) {
        for (auto col : row) {
            std::cout << col << " ";
        }
        std::cout << std::endl;
    }

    solution.rotate(matrix);

    std::cout << "After rotate:" << std::endl;

    for (auto row : matrix) {
        for (auto col : row) {
            std::cout << col << " ";
        }
        std::cout << std::endl;
    }
    
}