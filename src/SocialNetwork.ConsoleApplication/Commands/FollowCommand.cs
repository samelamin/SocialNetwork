using System.Collections.Generic;
using System.IO;

using SocialNetwork.Domain;
using SocialNetwork.Infrastructure;

namespace SocialNetwork.ConsoleApplication.Commands
{
    public class FollowCommand : ICommand
    {
        readonly User _user;

        readonly User _userToFollow;

        readonly TextWriter _textWriter;

        readonly ITweetsRepository _tweetsRepository;

        public FollowCommand(User user, User userToFollow, TextWriter textWriter)
        {
            _user = user;
            _userToFollow = userToFollow;
            _textWriter = textWriter;
        }

        public void Execute()
        {
            _user.Following.Add(_userToFollow);
            _textWriter.WriteLine("{0} has followed {1}", _user.Name, _userToFollow.Name);
        }
    }
}