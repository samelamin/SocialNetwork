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

        public WallCommand(User user, ITweetsRepository tweetsRepository, TextWriter textWriter)
        {
            _user = user;
            _tweetsRepository = tweetsRepository;
            _textWriter = textWriter;
        }

        public void Execute()
        {
            Timeline timeline = new Timeline(_user,_tweetsRepository, DateTime.Now);
            _textWriter.WriteLine(timeline.FormatWallTweets());
        }
    }
}