# Reverse Linked List:

This directory contains implementations of the "Reverse Linked List" problem in the C++ and C# languages. The main solution uses recursion; an iterative version is commented in the source files. Temporal complexity is `O(n)`.

## Problem description

Given the `head` of a singly linked list, reverse the list, and return the reversed list.

- Example 1:

```
Input: head = [1,2,3,4,5]
Output: [5,4,3,2,1]
```

- Example 2:

```
Input: head = [1,2]
Output: [2,1]
```

- Example 3:

```
Input: head = []
Output: []
```

## Solution:

**Recursive approach (implemented):**

Helper returns a pair `(newHead, newTail)` of the reversed suffix:

1. Base: single node → `(head, head)`
2. Recursively reverse `head.next` → get `(h, t)`
3. Attach current node after `t`: `t.next = head`, `head.next = null`
4. Return `(h, head)` so the original head becomes the new tail

Public method returns the new head (`h`).

**Iterative approach (commented):** walk the list, prepending each node onto a new head.

For `[1,2,3]`:

1. Reverse `[2,3]` → `3→2`
2. Attach `1` after `2` → `3→2→1`
3. Return head `3`

## Implementations:

### C# :

```csharp
// Using recursion - Time: O(n)

public class Solution
{
    private (ListNode, ListNode) Reverse(ListNode head)
    {
        if (head.next == null) return (head, head);

        var (h, t) = Reverse(head.next);
        t.next = head;
        head.next = null;

        return (h, head);
    }

    public ListNode ReverseList(ListNode head)
    {
        if (head == null) return null;
        return Reverse(head).Item1;
    }
}
```

1. `Reverse` returns `(newHead, newTail)` of the reversed sublist.

2. Wire current node after the reversed tail and clear its `next`.

3. Public API returns only the new head; empty list stays null.

### C++ :

```cpp
// Using recursion - Time: O(n)

class Solution {
    std::array<ListNode*, 2> reverse(ListNode *head)
    {
        if (!head->next) return {head, head};

        auto [h, t] = reverse(head->next);
        t->next = head;
        head->next = NULL;

        return {h, head};
    }

public:
    ListNode* reverseList(ListNode* head)
    {
        if (!head) return NULL;
        return reverse(head)[0];
    }
};
```

1. Uses `std::array` / structured bindings for the `(head, tail)` pair.

2. Same recursive reverse as C#.

3. Iterative alternative is available as comments in the source files.
