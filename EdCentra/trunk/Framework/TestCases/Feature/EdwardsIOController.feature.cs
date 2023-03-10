// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Edwards.Scada.Test.Framework.TestCases.Feature
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("EdwardsIOController")]
    public partial class EdwardsIOControllerFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "EdwardsIOController.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "EdwardsIOController", "\tTest the new Edwards IO Controller import and export functionality.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
#line 5
testRunner.Given("I opened EDCENTRA app url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
testRunner.When("I entered \'administrator\' and \'toolkit\' and clicked login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
testRunner.Then("I should be navigated to Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Edwards IO Controller/Type 2 Import and Export")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("EdwardsIOController")]
        [NUnit.Framework.CategoryAttribute("JenkinsSingleServer")]
        public virtual void EdwardsIOControllerType2ImportAndExport()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edwards IO Controller/Type 2 Import and Export", null, new string[] {
                        "SplitServer",
                        "SingleServer",
                        "EdwardsIOController",
                        "JenkinsSingleServer"});
#line 13
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 14
testRunner.When("Go to the Configure -> Edwards IO Controller Settings section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
testRunner.Then("Page loads and shows Create new profile dialog if there are no existing profiles", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
testRunner.When("New dialog is not showing if there are existing profiles then click the New butto" +
                    "n, enter a unique name \'ControllerProfile\' and click the create button.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.Then("Profile is created and shown - you can see the details with tabs: Parameters, Fun" +
                    "ctions, Alerts and assignments.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
testRunner.And("the profiles list at the top you can see the new profile\'ControllerProfile\' selec" +
                    "ted and showing 0 assignments.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Parameter",
                        "Description",
                        "CustomScaling",
                        "DefaultOffset",
                        "OffsetUnit"});
            table1.AddRow(new string[] {
                        "DigitalInput1",
                        "SampleDigitalInputTest",
                        "2",
                        "1",
                        "Current (A)"});
#line 19
testRunner.When("Edit some parameters by clicking the checkboxes and entering values then click Ap" +
                    "ply.", ((string)(null)), table1, "When ");
#line 22
testRunner.Then("Changes are applied.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Function",
                        "BooleanOperation",
                        "FirstInputParameter",
                        "SecondInputParameter"});
            table2.AddRow(new string[] {
                        "Function1_Boolean_Output",
                        "XOR",
                        "SampleDigitalInputTest",
                        "DigitalInput2"});
#line 23
testRunner.When("Click the Functions tab then edit some functions by selecting a function in the B" +
                    "oolean Operation drop-down select different first and second input parameters.Cl" +
                    "ick Apply.", ((string)(null)), table2, "When ");
#line 26
testRunner.Then("Changes are applied.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Parameter",
                        "Alert",
                        "AlertMessage"});
            table3.AddRow(new string[] {
                        "SampleDigitalInputTest",
                        "Minor Alarm",
                        "TestAlert"});
#line 27
testRunner.When("Click the Alerts tab and create an alert, making sure to enter something into the" +
                    " Alert Message and click Add again.", ((string)(null)), table3, "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Parameter",
                        "Alert",
                        "AlertMessage"});
            table4.AddRow(new string[] {
                        "SampleDigitalInputTest",
                        "Minor Alarm",
                        "TestAlert"});
