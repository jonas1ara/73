#include <iostream>
#include <vector>
#include <string>
#include <unordered_set>
#include <climits>

// Using bottom-up approach - Time: O(n^2)

class Solution {
public:
    bool wordBreak(std::string s, std::vector<std::string> &wordDict)
    {
        std::unordered_set<std::string> st(wordDict.begin(), wordDict.end());
        int n = s.size(), minLen = INT_MAX, maxLen = 0;
        
        for (const auto &w : wordDict)
        {
            minLen = std::min(minLen, static_cast<int>(w.size()));
            maxLen = std::max(maxLen, static_cast<int>(w.size()));
        }
        
        std::vector<bool> dp(n + 1, false);
        dp[0] = true;
        
        for (int i = 1; i <= n; i++)
        {
            for (int len = minLen; len <= maxLen && i - len >= 0 && !dp[i]; len++)
            {
                dp[i] = dp[i - len] && st.count(s.substr(i - len, len));
            }
        }
        
        return dp[n];
    }
};

int main()
{
    std::string s = "leetcode";
    std::vector<std::string> wordDict = {"leet", "code"};

    std::cout << "Input: s = " << s << ", wordDict = [";
    for (int i = 0; i < wordDict.size(); i++)
    {
        std::cout << "" << wordDict[i] << "";
        if (i < wordDict.size() - 1)
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    Solution sol;
    bool result = sol.wordBreak(s, wordDict);
    
    std::cout << "Output: " << std::boolalpha << result << std::endl;

    return 0;
}
