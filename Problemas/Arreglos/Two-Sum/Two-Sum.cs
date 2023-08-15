using System;
using System.Collections.Generic;

namespace TwoSum
{
	class Program
	{
		public static int[] TwoSum(int[] nums, int target)
		{
			var dic = new Dictionary<int, int>();

			for (int i = 0; i < nums.Length; i++)
			{
				int t = target - nums[i]; 
				
				//If the dictionary contains the key t, return the index of t and the current index
				if (dic.ContainsKey(t)) return new int[] { dic[t], i }; 
				
				dic[nums[i]] = i; 
			}
			return new int[] { }; //If the sum has no solution, return the empty array
		}
		public static void Main(String[] args)
		{
			int[] nums = { 2, 7, 11, 15 };
			int target = 9;
			int[] result = TwoSum(nums, target);

			foreach (var item in result)
			{
				Console.Write(item + " ");
			}
			Console.WriteLine();
		}
	}
}





