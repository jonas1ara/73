# Container With Most Water:

This directory contains implementations of the "Container With Most Water" problem in the C++ and C# languages. Each implementation uses two pointers technique to find two lines that together with the x-axis form a container, such that the container contains the most water and maintain a temporal complexity of `O(n)`.

## Problem description

You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

Find two lines that together with the x-axis form a container, such that the container contains the most water.

Return the maximum amount of water a container can store.

Notice that you may not slant the container.

- Example 1:

```
Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.
```

- Example 2:

```
Input: height = [1,1]
Output: 1
```

## Solution:

The easy and intuitive way to solve this problem is just check every combination of two values and if they can sum up to our target, that is, iterate the array using two for cycles and compare each value of the array to verify if it is the desired sum. If you can do that, congratulations! Once you've solved the problem, you just have to implement it in a computationally fast way and that's the reason why a hash table is needed to go from a quadratic time complexity O(n^2) to a linear time complexity O(n), and it's also a good perspective on when to use a hash table to solve certain types of problems.

Let's go through the array `height = {1, 8, 6, 2, 5, 4, 8, 3, 7}` to understand how the algorithm works step by step: 

1. Variable initialization:
 
    - `ans = 0` (initial maximum area)
    - `left = 0` (initial left edge)
    - `right = height.size() - 1` (initial right edge)

2. First iteration:

    - `left = 0`, `right = 8` 
    - Heights: `height[left] = 1`, `height[right] = 7`
    - Calculated area: `area = (8 - 0) * min(1, 7) = 8 * 1 = 8`
    - `ans` is updated to `8`

3. Second iteration:
    
    - `left = 0`, `right = 7` 
    - Heights: `height[left] = 1`, `height[right] = 3`
    - Calculated area: `area = (7 - 0) * min(1, 3) = 7 * 1 = 7`
    - `ans` remains in `8` (8 > 7)

4. Third iteration:

    - `left = 0`, `right = 6` 
    - Heights: `height[left] = 1`, `height[right] = 8`
    - Calculated area: `area = (6 - 0) * min(1, 8) = 6 * 1 = 6`
    - `ans` remains in `8`

5. Fourth iteration:

    - `left = 0`, `right = 5` 
    - Heights: `height[left] = 1`, `height[right] = 4`
    - Calculated area: `area = (5 - 0) * min(1, 4) = 5 * 1 = 5`
    - `ans` remains in `8`

6. Fifth iteration: 

    - `left = 0`, `right = 4` 
    - Heights: `height[left] = 1`, `height[right] = 5`
    - Calculated area: `area = (4 - 0) * min(1, 5) = 4 * 1 = 4`
    - `ans` remains in `8`

7. Sixth iteration:

    - `left = 0`, `right = 3` 
    - Heights: `height[left] = 1`, `height[right] = 2`
    - Calculated area: `area = (3 - 0) * min(1, 2) = 3 * 1 = 3`
    - `ans` remains in `8`

8. Seventh iteration:
 
    - `left = 0`, `right = 2` 
    - Heights: `height[left] = 1`, `height[right] = 6`
    - Calculated area: `area = (2 - 0) * min(1, 6) = 2 * 1 = 2`
    - `ans` remains in `8`

9. Eighth iteration:
    -  `left = 0`, `right = 1`
    - Heights: `height[left] = 1`, `height[right] = 8` 
    - Calculated area: `area = (1 - 0) * min(1, 8) = 1 * 1 = 1`
    - `ans` remains in 8

10. New iteration:
    - `left = 1`, `right = 1` (indices crossed, cycle ends)

11. Result:
    - The maximum area found is `ans = 8`, which is the largest possible container area with the given heights


This algorithm uses the two-pointer technique (`left` and `right`) to find the solution efficiently, reducing the temporal complexity to `O(n)`, where `n` is the size of the height array.


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
                left++; // Move the smaller edge
            else
                right--; // Move the larger edge
        }

        return ans;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public int[] TwoSum(int[] nums, int target)` : Define a public method called `TwoSum` that takes two parameters: an array of `nums` integers and a `target` integer. Returns an integer array representing the indices of the two numbers whose sum equals the target.

3. `var dic = new Dictionary<int, int>();` :  Create an integer dictionary (int), where the `key` will be a number of the nums array and the `value` will be its index in the array. **This dictionary will be used to keep track of the numbers that have been seen during the iteration.**

4. `for (int i = 0; i < nums.Length; i++)` : Initialites a for loop that iterate through all the elements of the `nums` array.

5. `int t = target - nums[i];` : Calculate the difference `t` between the `target` and the current number of the array at position `i`.

6. `if (dic.ContainsKey(t))` : Check if the key `t` is present in the dictionary. **This means that a number has already been found whose sum with the current number equals the `target`.**

7. `return new int[] { dic[t], i };` : If a pair of numbers is found whose sum equals the 'target', it returns an integer array containing the indices of those two numbers in the `nums` array.

8. `dic[nums[i]] = i;` : Adds the current number of the `nums` array as a key to the `dic` dictionary, with its value being the current index `i`. **This makes it possible to track which numbers have been seen during the iteration.**

9. `return new int[] { }` : If the sum has no solution, return the empty array.

### C++ :

```cpp
// Using two pointers technique - Time: O(n)

class Solution {
public:
    int maxArea(std::vector<int> &height)
    {
        int ans = 0, left = 0, right = height.size() - 1;

        while (left < right)
        {
            ans = std::max(ans, (right - left) * std::min(height[left], height[right]));
            
			if (height[left] < height[right])
                left++; // Move the smaller edge
            else
                right--; // Move the larger edge
        }

        return ans;
    }
};
```

1. `class Solution {public: ...};` : Define a public class called `Solution`.

2. `std::vector<int> twoSum(std::vector<int> &nums, int target)` : Define a function called `TwoSum` that takes two parameters: a vector of integers `nums` by reference and a `target` integer. Returns a vector representing the indices of the two numbers whose sum equals the target.

3. `std::map<int, int> map;` :  Create a `map`, where the `key` will be a number of the nums array and the `value` will be its index in the array. **This dictionary will be used to keep track of the numbers that have been seen during the iteration.**

4. `for (int i = 0; i < nums.size(); i++)` : Initialites a for loop that iterate through all the elements of the `nums` array.

5. `int t = target - nums[i];` : Calculate the difference `t` between the `target` and the current number of the array at position `i`.

6. `if (map.count(t))` : Check if the key `t` is present in the dictionary. **This means that a number has already been found whose sum with the current number equals the `target`.**

7. `return {map[t], i};` : If a pair of numbers is found whose sum equals the 'target', it returns an integer array containing the indices of those two numbers in the `nums` array.

8. `map[nums[i]] = i;` : Adds the current number of the `nums` array as a key to the `dic` dictionary, with its value being the current index `i`. **This makes it possible to track which numbers have been seen during the iteration.**

9. `return {}` : If the sum has no solution, return the empty array.


