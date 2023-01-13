using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public class MQTTTestsSteps
    {
        #region 
        private IWebDriver driver;
        WindowAppServices winApp = null;
        string equipmentName = string.Empty;
        string testFolderName = "VI Testing";
        Simulator simulator = new Simulator();
        HomePage homePage;
        LoginPage loginPage;
        LoggingPage loggingPage;
        VIManagementPage viPage;
        HistorianPage historianPage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        SetUpPage setUpPage;
        ReportPage reportPage;
        string iPAdress = SpecflowHooks.HostIpAddress();

#endregion
        public MQTTTestsSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            setUpPage = new SetUpPage(driver);
            historianPage = new HistorianPage(driver);
            loggingPage = new LoggingPage(driver);
            reportPage = new ReportPage(driver);
        }

        [When(@"I launch and connect SSMS")]
        public void WhenILaunchAndConnectSSMS()
        {
            //Create 
            winApp = new WindowAppServices();
            winApp.LaunchSSMS();
            //Waits.Wait(driver, 2000);
            //winApp.SelectAuthenticationSQLLogin();
            //Waits.Wait(driver, 1000);
            winApp.SQLLogging();
            //Expand 
            Waits.Wait(driver, 2000);
            winApp.ExpandSqlServerTrees("Databases");
            Waits.Wait(driver, 1000);
            
        }

        [Then(@"I insert group permission to enable VI Management")]
        public void ThenIInsertGroupPermissionToEnableVIManagement()
        {
            winApp.EnableVIManagmentInSSMS("scada_Production");
            winApp.CloseSSMSWithoutSave();
            //Assert.IsTrue(GCNotificationStatus, "Verified command executed successfully");
        }

        [When(@"I Open EDCENTRA application and I enter the username as '(.*)' and password as '(.*)' and clicked login button")]
        public void WhenIOpenEDCENTRAApplicationAndIEnterTheUsernameAsAndPasswordAsAndClickedLoginButton(string username, string password)
        {
            PageInitialization();
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);
            loginPage.SignIn(username, password);
        }

        [Then(@"I click Configure to see VI Management")]
        public void ThenIClickConfigureToSeeVIManagement()
        {
            try
            {
                homePage.ClickOnConfiguration();
                homePage.ClickOnVIManagement();
            }
            catch
            {
                Assert.IsTrue(false, "VI Management is not visible in EdCentra");
            }
        }


        [Given(@"Open EDCENTRA application URL in the browser")]
        public void GivenOpenEDCENTRAApplicationURLInTheBrowser()
        {
            PageInitialization();
            driver.Navigate().GoToUrl("http://localhost/EdwardsScada/");
        }

        //Agent MQTT configuration
        [When(@"I run Agent Configuration \(shortcut on desktop\)")]
        public void WhenIRunAgentConfigurationShortcutOnDesktop()
        {
            simulator.LaunchAgent();
            Waits.Wait(driver, 1000);
            Assert.IsTrue(simulator.AgentConfigurationWindowIsExist(), "Verified Scada Agent Configuration window opened Successfully");
            Waits.Wait(driver, 1000);
        }

        [When(@"I set pin value '(.*)'")]
        public void WhenISetPinValue(int pin)
        {
            simulator.SetPin(pin);
            Waits.Wait(driver, 80000);
        }

        [When(@"I added '(.*)' agents")]
        public void WhenIAddedAgents(string agent)
        {
            simulator.UpdatedAgent(agent);
        }

        [When(@"I selected PC Interface Network Id card under Relay tab")]
        public void WhenISelectedPCInterfaceNetworkIdCardUnderRelayTab()
        {
            simulator.SelectPCNetworkInterfaceCard();
            simulator.KillProcess();
        }


        //Commission Device
        [When(@"I enter the username as '(.*)' and password as '(.*)' and clicked login button")]
        public void WhenIEnterTheUsernameAsAndPasswordAsAndClickedLoginButton(string username, string password)
        {
            loginPage.SignIn(username, password);
        }
        
        [When(@"I click the DeviceExplorer link")]
        public void WhenIClickTheDeviceExplorerLink()
        {
            homePage.ClickOnDeviceExplorer();
        }
        
        [When(@"I click on the system icon - Add Folder")]
        public void WhenIClickOnTheSystemIcon_AddFolder()
        {
            deviceExplorerNavigationPage.ClickOnPlusToAddFolder();
            Waits.Wait(driver, 1000);
        }
        
        [When(@"I entered the folder name and clicked on Add button")]
        public void WhenIEnteredTheFolderNameAndClickedOnAddButton()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            //Delete the existing folder then add the same folder name
            try
            {
                //deviceExplorerNavigationPage.LinkHomePage.Click();
                //homePage.ClickOnDeviceExplorer();
                //deviceExplorerNavigationPage.CheckAndDeleteFolder(testFolderName);
            }
            catch
            {

            }
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.EnterFolderName(testFolderName);
            Waits.Wait(driver, 2000);
        }
        
        [When(@"I clicked the OK button")]
        public void WhenIClickedTheOKButton()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.BtnOK, 3000);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }
        
        [When(@"I clicked the Find Equipment")]
        public void WhenIClickedTheFindEquipment()
        {
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.ClickFindEquipment(testFolderName);
        }
        
        [When(@"I delete all the existing Equipments")]
        public void WhenIDeleteAllTheExistingEquipments()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            deviceExplorerNavigationPage.DeleteAllEquipments(driver);
            Waits.Wait(driver, 3000);
        }
        
        [When(@"I run the VIsimulator to get the VI device communicating with EdCentra")]
        public void WhenIRunTheVIsimulatorToGetTheVIDeviceCommunicatingWithEdCentra()
        {
            simulator.LaunchandStartVISimulator();
            simulator.MinimizeSimulator();
        }
        
        [When(@"I configure (.*) in VISimulator to disconnect the connectivity")]
        public void WhenIConfigureInVISimulatorToDisconnectTheConnectivity(int p0)
        {
            simulator.VISimulatorConnectivity();
        }
        
        [Then(@"I should be navigated to the DeviceExplorer page in EdCentra")]
        public void ThenIShouldBeNavigatedToTheDeviceExplorerPageInEdCentra()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkAddFolder);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LnkAddFolder), "Verifying User should be navigated to Device Explorer page");
            Waits.Wait(driver, 1000);
        }
        
        [Then(@"I should be able to see the folder added successfully message")]
        public void ThenIShouldBeAbleToSeeTheFolderAddedSuccessfullyMessage()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            bool res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(res, "Verifying 'Folder Added Successfully' message");
        }
        
        [Then(@"I should be able to see the newly added Folder")]
        public void ThenIShouldBeAbleToSeeTheNewlyAddedFolder()
        {
            Waits.Wait(driver, 8000);
            Assert.IsTrue(driver.PageSource.Contains(testFolderName), "Verifying added folder");
        }
        
        [Then(@"I commission the VISimulator as equipment Name '(.*)' equipmentType '(.*)' and serial number '(.*)'")]
        public void ThenICommissionTheVISimulatorAsEquipmentNameEquipmentTypeAndSerialNumber(string equipName, string equipType, string serial)
        {
            Thread.Sleep(2000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkNavigate);
            Thread.Sleep(2000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Thread.Sleep(2000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            Thread.Sleep(2000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            Thread.Sleep(2000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.TxtBoxEquipmentName);
            Thread.Sleep(2000);
            string equipmentName = ElementExtensions.GetRandomAlphabeticalString(6);
            deviceExplorerNavigationPage.EnterMQTTCommissionDetails(equipName, equipType, serial);
            Thread.Sleep(2000);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 1000);
           
        }
        
        [Then(@"I see the VISimulator connectivity established in folder '(.*)' and the background color is green")]
        public void ThenISeeTheVISimulatorConnectivetyEstablishedInFolderAndTheBackgroundColorIsGreen(string equipName)
        {
            bool status = false;
            equipmentName = equipName;
            setUpPage.ClickOnFolder(equipName);
            Waits.Wait(driver, 2000);
            for (int i = 0; i < 30; i++)
            {
                //Advisory - rgba(204, 204, 255, 1) - checking advisory - #CCCCFF
                //green - rgb(115, 218, 97) - rgba(115, 218, 97, 1)
                Waits.Wait(driver, 1000);
                if (deviceExplorerNavigationPage.VerifyBackgroundColor(setUpPage.LnkSevPage, "rgba(115, 218, 97, 1)"))
                {
                    status = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            Assert.IsTrue(status, "VISimulator folder background color is not green");
        }
        
        [Then(@"I see the background color changed in folder")]
        public void ThenISeeTheBackgroundColorChangedInFolder()
        {
            bool status = false;
            //setUpPage.ClickOnFolder(equipmentName);
            Waits.Wait(driver, 2000);
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 1000);
                //Green is changed to warning during disconnect
                //Warning - yellow
                if (deviceExplorerNavigationPage.VerifyBackgroundColor(setUpPage.LnkSevPage, "rgba(233, 227, 135, 1)"))
                {
                    status = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            simulator.KillProcess();
            Assert.IsTrue(status, "VISimulator folder background color is not yellow (Warning)");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            try
            {
                //deviceExplorerNavigationPage.LinkHomePage.Click();
                homePage.ClickOnDeviceExplorer();
                deviceExplorerNavigationPage.DeleteAddedFolder(testFolderName);
                simulator.KillProcess();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught " + ex.Message);
            }

        }

        //Scenario 3 - DataLogging
        [When(@"I click the Logging option within the \[Configure \\/] menu")]
        public void WhenIClickTheLoggingOptionWithinTheConfigureMenu()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkHomePage);
            homePage.ClickOnConfiguration();
            homePage.ClickOnLogging();
            loggingPage.ClickOnLoggingLink();
        }

        [Then(@"the Logging tab is opened in Configure")]
        public void ThenTheLoggingTabIsOpenedInConfigure()
        {
            Waits.WaitForElementVisible(driver, loggingPage.LnkCreateProfile);
            Assert.IsTrue(loggingPage.LnkCreateProfile.Displayed, "Verifying User should be navigated to logging page");
        }

        [When(@"I Click on the Create Profile button")]
        public void WhenIClickOnTheCreateProfileButton()
        {
            loggingPage.ClickOnCreateProfileOption();
        }

        [Then(@"the Create Profile form is displayed in EdCentra")]
        public void ThenTheCreateProfileFormIsDisplayedInEdCentra()
        {
            Waits.WaitForElementVisible(driver, loggingPage.BtnCreateProfile);
            Assert.IsTrue(loggingPage.BtnCreateProfile.Displayed, "Verified Create Profile form is displayed");
        }

        [When(@"I provide a name '(.*)' and select an equipment type'(.*)' for the profile\. Click Create\.")]
        public void WhenIProvideANameAndSelectAnEquipmentTypeForTheProfile_ClickCreate_(string profileName, string equip)
        {
            Waits.WaitForElementVisible(driver, loggingPage.BtnCreateProfile);
            loggingPage.CreateProfile(profileName, equip);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The form expand and shows the detail tab which lists parameter for the equipment type")]
        public void ThenTheFormExpandAndShowsTheDetailTabWhichListsParameterForTheEquipmentType()
        {
            Waits.WaitForElementVisible(driver, loggingPage.LblDetailTab);
            Assert.IsTrue(loggingPage.LblDetailTab.Displayed, "Verified the form expand and shows detail tab which lists parameter for the equipment type");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta\.Click Apply\.")]
        public void WhenIMakeANumberOfSelectionsFromTheListOfAvailableParametersAndChangeTheValuesForTheNormalAlertAndDelta_ClickApply_(Table table)
        {
            int rowCount = table.RowCount;
            for (int i=0; i<rowCount; i++)
            {
                loggingPage.ParameterSelection(table.Rows[i]["Parameter"], table.Rows[i]["TimeIntervalforNormal"], table.Rows[i]["TimeIntervalforAlert"], table.Rows[i]["TimeIntervalforDelta"]);
                //loggingPage.ParameterSelection(table.Rows[0]["Parameter"], table.Rows[0]["TimeIntervalforNormal"], table.Rows[0]["TimeIntervalforAlert"], table.Rows[0]["TimeIntervalforDelta"]);
                //loggingPage.ClickApplyChanges();
            }
            loggingPage.ClickApplyChanges();

        }

        [Then(@"The screen will show applied values for Normal / Alert and Delta fields for the parameter\.The screen will only list parameters added in profile")]
        public void ThenTheScreenWillShowAppliedValuesForNormalAlertAndDeltaFieldsForTheParameter_TheScreenWillOnlyListParametersAddedInProfile(Table table)
        {
            for (int i = 0; i < 5; i++)
            {

                if (!ElementExtensions.isDisplayed(driver, loggingPage.LblSuccessMessageAfterAddingEquipment))
                {
                    Waits.Wait(driver, 1000);
                    loggingPage.ClickApplyChanges();
                    break;
                }
                else
                {
                    continue;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                Waits.Wait(driver, 1000);
                if (loggingPage.ShowOnlyParameterChkBox.GetAttribute("src").Contains("chk_on"))
                {
                    Assert.IsTrue(loggingPage.SelectedParameterListed(table.Rows[0]["Parameter"]), "Screen present only the selected parameters");
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        [When(@"I click on the Equipments tab")]
        public void WhenIClickOnTheEquipmentsTab()
        {
            loggingPage.NavigateToEquipmentTab();
            Waits.Wait(driver, 1000);
        }

        [Then(@"I should be navigated to the Equipments tab in the page")]
        public void ThenIShouldBeNavigatedToTheEquipmentsTabInThePage()
        {
            Waits.WaitForElementVisible(driver, loggingPage.LnkEquipmentTabNew);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, loggingPage.LnkEquipmentTabNew), "Verifying User should be navigated to EquipmentsTab");
            Waits.Wait(driver, 3000);
        }

        [When(@"I Find the equipment using equipment description and add Equipments '(.*)' to Assigned Equipment list using > and >> button then Click Apply")]
        public void WhenIFindTheEquipmentUsingEquipmentDescriptionAndAddEquipmentsToAssignedEquipmentListUsingAndButtonThenClickApply(string equipment)
        {
            loggingPage.SelectSingleEquipmentAndMoveToAssign(equipment);
        }

        [Then(@"the changes have been applied message will be displayed on the screen")]
        public void ThenTheChangesHaveBeenAppliedMessageWillBeDisplayedOnTheScreen()
        {
            Waits.Wait(driver, 3000);
            Waits.WaitForElementVisible(driver, loggingPage.LblSuccessMessageAfterAddingEquipment);
            Assert.IsTrue(loggingPage.LblSuccessMessageAfterAddingEquipment.Text.Contains(GlobalConstants.ChangesApplied), "Verified the Changes have been applied message is displayed on the screen");
        }

        [When(@"I navigate to Historian -> Equipment Data Select a piece of System and Equipment '(.*)' that is logging data \(and also of which you have another of this exact equipment type\)")]
        public void WhenINavigateToHistorian_EquipmentDataSelectAPieceOfSystemAndEquipmentThatIsLoggingDataAndAlsoOfWhichYouHaveAnotherOfThisExactEquipmentType(string equipment)
        {
            //testFolderName = (string)ScenarioContext.Current["TestFolderName"];

            loggingPage.NavigateToHomePage();
            Waits.Wait(driver, 1000);
            homePage.NavigateToHistorianPage();
            Waits.Wait(driver, 1000);
            historianPage.ExpandSystemsParameter("VI Testing");
            Waits.Wait(driver, 1000);
            historianPage.SelectSingleParameterEquipment(equipment);
            Waits.Wait(driver, 12000);
        }

        [Then(@"Parameter'(.*)'listed of which we have data to plot for the Equipment'(.*)'")]
        public void ThenParameterListedOfWhichWeHaveDataToPlotForTheEquipment(string Parameter, string Equipment)
        {
            for (int i = 1; i <= 10; i++)
            {
                Waits.Wait(driver, 1000);
                if (historianPage.IsSelectedParameterListPresent(Parameter))
                {
                    Assert.IsTrue(historianPage.IsSelectedParameterListPresent(Parameter), "Verified The parameters for that equipment will be displayed");
                    break;
                }
                else
                {
                    driver.Navigate().Refresh();
                    historianPage.SelectSingleParameterEquipment(Equipment);
                    Waits.Wait(driver, 1000);
                    continue;
                }
            }
        }

        [When(@"I click the VI Management option within the \[Configure \\/] menu")]
        public void WhenIClickTheVIManagementOptionWithinTheConfigureMenu()
        {
            //create vi page
            viPage = new VIManagementPage(driver);
           
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkHomePage);
            homePage.ClickOnConfiguration();
            homePage.ClickOnVIManagement();            
        }

        [Then(@"I see the VI Management page")]
        public void ThenISeeTheVIManagementPage()
        {
            //Assert
        }

        [When(@"I click on the device and Details tab")]
        public void WhenIClickOnTheDeviceAndDetailsTab()
        {
            viPage.LnkVIsionBoxes.Click();
            Thread.Sleep(2000);
            viPage.LnkDetailsTab.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I verify the serial number of the device as '(.*)'")]
        public void ThenIVerifyTheSerialNumberOfTheDeviceAs(string expected)
        {
            string serialNumber = viPage.TxtSerialNumber.Text;
            Assert.IsTrue(serialNumber.Equals(expected), "Serial number is verified correctly");
        }

        [Then(@"I verify the part number of the device as '(.*)'")]
        public void ThenIVerifyThePartNumberOfTheDeviceAs(string expected)
        {
            string partNumber = viPage.TxtPartNumber.Text;
            Assert.IsTrue(partNumber.Equals(expected), "Part number is verified correctly");
        }

        //Unit Up Time Verification in Details Tab
        [Then(@"I verify the UnitUpTime of the device updating at regular intervals")]
        public void ThenIVerifyTheUnitUpTimeOfTheDeviceUpdatingAtRegularIntervals()
        {
            string unitNumber = viPage.TxtUnitUpTime.Text;
            //Wait for 10 seconds - time will be refreshed
            Thread.Sleep(10000);
            string newUnitNumber = viPage.TxtUnitUpTime.Text;
            TimeSpan dateTime1 = TimeSpan.Parse(unitNumber);
            TimeSpan dateTime2 = TimeSpan.Parse(newUnitNumber);
            var diffInSeconds = (dateTime1 - dateTime2).TotalSeconds;

            Assert.IsTrue(diffInSeconds.Equals(-10), "Unit Up Time is verified correctly");

            //Delete the VITesting folder
            viPage.LinkHomePage.Click();
        }


        //Assigned Equipment in Administer Tab
        [When(@"I launched Turbo simulator")]
        public void WhenILaunchedTurboSimulator()
        {
            simulator.LaunchTurboWindow();
            Waits.Wait(driver, 2000);
            simulator.StartTurboCommunication();
            Waits.Wait(driver, 2000);
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"I configure Turbo Simulator")]
        public void WhenIConfigureTurboSimulator()
        {
            simulator.RestoreWindow("TURBO");
            simulator.ConfigureSimulator();
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"I select an equipmentName '(.*)' equipmentType '(.*)' device iPPortNumber'(.*)'\.")]
        public void WhenISelectAnEquipmentNameEquipmentTypeDeviceIPPortNumber_(string equipmentName, string equipmentType, string iPPortNumber)
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkNavigate);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.TxtBoxEquipmentName);
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            Waits.Wait(driver, 3000);
        }

        [When(@"I click on the device, Administer tab and Choose button in Assigned Equipment")]
        public void WhenIClickOnTheDeviceAdministerTabAndChooseButtonInAssignedEquipment()
        {
            viPage.LnkVIsionBoxes.Click();
            Waits.Wait(driver, 2000);
            viPage.LnkAdministerTab.Click();
            Waits.Wait(driver, 2000);
            viPage.BtnChooseAssignedEquipment.Click();
            Waits.Wait(driver, 2000);
        }

        [Then(@"I see the Linked System")]
        public void ThenISeeTheLinkedSystem()
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"I click the Find Equipment button")]
        public void WhenIClickTheFindEquipmentButton()
        {
            viPage.BtnFindEquipment.Click();
            Waits.Wait(driver, 2000);
        }

        [Then(@"I see the turbo equipment is listed")]
        public void ThenISeeTheTurboEquipmentIsListed()
        {
            //check if 'no equipment' 
            //Select the equipment
            viPage.SltEquipment.Click();
            Waits.Wait(driver, 2000);
        }

        [When(@"I choose the turbo equipment and click OK button")]
        public void WhenIChooseTheTurboEquipmentAndClickOKButton()
        {
            //ScenarioContext.Current.Pending();
            viPage.ApplyEquipment.Click();
            Waits.Wait(driver, 2000);
            viPage.BtnChangesAppliedOk.Click();
            Waits.Wait(driver, 2000);
        }

        [Then(@"I verify the turbo equipment displayed near Choose button in Assigned Equipment of Administer Tab")]
        public void ThenIVerifyTheTurboEquipmentDisplayedNearChooseButtonInAssignedEquipmentOfAdministerTab()
        {
            //wait for a minute
            Waits.Wait(driver, 10000);
            bool stat = viPage.VerifyAssignedEquipment();
            bool labelstat = ElementExtensions.isDisplayed(driver, viPage.LblTurboAssingedEquipment);
            Assert.IsTrue(stat, "Turbo Image is not found!");
            Assert.IsTrue(labelstat, "Turbo Label Name mismatch!");
        }

        [When(@"I move to Device Explorer and click create commission the VISimulator as equipment Name '(.*)' equipmentType '(.*)' and serial number '(.*)'")]
        public void WhenIMoveToDeviceExplorerAndClickCreateCommissionTheVISimulatorAsEquipmentNameEquipmentTypeAndSerialNumber(string equipName, string equipType, string serial)
        {
            Waits.Wait(driver, 1000);
            viPage.LinkHomePage.Click();
            homePage.ClickOnDeviceExplorer();
            deviceExplorerNavigationPage.SelectFolderMain("VI Testing");

            Thread.Sleep(2000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkNavigate);
            Thread.Sleep(2000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Thread.Sleep(2000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            Thread.Sleep(2000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            Thread.Sleep(2000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.TxtBoxEquipmentName);
            Thread.Sleep(2000);
            string equipmentName = ElementExtensions.GetRandomAlphabeticalString(6);
            deviceExplorerNavigationPage.EnterMQTTCommissionDetailsLinkedSystem(equipName, equipType, serial);
            Thread.Sleep(2000);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 1000);

        }

        [Then(@"I click Linked System Choose button and select Turbo pump to see no equipment listed")]
        public void ThenIClickLinkedSystemChooseButtonAndSelectTurboPumpToSeeNoEquipmentListed()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
