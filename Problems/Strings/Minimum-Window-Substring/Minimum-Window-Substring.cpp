#include <iostream>
#include <string>
#include <climits>

// Using sliding window technique - Time: O(n)

class Solution {
public:
    std::string minWindow(std::string s, std::string t)
    {
        int cnt[128] = {};
        for (char c : t)
        {
            cnt[c]++;
        }

        int n = s.size(); 
        int i = 0, j = 0, start = -1, minLen = INT_MAX, matched = 0;
        
        while (j < n)
        {
            matched += --cnt[s[j++]] >= 0;
            
            while (matched == t.size())
            {
                if (j - i < minLen)
                    minLen = j - i, start = i;
                matched -= ++cnt[s[i++]] > 0;
            }
        }

        return start == -1 ? "" : s.substr(start, minLen);
    }
};

int main()
{   
    std::string s = "ADOBECODEBANC";
    std::string t = "ABC";
    std:: cout << "Input: s = " << s << ", t = " << t << std::endl;

    Solution sol;
    std::string result = sol.minWindow(s, t);

    std::cout << "Output: " << result << std::endl;

    return 0;
}
