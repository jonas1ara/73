# Remove Nth Node From End of List:

This directory contains implementations of the "Remove Nth Node From End of List" problem in the C, C++, and C# languages. Each implementation uses two pointers with a gap of `n` and temporal complexity `O(n)`.

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

### C++ :

```cpp
// Using two pointers - Time: O(n)

class Solution {
public:
    ListNode *removeNthFromEnd(ListNode *head, int n)
    {
        ListNode *p = head;
        ListNode *q = head;

        while (n > 0)
        {
            q = q->next;
            n--;
        }

        if (q == nullptr)
        {
            return head->next;
        }

        while (q->next != nullptr)
        {
            p = p->next;
            q = q->next;
        }

        p->next = p->next->next;

        return head;
    }
};
```

1. Same two-pointer unlink as C#.

### C:

```c
// Using two pointers - Time: O(n)

struct ListNode *removeNthFromEnd(struct ListNode *head, int n)
{
    struct ListNode *p = head;
    struct ListNode *q = head;
    struct ListNode *prev = NULL;

    while (n > 0)
    {
        q = q->next;
        n--;
    }

    if (q == NULL)
    {
        struct ListNode *newHead = head->next;
        free(head);
        return newHead;
    }

    while (q != NULL)
    {
        prev = p;
        p = p->next;
        q = q->next;
    }

    prev->next = p->next;
    free(p);

    return head;
}
```

1. C version also frees the removed node.

2. Uses `prev` because the C loop advances until `q` is null (slightly different stopping condition, same effect).
