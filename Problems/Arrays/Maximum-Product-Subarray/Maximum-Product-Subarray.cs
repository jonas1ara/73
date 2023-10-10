using System;
public class Solution
{
    public int MaxProduct(int[] nums)
    {
        int ans = nums[0];
        int N = nums.Length;
        int j = 0;

        while (j < N)
        {
            int i = j;
            int prod = 1;

            while (j < N && nums[j] != 0)
            {
                prod *= nums[j++];
                ans = Math.Max(ans, prod);
            }

            if (j < N)
            {
                ans = Math.Max(ans, 0);
            }

            while (i < N && prod < 0)
            {
                prod /= nums[i++];
                if (i != j)
                {
                    ans = Math.Max(ans, prod);
                }
            }

            while (j < N && nums[j] == 0)
            {
                ++j;
            }
        }

        return ans;
    }

    public static void Main(string[] args)
    {
        int[] nums = new int[] { 2, 3, -2, 4 };
        Console.WriteLine(new Solution().MaxProduct(nums));
    }
}
