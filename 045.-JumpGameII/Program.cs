using System;

int Jump(int[] nums)
{
    int maxRight = 0, currentRight = 0, count = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        if (i > maxRight) { return 0; }
        if (i > currentRight)
        {
            count++;
            currentRight = maxRight;

        }
        if (i + nums[i] > maxRight) { maxRight = i + nums[i]; }
    }

    return count;
}