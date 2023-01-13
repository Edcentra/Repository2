@setup_feature
Feature: DeviceExplorerTests

Background: 
    Given I opened EDCENTRA app url 
	When I entered 'administrator' and 'toolkit' and clicked login button
	Then Change the User Preference 

@SplitServer
@SingleServer
@DeviceExplorer
Scenario: Device Explorer - Add Folder 
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder

@SplitServer
@SingleServer
@DeviceExplorer
Scenario: Device Explorer - Rename Folder
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
	When I click on added folder and rename
	Then I should be able to see Folder Renamed Successfully message and after clicking on Ok button, renamed folder should be displayed

@SplitServer
@SingleServer
@DeviceExplorer
Scenario: Device Explorer - Find, Add and Remove Systems
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
	And Launched Eissa and started simulator
	And I commissioned device with following details 'eZenith', '50000'
	And I selected Remove from Folder and clicked on OK button
	Then I should be able to see Equipment Removed Successfully message and Equipment should be removed from device

@SplitServer
@SingleServer
@DeviceExplorer
Scenario: Device Explorer - Delete folder
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
	When I clicked header of added folder and clicked Delete option
	Then Delete Folder window should appear to confirm your action
	When I clicked cancel button
	Then Delete Folder window closes and no action is taken
	When I clicked the header of the folder again and choose Delete
	Then Delete Folder window should appear to confirm your action
	When I clicked OK button in Delete window pop -up
	Then Folder Deleted Successfully is displayed and deleted Folder should no longer be visible

@SplitServer
@SingleServer
@DeviceExplorer	
Scenario: Device Explorer - Share Folder with groups & users
	When I Added user in group with details 'testuser' 'Test@123' 'Test@123' 'Client Name' 'Edward' 'test' 'user' and 'testuser@atlascopco.com' and group details 'testgroup' and 'testgroupdescription'
	And  I clicked on Home Icon in top navigation menubar
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
	When I clicked the header of the folder and this choose Share Folder
	Then Share Folder Foldername pop-up should be displayed with available and granted list.
	And I selected previously created Group ('testgroup') from available list and transfered it to granted list and pressed Apply.
	When I clicked OK button
	And I clicked the header of the folder and this choose Share Folder
	And I selected previously created Group 'test' 'user' and 'testuser' from available list and transfered it to granted list and pressed Apply.
	Then Changes should be saved.
	When I clicked OK button
	Then message pop- up should be closed
	When I clicked on Home Icon in top navigation menubar
	Then I should be navigated to Home page
	When I clicked on user and selected logout option 
	Then I should be navigated to login page
    When I entered 'testuser' and 'Test@123' and clicked login button
    Then I should be navigated to Home page
	When I clicked Device Explorer link
    Then I should be able to see added folder in previous steps 
	When I add new User with details 'testuser2' 'Test2@123' 'Test2@123' 'Client Name?' 'Atlas' 'test2' 'user2' and 'testuser2@atlascopco.com'
	And I clicked on Home Icon in top navigation menubar on UserPage
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked the header of the folder and this choose Share Folder
	Then Share Folder Foldername pop-up should be displayed with available and granted list.
	When I selected previously created Group 'test2' 'user2' and 'testuser2' from available list and transfered it to granted list and pressed Apply.
	Then Changes should be saved.
	When I clicked OK button
	Then message pop- up should be closed
	When I clicked on Home Icon in top navigation menubar
	Then I should be navigated to Home page
	When I clicked on user and selected logout option 
	Then I should be navigated to login page
    When I entered 'testuser2' and 'Test2@123' and clicked login button
    Then I should be navigated to Home page
	When I clicked Device Explorer link
    Then I should be able to see added folder in previous steps 

@SplitServer
@SingleServer
@DeviceExplorer
Scenario: Device Explorer - Device Explorer - SEV Pages
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
	And Launched Eissa and started simulator
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001PM1' device
	Then I should be navigated to SEV page
	And Status should be running and alarm should be enabled
	When I selected one of the options 'Booster Inverter State Serial Number' from the serial number drop-down
	Then The textbox next to the serial number drop-down should briefly say Retrieving then come back with the result. 
	When I clicked Parameters tab
	Then Parameters page should show with all of the parameters for the piece of equipment
	When I clicked the Guage tab
	Then Gauges page should show with all of the gauged parameters for the piece of equipment
	When I clicked the Graph tab
	Then should see a drop-down box with a list of parameters that you can add to the graph
	When I selected MB Temp (ºC) clicked the Add button
	Then I should be able to see Reset button
	When I clicked Reset button
	Then The graph should be removed and you will be left with the "Select Parameter" drop-down and graph plaeholder image.

@SplitServer
@SingleServer
@DeviceExplorer
Scenario: Create then Commission Decommission Equipment
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
	Given Turbo agent up and running
	When I clicked on Add button, selected create/commission and provided all required parameters 'Turbo Pump', "4001" and clicked on Add button
	Then device should be commissioned and appropriate message should be displayed
	When I clicked the header of the folder selected decommission 
	Then device should be decommissioned and appropriate message should be displayed

