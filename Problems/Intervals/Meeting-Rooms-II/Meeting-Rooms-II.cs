using System;
using System.Collections.Generic;

// Using a greedy algorithm - Time: O(nlogn)

// Definition of Interval:
public class Interval
{
    public int start, end;
    public Interval(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}

public class Solution
{
    public int MinMeetingRooms(List<Interval> intervals)
    {
        List<int> starts = new List<int>();
        List<int> ends = new List<int>();

        foreach (Interval interval in intervals)
        {
            starts.Add(interval.start);
            ends.Add(interval.end);
        }

        starts.Sort();
        ends.Sort();

        int rooms = 0;
        int endIdx = 0;

        for (int i = 0; i < intervals.Count; i++)
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
}


class Program
{
    static void Main(string[] args)
    {
        List<Interval> intervals = new List<Interval>();
        intervals.Add(new Interval(0, 30));
        intervals.Add(new Interval(5, 10));
        intervals.Add(new Interval(15, 20));

        Console.Write("Input: intervals =[");
        foreach (Interval interval in intervals)
        {
            Console.Write("[" + interval.start + "," + interval.end + "]");
            if (interval != intervals[intervals.Count - 1])
            {
                Console.Write(",");
            }
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        int ans = sol.MinMeetingRooms(intervals);

        Console.WriteLine("Output: " + ans);
    }
}
