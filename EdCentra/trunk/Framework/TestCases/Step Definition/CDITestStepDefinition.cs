using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using FlaUI.UIA3;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class CDITestStepDefinition
    {
        HomePage homePage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        DataExtractionPage dataExtractionPage;
        WindowAppServices winApp = null;
        Simulator simulator = new Simulator();
        private IWebDriver driver;
        string importPdmFilePath = string.Empty;

        public CDITestStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            homePage = new HomePage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            dataExtractionPage = new DataExtractionPage(driver);
        }

        [When(@"We have access to EdCentra new version installation environment")]
        public void WhenWeHaveAccessToEdCentraNewVersionInstallationEnvironment()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkAddFolder);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LnkAddFolder), "Verifying User should be navigated to Device Explorer page");
            Waits.Wait(driver, 1000);
        }

        [Then(@"EdCentra is installed sucessfully, which also contains CDI EXPORT by default\.")]
        public void ThenEdCentraIsInstalledSucessfullyWhichAlsoContainsCDIEXPORTByDefault_()
        {
            if (dataExtractionPage == null)
                dataExtractionPage = new DataExtractionPage(driver);
            dataExtractionPage.FileExist();
            Waits.Wait(driver, 1000);
        }

        [When(@"Run CDI_Win\.exe which is normally located in Local drive")]
        public void WhenRunCDI_Win_ExeWhichIsNormallyLocatedInLocalDrive()
        {
            simulator.LaunchCDI();
            Waits.Wait(driver, 2000);
        }

        [Then(@"CDI config tool \(CDI_Win\) presents a login window requesting login entry\.")]
        public void ThenCDIConfigToolCDI_WinPresentsALoginWindowRequiestingLoginEntry_()
        {
            Assert.IsTrue(simulator.CDILoginWindowsIsExist(), "Verified CDI config tool not Present");
            Waits.Wait(driver, 2000);
        }

        [When(@"valid Password is provided, the user is presented with the main application window\.")]
        public void WhenValidPasswordIsProvidedTheUserIsPresentedWithTheMainApplicationWindow_(Table table)
        {
            simulator.LoginDetails(table.Rows[0]["userName"], table.Rows[0]["password"]);
            Waits.Wait(driver, 2000);
            Assert.IsTrue(simulator.CDILoginWindowsIsExist(), "Verified CDI config tool not Present");
            Waits.Wait(driver, 2000);
        }

        [When(@"I Close the CDI window")]
        public void WhenCloseTheCDIWindow()
        {
            simulator.KillCDIWIndow();
        }

        [Then(@"user attempts three invalid PIN codes, the login process is terminated\.")]
        public void ThenUserAttemptsThreeInvalidPINCodesTheLoginProcessIsTerminated_(Table table)
        { 
            simulator.LaunchCDI();
            Waits.Wait(driver, 2000);
            simulator.LoginDetails(table.Rows[0]["userName"], table.Rows[0]["password1"]);
            Waits.Wait(driver, 2000);
            simulator.ConfirmLoginFailed();
            Waits.Wait(driver, 1000);
            simulator.LoginDetails(table.Rows[0]["userName"], table.Rows[0]["password2"]);
            Waits.Wait(driver, 2000);
            simulator.ConfirmLoginFailed();
            Waits.Wait(driver, 1000);
            simulator.LoginDetails(table.Rows[0]["userName"], table.Rows[0]["password3"]);
            Waits.Wait(driver, 2000);
            simulator.ConfirmLoginFailed();
            Waits.Wait(driver, 4000);
            Assert.IsFalse(simulator.CDILoginWindowsIsExist(), "Verified CDI config tool Present");
           // Waits.Wait(driver, 1000);
        }

        [When(@"I launch SQl Server Managment Studio")]
        public void WhenILaunchSQlServerManagmentStudio()
        {
            winApp = new WindowAppServices();
            winApp.LaunchSSMS();
            Waits.Wait(driver, 50000);
        }

        [When(@"using SQL Management Studio, log on with sa accounts using SQL Server Authentication")]
        public void WhenUsingSQLManagementStudioLogOnWithSaAccountsUsingSQLServerAuthentication()
        {
            
            Waits.Wait(driver, 1000);
            winApp.SQLLogging();
            Waits.Wait(driver, 1000);
        }

        [When(@"I expand '(.*)' in Database")]
        public void WhenIExpandInDatabase(string dbOption)
        {
            Waits.Wait(driver, 3000);
            winApp.ExpandSqlServerTrees(dbOption);
            winApp.ExpandSqlServerTrees("Jobs");
        }

        [Then(@"the Jobs ""(.*)"" and ""(.*)"" should exist under Sql Server Agent")]
        public void ThenTheJobsAndShouldExistUnderSqlServerAgent(string job1, string job2)
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(winApp.ScadaDatabaseVerification(job1));
            Assert.IsTrue(winApp.ScadaDatabaseVerification(job2));
            winApp.CloseSSMS();
        }

        [Then(@"check CDI folder exists under '(.*)'")]
        public void ThenCDIFolderExistsUnder(string path)
        {
            path = path +@"\CDI";
            Assert.IsTrue(winApp.DiretoryExists(path));
        }

        [Then(@"check packages folder exists under '(.*)'")]
        public void ThenPackagesFolderExistUnder(string path)
        {
            path = path +@"\Packages";
            Assert.IsTrue(winApp.DiretoryExists(path));
        }

        [When(@"I click on Daily Equipment Filter")]
        public void WhenIClickOnDailyEquipmentFilter()
        {
            winApp = new WindowAppServices();
            winApp.AttachCDIWindow();
            winApp.ClickDailyEquipmentFilter();
        }

        [When(@"I add the equipments to the Daily Equipment Filter")]
        public void WhenIAddTheEquipmentsToTheDailyEquipmentFilter()
        {
            winApp.ClickAddAllFilterButton();
        }

        [When(@"I add the equipments to the Adhoc Equipment Filter")]
        public void WhenIAddTheEquipmentsToTheAdhocEquipmentFilter()
        {
            winApp.ClickAddAllFilterButton();
        }

        [When(@"I remove all the equipment filters if exist")]
        public void WhenIRemoveAllTheEquipmentFiltersIfExist()
        {
            winApp.ClickRemoveAllFilterButton();
        }

        [When(@"I click on the Adhoc Data Export")]
        public void WhenIClickOnTheAdhocDataExport()
        {
            winApp.ClickAdhocDataExport();
        }

        [When(@"I Click on Adhoc Equipment Filter")]
        public void WhenIClickOnAdhocEquipmentFilter()
        {
            winApp.ClickAdhocEquipmentFilter();
        }

        [When(@"run the Job ""(.*)"" manually")]
        public void WhenRunTheJobManually(string job)
        {
            winApp.RunJobManuallyInDatabase(job);
            winApp.CloseSSMS();
        }

        [Then(@"there should not be any entry in Daily Data Export")]
        public void ThenThereShouldNotBeAnyEntryInDailyDataExport()
        {
            winApp.AttachCDIWindow();
            winApp.ClickDailyDataExport();
            Assert.AreEqual(0, winApp.GetDailyDataExportRowsCount());
            winApp.CloseCDI();
        }

        [Then(@"there should not be any data export folder exist in directory ""(.*)""")]
        public void ThenThereShouldNotBeAnyDataExportFolderExistInDirectory(string path)
        {
            Assert.IsFalse(winApp.DiretoryExists(path));
        }

        [Then(@"open the file ""(.*)"" and check the text ""(.*)"" exists")]
        public void ThenOpenTheFileAndCheckTheTextExists(string filePath, string text)
        {
            Assert.IsTrue(winApp.FileExist(filePath));
            Waits.Wait(driver, 1000);
            string Actualtext = File.ReadAllText(filePath);
            Assert.IsTrue(Actualtext.Contains(text), "Expected text not present");
        }

        [When(@"I select the application Id from the combo box")]
        public void WhenISelectTheApplicationIdFromTheComboBox()
        {
            winApp.SelectApplicationId();
        }

        [When(@"I click on the Create Data Export button")]
        public void WhenIClickOnTheCreateDataExportButton()
        {
            winApp.ClickCreateDataExport();
            Waits.Wait(driver,8000);
        }

        [When(@"run the Job ""(.*)"" manually by right clicking and selecting '(.*)'")]
        public void WhenRunTheJobManuallyByRightClickingAndSelecting(string job, string menuItem)
        {
            winApp.RunJobManuallyInDatabase(job,menuItem);
            Waits.Wait(driver, 10000);
            winApp.CloseSSMS();
            winApp.AttachCDIWindow();  
            
        }

        [Then(@"the zip file exists for Adhoc Data Export in '(.*)'")]
        public void ThenTheZipFileExistsForAdhocDataExportIn(string filePath)
        {
            Waits.Wait(driver, 40000);
            winApp.RefreshDataRowInExport();
            var date1 = DateTime.Now.Date.ToString("yyyyMMdd");
            var date2 = DateTime.Now.AddDays(1).Date.ToString("yyyyMMdd");
            var fileName = $"Edwards_Default_Adhoc_(2)_{date1}_to_{date2}";
            var AdhocFilePath = filePath + @"\" + fileName + ".zip";
            ScenarioContext.Current.Add("AdhocFilePath", AdhocFilePath);
            Assert.IsTrue(winApp.FileExist(AdhocFilePath),"Zip file not created in CDI Data_Export folder");
        }

        [Then(@"the zip file exists for Daily Data Export in '(.*)'")]
        public void ThenTheZipFileExistsForDailyDataExportIn(string filePath)
        {
          //  var date1 = DateTime.Now.Date.ToString("yyyy_MM_dd_000000000");
            var date1 = DateTime.Now.Date.ToString("yyyyMMdd");
            var fileName = $"Edwards_Default_Daily_{date1}_to_{date1}";
            var DailyFilePath = filePath + @"\" + fileName + ".zip";
            ScenarioContext.Current.Add("DailyFilePath", DailyFilePath);
            Assert.IsTrue(winApp.FileExist(DailyFilePath), "Zip file not created in CDI Data_Export folder");
        }

        [When(@"I Unzip the Adhoc Data Export file")]
        public void WhenIUnzipTheAdhocDataExportFile()
        {
            string sourceFileName = (string)ScenarioContext.Current["AdhocFilePath"];
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            if (winApp.DiretoryExists(destinationDirectory))
                Directory.Delete(destinationDirectory,true);
            ZipFile.ExtractToDirectory(sourceFileName, destinationDirectory);
            Assert.IsTrue(winApp.DiretoryExists(destinationDirectory),$"Directory {destinationDirectory} does not exist");
        }

        [Then(@"the no\.of files exported for Adhoc Export from scada production should be (.*)")]
        public void ThenTheNo_OfFilesExportedForAdhocExportFromScadaProductionShouldBe(int expectedFileCount)
        {
            string sourceFileName = (string)ScenarioContext.Current["AdhocFilePath"];
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            int actualCount = Directory.GetFiles(destinationDirectory+@"\scada_Production", "*", SearchOption.TopDirectoryOnly).Length;
            Assert.AreEqual(expectedFileCount, actualCount, "File count does not match with expected in scada_Production");
        }

        [Then(@"the no\.of files exported for Adhoc Export from pdm config should be (.*)")]
        public void ThenTheNo_OfFilesExportedForAdhocExportFromPdmConfigShouldBe(int expectedFileCount)
        {
            string sourceFileName = (string)ScenarioContext.Current["AdhocFilePath"];
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            int actualCount = Directory.GetFiles(destinationDirectory + @"\pdm_config", "*", SearchOption.TopDirectoryOnly).Length;
            Assert.AreEqual(expectedFileCount, actualCount, "File count does not match with expected in pdm_config");
        }

        [Then(@"the no\. of files exported for Adhoc Export from pdm probe should be (.*)")]
        public void ThenTheNo_OfFilesExportedForAdhocExportFromPdmProbeShouldBe(int expectedFileCount)
        {
            string sourceFileName = (string)ScenarioContext.Current["AdhocFilePath"];
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            int actualCount = Directory.GetFiles(destinationDirectory + @"\pdm_probe", "*", SearchOption.TopDirectoryOnly).Length;
            Assert.AreEqual(expectedFileCount, actualCount, "File count does not match with expected in pdm_probe");
        }

        [When(@"I Unzip the Daily Data Export file")]
        public void WhenIUnzipTheDailyDataExportFile()
        {
            string sourceFileName = (string)ScenarioContext.Current["DailyFilePath"];
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            ZipFile.ExtractToDirectory(sourceFileName, destinationDirectory);
            Assert.IsTrue(winApp.DiretoryExists(destinationDirectory), $"Directory {destinationDirectory} does not exist");
        }

        [Then(@"the no\.of files exported for Daily Export from scada production should be (.*)")]
        public void ThenTheNo_OfFilesExportedForDailyExportFromScadaProductionShouldBe(int expectedFileCount)
        {
            string sourceFileName = (string)ScenarioContext.Current["DailyFilePath"];
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            int actualCount = Directory.GetFiles(destinationDirectory + @"\scada_Production", "*", SearchOption.TopDirectoryOnly).Length;
            Assert.AreEqual(expectedFileCount, actualCount, "File count does not match with expected in scada_Production");
        }

        [Then(@"the no\.of files exported for Daily Export from pdm config should be (.*)")]
        public void ThenTheNo_OfFilesExportedForDailyExportFromPdmConfigShouldBe(int expectedFileCount)
        {
            string sourceFileName = (string)ScenarioContext.Current["DailyFilePath"];
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            int actualCount = Directory.GetFiles(destinationDirectory + @"\pdm_config", "*", SearchOption.TopDirectoryOnly).Length;
            Assert.AreEqual(expectedFileCount, actualCount, "File count does not match with expected in pdm_config");
        }

        [Then(@"the no\. of files exported for Daily Export from pdm probe should be (.*)")]
        public void ThenTheNo_OfFilesExportedForDailyExportFromPdmProbeShouldBe(int expectedFileCount)
        {
            string sourceFileName = (string)ScenarioContext.Current["DailyFilePath"];
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            int actualCount = Directory.GetFiles(destinationDirectory + @"\pdm_probe", "*", SearchOption.TopDirectoryOnly).Length;
            Assert.AreEqual(expectedFileCount, actualCount, "File count does not match with expected in pdm_probe");
        }

        [Then(@"the table names in the Adhoc Export files are obfuscated")]
        public void ThenTheTableNamesInTheAdhocExportFilesAreObfuscated()
        {
            string sourceFileName = (string)ScenarioContext.Current["AdhocFilePath"];
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            string fileScadaTable = destinationDirectory+@"\scada_Production\ofst_1.csv";
            string filePdmConfig = destinationDirectory + @"\pdm_config\ofst_31.csv";
            string filePdmProbe = destinationDirectory + @"\pdm_probe\ofst_52.csv";
            Assert.IsTrue(winApp.FileExist(fileScadaTable),$"File {fileScadaTable} does not exist");
            Assert.IsTrue(winApp.FileExist(filePdmConfig), $"File {filePdmConfig} does not exist");
            Assert.IsTrue(winApp.FileExist(filePdmProbe), $"File {filePdmProbe} does not exist");

        }

        [Then(@"the column names in the Adhoc Export file are obfuscated")]
        public void ThenTheColumnNamesInTheAdhocExportFileAreObfuscated()
        {
            bool flag;
            string sourceFileName = (string)ScenarioContext.Current["AdhocFilePath"];
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            string fileScadaTable = destinationDirectory + @"\scada_Production\ofst_1.csv";
            if(winApp.FileExist(fileScadaTable))
            {
                var firstLine = File.ReadLines(fileScadaTable).First();
                flag = firstLine.Contains(",");
                Assert.IsFalse(flag, "Column name are not obfuscated in Adhoc Export file");
            }
            else
            {
                Assert.Fail($"File {fileScadaTable} does not exist");
            }
            
        }

        [Then(@"the table names in the Daily Export files are obfuscated")]
        public void ThenTheTableNamesInTheDailyExportFilesAreObfuscated()
        {
            string sourceFileName = (string)ScenarioContext.Current["DailyFilePath"];
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            string fileScadaTable = destinationDirectory + @"\scada_Production\ofst_1.csv";
            string filePdmConfig = destinationDirectory + @"\pdm_config\ofst_31.csv";
            string filePdmProbe = destinationDirectory + @"\pdm_probe\ofst_52.csv";
            Assert.IsTrue(winApp.FileExist(fileScadaTable), $"File {fileScadaTable} does not exist");
            Assert.IsTrue(winApp.FileExist(filePdmConfig), $"File {filePdmConfig} does not exist");
            Assert.IsTrue(winApp.FileExist(filePdmProbe), $"File {filePdmProbe} does not exist");

        }

        [Then(@"the column names in the Daily Export files are obfuscated")]
        public void ThenTheColumnNamesInTheDailyExportFilesAreObfuscated()
        {
            bool flag;
            string sourceFileName = (string)ScenarioContext.Current["DailyFilePath"];
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            string fileScadaTable = destinationDirectory + @"\scada_Production\ofst_1.csv";
            if (winApp.FileExist(fileScadaTable))
            {
                var firstLine = File.ReadLines(fileScadaTable).First();
                flag = firstLine.Contains(",");
                Assert.IsFalse(flag, "Column name are not obfuscated in Adhoc Export file");
            }
            else
            {
                Assert.Fail($"File {fileScadaTable} does not exist");
            }
        }


        [When(@"Create a CDI Import folder")]
        public void WhenCreateACDIImportFolder()
        {
            winApp = new WindowAppServices();
            winApp.DeleteFolderExists();
            Waits.Wait(driver, 2000);
            winApp.CreateCDIIMportFolder();
            Waits.Wait(driver, 2000);
        }

        [When(@"I Copy CDI Exported files to CDI Import folder")]
        public void WhenICopyCDIExportedFilesToCDIImportFolder()
        {
           // winApp.MoveFiles();
            Waits.Wait(driver, 2000);
        }

        [When(@"I Copy Adhoc Exported file to CDI Import folder")]
        public void WhenICopyAdhocExportedFileToCDIImportFolder()
        {
            string sourceFileName = (string)ScenarioContext.Current["AdhocFilePath"];
            winApp.MoveSingleFile(sourceFileName);
            Waits.Wait(driver, 2000);
        }

       
        [When(@"I extract file in CDI Import folder using command")]
        public void WhenIExtractFileInCDIImportFolderUsingCommand()
        {
            winApp = new WindowAppServices();
            winApp.LaunchCmdPrmbt();
            Waits.Wait(driver, 2000);
        }

        [Then(@"the file ""(.*)"" should exist in CDI Adhoc import files")]
        public void ThenTheFileShouldExistInCDIAdhocImportFiles(string fileName)
        {
            Waits.Wait(driver, 10000);
            string sourceFileName = (string)ScenarioContext.Current["AdhocFilePath"];
            sourceFileName = sourceFileName.Replace("CDI_Export", "CDI_Import");
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            string fileScadaTable = @"G:\fs_maintenance\CDI\CDI_Import\" +destinationDirectory + @"\scada_Production\"+ fileName;
            Assert.IsTrue(winApp.FileExist(fileScadaTable));
            simulator.KillCDIWIndow();
            simulator.KillCommandPromptWIndow();
        }

        [When(@"run the Job ""(.*)"" manually by right click and selecting '(.*)'")]
        public void WhenRunTheJobManuallyByRightClickAndSelecting(string job, string menuItem)
        {
            winApp.RunJobManuallyInDatabase(job, menuItem);
            Waits.Wait(driver, 10000);
            winApp.CloseSSMS();
            winApp.AttachCDIWindow();
        }

        [When(@"Select Job Schedule from the config menu\.")]
        public void WhenSelectJobScheduleFromTheConfigMenu_()
        {
            winApp = new WindowAppServices();
            winApp.AttachCDIWindow();
            Waits.Wait(driver, 2000);
            winApp.GetJobSchedule();
            Waits.Wait(driver, 2000);
        }

        [Then(@"SQL job Scheduler GUI dialog is opened\.")]
        public void ThenSQLJobSchedulerGUIDialogIsOpened_()
        {
            Assert.IsTrue(winApp.SqlJobWindowIsExist(), "SQL Job Scheduler GUI dialog is not opened");
            Waits.Wait(driver, 2000);
        }

        [When(@"Select Job '(.*)' then Schedules '(.*)' and Click Edit button\.")]
        public void WhenSelectJobThenSchedulesAndClickEditButton_(string job, string schedule)
        {
            winApp.JobSchedulerText(job, schedule);
            Waits.Wait(driver, 2000);
        }

        [Then(@"The Edit Schedule '(.*)' dialog box is opened for the selected schedule\.")]
        public void ThenTheEditScheduleDialogBoxIsOpenedForTheSelectedSchedule_(string windowName)
        {
            Assert.IsTrue(winApp.SqlJobEditWindowIsExist(), "The Edit Schedule dialog box is not opened");
            Waits.Wait(driver, 2000);
        }

        [When(@"configure the schedule '(.*)'")]
        public void WhenConfigureTheSchedule(string schedule)
        {
            winApp.EditSchedule(schedule);
            Waits.Wait(driver, 2000);
        }

        [When(@"The folder '(.*)' have file '(.*)' should exist in CDI Adhoc import files")]
        public void WhenTheFolderHaveFileShouldExistInCDIAdhocImportFiles(string folderName, string fileName)
        {
            Waits.Wait(driver, 10000);
            string sourceFileName = (string)ScenarioContext.Current["AdhocFilePath"];
            sourceFileName = sourceFileName.Replace("CDI_Export", "CDI_Import");
            string destinationDirectory = Path.GetFileNameWithoutExtension(sourceFileName);
            importPdmFilePath = @"G:\fs_maintenance\CDI\CDI_Import\" + destinationDirectory + @"\" + folderName + @"\" + fileName;
            Assert.IsTrue(winApp.FileExist(importPdmFilePath));
            simulator.KillCDIWIndow();
        }

        [Then(@"Column Encrypted_XML in tbl_Model_Configuration\.csv is '(.*)'")]
        public void ThenColumnEncrypted_XMLInTbl_Model_Configuration_CsvIs(string text)
        {
            string Actualtext = File.ReadAllText(importPdmFilePath);
            Assert.IsTrue(Actualtext.Contains(text), "Expected text not present");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Column model_xm in model_xml\.csv is '(.*)'")]
        public void ThenColumnModel_XmInModel_Xml_CsvIs(string text)
        {
            string Actualtext = File.ReadAllText(importPdmFilePath);
            Assert.IsTrue(Actualtext.Contains(text), "Expected text not present");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Column eads_activity_response in eads_activity_response\.csv is '(.*)'")]
        public void ThenColumnEads_Activity_ResponseInEads_Activity_Response_CsvIs(string text)
        {
            string Actualtext = File.ReadAllText(importPdmFilePath);
            Assert.IsTrue(Actualtext.Contains(text), "Expected text not present");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Each day's extraction contains data for that day for values, statuses, alerts for scada_Production export")]
        public void ThenEachDaySExtractionContainsDataForThatDayForValuesStatusesAlertsForScada_ProductionExport()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string Actualtext = File.ReadAllText(importPdmFilePath);
            Assert.IsTrue(Actualtext.Contains(date), "Expected text not present");
            Waits.Wait(driver, 1000);
        }




    }
}
