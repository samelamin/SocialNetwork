namespace SocialNetwork.Domain
{
    using System.Collections.Generic;

    public class User
    {
        public readonly string Name;

        public User(string name)
        {
            Name = name;
            Following = new List<User>();
        }

        public List<User> Following { get; set; }

        public void Follow(User follower)
        {
            Following.Add(follower);
        }
    }
}