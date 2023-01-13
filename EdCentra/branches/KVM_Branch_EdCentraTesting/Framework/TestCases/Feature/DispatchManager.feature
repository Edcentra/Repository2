Feature: DispatchManager

Background: 
Given opened EDCENTRA url in browser
When entered Username as 'administrator' and Password  as'toolkit' and I clicked login button
Then should be navigated to home page
When selected dispatch manager option under Configure drop down

@SplitServer
@SingleServer
@DispatchManager
Scenario: Dispatch Manager - General Settings
	When Configure the options on the Dispatch Manager General Settings screen 'Test Site'
	And Apply is used
	Then the settings should be saved

@SplitServer
@SingleServer
@DispatchManager
Scenario: Dispatch Manager - Configure SMTP Paging
    When navigated to SMTP tab under Page Settings tab
    And login user 'administrator' created new SMTP page From as 'support@edwardsvacuum.com' destination with SMTP IP of '160.100.30.222', port number as '25' and To address as 'shalu.gupta@edwardsvacuum.com'  
	And Clicked Test button
	Then A message 'A test message has been placed on the queue.' should be displayed. 

@SplitServer
@SingleServer
@DispatchManager
Scenario: Dispatch Manager - Configure Other Paging
   When navigated to SMTP tab under Page Settings tab
   And Clicked SMTP auth
   And login user 'administrator' created new SMTP Auth page From as 'support@edwardsvacuum.com' destination with SMTP IP of '160.100.30.222', port number as '25' and To address as 'shalu.gupta@edwardsvacuum.com'
   And navigated to General Settings page
   Then General settings page should display
   When Clicked on manual page
   Then 'Send a Page Message' pop-up will appear
   When Typed in Message 'Test Mail' and clicked Send button
   Then 'Page has been submitted' message should be displayed
   When navigate to SNPP tab Under Page Settings tab
   And Clicked SNPP
   And login user 'administrator' created new SNPP page with SNPP IP of '160.100.30.222', page number as '252'
   And Clicked Test button
   Then A message 'A test message has been placed on the queue.' should be displayed.
   When navigate to PageMate tab Under Page Settings tab
   And Clicked PageMate
   And login user 'administrator' created new PageMate page with page number as '1452'
   And Clicked Test button
   Then A message 'A test message has been placed on the queue.' should be displayed.
   When navigated to Derdack tab under Page Settings tab
   And Clicked Derdack
   And login user 'administrator' created new Derdack page with DerdackUserLogin of 'Test', Server SOAP URL as 'www.edwards.com' and Provider Name as 'atlascopco'
   And Clicked Test button
   Then A message 'A test message has been placed on the queue.' should be displayed.

@SingleServer
@ApplicationServer
@DispatchManager
 Scenario: Dispatch Manager - Pause and Resume
 Then General settings page should display
 When Press the Service status button	
 Then The service status should display accordingly action taken
 And Check the AAP console utility in the Taskbar and observe the text
 When Press the Service status button	
 Then The service status should display accordingly action taken
 And Check the AAP console utility in the Taskbar and observe the text
 
@DispatchManager
Scenario: Dispatch Manager - Send a manual page
When navigated to SMTP tab under Page Settings tab
And Clicked SMTP auth
And login user 'administrator' created new SMTP Auth page From as 'support@edwardsvacuum.com' destination with SMTP IP of '160.100.30.222', port number as '25' and To address as 'shalu.gupta@edwardsvacuum.com'
And Clicked to General Settings link
Then General Settings detail page should be displayed.
When Clicked on manual page.
Then 'Send a Page Message' pop-up will appear
When Selected Engineer and Select SMTP in Page Destination.
And Typed in Message 'Test Mail' and clicked Send button	
Then 'Page has been submitted' message should be displayed
#If SMTP destination is configured correctly , the message should be received to the destination e-mail address.


