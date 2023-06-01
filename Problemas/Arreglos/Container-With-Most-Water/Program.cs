using System;
using System.Collections.Generic;

//public int MaxArea(int[] height)
int MaxArea(List<int> height)
{
    // int R = height.Length - 1;
    int R = height.Count - 1;
    int ans = 0, L = 0;
    while (L < R)
    {
        // A = b * h
        ans = Math.Max(ans, (R - L) * Math.Min(height[L], height[R]));

        if (height[L] < height[R]) L++; // Move the smaller edge
        else R--;
    }
    return ans;
}

//int[] height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
List<int> height = new List<int>() { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

Console.WriteLine("Input: " + string.Join(" ", height));

Console.WriteLine("Output: " + MaxArea(height));