@SplitServer
@SingleServer	
@DeviceExplorer
Scenario Outline:User Permissions on Device Explorer having "View" and "Maintenance" permission
	Then I should be navigated to Home page
	When I set up user who has Device Explorer permission with details <Username>, <Password>, <Confirm Password>, <Memorable Question>, <Memorable Answer>, <First Name>, <Last Name>, <Email>, <Feature>, <column1>, <column2>
	And I clicked on Home Icon in top navigation menubar on UserPage
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
    When Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
    And I commissioned device with following details 'eZenith', '50000'
	And I clicked on Top Level link
	Then I should be navigated to Device Explorer page
	When I clicked on Top Level link
	When I clicked the header of the folder and this choose Share Folder
	Then Share Folder Foldername pop-up should be displayed with available and granted list.
	When I selected previously created user <First Name>, <Last Name> and <Username> from available list and transfered it to granted list and pressed Apply.
	Then Changes should be saved.
	When I clicked OK button
	Then message pop- up should be closed
	When I clicked on Home Icon in top navigation menubar
	Then I should be navigated to Home page
	When I clicked on user and selected logout option 
	Then I should be navigated to login page
    When entered <Username> and <Password> and clicked login button
    Then I should be navigated to Home page
	When I clicked Device Explorer link
    Then I should be able to see added folder in previous steps 
	When I clicked Find Equipment
	When I clicked again Equipment header 
	When Selected this option to turn Maintenance Mode on
	Then A message saying that maintenance is set to on is displayed and the item updates to show the maintenance icon
	When I clicked again Equipment header 
	When I selected this option to turn Maintenance Mode off
	Then A message saying that maintenance is set to off is displayed and the item updates to remove the maintenance icon.
	When I clicked on user and selected logout option 
	Then I should be navigated to login page
	When I entered 'administrator' and 'toolkit' and clicked login button
	Then I should be navigated to home page

 Examples: 
	| Username  | Password  | Confirm Password | Memorable Question |  Memorable Answer    | First Name | Last Name | Email | Feature | column1 | column2 |
	| Testuser1 | Test1@123 | Test1@123        | Client Name?       |   Edward             | test1      | user1     | testuser1@atlascopco.com | Device Explorer | View    | Maintenance|

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario Outline:User Permissions on Device Explorer having "View" and "Commission" permission
	Then I should be navigated to Home page
	When I set up user who has Device Explorer permission with details <Username>, <Password>, <Confirm Password>, <Memorable Question>, <Memorable Answer>, <First Name>, <Last Name>, <Email>, <Feature>, <column1>, <column2>
	And I clicked on Home Icon in top navigation menubar on UserPage
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
    When Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
    And I commissioned device with following details 'eZenith', '50000'
	And I clicked on Top Level link
	Then I should be navigated to Device Explorer page
	When I clicked the header of the folder and this choose Share Folder
	Then Share Folder Foldername pop-up should be displayed with available and granted list.
	When I selected previously created user <First Name>, <Last Name> and <Username> from available list and transfered it to granted list and pressed Apply.
	Then Changes should be saved.
	When I clicked OK button
	Then message pop- up should be closed
	When I clicked on Home Icon in top navigation menubar
	Then I should be navigated to Home page
	When I clicked on user and selected logout option 
	Then I should be navigated to login page
    When entered <Username> and <Password> and clicked login button
    Then I should be navigated to Home page
	When I clicked Device Explorer link
    Then I should be able to see added folder in previous steps 
	When I clicked Find Equipment
	Then I should get a context menu with Commission or Decommission options depending on the state of the system
	When I clicked on user and selected logout option 
	Then I should be navigated to login page
	When I entered 'administrator' and 'toolkit' and clicked login button
	Then I should be navigated to home page
	

 Examples: 
	| Username  | Password  | Confirm Password |Memorable Question |Memorable Answer | First Name | Last Name | Email | Feature | column1 | column2 |
	| Testuser2 | Test2@123 | Test2@123        | Client Name       |Edward           | test2      | user2     | testuser2@atlascopco.com | Device Explorer | View    | Commission |

@SplitServer
@SingleServer
@DeviceExplorer	
	Scenario Outline:User Permissions on Device Explorer having "View" and "Delete" permission
	Then I should be navigated to Home page
	When I set up user who has Device Explorer permission with details <Username>, <Password>, <Confirm Password>, <Memorable Question>, <Memorable Answer>, <First Name>, <Last Name>, <Email>, <Feature>, <column1>, <column2>
	When I clicked on Home Icon in top navigation menubar on UserPage
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
    When Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
    When I commissioned device with following details 'eZenith', '50000'
	#When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
	#Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When I clicked on Top Level link
	Then I should be navigated to Device Explorer page
	When I clicked the header of the folder and this choose Share Folder
	Then Share Folder Foldername pop-up should be displayed with available and granted list.
	When I selected previously created user <First Name>, <Last Name> and <Username> from available list and transfered it to granted list and pressed Apply.
	Then Changes should be saved.
	When I clicked OK button
	Then message pop- up should be closed
	When I clicked on Home Icon in top navigation menubar
	Then I should be navigated to Home page
	When I clicked on user and selected logout option 
	Then I should be navigated to login page
    When entered <Username> and <Password> and clicked login button
    Then I should be navigated to Home page
	When I clicked Device Explorer link
    Then I should be able to see added folder in previous steps 
	When I clicked Find Equipment
	Then A context menu opened with the option to Delete
	#When Hover over user name
	#Then A Logout link should be displayed on hover menu.
	#When clicked over it
	#And I entered 'administrator' and 'toolkit' and clicked login button
	#Then I should be navigated to home page

 Examples: 
	| Username  | Password  | Confirm Password  | Memorable Question | Memorable Answer | First Name | Last Name | Email | Feature | column1 | column2 |
	| Testuser3 | Test3@123 | Test3@123         | Client Name       | Edward           | test3      | user3     | testuser3@atlascopco.com | Device Explorer | View    | Delete     |

