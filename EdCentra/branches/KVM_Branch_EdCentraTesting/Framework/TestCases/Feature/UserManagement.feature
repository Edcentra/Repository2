Feature: UserManagement

Background: 
Given I opened EDCENTRA app url in browser
When I entered username as 'administrator' and password as 'toolkit' and clicked login button
Then  I should be navigated to home page

@SplitServer
@SingleServer
@UserManagement
Scenario:User Manager - Create User
	When Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
	Then Create User form is displayed.
	When Clicked Create
	Then Required Field text should appear besides User Name, Password, confirm, First Name, Last Name and e-mail field
	When Fill in the following fields one by one username 'TestUser' password 'Test@123', First Name 'Test', clicking ‘Create’ in between entering them: User Name, Password/confirm, First Name, Last Name, e-mail
	Then Required Field is displayed each time besides empty required field until all of the fields have been entered correctly
	When I added new User with details 'testuser' 'Test@123' 'Test@123' 'Client Name' 'Edward' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
	And Provided all application permissions
	Then Newly created user 'test' 'user' 'testuser' should appear as Link(User name as link text) on left hand side.User detail tab should be displayed for newly created user
	When logged out
	And  logon as the newly created user userName 'testuser' and password 'Test@123'
	And Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
	Then Create User form is displayed.
	When I entered user with details 'testuser1' 'Test1@123' 'Test2@123' 'Client Name' 'Edward' 'test1' 'user1' and 'testuser1@atlascopco.com' in Create user form
	Then Passwords do not match text should appear besides conform filed

@SplitServer
@SingleServer
@UserManagement
Scenario: User Manager - Memorable Information
    When Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
    And I added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
	And Provided all application permissions
	And logged out
	And logon as the newly created user userName 'testuser' and password 'Test@123'
	And In User Manager application click on Current User tab
	Then User details displayed with details 'testuser', 'user', 'testuser@atlascopco.com'
	When I click Set Memorable Information Link 
	And I entered Memorable question 'What is Client Name?', Memorable answer 'Atlas Copco' and Reentered password 'Test@123'
	And I clicked Apply button
	Then Successful message 'Your Memorable Question has been updated' should appear on screen
	When clicked on OK button
	And logged out
	And logon as the newly created user userName 'testuser' and password 'Test1@123'
	And clicked Forgot Password
	Then Forgotten password dialog opened displaying memorable Question: 'What is the name of this company?'
	When Supply memorable answer: 'Atlas Copco' and click the apply button
	Then Password Reset dialog 'Password Reset' opened displaying message Password has been reset Please change this as soon as possible
	When  clicked on OK button
	And Login with updated password 'testuser' and 'password123'
	Then Logon successful

@SplitServer
@SingleServer
@UserManagement
Scenario: User Manager - Change Password
    When Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
    And I added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
	And Provided all application permissions
	And logged out
	And logon as the newly created user userName 'testuser' and password 'Test@123'
	And In User Manager application click on Current User tab
	Then User details displayed with details 'testuser', 'user', 'testuser@atlascopco.com'
	When I click Change Password Link 
	Then 'Change password' window should open
	When entered current password 'Test@123', new password 'password123', confirm new password 'password123' fields and clicked Apply button
	Then New password applied
	When logged out
	And  Login with old password 'testuser' and 'Test@123'
	Then error message should display on login page
	When Login with updated password 'testuser' and 'password123'
	Then Logon successful

@SplitServer
@SingleServer
@UserManagement
Scenario: User Manager - Add User to Group	
	When Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
	Then Create User form is displayed.
	When I added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
	And Provided all application permissions
	And created new group with group name 'Group1' and Description 'Testing Group'
	And Clicked on newly created Group link on left hand side on the Maintain Groups tab , Select group detail tab is displayed and added created user 'test' 'user' 'testuser'
	Then 'Changes have been applied' text appears on Users tab.Changes should be saved while navigating to other groups.

@SplitServer
@SingleServer
@UserManagement
Scenario: User Manager - Create Group
  When Open the User Manager application, and click on the ‘Maintain Groups’ tab.Click on "Create Group" link
  Then The Create Group form should show
  When Clicked Create
  Then Required Field text should appear besides GroupName
  When created new group with group name 'Group1' and Description 'Testing Group'
  Then newly created group 'Group1' should be shown in left side group list

@SplitServer
@SingleServer
@UserManagement
Scenario: User Manager - Edit Group 
    When created new group with group name 'Group1' and Description 'Testing Group'
	And Selected created group 'Group1'
	Then Group details should displayed  group name 'Group1' and Description 'Testing Group'
	When updated Group Name to 'TestGroup100', Group Description to 'TestingGroup100' and clicked Apply button
	Then 'Changes have been applied' text will be displayed on the detail tab.

@SplitServer
@SingleServer
@UserManagement
Scenario: User Manager - Edit User
    When Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
    And I added new User with details 'Vaccum Edwards1' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'Vaccum' 'Edward' and 'Vaccum@Edwardscopco.com' in Create user form
	And  Clicked the user link on left hand side created 'Vaccum Edwards1', 'Vaccum', 'Edward'
	Then Users details tab displayed with details 'Vaccum' 'Edward' and 'Vaccum@Edwardscopco.com'
	When altered field First Name 'Vaccum1', 'Edward1','Vaccum1@Edwardscopco.com' and clicked Apply button
	Then 'Changes have been applied' text will be displayed on the detail tab.

@SplitServer
@SingleServer
@UserManagement
Scenario: Delete Group - User Manager
    When created new group with group name 'Group1' and Description 'Testing Group'
	And Selected created group 'Group1'
	Then Group details should displayed  group name 'Group1' and Description 'Testing Group'
	When clicked Delete button
	Then 'Are you sure you wish to delete the Group ?' pop-up is displayed
	When Press the Cancel button on the popup
	Then The pop-up should disappear leaving the group intact 'Group1'
	When clicked Delete button
	Then 'Are you sure you wish to delete the Group ?' pop-up is displayed
	When answer Ok to the popup box 
	Then The group disappears from the links on the left and an empty Create Group form is displayed 'Group1'.

@SplitServer
@SingleServer
@UserManagement
Scenario: User Manager - Delete User
  When Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And I added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
  And Selected created user 'testuser' 'test' 'user'
  Then User details displayed with details 'testuser', 'user', 'testuser@atlascopco.com' on maintain user tab
  When Clicked Delete
  Then 'Are you sure you wish to delete the user?' pop-up message displayed
  When Clicked Check that the ‘Cancel’ button on the same popup cancels the delete request
  Then The request is cancelled and the existing details remain displayed 'test' 'user' 'testuser'
  When Clicked Delete
  Then 'Are you sure you wish to delete the user?' pop-up message displayed
  When answer Ok to the popup box 
  Then User details form cleared and blank form displayed 'testuser' 'test' 'user'

@SplitServer
@SingleServer
@UserManagement
  Scenario: User Manager - Group Permissions (1)
  When Launched and started Eissa simulator 
  And Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And I added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
  And Clicked on the Maintain Groups tab
  Then The Create Group form should show
  And New group created with group name 'Group1'
  When Selected created group 'Group1'
  Then Group details should displayed  group name 'Group1' and Description 'Testing Group'
  When added newly created user 'test' 'user' 'testuser' in group
  Then 'Changes have been applied' text appears on Users tab.Changes should be saved while navigating to other groups.
  When Clicked 'group permission' tab selected for 'Dispatch Manager' application and kept 'View' checkbox and clicked Apply
  And logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only Dispatch Manager application should be available to select.User should only able to view the diffferent forms
  When clicked dispatch manager link
  Then I should be able to view but shouldn't be allow to edit
  When logged out
  And I entered username as 'administrator' and password as 'toolkit' and clicked login button
  And Opened the User Manager application, and click on the ‘Maintain Groups’ tab
  And Selected created group 'Group1'
  And Clicked 'group permission' tab selected for 'Dispatch Manager' application and kept 'Edit' checkbox and clicked Apply
  And logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only Dispatch Manager application should be available to select and User should able to edit different forms in Dispatch Manager

@SplitServer
@SingleServer
@UserManagement
  Scenario: User Manager - Group Permissions (2)
  When Launched and started Eissa simulator 
  And Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And I added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
  And Clicked on the Maintain Groups tab
  Then The Create Group form should show
  And New group created with group name 'Group1'
  When Selected created group 'Group1'
  Then Group details should displayed  group name 'Group1' and Description 'Testing Group'
  When added newly created user 'test' 'user' 'testuser' in group
  Then 'Changes have been applied' text appears on Users tab.Changes should be saved while navigating to other groups.
  When Clicked 'group permission' tab selected for 'Configuration Handler' application and kept 'View' checkbox and clicked Apply
  And logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Configuration Handler' link should be visible under configure dropdown list
  When clicked Configuration Handler link
  Then I should be able to view 'Configuration Handler' page but shouldn't be allow to edit
  When logged out
  And I entered username as 'administrator' and password as 'toolkit' and clicked login button
  And Opened the User Manager application, and click on the ‘Maintain Groups’ tab
  And Selected created group 'Group1'
  And Unchecked all selected permissions
  And Clicked 'group permission' tab selected for 'Historian' application and kept 'View' checkbox and clicked Apply
  And logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Historian' should be available to select
  When clicked 'Historian' link on home page
  Then I should be able to view 'Historian' page but shouldn't be allow to edit
  When logged out
  And I entered username as 'administrator' and password as 'toolkit' and clicked login button
  And Opened the User Manager application, and click on the ‘Maintain Groups’ tab
  And Selected created group 'Group1'
  And Unchecked all selected permissions
  And Clicked 'group permission' tab selected for 'Device Explorer' application and kept 'View' checkbox and clicked Apply
  And logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Device Explorer' should be available to select
  When clicked 'Device Explorer' link on home page
  Then I should be able to view 'Device Explorer' page but shouldn't be allow to edit
  When logged out
  And I entered username as 'administrator' and password as 'toolkit' and clicked login button
  And Opened the User Manager application, and click on the ‘Maintain Groups’ tab
  And Selected created group 'Group1'
  And Unchecked all selected permissions
  And Clicked 'group permission' tab selected for 'Reports' application and kept 'View' checkbox and clicked Apply
  And logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Reports' should be available to select
  When clicked 'Reports' link on home page
  Then I should be able to view 'Reports' page but shouldn't be allow to edit
  When logged out
  And I entered username as 'administrator' and password as 'toolkit' and clicked login button
  And Opened the User Manager application, and click on the ‘Maintain Groups’ tab
  And Selected created group 'Group1'
  And Unchecked all selected permissions
  And Clicked 'group permission' tab selected for 'Live Alerts List' application and kept 'View' checkbox and clicked Apply
  And logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Live Alerts List' should be available to select
  When clicked 'Live Alerts List' link on home page
  Then I should be able to view 'Live Alerts List' page but shouldn't be allow to edit

@SplitServer
@SingleServer
@UserManagement
  Scenario:User Manager - User Permissions (1)
  When Launched and started Eissa simulator 
  And Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And I added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
  And Clicked 'user permission' tab selected for 'Dispatch Manager' application and kept 'View' checkbox and clicked Apply
  And logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only Dispatch Manager application should be available to select.User should only able to view the diffferent forms
  When clicked dispatch manager link
  Then I should be able to view but shouldn't be allow to edit
  When logged out
  And I entered username as 'administrator' and password as 'toolkit' and clicked login button
  And Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And Selected created user 'testuser' 'test' 'user'
  And Clicked 'user permission' tab selected for 'Dispatch Manager' application and kept 'Edit' checkbox and clicked Apply
  And logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only Dispatch Manager application should be available to select and User should able to edit different forms in Dispatch Manager

