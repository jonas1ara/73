using System;
using System.Collections.Generic;

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);

        return set.Count != nums.Length;
    }

    public static void Main(string[] args)
    {
        int[] nums = new int[] { 1, 2, 3, 1 };

        Console.WriteLine(new Solution().ContainsDuplicate(nums));
    }
}
