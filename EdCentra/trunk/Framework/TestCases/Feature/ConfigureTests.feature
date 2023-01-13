Feature: ConfigureTest
Creating a new XNIM profile with some boolean logic, ensuring it can be renamed and deleted


Background: 
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
Then I should be navigated to Home page
Then Change the User Preference

@SplitServer
@SingleServer
@ConfigureTest
Scenario: Configure - XNIM Configuration
When Create a new XNIM ProfileName'XNIMCT' with Add Button
Then The Profile'XNIMCT' should create and added in the list of Profiles 
When I Select newly created Profile'XNIMCT' and add a Parameter'ParameterTest' and some boolean logic Operator 'XOR' using New Parameter panel's add button
Then A new Parameter'ParameterTest' should be created and added in the list of Parameters for the selected profile
When Select newly created Parameter'ParameterTest' and add a Alert'CTAlert' and some boolean logic Operator'AND'using New Alert panel's add button
Then A new Alert'CTAlert' should be created and added in the list of Alerts for the selecte parameter
When Select Profile'NewXNIMCT' Parameter'NewParameterTest' and Alert'NewCTAlert' in the respective list and try to update detail from Edit panel of respective entry
Then Profile'NewXNIMCT' Parameter'NewParameterTest' and Alert'NewCTAlert' Detail should be updated and saved
When Select already created Profile'NewXNIMCT' from the list and click Copy button
Then Copy of Profile'NewXNIMCT*' should be created and added in the profile list. 
When Make sure copied profile has all related Parameter'NewParameterTest' and Alert'NewCTAlert' entries as the original profile
Then Delete the Already created Profile'NewXNIMCT'
When Select Newly Copied Profile'NewXNIMCT*' Parameter'NewParameterTest' and Alert'NewCTAlert' in the respective list and try to delete it from lis's respective Delete button
Then The entry should be deleted Profile'NewXNIMCT*'

@SplitServer
@SingleServer
@ConfigureTest
Scenario Outline: Parameter Threshold Monitoring - Set-up a profile
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
And Select an equipmentName 'TURBO4001' equipmentType 'Turbo Pump' device iPPortNumber'4001'.
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When Within Configuration, click the tab parameter Threshold Monitoring
Then PTM tab is opened
When Click on Create profileName'PTMTest'. Select Value'112' Turbo pump in Type dropdown and give appropriate name to PTM Turbo profile and click Create button
Then New profile will be created and its details tab will be displayed
When Entered details tab, Make a number of selections from the list of available in parameters '<Parameter>' '<LowValue>' '<HighValue>' '<SetValue>' '<ClearValue>' '<Parameter1>' '<LowValue1>' '<HighValue1>' '<SetValue1>' '<ClearValue1>' and Click Apply Button
Then The profile will display assigned Parameter'TMS Temperature (K)' with its values LowValue'325' and  HighValue'450'(high-Low etc.) updated
When Click on Equipments tab
Then I should be navigated to the Equipments tab 
When I find equipment using equipment description and add Equipment'Turbo4003' to Assigned Equipment list using > and >> button then Click Apply
Then Changes have been applied message will be displayed on the screen

Examples: 
| Parameter              | LowValue | HighValue | SetValue		| ClearValue	| Parameter1           | LowValue1 | HighValue1 | SetValue1		| ClearValue1	|
| Motor Temperature (K)  | 300.0    | 400.0     |	 00:00:00   |	00:00:00    | TMS Temperature (K)  | 325.0     | 450.0      |	00:00:00    |	00:00:00    |

@SplitServer
@SingleServer
@ConfigureTest
Scenario Outline: Parameter Threshold Monitoring - Renamed
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
And Select an equipmentName 'TURBO4001' equipmentType 'Turbo Pump' device iPPortNumber'4001'.
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When Within Configuration, click the tab parameter Threshold Monitoring
Then PTM tab is opened
When Click on Create profileName'PTMTest'. Select Value'112' Turbo pump in Type dropdown and give appropriate name to PTM Turbo profile and click Create button
Then New profile will be created and its details tab will be displayed
When Entered details tab, Make a number of selections from the list of available in parameters '<Parameter>' '<LowValue>' '<HighValue>' '<SetValue>' '<ClearValue>' '<Parameter1>' '<LowValue1>' '<HighValue1>' '<SetValue1>' '<ClearValue1>' and Click Apply Button
Then The profile will display assigned Parameter'TMS Temperature (K)' with its values LowValue'325' and  HighValue'450'(high-Low etc.) updated
When Click on Equipments tab
Then  I should be navigated to the Equipments tab 
When I find equipment using equipment description and add Equipment'Turbo4003' to Assigned Equipment list using > and >> button then Click Apply
Then Changes have been applied message will be displayed on the screen
When Select a newly created profile from profileName'PTMTest' listed on left hand side of the PTM screen
Then Details tab of selected profile will be displayed
When Change profileName'PTMTestRename' on details tab and click Apply
Then The profileName'PTMTestRename' Changes should be saved
When Delete the ProfileName'PTMTestRename' if profilename exist
Then Ensure ProfileName 'PTMTestRename' is deleted

Examples: 
| Parameter              | LowValue | HighValue | SetValue		| ClearValue	| Parameter1           | LowValue1 | HighValue1 | SetValue1		| ClearValue1	|
| Motor Temperature (K)  | 300.0    | 400.0     |	 00:00:00   |	00:00:00    | TMS Temperature (K)  | 325.0     | 450.0      |	00:00:00    |	00:00:00    |

@SplitServer
@SingleServer
@ConfigureTest
Scenario Outline: Data Logging - Setup a data logging profile
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
When I adding more parameter unmark Show only parameters in profile button
Then The Show only parameters in profile button unmark and all the parameters Param'Booster Power (W)' listed
When I Check the checkbox entitled Show only parameters in profile
Then The Only parameters '<Parameter>' selected as present in the profile should be present
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen

Examples: 
| Parameter               | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (K)  | 1 Second              | 1 Second             |     3	            |

Scenario: PTM Profile Editor must only show parameters available to log
When I run the SQL query against the scada_producttion database which will return the counts of PTM parameters available to be logged for each device type.
Then the total no.of parameters available for PTM is 86
And the following PTM parameters details should be present in database
	| Description | SystemTypeId | Total |
	| iQ DryPump  | 0            | 32    |
	| iH DryPump  | 1            | 70    |
	| iL DryPump  | 2            | 35    |
	| iXH DryPump | 25           | 47    |