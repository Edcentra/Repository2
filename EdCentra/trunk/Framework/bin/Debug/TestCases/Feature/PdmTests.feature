Feature: PdmTests
	
Background:
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
#Given Opened the EDCENTRA application url in browser
#When I entered 'administrator' and 'toolkit' and clicked login button
#When I Enter the username as 'administrator' and password a*******kit' and Clicked login button
#Then I Should be Navigated to the home page
When Clicked on PDM link
Then  I should be navigated to PDM page
And copied site activation key available in the clipboard

@Pdm
Scenario: Licensing - Generate a license from single algorithm
Given Launched License Genrator
And Selected latest database 
When entered general settings fields i.e. Max Assignment Count '25',Equipment Type 'Atlas Abatement' & Author Name 'PdmTestUser'
And  filled algorithmName 'SingleAlgorithm', algTypeCode 'Noz1', Max Assignment Count '25', algorithm File 'MdxN3Compressed_VG04_Alarm.xml' & visualization File 'VisualisationXML_Algorithm.txt'
And clicked Generate License button
Then License should be generated for 'SingleAlgorithm.alf'

@Pdm
Scenario: Licensing- Generate a license from Web UI for multi algorithm
Given Launched License Genrator
And Selected latest database 
When entered general settings fields i.e. Max Assignment Count '25',Equipment Type 'Atlas Abatement' & Author Name 'PdmTestUser'
And  filled algorithmName 'MultiAlgo1', algTypeCode 'Noz1', Max Assignment Count '25', algorithm File 'MdxN3Compressed_VG04_Alarm.xml' & visualization File 'VisualisationXML_Algorithm.txt'
And  filled algorithmName 'MultiAlgo2', algTypeCode 'Noz2', Max Assignment Count '25', algorithm File 'MdxN3Compressed_VG04_Warning.xml' & visualization File 'VisualisationXML_Algorithm.txt'
And clicked Generate License button
Then License should be generated for 'MultipleAlgorithm.alf'

@Pdm
Scenario: Licensing-Upload a license from Web UI for multi algorithm
When entered App Name 'MultiAlgoDemoAPP'
And clicked on Import App button
And selected the algorithm license file 'MultipleAlgorithm.alf' created in previous test and upload the license file
Then License File uploaded successfully for app 'MultiAlgoDemoAPP' with algorithms 'MultiAlgo1 :: MultiAlgoDemoAPP' and 'MultiAlgo2 :: MultiAlgoDemoAPP'

@Pdm
Scenario: Licensing-Upload a license from Web UI for single algorithm
When entered App Name 'SingleAlgoDemoAPP'
And clicked on Import App button
And selected the algorithm license file 'SingleAlgorithm.alf' created in previous test and upload the license file
Then License File uploaded successfully for app 'SingleAlgoDemoAPP' with algorithm 'SingleAlgorithm :: SingleAlgoDemoAPP' 

