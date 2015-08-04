namespace SocialNetwork.Domain
{
    using System;

    public class Tweet
    {
        public readonly string Message;

        public readonly User User;

        public DateTime DatePublished;

        public Tweet(User user, string message, DateTime datePublished)
        {
            User = user;
            Message = message;
            DatePublished = datePublished;
        }
    }
}