#line 30
testRunner.Then("New Alert entry appears in list.", ((string)(null)), table4, "Then ");
#line 33
testRunner.When("Click the Apply button.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.Then("Changes are applied.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
testRunner.When("the profile \'ControllerProfile\' that you created selected, click the Export butto" +
                    "n.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
testRunner.Then("The File \'ControllerProfile\' saved locally.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
testRunner.When("click the Import button.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("Import panel appears.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
testRunner.When("Click the Import button on the newly shown panel.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.Then("A message appears You must enter a profile name.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
testRunner.When("Enter a profile name \'ImportProfile\' and click Import again.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
testRunner.Then("A Message Shows No file selected.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
testRunner.When("Enter the name of an existing profile \'ControllerProfile\' e.g. the one you create" +
                    "d earlier and select the file that you downloaded earlier then click Import.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
testRunner.Then("A Message Shows Profile Name Already Exists.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
testRunner.When("Enter a unique name \'ImportProfile\' then select the file\'ControllerProfile\' that " +
                    "you downloaded earlier then click Import.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
testRunner.Then("Profile \'ImportProfile\' is imported and selected.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Parameter",
                        "Alert",
                        "AlertMessage"});
            table5.AddRow(new string[] {
                        "SampleDigitalInputTest",
                        "Minor Alarm",
                        "TestAlert"});
#line 47
testRunner.When("Check that the parameters, functions and alerts match the profile that was export" +
                    "ed.", ((string)(null)), table5, "When ");
#line 50
testRunner.Then("assignments are not exported/imported \'ImportProfile\' so these will always be emp" +
                    "ty \'0\' for the newly imported profile.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Edwards IO Controller/Type 2 Profile Management UI")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("EdwardsIOController")]
        [NUnit.Framework.CategoryAttribute("JenkinsSingleServer")]
        public virtual void EdwardsIOControllerType2ProfileManagementUI()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edwards IO Controller/Type 2 Profile Management UI", null, new string[] {
                        "SplitServer",
                        "SingleServer",
                        "EdwardsIOController",
                        "JenkinsSingleServer"});
#line 57
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 58
testRunner.When("I clicked Device Explorer link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
testRunner.Then("I should be navigated to Device Explorer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
testRunner.When("I clicked on add folder/ system icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
testRunner.And("I Entered folder name and Clicked on Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
testRunner.Then("I should be able to see Folder Added Successfully message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 63
testRunner.When("I clicked OK button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
testRunner.Then("I should be able to see newly added folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
testRunner.When("I clicked Find Equipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
testRunner.And("deleted all equipments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
testRunner.Then("I commissioned device with following details \'Edwards IO Controller\', \'502\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
testRunner.When("Go to the Configure -> Edwards IO Controller Settings section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
testRunner.Then("Page loads and shows Create new profile dialog if there are no existing profiles", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
testRunner.When("New dialog is not showing if there are existing profiles then click the New butto" +
                    "n, enter a unique name \'ControllerProfile\' and click the create button.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
testRunner.Then("Profile is created and shown - you can see the details with tabs: Parameters, Fun" +
                    "ctions, Alerts and assignments.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
testRunner.And("the profiles list at the top you can see the new profile\'ControllerProfile\' selec" +
                    "ted and showing 0 assignments.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
testRunner.When("Click the New button and leave the name field blank then click Create.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
testRunner.Then("A Message Shows to enter a profile name.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
testRunner.When("enter exactly the same name as the current profile \'ControllerProfile\' then click" +
                    " Create.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
testRunner.Then("Message Shows Profile Name Already Exists.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
testRunner.When("Click Cancel.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Parameter",
                        "Description",
                        "CustomScaling",
                        "DefaultOffset",
                        "OffsetUnit"});
            table6.AddRow(new string[] {
                        "DigitalInput1",
                        "SampleDigitalInputTest",
                        "2",
                        "1",
                        "Current (A)"});
#line 79
testRunner.When("Edit some parameters by clicking the checkboxes and entering values then click Ap" +
                    "ply.", ((string)(null)), table6, "When ");
#line 82
testRunner.Then("Changes are applied.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Function",
                        "BooleanOperation",
                        "FirstInputParameter",
                        "SecondInputParameter"});
            table7.AddRow(new string[] {
                        "Function1_Boolean_Output",
                        "XOR",
                        "SampleDigitalInputTest",
                        "DigitalInput2"});
#line 83
testRunner.When("Click the Functions tab then edit some functions by selecting a function in the B" +
                    "oolean Operation drop-down select different first and second input parameters.Cl" +
                    "ick Apply.", ((string)(null)), table7, "When ");
#line 86
testRunner.Then("Changes are applied.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Parameter",
                        "Alert",
                        "AlertMessage"});
            table8.AddRow(new string[] {
                        "SampleDigitalInputTest",
                        "Minor Alarm",
                        "TestAlert"});
#line 87
testRunner.When("Click the Alerts tab and create an alert, making sure to enter something into the" +
                    " Alert Message and click Add again.", ((string)(null)), table8, "When ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Parameter",
                        "Alert",
                        "AlertMessage"});
            table9.AddRow(new string[] {
                        "SampleDigitalInputTest",
                        "Minor Alarm",
                        "TestAlert"});
#line 90
testRunner.Then("New Alert entry appears in list.", ((string)(null)), table9, "Then ");
#line 93
testRunner.When("Click the Apply button.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
testRunner.Then("Changes are applied.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 95
testRunner.When("Click the Assignments tab then Find Equipment.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
testRunner.Then("The IO Controller devices that you added in the preparation steps should be liste" +
                    "d.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
testRunner.When("Select a device in the list and move it over with the single right arrow or by do" +
                    "uble clicking it. Click Apply.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
testRunner.Then("Changes are applied and persist when leaving and returning to the page.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
testRunner.And("Notice the Assignments count in the profile \'ControllerProfile\' list at the top s" +
                    "how \'1\' for this profile.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
testRunner.When("With the profile\'ControllerProfile\' that you created selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 101
testRunner.And("click duplicate button, leave the new name field blank then click Duplicate.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
testRunner.Then("Message Shows to enter a profile name.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
testRunner.When("enter exactly the same name as the current profile \'ControllerProfile\' then click" +
                    " Duplicate.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
testRunner.Then("A Message Shows that this Profile name already exists.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
testRunner.When("Now enter a unique name \'DuplicateProfile\' and click Duplicate.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
testRunner.Then("Profile \'DuplicateProfile\' is duplicated, appears in the list of profiles and is " +
                    "selected.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Description",
                        "CustomScaling",
                        "OffsetUnit",
                        "BooleanOperation",
                        "SecondInputParameter",
                        "Alert",
                        "AlertMessage"});
            table10.AddRow(new string[] {
                        "SampleDigitalInputTest",
                        "2",
                        "A",
                        "XOR",
                        "DigitalInput2",
                        "Minor Alarm",
                        "TestAlert"});
#line 107
testRunner.When("Compare the parameters, functions and alerts for the duplicated profile with the " +
                    "original.", ((string)(null)), table10, "When ");
#line 110
testRunner.Then("Note duplicate profile \'DuplicateProfile\' that assignments are NOT duplicated and" +
                    " this should read \'0\'.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 111
testRunner.When("With a profile \'DuplicateProfile\' selected, click the Rename button and enter the" +
                    " name of the profile \'ControllerProfile\' that is not currently selected then cli" +
                    "ck Rename.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
testRunner.Then("A Message Shows that this Profile name already exists.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
testRunner.When("Now enter a unique name \'RenameProfile\' and click Rename.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 114
testRunner.Then("Profile is renamed \'RenameProfile\' as seen in the profile list and label at the t" +
                    "op of the details/editing view below.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 115
testRunner.When("Navigate to Device Explorer and to the Manage Equipment Tab and search for the IO" +
                    " Controller you added at the begining of this test. Highlight and delete this pi" +
                    "ece of equipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
testRunner.Then("The IO Controller is removed and confirmed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 117
testRunner.When("Navigate back to the IO Controller Settings page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
testRunner.Then("The device is not present in the profile \'ControllerProfile\' and the Assignments " +
                    "count \'0\' is reduced accordingly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 119
testRunner.When("a profile \'ControllerProfile\' selected, click the Delete button then click Cancel" +
                    ".", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 120
testRunner.Then("The profile \'ControllerProfile\' is NOT deleted.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 121
testRunner.When("a profile \'ControllerProfile\' selected, click the Delete button again then click " +
                    "Delete.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 122
testRunner.Then("The profile \'ControllerProfile\' is deleted (a message is shown confirming this), " +
                    "the details/edit area is hidden as no profiles are currently selected.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

