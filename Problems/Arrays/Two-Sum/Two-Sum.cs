using System;
using System.Collections.Generic;

// Using hash table - Time: O(n)

public class Solution /* Define a public class Solution */
{
	public int[] TwoSum(int[] nums, int target)
	{
		var dic = new Dictionary<int, int>();

		for (int i = 0; i < nums.Length; i++)
		{
			int t = target - nums[i];

			// If the dictionary contains the key t, return the index of t and the current index i

			if (dic.ContainsKey(t)) 
				return new int[] { dic[t], i };

			dic[nums[i]] = i;
		}

		return new int[] { };
	}
}

class Program
{
    static void Main(String[] args)
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;

        Console.Write("Input: nums = [");
        foreach (int n in nums)
        {
            Console.Write(n + "");
            if (n != nums[nums.Length - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("], target = " + target);

        Solution sol = new Solution();
        int[] result = sol.TwoSum(nums, target);

        Console.Write("Output: [");
        foreach (int r in result)
        {
            Console.Write(r + "");
            if (r != result[result.Length - 1])
            {
                Console.Write(", ");
            }
        }
		Console.WriteLine("]");
    }
}





