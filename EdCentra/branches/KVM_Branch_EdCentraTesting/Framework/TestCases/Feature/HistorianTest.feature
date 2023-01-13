Feature: Historian
	
Background:
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
Then Change the User Preference
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

@mytag
@SplitServer
@SingleServer
@Historian
Scenario Outline: Data Logging - Setup a data logging profile
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>' '<Parameter1>' '<TimeIntervalforNormal1>' '<TimeIntervalforAlert1>' '<TimeIntervalforDelta1>'.Then Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I adding more parameter unmark Show only parameters in profile button
Then The Show only parameters in profile button unmark and all the parameters Param'Booster Power (W)' listed
When I Check the checkbox entitled Show only parameters in profile
Then The Only parameters '<Parameter1>' selected as present in the profile should be present
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
Examples: 
|      Parameter      | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |       Parameter1        | TimeIntervalforNormal1 | TimeIntervalforAlert1 | TimeIntervalforDelta1 |
| Booster Current (A) |     1 Second          |   1 Second           |         3            | AEM CJ Temperature (K)  |        1 Second        |      1 Second         |       5               |

@SplitServer
@SingleServer
@Historian
Scenario Outline: Data Logging - Rename Profile
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
When I Select already created test data logging profile ProfileName'LoggingTest'
Then The Profile detail will be displayed ProfileName 'LoggingTest'
When I Change the name of the profile Newprofilename 'RenameTest' and click apply
Then The changes should be saved and Newprofilename 'RenameTest'
When I delete the ProfileName'RenameTest' if profilename exist
Then Ensure the ProfileName 'RenameTest' is deleted
Examples: 
|       Parameter         | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (K)  |      1 Second         |      1 Second        |         1            |

@SplitServer
@SingleServer
@Historian
Scenario Outline: Data Logging - Duplicate Profile
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
When I Select already created test data logging profile ProfileName'LoggingTest'
Then The Profile detail will be displayed ProfileName 'LoggingTest'
When I Select a Logging profile 'LoggingTest'and click the Duplicate button
Then A dialog is opened displaying the profile name with Copy of prefixing the profile name, OK and Cancel buttons
When I Click cancel
Then verify that the copy dialog is closed and the profile is not copied
When I Click the Duplicate button again
Then I get a dialog is opened displaying the profile name with Copy of prefixing the profile name
When I click OK on the copy profile dialog and delete ProfileName'LoggingTest' already exist
Then Verify that a new profile duplicatename 'Copy of LoggingTest' is created with the same parameter'AEM CJ Temperature (K)' attributes as the original
When I delete the ProfileName'Copy of LoggingTest' if profilename exist
Then Ensure the ProfileName 'Copy of LoggingTest' is deleted
Examples: 
|       Parameter         | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (K)  |      1 Second         |      1 Second        |         2            |

@SplitServer
@SingleServer
@Historian
Scenario Outline: Data Logging - Delete Profile
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
When I Select already created test data logging profile ProfileName'LoggingTest'
Then The Profile detail will be displayed ProfileName 'LoggingTest'
When I Click the delete button
Then Verify that the delete profile dialog is opened with OK and Cancel buttons
When Click the Cancel button
Then Verify that the delete dialog is closed and the profile is not deleted
When I Click the delete button again
Then verify that the delete profile dialog is opened
When I click OK on the delete dialog
Then Ensure the profile profilename 'LoggingTest' is deleted
Examples: 
| Parameter              | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (K) | 1 Second              |       1 Second       | 2                    |

@SplitServer
@SingleServer
@Historian
Scenario: Data Logging - Apply parameter selection
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
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
When I Navigate to the details tab of a Data Logging profile
Then The details tab of a Data Logging profile displayed
When Select a parameter from the list for logging by checking the Log Parameter'AEM CJ Temperature (K)' check box
Then Green tick appears in checkbox
When Without clicking the apply button, navigate to another logging profile or another Edcentra window such as the Device Explorer, navigate back to the previous data logging profile'LoggingTest'
Then verify that the selected Parameter'AEM CJ Temperature (K)' Check box no longer ticked
When I select the same Parameter'AEM CJ Temperature (K)'
Then I click the Apply button
When Navigate away and back again to the selection Profile'LoggingTest'
Then Verify that the selection Parameter'AEM CJ Temperature (K)' has been remembered

