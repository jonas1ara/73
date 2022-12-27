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
                if (dic.ContainsKey(nums[i]))
                    return new int[] { dic[nums[i]], i };
                else
                    dic[target - nums[i]] = i;
            }

            return new int[] { };
        }
        public static void Main (string[] args)
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;
            int[] Result = TwoSum(nums, target);
            
            Console.WriteLine("[" + Result[0] + ", " + Result[1] + "]");
        }
    }
}