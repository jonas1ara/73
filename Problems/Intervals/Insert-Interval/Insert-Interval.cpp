#include <iostream>
#include <vector>

// Using linear search technique - Time: O(n)

class Solution {
public:
    std::vector<std::vector<int>> insert(std::vector<std::vector<int>> &intervals, std::vector<int> &newInterval)
    {
        std::vector<std::vector<int>> ans;
        int start = newInterval[0]; 
        int end = newInterval[1]; 
        
        for (auto &intv : intervals)
        {
            if (start > end)
            {
                ans.push_back(intv);
            }
            else if (intv[0] > end)
            {
                ans.push_back({start, end});
                start = end + 1;
                ans.push_back(intv);
            }
            else if (intv[1] < start)
                ans.push_back(intv);
            else
            {
                start = std::min(start, intv[0]);
                end = std::max(end, intv[1]);
            }
        }

        if (start <= end)
        {
            ans.push_back({start, end});
        }
        
        return ans;
    }
};

int main()
{
    std::vector<std::vector<int>> intervals = {{1,2},{3, 5}, {6, 7}, {8, 10}, {12, 16}};
    std::vector<int> newInterval = {4, 8};

    std::cout << "Input: intervals = [";
    for (const auto &interval : intervals)
    {
        std::cout << "[" << interval[0] << "," << interval[1] << "]";
        if (&interval != &intervals.back())
        {
            std::cout << ", ";
        }
    }
    std::cout << "], newInterval = [" << newInterval[0] << "," << newInterval[1] << "]" << std::endl;


    Solution sol;
    std::vector<std::vector<int>> ans = sol.insert(intervals, newInterval);

    std::cout << "Output: [";
    for (const auto &a : ans)
    {
        std::cout << "[" << a[0] << "," << a[1] << "]";
        if (&a != &ans.back())
        {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;

    return 0;
}