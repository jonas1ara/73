#include <iostream>
#include <string>

// Using an array - Time: O(n)

class Solution {
public:
    bool isAnagram(std::string s, std::string t)
    {
        int cnt[26] = {};

        for (char c : s)
            cnt[c - 'a']++;

        for (char c : t)
            cnt[c - 'a']--;

        for (int n : cnt)
        {
            if (n)
                return false;
        }

        return true;
    }
};

int main() 
{
    std::string s = "anagram";
    std::string t = "nagaram";
    std::cout << "Input: s = " << s << ", t = " << t << std::endl;

    Solution sol;
    bool result = sol.isAnagram(s, t);

    std::cout << "Output = " << std::boolalpha << result << std::endl;

    return 0;
}
