#include <iostream>
#include <vector>

// Using Kadan's algorithm - Time: O(n)

class Solution {
public:
    int maxSubArray(std::vector<int> &nums)
    {
        int ans = nums[0];

        for (int i = 1; i < nums.size(); i++)
        {
            nums[i] += std::max(nums[i - 1], 0);
            ans = std::max(ans, nums[i]);
        }

        return ans;
    }
};

int main()
{
    std::vector<int> nums = {-2, 1, -3, 4, -1, 2, 1, -5, 4};

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
    int result = sol.maxSubArray(nums);

    // Print output
    std::cout << "Output: " << result << std::endl;

    return 0;
}
