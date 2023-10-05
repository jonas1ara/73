using System;
using System.Collections.Generic;

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        List<IList<int>> result = new List<IList<int>>();
        int n = nums.Length;

        if (n < 3)
        {
            return result;
        }

        Array.Sort(nums);

        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] > 0)
            {
                break;
            }
            if (i > 0 && nums[i - 1] == nums[i])
            {
                continue;
            }

            int j = i + 1;
            int k = n - 1;

            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];

                if (sum < 0)
                {
                    j++;
                }
                else if (sum > 0)
                {
                    k--;
                }
                else
                {
                    result.Add(new List<int> { nums[i], nums[j], nums[k] });

                    while (j < k && nums[j] == nums[j + 1])
                    {
                        j++;
                    }
                    j++;

                    while (j < k && nums[k - 1] == nums[k])
                    {
                        k--;
                    }
                    k--;
                }
            }
        }
        return result;
    }

    public static void Main(string[] args)
    {
        int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };

        Console.WriteLine("Input: nums = [" + string.Join(" ", nums) + "]");

        IList<IList<int>> ans = new Solution().ThreeSum(nums);

        Console.Write("Output: [");
        foreach (IList<int> list in ans)
        {
            Console.Write("[" + string.Join(" ", list) + "]");
        }
        Console.WriteLine("]");
    }
}
