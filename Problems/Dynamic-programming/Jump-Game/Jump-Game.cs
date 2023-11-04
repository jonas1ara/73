using System;

// DP
public class Solution
{
    public bool CanJump(int[] nums)
    {
        int n = nums.Length;
        bool[] dp = new bool[n];

        dp[0] = true;

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (dp[j] && j + nums[j] >= i)
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[n - 1];
    }
}

// Greedy

// public class Solution
// {
//     public bool CanJump(int[] A)
//     {
//         int last = 0;
//         for (int i = 0; i <= last; i++)
//         {
//             last = Math.Max(last, i + A[i]);
//             if (last >= A.Length - 1) return true;
//         }
//         return false;
//     }
// }

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int[] nums = { 2, 3, 1, 1, 4 };
        bool result = solution.CanJump(nums);

        if (result)
        {
            Console.WriteLine("Can jump to the end.");
        }
        else
        {
            Console.WriteLine("Cannot jump to the end.");
        }
    }
}
