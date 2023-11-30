#include <iostream>
#include <vector>

// Using prefix and postfix - Time O(n)

class Solution {
public:
    std::vector<int> productExceptSelf(std::vector<int> &nums)
    {
        int n = nums.size();
        std::vector<int> result(n, 1);
        result[0] = 1;

        for (int i = 1; i < n; i++)
        {
            result[i] = result[i - 1] * nums[i - 1];
        }

        int rightSide = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            result[i] = result[i] * rightSide;
            rightSide *= nums[i]; // rightSide = rightSide * nums[i];
        }

        return result;
    }
};

int main()
{
    std::vector<int> nums = {1, 2, 3, 4};

    // Print input
    std::cout << "Input: nums = [";
    for (const auto &num : nums)
    {
        std::cout << num << "";
        if (&num != &nums.back())
        {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;

    Solution sol;
    std::vector<int> result = sol.productExceptSelf(nums);

    // Print input
    std::cout << "Output: [";
    for (const auto &r : result)
    {
        std::cout << r << "";
        if (&r != &result.back())
        {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;

    return 0;
}
