Feature: LiveAlertsList

Background: 
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
Then I should be navigated to Home page
When I clicked Device Explorer link
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments

@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts List - Live Alerts Count
Given Navigated to Live Alerts page
When cleared all previous alerts
When Launched Eissa and started Simulator and selected device type 'NEW0001PM1'
And I commissioned device with following details 'eZenith', '50000'
Given Raised alert High Alarm on Booster Power, Low alarm on MB Motor Temperature, High Warning on Dry Pump Control,low warning on  Booster Control, Advisory on Seals Purge 
When Navigated to Home page
And Selected Live Alerts List
And Clicked the Show Filter button.	
And In the System Name text box, type part or the entire name of a device 'NEW0001PM1' that is visible in the list of alerts in the main window.	
And Clicked Apply Filter
Then current live alerts should be shown
When count displayed is greater than '0'
Then Symbols should be enabled
When clicked on the Alarm Symbol in top right corner.(Assuming there are alerts of type Alarm present and Sysmbol is enabled)	
Then Live Alerts list screen should appear with all Major and Minor Alarm ie '2' 
And  Alerts Level filter set to Major Alarm and Minor Alarm.
When Clicked on the Warning Symbol in top right corner.(Assuming there are alerts of type Warning present and Sysmbol is enabled)	
Then Live Alerts list screen should appear with total count i.e. '2' 
And Alert Level filter set to Major Warning and Minor Warning.
When Clicked on the Advisory Symbol in top right corner
Then The Live Alerts list should display the Advisory ie.'1'
And Alert Level filter set to Advisory

@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts List - Filtering (Actual Status)
Given Navigated to Live Alerts page
When cleared all previous alerts
When Launched Eissa and started Simulator and selected device type 'NEW0001PM1'
And I commissioned device with following details 'eZenith', '50000'
And Raised Alert on parameters '8          (Booster Power)', '11          (Dry Pump Control)' 
Given I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001PM1' and clicked Add button
When Navigated to Home page
And Selected Live Alerts List
And clicked the Active Alert tab on Live Alert screen.	
Then The list alerts should only show alerts that are active – i.e. alerts that have been raised by the device but not yet ended by the device.
When Cleared Alert from simulator  '8          (Booster Power)'
And clicked the All Alerts tab on Live Alert screen.
Then the list of alerts should show alerts inactive – i.e. alerts that have been raised by the device and then ended by the device.

@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts List - Filtering (Alert Level)
Given Navigated to Live Alerts page
When cleared all previous alerts
And Commissioned device with following details  'Turbo Pump', '4003'
And Commissioned device with details  'Turbo Pump', '4002'
And Raised alert on turbo equipment with alert codes '18' & '19' on port '4003' & '4002'
When Navigated to Home page
And Selected Live Alerts List
Then The Created Alert should appear in Live Alerts List.
When Clicked the Show Filter button.
Then Filter pane displayed at top of View Alerts screen.
When Marked CheckBox Minor Alarm and Un-Mark all other Alert Level CheckBox
And Clicked Apply Filter
Then Only Alert with code '18' creataed in previous step should display
When Repeated the previous steps with severity levels ‘Major Warning’
And Clicked Apply Filter
Then Only Alert with code '19' creataed in previous step should display 

#Prerequisites
#Alerts in Live Alerts List from a range of sources including 'Equipment'.
@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts List - Filtering (Alert Source)
Given Navigated to Live Alerts page
When cleared all previous alerts
When Launched Eissa and started Simulator and selected device type 'NEW0001PM1'
And I commissioned device with following details 'eZenith', '50000'
And Navigated to Home page
And Raised Alert on parameters '8          (Booster Power)', '11          (Dry Pump Control)' 
Given Selected Live Alerts List
When Clicked the Show Filter button.	
Then The filter section should pop-up showing several fields that can be used to search for a particular alert.
When Deselected all the Alert Source checkboxes.
Then All checkboxes cleared.
When Selected Equipment checkbox
And Clicked Apply Filter
Then Only Alerts with the selected source should be displayed.
#When Repeated steps the previous steps with: ‘Predictive Diagnostics’, ‘Surge/Dip Analysis’, ‘Network’, ‘Parameter Threshold Monitoring’, ‘System Health Monitor’, ‘Status Monitor’, and ‘Manually Created’	
#Then Only Alerts with the selected source should be displayed.
#When Repeated the above tests in [All Alerts] (or [Active Alerts] if you're already on [All Alerts])
#Then Filtering to be applied to both [All Alerts] and [Active Alerts]

