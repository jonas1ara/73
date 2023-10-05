using System;
public class Solution
{
    public int Search(int[] nums, int target)
    {
        if (nums.Length == 0)
            return -1;

        int N = nums.Length;
        int L = 0, R = N - 1, pivot;

        while (L < R)
        {
            int M = L + (R - L) / 2;
            if (nums[M] < nums[R])
                R = M;
            else
                L = M + 1;
        }
        pivot = L;
        L = 0;
        R = N - 1;

        while (L <= R)
        {
            int M = L + (R - L) / 2;
            int MM = (M + pivot) % N;

            if (nums[MM] == target)
                return MM;
            if (target > nums[MM])
                L = M + 1;
            else
                R = M - 1;
        }
        return -1;
    }
    public static void Main(string[] args)
    {
        int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
        int target = 0;
        Solution sol = new Solution();
        Console.WriteLine(sol.Search(nums, target));
    }
}

