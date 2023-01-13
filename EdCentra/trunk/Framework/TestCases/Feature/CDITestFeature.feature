Feature: CDITest
The ability to restrict access control to CDI configuration tool by requesting authenticating PIN code to unlock access.

Background:
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
When I clicked Device Explorer link
Then I should be navigated to Device Explorer page

@ApplicationServer
@SingleServer
Scenario: CDI Config Tool to have simple authentication
When We have access to EdCentra new version installation environment
Then EdCentra is installed sucessfully, which also contains CDI EXPORT by default.
When Run CDI_Win.exe which is normally located in Local drive
Then CDI config tool (CDI_Win) presents a login window requesting login entry.
When valid Password is provided, the user is presented with the main application window.
	|   userName  | password |
	|Administrator|  toolkit |
And I Close the CDI window
Then user attempts three invalid PIN codes, the login process is terminated.
	| userName      | password1 | password2 | password3 |
	| Administrator | Toolkit   | !Toolkit  | !kittool  |


@ApplicationServer
@SingleServer
Scenario: Verify CDI Jobs in SQL and CDI in Maintenance Logs
When I launch SQl Server Managment Studio
And using SQL Management Studio, log on with sa accounts using SQL Server Authentication 
And I expand 'SQL Server Agent' in Database
Then the Jobs "EADS | Generate Daily Execution" and "EADS | Run Data Export Executions" should exist under Sql Server Agent
And check CDI folder exists under 'G:\fs_maintenance'
And check packages folder exists under 'D:\Edwards'

@ApplicationServer
@SingleServer
Scenario:A CDI Export should not run if equipment filter not set up
When Run CDI_Win.exe which is normally located in Local drive
Then CDI config tool (CDI_Win) presents a login window requesting login entry.
When valid Password is provided, the user is presented with the main application window.
	|   userName  | password |
	|Administrator|  toolkit |
When I click on Daily Equipment Filter
And I remove all the equipment filters if exist
When I launch SQl Server Managment Studio
And using SQL Management Studio, log on with sa accounts using SQL Server Authentication 
And I expand 'SQL Server Agent' in Database
And run the Job "EADS | Generate Daily Execution" manually
Then there should not be any entry in Daily Data Export
And there should not be any data export folder exist in directory "G:\fs_Maintenance\CDI\CDI_Export"
And open the file "G:\fs_Maintenance\CDI\GenerateDailyExecution.txt" and check the text "Equipment Fitler for Daily Export is not setup." exists

@ApplicationServer
@SingleServer
Scenario: Verify Zipping functionality in Edcentra CDI
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
When Run CDI_Win.exe which is normally located in Local drive
Then CDI config tool (CDI_Win) presents a login window requesting login entry.
When valid Password is provided, the user is presented with the main application window.
	|   userName  | password |
	|Administrator|  toolkit |
When I click on Daily Equipment Filter
And I add the equipments to the Daily Equipment Filter
When I Click on Adhoc Equipment Filter
And I add the equipments to the Adhoc Equipment Filter
And I click on the Adhoc Data Export
And I select the application Id from the combo box
And I click on the Create Data Export button
When I launch SQl Server Managment Studio
And using SQL Management Studio, log on with sa accounts using SQL Server Authentication 
And I expand 'SQL Server Agent' in Database
And run the Job "EADS | Generate Daily Execution" manually by right clicking and selecting 'Start Job at Step...'
Then the zip file exists for Adhoc Data Export in 'G:\fs_maintenance\CDI\CDI_Export'
And the zip file exists for Daily Data Export in 'G:\fs_maintenance\CDI\CDI_Export' 


@ApplicationServer
@SingleServer
Scenario: Verify table names obfuscated in CDI Export files
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
When Run CDI_Win.exe which is normally located in Local drive
Then CDI config tool (CDI_Win) presents a login window requesting login entry.
When valid Password is provided, the user is presented with the main application window.
	|   userName  | password |
	|Administrator|  toolkit |
