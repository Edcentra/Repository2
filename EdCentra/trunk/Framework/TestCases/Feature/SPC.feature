Feature: SPC feature
SPC Graph should arrive Properly

Background:
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button

@mytag
Scenario Outline: New SPC App
When I Change Temperature User Preference.
When I clicked Device Explorer link	
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
And Launched Eissa, started simulator Check Randomparameter and selected device type 'NEW0001PM1'. 
And I commissioned device with following details 'eZenith', '50000'
When I selected the equipment type, entered equipmentName'NEW0001PM1' 'NEW0001PM2' 'NEW0001PM3' 'NEW0001AC1',Cliked Find Equipment button, selected one equipment and clicked Add button
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
When Go into Historian - SPC section and select a parameter 'NEW0001PM1' from a system with logged data.
Then Parameter'Booster Control (12)' listed
When SPC section and select a parameter 'DP End Cover Temp (57)' from a system with logged data.
Then SPC graph should show with the 'Mean' value in the top graph and 'Mean Range' value below
When Choose a different metric 'Maximum' from the drop down below the charts.
Then The chart should re-draw the parameter 'DP End Cover Temp (57)' and the top chart should now show the Maximum value 'Mean' at a given time.
When Change the control limit drop-down below the chart.
Then The chart should re-draw the parameter 'DP End Cover Temp (57)' and the red control limit '6σ Upper Control Limit' lines should reflect the option selected in the drop-down
When Select another parameter 'Booster Control (12)' on the same system by clicking it in the list.
Then Chart should re-draw with the selected parameter 'NEW0001PM1 Booster Control (12)' now show instead of the previous one.
When Select another system 'NEW0001PM2' of the same type in the Systems tree.
Then Chart should re-draw with the equivalent parameter now plotted from the newly selected system 'NEW0001PM2 Booster Control (12)'.
When Select another system 'NEW0001AC1' of a different type from the Systems tree.
Then Parameters 'Ammonia Flow Tool 2 (275)' are loaded from the selected system but the graph is not changed and retains its current system/parameter 'NEW0001PM2 Booster Control (12)'.
When Click the Box Plot tab.
Then Box plot graph will show with the previously selected paramter 'NEW0001PM2' now rendered as a box plot.
When I Select another system 'NEW0001PM3' of the same type in the Systems tree.
Then Another box plot is added to the graph showing the equivalent parameters 'NEW0001PM2' 'NEW0001PM3' from the newly selected system
When Select the Graph tab
Then SPC graph is one again shown for the last system'NEW0001PM3 Booster Control (12)' selected.

Examples: 
|       Parameter          | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| AEM CJ Temperature (ºC)  |      1 Second         |      1 Second        |         3            |  

Scenario Outline: SPC Temperature Range Data
When I Change Temperature User Preference.
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
When I Find equipment using equipment description and add Equipments 'NEW0001PM1' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
When Go into Historian - SPC section and select a parameter 'NEW0001PM1' from a system with logged data.
And select the parameter 'DP End Cover Temp (57)' from the list of available parameters
Then the graph should be displayed on the right side and the range graph should display non negative numbers

Examples: 
| Parameter              | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| DP End Cover Temp (ºC) | 1 Second              | 1 Second             | 3                    | 