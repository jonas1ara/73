public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        List<List<int>> G = new List<List<int>>(numCourses);
        for (int i = 0; i < numCourses; i++)
        {
            G.Add(new List<int>());
        }

        int[] indegree = new int[numCourses];

        foreach (var e in prerequisites)
        {
            G[e[1]].Add(e[0]);
            indegree[e[0]]++;
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

            foreach (int v in G[u])
            {
                if (--indegree[v] == 0) q.Enqueue(v);
            }
        }

        return numCourses == 0;
    }
}
