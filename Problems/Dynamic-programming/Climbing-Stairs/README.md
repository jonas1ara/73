# Climbing Stairs:

This directory contains implementations of the "Climbing Stairs" problem in the C++ and C# languages. Each implementation uses bottom-up dynamic programming (Fibonacci recurrence) with temporal complexity `O(n)`.

## Problem description

You are climbing a staircase. It takes `n` steps to reach the top.

Each time you can either climb `1` or `2` steps. In how many distinct ways can you climb to the top?

- Example 1:

```
Input: n = 2
Output: 2
Explanation: 1+1 or 2.
```

- Example 2:

```
Input: n = 3
Output: 3
Explanation: 1+1+1, 1+2, 2+1.
```

## Solution:

To reach step `n` you either:

- come from `n - 1` with a single step, or
- come from `n - 2` with a double step

So `ways(n) = ways(n - 1) + ways(n - 2)`, with `ways(1) = 1`, `ways(2) = 2`.

Only the last two values are needed, so space is `O(1)`.

Walk for `n = 5`:

1. Start `ans = 1`, `prev = 1` (like ways for 0/1 base)
2. After iterations: 2, 3, 5, 8
3. Answer for 5 is `8`

## Implementations:

### C# :

```csharp
// Using bottom-up approach - Time: O(n)

public class Solution
{
    public int ClimbStairs(int n)
    {
        int ans = 1;
        int prev = 1;

        while (--n > 0)
        {
            int temp = ans;
            ans += prev;
            prev = temp;
        }

        return ans;
    }
}
```

1. Keep two rolling Fibonacci values: `ans` (current) and `prev` (previous).

2. Each iteration advances the Fibonacci sequence by one step.

3. Loop runs `n - 1` times via `--n > 0`.

4. `return ans;` number of ways.

### C++ :

```cpp
// Using bottom-up approach - Time: O(n)

class Solution {
public:
    int climbStairs(int n)
    {
        int ans = 1, prev = 1;
        while (--n)
        {
            ans += prev;
            prev = ans - prev;
        }

        return ans;
    }
};
```

1. Same Fibonacci rolling update (C++ updates `prev` via `ans - prev` after adding).

2. `return ans;` number of distinct climbing sequences.
