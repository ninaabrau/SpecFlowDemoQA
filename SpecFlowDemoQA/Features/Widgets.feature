Feature: Widgets

A short summary of the feature

@auto_complete
Scenario: Verify auto complete in single color name field
Given I navigate to Auto Complete
When I start to type 'r' single color name field
And I press enter key to single color name field to autocomplete
Then Color "Red" should be added in the single color name field

@auto_complete
Scenario: Verify auto complete in multiple color name field
Given I navigate to Auto Complete
When I start to type 'r' multiple color name field
And I press enter key to multiple color name field to autocomplete
Then Color "Red" should be added in the multiple color name field
When I start to type 'g' multiple color name field
And I press enter key to multiple color name field to autocomplete
Then Color "Green" should be added in the multiple color name field

@date_picker
Scenario: Verify selected date from the calendar
Given I navigate to Date Picker
When I click on Select Date field
Then Calendar picker is displayed
When I select date "May 24, 2023"
Then Date is displayed in the selected date field

@date_picker
Scenario: Verify selected date time from the calendar
Given I navigate to Date Picker
When I click on Date and Time field
Then Calendar picker is displayed
When I select date time "Aug 24, 2036 9:15 PM"
Then Date is displayed in the date time field

@tooltip
Scenario: Verify tooltip is displayed on hover
Given I navigate to Tooltips
When I hover over the button 
Then Tooltip "You hovered over the Button" is displayed
When I hover over the text field
Then Tooltip "You hovered over the text field" is displayed
When I hover over the contrary
Then Tooltip "You hovered over the Contrary" is displayed
When I hover over the section
Then Tooltip "You hovered over the 1.10.32" is displayed


