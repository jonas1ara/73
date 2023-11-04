#include <iostream>
#include <vector>
#include <string>

using namespace std;

class Solution {
public:
    int longestCommonSubsequence(string s, string t) {
        int M = s.size(), N = t.size();
        if (M < N) swap(M, N), swap(s, t);
        vector<int> dp(N + 1);
        for (int i = 0; i < M; ++i) {
            int prev = 0;
            for (int j = 0; j < N; ++j) {
                int cur = dp[j + 1];
                if (s[i] == t[j]) dp[j + 1] = prev + 1;
                else dp[j + 1] = max(dp[j], dp[j + 1]);
                prev = cur; 
            }
        }
        return dp[N];
    }
};

int main() {
    Solution solution;
    string s = "abcde";
    string t = "ace";
    int result = solution.longestCommonSubsequence(s, t);
    cout << "Longest Common Subsequence: " << result << endl;
    return 0;
}
