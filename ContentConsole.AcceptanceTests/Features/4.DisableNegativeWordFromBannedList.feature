Feature: DisableNegativeWordFromBannedList
	As an content curator
	I want disable negative word filtering on the command line
	So that I can see the original content.

Scenario Outline: Replace the middle letters with hashes for negative 
	Given <content> is supplied
	And a set of predefined negative words that include 'bad,horrible'
	And disabled negative word filtering
	When the content is analysed
	And provide the a sanitized phrase as its '<output>'
Examples:
| content                                                                              | output                                                                               | expectedNumber |
| The weather in Manchester in winter is bad. It must be horrible for people visiting. | The weather in Manchester in winter is bad. It must be horrible for people visiting. | 2              |

