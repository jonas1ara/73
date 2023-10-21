using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int EraseOverlapIntervals(int[][] A)
    {
        Array.Sort(A, (a, b) => a[1].CompareTo(b[1]));
        int ans = 0;
        int e = int.MinValue;

        foreach (var v in A)
        {
            if (v[0] >= e)
                e = v[1];
            else
                ans++;
        }

        return ans;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] intervals = new int[][] {
            new int[] {1, 3},
            new int[] {2, 4},
            new int[] {3, 5},
            new int[] {4, 6}
        };

        int result = solution.EraseOverlapIntervals(intervals);

        Console.WriteLine("Minimum number of intervals to remove: " + result);
    }
}


