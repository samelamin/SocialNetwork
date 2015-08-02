using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialNetwork.ConsoleApplication.Commands;
using SocialNetwork.Domain;
using SocialNetwork.Infrastructure;

namespace SocialNetwork.ConsoleApplication
{
    public class Program
    {
        static ITweetsRepository _tweetsRepository;

        private readonly ConsoleWriter _consoleWriter;

        readonly InputParser _inputParser;

        readonly CommandFactory _commandFactory;

        readonly TextWriter _textWriter;

        public Program(ITweetsRepository tweetsRepository, InputParser inputParser, CommandFactory commandFactory, TextWriter textWriter)
        {
            _tweetsRepository = tweetsRepository;
            _inputParser = inputParser;
            _commandFactory = commandFactory;
            _textWriter = textWriter;
            _consoleWriter = new ConsoleWriter(_textWriter);
        }

        public Program()
        {
            _textWriter = Console.Out;
            _consoleWriter = new ConsoleWriter(_textWriter);
            _commandFactory = new CommandFactory();
            _inputParser = new InputParser();
            _tweetsRepository = new TweetsRepository();
        }

        public void PrintInstructions()
        {
            _consoleWriter.PrintInstructions();
        }

        private void WaitForCommand()
        {
            do
            {
                _textWriter.Write("Please enter a command:");
                var stringCommand = Console.ReadLine();
                var parsedInput = _inputParser.Parse(stringCommand, DateTime.Now);

                Execute(parsedInput);

            } while (true);
        }
        public virtual void Execute(ParsedInput parsedInput)
        {
            var command = _commandFactory.Create(new User(parsedInput.Username), parsedInput, _tweetsRepository, _textWriter);
            command.Execute();
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.PrintInstructions();
            program.WaitForCommand();
            Console.ReadLine();

        }
    }
}
