using System;

// Using Kadan's algorithm - Time: O(n)

public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int ans = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            nums[i] = nums[i] +  Math.Max(nums[i - 1], 0);
            ans = Math.Max(ans, nums[i]);
        }

        return ans;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

        // Print input
        Console.Write("Input: nums = [");
        foreach (int num in nums)
        {
            Console.Write(num + "");
            if (num != nums[nums.Length - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        int result = sol.MaxSubArray(nums);

        // Print output
        Console.WriteLine("Output: " + result);
    }
}