@SplitServer
@SingleServer
@DeviceExplorer
   Scenario: Device Explorer_ SEV Pages - Overview Tab - Device Status
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
   When Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
   And I commissioned device with following details 'eZenith', '50000'
   And I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
   Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
   When Selected added 'NEW0001PM1' device
   Then Overview tab opened displaying connected device 'NEW0001PM1'
   When Using EISSA, change the device status SEV Status field: 'Off'
   Then SEV of selected device displayed status selected in the EISSA is updated to 'Off' and displayed correctly in the Edcentra Device Explorer SEV
   When Using EISSA, change the device status SEV Status field: 'Stop'
   Then SEV of selected device displayed status selected in the EISSA is updated to 'Stopping' and displayed correctly in the Edcentra Device Explorer SEV
   When Using EISSA, change the device status SEV Status field: 'Stopping'
   Then SEV of selected device displayed status selected in the EISSA is updated to 'Stopping' and displayed correctly in the Edcentra Device Explorer SEV
   When Using EISSA, change the device status SEV Status field: 'Starting'
   Then SEV of selected device displayed status selected in the EISSA is updated to 'Starting' and displayed correctly in the Edcentra Device Explorer SEV
   When Using EISSA, change the device status SEV Status field: 'Running'
   Then SEV of selected device displayed status selected in the EISSA is updated to 'Running' and displayed correctly in the Edcentra Device Explorer SEV
   When Using EISSA, change the device status SEV Status field: 'Comms_Fail'
   Then SEV of selected device displayed status selected in the EISSA is updated to 'No Communication' and displayed correctly in the Edcentra Device Explorer SEV
   When Using EISSA, change the device status SEV Status field: 'Network_Fault'
   Then SEV of selected device displayed status selected in the EISSA is updated to 'Network Fault' and displayed correctly in the Edcentra Device Explorer SEV

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario Outline: Device Explorer_SEV Pages - Overview Tab - Serial Number Dropdown Control
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
    When Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
    And I commissioned device with following details 'eZenith', '50000'
    And I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
    Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
    When Selected added 'NEW0001PM1' device
	And Select the Serial Number dropdown control and verify that it contains a list of values
	Then Dropdown control contains a list of values'Dry Pump Inverter State Software Version' 'Gas Software' 'Pump IP Address'
	And  each value '<Parameter1>'  '<serialNum1>'  '<Parameter2>' '<serialNum2>' '<Parameter3>' '<serialNum3>' '<Parameter4>' '<serialNum4>' with associate serial number  data is displayed in the serial number field
	
	Examples: 
	| Parameter1                            | serialNum1                                        | Parameter2      | serialNum2                    | Parameter3    | serialNum3               |
	| Dry Pump Inverter State Serial Number | Test:Dry Pump Inverter State Serial Number0 186,4 | Pump IP Address | Test:Pump IP Address0 109,194 | Pump Hardware | Test:Pump Hardware0 1,10 |

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario: Device Explorer_SEV Pages -Overview Tab - Default Parameters
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
	And Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001PM1' device
	Then Overview tab opened displaying connected device 'NEW0001PM1'
	When selected parameter  '11          (Dry Pump Control)'
	And each default parameter displayed on the Overview tab, using EISSA, change value to '2'
	Then this updated 'Dry Pump Control' parameters status to 'Stopping'
	When each default parameter displayed on the Overview tab, using EISSA, change value to '1'
	Then this updated 'Dry Pump Control' parameters status to 'Starting'
	When each default parameter displayed on the Overview tab, using EISSA, change value to '4'
	Then this updated 'Dry Pump Control' parameters status to 'Running'
	When each default parameter displayed on the Overview tab, using EISSA, change value to '5'
	Then this updated 'Dry Pump Control' parameters status to 'Unknown' 

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario: Device Explorer_SEV Pages - Overview Tab - Advisory Alerts
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
	And Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001PM1' device
	Then Overview tab opened displaying connected device 'NEW0001PM1'
	When In EISSA, create an advisory alert  
	Then verify that the display in the device overview updates to show the correct number of alerts
	And Then adivisory alert is created, the Overview alert count icon object and the tab background change to lilac

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario Outline: Device Explorer_SEV Pages -Overview Tab - AtlasMk4 device
	Then I should be navigated to Home page
	When I Change Temperature User Preference.
	And I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
    When I clicked Find Equipment
	And deleted all equipments
	And Launched Eissa, started simulator and selected equipment type 'StandaloneAtlasMk4' and device type 'NEW0001AC' 
	And I commissioned device with following details 'Atlas Mk4 Abatement', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001AC' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001AC' device
	Then Overview tab opened displaying connected device 'NEW0001AC'
	When Using EISSA, change the device status SEV Status field: 'Stop'
	Then SEV of selected device displayed status selected in the EISSA is updated to 'Stop' and displayed correctly in the Edcentra Device Explorer SEV
	When Using EISSA, change the device status SEV Status field: 'Running'
	Then SEV of selected device displayed status selected in the EISSA is updated to 'Running' and displayed correctly in the Edcentra Device Explorer SEV
	When I stop the EISSA Stimulator
	Then SEV of selected device displayed status selected in the EISSA is updated to 'No Communication' and displayed correctly in the Edcentra Device Explorer SEV
	When I start the EISSA Stimulator with device 'NEW0001AC'
	Then SEV of selected device displayed status selected in the EISSA is updated to 'Running' and displayed correctly in the Edcentra Device Explorer SEV
	When each default parameter displayed on the Overview tab, using EISSA, change '145          (TE406 Combustor Temperature)' value to '890'
	Then this has updated '145          (TE406 Combustor Temperature)' parameters status to '616.85 ºC'
	When I Create a new profile as 'LoggingTest' and equipment type as 'Atlas Mk4 Abatement'
	And I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>' '<Parameter1>' '<TimeIntervalforNormal1>' '<TimeIntervalforAlert1>' '<TimeIntervalforDelta1>'.Then Click Apply.
	Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
	When navigated to Device Explorer-> Overview tab
	And Create an 'HighWarning' Alert for a parameter '148          (TE509 Quench Temperature)' with alert code 'IDS_16406_ALERT_14813 (TE509 Quench Temperature Error)'
	And Create an 'HighAlarm' Alert for a parameter '145          (TE406 Combustor Temperature)' with alert code 'IDS_16406_ALERT_14513 (TE406 Combustor Temperature Error)'
	Then The SEV updates to show the warning alert as '1' and alarm alert as '1' in the overview tab
	And Alarm Alert is created, the SEV alert count object and tab background colour changes to RED
	When I Clear the alert for the parameter '148          (TE509 Quench Temperature)'
	And I Clear the alert for the parameter '145          (TE406 Combustor Temperature)'
	Then The SEV updates to show the warning alert as '0' and alarm alert as '0' in the overview tab

