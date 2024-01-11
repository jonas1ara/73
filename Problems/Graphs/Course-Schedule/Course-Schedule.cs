using System;
using System.Collections.Generic;

// Using topological sort - Time: O(n)

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

        Queue<int> q = new Queue<int>(); // q = queue of nodes with indegree = 0
        
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

class Program
{
    static void Main()
    {
        int numCourses = 2;

        int[][] prerequisites = new int[][]
        {
            new int[] { 1, 0 },
            new int[] { 0, 1 },
        };

        Console.Write("Input: numCourses: {0}, prerequisites = [", numCourses);
        foreach (var p in prerequisites)
        {
            Console.Write("[{0}, {1}], ", p[0], p[1]);
            if (p == prerequisites[prerequisites.Length - 1])
                Console.Write("\b\b"); 
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        bool result = sol.CanFinish(numCourses, prerequisites);

        Console.WriteLine("Output: {0}", result);
    }
}
