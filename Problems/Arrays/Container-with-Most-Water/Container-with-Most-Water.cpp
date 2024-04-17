#include <iostream>
#include <vector>
#include <climits>

// Using two pointers technique - Time: O(n)

class Solution {
public:
    int maxArea(std::vector<int> &height)
    {
        int ans = 0, left = 0, right = height.size() - 1;

        while (left < right)
        {
            ans = std::max(ans, (right - left) * std::min(height[left], height[right]));
            
			if (height[left] < height[right])
                left++; // Move the smaller edge
            else
                right--; // Move the larger edge
        }

        return ans;
    }
};

int main()
{
    std::vector<int> height = {1, 8, 6, 2, 5, 4, 8, 3, 7};

    // Print input
    std::cout << "Input: height = [";
    for (const auto &h : height)
    {
        std::cout << h << "";
        if (&h != &height.back())
        {
        	std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;

    Solution sol;

    // Print output
    int maxWater = sol.maxArea(height);
    std::cout << "Output: " << maxWater << std::endl;

    return 0;
}
