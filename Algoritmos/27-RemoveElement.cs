using System;

namespace LeetCode
{
    class Program
    {
        public static int RemoveElement(int[] nums, int val)
        {
            var lastIndex = nums.Length - 1;

            for (int i = 0; i <= lastIndex; i++)
            {
                if (nums[i] == val)
                {
                    nums[i--] = nums[lastIndex--];
                }
            }

            return lastIndex + 1;
        }
        public static void Main (string[] args)
        {
            var nums = new int[] { 3, 2, 2, 3 };
            var val = 3;
            var Result = RemoveElement(nums, val);
            Console.WriteLine(Result);
        }
    }
}