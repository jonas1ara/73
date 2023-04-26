#include <iostream>
#include <string>
#include <algorithm>
#include <climits>

int reverse(int x)
{
    if (x == INT_MIN)
        return 0;
    int r = 0, sign = x >= 0 ? 1 : -1, y = sign * x, p = 1;
    while (y)
    {
        y /= 10;
        if (y)
            p *= 10;
    }
    x = sign * x;
    while (x)
    {
        int d = x % 10;
        x /= 10;
        if ((INT_MAX - r) / p < d)
            return 0;
        r += p * d;
        p /= 10;
    }
    return sign * r;
}

int main()
{
    int x = 123;

    std::cout << "Input: x = " << x << std::endl;

    int result = reverse(x);

    std::cout << "Output: " << result << std::endl;

    return 0;


}