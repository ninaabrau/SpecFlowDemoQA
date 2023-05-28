Feature: Login

Verify register and login feature

@tag1
Scenario: Verify user is logged in
Given I navigate to Login Page
When I click New User button to register new user
And I register with user details
Then User is successfuly registered
When I go back to login page
And I login with user details
Then User profile is displayed
