#include <iostream>
#include <climits>

int charToNum(char c)
{
    switch (c)
    {
    case 'I':
        return 1;
    case 'V':
        return 5;
    case 'X':
        return 10;
    case 'L':
        return 50;
    case 'C':
        return 100;
    case 'D':
        return 500;
    case 'M':
        return 1000;
    }
    return 0;
}

int romanToInt(std::string s)
{
    int ans = 0, last = INT_MAX;
    for (char c : s)
    {
        int n = charToNum(c);
        if (n > last)
            ans -= 2 * last;
        ans += n;
        last = n;
    }
    return ans;
}

int main()
{
    std::string s = "MCMXCIV";

    std::cout << "Input: s = " << s << std::endl;

    int result = romanToInt(s);

    std::cout << "Output: " << result << std::endl;

    return 0;
}