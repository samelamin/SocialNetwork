using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using Moq;

using NUnit.Framework;

using Shouldly;

using SocialNetwork.ConsoleApplication;
using SocialNetwork.ConsoleApplication.Commands;
using SocialNetwork.Domain;
using SocialNetwork.Infrastructure;

using TechTalk.SpecFlow;

namespace SocialNetwork.Tests
{
    [Binding]
    public class SendingCommandsToConsoleAppSteps
    {
        Program _program;
        ITweetsRepository  _tweetsRepository;
        IUsersRepository   _usersRepository;
        InputParser _inputParser;
        DateTime _today = DateTime.Today;
        StringWriter _textWriter;

        [Given(@"the application is awaiting a command")]
        public void GivenTheApplicationIsAwaitingACommand()
        {
            _tweetsRepository = new TweetsRepository();
            _usersRepository = new UsersRepository();
            _inputParser = new InputParser();
            _textWriter = new StringWriter();
            _program = new Program(_tweetsRepository, _usersRepository, _inputParser, new CommandFactory(), _textWriter);
        }

        [Given(@"a tweet with message ""(.*)"" exists for a username ""(.*)""")]
        public void GivenATweetWithMessageExistsForAUser(string message, string username)
        {
            _tweetsRepository.PostTweet(new Tweet(new User(username), message, _today));
        }

        [Given(@"a tweet with message ""(.*)"" was posted by user ""(.*)"" (.*) minutes ago")]
        public void GivenATweetWithMessageWasPostedByUserMinutesAgo(string message, string username, int minutesPassed)
        {
            _tweetsRepository.PostTweet(new Tweet(new User(username), message, _today.AddMinutes(-minutesPassed)));
        }


        [Given(@"the user ""(.*)"" has followed ""(.*)""")]
        public void GivenTheUserHasFollowed(string username, string userToFollow)
        {
            User user = _usersRepository.GetUser(username);
            User famousUser = new User(userToFollow);
            user.Following.Add(famousUser);

        }


        [When(@"I enter a read command for user ""(.*)"" timeline")]
        public void WhenIEnterAReadCommandForUserTimeline(string username)
        {
            var parsedInput = _inputParser.Parse(username, _today);
            _program.Execute(parsedInput);
        }

        [When(@"I enter a post command for ""(.*)"" with message of ""(.*)""")]
        public void WhenIEnterAPostCommandForWithMessageOf(string username, string message)
        {
            string input = string.Format("{0} -> {1}", username, message);
            var parsedInput = _inputParser.Parse(input, _today);
            _program.Execute(parsedInput);
        }


        [Then(@"then the console should return ""(.*)""")]
        public void ThenThenTheConsoleShouldReturn(string expectedOutput)
        {
            _textWriter.ToString().ShouldContain(expectedOutput);
        }

        [When(@"I enter a follow command for ""(.*)"" To Follow ""(.*)""")]
        public void WhenIEnterAFollowCommandForToFollow(string user, string famousUser)
        {
            string input = string.Format("{0} follows {1}", user, famousUser);
            var parsedInput = _inputParser.Parse(input, _today);
            _program.Execute(parsedInput);
        }

        [When(@"I enter a wall command for ""(.*)""")]
        public void WhenIEnterAWallCommandFor(string user)
        {
            string input = string.Format("{0} wall", user);
            var parsedInput = _inputParser.Parse(input, _today);
            _program.Execute(parsedInput);
        }

        [Then(@"the console should contain ""(.*)""")]
        public void ThenTheConsoleShouldContain(string expectedOutput)
        {
            _textWriter.ToString().ShouldContain(expectedOutput);
        }
    }
}
