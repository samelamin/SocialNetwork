namespace SocialNetwork.Domain
{
    using System;

    public class Tweet
    {
        public readonly User User;

        public readonly string Message;

        public DateTime DatePublished;

        public Tweet(User user, string message, DateTime datePublished)
        {
            User = user;
            Message = message;
            DatePublished = datePublished;
        }

    }
}