#include <iostream>
#include <vector>
#include <algorithm>

class Interval
{
public:
    int start, end;
    Interval(int start, int end)
    {
        this->start = start;
        this->end = end;
    }
};

class Solution
{
public:
    bool canAttendMeetings(std::vector<Interval> &intervals)
    {
        std::sort(intervals.begin(), intervals.end(), [&](Interval &a, Interval &b)
                  { return a.start < b.start; });
        for (int i = 1; i < intervals.size(); ++i)
        {
            if (intervals[i].start < intervals[i - 1].end)
                return false;
        }
        return true;
    }
};

int main()
{
    // Crea un vector de Intervalos para probar la función canAttendMeetings
    std::vector<Interval> intervals;
    intervals.push_back(Interval(5, 8));
    intervals.push_back(Interval(9, 15));

    Solution solution;
    bool canAttend = solution.canAttendMeetings(intervals);

    if (canAttend)
    {
        std::cout << "Puede asistir a todas las reuniones." << std::endl;
    }
    else
    {
        std::cout << "No puede asistir a todas las reuniones." << std::endl;
    }

    return 0;
}