Examples: 
| Parameter                        | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta | Parameter1                    | TimeIntervalforNormal1 | TimeIntervalforAlert1 | TimeIntervalforDelta1 |
| TE406 Combustor Temperature (ºC) | 10 Seconds            | 10 Seconds           | 1                    | TE509 Quench Temperature (ºC) | 10 Seconds             | 10 Seconds            | 1                     |

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario Outline: Device Explorer_SEV Pages -Overview Tab - EUVHRS device
	Then I should be navigated to Home page
	When I Change Temperature User Preference.
	And I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
    When I clicked Find Equipment
	And deleted all equipments
	And Launched Eissa, started simulator and selected equipment type 'EUVWithHRS' and device type 'NEW0001FC' 
	And I commissioned device with following details 'Hydrogen Recovery System', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001FC' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001FC' device
	Then Overview tab opened displaying connected device 'NEW0001FC'
	When Using EISSA, change the device status SEV Status field: 'Off'
	Then SEV of selected device displayed status selected in the EISSA is updated to 'Initialisation' and displayed correctly in the Edcentra Device Explorer SEV
	When Using EISSA, change the device status SEV Status field: 'Running'
	Then SEV of selected device displayed status selected in the EISSA is updated to 'Stopped' and displayed correctly in the Edcentra Device Explorer SEV
	When I stop the EISSA Stimulator
	Then SEV of selected device displayed status selected in the EISSA is updated to 'No Communication' and displayed correctly in the Edcentra Device Explorer SEV
	When I start the EISSA Stimulator with device 'NEW0001FC'
	Then SEV of selected device displayed status selected in the EISSA is updated to 'Stopped' and displayed correctly in the Edcentra Device Explorer SEV
	When each default parameter displayed on the Overview tab, using EISSA, change '200          (TC30 Water Tank Temperature)' value to '290'
	Then this has updated '200          (TC30 Water Tank Temperature)' parameters status to '16.85 ºC'
	When I Create a new profile as 'LoggingTest' and equipment type as 'Hydrogen Recovery System'
	And I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>' '<Parameter1>' '<TimeIntervalforNormal1>' '<TimeIntervalforAlert1>' '<TimeIntervalforDelta1>'.Then Click Apply.
	Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
	When navigated to Device Explorer-> Overview tab
	And Create an 'HighWarning' Alert for a parameter '200          (TC30 Water Tank Temperature)' with alert code 'IDS_17003_ALERT_49 (Low tank water temperature)'
	And Create an 'HighAlarm' Alert for a parameter '167          (FM3 Product Gas Flow)' with alert code 'IDS_17003_ALERT_42 (Low product flow)'
	Then The SEV updates to show the warning alert as '1' and alarm alert as '1' in the overview tab
	And Alarm Alert is created, the SEV alert count object and tab background colour changes to RED
	When I Clear the alert for the parameter '200          (TC30 Water Tank Temperature)'
	And I Clear the alert for the parameter '167          (FM3 Product Gas Flow)'
	Then The SEV updates to show the warning alert as '0' and alarm alert as '0' in the overview tab

Examples: 
| Parameter                        | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta | Parameter1                   | TimeIntervalforNormal1 | TimeIntervalforAlert1 | TimeIntervalforDelta1 |
| TC30 Water Tank Temperature (ºC) | 10 Seconds            | 10 Seconds           | 1                    | DP3 Equivalent Dewpoint (ºC) | 10 Seconds             | 10 Seconds            | 1                     |

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario Outline: Device Explorer_SEV Pages -Overview Tab - EUVH2D device
	Then I should be navigated to Home page
	When I Change Temperature User Preference.
	And I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
    When I clicked Find Equipment
	And deleted all equipments
	And Launched Eissa, started simulator and selected equipment type 'EUVWithH2D' and device type 'NEW0001FC' 
	And I commissioned device with following details 'Hydrogen Dilution System', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001FC' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001FC' device
	Then Overview tab opened displaying connected device 'NEW0001FC'
	When Using EISSA, change the device status SEV Status field: 'Stop'
	# When Using EISSA, change the device status SEV Status field: 'Stopping'
	#When Using EISSA, change the device status SEV Status field: 'Stop'
	Then SEV of selected device displayed status selected in the EISSA is updated to 'Stopped' and displayed correctly in the Edcentra Device Explorer SEV
	When Using EISSA, change the device status SEV Status field: 'Running'
	Then SEV of selected device displayed status selected in the EISSA is updated to 'Start-up' and displayed correctly in the Edcentra Device Explorer SEV
	When I stop the EISSA Stimulator
	Then SEV of selected device displayed status selected in the EISSA is updated to 'No Communication' and displayed correctly in the Edcentra Device Explorer SEV
	When I start the EISSA Stimulator with device 'NEW0001FC'
	Then SEV of selected device displayed status selected in the EISSA is updated to 'Start-up' and displayed correctly in the Edcentra Device Explorer SEV
	When each default parameter displayed on the Overview tab, using EISSA, change '111          (M-GB301 Primary Fan Bearing Temperature)' value to '890'
	Then this has updated '111          (M-GB301 Primary Fan Bearing Temperature)' parameters status to '616.85 ºC'
	When I Create a new profile as 'LoggingTest' and equipment type as 'Hydrogen Dilution System'
	And I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>' '<Parameter1>' '<TimeIntervalforNormal1>' '<TimeIntervalforAlert1>' '<TimeIntervalforDelta1>'.Then Click Apply.
	Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
	When navigated to Device Explorer-> Overview tab
	And Create an 'HighWarning' Alert for a parameter '54          (High Exhaust Temperature)' with alert code 'IDS_17004_ALERT_10 (High Exhaust Temperature)'
	And Create an 'HighAlarm' Alert for a parameter '55          (High Process Inlet Temperature)' with alert code 'IDS_17004_ALERT_11 (High Process Inlet Temperature)'
	Then The SEV updates to show the warning alert as '1' and alarm alert as '1' in the overview tab
	And Alarm Alert is created, the SEV alert count object and tab background colour changes to RED
	When I Clear the alert for the parameter '54          (High Exhaust Temperature)'
	And I Clear the alert for the parameter '55          (High Process Inlet Temperature)'
	Then The SEV updates to show the warning alert as '0' and alarm alert as '0' in the overview tab

Examples: 
| Parameter                                    | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta | Parameter1                          | TimeIntervalforNormal1 | TimeIntervalforAlert1 | TimeIntervalforDelta1 |
| M-GB301 Primary Fan Bearing Temperature (ºC) | 10 Seconds            | 10 Seconds           | 1                    | CS-FT388 Inlet Air Flow Rate (m3/s) | 10 Seconds             | 10 Seconds            | 1                     |

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario Outline: Device Explorer_SEV Pages -Overview Tab - CTI device
	Then I should be navigated to Home page
	When I Change Temperature User Preference.
	And I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
    When I clicked Find Equipment
	And deleted all equipments
	And Launched Eissa, started simulator and selected equipment type 'CTiEquipment' and device type '<DeviceName>' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'<DeviceName>' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added '<DeviceName>' device
	Then Overview tab opened displaying connected device '<DeviceName>'
	When Using EISSA, change the device status SEV Status field: 'Off'
	Then SEV of selected device displayed status selected in the EISSA is updated to '<StatusOff>' and displayed correctly in the Edcentra Device Explorer SEV
	When Using EISSA, change the device status SEV Status field: 'Running'
	Then SEV of selected device displayed status selected in the EISSA is updated to '<StatusON>' and displayed correctly in the Edcentra Device Explorer SEV
	When I stop the EISSA Stimulator
	Then SEV of selected device displayed status selected in the EISSA is updated to 'No Communication' and displayed correctly in the Edcentra Device Explorer SEV
	When I start the EISSA Stimulator with device '<DeviceName>'
	Then SEV of selected device displayed status selected in the EISSA is updated to '<StatusON>' and displayed correctly in the Edcentra Device Explorer SEV
	When I selected one of the options 'Serial Number' from the serial number dropdown
	Then The textbox next to the serial number drop-down should display "Test:Serial Number0 1,1". 
	When Create an 'HighWarning' Alert for a parameter '<WarningParameter>' with alert code '<AlertWarningCode>'
	And Create an 'HighAlarm' Alert for a parameter '<AlertParameter>' with alert code '<AlertCode>'
	Then The SEV updates to show the warning alert as '1' and alarm alert as '1' in the overview tab
	And Alarm Alert is created, the SEV alert count object and tab background colour changes to RED
	When I Clear the alert for the parameter '<WarningParameter>'
	And I Clear the alert for the parameter '<AlertParameter>'
	Then The SEV updates to show the warning alert as '0' and alarm alert as '0' in the overview tab
	When I Create a new profile as 'LoggingTest' and equipment type as '<EquipmentType>'
	And I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>' '<Parameter1>' '<TimeIntervalforNormal1>' '<TimeIntervalforAlert1>' '<TimeIntervalforDelta1>'.Then Click Apply.
	Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
	