@SplitServer
@SingleServer
@UserManagement
  Scenario: User Manager - User Permissions (2) 
  When Launched and started Eissa simulator 
  And Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And I added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
  And Clicked 'user permission' tab selected for 'Configuration Handler' application and kept 'View' checkbox and clicked Apply
  And logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Configuration Handler' link should be visible under configure dropdown list
  When clicked Configuration Handler link
  Then I should be able to view 'Configuration Handler' page but shouldn't be allow to edit
  When logged out
  And I entered username as 'administrator' and password as 'toolkit' and clicked login button
  And Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And Selected created user 'testuser' 'test' 'user'
  And Unchecked all selected permissions
  And Clicked 'user permission' tab selected for 'Historian' application and kept 'View' checkbox and clicked Apply
  And logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Historian' should be available to select
  When clicked 'Historian' link on home page
  Then I should be able to view 'Historian' page but shouldn't be allow to edit
  When logged out
  And I entered username as 'administrator' and password as 'toolkit' and clicked login button
  And Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And Selected created user 'testuser' 'test' 'user'
  And Unchecked all selected permissions
  And Clicked 'user permission' tab selected for 'Device Explorer' application and kept 'View' checkbox and clicked Apply
  And logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Device Explorer' should be available to select
  When clicked 'Device Explorer' link on home page
  Then I should be able to view 'Device Explorer' page but shouldn't be allow to edit
  When logged out
  And I entered username as 'administrator' and password as 'toolkit' and clicked login button
  And Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And Selected created user 'testuser' 'test' 'user'
  And Unchecked all selected permissions
  And Clicked 'user permission' tab selected for 'Reports' application and kept 'View' checkbox and clicked Apply
  And logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Reports' should be available to select
  When clicked 'Reports' link on home page
  Then I should be able to view 'Reports' page but shouldn't be allow to edit
  When logged out
  And I entered username as 'administrator' and password as 'toolkit' and clicked login button
  And Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And Selected created user 'testuser' 'test' 'user'
  And Unchecked all selected permissions
  And Clicked 'user permission' tab selected for 'Live Alerts List' application and kept 'View' checkbox and clicked Apply
  And logged out
  When logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Live Alerts List' should be available to select
  When clicked 'Live Alerts List' link on home page
  Then I should be able to view 'Live Alerts List' page but shouldn't be allow to edit

@SplitServer
@SingleServer
@UserManagement
  Scenario: User Manager - User Alerts Viewing Level (1)
  When Raised alert High Alarm on Booster Power, Low alarm on MB Motor Temperature, High Warning on Dry Pump Control,low warning on  Booster Control, Advisory on Seals Purge. 
  And Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And I added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
  And Clicked 'user permission' tab selected for 'Live Alerts List' application and kept 'View' checkbox and clicked Apply
  And clicked on Alerts
  Then Alerts tab details displayed
  When Click on the ‘Advisory’ checkbox
  Then The Advisory checkbox and all checkboxes below should be checked
  When clicked Apply
  Then 'Changes have been applied' text appears on Users tab.Changes should be saved while navigating to other groups.
  When clicked on home link
  Then should be navigated to Home page
  When clicked Device Explorer link
  Then should be navigated to Device Explorer page
  When clicked on add folder/ system icon
  And  Entered folder name and Clicked on Add button
  Then should be able to see Folder Added Successfully message
  When clicked OK button 
  Then should be able to see newly added folder
  When clicked Find Equipment
  And entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
  Then should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
  When  I clicked the header of the folder and choose Share Folder
  Then Share Folder Foldername pop-up should be displayed with available and granted list
  And  selected previously created Group 'test' 'user' and 'testuser' from available list and transfered it to granted list and pressed Apply
  And Changes should be saved
  When clicked OK button
  And clicked on Home Icon in top navigation menubar
  Then should be navigated to Home page
  When logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Live Alerts List' should be available to select
  When clicked 'Live Alerts List' link on home page
  Then Events of all selected severities for the user should be displayed.

