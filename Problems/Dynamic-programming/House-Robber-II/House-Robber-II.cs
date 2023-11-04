using System;

class Solution
{
    private int Rob(int[] nums, int start, int end)
    {
        if (start == end) return 0;
        if (start + 1 == end) return nums[start];
        int prev2 = 0, prev = 0;
        for (int i = start; i < end; ++i)
        {
            int cur = Math.Max(prev, nums[i] + prev2);
            prev2 = prev;
            prev = cur;
        }
        return prev;
    }

    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        return Math.Max(Rob(nums, 1, nums.Length), Rob(nums, 0, nums.Length - 1));
    }

    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = { 2, 3, 2 };
        int result = solution.Rob(nums);
        Console.WriteLine("Result: " + result);
    }
}
