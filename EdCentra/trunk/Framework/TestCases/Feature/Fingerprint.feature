Feature: Fingerprint 

Background: 
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
Then I should be navigated to Home page

@SplitServer
@SingleServer
Scenario: Fingerprint - Initiate UI
When Navigated to 'Fingerprint' page
Then I Should be navigated to the Fingerprint page
When I clicked on Home Icon in top navigation menubar
And I navigate to the historian page
Then the Fingerprint option should appear in the menu bar
When I click Fingerprint menu on the historian page
Then I Should be navigated to the Fingerprint page
When I navigate to Fingerprint module by clicking via Diagnostics -> Fingerprint option
Then I Should be navigated to the Fingerprint page
And the heading of the second panel should be "No Equipment Selected"


@SplitServer
@SingleServer
Scenario: Fingerprint - Add and Delete
When I clicked Device Explorer link
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
And I commissioned device with following details 'eZenith', '50000'
And Go to the Diagnostics -> Fingerprint section.
And Expand the folder and Select single Equipment in the tree
Then a message "No Fingerprints found for this system" should appear on the fingerprint section
When I click a new button on the fingerprint page
When I enter a name as 'TestF' and notes as 'test'and then click Add
Then after 60 seconds a message "No data availabe" will appear.
When Launched Eissa and started simulator
When I clicked on Home Icon in top navigation menubar
When I clicked Device Explorer link
And I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When Go to the Diagnostics -> Fingerprint section.
When Select a communicating system 'NEW0001PM1' (recommend iXH) on the left hand side and click the New button.
When I enter a name as 'TestF1' and notes as 'test'and then click Add
When Fingerprint "TestF1" selected in the list
Then Compare Section appears
When A fingerprint "TestF1" selected in the list, click the Delete button.
Then Delete confirmation box shows.
When Click Ok
Then Fingerprint "TestF1" is deleted and removed from the list


Scenario: Fingerprint - Compare
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
When I selected the equipment type, entered equipmentName'NEW0001PM1' 'NEW0001PM2' 'NEW0001AC1', Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When I navigate to Fingerprint module
When Select a communicating system 'NEW0001PM1' (recommend iXH) on the left hand side and click the New button.
When I enter a name as 'TestF1' and notes as 'test'and then click Add
And Fingerprint "TestF1" selected in the list
Then Compare Section appears
And the Fingerprint Details columns are displayed in the following order
	| Columns       |
	| System        |
	| Fingerprint   |
	| Type          |
	| Date          |
	| Serial Number |
	| Note          |
And the following fingerprint Details are displayed in the Compare Section
	| System Name | Fingerprint Name | Type        | Serial Number | Note |
	| NEW0001PM1  | TestF1           | iXH DryPump |               | test |
And the following parameter details are displayed in the compare section
	| ParameterName    | FingerprintParameterValue | Fingerprint2ParameterValue | Delta | Unit |
	| Dry Pump Control |  Starting                  |                           |       |      |
When I click a new button on the fingerprint page
And I enter a name as 'TestF2' and notes as 'test'and then click Add
And Fingerprint "TestF2" selected in the list
Then the following fingerprint Details are displayed in the Compare Section
	| System Name | Fingerprint Name | Type        | Serial Number | Note |
	| NEW0001PM1  | TestF1           | iXH DryPump |               | test |
	| NEW0001PM1  | TestF2           | iXH DryPump |               | test |
When I click a new button on the fingerprint page
When I enter a name as 'TestF3' and notes as 'test'and then click Add
And Fingerprint "TestF3" selected in the list
Then the following fingerprint Details are displayed in the Compare Section
	| System Name | Fingerprint Name | Type        | Serial Number | Note |
	| NEW0001PM1  | TestF1           | iXH DryPump |               | test |
	| NEW0001PM1  | TestF3           | iXH DryPump |               | test |
When Click the Export button
Then The browser should download a .csv file
When I open the csv file then following details should be displayed in the header of the compare section
	| System Name | Fingerprint Name | Type        | Serial Number | Note |
	| NEW0001PM1  | TestF1           | iXH DryPump |               | test |
	| NEW0001PM1  | TestF3           | iXH DryPump |               | test |
