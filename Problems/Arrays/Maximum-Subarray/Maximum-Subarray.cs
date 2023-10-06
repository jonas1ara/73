using System;

public class Solution {
    public int MaxSubArray(int[] nums) {
        int ans = nums[0];
        for (int i = 1; i < nums.Length; ++i) {
            nums[i] += Math.Max(nums[i - 1], 0);
            ans = Math.Max(ans, nums[i]);
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        int[] nums = new int[] {-2,1,-3,4,-1,2,1,-5,4};
        Console.WriteLine(new Solution().MaxSubArray(nums));
    }
}
