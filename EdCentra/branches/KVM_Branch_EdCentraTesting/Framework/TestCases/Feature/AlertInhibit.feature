Feature: AlertInhibit
	Alerts can be inhibitted from paging
	This test verifies that inhibitting is functioning correctly

Background: 
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
Then I should be navigated to Home page

@ApplicationServer
@SingleServer
@RegressionPass1
@AlertInhibit
Scenario: Alert Inhibit - From Dispatch Manager
When I clicked Device Explorer link
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
When Launched Eissa and started simulator
And I commissioned device with following details 'eZenith', '50000'
And I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When navigated to SMTP tab under Page Settings tab
And login user 'administrator' created new SMTP page From as 'support@edwardsvacuum.com' destination with SMTP IP of '160.100.30.222', port number as '25' and To address as 'xyz@atlascopco.com'  
And navigated to Dispatch Manager->Scheduler.
When Clicked Week days check box, All Day Check box and selected previously created PageDestination'Admin, FabWorks (administrator) (SMTP)'.
Then clicked Apply
When Go to Dispatch Manager->Inhibit Settings tab and Click on the [New] button
Then A new Inhibit form should be visible and delete already created alert inhibit'Admin, FabWorks (administrator)'
When Search Equipment System'iXH DryPump' Using Type. And Select the Equipment'NEW0001PM1'
Then List of Parameters'All Parameters' should be displayed in parameter list
When Choose Parameters 'MB Temp (54)' 
Then A list of possible Alerts'MB body temperature sensor missing' shall be displayed in Alert List
When Click on an appropriate Alert'MB body temperature high' entry
And Mark Alert Level as All in Options section
And Mark This Alert will not Expire check box
And I Select Inhibit Pages Only
And I Enter Comment'Alert Inhibiting Test for MB body temperature high' and click Apply
Then Inhibit Settings should be saved and new entry 'Admin, FabWorks (administrator)' entry should be added on the top list
When I Create an alert which matches the inhibit just created Parameter '54          (MB Temp)' AlertType 'HighAlarm' AlertCode 'IDS_25_ALERT_54_HIGH (MB body temperature high)'
Then No page should arrive. The message 'Blocked AutoPager Exception ID' should be displayed in the Autopager console window.
When I Create an alert which does not match the inhibit just created Parameter '8          (Booster Power)' AlertType 'HighAlarm' AlertCode 'IDS_25_ALERT_1_0 (System configuration fault)'
Then A page should arrive
