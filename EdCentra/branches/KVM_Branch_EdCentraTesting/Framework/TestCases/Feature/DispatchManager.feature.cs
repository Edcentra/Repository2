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
    [NUnit.Framework.DescriptionAttribute("DispatchManager")]
    public partial class DispatchManagerFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DispatchManager.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "DispatchManager", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
testRunner.Given("opened EDCENTRA url in browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
testRunner.When("entered Username as \'administrator\' and Password  as\'toolkit\' and I clicked login" +
                    " button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 6
testRunner.Then("should be navigated to home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 7
testRunner.When("selected dispatch manager option under Configure drop down", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dispatch Manager - General Settings")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("DispatchManager")]
        public virtual void DispatchManager_GeneralSettings()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dispatch Manager - General Settings", null, new string[] {
                        "SplitServer",
                        "SingleServer",
                        "DispatchManager"});
#line 12
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 13
 testRunner.When("Configure the options on the Dispatch Manager General Settings screen \'Test Site\'" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.And("Apply is used", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.Then("the settings should be saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dispatch Manager - Configure SMTP Paging")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("DispatchManager")]
        public virtual void DispatchManager_ConfigureSMTPPaging()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dispatch Manager - Configure SMTP Paging", null, new string[] {
                        "SplitServer",
                        "SingleServer",
                        "DispatchManager"});
#line 20
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 21
    testRunner.When("navigated to SMTP tab under Page Settings tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
    testRunner.And("login user \'administrator\' created new SMTP page From as \'support@edwardsvacuum.c" +
                    "om\' destination with SMTP IP of \'160.100.30.222\', port number as \'25\' and To add" +
                    "ress as \'shalu.gupta@edwardsvacuum.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("Clicked Test button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.Then("A message \'A test message has been placed on the queue.\' should be displayed.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dispatch Manager - Configure Other Paging")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("DispatchManager")]
        public virtual void DispatchManager_ConfigureOtherPaging()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dispatch Manager - Configure Other Paging", null, new string[] {
                        "SplitServer",
                        "SingleServer",
                        "DispatchManager"});
