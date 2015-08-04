using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain;

namespace SocialNetwork.Infrastructure
{
    using System;

    public interface IUsersRepository
    {
        User GetUser(string name);
    }

    public class UsersRepository : IUsersRepository
    {
        List<User> _users { get; set; }

        public UsersRepository()
        {
            _users = new List<User>();
        }
        
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