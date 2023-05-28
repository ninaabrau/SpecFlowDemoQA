Feature: Alerts

A short summary of the feature

@browser_windows
Scenario: Verify new tab is opened
Given I navigate to Browser Windows
When I Click on New Tab
Then New tab is opened

@browser_windows
Scenario: Verify new window is opened
Given I navigate to Browser Windows
When I Click on New Window
Then New window is opened

@alert
Scenario: Verify output entered in prompt
Given I navigate to Alerts
When I click on prompt box click me
And I enter "Hello There" in the prompt box
Then Prompt output is displayed

@alert
Scenario: Verify output is not displayed when prompt is dismissed
Given I navigate to Alerts
When I click on prompt box click me
And I dismiss the prompt
Then Prompt output is not displayed
