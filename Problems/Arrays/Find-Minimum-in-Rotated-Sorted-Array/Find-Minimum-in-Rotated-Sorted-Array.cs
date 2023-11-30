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
        int[] nums = {3, 4, 5, 1, 2 };

        // Print intput
        Console.Write("Input: nums = [");
        foreach (int n in nums)
        {
            Console.Write(n + "");
            if (n != nums[nums.Length - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        int result = sol.FindMin(nums);

        // Print output
        Console.WriteLine("Output: " + result);
    }
}
