#include <string>
#include <unordered_map>

class Solution
{
public:
    int lengthOfLongestSubstring(std::string s)
    {
        if (s.empty())
            return 0;

        std::unordered_map<char, int> map;
        int maxLen = 0;
        int lastRepeatPos = -1;
        for (int i = 0; i < s.length(); i++)
        {
            if (map.find(s[i]) != map.end() && lastRepeatPos < map[s[i]])
                lastRepeatPos = map[s[i]];
            if (maxLen < i - lastRepeatPos)
                maxLen = i - lastRepeatPos;
            map[s[i]] = i;
        }

        return maxLen;
    }
};
