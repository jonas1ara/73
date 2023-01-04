using System;
using System.Collections.Generic;

static int[] TwoSum(int[] nums, int target)
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
    
int[] nums = { 2, 1, 5, 3 };
int target = 4;
//Print the input
Console.WriteLine("Input: nums = [" + String.Join(", ", nums) + "], target = " + target);

int[] result = TwoSum(nums, target);	

//Print the output
Console.WriteLine("Output: [" + String.Join(", ",result) + "]");