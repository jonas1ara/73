using System;
using System.Collections.Generic;

public class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        List<int[]> ans = new List<int[]>();
        int s = newInterval[0];
        int e = newInterval[1];

        foreach (int[] interval in intervals)
        {
            if (s > e)
            {
                ans.Add(interval);
            }
            else if (interval[1] < s)
            {
                ans.Add(interval);
            }
            else if (interval[0] > e)
            {
                ans.Add(new int[] { s, e });
                s = e + 1;
                ans.Add(interval);
            }
            else
            {
                s = Math.Min(s, interval[0]);
                e = Math.Max(e, interval[1]);
            }
        }

        if (s <= e)
        {
            ans.Add(new int[] { s, e });
        }

        return ans.ToArray();
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();

        int[][] intervals = new int[][] {
            new int[] {1, 3},
            new int[] {6, 9}
        };

        int[] newInterval = new int[] { 2, 5 };

        int[][] result = solution.Insert(intervals, newInterval);

        foreach (int[] interval in result)
        {
            Console.WriteLine("[" + interval[0] + ", " + interval[1] + "]");
        }
    }
}






