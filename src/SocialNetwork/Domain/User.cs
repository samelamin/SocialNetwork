namespace SocialNetwork.Domain
{
    using System.Collections.Generic;

    public class User
    {

        public readonly string Name;


        public List<Tweet> TimelineEvents { get; set; }

        public List<User> Followers { get; set; }

        public User(string name)
        {
            Name = name;
            Followers = new List<User>();
        }

        public void AddFollower(User follower)
        {
            Followers.Add(follower);
        }

    }
}