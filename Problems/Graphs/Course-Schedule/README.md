# Course Schedule:

This directory contains an implementation of the "Course Schedule" problem in C#. The implementation uses BFS topological sort (Kahn's algorithm) with temporal complexity `O(n + m)` where `n` is the number of courses and `m` is the number of prerequisites.

## Problem description

There are a total of `numCourses` courses you have to take, labeled from `0` to `numCourses - 1`. You are given an array `prerequisites` where `prerequisites[i] = [ai, bi]` indicates that you must take course `bi` first if you want to take course `ai`.

Return `true` if you can finish all courses. Otherwise, return `false`.

- Example 1:

```
Input: numCourses = 2, prerequisites = [[1,0]]
Output: true
Explanation: Take course 0 then course 1.
```

- Example 2:

```
Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
Output: false
Explanation: A cycle makes both courses impossible to complete.
```

## Solution:

Model courses as a directed graph: edge `bi → ai` means `bi` unlocks `ai`.

Kahn's algorithm:

1. Build adjacency lists and indegree for every course
2. Enqueue all courses with indegree `0` (no remaining prereqs)
3. While the queue is not empty: dequeue `u`, decrement remaining course count, reduce indegree of neighbors; enqueue any that hit `0`
4. If every course was processed, there is no cycle → `true`; otherwise a cycle remains → `false`

For `[[1,0],[0,1]]`: both nodes have indegree `1` → queue starts empty → cannot finish.

## Implementations:

### C# :

```csharp
// Using topological sort (bfs) - Time: O(n + m)

public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        List<List<int>> graph = new List<List<int>>(numCourses);

        for (int i = 0; i < numCourses; i++)
        {
            graph.Add(new List<int>());
        }

        int[] indegree = new int[numCourses];

        foreach (var p in prerequisites)
        {
            graph[p[1]].Add(p[0]);
            indegree[p[0]]++;
        }

        Queue<int> q = new Queue<int>();

        for (int i = 0; i < numCourses; i++)
        {
            if (indegree[i] == 0) q.Enqueue(i);
        }

        while (q.Count > 0)
        {
            int u = q.Dequeue();
            numCourses--;

            foreach (int v in graph[u])
            {
                if (indegree[v]-- == 0) q.Enqueue(v);
            }
        }

        return numCourses == 0;
    }
}
```

1. Edge `p[1] → p[0]` matches “take `bi` before `ai`”.

2. Post-decrement `indegree[v]-- == 0` enqueues as soon as all prereqs are done.
