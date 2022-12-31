using System;
using System.Collections.Generic;

int RemoveDuplicates(int[] nums)
{
    if (nums.Length <= 1) { return nums.Length; }

    var index = 0;
    var lastValue = nums[index];
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == lastValue) { continue; }

        nums[++index] = nums[i];
        lastValue = nums[index];
    }

    return index + 1;
}

int[] nums = {1, 1, 2};
Console.WriteLine("Input: [" + string.Join(", ", nums) + "]");
int length = RemoveDuplicates(nums);
Console.WriteLine("Output: " + length);