@SplitServer
@SingleServer
@UserManagement
  Scenario: User Manager - Group Alerts Viewing Level (1)
  When Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And I added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
  And Clicked 'user permission' tab selected for 'Live Alerts List' application and kept 'View' checkbox and clicked Apply
  And clicked on Alerts
  Then Alerts tab details displayed
  When Click on the ‘Use Group’ radio button
  Then All checkboxes below should now be unchecked.
  When clicked Apply
  And Clicked on the Maintain Groups tab
  Then The Create Group form should show
  And New group created with group name 'Group1'
  When added newly created user 'test' 'user' 'testuser' in group
  Then 'Changes have been applied' text appears on Users tab.Changes should be saved while navigating to other groups.
  When Selected created group 'Group1'
  Then Group details should displayed  group name 'Group1' and Description 'Testing Group'
  When clicked on Alerts
  Then Alerts tab details displayed
  When Click on the ‘Advisory’ checkbox
  Then The Advisory checkbox and all checkboxes below should be checked
  When clicked Apply
  Then 'Changes have been applied' text appears on Users tab.Changes should be saved while navigating to other groups.
  When clicked on home link
  Then should be navigated to Home page
  When clicked Device Explorer link
  Then should be navigated to Device Explorer page
  When clicked on add folder/ system icon
  And  Entered folder name and Clicked on Add button
  Then should be able to see Folder Added Successfully message
  When clicked OK button 
  Then should be able to see newly added folder
  When clicked Find Equipment
  And Commissioned EZenith device with details  'eZenith', '50000'
  And Raised alert High Alarm on Booster Power, Low alarm on MB Motor Temperature, High Warning on Dry Pump Control,low warning on  Booster Control, Advisory on Seals Purge. 
  And entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
  Then should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
  When I clicked the header of the folder and choose Share Folder
  Then Share Folder Foldername pop-up should be displayed with available and granted list
  And I selected previously created Group 'Group1' from available list and transfered it to granted list and pressed Apply
  Then Changes should be saved
  When clicked OK button
  And clicked on Home Icon in top navigation menubar
  Then should be navigated to Home page
  When logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Live Alerts List' should be available to select
  When clicked 'Live Alerts List' link on home page
  Then I should be able to view 'Live Alerts List' page but shouldn't be allow to edit
  And Events of all selected severities for the user should be displayed.

#Prerequisite
#Advisory, Warning and Alarm alerts raised in SAM.
#Logon to Edcentra as Administrator.
@SplitServer
@SingleServer
@UserManagement
Scenario: User Manager - Group Alerts Viewing Level (2)
  When Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And I added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
  And Clicked 'user permission' tab selected for 'Live Alerts List' application and kept 'View' checkbox and clicked Apply
  And clicked on Alerts
  Then Alerts tab details displayed
  When Click on the ‘Use Group’ radio button
  Then All checkboxes below should now be unchecked.
  When applied changes
  And Clicked on the Maintain Groups tab
  Then The Create Group form should show
  And New group created with group name 'Group1'
  When added newly created user 'test' 'user' 'testuser' in group
  Then 'Changes have been applied' text appears on Users tab.Changes should be saved while navigating to other groups.
  When Selected created group 'Group1'
  Then Group details should displayed  group name 'Group1' and Description 'Testing Group'
  When clicked on Alerts
  Then Alerts tab details displayed
  When Click on the ‘Minor Warning’ checkbox
  Then except Advisory checkbox and all checkboxes below should be checked
  When clicked Apply
  Then 'Changes have been applied' text appears on Users tab.Changes should be saved while navigating to other groups.
  When clicked on home link
  Then should be navigated to Home page
  When clicked Device Explorer link
  Then should be navigated to Device Explorer page
  When clicked on add folder/ system icon
  And  Entered folder name and Clicked on Add button
  Then should be able to see Folder Added Successfully message
  When clicked OK button 
  Then should be able to see newly added folder
  When clicked Find Equipment
  And Commissioned EZenith device with details  'eZenith', '50000'
  And Raised alert High Alarm on Booster Power, Low alarm on MB Motor Temperature, High Warning on Dry Pump Control,low warning on  Booster Control, Advisory on Seals Purge. 
  And entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
  Then should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
  When I clicked the header of the folder and choose Share Folder
  Then Share Folder Foldername pop-up should be displayed with available and granted list
  And I selected previously created Group 'Group1' from available list and transfered it to granted list and pressed Apply
  Then Changes should be saved
  When clicked OK button
  And clicked on Home Icon in top navigation menubar
  Then should be navigated to Home page
  When logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Live Alerts List' should be available to select
  When clicked 'Live Alerts List' link on home page
  Then I should be able to view 'Live Alerts List' page but shouldn't be allow to edit
  And The alerts shown in Live Alerts List 'Booster Power (8)', 'MB MotorTemperature (9)', 'Dry Pump Control (11)', 'Booster Control (12)' for device 'NEW0001PM1' should be restricted accroding to the Alert Viewing Level set for the test.

