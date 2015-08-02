namespace SocialNetwork.Infrastructure
{
    using System.Collections.Generic;

    using SocialNetwork.Domain;

    public class UsersRepository
    {
        public static List<User> Users { get; set; }

        public UsersRepository()
        {
            Users = new List<User>();
        }


    }
}
