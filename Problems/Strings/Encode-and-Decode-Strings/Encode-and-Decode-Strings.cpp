#include <iostream>
#include <vector>
#include <string>

// Using string manipulation - Time: O(n)

class Solution {
public:
    std::string encode(std::vector<std::string> &strs)
    {
        std::string ans;
        for (std::string &str : strs)
        {
            for (char c : str)
            {
                if (c == '$')
                    ans.push_back(c);
                ans.push_back(c);
            }
            ans.push_back('$');
            ans.push_back('x');
        }
        return ans;
    }
    std::vector<std::string> decode(std::string str)
    {
        std::vector<std::string> ans;
        int i = 0, n = str.size();

        while (i < n)
        {
            std::string s;

            for (; i < n; i++)
            {
                if (str[i] != '$')
                    s.push_back(str[i]);
                else if (i + 1 < n && str[i + 1] == '$')
                    s.push_back(str[i++]);
                else
                {
                    i += 2;
                    break;
                }
            }
            ans.push_back(s);
        }

        return ans;
    }
};

int main()
{
    std::vector<std::string> strs = {"we", "say", ":", "yes"};

    std::cout << "Input: [";
    for (const auto &str : strs)
    {
        std::cout << str << " ";
        if (str != strs.back())
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    Solution sol;
    std::string encodedString = sol.encode(strs);

    // std::cout << "Encoded String: " << encodedString << std::endl;

    std::vector<std::string> decodedStrings = sol.decode(encodedString);

    std::cout << "Ouput: [";
    for (const auto &dstr : decodedStrings)
    {
        std::cout << dstr << " ";
        if (dstr != decodedStrings.back())
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    return 0;
}