@Pdm
Scenario: Algmanagement-Associate equipment to Algorithm
When entered App Name 'SingleAlgoDemoApp'
And clicked on Import App button
And selected the algorithm license file 'SingleAlgorithm.alf' created in previous test and upload the license file
And navigated to Import page
And entered App Name 'MultiAlgoDemoAPP'
And clicked on Import App button
And selected the algorithm license file 'MultipleAlgorithm.alf' created in previous test and upload the license file
And Launched DSPU simulator and Executed scenario 'MdxN3N4N5Scenario.xml' 'DSPU_MdxN3N4N5Compressed.csv' 'Dspu Output for MdxN3N4N5.csv' '25'
And Select the uploaded App name 'SingleAlgoDemoApp' from dropdown
And Clicked on the View Details
Then App name 'SingleAlgoDemoApp' selected successfully
When Select algorithm 'SingleAlgorithm :: SingleAlgoDemoApp' associated to that App
Then Algorithm 'SingleAlgorithm :: SingleAlgoDemoApp'selected
When Search for equipment using search box and select one by one
Then List of equipments 'MdxN3N4N5VG2002' are shown in left side list box control.
When Use > button for addition of equipment 'MdxN3N4N5VG2001'
Then Selected equipment 'MdxN3N4N5VG2001' is added to right side list box control
When Press Apply button
Then Changes are saved and equipment associated to app successfully.
When Select the uploaded App name 'MultiAlgoDemoAPP' from dropdown
And Clicked on the View Details
Then App name 'MultiAlgoDemoAPP' selected successfully
When Select algorithm 'MultiAlgo1 :: MultiAlgoDemoAPP' associated to that App
Then Algorithm 'MultiAlgo1 :: MultiAlgoDemoAPP'selected
When Search for equipment using search box and select one by one
Then List of equipments 'MdxN3N4N5VG2002' are shown in left side list box control.
When Use > button for addition of equipments 'MdxN3N4N5VG2002' 'MdxN3N4N5VG2003'
Then Selected equipment 'MdxN3N4N5VG2003' is added to right side list box control
When Press Apply button
Then Changes are saved and equipment associated to app successfully.

@Pdm
Scenario: Algmanagement-Associate equipment to App
When entered App Name 'MultiAlgoDemoAPP'
And clicked on Import App button
And selected the algorithm license file 'MultipleAlgorithm.alf' created in previous test and upload the license file
Then License File uploaded successfully for app 'MultiAlgoDemoAPP' with algorithms 'MultiAlgo1 :: MultiAlgoDemoAPP' and 'MultiAlgo2 :: MultiAlgoDemoAPP'
When Launched DSPU simulator and Executed scenario 'MdxN3N4N5Scenario.xml' 'DSPU_MdxN3N4N5Compressed.csv' 'Dspu Output for MdxN3N4N5.csv' '25'
And Select the uploaded App name 'MultiAlgoDemoAPP' from dropdown
And Clicked on the View Details
And Search for equipment using search box and select one by one
Then List of equipments 'MdxN3N4N5VG2002' are shown in left side list box control.
When Use > button for addition of equipment 'MdxN3N4N5VG2001'
Then Selected equipment 'MdxN3N4N5VG2001' is added to right side list box control
When Press Apply button
Then Changes are saved and equipment associated to app successfully.
And All the algorithms 'MultiAlgo1 :: MultiAlgoDemoAPP' & 'MultiAlgo2 :: MultiAlgoDemoAPP' associated with the App have the same equipments 'MdxN3N4N5VG2001'.

@Pdm
Scenario: Licensing-Delete App License File using single/multiple algorithm
When entered App Name 'SingleAlgoDemoAPP'
And clicked on Import App button
When selected the algorithm license file 'SingleAlgorithm.alf' created in previous test and upload the license file
Then License File uploaded successfully for app 'SingleAlgoDemoAPP' with algorithm 'SingleAlgorithm :: SingleAlgoDemoAPP'
When Launched DSPU simulator and Executed scenario 'MdxN3N4N5Scenario.xml' 'DSPU_MdxN3N4N5Compressed.csv' 'Dspu Output for MdxN3N4N5.csv' '25'
And Select the uploaded App name 'SingleAlgoDemoApp' from dropdown
And Clicked on the View Details
And Search for equipment using search box and select one by one
Then List of equipments 'MdxN3N4N5VG2002' are shown in left side list box control.
When Use > button for addition of equipment 'MdxN3N4N5VG2001'
Then Selected equipment 'MdxN3N4N5VG2001' is added to right side list box control
When Press Apply button
Then Changes are saved and equipment associated to app successfully.
When Dissociate all the equipments assigned to App 'SingleAlgoDemoApp' algorithm if any
Then Equipments'MdxN3N4N5VG2001' are Dissociated successfully
When Press Delete button
Then Alert shown with message "This app and its algorithms will be permanently deleted. Are you sure?"
When Press Cancel
Then Returns to same page
When Press app 'SingleAlgoDemoApp' Delete button
Then Delete this app shown
When Press Delete item
Then Delete the app with algorithms 'SingleAlgorithm :: SingleAlgoDemoApp' successfully
And App name 'SingleAlgoDemoApp' should disappear from the list

