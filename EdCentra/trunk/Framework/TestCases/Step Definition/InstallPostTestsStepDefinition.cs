using Edwards.Scada.Test.Framework.GlobalHelper;
using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using System.ServiceProcess;
using System.Collections.Generic;
using OpenQA.Selenium;
using Edwards.Scada.Test.Framework.Pages;
using System.Threading;
using System.IO;
using Edwards.Scada.Test.Framework.Contract;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public class InstallPostTestsSteps
    {
        #region fields
        bool status = false;
        WindowAppServices winApp = null;
        List<string> lstFirewallActual = new List<string>();
        bool fireStatus = false;      
        private IWebDriver driver;   
        LoginPage loginPage;
        Simulator simulator = new Simulator();
        string serverText = string.Empty;
        string dBText = string.Empty;
        #endregion

        public InstallPostTestsSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }


        [When(@"I open the Programs and Features in the Control Panel")]
        public void WhenIOpenTheProgramsAndFeaturesInTheControlPanel()
        {
            //Create 
            winApp = new WindowAppServices();
         
            winApp.OpenControlPanelPF();
           
        }
        
        [Then(@"I see the components '(.*)' installed in the system")]
        public void ThenISeeTheComponentsInstalledInTheSystem(string components, Table table)
        {
            //Check for the components        
            var expectedComponents = table.Rows.Select(x => x["Components"]).ToList();
            var actualColumnHeaders = winApp.InstalledComponents(expectedComponents);

            Thread.Sleep(1000);

            winApp.KillControlPanel();

            //Assert
            CollectionAssert.AreEqual(expectedComponents, actualColumnHeaders);

        }

        //Services
        [Then(@"I see the following services installed in the system")]
        public void ThenISeeTheFollowingServicesInstalledInTheSystem(Table table)
        {
            var lstServices = table.Rows.Select(x => x["ServiceName"]).ToList();
          
            foreach(var service in lstServices)
            {
               Assert.IsTrue(serviceExists(service),$"Service {service} not installed in system");
               Assert.IsTrue(IsServiceRunning(service), $"Service {service} exists in system but not in running mode");
            }

        }

        public bool serviceExists(string ServiceName)
        {
            return ServiceController.GetServices().Any(serviceController => serviceController.ServiceName.Equals(ServiceName));
        }

        public bool IsServiceRunning(string ServiceName)
        {
            bool flag = false;
            ServiceController sc = new ServiceController();
            sc.ServiceName = ServiceName;
            if (sc.Status == ServiceControllerStatus.Running)
            {
                flag = true;
            }
            return flag;
        }

        //Firewall
        [Then(@"I check whether Symantec is installed in the system")]
        public void ThenICheckWhetherSymantecIsInstalledInTheSystem()
        {
            //Create 
            winApp = new WindowAppServices();
            
            //check symantec
            bool status = winApp.IsProcessRunning("ccSvcHst");

            //Assert
            Assert.IsTrue(status, "Symantec is NOT running in the system!");

        }

        [When(@"I open Windows Firewall Advnace Settings and click on the Inbound Rules tree node")]
        public void WhenIOpenWindowsFirewallAdvnaceSettingsAndClickOnTheInboundRulesTreeNode()
        {
            //Inbound rules in firewall
            lstFirewallActual = winApp.OpenWindowsFireWallAdvSettingsInbound();

            //kill
            winApp.KillControlPanel();
        }

        [Then(@"I see exceptions starting with Edwards")]
        public void ThenISeeExceptionsStartingWithEdwards(Table tab)
        {
            List<string> lstFirewallExpected = tab.Rows.Select(x => x["InboundRuleExceptions"]).ToList();
            
            //Compare

            var expectedNotInActual = lstFirewallExpected.Except(lstFirewallActual).ToList();

            if (expectedNotInActual.Count == 0)
            {
                fireStatus = true;
            }
            else
            {
                foreach (var name in expectedNotInActual)
                {
                    Assert.IsTrue(fireStatus, $"Expected Edwards Name {name} is not seen in Firewall InboundRules");
                }
            }            

        }

        //Check IIS
        [Given(@"I launch the Server Manager app")]
        public void GivenILaunchTheServerManagerApp()
        {
            winApp = new WindowAppServices();

            winApp.LaunchServerManager();
        }

        [When(@"I click on Add roles and Features and click on next until get to Server Roles")]
        public void WhenIClickOnAddRolesAndFeaturesAndClickOnNextUntilGetToServerRoles()
        {
            winApp.ClickAddRolesAndFeatures();
        }

        [When(@"I expand Web Server \(IIS\) -> Web Server -> Application Development")]
        public void WhenIExpandWebServerIIS_WebServer_ApplicationDevelopment()
        {
            winApp.ExpandTillApplicationDevelopment();
        }

        [Then(@"'(.*)' and '(.*)' should be installed")]
        public void ThenAndShouldBeInstalled(string comp1, string comp2)
        {
            Assert.IsTrue(winApp.CheckComponentsInstalled(comp1), $"{comp1} not installed");
            Assert.IsTrue(winApp.CheckComponentsInstalled(comp2), $"{comp2} not installed");
        }

        [When(@"I click on cancel button on the wizard")]
        public void WhenIClickOnCancelButtonOnTheWizard()
        {
            winApp.ClickCancelButtonInTheWizard();
        }

        [When(@"I click on Tools menu and open '(.*)'")]
        public void WhenIClickOnToolsMenuAndOpen(string option)
        {
            winApp.CheckToolsMenu(option);
            winApp.CloseServerManager();
        }

        [When(@"I expand Default Sites")]
        public void WhenIExpandDefaultSites()
        {
            winApp.ExpandDefaultWebSite();
        }

        [Then(@"I should see the following two virtual directories")]
        public void ThenIShouldSeeTheFollowingTwoVirtualDirectories(Table table)
        {
            var expectedDirectories = table.Rows.Select(r => r["Directories"]).ToList();

            foreach (var directory in expectedDirectories)
            {
                Assert.IsTrue(winApp.IsVirtualDirectoryExistsInIIS(directory));
            }

            winApp.CloseIIS();
        }

        [When(@"I navigate to '(.*)' in the browser")]
        public void WhenINavigateToInTheBrowser(string url)
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(3000);
        }

        [Then(@"Edcentra login screen should appear")]
        public void ThenEdcentraLoginScreenShouldAppear()
        {
            if (loginPage == null)
                loginPage = new LoginPage(driver);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, loginPage.TxtLoginUserName), "Login page has not opened after accepting license");
        }

        //Event Viewer
        [When(@"On the agent PC, open eventvwr\.msc")]
        public void WhenOnTheAgentPCOpenEventvwr_Msc()
        {
            winApp = new WindowAppServices();
            winApp.LaunchEventViewer();
        }

        //Firewall allow apps/feature
        [When(@"I open Allow an app or feature through Windows Firewall")]
        public void WhenIOpenAllowAnAppOrFeatureThroughWindowsFirewall()
        {
            winApp = new WindowAppServices();            
        }

        [Then(@"I should see list of Edwards labelled rules with Public and Private checked")]
        public void ThenIShouldSeeListOfEdwardsLabelledRulesWithPublicAndPrivateChecked(Table table)
        {
            List<string> lstFirewallExpected = table.Rows.Select(x => x["AllowedAps"]).ToList();

            //Get the list from control panel
            Dictionary<string, bool> actualFirewallApps = new Dictionary<string, bool>();

            actualFirewallApps = winApp.GetEdwardsAllowedAppsList();

            //Compare

            var expectedNotInActual = lstFirewallExpected.Except(actualFirewallApps.Keys).ToList();
            string lstNotInActual = string.Empty;
            string lstNotChecked = string.Empty;
            List<string> notEnabledList = new List<string>();

            if (expectedNotInActual.Count != 0)
            {
                List<string> notinActual = new List<string>();
                foreach (var name in expectedNotInActual)
                {
                    notinActual.Add(name);
                    //Assert.IsTrue(fireStatus, $"Expected Edwards Name {name} is not seen in Firewall Allowed Apps");
                }
                lstNotInActual = string.Join(", ", notinActual);
                Assert.IsTrue(fireStatus, $"Expected Edwards Name {lstNotInActual} is not seen in Firewall Allowed Apps");
            }

            
            //Edwards not checked in firewall allowed apps
            foreach (KeyValuePair<string, bool> entry in actualFirewallApps)
            {
                if(!entry.Value)
                {
                    notEnabledList.Add(entry.Key);
                    //Assert.IsTrue(fireStatus, $"Expected Edwards Name {entry.Key} is NOT CHECKED in Firewall Allowed Apps");
                }
            }
            if (notEnabledList.Count != 0)
            {
                string str = string.Join(", ", notEnabledList);
                Assert.IsTrue(fireStatus, $"Expected Edwards Name {str} is NOT CHECKED in Firewall Allowed Apps");
            }
        }

        [Then(@"Event Viewer opens")]
        public void ThenEventViewerOpens()
        {
            Assert.IsTrue(winApp.ScadaEventLogWindowIsExist(), "Verified Event Viewer not Open");
            Waits.Wait(driver, 3000);
        }       

        [When(@"Go to the Scada event log, and check for the entries labled Agent Framework")]
        public void WhenGoToTheScadaEventLogAndCheckForTheEntriesLabledAgentFramework()
        {
            winApp.GetEventLog();
            Waits.Wait(driver, 3000);
        }

        [Then(@"Agent Framework event log should state ""(.*)""")]
        public void ThenAgentFrameworkEventLogShouldState(string text)
        {
            Thread.Sleep(5000);
            Assert.IsTrue(winApp.DeferredTextExists(text),"Agent framework deferred text does not exist");
        }

        [When(@"Copy ScanAssemblyBuildType\.exe to D drive\.")]
        public void WhenCopyScanAssemblyBuildType_ExeToDDrive_()
        {
            //Create 
            winApp = new WindowAppServices();
          //  winApp.DeleteFileExist();
            //Waits.Wait(driver, 1000);
            //winApp.CopyFile();
        }

        [Then(@"pen a command window and ensure that the present working directory is D")]
        public void ThenPenACommandWindowAndEnsureThatThePresentWorkingDirectoryIsD()
        {
            //if (File.Exists(@"G:\Expected.txt"))
            //{
            //    File.Delete(@"G:\Expected.txt");
            //}
            winApp.LaunchCmdPrompt();
            Waits.Wait(driver, 1000);
        }

        [When(@"Run ScanAssemblyBuildType\.exe and await the results\.")]
        public void WhenRunScanAssemblyBuildType_ExeAndAwaitTheResults_()
        {
            winApp.RunExe();
            Waits.Wait(driver, 1000);
        }

        [Then(@"There to be '(.*)' matches, once those marked as exceptions have been accounted for\.")]
        public void ThenThereToBeMatchesOnceThoseMarkedAsExceptionsHaveBeenAccountedFor_(string value)
        {
            winApp.getexpectedText();
            string Actualtext = File.ReadAllText(GlobalConstants.AssemblyExpectedtxtPath);
            Assert.IsTrue(Actualtext.Contains(value), "Verified there to be non zero matches");
        }

        [When(@"Check D:\\Edwards\\Scada\\Database - \{ Installation \| Upgrade }x\.y\\schema\.manifest\.log for errors\.")]
        public void WhenCheckDEdwardsScadaDatabase_InstallationUpgradeX_YSchema_Manifest_LogForErrors_()
        {
            winApp = new WindowAppServices();
            Assert.IsTrue(winApp.FileExist(GlobalConstants.installationLogPath), "Verified there to be database error log not available");
            Waits.Wait(driver, 1000);
        }

        [Then(@"There should be no substantive errors\.")]
        public void ThenThereShouldBeNoSubstantiveErrors_()
        {
            string Actualtext = File.ReadAllText(GlobalConstants.installationLogPath);
            Assert.IsTrue(Actualtext.Contains(GlobalConstants.DataDifferenceErrorText), "Verified there to be non zero matches");
        }

        [When(@"Run SQL Management Studio and try to access the scada_Production database using Windows Authentication")]
        public void WhenRunSQLManagementStudioAndTryToAccessTheScada_ProductionDatabaseUsingWindowsAuthentication()
        {
            winApp.LaunchSSMS();
            Waits.Wait(driver, 2000);
            winApp.SelectAuthenticationWindowsLogin();
            Waits.Wait(driver, 2000);
        }

        [Then(@"This should fail\.")]
        public void ThenThisShouldFail_()
        {
            Assert.IsTrue(winApp.ErrorMessageVerification(GlobalConstants.ConnectionErrMsg), "Verified loging happened");
            Waits.Wait(driver, 2000);
            winApp.SelectConfirmOkError();
            Waits.Wait(driver, 2000);
        }

        [When(@"Still using SQL Management Studio, log on using SQL Authentication and the fsu_user and sa accounts\.")]
        public void WhenStillUsingSQLManagementStudioLogOnUsingSQLAuthenticationAndTheFsu_UserAndSaAccounts_()
        {
            winApp.SelectAuthenticationSQLLogin();
            Waits.Wait(driver, 1000);
            winApp.SQLLogging();
            Waits.Wait(driver, 1000);
        }

        [When(@"Ensure that '(.*)' have '(.*)' under the list")]
        public void WhenEnsureThatHaveUnderTheList(string mainTree, string databaseTreeItem1)
        {
            Waits.Wait(driver, 2000);
            winApp.ExpandSqlServerTrees(mainTree);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(winApp.ScadaDatabaseVerification(databaseTreeItem1), "Verified scada_Production is not shown under Databases");
            Waits.Wait(driver, 1000);

        }

        [When(@"Ensure that '(.*)' and '(.*)' also exist\.")]
        public void WhenEnsureThatAndAlsoExist_(string databaseTreeItem1, string databaseTreeItem2)
        {
            Assert.IsTrue(winApp.ScadaDatabaseVerification(databaseTreeItem1), "Verified Expected Tree sub items is not shown under Databases");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(winApp.ScadaDatabaseVerification(databaseTreeItem1), "Verified Expected Tree sub items is not shown under Databases");
            Waits.Wait(driver, 1000);
        }

        [When(@"Ensure that table '(.*)' exists in the master database\.")]
        public void WhenEnsureThatTableExistsInTheMasterDatabase_(string databaseTreeItem1)
        {
            winApp.ExpandSqlServerTrees("System Databases");
            Waits.Wait(driver, 1000);
            winApp.ExpandSqlServerTrees("master");
            Waits.Wait(driver, 1000);
            winApp.ExpandSqlServerTrees("Tables");
            Waits.Wait(driver, 3000);
            Assert.IsTrue(winApp.ScadaDatabaseVerification(databaseTreeItem1), "Verified Expected Tree sub items is not shown under Databases");
            Waits.Wait(driver, 1000);
        }

        [When(@"Check that with names like ‘fsj_’ exist under SQL Server Agent\\Jobs\.")]
        public void WhenCheckThatWithNamesLikeFsj_ExistUnderSQLServerAgentJobs_(Table table)
        {
            winApp.ExpandServerAgentTable();
            Waits.Wait(driver, 1000);
            winApp.ExpandSqlServerTrees("Jobs");
            winApp.ExpandSqlServerTrees("Jobs");
            Waits.Wait(driver, 1000);
            var expectedJobs = table.Rows.Select(x => x["AgentJobs"]).ToList();
            for (int i = 0; i < expectedJobs.Count; i++)
            {
                Assert.IsTrue(winApp.ScadaDatabaseVerification(expectedJobs[i]));
                Waits.Wait(driver, 1000);
            }
        }

        [When(@"Check server by right-clicking the server name and select Properties")]
        public void WhenCheckServerByRight_ClickingTheServerNameAndSelectProperties()
        {
            string hostName = SpecflowHooks.HostName();
            winApp.OpenServerProperty(hostName);
            Waits.Wait(driver, 1000);
            serverText = winApp.GetServerPropertyText();
            Waits.Wait(driver, 1000);
        }

        [When(@"Check database by right-clicking scada_Production and select Properties")]
        public void WhenCheckDatabaseByRight_ClickingScada_ProductionAndSelectProperties()
        {
            dBText = winApp.GetDatabasePropertyText();
            Waits.Wait(driver, 1000);
        }

        [Then(@"The collations should match\.")]
        public void ThenTheCollationsShouldMatch_()
        {
            Assert.AreEqual(serverText, dBText, "Verified The collations should not match");
            Waits.Wait(driver, 1000);
        }

        [When(@"Check file system security permissions")]
        public void WhenCheckFileSystemSecurityPermissions()
        {
            winApp = new WindowAppServices();
            bool result = winApp.VerifyFilePropertiesAccess(GlobalConstants.ScadaProductionFilePath1, GlobalConstants.ScadaProductionFile1);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(result, "Check file system security permissions is not matches");
            Waits.Wait(driver, 1000);
        }
        [Then(@"MSSQL\$FABWORKS has full access to the files")]
        public void ThenMSSQLFABWORKSHasFullAccessToTheFiles()
        {
            var result = winApp.VerifyFilePropertiesAccess(GlobalConstants.ScadaProductionFilePath2, GlobalConstants.ScadaProductionFile2);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(result, "Check file system security permissions is not matches");
        }

        [When(@"check file If they exists")]
        public void WhenCheckFileIfTheyExists()
        {
            Assert.IsTrue(winApp.FileExist(GlobalConstants.BackupFilePath1), "Verified there to be backup database log not available");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(winApp.FileExist(GlobalConstants.BackupFilePath2), "Verified there to be backup databaslog not available");
            Waits.Wait(driver, 1000);
        }

        [Then(@"check file system security permissions")]
        public void ThenCheckFileSystemSecurityPermissions()
        {
            var result = winApp.VerifyFilePropertiesAccess(GlobalConstants.BackupScadaProductionFilePath1, GlobalConstants.BackupScadaProductionFile1);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(result, "Check file system security permissions is not matches");
            Waits.Wait(driver, 1000);
            var result1 = winApp.VerifyFilePropertiesAccess(GlobalConstants.BackupScadaProductionFilePath2, GlobalConstants.BackupScadaProductionFile2);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(result1, "Check file system security permissions is not matches");
            Waits.Wait(driver, 1000);
            winApp.CloseSSMS();
            Waits.Wait(driver, 1000);
        }

    }
}
