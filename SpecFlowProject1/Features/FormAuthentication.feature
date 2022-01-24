Feature: Form Authentication

Background: 
Given I have navigated to the Herokuapp landing page
	And I have clicked the Form Authentication link

@Regression
Scenario: Try to login with correct username and wrong password
	When I log into Herokuapp with the incorrect password
	Then I can see the text 'Your password is invalid!'

Scenario: Try to login with wrong username and correct password
	When I log into Herokuapp with the incorrect username
	Then I can see the text 'Your username is invalid!'

Scenario: Try to login with correct username and correct password
	When I log into Herokuapp with the correct credentials
	Then I can see the text 'You logged into a secure area!'