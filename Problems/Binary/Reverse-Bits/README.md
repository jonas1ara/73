# Reverse Bits:

This directory contains implementations of the "Reverse Bits" problem in the C, C++, and C# languages. Each implementation reverses the 32 bits of an unsigned integer with temporal complexity `O(1)` (fixed 32 iterations).

## Problem description

Reverse bits of a given 32 bits unsigned integer.

- Example 1:

```
Input: n = 00000010100101000001111010011100
Output: 964176192 (00111001011110000010100101000000)
```

- Example 2:

```
Input: n = 11111111111111111111111111111101
Output: 3221225471 (10111111111111111111111111111111)
```

## Solution:

Build the answer bit by bit from the LSB of `n`:

1. Shift `ans` left by 1 (make room for the next bit)
2. Append the least significant bit of `n` with `(n & 1)`
3. Shift `n` right by 1
4. Repeat 32 times

This is the same idea as reversing a decimal digit string, but in base 2 with a fixed width.

Example sketch for a 4-bit toy `n = 0b1011`:

1. Start `ans = 0`
2. After 4 steps: `ans = 0b1101` (reverse of `1011`)

## Implementations:

### C# :

```csharp
// Using bit manipulation - Time: O(1)

public class Solution
{
    public uint reverseBits(uint n)
    {
        uint ans = 0;
        for (int i = 0; i < 32; i++)
        {
            ans = (ans << 1) | (n & 1);
            n >>= 1;
        }

        return ans;
    }
}
```

1. Loop exactly 32 times for a 32-bit integer.

2. `ans = (ans << 1) | (n & 1)` appends the next bit from `n`.

3. `n >>= 1` moves to the next bit of the input.

4. `return ans;` reversed bits.

### C++ :

```cpp
// Using bit manipulation - Time: O(1)

class Solution {
public:
    uint32_t reverseBits(uint32_t n)
    {
        int ans = 0;
        for (int i = 0; i < 32; i++)
        {
            ans = (ans << 1) | (n & 1);
            n >>= 1;
        }
        return ans;
    }
};
```

1. Same 32-step reverse construction as C#.

### C:

```c
// Using bit manipulation - Time: O(1)

uint32_t reverseBits(uint32_t n)
{
    uint32_t ans = 0;

    for (int i = 0; i < 32; i++)
    {
        ans = (ans << 1) | (n & 1);
        n >>= 1;
    }

    return ans;
}
```

1. Identical bit-by-bit reverse for 32-bit unsigned integers.
