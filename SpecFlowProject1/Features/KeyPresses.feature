Feature: Key Presses2

Background: 
Given I have navigated to the Herokuapp landing page
	And I have clicked the Key Presses link

@Regression
Scenario Outline: Entering keys into the input feild displays the last key used
When I send the text '<input text>' into the Key Presses input
Then I can see the text '<expected text>' in the Key Presses result

Example:
| input text | expected text  |
| A          | You entered: A |
| 1          | You entered: 1 |
| b          | You entered: B |
| 0          | You entered: 0 |
