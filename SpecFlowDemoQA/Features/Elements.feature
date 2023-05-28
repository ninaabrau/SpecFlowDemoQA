Feature: Elements

Test the elements category
@text_box
Scenario Outline:Verify textbox value submitted
Given I navigate to Elements
When I click on Text Box subcategory
And I fill in details in the fields
| FullName   | Email   | CurrentAddress   | Permanent Address  |
| <fullName> | <email> | <currentAddress> | <permanentAddress> |
And I click Submit
Then Below details are listed in the result
| FullName   | Email   | CurrentAddress   | Permanent Address  |
| <fullName> | <email> | <currentAddress> | <permanentAddress> |
Examples: 
| fullName | email        | currentAddress | permanentAddress |
| John Doe | jd@email.com | Cebu           | Manila           |
|          | test@em.com  |                |                  |
| John Doe |              |                | Philippines      |

@text_box
Scenario: Invalid email address
Given I navigate to Elements
When I click on Text Box subcategory
And I enter in@valid in email address field
And I click Submit
Then Email address field should be displayed in red border

@check_box
Scenario: Verify output when I select all checkboxes
Given I navigate to Elements
When I click on Check Box subcategory
And I click expand all to show all
And I check Home checkbox
Then Output should list all selected items

@check_box
Scenario: Verify output for selected checkboxes
Given I navigate to Elements
When I click on Check Box subcategory
And I click expand all to show all
And I select the following checkboxes
| CheckBox  |
| Notes     |
| WorkSpace |
| Public    |
| General   |
Then Output should list all selected items

@web_tables
Scenario: Verify values after editing entry in Web Tables
Given I navigate to Elements
When I click on Web Tables subcategory
And I click edit on entry number 1
Then Registration form is displayed
When I edit details in the form to below values
| FirstName | LastName | Age | Email      | Salary | Department |
| Try       | First    | 29  | try@go.com | 20000  | IT         |
Then Details should be updated for entry number 1

@buttons
Scenario: Verify message is displayed when button action is correct
Given I navigate to Elements
When I click on Buttons subcategory
And I double click on Double Click Me button
Then Double click message is displayed
When I right click on Right Click Me button
Then Right click message is displayed
When I click on Click Me button 
Then Dynamic click message is displayed

@buttons
Scenario: Verify message is not displayed when button action is incorrect
Given I navigate to Elements
When I click on Buttons subcategory
And I click on Double Click Me button
Then Double click message is not displayed
When I double click on Right Click Me button
Then Right click message is not displayed
When I right click on Click Me button 
Then Dynamic click message is not displayed

@download
Scenario: Verify file is downloaded
Given I navigate to Elements
When I click on Download and Upload subcategory
And I click Download button
Then File is downloaded

@upload
Scenario: Verify file is uploaded
Given I navigate to Elements
When I click on Download and Upload subcategory
And I upload file
Then File is uploaded