Examples: 
| TestCaseName | DeviceName | StatusON | StatusOff | EquipmentType  | Parameter              | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta | Parameter1               | TimeIntervalforNormal1 | TimeIntervalforAlert1 | TimeIntervalforDelta1 | WarningParameter               | AlertWarningCode                    | AlertParameter                   | AlertCode                           |
| CryoPump     | NEW0001PM0 | On       | Off       | CTi Cryopump   | 1st Stage Temp (ºC)    | 10 Seconds            | 10 Seconds           | 1                    | 2nd Stage Temp (ºC)      | 10 Seconds             | 10 Seconds            | 1                     | 5          (1st Stage Temp)    | IDS_18019_ALERT_18 (No Cryopower 1) | 6          (2nd Stage Temp)      | IDS_18019_ALERT_19 (No Cryopower 2) |
| Compressor   | NEW0001PM1 | On       | Off       | CTi Compressor | Diff Pressure (Pa)     | 10 Seconds            | 10 Seconds           | 1                    | He Avail Total (m3/s)    | 10 Seconds             | 10 Seconds            | 1                     | 1          (Compressor Status) | IDS_18020_ALERT_0 (No alerts)       | 2          (Motor Status)        | IDS_18020_ALERT_0 (No alerts)       |
| Controller   | NEW0001PM2 | Online   | Offline   | CTI Controller | Avg Diff Pressure (Pa) | 10 Seconds            | 10 Seconds           | 1                    | Avg Supply Pressure (Pa) | 10 Seconds             | 10 Seconds            | 1                     | 1          (Controller Status) | IDS_18021_ALERT_0 (TODO)            | 2          (Avg Supply Pressure) | IDS_18021_ALERT_0 (TODO)            |
| WaterPump    | NEW0001PM3 | On       | Off       | CTi Waterpump  | Delay start            | 10 Seconds            | 10 Seconds           | 1                    | Elapsed Time             | 10 Seconds             | 10 Seconds            | 1                     | 1          (Pump Status)       | IDS_18022_ALERT_18 (No Cryopower 1) | 2          (Motor Status)        | IDS_18022_ALERT_19 (No Cryopower 2) |

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario: Device Explorer_SEV Pages - Overview Tab - Warning Alerts
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
	And Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001PM1' device
	Then Overview tab opened displaying connected device 'NEW0001PM1'
    When In EISSA, create Low Warning Alert 
	Then Overview alert icon shows correct alert type and number
	And When a Low Warning alert is created, the Overview alert count object and tab background colour change to yellow
	When Repeat this test for both high and low warning alterts.
	Then SEV updates correctly for both high and low warning alerts.

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario: Device Explorer_SEV pages - Overview Tab - Alarm Alerts
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
	When Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
	When I commissioned device with following details 'eZenith', '50000'
	When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001PM1' device
	Then Overview tab opened displaying connected device 'NEW0001PM1'
	When Create an low Alarm Alert on a device 
	Then The SEV updates to show the correct number of alerts and alert type
	And Alarm Alert is created, the SEV alert count object and tab background colour changes to RED
	When Repeat this test on both low and high alarm alerts
	Then SEV updates correctly for both high and low alarm alerts

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario: Device Explorer_SEV Pages - Overview Tab - Alert Icons
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
	And Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001PM1' device
	Then Overview tab opened displaying connected device 'NEW0001PM1'
	When Raised alert High Alarm on Booster Power, Low alarm on MB Motor Temperature, High Warning on Dry Pump Control,low warning on  Booster Control, Advisory on Seals Purge 
	Then The alert icons display the correct number of alerts of each type
	When Update the number and type of alerts of each type and verify that the alert icons correctly dislplay the updated numbers
	Then The alert icons correctly dislplay the updated numbers
	When Click each alert icon and verify that when one ore more alerts exist, the alert list is opened
	Then When one ore more alerts exist and an alert icon is clicked, the alert list is opened
	When Ensure that the alert colour updates according to the highest existing alert type
	Then The alert colour updates according to the highest existing alert type

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario: Device Explorer_SEV Pages - Parameters Tab - iXH device
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
    When I clicked Find Equipment
	And Launched Eissa and started simulator
	And I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001PM1' device
	When Select an iXH device and open it in Single Equipement View and then selecte the Parameters tab
	Then Device parameters displayed in SEV Parameters tab
	When each default parameter displayed on the Overview tab, using EISSA, change '54          (MB Temp)' value to '2'
	Then this has updated '54          (MB Temp)' parameters status to '2 K'
	When each default parameter displayed on the Overview tab, using EISSA, change '39          (Exhaust Pressure)' value to '5'
	Then this has updated '39          (Exhaust Pressure)' parameters status to '5 Pa'
	When each default parameter displayed on the Overview tab, using EISSA, change '4          (Dry Pump Power)' value to '4'
	Then this has updated '4          (Dry Pump Power)' parameters status to '4 W'
	When each default parameter displayed on the Overview tab, using EISSA, change '3          (Dry Pump Current)' value to '2'
	Then this has updated '3          (Dry Pump Current)' parameters status to '2 A'
	When each default parameter displayed on the Overview tab, using EISSA, change '174          (MB Inverter Speed)' value to '3'
	Then this has updated '174          (MB Inverter Speed)' parameters status to '3 Hz'


