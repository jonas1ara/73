# Two sum:

This directory contains implementations of the "Two Sum" problem in the C, C++, and C# languages. Each implementation uses a hash table to find two numbers in a array that add up to a given target value and maintain a temporal complexity of `O(n)`.

## Problem description

Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

- Example 1:

```
Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1]
```

- Example 2:

```
Input: nums = [3,2,4], target = 6
Output: [1,2]
```

## Solution:

The easy and intuitive way to solve this problem is just check every combination of two values and if they can sum up to our target, that is, iterate the array using two for cycles and compare each value of the array to verify if it is the desired sum. If you can do that, congratulations! Once you've solved the problem, you just have to implement it in a computationally fast way and that's the reason why a hash table is needed to go from a quadratic time complexity O(n^2) to a linear time complexity O(n), and it's also a good perspective on when to use a hash table to solve certain types of problems.

Let's go through the array `nums = {2, 7, 11, 15}` with `target = 9` to understand how the algorithm works step by step: 

1. Hash table initialization:
 
    - The hash table is empty at first

2. First iteration (i = 0):

    - `nums[0] = 2` 
    - `t = target - nums[0] = 9 - 2 = 7`
    - The hash table is empty, `{2, 0}` is added to the hash table `{ table[2] = 0 }`

3. Second iteration (i = 1):

    - `nums[1] = 7`
    - `t = target - nums[1] = 9 - 7 = 2`
    - The hash table already contains key `2`, so it returns `{ table[2], 1 } = {0, 1}` 

4. Result:
    - A pair of numbers `(nums[0] and nums[1])` whose sum is equal to the `target` has been found
    - The function returns `{0, 1}`, which are the indices of the numbers `2` and `7` in the original array and these two numbers add up to `9`, which is the `target`

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

			if (dic.ContainsKey(t)) 
				return new int[] { dic[t], i };

			dic[nums[i]] = i;
		}

		return new int[] { };
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

// Using hash table - Time: O(n)

class Solution {
public:
    std::vector<int> twoSum(std::vector<int> &nums, int target)
    {
        std::map<int, int> map;

        for (int i = 0; i < nums.size(); i++)
        {
            int t = target - nums[i];

            if (map.count(t))
                return {map[t], i}; 

            map[nums[i]] = i;       
        }

        return {}; 
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

### C:

```c
// Using hash table - Time: O(n)

#define SIZE 10000

typedef struct
{
    int key;
    int value;
} HashNode;

typedef struct
{
    HashNode **array;
} HashMap;

HashMap *createHashMap()
{
    HashMap *map = (HashMap *)malloc(sizeof(HashMap));
    map->array = (HashNode **)calloc(SIZE, sizeof(HashNode *));
    return map;
}

void insert(HashMap *map, int key, int value)
{
    int index = abs(key) % SIZE;
    while (map->array[index] != NULL && map->array[index]->key != key)
    {
        index = (index + 1) % SIZE;
    }
    if (map->array[index] == NULL)
    {
        map->array[index] = (HashNode *)malloc(sizeof(HashNode));
    }
    map->array[index]->key = key;
    map->array[index]->value = value;
}

int search(HashMap *map, int key)
{
    int index = abs(key) % SIZE;
    while (map->array[index] != NULL)
    {
        if (map->array[index]->key == key)
        {
            return map->array[index]->value;
        }
        index = (index + 1) % SIZE;
    }
    return -1;
}

int *twoSum(int *nums, int numsSize, int target, int *returnSize)
{
    HashMap *map = createHashMap();
    for (int i = 0; i < numsSize; i++)
    {
        int t = target - nums[i];
        int searchIndex = search(map, t);

        //If the hash table contains the key, return the index and the current index i
        if (searchIndex != -1)
        {
            int *result = (int *)malloc(2 * sizeof(int));
            result[0] = searchIndex;
            result[1] = i;
            *returnSize = 2;
            return result;
        }
        insert(map, nums[i], i);
    }

    *returnSize = 0;
    return NULL; 
}
```


