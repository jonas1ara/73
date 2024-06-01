# Two sum:

This directory contains implementations of the "Two Sum" problem in the C, C++, and C# languages. Each implementation uses a hash table to find two numbers in a array that add up to a given target value and maintain a temporal complexity of O(n)

## Problem description

Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

- Example 1:

```
Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
```

- Example 2:

```
Input: nums = [3,2,4], target = 6
Output: [1,2]
```

## Solution:

The easy and intuitive way to solve this problem is just check every combination of two values and if they can sum up to our target, that is, iterate the array using two for cycles and compare each value of the array to verify if it is the desired sum. If you manage to do that, congratulations! Once you've solved the problem, you just have to implement it in a computationally fast way and that's the reason why a hash table is needed to go from a quadratic time complexity O(n^2) to a linear time complexity O(n), and it's also a good perspective on when to use a hash table to solve certain types of problems.

## Implementations:

### C# :

```csharp
// Using hash table - Time: O(n)

public class Solution
{
	public int[] TwoSum(int[] nums, int target)
	{
		var dic = new Dictionary<int, int>();

		for (int i = 0; i < nums.Length; i++)
		{
			int t = target - nums[i];

			//If the dictionary contains the key t, return the index of t and the current index i

			if (dic.ContainsKey(t)) 
				return new int[] { dic[t], i };

			dic[nums[i]] = i;
		}

		return new int[] { };
	}
}
```

1. `public class Solution` : Define a public class called Solution.

2. `public int[] TwoSum(int[] nums, int target)` : Define a public method called `TwoSum` that takes two parameters: an array of `nums` integers and a `target` integer. Returns an integer array representing the indices of the two numbers whose sum equals the target.

3. `var dic = new Dictionary<int, int>();` :  Create an integer dictionary (int), where the key will be a number of the nums array and the value will be its index in the array. This dictionary will be used to keep track of the numbers that have been seen during the iteration.

4. `for (int i = 0; i < nums.Length; i++)` : Initialites a for loop that iterate through all the elements of the `nums` array.

5. `int t = target - nums[i];` : Calculate the difference `t` between the `target` and the current number of the array at position `i`.

### C++ :

### C++++:


