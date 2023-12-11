#include <iostream>
#include <vector>

//  Using dynamic programming - Time: O(n)

class Solution {
public:
    std::vector<int> countBits(int n)
    {
        std::vector<int> ans(n + 1);

        for (int i = 1; i <= n; i *= 2)
        {
            ans[i] = 1;

            for (int j = 1; j < i && i + j <= n; j++)
                ans[i + j] = ans[i] + ans[j];
        }

        return ans;
    }
};

int main()
{
    int n = 5; 
    std::cout << "Input: n = " << n << std::endl;

    Solution sol;
    std::vector<int> result = sol.countBits(n);

    std::cout << "Output: [";
    for (int i = 0; i <= n; i++)
    {
        std::cout << result[i];
        if (i < n) std::cout << ", ";
    }
    std::cout << "]\n";

    return 0;
}