When I click on Daily Equipment Filter
And I add the equipments to the Daily Equipment Filter
When I Click on Adhoc Equipment Filter
And I add the equipments to the Adhoc Equipment Filter
And I click on the Adhoc Data Export
And I select the application Id from the combo box
And I click on the Create Data Export button
When I launch SQl Server Managment Studio
And using SQL Management Studio, log on with sa accounts using SQL Server Authentication 
And I expand 'SQL Server Agent' in Database
And run the Job "EADS | Generate Daily Execution" manually by right clicking and selecting 'Start Job at Step...'
Then the zip file exists for Adhoc Data Export in 'G:\fs_maintenance\CDI\CDI_Export'
When I Unzip the Adhoc Data Export file
Then the table names in the Adhoc Export files are obfuscated

Scenario: Adding the option to change daily exports to weekly.
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
When Run CDI_Win.exe which is normally located in Local drive
Then CDI config tool (CDI_Win) presents a login window requesting login entry.
When valid Password is provided, the user is presented with the main application window.
|  userName  | password |
|Administrator|  toolkit |
When I click on Daily Equipment Filter
And I add the equipments to the Daily Equipment Filter
When I launch SQl Server Managment Studio
And using SQL Management Studio, log on with sa accounts using SQL Server Authentication 
And I expand 'SQL Server Agent' in Database
And run the Job "EADS | Generate Daily Execution" manually by right click and selecting 'Start Job at Step...'
Then the zip file exists for Daily Data Export in 'G:\fs_maintenance\CDI\CDI_Export' 
When Select Job Schedule from the config menu.
Then SQL job Scheduler GUI dialog is opened.
When Select Job 'EADS | Generate Daily Execution' then Schedules 'TestingSchedule' and Click Edit button.
Then The Edit Schedule 'Edit Schedule' dialog box is opened for the selected schedule.
Then The Edit Schedule 'CDI_Export_Dynamic' dialog box is opened for the selected schedule.
When configure the schedule 'CDI_Export_Dynamic'

@ApplicationServer
@SingleServer
Scenario: Verify column names obfuscated in CDI Export files
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
When Run CDI_Win.exe which is normally located in Local drive
Then CDI config tool (CDI_Win) presents a login window requesting login entry.
When valid Password is provided, the user is presented with the main application window.
	|   userName  | password |
	|Administrator|  toolkit |
When I click on Daily Equipment Filter
And I add the equipments to the Daily Equipment Filter
When I Click on Adhoc Equipment Filter
And I add the equipments to the Adhoc Equipment Filter
And I click on the Adhoc Data Export
And I select the application Id from the combo box
And I click on the Create Data Export button
When I launch SQl Server Managment Studio
And using SQL Management Studio, log on with sa accounts using SQL Server Authentication 
And I expand 'SQL Server Agent' in Database
And run the Job "EADS | Generate Daily Execution" manually by right clicking and selecting 'Start Job at Step...'
Then the zip file exists for Adhoc Data Export in 'G:\fs_maintenance\CDI\CDI_Export'
And the zip file exists for Daily Data Export in 'G:\fs_maintenance\CDI\CDI_Export' 
When I Unzip the Adhoc Data Export file
Then the table names in the Adhoc Export files are obfuscated
And the column names in the Adhoc Export file are obfuscated
When I Unzip the Daily Data Export file
Then the table names in the Daily Export files are obfuscated
And the column names in the Daily Export files are obfuscated


@ApplicationServer
@SingleServer
Scenario: Add System Swap out Information to CDI extracts
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
When Run CDI_Win.exe which is normally located in Local drive
Then CDI config tool (CDI_Win) presents a login window requesting login entry.
When valid Password is provided, the user is presented with the main application window.
	|   userName  | password |
	|Administrator|  toolkit |
When I click on Daily Equipment Filter
And I add the equipments to the Daily Equipment Filter
When I Click on Adhoc Equipment Filter
And I add the equipments to the Adhoc Equipment Filter
And I click on the Adhoc Data Export
And I select the application Id from the combo box
And I click on the Create Data Export button
Then the zip file exists for Adhoc Data Export in 'G:\fs_maintenance\CDI\CDI_Export'
When I Unzip the Adhoc Data Export file
Then the table names in the Adhoc Export files are obfuscated
And the column names in the Adhoc Export file are obfuscated
When Create a CDI Import folder
And I Copy CDI Exported files to CDI Import folder
When I extract file in CDI Import folder using command
Then the file "fst_GEN_SystemSerialNumber_cache.csv" should exist in CDI Adhoc import files

