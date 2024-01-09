#include <iostream>
#include <vector>
#include <unordered_map>
#include <algorithm>

// Using union find algorithm - Time: O(n)

class UnionFind {
    std::vector<int> id, size;

public:
    UnionFind(int n) : id(n), size(n, 1) 
    {
        for (int i = 0; i < n; i++)
            id[i] = i;
    }

    void connect(int a, int b) 
    {
        int x = find(a), y = find(b);

        if (x == y)
            return;

        id[x] = y;
        size[y] += size[x];
    }

    int find(int a) 
    {
        return id[a] == a ? a : (id[a] = find(id[a]));
    }

    std::vector<int> &getSizes() 
    {
        return size;
    }
};

class Solution {
public:
    int longestConsecutive(std::vector<int> &nums) 
    {
        if (nums.empty())
            return 0;

        UnionFind uf(nums.size());
        std::unordered_map<int, int> m;
        
        for (int i = 0; i < nums.size(); i++) 
        {
            int n = nums[i];
            if (m.count(n))
                continue;

            m[n] = i;
            if (m.count(n + 1))
                uf.connect(m[n], m[n + 1]);

            if (m.count(n - 1))
                uf.connect(m[n], m[n - 1]);
        }

        return *max_element(uf.getSizes().begin(), uf.getSizes().end());
    }
};

int main() 
{
    std::vector<int> nums = {100, 4, 200, 1, 3, 2};

    std::cout << "Input: [";
    for (int i = 0; i < nums.size(); i++) 
    {
        std::cout << nums[i];
        if (i != nums.size() - 1)
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    Solution sol;
    int result = sol.longestConsecutive(nums);

    std::cout << "Output: " << result << std::endl;

    return 0;
}
