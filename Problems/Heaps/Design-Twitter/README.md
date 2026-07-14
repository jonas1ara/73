# Design Twitter:

This directory contains an implementation of the "Design Twitter" problem in C#. Tweets and follow relations are stored in maps; news feed merges recent tweets with a max-ordered set, with temporal complexity dominated by `O(n log n)` when building a feed of size up to 10.

## Problem description

Design a simplified version of Twitter where users can post tweets, follow/unfollow another user, and is able to see the 10 most recent tweets in the user's news feed.

Implement the `Twitter` class:

- `Twitter()` Initializes your twitter object
- `void postTweet(int userId, int tweetId)` Composes a new tweet with ID `tweetId` by the user `userId`
- `List<Integer> getNewsFeed(int userId)` Retrieves the 10 most recent tweet IDs in the user's news feed. Each item must be posted by users who the user followed or by the user themself. Tweets must be ordered from most recent to least recent
- `void follow(int followerId, int followeeId)` The user with ID `followerId` started following the user with ID `followeeId`
- `void unfollow(int followerId, int followeeId)` The user with ID `followerId` started unfollowing the user with ID `followeeId`

- Example 1:

```
Input
["Twitter", "postTweet", "getNewsFeed", "follow", "postTweet", "getNewsFeed", "unfollow", "getNewsFeed"]
[[], [1, 5], [1], [1, 2], [2, 6], [1], [1, 2], [1]]
Output
[null, null, [5], null, null, [6, 5], null, [5]]

Explanation
Twitter twitter = new Twitter();
twitter.postTweet(1, 5); // User 1 posts a new tweet (id = 5)
twitter.getNewsFeed(1);  // User 1's news feed should return [5]
twitter.follow(1, 2);    // User 1 follows user 2
twitter.postTweet(2, 6); // User 2 posts a new tweet (id = 6)
twitter.getNewsFeed(1);  // User 1's news feed should return [6, 5]
twitter.unfollow(1, 2);  // User 1 unfollows user 2
twitter.getNewsFeed(1);  // User 1's news feed should return [5]
```

## Solution:

State:

- `following[userId]` → set of followee IDs
- `tweets[userId]` → list of `(timestamp, tweetId)`
- Global `time` incremented on every post

**PostTweet:** append `(time++, tweetId)` to the user's tweet list.

**Follow / Unfollow:** add or remove from the follower's set.

**GetNewsFeed:** collect the user's tweets plus all followees' tweets into a max-ordered set by timestamp; take the first 10 tweet IDs.

## Implementations:

### C# :

```csharp
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
            tweets[userId] = new List<Tuple<int, int>>();
        tweets[userId].Add(new Tuple<int, int>((int)time++, tweetId));
    }

    public IList<int> GetNewsFeed(int userId)
    {
        var result = new List<int>();
        var pq = new SortedSet<Tuple<int, int>>(new TupleComparer());

        if (tweets.ContainsKey(userId))
            foreach (var t in tweets[userId])
                pq.Add(t);

        if (following.ContainsKey(userId))
            foreach (var f in following[userId])
                if (tweets.ContainsKey(f))
                    foreach (var t in tweets[f])
                        pq.Add(t);

        foreach (var item in pq)
        {
            result.Add(item.Item2);
            if (result.Count == 10)
                break;
        }
        return result;
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!following.ContainsKey(followerId))
            following[followerId] = new HashSet<int>();
        following[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (following.ContainsKey(followerId))
            following[followerId].Remove(followeeId);
    }
}

public class TupleComparer : IComparer<Tuple<int, int>>
{
    public int Compare(Tuple<int, int> x, Tuple<int, int> y)
    {
        return y.Item1.CompareTo(x.Item1); // newer first
    }
}
```

1. Timestamps establish a total order for the feed.

2. `SortedSet` with reverse time order yields most-recent tweets first.

### F# :

```fsharp
open System
open System.Collections.Generic

// Using a heap - Time: O(n log n)

type Twitter() =
    let following = Dictionary<int, HashSet<int>>()
    let tweets = Dictionary<int, ResizeArray<int * int>>() // (time, tweetId) per user
    let mutable time = 0

    member this.PostTweet(userId: int, tweetId: int) =
        if not (tweets.ContainsKey userId) then
            tweets.[userId] <- ResizeArray<int * int>()
        tweets.[userId].Add((time, tweetId))
        time <- time + 1

    member this.GetNewsFeed(userId: int) =
        let allTweets = ResizeArray<int * int>()

        if tweets.ContainsKey userId then
            allTweets.AddRange tweets.[userId]

        if following.ContainsKey userId then
            for followeeId in following.[userId] do
                if tweets.ContainsKey followeeId then
                    allTweets.AddRange tweets.[followeeId]

        allTweets
        |> Seq.sortByDescending fst
        |> Seq.truncate 10
        |> Seq.map snd
        |> List.ofSeq

    member this.Follow(followerId: int, followeeId: int) =
        if not (following.ContainsKey followerId) then
            following.[followerId] <- HashSet<int>()
        following.[followerId].Add followeeId |> ignore

    member this.Unfollow(followerId: int, followeeId: int) =
        if following.ContainsKey followerId then
            following.[followerId].Remove followeeId |> ignore
```

1. `following` / `tweets` / `time` : Declared as `let` bindings in the primary constructor, equivalent to private fields initialized in the C# constructor — no separate `new()` needed.

2. `(time, tweetId)` : A plain tuple replaces `Tuple<int, int>`; no custom comparer class is needed because sorting is done with a pipeline instead of a `SortedSet`.

3. `allTweets |> Seq.sortByDescending fst |> Seq.truncate 10 |> Seq.map snd |> List.ofSeq` : Same net effect as the C# `SortedSet` + `TupleComparer`, expressed as a single pipe chain: sort by timestamp descending, keep the first 10, project the tweet IDs.

4. `following.[followerId].Add followeeId |> ignore` : `HashSet.Add` returns a `bool` in .NET; `|> ignore` discards it since the F# compiler warns on unused non-unit results.

## Suggested practice 🎯

Same heap/ordered-set design pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [LFU Cache](https://leetcode.com/problems/lfu-cache/)
- [Design Underground System](https://leetcode.com/problems/design-underground-system/)
- [Time Based Key-Value Store](https://leetcode.com/problems/time-based-key-value-store/)
