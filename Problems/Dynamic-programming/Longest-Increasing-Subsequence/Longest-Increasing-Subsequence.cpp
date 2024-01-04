#include <iostream>
#include <vector>
#include <algorithm>

class Solution {
public:
    int lengthOfLIS(std::vector<int>& A) {
        if (A.empty()) return 0;
        int N = A.size();
        std::vector<int> dp(N, 1);
        for (int i = 1; i < N; ++i) {
            for (int j = 0; j < i; ++j) {
                if (A[j] < A[i]) dp[i] = std::max(dp[i], dp[j] + 1);
            }
        }
        return *std::max_element(dp.begin(), dp.end());
    }
};

int main() {
    std::vector<int> A = {10, 9, 2, 5, 3, 7, 101, 18};
    Solution solution;
    int result = solution.lengthOfLIS(A);
    std::cout << "Longitud de la subsecuencia creciente más larga: " << result << std::endl;
    return 0;
}
