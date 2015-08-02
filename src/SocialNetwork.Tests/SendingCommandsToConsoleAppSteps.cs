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

        Mock<ITweetsRepository> _tweetsRepository;


        InputParser _inputParser;
        DateTime _today = DateTime.Today;

        StringWriter _textWriter;

        [Given(@"the application is awaiting a command")]
        public void GivenTheApplicationIsAwaitingACommand()
        {
            _tweetsRepository = new Mock<ITweetsRepository>();
            _inputParser = new InputParser();
            _textWriter = new StringWriter();
            _program = new Program(_tweetsRepository.Object, _inputParser, new CommandFactory(), _textWriter);
        }

        [Given(@"a tweet with message ""(.*)"" exists for a user ""(.*)""")]
        public void GivenATweetWithMessageExistsForAUser(string message, string username)
        {
            IEnumerable<Tweet> existingTweets = new List<Tweet>() { new Tweet(new User(username), message, _today) };
            _tweetsRepository.Setup(repo => repo.GetTweets(new User(username))).Returns(existingTweets);
        }

        [Given(@"a tweet with message ""(.*)"" was posted by user ""(.*)"" (.*) minutes ago")]
        public void GivenATweetWithMessageWasPostedByUserMinutesAgo(string message, string username, int minutesPassed)
        {
             IEnumerable<Tweet> existingTweets = new List<Tweet>() { new Tweet(new User(username), message, _today.AddMinutes(-minutesPassed)) };
            _tweetsRepository.Setup(repo => repo.GetTweets(It.IsAny<User>())).Returns(existingTweets);
        }

        
        [When(@"I enter a post command with message of ""(.*)""")]
        public void WhenIEnterAPostCommandWithMessageOf(string message)
        {
            string input = "sam -> test message";
            var parsedInput = _inputParser.Parse(input, _today);
            _program.Execute(parsedInput);
        }
        

        [Then(@"there should be atleast (.*) tweet posted")]
        public void ThenThereShouldBeAtleastTweetPosted(int tweetCount)
        {
            _tweetsRepository.Verify(repo => repo.PostTweet(It.IsAny<Tweet>()), Times.AtLeastOnce);
        }

        [When(@"I enter a read command for user ""(.*)"" timeline")]
        public void WhenIEnterAReadCommandForUserTimeline(string username)
        {
            string input = "sam";
            var parsedInput = _inputParser.Parse(input, _today);
            _program.Execute(parsedInput);
        }

        [Then(@"then the console should return ""(.*)""")]
        public void ThenThenTheConsoleShouldReturn(string expectedOutput)
        {
            var output = _textWriter.ToString();
            _textWriter.ToString().ShouldContain(expectedOutput);
        }


    }
}