@SplitServer
@SingleServer
@Historian
Scenario Outline: Data Logging - Review the Logging Assignments
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
When I Navigate to the details tab of a Data Logging profile
Then The details tab of a Data Logging profile displayed
When I Click the Assignments button within Logging
Then The tab Logging is displayed showing a list of all equipment with logging profiles
When Click the Not Logging tab and All tab
Then The logging profiles should appear in black (when they have applied) or blue (when they are ‘in process’ just before they have been processed by the relevant agent). Keep monitoring this page to check that the profile ‘goes black’. 
Examples: 
| Parameter               | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (K)  | 1 Second              | 1 Second             | 4                    |

@SplitServer
@SingleServer
@Historian
Scenario Outline: Data Logging - Display effective logging and Refresh assignment
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
When I Navigate to the details tab of a Data Logging profile
Then The details tab of a Data Logging profile displayed
When Click on the Display effective logging on this equipment icon (looks like a piece of paper with writting on it)
Then After a few moments, a form will show detailing the logging regime applied
When Choose a profile and click on the refresh icon (two green arrows)
Then The entry should display blue with an animated refresh gif in place of the green tick
Examples: 
| Parameter               | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (K)  | 1 Second              | 1 Second             | 2                   |

@SplitServer
@SingleServer
@Historian
Scenario Outline: Historian - Equipment Data Filter
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
When Click Historian ->Equipment Data tab
Then Equipment Data tab should be shown
When I Select date range StartDate and mark only Parameter Data check box.Ummark Alerts and Equipment Status.Click Apply
Then Select Device Explorer folder on Systems list
When Expand the folder and Select single Equipment '<EquipmentName>' in the tree
Then The Parameter'<Parameter1>' for that equipment'<EquipmentName>' will be displayed in the parameter's list
When Click on of the parameter'<Parameter2>' and click Add button at the bottom of the parameter list
Then Grid tab should display values for selected equipment'<EquipmentName>' and selected parameter'<ParameterName1>'
When Click on the Graph tab
Then The Graph tab should display graph of selected parameter'<ParameterName3>' values against date and time
And Alerts raised against a Parameter '8          (Booster Power)' AlertType 'HighAlarm' AlertCode 'IDS_25_ALERT_1_0 (System configuration fault)'
When Mark the Alerts and Equipment Status check box on top and click [Apply]
Then Both the Grid and Graph tabs should display values of Alerts Message'Booster Power' and Equipment status
When Clear alert against a Parameter '8          (Booster Power)'
When Add one more parameter'<Parameter1>'to the list
Then Both the Grid and Graph tabs should display values of newly added parameter as well as previously added parameter'<EquipmentName>' '<ParameterName1>' '<ParameterName2>' '<ParameterName3>' '<ParameterName4>'
Examples: 
| Parameter              | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta | EquipmentName |     Parameter1       |     Parameter2    | ParameterName1   |   ParameterName2    |       ParameterName3         |        ParameterName4           |
| AEM CJ Temperature (K) | 1 Second              | 1 Second             | 3                    | NEW0001PM1    | Dry Pump Current (3) | Booster Power (8) |  Booster Power   |  Dry Pump Current   | NEW0001PM1:Booster Power (8) | NEW0001PM1:Dry Pump Current (3) |

