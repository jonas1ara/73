using System;

// Using binary search technique - Time: O(log n)

public class Solution
{
    public int Search(int[] nums, int target)
    {
        if (nums.Length == 0)
            return -1;

        int n = nums.Length, left = 0, right = n - 1, pivot;

        while (left < right)
        {
            int m = left + (right - left) / 2; // m is the index of the middle element

            if (nums[m] < nums[right])
                right = m;
            else
                left = m + 1;
        }
        pivot = left;
        left = 0;
        right = n - 1;

        while (left <= right)
        {
            int m = left + (right - left) / 2;
            int mm = (m + pivot) % n; // mm is the index of the middle element in the rotated array

            if (nums[mm] == target)
                return mm;
            if (target > nums[mm])
                left = m + 1;
            else
                right = m - 1;
        }

        return -1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 4, 5, 6, 7, 0, 1, 2 };
        int target = 0;

        // Print input
        Console.Write("Input: nums = [");
        foreach (int num in nums)
        {
            Console.Write(num + "");
            if (num != nums[nums.Length - 1])
                Console.Write(", ");
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        int result = sol.Search(nums, target);

        // Print output
        Console.WriteLine("Output: " + result);
    }
}

