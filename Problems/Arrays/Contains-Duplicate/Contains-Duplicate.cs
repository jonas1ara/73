using System;
using System.Collections.Generic;

// Using hash table - Time O(n)

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);

        return set.Count != nums.Length;
    }
}
class Program
{
    static void Main(string[] args)
    {
        int[] nums = {1, 2, 3, 1};

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
        bool result = sol.ContainsDuplicate(nums);

        // Print output
        Console.WriteLine("Output: " + result);
    }
}