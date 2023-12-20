# 73 - The best number 🤓

According to Sheldon Cooper **the best number is 73**, because 73 is the 21st prime number. Its mirror, 37, is the 12th prime number. 21 is the product of multiplying 7 by 3 and in binary, 73 is a palindrome: 1001001

![73](/Sources/Sheldon.gif)

_Sheldon Cooper (character in the famous series "The Big-Bang Theory")_


## What is this? 🚀

This is a repository that will take you by the hand in the 73 most useful LeetCode problems, well they are actually [76](https://leetcode.com/list/xi4ci4ig/), 😬 the algorithms are written in C, C ++ and C#, I wrote each program placing the worst solution and one of the most optimal, the main function or method of the program to be tested on your machine and a README with notes of the problem and the solution. At the end when I have time I will make a video on YT explaining each problem. 🤓

**No hurry, but no rest** 

## Repository structure 📦

The repository is divided into 4 folders:

```
|- Repository
    |- .vscode
        |- tasks.json
    |- Problems
        |- Arrays
        |- Matrix
            |- Rotate-Image
                |- Rotate-Image.c
                |- Rotate-Image.cpp
                |- Rotate-Image.cs
                |- Rotate-Image.csproj
                |- README.md
            |- Set-Matrix-Zeroes
            |- Spiral-Matrix
            |- Word-Search
        |- Strings
        |- Intervals
        |- Binary Search
        |- Dynamic Programming
        |- Linked Lists
        |- Trees
        |- Heaps
        |- Graphs
    |- Sources
        |- Sheldon.gif
```

- **.vscode:** Contains the 'tasks.json' file that configures the build task in Visual Studio Code for `/usr/bin/g++` and the configuration for the output generated `${fileDirname}\\${fileBasenameNoExtension}.out`

- **Problems:** Contains the folders for each topic, inside it has a folder per problem and inside each folder is the source code and the README that explains the problem, for example the `Two-Sum` folder contains the C source code `Two-Sum.c` **(Only in the first problem of each topic there is an implementation in C language to go a little deeper)**, the C++ source code `Two-Sum .cpp`, the C# source code in `Two-Sum.cs` and the .NET project settings in `Two-Sum.csproj` and finally the `README.md` file

- **Sources:** Contains the images and gifs used in the repository, such as Sheldon Cooper's 😁 gif

## Configuration🔧

The focus of this repository is towards C#, so you can use it from Windows, Linux, Mac, Docker or even GitHub Codespaces, but it is intended to be used on Linux, **specifically a Ubuntu-based distribution**, no matter if it is a complete distro or a WSL distro. Solutions in C (only the first problem of each topic) and C++ are also included , so to use this repository you must have installed:

To compile C and C++ you need to install `gcc` and `g++` 

- gcc
- g++

To install them on Ubuntu you can type:

```bash
sudo apt update && \
    sudo apt install build-essential -y
```

If you want use this repository with C# then you should install `dotnet-sdk-8.0`

- dotnet-sdk-8.0

At this time the .NET 8 is only available from Ubuntu feed for Ubuntu 23.10, so, to install you can copy and paste the following commands:


**Ubuntu 23.10:**
```bash
sudo apt update && \
    sudo apt install dotnet-sdk-8.0 -y
```

**Note: To install on other linux distributions, please check this [page](https://learn.microsoft.com/en-us/dotnet/core/install/linux).**

## Index 📖

### Arrays

| # | Title | Solution | Difficulty |
|---| ----- | -------- | ---------- |
|0001|[Two Sum](https://leetcode.com/problems/two-sum/) | [C - C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Arrays/Two-Sum)|Easy|
|0011|[Container With Most Water](https://leetcode.com/problems/container-with-most-water/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Arrays/Container-with-Most-Water)|Medium|
|0015|[3Sum](https://leetcode.com/problems/3sum/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Arrays/3Sum)|Medium|
|0033|[Search in Rotated Sorted Array](https://leetcode.com/problems/search-in-rotated-sorted-array/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Arrays/Search-in-Rotated-Sorted-Array)|Medium|
|0053|[Maximum Subarray](https://leetcode.com/problems/maximum-subarray/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Arrays/Maximum-Subarray)|Medium|
|0121|[Best Time to Buy and Sell Stock](https://leetcode.com/problems/best-time-to-buy-and-sell-stock/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Arrays/Best-Time-to-Buy-and-Sell-Stock)|Medium|
|0152|[Maximum Product Subarray](https://leetcode.com/problems/maximum-product-subarray/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Arrays/Maximum-Product-Subarray)|Medium|
|0153|[Find Minimum in Rotated Sorted Array](https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Arrays/Find-Minimum-in-Rotated-Sorted-Array)|Medium|
|0217|[Contains Duplicate](https://leetcode.com/problems/contains-duplicate/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Arrays/Contains-Duplicate)|Easy|
|0238|[Product of Array Except Self](https://leetcode.com/problems/product-of-array-except-self/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Arrays/Product-of-Array-Except-Self)|Easy|


### Matrix

| # | Title | Solution | Difficulty |
|---| ----- | -------- | ---------- |
|0048|[Rotate Image](https://leetcode.com/problems/rotate-image/) | [C - C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Matrix/Rotate-Image)|Medium|
|0054|[Spiral Matrix](https://leetcode.com/problems/spiral-matrix/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Matrix/Spiral-Matrix)|Medium|
|0073|[Set Matrix Zeroes](https://leetcode.com/problems/set-matrix-zeroes/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Matrix/Set-Matrix-Zeroes)|Medium|
|0079|[Word Search](https://leetcode.com/problems/word-search/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Matrix/Word-Search)|Medium|


### Strings

| # | Title | Solution | Difficulty |
|---| ----- | -------- | ---------- |
|0003|[Longest Substring Without Repeating Characters](https://leetcode.com/problems/longest-substring-without-repeating-characters/) | [C - C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Strings/Longest-Substring-Without-Repeating-Characters)|Medium|
|0005|[Longest Palindromic Substring](https://leetcode.com/problems/longest-palindromic-substring/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Strings/Longest-Palindromic-Substring)|Medium|
|0020|[Valid Parentheses](https://leetcode.com/problems/valid-parentheses/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Strings/Valid-Parentheses)|Easy|
|0049|[Group Anagrams](https://leetcode.com/problems/group-anagrams/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Strings/Group-Anagrams)|Medium|
|0076|[Minimum Window Substring](https://leetcode.com/problems/minimum-window-substring/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Strings/Minimum-Window-Substring)|Hard|
|0125|[Valid Palindrome](https://leetcode.com/problems/valid-palindrome/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Strings/Valid-Palindrome)|Easy|
|0242|[Valid Anagram](https://leetcode.com/problems/valid-anagram/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Strings/Valid-Anagram)|Easy|
|0271|[Encode and Decode Strings](https://github.com/jonas1ara/73/tree/main/Problems/Strings/Encode-and-Decode-Strings/Problem.md) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Strings/Encode-and-Decode-Strings)|Medium|   
|0424|[Longest Repeating Character Replacement](https://leetcode.com/problems/longest-repeating-character-replacement/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Strings/Longest-Repeating-Character-Replacement)|Medium|
|0647|[Palindromic Substrings](https://leetcode.com/problems/palindromic-substrings/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Strings/Palindromic-Substrings)|Medium|

### Intervals

| # | Title | Solution | Difficulty |
|---| ----- | -------- | ---------- |
|0056|[Merge Intervals](https://leetcode.com/problems/merge-intervals/) | [C - C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Intervals/Merge-Intervals)|Medium|
|0057|[Insert Interval](https://leetcode.com/problems/insert-interval/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Intervals/Insert-Interval)|Medium|
|0252|[Meeting Rooms](https://github.com/jonas1ara/73/tree/main/Problems/Intervals/Meeting-Rooms/Problem.md) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Intervals/Meeting-Rooms)|Easy|
|0253|[Meeting Rooms II](https://github.com/jonas1ara/73/tree/main/Problems/Intervals/Meeting-Rooms-II/Problem.md) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Intervals/Meeting-Rooms-II)|Medium|
|0435|[Non-overlapping Intervals](https://leetcode.com/problems/non-overlapping-intervals/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Intervals/Non-overlapping-Intervals)|Medium|

### Binary 

| # | Title | Solution | Difficulty |
|---| ----- | -------- | ---------- |
|0190|[Reverse Bits](https://leetcode.com/problems/reverse-bits/) | [C - C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Binary/Reverse-Bits)|Easy|
|0191|[Number of 1 Bits](https://leetcode.com/problems/number-of-1-bits/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Binary/Number-of-1-Bits)|Easy|
|0268|[Missing Number](https://leetcode.com/problems/missing-number/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Binary/Missing-Number)|Easy|
|0338|[Counting Bits](https://leetcode.com/problems/counting-bits/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Binary/Counting-Bits)|Easy|
|0371|[Sum of Two Integers](https://leetcode.com/problems/sum-of-two-integers/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Binary/Sum-of-Two-Integers)|Medium|

### Dynamic Programming

| # | Title | Solution | Difficulty |
|---| ----- | -------- | ---------- |
|**0055**|[Jump Game](https://leetcode.com/problems/jump-game/) | [C - C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Dynamic-programming/Jump-Game)|Medium|
|**0062**|[Unique Paths](https://leetcode.com/problems/unique-paths/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Dynamic-programming/Unique-Paths)|Medium|
|**0070**|[Climbing Stairs](https://leetcode.com/problems/climbing-stairs/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Dynamic-programming/Climbing-Stairs)|Easy|
|**0091**|[Decode Ways](https://leetcode.com/problems/decode-ways/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Dynamic-programming/Decode-Ways)|Medium|
|**0139**|[Word Break](https://leetcode.com/problems/word-break/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Dynamic-programming/Word-Break)|Medium|
|**0198**|[House Robber](https://leetcode.com/problems/house-robber/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Dynamic-programming/House-Robber)|Medium|
|**0213**|[House Robber II](https://leetcode.com/problems/house-robber-ii/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Dynamic-programming/House-Robber-II)|Medium|
|**0300**|[Longest Increasing Subsequence](https://leetcode.com/problems/longest-increasing-subsequence/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Dynamic-programming/Longest-Common-Subsequence)|Medium|
|**0322**|[Coin Change](https://leetcode.com/problems/coin-change/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Dynamic-programming/Coin-Change)|Medium|
|**0377**|[Combination Sum IV](https://leetcode.com/problems/combination-sum-iv/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Dynamic-programming/Combination-Sum-IV)|Medium|
|**1143**|[Longest Common Subsequence](https://leetcode.com/problems/longest-common-subsequence/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Dynamic-programming/Longest-Increasing-Subsequence)|Medium|

### Linked Lists (Saturday 10/16/2021)

| # | Title | Solution | Difficulty |
|---| ----- | -------- | ---------- |
|**0019**|[Remove Nth Node From End of List](https://leetcode.com/problems/remove-nth-node-from-end-of-list/) | [C - C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Linked-lists/Remove-Nth-Node-From-End-of-List)|Medium|
|**0021**|[Merge Two Sorted Lists](https://leetcode.com/problems/merge-two-sorted-lists/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Linked-lists/Merge-Two-Sorted-Lists)|Easy|
|**0023**|[Merge k Sorted Lists](https://leetcode.com/problems/merge-k-sorted-lists/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Linked-lists/Merge-k-Sorted-Lists)|Hard|
|**0141**|[Linked List Cycle](https://leetcode.com/problems/linked-list-cycle/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Linked-lists/Linked-List-Cycle)|Easy|
|**0143**|[Reorder List](https://leetcode.com/problems/reorder-list/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Linked-lists/Reorder-List)|Medium|
|**0206**|[Reverse Linked List](https://leetcode.com/problems/reverse-linked-list/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Linked-lists/Reverse-Linked-List)|Easy|

### Trees

| # | Title | Solution | Difficulty |
|---| ----- | -------- | ---------- |
|**0098**|[Validate Binary Search Tree](https://leetcode.com/problems/validate-binary-search-tree/) | [C - C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Validate-Binary-Search-Tree)|Medium|
|**0100**|[Same Tree](https://leetcode.com/problems/same-tree/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Same-Tree)|Easy|
|**0102**|[Binary Tree Level Order Traversal](https://leetcode.com/problems/binary-tree-level-order-traversal/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Binary-Tree-Level-Order-Traversal)|Medium|
|**0104**|[Maximum Depth of Binary Tree](https://leetcode.com/problems/maximum-depth-of-binary-tree/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Maximum-Depth-of-Binary-Tree)|Easy|
|**0105**|[Construct Binary Tree from Preorder and Inorder Traversal](https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Construct-Binary-Tree-from-Preorder-and-Inorder-Traversal)|Medium|
|**0124**|[Binary Tree Maximum Path Sum](https://leetcode.com/problems/binary-tree-maximum-path-sum/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Binary-Tree-Maximum-Path-Sum)|Hard|
|**0208**|[Implement Trie (Prefix Tree)](https://leetcode.com/problems/implement-trie-prefix-tree/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Implement-Trie-Prefix-Tree)|Medium|
|**0211**|[Design Add and Search Words Data Structure](https://leetcode.com/problems/design-add-and-search-words-data-structure/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Design-Add-and-Search-Words-Data-Structure)|Medium|
|**0212**|[Word Search II](https://leetcode.com/problems/word-search-ii/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Word-Search-II)|Hard|
|**0226**|[Invert Binary Tree](https://leetcode.com/problems/invert-binary-tree/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Invert-Binary-Tree)|Hard|
|**0230**|[Kth Smallest Element in a BST](https://leetcode.com/problems/kth-smallest-element-in-a-bst/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Kth-Smallest-Element-in-a-BST)|Medium|
|**0235**|[Lowest Common Ancestor of a Binary Search Tree](https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Lowest-Common-Ancestor-of-a-Binary-Search-Tree)|Medium|
|**0297**|[Serialize and Deserialize Binary Tree](https://leetcode.com/problems/serialize-and-deserialize-binary-tree/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Serialize-and-Deserialize-Binary-Tree)|Hard|
|**0572**|[Subtree of Another Tree](https://leetcode.com/problems/subtree-of-another-tree/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Trees/Subtree-of-Another-Tree)|Easy|

### Heaps (Saturday 10/23/2021)

| # | Title | Solution | Difficulty |
|---| ----- | -------- | ---------- |
|**0023**|[Merge k Sorted Lists](https://leetcode.com/problems/merge-k-sorted-lists/) | [C - C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Heaps/Merge-k-Sorted-Lists)|Hard|
|**0295**|[Find Mediumn from Data Stream](https://leetcode.com/problems/find-median-from-data-stream/description/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Heaps/Find-Mediumn-from-Data-Stream)|Hard|
|**0347**|[Top K Frequent Elements](https://leetcode.com/problems/top-k-frequent-elements/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Heaps/Top-K-Frequent-Elements)|Medium|

### Graphs

| # | Title | Solution | Difficulty |
|---| ----- | -------- | ---------- |
|**0128**|[Longest Consecutive Sequence](https://leetcode.com/problems/longest-consecutive-sequence/) | [C - C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Graphs/Longest-Consecutive-Sequence)|Medium|
|**0133**|[Clone Graph](https://leetcode.com/problems/clone-graph/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Graphs/Clone-Graph)|Medium|
|**0200**|[Number of Islands](https://leetcode.com/problems/number-of-islands/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Graphs/Number-of-Islands)|Medium|
|**0207**|[Course Schedule](https://leetcode.com/problems/course-schedule/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Graphs/Course-Schedule)|Medium|
|**0261**|[Graph Valid Tree](https://www.lintcode.com/problem/178/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Graphs/Graph-Valid-Tree)|Medium|
|**0269**|[Alien Dictionary](https://www.lintcode.com/problem/892/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Graphs/Alien-Dictionary)|Hard|
|**0323**|[Number of Connected Components in an Undirected Graph](https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Graphs/Number-of-Connected-Components-in-an-Undirected-Graph)|Medium|
|**0417**|[Pacific Atlantic Water Flow](https://leetcode.com/problems/pacific-atlantic-water-flow/) | [C++ - C#](https://github.com/jonas1ara/73/tree/main/Problems/Graphs/Pacific-Atlantic-Water-Flow)|Medium|


## Build with 🛠️

- [C](https://en.wikipedia.org/wiki/C_(programming_language))
- [C#](https://dotnet.microsoft.com/es-es/languages/csharp) 
- [C++](https://isocpp.org/)
- [Ubuntu](https://ubuntu.com/)
- [VS Code](https://code.visualstudio.com/) 

## C# Conferences 📊

- [High Speed History of C#](https://www.youtube.com/watch?v=n7-9iXvx88I)
- [Mono Edge - Miguel de Icaza](https://www.youtube.com/watch?v=uS_9nwdzfzM)
- [.NET at Stack Overflow | .NET Conf 2022](https://www.youtube.com/watch?v=nZX13dVxnJw)
- [Miguel de Icaza's Vision Keynote - UnoConf 2019](https://www.youtube.com/watch?v=acryVgY0O3E&t=240s)
- [Full stack web UI with Blazor in .NET 8 | .NET Conf 2023](https://www.youtube.com/watch?v=YwZdtLEtROA&t=2804s)
- [Patterns for high-performance C# - Federico Andres Lois](https://www.youtube.com/watch?v=4yALYEINbyI)
- [Let's design a new C# language feature! | .NET Conf 2022](https://www.youtube.com/watch?v=ArN9R_8eL-E&t=152s)
- [Adam SITNIK: Solving .NET performance issues | UCP2019](https://www.youtube.com/watch?v=HDbtwTsar1Q)
- [What’s Next in C#? - Mads Torgersen - Copenhagen DevFest 2023](https://www.youtube.com/watch?v=gGzfAJwoH5A&t=2018s)
- [S101 - Keynote with Scott Hunter, Mads Torgersen, and Miguel De Icaza](https://www.youtube.com/watch?v=qQdGC2jIP8s)
- [The functional journey of C# - Mads Torgersen - NDC Copenhagen 2022](https://www.youtube.com/watch?v=CLKZ7ZgVido)
- [Stop using Entity Framework as a DTO provider! - Chris Klug - NDC Oslo 2023](https://www.youtube.com/watch?v=ZYfdjszs8sU)
- [You are doing logging in .NET wrong. Let’s fix it. - Nick Chapsas - NDC Oslo 2023](https://www.youtube.com/watch?v=NlBjVJPkT6M)
- [.NET Systems Programming Learned the Hard Way - Aaron Stannard - NDC Oslo 2023](https://www.youtube.com/watch?v=fi9P3-7VqHo)
- [Keynote: The Microsoft Open Source Cinematic Universe - Phase 2 - Scott Hanselman](https://www.youtube.com/watch?v=HUN1j9G1Py8)
- [Using C# Source Generators to Build a .NET IoT Device - Alon Fliess - NDC Melbourne 2022](https://www.youtube.com/watch?v=ifx_7daOzZw)
- [Patterns for application development with ASP.NET Core - Damian Edwards & David Fowler](https://www.youtube.com/watch?v=x-C-CNBVTaY)
- [Performance tricks I learned from contributing to open source .NET packages - Daniel Marbach](https://www.youtube.com/watch?v=pGgsFW7kDKI)
- [Real-world examples on optimizing .NET performance - Stefán Jökull Sigurðarson - NDC Oslo 2023](https://www.youtube.com/watch?v=545Nj0_BuzA)

## C++ Conferences 📊

- [Pontus Nyman: C++ in Space](https://www.youtube.com/watch?v=VxNVGVW9nyI)
- [Bjarne Stroustrup - The Essence of C++](https://www.youtube.com/watch?v=86xWVb4XIyE&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=1)
- [CppCon 2015: Kate Gregory “Stop Teaching C"](https://www.youtube.com/watch?v=YnWhqhNdYyk&t=1215s)
- [Bjarne Stroustrup: C++ | Lex Fridman Podcast #48](https://www.youtube.com/watch?v=uTxRF5ag27A&t=2842s)
- [Bjarne Stroustrup: Why you should avoid Linked Lists](https://www.youtube.com/watch?v=YQs6IC-vgmo&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=15)
- [Keynote: C++'s Superpower - Matt Godbolt - CPPP 2021](https://www.youtube.com/watch?v=0_UttFDnV3k&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=7)
- [CppCon 2016: Jason Turner “Practical Performance Practices"](https://www.youtube.com/watch?v=uzF4u9KgUWI)
- [Can C++ be 10x Simpler & Safer? - Herb Sutter - CppCon 2022](https://www.youtube.com/watch?v=ELeZAKCN4tY&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=14)
- [C++ in Constrained Environments - Bjarne Stroustrup - CppCon 2022](https://www.youtube.com/watch?v=2BuJjaGuInI)
- [Keynote: "Am I A Good Programmer?" - Kate Gregory - CppNorth 2022](https://www.youtube.com/watch?v=pdHvC8fDC5E&t=1420s)
- [CppCon 2017: Bjarne Stroustrup “Learning and Teaching Modern C++”](https://www.youtube.com/watch?v=fX2W3nNjJIo&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=17)
- [CppCon 2017: Peter Goldsborough “A Tour of Deep Learning With C++”](https://www.youtube.com/watch?v=Lo1rXJdAJ7w)
- [CppCon 2017: Louis Brandy “Curiously Recurring C++ Bugs at Facebook”](https://www.youtube.com/watch?v=lkgszkPnV8g)
- [CppCon 2018: Peter Goldsborough “Machine Learning in C++ with PyTorch”](https://www.youtube.com/watch?v=auRPXMMHJzc)
- [CppCon 2014: Herb Sutter "Back to the Basics! Essentials of Modern C++ Style"](https://www.youtube.com/watch?v=xnqTKD8uD64&t=4814s)
- [CppCon 2016: Bjarne Stroustrup "The Evolution of C++ Past, Present and Future"](https://www.youtube.com/watch?v=_wzc7a3McOs&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=4)
- [The Most Important Optimizations to Apply in Your C++ Programs - Jan Bielak - CppCon 2022](https://www.youtube.com/watch?v=qCjEN5XRzHc)
- [Trading at light speed: designing low latency systems in C++ - David Gross - Meeting C++ 2022](https://www.youtube.com/watch?v=8uAW5FQtcvE)
- [CppCon 2018: Gordon Brown “A Modern C++ Programming Model for GPUs using Khronos SYCL”](https://www.youtube.com/watch?v=miqZS6aS9K0)
- [The Imperatives Must Go! [Functional Programming in Modern C++] - Victor Ciura - CppCon 2022](https://www.youtube.com/watch?v=M5HuOZ4sgJE)
- [Bjarne Stroustrup's Closing Keynote at Code Europe 2022 in Cracow – "How to evolve a language"](https://www.youtube.com/watch?v=UoLM-6n-Ktg&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=3)
- [Writing Safety Critical Automotive Software for High Perf AI Hardware - Michael Wong - CppCon 2019](https://www.youtube.com/watch?v=F4GzsA00s5I)

## References 📚

_Cppreference.com. (s. f.). https://en.cppreference.com/w/_

_Eckel, B. (2004). Thinking in C++. [Thinking in C++](https://www.amazon.com/Thinking-C-Introduction-Standard-2nd/dp/0139798099/ref=sr_1_1?dchild=1&keywords=thinking+in+c%2B%2B&qid=1618383343&sr=8-1) (2nd ed.). Pearson._

_C# Docs - Get started, Tutorials, reference. https://learn.microsoft.com/en-us/dotnet/csharp/_

_Cormen, T. H., Leiserson, C. E., Rivest, R. L. & Stein, C. (2009). [Introduction to Algorithms](https://www.amazon.com/Introduction-Algorithms-3rd-MIT-Press/dp/0262033844) (3rd ed.). MIT Press._

## Acknowledgments 🎁

_Written with ❤️ by [Jonas Lara](https://twitter.com/jonas1ara) for anyone who is interested_