@Pdm
Scenario: Licensing-Update App License File using single algorithm
When entered App Name 'SingleAlgoDemoApp'
And clicked on Import App button
And selected the algorithm license file 'AlarmAlgorithm.alf' created in previous test and upload the license file
Then License File uploaded successfully for app 'SingleAlgoDemoApp' with algorithm 'AlarmAlgorithm :: SingleAlgoDemoApp'
When navigated to home page and clicked device explorer link
Then Should be navigated to Device Explorer page
When Clicked on add folder/ system icon 
And  entered folder name and clicked on Add button 
Then should be able to see folder added successfully message 
When clicked Ok button 
Then should be able to see newly added Folder 
When clicked find equipment 
And deleted all Equipments
When Launched DSPU simulator and Execute scenario 'DSPU_FvxN2VG2.xml' 'DSPU_FVX23913AcN2_UpdateTest.csv' 'DSPU Output for FvxN2VG2.csv' '2'
And I entered Equipment name, selected equipmentType 'All', Cliked Find Equipment button, selected equipment 'FvxN2updateVG1'
Then Navigate to PdM Page
When Select the uploaded App name 'SingleAlgoDemoApp' from dropdown
And Clicked on the View Details
And Search for equipment using search box and select one by one
Then List of equipments 'FvxN2updateVG2' are shown in left side list box control.
When Use > button for addition of equipment 'FvxN2updateVG1'
Then Selected equipment 'FvxN2updateVG1' is added to right side list box control
When Press Apply button
Then Changes are saved and equipment associated to app successfully.
When Start DSPU Scenario 'DSPU_FvxN2VG2.xml'
And Check for alerts on Web UI.
Then Alarm alerts are displayed on the Web UI
When Restore scada 'DSPU_FvxN2VG2.xml' and stop scenario once execution got closed
And Open the App license 'AlarmAlgorithm.alf' in license generator tool.
#Then GUID noted in step one should be shown.
And Update the xml use warning alert model 'FVX23913AcN2_UpdateTestV1.xml' and expiry date and generate the new 'WarningAlgorithm.alf' App license.
Then New app license 'WarningAlgorithm.alf' with updated details is created
When Refresh page and switch to PdM license page
And entered App Name 'WarningAlgoDemoAPP'
And clicked on Import App button
And selected the algorithm license file 'WarningAlgorithm.alf' created in previous test and upload the license file
Then Ensure it prompts for Update, Create New and Cancel.
When Click on Update button.
Then License is updated successfully.
When Check the expiry date on Web UI.
Then Ensure that the expiry date is updated successfully.
When Run DSPU scenario 'DSPU_FvxN2VG2.xml' and check the alerts.
Then warning alerts are observed then model xml is updated successfully otherwise fail the test.
And Ensure that on perfroming license 'AlarmAlgoDemoAPP' update, the associated equipments'FvxN2updateVG1' will not change.

