using System;
using System.Collections.Generic;

// Using a heap - Time: O(n log n)

public class Twitter
{
    private Dictionary<int, HashSet<int>> following;
    private Dictionary<int, List<Tuple<int, int>>> tweets;
    private long time;

    public Twitter()
    {
        following = new Dictionary<int, HashSet<int>>();
        tweets = new Dictionary<int, List<Tuple<int, int>>>();
        time = 0;
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (!tweets.ContainsKey(userId))
        {
            tweets[userId] = new List<Tuple<int, int>>();
        }
        tweets[userId].Add(new Tuple<int, int>((int)time++, tweetId));
    }

    public IList<int> GetNewsFeed(int userId)
    {
        var result = new List<int>();
        var comparer = new TupleComparer();
        var pq = new SortedSet<Tuple<int, int>>(comparer);

        if (tweets.ContainsKey(userId))
        {
            foreach (var t in tweets[userId])
            {
                pq.Add(t);
            }
        }

        if (following.ContainsKey(userId))
        {
            foreach (var f in following[userId])
            {
                if (tweets.ContainsKey(f))
                {
                    foreach (var t in tweets[f])
                    {
                        pq.Add(t);
                    }
                }
            }
        }

        foreach (var item in pq)
        {
            result.Add(item.Item2);
            if (result.Count == 10)
            {
                break;
            }
        }

        return result;
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!following.ContainsKey(followerId))
        {
            following[followerId] = new HashSet<int>();
        }
        following[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (following.ContainsKey(followerId))
        {
            following[followerId].Remove(followeeId);
        }
    }
}

public class TupleComparer : IComparer<Tuple<int, int>>
{
    public int Compare(Tuple<int, int> x, Tuple<int, int> y)
    {
        return y.Item1.CompareTo(x.Item1);
    }
}

class Program
{
    static void Main()
    {
        Twitter twitter = new Twitter();

        Console.WriteLine("Input: [\"Twitter\", \"postTweet\", \"getNewsFeed\", \"follow\", \"postTweet\", \"getNewsFeed\", \"unfollow\", \"getNewsFeed\"]");
        Console.WriteLine("[[], [1, 5], [1], [1, 2], [2, 6], [1], [1, 2], [1]]");

        twitter.PostTweet(1, 5);
        IList<int> feed1 = twitter.GetNewsFeed(1);
        Console.Write("Output: [[");
        foreach (var item in feed1)
        {
            Console.Write(item);
            if (item != feed1[feed1.Count - 1])
            {
                Console.Write(", ");
            }
        }
        Console.Write("], ");

        twitter.Follow(1, 2);
        twitter.PostTweet(2, 6);
        IList<int> feed2 = twitter.GetNewsFeed(1);
        Console.Write("[");
        foreach (var item in feed2)
        {
            Console.Write(item);
            if (item != feed2[feed2.Count - 1])
            {
                Console.Write(", ");
            }
        }
        Console.Write("], ");

        twitter.Unfollow(1, 2);
        IList<int> feed3 = twitter.GetNewsFeed(1);
        Console.Write("[");
        foreach (var item in feed1)
        {
            Console.Write(item);
            if (item != feed1[feed1.Count - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]]");
    }
}

