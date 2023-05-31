using System;

int SearchInsert(int[] nums, int target)
{
    int lo = 0, hi = nums.Length;

    while (lo < hi)
    {
        var mid = lo + (hi - lo) / 2;
        if (nums[mid] == target) return mid;
        else if (nums[mid] < target) lo = mid + 1;
        else hi = mid;
    }

    return lo;
}