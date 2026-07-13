# Counting Bits:

This directory contains implementations of the "Counting Bits" problem in the C++ and C# languages. Each implementation fills bit counts using dynamic programming over powers of two with temporal complexity `O(n)`.

## Problem description

Given an integer `n`, return an array `ans` of length `n + 1` such that for each `i` (`0 <= i <= n`), `ans[i]` is the number of `1`'s in the binary representation of `i`.

- Example 1:

```
Input: n = 2
Output: [0,1,1]
Explanation:
0 --> 0
1 --> 1
2 --> 10
```

- Example 2:

```
Input: n = 5
Output: [0,1,1,2,1,2]
```

## Solution:

A naive approach counts bits for every number separately (`O(n log n)` total).

This solution observes that each range between powers of two reuses earlier answers:

- `ans[2^k] = 1` (a single high bit)
- For offsets `j` in `1 .. 2^k - 1`: `ans[2^k + j] = ans[2^k] + ans[j] = 1 + ans[j]`

So each value is filled once in linear total work.

Let's go through `n = 5`:

1. `ans[0] = 0`
2. `i = 1`: `ans[1] = 1`
3. `i = 2`: `ans[2] = 1`, then `ans[3] = 1 + ans[1] = 2`
4. `i = 4`: `ans[4] = 1`, then `ans[5] = 1 + ans[1] = 2`
5. Result: `[0,1,1,2,1,2]`

## Implementations:

### C# :

```csharp
// Using dynamic programming - Time: O(n)

public class Solution
{
    public int[] CountBits(int n)
    {
        int[] ans = new int[n + 1];

        for (int i = 1; i <= n; i *= 2)
        {
            ans[i] = 1;

            for (int j = 1; j < i && i + j <= n; j++)
                ans[i + j] = ans[i] + ans[j];
        }

        return ans;
    }
}
```

1. Allocate `ans` of length `n + 1` (zeros by default).

2. Outer loop walks powers of two: `1, 2, 4, 8, ...`

3. Set `ans[i] = 1` for pure powers of two.

4. Fill `ans[i + j]` as sum of high-bit contribution and `ans[j]`.

5. `return ans;`

### C++ :

```cpp
// Using dynamic programming - Time: O(n)

class Solution {
public:
    std::vector<int> countBits(int n)
    {
        std::vector<int> ans(n + 1);

        for (int i = 1; i <= n; i *= 2)
        {
            ans[i] = 1;

            for (int j = 1; j < i && i + j <= n; j++)
                ans[i + j] = ans[i] + ans[j];
        }

        return ans;
    }
};
```

1. Same power-of-two DP fill as C#.

2. `return ans;` bit counts for every value in `[0, n]`.
