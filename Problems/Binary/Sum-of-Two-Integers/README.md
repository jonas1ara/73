# Sum of Two Integers:

This directory contains implementations of the "Sum of Two Integers" problem in the C++ and C# languages. Each implementation adds two integers using only bit operations (no `+` / `-`) with temporal complexity `O(1)` for fixed-width 32-bit integers.

## Problem description

Given two integers `a` and `b`, return the sum of the two integers without using the operators `+` and `-`.

- Example 1:

```
Input: a = 1, b = 2
Output: 3
```

- Example 2:

```
Input: a = 2, b = 3
Output: 5
```

## Solution:

Addition can be simulated bit by bit with a carry, exactly like grade-school addition in binary:

For each bit position `i` from 0 to 31:

- Extract bits `x = (a >> i) & 1`, `y = (b >> i) & 1`
- Depending on current `carry`:
  - If carry is set: write a `1` when `x == y` (both 0 → sum bit 1 and clear carry; both 1 → sum bit 1 and keep carry)
  - If carry is clear: write a `1` when `x != y`; set carry when `x == y == 1`

This walks all 32 bits once.

Let's go through `a = 2` (`10`), `b = 3` (`11`):

1. Bit 0: `0 + 1` → write 1, no carry → ans bit0 = 1
2. Bit 1: `1 + 1` → write 0, carry 1
3. Bit 2: carry 1, both 0 → write 1, clear carry
4. Result: `101` = 5

## Implementations:

### C# :

```csharp
// Using bit manipulation - Time: O(1)

public class Solution
{
    public int GetSum(int a, int b)
    {
        int carry = 0, ans = 0;

        for (int i = 0; i < 32; ++i)
        {
            int x = (a >> i & 1), y = (b >> i & 1);

            if (carry != 0)
            {
                if (x == y)
                {
                    ans |= 1 << i;
                    if (x == 0 && y == 0) carry = 0;
                }
            }
            else
            {
                if (x != y) ans |= 1 << i;
                if (x == 1 && y == 1) carry = 1;
            }
        }

        return ans;
    }
}
```

1. Process each of the 32 bit positions.

2. Maintain an explicit `carry` while writing sum bits into `ans`.

3. `return ans;` is `a + b` without using `+`.

### C++ :

```cpp
// Using bit manipulation - Time: O(1)

class Solution {
public:
    int getSum(int a, int b)
    {
        int carry = 0, ans = 0;

        for (int i = 0; i < 32; i++)
        {
            int x = (a >> i & 1), y = (b >> i & 1);

            if (carry)
            {
                if (x == y)
                {
                    ans |= 1 << i;
                    if (!x & !y)
                        carry = 0;
                }
            }
            else
            {
                if (x != y)
                    ans |= 1 << i;
                if (x & y)
                    carry = 1;
            }
        }

        return ans;
    }
};
```

1. Same bit-wise full adder simulation as C#.

2. Works for negative numbers too because two's complement is bit-consistent over 32 bits.
