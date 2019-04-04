Feature: ValidateBugStats
	Validate the total number of bugs and turnaround time


Scenario: Validate Total number of bugs

Given I have requested usernames
When I have passed them to the web UI
Then I will get total number of bugs


