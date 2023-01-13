using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class LiveAlertsListStepDefinition
    {
        private IWebDriver driver;
        HomePage homePage;
        LoginPage loginPage;
        LiveAlertsListPage liveAlertsListPage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        UserPage userPage;

        //Fields
        public readonly string myVar = Environment.NewLine;
        private string lastUpdated = string.Empty;
        private DateTime startDate = DateTime.Now;
        private DateTime fromDate = DateTime.Now;
        private DateTime endDate = DateTime.Now;
        string testFolderName = ElementExtensions.GetRandomString(4);

        Simulator simulator = new Simulator();
        string iPAdress = SpecflowHooks.HostIpAddress();

        //Constructor
        public LiveAlertsListStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            liveAlertsListPage = new LiveAlertsListPage(driver);
            userPage = new UserPage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
        }


        [Given(@"Raised alert High Alarm on Booster Power, Low alarm on MB Motor Temperature, High Warning on Dry Pump Control,low warning on  Booster Control, Advisory on Seals Purge")]
        public void GivenRaisedAlertHighAlarmOnBoosterPowerLowAlarmOnMBMotorTemperatureHighWarningOnDryPumpControlLowWarningOnBoosterControlAdvisoryOnSealsPurge()
        {
            simulator.RestoreWindow();
            simulator.StopSimulator();
            Thread.Sleep(1000);
            simulator.RaiseAllTypeOfAlerts();
            simulator.MinimizeSimulator();
        }
        [Given(@"I entered Equipment name, selected equipmentType'(.*)', Cliked Find Equipment button, selected one equipmentName'(.*)' and clicked Add button")]
        public void GivenIEnteredEquipmentNameSelectedEquipmentTypeClikedFindEquipmentButtonSelectedOneEquipmentNameAndClickedAddButton(string equipmentType, string equipmentName)
        {
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.AddEquipmentToSystem(equipmentType, equipmentName);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnOK);
            Waits.Wait(driver, 2000);
        }

        [When(@"Navigated to Home page")]
        public void GivenNavigatedToHomePage()
        {
            Waits.Wait(driver, 5000);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkHomePage);
            Waits.Wait(driver, 3000);
        }            

        [When(@"Selected Live Alerts List")]
        public void WhenSelectedLiveAlertsList()
        {            
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkLiveAlerts);
            if (liveAlertsListPage == null)
                liveAlertsListPage = new LiveAlertsListPage(driver);
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkActive);
        }

        [Given(@"Navigated to Live Alerts page")]
        public void GivenNavigatedToLiveAlertsPage()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkRealTimeMonitoring);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkLiveAlertsList);
            Waits.Wait(driver, 8000);
        }


        [Then(@"current live alerts should be shown")]
        public void ThenCurrentLiveAlertsShouldBeShown()
        {
            Waits.Wait(driver, 30000);
            Assert.IsTrue(liveAlertsListPage.IsAllAlertsRaised("Seals Purge (13)", "Booster Power (8)", "MB MotorTemperature (9)", "Dry Pump Control (11)", "Booster Control (12)", "NEW0001PM1"));
        }

        [Then(@"Symbols should be enabled")]
        public void ThenSymbolsShouldBeEnabled()
        {
            Assert.IsTrue(liveAlertsListPage.LnkAlarmCount.Enabled, "Verified Alarm symbol not eneabled");
            Assert.IsTrue(liveAlertsListPage.LnkWarningCount.Enabled, "Verified Warning symbol not eneabled");
            Assert.IsTrue(liveAlertsListPage.LnkInfoCount.Enabled, "Verified Advisory symbol not eneabled");
        }

        [When(@"Commissioned device with following details  '(.*)', '(.*)'")]
        public void WhenCommissionedDeviceWithFollowingDetails(string equipmentType, string iPPortNumber)
        {
            if (liveAlertsListPage == null)
                liveAlertsListPage = new LiveAlertsListPage(driver);
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkHome);
            Waits.Wait(driver, 2000);
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkDeviceManager);
            Waits.Wait(driver, 2000);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkNavigate);
            deviceExplorerNavigationPage.LnkNavigate.Click();
            var tabs = driver.WindowHandles;
            if (tabs.Count > 1)
            {
                int totalCount = tabs.Count;

                driver.SwitchTo().Window(tabs[totalCount - 1]);
            }
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            deviceExplorerNavigationPage.LnkCreateCommission.Click();
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.TxtBoxEquipmentName);
            string equipmentName = ElementExtensions.GetRandomAlphabeticalString(6);
            ScenarioContext.Current.Add("EquipmentName", equipmentName);
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 8000);            
        }

        [When(@"Commissioned device with details  '(.*)', '(.*)'")]
        public void WhenCommissionedDeviceWithDetails(string equipmentType, string iPPortNumber)
        {            
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkNavigate);
            deviceExplorerNavigationPage.LnkNavigate.Click();
            var tabs = driver.WindowHandles;
            if (tabs.Count > 1)
            {
                int totalCount = tabs.Count;

                driver.SwitchTo().Window(tabs[totalCount - 1]);
            }
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkAddDevice);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            deviceExplorerNavigationPage.LnkCreateCommission.Click();
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.TxtBoxEquipmentName);
            string equipmentName = ElementExtensions.GetRandomAlphabeticalString(6);
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 8000);
        }


        [When(@"Raised alert on turbo equipment with alert codes '(.*)' & '(.*)' on port '(.*)' & '(.*)'")]
        public void GivenRaisedAlertOnTurboEquipmentWithAlertCodesOnPort(string alertCodeMotorHeat, string alertCodeCntHeat, string motorHeatPort, string cntHeatPort)
        {
            simulator.LaunchTurboWindow();
            Thread.Sleep(2000);
            simulator.RaiseEquipmentAlertTurbo(alertCodeMotorHeat, motorHeatPort);
            simulator.RaiseEquipmentAlertTurbo(alertCodeCntHeat, cntHeatPort);
            simulator.MinimizeSimulator();
        }

        [Given(@"Selected Live Alerts List")]
        public void GivenSelectedLiveAlertsList()
        {
            //JavaScriptExecutor.JavaScriptLinkClick(driver, homePage.LnkLiveAlerts);
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkLiveAlerts);
            if (liveAlertsListPage == null)
                liveAlertsListPage = new LiveAlertsListPage(driver);
            Waits.WaitForElementVisible(driver, liveAlertsListPage.BtnShowFilter);
        }

        [When(@"cleared all previous alerts")]
        public void WhenClearedAllPreviousAlerts()
        {
            Waits.Wait(driver, 2000);
            if (liveAlertsListPage == null)
                liveAlertsListPage = new LiveAlertsListPage(driver);
            var tabs = driver.WindowHandles;
            if (tabs.Count > 1)
            {
                int totalCount = tabs.Count;

                driver.SwitchTo().Window(tabs[totalCount - 1]);
            }
            liveAlertsListPage.ClosePreviousActiveAlerts();
            Waits.Wait(driver, 2000);
        }

        [When(@"Launched Eissa and started Simulator and selected device type '(.*)'")]
        public void WhenLaunchedEissaAndStartedSimulatorAndSelectedDeviceType(string deviceType)
        {
            if (liveAlertsListPage == null)
                liveAlertsListPage = new LiveAlertsListPage(driver);            
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkHome);
            Waits.Wait(driver, 2000);
            if (homePage == null)
                homePage = new HomePage(driver);

            Waits.WaitAndClick(driver, homePage.LnkDeviceManager);
            Waits.Wait(driver, 2000);
            simulator.LaunchSimulator();
            simulator.SelectEquipment(deviceType);
            simulator.MinimizeWindow();
            Waits.Wait(driver, 2000);
        }


        [When(@"navigated to Home page")]
        public void WhenNavigatedToHomePage()
        {
            if (liveAlertsListPage == null)
                liveAlertsListPage = new LiveAlertsListPage(driver);
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkHome);
        }

        [When(@"Clicked the Show Filter button\.")]
        public void WhenClickedTheShowFilterButton_()
        {
            try
            {
                Waits.Wait(driver, 5000);
                Waits.WaitAndClick(driver, liveAlertsListPage.BtnShowFilter);
            }
            catch(TargetInvocationException)
            {
                WhenClickedTheShowFilterButton_();
            }
        }

        [When(@"Clicked and Hide Filter button")]
        public void WhenClickedAndHideFilterButton()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnHideFilter);
        }

        [When(@"In the filter, disable all of the ‘Maintenance Status’ checkboxes \(apart from Closed which toggles with Unacknowledged\)")]
        public void WhenInTheFilterDisableAllOfTheMaintenanceStatusCheckboxesApartFromClosedWhichTogglesWithUnacknowledged()
        {
            JavaScriptExecutor.JavaScriptLinkClick(driver, liveAlertsListPage.BtnHideFilter);
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnShowFilter);
            if (liveAlertsListPage.ChkBoxUnacknowledged.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxUnacknowledged);
            }
            if (liveAlertsListPage.ChkBoxAcknowledged.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxAcknowledged);
            }
            if (liveAlertsListPage.ChkBoxAssigned.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxAssigned);
            }
            if (liveAlertsListPage.ChkBoxWorkInProgress.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxWorkInProgress);
            }
            if (liveAlertsListPage.ChkBoxPending.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxPending);
            }
            if (liveAlertsListPage.ChkBoxClosed.GetAttribute("src").Contains("chk_off"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxClosed);
            }
        }

        [When(@"set an alert to Closed clicked the alert in the main view")]
        public void WhenSetAnAlertToClosedClickedTheAlertInTheMainView()
        {
            Waits.Wait(driver, 2000);
            liveAlertsListPage.ClickNewlyCreatedAlert();
        }

        [When(@"clicked Apply button\.")]
        public void WhenClickedApplyButton_()
        {
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnApply);
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnClose);
            Waits.Wait(driver, 5000);
        }


        [When(@"clicked maintenance status drop down, selected '(.*)'")]
        public void WhenClickedMaintenanceStatusDropDownSelected(string maintenanceStatus)
        {
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, liveAlertsListPage.LblSeverityValue);
            ElementExtensions.SelectByText(liveAlertsListPage.DrpDwnMaintenanceStatus, maintenanceStatus);
        }

        [When(@"count displayed is greater than '(.*)'")]
        public void WhenCountDisplayedIsGreaterThan(int number)
        {
            Assert.IsTrue(liveAlertsListPage.GetAlertsNumber() > number, "Alert count is not greater than 0");
        }

        [When(@"clicked on the Alarm Symbol in top right corner\.\(Assuming there are alerts of type Alarm present and Sysmbol is enabled\)")]
        public void WhenClickedOnTheAlarmSysmbolInTopRightCorner_AssumingThereAreAlertsOfTypeAlarmPresentAndSysmbolIsEnabled()
        {          
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkAlarmCount);
        }

        [Then(@"Live Alerts list screen should appear with all Major and Minor Alarm ie '(.*)'")]
        public void ThenLiveAlertsListScreenShouldAppearWithAllMajorAndMinorAlarmIe(int count)
        {
            bool flag = false;
            for (int i = 1; i <= 25; i++)
            {
                if(liveAlertsListPage.GetAlertsNumber().Equals(count))
                {
                    flag = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            Assert.IsTrue(flag, "Major and minor alarm not displayed on Alarm screen");
        }

        [Then(@"Alerts Level filter set to Major Alarm and Minor Alarm\.")]
        public void ThenAlertsLevelFilterSetToMajorAlarmAndMinorAlarm_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnShowFilter);
            Waits.Wait(driver, 2000);
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxMinorAlarm, "chk_on"), "Minor alarm checkbox not checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxMajorAlarm, "chk_on"), "Major alarm checkbox not checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkboxMajorWarning, "chk_off"), "Major Warning checkbox checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxMinorWarning, "chk_off"), "Minor Warning checkbox checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxAdvisory, "chk_off"), "Advisory checkbox checked");
        }

  
        [When(@"Clicked on the Warning Symbol in top right corner\.\(Assuming there are alerts of type Warning present and Sysmbol is enabled\)")]
        public void WhenClickedOnTheWarningSymbolInTopRightCorner_AssumingThereAreAlertsOfTypeWarningPresentAndSysmbolIsEnabled()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkWarningCount);
        }

        [Then(@"Live Alerts list screen should appear with total count i\.e\. '(.*)'")]
        public void ThenLiveAlertsListScreenShouldAppearWithTotalCountI_E_(int count)
        {
            bool flag = false;
            for (int i = 1; i <= 25; i++)
            {
                if (liveAlertsListPage.GetAlertsNumber().Equals(count))
                {
                    flag = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            Assert.IsTrue(flag, "Major and minor warning not diplayed on warning screen");
        }

        [Then(@"Alert Level filter set to Major Warning and Minor Warning\.")]
        public void ThenAlertLevelFilterSetToMajorWarningAndMinorWarning_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnShowFilter);
            Assert.IsTrue(liveAlertsListPage.ChkboxMajorWarning.GetAttribute("src").Contains("chk_on"), "Major Warning checkbox not checked");
            Assert.IsTrue(liveAlertsListPage.ChkBoxMinorWarning.GetAttribute("src").Contains("chk_on"), "Minor Warning checkbox not checked");
            Assert.IsTrue(liveAlertsListPage.ChkBoxMinorAlarm.GetAttribute("src").Contains("chk_off"), "Minor alarm checkbox checked");
            Assert.IsTrue(liveAlertsListPage.ChkBoxMajorAlarm.GetAttribute("src").Contains("chk_off"), "Major alarm checkbox checked");
            Assert.IsTrue(liveAlertsListPage.ChkBoxAdvisory.GetAttribute("src").Contains("chk_off"), "Advisory checkbox checked");
        }

        [When(@"Clicked on the Advisory Symbol in top right corner")]
        public void WhenClickedOnTheAdvisorySymbolInTopRightCorner()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkInfoCount);
        }

        [Then(@"The Live Alerts list should display the Advisory ie\.'(.*)'")]
        public void ThenTheLiveAlertsListShouldDisplayTheAdvisoryIe_(int count)
        {
            bool flag = false;
            for (int i = 1; i <= 25; i++)
            {
                if (liveAlertsListPage.GetAlertsNumber().Equals(count))
                {
                    flag = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            Assert.IsTrue(flag, "Major and minor warning not diplayed on warning screen");

        }

        [Then(@"Alert Level filter set to Advisory")]
        public void ThenAlertLevelFilterSetToAdvisory()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnShowFilter);
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxAdvisory, "chk_on"), "Advisory checkbox not checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkboxMajorWarning, "chk_off"), "Major Warning checkbox checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxMinorWarning, "chk_off"), "Minor Warning checkbox checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxMinorAlarm, "chk_off"), "Minor alarm checkbox checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxMajorAlarm, "chk_off"), "Major alarm checkbox checked");
        }


        [Then(@"The filter section should pop-up showing several fields that can be used to search for a particular alert\.")]
        public void ThenTheFilterSectionShouldPop_UpShowingSeveralFieldsThatCanBeUsedToSearchForAParticularAlert_()
        {
            Assert.IsTrue(liveAlertsListPage.ChkBoxAdvisory.Displayed, "Advisory checkbx is not displayed to filter alerts");
            Assert.IsTrue(liveAlertsListPage.ChkBoxMajorAlarm.Displayed, "Major alarm checkbx is not displayed to filter alerts");
            Assert.IsTrue(liveAlertsListPage.ChkboxMajorWarning.Displayed, "Major warning checkbx is not displayed to filter alerts");
            Assert.IsTrue(liveAlertsListPage.ChkBoxMinorAlarm.Displayed, "Minor alarm checkbx is not displayed to filter alerts");
            Assert.IsTrue(liveAlertsListPage.ChkBoxMinorWarning.Displayed, "Minor warning checkbx is not displayed to filter alerts");
        }

        [When(@"Deselected all the Alert Source checkboxes\.")]
        public void WhenDeselectedAllTheAlertSourceCheckboxes_()
        {
            Waits.Wait(driver, 6000);
            if (liveAlertsListPage.ChkBoxEquipment.GetAttribute("src").Contains("chk_on"))
            {
                Waits.Wait(driver, 2000);
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxEquipment);
                Waits.Wait(driver, 2000);
                //if (liveAlertsListPage.ChkBoxEquipment.GetAttribute("src").Contains("chk_on"))
                //{
                //    Waits.Wait(driver, 1000);
                //    Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxEquipment);
                //}
            }
            if (liveAlertsListPage.ChkBoxPdM.GetAttribute("src").Contains("chk_on"))
            {
                Waits.Wait(driver, 2000);
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxPdM);
                Waits.Wait(driver, 2000);
                //if (liveAlertsListPage.ChkBoxPdM.GetAttribute("src").Contains("chk_on"))
                //{
                //    Waits.Wait(driver, 1000);
                //    Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxPdM);
                //}
            }
            if (liveAlertsListPage.ChkBoxPTM.GetAttribute("src").Contains("chk_on"))
            {
                Waits.Wait(driver, 2000);
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxPTM);
                Waits.Wait(driver, 2000);
                //if (liveAlertsListPage.ChkBoxPTM.GetAttribute("src").Contains("chk_on"))
                //{
                //    Waits.Wait(driver, 1000);
                //    Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxPTM);
                //}
            }
            if (liveAlertsListPage.ChkBoxNetwork.GetAttribute("src").Contains("chk_on"))
            {
                Waits.Wait(driver, 2000);
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxNetwork);
                Waits.Wait(driver, 2000);
                //if (liveAlertsListPage.ChkBoxNetwork.GetAttribute("src").Contains("chk_on"))
                //{
                //    Waits.Wait(driver, 1000);
                //    Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxNetwork);
                //}
            }
            if (liveAlertsListPage.ChkBoxSysHealthMonitor.GetAttribute("src").Contains("chk_on"))
            {
                Waits.Wait(driver, 2000);
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxSysHealthMonitor);
                Waits.Wait(driver, 2000);
                //if (liveAlertsListPage.ChkBoxSysHealthMonitor.GetAttribute("src").Contains("chk_on"))
                //{
                //    Waits.Wait(driver, 1000);
                //    Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxSysHealthMonitor);
                //}
            }
            if (liveAlertsListPage.ChkBoxStatusMonitor.GetAttribute("src").Contains("chk_on"))
            {
                Waits.Wait(driver, 2000);
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxStatusMonitor);
                Waits.Wait(driver, 2000);
            }
            if (liveAlertsListPage.ChkBoxManuallyCreated.GetAttribute("src").Contains("chk_on"))
            {
                Waits.Wait(driver, 2000);
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxManuallyCreated);
                Waits.Wait(driver, 2000);
                //if (liveAlertsListPage.ChkBoxStatusMonitor.GetAttribute("src").Contains("chk_on"))
                //{
                //    Waits.Wait(driver, 1000);
                //    Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxManuallyCreated);
                //}
            }
        }

        [Then(@"All checkboxes cleared\.")]
        public void ThenAllCheckboxesCleared_()
        {
            Waits.WaitForElementVisible(driver, liveAlertsListPage.ChkBoxEquipment);
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxEquipment, "chk_off"), "Equipment checkbox is coming checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxPdM, "chk_off"), "PdM checkbox is coming checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxPTM, "chk_off"), "PTM checkbox is coming checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxNetwork, "chk_off"), "Network checkbox is coming checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxSysHealthMonitor, "chk_off"), "Sys Health Monitor checkbox is checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxStatusMonitor, "chk_off"), "Status Monitor checkbox is checked");
            Assert.IsTrue(ElementExtensions.VerifyAttributeSRCValue(driver, liveAlertsListPage.ChkBoxManuallyCreated, "chk_off"), "Manually created checkbox is checked");
        }

        [Then(@"Only Alerts with the selected source should be displayed\.")]
        public void ThenOnlyAlertsWithTheSelectedSourceShouldBeDisplayed_()
        {
            Assert.IsTrue(liveAlertsListPage.CheckSystemAlerts("NEW0001PM1"), "Active alerts are not shown");
        }

        [When(@"Selected Equipment checkbox")]
        public void WhenSelectedEquipmentCheckbox()
        {
            if (liveAlertsListPage.ChkBoxEquipment.GetAttribute("src").Contains("chk_off"))
            {
                Waits.Wait(driver, 1000);
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxEquipment);
                if (liveAlertsListPage.ChkBoxEquipment.GetAttribute("src").Contains("chk_off"))
                {
                    Waits.Wait(driver, 1000);
                    Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxEquipment);
                }
            }
            if (liveAlertsListPage.ChkBoxPdM.GetAttribute("src").Contains("chk_on"))
            {
                Waits.Wait(driver, 1000);
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxPdM);
                if (liveAlertsListPage.ChkBoxPdM.GetAttribute("src").Contains("chk_on"))
                {
                    Waits.Wait(driver, 1000);
                    Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxPdM);
                }
            }
            if (liveAlertsListPage.ChkBoxPTM.GetAttribute("src").Contains("chk_on"))
            {
                Waits.Wait(driver, 1000);
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxPTM);
                if (liveAlertsListPage.ChkBoxPTM.GetAttribute("src").Contains("chk_on"))
                {
                    Waits.Wait(driver, 1000);
                    Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxPTM);
                }
            }
            if (liveAlertsListPage.ChkBoxNetwork.GetAttribute("src").Contains("chk_on"))
            {
                Waits.Wait(driver, 1000);
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxNetwork);
                if (liveAlertsListPage.ChkBoxNetwork.GetAttribute("src").Contains("chk_on"))
                {
                    Waits.Wait(driver, 1000);
                    Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxNetwork);
                }
            }
            Waits.Wait(driver, 3000);
            if (liveAlertsListPage.ChkBoxSysHealthMonitor.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxSysHealthMonitor);
                Waits.Wait(driver, 1000);
                if (liveAlertsListPage.ChkBoxSysHealthMonitor.GetAttribute("src").Contains("chk_on"))
                {
                    Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxSysHealthMonitor);
                }
            }
            if (liveAlertsListPage.ChkBoxStatusMonitor.GetAttribute("src").Contains("chk_on"))
            {
                Waits.Wait(driver, 1000);
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxStatusMonitor);
                if (liveAlertsListPage.ChkBoxStatusMonitor.GetAttribute("src").Contains("chk_on"))
                {
                    Waits.Wait(driver, 1000);
                    Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxStatusMonitor);
                }
            }
            if (liveAlertsListPage.ChkBoxManuallyCreated.GetAttribute("src").Contains("chk_on"))
            {
                Waits.Wait(driver, 1000);
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxManuallyCreated);
                Waits.Wait(driver, 3000);
                if (liveAlertsListPage.ChkBoxManuallyCreated.GetAttribute("src").Contains("chk_on"))
                {
                    Waits.Wait(driver, 1000);
                    Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxManuallyCreated);
                }
            }
        }

        [When(@"Clicked the Create Alert button\.")]
        public void WhenClickedTheCreateAlertButton_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnCreateAlert);
        }

        [Then(@"A '(.*)' popup window should be displayed\.")]
        public void ThenAPopupWindowShouldBeDisplayed_(string popUpName)
        {
            Waits.Wait(driver, 5000);
            Waits.WaitForElementVisible(driver, liveAlertsListPage.TitleCreateAlertPopUp);
            Assert.IsTrue(liveAlertsListPage.TitleCreateAlertPopUp.Text.Contains("Create Alert"), "Create alert pop up has not opened");
        }

        [When(@"Changed the Assigned User box to a user in the system\.")]
        public void WhenChangedTheAssignedUserBoxToAUserInTheSystem_()
        {
            Waits.WaitForElementVisible(driver, liveAlertsListPage.DrpDwnAssignedUser);
            ElementExtensions.SelectByValue(liveAlertsListPage.DrpDwnAssignedUser, "1");
            Waits.WaitForElementVisible(driver, liveAlertsListPage.DrpDwnSeverity);
            ElementExtensions.SelectByValue(liveAlertsListPage.DrpDwnSeverity, "5");
        }

        [Then(@"The entry changes")]
        public void ThenTheEntryChanges()
        {
            liveAlertsListPage.DrpDwnAssignedUser.Text.Contains("administrator");
        }

        [When(@"Entered '(.*)' in the Default Alert Message textbox\.")]
        public void WhenEnteredInTheDefaultAlertMessageTextbox_(string msg)
        {
            liveAlertsListPage.TxtAreaMessage.Clear();
            liveAlertsListPage.TxtAreaMessage.SendKeys("");
            liveAlertsListPage.TxtAreaMessage.SendKeys(msg);
            ElementExtensions.SelectByText(liveAlertsListPage.DrpDwnSeverity, "Advisory");
        }

        [When(@"Clicked Create Alert button")]
        public void WhenClickedCreateAlertButton()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnCreateAlertPopUp);
        }

        [Then(@"The alert should be created '(.*)'")]
        public void ThenTheAlertShouldBeCreated(string successMsg)
        {
            Waits.Wait(driver, 5000);
            Waits.WaitForElementVisible(driver, liveAlertsListPage.InfoMessage);            
            Assert.IsTrue(liveAlertsListPage.InfoMessage.Text.Contains(successMsg), "Verified " + successMsg + " ");
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnClose);
            Waits.Wait(driver, 2000);
        }

        [Then(@"displayed in the View Alerts screen with message'(.*)' and Severity '(.*)'\.")]
        public void ThenDisplayedInTheViewAlertsScreenWithMessageAndSeverity_(string alertMessage, string alertType)
        {
            Waits.Wait(driver, 5000);
            Assert.IsTrue(liveAlertsListPage.IsCreatedAlertDisplayed(alertMessage, alertType), "Verified created alert is not displayed on alert screen");
        }

        [Then(@"The filter section should pop-up\.")]
        public void ThenTheFilterSectionShouldPop_Up_()
        {
            Waits.Wait(driver, 2000);
            bool res= Waits.WaitForElementVisible(driver, liveAlertsListPage.LblMaintenanceStatus);
            Assert.IsTrue(res, "Verified Maintenance Status label in filter pop-up");
        }

        [When(@"Selected the Assigned user drop down as the user '(.*)' you selected when created the test alert above\.")]
        public void WhenSelectedTheAssignedUserDropDownAsTheUserYouSelectedWhenCreatedTheTestAlertAbove_(string userName)
        {
            ElementExtensions.SelectByText(liveAlertsListPage.DrpDwnAssignedUserFilter, userName);
        }

        [When(@"Clicked Apply Filter")]
        public void WhenClickedApplyFilter()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnApplyFilter);
        }

        [Then(@"Appeared in the list '(.*)'\.")]
        public void ThenAppearedInTheList_(string alertMessage)
        {
            Assert.IsTrue(liveAlertsListPage.IsCreatedAlertDisplayed(alertMessage), "Verified created alert is not displayed on alert screen");
            Waits.Wait(driver, 3000);
        }

        [Then(@"The current Alerts screen should only show alerts for the user '(.*)' specified in the filter\.")]
        public void ThenTheCurrentAlertsScreenShouldOnlyShowAlertsForTheUserSpecifiedInTheFilter_(string user)
        {
            Waits.Wait(driver, 2000);
            liveAlertsListPage.IsAlertsDisplayedAssignedtoFilteredUser(user);
        }


        [When(@"Clicked the checkbox besides From and To Date\.")]
        public void WhenClickedTheCheckboxBesidesFromAndToDate_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxFilterDateRange);
        }

        [Then(@"Two date entry boxes will be enabled\.")]
        public void ThenTwoDateEntryBoxesWillBeEnabled_()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(liveAlertsListPage.TxtBoxFromDate.Enabled, "From Date textbox not enabled");
            Assert.IsTrue(liveAlertsListPage.TxtBoxToDate.Enabled, "To Date textbox not enabled");
            Waits.Wait(driver, 5000);
            Assert.IsTrue(liveAlertsListPage.TxtBoxFromDate.GetAttribute("value").Contains(DateTime.Today.ToString("yyyy/MM/dd")), "From Date textbox does not contains system date");
            Assert.IsTrue(liveAlertsListPage.TxtBoxToDate.GetAttribute("value").Contains(DateTime.Today.ToString("yyyy/MM/dd")), "To Date textbox does not contains system date");
        }

        [When(@"The dates can be entered by text input \(in the format yyyy-mm-dd\) or by using the date selection boxes next to the date text boxes\.")]
        public void WhenTheDatesCanBeEnteredByTextInputInTheFormatYyyy_Mm_DdOrByUsingTheDateSelectionBoxesNextToTheDateTextBoxes_()
        {
            liveAlertsListPage.TxtBoxFromDate.Clear();
            liveAlertsListPage.TxtBoxFromDate.SendKeys(DateTime.Now.Date.AddDays(-1).ToString("yyyy-MM-dd"));
            liveAlertsListPage.TxtBoxToDate.SendKeys(DateTime.Now.Date.AddDays(-1).ToString("yyyy-MM-dd"));
            Waits.Wait(driver, 2000);
            liveAlertsListPage.TxtBoxFromDate.Clear();
            Waits.Wait(driver, 2000);
            liveAlertsListPage.TxtBoxToDate.Clear();
        }

        [When(@"Clicked the calender button besides From date\.")]
        public void WhenClickedTheCalenderButtonBesidesFromDate_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.CalendarFromDate);
        }

        [Then(@"A datepicker calendar control will be displayed\.")]
        public void ThenADatepickerCalendarControlWillBeDisplayed_()
        {
            bool res= Waits.WaitForElementVisible(driver, liveAlertsListPage.CalendarFromDate);
            Assert.IsTrue(res, "Date picker calender not displayed");
        }

        [When(@"Selected a date from the popup calendar window by clicking on a day number\.")]
        public void WhenSelectedADateFromThePopupCalendarWindowByClickingOnADayNumber_()
        {
            //bool res = Waits.WaitForElementVisible(driver, liveAlertsListPage.CalendarFromDate);
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnPrevious);
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnNext);
            ElementExtensions.MouseHover(driver, liveAlertsListPage.LblFromDate);
            Waits.WaitAndClick(driver, liveAlertsListPage.LblFromDate);
        }

        [Then(@"The Start Date textbox is populated with the selected date from the calendar\.")]
        public void ThenTheStartDateTextboxIsPopulatedWithTheSelectedDateFromTheCalendar_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnApplyFilter);
            liveAlertsListPage.TxtBoxFromDate.GetAttribute("value").Contains("01");
            string date = liveAlertsListPage.TxtBoxFromDate.GetAttribute("value");
            startDate = Convert.ToDateTime(date);
        }

        [When(@"Selected End date from the popup calendar window by clicking on a day number\.")]
        public void WhenSelectedEndDateFromThePopupCalendarWindowByClickingOnADayNumber_()
        {
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnPrevious);
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnNext);
            Waits.Wait(driver, 2000);
            ElementExtensions.MouseHover(driver, liveAlertsListPage.LblToDate);
            Waits.WaitAndClick(driver, liveAlertsListPage.LblToDate);
        }

        [Then(@"The End Date textbox will be populated with selected end date\.")]
        public void ThenTheEndDateTextboxWillBePopulatedWithSelectedEndDate_()
        {
            liveAlertsListPage.BtnApplyFilter.Click();
            liveAlertsListPage.TxtBoxToDate.GetAttribute("value").Contains("30");
            string date = liveAlertsListPage.TxtBoxToDate.GetAttribute("value");
            endDate = Convert.ToDateTime(date);
        }

        [When(@"Clicked the calender button besides To date\.")]
        public void WhenClickedTheCalenderButtonBesidesToDate_()
        {
           Waits.WaitAndClick(driver, liveAlertsListPage.CalendarToDate);
        }

        [Then(@"Clicked Apply Filter Only events between the selected dates are shown in the Alerts screen\.")]
        public void WhenClickedApplyFilterOnlyEventsBetweenTheSelectedDatesAreShownInTheAlertsScreen_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxFilterDateRange);
            Waits.Wait(driver, 1000);
             Waits.WaitAndClick(driver, liveAlertsListPage.BtnApplyFilter);
            Assert.IsTrue(liveAlertsListPage.IsAlertFilteredByDate(startDate.Date, endDate.Date), "Date filter is not working correctly");

        }

        [Then(@"Filter pane displayed at top of View Alerts screen\.")]
        public void ThenFilterPaneDisplayedAtTopOfViewAlertsScreen_()
        {
            bool res= Waits.WaitForElementVisible(driver, liveAlertsListPage.LblMaintenanceStatus);
            Assert.IsTrue(res, "Verified Maintenance Status label in filter pop-up");
        }


        [When(@"In the Message text box, type part or the entire description of an alert '(.*)' that is visible in the list in the main window\.")]
        public void WhenInTheMessageTextBoxTypePartOrTheEntireDescriptionOfAnAlertThatIsVisibleInTheListInTheMainWindow_(string partialsMsg)
        {
            liveAlertsListPage.TxtBoxMessage.SendKeys(partialsMsg);
        }

        [Then(@"Only alerts with descriptions matching the string entered in the filter message '(.*)' field should be displayed\.")]
        public void ThenOnlyAlertsWithDescriptionsMatchingTheStringEnteredInTheFilterMessageFieldShouldBeDisplayed_(string partialsMsg)
        {
            Waits.Wait(driver, 8000);
            Assert.IsTrue(liveAlertsListPage.IsAlertFilteredByMessage(partialsMsg), "Verified message filter not working correctly");
        }

        [When(@"In the System Name text box, type part or the entire name of a device '(.*)' that is visible in the list of alerts in the main window\.")]
        public void WhenInTheSystemNameTextBoxTypePartOrTheEntireNameOfADeviceThatIsVisibleInTheListOfAlertsInTheMainWindow_(string equipmentName)
        {
            Waits.Wait(driver, 3000);
            liveAlertsListPage.TxtBoxSystemName.SendKeys(equipmentName);
        }

        [Then(@"The Current Alerts screen should only display alerts for the equipment '(.*)' identified by the System Name string in the filter specification\.")]
        public void ThenTheCurrentAlertsScreenShouldOnlyDisplayAlertsForTheEquipmentIdentifiedByTheSystemNameStringInTheFilterSpecification_(string systemName)
        {
            Waits.Wait(driver, 8000);
            liveAlertsListPage.CheckSystemAlerts(systemName);
        }

        [When(@"Changed the Maintenance status drop down to '(.*)'")]
        public void WhenChangedTheMaintenanceStatusDropDownTo(string maintenanceStatus)
        {
            ElementExtensions.SelectByText(liveAlertsListPage.DrpDwnMaintenanceStatusCreateAlert, maintenanceStatus);
        }

        [Then(@"Displayed in the View Alerts screen with message'(.*)'")]
        public void ThenDisplayedInTheViewAlertsScreenWithMessage(string msg)
        {
          Assert.IsTrue(liveAlertsListPage.IsCreatedAlertDisplayed(msg), "Created alert is not displaying");
            Waits.Wait(driver, 2000);
        }

        [When(@"Entered a search string in the Search '(.*)' box\.")]
        public void WhenEnteredASearchStringInTheSearchBox_(string equipmentName)
        {
            liveAlertsListPage.TxtBoxSearch.SendKeys(equipmentName);
        }

        [When(@"Use the drop down list also to select a type of equipment '(.*)'\. Make sure this type corresponds with the name you have entered in the first box\.")]
        public void WhenUseTheDropDownListAlsoToSelectATypeOfEquipment_MakeSureThisTypeCorrespondsWithTheNameYouHaveEnteredInTheFirstBox_(string equipmentType)
        {
            ElementExtensions.SelectByText(liveAlertsListPage.DrpDwnEquipmentType, equipmentType);
        }

        [When(@"Clicked Find Equipment button\.")]
        public void WhenClickedFindEquipmentButton_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnFindEquipment);
            Waits.Wait(driver, 2000);
        }

        [Then(@"A list of results is then shown '(.*)'")]
        public void ThenAListOfResultsIsThenShown(string equipment)
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(ElementExtensions.VerifyText(driver, liveAlertsListPage.LblEquipment, equipment), "Result has not shown");
        }

        [When(@"Selected one of the pieces of equipment\.")]
        public void WhenSelectedOneOfThePiecesOfEquipment_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.LblEquipment);
            Waits.Wait(driver, 2000);
        }

        [When(@"Typed a message for this alert, e\.g\. '(.*)'\.")]
        public void WhenTypedAMessageForThisAlertE_G__(string msg)
        {
            liveAlertsListPage.TxtBoxMessage.SendKeys(msg);
        }

        [When(@"Entered a comment '(.*)'")]
        public void WhenEnteredAComment(string comment)
        {
            liveAlertsListPage.TxtBoxComment.SendKeys(comment);
        }

        [When(@"Clicked ‘Create Alert’\.")]
        public void WhenClickedCreateAlert_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnCreateAlert);
        }

        [Then(@"The alert '(.*)' should appear at the top of the Alert list and will remain until closed\.")]
        public void ThenTheAlertShouldAppearAtTheTopOfTheAlertListAndWillRemainUntilClosed_(string msg)
        {
            Waits.Wait(driver, 4000);
            Assert.IsTrue(liveAlertsListPage.IsCreatedAlertDisplayed(msg), "Verified created alert is not displayed on alert screen");
            Waits.Wait(driver, 3000);
            liveAlertsListPage.ClickNewlyCreatedAlert();
            Waits.Wait(driver, 3000);
            ElementExtensions.SelectByValue(liveAlertsListPage.DrpDwnMaintenanceStatus, "6");
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnApply);
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnClose);
        }

        [When(@"Selected few filter options through the check boxes or enter valid text in text boxes as shown in previous step")]
        public void WhenSelectedFewFilterOptionsThroughTheCheckBoxesOrEnterValidTextInTextBoxesAsShownInPreviousStep()
        {
            if (liveAlertsListPage.ChkBoxAdvisory.GetAttribute("src").Contains("chk_off"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxAdvisory);
            }
            if (liveAlertsListPage.ChkBoxMinorWarning.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxMinorWarning);
            }
            if (liveAlertsListPage.ChkboxMajorWarning.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkboxMajorWarning);
            }
            if (liveAlertsListPage.ChkBoxMinorAlarm.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxMinorAlarm);
            }
            if (liveAlertsListPage.ChkBoxMajorAlarm.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxMajorAlarm);
            }
        }

        [Then(@"Only Alerts matching with the applied filter option should be visible in the list\.")]
        public void ThenOnlyAlertsMatchingWithTheAppliedFilterOptionShouldBeVisibleInTheList_()
        {
            liveAlertsListPage.IsAlertFilteredBySeverity("Advisory");
        }

        [When(@"Clicked on Hide Filter button\.")]
        public void WhenClickedOnHideFilterButton_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnHideFilter);
        }

        [Then(@"The Filter panel should be hidden from the view\.")]
        public void ThenTheFilterPanelShouldBeHiddenFromTheView_()
        {
            Assert.IsTrue(!ElementExtensions.isDisplayed(driver, liveAlertsListPage.LblMaintenanceStatus), "Filter Panel no hiddden after clicking Hide filter button");
            Assert.IsTrue(liveAlertsListPage.BtnShowFilter.Displayed, "Filter Panel no hiddden after clicking Hide filter button");
        }

        [Then(@"The filter panel should be displayed with last applied filter option marked\.")]
        public void ThenTheFilterPanelShouldBeDisplayedWithLastAppliedFilterOptionMarked_()
        {
            Waits.WaitForElementVisible(driver, liveAlertsListPage.InfoMessage);
            Assert.IsTrue(liveAlertsListPage.InfoMessage.Text.Contains(GlobalConstants.FilterApplied));
            Assert.IsTrue(liveAlertsListPage.ChkBoxAdvisory.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxMinorWarning.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxMinorAlarm.GetAttribute("src").Contains("chk_on"));
            // Assert.IsTrue(liveAlertsListPage.ChkBoxMajorAlarm.GetAttribute("src").Contains("chk_off"));
           Assert.IsTrue(liveAlertsListPage.ChkBoxMajorAlarm.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxUnacknowledged.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxAcknowledged.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxAssigned.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxWorkInProgress.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxPending.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxClosed.GetAttribute("src").Contains("chk_off"));
            Assert.IsTrue(liveAlertsListPage.DrpdwnSelectedAssignedUser.Text.Contains("Not Selected"));
            Assert.IsTrue(liveAlertsListPage.DrpdwnSelectedAssignedUser.Text.Contains("Not Selected"));
            Assert.IsTrue(liveAlertsListPage.DrpdwnSelectedGroupOption.Text.Contains(""));
            Assert.IsTrue(liveAlertsListPage.TxtBoxMessage.GetAttribute("value").Contains(""));
            Assert.IsTrue(liveAlertsListPage.TxtBoxSystemName.GetAttribute("value").Contains(""));
            Assert.IsTrue(liveAlertsListPage.TxtBoxToDate.GetAttribute("value").Contains(""));
            Assert.IsTrue(liveAlertsListPage.TxtBoxFromDate.GetAttribute("value").Contains(""));
        }

        [When(@"Clicked on Reset Filter button\.")]
        public void WhenClickedOnResetFilterButton_()
        {
            Waits.Wait(driver, 3000);
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnResetFilter);
        }

        [Then(@"All the filter option previously applied should be removed and Alert list should be reset\.")]
        public void ThenAllTheFilterOptionPreviouslyAppliedShouldBeRemovedAndAlertListShouldBeReset_()
        {
            Waits.Wait(driver, 5000);
            Waits.WaitForElementVisible(driver, liveAlertsListPage.InfoMessage);
            Assert.IsTrue(liveAlertsListPage.InfoMessage.Text.Contains(GlobalConstants.DefaultsApplied));
            Assert.IsTrue(liveAlertsListPage.ChkBoxAdvisory.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxMinorWarning.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxMinorWarning.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxMinorAlarm.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxMajorAlarm.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxUnacknowledged.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxAcknowledged.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxAssigned.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxWorkInProgress.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxPending.GetAttribute("src").Contains("chk_on"));
            Assert.IsTrue(liveAlertsListPage.ChkBoxClosed.GetAttribute("src").Contains("chk_off"));
            Assert.IsTrue(liveAlertsListPage.DrpdwnSelectedAssignedUser.Text.Contains("Not Selected"));
            Assert.IsTrue(liveAlertsListPage.DrpdwnSelectedAssignedUser.Text.Contains("Not Selected"));
            Assert.IsTrue(liveAlertsListPage.DrpdwnSelectedGroupOption.Text.Contains("Not Selected"));
            Assert.IsTrue(liveAlertsListPage.TxtBoxMessage.GetAttribute("value").Contains(""));
            Assert.IsTrue(liveAlertsListPage.TxtBoxSystemName.GetAttribute("value").Contains(""));
            Assert.IsTrue(liveAlertsListPage.TxtBoxToDate.GetAttribute("value").Contains(""));
            Assert.IsTrue(liveAlertsListPage.TxtBoxFromDate.GetAttribute("value").Contains(""));
        }

        [Then(@"A new window will pop-up with '(.*)' tab selected on the screen\.")]
        public void ThenANewWindowWillPop_UpWithTabSelectedOnTheScreen_(string tabName)
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(liveAlertsListPage.LnkAlertDetails.Text.Contains(tabName), "Verified alert tab window pop up not opened");
        }

        [When(@"updated maintenance status to '(.*)' and assigned user '(.*)'\. Also added comment '(.*)'\.")]
        public void WhenUpdatedMaintenanceStatusToAndAssignedUser_AlsoAddedComment_(string maintenanceStatus, string assignedUser, string comment)
        {
            Waits.Wait(driver, 2000);
            ElementExtensions.SelectByText(liveAlertsListPage.DrpDwnAssignedUserAlertDetails, assignedUser);
            Waits.Wait(driver, 3000);
            ElementExtensions.SelectByText(liveAlertsListPage.DrpDwnMaintenanceStatus, maintenanceStatus);
            Waits.Wait(driver, 3000);
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnApply);
            lastUpdated = liveAlertsListPage.LblLastUpdated.Text;
            liveAlertsListPage.TxtBoxAddComment.SendKeys(comment);
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnAdd);
        }

        [When(@"Clicked close\.")]
        public void WhenClickedClose_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnClose);
        }

        [Then(@"Once closed open the same detail window again\.\tThe Detail window should show updated detail in last step maintenance status as '(.*)', assigned user as '(.*)' and comment '(.*)'")]
        public void ThenOnceClosedOpenTheSameDetailWindowAgain_TheDetailWindowShouldShowUpdatedDetailInLastStepMaintenanceStatusAsAssignedUserAsAndComment(string maintenanceStatus, string assignedUser, string comment)
        {

            liveAlertsListPage.ClickNewlyCreatedAlert();
            Waits.Wait(driver, 4000);
            Assert.IsTrue(ElementExtensions.VerifyText(driver, liveAlertsListPage.DrpDwnSelectedMaintenanceStatusAlertDetails, maintenanceStatus));
            Assert.IsTrue(ElementExtensions.VerifyText(driver, liveAlertsListPage.DrpDwnSelectedAssignedUserAlertDetails, assignedUser));
            Assert.IsTrue(ElementExtensions.VerifyText(driver, liveAlertsListPage.TxtBoxCommentAlertDetails, comment));
        }


        [When(@"clicked on Alert History tab\.")]
        public void WhenClickedOnAlertHistoryTab_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkAlertHistory);
        }

        [Then(@"User should able to see history of changes made on that alert with date-time, user and detail\.")]
        public void ThenUserShouldAbleToSeeHistoryOfChangesMadeOnThatAlertWithDate_TimeUserAndDetail_()
        {
            List<string> historyDataLst = liveAlertsListPage.GetAlertHistoryData();
            if (historyDataLst.ElementAt(8).Contains("Changed status to pending / Assigned to user user, test (testuser)")
                 && historyDataLst.ElementAt(5).Contains("Added comment"))
            {
                Assert.IsTrue(true, "History logged for maintenance status, assigned user and comment");
                Waits.WaitAndClick(driver, liveAlertsListPage.BtnClose);
            }
            else
            {
                Assert.IsFalse(false, "History is not logged for maintenance status and comment");
            }
        }

        [Given(@"I Added user with details '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' and '(.*)'")]
        public void GivenIAddedUserWithDetailsAnd(string userName, string pwd, string confirmPwd, string question, string ans, string firstName, string lastName, string email)
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            if (userPage == null)
                userPage = new UserPage(driver);
            Waits.WaitAndClick(driver, userPage.LnkMaintainUser);            
            userPage.CreateNewUser(userName, pwd, confirmPwd, question, ans, firstName, lastName, email);
            userPage.ClickOnApplyChanges();
            Waits.WaitForElementVisible(driver, userPage.LnkPermission);
            Waits.WaitAndClick(driver, userPage.LnkPermission);
            Waits.WaitAndClick(driver, userPage.SelectAllCheckBox);
            Waits.WaitAndClick(driver, userPage.BtnApplyChange);
            Waits.WaitForElementVisible(driver, userPage.LblChangesApplied);
            Assert.IsTrue(userPage.LblChangesApplied.Text.Contains("Changes have been applied"), "Verified 'Changes have been applied' message");
            Waits.WaitAndClick(driver, userPage.LinkHomePage);
        }

        [When(@"Clicked on an alert in the list")]
        public void WhenClickedOnAnAlertInTheList()
        {
            Waits.Wait(driver, 8000);
            liveAlertsListPage.ClickOnAlertItem(1);
            Waits.Wait(driver, 3000);
        }

        [When(@"Clicked on tab: \[Alert Details]")]
        public void WhenClickedOnTabAlertDetails()
        {
            liveAlertsListPage.ClickOnAlertItem(1);
            Waits.Wait(driver, 3000);
        }

        [Then(@"Appropriate settings to be displayed for Alert details tab")]
        public void ThenAppropriateSettingsToBeDisplayedForAlertDetailsTab()
        {
            Assert.IsTrue(liveAlertsListPage.LblSeverityValue.Displayed, "Alert Severity is not displayed");
            Assert.IsTrue(liveAlertsListPage.LblEquipmentAlertDetails.Displayed, "Alert Equipment is not displayed");
            Assert.IsTrue(liveAlertsListPage.LblAlertDetailsMsg.Displayed, "Alert Message is not displayed");
        }
      
        [When(@"Entered Message '(.*)' to filter for alerts from the list,")]
        public void WhenEnteredMessageToFilterForAlertsFromTheList(string msg)
        {
            liveAlertsListPage.TxtBoxMessage.SendKeys(msg);
        }

        [Then(@"Alerts matching to the message '(.*)' filter will be displayed in the alerts list\.")]
        public void ThenAlertsMatchingToTheMessageFilterWillBeDisplayedInTheAlertsList_(string msg)
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(liveAlertsListPage.IsAlertFilteredByMessage(msg), "Alerts are not filtered by Message correctly");
        }

        [When(@"Raised Alert on parameters '(.*)', '(.*)'")]
        public void GivenRaisedAlertOnParameters(string parameter1, string parameter2)
        {
            simulator.RestoreWindow();
            simulator.StopSimulator();
            Waits.Wait(driver, 2000);
            simulator.SelectEquipment();
            simulator.RaiseAlert(parameter1);
            Waits.Wait(driver, 2000);
            simulator.RaiseAlert(parameter2);
            Waits.Wait(driver, 3000);
        }
        [When(@"Raised Alert on parameters '(.*)'")]
        public void GivenRaisedAlertOnParameter(string parameter1)
        {
           simulator.RestoreWindow();
         //  simulator.StopSimulator();
            Waits.Wait(driver, 2000);
          //  simulator.SelectETXEquipment();
            simulator.RaiseAlert(parameter1);
            Waits.Wait(driver, 3000);
        }


        [When(@"clicked the Active Alert tab on Live Alert screen\.")]
        public void WhenClickedTheActiveAlertTabOnLiveAlertScreen_()
        {
            Waits.Wait(driver, 4000);
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkActive);
            Waits.Wait(driver, 4000);
        }

        [Then(@"The list alerts should only show alerts that are active – i\.e\. alerts that have been raised by the device but not yet ended by the device\.")]
        public void ThenTheListAlertsShouldOnlyShowAlertsThatAreActiveI_E_AlertsThatHaveBeenRaisedByTheDeviceButNotYetEndedByTheDevice_()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnShowFilter);
            Waits.Wait(driver, 2000);
            liveAlertsListPage.TxtBoxSystemName.SendKeys("NEW0001PM1");
            WhenMarkedCheckBoxMajorAlarmAndUn_MarkAllOtherAlertLevelCheckBox();
            Waits.Wait(driver, 5000);
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnApplyFilter);
            Waits.Wait(driver, 50000);
            Assert.IsTrue(liveAlertsListPage.CheckSystemAlerts("NEW0001PM1"), "Active alerts are not shown");
        }

        [When(@"clicked the All Alerts tab on Live Alert screen\.")]
        public void WhenClickedTheAllAlertsTabOnLiveAlertScreen_()
        {
            Waits.WaitForElementVisible(driver, liveAlertsListPage.LnkAllAlerts);
            Waits.Wait(driver, 2000);
            liveAlertsListPage.LnkAllAlerts.Click();
            Waits.Wait(driver, 5000);
        }

        [When(@"Cleared Alert from simulator  '(.*)'")]
        public void WhenClearedAlertFromSimulator(string parameter)
        {
            simulator.ClearAlert(parameter);
            Thread.Sleep(1000);
            simulator.MinimizeSimulator();
        }

        [Then(@"the list of alerts should show alerts inactive – i\.e\. alerts that have been raised by the device and then ended by the device\.")]
        public void ThenTheListOfAlertsShouldShowAlertsInactiveI_E_AlertsThatHaveBeenRaisedByTheDeviceAndThenEndedByTheDevice_()
        {
            Waits.Wait(driver, 15000);
            liveAlertsListPage.ClickOnAlertItem(2);
            Waits.Wait(driver, 3000);
            string status = liveAlertsListPage.LblActualStatus.Text;
            Assert.IsTrue(liveAlertsListPage.LblActualStatus.Text.Contains("Inactive"), "Cleared alert status is not Inactive");
        }

        [When(@"Clicked on the previously created alert in the list\.")]
        public void WhenClickedOnThePreviouslyCreatedAlertInTheList_()
        {
            liveAlertsListPage.ClickNewlyCreatedAlert();
        }

        [Then(@"Alert details to be displayed with msg '(.*)', alert type as '(.*)' , equipmenttype as'(.*)'")]
        public void ThenAlertDetailsToBeDisplayedWithMsgAlertTypeAsEquipmenttypeAs(string msg, string alertType, string equipmentType)
        {
            Waits.WaitForElementVisible(driver, liveAlertsListPage.LblAlertDetailsMsg);
            liveAlertsListPage.LblAlertDetailsMsg.Text.Contains(msg);
            liveAlertsListPage.LblSeverityValue.Text.Contains(alertType);
            liveAlertsListPage.LblEquipmentAlertDetails.Text.Contains(equipmentType);
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnClose);
            Waits.Wait(driver, 2000);
        }

        [When(@"Clickd on tab: \[Alert History]")]
        public void WhenClickdOnTabAlertHistory()
        {
            liveAlertsListPage.ClickOnAlertHistoryTab();
            Waits.Wait(driver, 3000);
        }

        [Then(@"Appropriate settings to be displayed for Alert History details tab")]
        public void ThenAppropriateSettingsToBeDisplayedForAlertHistoryDetailsTab()
        {
            List<string> lstHistoryData = new List<string>(liveAlertsListPage.GetAlertHistoryData());
            if (lstHistoryData.ElementAt(2).Contains("Created by system"))
            {
                Assert.IsTrue(true, "HistoryData data is correct");
            }
            else
            {
                Assert.IsFalse(true, "HistoryData data is incorrect");
            }
            Assert.IsTrue(liveAlertsListPage.BtnClose.Displayed, "Button close is not present");
        }

        [When(@"Clickd on tab: \[Inhbit Settings]")]
        public void WhenClickdOnTabInhbitSettings()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkInhibitSettings);
        }

        [Then(@"Appropriate settings to be displayed for Inhibit Settings tab")]
        public void ThenAppropriateSettingsToBeDisplayedForInhibitSettingsTab()
        {
            Waits.Wait(driver, 3000);
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkInhibitSettings);
            Assert.IsTrue(liveAlertsListPage.TxAreaReason.Displayed, "Reason text area is not present");
            Assert.IsTrue(liveAlertsListPage.TxtBoxCreatedBy.Displayed, "Created by text box is not present");
            Assert.IsTrue(liveAlertsListPage.TxtBoxInhibitEnd.Displayed, "InhibitEnd text box is not present");
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnClose);
        }

        [When(@"Selected another alert")]
        public void WhenSelectedAnotherAlert()
        {
            Waits.Wait(driver, 3000);
            liveAlertsListPage.ClickOnAlertItem(2);
        }

        [Then(@"The Created Alert should appear in Live Alerts List\.")]
        public void ThenTheCreatedAlertShouldAppearInLiveAlertsList_()
        {
            Waits.Wait(driver, 50000);
            Assert.IsTrue(liveAlertsListPage.IsAllTurboAlertsDisplayed(), "Turbo alerts are not displayed on screen");
        }

        [When(@"Marked CheckBox Minor Alarm and Un-Mark all other Alert Level CheckBox")]
        public void WhenMarkedCheckBoxMinorAlarmAndUn_MarkAllOtherAlertLevelCheckBox()
        {
            Waits.Wait(driver, 4000);
            if (liveAlertsListPage.ChkBoxAdvisory.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxAdvisory);
                Waits.Wait(driver, 2000);
            }
            if (liveAlertsListPage.ChkBoxMinorWarning.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxMinorWarning);
                Waits.Wait(driver, 2000);
            }
            if (liveAlertsListPage.ChkboxMajorWarning.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkboxMajorWarning);
                Waits.Wait(driver, 2000);
            }
            if (liveAlertsListPage.ChkBoxMinorAlarm.GetAttribute("src").Contains("chk_off"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxMinorAlarm);
                Waits.Wait(driver, 2000);
            }
            if (liveAlertsListPage.ChkBoxMajorAlarm.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxMajorAlarm);
                Waits.Wait(driver, 2000);
            }
        }

        [Then(@"Only Alert with code '(.*)' creataed in previous step should display")]
        public void ThenOnlyAlertWithCodeCreataedInPreviousStepShouldDisplay(string alertCode)
        {
            liveAlertsListPage.IsAlertFilteredByMessage(alertCode);
        }

        [When(@"Repeated the previous steps with severity levels ‘Major Warning’")]
        public void WhenRepeatedThePreviousStepsWithSeverityLevelsMajorWarning()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.BtnResetFilter);
            if (liveAlertsListPage.ChkBoxAdvisory.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxAdvisory);
            }
            if (liveAlertsListPage.ChkBoxMinorWarning.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxMinorWarning);
            }
            if (liveAlertsListPage.ChkboxMajorWarning.GetAttribute("src").Contains("chk_off"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkboxMajorWarning);
            }
            if (liveAlertsListPage.ChkBoxMinorAlarm.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxMinorAlarm);
            }
            if (liveAlertsListPage.ChkBoxMajorAlarm.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxMajorAlarm);
            }
        }

        public void WhenMarkedCheckBoxMajorAlarmAndUn_MarkAllOtherAlertLevelCheckBox()
        {
            Waits.Wait(driver, 4000);
            if (liveAlertsListPage.ChkBoxAdvisory.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxAdvisory);
            }
            if (liveAlertsListPage.ChkBoxMinorWarning.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxMinorWarning);
            }
            if (liveAlertsListPage.ChkboxMajorWarning.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkboxMajorWarning);
            }
            if (liveAlertsListPage.ChkBoxMinorAlarm.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxMinorAlarm);
            }
            if (liveAlertsListPage.ChkBoxMajorAlarm.GetAttribute("src").Contains("chk_off"))
            {
                Waits.WaitAndClick(driver, liveAlertsListPage.ChkBoxMajorAlarm);
            }
        }
    }
}