Scenario: Model XML information needs to be omitted in CDI export files
When Clicked on PDM link
Then I should be navigated to PDM page
And copied site activation key available in the clipboard
Given Launched License Genrator
And Selected latest database 
When entered general settings fields i.e. Max Assignment Count '25',Equipment Type 'Atlas Abatement' & Author Name 'PdmTestUser'
And  filled algorithmName 'SingleAlgorithm', algTypeCode 'Noz1', Max Assignment Count '25', algorithm File 'MdxN3Compressed_VG04_Alarm.xml' & visualization File 'VisualisationXML_Algorithm.txt'
And clicked Generate License button
Then License should be generated for 'SingleAlgorithm.alf'
When entered App Name 'SingleAlgoDemoApp'
And clicked on Import App button
And selected the algorithm license file 'SingleAlgorithm.alf' created in previous test and upload the license file
Then License File uploaded successfully for app 'SingleAlgoDemoApp' with algorithm 'SingleAlgorithm :: SingleAlgoDemoApp'
When navigated to home page and clicked device explorer link
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment	
And deleted all equipments
When Launched DSPU simulator and Execute scenario 'DSPU_FvxN2VG2.xml' 'DSPU_FVX23913AcN2_UpdateTest.csv' 'DSPU Output for FvxN2VG2.csv' '2'
And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'FvxN2updateVG1' and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
Then Navigate to PdM Page
When Select the uploaded App name 'SingleAlgoDemoApp' from dropdown
And Clicked on the View Details
And Search for equipment using search box and select one by one
Then List of equipments 'FvxN2updateVG2' are shown in left side list box control.
When Use > button for addition of equipment 'FvxN2updateVG1'
Then Selected equipment 'FvxN2updateVG1' is added to right side list box control
When Press Apply button
Then Changes are saved and equipment associated to app successfully.
When Run CDI_Win.exe which is normally located in Local drive
Then CDI config tool (CDI_Win) presents a login window requesting login entry.
When valid Password is provided, the user is presented with the main application window.
	|   userName  | password |
	|Administrator|  toolkit |
When I click on Daily Equipment Filter
And I add the equipments to the Daily Equipment Filter
When I Click on Adhoc Equipment Filter
And I add the equipments to the Adhoc Equipment Filter
And I click on the Adhoc Data Export
And I select the application Id from the combo box
And I click on the Create Data Export button
When I launch SQl Server Managment Studio
And using SQL Management Studio, log on with sa accounts using SQL Server Authentication 
And I expand 'SQL Server Agent' in Database
And run the Job "EADS | Generate Daily Execution" manually by right clicking and selecting 'Start Job at Step...'
Then the zip file exists for Adhoc Data Export in 'G:\fs_maintenance\CDI\CDI_Export'
When Create a CDI Import folder
And I Copy CDI Exported files to CDI Import folder
When I extract file in CDI Import folder using command
When The folder 'pdm_probe' have file 'tbl_Model_Configuration.csv' should exist in CDI Adhoc import files
Then Column Encrypted_XML in tbl_Model_Configuration.csv is '<removed>'
When The folder 'pdm_config' have file 'eads_profile.csv' should exist in CDI Adhoc import files
Then Column model_xm in model_xml.csv is '<removed>'
When The folder 'pdm_config' have file 'eads_activity_response.csv' should exist in CDI Adhoc import files
Then Column eads_activity_response in eads_activity_response.csv is '<removed>'

@ApplicationServer
@SingleServer
Scenario: Verify that files are exported correctly
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
When Run CDI_Win.exe which is normally located in Local drive
Then CDI config tool (CDI_Win) presents a login window requesting login entry.
When valid Password is provided, the user is presented with the main application window.
	|   userName  | password |
	|Administrator|  toolkit |
