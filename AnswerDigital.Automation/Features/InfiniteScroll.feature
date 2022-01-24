Feature: Infinite Scroll2

Background: 
Given I have navigated to the Herokuapp landing page
	And I have clicked the Infinite Scroll link

@Regression
Scenario Outline: Entering keys into the input feild displays the last key used
When I scroll down '4' times
Then I can see the page has loaded '4' times