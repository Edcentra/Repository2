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
    [NUnit.Framework.DescriptionAttribute("InstallPostTests")]
    public partial class InstallPostTestsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "InstallPostTests.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "InstallPostTests", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Installer - Installed Components in Single and Application Server")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("ApplicationServer")]
        public virtual void Installer_InstalledComponentsInSingleAndApplicationServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Installer - Installed Components in Single and Application Server", null, new string[] {
                        "SingleServer",
                        "ApplicationServer"});
#line 5
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
testRunner.When("I open the Programs and Features in the Control Panel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Components"});
            table1.AddRow(new string[] {
                        "Microsoft .NET Framework 4.5.1 Multi-Targeting Pack"});
            table1.AddRow(new string[] {
                        "Microsoft ASP.NET 2.0 AJAX Extensions 1.0"});
            table1.AddRow(new string[] {
                        "Microsoft SQL Server 2016"});
            table1.AddRow(new string[] {
                        "Microsoft SOAP Toolkit 2.0 SP2"});
            table1.AddRow(new string[] {
                        "Microsoft Visual C++ 2008 Redistributable"});
            table1.AddRow(new string[] {
                        "Microsoft Visual C++ 2010  x86 Redistributable"});
            table1.AddRow(new string[] {
                        "Microsoft XML Parser and SDK"});
            table1.AddRow(new string[] {
                        "System.Data.SQLite"});
#line 7
testRunner.Then("I see the components \'<Components>\' installed in the system", ((string)(null)), table1, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Installer - Installed Components in Database Server")]
        [NUnit.Framework.CategoryAttribute("DatabaseServer")]
        public virtual void Installer_InstalledComponentsInDatabaseServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Installer - Installed Components in Database Server", null, new string[] {
                        "DatabaseServer"});
#line 20
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 21
testRunner.When("I open the Programs and Features in the Control Panel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Components"});
            table2.AddRow(new string[] {
                        "Microsoft .NET Framework 4.5.1 Multi-Targeting Pack"});
            table2.AddRow(new string[] {
                        "Microsoft SQL Server 2016"});
            table2.AddRow(new string[] {
                        "Microsoft Visual C++ 2008 Redistributable"});
            table2.AddRow(new string[] {
                        "Microsoft Visual C++ 2010  x86 Redistributable"});
            table2.AddRow(new string[] {
                        "System.Data.SQLite"});
#line 22
testRunner.Then("I see the components \'<Components>\' installed in the system", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Installer - Active Edwards Scada Services")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("ApplicationServer")]
        public virtual void Installer_ActiveEdwardsScadaServices()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Installer - Active Edwards Scada Services", null, new string[] {
                        "SingleServer",
                        "ApplicationServer"});
#line 34
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ServiceName"});
            table3.AddRow(new string[] {
                        "Edwards Scada Agent Framework"});
            table3.AddRow(new string[] {
                        "Edwards Scada Agent Framework WatchDog"});
            table3.AddRow(new string[] {
                        "Edwards Scada Agent Manager"});
            table3.AddRow(new string[] {
                        "Edwards Scada Application Logging"});
            table3.AddRow(new string[] {
                        "Edwards Scada Autopager"});
            table3.AddRow(new string[] {
                        "Edwards Scada Current State Provisioner"});
            table3.AddRow(new string[] {
                        "Edwards Scada Data Extraction"});
            table3.AddRow(new string[] {
                        "Edwards Scada Data Logger"});
            table3.AddRow(new string[] {
                        "Edwards Scada Data Provisioner"});
            table3.AddRow(new string[] {
                        "EdwardsScadaIssueManager"});
            table3.AddRow(new string[] {
                        "Edwards Scada Multi Lingual Pooler"});
            table3.AddRow(new string[] {
                        "Edwards Scada NetworkBridge"});
            table3.AddRow(new string[] {
                        "Edwards Scada PlugIn Tunneller"});
            table3.AddRow(new string[] {
                        "Edwards Scada Predictive Diagnostics"});
            table3.AddRow(new string[] {
                        "Edwards Scada Protection"});
            table3.AddRow(new string[] {
                        "Edwards Scada SECS GEM"});
            table3.AddRow(new string[] {
                        "Edwards Scada Session Manager"});
            table3.AddRow(new string[] {
                        "Edwards Scada Software Generated Events"});
            table3.AddRow(new string[] {
                        "Edwards Scada System HealthMonitor"});
            table3.AddRow(new string[] {
                        "Edwards Scada Task Scheduler"});
            table3.AddRow(new string[] {
                        "Edwards Scada XML Repository"});
