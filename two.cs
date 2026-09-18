// Fuerza bruta

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int[] n = nums;

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (n[i] + n[j] == target)
                    return new int[] { i, j };
            }
        }

        return new int[0];
    }
}

