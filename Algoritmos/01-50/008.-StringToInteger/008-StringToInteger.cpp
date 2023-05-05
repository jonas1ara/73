#include <iostream>
#include <climits>

int myAtoi(std::string s)
{
    int i = 0, N = s.size(), sign = 1, ans = 0;
    while (i < N && s[i] == ' ')
        ++i;
    if (i < N && (s[i] == '+' || s[i] == '-'))
        sign = s[i++] == '+' ? 1 : -1;
    while (i < N && isdigit(s[i]))
    {
        int n = s[i++] - '0';
        if (ans > INT_MAX / 10 || (ans == INT_MAX / 10 && n > INT_MAX % 10))
            return sign == 1 ? INT_MAX : INT_MIN;
        ans = ans * 10 + n;
    }
    return ans * sign;
}

int main()
{
    std::string s = "42";

    std::cout << "Input: s = " << s << std::endl;

    int result = myAtoi(s);

    std::cout << "Output: " << result << std::endl;

    return 0;
}
