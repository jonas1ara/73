#include <iostream>
#include <numeric>
#include <vector>

int main() {
    std::vector<int> nums1 = {1, 2, 3};
    std::vector<int> nums2 = {4, 5, 6};
    
    int result = std::inner_product(nums1.begin(), nums1.end(), nums2.begin(), 0);

    std::cout << "Inner Product: " << result << std::endl;

    return 0;
}
