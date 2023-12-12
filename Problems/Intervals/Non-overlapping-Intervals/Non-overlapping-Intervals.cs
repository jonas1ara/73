using System;
using System.Collections.Generic;

// Using a greedy algorithm - Time: O(nlogn)

public class Solution
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

        int ans = 0;
        int end = int.MinValue; // end 

        foreach (var i in intervals)
        {
            if (i[0] >= end)
                end = i[1];
            else
                ans++;
        }

        return ans;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[][] intervals = new int[][] {
            new int[] {1, 2},
            new int[] {2, 3},
            new int[] {3, 4},
            new int[] {1, 3}
        };
        
        Console.Write("Input: intervals = [");
        foreach (var i in intervals)
        {
            Console.Write("[" + i[0] + "," + i[1] + "]");
            if(i != intervals[intervals.Length - 1])
                Console.Write(",");
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        int ans = sol.EraseOverlapIntervals(intervals);

        Console.WriteLine("Output: " + ans);
    }
}


