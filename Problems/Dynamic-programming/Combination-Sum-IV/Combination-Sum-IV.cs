using System;
using System.Collections.Generic;

// Using top-down approach - Time: O(n * amount)

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
        int[] nums = { 1, 2, 3 };
        int target = 4;

        Console.Write("Input: nums = [");
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write(nums[i]);
            if (i < nums.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("], target = " + target);

        Solution sol = new Solution();
        int result = sol.CombinationSum4(nums, target);

        Console.WriteLine("Output: " + result);
    }
}
