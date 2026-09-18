using System;
using System.Collections.Generic;

namespace LeetCode73.Core;

public record ComplexityInfo(
    string Time,
    string Space,
    string? TradeOffNote = null);

public static class ComplexityRegistry
{
    private static readonly Dictionary<int, ComplexityInfo> _specific = new()
    {
        [1] = new("O(N)", "O(N)", "Brute force O(N^2) has zero heap allocations and runs entirely in CPU L1 cache for tiny inputs (N < 20). Optimal O(N) with Dictionary trades O(N) memory to scale orders of magnitude faster (100x+) on large inputs."),
        [11] = new("O(N)", "O(1)", "Two-pointer approach eliminates the need to check all pairs O(N^2) by greedily advancing the shorter boundary pointer."),
        [15] = new("O(N^2)", "O(1)", "Sorting in O(N log N) enables two-pointer search for each element, reducing O(N^3) brute force to O(N^2)."),
        [33] = new("O(log N)", "O(1)", "Modified binary search determines which half is sorted in each step to discard half the search space."),
        [53] = new("O(N)", "O(1)", "Kadane's algorithm computes max subarray in a single pass without needing O(N^2) prefix sums."),
        [121] = new("O(N)", "O(1)", "Single pass tracking the minimum price seen so far avoids comparing all buy/sell pairs."),
        [152] = new("O(N)", "O(1)", "Tracking both minimum and maximum products at each step handles negative number sign flips in a single pass."),
        [153] = new("O(log N)", "O(1)", "Binary search finds the inflection point where the sorted array wraps around."),
        [217] = new("O(N)", "O(N)", "HashSet provides O(1) average lookup, trading O(N) memory to avoid O(N^2) brute force or O(N log N) sorting."),
        [238] = new("O(N)", "O(1)", "Two passes (prefix product and suffix product) avoid division and extra array allocations."),
        [48] = new("O(N^2)", "O(1)", "Transposing the matrix and reversing each row rotates in-place with zero additional memory."),
        [54] = new("O(M * N)", "O(1)", "Boundary pointers traverse perimeter layers sequentially without extra memory."),
        [73] = new("O(M * N)", "O(1)", "Using first row and first column as marker flags avoids O(M + N) extra boolean arrays."),
        [79] = new("O(M * N * 3^L)", "O(L)", "Backtracking in-place marks visited cells with a temporary character, avoiding a separate boolean visited matrix."),
        [3] = new("O(N)", "O(min(M, N))", "Sliding window with hash map/array tracks last seen indices in a single pass."),
        [5] = new("O(N^2)", "O(1)", "Expanding around centers takes O(1) space, avoiding O(N^2) DP matrix memory."),
        [20] = new("O(N)", "O(N)", "Stack verifies matching brackets in LIFO order in a single pass."),
        [49] = new("O(N * K)", "O(N * K)", "Character frequency counting avoids O(K log K) per-string sorting."),
        [76] = new("O(N)", "O(K)", "Two-pointer sliding window expands and contracts to find minimum valid substring in linear time."),
        [125] = new("O(N)", "O(1)", "Two pointers moving inward check alphanumeric characters in-place without string allocation."),
        [242] = new("O(N)", "O(1)", "Fixed 26-int frequency array uses O(1) auxiliary space compared to dictionary or sorting."),
        [424] = new("O(N)", "O(1)", "Sliding window tracks max frequency character within the window in linear time."),
        [647] = new("O(N^2)", "O(1)", "Expanding around 2N - 1 centers uses O(1) extra memory compared to O(N^2) dynamic programming."),
        [56] = new("O(N log N)", "O(N)", "Sorting intervals by start time allows merging overlapping ranges in a single linear pass."),
        [57] = new("O(N)", "O(1)", "Since intervals are already sorted, single pass processes non-overlapping, merging, and remaining intervals."),
        [435] = new("O(N log N)", "O(1)", "Greedy interval scheduling sorts by end time to maximize compatible intervals."),
        [190] = new("O(1)", "O(1)", "Bit manipulation processes all 32 bits using bitwise shifts and masks."),
        [191] = new("O(1)", "O(1)", "Brian Kernighan's algorithm `n &= (n - 1)` clears lowest set bit in iterations equal to number of set bits."),
        [268] = new("O(N)", "O(1)", "XOR property `x ^ x = 0` finds the missing number with zero risk of arithmetic integer overflow."),
        [338] = new("O(N)", "O(1)", "DP relation `bits[i] = bits[i >> 1] + (i & 1)` computes set bits for all numbers in linear time."),
        [371] = new("O(1)", "O(1)", "Bitwise XOR simulates sum without carry, AND shifted left simulates carry."),
        [55] = new("O(N)", "O(1)", "Greedy tracking of maximum reachable index avoids O(N^2) DP or exponential recursion."),
        [62] = new("O(M * N)", "O(N)", "Rolling 1D array reduces space from O(M * N) 2D table to O(min(M, N))."),
        [70] = new("O(N)", "O(1)", "Fibonacci transition uses only two variables, reducing space from O(N) to O(1)."),
        [91] = new("O(N)", "O(1)", "State depends only on previous two characters, allowing O(1) space optimization."),
        [139] = new("O(N^2)", "O(N)", "1D boolean array records valid split prefixes using a HashSet for O(1) dictionary word lookups."),
        [198] = new("O(N)", "O(1)", "Robbing decision depends only on two previous houses, optimizing space to O(1)."),
        [213] = new("O(N)", "O(1)", "Running House Robber I twice (excluding first house vs excluding last house) solves the circular dependency."),
        [300] = new("O(N log N)", "O(N)", "Patience sorting with binary search replaces tails array in O(N log N) instead of O(N^2) DP."),
        [322] = new("O(N * amount)", "O(amount)", "Bottom-up 1D DP finds minimum coins required for each sub-amount."),
        [377] = new("O(N * target)", "O(target)", "Bottom-up combination DP counts permutations summing to target."),
        [1143] = new("O(M * N)", "O(min(M, N))", "Rolling 1D DP array stores previous row values to compute longest common subsequence."),
        [19] = new("O(N)", "O(1)", "Fast and slow pointers separated by n nodes locate the target node in a single pass."),
        [21] = new("O(N + M)", "O(1)", "Dummy head pointer merges two sorted lists iteratively with zero extra node allocation."),
        [23] = new("O(N log k)", "O(k)", "PriorityQueue (Min-Heap) extracts the smallest head node across k lists in O(log k) per element."),
        [141] = new("O(N)", "O(1)", "Floyd's Tortoise and Hare algorithm detects cycles without modifying nodes or allocating a HashSet."),
        [143] = new("O(N)", "O(1)", "Splitting at midpoint, reversing second half, and interleaving nodes requires zero additional memory."),
        [206] = new("O(N)", "O(1)", "Iterative pointer reversal avoids recursion call stack overhead (O(N) -> O(1) space)."),
        [100] = new("O(N)", "O(H)", "Simultaneous DFS traversal verifies node structure and values with recursion stack bounded by tree height H."),
        [102] = new("O(N)", "O(N)", "Queue-based BFS processes tree level by level, bounded in space by max level width (N/2)."),
        [104] = new("O(N)", "O(H)", "Recursive DFS computes max depth with stack depth proportional to tree height H."),
        [105] = new("O(N)", "O(N)", "HashMap of inorder indices allows O(1) boundary lookups during recursive tree reconstruction."),
        [124] = new("O(N)", "O(H)", "Post-order DFS computes max branch sum upward while updating global maximum path sum across nodes."),
        [226] = new("O(N)", "O(H)", "Post-order or pre-order DFS swaps left and right child pointers in-place."),
        [230] = new("O(H + k)", "O(H)", "Iterative in-order traversal stops immediately after visiting the k-th node."),
        [235] = new("O(H)", "O(1)", "BST ordering property allows directional traversal without backtracking or storing ancestors."),
        [572] = new("O(N * M)", "O(H)", "DFS checks tree equality at each matching node candidate."),
        [98] = new("O(N)", "O(H)", "In-order traversal or min/max range propagation validates BST invariant in linear time."),
        [208] = new("O(L)", "O(L)", "Prefix tree with 26-element array per node enables prefix lookups proportional to word length L."),
        [211] = new("O(M)", "O(M)", "Trie search with backtracking handles '.' wildcard branches up to 26 alternatives."),
        [212] = new("O(M * N * 4^L)", "O(Total chars)", "Trie integrated with DFS board backtracking prunes dead search branches immediately."),
        [295] = new("O(log N) add, O(1) find", "O(N)", "Two balanced heaps (Max-Heap for lower half, Min-Heap for upper half) maintain median in O(1)."),
        [133] = new("O(V + E)", "O(V)", "HashMap maps original nodes to cloned copies to handle cycles during BFS/DFS traversal."),
        [200] = new("O(M * N)", "O(M * N)", "DFS/BFS sinks visited land cells ('1' -> '0') in-place to avoid extra visited matrix."),
        [207] = new("O(V + E)", "O(V + E)", "Kahn's algorithm (indegree BFS) or DFS 3-color cycle detection identifies circular prerequisites."),
        [417] = new("O(M * N)", "O(M * N)", "Reverse BFS/DFS starting from ocean borders inward finds cells reachable by both oceans.")
    };

    public static ComplexityInfo GetComplexity(int number, string category)
    {
        if (_specific.TryGetValue(number, out var info))
            return info;

        return category.ToLowerInvariant() switch
        {
            "binary search" or "binary-search" => new("O(log N)", "O(1)", "Binary search divides the problem space in half each iteration."),
            "trees" => new("O(N)", "O(H)", "Tree traversals visit each node once with call stack bounded by tree height H."),
            "graphs" => new("O(V + E)", "O(V + E)", "Graph algorithms process vertices and edges using BFS or DFS."),
            "dynamic programming" or "dynamic-programming" => new("O(N)", "O(1)", "DP memoization or rolling state optimization achieves linear time."),
            "intervals" => new("O(N log N)", "O(1)", "Sorting intervals enables single-pass linear processing."),
            "matrix" => new("O(M * N)", "O(1)", "Matrix algorithms visit each cell with in-place pointer manipulation."),
            "strings" => new("O(N)", "O(1)", "Sliding window or two pointers process characters in linear time."),
            _ => new("O(N)", "O(1)", "Linear time single-pass processing is typically the optimal target.")
        };
    }
}
