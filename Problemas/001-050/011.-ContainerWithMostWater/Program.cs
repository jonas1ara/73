using System;

int MaxArea(int[] height)
{
    int left = 0, right = height.Length - 1;
    int result = 0;

    while (left < right)
    {
        var area = Math.Min(height[left], height[right]) * (right - left);
        result = Math.Max(result, area);

        if (height[left] <= height[right])
        {
            var temp = height[left];
            do
                left++;
            while (left < right && height[left] <= temp);
        }
        else
        {
            var temp = height[right];
            do
                right--;
            while (left < right && height[right] <= temp);
        }
    }
    return result;
}

