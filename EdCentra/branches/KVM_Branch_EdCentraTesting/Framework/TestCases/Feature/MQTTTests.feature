Feature: MQTTTests
	In order to verify MQTT feature
	As a verifier
	I want to check MQTT works fine in integration with EdCentra


@SingleServer
Scenario: Configure MQTT in AgentConfiguration
	When I run Agent Configuration (shortcut on desktop)
	When I set pin value '9110'
	And I added 'MQTT' agents 
	And I selected PC Interface Network Id card under Relay tab

@SingleServer
Scenario: Enable VI Management in EdCentra
	When I launch and connect SSMS 
	Then I insert group permission to enable VI Management
	When I Open EDCENTRA application and I enter the username as 'administrator' and password as 'toolkit' and clicked login button
	Then I click Configure to see VI Management

@SingleServer
Scenario: VISimulator commission device
Given Open EDCENTRA application URL in the browser
When I enter the username as 'administrator' and password as 'toolkit' and clicked login button
#Then I Change the User-Preference
When I click the DeviceExplorer link
Then I should be navigated to the DeviceExplorer page in EdCentra
When I click on the system icon - Add Folder
And I entered the folder name and clicked on Add button 
Then I should be able to see the folder added successfully message
When I clicked the OK button
Then I should be able to see the newly added Folder
When I clicked the Find Equipment
And I delete all the existing Equipments
When I run the VIsimulator to get the VI device communicating with EdCentra
Then I commission the VISimulator as equipment Name 'viVISIM0000' equipmentType 'EdCentra VIsion Box' and serial number 'VISIM0000'
And I see the VISimulator connectivity established in folder 'viVISIM0000' and the background color is green
When I configure 3 in VISimulator to disconnect the connectivity
Then I see the background color changed in folder

@SingleServer
Scenario: VISimulator - Applying Logging Profile
Given Open EDCENTRA application URL in the browser
When I enter the username as 'administrator' and password as 'toolkit' and clicked login button
#Then I Change the User-Preference
When I click the DeviceExplorer link
Then I should be navigated to the DeviceExplorer page in EdCentra
When I click on the system icon - Add Folder
And I entered the folder name and clicked on Add button 
Then I should be able to see the folder added successfully message
When I clicked the OK button
Then I should be able to see the newly added Folder
When I clicked the Find Equipment
And I delete all the existing Equipments
When I run the VIsimulator to get the VI device communicating with EdCentra
Then I commission the VISimulator as equipment Name 'viVISIM0000' equipmentType 'EdCentra VIsion Box' and serial number 'VISIM0000'
When I click the Logging option within the [Configure \/] menu
Then the Logging tab is opened in Configure
When I Click on the Create Profile button
Then the Create Profile form is displayed in EdCentra
When I provide a name 'LoggingTest' and select an equipment type'EdCentra VIsion Box' for the profile. Click Create.
Then The form expand and shows the detail tab which lists parameter for the equipment type
When I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta.Click Apply.
| Parameter     | TimeIntervalforNormal | TimeIntervalforAlert | TimeIntervalforDelta |
| Ch1 VI 1 (VI) | 1 Minute              | 1 Hour               | 0                    |
#| Ch1 VI 2 (VI) | 1 Minute              | 1 Hour               | 0                    |
#| Ch1 VI 3 (VI) | 1 Minute              | 1 Hour               | 0                    |
#| Ch1 VI 4 (VI) | 1 Minute              | 1 Hour               | 0                    |
#| Ch1 VI 5 (VI) | 1 Minute              | 1 Hour               | 0                    |
#| Ch1 VI 6 (VI) | 1 Minute              | 1 Hour               | 0                    |
#| Ch1 Scaling   | 1 Minute              | 1 Hour               | 0                    |
#| Ch1 Offset    | 1 Minute              | 1 Hour               | 0                    |
Then The screen will show applied values for Normal / Alert and Delta fields for the parameter.The screen will only list parameters added in profile
| Parameter     |
| Ch1 VI 1 (VI) |
When I click on the Equipments tab
Then I should be navigated to the Equipments tab in the page
When I Find the equipment using equipment description and add Equipments 'viVISIM0000' to Assigned Equipment list using > and >> button then Click Apply
Then the changes have been applied message will be displayed on the screen
When I navigate to Historian -> Equipment Data Select a piece of System and Equipment 'viVISIM0000' that is logging data (and also of which you have another of this exact equipment type)
Then Parameter'Ch1 VI 1 (VI)'listed of which we have data to plot for the Equipment'viVISIM0000'

