#include <iostream>
#include <vector>
#include <algorithm>

// Using interval scheduling algorithm - Time: O(nlogn)

// Definition of Interval:

class Interval {
public:
    int start, end;
    Interval(int start, int end)
    {
        this->start = start;
        this->end = end;
    }
};

class Solution {
public:
    bool canAttendMeetings(std::vector<Interval> &intervals)
    {
        std::sort(intervals.begin(), intervals.end(), [&](Interval &a, Interval &b)
                  { return a.start < b.start; });

        for (int i = 1; i < intervals.size(); i++)
        {
            if (intervals[i].start < intervals[i - 1].end)
                return false;
        }

        return true;
    }
};

int main()
{
    std::vector<Interval> intervals;
    intervals.push_back(Interval(5, 8));
    intervals.push_back(Interval(9, 15));

    std::cout << "Input: intervals = [";
    for (int i = 0; i < intervals.size(); i++)
    {
        std::cout << "[" <<  intervals[i].start <<  "," << intervals[i].end << "]";
        if (i != intervals.size() - 1)
            std::cout << ",";
    }
    std::cout << "]"<< std::endl;

    Solution sol;
    bool ans = sol.canAttendMeetings(intervals);

    std::cout << "Output: " << std::boolalpha << ans << std::endl;

    return 0;
}
