using System;
using System.Collections.Generic;
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
        // Create lists to store the start and end times
        List<int> starts = new List<int>();
        List<int> ends = new List<int>();

        // Populate the start and end lists from the intervals
        foreach (Interval interval in intervals)
        {
            starts.Add(interval.start);
            ends.Add(interval.end);
        }

        // Sort the start and end times
        starts.Sort();
        ends.Sort();

        int rooms = 0;  // Number of rooms required
        int endIdx = 0; // Index for the end times

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

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        List<Interval> intervals = new List<Interval>();

        // Initialize 'intervals' with your meeting time intervals
        intervals.Add(new Interval(0, 30));
        intervals.Add(new Interval(5, 10));
        intervals.Add(new Interval(15, 20));

        int minRooms = solution.MinMeetingRooms(intervals);
        Console.WriteLine("Minimum meeting rooms required: " + minRooms);
    }
}
