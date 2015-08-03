using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain;

namespace SocialNetwork.Infrastructure
{
    public interface IUsersRepository
    {
        User GetUser(string name);
    }

    public class UsersRepository : IUsersRepository
    {
        static List<User> _users { get; set; }

        public UsersRepository()
        {
            _users = new List<User>();
        }
        
        public User GetUser(string name)
        {
            var user = _users.SingleOrDefault(u => u.Name == name);
            if (user == null)
            {
                user = new User(name);
                _users.Add(user);
            }

            return user;
        }
    }
}