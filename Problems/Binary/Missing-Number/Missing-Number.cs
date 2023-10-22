using System;

public class Solution {
    public int MissingNumber(int[] nums) {
        int n = nums.Length;
        int xorVal = 0;
        for (int i = 0; i < n; i++) {
            xorVal ^= nums[i] ^ (i + 1);
        }
        return xorVal;
    }

    public static void Main(string[] args) {
        int[] nums = new int[] { 3, 0, 1 };
        Console.WriteLine(new Solution().MissingNumber(nums));
    }
}
