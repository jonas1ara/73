using System;
using System.Collections.Generic;

// Using linear search technique - Time: O(n)

public class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        List<int[]> ans = new List<int[]>();
        int start = newInterval[0];
        int end = newInterval[1];

        foreach (int[] interval in intervals)
        {
            if (start > end)
            {
                ans.Add(interval);
            }
            else if (interval[1] < start)
            {
                ans.Add(interval);
            }
            else if (interval[0] > end)
            {
                ans.Add(new int[] { start, end });
                start = end + 1;
                ans.Add(interval);
            }
            else
            {
                start = Math.Min(start, interval[0]);
                end = Math.Max(end, interval[1]);
            }
        }

        if (start <= end)
        {
            ans.Add(new int[] { start, end });
        }

        return ans.ToArray();
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[][] intervals = new int[][] {
            new int[] {1, 2},
            new int[] {3, 5},
            new int [] {6, 7},
            new int [] {8, 10},
            new int[] {12, 16}
        };

        int[] newInterval = new int[] { 4, 8 };

        Console.Write("Input: intervals = [");
        foreach (int[] interval in intervals)
        {
            Console.Write("[" + interval[0] + ", " + interval[1] + "]");
            if(interval != intervals[intervals.Length - 1])
            {
                Console.Write(", ");
            }
        }
        Console.Write("], newInterval = [" + newInterval[0] + ", " + newInterval[1] + "]\n");

        Solution sol = new Solution();
        int[][] ans = sol.Insert(intervals, newInterval);

        Console.Write("Output: [");
        foreach (int[] a in ans)
        {
            Console.Write("[" + a[0] + ", " + a[1] + "]");
            if(a != ans[ans.Length - 1])
            {
                Console.Write(", ");
            }
        }
        Console.Write("]\n");
    }
}