@SingleServer
Scenario: VI Management Details - Serial and Part Number
Given Open EDCENTRA application URL in the browser
When I enter the username as 'administrator' and password as 'toolkit' and clicked login button
When I click the DeviceExplorer link
Then I should be navigated to the DeviceExplorer page in EdCentra
When I click on the system icon - Add Folder
And I entered the folder name and clicked on Add button 
Then I should be able to see the folder added successfully message
When I clicked the OK button
Then I should be able to see the newly added Folder
When I clicked the Find Equipment
And I delete all the existing Equipments
When I run the VIsimulator to get the VI device communicating with EdCentra
Then I commission the VISimulator as equipment Name 'viVISIM0000' equipmentType 'EdCentra VIsion Box' and serial number 'VISIM0000'
When I click the VI Management option within the [Configure \/] menu
Then I see the VI Management page
When I click on the device and Details tab
Then I verify the serial number of the device as 'VISIM0000'
Then I verify the part number of the device as 'D37700000'


@SingleServer
Scenario: VI Management Administer - Assigned Equipment
Given Open EDCENTRA application URL in the browser
When I enter the username as 'administrator' and password as 'toolkit' and clicked login button
When I click the DeviceExplorer link
Then I should be navigated to the DeviceExplorer page in EdCentra
When I click on the system icon - Add Folder
And I entered the folder name and clicked on Add button 
Then I should be able to see the folder added successfully message
When I clicked the OK button
Then I should be able to see the newly added Folder
When I clicked the Find Equipment
And I delete all the existing Equipments
And I launched Turbo simulator
And I configure Turbo Simulator
And I select an equipmentName 'TURBO4001' equipmentType 'Turbo Pump' device iPPortNumber'4001'.
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I run the VIsimulator to get the VI device communicating with EdCentra
Then I commission the VISimulator as equipment Name 'viVISIM0000' equipmentType 'EdCentra VIsion Box' and serial number 'VISIM0000'
When I click the VI Management option within the [Configure \/] menu
Then I see the VI Management page
When I click on the device, Administer tab and Choose button in Assigned Equipment
Then I see the Linked System 
When I click the Find Equipment button
Then I see the turbo equipment is listed
When I choose the turbo equipment and click OK button
Then I verify the turbo equipment displayed near Choose button in Assigned Equipment of Administer Tab
When I move to Device Explorer and click create commission the VISimulator as equipment Name 'viVISIM0001' equipmentType 'EdCentra VIsion Box' and serial number 'VISIM0001'
Then I click Linked System Choose button and select Turbo pump to see no equipment listed


@SingleServer
Scenario: VI Management Details - Unit Up Time
Given Open EDCENTRA application URL in the browser
When I enter the username as 'administrator' and password as 'toolkit' and clicked login button
When I click the DeviceExplorer link
Then I should be navigated to the DeviceExplorer page in EdCentra
When I click on the system icon - Add Folder
And I entered the folder name and clicked on Add button 
Then I should be able to see the folder added successfully message
When I clicked the OK button
Then I should be able to see the newly added Folder
When I clicked the Find Equipment
And I delete all the existing Equipments
When I run the VIsimulator to get the VI device communicating with EdCentra
Then I commission the VISimulator as equipment Name 'viVISIM0000' equipmentType 'EdCentra VIsion Box' and serial number 'VISIM0000'
When I click the VI Management option within the [Configure \/] menu
Then I see the VI Management page
When I click on the device and Details tab
Then I verify the UnitUpTime of the device updating at regular intervals