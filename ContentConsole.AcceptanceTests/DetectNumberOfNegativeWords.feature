Feature: Detect number of negative words
	As a user
	I want see the number of negative words in a text input
	So that we can track the amount of negative content


Scenario Outline: Detect negative words
	Given <content> is supplied
	# And a set of predefined negative words
	When the content is analysed
	Then the number of negative words should be <expectedNumber>
	And provide the analysed phrase as its output
Examples:
| content                                                                                                      | expectedNumber |
| The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting. | 2              |
| The weather in Manchester in winter is good. It rains all the time - it must be great for people visiting.   | 0              |
