using System;
using System.IO;

namespace SocialNetwork.ConsoleApplication
{
    public class ConsoleWriter
    {
        readonly TextWriter _textWriter;

        public ConsoleWriter(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void PrintInstructions()
        {
            _textWriter.WriteLine("The application must use the console for input and output.");
            _textWriter.WriteLine("_users submit commands to the application. There are four commands. “posting”, “reading”, etc. are not part of the commands; commands always start with the user’s name.");
            _textWriter.WriteLine("| Posting | <username> -> <message> |");
            _textWriter.WriteLine("| Reading | <username> |");
            _textWriter.WriteLine("| Following | <user name> follows <another user> |");
            _textWriter.WriteLine("| Wall | <user name> wall |");
        }


    }
}