#include "../../../Libraries/ArrayPrinter.h"
#include <iostream>
#include <vector>
#include <climits>

class Solution {
public:
    int maxProfit(std::vector<int> &A)
    {
        int buy = INT_MIN, sell = 0;
        for (int n : A)
        {
            buy = std::max(buy, -n);
            sell = std::max(sell, buy + n);
        }
        return sell;
    }
};

int main()
{
    std::vector<int> array = {7, 1, 5, 3, 6, 4};

    return 0;
}