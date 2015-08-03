namespace SocialNetwork.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SocialNetwork.Helpers;
    using SocialNetwork.Infrastructure;

    public class Timeline
    {
        readonly User _user;

        readonly ITweetsRepository _tweetsRepository;

        readonly DateTime _currentTime;
        
        public Timeline(User user,ITweetsRepository tweetsRepository, DateTime currentTime)
        {
            _user = user;
            _tweetsRepository = tweetsRepository;
            _currentTime = currentTime;
        }

        private IEnumerable<Tweet> GetTweets()
        {
            return _tweetsRepository.GetTweets(_user);
        }

        public string FormatWallTweets()
        {
            StringBuilder formattedOutput = new StringBuilder(FormatReadTweets());
            
            foreach (var followedUser in _user.Following)
            {
                formattedOutput.AppendFormat("{0} follows {1}", _user.Name, followedUser.Name);
            }

            return formattedOutput.ToString();
        }

        public string FormatReadTweets()
        {
            StringBuilder formattedOutput = new StringBuilder();

            foreach (var tweet in GetTweets())
            {
                TimeSpan dateDiff = (_currentTime - tweet.DatePublished);
                formattedOutput.AppendLine(string.Format("{0} ({1})", tweet.Message, DateTimeHelper.GetFriendlyRelativeTime(dateDiff)));
            }

            return formattedOutput.ToString();
        }
    }
}
