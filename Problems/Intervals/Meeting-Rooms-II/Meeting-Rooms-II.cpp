#include <iostream>
#include <vector>
#include <algorithm>
#include <queue>

using namespace std;

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
    int minMeetingRooms(vector<Interval> &intervals)
    {
        // Create vectors to store the start and end times
        vector<int> starts, ends;

        // Populate the start and end vectors from the intervals
        for (const Interval &interval : intervals)
        {
            starts.push_back(interval.start);
            ends.push_back(interval.end);
        }

        // Sort the start and end times
        sort(starts.begin(), starts.end());
        sort(ends.begin(), ends.end());

        int rooms = 0;  // Number of rooms required
        int endIdx = 0; // Index for the end times

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
    Solution solution;
    vector<Interval> intervals;
    // Initialize 'intervals' with your meeting time intervals

    intervals.push_back(Interval(0, 30));
    intervals.push_back(Interval(5, 10));
    intervals.push_back(Interval(15, 20));

    int minRooms = solution.minMeetingRooms(intervals);
    cout << "Minimum meeting rooms required: " << minRooms << endl;

    return 0;
}