#line 29
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 30
   testRunner.When("navigated to SMTP tab under Page Settings tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
   testRunner.And("Clicked SMTP auth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
   testRunner.And("login user \'administrator\' created new SMTP Auth page From as \'support@edwardsvac" +
                    "uum.com\' destination with SMTP IP of \'160.100.30.222\', port number as \'25\' and T" +
                    "o address as \'shalu.gupta@edwardsvacuum.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
   testRunner.And("navigated to General Settings page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
   testRunner.Then("General settings page should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
   testRunner.When("Clicked on manual page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
   testRunner.Then("\'Send a Page Message\' pop-up will appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
   testRunner.When("Typed in Message \'Test Mail\' and clicked Send button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
   testRunner.Then("\'Page has been submitted\' message should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
   testRunner.When("navigate to SNPP tab Under Page Settings tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
   testRunner.And("Clicked SNPP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
   testRunner.And("login user \'administrator\' created new SNPP page with SNPP IP of \'160.100.30.222\'" +
                    ", page number as \'252\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
   testRunner.And("Clicked Test button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
   testRunner.Then("A message \'A test message has been placed on the queue.\' should be displayed.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
   testRunner.When("navigate to PageMate tab Under Page Settings tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
   testRunner.And("Clicked PageMate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
   testRunner.And("login user \'administrator\' created new PageMate page with page number as \'1452\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
   testRunner.And("Clicked Test button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
   testRunner.Then("A message \'A test message has been placed on the queue.\' should be displayed.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
   testRunner.When("navigated to Derdack tab under Page Settings tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
   testRunner.And("Clicked Derdack", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
   testRunner.And("login user \'administrator\' created new Derdack page with DerdackUserLogin of \'Tes" +
                    "t\', Server SOAP URL as \'www.edwards.com\' and Provider Name as \'atlascopco\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
   testRunner.And("Clicked Test button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
   testRunner.Then("A message \'A test message has been placed on the queue.\' should be displayed.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dispatch Manager - Pause and Resume")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("ApplicationServer")]
        [NUnit.Framework.CategoryAttribute("DispatchManager")]
        public virtual void DispatchManager_PauseAndResume()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dispatch Manager - Pause and Resume", null, new string[] {
                        "SingleServer",
                        "ApplicationServer",
                        "DispatchManager"});
#line 58
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 59
 testRunner.Then("General settings page should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
 testRunner.When("Press the Service status button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
 testRunner.Then("The service status should display accordingly action taken", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
 testRunner.And("Check the AAP console utility in the Taskbar and observe the text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.When("Press the Service status button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
 testRunner.Then("The service status should display accordingly action taken", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
 testRunner.And("Check the AAP console utility in the Taskbar and observe the text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dispatch Manager - Send a manual page")]
        [NUnit.Framework.CategoryAttribute("DispatchManager")]
        public virtual void DispatchManager_SendAManualPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dispatch Manager - Send a manual page", null, new string[] {
                        "DispatchManager"});
#line 68
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 69
testRunner.When("navigated to SMTP tab under Page Settings tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
testRunner.And("Clicked SMTP auth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
testRunner.And("login user \'administrator\' created new SMTP Auth page From as \'support@edwardsvac" +
                    "uum.com\' destination with SMTP IP of \'160.100.30.222\', port number as \'25\' and T" +
                    "o address as \'shalu.gupta@edwardsvacuum.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
testRunner.And("Clicked to General Settings link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
testRunner.Then("General Settings detail page should be displayed.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
testRunner.When("Clicked on manual page.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
testRunner.Then("\'Send a Page Message\' pop-up will appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
testRunner.When("Selected Engineer and Select SMTP in Page Destination.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
testRunner.And("Typed in Message \'Test Mail\' and clicked Send button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
testRunner.Then("\'Page has been submitted\' message should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dispatch Manager - Configure Simple Scheduling")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("ApplicationServer")]
        [NUnit.Framework.CategoryAttribute("DispatchManager")]
        public virtual void DispatchManager_ConfigureSimpleScheduling()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dispatch Manager - Configure Simple Scheduling", null, new string[] {
                        "SingleServer",
                        "ApplicationServer",
                        "DispatchManager"});
#line 85
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 86
testRunner.When("I click Device Explorer link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
testRunner.Then("I should navigated to Device Explorer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
testRunner.When("I clicked on add folder/system icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 89
testRunner.And("I entered folder name and Clicked on Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
testRunner.Then("I should be able to see Folder Added Successfully Message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 91
testRunner.When("I click OK button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
testRunner.Then("I should able to see newly added folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
testRunner.When("I click Find Equipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
testRunner.And("Deleted all equipments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
testRunner.And("Launch Turbo simulator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
testRunner.And("Select an equipmentName \'TURBO4002\', equipmentType \'Turbo Pump\' and iPPortNumber\'" +
                    "4002\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
testRunner.And("navigated to SMTP tab under Page Settings tab.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
testRunner.And("Clicked SMTP auth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
testRunner.And("login user \'administrator\' created new SMTP Auth page From as \'support@edwardsvac" +
                    "uum.com\' destination with SMTP IP of \'160.100.30.222\', port number as \'25\' and T" +
                    "o address as \'shalu.gupta@edwardsvacuum.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
testRunner.And("navigated to Dispatch Manager->Scheduler.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
testRunner.When("Clicked Week days check box, All Day Check box and selected previously created Pa" +
                    "geDestination\'Admin, FabWorks (administrator) (SMTPAuth)\'.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
testRunner.And("clicked Apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
testRunner.Then("The changes made in scheduling entry should be displayed and new PageDestination\'" +
                    "Admin, FabWorks (administrator) (SMTPAuth)\' entry added in the list.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 104
testRunner.When("Created an alert\'18\' from a piece of equipment\'4002\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 105
testRunner.Then("The alert should arrive via the dispatch method selected.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 106
testRunner.When("Cleared alert from \'4002\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 107
testRunner.And(@"Edited the previous schedule PageDestination'(SMTPAuth)' entry(Select the scheduler entry in the list to edit it) edit with  SMTP page From as 'support@edwardsvacuum.com' destination with SMTP IP of '160.100.30.222' and To address as 'shalu.gupta@external.atlascopco.com' and add an Alternative Destination'Admin, FabWorks (administrator) (SMTP)' with an After Minutes value of one", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
testRunner.Then("The scheduling PageDestination\'Admin, FabWorks (administrator) (SMTP)\' entry shou" +
                    "ld be displayed with a blue pointer indicating that escalation has been establis" +
                    "hed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
testRunner.When("Create an alert \'19\' from a piece of equipment\'4002\' and wait for two minutes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 110
testRunner.Then("The alert should arrive via the dispatch method selected. After a minute the alte" +
                    "rnative page destination should be used (escalated)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 111
testRunner.When("Cleared alert from \'4002\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
testRunner.And("Edit the previous schedule entry and add a time (Between [____] And [____] (Leave" +
                    " blank for all day) which is two hours from now", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
testRunner.Then("The schedule\'Admin, FabWorks (administrator) (SMTP)\' entry should display with th" +
                    "e Start and End columns set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 114
testRunner.When("Created an alert\'18\' from a piece of equipment\'4002\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 115
testRunner.Then("The alert should NOT arrive via the dispatch method selected.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 116
testRunner.When("Cleared alert from \'4002\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 117
testRunner.Then("the new schedule window isn\'t shown, click on New Button to create new schedule.N" +
                    "ew Schedule form will be displayed.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dispatch Manager - Send a test page")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("ApplicationServer")]
        [NUnit.Framework.CategoryAttribute("DispatchManager")]
        public virtual void DispatchManager_SendATestPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dispatch Manager - Send a test page", null, new string[] {
                        "SingleServer",
                        "ApplicationServer",
                        "DispatchManager"});
#line 122
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 123
testRunner.When("Navigated to Page Destinations Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
testRunner.And("login user \'testuser\' created new SMTP page From as \'support@edwardsvacuum.com\' d" +
                    "estination with SMTP IP of \'160.100.30.222\', port number as \'25\' and To address " +
                    "as \'shalu.gupta@edwardsvacuum.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
testRunner.Then("The dispatcher details should display along with [Test], [Apply] and [Delete] but" +
                    "tons", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 126
testRunner.When("Clicked Test button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 127
testRunner.Then("A message \'A test message has been placed on the queue.\' should be displayed.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
testRunner.And(@"message ' Message [Test message] placed on queue for'dispayed in Autopager console with fields set to Subject as 'Subject: Test message' From as'From: support@edwardsvacuum.com' To as 'To: shalu.gupta@edwardsvacuum.com', content as 'Test message. Test message.'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dispatch Manager - Configure Restricted (Equipment and Alerts) Scheduling")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("DispatchManager")]
        public virtual void DispatchManager_ConfigureRestrictedEquipmentAndAlertsScheduling()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dispatch Manager - Configure Restricted (Equipment and Alerts) Scheduling", null, new string[] {
                        "SplitServer",
                        "SingleServer",
                        "DispatchManager"});
#line 133
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 134
testRunner.When("I click Device Explorer link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 135
testRunner.Then("I should navigated to Device Explorer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 136
testRunner.When("I clicked on add folder/system icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 137
testRunner.And("I entered folder name and Clicked on Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 138
testRunner.Then("I should be able to see Folder Added Successfully Message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 139
testRunner.When("I click OK button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 140
testRunner.Then("I should able to see newly added folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 141
testRunner.When("I click Find Equipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 142
testRunner.And("Deleted all equipments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
testRunner.And("Launch Turbo simulator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 144
testRunner.When("Select an equipmentName \'TURBO4002\', equipmentType \'Turbo Pump\' and iPPortNumber\'" +
                    "4002\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 145
testRunner.And("Select an equipmentName \'TURBO4001\', equipmentType \'Turbo Pump\' and iPPortNumber\'" +
                    "4001\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 146
testRunner.When("navigated to SMTP tab under Page Settings tab.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 147
testRunner.And("Clicked SMTP auth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 148
testRunner.And("login user \'administrator\' created new SMTP Auth page From as \'support@edwardsvac" +
                    "uum.com\' destination with SMTP IP of \'160.100.30.222\', port number as \'25\' and T" +
                    "o address as \'shalu.gupta@edwardsvacuum.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
testRunner.When("navigated to Dispatch Manager->Scheduler.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
testRunner.And("Clicked Week days check box, All Day Check box and selected previously created Pa" +
                    "geDestination\'Admin, FabWorks (administrator) (SMTPAuth)\'.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 151
testRunner.And("clicked Apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
testRunner.Then("The Equipment tab should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 153
testRunner.When("Add a singlie piece of Equipment\'TURBO4002\', searching by either Equipment type o" +
                    "r name or both in Find Equipment to add panel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 154
testRunner.Then("The Equipment\'TURBO4002\' discovered and added should be displayed in Restrict Pag" +
                    "es to this Equipment:(NB: If empty then all equipment is allowed) :", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 155
testRunner.When("Created an alert\'18\' from a piece of equipment\'4002\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 156
testRunner.Then("The alert should arrive via the dispatch method selected.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 157
testRunner.When("Cleared alert from \'4002\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 158
testRunner.And("Created an alert \'18\' from a piece of equipment\'4001\'.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
testRunner.Then("The alert should NOT arrive via the dispatch method selected.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 160
testRunner.When("Cleared alert from \'4001\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 161
testRunner.And("Remove the Equipment\'TURBO4002\' restriction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
testRunner.Then("The schedule screen should no longer report a certain number of Equipment\'TURBO40" +
                    "02\' are configured for restriction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 163
testRunner.When("Click on Alert tab in Schedule detail screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 164
testRunner.Then("The Alert tab UI should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 165
testRunner.When("Add a single alert  Value\'112\' for a type of equipment Alert\'Motor Overheat-Motor" +
                    " Temperature\' to restrict to", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 166
testRunner.Then("The Alert\'Motor Overheat-Motor Temperature\' should be displayed in the \'Restrict " +
                    "Pages to these Alerts:(NB: If empty then all Alerts are allowed) list.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 167
testRunner.When("Created an alert \'18\' from a piece of equipment\'4002\'.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 168
testRunner.Then("The alert should arrive via the dispatch method selected.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 169
testRunner.When("Cleared alert from \'4002\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 170
testRunner.And("Created an alert \'19\' from a piece of equipment\'4002\'.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 171
testRunner.Then("The alert should NOT arrive via the dispatch method selected.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 172
testRunner.When("Cleared alert from \'4002\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dispatch Manager - Review General Settings, Destinations and Schedule")]
        [NUnit.Framework.CategoryAttribute("SplitServer")]
        [NUnit.Framework.CategoryAttribute("SingleServer")]
        [NUnit.Framework.CategoryAttribute("DispatchManager")]
        public virtual void DispatchManager_ReviewGeneralSettingsDestinationsAndSchedule()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dispatch Manager - Review General Settings, Destinations and Schedule", null, new string[] {
                        "SplitServer",
                        "SingleServer",
                        "DispatchManager"});
#line 177
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 178
testRunner.When("Click on each mode: [General Settings]; [Page Destinations]; [Scheduler]; [Inhibi" +
                    "t Settings]", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 179
testRunner.Then("The appropriate settings to be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

