Feature: OtherDeviceDataTypes

Background:
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
Then Change the User Preference 

@SplitServer
@SingleServer
@OtherDeviceDataTypes
Scenario: Other Device Data Types - EcoLink Cycling
When Enable GreenMode in EdCentra Options EnableGreenMode=On
Then Confirm the Success message
When I clicked Device Explorer link
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
And Launched Eissa, started simulator and selected equipment type 'eZenith' and device type 'NEW0001PM1' 
And I commissioned device with following details 'eZenith', '50000'
And I Entered Equipment name, Selected the Equipment type,Cliked Find Equipment button, selected one by one equipments 'NEW0001PM1' 'NEW0001PM2' 'NEW0001PM3' 'NEW0001PM4' 'NEW0001PM5' 'NEW0001PM6'and clicked Add button
And grab the system '[WEB]' id of every iXH for the test
And open the DSPU and open Eco Mode Scenario 'ecomode_scenario.dspu.xml'
Then in the DSPU, edit [ MANIPULATOR / Spawner / DPD to systems A ] and [ MANIPULATOR / Spawner / DPD to systems B ] setting the property Value to the iXH pipe delimited system id list above
When Execute the DSPU scenario and then watch the equipment in DeviceExplorer for a about five minutes
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
When Click Historian Equipment Data tab
Then Equipment Datatab should be shown and Select Device Explorer folder on Systems list
When Expand the folder and Select single Equipment 'NEW0001PM1' in the Tree
Then The Parameter'Booster Control (12)' for that Equipment will be displayed in the parameter's list
When I click on of the parameter'Equipment Status' and click Add button at the bottom of the parameter list
Then view the Equipment Status value 'IDLE' in the Historian Equipment Status grid view
When Stop the DSPU scenario and start EISSA again
Then DSPU data to stop flowing and regular EISSA data'12          (Booster Control)' '10' to flow again 'Booster Control (12)'

@SplitServer
@SingleServer
@OtherDeviceDataTypes
Scenario Outline:Add EUV support to EdCentra only
When I clicked Device Explorer link
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
And Launched Eissa, started simulator and selected equipment type 'EUVZenith' and device type 'NEW0001FC' 
And I commissioned device with following details 'EUV Zenith', '50000'
And I entered Equipment name, selected equipmentType'EUV Zenith Slice Controller', Cliked Find Equipment button, selected one equipmentName'NEW0001FC' and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When Open the SEV 'NEW0001FC' to the device
Then Make sure data appears on the UI
When Raise an alert '6          (Exhaust Valve)' 'HighAlarm' 'IDS_17000_ALERT_38_ERROR (Leak Detector 101 Error)' (alarm) on the EISSA simulator on the Slice Controller
Then Make sure the  alarm alert appears in the SEV, and Alert List app
When Raise an alert '2          (RS Gate Valve)' 'HighWarning' 'IDS_17000_ALERT_203_ERROR (System Error)' (warning) on the EISSA simulator on the Slice Controller
Then Make sure the warning alert appears in the SEV, and Alert List app
When Clear the alarm '6          (Exhaust Valve)' alert
Then Make sure the alarm alert disappears in the SEV, and Alert List app
When Clear the warning '2          (RS Gate Valve)' alert
Then Make sure the warning alert disappears in the SEV, and Alert List app
When Modify the running status of the Slice Controller device'NEW0001FC' between Running and 'Stop' in EISSA
Then Just make sure the status changes in EdCentra between 'Off' and Modify the running status of the Slice Controller device 'Running' and  status changes in EdCentra'On'
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'EUV Zenith Slice Controller' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When Make number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>' '<Parameter1>' '<TimeIntervalforNormal1>' '<TimeIntervalforAlert1>' '<TimeIntervalforDelta1>' '<Parameter2>' '<TimeIntervalforNormal2>' '<TimeIntervalforAlert2>' '<TimeIntervalforDelta2>'.Click Apply.
#When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>' '<Parameter1>' '<TimeIntervalforNormal1>' '<TimeIntervalforAlert1>' '<TimeIntervalforDelta1>'.Then Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001FC' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
Examples: 
|          Parameter         | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |              Parameter1          | TimeIntervalforNormal1 | TimeIntervalforAlert1 | TimeIntervalforDelta1 |       Parameter2         | TimeIntervalforNormal2 | TimeIntervalforAlert2 | TimeIntervalforDelta2 |
|Water In Pressure 101W (Pa) |        1 Second       |      1 Second        |           8E-05      | Mass Flow Meter 101 (Exp) (slm) |        1 Second         |        1 Second       |          3E-05        | Exposure O2 Transmission |         1 Second       |         1 Second      |         1             |

@SplitServer
@SingleServer
@OtherDeviceDataTypes
Scenario Outline: Add Proteus support to EdCentra only
When I clicked Device Explorer link
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
And Launched Eissa, started simulator and selected equipment type 'Proteus' and device type 'NEW0001AC' 
And I commissioned device with following details 'Proteus Abatement', '50000'
And I entered Equipment name, selected equipmentType'Proteus Abatement', Cliked Find Equipment button, selected one equipmentName'NEW0001AC' and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When Open the SEV 'NEW0001AC' to the device
Then Make sure Proteus data appears on the UI
When Raise an alert '36          (Process Gas 1 Pressure)' 'HighAlarm' 'IDS_16409_ALERT_1022_HIGH (Channel B NPW Main Pressure High Alarm)' (alarm) on the EISSA simulator on the Slice Controller
Then Make sure the  alarm alert appears in the SEV, and Alert List app
When Raise an alert '75          (Channel A System Exhaust Pressure)' 'HighWarning' 'IDS_16409_ALERT_10_HIGH (Channel A PCW Main Pressure High Alarm)' (warning) on the EISSA simulator on the Slice Controller
Then Make sure the warning alert appears in the SEV, and Alert List app
When Clear the alarm '36          (Process Gas 1 Pressure)' alert
Then Make sure the alarm alert disappears in the SEV, and Alert List app
When Clear the warning '75          (Channel A System Exhaust Pressure)' alert
Then Make sure the warning alert disappears in the SEV, and Alert List app
When Modify the running status of the Slice Controller device'NEW0001AC' between Running and 'Stop' in EISSA
Then Just make sure the status changes in EdCentra between 'Off' and Modify the running status of the Slice Controller device 'Running' and  status changes in EdCentra'On'
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'Proteus Abatement' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When Make number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>' '<Parameter1>' '<TimeIntervalforNormal1>' '<TimeIntervalforAlert1>' '<TimeIntervalforDelta1>' '<Parameter2>' '<TimeIntervalforNormal2>' '<TimeIntervalforAlert2>' '<TimeIntervalforDelta2>'.Click Apply.
#When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>' '<Parameter1>' '<TimeIntervalforNormal1>' '<TimeIntervalforAlert1>' '<TimeIntervalforDelta1>'.Then Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001AC' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
Examples: 
|          Parameter          | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |         Parameter1         | TimeIntervalforNormal1 | TimeIntervalforAlert1 | TimeIntervalforDelta1 |         Parameter2               | TimeIntervalforNormal2 | TimeIntervalforAlert2 | TimeIntervalforDelta2 |
| Process Gas 1 Pressure (Pa) |        1 Second       |       1 Second       |           1          | Channel A Plasma Power (W) |         1 Second       |        1 Second       |             1         | Channel A PCW Main Pressure (Pa) |         1 Second       |        1 Second       |         1             |