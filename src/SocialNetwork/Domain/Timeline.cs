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
        readonly DateTime _currentTime;

        readonly ITweetsRepository _tweetsRepository;

        public Timeline(ITweetsRepository tweetsRepository, DateTime currentTime)
        {
            _tweetsRepository = tweetsRepository;
            _currentTime = currentTime;
        }

        IEnumerable<Tweet> GetTweets(User user)
        {
            return _tweetsRepository.GetTweets(user);
        }

        public string FormatTweets(User user, bool isWall)
        {
            var formattedOutput = new StringBuilder();
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
                var dateDiff = (_currentTime - tweet.DatePublished);
                formattedOutput.AppendLine(
                    $"{tweet.User.Name} - {tweet.Message} ({DateTimeHelper.GetFriendlyRelativeTime(dateDiff)})");
            }

            return formattedOutput.ToString();
        }
    }
}