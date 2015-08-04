namespace SocialNetwork.ConsoleApplication.Commands
{
    using System.IO;

    using SocialNetwork.Domain;
    using SocialNetwork.Infrastructure;

    public class WallCommand : ICommand
    {
        readonly ParsedInput _parsedInput;

        readonly TextWriter _textWriter;

        readonly ITweetsRepository _tweetsRepository;

        readonly User _user;

        public WallCommand(User user, ITweetsRepository tweetsRepository, TextWriter textWriter, ParsedInput parsedInput)
        {
            _user = user;
            _tweetsRepository = tweetsRepository;
            _textWriter = textWriter;
            _parsedInput = parsedInput;
        }

        public void Execute()
        {
            var timeline = new Timeline(_tweetsRepository, _parsedInput.CurrentDate);
            _textWriter.WriteLine(timeline.FormatTweets(_user, true));
        }
    }
}