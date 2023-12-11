#include <iostream>
#include <string>
#include <algorithm>

// Using sliding window technique - Time: O(n)

class Solution {
public:
    int characterReplacement(std::string s, int k)
    {
        int i = 0;
        int j = 0;
        int cnt[26] = {};
        int n = s.size();

        while (j < n)
        {
            cnt[s[j++] - 'A']++;
            if (j - i - *std::max_element(cnt, cnt + 26) > k)
                cnt[s[i++] - 'A']--;
        }
        return j - i;
    }
};

int main()
{
    std::string s = "ABAB";
    int k = 2;

    std::cout << "Input: s = " << s << ", k = " << k << std::endl;

    Solution sol;
    int result = sol.characterReplacement(s, k);

    std::cout << "Output: " << result << std::endl;

    return 0;
}