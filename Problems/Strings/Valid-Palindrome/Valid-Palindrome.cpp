#include <iostream>

// Using two pointers technique - Time: O(n)

class Solution {
public:
    bool isPalindrome(std::string s)
    {
        int i = 0, j = s.length() - 1;
        
        while (i < j)
        {
            while (i < j && !isalnum(s[i]))
                i++;
            while (i < j && !isalnum(s[j]))
                j--;
            if (i < j && tolower(s[i]) != tolower(s[j]))
                return false;
            
            i++;
            j--;
        }

        return true;
    }
};

int main()
{
    std::string s = "A man, a plan, a canal, Panama!";
    std::cout << "Input: s = " << s << std::endl;

    Solution sol;
    bool result = sol.isPalindrome(s);

    std::cout <<  "Output: "  << std::boolalpha << result << std::endl;

    return 0;
}