@SplitServer
@SingleServer
@DeviceExplorer
	Scenario: Device Explorer_SEV Pages - Parameters Tab - FC device
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
    When I clicked Find Equipment
	When Launched Eissa, started simulator and selected device type 'NEW0001FC' 
	When I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001FC' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Select a Facilities Controller device and view its parameters in Single Eqiupment View
	Then Selected device parameters displayed
	When each default parameter displayed on the Overview tab, using EISSA, change '75          (Abatement Green Mode)' value to '0'
	Then this has updated '75          (Abatement Green Mode)' parameters status to 'Off'
	When each default parameter displayed on the Overview tab, using EISSA, change '50          (Inlet Thermocouple 1)' value to '2'
	Then this has updated '50          (Inlet Thermocouple 1)' parameters status to '2 K'
	When each default parameter displayed on the Overview tab, using EISSA, change '34          (Active Gauge Pressure)' value to '2'
	Then this has updated '34          (Active Gauge Pressure)' parameters status to '2 Pa'
	When each default parameter displayed on the Overview tab, using EISSA, change '64          (HAPS 1 Status)' value to '2'
	Then this has updated '64          (HAPS 1 Status)' parameters status to '2'

@SplitServer
@SingleServer
@DeviceExplorer	
	Scenario: Device Explorer_SEV Pages - Parameters Tab - Atlas Abatement device
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
	And Launched Eissa, started simulator and selected device type 'NEW0001AC1' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001AC1' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001AC1' device
	Then Overview tab opened displaying connected device 'NEW0001AC1'
	When Navigated to 'Parameters' tab
	Then SEV Parameters tab opens and displays selected device parameters
	When each default parameter displayed on the Overview tab, using EISSA, change '35          (TE406 Combustor Temperature)' value to '2'
	Then this has updated '35          (TE406 Combustor Temperature)' parameters status to '2 K'
	When each default parameter displayed on the Overview tab, using EISSA, change '40          (FT615 Quench Water Flow)' value to '2'
	Then this has updated '40          (FT615 Quench Water Flow)' parameters status to '2 m3/s'
	When each default parameter displayed on the Overview tab, using EISSA, change '8          (EMO)' value to '0'
	Then this has updated '8          (EMO)' parameters status to 'Off'
	When each default parameter displayed on the Overview tab, using EISSA, change '5          (Number of Inlets)' value to '3'
	Then this has updated '5          (Number of Inlets)' parameters status to '3'

@SplitServer
@SingleServer
@DeviceExplorer	
	Scenario: Device Explorer_SEV Pages - Guages Tab - iXH Device
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
	And Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001PM1' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001PM1' device
	Then Overview tab opened displaying connected device 'NEW0001PM1'
	When Navigated to 'Guages' tab
	Then Guages tab opened displaying selected device parameters
	When each default parameter displayed on the Overview tab, using EISSA, change '54          (MB Temp)' value to '360'
	Then The guages needle 'translate(75,75) rotate(-109.72499999999997 0 0)'and number displays update to show the correct value '360' set in EISSA for parameter 'MB Temp'
	When each default parameter displayed on the Overview tab, using EISSA, change '35          (Pump N2 Flow)' value to '0.0030'
	Then The guages needle 'translate(75,75) rotate(-40.00000000000001 0 0)'and number displays update to show the correct value '0.0030' set in EISSA for parameter 'Pump N2 Flow'
	When each default parameter displayed on the Overview tab, using EISSA, change '4          (Dry Pump Power)' value to '6000'
	Then The guages needle 'translate(75,75) rotate(-90 0 0)'and number displays update to show the correct value '6000' set in EISSA for parameter 'Dry Pump Power'

@SplitServer
@SingleServer
@DeviceExplorer	
	Scenario: Device Explorer_SEV Pages - Guages Tab - FC Device
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
	And Launched Eissa, started simulator and selected device type 'NEW0001FC' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001FC' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001FC' device
	Then Overview tab opened displaying connected device 'NEW0001FC'
	When Navigated to 'Guages' tab
	Then Guages tab opened displaying patameters of selected device
	When each default parameter displayed on the Overview tab, using EISSA, change '50          (Inlet Thermocouple 1)' value to '700'
	Then The guages needle 'translate(75,75) rotate(-111.94500000000001 0 0)'and number displays update to show the correct value '700' set in EISSA for parameter 'Inlet Thermocouple 1'
	When each default parameter displayed on the Overview tab, using EISSA, change '35          (PCW In Pressure System)' value to '600000'
	Then The guages needle 'translate(75,75) rotate(-66.92307692307692 0 0)'and number displays update to show the correct value '600000' set in EISSA for parameter 'PCW In Pressure System'
	When each default parameter displayed on the Overview tab, using EISSA, change '30          (FT460 Pump Frame N2 Flow)' value to '0.0060'
	Then The guages needle 'translate(75,75) rotate(-23.999991359999658 0 0)'and number displays update to show the correct value '0.0060' set in EISSA for parameter 'FT460 Pump Frame N2 Flow'

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario:  Device Explorer_SEV Pages - Guages Tab - Atlas Abatement Device
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
	And Launched Eissa, started simulator and selected device type 'NEW0001AC1' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001AC1' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001AC1' device
	Then Overview tab opened displaying connected device 'NEW0001AC1'
	When Navigated to 'Guages' tab
	Then Guages tab opened displaying the parameters for the selected device
	When each default parameter displayed on the Overview tab, using EISSA, change '35          (TE406 Combustor Temperature)' value to '1100'
	Then The guages needle 'translate(75,75) rotate(-41.556 0 0)'and number displays update to show the correct value '1100' set in EISSA for parameter 'TE406 Combustor Temperature'
	When each default parameter displayed on the Overview tab, using EISSA, change '39          (PT306 System Pressure)' value to '1000'
#	Then The guages needle 'translate(75,75) rotate(-95.99999999999999 0 0)'and number displays update to show the correct value '1000' set in EISSA for parameter 'PT306 System Pressure'
	When each default parameter displayed on the Overview tab, using EISSA, change '62          (GE703 Oxygen Concentration)' value to '80'
