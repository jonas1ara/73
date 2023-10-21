#include <iostream>
#include <vector>
#include <algorithm>


class Solution
{
public:
    std::vector<std::vector<int>> merge(std::vector<std::vector<int>> &A)
    {
        sort(begin(A), end(A));
        std::vector<std::vector<int>> ans;
        for (auto &v : A)
        {
            if (ans.empty() || v[0] > ans.back()[1])
                ans.push_back(v);
            else
                ans.back()[1] = std::max(ans.back()[1], v[1]);
        }
        return ans;
    }
};

int main()
{
    Solution solution;
    std::vector<std::vector<int>> intervals = {
        {1, 3},
        {2, 6},
        {8, 10},
        {15, 18}
    };

    std::vector<std::vector<int>> mergedIntervals = solution.merge(intervals);

    std::cout << "Merged Intervals:" << std::endl;
    for (const std::vector<int> &interval : mergedIntervals)
    {
        std::cout << "[" << interval[0] << ", " << interval[1] << "]" << std::endl;
    }

    return 0;
}