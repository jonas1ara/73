# Contains Duplicate:

This directory contains implementations of the "Contains Duplicate" problem in the C++ and C# languages. Each implementation uses a hash set to check whether any value appears at least twice and maintain a temporal complexity of `O(n)`.

## Problem description

Given an integer array `nums`, return `true` if any value appears at least twice in the array, and return `false` if every element is distinct.

- Example 1:

```
Input: nums = [1,2,3,1]
Output: true
Explanation: The number 1 appears twice in the array.
```

- Example 2:

```
Input: nums = [1,2,3,4]
Output: false
Explanation: All numbers are distinct.
```

- Example 3:

```
Input: nums = [1,1,1,3,3,4,3,2,4,2]
Output: true
```

## Solution:

The easy and intuitive way to solve this problem is to compare every pair of elements with two nested loops and check if any two values are equal. That works, but it has quadratic time complexity `O(n^2)`.

A faster approach is to use a hash set. A set only stores unique values, so if we insert every element of the array into a set and the set ends up smaller than the array, there must be duplicates. Building the set takes linear time `O(n)` on average.

Let's go through the array `nums = {1, 2, 3, 1}` to understand how the algorithm works step by step:

1. Hash set construction:

    - Insert every element into the set: `{1, 2, 3}`
    - The set has size `3`, the array has size `4`

2. Comparison:

    - `set.Count != nums.Length` → `3 != 4` → `true`
    - There is at least one duplicate

In this case, the algorithm returns `true` because `1` appears twice.

## Implementations:

### C# :

```csharp
// Using hash table - Time O(n)

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);

        return set.Count != nums.Length;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public bool ContainsDuplicate(int[] nums)` : Define a public method that takes an integer array `nums` and returns whether it contains any duplicate.

3. `HashSet<int> set = new HashSet<int>(nums);` : Build a hash set from the array. **Only unique values are kept.**

4. `return set.Count != nums.Length;` : If the set is smaller than the array, at least one value was discarded as a duplicate, so return `true`. Otherwise return `false`.

### C++ :

```cpp
// Using hash table - Time O(n)

class Solution {
public:
    bool containsDuplicate(std::vector<int> &nums)
    {
        std::unordered_set<int> s(begin(nums), end(nums));
        return s.size() != nums.size();
    }
};
```

1. `class Solution {public: ...};` : Define a public class called `Solution`.

2. `bool containsDuplicate(std::vector<int> &nums)` : Define a function that takes a vector of integers by reference and returns whether it contains any duplicate.

3. `std::unordered_set<int> s(begin(nums), end(nums));` : Build an unordered set from the vector. **Only unique values are kept.**

4. `return s.size() != nums.size();` : If the set is smaller than the vector, there is at least one duplicate.
