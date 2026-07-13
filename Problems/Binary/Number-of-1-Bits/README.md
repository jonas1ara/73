# Number of 1 Bits:

This directory contains implementations of the "Number of 1 Bits" (Hamming Weight) problem in the C++ and C# languages. Each implementation uses Brian Kernighan's algorithm with temporal complexity proportional to the number of set bits (bounded by 32, treated as `O(1)` for fixed-width integers).

## Problem description

Write a function that takes an unsigned integer and returns the number of `1` bits it has (also known as the Hamming weight).

- Example 1:

```
Input: n = 00000000000000000000000000001011
Output: 3
Explanation: The input binary string has a total of three '1' bits.
```

- Example 2:

```
Input: n = 00000000000000000000000010000000
Output: 1
```

- Example 3:

```
Input: n = 11111111111111111111111111111101
Output: 31
```

## Solution:

A simple loop checks every bit (`n & 1`, shift). Brian Kernighan's trick is faster in practice:

- `n & -n` isolates the lowest set bit
- `n -= (n & -n)` clears that bit
- Count how many times you can do this until `n` becomes 0

Each iteration removes exactly one `1`, so the loop runs once per set bit.

Example for `n = 11` (`1011`):

1. Clear lowest 1 → `1010`, count 1
2. Clear lowest 1 → `1000`, count 2
3. Clear lowest 1 → `0000`, count 3
4. Answer: `3`

## Implementations:

### C# :

```csharp
// Using Brian Kernighan's Algorithm - Time: O(1)

public class Solution
{
    public int HammingWeight(uint n)
    {
        int ans = 0;
        long ln = n;

        while (ln != 0)
        {
            ln -= (ln & -ln);
            ans++;
        }

        return ans;
    }
}
```

1. Use `long` so two's-complement `-ln` behaves correctly for the bit trick.

2. Each loop clears one set bit and increments `ans`.

3. `return ans;` Hamming weight.

### C++ :

```cpp
// Using Brian Kernighan's Algorithm - Time: O(1)

class Solution {
public:
    int hammingWeight(uint32_t n)
    {
        int ans = 0;

        for (; n; n -= (n & -n))
            ans++;

        return ans;
    }
};
```

1. `n & -n` isolates the lowest set bit of `n`.

2. Subtract it to clear that bit; count iterations.

3. `return ans;` number of 1-bits.
