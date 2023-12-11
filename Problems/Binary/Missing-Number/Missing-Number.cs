using System;

// Using XOR operation - Time: O(n)
public class Solution
{
    public int MissingNumber(int[] nums)
    {
        int n = nums.Length;
        int xorVal = 0;
        for (int i = 0; i < n; i++)
            xorVal ^= nums[i] ^ (i + 1);

        return xorVal;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 3, 0, 1 };
        Console.WriteLine("Input: nums = " + string.Join(", ", nums));

        Solution sol = new Solution();  
        int ans = sol.MissingNumber(nums);

        Console.WriteLine("Output: " + ans);
    }
}
