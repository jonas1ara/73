using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
				int t = target - nums[i];

                if (dic.ContainsKey(t)) return new int[] { dic[t], i };
    
                dic[nums[i]] = i;
            }

            return new int[] { };
        }
    
	    public static void Main (string[] args)
        {
            int[] nums = { 2, 1, 5, 3 };
            int target = 4;
	
			Console.WriteLine("Input: nums = [" + String.Join(", ", nums) + "], target = " + target);

    		int[] result = TwoSum(nums, target);	
			Console.WriteLine("Output: [" + String.Join(", ",result) + "]");
	

        }
    }
}
