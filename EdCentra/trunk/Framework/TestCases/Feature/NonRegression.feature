Feature:NonRegression
	deprecate c++ code from turbo agent

Background: 
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
Then I should be navigated to Home page
Then Change the User Preference

@SingleServer
@ConfigureTest
Scenario Outline: deprecate c++ code from turbo agent
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
When I Within the [Configure \/] menu, click the Logging option
Then the Logging tab is opened
When I Click on Create Profile button
Then the Create Profile form is displayed
When Provide a name'TurboDevice' and select an equipment type'Turbo Pump' for the profile. Click Create.
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '<Parameter>' '<TimeIntervalforNormal>' '<TimeIntervalforAlert>' '<TimeIntervalforDelta>'.Click Apply.
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters'<Parameter>' added in profile
When I click on Equipments tab
Then I should be navigated to Equipments tab 
When I Find equipment using equipment description and add Equipments 'TURBO4001' to Assigned Equipment list using > and >> button then Click Apply
Then the Changes have been applied message will be displayed on the screen
When Navigated to Home page
And I clicked Device Explorer link
When Selected added 'TURBO4001' device
And Select the Serial Number dropdown control and verify that it contains a list of values
And I selected one of the options 'Control Unit Serial Number' from the serial number drop-down
Then The textbox next to the serial number drop-down should briefly say Retrieving then come back with the result.
When I clicked Parameters tab
Then Parameters page should show with all of the parameters for the piece of equipment
Then There should be a [Measure Tab] visible
When Choose a turbo device and navigate to the SEV page. Click on the Measure tab
#And Raised alert on turbo equipment with alert codes '18' & '19' on port '4001' & '4002'
#Then displays the measure view as per turbo measure view non alert status.png
And Using the simualator trigger a warning using alert code '18' at port '4001'
Then After a short interval, the view will be updated and the motor temperature chart will change colour to the red colour and the motor temperature parameter box will change background colour to the red colour and dispaly the red icon warning image
When Click Historian ->Equipment Data tab
Then Equipment Data tab should be shown
When Navigate to Historian -> Equipment Data Select a piece of System and Equipment 'TURBO4001' that is logging data (and also of which you have another of this exact equipment type)
Then Parameter'DC Link Voltage (22)'listed of which we have data to plot for Equipment'TURBO4001'
When Select at least one Parameter'Motor Current (23)' that has logged data, preferably an analogue parameter such as Temperature, Power, Speed etc. You can multi-select by holding the ctrl key down while selecting
Then  Click the lock button when you selection is complete (the one with the closed padlock symbol)
When Data for all selected Parameter'Motor Current (23)' is shown in the data grid
Then Lock icon turns to an unlock icon (with an open padlock icon)
When I click  the Graph tab
Then Graph is displayed with your selection of Parameter'TURBO4001:Motor Current (23)' plot against each other
When Using the simualator trigger a warning using alert code '19' at port '4001'

Examples: 
| Parameter                        | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| Amplifier Temperature (K)        | 5 Seconds             | 5 Seconds             |     5	         |