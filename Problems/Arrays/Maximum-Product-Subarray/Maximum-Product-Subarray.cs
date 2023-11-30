using System;

// Using two pointers technique - Time O(n)

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
                prod *= nums[j++]; // prod = prod * nums[j]
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
                j++;
            }
        }

        return ans;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        int[] nums = { 2, 3, -2, 4 };

        // Print input
        Console.Write("Input: nums = [");
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write(nums[i] + "");
            if (i < nums.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        int result = sol.MaxProduct(nums);

        // Print output
        Console.WriteLine("Output " + result);
    }
}
