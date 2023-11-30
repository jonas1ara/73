#include <iostream>
#include <vector>

// Using binary search technique - Time: O(log n)

class Solution {
public:
    int search(std::vector<int> &nums, int target)
    {
        if (nums.empty())
            return -1;

        int n = nums.size(), left = 0, right = n - 1, pivot;
        
        while (left < right)
        {
            int m = left + (right - left) / 2; // m is the index of the middle element
            if (nums[m] < nums[right])
                right = m;
            else
                left = m + 1;
        }
        
        pivot = left;
        left = 0, right = n - 1;

        while (left <= right)
        {
            int m = left + (right - left) / 2; 
            int mm = (m + pivot) % n; // mm is the index of the middle element in the rotated array
            
            if (nums[mm] == target)
                return mm;

            if (target > nums[mm])
                left = m + 1;
            else
                right = m - 1;
        }

        return -1;
    }
};

int main()
{
    std::vector<int> nums = {4, 5, 6, 7, 0, 1, 2};
    int target = 3;

    // Print input
    std::cout << "Input: nums = [";
    for (const auto &num : nums)
    {
        std::cout << num << "";
        if (&num != &nums.back())
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    Solution sol;
    int result = sol.search(nums, target);

    // Print output
    std::cout << "Output: " << result << std::endl;

    return 0;
}