@SplitServer
@SingleServer
@Historian
 Scenario Outline: Data Extraction Utility - Daily Extraction
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
When Go to Historian->Data Extraction Utility
Then The Data Extraction Utility tab should be shown
When Click on Enable Daily Extraction Utility
Then Click Settings button and check some filtering option dialogs
When I click on [Save]
Then The settings screen shall hide, later tests will verify the settings have been made
When Select some equipment via Change Selection button on under Selected Systems list
Then Search Equipments using a variety of search conditions
When some System'NEW0001PM1' are selected, click on the move button (either [>] or [>>])
Then The selected equipment'NEW0001PM1' should appear in the ride hand pane
When click on the Apply Button
Then Extraction system settings screen shall hide
When Select some Groups via Change Selection button on under Selected Groups list
And Mark groups under either PTCs, User folders and Equipment Type node
And Click on the Apply Button
And I Click on the Save Button
Then The Extraction system settings screen shall hide
When Return to the EdCentra Home screen, then return to daily extraction utility (specifically the Daily Extraction Settings button.)
Then The settings previously made System'NEW0001PM1' and Group 'PTCs' 'Equipment Type'should be shown  
Examples: 
| Parameter               | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (K)  | 1 Second              | 1 Second             |         1            |

@SingleServer
@Historian
@DBServer
Scenario Outline: Data Extraction Utility - Historic Extraction
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
When Check some filtering option for Row data. Type in Description and select start and End date.
Then The changes previously made should be shown
When Select some equipment via Change Selection button on under Selected Systems list
Then Search Equipments using a variety of search conditions
When some System'NEW0001PM1' are selected, click on the move button (either [>] or [>>])
Then The selected equipment'NEW0001PM1' should appear in the ride hand pane
When click on the Apply Button
Then Extraction system settings screen shall hide
When Select some Groups via Change Selection button on under Selected Groups list
And Mark groups under either PTCs, User folders and Equipment Type node
And I Click on the Apply Button
Then The selected equipment should appear in Selected System'NEW0001PM1' list The selected Group'PTCs' 'Equipment Type' should appear in the selected groups list
When press [Extract]
Then A message stating The Historic Extraction Utility is currently extracting should display with a wait icon
When Once the extraction is complete, look on the local file system of the server under path
Then There should be a folder named yyyy-mm-dd inside of which should be a ZIP file with the same filename and its contains CSV files
Examples: 
| Parameter               | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (K)  | 1 Second              | 1 Second             | 2                    |

@SplitServer
@SingleServer
@Historian
Scenario Outline: Reports - Swap Out Report Display
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
When Select the Equipment Software Survey report from the list of reports
Then A tree showing the current groups and folders to be displayed
When Select the node containing the EISSA simulated devices System'NEW0001PM1'
Then A swirling icon indicating that the graph is running
And Wait for the swiling icon to disappear
#Then The report to show with serial number'Test:AIM Software0 151,11' details of the various EISSA devices
Examples: 
| Parameter               | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (K)  | 1 Second              | 1 Second             | 2                    |

