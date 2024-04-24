using System;
using System.Collections.Generic;

// Using two pointers technique - Time: O(n^2)

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
}


class Program
{
    static void Main(string[] args)
    {
        int[] nums = { -1, 0, 1, 2, -1, -4 };

        // Print input
        Console.Write("Input: nums = [");
        foreach (int num in nums)
        {
            Console.Write(num + "");
            if (num != nums[nums.Length - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        IList<IList<int>> result = new Solution().ThreeSum(nums);

        // Print output
        Console.Write("Output: [");
        foreach (IList<int> list in result)
        {
            Console.Write("[" + string.Join(" ", list) + "]");
            if (list != result[result.Count - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");
	}
}