@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts List - Filtering (Assigned user)
Given Navigated to Live Alerts page
When cleared all previous alerts
And Clicked the Create Alert button.	
Then  A 'Create Alert' popup window should be displayed.
When Changed the Assigned User box to a user in the system.
Then The entry changes
When Entered 'Test Message' in the Default Alert Message textbox.	
And Clicked Create Alert button
Then The alert should be created 'The alert has been created' 
And displayed in the View Alerts screen with message'Test Message' and Severity 'Advisory'. 
When Clicked the Show Filter button.	
Then The filter section should pop-up.
When Selected the Assigned user drop down as the user 'administrator' you selected when created the test alert above.	
And Clicked Apply Filter	
Then The current Alerts screen should only show alerts for the user 'administrator' specified in the filter.

@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts List - Filtering (Dates)
Given Navigated to Live Alerts page
When cleared all previous alerts
And Clicked the Show Filter button.	
And Clicked the Create Alert button.	
Then  A 'Create Alert' popup window should be displayed.
When Changed the Assigned User box to a user in the system.
Then The entry changes
When Entered 'Test Message' in the Default Alert Message textbox.	
And Clicked Create Alert button
Then The alert should be created 'The alert has been created' 
And The filter section should pop-up showing several fields that can be used to search for a particular alert.
When Clicked the checkbox besides From and To Date.	
Then Two date entry boxes will be enabled. 
When The dates can be entered by text input (in the format yyyy-mm-dd) or by using the date selection boxes next to the date text boxes.
And Clicked the calender button besides From date.	
Then A datepicker calendar control will be displayed.
When Selected a date from the popup calendar window by clicking on a day number.	
Then The Start Date textbox is populated with the selected date from the calendar.
When Clicked the calender button besides To date.	
Then A datepicker calendar control will be displayed.
When Selected End date from the popup calendar window by clicking on a day number.	
Then The End Date textbox will be populated with selected end date.
And Clicked Apply Filter Only events between the selected dates are shown in the Alerts screen.

#(Note: The filter should work on both Active Alerts and All Alerts screen)
@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts List - Filtering (Description)
Given Navigated to Live Alerts page
When cleared all previous alerts
And Clicked the Create Alert button.	
Then  A 'Create Alert' popup window should be displayed.
When Changed the Assigned User box to a user in the system.
Then The entry changes
When Entered 'Test Message' in the Default Alert Message textbox.	
And Clicked Create Alert button
Then The alert should be created 'The alert has been created' 
When Clicked the Show Filter button.
Then Filter pane displayed at top of View Alerts screen.
When In the Message text box, type part or the entire description of an alert 'Test' that is visible in the list in the main window.
And Clicked Apply Filter
Then Only alerts with descriptions matching the string entered in the filter message 'Test' field should be displayed.

#Prerequisites
#Two or more items of equipment with logged alerts.
#(Note: The filter should work on both Active Alerts and All Alerts screen)
@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts List - Filtering (Equipment)
Given Navigated to Live Alerts page
When cleared all previous alerts
When Launched Eissa and started Simulator and selected device type 'NEW0001PM1'
And I commissioned device with following details 'eZenith', '50000'
Given Raised alert High Alarm on Booster Power, Low alarm on MB Motor Temperature, High Warning on Dry Pump Control,low warning on  Booster Control, Advisory on Seals Purge 
When Navigated to Home page
Given Selected Live Alerts List
When Clicked the Show Filter button.
And In the System Name text box, type part or the entire name of a device 'NEW0001PM1' that is visible in the list of alerts in the main window.	
And Clicked Apply Filter
Then The Current Alerts screen should only display alerts for the equipment 'NEW0001PM1' identified by the System Name string in the filter specification.

