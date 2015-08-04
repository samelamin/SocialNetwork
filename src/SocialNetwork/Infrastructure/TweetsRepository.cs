namespace SocialNetwork.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SocialNetwork.Domain;

    public interface ITweetsRepository
    {
        void PostTweet(Tweet tweet);

        IEnumerable<Tweet> GetTweets(User user);
    }

    public class TweetsRepository : ITweetsRepository
    {
        public TweetsRepository()
        {
            Tweets = new List<Tweet>();
        }

        public List<Tweet> Tweets { get; set; }

        public void PostTweet(Tweet tweet)
        {
            Tweets.Add(tweet);
        }

        public IEnumerable<Tweet> GetTweets(User user)
        {
            return Tweets.Where(tweet => tweet.User.Name.Equals(user.Name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}