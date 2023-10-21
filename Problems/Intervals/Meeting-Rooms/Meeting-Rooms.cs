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
    public bool CanAttendMeetings(List<Interval> intervals)
    {
        intervals.Sort((a, b) => a.start - b.start);

        for (int i = 1; i < intervals.Count; ++i)
        {
            if (intervals[i].start < intervals[i - 1].end)
            {
                return false;
            }
        }
        return true;
    }

    public static void Main(string[] args)
    {
        // Crea una lista de Intervalos para probar la función CanAttendMeetings
        List<Interval> intervals = new List<Interval> {
            new Interval(0, 30),
            new Interval(5, 10),
            new Interval(15, 20)
        };

        Solution solution = new Solution();
        bool canAttend = solution.CanAttendMeetings(intervals);

        if (canAttend)
        {
            Console.WriteLine("Puede asistir a todas las reuniones.");
        }
        else
        {
            Console.WriteLine("No puede asistir a todas las reuniones.");
        }
    }
}