#Prerequisite
#Advisory, Warning and Alarm alerts raised in Live alerts List.
#Logon to EdCentra as Administrator.
#Also, have a second user who has rights to view the "Live Alerts List" application.
@SplitServer
@SingleServer
@UserManagement
  Scenario: User Manager - User Alerts Viewing Level (2)
  #Given Raised alert High Alarm on Booster Power, Low alarm on MB Motor Temperature, High Warning on Dry Pump Control,low warning on  Booster Control, Advisory on Seals Purge. 
  When Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And I added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
  And Clicked 'user permission' tab selected for 'Live Alerts List' application and kept 'View' checkbox and clicked Apply
  And clicked on Alerts
  Then Alerts tab details displayed
  When Click on the ‘Minor Warning’ checkbox
  Then except Advisory checkbox and all checkboxes below should be checked
  When clicked Apply
  Then 'Changes have been applied' text appears on Users tab.Changes should be saved while navigating to other groups.
  When clicked on home link
  Then should be navigated to Home page
  When clicked Device Explorer link
  Then should be navigated to Device Explorer page
  When clicked on add folder/ system icon
  And  Entered folder name and Clicked on Add button
  Then should be able to see Folder Added Successfully message
  When clicked OK button 
  Then should be able to see newly added folder
  When clicked Find Equipment
  When entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
  Then should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
  When I clicked the header of the folder and choose Share Folder
  Then Share Folder Foldername pop-up should be displayed with available and granted list
  And  selected previously created Group 'test' 'user' and 'testuser' from available list and transfered it to granted list and pressed Apply
  And Changes should be saved
  When clicked OK button
  And clicked on Home Icon in top navigation menubar
  Then should be navigated to Home page
  When logged out
  And logon as the newly created user userName 'testuser' and password 'Test@123'
  Then Only 'Live Alerts List' should be available to select
  When clicked 'Live Alerts List' link on home page
  Then The alerts shown in Live Alerts List 'Booster Power (8)', 'MB MotorTemperature (9)', 'Dry Pump Control (11)', 'Booster Control (12)' for device 'NEW0001PM1' should be restricted accroding to the Alert Viewing Level set for the test.
 
@SplitServer
@SingleServer
@UserManagement
Scenario: User Manager - Review Users and Groups
  When Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And I added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form
  And Clicked 'user permission' tab selected for 'Dispatch Manager' application and kept 'Edit' checkbox and clicked Apply
  And Clicked Alerts and set Auto Alerts as Yes
  And Clicked on the Maintain Groups tab
  Then The Create Group form should show
  When created new group with group name 'Group1' and Description 'Testing Group'
  And Clicked 'group permission' tab selected for 'Dispatch Manager' application and kept 'Edit' checkbox and clicked Apply
  And Clicked Alerts and set Auto Alerts as Yes
  And Clicked on newly created Group link on left hand side on the Maintain Groups tab , Select group detail tab is displayed and added created user 'test' 'user' 'testuser'
  Then 'Changes have been applied' text appears on Users tab.Changes should be saved while navigating to other groups.
  When Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
  And Selected created user 'testuser' 'test' 'user'
  Then User details displayed with details 'testuser', 'user', 'testuser@atlascopco.com' on maintain user tab
  When Clicked users tab 
  Then selected group should be displayed 'Group1'
  When clicked on permission 
  Then In 'user permission' table 'Dispatch Manager' feature, 'Edit' checkbox should be selected
  When clicked on Alerts
  Then Auto Alerts should be selected in user permission
  When Clicked on the Maintain Groups tab
  And Selected created group 'Group1'
  Then Group details should displayed  group name 'Group1' and Description 'Testing Group'
  When clicked on permission 
  Then In 'group permission' table 'Dispatch Manager' feature, 'Edit' checkbox should be selected
  When clicked on Alerts
  Then Auto Alerts should be selected in user permission