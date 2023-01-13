Feature: ConfigurationHandler

Background: 
Given Opened EDCENTRA url in browser
When Entered username as 'administrator' and password  as'toolkit' and I clicked login button
Then Should be navigated to home page

@SplitServer
@SingleServer
@ConfigurationHandler
Scenario: Configuration Handler - Create Configuration Set
Given navigated to Configuration Handler page
When selected Equipment Type in the list
And deleted if Configration Set already exists with same name 'Set1'
And clicked Create button.
Then Create Configuration sdet pop-up will appear
When gave a unique name 'Set1' to configuration set 
And selected required radio button from the list and click create
Then Configuration Set with given name 'Set1' will be created 
When Selected 'Set1 'and added the parameters required '1 - Pump Node - Node'
Then configuration set changes should be saved
When selected the set 'Set1' and clicked 'Delete'
Then The set 'Set1' should be deleted 


#Prerequisite
#Create configuarartion set by running first test case
@SplitServer
@SingleServer
@ConfigurationHandler
Scenario: Configuration Handler - Edit/Rename/Copy-Paste/Delete Configuration Set
Given navigated to Configuration Handler page
When selected Equipment Type in the list
And deleted if Configration Set already exists with same name 'Set1'
And clicked Create button.
Then Create Configuration sdet pop-up will appear
When gave a unique name 'Set1' to configuration set 
And selected required radio button from the list and click create
Then Configuration Set with given name 'Set1' will be created 
When Selected 'Set1 'and added the parameters required '1 - Pump Node - Node'
Then configuration set changes should be saved
When selected type from the list and then select already created configuration set 'Set1'
Then its detail will be listed i.e. selected parameter '1 - Pump Node - Node'
When selected the set 'Set1' and clicked 'Rename'
Then A pop-up will appear 
When entered same name there 'Set1' and clicked confirm
Then Make sure the it prompts for 'Name already exists' message
When entered unique name 'Set2'and clicked confirm  from 'Set1' and clicked 'Rename' 
#When entered unique name 'Set2'and clicked confirm 
Then set name should be changed to 'Set2'
When selected type from the list and then selected already created configuration set 'Set2'
And added few entries '1 - Pump Node - User Tag', '3 - Dry Pump Current - Analogue' in the set detail and clicked Save
Then configuration set changes should be saved
When clicked on the entry in right hand list and clicked Edit '3 - Dry Pump Current - Analogue'
Then A Edit pop-up will appear contains title 'Set2' and '3 - Dry Pump Current - Analogue'
When made few changes i.e edit High alarm value to '50' and clicked save
Then Changes made should be saved for parameter '3 - Dry Pump Current - Analogue' with new high alarm value '50' 
When selected the set 'Set2' and clicked 'Copy'
Then 'Current copied Configuration Set: "Set2"' message will appear
When selected another type or same type from list and clicked paste
Then A pop-up will appear to enter new name for the copying set
When Entered name and clicked ok
Then The profile should be copied to the selected node with new name.
When selected the set 'Set2' and clicked 'Delete'
Then The set 'Set2' should be deleted 
And deleted copied folder

@SplitServer
@SingleServer
@ConfigurationHandler
Scenario: Configuration Handler - General Usage
Given navigated to Configuration Handler page
When selected Equipment Type in the list
And deleted if Configration Set already exists with same name 'Set3'
And deleted if Configration Set already exists with same name 'Set4'
And clicked Create button.
Then Create Configuration sdet pop-up will appear
When gave a unique name 'Set3' to configuration set 
And selected required radio button from the list and click create
Then Configuration Set with given name 'Set3' will be created 
When Selected 'Set3 'and added the parameters required '1 - Pump Node - Node'
Then configuration set changes should be saved
When clicked Create button.
And gave a unique name 'Set4' to configuration set 
And selected required radio button from the list and click create
Then Configuration Set with given name 'Set4' will be created 
When Selected 'Set4 'and added the parameters required '1 - Pump Node - Node'
Then configuration set changes should be saved
When Selected created configuaration sets and clicked compare button
Then pop up should appear
When clicked same radio button
Then similar parameters should shown