@SplitServer
@SingleServer
@Historian
Scenario Outline: Historian - Graphing
When I selected the equipment type, entered equipmentName'NEW0001PM1' 'NEW0001PM2' 'NEW0001PM3', Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipment'NEW0001PM3' to Assigned Equipment list using > and >> button then Click Apply
Then The assigned Equipment'NEW0001PM3' should appear in the ride hand pane and I click apply button
When Navigate to Historian -> Equipment Data Select a piece of System and Equipment 'NEW0001PM1' that is logging data (and also of which you have another of this exact equipment type)
Then Parameter'Exhaust Gas Temperature (56)'listed of which we have data to plot for Equipment'NEW0001PM1'
When Select at least one Parameter'Booster Power (8)' that has logged data, preferably an analogue parameter such as Temperature, Power, Speed etc. You can multi-select by holding the ctrl key down while selecting
Then  Click the lock button when you selection is complete (the one with the closed padlock symbol)
When Data for all selected Parameter'Booster Power' is shown in the data grid
Then Lock icon turns to an unlock icon (with an open padlock icon)
When I click  the Graph tab
Then Graph is displayed with your selection of Parameter'NEW0001PM1:Booster Power (8)' plot against each other
When Choose another System'NEW0001PM2' of the same type from the system tree 
Then if you have previously plot parameters from a Turbo device, you musts select a different Turbo device Parameter'DP End Cover Temp (57)'
When Graph is redrawn but with Parameter'NEW0001PM2:Booster Power (8)' substituted in from the newly selected system 
Then Click the unlock button (with an open padlock icon)
When select any other System'NEW0001PM3'from the system tree
Then Graph should not refresh and substitute parameters'NEW0001PM2:Booster Power (8)' as before. It should keep whatever parameters were previously selected
When allow you from any other System'NEW0001PM3' to add any others Parameter'Exhaust Pressure (39)' 
Then Graph should redrawn with Parameter'NEW0001PM3:Exhaust Pressure (39)' substituted in from the newly selected system
When Click the Edit Parameters button below the graph
Then Edit parameters box opens with a remove option for each parameter and an editor for the Lower and Upper limit of each unit type
When Change the lower LowerValue'20' and/or upper UpperValue'60' limit for a unit then click the Apply button
And Click the clear button underneath the graph
Then All your parameters selections are removed and graph is hidden
When Select a System 'NEW0001PM1' which has Equipment Events
Then The parameter list, an entry called Parameter 'Equipment Status' should appear, along with any other parameters that have been logging
When I Choose Parameter 'Equipment Status' and click the Add button
 Then Graph should show with equipment statuses Parameter'Equipment Status' plot on it. If the values tab is selected instead of the graph, click the Graph tab to show it. Also the Equipment Status checkbox at the top should automatically be ticked when you added the Equipmentt Status item.
Examples: 
|       Parameter         | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (K)  |      1 Second         |      1 Second        |         3           |  

@SplitServer
@SingleServer
@Historian
Scenario Outline:load and save current historian graph
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
When Log into EdCentra with an account that has acess to historian. Click on the Historian icon
Then The historian page will appear. Thre will be a button [Load Saved Graph] on the toolbar. This button will be disabled if there are not already some graphs saved for the current user
When Choose a System and plot some Equipment'NEW0001PM1'
Then The Equipment'NEW0001PM1' Parameter'Booster Power (8)' listed of which we have data to plot
When Select at least one Parameter'Booster Power (8)' data
Then The button [Save Graph] will appear at the bottom of the graph next to the [Clear Button]
When Click the [Save Graph] button
Then The save graph modal dialog will appear. The comments box will be populated with the system id and the parameters previosuly selected
When Click [Cance] in the save graph modal dialog
Then The modal dialog is hidden
When Click the [Save Graph] button and click [OK] without entering a name in the Name field
Then Message'Name cannot be blank!' is displayed
When Enter a name in the GraphName 'TestingGraph' field and click [OK]
Then The Message 'TestingGraph : Save was successful'is displayed in the toolbar next to the Load Saved Graph button/ The Load Saved Graph button is now enabled
When Click [Clear] to clear the graph
Then The graph are is cleared
When Click [Load Saved Graph]
Then The load saved graph modal dialog is displayed
When Click [Cancel]
Then The modal dialog is closed
When  Click the [Load Saved Graph] button and choose the GraphName'TestingGraph' in the dropdown box. Click [OK]
Then The modal dialog is closed and the graph is displayed using the start date, end date, Parameter 'NEW0001PM1' 'Booster Power (8)', zoom level and axis and systems previously saved
When Click [Save Graph] and [OK]
Then The Message'Unable to save graph, the name already exists. Would you like to overwrite the existing graph ?' is displayed. Yes and No buttons are displayed
When I Click No
Then The buttons are reverted to their previous state of OK and Cancel
When I Click [OK] and [Yes]
Then  The modal dialog is closed and the success Message'TestingGraph : Save was successful' is displayed
When I Click the [Save Graph] button and choose a GraphName 'TestingGraph' field 
And I Click [Delete graph] 
And Create and save some more graphs using different System 'NEW0001PM1' and Parameter'Dry Pump Current (3)'
And Click the [Save Graph] button and Enter a name in the GraphName 'DuplicateGraphTesting' field and click [OK]
And Click [Load Saved Graph] and choose a GraphName'DuplicateGraphTesting' from the list. Click [Delete graph]
Then The message Graph deleted successfully is displayed. The item is removed from the list. If the item was the last item in the list the modal dialog is closed. The [Load Saved Graph] button will be disabled if all of the saved graphs have been removed
When I Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link
Then Create User form is displayed
When I Clicked Create
Then The Required Field text should appear besides User Name, Password, confirm, First Name, Last Name and e-mail field
When added new User with details 'historianuser' 'Test@123' 'Test@123' 'Client Name' 'Edward' 'historian' 'testuser' and 'historianuser@atlascopco.com' in Create user form
Then I Provided all application permissions
When I got logged out
Then I logon as the newly created user userName 'historianuser' and password 'Test@123'
When I navigate to the historian page
Then The Load Saved Graph Button will be disabled
And I enter Administrator login again username as 'administrator' and password as 'toolkit' and clicked login button
Examples: 
|       Parameter         | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (K)  |      1 Second         |      1 Second        |         1            |   


