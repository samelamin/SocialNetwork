namespace SocialNetwork.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SocialNetwork.Domain;

    public interface IUsersRepository
    {
        User GetUser(string name);
    }

    public class UsersRepository : IUsersRepository
    {
        public UsersRepository()
        {
            _users = new List<User>();
        }

        List<User> _users { get; }

        public User GetUser(string name)
        {
            var user = _users.SingleOrDefault(u => u.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            if (user == null)
            {
                user = new User(name);
                _users.Add(user);
            }

            return user;
        }
    }
}