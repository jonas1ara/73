#include "../../../Libraries/ArrayPrinter.h"
#include <iostream>
#include <vector>

class Solution {
public:
    int maxProduct(std::vector<int> &nums)
    {
        int ans = nums[0], N = nums.size(), j = 0;
        while (j < N)
        {
            int i = j, prod = 1;
            while (j < N && nums[j] != 0)
            {
                prod *= nums[j++];
                ans = std::max(ans, prod);
            }
            if (j < N)
                ans = std::max(ans, 0);
            while (i < N && prod < 0)
            {
                prod /= nums[i++];
                if (i != j)
                    ans = std::max(ans, prod);
            }
            while (j < N && nums[j] == 0)
                ++j;
        }
        return ans;
    }
};

int main()
{
    std::vector <int> nums = {2,3,-2,4};
    Solution solution;
    

    return 0;
}