#	Then The guages needle 'translate(75,75) rotate(-5.088887490341627e-14 0 0)'and number displays update to show the correct value '80.0' set in EISSA for parameter 'GE703 Oxygen Concentration'

@SplitServer
@SingleServer
@DeviceExplorer
Scenario: Device Explorer_SEV Pages - Graph Tab - Atlas Abatement Device
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
	And Launched Eissa, started simulator and selected device type 'NEW0001AC1' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001AC1' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001AC1' device
	Then Overview tab opened displaying connected device 'NEW0001AC1'
	When Navigated to 'Graph' tab
	Then verify that the dropdown control contains the device parameters for device 'NEW0001AC1' 
	And Select Parameter'TE909 PCW Return Temperature (K)' dropdown control contains the device parameters
	When Select a parameter'PT121 Nozzle Pressure 1 (Pa)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	Then The parameter'PT121 Nozzle Pressure 1 (Pa) (50)' is added to the graph and displayed correctly as '1.00 Pa'
	When I clicked reset Graph
	And each default parameter displayed on the Overview tab, using EISSA, change '50          (PT121 Nozzle Pressure 1)' value to '20'
	And Select a parameter'PT121 Nozzle Pressure 1 (Pa)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	Then The parameter'PT121 Nozzle Pressure 1 (Pa) (50)' is added to the graph and displayed correctly as '20.00 Pa'

@SplitServer
@SingleServer
@DeviceExplorer	
	Scenario: Device Explorer_SEV Pages - Graph Tab - FC Device
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
	And Launched Eissa, started simulator and selected device type 'NEW0001FC' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001FC' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001FC' device
	Then Overview tab opened displaying connected device 'NEW0001FC'
	When Navigated to 'Graph' tab	
	Then verify that the dropdown control contains the device parameters for device 'NEW0001FC' 
	And Select Parameter'Inlet Thermocouple 6 (K)' dropdown control contains the device parameters
	When Select a parameter'FC4072 N2 Dilution Flow 2 (m3/s)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	Then The parameter'FC4072 N2 Dilution Flow 2 (m3/s) (38)' is added to the graph and displayed correctly as '1.00 m3/s'
	When I clicked reset Graph
	And each default parameter displayed on the Overview tab, using EISSA, change '38          (FC4072 N2 Dilution Flow 2)' value to '20'
	And Select a parameter'FC4072 N2 Dilution Flow 2 (m3/s)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	Then The parameter'FC4072 N2 Dilution Flow 2 (m3/s) (38)' is added to the graph and displayed correctly as '20.00 m3/s'

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario: Device Explorer_SEV Pages - GraphTab - iXH Device
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
	And Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001PM1' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001PM1' device
	Then Overview tab opened displaying connected device 'NEW0001PM1'
	When Navigated to 'Graph' tab
	Then Graph tab opened displaying the Select Paramater dropdown and the Add button
	When Select a parameter'Exhaust Pressure (Pa)' from the dropdown control, click the Add button 
	Then The selected parameter'Exhaust Pressure (Pa) (39)' is added to graph and plotted in a horizontal line with circles representing each data point
	And The parameter'Exhaust Pressure (Pa) (39)' is added to the graph and displayed correctly as '1.00 Pa'
	When I clicked reset Graph
	And each default parameter displayed on the Overview tab, using EISSA, change '39          (Exhaust Pressure)' value to '20'
	And Select a parameter'Exhaust Pressure (Pa)' from the dropdown control, click the Add button 
	Then The parameter'Exhaust Pressure (Pa) (39)' is added to the graph and displayed correctly as '20.00 Pa'

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario: Device Explorer_SEV Pages - Graph Tab - Multiple Parameters_iXH Device
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
	And Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001PM1' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001PM1' device
	Then Overview tab opened displaying connected device 'NEW0001PM1'
	When Navigated to 'Graph' tab
	Then Graph tab opened displaying the Select Paramater dropdown and the Add button
	And verify that the dropdown control contains the device parameters for device 'NEW0001PM1' 
	When each default parameter displayed on the Overview tab, using EISSA, change '54          (MB Temp)' value to '15'
	And each default parameter displayed on the Overview tab, using EISSA, change '39          (Exhaust Pressure)' value to '20'
	And refreshed page
	And Select a parameter'MB Temp (K)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	Then The parameter'MB Temp (K) (54)' is added to the graph and displayed correctly as '15.00 K'
	When Select a parameter'Exhaust Pressure (Pa)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	And I clicked legend 'MB Temp (K) (54)' 
	Then The parameter'Exhaust Pressure (Pa)' is added to the graph and displayed correctly as '20.00 Pa'

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario: Device Explorer_SEV Pages - Graph Tab - Multiple Parameters_Facilities Controler
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
	And Launched Eissa, started simulator and selected device type 'NEW0001FC' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001FC' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001FC' device
	Then Overview tab opened displaying connected device 'NEW0001FC'
	When Navigated to 'Graph' tab
	Then verify that the dropdown control contains the device parameters for device 'NEW0001FC'
	When each default parameter displayed on the Overview tab, using EISSA, change '51          (Inlet Thermocouple 2)' value to '15'
	And each default parameter displayed on the Overview tab, using EISSA, change '38          (FC4072 N2 Dilution Flow 2)' value to '20'
    And refreshed page
	And Select a parameter'Inlet Thermocouple 2 (K)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	Then The parameter'Inlet Thermocouple 2 (K) (51)' is added to the graph and displayed correctly as '15.00 K'
	When Select a parameter'FC4072 N2 Dilution Flow 2 (m3/s)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	And I clicked legend 'Inlet Thermocouple 2 (K) (51)' 
	Then The parameter'FC4072 N2 Dilution Flow 2 (m3/s) (38)' is added to the graph and displayed correctly as '20.00 m3/s'

