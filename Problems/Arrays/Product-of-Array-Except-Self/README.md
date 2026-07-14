# Product of Array Except Self:

This directory contains an implementation of the "Product of Array Except Self" problem in C#. The implementation uses prefix and postfix products to build the answer without division and maintain a temporal complexity of `O(n)`.

## Problem description

Given an integer array `nums`, return an array `answer` such that `answer[i]` is equal to the product of all the elements of `nums` except `nums[i]`.

The product of any prefix or suffix of `nums` is guaranteed to fit in a 32-bit integer.

You must write an algorithm that runs in `O(n)` time and without using the division operation.

- Example 1:

```
Input: nums = [1,2,3,4]
Output: [24,12,8,6]
```

- Example 2:

```
Input: nums = [-1,1,0,-3,3]
Output: [0,0,9,0,0]
```

## Solution:

A naive solution multiplies everything except the current index for every position, which is `O(n^2)`. Division by `nums[i]` is not allowed either.

The optimal idea uses two product passes:

1. **Left products (prefix):** `result[i]` stores the product of all elements to the left of `i`
2. **Right products (postfix):** multiply `result[i]` by the product of all elements to the right of `i`

After both passes, `result[i]` is the product of every element except `nums[i]`.

Let's go through `nums = {1, 2, 3, 4}`:

1. Left pass:
    - `result = [1, 1, 2, 6]`  
      (`1`, then `1`, then `1*2`, then `1*2*3`)

2. Right pass (`rightSide` starts at `1`):
    - i = 3: `result[3] = 6 * 1 = 6`, `rightSide = 4`
    - i = 2: `result[2] = 2 * 4 = 8`, `rightSide = 12`
    - i = 1: `result[1] = 1 * 12 = 12`, `rightSide = 24`
    - i = 0: `result[0] = 1 * 24 = 24`, `rightSide = 24`

3. Result: `[24, 12, 8, 6]`

## Implementations:

### C# :

```csharp
// Using prefix and postfix - Time O(n)

public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];
        result[0] = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            result[i] = result[i - 1] * nums[i - 1];
        }

        int rightSide = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            result[i] = result[i] * rightSide;
            rightSide *= nums[i];
        }

        return result;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public int[] ProductExceptSelf(int[] nums)` : Define a public method that returns the product of all elements except the one at each index.

3. `var result = new int[nums.Length]; result[0] = 1;` : Create the answer array and set the left product of the first index to `1`.

4. `for (int i = 1; i < nums.Length; i++)` : Fill left products: each position gets the product of all previous elements.

5. `result[i] = result[i - 1] * nums[i - 1];` : Prefix product for index `i`.

6. `int rightSide = 1;` : Running product of elements to the right.

7. `for (int i = nums.Length - 1; i >= 0; i--)` : Second pass from right to left.

8. `result[i] = result[i] * rightSide;` : Multiply left product by right product.

9. `rightSide *= nums[i];` : Include the current element in the right product for the next index.

10. `return result;` : Return the final array.

### F# :

```fsharp
open System

type Solution() =
    member this.ProductExceptSelf(nums : int[]) =
        let result = Array.zeroCreate<int>(nums.Length)
        result.[0] <- 1

        for i = 1 to nums.Length - 1 do
            result.[i] <- result.[i - 1] * nums.[i - 1]

        let mutable rightSide = 1
        for i = nums.Length - 1 downto 0 do
            result.[i] <- result.[i] * rightSide
            rightSide <- rightSide * nums.[i]

        result
```

1. `type Solution() =` : Define a class-like type called `Solution`.

2. `member this.ProductExceptSelf(nums : int[]) =` : Define a member method that returns the product of all elements except the one at each index.

3. `let result = Array.zeroCreate<int>(nums.Length)` : Allocate the answer array with `0`s, then set the left product of the first index to `1`.

4. `for i = 1 to nums.Length - 1 do` : Fill left products in an inclusive `for` loop (F# ranges are inclusive on both ends).

5. `result.[i] <- result.[i - 1] * nums.[i - 1]` : Prefix product for index `i`, using `<-` to mutate the array in place.

6. `let mutable rightSide = 1` : `mutable` is required because F# bindings are immutable by default.

7. `for i = nums.Length - 1 downto 0 do` : Second pass from right to left using `downto`.

8. `result.[i] <- result.[i] * rightSide` : Multiply left product by right product.

9. `rightSide <- rightSide * nums.[i]` : Include the current element in the right product for the next index.

10. `result` : The last expression of the member is its return value; no explicit `return` keyword is needed.

## Suggested practice 🎯

Same prefix/suffix pass pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Trapping Rain Water](https://leetcode.com/problems/trapping-rain-water/)
- [Candy](https://leetcode.com/problems/candy/)
- [Subarray Sum Equals K](https://leetcode.com/problems/subarray-sum-equals-k/)
