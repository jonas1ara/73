using System;
using System.Collections.Generic;

IList<IList<int>> ThreeSum(int[] nums)
{
    Array.Sort(nums);

    var ans = new List<IList<int>>();

    int N = nums.Length;

    for (int i = 0; i < N - 2; i++)
    {
        if (i > 0 && nums[i] == nums[i - 1]) continue;

        int L = i + 1, R = N - 1;

        while (L < R)
        {
            int sum = nums[i] + nums[L] + nums[R];

            if (sum == 0)
            {
                ans.Add(new List<int>() { nums[i], nums[L], nums[R] });
            }

            if (sum >= 0)
            {
                R--;
                while (L < R && nums[R] == nums[R + 1]) R--;
            }

            if (sum <= 0)
            {
                L++;
                while (L < R && nums[L] == nums[L - 1]) L++;
            }
        }
    }
    return ans;
}

int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };

IList<IList<int>> ans = ThreeSum(nums);
foreach (List<int> l in ans)
{
    foreach (int i in l)
    {
        Console.Write(i + " ");
    }
    Console.WriteLine();
}
