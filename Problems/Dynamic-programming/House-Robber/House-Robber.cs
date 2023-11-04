using System;

class Solution
{
    public int Rob(int[] nums)
    {
        int rob = 0, skip = 0;
        foreach (int n in nums)
        {
            int r = n + skip;
            int s = Math.Max(rob, skip);
            rob = r;
            skip = s;
        }
        return Math.Max(rob, skip);
    }

    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = { 2, 7, 9, 3, 1 };
        int result = solution.Rob(nums);
        Console.WriteLine("Result: " + result);
    }
}
