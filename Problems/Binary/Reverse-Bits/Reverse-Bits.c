#include <stdio.h>
#include <stdint.h>

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

int main()
{
    uint32_t n = 43261596; // 00000010100101000001111010011100
    uint32_t reversed = reverseBits(n);  // 964176192 (00111001011110000010100101000000)

    printf("Input: n = %u\n", n);
    printf("Output: %u\n", reversed);

    return 0;
}
