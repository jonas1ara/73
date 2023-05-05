#include <iostream>

bool isPalindrome(int x)
{
    if (x < 0)
        return false;
    long long a = x, b = 0;
    while (x)
    {
        b = b * 10 + x % 10;
        x /= 10;
    }
    return a == b;
}

int main()
{
    int x = 121;

    std::cout << "Input: x = " << x << std::endl;

    bool result = isPalindrome(x);

    std::cout << "Output: " << result << std::endl;

    return 0;


}