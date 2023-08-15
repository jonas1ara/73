using System;
using System.Collections.Generic;

namespace ContainerWithMostWater
{
    public class Solution 
    {
        public int MaxArea(int[] height)
        {
            int ans = 0, L = 0, R = height.Length - 1;
            while (L < R)
            {
                ans = Math.Max(ans, (R - L) * Math.Min(height[L], height[R]));
                if (height[L] < height[R]) L++; // Move the smaller edge
                else R--;
            }
            return ans;
        }
        public static void Main(String[] args)
        {
            int[] height = new int[] {1,8,6,2,5,4,8,3,7};

            Console.WriteLine("Input: height = [" + string.Join(" ", height) + "]"); 

            int ans = new Solution().MaxArea(height);
            Console.WriteLine("Output: " + ans);


        }
    }   
}
