using System;

// Using bottom-up approach - Time: O(n)

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
}

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 2, 7, 9, 3, 1 };
        Console.WriteLine("Input: nums = [" + string.Join(", ", nums) + "]");

        Solution sol = new Solution();
        int result = sol.Rob(nums);
        
        Console.WriteLine("Output: " + result);
    }
}
