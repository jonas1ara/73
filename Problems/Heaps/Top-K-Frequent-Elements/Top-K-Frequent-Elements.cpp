#include <iostream>
#include <vector>
#include <unordered_map>
#include <queue>

// Using a heap - Time complexity: O(nlogk)

class Solution {
public:
    std::vector<int> topKFrequent(std::vector<int> &nums, int k)
    {
        if (nums.size() == k)
            return nums;
        std::unordered_map<int, int> cnt;

        for (int n : nums)
            cnt[n]++;
        std::vector<int> ans;

        if (cnt.size() == k)
        {
            for (auto &[n, c] : cnt)
                ans.push_back(n);
            return ans;
        }

        auto cmp = [&](int a, int b)
        { return cnt[a] > cnt[b]; };
        std::priority_queue<int, std::vector<int>, decltype(cmp)> pq(cmp); // Min heap

        for (auto &[n, c] : cnt)
        {
            pq.push(n);
            if (pq.size() > k)
                pq.pop();
        }
        while (pq.size())
        {
            ans.push_back(pq.top());
            pq.pop();
        }

        ans = std::vector<int>(ans.rbegin(), ans.rend());
        return ans;
    }
};

int main()
{
    std::vector<int> nums = {1, 1, 1, 2, 2, 3};
    int k = 2;

    Solution sol;
    std::vector<int> result = sol.topKFrequent(nums, k);

    std::cout << "Input: nums = [";
    for (int i = 0; i < nums.size(); i++)
    {
        std::cout << nums[i];
        if (i < nums.size() - 1)
            std::cout << ", ";
    }
    std::cout << "], k = " << k << std::endl;

    std::cout << "Output: [";
    for (int i = 0; i < result.size(); ++i)
    {
        std::cout << result[i];
        if (i < result.size() - 1)
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    return 0;
}