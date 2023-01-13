Feature: TipOfTheDayManager

@SplitServer
@SingleServer
Scenario: TipOfTheManager_AddEditDeleteTip
	Given I navigated to Tip of the Day Manager tool
	When I Click on the Add Tip button
	And I enter Tip title as 'Testing' and Tip content as 'Automation testing tip' and click on Add New Tip button
	Then the tip 'Testing' should be added successfully
	When I select the checkbox against the added tip 'Testing' and click on the Edit Tip button
	And I edit the tip title as 'Test' and click on Save Changes button
	Then the tip should be edited successfully and the new text 'Test' should reflect in the table
	When I select a tip 'Test' and click the second left most sign in the move rank column
	Then the selected tip 'Test' should move one rank up in the table
	When I select a tip 'Test' and click the third left most sign in the move rank column
	Then the selected tip 'Test' should move one rank down in the table
	When I select a tip 'Test' and click the left most sign in the move rank column
	Then the selected tip 'Test' should move to the top of the table
	When I select a tip 'Test' and click the fourth left most sign in the move rank column
	Then the selected tip 'Test' should move to the bottom of the table
	When I select a tip 'Test' and click on the Delete Tip button
	Then a confirmation popup will appear stating 'Are you sure you want to Delete the selected Tip?'
	When I click Delete Tip button on the pop up
	Then the tip 'Test' will be deleted successfully from the table


@SplitServer
@SingleServer
Scenario: TipOfTheManager_PromoteLLTraining_Edcentra
	Given I Insert tips in the database
	And I opened EDCENTRA app url 
	When I entered 'administrator' and 'toolkit' and clicked login button
	Then the Tip of the day popup should appear with Next and Close button
	And the tip content 'Did you know Edwards offers LL Training ?' should appear 
	When I click on the Next button
	Then the tip content 'Did you know Edwards offers Tuesday training ...' should appear
	When I Click on the previous button
	Then the tip content 'Did you know Edwards offers LL Training ?' should appear
	When I click on the Next button twice
	Then the tip content 'More training on Wednesdays ...' should appear
	When I click on the don't show this tip again checkbox
	Then the tip header 'Tuesday Training' should appear
	When I Click on the close button
	And I clicked on user and selected logout option
	And I entered 'administrator' and 'toolkit' and clicked login button
	Then the Tip of the day popup should appear with Next and Close button
	And the tip content 'Did you know Edwards offers LL Training ?' should appear 
	When I click on the don't show this tip again checkbox
	Then the tip content 'Did you know Edwards offers Tuesday training ...' should appear
	When I click on the don't show this tip again checkbox
	Then the tip header 'Lorum Ipsum Training' should appear
	When I click on the don't show this tip again checkbox
	Then the tip header 'Friday Training' should appear
	When I click on the don't show this tip again checkbox
	Then the tip header 'Saturday Training' should appear
	When I click on the don't show this tip again checkbox
	Then the tip header 'Sundays are holidays' should appear
	When I click on the don't show this tip again checkbox
	Then the Tip of the day popup should disappear
	And I should be navigated to Home page

