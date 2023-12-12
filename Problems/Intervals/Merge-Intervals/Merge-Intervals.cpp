#include <iostream>
#include <vector>
#include <algorithm>

// Using merge and quick sort - Time: O(nlogn)

class Solution {
public:
    std::vector<std::vector<int>> merge(std::vector<std::vector<int>> &intervals)
    {
        if (intervals.empty())
        {
            return {};
        }

        sort(intervals.begin(), intervals.end());

        std::vector<std::vector<int>> merged;
        merged.push_back(intervals[0]);

        for (int i = 1; i < intervals.size(); i++)
        {
            if (merged.back()[1] < intervals[i][0])
            {
                merged.push_back(intervals[i]);
            }
            else
            {
                merged.back()[1] = std::max(merged.back()[1], intervals[i][1]);
            }
        }

        return merged;
    }
};

int main()
{
    std::vector<std::vector<int>> intervals = {{1, 3}, {2, 6}, {8, 10}, {15, 18}};

    std::cout << "Input: intervals = [";
    for (const auto &interval : intervals)
    {
        std::cout << "[" << interval[0] << "," << interval[1] << "]";
    }
    std::cout << "]" << std::endl;

    Solution solution;
    std::vector<std::vector<int>> merged = solution.merge(intervals);

    std::cout << "Output: [";
    for (const auto &interval : merged)
    {
        std::cout << "[" << interval[0] << "," << interval[1] << "]";
    }
    std::cout << "]" << std::endl;

    return 0;
}