#(Note: The filter should work on both Active Alerts and All Alerts screen)
@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts List - Filtering (Maintenance Status)
Given Navigated to Live Alerts page
When cleared all previous alerts
And Clicked the Create Alert button.	
Then A 'Create Alert' popup window should be displayed.
When Changed the Maintenance status drop down to 'Unacknowledged'
And Entered 'Test Message Unacknowledged' in the Default Alert Message textbox.	
And Clicked Create Alert button
Then The alert should be created 'The alert has been created' 
And  Displayed in the View Alerts screen with message'Test Message Unacknowledged'
When Clicked the Show Filter button.
Then The filter section should pop-up.
When set an alert to Closed clicked the alert in the main view
And clicked maintenance status drop down, selected 'Closed' 
And clicked Apply button.
And Clicked and Hide Filter button
And Clicked the Create Alert button.	
Then  A 'Create Alert' popup window should be displayed.
When Changed the Maintenance status drop down to 'Assigned'
And Entered 'Test Message Assigned' in the Default Alert Message textbox.	
And Clicked Create Alert button
Then The alert should be created 'The alert has been created' 
And  Displayed in the View Alerts screen with message'Test Message Assigned'
When Clicked the Show Filter button.
Then The filter section should pop-up.
When set an alert to Closed clicked the alert in the main view
And clicked maintenance status drop down, selected 'Closed' 
And clicked Apply button.
And Clicked and Hide Filter button
And Clicked the Create Alert button.	
Then  A 'Create Alert' popup window should be displayed.
When Changed the Maintenance status drop down to 'Work in Progress'
And Entered 'Test Message Work in Progress' in the Default Alert Message textbox.	
And Clicked Create Alert button
Then The alert should be created 'The alert has been created' 
And  Displayed in the View Alerts screen with message'Test Message Work in Progress'
When Clicked the Show Filter button.
Then The filter section should pop-up.
When set an alert to Closed clicked the alert in the main view
And clicked maintenance status drop down, selected 'Closed' 
And clicked Apply button.
And Clicked and Hide Filter button
And Clicked the Create Alert button.	
Then  A 'Create Alert' popup window should be displayed.
When Changed the Maintenance status drop down to 'Pending'
And Entered 'Test Message Work Pending' in the Default Alert Message textbox.	
And Clicked Create Alert button
Then The alert should be created 'The alert has been created' 
And  Displayed in the View Alerts screen with message'Test Message Work Pending'
When Clicked the Show Filter button.
Then The filter section should pop-up.
When Clicked and Hide Filter button
And set an alert to Closed clicked the alert in the main view
And clicked maintenance status drop down, selected 'Closed' 
And clicked Apply button.
And In the filter, disable all of the ‘Maintenance Status’ checkboxes (apart from Closed which toggles with Unacknowledged) 
And Clicked Apply Filter	
#Then Only closed events will be displayed.

#Prerequisites : Raise advisory alert for Eissa equipment
#Make sure you have many no of alerts present in both All Alerts and Active Alerts tab.
@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts List - Hide/Reset Filter
Given Navigated to Live Alerts page
When cleared all previous alerts
When Launched Eissa and started Simulator and selected device type 'NEW0001PM1'
And I commissioned device with following details 'eZenith', '50000'
And Navigated to Home page
Given Raised alert High Alarm on Booster Power, Low alarm on MB Motor Temperature, High Warning on Dry Pump Control,low warning on  Booster Control, Advisory on Seals Purge 
And Selected Live Alerts List
When Clicked the Show Filter button.
Then Filter pane displayed at top of View Alerts screen.
When Selected few filter options through the check boxes or enter valid text in text boxes as shown in previous step 
And Clicked Apply Filter
Then Only Alerts matching with the applied filter option should be visible in the list.
When Clicked on Hide Filter button.	
Then The Filter panel should be hidden from the view. 
When Clicked the Show Filter button.
Then The filter panel should be displayed with last applied filter option marked.
When Clicked on Reset Filter button.	
Then All the filter option previously applied should be removed and Alert list should be reset.

