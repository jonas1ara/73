#include <stdio.h>
#include <stdbool.h>

// Using tabulation - Time: O(n^2)

bool canJump(int nums[], int n)
{
    bool dp[n];
    for (int i = 0; i < n; i++)
    {
        dp[i] = false;
    }

    dp[0] = true;

    for (int i = 1; i < n; i++)
    {
        for (int j = 0; j < i; j++)
        {
            if (dp[j] && j + nums[j] >= i)
            {
                dp[i] = true;
                break;
            }
        }
    }

    return dp[n - 1];
}

// Using greedy algorithm - Time: O(n)
//
// bool canJump(int nums[], int n)
// {
//     for (int i = 0, last = 0; i <= last; ++i)
//     {
//         last = (last > i + nums[i]) ? last : i + nums[i];
//         if (last >= n - 1)
//             return true;
//     }
//     return false;
// }

int main()
{
    int nums[] = {2, 3, 1, 1, 4};
    int n = sizeof(nums) / sizeof(nums[0]);

    printf("Input: [");
    for (int i = 0; i < n; i++)
    {
        printf("%d", nums[i]);
        if (i < n - 1)
            printf(", ");
    }
    printf("]\n");

    bool result = canJump(nums, n);

    printf("Output: %s\n", result ? "true" : "false");

    return 0;
}
