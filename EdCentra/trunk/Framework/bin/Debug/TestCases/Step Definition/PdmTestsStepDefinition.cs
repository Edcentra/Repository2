using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class PdmTestsStepDefinition
    {
        string testFolderName = ElementExtensions.GetRandomString(4);
        private IWebDriver driver;
        HomePage homePage;
        LoginPage loginPage;
        PdMPage pdMPage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        PDMLicenseGenerator pdmLicenseGenerator = new PDMLicenseGenerator();
        Simulator simulator = new Simulator();
        string activationCode = string.Empty;
        string uniqueID = string.Empty;
        string expirydate = string.Empty;
        string Updateexpiry = string.Empty;

        public PdmTestsStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        /// <summary>
        /// Get Assembly directory path
        /// </summary>
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public void PageInitialization()
        {
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            pdMPage = new PdMPage(driver);
        }

        [Given(@"Opened the EDCENTRA application url in browser")]
        public void GivenOpenedTheEDCENTRAApplicationUrlInBrowser()
        {
            PageInitialization();
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);
        }

        [When(@"I Enter the username as '(.*)' and password as '(.*)' and Clicked login button")]
        public void WhenIEnterTheUsernameAsAndPasswordAsAndClickedLoginButton(string username, string password)
        {
            loginPage.SignIn(username, password);
        }

        [Then(@"I Should be Navigated to the home page")]
        public void ThenIShouldBeNavigatedToTheHomePage()
        {
            Waits.WaitForElementVisible(driver, homePage.LnkDeviceManager);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, homePage.LnkDeviceManager), "Verifying User should be navigated to Home page");
        }

        [When(@"Clicked on PDM link")]
        public void WhenClickedOnPDMLink()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            deviceExplorerNavigationPage.NavigateToHomePage();
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkPdM);
        }

        [Then(@"I should be navigated to PDM page")]
        public void ThenIShouldBeNavigatedToPDMPage()
        {
            if (pdMPage == null)
                pdMPage = new PdMPage(driver);
            bool isDisplayed = Waits.WaitForElementVisible(driver, pdMPage.PDMMenuImage);
            Assert.IsTrue(isDisplayed, "Verified user is not navigaed to PDM page on clicking PDM link");
        }

        [Then(@"copied site activation key available in the clipboard")]
        public void ThenCopiedSiteActivationKeyAvailableInTheClipboard()
        {
            Waits.Wait(driver, 5000);
            activationCode = pdMPage.ActivationCode();
        }

        [Given(@"Launched License Genrator")]
        public void GivenLaunchedLicenseGenrator()
        {
            PDMLicenseGenerator pdmLicenseGenerator = new PDMLicenseGenerator();
            pdmLicenseGenerator.LaunchPdMLicenseGeneratorApp();
        }

        [Given(@"Selected latest database")]
        public void GivenSelectedLatestDatabase()
        {
            Waits.Wait(driver, 2000);
            pdmLicenseGenerator.SetDatabase();
        }

        [When(@"entered general settings fields i\.e\. Max Assignment Count '(.*)',Equipment Type '(.*)' & Author Name '(.*)'")]
        public void WhenEnteredGeneralSettingsFieldsI_E_MaxAssignmentCountEquipmentTypeAuthorName(int maxAssignmentCount, string equipmentName, string authorName)
        {
            pdmLicenseGenerator.EnterGeneralSettingsDataInLicenseGenerator(activationCode, maxAssignmentCount, equipmentName, authorName);
        }

        [When(@"filled algorithmName '(.*)', algTypeCode '(.*)', Max Assignment Count '(.*)', algorithm File '(.*)' & visualization File '(.*)'")]
        public void WhenFilledAlgorithmNameAlgTypeCodeMaxAssignmentCountAlgorithmFileVisualizationFile(string algorithmName, string algTypeCode, int count, string algorithmFile, string visualizationFile)
        {
            pdmLicenseGenerator.UploadAlgorithmDetails(algorithmName, algTypeCode, count, algorithmFile, visualizationFile);
        }

        [When(@"filled algorithmName MultiAlgo(.*), algorithmTypeCode Noz(.*), Max Assignment Count (.*), Algorithm File MdxN(.*)Compressed_VG(.*)_Alarm\.xml and Visualization File VisualisationXML_Algorithm\.txt")]
        public void WhenFilledAlgorithmNameMultiAlgoAlgorithmTypeCodeNozMaxAssignmentCountAlgorithmFileMdxNCompressed_VG_Alarm_XmlAndVisualizationFileVisualisationXML_Algorithm_Txt(string algorithmName, string algTypeCode, int count, string algorithmFile, string visualizationFile)
        {
            pdmLicenseGenerator.UploadAlgorithmDetails(algorithmName, algTypeCode, count, algorithmFile, visualizationFile);
        }

        [When(@"clicked Generate License button")]
        public void WhenClickedGenerateLicenseButton()
        {
            Thread.Sleep(1000);
            pdmLicenseGenerator.ClickGenerateLicense();
        }

        [Then(@"License should be generated for '(.*)'")]
        public void ThenLicenseShouldBeGeneratedFor(string licenseFileName)
        {
            pdmLicenseGenerator.SaveGenratedLicenseFile(licenseFileName);
            pdmLicenseGenerator.KillProcess();
        }

        [When(@"entered App Name '(.*)'")]
        public void WhenEnteredAppName(string appName)
        {
            if (pdMPage == null)
                pdMPage = new PdMPage(driver);
            if (pdMPage.IsAppExists(appName))
            {
                pdMPage.DeleteExistingApp(appName);
                Waits.Wait(driver, 2000);
            }
            pdMPage.EnterAppName(appName);
            Waits.Wait(driver, 1000);
        }

        [When(@"clicked on Import App button")]
        public void WhenClickedOnImportAppButton()
        {
            pdMPage.BtnImportApp.Click();
            Waits.Wait(driver, 1000);
        }

        [When(@"selected the algorithm license file '(.*)' created in previous test and upload the license file")]
        public void WhenSelectedTheMultiAlgorithmLicenseFileCreatedInPreviousTestAndUploadTheLicenseFile(string fileName)
        {
            string path = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\..\..\..\..\..\"));
            path = Path.Combine(path + fileName);
            if (!File.Exists(path))
            {
                if (fileName.Contains("Multiple"))
                {
                    pdmLicenseGenerator.GenerateMultiAlgoLicense(activationCode);
                }
                else if (fileName.Contains("Single"))
                {
                    pdmLicenseGenerator.GenerateSingleAlgoLicense(activationCode);
                }
                else if (fileName.Contains("Alarm"))
                {
                    pdmLicenseGenerator.GenerateSingleAlgoLicense(activationCode, algorithmName :"AlarmAlgorithm", algorithmFile: "FVX23913AcN2_UpdateTestV1.xml", visualizationFile : "UpdateVisualisationXML_Algorithm.txt", licensefileName : "AlarmAlgorithm.alf");
                }
            }
            pdMPage.UploadLicense(fileName);
        }

        [When(@"navigated to Import page")]
        public void WhenNavigatedToImportPage()
        {
            Waits.WaitAndClick(driver, pdMPage.ImgAddApp);
            Waits.Wait(driver, 1000);
        }

        [Then(@"License File uploaded successfully for app '(.*)' with algorithms '(.*)' and '(.*)'")]
        public void ThenLicenseFileUploadedSuccessfullyForAppWithAlgorithmsAnd(string appName, string algo1, string algo2)
        {
            Waits.WaitForElementVisible(driver, pdMPage.DrpDownAppName);
            Assert.IsTrue(pdMPage.DrpDownAppName.Text.Contains(appName), "Verified license file not updated successfully");
            List<string> algorithmNameList = pdMPage.GetAlgorithmNameFromList();
            Assert.IsTrue(algorithmNameList[0].Contains(algo1), "Verified uploaded alogrithm is not correct" + algorithmNameList[0]);
            Assert.IsTrue(algorithmNameList[1].Contains(algo2), "Verified uploaded alogrithm is not correct" + algorithmNameList[1]);
        }

        [Then(@"License File uploaded successfully for app '(.*)' with algorithm '(.*)'")]
        public void ThenLicenseFileUploadedSuccessfullyForAppWithAlgorithm(string appName, string algorithm)
        {
            Waits.Wait(driver, 5000);
            Waits.WaitForElementVisible(driver, pdMPage.DrpDownAppName);
            Assert.IsTrue(pdMPage.DrpDownAppName.Text.Contains(appName), "Verified license file not updated successfully");
            List<string> algorithmNameList = pdMPage.GetAlgorithmNameFromList();
            Assert.IsTrue(algorithmNameList[0].Contains(algorithm), "Verified uploaded alogrithm is not correct" + algorithmNameList[0]);
        }

        [When(@"Select the uploaded App name '(.*)' from dropdown")]
        public void WhenSelectTheUploadedAppNameFromDropdown(string appname)
        {
            driver.Navigate().Refresh();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Frame("ifmMain");
            pdMPage.SelectCreatedApp(appname);
        }

        [Then(@"App name '(.*)' selected successfully")]
        public void ThenAppNameSelectedSuccessfully(string appname)
        {
            Assert.IsTrue(pdMPage.SelectionIsExists(appname), "Verified App name is not selected successfully");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select algorithm '(.*)' associated to that App")]
        public void WhenSelectAlgorithmAssociatedToThatApp(string algoName)
        {
            pdMPage.SelectCreatedAlgorithm(algoName);
            Waits.Wait(driver, 3000);
        }

        [Then(@"Algorithm '(.*)'selected")]
        public void ThenAlgorithmSelected(string algoName)
        {
            Assert.IsTrue(pdMPage.SelectionIsExists(algoName), "Verified App name is not selected successfully");
            Waits.Wait(driver, 2000);
        }

        [When(@"Search for equipment using search box and select one by one")]
        public void WhenSearchForEquipmentUsingSearchBoxAndSelectOneByOne()
        {
            Waits.WaitAndClick(driver, pdMPage.BtnGo);
        }

        [Then(@"List of equipments '(.*)' are shown in left side list box control\.")]
        public void ThenListOfEquipmentsAreShownInLeftSideListBoxControl_(string equipment)
        {
            Assert.IsTrue(pdMPage.IsListedUnAssignedSystem(equipment), "Verified List of Equipment is not Listed successfully");
            Waits.Wait(driver, 1000);
        }

        [When(@"Use > button for addition of equipment '(.*)'")]
        public void WhenUseButtonForAdditionOfEquipment(string equipment)
        {
            pdMPage.MoveEquipment(equipment);
            Waits.Wait(driver, 1000);
        }

        [When(@"Use > button for addition of equipments '(.*)' '(.*)'")]
        public void WhenUseButtonForAdditionOfEquipments(string equipment, string equipment1)
        {
            string[] equipments = new string[] { equipment, equipment1 };
            for (int i = 0; i < 2; i++)
            {
                pdMPage.MoveEquipment(equipments[i]);
                Waits.Wait(driver, 1000);
            }
        }

        [Then(@"Selected equipment '(.*)' is added to right side list box control")]
        public void ThenSelectedEquipmentIsAddedToRightSideListBoxControl(string equipment)
        {
            Assert.IsTrue(pdMPage.IsListedAssignedSystem(equipment), "Verified List of Equipment is not Listed successfully");
        }

        [When(@"Press Apply button")]
        public void WhenPressApplyButton()
        {
            Waits.WaitAndClick(driver, pdMPage.BtnApply);
            Waits.Wait(driver, 5000);
        }

        [Then(@"Changes are saved and equipment associated to app successfully\.")]
        public void ThenChangesAreSavedAndEquipmentAssociatedToAppSuccessfully_()
        {            
            bool res = Waits.WaitForElementVisible(driver, pdMPage.LblApplySuccessMessage);
            Assert.IsTrue(res, "Verified Changes are not saved and equipment not associated to app successfully");
            Waits.Wait(driver, 1000);
        }

        [When(@"Launched DSPU simulator and Executed scenario '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void WhenLaunchedDSPUSimulatorAndExecutedScenario(string scenarioName, string inputFileName, string outFileName, string value)
        {
            simulator.LaunchScadaDSPU();
            string path = simulator.ScenarioAtributePath(scenarioName);
            simulator.SelectDSPUScenario(path);
            string inputPath = simulator.ScenarioAtributePath(inputFileName);
            string outputPath = simulator.ScenarioAtributePath(outFileName);
            simulator.SetDSPUAtributes(inputPath, outputPath, value);
            Waits.Wait(driver, 1000);
            simulator.ExecuteDSPU();
            Waits.Wait(driver, 7000);
            simulator.MinimizeDSPUGraph();
            Waits.Wait(driver, 1000);
            simulator.MinimizeDSPU();
            Waits.Wait(driver, 1000);
        }

        [When(@"navigated to PDM page")]
        public void WhenNavigatedToPDMPage()
        {
            deviceExplorerNavigationPage.LnkAdvancedSataAnalytics.Click();
            deviceExplorerNavigationPage.LnkPDM.Click();
        }

        [When(@"Clicked on the View Details")]
        public void WhenClickedOnTheViewDetails()
        {
            Waits.WaitAndClick(driver, pdMPage.LinkViewDetails);
        }

        [Then(@"All the algorithms '(.*)' & '(.*)' associated with the App have the same equipments '(.*)'\.")]
        public void ThenAllTheAlgorithmsAssociatedWithTheAppHaveTheSameEquipments_(string algo1, string algo2, string appName)
        {
            pdMPage.SelectCreatedAlgorithm(algo1);
            Assert.IsTrue(pdMPage.IsListedAssignedSystem(appName), "Verified Equipment " + appName + " is not associated to algorithm " + appName);
            pdMPage.SelectCreatedAlgorithm(algo2);
            Assert.IsTrue(pdMPage.IsListedAssignedSystem(appName), "Verified Equipment " + appName + " is not associated to algorithm " + appName);
        }

        [When(@"Dissociate all the equipments assigned to App '(.*)' algorithm if any")]
        public void WhenDissociateAllTheEquipmentsAssignedToAppAlgorithmIfAny(string appName)
        {
            pdMPage.Dissociate(appName);
        }

        [Then(@"Equipments'(.*)' are Dissociated successfully")]
        public void ThenEquipmentsAreDissociatedSuccessfully(string equipment)
        {
            Assert.IsTrue(pdMPage.IsListedUnAssignedSystem(equipment), "Verified Equipments are not Dissociated Successfully");
            Waits.Wait(driver, 1000);
        }

        [When(@"Press Delete button")]
        public void WhenPressDeleteButton()
        {
            Waits.WaitAndClick(driver, pdMPage.BtnDelete);
        }

        [Then(@"Alert shown with message ""(.*)""")]
        public void ThenAlertShownWithMessage(string message)
        {
            Waits.WaitForElementVisible(driver, pdMPage.LblSuccessDeleteMessage);
            Assert.IsTrue(pdMPage.LblSuccessDeleteMessage.Text.Contains(message), "Verifying Alert not shown delete confirmation message");
        }

        [When(@"Press Cancel")]
        public void WhenPressCancel()
        {
            Waits.WaitAndClick(driver, pdMPage.BtnCancel);
        }

        [Then(@"Returns to same page")]
        public void ThenReturnsToSamePage()
        {
            bool res = Waits.WaitForElementVisible(driver, pdMPage.BtnDelete);
            Assert.IsTrue(res, "Verifying Returns to same page not happened");
        }

        [When(@"Press app '(.*)' Delete button")]
        public void WhenPressAppDeleteButton(string appName)
        {
            Waits.WaitAndClick(driver, pdMPage.BtnDelete);
        }

        [Then(@"Delete this app shown")]
        public void ThenDeleteThisAppShown()
        {
            bool res = Waits.WaitForElementVisible(driver, pdMPage.BtnCancel);
            Assert.IsTrue(res, "Verified Delete this App not appear in screen");
        }

        [When(@"Press Delete item")]
        public void WhenPressDeleteItem()
        {
            Waits.WaitAndClick(driver, pdMPage.BtnDeleteItem);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Delete the app with algorithms '(.*)' successfully")]
        public void ThenDeleteTheAppWithAlgorithmsSuccessfully(string algoName)
        {
            Assert.IsFalse(pdMPage.IsAlgorithmExist(algoName), "Verfied Delete the app with algorithms not successfully");
        }

        [Then(@"App name '(.*)' should disappear from the list")]
        public void ThenAppNameShouldDisappearFromTheList(string appName)
        {
            Assert.IsFalse(pdMPage.IsAppExists(appName), "Verfied App name should not disappear from the list");
        }

        [Then(@"Note down the Unique Id details GUID shown in tool")]
        public void ThenNoteDownTheUniqueIdDetailsGUIDShownInTool()
        {
            uniqueID = pdmLicenseGenerator.UniqueID();
        }

        [When(@"navigated to home page and clicked device explorer link")]
        public void WhenNavigatedToHomePageAndClickedDeviceExplorerLink()
        {
            driver.Navigate().Refresh();
            Waits.Wait(driver, 1000);
            deviceExplorerNavigationPage.NavigateToHomePage();
            bool res = Waits.WaitForElementVisible(driver, homePage.LnkDeviceManager);
            Assert.IsTrue(res, "Verifying User should be navigated to Home page");
            homePage.ClickOnDeviceExplorer();
        }

        [When(@"Launched DSPU simulator and Execute scenario '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void WhenLaunchedDSPUSimulatorAndExecuteScenario(string scenarioName, string inputFileName, string outFileName, string value)
        {
            simulator.LaunchScadaDSPU();
            string path = simulator.ScenarioAtributePath(scenarioName);
            simulator.SelectDSPUScenario(path);
            string inputPath = simulator.ScenarioAtributePath(inputFileName);
            string outputPath = simulator.ScenarioAtributePath(outFileName);
            simulator.SetDSPUAtributes(inputPath, outputPath, value);
            Waits.Wait(driver, 1000);
            simulator.ExecuteDSPU();
            Waits.Wait(driver, 10000);
            simulator.StopDSPUScenario();
            Waits.Wait(driver, 1000);
            simulator.MinimizeDSPU();
            Waits.Wait(driver, 1000);
        }
               

        [Then(@"Navigate to PdM Page")]
        public void ThenNavigateToPdMPage()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            deviceExplorerNavigationPage.NavigateToHomePage();
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkPdM);
            Waits.Wait(driver, 4000);
            if (pdMPage == null)
                pdMPage = new PdMPage(driver);
            Waits.WaitForElementVisible(driver, pdMPage.PDMMenuImage);
            driver.Navigate().Refresh();
            Waits.Wait(driver, 1000);
            driver.SwitchTo().Frame("ifmMain");
            Waits.Wait(driver, 1000);
        }

        [When(@"Start DSPU Scenario '(.*)'")]
        public void ThenStartDSPUScenario(string name)
        {
            string dspuPath = simulator.ScenarioAtributePath(name);
            simulator.RestoreScada(dspuPath);
            Waits.Wait(driver, 1000);
            simulator.StartDSPUScenario();
            Waits.Wait(driver, 1000);
            simulator.MinimizeDSPUGraph();
            Waits.Wait(driver, 1000);
            simulator.MinimizeDSPU();
            Waits.Wait(driver, 1000);
        }
               
        [When(@"Check for alerts on Web UI\.")]
        public void WhenCheckForAlertsOnWebUI_()
        {
            driver.Navigate().Refresh();
            Waits.Wait(driver, 1000);
            for (int i = 0; i < 600; i++)
            {
                Waits.Wait(driver, 5000);
                if (pdMPage.LblAlarmCount.Text.Contains("2"))
                {
                    Assert.IsTrue(ElementExtensions.isDisplayed(driver, pdMPage.LblAlarmCount), "Verified alerts not appeared on Web UI.");
                    break;
                }
                else
                {
                    continue;
                }
            }
            Waits.Wait(driver, 1000);
        }

        [Then(@"Alarm alerts are displayed on the Web UI")]
        public void ThenAlarmAlertsAreDisplayedOnTheWebUI()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(pdMPage.LblAlarmCount, "2"), "Verified Alarm alerts are not displayed on the Web UI");
            Waits.Wait(driver, 1000);
        }

        [When(@"Restore scada '(.*)' and stop scenario once execution got closed")]
        public void ThenRestoreScadaAndStopScenarioOnceExecutionGotClosed(string name)
        {
            for (int i = 0; i < 60; i++)
            {
                Waits.Wait(driver, 5000);
                if (pdMPage.LblErrorCount.Text.Contains("0"))
                {
                    string dspuPath = simulator.ScenarioAtributePath(name);
                    simulator.RestoreScada(dspuPath);
                    Thread.Sleep(1000);
                    simulator.StopDSPUScenario();
                    Thread.Sleep(1000);
                    simulator.MinimizeDSPU();
                    break;
                }
            }
            Waits.Wait(driver, 1000);
            //simulator.ScenarioCompletion();
        }
        
        [When(@"Open the App license '(.*)' in license generator tool\.")]
        public void WhenOpenTheAppLicenseInLicenseGeneratorTool_(string licenseName)
        {
            pdmLicenseGenerator.LaunchPdMLicenseGeneratorApp();
            pdmLicenseGenerator.SetDatabase();
            Thread.Sleep(1000);
            pdmLicenseGenerator.OpenLicense(licenseName);
            Thread.Sleep(1000);
        }

        [Then(@"GUID noted in step one should be shown\.")]
        public void ThenGUIDNotedInStepOneShouldBeShown_()
        {
            Assert.AreEqual(uniqueID, pdmLicenseGenerator.UniqueID(), "Verified GUID noted in step1 should not shown");

        }

        [When(@"Update the xml use warning alert model '(.*)' and expiry date and generate the new '(.*)' App license\.")]
        public void WhenUpdateTheXmlUseWarningAlertModelAndExpiryDateAndGenerateTheNewAppLicense_(string algorithmFile, string filename)
        {
            pdmLicenseGenerator.UpdateXML(algorithmFile, filename);
            Updateexpiry = pdmLicenseGenerator.ExpiryDate();
            pdmLicenseGenerator.KillProcess();
        }

        [Then(@"New app license '(.*)' with updated details is created")]
        public void ThenNewAppLicenseWithUpdatedDetailsIsCreated(string licenseName)
        {
            Assert.IsTrue(pdMPage.IsLicenseExist(licenseName), "Verified New app license  with updated details is not created");
            Waits.Wait(driver, 1000);
        }

        [When(@"Refresh page and switch to PdM license page")]
        public void ThenRefreshPageAndSwitchToPdMLicensePage()
        {
            driver.Navigate().Refresh();
            driver.SwitchTo().Frame("ifmMain");
        }


        [Then(@"Ensure it prompts for Update, Create New and Cancel\.")]
        public void ThenEnsureItPromptsForUpdateCreateNewAndCancel_()
        {
            if (ElementExtensions.isDisplayed(driver, pdMPage.BtnUpdate))
            {
                Assert.IsTrue(ElementExtensions.isDisplayed(driver, pdMPage.BtnUpdate), "Ensure it prompts for Update not Appeared");
                Waits.Wait(driver, 1000);
            }
            if (ElementExtensions.isDisplayed(driver, pdMPage.BtnCreateNew))
            {
                Assert.IsTrue(ElementExtensions.isDisplayed(driver, pdMPage.BtnCreateNew), "Ensure it prompts for Update not Appeared");
                Waits.Wait(driver, 1000);
            }
            if (ElementExtensions.isDisplayed(driver, pdMPage.BtnUpdateCancel))
            {
                Assert.IsTrue(ElementExtensions.isDisplayed(driver, pdMPage.BtnUpdateCancel), "Ensure it prompts for Update not Appeared");
                Waits.Wait(driver, 1000);
            }
        }

        [When(@"Click on Update button\.")]
        public void WhenClickOnUpdateButton_()
        {
            Waits.WaitAndClick(driver, pdMPage.BtnUpdate);
            Waits.Wait(driver, 1000);
        }

        [Then(@"License is updated successfully\.")]
        public void ThenLicenseIsUpdatedSuccessfully_()
        {
            Assert.IsFalse(ElementExtensions.isDisplayed(driver, pdMPage.BtnCreateNew), "License is updated not successfully");
            Waits.Wait(driver, 1000);
        }

        [When(@"Check the expiry date on Web UI\.")]
        public void WhenCheckTheExpiryDateOnWebUI_()
        {
            driver.Navigate().Refresh();
            driver.SwitchTo().Frame("ifmMain");
            Waits.WaitAndClick(driver, pdMPage.LinkViewDetails);
            string tempDate = pdMPage.LnkExpiryDate.Text;
            Waits.Wait(driver, 1000);
        }

        [Then(@"Ensure that the expiry date is updated successfully\.")]
        public void ThenEnsureThatTheExpiryDateIsUpdatedSuccessfully_()
        {
            Assert.IsTrue(pdMPage.LnkExpiryDate.Text.Contains(Updateexpiry), "Ensure that the expiry date is not updated successfully");
        }

        [When(@"Run DSPU scenario '(.*)' and check the alerts\.")]
        public void WhenRunDSPUScenarioAndCheckTheAlerts_(string name)
        {
            string dspuPath = simulator.ScenarioAtributePath(name);
            simulator.RestoreScada(dspuPath);
            Waits.Wait(driver, 1000);
            simulator.StartDSPUScenario();
            Waits.Wait(driver, 7000);
            simulator.MinimizeDSPUGraph();
            Waits.Wait(driver, 1000);
            simulator.MinimizeDSPU();
        }

        [Then(@"warning alerts are observed then model xml is updated successfully otherwise fail the test\.")]
        public void ThenWarningAlertsAreObservedThenModelXmlIsUpdatedSuccessfullyOtherwiseFailTheTest_()
        {
            driver.Navigate().Refresh();
            Waits.Wait(driver, 1000);
            for (int i = 0; i < 600; i++)
            {
                Waits.Wait(driver, 5000);
                if (pdMPage.LblWarningCount.Text.Contains("2"))
                {
                    Assert.IsTrue(ElementExtensions.isDisplayed(driver, pdMPage.LblWarningCount), "Verified alerts not appeared on Web UI.");
                    break;
                }
                else
                {
                    continue;
                }
            }
            Waits.Wait(driver, 1000);
        }

        [Then(@"Ensure that on perfroming license '(.*)' update, the associated equipments'(.*)' will not change\.")]
        public void ThenEnsureThatOnPerfromingLicenseUpdateTheAssociatedEquipmentsWillNotChange_(string appname, string equipment)
        {
            driver.Navigate().Refresh();
            driver.SwitchTo().Frame("ifmMain");
            pdMPage.SelectCreatedApp(appname);
            Waits.WaitAndClick(driver, pdMPage.LinkViewDetails);
            Assert.IsTrue(pdMPage.IsListedAssignedSystem(equipment), "Ensured that on perfroming license update, the associated equipments changed");
        }

        [When(@"I entered Equipment name, selected equipmentType '(.*)', Cliked Find Equipment button, selected equipment '(.*)' '(.*)' '(.*)' and clicked Add button\.")]
        public void WhenIEnteredEquipmentNameSelectedEquipmentTypeClikedFindEquipmentButtonSelectedEquipmentAndClickedAddButton_(string equipmentType, string equipmentName1, string equipmentName2, string equipmentName3)
        {
            string[] equipment = new string[] { equipmentName1, equipmentName2, equipmentName3 };
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkNavigate);
            deviceExplorerNavigationPage.LnkNavigate.Click();
            for (int i = 0; i < equipment.Length; i++)
            {
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkAddDevice);
                deviceExplorerNavigationPage.AddEquipmentToSystem(equipmentType, equipment[i]);
                Waits.Wait(driver, 4000);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
                Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.EquipmentAddedMsg), "Verifying 'Equipment Added Successfully' message");
                deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
                Waits.Wait(driver, 4000);
            }
        }

        [Then(@"Alerts to be shown on screen")]
        public void ThenAlertsToBeShownOnScreen()
        {
            for (int i = 0; i <= 40; i++)
            {
                try
                {
                    Waits.Wait(driver, 5000);
                    if (!pdMPage.LnkAlarmCount.Text.Equals("0"))
                    {
                        break;
                    }
                    else
                    {
                        Assert.Fail("Alarm alerts not generated");
                    }
                }
                catch (NoSuchElementException)
                {
                    Waits.Wait(driver, 30000);
                    driver.Navigate().Refresh();

                }
            }
        }



        [When(@"Selected previously added '(.*)' equipment")]
        public void WhenSelectedPreviouslyAddedEquipment(string equipment)
        {
            pdMPage.SelectAssignedEquipment(equipment);
        }

        [When(@"clicked Reset button")]
        public void WhenClickedResetButton()
        {
            Waits.WaitAndClick(driver, pdMPage.BtnReset);
        }

        [Then(@"Dialog box appear with message '(.*)'")]
        public void ThenDialogBoxAppearWithMessage(string message)
        {
            Assert.IsTrue(pdMPage.BtnResetPopUpMsg.Text.Contains(message), "Reset pop -up message is incorrect" + "Expected was " + message + "Actaula was : " + pdMPage.BtnResetPopUpMsg.Text.Contains(message));
        }

        [When(@"Pressed Reset button on the dialog box")]
        public void WhenPressedResetButtonOnTheDialogBox()
        {
            Waits.WaitAndClick(driver, pdMPage.BtnResetPopUp);
        }

        [Then(@"'(.*)' message appeared")]
        public void ThenMessageAppeared(string message)
        {
            Assert.IsTrue(pdMPage.BtnResetPopUpMsg.Text.Contains(message), "Reset pop -up message is incorrect" + "Expected was " + message + "Actaula was : " + pdMPage.BtnResetPopUpMsg.Text.Contains(message));
        }


        [When(@"Closed pop up")]
        public void ThenClosedPopUp()
        {
            Waits.WaitAndClick(driver, pdMPage.BtnClose);
        }

        [Then(@"All active alerts associated with selected equipments should disapper")]
        public void ThenAllActiveAlertsAssociatedWithSelectedEquipmentsShouldDisapper()
        {
            Waits.Wait(driver, 10000);
            driver.Navigate().Refresh();
            Waits.Wait(driver, 8000);
            Assert.IsTrue(pdMPage.LnkAlarm.GetAttribute("title").Contains("Systems In Alarm: 0 (Total Alarms: 0)"), "Alarm alerts are not set to 0 after manaul reset");
        }


        [When(@"added '(.*)' device\.")]
        public void WhenAddedDevice_(string equipment)
        {
            Waits.Wait(driver, 5000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkNavigate);
            Waits.Wait(driver, 5000);
            deviceExplorerNavigationPage.AddEquipmentToSystem(equipment);
        }
    }

}