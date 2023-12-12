#include <iostream>
#include <vector>
#include <algorithm>
#include <climits>

// Using a greedy algorithm - Time: O(nlogn)

class Solution {
public:
    int eraseOverlapIntervals(std::vector<std::vector<int>> &intervals)
    {
        sort(begin(intervals), end(intervals), [](auto &a, auto &b) { return a[1] < b[1]; });

        int ans = 0;
        int end = INT_MIN;

        for (auto &i : intervals)
        {
            if (i[0] >= end)
                end = i[1];
            else
                ans++;
        }

        return ans;
    }
};

int main() 
{    
    std::vector<std::vector<int>> intervals = {{1, 2}, {2, 3}, {3, 4}, {1, 3}};

    std::cout << "Input: intervals = [";
    for (const auto &interval : intervals)
    {
        std::cout << "[" << interval[0] << "," << interval[1] << "]";
        if (&interval != &intervals.back())
            std::cout << ",";
    }
    std::cout << "]" << std::endl;
    
    Solution sol;
    int ans = sol.eraseOverlapIntervals(intervals);
    
    std::cout << "Output: " << ans << std::endl;
    
    return 0;
}