#line 35
testRunner.Then("I see the following services installed in the system", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Installer - Active Edwards Scada Services for Database Server")]
        [NUnit.Framework.CategoryAttribute("DatabaseServer")]
        public virtual void Installer_ActiveEdwardsScadaServicesForDatabaseServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Installer - Active Edwards Scada Services for Database Server", null, new string[] {
                        "DatabaseServer"});
#line 60
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "ServiceName"});
            table4.AddRow(new string[] {
                        "Edwards Scada Application Logging"});
            table4.AddRow(new string[] {
                        "Edwards Scada Data Extraction"});
            table4.AddRow(new string[] {
                        "Edwards Scada Multi Lingual Pooler"});
            table4.AddRow(new string[] {
                        "Edwards Scada System HealthMonitor"});
#line 61
testRunner.Then("I see the following services installed in the system", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Installer - Windows Firewall")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("ApplicationServer")]
        public virtual void Installer_WindowsFirewall()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Installer - Windows Firewall", null, new string[] {
                        "SingleServer",
                        "ApplicationServer"});
#line 70
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 71
testRunner.Then("I check whether Symantec is installed in the system", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
testRunner.When("I open Windows Firewall Advnace Settings and click on the Inbound Rules tree node" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "InboundRuleExceptions"});
            table5.AddRow(new string[] {
                        "Edwards WebAgentUDP"});
            table5.AddRow(new string[] {
                        "Edwards Agent HMI Frame"});
            table5.AddRow(new string[] {
                        "Edwards Agent Service"});
            table5.AddRow(new string[] {
                        "Edwards Agent_Framework_Heartbeat"});
            table5.AddRow(new string[] {
                        "Edwards AgentFrameworkTCP"});
            table5.AddRow(new string[] {
                        "Edwards AgentFrameworkTCP # 2"});
            table5.AddRow(new string[] {
                        "Edwards AgentFrameworkTCP # 3"});
            table5.AddRow(new string[] {
                        "Edwards AgentFrameworkTCP # 4"});
            table5.AddRow(new string[] {
                        "Edwards AgentFrameworkTCP # 5"});
            table5.AddRow(new string[] {
                        "Edwards AgentFrameworkWCF"});
            table5.AddRow(new string[] {
                        "Edwards Application Logging"});
            table5.AddRow(new string[] {
                        "Edwards AutoPagerTCP"});
            table5.AddRow(new string[] {
                        "Edwards DataExtractionTCP"});
            table5.AddRow(new string[] {
                        "Edwards DataProvisionerTCP"});
            table5.AddRow(new string[] {
                        "Edwards DCOM_TCP135"});
            table5.AddRow(new string[] {
                        "Edwards EADS CallbackTCP"});
            table5.AddRow(new string[] {
                        "Edwards EADS Coordinator CallbackTCP"});
            table5.AddRow(new string[] {
                        "Edwards EADS Coordinator Event ConsumerTCP"});
            table5.AddRow(new string[] {
                        "Edwards EADS Coordinator Trace Ts StoreTCP"});
            table5.AddRow(new string[] {
                        "Edwards EADS ModelBuilder Event ConsumerTCP"});
            table5.AddRow(new string[] {
                        "Edwards EADS Processing Node Ts StoreTCP"});
            table5.AddRow(new string[] {
                        "Edwards EADS UI WebApiTCP"});
            table5.AddRow(new string[] {
                        "Edwards EtherNIMAgentTCP"});
            table5.AddRow(new string[] {
                        "Edwards EtherNIMAgentUDP"});
            table5.AddRow(new string[] {
                        "Edwards Fleet Management Agent MQTT"});
            table5.AddRow(new string[] {
                        "Edwards Fleet Management HTTP"});
            table5.AddRow(new string[] {
                        "Edwards Fleet Management RSYNC"});
            table5.AddRow(new string[] {
                        "Edwards Fleet Management Server MQTT"});
            table5.AddRow(new string[] {
                        "Edwards GEMSECSIIDefaultPort"});
            table5.AddRow(new string[] {
                        "Edwards GEMSECSIITCP"});
            table5.AddRow(new string[] {
                        "Edwards IGateWayAgentUDP"});
            table5.AddRow(new string[] {
                        "Edwards IGateWayAgentUDP"});
            table5.AddRow(new string[] {
                        "Edwards Model Builder WCF Endpoint"});
            table5.AddRow(new string[] {
                        "Edwards Model Builder WCF Endpoint"});
            table5.AddRow(new string[] {
                        "Edwards MultilingualPoolerTCP"});
            table5.AddRow(new string[] {
                        "Edwards Network Bridge Service"});
            table5.AddRow(new string[] {
                        "Edwards NetworkBridgeTCP"});
            table5.AddRow(new string[] {
                        "Edwards PluginTunnellerTCP"});
            table5.AddRow(new string[] {
                        "Edwards PredictiveDiagnosticsSGETCP"});
            table5.AddRow(new string[] {
                        "Edwards ProtectionRemotingTCP"});
            table5.AddRow(new string[] {
                        "Edwards RSSTCP"});
            table5.AddRow(new string[] {
                        "Edwards SessionPoolerTCP"});
            table5.AddRow(new string[] {
                        "Edwards SEV Provisioner"});
            table5.AddRow(new string[] {
                        "Edwards SHM_Console_Service_Heartbeat"});
            table5.AddRow(new string[] {
                        "Edwards SHM_Heartbeats"});
            table5.AddRow(new string[] {
                        "Edwards SystemHealthMonitor ConsoleWindow"});
            table5.AddRow(new string[] {
                        "Edwards WebAgentUDP"});
