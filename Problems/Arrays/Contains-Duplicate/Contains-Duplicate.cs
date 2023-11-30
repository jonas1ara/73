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
        bool result = sol.ContainsDuplicate(nums);

        // Print output
        Console.WriteLine("Output: " + result);
    }
}