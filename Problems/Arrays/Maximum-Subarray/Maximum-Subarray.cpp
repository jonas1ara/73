#include "../../../Libraries/ArrayPrinter.h"
#include <iostream>
#include <vector>

class Solution {
public:
    int maxSubArray(std::vector<int> &nums)
    {
        int ans = nums[0];
        for (int i = 1; i < nums.size(); ++i)
        {
            nums[i] += std::max(nums[i - 1], 0);
            ans = std::max(ans, nums[i]);
        }
        return ans;
    }
};

int main()
{
    std::vector<int> array = {-2, 1, -3, 4, -1, 2, 1, -5, 4};

    return 0;
}