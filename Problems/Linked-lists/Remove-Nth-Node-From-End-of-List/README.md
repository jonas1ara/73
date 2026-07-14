# Remove Nth Node From End of List:

This directory contains an implementation of the "Remove Nth Node From End of List" problem in C#. The implementation uses two pointers with a gap of `n` and temporal complexity `O(n)`.

## Problem description

Given the head of a linked list, remove the `n`-th node from the end of the list and return its head.

- Example 1:

```
Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]
```

- Example 2:

```
Input: head = [1], n = 1
Output: []
```

- Example 3:

```
Input: head = [1,2], n = 1
Output: [1]
```

## Solution:

Two-pointer technique:

1. Advance fast pointer `q` by `n` steps
2. If `q` is null, the head itself is the n-th from end → return `head.next`
3. Otherwise move `p` and `q` together until `q` reaches the end
4. Then `p` is just before the node to delete → skip it with `p.next = p.next.next`

One pass, no need to count the length first.

For `[1,2,3,4,5]`, `n = 2`:

1. `q` starts 2 ahead of `p`
2. When `q` is at the last node, `p` is at `3`
3. Skip `4` → list becomes `1→2→3→5`

## Implementations:

### C# :

```csharp
// Using two pointers - Time: O(n)

public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode p = head, q = head;
        while (n > 0)
        {
            q = q.next;
            n--;
        }

        if (q == null)
        {
            return head.next;
        }

        while (q.next != null)
        {
            p = p.next;
            q = q.next;
        }

        p.next = p.next.next;

        return head;
    }
}
```

1. Gap `q` ahead by `n`.

2. Handle removal of the head separately.

3. Align `p` before the target and unlink it.

4. Return original `head` (or new head if first node removed).

## Suggested practice 🎯

Same two-pointer gap pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Remove Duplicates from Sorted List](https://leetcode.com/problems/remove-duplicates-from-sorted-list/)
- [Remove Duplicates from Sorted List II](https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/)
- [Middle of the Linked List](https://leetcode.com/problems/middle-of-the-linked-list/)
