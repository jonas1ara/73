#include <iostream>
#include <vector>

// Using binary search technique - Time O(log n)

class Solution {
public:
    int findMin(std::vector<int> &nums)
    {
        int left = 0, right = nums.size() - 1;

        while (left < right)
        {
            int m = (left + right) / 2; // middle index

            if (nums[m] > nums[right])
                left = m + 1;
            else
                right = m;
        }

        return nums[left];
    }
};

int main()
{
    std::vector<int> nums = {3, 4, 5, 1, 2};

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
    int result = sol.findMin(nums);

    // Print output
    std::cout << "Output: " << result << std::endl;

    return 0;
}