using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class SetupTestsStepDefinition
    {
        private IWebDriver driver;
        string testFolderName = ElementExtensions.GetRandomString(4);
        Simulator simulator = new Simulator();
        HomePage homePage;
        LoginPage loginPage;
        LoggingPage loggingPage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        SetUpPage setUpPage;
        ReportPage reportPage;
        string grabID = "";
        string iPAdress = SpecflowHooks.HostIpAddress();

        public SetupTestsStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            setUpPage = new SetUpPage(driver);
            loggingPage = new LoggingPage(driver);
            reportPage = new ReportPage(driver);
        }
        [When(@"Run Agent Configuration")]
        public void WhenRunAgentConfiguration()
        {
         //   simulator.LaunchAgentonWinProTest();
           simulator.LaunchAgentonWinPro();
            Waits.Wait(driver, 1000);
         // Assert.IsTrue(simulator.AgentConfigurationWindowIsExist(), "Verified Scada Agent Configuration window opened Successfully");
            Waits.Wait(driver, 1000);
        }
        [When(@"Run Agent Configuration \(shortcut on desktop\)")]
        public void WhenRunAgentConfigurationShortcutOnDesktop()
        {
            simulator.LaunchAgent();
            Waits.Wait(driver, 1000);
            Assert.IsTrue(simulator.AgentConfigurationWindowIsExist(), "Verified Scada Agent Configuration window opened Successfully");
            Waits.Wait(driver, 1000);
        }

        [When(@"I click server '(.*)' '(.*)' lookup IP")]
        public void WhenIClickServerLookupIP(string agentName, string serverName)
        {            
            simulator.EnterSplitServerDetails(agentName,serverName);
        }

        [When(@"Selected PC Interface Network Id card under Relay tab")]
        public void WhenSelectedPCInterfaceNetworkIdCardUnderRelayTab()
        {
            simulator.SelectPCNetworkInterfaceCard();
            simulator.KillProcess();
        }

        [When(@"Set pin value '(.*)'")]
        public void ThenSetPinValue(int pin)
        {
            simulator.SetPin(pin);
            Waits.Wait(driver, 80000);
        }

        [When(@"added '(.*)' '(.*)' '(.*)' agents")]
        public void WhenAddedAgents(string agentToConfigure1, string agentToConfigure2, string agentToConfigure3)
        {
            simulator.UpdatedAgent(agentToConfigure1);
            simulator.UpdatedAgent(agentToConfigure2);
            simulator.UpdatedAgent(agentToConfigure3);
        }        

        [When(@"Launch the EISSA tool and specify ten devices with six pumps")]
        public void WhenLaunchTheEISSAToolAndSpecifyTenDevicesWithSixPumps()
        {
            simulator.LaunchSimulator();
            simulator.SelectBaseName();
            simulator.SelectDeviceEquipmentType();
        }

        [Then(@"Ensure that Log is checked on the EISSA screen")]
        public void ThenEnsureThatLogIsCheckedOnTheEISSAScreen()
        {
            simulator.CheckboxStatus();
            Waits.Wait(driver, 1000);
        }

        [When(@"Click on the green play button")]
        public void WhenClickOnTheGreenPlayButton()
        {
            simulator.RestoreWindow();
            simulator.StartSimulator();
            simulator.MinimizeWindow();
        }

        [Then(@"Log entries in the log window, eventually served: Equipment log entries")]
        public void ThenLogEntriesInTheLogWindowEventuallyServedEquipmentLogEntries()
        {
            Thread.Sleep(1000);
            simulator.RestoreWindow();
            Thread.Sleep(25000);
            Assert.IsTrue(simulator.LogEntriesStatus(), "Verified Log entries in the log window");
            Thread.Sleep(1000);
        }

        [When(@"Uncheck Log")]
        public void WhenUncheckLog()
        {
            simulator.UnCheckboxStatus();
            Waits.Wait(driver, 1000);
        }

        [Then(@"The log window to stop refreshing")]
        public void ThenTheLogWindowToStopRefreshing()
        {
            Assert.IsFalse(simulator.LogEntriesStatus(), "Verified The log window to stop refreshing");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click on Edit -> Adjustables")]
        public void WhenClickOnEdit_Adjustables()
        {
            simulator.EditMenuSelection();
        }

        [Then(@"The adjustables window to show")]
        public void ThenTheAdjustablesWindowToShow()
        {
            Assert.IsTrue(simulator.VerifyAdjustableWindow(), "Verfiied The adjustables window to show");
        }

        [When(@"Use the \[Load] button to load the adjustables file '(.*)'")]
        public void WhenUseTheLoadButtonToLoadTheAdjustablesFile(string fileName)
        {
            string adjustableFileName = simulator.AdjustableFile(fileName);
            simulator.LoadAdjustableFile(adjustableFileName);
        }

        [Then(@"The file to load and show entries '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'in the grid")]
        public void ThenTheFileToLoadAndShowEntriesInTheGrid(string parameter1, string parameter2, string parameter3, string parameter4, string parameter5, string parameter6)
        {
            string[] Parameters = new string[] { parameter1, parameter2, parameter3, parameter4, parameter5, parameter6 };
            for (int i = 0; i < Parameters.Length; i++)
            {
                simulator.GridListedElements(Parameters[i]);
            }
        }

        [When(@"Start the turbo simulator and get it to start listening on ports")]
        public void WhenStartTheTurboSimulatorAndGetItToStartListeningOnPorts()
        {
            simulator.LaunchTurboWindow();
        }

        [Then(@"The simulator should spin up and, once the port range has been entered, show something again and minimize")]
        public void ThenTheSimulatorShouldSpinUpAndOnceThePortRangeHasBeenEnteredShowSomethingAgainAndMinimize()
        {
            simulator.StartTurboCommunication();
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"Login to FabWorks and show the Turbo '(.*)' creation test script")]
        public void WhenLoginToFabWorksAndShowTheTurboCreationTestScript(string equipmentType)
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            if (setUpPage == null)
                setUpPage = new SetUpPage(driver);
            Waits.WaitForElementVisible(driver, setUpPage.DrpDownSelectEquipmentType);
            if (setUpPage == null)
                setUpPage = new SetUpPage(driver);
            ElementExtensions.SelectByText(setUpPage.DrpDownSelectEquipmentType, equipmentType);
            Waits.Wait(driver, 3000);
        }

        [Then(@"You should be presented with the opportunity to enter the following details")]
        public void ThenYouShouldBePresentedWithTheOpportunityToEnterTheFollowingDetails()
        {
            if (setUpPage == null)
                setUpPage = new SetUpPage(driver);
            Waits.WaitForElementVisible(driver, setUpPage.DrpDownSelectEquipmentType);
            Assert.IsTrue(setUpPage.DrpDownSelectEquipmentType.Displayed, "Turbo Equipment selection Dropdown Presented");
            Waits.WaitForElementVisible(driver, setUpPage.TxtBoxEquipmentName);
            Assert.IsTrue(setUpPage.TxtBoxEquipmentName.Displayed, "Turbo EquipmentName TxtBox Presented");
            Waits.WaitForElementVisible(driver, setUpPage.TxtBoxIPAddress);
            Assert.IsTrue(setUpPage.TxtBoxIPAddress.Displayed, "Turbo IPAddress TxtBox Presented");
            Waits.Wait(driver, 4000);
        }

        [When(@"Enter the data as equipment Name '(.*)' equipmentType '(.*)' device iPPortNumber'(.*)'")]
        public void WhenEnterTheDataAsEquipmentNameEquipmentTypeDeviceIPPortNumber(string equipmentName, string equipmentType, string iPPortNumber)
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            Waits.Wait(driver, 4000);
        }


        [Then(@"The turbo devices should be created\. Messages should be shown in the Turbo Simulator indicating that connections are being made")]
        public void ThenTheTurboDevicesShouldBeCreated_MessagesShouldBeShownInTheTurboSimulatorIndicatingThatConnectionsAreBeingMade()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.EquipmentAddedMsg), "Verifying 'Equipment Added Successfully' message");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 2000);
        }

        [When(@"Use Device Explorer and create a folder named then add as many turbos'(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void WhenUseDeviceExplorerAndCreateAFolderNamedThenAddAsManyTurbos(string equipmentName1, string equipmentType, string iPPortNumber1, string equipmentName2, string iPPortNumber2, string equipmentName3, string iPPortNumber3, string equipmentName4, string iPPortNumber4, string equipmentName5, string iPPortNumber5)
        {
            if (setUpPage == null)
                setUpPage = new SetUpPage(driver);
            setUpPage.AddEquipment(equipmentName1, equipmentType, iPAdress, iPPortNumber1);
            Waits.Wait(driver, 1000);
            setUpPage.AddEquipment(equipmentName2, equipmentType, iPAdress, iPPortNumber2);
            Waits.Wait(driver, 1000);
            setUpPage.AddEquipment(equipmentName3, equipmentType, iPAdress, iPPortNumber3);
            Waits.Wait(driver, 1000);
            setUpPage.AddEquipment(equipmentName4, equipmentType, iPAdress, iPPortNumber4);
            Waits.Wait(driver, 1000);
            setUpPage.AddEquipment(equipmentName5, equipmentType, iPAdress, iPPortNumber5);
            Waits.Wait(driver, 1000);
        }

        [Then(@"New turbos'(.*)' Alert '(.*)' and '(.*)' to be created")]
        public void ThenNewTurbosAlertAndToBeCreated(string equipment3, string Alert, string iPPortNumber3)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(Alert, iPPortNumber3);
            simulator.MinimizeWindow("TURBO");
            if (setUpPage == null)
                setUpPage = new SetUpPage(driver);
            setUpPage.ClickOnFolder(equipment3);
            Waits.Wait(driver, 1000);
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 2000);
                if (reportPage == null)
                    reportPage = new ReportPage(driver);
                if (reportPage.GetWarningCountText.Contains("1"))
                {
                    Assert.IsTrue(reportPage.GetWarningCountText.Contains("1"), "Verified Warning alerts present for number of devices");
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        [When(@"open the DSPU and open ADS_SystemTest Scenario '(.*)'")]
        public void WhenOpenTheDSPUAndOpenADS_SystemTestScenario(string filePath)
        {
            simulator.LaunchScadaDSPU();
            Waits.Wait(driver, 2000);
            filePath = simulator.ADS_SystemTestFilePath(filePath);
            simulator.SelectDSPUScenario(filePath);
            Waits.Wait(driver, 2000);
        }
     
        [Then(@"DSPU should show '(.*)' in cell '(.*)' the complex ADS scenario")]
        public void ThenDSPUShouldShowInCellTheComplexADSScenario(string text, int cell)
        {
          Assert.IsTrue(simulator.DataGridViewVisible(text, cell), "Verified DSPU should show the complex ADS scenario");
            Waits.Wait(driver, 1000);
        }

        [When(@"Start the ADS scenario")]
        public void WhenStartTheADSScenario()
        {
            simulator.ExecuteDSPU();
            Waits.Wait(driver, 3000);
        }

        [Then(@"Several graphs should be displayed whilst the scenario is running")]
        public void ThenSeveralGraphsShouldBeDisplayedWhilstTheScenarioIsRunning()
        {
            Assert.IsTrue(simulator.IsGraphExist(), "Verified Several graphs should be displayed ");
            Waits.Wait(driver, 10000);
        }

        [When(@"wait (.*) seconds and then Stop the scenario when some data points have been displayed in the graph")]
        public void WhenWaitSecondsAndThenStopTheScenarioWhenSomeDataPointsHaveBeenDisplayedInTheGraph(int p0)
        {
            simulator.StopDSPUScenario();
            Waits.Wait(driver, 1000);
        }

        [Then(@"They should disappear when the scenario is stopped")]
        public void ThenTheyShouldDisappearWhenTheScenarioIsStopped()
        {
            Assert.IsFalse(simulator.IsGraphExist(), "Verified graphs should disappear when the scenario is stopped ");
            //simulator.MinimizeDSPU();
        }
        
        [When(@"Login to EdCentra, select the Predictive Maintenance -> Import Profile and upload the following models '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void WhenLoginToEdCentraSelectThePredictiveMaintenance_ImportProfileAndUploadTheFollowingModels(string profile1, string model1, string profile2, string model2, string profile3, string model3, string profile4, string model4, string profile5, string model5)
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkPredictiveMaintenance);
            if (setUpPage == null)
                setUpPage = new SetUpPage(driver);
            Waits.WaitForElementVisible(driver, setUpPage.LnkImportProfile);
            string[] profiles = new string[] { profile1, profile2, profile3, profile4, profile5 };
            string[] models = new string[] { model1, model2, model3, model4, model5 };
            if (ElementExtensions.isDisplayed(driver, setUpPage.TxtProfileName))
            {
                for (int i = 0; i < 5; i++)
                {
                    Waits.Wait(driver, 2000);
                    Waits.WaitAndClick(driver, setUpPage.LnkImportProfile);
                    Waits.WaitForElementVisible(driver, setUpPage.TxtProfileName);
                    string modelName = simulator.ADS_SystemTestFilePath(models[i]);
                    Waits.Wait(driver, 2000);
                    setUpPage.ImportFile(profiles[i], modelName);
                }
            }
        }

        [Then(@"After a period of upto two minutes, the ADS'(.*)' '(.*)' list should populated with the models uploaded")]
        public void ThenAfterAPeriodOfUptoTwoMinutesTheADSListShouldPopulatedWithTheModelsUploaded(string profile1, string profile4)
        {
            Assert.IsTrue(setUpPage.IsProfileExist(profile1), "Verified ADS list should populated with the models uploaded");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(setUpPage.IsProfileExist(profile4), "Verified ADS list should populated with the models uploaded");
            Waits.Wait(driver, 1000);
        }

        [When(@"Associate the iXH device '(.*)' with all the models uploaded '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void WhenAssociateTheIXHDeviceWithAllTheModelsUploaded(string device, string profile1, string profile2, string profile3, string profile4, string profile5)
        {
            string[] profiles = new string[] { profile1, profile2, profile3, profile4, profile5 };
            for (int i = 0; i < profiles.Length; i++)
            {
                setUpPage.SelectSystem(profiles[i], device);
                Waits.Wait(driver, 1000);
            }
        }

        [Then(@"The UI should show iXH device '(.*)' with all the models uploaded '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' that the associations have been made")]
        public void ThenTheUIShouldShowIXHDeviceWithAllTheModelsUploadedThatTheAssociationsHaveBeenMade(string device, string profile1, string profile2, string profile3, string profile4, string profile5)
        {
            string[] profiles = new string[] { profile1, profile2, profile3, profile4, profile5 };
            for (int i = 0; i < profiles.Length; i++)
            {
                setUpPage.SelectCreatedProfile(profiles[i]);
                Waits.WaitAndClick(driver, setUpPage.TabEquipment);
                if (ElementExtensions.isDisplayed(driver, setUpPage.TabEquipment))
                {
                    Assert.IsTrue(setUpPage.IsSystemExist(device), "Veryfied Associate the iXH device With this model");
                }
            }
        }

        [When(@"Start the DSPU scenario '(.*)'")]
        public void WhenStartTheDSPUScenario(string name)
        {
            Waits.Wait(driver, 1000);
            string scenarioName = simulator.ScenarioAtributePath(name);
            simulator.RestoreScada(scenarioName);
            Waits.Wait(driver, 1000);
            string scadaScenario = "Scada DSPU - " + scenarioName;
            simulator.RestoreADSScada(scadaScenario);
            Waits.Wait(driver, 1000);
            simulator.StartDSPUScenario();
            Waits.Wait(driver, 1000);
        }
        
        [Then(@"DSPU graphs should be displayed")]
        public void ThenDSPUGraphsShouldBeDisplayed()
        {
            Waits.Wait(driver, 3000);
           // simulator.KillProcess();
            Assert.IsTrue(simulator.IsGraphExist(), "Verified Several graphs should be displayed "); 
        }

        [When(@"open the DSPU and open Availability Mode Scenario '(.*)'")]
        public void WhenOpenTheDSPUAndOpenAvailabilityModeScenario(string path)
        {
            simulator.LaunchScadaDSPU();
            path = simulator.AvailabilitySystemFilePath(path);
            simulator.SelectDSPUScenario(path);
        }

        [When(@"Execute the DSPU scenario")]
        public void WhenExecuteTheDSPUScenario()
        {
            Thread.Sleep(1000);
            simulator.ExecuteDSPU();
        }

        [Then(@"The scenario should run and show the Swap Out Generator form")]
        public void ThenTheScenarioShouldRunAndShowTheSwapOutGeneratorForm()
        {
            Assert.IsTrue(simulator.IsExistSwapoutGenerator(), "Verified The scenario should run and show the Swap Out Generator form");
        }
        [When(@"After a second, select '(.*)' \[New System Type] DDL and click on \[Swapout]")]
        public void WhenAfterASecondSelectNewSystemTypeDDLAndClickOnSwapout(string element)
        {
            simulator.SwapoutElement(element);
        }
        [When(@"After another second, select '(.*)' \[New System Type] DDL and click on \[Swapout]")]
        public void WhenAfterAnotherSecondSelectNewSystemTypeDDLAndClickOnSwapout(string element)
        {
            simulator.SwapoutElement(element);
        }

        [When(@"Run the SQL")]
        public void WhenRunTheSQL()
        {
            simulator.LaunchSQL();
            simulator.SQLLogging();
            simulator.CreateNewQuery();
            Waits.Wait(driver, 4000);
        }
        
        [When(@"Select an iXH device and open it in Single Equipement View and then Selecte the Parameters tab")]
        public void WhenSelectAnIXHDeviceAndOpenItInSingleEquipementViewAndThenSelecteTheParametersTab()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSEVPage);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSEVPage.Displayed, "Verified Navigate to the SEV view of a valid device");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkParameters);
        }

        [Then(@"Device Parameters displayed in SEV Parameters tab")]
        public void ThenDeviceParametersDisplayedInSEVParametersTab()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblMBTemp);
            Assert.IsTrue(deviceExplorerNavigationPage.LblMBTemp.Displayed, "Verified MB Temp parameter is not displayed");
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblExhaustPressure);
            Assert.IsTrue(deviceExplorerNavigationPage.LblExhaustPressure.Displayed, "Verified Exhaust Pressure parameter is not displayed");
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblDryPumpCurrent);
            Assert.IsTrue(deviceExplorerNavigationPage.LblDryPumpCurrent.Displayed, "Verified Dry Pump Current parameter is not displayed");
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblDryPumpPower);
            Assert.IsTrue(deviceExplorerNavigationPage.LblDryPumpPower.Displayed, "Verified Dry Pump Power parameter is not displayed");
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblMBInverterSpeed);
            Assert.IsTrue(deviceExplorerNavigationPage.LblMBInverterSpeed.Displayed, "Verified MB Inverter Speed parameter is not displayed");
            Waits.Wait(driver, 1000);
        }

        [When(@"Each default parameter displayed on the Overview tab, using EISSA, change '(.*)' value to '(.*)'")]
        public void WhenEachDefaultParameterDisplayedOnTheOverviewTabUsingEISSAChangeValueTo(string parameter, string value)
        {
            simulator.RestoreWindow();
            simulator.SelectParameter(parameter);
            simulator.SetParameterValue(value);
            simulator.MinimizeWindow();
        }

        [Then(@"Presuming the parameter data is varying from the equipment or simulator, every few seconds you should see updated parameter value'(.*)'")]
        public void ThenPresumingTheParameterDataIsVaryingFromTheEquipmentOrSimulatorEveryFewSecondsYouShouldSeeUpdatedParameterValue(string value)
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Thread.Sleep(10000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblMBTempValue);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblMBTempValue, value), "Verified Displayed value is not correct for MB Temperature");
            Waits.Wait(driver, 1000);
        }

        [Given(@"Agents tab, double click list '(.*)' and give the new Networks a name '(.*)' '(.*)' to open options, click Add and give the new Network name '(.*)'\. Click the Enabled checkbox then Ok")]
        public void GivenAgentsTabDoubleClickListAndGiveTheNewNetworksANameToOpenOptionsClickAddAndGiveTheNewNetworkName_ClickTheEnabledCheckboxThenOk(string list1, string name1, string list2, string name2)
        {
            string hostIP = SpecflowHooks.HostIpAddress();
            //simulator.AgentOptionStatus(list1, name1, hostIP);
            //simulator.AgentOptionStatus(list2, name2, hostIP);
            simulator.KillProcess();
        }

        [Then(@"the log should show Web pages being served")]
        public void ThenTheLogShouldShowWebPagesBeingServed()
        {
            Thread.Sleep(5000);
            simulator.RestoreWindow();
            Thread.Sleep(25000);
            Assert.IsTrue(simulator.LogEntriesStatus(), "Verified Log entries in the log window");
            Waits.Wait(driver, 1000);
        }

        [When(@"run the Turbo simulator to get some Turbo devices communicating")]
        public void WhenRunTheTurboSimulatorToGetSomeTurboDevicesCommunicating()
        {
            Waits.Wait(driver, 1000);
            simulator.KillProcess();
            Waits.Wait(driver, 1000);
            simulator.LaunchTurboWindow();
            simulator.StartTurboCommunication();
            simulator.MinimizeWindow("TURBO");
            Waits.Wait(driver, 7000);
        }

        [Then(@"the console window should show connectivety established the data as equipment Name '(.*)' equipmentType '(.*)' device iPPortNumber'(.*)'")]
        public void ThenTheConsoleWindowShouldShowConnectivetyEstablishedTheDataAsEquipmentNameEquipmentTypeDeviceIPPortNumber(string equipmentName, string equipmentType, string iPPortNumber)
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkAddDevice);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            deviceExplorerNavigationPage.LnkCreateCommission.Click();
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.EquipmentAddedMsg), "Verifying 'Equipment Added Successfully' message");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 2000);
        }

        [Then(@"New turbo show connectivety established the data '(.*)' Alert '(.*)' and '(.*)' to be created")]
        public void ThenNewTurboShowConnectivetyEstablishedTheDataAlertAndToBeCreated(string data, string Alert, string iPPortNumber)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(Alert, iPPortNumber);
            simulator.MinimizeWindow("TURBO");
            if (setUpPage == null)
                setUpPage = new SetUpPage(driver);
            setUpPage.ClickOnFolder(data);
            Waits.Wait(driver, 2000);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 1000);
                if (deviceExplorerNavigationPage.VerifyBackgroundColor(setUpPage.LnkSevPage, "rgba(233, 227, 135, 1)"))
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(reportPage.LblWarningCount, "1"), "Verified Warning alerts  not present for number of devices");
        }

        [When(@"Click a communicating piece of equipment'(.*)' that has parameters \(again, below the name / header\) to show the SEV")]
        public void WhenClickACommunicatingPieceOfEquipmentThatHasParametersAgainBelowTheNameHeaderToShowTheSEV(string equipment)
        {
            if (setUpPage == null)
                setUpPage = new SetUpPage(driver);
            setUpPage.ClickOnFolder(equipment);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSEVPage);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSEVPage.Displayed, "Verified Navigate to the SEV view of a valid device");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkParameters);
        }

        [Then(@"SEV window shows\. The Parameter data should be coming through\. If the parameter boxes are grey and there are no values, Wait for a few seconds\(no more than (.*)\) for the data to come through")]
        public void ThenSEVWindowShows_TheParameterDataShouldBeComingThrough_IfTheParameterBoxesAreGreyAndThereAreNoValuesWaitForAFewSecondsNoMoreThanForTheDataToComeThrough(int p0)
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.Wait(driver, 10000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblMBTemp);
            Assert.IsTrue(deviceExplorerNavigationPage.LblMBTemp.Displayed, "Verified MB Temp parameter is not displayed");
        }

        [When(@"Entered equipment name, selected the equipment type,cliked find equipment button, selected one by one equipments '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'and clicked Add button")]
        public void WhenEnteredEquipmentNameSelectedTheEquipmentTypeClikedFindEquipmentButtonSelectedOneByOneEquipmentsAndClickedAddButton(string equipmentName1, string equipmentName2, string equipmentName3, string equipmentName4, string equipmentName5, string equipmentName6)
        {
            string[] Equipment = new string[] { equipmentName1, equipmentName2, equipmentName3, equipmentName4, equipmentName5, equipmentName6 };
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            for (int i = 0; i < Equipment.Length; i++)
            {
                 Waits.WaitForElementVisible(driver, loggingPage.LnkAddDevice);
                loggingPage.AddSingleEquipment(Equipment[i]);
                Waits.Wait(driver, 1000);
            }
        }

        [When(@"Entered equipment name, selected the equipment type,cliked find equipment button, selected one by one equipments '(.*)' '(.*)' '(.*)' and clicked Add button")]
        public void WhenEnteredEquipmentNameSelectedTheEquipmentTypeClikedFindEquipmentButtonSelectedOneByOneEquipmentsAndClickedAddButton(string equipmentName1, string equipmentName2, string equipmentName3)
        {
            string[] Equipment = new string[] { equipmentName1, equipmentName2, equipmentName3 };
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            for (int i = 0; i < Equipment.Length; i++)
            {
                Waits.WaitForElementVisible(driver, loggingPage.LnkAddDevice);
                loggingPage.AddSingleEquipment(Equipment[i]);
                Waits.Wait(driver, 1000);
            }
        }


        [Then(@"Grab the system '(.*)' id of every iXH for the test")]
        public void ThenGrabTheSystemIdOfEveryIXHForTheTest(string Agent)
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            deviceExplorerNavigationPage.LnkNetworkLayout.Click();
            Waits.Wait(driver, 1000);
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            loggingPage.SelectAgentServer(Agent);
            Waits.Wait(driver, 1000);
            grabID = loggingPage.SelectSystemId();
            Waits.Wait(driver, 1000);
        }

        [When(@"open the DSPU and open Maintenance Mode Scenario '(.*)'")]
        public void WhenOpenTheDSPUAndOpenMaintenanceModeScenario(string fileName)
        {
            simulator.KillProcess();
            simulator.LaunchScadaDSPU();
            Waits.Wait(driver, 1000);
            string path = simulator.MaintainModuleScenarioFilePath("DSPU_New Scenario.xml");
            simulator.SelectDSPUScenario(path);
            Waits.Wait(driver, 2000);
        }

        [Then(@"Update the Triangle Wave DS and ensure that the System ID GUID in the EquipmentEventDetails field is the system id of an iXH registered with FabWorks")]
        public void ThenUpdateTheTriangleWaveDSAndEnsureThatTheSystemIDGUIDInTheEquipmentEventDetailsFieldIsTheSystemIdOfAnIXHRegisteredWithFabWorks()
        {
            simulator.SetSystemID(grabID);
            simulator.ExecuteDSPU();
            simulator.MinimizeDSPU();
            Waits.Wait(driver, 2000);            
        }

        [When(@"run query and read data")]
        public void WhenRunQueryAndReadData()
        {
            if (setUpPage == null)
                setUpPage = new SetUpPage(driver);
            setUpPage.ReadData();
        }       
    }
}
