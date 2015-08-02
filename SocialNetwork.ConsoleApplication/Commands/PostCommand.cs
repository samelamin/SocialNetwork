using System.Collections.Generic;

using SocialNetwork.Domain;
using SocialNetwork.Infrastructure;

namespace SocialNetwork.ConsoleApplication.Commands
{
    public class PostCommand : ICommand
    {
        readonly User _user;

        readonly ITweetsRepository _tweetsRepository;

        readonly ParsedInput _parsedInput;

        public PostCommand(User user, ITweetsRepository tweetsRepository, ParsedInput parsedInput)
        {
            _user = user;
            _tweetsRepository = tweetsRepository;
            _parsedInput = parsedInput;
        }

        public void Execute()
        {
            _tweetsRepository.PostTweet(new Tweet(_user,_parsedInput.RequiredAction, _parsedInput.CurrentDate));
        }
    }
}