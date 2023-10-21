using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        List<int[]> mergedIntervals = new List<int[]>();

        foreach (var interval in intervals)
        {
            if (mergedIntervals.Count == 0 || interval[0] > mergedIntervals.Last()[1])
            {
                mergedIntervals.Add(interval);
            }
            else
            {
                mergedIntervals.Last()[1] = Math.Max(mergedIntervals.Last()[1], interval[1]);
            }
        }

        return mergedIntervals.ToArray();
    }
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] intervals = new int[][]
        {
            new int[] {1, 3},
            new int[] {2, 6},
            new int[] {8, 10},
            new int[] {15, 18}
        };

        int[][] mergedIntervals = solution.Merge(intervals);

        Console.WriteLine("Merged Intervals:");
        foreach (var interval in mergedIntervals)
        {
            Console.WriteLine($"[{interval[0]}, {interval[1]}]");
        }
    }
}



