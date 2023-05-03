#include <iostream>

using namespace std;

bool isPerfectSquare(int num)
{
    long L = 1, R = num;
    while (L <= R)
    {
        long M = L + (R - L) / 2;
        if (M * M == num)
            return true;
        if (num / M < M)
            R = M - 1;
        else
            L = M + 1;
    }
    return false;
}

int main()
{
    int num = 16;

    cout << isPerfectSquare(num) << endl;

    return 0;
}