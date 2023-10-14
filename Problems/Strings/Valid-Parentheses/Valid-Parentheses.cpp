#include <iostream>
#include <stack>
#include <string>

class Solution
{
public:
    bool isValid(std::string s)
    {
        std::stack<char> stk;
        for (char c : s)
        {
            if (c == '(' || c == '{' || c == '[')
                stk.push(c);
            else if (stk.empty() || (c == ')' && stk.top() != '(') || (c == '}' && stk.top() != '{') || (c == ']' && stk.top() != '['))
                return false;
            else
                stk.pop();
        }
        return stk.empty();
    }
};

int main()
{
    Solution solution;
    std::string input = "({[()]})"; // Cambia la cadena de entrada según tus necesidades

    bool isValid = solution.isValid(input);

    if (isValid)
    {
        std::cout << "La cadena es válida." << std::endl;
    }
    else
    {
        std::cout << "La cadena no es válida." << std::endl;
    }

    return 0;
}
