#include <iostream>
#include <vector>

class Solution
{
public:
    std::vector<std::vector<int>> insert(std::vector<std::vector<int>> &intervals, std::vector<int> &newInterval)
    {
        int s = newInterval[0], e = newInterval[1];
        std::vector<std::vector<int>> ans;
        for (auto &intv : intervals)
        {
            if (s > e)
                ans.push_back(intv);
            else if (intv[0] > e)
            {
                ans.push_back({s, e});
                s = e + 1;
                ans.push_back(intv);
            }
            else if (intv[1] < s)
                ans.push_back(intv);
            else
            {
                s = std::min(s, intv[0]);
                e = std::max(e, intv[1]);
            }
        }
        if (s <= e)
            ans.push_back({s, e});
        return ans;
    }
};

int main()
{
    Solution solution;

    // Ejemplo de uso: crea intervalos y un nuevo intervalo, y llama a la función 'insert'.
    std::vector<std::vector<int>> intervals = {{1, 3}, {6, 9}};
    std::vector<int> newInterval = {2, 5};

    std::vector<std::vector<int>> result = solution.insert(intervals, newInterval);

    // Imprimir el resultado.
    for (const auto &interval : result)
    {
        std::cout << "[" << interval[0] << ", " << interval[1] << "] ";
    }
    std::cout << std::endl;

    return 0;
}