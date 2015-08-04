using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialNetwork.Domain;
using SocialNetwork.Infrastructure;

namespace SocialNetwork.ConsoleApplication.Commands
{
    public class CommandFactory
    {
        public ICommand Create( User user, ParsedInput parsedInput, ITweetsRepository tweetsRepository,TextWriter textWriter)
        {
            switch (parsedInput.CommandType)
            {
                case CommandType.Post:
                    {
                        return new PostCommand(user, tweetsRepository, parsedInput, textWriter);
                    }
                case CommandType.Read:
                    {
                        return new ReadCommand(user, tweetsRepository, textWriter, parsedInput);
                    }
                case CommandType.Follow:
                    {
                        return new FollowCommand(user, new User(parsedInput.RequiredAction),textWriter);
                    }
                case CommandType.Wall:
                default:
                    {
                        return new WallCommand(user,tweetsRepository, textWriter, parsedInput);
                    }
     
            }
        }
    }

}
