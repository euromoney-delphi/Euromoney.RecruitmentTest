Feature: Retrieve negative words from data store
	As an administrator
	I want to be able to change the set of negative words counted
	So that I don't need to change the code when we select new negative words or phrases

Scenario Outline: Detect negative words
	Given <content> is supplied
	And a set of predefined negative words that include '<bannedWords>'
	When the content is analysed
	Then the number of negative words should be <expectedNumber>
	#And provide the analysed phrase as its output
Examples:
| content                                                                              | bannedWords        | expectedNumber |
| The weather in Manchester in winter is bad. It must be horrible for people visiting. | bad,horrible,swine | 2              |
| The weather in Manchester in winter is bad. It must be horrible for people visiting. | annoying,swine     | 0              |
