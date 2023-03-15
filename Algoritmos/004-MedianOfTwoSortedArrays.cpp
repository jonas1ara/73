/* Binary Search */

#include <iostream>
#include <vector>
#include <climits>

double findMedianSortedArrays(std::vector<int> &nums1, std::vector<int> &nums2);

int main()
{
    std::vector<int> nums1 = { 1, 3 };
    std::vector<int> nums2 = { 2 ,4};

    std::cout << "Input: nums1 = ";
    for (int i = 0; i < nums1.size(); i++)
        std::cout << "[" << nums1[i] << "]";
    std::cout << ", nums2 = ";
    for (int i = 0; i < nums2.size(); i++)
        std::cout << "[" << nums2[i] << "]";
    std::cout << std::endl;

    std::cout << "Output: ";
    std::cout << findMedianSortedArrays(nums1, nums2) << std::endl;
    std::cout <<"\n\n";
}

double findMedianSortedArrays(std::vector<int> &nums1, std::vector<int> &nums2)
{
    if (nums1.size() > nums2.size())
        std::swap(nums1, nums2);
    int M = nums1.size(), N = nums2.size(), L = 0, R = M, K = (M + N + 1) / 2;
    while (true)
    {
        int i = (L + R) / 2, j = K - i;
        if (i < M && nums2[j - 1] > nums1[i])
            L = i + 1;
        else if (i > L && nums1[i - 1] > nums2[j])
            R = i - 1;
        else
        {
            int maxLeft = std::max(i ? nums1[i - 1] : INT_MIN, j ? nums2[j - 1] : INT_MIN);
            if ((M + N) % 2)
                return maxLeft;
            int minRight = std::min(i == M ? INT_MAX : nums1[i], j == N ? INT_MAX : nums2[j]);
            return (maxLeft + minRight) / 2.0;
        }
    }
}