Feature: Hash out negative words shown to clients
	As a reader
	I want negative words filtered out of the text
	So that our clients are not upset by negative language

Scenario Outline: Replace the middle letters with hashes for negative 
	Given <content> is supplied
	And a set of predefined negative words that include 'bad,horrible'
	When the content is analysed
	And provide the a sanitized phrase as its '<output>'
Examples:
| content                                                                              | output                                                                               |
| The weather in Manchester in winter is bad. It must be horrible for people visiting. | The weather in Manchester in winter is b#d. It must be h######e for people visiting. |
| The weather in Manchester in winter is good. It must be great for people visiting. | The weather in Manchester in winter is good. It must be great for people visiting. |
