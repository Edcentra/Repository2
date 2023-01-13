Feature: SecsGem
	
Background: 
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
Then I should be navigated to Home page

@SplitServer
@SingleServer
Scenario: SecsGem - SecsGem Agent Features
When I click on SECS/GEM Agent (Host) item
Then the panel shows with description and a View Network link
When I Click on the View Networks link
Then I should see the SecsGem section in Network layout screen
When I clicked on Home Icon in top navigation menubar
And I clicked Device Explorer link
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
And Launched Eissa and started simulator
And I commissioned device with details 'iXH DryPump', '5001','127.0.0.1','testixh'
And I clicked the header of the folder selected Map SECS/GEM VIDs
Then VIDs are displayed for each parameter starting from '10001'
When I upload the second file in Map Secs/Gem VID's popup
Then VIDs are displayed for each parameter starting from '20001'
When I edit the VID value for a parameter and click Apply button
And I clicked the header of the folder selected Map SECS/GEM VIDs
Then the updated value should reflect in the corresponding parameters VID 

@SplitServer
@SingleServer
Scenario: GEMSECS - Provide mode for testing with SECS/GEM Agent.
When Connect to the SECS/GEM Service with the SECS/GEM Support Host.
Then the pannel open and tab activation 
When Send 'S1' message 'S1F13 - Establish Communication'.
Then The SECS/GEM Service will respond with an 'S1/F14' message. The format will be:
| ListNodecount |         COMMACK           |             MDLN                |          SOFTREV        |
|       2       |   <Binary>0</Binary>      | <Ascii>Edwards SECS/GEM</Ascii> |   <Ascii>1.9.6.1</Ascii>|
When Update the registry key IsSecsGemAgentCompatible to 'true'.
When Connect to the SECS/GEM Service 'S1' with the SECS/GEM Support Host. Send an 'S1F13 - Establish Communication' message.
Then The SECS/GEM Service will respond with an 'S1F14' message.Then the format will be:
| ListNodeNewcount |         COMMACK           |             MDLN                |          SOFTREV        |
|       1          |   <Binary>0</Binary>      | <Ascii>Edwards SECS/GEM</Ascii> |   <Ascii>1.9.6.1</Ascii>|