class Solution {
public:
    vector<int> topKFrequent(vector<int>& nums, int k) {
        if (nums.size() == k) return nums;
        unordered_map<int, int> cnt;
        for (int n : nums) cnt[n]++;
        vector<int> ans;
        if (cnt.size() == k) {
            for (auto &[n, c] : cnt) ans.push_back(n);
            return ans;
        }
        auto cmp = [&](int a, int b) { return cnt[a] > cnt[b]; };
        priority_queue<int, vector<int>, decltype(cmp)> pq(cmp); // keep a min-heap of size at most k
        for (auto &[n, c] : cnt) {
            pq.push(n);
            if (pq.size() > k) pq.pop();
        }
        while (pq.size()) {
            ans.push_back(pq.top());
            pq.pop();
        }
        return ans;
    }
};