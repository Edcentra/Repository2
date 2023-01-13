﻿// ------------------------------------------------------------------------------
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
    [NUnit.Framework.DescriptionAttribute("AlertInhibit")]
    public partial class AlertInhibitFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AlertInhibit.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AlertInhibit", "\tAlerts can be inhibitted from paging\r\n\tThis test verifies that inhibitting is fu" +
                    "nctioning correctly", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 5
#line 6
testRunner.Given("I opened EDCENTRA app url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
testRunner.When("I entered \'administrator\' and \'toolkit\' and clicked login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
testRunner.Then("I should be navigated to Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Alert Inhibit - From Dispatch Manager")]
        [NUnit.Framework.CategoryAttribute("ApplicationServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("RegressionPass1")]
        [NUnit.Framework.CategoryAttribute("AlertInhibit")]
        public virtual void AlertInhibit_FromDispatchManager()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Alert Inhibit - From Dispatch Manager", null, new string[] {
                        "ApplicationServer",
                        "SingleServer",
                        "RegressionPass1",
                        "AlertInhibit"});
#line 14
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 15
testRunner.When("I clicked Device Explorer link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.Then("I should be navigated to Device Explorer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
testRunner.When("I clicked on add folder/ system icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.And("I Entered folder name and Clicked on Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.Then("I should be able to see Folder Added Successfully message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
testRunner.When("I clicked OK button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
testRunner.Then("I should be able to see newly added folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
testRunner.When("I clicked Find Equipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
testRunner.And("deleted all equipments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
testRunner.When("Launched Eissa and started simulator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.And("I commissioned device with following details \'eZenith\', \'50000\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
testRunner.And("I entered Equipment name, selected equipment type, Cliked Find Equipment button, " +
                    "selected one equipment and clicked Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
testRunner.Then("I should be able to see Equipment Added Successfully message and after clicking O" +
                    "k button, added Equipment should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
testRunner.When("navigated to SMTP tab under Page Settings tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
testRunner.And("login user \'administrator\' created new SMTP page From as \'Edwards.Support@edwards" +
                    "vacuum.com\' destination with SMTP IP of \'160.100.30.222\', port number as \'25\' an" +
                    "d To address as \'xyz@atlascopco.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
testRunner.And("navigated to Dispatch Manager->Scheduler.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
testRunner.When("Clicked Week days check box, All Day Check box and selected previously created Pa" +
                    "geDestination\'Admin, EdCentra (administrator) (SMTP)\'.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
testRunner.Then("clicked Apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
testRunner.When("Go to Dispatch Manager->Inhibit Settings tab and Click on the [New] button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.Then("A new Inhibit form should be visible and delete already created alert inhibit\'Adm" +
                    "in, EdCentra (administrator)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
testRunner.When("Search Equipment System\'iXH DryPump\' Using Type. And Select the Equipment\'NEW0001" +
                    "PM1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
testRunner.Then("List of Parameters\'All Parameters\' should be displayed in parameter list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
testRunner.When("Choose Parameters \'MB Temp (54)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("A list of possible Alerts\'MB body temperature sensor missing\' shall be displayed " +
                    "in Alert List", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
testRunner.When("Click on an appropriate Alert\'MB body temperature high\' entry", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.And("Mark Alert Level as All in Options section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
testRunner.And("Mark This Alert will not Expire check box", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
testRunner.And("I Select Inhibit Pages Only", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
testRunner.And("I Enter Comment\'Alert Inhibiting Test for MB body temperature high\' and click App" +
                    "ly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
testRunner.Then("Inhibit Settings should be saved and new entry \'Admin, EdCentra (administrator)\' " +
                    "entry should be added on the top list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
testRunner.When("I Create an alert which matches the inhibit just created Parameter \'54          (" +
                    "MB Temp)\' AlertType \'HighAlarm\' AlertCode \'IDS_25_ALERT_54_HIGH (MB body tempera" +
                    "ture high)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
testRunner.Then("No page should arrive. The message \'Blocked AutoPager Exception ID\' should be dis" +
                    "played in the Autopager console window.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
testRunner.When("I Create an alert which does not match the inhibit just created Parameter \'8     " +
                    "     (Booster Power)\' AlertType \'HighAlarm\' AlertCode \'IDS_25_ALERT_1_0 (System " +
                    "configuration fault)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
testRunner.Then("A page should arrive", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