#line 73
testRunner.Then("I see exceptions starting with Edwards", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Installer - Check IIS")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("ApplicationServer")]
        public virtual void Installer_CheckIIS()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Installer - Check IIS", null, new string[] {
                        "SingleServer",
                        "ApplicationServer"});
#line 125
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 126
testRunner.Given("I launch the Server Manager app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 127
testRunner.When("I click on Add roles and Features and click on next until get to Server Roles", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 128
testRunner.And("I expand Web Server (IIS) -> Web Server -> Application Development", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
testRunner.Then("\'ASP.NET 4.6\' and \'ISAPI Filters\' should be installed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
testRunner.When("I click on cancel button on the wizard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 131
testRunner.And("I click on Tools menu and open \'Internet Information Services (IIS) Manager\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
testRunner.And("I expand Default Sites", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Directories"});
            table6.AddRow(new string[] {
                        "EdwardsScada"});
            table6.AddRow(new string[] {
                        "LoggingCoordinator"});
#line 133
testRunner.Then("I should see the following two virtual directories", ((string)(null)), table6, "Then ");
#line 137
testRunner.When("I navigate to \'http://localhost/\' in the browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 138
testRunner.Then("Edcentra login screen should appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Agent Framework needs longer service start delay")]
        public virtual void AgentFrameworkNeedsLongerServiceStartDelay()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Agent Framework needs longer service start delay", null, ((string[])(null)));
#line 141
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 142
testRunner.When("On the agent PC, open eventvwr.msc", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 143
testRunner.Then("Event Viewer opens", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 144
testRunner.When("Go to the Scada event log, and check for the entries labled Agent Framework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 145
testRunner.Then("Agent Framework event log should state \"Agent Framework deferred start for \'60\' s" +
                    "econds.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Installer - Firewall Rules may not be in correct Place")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("ApplicationServer")]
        public virtual void Installer_FirewallRulesMayNotBeInCorrectPlace()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Installer - Firewall Rules may not be in correct Place", null, new string[] {
                        "SingleServer",
                        "ApplicationServer"});
#line 150
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 151
testRunner.When("I open Allow an app or feature through Windows Firewall", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "AllowedAps"});
            table7.AddRow(new string[] {
                        "Edwards WebAgentUDP"});
            table7.AddRow(new string[] {
                        "Edwards Agent HMI Frame"});
            table7.AddRow(new string[] {
                        "Edwards Agent Service"});
            table7.AddRow(new string[] {
                        "Edwards Agent_Framework_Heartbeat"});
            table7.AddRow(new string[] {
                        "Edwards AgentFrameworkTCP"});
            table7.AddRow(new string[] {
                        "Edwards AgentFrameworkTCP # 2"});
            table7.AddRow(new string[] {
                        "Edwards AgentFrameworkTCP # 3"});
            table7.AddRow(new string[] {
                        "Edwards AgentFrameworkTCP # 4"});
            table7.AddRow(new string[] {
                        "Edwards AgentFrameworkTCP # 5"});
            table7.AddRow(new string[] {
                        "Edwards AgentFrameworkWCF"});
            table7.AddRow(new string[] {
                        "Edwards Application Logging"});
            table7.AddRow(new string[] {
                        "Edwards AutoPagerTCP"});
            table7.AddRow(new string[] {
                        "Edwards DataExtractionTCP"});
            table7.AddRow(new string[] {
                        "Edwards DataProvisionerTCP"});
            table7.AddRow(new string[] {
                        "Edwards DCOM_TCP135"});
            table7.AddRow(new string[] {
                        "Edwards EADS CallbackTCP"});
            table7.AddRow(new string[] {
                        "Edwards EADS Coordinator CallbackTCP"});
            table7.AddRow(new string[] {
                        "Edwards EADS Coordinator Event ConsumerTCP"});
            table7.AddRow(new string[] {
                        "Edwards EADS Coordinator Trace Ts StoreTCP"});
            table7.AddRow(new string[] {
                        "Edwards EADS ModelBuilder Event ConsumerTCP"});
            table7.AddRow(new string[] {
                        "Edwards EADS Processing Node Ts StoreTCP"});
            table7.AddRow(new string[] {
                        "Edwards EADS UI WebApiTCP"});
            table7.AddRow(new string[] {
                        "Edwards EtherNIMAgentTCP"});
            table7.AddRow(new string[] {
                        "Edwards EtherNIMAgentUDP"});
            table7.AddRow(new string[] {
                        "Edwards Fleet Management Agent MQTT"});
            table7.AddRow(new string[] {
                        "Edwards Fleet Management HTTP"});
            table7.AddRow(new string[] {
                        "Edwards Fleet Management RSYNC"});
            table7.AddRow(new string[] {
                        "Edwards Fleet Management Server MQTT"});
            table7.AddRow(new string[] {
                        "Edwards GEMSECSIIDefaultPort"});
            table7.AddRow(new string[] {
                        "Edwards GEMSECSIITCP"});
            table7.AddRow(new string[] {
                        "Edwards IGateWayAgentUDP"});
            table7.AddRow(new string[] {
                        "Edwards IGateWayAgentUDP"});
            table7.AddRow(new string[] {
                        "Edwards Model Builder WCF Endpoint"});
            table7.AddRow(new string[] {
                        "Edwards Model Builder WCF Endpoint"});
            table7.AddRow(new string[] {
                        "Edwards MultilingualPoolerTCP"});
            table7.AddRow(new string[] {
                        "Edwards Network Bridge Service"});
            table7.AddRow(new string[] {
                        "Edwards NetworkBridgeTCP"});
            table7.AddRow(new string[] {
                        "Edwards PluginTunnellerTCP"});
            table7.AddRow(new string[] {
                        "Edwards PredictiveDiagnosticsSGETCP"});
            table7.AddRow(new string[] {
                        "Edwards ProtectionRemotingTCP"});
            table7.AddRow(new string[] {
                        "Edwards RSSTCP"});
            table7.AddRow(new string[] {
                        "Edwards SessionPoolerTCP"});
            table7.AddRow(new string[] {
                        "Edwards SEV Provisioner"});
            table7.AddRow(new string[] {
                        "Edwards SHM_Console_Service_Heartbeat"});
            table7.AddRow(new string[] {
                        "Edwards SHM_Heartbeats"});
            table7.AddRow(new string[] {
                        "Edwards SystemHealthMonitor ConsoleWindow"});
            table7.AddRow(new string[] {
                        "Edwards WebAgentUDP"});
            table7.AddRow(new string[] {
                        "Edwards WebAgentUDP"});
#line 152
testRunner.Then("I should see list of Edwards labelled rules with Public and Private checked", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Installer - Check Database")]
        public virtual void Installer_CheckDatabase()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Installer - Check Database", null, ((string[])(null)));
#line 203
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 204
testRunner.When("Check D:\\Edwards\\Scada\\Database - { Installation | Upgrade }x.y\\schema.manifest.l" +
                    "og for errors.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 205
testRunner.Then("There should be no substantive errors.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 206
testRunner.When("Run SQL Management Studio and try to access the scada_Production database using W" +
                    "indows Authentication", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 207
testRunner.Then("This should fail.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 208
testRunner.When("Still using SQL Management Studio, log on using SQL Authentication and the fsu_us" +
                    "er and sa accounts.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 209
testRunner.And("Ensure that \'Databases\' have \'scada_Production\' under the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 210
testRunner.When("Ensure that \'ReportServer$FABWORKS\' and \'ReportServer$FABWORKSTempDB\' also exist." +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 211
testRunner.And("Ensure that table \'dbo.fst_INS_Parameters\' exists in the master database.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "AgentJobs"});
            table8.AddRow(new string[] {
                        "fsj_ALE_ParameterAlertMappingMaintenance"});
            table8.AddRow(new string[] {
                        "fsj_ARC_Import"});
            table8.AddRow(new string[] {
                        "fsj_Data_Logging"});
            table8.AddRow(new string[] {
                        "fsj_DBA_AlignAlert"});
            table8.AddRow(new string[] {
                        "fsj_DBA_KillLeadBlockerProcesses"});
            table8.AddRow(new string[] {
                        "fsj_DBA_TableRowCountSnapshot"});
            table8.AddRow(new string[] {
                        "fsj_GEN_CalculateAvailabilityByDate"});
            table8.AddRow(new string[] {
                        "fsj_GEN_CalculateConsumptionByDate"});
            table8.AddRow(new string[] {
                        "fsj_GEN_GenerateSystemSerialNumber"});
            table8.AddRow(new string[] {
                        "fsj_GEN_ParentGroupDailyTotalsCatchup"});
            table8.AddRow(new string[] {
                        "fsj_GEN_ParentGroupDailyTotalsTrigger"});
            table8.AddRow(new string[] {
                        "fsj_GEN_UptimeDataCount"});
            table8.AddRow(new string[] {
                        "fsj_MAIN_DailyDBMaintenance"});
            table8.AddRow(new string[] {
                        "fsj_MAIN_WeeklyDataMaintenance"});
            table8.AddRow(new string[] {
                        "fsj_MAIN_WeeklyDBMaintenance"});
            table8.AddRow(new string[] {
                        "fsj_REP_ConsumptionDataBackLoad"});
#line 212
testRunner.When("Check that with names like ‘fsj_’ exist under SQL Server Agent\\Jobs.", ((string)(null)), table8, "When ");
#line 230
testRunner.When("Check server by right-clicking the server name and select Properties", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 231
testRunner.And("Check database by right-clicking scada_Production and select Properties", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 232
testRunner.Then("The collations should match.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 233
testRunner.When("Check file system security permissions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 234
testRunner.Then("MSSQL$FABWORKS has full access to the files", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 235
testRunner.When("check file If they exists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 236
testRunner.Then("check file system security permissions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ensure RELEASE assemblies are deployed")]
        public virtual void EnsureRELEASEAssembliesAreDeployed()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure RELEASE assemblies are deployed", null, ((string[])(null)));
#line 238
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 239
testRunner.When("Copy ScanAssemblyBuildType.exe to D drive.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 240
testRunner.Then("pen a command window and ensure that the present working directory is D", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 241
testRunner.When("Run ScanAssemblyBuildType.exe and await the results.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 242
testRunner.Then("There to be \'0\' matches, once those marked as exceptions have been accounted for." +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
