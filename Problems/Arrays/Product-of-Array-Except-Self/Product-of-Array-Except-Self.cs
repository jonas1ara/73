using System;

// Using prefix and postfix - Time O(n)
public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];
        result[0] = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            result[i] = result[i - 1] * nums[i - 1];
        }

        int rightSide = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            result[i] = result[i] * rightSide;
            rightSide *= nums[i]; // rightSide = rightSide * nums[i];
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 4 };

        // Print intput
        Console.Write("Input: nums = [");
        foreach (int n in nums)
        {
            Console.Write(n + "");
            if (n != nums[nums.Length - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        int[] result = sol.ProductExceptSelf(nums);

        // Print intput
        Console.Write("Output: [");
        foreach (int r in result)
        {
            Console.Write(r + "");
            if (r != result[result.Length - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");
    }
}
