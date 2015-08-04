Feature: SendingCommandsToConsoleApp
	In the console application
	as a user
	I want to be able to input commands


Scenario: Posting a tweet
	Given the application is awaiting a command
	When I enter a post command for "sam" with message of "Send a random tweet"
	Then the console should contain "Tweet Sent"

Scenario: Reading a users timeline
	Given the application is awaiting a command
	And a tweet with message "Testing tweets" was posted by user "Sam" 5 minutes ago
	When I enter a read command for user "Sam" timeline
	Then then the console should return "Sam - Testing tweets (5 minutes ago)"

Scenario: Follow a user
	Given the application is awaiting a command
	When I enter a follow command for "Sam" To Follow "Sandro"
	Then the console should contain "Sam has followed Sandro"

Scenario: Display a wall
	Given the application is awaiting a command
	And a tweet with message "Whos coming to the LSCC roundtable tonight?" was posted by user "Sam" 5 minutes ago
	And a tweet with message "Looking forward to the LSCC Talks Today" was posted by user "Sandro" 10 minutes ago
	And the user "Sam" has followed "Sandro"
	When I enter a wall command for "Sam"
	Then the console should contain "Sam follows Sandro"
	Then the console should contain "Sam - Whos coming to the LSCC roundtable tonight? (5 minutes ago)"
	Then the console should contain "Sandro - Looking forward to the LSCC Talks Today (10 minutes ago)"

Scenario: Display a wall (case insensitive)
	Given the application is awaiting a command
	And a tweet with message "Whos coming to the LSCC roundtable tonight?" was posted by user "Sam" 5 minutes ago
	And a tweet with message "Looking forward to the LSCC Talks Today" was posted by user "Sandro" 10 minutes ago
	And the user "Sam" has followed "Sandro"
	When I enter a wall command for "sam"
	Then the console should contain "Sam follows Sandro"
	Then the console should contain "Sam - Whos coming to the LSCC roundtable tonight? (5 minutes ago)"
	Then the console should contain "Sandro - Looking forward to the LSCC Talks Today (10 minutes ago)"