And Select a communicating system 'NEW0001AC1' (recommend iXH) on the left hand side and click the New button.
And I enter a name as 'TestF4' and notes as 'test'and then click Add
And Fingerprint "TestF4" selected in the list
Then the following fingerprint Details are displayed in the Compare Section
	| System Name | Fingerprint Name | Type            | Serial Number               | Note |
	| NEW0001AC1  | TestF4           | Atlas Abatement | Test:PCA Serial Number0 1,5 | test |
When I Click Clear Button
Then Compare section disappears and Add a fingerprint to begin message appears


Scenario: Fingerprint - Fingerprint Updates
When I Change User Preference
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
And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'NEW0001PM1' and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When Go to the Diagnostics -> Fingerprint section.
Then Fingerprint page launches.
When Select a communicating system 'NEW0001PM1' (recommend iXH) on the left hand side and click the New button.
Then New Fingerprint panel is displayed
When Enter a name 'Firstfingerprint' and then enter thousand characters in the notes field then click Add.
Then The time it takes to add the fingerprint 'Firstfingerprint' should be sixtyseconds as it gathers the parameter data.
When Click the new fingerprint 'Firstfingerprint' in the list.
Then the following fingerprint Details are displayed in the Compare Section
	| System Name |    Fingerprint Name    | Type        | Serial Number |     Note           |
	| NEW0001PM1  |   Firstfingerprint     | iXH DryPump |               |  1000Characters    |
When Hover over the note icon for the new fingerprint.
Then A tooltip should show containing what you entered earlier.
When Open the User Preferences panel
And Observe the unit preference that Temperature is set to and close the panel.
Then Any parameters that are Temperatures should be displayed with the unit that is set in the User Preferences.
When Click the Export button
Then The browser should download a .csv file
Then Open the csv file and check the following values are displayed in the parameter detail section
	| Parameter Name | Fingerprint ParameterValue | Unit |
	| MB Temp        | 1                          | K    | 
When Open the User Preferences panel again
And change the Temperature unit to something else and click Apply.
When Click the Export button
Then The browser should download a .csv file
Then Open the csv file and check the following values are displayed in the parameter detail section
	| Parameter Name | Fingerprint ParameterValue | Unit |
	| MB Temp        | -272.15                    | C    |
When using EISSA, change the parameters '54          (MB Temp)' value to '200' '13          (Seals Purge)' value to '0' '14          (DP Run Hours)' value to '0'
When Create another fingerprint 'SecondFingerprint', using system 'NEW0001PM1' of the same type
Then After sixty seconds where it gathers the parameters a new fingerprint 'SecondFingerprint' is created.
When If you don`t currently have the first fingerprint selected please click on it. Then select the second fingerprint 'SecondFingerprint' by clicking it too.
Then Fingerprints 'Firstfingerprint' '1' 'SecondFingerprint' are marked with '2' and show their details and parameters in the main right-hand pane.
Then Compare Section appears
Then the Parameter Details columns are displayed in the following order
	| Columns                        |
	| Parameter                      |
	| NEW0001PM1 (Firstfingerprint)  |
	| Delta                          |
	| NEW0001PM1 (SecondFingerprint) |
	| Unit                           |
And the following parameter details are displayed in the compare section
	| ParameterName    | FingerprintParameterValue | Fingerprint2ParameterValue | Delta | Unit |
	| Dry Pump Control | Starting                  | Starting                   | =     |      |
	| MB Temp          | 1                         | 200                        | +199  | K    |
	| DP Run Hours     | 1                         | 0                          | -1    |      |
	| Seals Purge      | Off Going On              | Off                        | ≠     |      |
When A fingerprint "SecondFingerprint" selected in the list, click the Delete button.
Then Delete confirmation box shows.
When Click Cancel
Then Delete confirmation box closes and fingerprint is NOT deleted.
When Click the Delete button again.
Then Delete confirmation box shows.
When Click Ok
Then Fingerprint "SecondFingerprint" is deleted and removed from the list
