using System;
using System.Collections.Generic;

public class Solution
{
    private Dictionary<int, int> m = new Dictionary<int, int> { { 0, 1 } };

    private int Dp(int[] nums, int target)
    {
        if (m.ContainsKey(target)) return m[target];
        int cnt = 0;
        foreach (int n in nums)
        {
            if (n > target) break;
            cnt += Dp(nums, target - n);
        }
        m[target] = cnt;
        return cnt;
    }

    public int CombinationSum4(int[] nums, int target)
    {
        Array.Sort(nums);
        return Dp(nums, target);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = { 1, 2, 3 };
        int target = 4;
        int result = solution.CombinationSum4(nums, target);
        Console.WriteLine("Result: " + result);
    }
}
