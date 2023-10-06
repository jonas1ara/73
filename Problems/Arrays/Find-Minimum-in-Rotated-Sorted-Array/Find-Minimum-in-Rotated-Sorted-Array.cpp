#include "../../../Libraries/ArrayPrinter.h"
#include <iostream>
#include <vector>

class Solution {
public:
    int findMin(std::vector<int> &nums)
    {
        int L = 0, R = nums.size() - 1;
        while (L < R)
        {
            int M = (L + R) / 2;
            if (nums[M] > nums[R])
                L = M + 1;
            else
                R = M;
        }
        return nums[L];
    }
};

int main()
{
    std::vector<int> nums = {3, 4, 5, 1, 2};

    return 0;
}