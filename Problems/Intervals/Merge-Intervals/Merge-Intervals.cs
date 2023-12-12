using System;
using System.Collections.Generic;

// Using merge and quick sort - Time: O(nlogn)

public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 0)
        {
            return new int[0][];
        }

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> merged = new List<int[]>();
        merged.Add(intervals[0]);

        for (int i = 1; i < intervals.Length; i++)
        {
            if (merged.Last()[1] < intervals[i][0])
            {
                merged.Add(intervals[i]);
            }
            else
            {
                merged.Last()[1] = Math.Max(merged.Last()[1], intervals[i][1]);
            }
        }

        return merged.ToArray();
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        int[][] intervals = new int[][] {
            new int[] {1, 3},
            new int[] {2, 6},
            new int[] {8, 10},
            new int[] {15, 18}
        };

        Console.Write("Input: intervals = [");
        foreach (int[] interval in intervals)
        {
            Console.Write("[" + interval[0] + "," + interval[1] + "]");
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        int[][] merged = sol.Merge(intervals);

        Console.Write("Output: [");
        foreach (int[] interval in merged)
        {
            Console.Write("[" + interval[0] + "," + interval[1] + "]");
        }
        Console.WriteLine("]");
    }
}


