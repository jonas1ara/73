# Linked List Cycle:

This directory contains an implementation of the "Linked List Cycle" problem in C#. The implementation uses Floyd's tortoise and hare algorithm with temporal complexity `O(n)` and constant extra space.

## Problem description

Given `head`, the head of a linked list, determine if the linked list has a cycle in it.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the `next` pointer.

Return `true` if there is a cycle in the linked list. Otherwise, return `false`.

- Example 1:

```
Input: head = [3,2,0,-4], pos = 1
Output: true
Explanation: There is a cycle where the tail connects to the 1st node (0-indexed).
```

- Example 2:

```
Input: head = [1,2], pos = 0
Output: true
```

- Example 3:

```
Input: head = [1], pos = -1
Output: false
```

## Solution:

Use two pointers starting at `head`:

- `p` (tortoise) moves one step at a time
- `q` (hare) moves two steps at a time

If there is a cycle, the faster pointer eventually laps the slower one and they meet. If `q` reaches `null`, there is no cycle.

This avoids storing all visited nodes in a set.

Meeting illustration:

1. Both start at head
2. In a cycle, relative speed is 1, so they must meet
3. On a straight list, hare hits the end first

## Implementations:

### C# :

```csharp
// Using Floyd's tortoise and hare algorithm - Time: O(n)

public class Solution
{
    public bool HasCycle(ListNode head)
    {
        ListNode p = head;
        ListNode q = head;

        while (q != null && q.next != null)
        {
            p = p.next;
            q = q.next.next;
            if (p == q)
            {
                return true;
            }
        }

        return false;
    }
}
```

1. Initialize slow `p` and fast `q` at the head.

2. Advance one and two steps; guard `q` and `q.next` for null.

3. If pointers meet → cycle exists.

4. If the loop ends → no cycle.

## Suggested practice 🎯

Same fast/slow pointers pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Linked List Cycle II](https://leetcode.com/problems/linked-list-cycle-ii/)
- [Happy Number](https://leetcode.com/problems/happy-number/)
- [Find the Duplicate Number](https://leetcode.com/problems/find-the-duplicate-number/)
