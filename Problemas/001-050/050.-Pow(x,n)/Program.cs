using System;

double MyPow(double x, int n)
{
    if (x == 0 || x == 1) return x;
    if (n == 0) return 1;

    var temp = MyPow(x, n / 2);

    if (n % 2 == 0) return temp * temp;
    return n > 0 ? x * temp * temp : (temp * temp) / x;
}