Feature: Posting On Timeline
	In order to socialise with friends
	As a user who uses this social network
	I want to tweet and see my friends timeline

Scenario Outline: Multiple Users Posting 
	Given a User "<user_name>" has an account 
	When they publish a tweet "<tweet_message>"
	Then the timeline should contain "<tweet_message>"

		Examples: 
		| user_name | tweet_message            |
		| Alice     | I love the weather today |
		| Bob       | Damn! We lost!           |
		| Bob       | Good game though.        |

	Scenario: I can view Bobs timeline
		Given a User "Bob" has an account 
		When they publish a tweet "Damn! we lost!" 1 mins ago
		And they publish a tweet "Good game though." 2 mins ago
		Then the timeline should contain "Bob - Damn! We lost! (1 minute ago)"
		Then the timeline should contain "Bob - Good game though. (2 minutes ago)"

	Scenario Outline: I can view Alice and Bob’s timelines
		Given a User "<user_name>" has an account 
		When they publish a tweet "<tweet_message>" <minutes_passed> mins ago
		Then the timeline should contain "<formatted_tweet>"
	
		Examples: 
		| user_name | tweet_message           | formatted_tweet                                   | minutes_passed |
		| Alice     | I love the weather today | Alice - I love the weather today (5 minutes ago) | 5              |
		| Bob       | Damn! We lost!           | Bob - Damn! We lost! (1 minute ago)              | 1              |
		| Bob       | Good game though.        | Bob - Good game though. (2 minutes ago)          | 2              |

	Scenario: Charlie Follows Alice
		Given a User "Charlie" has an account
		When they Follow User "Alice" 
		And they publish a tweet "I'm in New York today! Anyone want to have a coffee?" 2 seconds ago
		Then the timeline should contain "Charlie follows Alice"
		Then the timeline should contain "Charlie - I'm in New York today! Anyone want to have a coffee? (2 seconds ago)"
