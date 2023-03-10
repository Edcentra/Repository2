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
    [NUnit.Framework.DescriptionAttribute("OtherDeviceDataTypes")]
    public partial class OtherDeviceDataTypesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "OtherDeviceDataTypes.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "OtherDeviceDataTypes", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 3
#line 4
testRunner.Given("I opened EDCENTRA app url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
testRunner.When("I entered \'administrator\' and \'toolkit\' and clicked login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 6
testRunner.Then("Change the User Preference", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Other Device Data Types - EcoLink Cycling")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("OtherDeviceDataTypes")]
        public virtual void OtherDeviceDataTypes_EcoLinkCycling()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Other Device Data Types - EcoLink Cycling", null, new string[] {
                        "SplitServer",
                        "SingleServer",
                        "OtherDeviceDataTypes"});
#line 11
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 12
testRunner.When("Enable GreenMode in EdCentra Options EnableGreenMode=On", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
testRunner.Then("Confirm the Success message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
testRunner.When("I clicked Device Explorer link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
testRunner.Then("I should be navigated to Device Explorer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
testRunner.When("I clicked on add folder/ system icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.And("I Entered folder name and Clicked on Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
testRunner.Then("I should be able to see Folder Added Successfully message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
testRunner.When("I clicked OK button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
testRunner.Then("I should be able to see newly added folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
testRunner.When("I clicked Find Equipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
testRunner.And("deleted all equipments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.And("Launched Eissa, started simulator and selected equipment type \'eZenith\' and devic" +
                    "e type \'NEW0001PM1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
testRunner.And("I commissioned device with following details \'eZenith\', \'50000\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
testRunner.And("I Entered Equipment name, Selected the Equipment type,Cliked Find Equipment butto" +
                    "n, selected one by one equipments \'NEW0001PM1\' \'NEW0001PM2\' \'NEW0001PM3\' \'NEW000" +
                    "1PM4\' \'NEW0001PM5\' \'NEW0001PM6\'and clicked Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
testRunner.And("grab the system \'[WEB]\' id of every iXH for the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
testRunner.And("open the DSPU and open Eco Mode Scenario \'ecomode_scenario.dspu.xml\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.Then("in the DSPU, edit [ MANIPULATOR / Spawner / DPD to systems A ] and [ MANIPULATOR " +
                    "/ Spawner / DPD to systems B ] setting the property Value to the iXH pipe delimi" +
                    "ted system id list above", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
testRunner.When("Execute the DSPU scenario and then watch the equipment in DeviceExplorer for a ab" +
                    "out five minutes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
testRunner.When("I Within the [Configure \\/] menu, click the Logging option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
testRunner.Then("the Logging tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
testRunner.When("I Click on Create Profile button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
testRunner.Then("the Create Profile form is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
testRunner.When("Provide a name\'LoggingTest\' and select an equipment type\'iXH DryPump\' for the pro" +
                    "file. Click Create.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
testRunner.Then("The form expand and shows detail tab which lists parameter for the equipment type" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
testRunner.When("I click on Equipments tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
testRunner.Then("I should be navigated to Equipments tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
testRunner.When("I Find equipment using equipment description and add Equipments \'NEW0001PM1\' to A" +
                    "ssigned Equipment list using > and >> button then Click Apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
testRunner.Then("the Changes have been applied message will be displayed on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
testRunner.When("Click Historian Equipment Data tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
testRunner.Then("Equipment Datatab should be shown and Select Device Explorer folder on Systems li" +
                    "st", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
testRunner.When("Expand the folder and Select single Equipment \'NEW0001PM1\' in the Tree", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
testRunner.Then("The Parameter\'Booster Control (12)\' for that Equipment will be displayed in the p" +
                    "arameter\'s list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
testRunner.When("I click on of the parameter\'Equipment Status\' and click Add button at the bottom " +
                    "of the parameter list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
testRunner.Then("view the Equipment Status value \'IDLE\' in the Historian Equipment Status grid vie" +
                    "w", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
testRunner.When("Stop the DSPU scenario and start EISSA again", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
testRunner.Then("DSPU data to stop flowing and regular EISSA data\'12          (Booster Control)\' \'" +
                    "10\' to flow again \'Booster Control (12)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add EUV support to EdCentra only")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("OtherDeviceDataTypes")]
        [NUnit.Framework.TestCaseAttribute("Water In Pressure 101W (Pa)", "1 Second", "1 Second", "8E-05", "Mass Flow Meter 101 (Exp) (slm)", "1 Second", "1 Second", "3E-05", "Exposure O2 Transmission", "1 Second", "1 Second", "1", null)]
        public virtual void AddEUVSupportToEdCentraOnly(string parameter, string timeIntervalforNormal, string timeIntervalforAlert, string timeIntervalforDelta, string parameter1, string timeIntervalforNormal1, string timeIntervalforAlert1, string timeIntervalforDelta1, string parameter2, string timeIntervalforNormal2, string timeIntervalforAlert2, string timeIntervalforDelta2, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SplitServer",
                    "SingleServer",
                    "OtherDeviceDataTypes"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add EUV support to EdCentra only", null, @__tags);
#line 52
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 53
testRunner.When("I clicked Device Explorer link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
testRunner.Then("I should be navigated to Device Explorer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
testRunner.When("I clicked on add folder/ system icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
testRunner.And("I Entered folder name and Clicked on Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
testRunner.Then("I should be able to see Folder Added Successfully message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
testRunner.When("I clicked OK button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
testRunner.Then("I should be able to see newly added folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
testRunner.When("I clicked Find Equipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
testRunner.And("deleted all equipments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
testRunner.And("Launched Eissa, started simulator and selected equipment type \'EUVZenith\' and dev" +
                    "ice type \'NEW0001FC\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
testRunner.And("I commissioned device with following details \'EUV Zenith\', \'50000\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
testRunner.And("I entered Equipment name, selected equipmentType\'EUV Zenith Slice Controller\', Cl" +
                    "iked Find Equipment button, selected one equipmentName\'NEW0001FC\' and clicked Ad" +
                    "d button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
testRunner.Then("I should be able to see Equipment Added Successfully message and after clicking O" +
                    "k button, added Equipment should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
testRunner.When("Open the SEV \'NEW0001FC\' to the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
testRunner.Then("Make sure data appears on the UI", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
testRunner.When("Raise an alert \'6          (Exhaust Valve)\' \'HighAlarm\' \'IDS_17000_ALERT_38_ERROR" +
                    " (Leak Detector 101 Error)\' (alarm) on the EISSA simulator on the Slice Controll" +
                    "er", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
testRunner.Then("Make sure the  alarm alert appears in the SEV, and Alert List app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
testRunner.When("Raise an alert \'2          (RS Gate Valve)\' \'HighWarning\' \'IDS_17000_ALERT_203_ER" +
                    "ROR (System Error)\' (warning) on the EISSA simulator on the Slice Controller", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
testRunner.Then("Make sure the warning alert appears in the SEV, and Alert List app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
testRunner.When("Clear the alarm \'6          (Exhaust Valve)\' alert", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
testRunner.Then("Make sure the alarm alert disappears in the SEV, and Alert List app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
testRunner.When("Clear the warning \'2          (RS Gate Valve)\' alert", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
testRunner.Then("Make sure the warning alert disappears in the SEV, and Alert List app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
testRunner.When("Modify the running status of the Slice Controller device\'NEW0001FC\' between Runni" +
                    "ng and \'Stop\' in EISSA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
testRunner.Then("Just make sure the status changes in EdCentra between \'Off\' and Modify the runnin" +
                    "g status of the Slice Controller device \'Running\' and  status changes in EdCentr" +
                    "a\'On\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 78
testRunner.When("I Within the [Configure \\/] menu, click the Logging option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
testRunner.Then("the Logging tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
testRunner.When("I Click on Create Profile button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 81
testRunner.Then("the Create Profile form is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
testRunner.When("Provide a name\'LoggingTest\' and select an equipment type\'EUV Zenith Slice Control" +
                    "ler\' for the profile. Click Create.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 83
testRunner.Then("The form expand and shows detail tab which lists parameter for the equipment type" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
testRunner.When(string.Format("Make number of selections from the list of available parameters and change the va" +
                        "lues for the Normal, Alert, and Delta \'{0}\' \'{1}\' \'{2}\' \'{3}\' \'{4}\' \'{5}\' \'{6}\' " +
                        "\'{7}\' \'{8}\' \'{9}\' \'{10}\' \'{11}\'.Click Apply.", parameter, timeIntervalforNormal, timeIntervalforAlert, timeIntervalforDelta, parameter1, timeIntervalforNormal1, timeIntervalforAlert1, timeIntervalforDelta1, parameter2, timeIntervalforNormal2, timeIntervalforAlert2, timeIntervalforDelta2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 86
testRunner.Then(string.Format("The screen will show applied values for Normal / Alert and Delta fields for the p" +
                        "arameter.The screen will only list parameters\'{0}\' added in profile", parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 87
testRunner.When("I click on Equipments tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
testRunner.Then("I should be navigated to Equipments tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
testRunner.When("I Find equipment using equipment description and add Equipments \'NEW0001FC\' to As" +
                    "signed Equipment list using > and >> button then Click Apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
testRunner.Then("the Changes have been applied message will be displayed on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add Proteus support to EdCentra only")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("OtherDeviceDataTypes")]
        [NUnit.Framework.TestCaseAttribute("Process Gas 1 Pressure (Pa)", "1 Second", "1 Second", "1", "Channel A Plasma Power (W)", "1 Second", "1 Second", "1", "Channel A PCW Main Pressure (Pa)", "1 Second", "1 Second", "1", null)]
        public virtual void AddProteusSupportToEdCentraOnly(string parameter, string timeIntervalforNormal, string timeIntervalforAlert, string timeIntervalforDelta, string parameter1, string timeIntervalforNormal1, string timeIntervalforAlert1, string timeIntervalforDelta1, string parameter2, string timeIntervalforNormal2, string timeIntervalforAlert2, string timeIntervalforDelta2, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SplitServer",
                    "SingleServer",
                    "OtherDeviceDataTypes"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Proteus support to EdCentra only", null, @__tags);
#line 98
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 99
testRunner.When("I clicked Device Explorer link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
testRunner.Then("I should be navigated to Device Explorer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
testRunner.When("I clicked on add folder/ system icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
testRunner.And("I Entered folder name and Clicked on Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
testRunner.Then("I should be able to see Folder Added Successfully message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 104
testRunner.When("I clicked OK button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 105
testRunner.Then("I should be able to see newly added folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 106
testRunner.When("I clicked Find Equipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 107
testRunner.And("deleted all equipments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
testRunner.And("Launched Eissa, started simulator and selected equipment type \'Proteus\' and devic" +
                    "e type \'NEW0001AC\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
testRunner.And("I commissioned device with following details \'Proteus Abatement\', \'50000\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
testRunner.And("I entered Equipment name, selected equipmentType\'Proteus Abatement\', Cliked Find " +
                    "Equipment button, selected one equipmentName\'NEW0001AC\' and clicked Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
testRunner.Then("I should be able to see Equipment Added Successfully message and after clicking O" +
                    "k button, added Equipment should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 112
testRunner.When("Open the SEV \'NEW0001AC\' to the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
testRunner.Then("Make sure Proteus data appears on the UI", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 114
testRunner.When("Raise an alert \'36          (Process Gas 1 Pressure)\' \'HighAlarm\' \'IDS_16409_ALER" +
                    "T_1022_HIGH (Channel B NPW Main Pressure High Alarm)\' (alarm) on the EISSA simul" +
                    "ator on the Slice Controller", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 115
testRunner.Then("Make sure the  alarm alert appears in the SEV, and Alert List app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 116
testRunner.When("Raise an alert \'75          (Channel A System Exhaust Pressure)\' \'HighWarning\' \'I" +
                    "DS_16409_ALERT_10_HIGH (Channel A PCW Main Pressure High Alarm)\' (warning) on th" +
                    "e EISSA simulator on the Slice Controller", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 117
testRunner.Then("Make sure the warning alert appears in the SEV, and Alert List app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 118
testRunner.When("Clear the alarm \'36          (Process Gas 1 Pressure)\' alert", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
testRunner.Then("Make sure the alarm alert disappears in the SEV, and Alert List app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
testRunner.When("Clear the warning \'75          (Channel A System Exhaust Pressure)\' alert", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 121
testRunner.Then("Make sure the warning alert disappears in the SEV, and Alert List app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 122
testRunner.When("Modify the running status of the Slice Controller device\'NEW0001AC\' between Runni" +
                    "ng and \'Stop\' in EISSA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 123
testRunner.Then("Just make sure the status changes in EdCentra between \'Off\' and Modify the runnin" +
                    "g status of the Slice Controller device \'Running\' and  status changes in EdCentr" +
                    "a\'On\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 124
testRunner.When("I Within the [Configure \\/] menu, click the Logging option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 125
testRunner.Then("the Logging tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 126
testRunner.When("I Click on Create Profile button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 127
testRunner.Then("the Create Profile form is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
testRunner.When("Provide a name\'LoggingTest\' and select an equipment type\'Proteus Abatement\' for t" +
                    "he profile. Click Create.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 129
testRunner.Then("The form expand and shows detail tab which lists parameter for the equipment type" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
testRunner.When(string.Format("Make number of selections from the list of available parameters and change the va" +
                        "lues for the Normal, Alert, and Delta \'{0}\' \'{1}\' \'{2}\' \'{3}\' \'{4}\' \'{5}\' \'{6}\' " +
                        "\'{7}\' \'{8}\' \'{9}\' \'{10}\' \'{11}\'.Click Apply.", parameter, timeIntervalforNormal, timeIntervalforAlert, timeIntervalforDelta, parameter1, timeIntervalforNormal1, timeIntervalforAlert1, timeIntervalforDelta1, parameter2, timeIntervalforNormal2, timeIntervalforAlert2, timeIntervalforDelta2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 132
testRunner.Then(string.Format("The screen will show applied values for Normal / Alert and Delta fields for the p" +
                        "arameter.The screen will only list parameters\'{0}\' added in profile", parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 133
testRunner.When("I click on Equipments tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 134
testRunner.Then("I should be navigated to Equipments tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
testRunner.When("I Find equipment using equipment description and add Equipments \'NEW0001AC\' to As" +
                    "signed Equipment list using > and >> button then Click Apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 136
testRunner.Then("the Changes have been applied message will be displayed on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

