# Merge k Sorted Lists:

This directory contains implementations of the "Merge k Sorted Lists" problem in the C++ and C# languages. Each implementation merges lists pairwise in a bottom-up fashion (like merge sort) with temporal complexity `O(N log k)` where `N` is the total number of nodes.

## Problem description

You are given an array of `k` linked-lists `lists`, each linked-list is sorted in ascending order.

Merge all the linked-lists into one sorted linked-list and return it.

- Example 1:

```
Input: lists = [[1,4,5],[1,3,4],[2,6]]
Output: [1,1,2,3,4,4,5,6]
```

- Example 2:

```
Input: lists = []
Output: []
```

- Example 3:

```
Input: lists = [[]]
Output: []
```

## Solution:

Instead of repeatedly scanning all list heads (slower), merge lists in rounds:

1. `step = 1, 2, 4, ...`
2. Merge pairs `(lists[i], lists[i + step])` into `lists[i]`
3. After `log k` rounds, `lists[0]` holds the full merge

`mergeTwoLists` is the classic two-list merge with a dummy head.

For 3 lists A, B, C:

1. Round step=1: merge A with B → AB; C alone
2. Round step=2: merge AB with C → ABC

## Implementations:

### C# :

```csharp
// Using merge sort algorithm - Time: O(nlogn)

public class Solution
{
    private ListNode MergeTwoLists(ListNode a, ListNode b)
    {
        ListNode head = new ListNode(0);
        ListNode tail = head;

        while (a != null && b != null)
        {
            if (a.val < b.val)
            {
                tail.next = a;
                a = a.next;
            }
            else
            {
                tail.next = b;
                b = b.next;
            }
            tail = tail.next;
        }
        tail.next = a ?? b;

        return head.next;
    }

    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0)
        {
            return null;
        }
        int n = lists.Length;
        for (int step = 1; step < n; step <<= 1)
        {
            for (int i = 0; i < n - step; i += step << 1)
            {
                lists[i] = MergeTwoLists(lists[i], lists[i + step]);
            }
        }

        return lists[0];
    }
}
```

1. `MergeTwoLists` stitches two sorted lists into one.

2. Outer loop doubles `step` each round (`<<= 1`).

3. Inner loop merges non-overlapping pairs.

4. `return lists[0];` final merged list (or null if empty input).

### C++ :

```cpp
// Using merge sort algorithm - Time: O(nlogn)

class Solution {
private:
    ListNode *mergeTwoLists(ListNode *a, ListNode *b)
    {
        ListNode *head = new ListNode(0);
        ListNode *tail = head;

        while (a != nullptr && b != nullptr)
        {
            if (a->val < b->val)
            {
                tail->next = a;
                a = a->next;
            }
            else
            {
                tail->next = b;
                b = b->next;
            }
            tail = tail->next;
        }
        tail->next = a ? a : b;

        return head->next;
    }

public:
    ListNode *mergeKLists(std::vector<ListNode *> &lists)
    {
        if (lists.empty())
        {
            return nullptr;
        }

        int n = lists.size();

        for (int step = 1; step < n; step <<= 1)
        {
            for (int i = 0; i < n - step; i += step << 1)
            {
                lists[i] = mergeTwoLists(lists[i], lists[i + step]);
            }
        }

        return lists[0];
    }
};
```

1. Same pairwise bottom-up merge as C#.

2. Empty vector → `nullptr`.
