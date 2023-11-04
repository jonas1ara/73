#include <iostream>
#include <vector>
#include <string>
#include <unordered_set>
#include <climits>

class Solution
{
public:
    bool wordBreak(std::string s, std::vector<std::string> &wordDict)
    {
        std::unordered_set<std::string> st(wordDict.begin(), wordDict.end());
        int N = s.size(), minLen = INT_MAX, maxLen = 0;
        for (const auto &w : wordDict)
        {
            minLen = std::min(minLen, static_cast<int>(w.size()));
            maxLen = std::max(maxLen, static_cast<int>(w.size()));
        }
        std::vector<bool> dp(N + 1, false);
        dp[0] = true;
        for (int i = 1; i <= N; ++i)
        {
            for (int len = minLen; len <= maxLen && i - len >= 0 && !dp[i]; ++len)
            {
                dp[i] = dp[i - len] && st.count(s.substr(i - len, len));
            }
        }
        return dp[N];
    }
};

int main()
{
    Solution solution;
    std::string s = "leetcode";
    std::vector<std::string> wordDict = {"leet", "code"};
    bool result = solution.wordBreak(s, wordDict);
    if (result)
    {
        std::cout << "Result: true" << std::endl;
    }
    else
    {
        std::cout << "Result: false" << std::endl;
    }
    return 0;
}
