#include <iostream>
#include <vector>

class Solution
{
public:
    int missingNumber(std::vector<int> &nums)
    {
        int n = nums.size(), xorVal = 0;
        for (int i = 0; i < n; ++i)
            xorVal ^= nums[i] ^ (i + 1);
        return xorVal;
    }
};