When I click on Daily Equipment Filter
And I add the equipments to the Daily Equipment Filter
When I Click on Adhoc Equipment Filter
And I add the equipments to the Adhoc Equipment Filter
And I click on the Adhoc Data Export
And I select the application Id from the combo box
And I click on the Create Data Export button
When I launch SQl Server Managment Studio
And using SQL Management Studio, log on with sa accounts using SQL Server Authentication 
And I expand 'SQL Server Agent' in Database
And run the Job "EADS | Generate Daily Execution" manually by right clicking and selecting 'Start Job at Step...'
Then the zip file exists for Adhoc Data Export in 'G:\fs_maintenance\CDI\CDI_Export'
And the zip file exists for Daily Data Export in 'G:\fs_maintenance\CDI\CDI_Export' 
When I Unzip the Adhoc Data Export file
Then the no.of files exported for Adhoc Export from scada production should be 43
And the no.of files exported for Adhoc Export from pdm config should be 21
And the no. of files exported for Adhoc Export from pdm probe should be 13
When I Unzip the Daily Data Export file
Then the no.of files exported for Daily Export from scada production should be 43
And the no.of files exported for Daily Export from pdm config should be 21
And the no. of files exported for Daily Export from pdm probe should be 13

Scenario: CDI Tool Daily Extract is extracting one day extra it appears
When Clicked on PDM link
Then I should be navigated to PDM page
And copied site activation key available in the clipboard
Given Launched License Genrator
And Selected latest database 
When entered general settings fields i.e. Max Assignment Count '25',Equipment Type 'Atlas Abatement' & Author Name 'PdmTestUser'
And  filled algorithmName 'SingleAlgorithm', algTypeCode 'Noz1', Max Assignment Count '25', algorithm File 'MdxN3Compressed_VG04_Alarm.xml' & visualization File 'VisualisationXML_Algorithm.txt'
And clicked Generate License button
Then License should be generated for 'SingleAlgorithm.alf'
When entered App Name 'SingleAlgoDemoApp'
And clicked on Import App button
And selected the algorithm license file 'SingleAlgorithm.alf' created in previous test and upload the license file
Then License File uploaded successfully for app 'SingleAlgoDemoApp' with algorithm 'SingleAlgorithm :: SingleAlgoDemoApp'
When navigated to home page and clicked device explorer link
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment	
And deleted all equipments
When Launched DSPU simulator and Execute scenario 'DSPU_FvxN2VG2.xml' 'DSPU_FVX23913AcN2_UpdateTest.csv' 'DSPU Output for FvxN2VG2.csv' '2'
And I entered Equipment name, selected equipmentType'All', Cliked Find Equipment button, selected one equipmentName'FvxN2updateVG1' and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
Then Navigate to PdM Page
When Select the uploaded App name 'SingleAlgoDemoApp' from dropdown
And Clicked on the View Details
And Search for equipment using search box and select one by one
Then List of equipments 'FvxN2updateVG2' are shown in left side list box control.
When Use > button for addition of equipment 'FvxN2updateVG1'
Then Selected equipment 'FvxN2updateVG1' is added to right side list box control
When Press Apply button
Then Changes are saved and equipment associated to app successfully.
When Run CDI_Win.exe which is normally located in Local drive
Then CDI config tool (CDI_Win) presents a login window requesting login entry.
When valid Password is provided, the user is presented with the main application window.
	|   userName  | password |
	|Administrator|  toolkit |
When I click on Daily Equipment Filter
And I add the equipments to the Daily Equipment Filter
When I Click on Adhoc Equipment Filter
And I add the equipments to the Adhoc Equipment Filter
And I click on the Adhoc Data Export
And I select the application Id from the combo box
And I click on the Create Data Export button
When I launch SQl Server Managment Studio
And using SQL Management Studio, log on with sa accounts using SQL Server Authentication 
And I expand 'SQL Server Agent' in Database
And run the Job "EADS | Generate Daily Execution" manually by right clicking and selecting 'Start Job at Step...'
Then the zip file exists for Adhoc Data Export in 'G:\fs_maintenance\CDI\CDI_Export'
When Create a CDI Import folder
And I Copy CDI Exported files to CDI Import folder
When I extract file in CDI Import folder using command
When The folder 'scada_Production' have file 'fst_REP_SystemRunningTimeSummaryByDate.csv' should exist in CDI Adhoc import files
Then Each day's extraction contains data for that day for values, statuses, alerts for scada_Production export




