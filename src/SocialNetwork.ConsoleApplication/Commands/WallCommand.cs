using System;
using System.Collections.Generic;
using System.IO;

using SocialNetwork.Domain;
using SocialNetwork.Infrastructure;

namespace SocialNetwork.ConsoleApplication.Commands
{
    public class WallCommand : ICommand
    {
        readonly User _user;

        readonly ITweetsRepository _tweetsRepository;

        readonly TextWriter _textWriter;

        readonly ParsedInput _parsedInput;

        public WallCommand(User user, ITweetsRepository tweetsRepository, TextWriter textWriter, ParsedInput parsedInput)
        {
            _user = user;
            _tweetsRepository = tweetsRepository;
            _textWriter = textWriter;
            _parsedInput = parsedInput;
        }

        public void Execute()
        {
            Timeline timeline = new Timeline(_tweetsRepository, _parsedInput.CurrentDate);
            _textWriter.WriteLine(timeline.FormatWallTweets(_user));
        }
    }
}