Feature: SendingCommandsToConsoleApp
	In the console application
	as a user
	I want to be able to input commands


Scenario: Posting a tweet
	Given the application is awaiting a command
	When I enter a post command with message of "Send a random tweet"
	Then there should be atleast 1 tweet posted

Scenario: Reading a users timeline
	Given the application is awaiting a command
	And a tweet with message "Testing tweets" was posted by user "Sam" 5 minutes ago
	When I enter a read command for user "Sam" timeline
	Then then the console should return "Testing tweets (5 minutes ago)"
