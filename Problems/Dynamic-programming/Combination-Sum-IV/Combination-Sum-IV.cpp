#include <iostream>
#include <vector>
#include <unordered_map>'
#include <algorithm>

using namespace std;

class Solution {
    unordered_map<int, int> m {{0, 1}};
    int dp(vector<int>& nums, int target) {
        if (m.count(target)) return m[target];
        int cnt = 0;
        for (int n : nums) {
            if (n > target) break;
            cnt += dp(nums, target - n);
        }
        return m[target] = cnt;
    }
public:
    int combinationSum4(vector<int>& nums, int target) {
        sort(nums.begin(), nums.end());
        return dp(nums, target);
    }
};

int main() {
    Solution solution;
    vector<int> nums = {1, 2, 3};
    int target = 4;
    int result = solution.combinationSum4(nums, target);
    cout << "Result: " << result << endl;
    return 0;
}