@SingleServer
@ApplicationServer
@DispatchManager
Scenario: Dispatch Manager - Configure Simple Scheduling
When I click Device Explorer link
Then I should navigated to Device Explorer page
When I clicked on add folder/system icon
And  I entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully Message
When I click OK button 
Then I should able to see newly added folder
When I click Find Equipment
And Deleted all equipments
And Launch Turbo simulator
And Select an equipmentName 'TURBO4002', equipmentType 'Turbo Pump' and iPPortNumber'4002'
And navigated to SMTP tab under Page Settings tab.
And Clicked SMTP auth
And login user 'administrator' created new SMTP Auth page From as 'support@edwardsvacuum.com' destination with SMTP IP of '160.100.30.222', port number as '25' and To address as 'shalu.gupta@edwardsvacuum.com'
And navigated to Dispatch Manager->Scheduler.
When Clicked Week days check box, All Day Check box and selected previously created PageDestination'Admin, FabWorks (administrator) (SMTPAuth)'.
And clicked Apply
Then The changes made in scheduling entry should be displayed and new PageDestination'Admin, FabWorks (administrator) (SMTPAuth)' entry added in the list.
When Created an alert'18' from a piece of equipment'4002'
Then The alert should arrive via the dispatch method selected.
When Cleared alert from '4002'
And Edited the previous schedule PageDestination'(SMTPAuth)' entry(Select the scheduler entry in the list to edit it) edit with  SMTP page From as 'support@edwardsvacuum.com' destination with SMTP IP of '160.100.30.222' and To address as 'shalu.gupta@external.atlascopco.com' and add an Alternative Destination'Admin, FabWorks (administrator) (SMTP)' with an After Minutes value of one
Then The scheduling PageDestination'Admin, FabWorks (administrator) (SMTP)' entry should be displayed with a blue pointer indicating that escalation has been established
When Create an alert '19' from a piece of equipment'4002' and wait for two minutes
Then The alert should arrive via the dispatch method selected. After a minute the alternative page destination should be used (escalated)
When Cleared alert from '4002'
And Edit the previous schedule entry and add a time (Between [____] And [____] (Leave blank for all day) which is two hours from now
Then The schedule'Admin, FabWorks (administrator) (SMTP)' entry should display with the Start and End columns set
When Created an alert'18' from a piece of equipment'4002'
Then The alert should NOT arrive via the dispatch method selected.
When Cleared alert from '4002'
Then the new schedule window isn't shown, click on New Button to create new schedule.New Schedule form will be displayed.

@SingleServer
@ApplicationServer
@DispatchManager
Scenario: Dispatch Manager - Send a test page
When Navigated to Page Destinations Tab
And login user 'testuser' created new SMTP page From as 'support@edwardsvacuum.com' destination with SMTP IP of '160.100.30.222', port number as '25' and To address as 'shalu.gupta@edwardsvacuum.com'  
Then The dispatcher details should display along with [Test], [Apply] and [Delete] buttons
When Clicked Test button
Then A message 'A test message has been placed on the queue.' should be displayed. 
And message ' Message [Test message] placed on queue for'dispayed in Autopager console with fields set to Subject as 'Subject: Test message' From as'From: support@edwardsvacuum.com' To as 'To: shalu.gupta@edwardsvacuum.com', content as 'Test message. Test message.' 

@SplitServer
@SingleServer
@DispatchManager
Scenario: Dispatch Manager - Configure Restricted (Equipment and Alerts) Scheduling
When I click Device Explorer link
Then I should navigated to Device Explorer page
When I clicked on add folder/system icon
And  I entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully Message
When I click OK button 
Then I should able to see newly added folder
When I click Find Equipment
And Deleted all equipments
And Launch Turbo simulator
When Select an equipmentName 'TURBO4002', equipmentType 'Turbo Pump' and iPPortNumber'4002'
And  Select an equipmentName 'TURBO4001', equipmentType 'Turbo Pump' and iPPortNumber'4001'
When navigated to SMTP tab under Page Settings tab.
And Clicked SMTP auth
And login user 'administrator' created new SMTP Auth page From as 'support@edwardsvacuum.com' destination with SMTP IP of '160.100.30.222', port number as '25' and To address as 'shalu.gupta@edwardsvacuum.com'
When navigated to Dispatch Manager->Scheduler.
And Clicked Week days check box, All Day Check box and selected previously created PageDestination'Admin, FabWorks (administrator) (SMTPAuth)'.
And clicked Apply
Then The Equipment tab should display
When Add a singlie piece of Equipment'TURBO4002', searching by either Equipment type or name or both in Find Equipment to add panel
Then The Equipment'TURBO4002' discovered and added should be displayed in Restrict Pages to this Equipment:(NB: If empty then all equipment is allowed) :
When Created an alert'18' from a piece of equipment'4002'
Then The alert should arrive via the dispatch method selected.
When Cleared alert from '4002'
And Created an alert '18' from a piece of equipment'4001'.
Then The alert should NOT arrive via the dispatch method selected.
When Cleared alert from '4001'
And Remove the Equipment'TURBO4002' restriction
Then The schedule screen should no longer report a certain number of Equipment'TURBO4002' are configured for restriction
When Click on Alert tab in Schedule detail screen
Then The Alert tab UI should display
When Add a single alert  Value'112' for a type of equipment Alert'Motor Overheat-Motor Temperature' to restrict to
Then The Alert'Motor Overheat-Motor Temperature' should be displayed in the 'Restrict Pages to these Alerts:(NB: If empty then all Alerts are allowed) list.
When Created an alert '18' from a piece of equipment'4002'.
Then The alert should arrive via the dispatch method selected.
When Cleared alert from '4002'
And Created an alert '19' from a piece of equipment'4002'.
Then The alert should NOT arrive via the dispatch method selected.
When Cleared alert from '4002'

@SplitServer
@SingleServer
@DispatchManager
Scenario: Dispatch Manager - Review General Settings, Destinations and Schedule
When Click on each mode: [General Settings]; [Page Destinations]; [Scheduler]; [Inhibit Settings]
Then The appropriate settings to be displayed