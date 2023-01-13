Feature: ModbusTests
This test checks that EdCentra supports communication with the CSK, Ebara drypumps over Modbus

Background:
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
Then Change the User Preference 

@mytag
Scenario Outline: CSK Forest Abatement Support
When Run modbus simulator up, and set num ports to "1" Click the Start button
Then open file dialog shows, choose the 'CSK_Forest.rgr' file
When I clicked Device Explorer link	
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
And I commissioned device with following details 'iForest Abatement', '502'
When Open the device in Device explorer to show device SEV screen
Then Some analogue parameters such as Water Tank Flow  Inlet Pressure Oxidzer Flow Rate
When Change 'Holding Register' '113' to '15000'
Then Make sure that the parameter '#1-1 Inlet Pressure' changes to '15000 Pa'
When Change 'Holding Register' '102' to '2'
Then The device running status should go to 'Stand By'
When Change 'Holding Register' '102' to '1'
Then The device running status should go to 'Running'
When Change 'Holding Register' '108' to '1'
Then A warning 'W_#1-1 Inlet Pressure High' should be raised on parameter '#1 Warning Ch 1 (9)'
When Change 'Holding Register' '105' to '1'
Then One alarm 'A_#1 Water Leak' on parameter '#1 Emergency (6)' should be raised
When Change the 'Holding Registers' '108' and '105' to '0'
Then The warning and alarm alerts should clear
When In the Modbus simulator, uncheck the box `FC 03 (Read Holding Registers)`
Then This should cease communication between the agent and simulator,device should go to 'No Communication'
When Re-check the `FC 03` checkbox
Then Communication should be re-established 'Running'.
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iForest Abatement' for the profile. Click Create.
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>' '<Parameter1>' '<TimeIntervalforNormal1>' '<TimeIntervalforAlert1>' '<TimeIntervalforDelta1>'.Then Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
Examples: 
|       Parameter     | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |         Parameter1        | TimeIntervalforNormal1 | TimeIntervalforAlert1 | TimeIntervalforDelta1 | 
|   #1 Drain Time (s) | 1 Second              | 1 Second             | 1                    |  #1 Chamber Pressure (Pa) |        1 Second        |        1 Second       |           1           | 

Scenario Outline: Ebara DryPump support
When Run modbus simulator up, and set num ports to "2" Click the Start button
Then open file dialog shows, choose the 'Ebara.rgr' file
When I clicked Device Explorer link	
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
And I commissioned device with following details 'Ebara VOS Series Drypump', '502'
When Open the device in Device explorer to show device SEV screen
Then Some analogue parameters such as BP Power Pump N2 Flow BP Status
When Change 'Holding Register' '102' to '110'
Then Make sure that parameter 'BP Power 'changes to '110 W'
When Change 'Holding Register' '134' to '0'
Then The device running status should go to 'Stopped'
When Change 'Holding Register' '134' to '1'
Then The device running status should go to 'Running'
When Change 'Holding Register' '205' to '1'
Then A warning 'Casing temp. high' should be raised on parameter 'MP Casing Temperature (9)'
When Change 'Holding Register' '205' to '0'
Then The warning should clear
When Change 'Holding Register' '250' to '1'
Then One alarm 'Casing temp. HH' on parameter 'MP Casing Temperature (9)' should be raised
When Change 'Holding Register' '250' to '0'
Then The alarm alerts should clear
When In the Modbus simulator, uncheck the box `FC 03 (Read Holding Registers)`
Then This should cease communication between the agent and simulator,device should go to 'No Communication'
When Re-check the `FC 03` checkbox
Then Communication should be re-established 'Running'.
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'Ebara VOS Series Drypump' for the profile. Click Create.
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>' '<Parameter1>' '<TimeIntervalforNormal1>' '<TimeIntervalforAlert1>' '<TimeIntervalforDelta1>'.Then Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile

Examples: 
|       Parameter     | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |    Parameter1        | TimeIntervalforNormal1 | TimeIntervalforAlert1 | TimeIntervalforDelta1 | 
|   MP Power (W)      | 1 Second              | 1 Second             | 1                    |    BP Power (W)      |        1 Second        |        1 Second       |           1           |

