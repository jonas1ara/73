# Reverse Linked List:

This directory contains an implementation of the "Reverse Linked List" problem in C#. The main solution uses recursion; an iterative version is commented in the source files. Temporal complexity is `O(n)`.

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

### F# :

```fsharp
open System

type ListNode(v: int) =
    member val Val = v with get, set
    member val Next : ListNode option = None with get, set

type Solution() =
    member this.ReverseList(head: ListNode option) =
        let rec reverse (node: ListNode) =
            match node.Next with
            | None -> (node, node)
            | Some next ->
                let (h, t) = reverse next
                t.Next <- Some node
                node.Next <- None
                (h, node)

        match head with
        | None -> None
        | Some h -> reverse h |> fst |> Some
```

1. `Next : ListNode option` : Instead of a nullable reference like C#'s `head == null`, the list end is modeled with `None` / `Some`, so a missing node can never be dereferenced by accident.

2. `reverse` mirrors the C# helper: it returns `(newHead, newTail)` of the reversed sublist, using `<-` to mutate `Next` in place (`ListNode` fields are declared `with get, set`).

3. `match head with | None -> None | Some h -> ...` : Pattern matching replaces the C# `if (head == null) return null;` null check.

4. `reverse h |> fst |> Some` : Take the new head out of the tuple and re-wrap it in `Some` for the caller.

## Suggested practice 🎯

Same pointer reversal pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Reverse Linked List II](https://leetcode.com/problems/reverse-linked-list-ii/)
- [Swap Nodes in Pairs](https://leetcode.com/problems/swap-nodes-in-pairs/)
- [Rotate List](https://leetcode.com/problems/rotate-list/)
