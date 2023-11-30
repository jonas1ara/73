#include <iostream>
#include <vector>

// Using two pointers technique - Time O(n)

class Solution {
public:
    int maxProduct(std::vector<int> &nums)
    {
        int ans = nums[0], n = nums.size(), j = 0;
        while (j < n)
        {
            int i = j, prod = 1;
            while (j < n && nums[j] != 0)
            {
                prod *= nums[j++]; // prod = prod * nums[j]
                ans = std::max(ans, prod);
            }
            if (j < n)
                ans = std::max(ans, 0);
            while (i < n && prod < 0)
            {
                prod /= nums[i++];
                if (i != j)
                    ans = std::max(ans, prod);
            }
            while (j < n && nums[j] == 0)
                j++;
        }
        return ans;
    }
};

int main()
{
    std::vector<int> nums = {2, 3, -2, 4};

    // Print input
    std::cout << "Input: nums = [";
    for (int i = 0; i < nums.size(); i++)
    {
        std::cout << nums[i] << "";
        if (i < nums.size() - 1)
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    Solution sol;
    int result = sol.maxProduct(nums);

    // Print output
    std::cout << "Output: " << result << std::endl;

    return 0;
}
