#include <iostream>
#include <stack>
#include <string>

// Using a stack - Time O(n)

class Solution {
public:
    bool isValid(std::string s)
    {
        std::stack<char> stack;
        for (char c : s)
        {
            if (c == '(' || c == '{' || c == '[')
                stack.push(c);
            else if (stack.empty() || (c == ')' && stack.top() != '(') || (c == '}' && stack.top() != '{') 
                || (c == ']' && stack.top() != '['))
                return false;
            else
                stack.pop();
        }
        return stack.empty();
    }
};

int main()
{
    std::string input = "({[()]})"; 
    std::cout << "Input: s =" << input << std::endl;

    Solution sol;
    bool isValid = sol.isValid(input);

    std::cout << "Output: " << std::boolalpha << isValid  << std::endl;

    return 0;
}