Scenario Outline: Support Edwards I/O Controller (Type 2b) over Modbus TCP
When Run modbus simulator up, and set num ports to "2" Click the Start button
Then open file dialog shows, choose the 'edwardsiocontroller_registers.rgr' file
When I clicked Device Explorer link	
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
And I commissioned device with following details 'Edwards IO Controller', '502'
When Open the device in Device explorer to show device SEV screen
Then Change to 'Input Register' '1' to '1'
Then Make sure some data comes through. Some digital outs, and analogue parameters
When Add needed parameter 'DigitalInput1' 'AnalogueInput1' Before changing the Input register
When Change 'Input Register' '199' to '110'
Then Make sure the parameter 'AnalogueInput' changes to '110'
When Change 'Input Register' '1' to '0'
Then The device running status should go to 'Off'
When Change 'Input Register' '1' to '1'
Then The device running status should go to 'Running'
When In the Modbus simulator, uncheck the boxes activate FC checkboxes
Then This should cease communication between the agent and simulator,device should go to 'No Communication'
When Re-check the FC checkboxes
Then Communication should be re-established 'Running'.
When Provide a name'LoggingTest' and select an equipment type'Edwards IO Controller' for the profile. Click Create.
When Finally, create a logging profile for an Edwards IO Controller, logging parameters '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>' '<Parameter1>' '<TimeIntervalforNormal1>' '<TimeIntervalforAlert1>' '<TimeIntervalforDelta1>' '<Parameter2>' '<TimeIntervalforNormal2>' '<TimeIntervalforAlert2>' '<TimeIntervalforDelta2>'.Then Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile

Examples: 
|  Parameter    | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |  Parameter1    | TimeIntervalforNormal1 | TimeIntervalforAlert1 | TimeIntervalforDelta1 |     Parameter2    | TimeIntervalforNormal2 | TimeIntervalforAlert2 | TimeIntervalforDelta2 |
| DigitalInput3 |       30 Seconds      |        30 Seconds    |           1          | DigitalInput2  |          30 Seconds    |        30 Seconds     | 1                     |    DigitalInput1  |         30 Seconds     |        30 Seconds     |              1        |

Scenario: Agent changes to support IO controller alerts per system
When Run modbus simulator up, and set num ports to "2" Click the Start button
Then open file dialog shows, choose the 'edwardsiocontroller_registers.rgr' file
When I clicked Device Explorer link	
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
And I commissioned device with following details 'Edwards IO Controller', '502'
When Open the device in Device explorer to show device SEV screen
When Go to the Configure -> Edwards IO Controller Settings section
Then Page loads and shows Create new profile dialog if there are no existing profiles
When New dialog is not showing if there are existing profiles then click the New button, enter a unique name 'ControllerProfile' and click the create button.
Then Profile is created and shown - you can see the details with tabs: Parameters, Functions, Alerts and assignments.
When Now go to the parameters tab, and scroll down to 'DigitalInput1'. Click the checkbox
Then Edit textbox appears
When Enter 'Digi1' as the name
When scroll down to 'DigitalInput2'. Click the checkbox
Then Edit textbox appears
When I Enter 'Digi2' as the name
When Click Apply
Then Parameter'DigitalInput1' renames 'Digi1' are applied
When move to the alerts tab
Then Alert tab opens
When the dropdown list select Click the Add button at the end of the row
|         Parameter        |    Alert    |  AlertMessage |
| Function1_Boolean_Output | Major Alarm | Digi1OrDigi2  |
Then Alert is added to the profile
|         Parameter        |    Alert    |  AlertMessage |
| Function1_Boolean_Output | Major Alarm | Digi1OrDigi2  |
When Now move to the assignments tab
Then Assignments tab opens
When Click find equipment, and select the IO Controller you are using in this test. Select the device in the left hand pane, and click the > button to move it to the right pane. Click Apply
Then No errors are shown. Wait a minute or so for the profile to apply to the equipment
When Now, in the Modbus simulator application, on the left hand pane, select Coils and scroll down to register '299'. 
And Double click on the red False text, to change it to green True
When Go to live alerts list, and open the alert just raised
Then You can see a red alarm with message 'Digi1OrDigi2' on parameter
When Back to the Modbus simulator application, on the left hand pane, select Coils and scroll down to register '299'. 
And Double click on the green True text, to change it to a red False.
Then the previous major alarm should be cleared.