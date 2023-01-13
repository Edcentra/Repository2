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
    [NUnit.Framework.DescriptionAttribute("InstallEdcentra")]
    public partial class InstallEdcentraFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "InstallEdcentra.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "InstallEdcentra", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Install Edcentra application")]
        [NUnit.Framework.CategoryAttribute("Install")]
        public virtual void InstallEdcentraApplication()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Install Edcentra application", null, new string[] {
                        "Install"});
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
 testRunner.Given("Go to Installer folder and Launch Edwards.Installer.Launcher.exe file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.When("Scroll down to accept the software license and support agreement and click on “I " +
                    "Accept”.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
 testRunner.And("Select all three servers option like Agent PC, Application and Database server an" +
                    "d Click on Install", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Configure Agents")]
        [NUnit.Framework.CategoryAttribute("ConfigureAgent")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        public virtual void ConfigureAgents()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Configure Agents", null, new string[] {
                        "ConfigureAgent",
                        "SingleServer"});
#line 11
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 12
 testRunner.When("Run Agent Configuration (shortcut on desktop)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.When("Set pin value \'9110\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.And("added \'Turbo\' \'Web\' \'Modbus\' agents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("Selected PC Interface Network Id card under Relay tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Restore VM")]
        [NUnit.Framework.CategoryAttribute("CleanVM")]
        public virtual void RestoreVM()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Restore VM", null, new string[] {
                        "CleanVM"});
#line 22
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 23
testRunner.Given("Go to VM url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
testRunner.When("Logged in by username \'root\' and password \'root@123\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.Then("I should be navigated to VMWare ESXi page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
testRunner.When("I selected Slave VM", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
testRunner.And("Selected Manage Snapshot option under Snapshots", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.Then("Manage snapshots pop up should be opened \'Manage snapshots - SSISINAS172\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
testRunner.When("Selected Restore VM", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
testRunner.And("clicked Restore snapshot", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
testRunner.And("clicked Restore button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
testRunner.And("clicked close button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
testRunner.Then("after few minutes VM should restore", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Scenarios under console")]
        [NUnit.Framework.CategoryAttribute("RunScenariosUnderConsole")]
        public virtual void RunScenariosUnderConsole()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Scenarios under console", null, new string[] {
                        "RunScenariosUnderConsole"});
#line 37
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 38
testRunner.Given("Go to VM url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
testRunner.When("Logged in by username \'root\' and password \'root@123\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.Then("I should be navigated to VMWare ESXi page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
testRunner.When("I selected VM Shalu Automation VM", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
testRunner.And("Open browser Console", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Open up SQL Manager / Log In and go to scada_production and add the number 17 to " +
            "the row ApplicationID")]
        [NUnit.Framework.CategoryAttribute("ConfigurationHandlerSetUp")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        public virtual void OpenUpSQLManagerLogInAndGoToScada_ProductionAndAddTheNumber17ToTheRowApplicationID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open up SQL Manager / Log In and go to scada_production and add the number 17 to " +
                    "the row ApplicationID", null, new string[] {
                        "ConfigurationHandlerSetUp",
                        "SplitServer",
                        "SingleServer"});
#line 47
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 48
testRunner.Given("Find the table fst_SEC_InstalledApplication and choose edit. Add the number to th" +
                    "e row ApplicationID, save and close table.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Install Edcentra application In Database Server")]
        [NUnit.Framework.CategoryAttribute("DataBaseInstall")]
        public virtual void InstallEdcentraApplicationInDatabaseServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Install Edcentra application In Database Server", null, new string[] {
                        "DataBaseInstall"});
#line 51
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 52
testRunner.Given("Go to Installer folder and Launch Edwards.Installer.Launcher.exe file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 53
testRunner.When("Scroll down to accept the software license and support agreement and click on “I " +
                    "Accept”.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
testRunner.And("Select servers option Database server and give Application ServerName \'ShaluVM2\' " +
                    "Click on Install", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Install Edcentra application In Agent Server")]
        [NUnit.Framework.CategoryAttribute("AgentInstall")]
        public virtual void InstallEdcentraApplicationInAgentServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Install Edcentra application In Agent Server", null, new string[] {
                        "AgentInstall"});
#line 57
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 58
testRunner.Given("Go to Installer folder and Launch Edwards.Installer.Launcher.exe file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
testRunner.When("Scroll down to accept the software license and support agreement and click on “I " +
                    "Accept”.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
testRunner.And("Select servers option Database server and give Application serverName \'ShaluVM2\' " +
                    "and Database serverName \'EDC2\' Click on Install", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Install Edcentra application In Application Server")]
        [NUnit.Framework.CategoryAttribute("ApplicationInstall")]
        public virtual void InstallEdcentraApplicationInApplicationServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Install Edcentra application In Application Server", null, new string[] {
                        "ApplicationInstall"});
#line 63
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 64
testRunner.Given("Go to Installer folder and Launch Edwards.Installer.Launcher.exe file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
testRunner.When("Scroll down to accept the software license and support agreement and click on “I " +
                    "Accept”.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
testRunner.And("Select servers option Database server and give Database serverName \'EDC2\' Click o" +
                    "n Install", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Restore Servers")]
        [NUnit.Framework.CategoryAttribute("CleanSplitServers")]
        [NUnit.Framework.TestCaseAttribute("Edc2_Simbu", "CleanUp Server DB", "Edc3_Simbu", "CleanUp Server Agent", "ShaluVM2", "CleanUp Server Application", null)]
        public virtual void RestoreServers(string vmName, string snapShotName, string vmName1, string snapShotName1, string vmName2, string snapShotName2, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CleanSplitServers"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Restore Servers", null, @__tags);
#line 69
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 70
testRunner.Given("Go to VM url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 71
testRunner.When("Logged in by username \'root\' and password \'root@123\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
testRunner.Then("I should be navigated to VMWare ESXi page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
testRunner.When(string.Format("I select VMNames \'{0}\' \'{1}\' \'{2}\' \'{3}\' \'{4}\' \'{5}\' and restore the VM\'s", vmName, snapShotName, vmName1, snapShotName1, vmName2, snapShotName2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Configure Agents on split server")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("ConfigureAgentSplit")]
        public virtual void ConfigureAgentsOnSplitServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Configure Agents on split server", null, new string[] {
                        "SplitServer",
                        "ConfigureAgentSplit"});
#line 81
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 82
testRunner.When("Run Agent Configuration (shortcut on desktop)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 83
testRunner.And("I click server \'S14\' \'S16\' lookup IP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
testRunner.When("Set pin value \'9110\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
testRunner.And("added \'Turbo\' \'Web\' \'Modbus\' agents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
testRunner.And("Selected PC Interface Network Id card under Relay tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
