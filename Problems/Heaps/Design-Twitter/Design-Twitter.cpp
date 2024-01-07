#include <iostream>
#include <unordered_map>
#include <set>
#include <vector>
#include <queue>

// Using a heap - Time: O(n log n)

class Twitter {
public:
    std::unordered_map<int, std::set<int>> following;
    std::unordered_map<int, std::vector<std::pair<int, int>>> tweets;
    long long time;

    Twitter()
    {
        time = 0;
    }

    void postTweet(int userId, int tweetId)
    {
        tweets[userId].push_back({time++, tweetId});
    }

    std::vector<int> getNewsFeed(int userId)
    {
        std::vector<int> result;
        std::priority_queue<std::pair<int, int>> pq;

        // Push user's tweets into priority_queue
        for (auto t : tweets[userId])
        {
            pq.push(t);
        }

        // Push followed users' tweets into priority_queue
        for (auto f : following[userId])
        {
            for (auto t : tweets[f])
            {
                pq.push(t);
            }
        }

        // Retrieve top 10 tweets from priority_queue
        while (!pq.empty() && result.size() < 10)
        {
            result.push_back(pq.top().second);
            pq.pop();
        }

        return result;
    }

    void follow(int followerId, int followeeId)
    {
        following[followerId].insert(followeeId);
    }

    void unfollow(int followerId, int followeeId)
    {
        following[followerId].erase(followeeId);
    }
};

int main()
{
    Twitter twitter;

    twitter.postTweet(1, 5);
    twitter.follow(1, 2);
    twitter.postTweet(2, 6);

    std::vector<int> feed = twitter.getNewsFeed(1);

    std::cout << "News Feed for User 1: ";
    for (int tweetId : feed)
    {
        std::cout << tweetId << " ";
    }
    std::cout << std::endl;

    return 0;
}
