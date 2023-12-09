#include <iostream>
#include <string>
#include <unordered_map>

// Using hash map - Time: O(n)

class Solution {
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

int main() 
{    
    std::string input = "abcabcbb";

    std::cout << "Input: " << input << std::endl;
    
    Solution solution;
    int result = solution.lengthOfLongestSubstring(input);

    std::cout << "Output: " << result << std::endl;

    return 0;
}

