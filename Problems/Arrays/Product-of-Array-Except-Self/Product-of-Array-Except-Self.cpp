#include "../../../Libraries/ArrayPrinter.h"
#include <iostream>
#include <vector>

class Solution
{
public:
    std::vector<int> productExceptSelf(std::vector<int> &nums)
    {
        int N = nums.size();
        std::vector<int> result(N, 1);
        result[0] = 1;

        for (int i = 1; i < N; i++)
        {
            result[i] = result[i - 1] * nums[i - 1];
        }

        int rightSide = 1;
        for (int i = N - 1; i >= 0; i--)
        {
            result[i] = result[i] * rightSide;
            rightSide *= nums[i];
        }

        return result;
    }
};

int main()
{
    std::vector<int> array = {1, 2, 3, 4};

    return 0;
}