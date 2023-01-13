using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class ModbusTestStepDefinition
    {
        string testFolderName = ElementExtensions.GetRandomString(4);
        string equipmentName = ElementExtensions.GetRandomAlphabeticalString(5);
        string parentHandle = string.Empty;
        private IWebDriver driver;
        HomePage homePage;
        LoginPage loginPage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        LoggingPage loggingPage;
        ModbusTestPage modbusTestPage;
        LiveAlertsListPage liveAlertsListPage;
        EdwardsIOControllerPage edwardsIOControllerPage;
        Simulator simulator = new Simulator();

        public ModbusTestStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            loggingPage = new LoggingPage(driver);
            modbusTestPage = new ModbusTestPage(driver);
            liveAlertsListPage = new LiveAlertsListPage(driver);
            edwardsIOControllerPage = new EdwardsIOControllerPage(driver);
        }


        [When(@"Run modbus simulator up, and set num ports to ""(.*)"" Click the Start button")]
        public void WhenRunModbusSimulatorUpAndSetNumPortsToClickTheStartButton(string portNumber)
        {
            simulator.LaunchModbusWindow(portNumber);
        }

        [Then(@"open file dialog shows, choose the '(.*)' file")]
        public void ThenOpenFileDialogShowsChooseTheFile(string filename)
        {

            var filepath = GlobalConstants.ModbusFilePath + @"\" + filename;
            Waits.Wait(driver, 1000);
            simulator.OpenRgrFile(filename);
            simulator.MinimizeModbus();
        }

        [When(@"Open the device in Device explorer to show device SEV screen")]
        public void WhenOpenTheDeviceInDeviceExplorerToShowDeviceSEVScreen()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            string equipmentName = (string)ScenarioContext.Current["EquipmentName"];
            try
            {                
                Waits.Wait(driver, 15000);
                deviceExplorerNavigationPage.ClickEquipment(equipmentName);
            }
            catch (StaleElementReferenceException)
            {
                Waits.Wait(driver, 4000);
                deviceExplorerNavigationPage.ClickEquipment(equipmentName);
            }
            Waits.Wait(driver, 4000);
            bool res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSEVPage);
            Assert.IsTrue(res, "Verified Navigate to the SEV view of a valid device");
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkParameters);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Some analogue parameters such as Water Tank Flow  Inlet Pressure Oxidzer Flow Rate")]
        public void ThenSomeAnalogueParametersSuchAsWaterTankFlowInletPressureOxidzerFlowRate()
        {
            if (modbusTestPage == null)
                modbusTestPage = new ModbusTestPage(driver);
            bool res = Waits.WaitForElementVisible(driver, modbusTestPage.LblWaterTankFlowTemp);
            Assert.IsTrue(res, "Verified WaterTank Flow Temp is not displayed");
            res = Waits.WaitForElementVisible(driver, modbusTestPage.LblInletPressure);
            Assert.IsTrue(res, "Verified Inlet Pressure parameter is not displayed");
            res = Waits.WaitForElementVisible(driver, modbusTestPage.LblOxidizerFlowRate);
            Assert.IsTrue(res, "Verified Oxidizer Flow Rate parameter is not displayed");
            Waits.Wait(driver, 1000);
        }

        [When(@"Change '(.*)' '(.*)' to '(.*)'")]
        public void WhenChangeTo(string registerType, string address, string value)
        {
            simulator.RestoreModbus();
            Waits.Wait(driver, 1000);
            simulator.ChangeRegisterValue(registerType, address, value);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Make sure that the parameter '(.*)' changes to '(.*)'")]
        public void ThenMakeSureThatTheParameterChangesTo(string parameter, string value)
        {
            simulator.MinimizeModbus();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Window(parentHandle);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkParameters);
            Waits.Wait(driver, 1000);
            if (modbusTestPage == null)
                modbusTestPage = new ModbusTestPage(driver);
            string paramvalue = modbusTestPage.LblInletPressurervalue.Text;
            Waits.Wait(driver, 1000);
            Assert.AreEqual(value, paramvalue, "Verfied the parameter value not changed");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Make sure that parameter '(.*)'changes to '(.*)'")]
        public void ThenMakeSureThatParameterChangesTo(string parameter, string value)
        {
            simulator.MinimizeModbus();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Window(parentHandle);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkParameters);
            Waits.Wait(driver, 1000);
            if (modbusTestPage == null)
                modbusTestPage = new ModbusTestPage(driver);
            string paramvalue = modbusTestPage.LblBPPowervalue.Text;
            Waits.Wait(driver, 1000);
            Assert.AreEqual(value, paramvalue, "Verfied the parameter value not changed");
            Waits.Wait(driver, 1000);
        }

        [Then(@"The device running status should go to '(.*)'")]
        public void ThenTheDeviceRunningStatusShouldGoTo(string status)
        {
            simulator.MinimizeModbus();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Window(parentHandle);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.TabOverview);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblStatus, status));
        }

        [Then(@"A warning '(.*)' should be raised on parameter '(.*)'")]
        public void ThenAWarningShouldBeRaisedOnParameter(string warningParameter, string reflectedParameter)
        {
            simulator.MinimizeModbus();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Window(parentHandle);
            if (modbusTestPage == null)
                modbusTestPage = new ModbusTestPage(driver);
            Waits.WaitAndClick(driver, modbusTestPage.LblWarningCount);
            Waits.Wait(driver, 1000);
            if (liveAlertsListPage == null)
                liveAlertsListPage = new LiveAlertsListPage(driver);
            liveAlertsListPage.ClickNewlyCreatedAlert();
            Waits.WaitForElementVisible(driver, modbusTestPage.LblAlertDetailsMsg);
            modbusTestPage.LblAlertDetailsMsg.Text.Contains(warningParameter);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(modbusTestPage.LblhypParameter.Text.Contains(reflectedParameter), "Verified warning should not be raised a reflected parameter");
            Waits.WaitAndClick(driver, modbusTestPage.BtnClose);
        }

        [Then(@"One alarm '(.*)' on parameter '(.*)' should be raised")]
        public void ThenOneAlarmOnParameterShouldBeRaised(string alarmParameter, string reflectedParameter)
        {
            simulator.MinimizeModbus();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Window(parentHandle);
            if (liveAlertsListPage == null)
                liveAlertsListPage = new LiveAlertsListPage(driver);
            liveAlertsListPage.LnkHome.Click();
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnDeviceExplorer();
            if (modbusTestPage == null)
                modbusTestPage = new ModbusTestPage(driver);
            Waits.WaitAndClick(driver, modbusTestPage.LblAlarmCount);
            Waits.Wait(driver, 1000);
            if (liveAlertsListPage == null)
                liveAlertsListPage = new LiveAlertsListPage(driver);
            liveAlertsListPage.ClickNewlyCreatedAlert();
            Waits.WaitForElementVisible(driver, modbusTestPage.LblAlertDetailsMsg);
            Waits.Wait(driver, 1000);
            modbusTestPage.LblAlertDetailsMsg.Text.Contains(alarmParameter);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(modbusTestPage.LblhypParameter.Text.Contains(reflectedParameter), "Verified alarm should not be raised a reflected parameter");
            Waits.WaitAndClick(driver, modbusTestPage.BtnClose);
        }

        [When(@"Change the '(.*)' '(.*)' and '(.*)' to '(.*)'")]
        public void WhenChangeTheAndTo(string registerType, string address1, string address2, string value)
        {
            simulator.RestoreModbus();
            simulator.ChangeRegisterValue(registerType, address1, value);
            Waits.Wait(driver, 1000);
            simulator.ChangeRegisterValue(registerType, address2, value);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The warning and alarm alerts should clear")]
        public void ThenTheWarningAndAlarmAlertsShouldClear()
        {
            simulator.MinimizeModbus();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Window(parentHandle);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkHome);
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkDeviceExplorer);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblWarningCount, "0"), "Verified The warning alerts should not clear");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblAlarmCount, "0"), "Verified The Alarm alerts should not clear");
            Waits.Wait(driver, 1000);
        }

        [When(@"In the Modbus simulator, uncheck the box `FC (.*) \(Read Holding Registers\)`")]
        public void WhenInTheModbusSimulatorUncheckTheBoxFCReadHoldingRegisters(int p0)
        {
            simulator.RestoreModbus();
            simulator.UnCheckFunctionCodecheckbox();
        }

        [Then(@"This should cease communication between the agent and simulator,device should go to '(.*)'")]
        public void ThenThisShouldCeaseCommunicationBetweenTheAgentAndSimulatorDeviceShouldGoTo(string status)
        {
            simulator.MinimizeModbus();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Window(parentHandle);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.TabOverview);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblStatus, status));
        }

        [When(@"Re-check the `FC (.*)` checkbox")]
        public void WhenRe_CheckTheFCCheckbox(int p0)
        {
            simulator.RestoreModbus();
            simulator.CheckFunctionCodecheckbox();
            Waits.Wait(driver, 1000);
        }

        [Then(@"Communication should be re-established '(.*)'\.")]
        public void ThenCommunicationShouldBeRe_Established_(string status)
        {
            simulator.MinimizeModbus();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Window(parentHandle);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.TabOverview);
            deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblStatus, status);
            Waits.Wait(driver, 1000);
            simulator.RestoreModbus();
            Waits.Wait(driver, 1000);
            simulator.KillProcess();
            Waits.Wait(driver, 1000);
        }

        [When(@"I Create a new profile as '(.*)' and equipment type as '(.*)'")]
        public void WhenICreateANewProfileAsAndEquipmentTypeAs(string profileName, string deviceType)
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkHomePage);
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnConfiguration();
            homePage.ClickOnLogging();
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            loggingPage.ClickOnCreateProfileOption();
            Waits.WaitForElementVisible(driver, loggingPage.BtnCreateProfile);
            loggingPage.CreateProfile(profileName, deviceType);
            Waits.Wait(driver, 1000);
        }
        
        [Then(@"Some analogue parameters such as BP Power Pump N(.*) Flow BP Status")]
        public void ThenSomeAnalogueParametersSuchAsBPPowerPumpNFlowBPStatus(int p0)
        {
            if (modbusTestPage == null)
                modbusTestPage = new ModbusTestPage(driver);
            bool res = Waits.WaitForElementVisible(driver, modbusTestPage.LblBPPower);
            Assert.IsTrue(res, "Verified BP Power parameter is not displayed");
            res = Waits.WaitForElementVisible(driver, modbusTestPage.LblPumpN2Flow);
            Assert.IsTrue(res, "Verified Pump N2 Flow parameter is not displayed");
            res = Waits.WaitForElementVisible(driver, modbusTestPage.LblBPStatus);
            Assert.IsTrue(res, "Verified BP Status parameter is not displayed");
            Waits.Wait(driver, 1000);
        }

        [Then(@"The warning should clear")]
        public void ThenTheWarningShouldClear()
        {
            simulator.MinimizeModbus();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Window(parentHandle);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkHome);
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkDeviceExplorer);
            Waits.Wait(driver, 1000);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblWarningCount, "0"), "Verified The warning alerts should not clear");
            Waits.Wait(driver, 1000);
        }

        [Then(@"The alarm alerts should clear")]
        public void ThenTheAlarmAlertsShouldClear()
        {
            simulator.MinimizeModbus();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Window(parentHandle);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkHome);
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkDeviceExplorer);
            Waits.Wait(driver, 1000);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblAlarmCount, "0"), "Verified The Alarm alerts should not clear");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Change to '(.*)' '(.*)' to '(.*)'")]
        public void ThenChangeToTo(string registerType, string address, string value)
        {
            simulator.RestoreModbus();
            Waits.Wait(driver, 1000);
            simulator.SelectInputRegisterTab();
            simulator.ChangeRegisterValue(registerType, address, value);
            Waits.Wait(driver, 2000);
            simulator.MinimizeModbus();
            Waits.Wait(driver, 1000);
        }

        [Then(@"Make sure some data comes through\. Some digital outs, and analogue parameters")]
        public void ThenMakeSureSomeDataComesThrough_SomeDigitalOutsAndAnalogueParameters()
        {
            if (modbusTestPage == null)
                modbusTestPage = new ModbusTestPage(driver);
            bool res = Waits.WaitForElementVisible(driver, modbusTestPage.LblSoftwareVersion);
            Assert.IsTrue(res, "Verified Software Version parameter is not displayed");
            res = Waits.WaitForElementVisible(driver, modbusTestPage.LblHeartbeatCounter);
            Assert.IsTrue(res, "Verified Heartbeat Counter parameter is not displayed");
        }

        [When(@"Add needed parameter '(.*)' '(.*)' Before changing the Input register")]
        public void WhenAddNeededParameterBeforeChangingTheInputRegister(string parameter1, string parameter2)
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnConfiguration();
            if (modbusTestPage == null)
                modbusTestPage = new ModbusTestPage(driver);
            modbusTestPage.ClickOnEdwardsIOControllerSettings();
            modbusTestPage.ClickOnSystemfromList(equipmentName);
            Waits.Wait(driver, 1000);
            modbusTestPage.ParameterSelection(parameter1, GlobalConstants.DigitalParameterOverrideDescription);
            modbusTestPage.ParameterSelection(parameter2, GlobalConstants.AnalogueParameterOverrideDescription);
        }

        [Then(@"Make sure the parameter '(.*)' changes to '(.*)'")]
        public void ThenMakeSureTheParameterChangesTo(string parameter, string value)
        {
            simulator.MinimizeModbus();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Window(parentHandle);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkHomePage);
            Waits.Wait(driver, 1000);
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnDeviceExplorer();
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkParameters);
            if (modbusTestPage == null)
                modbusTestPage = new ModbusTestPage(driver);
            Waits.Wait(driver, 5000);
            string paramvalue = modbusTestPage.LblAnalogueInputValue.Text;
            Assert.AreEqual(value, paramvalue, "Verfied the parameter value not changed");
        }

        [When(@"In the Modbus simulator, uncheck the boxes activate FC checkboxes")]
        public void WhenInTheModbusSimulatorUncheckTheBoxesActivateFCCheckboxes()
        {
            simulator.RestoreModbus();
            Waits.Wait(driver, 1000);
            simulator.UncheckActivateFuctionalCheckboxes();
        }

        [When(@"Re-check the FC checkboxes")]
        public void WhenRe_CheckTheFCCheckboxes()
        {
            simulator.RestoreModbus();
            Waits.Wait(driver, 1000);
            simulator.RecheckActivateFuctionalCheckboxes();
        }

        [When(@"Finally, create a logging profile for an Edwards IO Controller, logging parameters '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'\.Then Click Apply\.")]
        public void WhenFinallyCreateALoggingProfileForAnEdwardsIOControllerLoggingParameters_ThenClickApply_(string Parameter, string TimeintervalforNormal, string TimeintervalforAlert, string TimeintervalforDelta, string Parameter1, string TimeintervalforNormal1, string TimeintervalforAlert1, string TimeintervalforDelta1, string Parameter2, string TimeintervalforNormal2, string TimeintervalforAlert2, string TimeintervalforDelta2)
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
        }

        [When(@"Now go to the parameters tab, and scroll down to '(.*)'\. Click the checkbox")]
        public void WhenNowGoToTheParametersTabAndScrollDownTo_ClickTheCheckbox(string parameter)
        {
            if (edwardsIOControllerPage == null)
                edwardsIOControllerPage = new EdwardsIOControllerPage(driver);
            edwardsIOControllerPage.SelectParametersCheckBoxes(parameter);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Edit textbox appears")]
        public void ThenEditTextboxAppears()
        {
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, edwardsIOControllerPage.TxtOverrideParameterName1), "Verified Edit textbox not appears ");
            Waits.Wait(driver, 1000);
        }

        [When(@"Enter '(.*)' as the name")]
        public void WhenEnterAsTheName(string customsDescription)
        {
            ElementExtensions.EnterTextValue(edwardsIOControllerPage.TxtOverrideParameterName1, customsDescription);
            Waits.Wait(driver, 1000);
        }

        [When(@"scroll down to '(.*)'\. Click the checkbox")]
        public void WhenScrollDownTo_ClickTheCheckbox(string parameter)
        {
            edwardsIOControllerPage.SelectParametersCheckBoxes(parameter);
            Waits.Wait(driver, 1000);
        }

        [When(@"I Enter '(.*)' as the name")]
        public void WhenIEnterAsTheName(string customsDescription)
        {
            ElementExtensions.EnterTextValue(edwardsIOControllerPage.TxtOverrideParameterName2, customsDescription);
            Waits.Wait(driver, 1000);
        }

        [When(@"Click Apply")]
        public void WhenClickApply()
        {
            edwardsIOControllerPage.ClickOnApply();
            Waits.Wait(driver, 1000);
        }

        [Then(@"Parameter'(.*)' renames '(.*)' are applied")]
        public void ThenParameterRenamesAreApplied(string parameter, string rename)
        {
            edwardsIOControllerPage.SelectParametersCheckBoxes(parameter);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.TxtOverrideParameterName1.GetAttribute("value").Contains(rename), "Verified parameter rename not applied");
            Waits.Wait(driver, 1000);
        }

        [When(@"move to the alerts tab")]
        public void WhenMoveToTheAlertsTab()
        {
            Waits.WaitAndClick(driver, edwardsIOControllerPage.TabAlerts);
            Waits.Wait(driver, 2000);
        }

        [Then(@"Alert tab opens")]
        public void ThenAlertTabOpens()
        {
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, edwardsIOControllerPage.DdlAlertParameter), "Verified Alert tab not opens ");
            Waits.Wait(driver, 1000);
        }

        [When(@"the dropdown list select Click the Add button at the end of the row")]
        public void WhenTheDropdownListSelectClickTheAddButtonAtTheEndOfTheRow(Table table)
        {
            Waits.Wait(driver, 2000);
            edwardsIOControllerPage.AlertCreation(table.Rows[0]["Parameter"], table.Rows[0]["Alert"], table.Rows[0]["AlertMessage"]);
        }

        [Then(@"Alert is added to the profile")]
        public void ThenAlertIsAddedToTheProfile(Table table)
        {
            Assert.IsTrue(edwardsIOControllerPage.Alertlistverification(table.Rows[0]["Parameter"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.Alertlistverification(table.Rows[0]["Alert"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.Alertlistverification(table.Rows[0]["AlertMessage"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
        }

        [When(@"Now move to the assignments tab")]
        public void WhenNowMoveToTheAssignmentsTab()
        {
            Waits.WaitAndClick(driver, edwardsIOControllerPage.TabAssignments);
            Waits.Wait(driver, 2000);
        }

        [Then(@"Assignments tab opens")]
        public void ThenAssignmentsTabOpens()
        {
            Waits.WaitForElementVisible(driver, edwardsIOControllerPage.BtnGetSystems);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, edwardsIOControllerPage.BtnGetSystems), "Verified Assignments tab not open");
        }

        [When(@"Click find equipment, and select the IO Controller you are using in this test\. Select the device in the left hand pane, and click the > button to move it to the right pane\. Click Apply")]
        public void WhenClickFindEquipmentAndSelectTheIOControllerYouAreUsingInThisTest_SelectTheDeviceInTheLeftHandPaneAndClickTheButtonToMoveItToTheRightPane_ClickApply()
        {
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            Waits.Wait(driver, 1000);
            loggingPage.SelectSingleEquipmentAndMoveToAssign(equipmentName);
        }

        [Then(@"No errors are shown\. Wait a minute or so for the profile to apply to the equipment")]
        public void ThenNoErrorsAreShown_WaitAMinuteOrSoForTheProfileToApplyToTheEquipment()
        {
            if (edwardsIOControllerPage == null)
                edwardsIOControllerPage = new EdwardsIOControllerPage(driver);
            Waits.WaitForElementVisible(driver, edwardsIOControllerPage.LblFeedback);
            Assert.IsTrue(edwardsIOControllerPage.LblFeedback.Text.Contains(GlobalConstants.ChangesApplied), "Verifying 'Changes have been applied' message will not be displayed on the screen");
        }

        [When(@"Now, in the Modbus simulator application, on the left hand pane, select Coils and scroll down to register '(.*)'\.")]
        public void WhenNowInTheModbusSimulatorApplicationOnTheLeftHandPaneSelectCoilsAndScrollDownToRegister_(string address)
        {
            simulator.RestoreModbus();
            simulator.SelectCoilsTab();
            simulator.MovetoAddress(address);
            Waits.Wait(driver, 1000);
        }

        [When(@"Double click on the red False text, to change it to green True")]
        public void WhenDoubleClickOnTheRedFalseTextToChangeItToGreenTrue()
        {
            simulator.ChangeValue();
            Waits.Wait(driver, 1000);
        }

        [When(@"Go to live alerts list, and open the alert just raised")]
        public void WhenGoToLiveAlertsListAndOpenTheAlertJustRaised()
        {
            simulator.MinimizeModbus();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Window(parentHandle);
            if (modbusTestPage == null)
                modbusTestPage = new ModbusTestPage(driver);
            Waits.WaitAndClick(driver, modbusTestPage.LblAlarmCount);
            Waits.Wait(driver, 1000);
            if (liveAlertsListPage == null)
                liveAlertsListPage = new LiveAlertsListPage(driver);
            liveAlertsListPage.ClickNewlyCreatedAlert();
        }

        [Then(@"You can see a red alarm with message '(.*)' on parameter")]
        public void ThenYouCanSeeARedAlarmWithMessageOnParameter(string message)
        {
            Waits.WaitForElementVisible(driver, modbusTestPage.LblAlertDetailsMsg);
            //modbusTestPage.LblAlertDetailsMsg.Text.Contains(warningParameter);
            //Waits.Wait(driver, 1000);
            Assert.IsTrue(modbusTestPage.LblhypParameter.Text.Contains(message), "Verified warning should not be raised a reflected parameter");
            Waits.WaitAndClick(driver, modbusTestPage.BtnClose);
        }

        [When(@"Back to the Modbus simulator application, on the left hand pane, select Coils and scroll down to register '(.*)'\.")]
        public void WhenBackToTheModbusSimulatorApplicationOnTheLeftHandPaneSelectCoilsAndScrollDownToRegister_(string address)
        {
            simulator.RestoreModbus();
            simulator.SelectCoilsTab();
            simulator.MovetoAddress(address);
            Waits.Wait(driver, 1000);
        }

        [When(@"Double click on the green True text, to change it to a red False\.")]
        public void WhenDoubleClickOnTheGreenTrueTextToChangeItToARedFalse_()
        {
            simulator.ChangeValue();
            Waits.Wait(driver, 1000);
        }

        [Then(@"the previous major alarm should be cleared\.")]
        public void ThenThePreviousMajorAlarmShouldBeCleared_()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblAlarmCount, "0"), "Verified The Alarm alerts should not clear");
            Waits.Wait(driver, 1000);
        }
    }
}
