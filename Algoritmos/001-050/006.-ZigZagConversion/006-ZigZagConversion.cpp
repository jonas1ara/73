#include <iostream>

std::string convert(std::string s, int numRows)
{
    if (numRows == 1)
        return s;
    int N = s.size(), d = (numRows - 1) * 2;
    std::string ans;
    for (int i = 0; i < numRows; ++i)
    {
        int w = 2 * i;
        for (int j = i; j < N;)
        {
            ans += s[j];
            w = d - w;
            if (!w)
                w = d;
            j += w;
        }
    }
    return ans;
}

int main()
{
    std::string s = "PAYPALISHIRING";
    int numRows = 3;

    std::cout << "Input: s = " << s << ", numRows = " << numRows << std::endl;

    std::string result = convert(s, numRows);

    std::cout << "Output: " << result << std::endl;

    return 0;
}