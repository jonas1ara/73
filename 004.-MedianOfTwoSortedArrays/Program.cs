﻿using System;

namespace FindMedianSortedArrays
{
    class Program
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length + nums2.Length;
            if (m % 2 == 1)
                return FindKth(nums1, 0, nums2, 0, (m + 1) / 2);
            else
                return (FindKth(nums1, 0, nums2, 0, (m + 1) / 2) + FindKth(nums1, 0, nums2, 0, (m + 1) / 2 + 1)) / 2;
        }

        public static double FindKth(int[] nums1, int startIndex1, int[] nums2, int startIndex2, int k)
        {
            var nums1Left = nums1.Length - startIndex1;
            var nums2Left = nums2.Length - startIndex2;

            if (nums1Left < nums2Left) { return FindKth(nums2, startIndex2, nums1, startIndex1, k); }
            if (nums2.Length <= startIndex2) { return nums1[startIndex1 + k - 1]; }
            if (k == 1) { return nums1[startIndex1] < nums2[startIndex2] ? nums1[startIndex1] : nums2[startIndex2]; }

            var index1 = k / 2 < nums1Left ? k / 2 : nums1Left;
            var index2 = k - index1 < nums2Left ? k - index1 : nums2Left;
            if (nums1[index1 + startIndex1 - 1] > nums2[index2 + startIndex2 - 1])
                return FindKth(nums1, startIndex1, nums2, index2 + startIndex2, k - index2);
            else if (nums1[index1 + startIndex1 - 1] < nums2[index2 + startIndex2 - 1])
                return FindKth(nums1, index1 + startIndex1, nums2, startIndex2, k - index1);
            else
            {
                if (index1 + index2 == k)
                    return nums1[index1 + startIndex1 - 1];
                    return FindKth(nums1, index1 + startIndex1, nums2, index2 + startIndex2, k - index1 - index2);
            }
        }

        static void Main (string[] args)
        {
            int[] nums1 = { 1, 3 };
            int[] nums2 = { 2 };
            Console.WriteLine("Input: nums1 = [ {0} ], nums2 =[ {1} ]", string.Join(", ", nums1), string.Join(", ", nums2));
            double result = FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine("Output: " + result);
        }
    }
}