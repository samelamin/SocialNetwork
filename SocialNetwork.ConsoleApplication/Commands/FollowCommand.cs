using System.Collections.Generic;

using SocialNetwork.Domain;
using SocialNetwork.Infrastructure;

namespace SocialNetwork.ConsoleApplication.Commands
{
    public class FollowCommand : ICommand
    {
        readonly User _user;

        readonly User _userToFollow;

        readonly ITweetsRepository _tweetsRepository;

        public FollowCommand(User user, User userToFollow)
        {
            _user = user;
            _userToFollow = userToFollow;
        }

        public void Execute()
        {
            _user.Following.Add(_userToFollow);
        }
    }
}