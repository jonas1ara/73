#include <iostream>
#include <vector>
#include <algorithm>
#include <climits>

class Solution
{
public:
    int eraseOverlapIntervals(std::vector<std::vector<int>> &A)
    {
        sort(begin(A), end(A), [](auto &a, auto &b)
             { return a[1] < b[1]; });
        int ans = 0, e = INT_MIN;
        for (auto &v : A)
        {
            if (v[0] >= e)
                e = v[1];
            else
                ++ans;
        }
        return ans;
    }
};

int main() {
    Solution solution;
    std::vector<std::vector<int>> intervals = {{1, 3}, {2, 4}, {3, 5}, {4, 6}};
    int result = solution.eraseOverlapIntervals(intervals);
    
    std::cout << "Minimum number of intervals to remove: " << result << std::endl;
    
    return 0;
}