@Pdm
Scenario: Algmanagement- Manual reset App with Multi algorithm
When entered App Name 'MultiAlgoDemoAPP'
And clicked on Import App button
And selected the algorithm license file 'MultipleAlgorithm.alf' created in previous test and upload the license file
And navigated to home page and clicked device explorer link
Then Should be navigated to Device Explorer page
When Clicked on add folder/ system icon 
And  entered folder name and clicked on Add button 
Then should be able to see folder added successfully message
When clicked Ok button 
Then should be able to see newly added Folder 
When clicked find equipment 
And deleted all Equipments
And Launched DSPU simulator and Executed scenario 'MdxN3N4N5Scenario.xml' 'DSPU_MdxN3N4N5Compressed.csv' 'Dspu Output for MdxN3N4N5.csv' '25'
And I entered Equipment name, selected equipmentType 'All', Cliked Find Equipment button, selected equipment 'MdxN3N4N5VG2001' 'MdxN3N4N5VG2002' 'MdxN3N4N5VG2003' and clicked Add button.
And navigated to PDM page
And Select the uploaded App name 'MultiAlgoDemoAPP' from dropdown
And Clicked on the View Details
When Search for equipment using search box and select one by one
Then List of equipments 'MdxN3N4N5VG2002' are shown in left side list box control.
When Use > button for addition of equipment 'MdxN3N4N5VG2001'
Then Selected equipment 'MdxN3N4N5VG2001' is added to right side list box control
When Press Apply button
Then Changes are saved and equipment associated to app successfully.
When Search for equipment using search box and select one by one
Then List of equipments 'MdxN3N4N5VG2002' are shown in left side list box control.
When Use > button for addition of equipment 'MdxN3N4N5VG2001'
Then Selected equipment 'MdxN3N4N5VG2001' is added to right side list box control
When Press Apply button
Then Changes are saved and equipment associated to app successfully.
And Alerts to be shown on screen
When Select the uploaded App name 'MultiAlgoDemoAPP' from dropdown
And Clicked on the View Details
And Selected previously added 'MdxN3N4N5VG2001' equipment
And clicked Reset button
Then Dialog box appear with message 'Reset app for the above systems?'
When Pressed Reset button on the dialog box
Then '1 of 1 systems reset.' message appeared
When Closed pop up
Then All active alerts associated with selected equipments should disapper

@Pdm
Scenario: Algmanagement- Manual reset App with Single algorithm
When entered App Name 'SingleAlgoDemoApp'
And clicked on Import App button
And selected the algorithm license file 'SingleAlgorithm.alf' created in previous test and upload the license file
And navigated to home page and clicked device explorer link
Then Should be navigated to Device Explorer page
When Clicked on add folder/ system icon 
And  entered folder name and clicked on Add button 
Then should be able to see folder added successfully message
When clicked Ok button 
Then should be able to see newly added Folder 
When clicked find equipment 
And deleted all Equipments
When Launched DSPU simulator and Executed scenario 'MdxN3N4N5Scenario.xml' 'DSPU_MdxN3N4N5Compressed.csv' 'Dspu Output for MdxN3N4N5.csv' '25'
And  added 'MdxN3N4N5VG2001' device.
And navigated to PDM page
And Select the uploaded App name 'SingleAlgoDemoApp' from dropdown
And Clicked on the View Details
And Search for equipment using search box and select one by one
Then List of equipments 'MdxN3N4N5VG2002' are shown in left side list box control.
When Use > button for addition of equipment 'MdxN3N4N5VG2001'
Then Selected equipment 'MdxN3N4N5VG2001' is added to right side list box control
When Press Apply button
Then Changes are saved and equipment associated to app successfully.
When Search for equipment using search box and select one by one
Then List of equipments 'MdxN3N4N5VG2002' are shown in left side list box control.
When Use > button for addition of equipment 'MdxN3N4N5VG2001'
Then Selected equipment 'MdxN3N4N5VG2001' is added to right side list box control
When Press Apply button
Then Changes are saved and equipment associated to app successfully.
Then Alerts to be shown on screen
When Select the uploaded App name 'SingleAlgoDemoApp' from dropdown
And Clicked on the View Details
And Selected previously added 'MdxN3N4N5VG2001' equipment
And clicked Reset button
Then Dialog box appear with message 'Reset app for the above systems?'
When Pressed Reset button on the dialog box
Then '1 of 1 systems reset.' message appeared
When Closed pop up
Then All active alerts associated with selected equipments should disapper




