#include <iostream>
#include <vector>

class Solution
{
public:
    std::vector<int> countBits(int n)
    {
        std::vector<int> ans(n + 1);
        for (int i = 1; i <= n; i *= 2)
        {
            ans[i] = 1;
            for (int j = 1; j < i && i + j <= n; ++j)
                ans[i + j] = ans[i] + ans[j];
        }
        return ans;
    }
};