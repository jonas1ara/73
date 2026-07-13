# Merge Two Sorted Lists:

This directory contains implementations of the "Merge Two Sorted Lists" problem in the C++ and C# languages. Each implementation merges two sorted lists in linear time `O(m + n)`.

## Problem description

You are given the heads of two sorted linked lists `list1` and `list2`.

Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.

Return the head of the merged linked list.

- Example 1:

```
Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]
```

- Example 2:

```
Input: list1 = [], list2 = []
Output: []
```

- Example 3:

```
Input: list1 = [], list2 = [0]
Output: [0]
```

## Solution:

This implementation starts with `list1` as the base chain attached to a dummy head, then inserts nodes from `list2` whenever they should come before the next node of the current chain:

1. Dummy `head` → `list1`
2. Walk with pointer `p`
3. While both sides still have candidates, if `p.next.val > list2.val`, splice `list2`'s front node after `p`
4. Append any remaining `list2` tail

Result is fully sorted without allocating new value nodes (reuses existing nodes).

For `[1,2,4]` and `[1,3,4]`:

1. Insert `1` before `2`
2. Insert `3` between `2` and `4`
3. Append remaining `4`
4. Result: `1→1→2→3→4→4`

## Implementations:

### C# :

```csharp
// Using a part of the merge sort algorithm - Time: O(m + n)

public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode head = new ListNode(0);
        ListNode p = head;
        head.next = list1;

        while (p.next != null && list2 != null)
        {
            if (p.next.val > list2.val)
            {
                ListNode node = list2;
                list2 = list2.next;
                node.next = p.next;
                p.next = node;
            }
            p = p.next;
        }

        if (list2 != null)
        {
            p.next = list2;
        }

        return head.next;
    }
}
```

1. Dummy node simplifies head handling.

2. Splice `list2` nodes into the `list1` chain when smaller.

3. Attach leftover `list2` and return `head.next`.

### C++ :

```cpp
// Using a part of the merge sort algorithm - Time: O(m + n)

class Solution {
public:
    ListNode *mergeTwoLists(ListNode *list1, ListNode *list2)
    {
        ListNode *head = new ListNode(0);
        ListNode *p = head;
        head->next = list1;

        while (p->next != nullptr && list2 != nullptr)
        {
            if (p->next->val > list2->val)
            {
                ListNode *node = list2;
                list2 = list2->next;
                node->next = p->next;
                p->next = node;
            }
            p = p->next;
        }

        if (list2 != nullptr)
        {
            p->next = list2;
        }

        return head->next;
    }
};
```

1. Same in-place splice merge as C#.

2. Returns the merged sorted list head.
