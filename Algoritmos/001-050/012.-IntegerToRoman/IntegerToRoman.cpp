#include <iostream>

std::string symbols = "MDCLXVI";
int values[7] = {1000, 500, 100, 50, 10, 5, 1};

std::string intToRoman(int num)
{
    std::string ans;
    for (int i = 0; i < 7; i += 2)
    {
        int d = num / values[i];
        if (d == 0)
            continue;
        if (d <= 3)
        {
            while (d--)
                ans += symbols[i];
        }
        else if (d == 4)
        {
            ans += symbols[i];
            ans += symbols[i - 1];
        }
        else if (d == 5)
        {
            ans += symbols[i - 1];
        }
        else if (d <= 8)
        {
            ans += symbols[i - 1];
            for (int j = 5; j < d; ++j)
                ans += symbols[i];
        }
        else
        {
            ans += symbols[i];
            ans += symbols[i - 2];
        }
        num %= values[i];
    }
    return ans;
}

int main()
{
    int num = 1994;

    std::cout << "Input: " << num << std::endl;

    std::cout << "Output: " << intToRoman(num) << std::endl;

    return 0;
}