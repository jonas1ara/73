#include <iostream>
#include <vector>
#include <algorithm>
#include <queue>

// Using a greedy algorithm - Time: O(nlogn)

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
    int minMeetingRooms(std::vector<Interval> &intervals)
    {
        std::vector<int> starts, ends;

        for (const Interval &interval : intervals)
        {
            starts.push_back(interval.start);
            ends.push_back(interval.end);
        }

        sort(starts.begin(), starts.end());
        sort(ends.begin(), ends.end());

        int rooms = 0;  
        int endIdx = 0; 

        for (int i = 0; i < intervals.size(); i++)
        {
            if (starts[i] < ends[endIdx])
            {
                rooms++;
            }
            else
            {
                endIdx++;
            }
        }

        return rooms;
    }
};

int main()
{
    std::vector<Interval> intervals;
    intervals.push_back(Interval(0, 30));
    intervals.push_back(Interval(5, 10));
    intervals.push_back(Interval(15, 20));

    std::cout << "Input: intervals = [";
    for (int i = 0; i < intervals.size(); i++)
    {
        std::cout << "[" << intervals[i].start << "," << intervals[i].end << "]";
        if (i != intervals.size() - 1)
        {
            std::cout << ",";
        }
    }
    std::cout << "]" << std::endl;

    Solution sol;
    int ans = sol.minMeetingRooms(intervals);
    
    std::cout << "Output: " << ans << std::endl;

    return 0;
}
