using System;

public class Solution
{
    public int FindMin(int[] nums)
    {
        int L = 0;
        int R = nums.Length - 1;

        while (L < R)
        {
            int M = (L + R) / 2;

            if (nums[M] > nums[R])
            {
                L = M + 1;
            }
            else
            {
                R = M;
            }
        }

        return nums[L];
    }
    
    public static void Main(string[] args)
    {
        int[] nums = new int[] { 3, 4, 5, 1, 2 };
        Console.WriteLine(new Solution().FindMin(nums));
    }
}
