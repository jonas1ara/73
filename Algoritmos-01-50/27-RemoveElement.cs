using System;
using System.Collections.Generic;

int RemoveElement(int[] nums, int val)
{
    var lastIndex = nums.Length - 1;

    for (int i = 0; i <= lastIndex; i++)
    {
        if (nums[i] == val)
            nums[i--] = nums[lastIndex--];
    }
    return lastIndex + 1;
}
        
int[] nums = {3, 2, 2, 3};
int val = 3;
Console.WriteLine("Input: nums = [" + string.Join(", ", nums) + "], val = " + val);
int length = RemoveElement(nums, val);
Console.WriteLine("Output: " + length);
