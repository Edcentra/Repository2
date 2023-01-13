Feature: EdwardsIOController
	Test the new Edwards IO Controller import and export functionality.

Background: 
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
Then I should be navigated to Home page

@SplitServer
@SingleServer
@EdwardsIOController 
@JenkinsSingleServer
Scenario: Edwards IO Controller/Type 2 Import and Export
When Go to the Configure -> Edwards IO Controller Settings section
Then Page loads and shows Create new profile dialog if there are no existing profiles
When New dialog is not showing if there are existing profiles then click the New button, enter a unique name 'ControllerProfile' and click the create button.
Then Profile is created and shown - you can see the details with tabs: Parameters, Functions, Alerts and assignments.
And the profiles list at the top you can see the new profile'ControllerProfile' selected and showing 0 assignments.
When Edit some parameters by clicking the checkboxes and entering values then click Apply.
|     Parameter   |         Description       | CustomScaling | DefaultOffset |    OffsetUnit |           
|  DigitalInput1  |   SampleDigitalInputTest  |      2        |        1      |  Current (A)  |
Then Changes are applied.
When Click the Functions tab then edit some functions by selecting a function in the Boolean Operation drop-down select different first and second input parameters.Click Apply.
|          Function         |  BooleanOperation  |    FirstInputParameter   | SecondInputParameter |
|  Function1_Boolean_Output |         XOR        |   SampleDigitalInputTest |      DigitalInput2   |
Then Changes are applied.
When Click the Alerts tab and create an alert, making sure to enter something into the Alert Message and click Add again.
|         Parameter      |    Alert    | AlertMessage |
| SampleDigitalInputTest | Minor Alarm | TestAlert    |
Then New Alert entry appears in list.
|        Parameter       |    Alert    | AlertMessage |
| SampleDigitalInputTest | Minor Alarm | TestAlert    |
When Click the Apply button.
Then Changes are applied.
When the profile 'ControllerProfile' that you created selected, click the Export button.
Then The File 'ControllerProfile' saved locally.
When click the Import button.
Then Import panel appears.
When Click the Import button on the newly shown panel.
Then A message appears You must enter a profile name.
When Enter a profile name 'ImportProfile' and click Import again.
Then A Message Shows No file selected.
When Enter the name of an existing profile 'ControllerProfile' e.g. the one you created earlier and select the file that you downloaded earlier then click Import.
Then A Message Shows Profile Name Already Exists.
When Enter a unique name 'ImportProfile' then select the file'ControllerProfile' that you downloaded earlier then click Import.
Then Profile 'ImportProfile' is imported and selected.
When Check that the parameters, functions and alerts match the profile that was exported.
|        Parameter       |    Alert    | AlertMessage |
| SampleDigitalInputTest | Minor Alarm | TestAlert    |
Then assignments are not exported/imported 'ImportProfile' so these will always be empty '0' for the newly imported profile.


@SplitServer
@SingleServer
@EdwardsIOController 
@JenkinsSingleServer
Scenario: Edwards IO Controller/Type 2 Profile Management UI
When I clicked Device Explorer link
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
Then I commissioned device with following details 'Edwards IO Controller', '502'
When Go to the Configure -> Edwards IO Controller Settings section
Then Page loads and shows Create new profile dialog if there are no existing profiles
When New dialog is not showing if there are existing profiles then click the New button, enter a unique name 'ControllerProfile' and click the create button.
Then Profile is created and shown - you can see the details with tabs: Parameters, Functions, Alerts and assignments.
And the profiles list at the top you can see the new profile'ControllerProfile' selected and showing 0 assignments.
When Click the New button and leave the name field blank then click Create.
Then A Message Shows to enter a profile name.
When enter exactly the same name as the current profile 'ControllerProfile' then click Create.
Then Message Shows Profile Name Already Exists.
When Click Cancel.
#Then New Dialog closes.
When Edit some parameters by clicking the checkboxes and entering values then click Apply.
|     Parameter   |         Description       | CustomScaling | DefaultOffset |    OffsetUnit |           
|  DigitalInput1  |   SampleDigitalInputTest  |      2        |        1      |  Current (A)  |
Then Changes are applied.
When Click the Functions tab then edit some functions by selecting a function in the Boolean Operation drop-down select different first and second input parameters.Click Apply.
|          Function         |  BooleanOperation  |    FirstInputParameter   | SecondInputParameter |
|  Function1_Boolean_Output |         XOR        |   SampleDigitalInputTest |      DigitalInput2   |
Then Changes are applied.
When Click the Alerts tab and create an alert, making sure to enter something into the Alert Message and click Add again.
|         Parameter      |    Alert    | AlertMessage |
| SampleDigitalInputTest | Minor Alarm | TestAlert    |
Then New Alert entry appears in list.
|        Parameter       |    Alert    | AlertMessage |
| SampleDigitalInputTest | Minor Alarm | TestAlert    |
When Click the Apply button.
Then Changes are applied.
When Click the Assignments tab then Find Equipment.
Then The IO Controller devices that you added in the preparation steps should be listed.
When Select a device in the list and move it over with the single right arrow or by double clicking it. Click Apply.
Then Changes are applied and persist when leaving and returning to the page.
And Notice the Assignments count in the profile 'ControllerProfile' list at the top show '1' for this profile.
When With the profile'ControllerProfile' that you created selected
And click duplicate button, leave the new name field blank then click Duplicate.
Then Message Shows to enter a profile name.
When enter exactly the same name as the current profile 'ControllerProfile' then click Duplicate.
Then A Message Shows that this Profile name already exists.
When Now enter a unique name 'DuplicateProfile' and click Duplicate.
Then Profile 'DuplicateProfile' is duplicated, appears in the list of profiles and is selected.
When Compare the parameters, functions and alerts for the duplicated profile with the original.
|        Description       | CustomScaling |   OffsetUnit  |  BooleanOperation | SecondInputParameter |     Alert   | AlertMessage |
|   SampleDigitalInputTest |     2         |        A      |       XOR         |     DigitalInput2    | Minor Alarm | TestAlert    |
Then Note duplicate profile 'DuplicateProfile' that assignments are NOT duplicated and this should read '0'.
When With a profile 'DuplicateProfile' selected, click the Rename button and enter the name of the profile 'ControllerProfile' that is not currently selected then click Rename.	
Then A Message Shows that this Profile name already exists.
When Now enter a unique name 'RenameProfile' and click Rename.
Then Profile is renamed 'RenameProfile' as seen in the profile list and label at the top of the details/editing view below.
When Navigate to Device Explorer and to the Manage Equipment Tab and search for the IO Controller you added at the begining of this test. Highlight and delete this piece of equipment
Then The IO Controller is removed and confirmed
When Navigate back to the IO Controller Settings page
Then The device is not present in the profile 'ControllerProfile' and the Assignments count '0' is reduced accordingly
When a profile 'ControllerProfile' selected, click the Delete button then click Cancel.
Then The profile 'ControllerProfile' is NOT deleted.
When a profile 'ControllerProfile' selected, click the Delete button again then click Delete.
Then The profile 'ControllerProfile' is deleted (a message is shown confirming this), the details/edit area is hidden as no profiles are currently selected.




