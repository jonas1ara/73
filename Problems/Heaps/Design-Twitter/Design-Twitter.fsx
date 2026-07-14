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

let twitter = Twitter()

printfn "Input: [\"Twitter\", \"postTweet\", \"getNewsFeed\", \"follow\", \"postTweet\", \"getNewsFeed\", \"unfollow\", \"getNewsFeed\"]"
printfn "[[], [1, 5], [1], [1, 2], [2, 6], [1], [1, 2], [1]]"

twitter.PostTweet(1, 5)
let feed1 = twitter.GetNewsFeed(1)
printf "Output: [[%s], " (String.Join(", ", feed1))

twitter.Follow(1, 2)
twitter.PostTweet(2, 6)
let feed2 = twitter.GetNewsFeed(1)
printf "[%s], " (String.Join(", ", feed2))

twitter.Unfollow(1, 2)
let feed3 = twitter.GetNewsFeed(1)
printfn "[%s]]" (String.Join(", ", feed3))
