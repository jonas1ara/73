public class DesignTwitterTests
{
    [Fact]
    public void GetNewsFeed_ReturnsOwnTweetsMostRecentFirst()
    {
        var twitter = new Twitter();

        twitter.PostTweet(1, 5);
        twitter.PostTweet(1, 6);

        Assert.Equal(new[] { 6, 5 }, twitter.GetNewsFeed(1));
    }

    [Fact]
    public void GetNewsFeed_IncludesFolloweeTweetsInterleavedByTime()
    {
        var twitter = new Twitter();

        twitter.PostTweet(1, 5);
        twitter.Follow(1, 2);
        twitter.PostTweet(2, 6);

        Assert.Equal(new[] { 6, 5 }, twitter.GetNewsFeed(1));
    }

    [Fact]
    public void GetNewsFeed_AfterUnfollow_ExcludesFolloweeTweets()
    {
        var twitter = new Twitter();

        twitter.PostTweet(1, 5);
        twitter.Follow(1, 2);
        twitter.PostTweet(2, 6);
        twitter.Unfollow(1, 2);

        Assert.Equal(new[] { 5 }, twitter.GetNewsFeed(1));
    }

    [Fact]
    public void GetNewsFeed_CapsAtTenMostRecentTweets()
    {
        var twitter = new Twitter();

        for (int i = 0; i < 15; i++)
        {
            twitter.PostTweet(1, i);
        }

        var feed = twitter.GetNewsFeed(1);

        Assert.Equal(10, feed.Count);
        Assert.Equal(new[] { 14, 13, 12, 11, 10, 9, 8, 7, 6, 5 }, feed);
    }

    [Fact]
    public void GetNewsFeed_UnknownUser_ReturnsEmpty()
    {
        var twitter = new Twitter();

        Assert.Empty(twitter.GetNewsFeed(1));
    }
}