@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts List - Create Manual Alert
Given Navigated to Live Alerts page
When cleared all previous alerts
When Launched Eissa and started Simulator and selected device type 'NEW0001PM1'
And I commissioned device with following details 'eZenith', '50000'
And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001PM1' and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When Navigated to Home page
Given Selected Live Alerts List
When Clicked the Show Filter button.
When Clicked the Create Alert button.	
Then  A 'Create Alert' popup window should be displayed.
When Entered a search string in the Search '001' box.
And Use the drop down list also to select a type of equipment 'All'. Make sure this type corresponds with the name you have entered in the first box.
When Clicked Find Equipment button.	
Then A list of results is then shown 'NEW0001'
When Selected one of the pieces of equipment.
When Entered 'Pump motor speed too high' in the Default Alert Message textbox.	
And Entered a comment 'Test comment'
And Clicked Create Alert button
Then The alert should be created 'The alert has been created' 
And The alert 'Pump motor speed too high' should appear at the top of the Alert list and will remain until closed.

@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts List - View/update alert detail and show history
Given I Added user with details 'testuser' 'Test@123' 'Test@123' 'Client Name' 'Edward' 'test' 'user' and 'testuser@atlascopco.com'
Given Navigated to Live Alerts page
When cleared all previous alerts
When Launched Eissa and started Simulator and selected device type 'NEW0001PM1'
And I commissioned device with following details 'eZenith', '50000'
And Navigated to Home page
And Selected Live Alerts List
When Clicked the Show Filter button.
When Clicked the Create Alert button.	
Then  A 'Create Alert' popup window should be displayed.
When Entered a search string in the Search '001' box.
And Use the drop down list also to select a type of equipment 'eZenith'. Make sure this type corresponds with the name you have entered in the first box.
When Clicked Find Equipment button.	
Then A list of results is then shown 'NEW0001'
When Selected one of the pieces of equipment.
When Entered 'Pump motor speed too high' in the Default Alert Message textbox.	
And Entered a comment 'Test comment'
And Clicked Create Alert button
Then The alert should be created 'The alert has been created' 
And Appeared in the list 'Pump motor speed too high'.
When Clicked on the previously created alert in the list. 
Then A new window will pop-up with 'Alert Details' tab selected on the screen.
When updated maintenance status to 'Pending' and assigned user 'testuser'. Also added comment 'test updated comment'. 
And Clicked close. 
Then Once closed open the same detail window again.	The Detail window should show updated detail in last step maintenance status as 'Pending', assigned user as 'testuser' and comment 'test updated comment'
When clicked on Alert History tab.	
Then User should able to see history of changes made on that alert with date-time, user and detail.

@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts List - Review Alerts and Alert Details 
Given Navigated to Live Alerts page
When cleared all previous alerts
When Launched Eissa and started Simulator and selected device type 'NEW0001PM1'
And I commissioned device with following details 'eZenith', '50000'
Given Raised alert High Alarm on Booster Power, Low alarm on MB Motor Temperature, High Warning on Dry Pump Control,low warning on  Booster Control, Advisory on Seals Purge 
When I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001PM1' and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When Navigated to Home page
And Selected Live Alerts List
When Clicked on an alert in the list	
Then Alert details to be displayed with msg 'System configuration fault', alert type as 'Major Alarm' , equipmenttype as'NEW0001PM1' 
When Clicked on tab: [Alert Details]
Then Appropriate settings to be displayed for Alert details tab
When Clickd on tab: [Alert History]
Then Appropriate settings to be displayed for Alert History details tab
When Clickd on tab: [Inhbit Settings]
Then Appropriate settings to be displayed for Inhibit Settings tab
When Selected another alert
Then Alert details to be displayed with msg 'System configuration fault', alert type as 'Minor Alarm' , equipmenttype as'NEW0001PM1' 

@SplitServer
@SingleServer
@LiveAlertsList
Scenario: Live Alerts Filter by message
Given Navigated to Live Alerts page
When cleared all previous alerts
When Launched Eissa and started Simulator and selected device type 'NEW0001PM1'
And I commissioned device with following details 'eZenith', '50000'
Given Raised alert High Alarm on Booster Power, Low alarm on MB Motor Temperature, High Warning on Dry Pump Control,low warning on  Booster Control, Advisory on Seals Purge 
When Navigated to Home page
And Selected Live Alerts List
Then current live alerts should be shown
When Clicked the Show Filter button.
Then The filter section should pop-up showing several fields that can be used to search for a particular alert.
When Entered Message 'System configuration fault' to filter for alerts from the list,
And Clicked Apply Filter	
Then Alerts matching to the message 'System configuration fault' filter will be displayed in the alerts list.