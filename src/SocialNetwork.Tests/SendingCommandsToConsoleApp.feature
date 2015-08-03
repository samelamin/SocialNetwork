Feature: SendingCommandsToConsoleApp
	In the console application
	as a user
	I want to be able to input commands


Scenario: Posting a tweet
	Given the application is awaiting a command
	When I enter a post command for "sam" with message of "Send a random tweet"
	Then there should be atleast 1 tweet posted
	And the console should return "Tweet Sent"

Scenario: Reading a users timeline
	Given the application is awaiting a command
	And a tweet with message "Testing tweets" was posted by user "Sam" 5 minutes ago
	When I enter a read command for user "Sam" timeline
	Then then the console should return "Testing tweets (5 minutes ago)"

Scenario: Follow a user
	Given the application is awaiting a command
	When I enter a follow command for "Sam" To Follow "Sandro"
	Then the console should return "Sam has followed Sandro"

Scenario: Display a wall
	Given the application is awaiting a command
	And a tweet with message "Testing tweets" was posted by user "Sam" 5 minutes ago
	And the user "Sam" has followed "Sandro"
	When I enter a wall command for "Sam"
	Then the console should return "Sam has followed Sandro"