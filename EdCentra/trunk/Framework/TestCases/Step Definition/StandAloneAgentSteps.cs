using System;
using TechTalk.SpecFlow;
using Edwards.Scada.Test.Framework.Pages;
using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using Edwards.Scada.Test.Framework.Contract;
using NUnit.Framework;
using System.IO;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class StandAloneAgentSteps
    {
        Simulator simulator = new Simulator();
        private IWebDriver driver;
        WindowAppServices winApp = null;
        public StandAloneAgentSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        [Given(@"Go to Installer folder and Launch Standalone Agent Setup\.exe file")]
        public void GivenGoToInstallerFolderAndLaunchStandaloneAgentSetup_ExeFile()
        {
            driver.Close();
            simulator.LaunchStandAloneAgentInstaller();
        }


        [Then(@"user finds the Run Agent Configuration \(shortcut on desktop\)")]
        public void ThenUserFindsTheRunAgentConfigurationShortcutOnDesktop()
        {
            Waits.Wait(driver, 5000);
            simulator.LaunchStandaloneAgent();
            Waits.Wait(driver, 1000);

        }
        [When(@"Check C:\\Program Files \(x(.*)\)\\Edwards\\DataLogger\\TsStorePlugins\\Edwards\.TsStore\.Plugin\.Cumulocity\.dll")]
        public void WhenCheckCProgramFilesXEdwardsDataLoggerTsStorePluginsEdwards_TsStore_Plugin_Cumulocity_Dll(int p0)
        {
            winApp = new WindowAppServices();
            Assert.IsTrue(winApp.FileExist(GlobalConstants.dllFilePath), "The dll file exists");
            Waits.Wait(driver, 1000);
        }
        [Then(@"rename the plugin to Edwards\.TsStore\.Plugin\.Cumulocity")]
        public void ThenRenameThePluginToEdwards_TsStore_Plugin_Cumulocity()
        {
            winApp = new WindowAppServices();
            Waits.Wait(driver, 3000);
            winApp.CopyDLLFile();
            Waits.Wait(driver, 1000);
            Assert.IsTrue(winApp.FileExist(GlobalConstants.targetDLL), "The disabled file exists");
            Waits.Wait(driver, 1000);
         // winApp.DeleteExistingDLL();

        }
        [When(@"Check C:\\Program Files \(x(.*)\)\\Edwards\\DataLogger\\TsStorePlugins\\TsStorePluginTemplate\.dll\.DISABLED")]
        public void WhenCheckCProgramFilesXEdwardsDataLoggerTsStorePluginsTsStorePluginTemplate_Dll_DISABLED(int p0)
        {
            winApp = new WindowAppServices();
            Assert.IsTrue(winApp.FileExist(GlobalConstants.TemplateDllFilePath), "The dll file exists");
            Waits.Wait(driver, 1000);
        }

        [Then(@"rename the plugin to TsStorePluginTemplate\.dll")]
        public void ThenRenameThePluginToTsStorePluginTemplate_Dll()
        {
            winApp = new WindowAppServices();
            Waits.Wait(driver, 3000);
            winApp.CopyTemplateDLLFile();
            Waits.Wait(driver, 1000);
            Assert.IsTrue(winApp.FileExist(GlobalConstants.targetTemplateDll), "The disabled file exists");
            Waits.Wait(driver, 1000);
        }


        [When(@"I open the services in the system")]
        public void WhenIOpenTheServicesInTheSystem()
        {
            winApp = new WindowAppServices();
            Waits.Wait(driver, 3000);
            winApp.OpenServices();
        }
        [When(@"I check whether localstorageEquipment\.config file exists")]
        public void WhenICheckWhetherLocalstorageEquipment_ConfigFileExists()
        {
            winApp = new WindowAppServices();
            Assert.IsTrue(winApp.FileExist(GlobalConstants.ConfigFilePath), "The dll file exists");
            Waits.Wait(driver, 1000);
        }

        [Then(@"there should be '(.*)' value needs to be displayed in config file")]
        public void ThenThereShouldBeValueNeedsToBeDisplayedInConfigFile(string value)
        {
            winApp.getexpectedText();
            string Actualtext = File.ReadAllText(GlobalConstants.ConfigFilePath);
            Assert.IsTrue(Actualtext.Contains(value), "Verified there is no specified IP");
        }
        [When(@"added '(.*)' agents")]
        public void WhenAddedAgents(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Check the specified log file is displayed under the path C:\\TS_STORE_TEMPLATE\.log")]
        public void WhenCheckTheSpecifiedLogFileIsDisplayedUnderThePathCTS_STORE_TEMPLATE_Log()
        {
            winApp = new WindowAppServices();
            Assert.IsTrue(winApp.FileExist(GlobalConstants.TSStoreTempLogFilePath), "The log file exists");
            Waits.Wait(driver, 1000);
        }

        [When(@"Reopening the log file check whether'(.*)' is displayed")]
        public void WhenReopeningTheLogFileCheckWhetherIsDisplayed(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"wait and check for the '(.*)' status")]
        public void WhenWaitAndCheckForTheStatus(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        

        [Then(@"replace the IP with the current System IP")]
        public void ThenReplaceTheIPWithTheCurrentSystemIP()
        {

            String strFile = File.ReadAllText("C:\\Temp\\localstorage_equipment.config");

            strFile = strFile.Replace("1.1.1.1", "20.0.0.133");

            File.WriteAllText("C:\\Temp\\localstorage_equipment.config", strFile);
        }

        [Then(@"there should be '(.*)' keywords in the log")]
        public void ThenThereShouldBeKeywordsInTheLog(string value)
        {
            winApp.getexpectedText();
            string Actualtext = File.ReadAllText(GlobalConstants.TSStoreTempLogFilePath);
            Assert.IsTrue(Actualtext.Contains(value), "Verified there is no Keyword");

        }

        [Then(@"Check for the raised alert in log file")]
        public void ThenCheckForTheRaisedAlertInLogFile()
        {
            ScenarioContext.Current.Pending();
        }
    }
}