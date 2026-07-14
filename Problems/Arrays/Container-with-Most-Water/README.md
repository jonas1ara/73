# Container With Most Water:

This directory contains an implementation of the "Container With Most Water" problem in C#. The implementation uses the two-pointer technique to find the maximum area of water and maintain a temporal complexity of `O(n)`.

## Problem description

You are given an integer array `height` of length `n`. There are `n` vertical lines drawn such that the two endpoints of the `i`-th line are `(i, 0)` and `(i, height[i])`.

Find two lines that together with the x-axis form a container, such that the container contains the most water.

Return the maximum amount of water a container can store.

Notice that you may not slant the container.

- Example 1:

```
Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The vertical lines at indices 1 and 8 form a container of height min(8,7) = 7 and width 7, area = 49.
```

- Example 2:

```
Input: height = [1,1]
Output: 1
```

## Solution:

The area between indices `left` and `right` is:

`(right - left) * min(height[left], height[right])`

A brute-force check of every pair is `O(n^2)`.

The optimal two-pointer idea starts at both ends (maximum width) and repeatedly moves the shorter line inward:

- The width always decreases by 1
- Only by moving the shorter side can the height possibly increase enough to improve the area

Let's go through `height = {1, 8, 6, 2, 5, 4, 8, 3, 7}`:

1. `left = 0`, `right = 8` → area = `8 * min(1,7) = 8`
2. Move left (shorter) → `left = 1`, `right = 8` → area = `7 * min(8,7) = 49`
3. Move right → continue updating when better areas appear
4. Best remains `49`

## Implementations:

### C# :

```csharp
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
                left++;
            else
                right--;
        }

        return ans;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public int MaxArea(int[] height)` : Define a public method that returns the maximum water area.

3. `int ans = 0, left = 0, right = height.Length - 1;` : Initialize answer and two pointers at both ends.

4. `while (left < right)` : Process while the container has positive width.

5. `ans = Math.Max(ans, (right - left) * Math.Min(height[left], height[right]));` : Update the best area for the current pair of lines.

6. `if (height[left] < height[right]) left++; else right--;` : Move the shorter edge inward to try a taller boundary.

7. `return ans;` : Return the maximum area found.
