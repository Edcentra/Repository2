Feature: SetupTests
	Verfiry Enable as many different agent types as possible.

Background: 
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
Then Change the User Preference

@mytag
@SetUp
@SingleServer
Scenario: Setup - Some Web Devices Data
When I clicked Device Explorer link
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
When Launch the EISSA tool and specify ten devices with six pumps
Then Ensure that Log is checked on the EISSA screen
When Click on the green play button
And I commissioned device with following details 'eZenith', '50000'
Then Log entries in the log window, eventually served: Equipment log entries
When Uncheck Log
Then The log window to stop refreshing
When Click on Edit -> Adjustables
Then The adjustables window to show
When Use the [Load] button to load the adjustables file 'EISSASystemTestConfiguration_Adjustables.adj'
Then The file to load and show entries '35 (TE406 Combustor Temperature)' '70 (Sleep Request)' '12 (Booster Control)' '174 (MB Inverter Speed)' '941 (External TMS Zone 7 Power)' '936 (External TMS Zone 6 Temp)'in the grid

@SetUp
@SingleServer
Scenario Outline: Setup - Some Turbo Devices Data
When Start the turbo simulator and get it to start listening on ports
Then The simulator should spin up and, once the port range has been entered, show something again and minimize
When I clicked Device Explorer link
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
And Login to FabWorks and show the Turbo '<equipmentType>' creation test script
Then You should be presented with the opportunity to enter the following details
When Enter the data as equipment Name 'T4000' equipmentType 'Turbo Pump' device iPPortNumber'4000'
Then The turbo devices should be created. Messages should be shown in the Turbo Simulator indicating that connections are being made
When Use Device Explorer and create a folder named then add as many turbos'<equipment1>' '<equipmentType>' '<iPPortNumber1>' '<equipment2>' '<iPPortNumber2>' '<equipment3>' '<iPPortNumber3>' '<equipment4>' '<iPPortNumber4>' '<equipment5>' '<iPPortNumber5>'
Then New turbos'<equipment3>' Alert '19' and '<iPPortNumber3>' to be created

Examples: 
| equipment1 | equipmentType | iPPortNumber1 | equipment2 | iPPortNumber2 | equipment3 | iPPortNumber3 | equipment4 | iPPortNumber4 |equipment5 | iPPortNumber5 |
|   T4001    | Turbo Pump    |     4001      |    T4002   |      4002     |    T4003   |     4003      |     T4004  |     4004      |   T4005   |     4005      |

@SetUp
@SingleServer
Scenario Outline: Setup - Some EADS events
When  open the DSPU and open ADS_SystemTest Scenario 'DSPU_scenario.xml'
Then DSPU should show 'ExhaustGasTemp' in cell '1' the complex ADS scenario
When Start the ADS scenario 
Then Several graphs should be displayed whilst the scenario is running 
When wait 30 seconds and then Stop the scenario when some data points have been displayed in the graph
Then They should disappear when the scenario is stopped
When Login to EdCentra, select the Predictive Maintenance -> Import Profile and upload the following models '<Profile1>' '<model1>' '<Profile2>' '<model2>' '<Profile3>' '<model3>' '<Profile4>' '<model4>' '<Profile5>' '<model5>' 
Then After a period of upto two minutes, the ADS'<Profile1>' '<Profile2>' list should populated with the models uploaded
When Associate the iXH device 'ADSSystemTesting' with all the models uploaded '<Profile1>' '<Profile2>' '<Profile3>' '<Profile4>' '<Profile5>'
Then The UI should show iXH device 'ADSSystemTesting' with all the models uploaded '<Profile1>' '<Profile2>' '<Profile3>' '<Profile4>' '<Profile5>' that the associations have been made
When Start the DSPU scenario 'DSPU_scenario.xml'
Then DSPU graphs should be displayed

Examples:
| Profile1 | Profile2 |       Profile3       | Profile4 | Profile5 |     model1        |        model2                     |         model3                |                                   model4                                           |                        model5                               |
|   Dnl    |    EXT   |  MUM (Dnl and EXT)   |   PCE    |    PCP   |   model_Dnl.xml   |   model_GradientBased_EXT.xml     |  model_MultiModel_Dnl_EXT.xml |   process_counter_ecolink_sample_model_with_diag_inhibit_and_alert_strings.xml     |  process_counter_pump_sample_model_2min_timewindow.xml      |

@SetUp
@SingleServer
Scenario: Setup - Availability Data
When open the DSPU and open Availability Mode Scenario 'DSPU_scenario.xml'
And Execute the DSPU scenario
Then The scenario should run and show the Swap Out Generator form
When After a second, select 'iQ DryPump' [New System Type] DDL and click on [Swapout]

@SetUp
@SingleServer
Scenario: Setup -Availability Data Verification
When run query and read data

@SetUp
@SingleServer
Scenario: Setup - Turn on Agent(s)
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
Then the log should show Web pages being served
When run the Turbo simulator to get some Turbo devices communicating
Then the console window should show connectivety established the data as equipment Name 'T4000' equipmentType 'Turbo Pump' device iPPortNumber'4000'
And New turbo show connectivety established the data 'T4000' Alert '19' and '4000' to be created

@SetUp
@SingleServer
Scenario: Setup - Add Folders and Systems
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
And I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
When Click a communicating piece of equipment'NEW0001PM1' that has parameters (again, below the name / header) to show the SEV
Then SEV window shows. The Parameter data should be coming through. If the parameter boxes are grey and there are no values, Wait for a few seconds(no more than 30) for the data to come through
When Each default parameter displayed on the Overview tab, using EISSA, change '54          (MB Temp)' value to '2'
Then Presuming the parameter data is varying from the equipment or simulator, every few seconds you should see updated parameter value'2 K'

@SetUp
@SingleServer
Scenario: Setup - Maintenance Mode
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
And Entered equipment name, selected the equipment type,cliked find equipment button, selected one by one equipments 'NEW0001PM1' 'NEW0001PM2' 'NEW0001PM3' 'NEW0001PM4' 'NEW0001PM5' and clicked Add button
Then Grab the system '[WEB]' id of every iXH for the test
When open the DSPU and open Maintenance Mode Scenario 'DSPU_New Scenario.xml'
Then Update the Triangle Wave DS and ensure that the System ID GUID in the EquipmentEventDetails field is the system id of an iXH registered with FabWorks
#When Display the SEV of the iXH with Device Explorer for a few of minutes (three to five)

