using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class OtherDeviceDataTypesStepDefinition
    {
        string testFolderName = ElementExtensions.GetRandomString(4);
        LoginPage loginPage;
        HomePage homePage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        LoggingPage loggingPage;
        UserPage userPage;
        LiveAlertsListPage liveAlertsListPage;
        HistorianPage historianPage;
        Simulator simulator = new Simulator();
        private IWebDriver driver;
        string grabID = "";
        string parentHandle = "";
        string iPAdress = SpecflowHooks.HostIpAddress();

        public OtherDeviceDataTypesStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            loggingPage = new LoggingPage(driver);
            userPage = new UserPage(driver);
            liveAlertsListPage = new LiveAlertsListPage(driver);
            historianPage = new HistorianPage(driver);
        }
        

        [When(@"Enable GreenMode in EdCentra Options EnableGreenMode=On")]
        public void WhenEnableGreenModeInEdCentraOptionsEnableGreenModeOn()
        {
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            loggingPage.EnableGreenMode();
            Waits.Wait(driver, 2000);
        }

        [Then(@"Confirm the Success message")]
        public void ThenConfirmTheSuccessMessage()
        {
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            Assert.IsTrue(loggingPage.LblFeedback.Text.Contains(GlobalConstants.ChangesApplied), "Verified changes saved message");
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, loggingPage.BtnClose);
            Waits.Wait(driver, 1000);
        }

        [When(@"open the DSPU and open Eco Mode Scenario '(.*)'")]
        public void WhenOpenTheDSPUAndOpenEcoModeScenario(string scenarioName)
        {
            simulator.RestoreWindow();
            simulator.KillProcess();
            Waits.Wait(driver, 4000);
            simulator.LaunchScadaDSPU();
            Waits.Wait(driver, 2000);
            simulator.SelectDSPUScenario(simulator.ScenarioAtributePath(scenarioName));
            Waits.Wait(driver, 2000);
        }

        [When(@"I Entered Equipment name, Selected the Equipment type,Cliked Find Equipment button, selected one by one equipments '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'and clicked Add button")]
        public void WhenIEnteredEquipmentNameSelectedTheEquipmentTypeClikedFindEquipmentButtonSelectedOneByOneEquipmentsAndClickedAddButton(string equipmentName1, string equipmentName2, string equipmentName3, string equipmentName4, string equipmentName5, string equipmentName6)
        {
            string[] equipments = new string[] { equipmentName1, equipmentName2, equipmentName3, equipmentName4, equipmentName5 };

            for (int i = 0; i <= equipments.Length - 1; i++)
            {
                Waits.Wait(driver, 2000);
                if (deviceExplorerNavigationPage == null)
                    deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
                deviceExplorerNavigationPage.AddEquipmentToSystem("All", equipments[i]);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
                Waits.Wait(driver, 1000);
                Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.EquipmentAddedMsg), "Verifying 'Equipment Added Successfully' message");
                Waits.Wait(driver, 1000);
                deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            }
        }

        [When(@"grab the system '(.*)' id of every iXH for the test")]
        public void ThenGrabTheSystemIdOfEveryIXHForTheTest(string agent)
        {
            Waits.Wait(driver, 4000);
            parentHandle = driver.CurrentWindowHandle;
            Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkNetworkLayout);
            deviceExplorerNavigationPage.LnkNetworkLayout.Click();
            Waits.Wait(driver, 3000);
            loggingPage.SelectAgentServer(agent);
            Waits.Wait(driver, 4000);
            grabID = loggingPage.SelectSystemId();
            Waits.Wait(driver, 4000);
        }


        [Then(@"in the DSPU, edit \[ MANIPULATOR / Spawner / DPD to systems A ] and \[ MANIPULATOR / Spawner / DPD to systems B ] setting the property Value to the iXH pipe delimited system id list above")]
        public void ThenInTheDSPUEditMANIPULATORSpawnerDPDToSystemsAAndMANIPULATORSpawnerDPDToSystemsBSettingThePropertyValueToTheIXHPipeDelimitedSystemIdListAbove()
        {
            simulator.SetPropertyValue(grabID);
            Waits.Wait(driver, 4000);
        }

        [When(@"Execute the DSPU scenario and then watch the equipment in DeviceExplorer for a about five minutes")]
        public void WhenExecuteTheDSPUScenarioAndThenWatchTheEquipmentInDeviceExplorerForAAboutFiveMinutes()
        {
            simulator.ExecuteDSPU();
            Waits.Wait(driver, 60000);
            simulator.MinimizeDSPU();
            Waits.Wait(driver, 3000);
        }

        [When(@"Click Historian Equipment Data tab")]
        public void WhenClickHistorianEquipmentDataTab()
        {
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            loggingPage.NavigateToHomePage();
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            Waits.WaitAndClick(driver, historianPage.LnkHistorian);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Equipment Datatab should be shown and Select Device Explorer folder on Systems list")]
        public void ThenEquipmentDatatabShouldBeShownAndSelectDeviceExplorerFolderOnSystemsList()
        {
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            bool res = Waits.WaitForElementVisible(driver, historianPage.LnkHistorianEquipmentData);
            Assert.IsTrue(res, "Verified screen presence the Equipment Data tab");
            Waits.Wait(driver, 1000);
            historianPage.ExpandSystemsParameter();
        }

        [When(@"Expand the folder and Select single Equipment '(.*)' in the Tree")]
        public void WhenExpandTheFolderAndSelectSingleEquipmentInTheTree(string EquipmentName)
        {
            Waits.Wait(driver, 6000);
            Assert.IsTrue(historianPage.ExpandSystemsParameterCheck(), "Verified Systems Parameter Expanded");
            historianPage.SelectSingleParameterEquipment(EquipmentName);
            Waits.Wait(driver, 2000);
        }

        [Then(@"The Parameter'(.*)' for that Equipment will be displayed in the parameter's list")]
        public void ThenTheParameterForThatEquipmentWillBeDisplayedInTheParameterSList(string Parameter1)
        {
            Assert.IsTrue(historianPage.IsParameterListPresent(Parameter1), "Verified The parameters for that equipment will be displayed");
            Waits.Wait(driver, 3000);
        }

        [When(@"I click on of the parameter'(.*)' and click Add button at the bottom of the parameter list")]
        public void WhenIClickOnOfTheParameterAndClickAddButtonAtTheBottomOfTheParameterList(string Parameter2)
        {
            historianPage.SelectSingleParameter(Parameter2);
            Waits.Wait(driver, 2000);
            Waits.WaitTillElementIsClickable(driver, historianPage.BtnAddParameter);
            Waits.Wait(driver, 5000);
        }

        [Then(@"view the Equipment Status value '(.*)' in the Historian Equipment Status grid view")]
        public void ThenViewTheEquipmentStatusValueInTheHistorianEquipmentStatusGridView(string value)
        {
            Waits.WaitAndClick(driver, historianPage.LnkGridTab);
            Waits.Wait(driver, 4000);
            Assert.IsTrue(loggingPage.EquipmentStatus(value), "Verfied view the Equipment Status value in the Historian Equipment Status grid view ");
            Waits.Wait(driver, 4000);
        }

        [When(@"Stop the DSPU scenario and start EISSA again")]
        public void WhenStopTheDSPUScenarioAndStartEISSAAgain()
        {
            simulator.KillProcess();
            Waits.Wait(driver, 4000);
            simulator.LaunchSimulator();
        }

        [Then(@"DSPU data to stop flowing and regular EISSA data'(.*)' '(.*)' to flow again '(.*)'")]
        public void ThenDSPUDataToStopFlowingAndRegularEISSADataToFlowAgain(string parameter1, string value, string parameter2)
        {
            simulator.SelectBaseName();
            simulator.SelectDeviceEquipmentType();
            simulator.SelectEquipment();
            simulator.SelectParameter(parameter1);
            simulator.SetParameterValueNew(value);
            simulator.MinimizeWindow();
            Waits.Wait(driver, 5000);
            historianPage.SelectSingleParameter(parameter2);
            Waits.Wait(driver, 2000);
            Waits.WaitTillElementIsClickable(driver, historianPage.BtnAddParameter);
            Waits.Wait(driver, 5000);
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            Assert.IsTrue(loggingPage.EquipmentStatus(value), "Verfied DSPU data to stop flowing and EISAA data to flow again ");
            Waits.Wait(driver, 4000);
        }

        [When(@"Open the SEV '(.*)' to the device")]
        public void WhenOpenTheSEVToTheDevice(string SEV)
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblFolderDivison);
            try
            {
                Waits.Wait(driver, 4000);
                deviceExplorerNavigationPage.ClickEquipment(SEV);
            }
            catch (StaleElementReferenceException)
            {
                Waits.Wait(driver, 1000);
                deviceExplorerNavigationPage.ClickEquipment(SEV);
            }

            //Assert.IsTrue(deviceExplorerNavigationPage.LblFolderDivison.GetAttribute("title").Contains(SEV), "Verified Select a EUV FC Slice Controller device");
            //Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSEVPage);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSEVPage.Displayed, "Verified Navigate to the SEV view of a valid device");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkParameters);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Make sure data appears on the UI")]
        public void ThenMakeSureDataAppearsOnTheUI()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblMasterFlow);
            Assert.IsTrue(deviceExplorerNavigationPage.LblMasterFlow.Displayed, "Verified Make sure data appears on the UI");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Make sure Proteus data appears on the UI")]
        public void ThenMakeSureProteusDataAppearsOnTheUI()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblChannelTemperatures);
            Assert.IsTrue(deviceExplorerNavigationPage.LblChannelTemperatures.Displayed, "Verified Make sure data appears on the UI");
            Waits.Wait(driver, 1000);
        }

        [When(@"Raise an alert '(.*)' '(.*)' '(.*)' \(alarm\) on the EISSA simulator on the Slice Controller")]
        public void WhenRaiseAnAlertAlarmOnTheEISSASimulatorOnTheSliceController(string parameter, string alerType, string alertCode)
        {
            simulator.RestoreWindow();
            simulator.RaiseAlert(parameter, alerType, alertCode);
            simulator.MinimizeWindow();
        }

        [Then(@"Make sure the  alarm alert appears in the SEV, and Alert List app")]
        public void ThenMakeSureTheAlarmAlertAppearsInTheSEVAndAlertListApp()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.TabOverview);
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblStatus);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblAlarmCount, "1"), "Verified Correct number of Alaram alerts displayed in overview");
            Waits.Wait(driver, 1000);
        }

        [When(@"Raise an alert '(.*)' '(.*)' '(.*)' \(warning\) on the EISSA simulator on the Slice Controller")]
        public void WhenRaiseAnAlertWarningOnTheEISSASimulatorOnTheSliceController(string parameter, string alerType, string alertCode)
        {
            simulator.RestoreWindow();
            simulator.RaiseAlert(parameter, alerType, alertCode);
            simulator.MinimizeWindow();
        }

        [Then(@"Make sure the warning alert appears in the SEV, and Alert List app")]
        public void ThenMakeSureTheWarningAlertAppearsInTheSEVAndAlertListApp()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.Wait(driver, 2000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblWarningCount, "1"), "Verified Correct number of Warning alerts displayed in overview");
            Waits.Wait(driver, 1000);
        }

        [When(@"Clear the alarm '(.*)' alert")]
        public void WhenClearTheAlarmAlert(string parameter)
        {
            simulator.RestoreWindow();
            simulator.ClearAlert(parameter);
            simulator.MinimizeWindow();
            Waits.Wait(driver, 1000);
        }

        [Then(@"Make sure the alarm alert disappears in the SEV, and Alert List app")]
        public void ThenMakeSureTheAlarmAlertDisappearsInTheSEVAndAlertListApp()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblAlarmCount, "0"), "Verified the alarm alert disappears in the SEV, and Alert List app");
        }

        [When(@"Clear the warning '(.*)' alert")]
        public void WhenClearTheWarningAlert(string parameter)
        {
            simulator.RestoreWindow();
            simulator.ClearAlert(parameter);
            simulator.MinimizeWindow();
        }

        [Then(@"Make sure the warning alert disappears in the SEV, and Alert List app")]
        public void ThenMakeSureTheWarningAlertDisappearsInTheSEVAndAlertListApp()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblWarningCount, "0"), "Verified the warning alert disappears in the SEV, and Alert List app");
            Waits.Wait(driver, 1000);
        }

        [When(@"Modify the running status of the Slice Controller device'(.*)' between Running and '(.*)' in EISSA")]
        public void WhenModifyTheRunningStatusOfTheSliceControllerDeviceBetweenRunningAndInEISSA(string device, string status)
        {
            Thread.Sleep(1000);
            simulator.RestoreWindow();
            Thread.Sleep(1000);
            simulator.SelectSingleEquipment(device);
            Thread.Sleep(1000);
            simulator.SetDeviceStatus(status);
            Thread.Sleep(1000);
            simulator.MinimizeWindow();
        }

        [Then(@"Just make sure the status changes in EdCentra between '(.*)' and Modify the running status of the Slice Controller device '(.*)' and  status changes in EdCentra'(.*)'")]
        public void ThenJustMakeSureTheStatusChangesInEdCentraBetweenAndModifyTheRunningStatusOfTheSliceControllerDeviceAndStatusChangesInEdCentra(string deviceStatus1, string status, string deviceStatus2)
        {
            for (int i = 0; i <= 30; i++)
            {
                Waits.Wait(driver, 1000);
                if (deviceExplorerNavigationPage.LblStatus.Text.Contains(deviceStatus1))
                {
                    Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblStatus);
                    Assert.IsTrue(deviceExplorerNavigationPage.LblStatus.Text.Contains(deviceStatus1), "Verified Status selected in the EISSA is updated and displayed correctly in the Edcentra Device Explorer SEV");
                    Waits.Wait(driver, 1000);
                    break;
                }
            }
            simulator.RestoreWindow();
            simulator.SetDeviceStatus(status);
            simulator.MinimizeWindow();
            Waits.Wait(driver, 15000);
            for (int i = 0; i <= 30; i++)
            {
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblStatus);
                if (deviceExplorerNavigationPage.LblStatus.Text.Contains(deviceStatus2))
                {
                    Assert.IsTrue(deviceExplorerNavigationPage.LblStatus.Text.Contains(deviceStatus2), "Verified Status selected in the EISSA is updated and displayed correctly in the Edcentra Device Explorer SEV");
                    Waits.Wait(driver, 1000);
                    break;
                }
            }
        }

        [When(@"Make number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'\.Click Apply\.")]
        public void WhenMakeNumberOfSelectionsFromTheListOfAvailableParametersAndChangeTheValuesForTheNormalAlertAndDelta_ClickApply_(string Parameter, string TimeintervalforNormal, string TimeintervalforAlert, string TimeintervalforDelta, string Parameter1, string TimeintervalforNormal1, string TimeintervalforAlert1, string TimeintervalforDelta1, string Parameter2, string TimeintervalforNormal2, string TimeintervalforAlert2, string TimeintervalforDelta2)
        {
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            loggingPage.ParameterSelection(Parameter, TimeintervalforNormal, TimeintervalforAlert, TimeintervalforDelta);
            Waits.Wait(driver, 1000);
            loggingPage.ParameterSelection(Parameter1, TimeintervalforNormal1, TimeintervalforAlert1, TimeintervalforDelta1);
            Waits.Wait(driver, 1000);
            loggingPage.ParameterSelection(Parameter2, TimeintervalforNormal2, TimeintervalforAlert2, TimeintervalforDelta2);
            Waits.Wait(driver, 1000);
            loggingPage.ClickApplyChanges();
            Waits.Wait(driver, 2000);
        }

        [Then(@"The screen will show applied values for Normal / Alert and Delta fields for the parameter\.The screen will only list parameters'(.*)' added in Profile")]
        public void ThenTheScreenWillShowAppliedValuesForNormalAlertAndDeltaFieldsForTheParameter_TheScreenWillOnlyListParametersAddedInProfile(string parameter)
        {
            Assert.IsTrue(loggingPage.SelectedParameterListed(parameter), "Screen present only the selected parameters");
            Waits.Wait(driver, 4000);
        }

        [When(@"I Find equipment'(.*)' using equipment description to Assigned Equipment list using > and >> button then Click Apply")]
        public void WhenIFindEquipmentUsingEquipmentDescriptionToAssignedEquipmentListUsingAndButtonThenClickApply(string Equipment)
        {
            loggingPage.SelectSingleEquipmentAndMoveToAssign(Equipment);
        }

        [When(@"I Delete the newly created Folder")]
        public void WhenIDeleteTheNewlyCreatedFolder()
        {
            loggingPage.DeleteNewlyCreatedFolder(testFolderName);
            Waits.Wait(driver, 2000);
        }

        [Then(@"Ensure the Folder is deleted")]
        public void ThenEnsureTheFolderIsDeleted()
        {
            Assert.IsTrue(historianPage.IsFolderHidden(testFolderName), "Verified folder shouldn't be present after delete action");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Close EISAA and Agent configuration")]
        public void ThenCloseEISAAAndAgentConfiguration()
        {
            simulator.RestoreWindow();
            Waits.Wait(driver, 1000);
            simulator.KillProcess();
            Waits.Wait(driver, 1000);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkRealTimeMonitoring);
                Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkDeviceExplorer);
                deviceExplorerNavigationPage.DeleteAddedFolder(testFolderName);
                simulator.KillProcess();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught " + ex.Message);
            }

        }
    }
}
