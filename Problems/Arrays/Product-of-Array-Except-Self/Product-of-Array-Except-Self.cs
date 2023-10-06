using System;

public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];
        result[0] = 1;

        for (int i = 1; i < nums.Length; i++)
            result[i] = result[i - 1] * nums[i - 1];

        int rightSide = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            result[i] = result[i] * rightSide;
            rightSide *= nums[i];
        }

        return result;
    }
    public static void Main(string[] args)
    {
        var solution = new Solution();
        var result = solution.ProductExceptSelf(new int[] { 1, 2, 3, 4 });
        foreach (var item in result)
            Console.WriteLine(item);
    }

}
