Feature: Interactions

Verify droppable and sortable actions

@droppable
Scenario: Verify drag box is dropped in the drop box
Given I navigate to droppable page
When I drag Drag me box to Drop here box
Then "Dropped!" is displayed in the drop box 

@sortable
Scenario: Sort list in descending order
Given I navigate to sortable page
When I sort the list to descending order
Then List is sorted in descending order
