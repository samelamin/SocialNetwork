using System.Collections.Generic;
using System.IO;

using SocialNetwork.Domain;
using SocialNetwork.Infrastructure;

namespace SocialNetwork.ConsoleApplication.Commands
{
    public class PostCommand : ICommand
    {
        readonly User _user;

        readonly ITweetsRepository _tweetsRepository;

        readonly ParsedInput _parsedInput;

        readonly TextWriter _textWriter;

        public PostCommand(User user, ITweetsRepository tweetsRepository, ParsedInput parsedInput, TextWriter textWriter)
        {
            _user = user;
            _tweetsRepository = tweetsRepository;
            _parsedInput = parsedInput;
            _textWriter = textWriter;
        }

        public void Execute()
        {
            _tweetsRepository.PostTweet(new Tweet(_user,_parsedInput.RequiredAction, _parsedInput.CurrentDate));
            _textWriter.WriteLine("Tweet Sent");
        }
    }
}