using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain;

namespace SocialNetwork.Infrastructure
{
    public interface ITweetsRepository
    {
        void PostTweet(Tweet tweet);

        IEnumerable<Tweet> GetTweets(User user);
    }

    public class TweetsRepository : ITweetsRepository
    {
        public static List<Tweet> Tweets { get; set; }

        public TweetsRepository()
        {
            Tweets = new List<Tweet>();
        }

        public void PostTweet(Tweet tweet)
        {
            Tweets.Add(tweet);
        }

        public IEnumerable<Tweet> GetTweets(User user)
        {
            return Tweets.Where(tweet => tweet.User == user);
        }
    }
}