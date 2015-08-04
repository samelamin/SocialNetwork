using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialNetwork.Domain;

namespace SocialNetwork.ConsoleApplication
{
    public class InputParser
    {
        const string _followsCommand = "FOLLOWS";

        const string _wallCommand = "WALL";

        public ParsedInput Parse(string input, DateTime currentDate)
        {
            var parsedInput = new ParsedInput { CurrentDate = currentDate };

            string commandInput = input.Trim();
            var seperatedInput = commandInput.Split(' ');
            parsedInput.Username = seperatedInput[0];

            if (seperatedInput.Count() == 1)
            {
                parsedInput.CommandType = CommandType.Read;
                return parsedInput;
            }

            parsedInput.Username = seperatedInput.First().Trim();
            var command = seperatedInput.Skip(1).First().Trim();
            parsedInput.CommandType = ParseCommandType(command);
            parsedInput.RequiredAction = string.Join(" ", seperatedInput.Skip(2)); ;
            return parsedInput;
        }

        CommandType ParseCommandType(string command)
        {
            var commandType = CommandType.Post;

            switch (command.ToUpper())
            {
                case _followsCommand:
                    commandType = CommandType.Follow;
                    break;

                case _wallCommand:
                    commandType = CommandType.Wall;
                    break;

                default:
                    commandType = CommandType.Post;
                    break;
            }

            return commandType;
        }
    }

    public class ParsedInput
    {
        public string Username { get; set; }

        public CommandType CommandType { get; set; }

        public string RequiredAction { get; set; }

        public DateTime CurrentDate { get; set; }
    }
}
