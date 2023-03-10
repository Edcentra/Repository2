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
    [NUnit.Framework.DescriptionAttribute("ConfigurationHandler")]
    public partial class ConfigurationHandlerFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ConfigurationHandler.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ConfigurationHandler", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
testRunner.Given("Opened EDCENTRA url in browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
testRunner.When("Entered username as \'administrator\' and password  as\'toolkit\' and I clicked login" +
                    " button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 6
testRunner.Then("Should be navigated to home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Configuration Handler - Create Configuration Set")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("ConfigurationHandler")]
        public virtual void ConfigurationHandler_CreateConfigurationSet()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Configuration Handler - Create Configuration Set", null, new string[] {
                        "SplitServer",
                        "SingleServer",
                        "ConfigurationHandler"});
#line 11
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 12
testRunner.Given("navigated to Configuration Handler page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
testRunner.When("selected Equipment Type in the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
testRunner.And("deleted if Configration Set already exists with same name \'Set1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
testRunner.And("clicked Create button.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
testRunner.Then("Create Configuration sdet pop-up will appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
testRunner.When("gave a unique name \'Set1\' to configuration set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.And("selected required radio button from the list and click create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.Then("Configuration Set with given name \'Set1\' will be created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
testRunner.When("Selected \'Set1 \'and added the parameters required \'1 - Pump Node - Node\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
testRunner.Then("configuration set changes should be saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
testRunner.When("selected the set \'Set1\' and clicked \'Delete\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
testRunner.Then("The set \'Set1\' should be deleted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Configuration Handler - Edit/Rename/Copy-Paste/Delete Configuration Set")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("ConfigurationHandler")]
        public virtual void ConfigurationHandler_EditRenameCopy_PasteDeleteConfigurationSet()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Configuration Handler - Edit/Rename/Copy-Paste/Delete Configuration Set", null, new string[] {
                        "SplitServer",
                        "SingleServer",
                        "ConfigurationHandler"});
#line 31
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 32
testRunner.Given("navigated to Configuration Handler page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
testRunner.When("selected Equipment Type in the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.And("deleted if Configration Set already exists with same name \'Set1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
testRunner.And("clicked Create button.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
testRunner.Then("Create Configuration sdet pop-up will appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
testRunner.When("gave a unique name \'Set1\' to configuration set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.And("selected required radio button from the list and click create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
testRunner.Then("Configuration Set with given name \'Set1\' will be created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
testRunner.When("Selected \'Set1 \'and added the parameters required \'1 - Pump Node - Node\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
testRunner.Then("configuration set changes should be saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
testRunner.When("selected type from the list and then select already created configuration set \'Se" +
                    "t1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
testRunner.Then("its detail will be listed i.e. selected parameter \'1 - Pump Node - Node\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
testRunner.When("selected the set \'Set1\' and clicked \'Rename\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
testRunner.Then("A pop-up will appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
testRunner.When("entered same name there \'Set1\' and clicked confirm", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
testRunner.Then("Make sure the it prompts for \'Name already exists\' message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
testRunner.When("entered unique name \'Set2\'and clicked confirm  from \'Set1\' and clicked \'Rename\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
testRunner.Then("set name should be changed to \'Set2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
testRunner.When("selected type from the list and then selected already created configuration set \'" +
                    "Set2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
testRunner.And("added few entries \'1 - Pump Node - User Tag\', \'3 - Dry Pump Current - Analogue\' i" +
                    "n the set detail and clicked Save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
testRunner.Then("configuration set changes should be saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
testRunner.When("clicked on the entry in right hand list and clicked Edit \'3 - Dry Pump Current - " +
                    "Analogue\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
testRunner.Then("A Edit pop-up will appear contains title \'Set2\' and \'3 - Dry Pump Current - Analo" +
                    "gue\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
testRunner.When("made few changes i.e edit High alarm value to \'50\' and clicked save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
testRunner.Then("Changes made should be saved for parameter \'3 - Dry Pump Current - Analogue\' with" +
                    " new high alarm value \'50\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
testRunner.When("selected the set \'Set2\' and clicked \'Copy\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
testRunner.Then("\'Current copied Configuration Set: \"Set2\"\' message will appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
testRunner.When("selected another type or same type from list and clicked paste", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
testRunner.Then("A pop-up will appear to enter new name for the copying set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
testRunner.When("Entered name and clicked ok", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
testRunner.Then("The profile should be copied to the selected node with new name.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
testRunner.When("selected the set \'Set2\' and clicked \'Delete\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
testRunner.Then("The set \'Set2\' should be deleted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
testRunner.And("deleted copied folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Configuration Handler - General Usage")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("ConfigurationHandler")]
        public virtual void ConfigurationHandler_GeneralUsage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Configuration Handler - General Usage", null, new string[] {
                        "SplitServer",
                        "SingleServer",
                        "ConfigurationHandler"});
#line 71
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 72
testRunner.Given("navigated to Configuration Handler page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 73
testRunner.When("selected Equipment Type in the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
testRunner.And("deleted if Configration Set already exists with same name \'Set3\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
testRunner.And("deleted if Configration Set already exists with same name \'Set4\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
testRunner.And("clicked Create button.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
testRunner.Then("Create Configuration sdet pop-up will appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 78
testRunner.When("gave a unique name \'Set3\' to configuration set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
testRunner.And("selected required radio button from the list and click create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
testRunner.Then("Configuration Set with given name \'Set3\' will be created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
testRunner.When("Selected \'Set3 \'and added the parameters required \'1 - Pump Node - Node\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
testRunner.Then("configuration set changes should be saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 83
testRunner.When("clicked Create button.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
testRunner.And("gave a unique name \'Set4\' to configuration set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
testRunner.And("selected required radio button from the list and click create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
testRunner.Then("Configuration Set with given name \'Set4\' will be created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 87
testRunner.When("Selected \'Set4 \'and added the parameters required \'1 - Pump Node - Node\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
testRunner.Then("configuration set changes should be saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
testRunner.When("Selected created configuaration sets and clicked compare button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
testRunner.Then("pop up should appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 91
testRunner.When("clicked same radio button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
testRunner.Then("similar parameters should shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

