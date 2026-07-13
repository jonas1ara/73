# Reorder List:

This directory contains implementations of the "Reorder List" problem in the C++ and C# languages. Each implementation splits, reverses, and interleaves the list in `O(n)` time and `O(1)` extra space.

## Problem description

You are given the head of a singly linked-list. The list can be represented as:

`L0 → L1 → … → Ln-1 → Ln`

Reorder the list to:

`L0 → Ln → L1 → Ln-1 → L2 → Ln-2 → …`

You may not modify the values in the list's nodes. Only nodes themselves may be changed.

- Example 1:

```
Input: head = [1,2,3,4]
Output: [1,4,2,3]
```

- Example 2:

```
Input: head = [1,2,3,4,5]
Output: [1,5,2,4,3]
```

## Solution:

Three classic steps:

1. **Split** the list into first half and second half
2. **Reverse** the second half
3. **Interleave** nodes from first and second halves

For `[1,2,3,4,5]`:

1. First half: `1→2→3`, second: `4→5`
2. Reverse second: `5→4`
3. Interleave: `1→5→2→4→3`

## Implementations:

### C# :

```csharp
// Using two pointers - Time: O(n)

public class Solution
{
    private int GetLength(ListNode head)
    {
        int ans = 0;
        for (ListNode current = head; current != null; current = current.next)
            ans++;
        return ans;
    }

    private ListNode SplitList(ListNode head)
    {
        int len = (GetLength(head) - 1) / 2;
        while (len > 0)
        {
            head = head.next;
            len--;
        }
        ListNode ans = head.next;
        head.next = null;
        return ans;
    }

    private ListNode ReverseList(ListNode head)
    {
        ListNode dummy = null;
        while (head != null)
        {
            ListNode node = head;
            head = head.next;
            node.next = dummy;
            dummy = node;
        }
        return dummy;
    }

    private void Interleave(ListNode first, ListNode second)
    {
        while (second != null)
        {
            ListNode node = second;
            second = second.next;
            node.next = first.next;
            first.next = node;
            first = node.next;
        }
    }

    public void ReorderList(ListNode head)
    {
        if (head == null || head.next == null)
            return;

        ListNode second = SplitList(head);
        second = ReverseList(second);
        Interleave(head, second);
    }
}
```

1. `GetLength` counts nodes to locate the split point.

2. `SplitList` cuts after the mid-left node and returns the second half.

3. `ReverseList` reverses the second half iteratively.

4. `Interleave` zips one node from the second list after each node of the first.

5. `ReorderList` orchestrates split → reverse → interleave.

### C++ :

```cpp
// Using two pointers - Time: O(n)

class Solution {
    int getLength(ListNode *head)
    {
        int ans = 0;
        for (; head; head = head->next)
            ans++;
        return ans;
    }

    ListNode *splitList(ListNode *head)
    {
        int len = (getLength(head) - 1) / 2;
        while (len--)
            head = head->next;
        auto ans = head->next;
        head->next = nullptr;
        return ans;
    }

    ListNode *reverseList(ListNode *head)
    {
        ListNode dummy;
        while (head)
        {
            auto node = head;
            head = head->next;
            node->next = dummy.next;
            dummy.next = node;
        }
        return dummy.next;
    }

    void interleave(ListNode *first, ListNode *second)
    {
        while (second)
        {
            auto node = second;
            second = second->next;
            node->next = first->next;
            first->next = node;
            first = node->next;
        }
    }

public:
    void reorderList(ListNode *head)
    {
        if (!head || !head->next)
            return;

        auto second = splitList(head);
        second = reverseList(second);
        interleave(head, second);
    }
};
```

1. Same three-phase algorithm as C#.

2. Modifies node links only; values stay unchanged.
