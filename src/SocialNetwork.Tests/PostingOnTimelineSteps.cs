using System;

using Shouldly;

using SocialNetwork.Domain;
using SocialNetwork.Infrastructure;

using TechTalk.SpecFlow;

namespace SocialNetwork.Tests
{
    [Binding]
    public class PostingOnTimelineSteps
    {
        DateTime _today = DateTime.Today;

        readonly TweetsRepository _tweetsRepository = new TweetsRepository();

        Timeline _timeline;

        User _user;

        User famousUser;

        [Given(@"a User ""(.*)"" has an account")]
        public void GivenAUserHasAnAccount(string name)
        {
            _user = new User(name);
            _timeline = new Timeline(_user, _tweetsRepository, _today);
        }

        [When(@"they publish a tweet ""(.*)""")]
        public void WhenTheyPublishATweet(string message)
        {
            _tweetsRepository.PostTweet(new Tweet(_user, message, _today));
        }

        [When(@"they publish a tweet ""(.*)"" (.*) mins ago")]
        public void WhenTheyPublishATweetMinsAgo(string message, int minutesPassed)
        {
            _tweetsRepository.PostTweet(new Tweet(_user, message, _today.AddMinutes(-minutesPassed)));
        }

        [When(@"they publish a tweet ""(.*)"" (.*) seconds ago")]
        public void WhenTheyPublishATweetSecondsAgo(string message, int secondsPassed)
        {
            _tweetsRepository.PostTweet(new Tweet(_user, message, _today.AddSeconds(-secondsPassed)));
        }

        [When(@"they Follow User ""(.*)""")]
        public void WhenTheyFollowUser(string userToFollow)
        {
            famousUser = new User(userToFollow);
            _user.Follow(famousUser);
        }

        [Then(@"the timeline should contain ""(.*)""")]
        public void ThenTheTimelineShouldContain(string formattedMessage)
        {
            _timeline.FormattedTweets().ShouldContain(formattedMessage);
        }
    }
}