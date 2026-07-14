# 3Sum:

This directory contains an implementation of the "3Sum" problem in C#. The implementation sorts the array and uses the two-pointer technique to find all unique triplets that sum to zero with a temporal complexity of `O(n^2)`.

## Problem description

Given an integer array `nums`, return all the triplets `[nums[i], nums[j], nums[k]]` such that `i != j`, `i != k`, and `j != k`, and `nums[i] + nums[j] + nums[k] == 0`.

Notice that the solution set must not contain duplicate triplets.

- Example 1:

```
Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explanation:
nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0
nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0
nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0
The distinct triplets are [-1,0,1] and [-1,-1,2].
```

- Example 2:

```
Input: nums = [0,1,1]
Output: []
Explanation: The only possible triplet does not sum up to 0.
```

- Example 3:

```
Input: nums = [0,0,0]
Output: [[0,0,0]]
```

## Solution:

A brute-force triple loop is `O(n^3)`. After sorting, for each fixed index `i` the problem reduces to finding two numbers that sum to `-nums[i]`, which two pointers can do in linear time.

Steps:

1. Sort the array
2. For each `i`, set `j = i + 1` and `k = n - 1`
3. Move `j` right if the sum is too small, move `k` left if too large
4. When the sum is zero, record the triplet and skip duplicates

Let's go through `nums = {-1, 0, 1, 2, -1, -4}` after sorting `{-4, -1, -1, 0, 1, 2}`:

1. `i = 0`, `nums[i] = -4` → look for pair sum `4` → none
2. `i = 1`, `nums[i] = -1` → pair `(-1, 2)` works → triplet `[-1, -1, 2]`
3. Same `i`, pair `(0, 1)` works → triplet `[-1, 0, 1]`
4. Skip the next duplicate `-1`
5. Remaining starts do not add new unique triplets

Result: `[[-1, -1, 2], [-1, 0, 1]]`

## Implementations:

### C# :

```csharp
// Using two pointers technique - Time: O(n^2)

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        List<IList<int>> result = new List<IList<int>>();
        int n = nums.Length;

        if (n < 3)
        {
            return result;
        }

        Array.Sort(nums);

        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] > 0)
            {
                break;
            }
            if (i > 0 && nums[i - 1] == nums[i])
            {
                continue;
            }

            int j = i + 1;
            int k = n - 1;

            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];

                if (sum < 0)
                {
                    j++;
                }
                else if (sum > 0)
                {
                    k--;
                }
                else
                {
                    result.Add(new List<int> { nums[i], nums[j], nums[k] });

                    while (j < k && nums[j] == nums[j + 1])
                    {
                        j++;
                    }
                    j++;

                    while (j < k && nums[k - 1] == nums[k])
                    {
                        k--;
                    }
                    k--;
                }
            }
        }

        return result;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public IList<IList<int>> ThreeSum(int[] nums)` : Define a public method that returns all unique triplets summing to zero.

3. `if (n < 3) return result;` : Need at least three numbers.

4. `Array.Sort(nums);` : Sort so two pointers and duplicate skipping work.

5. Outer loop over `i`: fix the first element of the triplet.

6. `if (nums[i] > 0) break;` : All remaining values are positive, no zero-sum triplet possible.

7. Skip duplicate values of `nums[i]`.

8. Two pointers `j` and `k` search for a pair that completes the sum to zero.

9. On match, add the triplet and skip duplicate `j` / `k` values.

10. `return result;` : Return all unique triplets.

## Suggested practice 🎯

Same two-pointer after sorting pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [3Sum Closest](https://leetcode.com/problems/3sum-closest/)
- [3Sum Smaller](https://leetcode.com/problems/3sum-smaller/)
- [4Sum](https://leetcode.com/problems/4sum/)
