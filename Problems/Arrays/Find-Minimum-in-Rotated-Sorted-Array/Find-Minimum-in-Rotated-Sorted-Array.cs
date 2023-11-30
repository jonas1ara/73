using System;

// Using binary search technique - Time O(log n)

public class Solution
{
    public int FindMin(int[] nums)
    {
        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            int m = (left + right) / 2; // middle index

            if (nums[m] > nums[right])
            {
                left = m + 1;
            }
            else
            {
                right = m;
            }
        }

        return nums[left];
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 3, 4, 5, 1, 2 };

        // Print input
        Console.Write("Input: nums = [");
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write(nums[i] + "");
            if (i < nums.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        int result = sol.FindMin(nums);

        // Print output
        Console.WriteLine("Output " + result);
    }
}
