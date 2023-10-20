#include <iostream>
#include <string>
#include <algorithm>

class Solution
{
public:
    int characterReplacement(std::string s, int k)
    {
        int i = 0, j = 0, cnt[26] = {}, N = s.size();
        while (j < N)
        {
            cnt[s[j++] - 'A']++;
            if (j - i - *std::max_element(cnt, cnt + 26) > k)
                cnt[s[i++] - 'A']--;
        }
        return j - i;
    }
};