@SplitServer
@SingleServer
@DeviceExplorer	
	Scenario: Device Explorer_SEV Pages - Graph Tab - Multiple Parameters_Atlas Abatement
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
	And Launched Eissa, started simulator and selected device type 'NEW0001AC1' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001AC1' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001AC1' device
	Then Overview tab opened displaying connected device 'NEW0001AC1'
	When Navigated to 'Graph' tab
	Then verify that the dropdown control contains the device parameters for device 'NEW0001AC1' 
	When each default parameter displayed on the Overview tab, using EISSA, change '35          (TE406 Combustor Temperature)' value to '15'
	And each default parameter displayed on the Overview tab, using EISSA, change '50          (PT121 Nozzle Pressure 1)' value to '20'
	And refreshed page
	And Select a parameter'TE406 Combustor Temperature (K)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	Then The parameter'TE406 Combustor Temperature (K)' is added to the graph and displayed correctly as '15.00 K'
	When Select a parameter'PT121 Nozzle Pressure 1 (Pa)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	And I clicked legend 'TE406 Combustor Temperature (K)' 
	Then The parameter'PT121 Nozzle Pressure 1 (Pa) (50)' is added to the graph and displayed correctly as '20.00 Pa'

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario: Device Explorer - SEV Pages - Graph Tab - Reset Graph
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
	And Launched Eissa, started simulator and selected device type 'NEW0001FC' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001FC' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001FC' device
	Then Overview tab opened displaying connected device 'NEW0001FC'
	When Navigated to 'Graph' tab
	Then verify that the dropdown control contains the device parameters for device 'NEW0001FC' 
	When Select a parameter'Inlet Thermocouple 6 (K)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	Then I should be able to see legend for added parameter 'Inlet Thermocouple 6 (K) (55)'
	When Select a parameter'FC4072 N2 Dilution Flow 2 (m3/s)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	Then I should be able to see legend for added parameter 'FC4072 N2 Dilution Flow 2 (m3/s) (38)'
	When I clicked reset Graph
	Then the devices are removed 'Inlet Thermocouple 6 (K) (55)' and 'FC4072 N2 Dilution Flow 2 (m3/s) (38)'

@SplitServer
@SingleServer
@DeviceExplorer
	Scenario:  Device Explorer - SEV Pages - Graph Tab - Legend Items
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
	And Launched Eissa, started simulator and selected device type 'NEW0001FC' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001FC' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001FC' device
	Then Overview tab opened displaying connected device 'NEW0001FC'
	When Navigated to 'Graph' tab
	Then verify that the dropdown control contains the device parameters for device 'NEW0001FC' 
	When Select a parameter'Inlet Thermocouple 2 (K)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	Then The parameter'Inlet Thermocouple 2 (K) (51)' is added to the graph and displayed correctly as '1.00 K'
	When Select a parameter'FC4072 N2 Dilution Flow 2 (m3/s)' from the dropdown control, click the Add button and verify that the parameter is added to the graph
	And I clicked legend 'Inlet Thermocouple 2 (K) (51)' 
	Then The parameter'FC4072 N2 Dilution Flow 2 (m3/s) (38)' is added to the graph and displayed correctly as '1.00 m3/s'.
	When I clicked legend 'FC4072 N2 Dilution Flow 2 (m3/s) (38)'
	And I clicked legend 'Inlet Thermocouple 2 (K) (51)'
	Then corresponding chart data line become visible
	When I clicked legend 'Inlet Thermocouple 2 (K) (51)' 
	Then corresponding chart data line become invisible
	When I clicked legend 'FC4072 N2 Dilution Flow 2 (m3/s) (38)'
	Then corresponding chart data line become visible.
	When I clicked legend 'FC4072 N2 Dilution Flow 2 (m3/s) (38)' 
	Then corresponding chart data line become invisible.

@SplitServer
@SingleServer
@DeviceExplorer
Scenario: Diagram Tab_Turbo SEV measure view
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
	And Launched Turbo simulator
    And Configure Turbo Simulator
	And Select an equipmentName 'TURBO4001' equipmentType 'Turbo Pump' device iPPortNumber'4001'.
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Choose a turbo device and navigate to the SEV page
	Then There should be a [Measure Tab] visible
	When Choose a turbo device and navigate to the SEV page. Click on the Measure tab
	Then displays the measure view as per turbo measure view non alert status.png
	When Using the simualator trigger a warning using alert code '128' at port '4001'
	Then After a short interval, the view will be updated and the motor speed chart will change colour to the warning colour and the motor speed parameter box will change background colour to the warning colour and dispaly the warning icon warning image
	When clear the simualator alert in port '4001'
	Then The display will revert to the non alert status
	When Create an alert code 28 - Motor Speed at port '4001'
	Then the parameter box will indicate the 'Motor Speed' alert status and the motor speed chart will reflect the alert
	When Create an alert code 18 - Motor Temperature overheat at port '4001'
	Then the parameter box will indicate the 'Motor Temperature' alert status 
	When Create an alert code 2 - TMS Temperature at port '4001'
	Then the parameter box will indicate the 'TMS Temperature' alert status
	When Create an alert code 6 - DC Link Voltage at port '4001'
	Then the parameter box will indicate the 'DC Link Voltage' alert status
	When Create an alert code 11 - Motor Current at port '4001'
	Then the parameter box will indicate the 'Motor Current' alert status
	When Create an alert code 13 - PosXH at port '4001'
	Then the parameter box will indicate the 'PosXH' alert status
	When Create an alert code 14 - PosYH at port '4001'
	Then the parameter box will indicate the 'PosYH' alert status
	When Create an alert code 15 - PosXB at port '4001'
	Then the parameter box will indicate the 'PosXB' alert status
	When Create an alert code 16 - PosYB at port '4001'
	Then the parameter box will indicate the 'PosYB' alert status
	When Create an alert code 17 - PosZ at port '4001'
	Then the parameter box will indicate the 'PosZ' alert status
	When Create an alert code 43 - Vibration H at port '4001'
	Then the parameter box will indicate the 'Vibration H' alert status
	When Create an alert code 44 - Vibration B at port '4001'
	Then the parameter box will indicate the 'Vibration B' alert status
	When Create an alert code 45 - Vibration Z at port '4001'
	Then the parameter box will indicate the 'Vibration Z' alert status

@SplitServer
@SingleServer
@DeviceExplorer	
	Scenario: Device Explorer_SEV Pages - Diagram Tab - iXH Device
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
	And Launched Eissa, started simulator and selected device type 'NEW0001PM1' 
	And I commissioned device with following details 'eZenith', '50000'
	And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001PM1' and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When Selected added 'NEW0001PM1' device
	Then Overview tab opened displaying connected device 'NEW0001PM1'
	When Navigated to 'Diagram' tab
	Then the image should be visible with non alert status
	When Create an High Warning Alert on a device
	Then high warning alert is created, the diagram tab background colour change to yellow
	When I Clear the alert for Booster Power
	When Create an High Alarm Alert on a device
	Then high alarm alert is created, the diagram tab background colour change to red

 
