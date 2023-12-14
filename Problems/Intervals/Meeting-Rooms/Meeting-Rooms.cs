using System;
using System.Collections.Generic;

// Using interval scheduling algorithm - Time: O(nlogn)

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
    public bool CanAttendMeetings(List<Interval> intervals)
    {
        intervals.Sort((a, b) => a.start - b.start);

        for (int i = 1; i < intervals.Count; i++)
        {
            if (intervals[i].start < intervals[i - 1].end)
            {
                return false;
            }
        }

        return true;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        List<Interval> intervals = new List<Interval> {
            new Interval(0, 30),
            new Interval(5, 10),
            new Interval(15, 20)
        };

        Console.Write("Input: intervals = [");
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
        bool ans = sol.CanAttendMeetings(intervals);

        Console.WriteLine("Output: " + ans);
    }
}


