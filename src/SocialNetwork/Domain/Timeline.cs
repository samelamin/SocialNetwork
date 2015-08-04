namespace SocialNetwork.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using SocialNetwork.Helpers;
    using SocialNetwork.Infrastructure;

    public class Timeline
    {
        readonly ITweetsRepository _tweetsRepository;

        readonly DateTime _currentTime;
        
        public Timeline(ITweetsRepository tweetsRepository, DateTime currentTime)
        {
            _tweetsRepository = tweetsRepository;
            _currentTime = currentTime;
        }

        private IEnumerable<Tweet> GetTweets(User user)
        {
            return _tweetsRepository.GetTweets(user);
        }

        public string FormatTweets(User user, bool isWall)
        {
            StringBuilder formattedOutput = new StringBuilder();
            var aggregatedList = _tweetsRepository.GetTweets(user).ToList();

            if (isWall)
            {
                foreach (var followedUser in user.Following)
                {
                    formattedOutput.AppendLine($"{user.Name} follows {followedUser.Name}");
                    aggregatedList.AddRange(_tweetsRepository.GetTweets(followedUser));
                }
            }

            aggregatedList = aggregatedList.OrderByDescending(tweet => tweet.DatePublished).ToList();
            foreach (var tweet in aggregatedList)
            {
                TimeSpan dateDiff = (_currentTime - tweet.DatePublished);
                formattedOutput.AppendLine($"{tweet.User.Name} - {tweet.Message} ({DateTimeHelper.GetFriendlyRelativeTime(dateDiff)})");
            }

            return formattedOutput.ToString();
        }
    }
}
