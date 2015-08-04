namespace SocialNetwork.Domain
{
    using System;
    using System.Collections.Generic;
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

        public string FormatWallTweets(User user)
        {
            StringBuilder formattedOutput = new StringBuilder(FormatReadTweets(user));
            
            foreach (var followedUser in user.Following)
            {
                formattedOutput.AppendLine($"{user.Name} follows {followedUser.Name}");
                formattedOutput.AppendLine(FormatReadTweets(followedUser));
            }

            return formattedOutput.ToString();
        }

        public string FormatReadTweets(User user)
        {
            StringBuilder formattedOutput = new StringBuilder();

            foreach (var tweet in GetTweets(user))
            {
                TimeSpan dateDiff = (_currentTime - tweet.DatePublished);
                formattedOutput.AppendLine(string.Format("{0} - {1} ({2})",tweet.User.Name, tweet.Message, DateTimeHelper.GetFriendlyRelativeTime(dateDiff)));
            }

            return formattedOutput.ToString();
        }
    }
}
