using System;
using System.Collections.Generic;

// Using two pointers technique - Time: O(n)

public class Solution
{
    public int MaxArea(int[] height)
    {
        int ans = 0, left = 0, right = height.Length - 1;

        while (left < right)
        {
            ans = Math.Max(ans, (right - left) * Math.Min(height[left], height[right]));
            
			if (height[left] < height[right])
                left++; // Move the smaller edge
            else
                right--; // Move the larger edge
        }

        return ans;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] height = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

        // Print intput
        Console.Write("Input: height = [");
        foreach (int h in height)
        {
            Console.Write(h + "");
            if (h != height[height.Length - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        Solution solution = new Solution();
        int maxArea = solution.MaxArea(height);

        // Print output
        Console.WriteLine("Output: " + maxArea);
    }
}
