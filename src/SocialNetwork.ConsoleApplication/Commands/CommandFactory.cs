namespace SocialNetwork.ConsoleApplication.Commands
{
    using System.IO;

    using SocialNetwork.Domain;
    using SocialNetwork.Infrastructure;

    public class CommandFactory
    {
        public ICommand Create(User user,
            ParsedInput parsedInput,
            ITweetsRepository tweetsRepository,
            TextWriter textWriter)
        {
            switch (parsedInput.CommandType)
            {
                case CommandType.Read:
                {
                    return new ReadCommand(user, tweetsRepository, textWriter, parsedInput);
                }
                case CommandType.Follow:
                {
                    return new FollowCommand(user, new User(parsedInput.RequiredAction), textWriter);
                }
                case CommandType.Wall:

                {
                    return new WallCommand(user, tweetsRepository, textWriter, parsedInput);
                }
                case CommandType.Post:
                default:
                {
                    return new PostCommand(user, tweetsRepository, parsedInput, textWriter);
                }
            }
        }
    }
}