#Need to get confirmation for live alerts list count 
@SplitServer
@SingleServer
@Historian
Scenario Outline: Report-Check data return in Alert report
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then The assigned Equipment'NEW0001PM1' should appear in the ride hand pane and I click apply button
When Ensure that simulators are running which result in some alerts evident for Parameter '7          (Booster Current)' '8          (Booster Power)' '9          (MB MotorTemperature)'AlertType 'Advisory' 'HighWarning' 'HighAlarm' in Live alerts List
Then Live alerts present for x number of devices
When Navigate to reports 
Then execute the Alert report for Equipment'NEW0001PM1' you know has alerts against it
And Ensure the Equipment'NEW0001PM1' is not in maintenance mode
#Then Report should return data matching the number of alerts present for any one device in Live alerts list
Examples: 
|       Parameter         | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (K)  |      1 Second         |      1 Second        |         2           |

Scenario Outline: Validate Location or Notes information in Historian tab
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I set the User Preferences of Temperature unit to Centigrade
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type 
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I clicked on Home Icon in top navigation menubar
When I clicked Device Explorer link
And I clicked on Top Level link
Then I should be navigated to Device Explorer page
When I clicked the header of the folder and this choose Edit Notes/Location
Then Edit Notes/Location pop-up should be displayed 
When I enter notes as "Testing Notes" on the EditNotesLocation section and click apply button
Then notes should be saved
When Click Historian ->Equipment Data tab
Then Equipment Data tab should be shown
And Select Device Explorer folder on Systems list
When hover on the folder name
Then the note "Testing Notes" should be displayed while hover on the folder name on the Historian page

Examples: 
|       Parameter         | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| DP End Cover Temp (ºC)  |      1 Second         |      1 Second        |         3           | 

@SplitServer
@SingleServer
@Historian
Scenario Outline: Historian - Filter SerialNumber
When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'LoggingTest' and select an equipment type'iXH DryPump' for the profile. Click Create.
Then The form expand and shows detail tab which lists parameter for the equipment type
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When Navigate to Historian -> Equipment Data Select a piece of System and Equipment 'NEW0001PM1' that is logging data (and also of which you have another of this exact equipment type)
And I select 'Serial #' option from the filter dropdown
And I enter the value 'Test' in the filter text box and click apply button
Then the search serial number grid will appear with the data filtered
When I select any single system on the filtered serial number data and click Apply button
Then the filtered system should alone appear under Systems folder

Examples: 
| Parameter              | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (K) | 10 Seconds             | 10 Seconds            | 3                    | 
