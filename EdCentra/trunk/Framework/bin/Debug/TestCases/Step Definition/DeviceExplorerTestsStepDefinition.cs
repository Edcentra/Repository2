using AventStack.ExtentReports.Gherkin.Model;
using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases
{
    [Binding]
    public sealed class DeviceExplorerTestsStepDefinition
    {
        string testFolderName = ElementExtensions.GetRandomString(4);
        string renameFolder = ElementExtensions.GetRandomString(4);
        LoginPage loginPage;
        HomePage homePage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        UserPage userPage;
        LoggingPage loggingPage;
        LiveAlertsListPage liveAlertsListPage;
        Simulator simulator = new Simulator();
        WindowAppServices winapp = new WindowAppServices();
        string iPAdress = SpecflowHooks.HostIpAddress();
        private IWebDriver driver;

        public DeviceExplorerTestsStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            userPage = new UserPage(driver);
            liveAlertsListPage = new LiveAlertsListPage(driver);
            loggingPage = new LoggingPage(driver);
        }

        [Given(@"I opened EDCENTRA app url")]
        public void GivenIOpenedEDCENTRAAppUrl()
        {
            PageInitialization();
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);
        }

        [When(@"I entered '(.*)' and '(.*)' and clicked login button")]
        public void WhenIEnteredAndAndClickedLoginButton(string username, string password)
        {
            Waits.Wait(driver, 1000);
            loginPage.SignIn(username, password);
        }

        [Then(@"Change the User Preference")]
        public void ThenChangeTheUserPreference()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.Lnkadministrator);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkPreferences);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkPreferences);
            Assert.IsTrue(deviceExplorerNavigationPage.LnkUserPreferences.Displayed, "Verfied User Preference window Open successfully");
            Waits.Wait(driver, 1000);
            deviceExplorerNavigationPage.UpdateUserPreference();
            Waits.Wait(driver, 1000);
        }

        [When(@"I set the User Preferences of Temperature unit to Centigrade")]
        public void WhenISetTheUserPreferencesOfTemperatureUnitToCentigrade()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.Lnkadministrator);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkPreferences);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkPreferences);
            Assert.IsTrue(deviceExplorerNavigationPage.LnkUserPreferences.Displayed, "Verfied User Preference window Open successfully");
            Waits.Wait(driver, 1000);
            deviceExplorerNavigationPage.UpdateUserPreferenceTemperatureUnit("203");
            Waits.Wait(driver, 1000);
        }

        [Then(@"I should be navigated to Home page")]
        public void ThenIShouldBeNavigatedToHomePage()
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            bool res = Waits.WaitForElementVisible(driver, homePage.LnkDeviceManager);
            Assert.IsTrue(res, "Verifying User should be navigated to Home page");
            simulator.KillEISSASimulator();
            Waits.Wait(driver, 2000);
        }

        [When(@"I clicked Device Explorer link")]
        public void WhenIClickedDeviceExplorerLink()
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnDeviceExplorer();
        }

        [Then(@"I should be navigated to Device Explorer page")]
        public void ThenIShouldBeNavigatedToDeviceExplorerPage()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            bool res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkAddFolder);
            Assert.IsTrue(res, "Verifying User should be navigated to Device Explorer page");
        }

        [When(@"I clicked on add folder/ system icon")]
        public void GivenIClickedOnAddFolderSystemIcon()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            deviceExplorerNavigationPage.ClickOnPlusToAddFolder();
            Waits.Wait(driver, 2000);
        }

        [When(@"I Entered folder name and Clicked on Add button")]
        public void WhenIEnteredFolderNameAndClickedOnAddButton()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
              Waits.Wait(driver, 2000); 
            deviceExplorerNavigationPage.EnterFolderName(testFolderName);
            ScenarioContext.Current.Add("TestFolderName", testFolderName);
            //Waits.Wait(driver, 2000);
        }

        [Then(@"I should be able to see Folder Added Successfully message")]
        public void ThenIShouldBeAbleToSeeFolderAddedSuccessfullyMessage()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Displayed);
           // Assert.IsTrue(ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder), "Verifying 'Folder Added Successfully' message");
        }

        [When(@"I clicked OK button")]
        public void WhenIClickOKButton()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [Then(@"I should be able to see newly added folder")]
        public void ThenIShouldBeAbleToSeeNewlyAddedFolder()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(driver.PageSource.Contains(testFolderName), "Verifying added folder");
        }

        [When(@"I click on added folder and rename")]
        public void WhenIClickOnAddedFolderAndRename()
        {
            deviceExplorerNavigationPage.ClickOnFolderHeader(testFolderName);
            deviceExplorerNavigationPage.ClickRename(renameFolder);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnApply);
        }

        [Then(@"I should be able to see Folder Renamed Successfully message and after clicking on Ok button, renamed folder should be displayed")]
        public void ThenIShouldBeAbleToSeeFolderRenamedSuccessfullyMessageAndAfterClickingOnOkButtonRenamedFolderShouldBeDisplayed()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.FolderRenamedMsg), "Verifying Folder Renamed Successfully message");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Assert.IsTrue(driver.PageSource.Contains(renameFolder), "Verifying Renamed folder should be displayed");
            Assert.IsTrue(deviceExplorerNavigationPage.IsFolderHidden(testFolderName), "Verified renamed folder is hidden and ipdated with new name");
        }

        [When(@"I clicked Find Equipment")]
        public void WhenIClickedFindEquipment()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.ClickFindEquipment(testFolderName);
        }

        [When(@"Launched Eissa, started simulator and selected equipment type '(.*)' and device type '(.*)'")]
        public void WhenLaunchedEissaStartedSimulatorAndSelectedEquipmentTypeAndDeviceType(string equipmentType, string deviceType)
        {
            simulator.LaunchSimulator(equipmentType);
            simulator.SelectEquipment(deviceType);
            simulator.MinimizeWindow();
        }

        [When(@"Selected added '(.*)' device")]
        public void WhenSelectedAddedDevice(string equipment)
        {
            try
            {
                Waits.Wait(driver, 8000);
                deviceExplorerNavigationPage.ClickEquipment(equipment);
            }
            catch (StaleElementReferenceException)
            {
                WhenSelectedAddedDevice(equipment);

            }
        }

        [When(@"I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button")]
        public void WhenIEnteredEquipmentNameSelectedEquipmentTypeClikedFindEquipmentButtonSelectedOneEquipmentAndClickedAddButton()
        {
            Waits.Wait(driver, 8000);
            deviceExplorerNavigationPage.AddEquipmentToSystem();
            Waits.Wait(driver, 8000);
        }

        [When(@"I selected the equipment type, entered equipmentName , Cliked Find Equipment button, selected All equipment and clicked Add button")]
        public void WhenISelectedTheEquipmentTypeEnteredEquipmentNameClikedFindEquipmentButtonSelectedAllEquipmentAndClickedAddButton()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.Wait(driver, 5000);
            deviceExplorerNavigationPage.AddAllEquipmentsToSystem();
            Waits.Wait(driver, 8000);
        }

        [When(@"Deleted existing equipment")]
        public void WhenDeletedExistingEquipment()
        {
            deviceExplorerNavigationPage.DeleteAllEquipments(driver);
            Waits.Wait(driver, 3000);
        }

        [When(@"I commissioned device with following details '(.*)', '(.*)'")]
        public void WhenICommissionedDeviceWithFollowingDetails(string equipmentType, string iPPortNumber)
        {            
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.Wait(driver, 2000);
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
            ScenarioContext.Current.Add("EquipmentName", equipmentName);
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            Waits.Wait(driver, 2000);
            if(ElementExtensions.isDisplayed(driver,deviceExplorerNavigationPage.ErrormsgInvalidIPAddress))
            {
                deviceExplorerNavigationPage.TxtBoxIPAddress.SendKeys(iPAdress);
                Waits.Wait(driver, 2000);
            }
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 8000);            
        }

      
        [Then(@"I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed")]
        public void ThenIShouldBeAbleToSeeEquipmentAddedSuccessfullyMessageAndAfterClickingOkButtonAddedEquipmentShouldBeDisplayed()
        {
            Waits.Wait(driver, 1000);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            //var tabs = driver.WindowHandles;
            //if (tabs.Count > 1)
            //{
            //    int totalCount = tabs.Count;

            //    driver.SwitchTo().Window(tabs[totalCount - 1]);
            //}

            Waits.Wait(driver, 2000);
            //Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.EquipmentAddedMsg), "Verifying 'Equipment Added Successfully' message");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 1000);
        }

        [When(@"I selected Remove from Folder and clicked on OK button")]
        public void WhenISelectedRemoveFromFolderAndClickedOnOKButton()
        {
            deviceExplorerNavigationPage.RemoveEquipmentFromSystemWithConformDelete();
        }

        [When(@"I commissioned device with details '(.*)', '(.*)','(.*)','(.*)'")]
        public void WhenICommissionedDeviceWithDetails(string equipmentType, string iPPortNumber, string iPAddress, string equipmentName)
        {
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
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            deviceExplorerNavigationPage.LnkCreateCommission.Click();
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.TxtBoxEquipmentName);
            Assert.AreEqual("SECSGEM", deviceExplorerNavigationPage.DropDownProtocolSelectedText);
            deviceExplorerNavigationPage.EnterCommissionedDetailsWithMappingFile(equipmentName, equipmentType, iPAddress, iPPortNumber);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 2000);
        }

        [Then(@"I should be able to see Equipment Removed Successfully message and Equipment should be removed from device")]
        public void ThenIShouldBeAbleToSeeEquipmentRemovedSuccessfullyMessageAndEquipmentShouldBeRemovedFromDevice()
        {
            Waits.Wait(driver,2000);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.EquipmentRemovedMsg), "Verifying 'Equipment Removed Successfully' message");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [When(@"I clicked header of added folder and clicked Delete option")]
        public void WhenIClickedHeaderOfAddedFolderAndClickedDeleteOption()
        {
            deviceExplorerNavigationPage.ClickOnFolderHeader(testFolderName);
            deviceExplorerNavigationPage.ClickDelete();
        }

        [Then(@"Delete Folder window should appear to confirm your action")]
        public void ThenDeleteFolderWindowShouldAppearToConfirmYourAction()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.WindowDelete);
            Assert.IsTrue(deviceExplorerNavigationPage.WindowDelete.Displayed, "Verified Delete window");
        }

        [When(@"I clicked cancel button")]
        public void WhenIClickedCancelButton()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnCancelOnDeleteWindow);
        }

        [Then(@"Delete Folder window closes and no action is taken")]
        public void ThenDeleteFolderWindowClosesAndNoActionIsTaken()
        {
            Waits.Wait(driver, 2000);
            Assert.IsFalse(deviceExplorerNavigationPage.WindowDelete.Displayed, "Verified Delete window closed");
        }

        [When(@"I clicked the header of the folder again and choose Delete")]
        public void WhenIClickedTheHeaderOfTheFolderAgainAndChooseDelete()
        {
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.ClickOnFolderHeader(testFolderName);
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.ClickDelete();
        }

        [When(@"I clicked OK button in Delete window pop -up")]
        public void WhenIClickedOKButtonInDeleteWindowPop_Up()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnOkDelete);
        }

        [Then(@"Folder Deleted Successfully is displayed and deleted Folder should no longer be visible")]
        public void ThenFolderDeletedSuccessfullyIsDisplayedAndDeletedFolderShouldNoLongerBeVisible()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains("Folder Deleted Successfully"), "Verifying 'Folder Deleted Successfully ' message");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnOK);
            Assert.IsTrue(deviceExplorerNavigationPage.IsFolderHidden(testFolderName), "Verified folder shouldn't be present after delete action");
        }

        [When(@"I Added user in group with details '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' and '(.*)' and group details '(.*)' and '(.*)'")]
        public void WhenIAddedUserInGroupWithDetailsAndAndGroupDetailsAnd(string userName, string pwd, string confirmPwd, string question, string ans, string firstName, string lastName, string email, string groupName, string groupDescripton)
        {
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            Waits.WaitAndClick(driver, userPage.LnkMaintainUser);
            userPage.CreateNewUser(userName, pwd, confirmPwd, question, ans, firstName, lastName, email);
            userPage.ClickOnApplyChanges();
            Waits.WaitAndClick(driver, userPage.LnkMaintainGroup);
            userPage.CreateNewGroup(groupName, groupDescripton);
            userPage.AddUserInGroup(firstName, lastName, userName);
            userPage.ApplicationPermission();
        }

        [When(@"I clicked the header of the folder and this choose Edit Notes/Location")]
        public void WhenIClickedTheHeaderOfTheFolderAndThisChooseEditNotesLocation()
        {
            deviceExplorerNavigationPage.ClickOnFolderHeader(testFolderName);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkEditNotesLocation);
        }

        [When(@"I clicked the header of the folder and this choose Share Folder")]
        public void WhenIClickedTheHeaderOfTheFolderAndThisChooseShareFolder()
        {
            deviceExplorerNavigationPage.ClickOnFolderHeader(testFolderName);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkShareFolder);
        }

        [Then(@"Share Folder Foldername pop-up should be displayed with available and granted list\.")]
        public void ThenShareFolderFoldernamePop_UpShouldBeDisplayedWithAvailableAndGrantedList_()
        {
            deviceExplorerNavigationPage.PopUpShareFolder.Text.Contains("Share Folder " + testFolderName);
        }

        [Then(@"Edit Notes/Location pop-up should be displayed")]
        public void ThenEditNotesLocationPop_UpShouldBeDisplayed()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.PopUpEditLocation.Displayed, "Edit Notes/Location Popup not displayed");
        }

        [When(@"I enter notes as ""(.*)"" on the EditNotesLocation section and click apply button")]
        public void WhenIEnterNotesAsOnTheEditNotesLocationSectionAndClickApplyButton(string notesText)
        {
            deviceExplorerNavigationPage.EnterNotesAndClickApply(notesText);
        }

        [Then(@"I selected previously created Group \('(.*)'\) from available list and transfered it to granted list and pressed Apply\.")]
        public void ThenISelectedPreviouslyCreatedGroupFromAvailableListAndTransferedItToGrantedListAndPressedApply_(string grpName)
        {
            deviceExplorerNavigationPage.selectGroupToshareFolder(grpName);
            Waits.Wait(driver, 2000);
        }

        [When(@"I selected previously created Group '(.*)' '(.*)' and '(.*)' from available list and transfered it to granted list and pressed Apply\.")]
        public void ThenISelectedPreviouslyCreatedGroupAndFromAvailableListAndTransferedItToGrantedListAndPressedApply_(string firstName, string lastName, string userName)
        {
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.selectUserToshareFolder(firstName, lastName, userName);
        }

        [Then(@"Changes should be saved\.")]
        public void ThenChangesShouldBeSaved_()
        {
            Waits.Wait(driver, 4000);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.ChangesApplied), "Verified changes saved message");
        }

        [Then(@"notes should be saved")]
        public void ThenNotesShouldBeSaved()
        {
            Waits.Wait(driver, 4000);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.NoteAddedMsg), "Verified Notes added message");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [Then(@"message pop- up should be closed")]
        public void ThenMessagePop_UpShouldBeClosed()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LinktTopLevel.Displayed, "Verified Top level link in Device explorer page");
        }

        [When(@"I clicked on Home Icon in top navigation menubar")]
        public void WhenIClickedOnHomeIconInTopNavigationMenubar()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LinkHomePage);
        }

        [When(@"I clicked on user and selected logout option")]
        public void WhenIClickedOnUserAndSelectedLogoutOption()
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, homePage.LnkLoginUser);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, homePage.LnkLoginUser);
            homePage.LnkLoginUser.Click();
            ElementExtensions.MouseHover(driver, homePage.LinkLogout);
            Waits.Wait(driver, 2000);
            homePage.LinkLogout.Click();
        }

        [Then(@"I should be able to see Set Memorable Information window")]
        public void ThenIShouldBeAbleToSeeSetMemorableInformationWindow()
        {
            Assert.IsTrue(loginPage.LblsetMemorableInformation.Displayed, "Verified  Set Memorable Information label ");
        }

        [When(@"I entered memorable question '(.*)', memorable answer '(.*)' and reentered password '(.*)'")]
        public void WhenIEnteredMemorableQuestionMemorableAnswerAndReconfirmedPassword(string memorableQuestion, string memorableAnswer, string reEnterPwd)
        {
            loginPage.TxtMemorableQuestion.SendKeys(memorableQuestion);
            loginPage.TxtMemorableAnswer.SendKeys(memorableAnswer);
            loginPage.TxtReEnterPassword.SendKeys(reEnterPwd);
        }

        [When(@"clicked Apply button")]
        public void WhenClickedApplyButton()
        {
            Waits.Wait(driver, 1000);
            loginPage.BtnApply.Click();
        }

        [Then(@"Successful message '(.*)' should appear")]
        public void ThenSuccessfulMessageShouldAppear(string message)
        {
            Assert.IsTrue(loginPage.LblConfirmationMessage.Text.Contains(message), "Verifying 'Your Memorable Question has been updated' message");
        }

        [When(@"I clicked on OK button")]
        public void WhenIClickedOnOKButton()
        {
            loginPage.BtnOk.Click();
        }

        [When(@"I clicked on Home Icon in top navigation menubar on UserPage")]
        public void WhenIClickedOnHomeIconInTopNavigationMenubarOnUserPage()
        {
            // JavaScriptExecutor.JavaScriptScrollToElement(driver, userPage.LblUserManager);
            ElementExtensions.MouseHover(driver, userPage.LinkHomePage);
            userPage.LinkHomePage.Click();
        }


        [Then(@"I should be navigated to login page")]
        public void ThenIShouldBeNavigatedToLoginPage()
        {
            Waits.Wait(driver, 4000);
            Assert.IsTrue(loginPage.TxtLoginUserName.Displayed, "Verified user is navigated tologin page");
        }

        [Then(@"I should be able to see added folder in previous steps")]
        public void ThenIShouldBeAbleToSeeAddedFolderInPreviousSteps()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.IsFolderPresent(testFolderName), "Verified added folder in previous steps");
        }

        [When(@"I add new User with details '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' and '(.*)'")]
        public void WhenIAddNewUserWithDetailsAnd(string userName, string pwd, string confirmPwd, string question, string ans, string firstName, string lastName, string email)
        {
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            userPage.LnkMaintainUser.Click();
            userPage.CreateNewUser(userName, pwd, confirmPwd, question, ans, firstName, lastName, email);
            userPage.ClickOnApplyChanges();
            Waits.Wait(driver, 4000);
            userPage.LnkPermission.Click();
            Waits.WaitForElementVisible(driver, userPage.SelectAllCheckBox);
            Waits.Wait(driver, 4000);
            for (int i = 0; i < 5; i++)
            {
                if (!userPage.SelectAllCheckBox.GetAttribute("src").Contains("chk_on"))
                {
                    userPage.SelectAllCheckBox.Click();
                    Waits.Wait(driver, 4000);
                }
                else
                {
                    break;
                }
            }

            Waits.WaitForElementVisible(driver, userPage.BtnApplyChange);
            userPage.BtnApplyChange.Click();
            Waits.WaitForElementVisible(driver, userPage.LblChangesApplied);
            Assert.IsTrue(userPage.LblChangesApplied.Text.Contains(GlobalConstants.ChangesApplied), "Verified 'Changes have been applied' message");
        }

        [When(@"I clicked on added equipment")]
        public void WhenIClickedOnAddedEquipment()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.TxtAreaEquipment);
            deviceExplorerNavigationPage.TxtAreaEquipment.Click();
        }

        [Then(@"Status should be running and alarm should be enabled")]
        public void ThenStatusShouldBeRunningAndAlarmShouldBeEnabled()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblStatus);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblStatus, "Running"), "Verified running status");
            Assert.IsTrue(deviceExplorerNavigationPage.IconAlarm.Enabled, "Verified Alarm should be enabled");
        }

        [Then(@"I should be navigated to SEV page")]
        public void ThenIShouldBeNavigatedToSEVPage()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.TabOverview);
            Assert.IsTrue(deviceExplorerNavigationPage.TabOverview.Displayed, "Verified Overview tab on SEV page");
        }

        [When(@"I selected one of the options '(.*)' from the serial number drop-down")]
        public void WhenISelectedOneOfTheOptionsFromTheSerialNumberDrop_Down(string option)
        {
            ElementExtensions.SelectByText(deviceExplorerNavigationPage.DrpdwnSerialNumber, option);
        }

        [When(@"I selected one of the options '(.*)' from the serial number dropdown")]
        public void WhenISelectedOneOfTheOptionsFromTheSerialNumberDropdown(string option)
        {
            ElementExtensions.SelectByText(deviceExplorerNavigationPage.DrpdwnSerialNumber, option);

        }

        [Then(@"The textbox next to the serial number drop-down should display ""(.*)""\.")]
        public void ThenTheTextboxNextToTheSerialNumberDrop_DownShouldDisplay_(string text)
        {
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyAttributeValue(deviceExplorerNavigationPage.TxtBoxSerialNumber, text), "Verifeed serial number text");
        }

        [Then(@"The textbox next to the serial number drop-down should briefly say Retrieving then come back with the result\.")]
        public void ThenTheTextboxNextToTheSerialNumberDrop_DownShouldBrieflySayRetrievingThenComeBackWithTheResult_()
        {
            Assert.AreEqual("Retrieving...", deviceExplorerNavigationPage.TxtBoxSerialNumber.GetAttribute("value"), "Verified Retrieving text");
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyAttributeValue(deviceExplorerNavigationPage.TxtBoxSerialNumber, "Test:Booster Inverter State Serial Number0 176,4"), "Verifeed serial number text");
        }

        [When(@"I clicked Parameters tab")]
        public void WhenIClickedParametersTab()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkParameters);
        }

        [Then(@"Parameters page should show with all of the parameters for the piece of equipment")]
        public void ThenParametersPageShouldShowWithAllOfTheParametersForThePieceOfEquipment()
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(deviceExplorerNavigationPage.LblMBTemp.Displayed, "Verified MB Temp field on Parameters tab");
            Assert.IsTrue(deviceExplorerNavigationPage.LblExhaustPressure.Displayed, "Verified Exhaust Pressure field on Parameters tab");
            Assert.IsTrue(deviceExplorerNavigationPage.LblDryPumpCurrent.Displayed, "Verified Dry Pump Current field on Parameters tab");
            Assert.IsTrue(deviceExplorerNavigationPage.LblDryPumpPower.Displayed, "Verified Dry Pump Power field on Parameters tab");
            Assert.IsTrue(deviceExplorerNavigationPage.LblMBInverterSpeed.Displayed, "Verified MB inverter Speed field on Parameters tab");
        }

        [When(@"I clicked the Guage tab")]
        public void WhenIClickedTheGuageTab()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkGuages);
        }

        [Then(@"Gauges page should show with all of the gauged parameters for the piece of equipment")]
        public void ThenGaugesPageShouldShowWithAllOfTheGaugedParametersForThePieceOfEquipment()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblMBTempGuages);
            Assert.IsTrue(deviceExplorerNavigationPage.LblMBTempGuages.Displayed, "Verified Guage MB  temperature ");
        }

        [Then(@"should see a drop-down box with a list of parameters that you can add to the graph")]
        public void ThenShouldSeeADrop_DownBoxWithAListOfParametersThatYouCanAddToTheGraph()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.DrpDwnSelectParameters);
            Assert.IsTrue(deviceExplorerNavigationPage.DrpDwnSelectParameters.Displayed, "Verified selection parameters dropdown");
        }

        [When(@"I clicked the Graph tab")]
        public void WhenIClickedTheGraphTab()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkGraph);
        }

        [Then(@"I should be able to see Reset button")]
        public void ThenIShouldBeAbleToSeeResetButton()
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(deviceExplorerNavigationPage.BtnResetGraph.Displayed, "Verified Reset button");
        }

        [When(@"I clicked Reset button")]
        public void WhenIClickedResetButton()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnResetGraph);
        }

        [Then(@"The graph should be removed and you will be left with the ""(.*)"" drop-down and graph plaeholder image\.")]
        public void ThenTheGraphShouldBeRemovedAndYouWillBeLeftWithTheDrop_DownAndGraphPlaeholderImage_(string p0)
        {
            bool res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.DrpDwnSelectParameters);
            Assert.IsTrue(res, "Verified selection parameters dropdown");
            Assert.IsTrue(!ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.BtnResetGraph), "Reset button is displaying");
        }
        [When(@"I selected MB Temp \(ºC\) clicked the Add button")]
        public void ThenISelectedMBTempºCClickedTheAddButton()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.DrpDwnSelectParameters);
            ElementExtensions.SelectByIndex(deviceExplorerNavigationPage.DrpDwnSelectParameters, 0);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnAddGraph);
        }

        [Given(@"Turbo agent up and running")]
        public void GivenTurboAgentUpAndRunning()
        {
            simulator.LaunchTurboWindow();
            Thread.Sleep(2000);
            simulator.StartTurboCommunication();
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"I clicked on Add button, selected create/commission and provided all required parameters '(.*)', ""(.*)"" and clicked on Add button")]
        public void WhenIClickedOnAddButtonSelectedCreateCommissionAndProvidedAllRequiredParametersAndClickedOnAddButton(string equipmentType, string iPPortNumber)
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkAddDevice);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            deviceExplorerNavigationPage.LnkCreateCommission.Click();
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.TxtBoxEquipmentName);
            string equipmentName = ElementExtensions.GetRandomAlphabeticalString(6);
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
        }

        [Then(@"device should be commissioned and appropriate message should be displayed")]
        public void ThenDeviceShouldBeCommissionedAndAppropriateMessageShouldBeDisplayed()
        {
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 3000);
        }

        [When(@"I clicked the header of the folder selected decommission")]
        public void WhenIClickedTheHeaderOfTheFolderSelectedDecommission()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblEquipment);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkDecommission);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkDecommission);
        }

        [When(@"I clicked the header of the folder selected Map SECS/GEM VIDs")]
        public void WhenIClickedTheHeaderOfTheFolderSelectedMapSECSGEMVIDs()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblEquipment);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkMapSecsGemVID);
            
        }

        [Then(@"device should be decommissioned and appropriate message should be displayed")]
        public void ThenDeviceShouldBeDecommissionedCommissionedAndAppropriateMessageShouldBeDisplayed()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.BtnOkOnDecommissionPopUP);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.BtnOkOnDecommissionPopUP);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains("The equipment has been decommissioned successfully."), "Verified 'The equipment has been decommissioned successfully.'");
            Waits.Wait(driver, 3000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnOK);
        }

        [When(@"I selected comissioned option and provided all required parameters '(.*)','(.*)', '(.*)', '(.*)' and clicked on Add button")]
        public void WhenISelectedComissionedOptionAndProvidedAllRequiredParametersAndClickedOnAddButton(string equipmentName, string equipmentType, string iPAdress, string iPPortNumber)
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkCommission);
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
        }

        [When(@"deleted all equipments")]
        public void WhenDeletedAllEquipments()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            deviceExplorerNavigationPage.DeleteAllEquipments(driver);
            Waits.Wait(driver, 6000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkNavigate);
           // JavaScriptExecutor.JavaScriptLinkClick(driver, deviceExplorerNavigationPage.LnkNavigate);
            var tabs = driver.WindowHandles;
            if (tabs.Count > 1)
            {
                int totalCount = tabs.Count;
                driver.SwitchTo().Window(tabs[totalCount-1]);     
            }
            Waits.Wait(driver, 1000);
            JavaScriptExecutor.JavaScriptLinkClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            deviceExplorerNavigationPage.ClickOnGetEquipment();
            Waits.Wait(driver, 2000);
            if (!ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.MsgNoEquipmentFound))
            {
                Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnCancelAddEquipment);
                deviceExplorerNavigationPage.DeleteAllEquipments(driver);
                Waits.Wait(driver, 6000);
            }
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnCancelAddEquipment);
            Waits.Wait(driver, 2000);
        }


        [When(@"I set up user who has Device Explorer permission with details (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenISetUpUserWhoHasPermissionToDeviceExplorerViewAndMaintenancePermissionWithDetailsTestuserTestTestTestUserTestuserAtlascopco_ComDeviceExplorerViewCommission
            (string username, string password, string confirmPassword, string question, string ans, string firstName, string lastName, string email, string feature, string column1, string column2)
        {
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            userPage.LnkMaintainUser.Click();
            userPage.CreateNewUser(username, password, confirmPassword, question, ans, firstName, lastName, email);
            userPage.ClickOnApplyChanges();
            Waits.WaitForElementVisible(driver, userPage.LnkPermission);
            userPage.LnkPermission.Click();
            Waits.Wait(driver, 5000);
            Waits.WaitForElementVisible(driver, userPage.LnkPermission);
            userPage.SelectPermissionCheckBoxes("user permission", feature, column1);
            Waits.Wait(driver, 2000);
            userPage.BtnApplyChange.Click();
            Waits.Wait(driver, 15000);
            if (column2.Equals("Commission"))
            {
                userPage.ChkBoxCommissionPermission.Click();
            }
            userPage.SelectPermissionCheckBoxes("user permission", feature, column2);
            Waits.Wait(driver, 4000);
            userPage.BtnApplyChange.Click();
            Waits.Wait(driver, 4000);
            Assert.IsTrue(userPage.LblChangesApplied.Text.Contains(GlobalConstants.ChangesApplied), "Verified 'Changes have been applied' message");
        }


        [When(@"I selected previously created user (.*), (.*) and (.*) from available list and transfered it to granted list and pressed Apply\.")]
        public void ThenISelectedPreviouslyCreatedUserTestUserAndTestuserFromAvailableListAndTransferedItToGrantedListAndPressedApply_(string firstName, string lastName, string userName)
        {
            deviceExplorerNavigationPage.selectUserToshareFolder(firstName, lastName, userName);
        }

        [When(@"entered (.*) and (.*) and clicked login button")]
        public void WhenEnteredTestuserAndTestAndClickedLoginButton(string username, string password)
        {
            loginPage.SignIn(username, password);
        }

        [When(@"I entered memorable question '(.*)', memorable answer '(.*)' and reenter password (.*)")]
        public void WhenIEnteredMemorableQuestionMemorableAnswerAndReenterPasswordTest(string memorableQuestion, string memorableAnswer, string reEnterPwd)
        {
            loginPage.TxtMemorableQuestion.SendKeys(memorableQuestion);
            loginPage.TxtMemorableAnswer.SendKeys(memorableAnswer);
            loginPage.TxtReEnterPassword.SendKeys(reEnterPwd);
        }

        [When(@"I clicked on Top Level link")]
        public void WhenIClickedOnTopLevelLink()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinktTopLevel);
        }

        [Then(@"A context menu opened with the option to Set Maintenance to ON")]
        public void ThenAContextMenuOpenedWithTheOptionToSetMaintenanceToON()
        {
            Thread.Sleep(1000);
            deviceExplorerNavigationPage.ClickOnEquipmentHeader();
            Waits.Wait(driver, 1000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LnkSetMaintenanceOn);
            Assert.IsTrue(deviceExplorerNavigationPage.LnkSetMaintenanceOn.Displayed, "Verified context menu opened with the option to Set Maintenance to ON");
        }

        [When(@"Selected this option to turn Maintenance Mode on")]
        public void WhenSelectedThisOptionToTurnMaintenanceModeOn()
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LnkSetMaintenanceOn);
            deviceExplorerNavigationPage.ClickLinkEquipmentMaintenanceOn("on");
        }

        [Then(@"A message saying that maintenance is set to on is displayed and the item updates to show the maintenance icon")]
        public void ThenAMessageSayingThatMaintenanceIsSetToOnIsDisplayedAndTheItemUpdatesToShowTheMaintenanceIcon()
        {
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.GetConformationMessage().Contains(GlobalConstants.TurnMaintenanceModeOn), "Verified Selected this option to turn Maintenance Mode on");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [When(@"I clicked again Equipment header")]
        public void WhenIClickedAgainEquipmentHeader()
        {
            deviceExplorerNavigationPage.ClickOnEquipmentHeader();
        }

        [Then(@"A context menu opened with the option to Set Maintenance to OFF")]
        public void ThenAContextMenuOpenedWithTheOptionToSetMaintenanceToOFF()
        {
            Waits.Wait(driver, 2000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LnkSetMaintenanceOn);
            Assert.IsTrue(deviceExplorerNavigationPage.LnkSetMaintenanceOff.Displayed, "Verified context menu opened with the option to Set Maintenance to Off");
        }

        [When(@"I selected this option to turn Maintenance Mode off")]
        public void WhenISelectedThisOptionToTurnMaintenanceModeOff()
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LnkSetMaintenanceOn);
            deviceExplorerNavigationPage.ClickLinkEquipmentMaintenanceOn("off");
        }

        [Then(@"A message saying that maintenance is set to off is displayed and the item updates to remove the maintenance icon\.")]
        public void ThenAMessageSayingThatMaintenanceIsSetToOffIsDisplayedAndTheItemUpdatesToRemoveTheMaintenanceIcon_()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(deviceExplorerNavigationPage.GetConformationMessage().Contains(GlobalConstants.TurnMaintenanceModeOff), "Verified Selected this option to turn Maintenance Mode off");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [Then(@"A context menu opened with the option to Delete")]
        public void ThenAContextMenuOpenedWithTheOptionToDelete()
        {
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.ClickOnEquipmentHeader();
            Waits.Wait(driver, 5000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LnkDelete);
            Assert.IsTrue(deviceExplorerNavigationPage.LinkDeleteEquipment.Displayed, "Verified context menu opened with the option to Delete");
        }

        [Then(@"I should get a context menu with Commission or Decommission options depending on the state of the system")]
        public void ThenIShouldGetAContextMenuWithCommissionOrDecommissionOptionsDependingOnTheStateOfTheSystem()
        {
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.ClickOnEquipmentHeader();
            Waits.Wait(driver, 5000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LnkDecommission);
            Waits.Wait(driver, 2000);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LnkDecommission), "Verified context menu opened with the Commison/Decommission option");
            Waits.Wait(driver, 2000);
        }

        [When(@"Navigate to an iXH device in the Device Explorer and drill down to the Single Equipment View and ensure that the SEV is opened displaying the Overview tab")]
        public void WhenNavigateToAnIXHDeviceInTheDeviceExplorerAndDrillDownToTheSingleEquipmentViewAndEnsureThatTheSEVIsOpenedDisplayingTheOverviewTab()
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(deviceExplorerNavigationPage.LblFolderDivison.GetAttribute("title").Contains("iXH DryPump"), "Verified Navigate to an iXH device in the Device Explorer");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.Wait(driver, 1000);
        }

        [Then(@"SEV of selected iXH device opened\. Overview tab is displayed by default")]
        public void ThenSEVOfSelectedIXHDeviceOpened_OverviewTabIsDisplayedByDefault()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LblSEVPage.Displayed, "Verified SEV of selected iXH device opened");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.TabOverview.Displayed, "Verified Overview tab is displayed by default");
            Waits.Wait(driver, 1000);
        }
        [When(@"Launched Eissa on winpro and started simulator")]
        public void WhenLaunchedEissaOnWinproAndStartedSimulator()
        {
            simulator.LaunchSimulatorinWinPro();
            simulator.SelectETXEquipment();
            simulator.MinimizeWindow();
        }

        [When(@"Launched Eissa and started simulator")]
        public void WhenLaunchedEissaAndStartedSimulator()
        {
            simulator.LaunchSimulator();
            simulator.SelectEquipment();
            simulator.MinimizeWindow();
        }

        [When(@"Launched Eissa, started simulator and selected device type '(.*)'")]
        public void WhenLaunchedEissaStartedSimulatorAndSelectedDeviceType(string deviceType)
        {
            simulator.LaunchSimulator();
            simulator.SelectEquipment(deviceType);
            simulator.MinimizeWindow();
            Waits.Wait(driver, 2000);
        }

        [Then(@"I should be able to see legend for added parameter '(.*)'")]
        public void ThenIShouldBeAbleToSeeLegendForAddedParameter(string paramter)
        {
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(paramter), "Paramter legend is not added in the graph");
        }

        [When(@"each default parameter displayed on the Overview tab, using EISSA, change '(.*)' value to '(.*)'")]
        public void WhenEachDefaultParameterDisplayedOnTheOverviewTabUsingEISSAChangeValueTo(string parameter, string value)
        {
            simulator.RestoreWindow();
            Thread.Sleep(1000);
            simulator.SelectParameter(parameter);
            Thread.Sleep(2000);
            simulator.SetParameterValue(value);
            Thread.Sleep(5000);
            simulator.MinimizeWindow();
        }

        [Then(@"verify that the '(.*)' parameter in Edcentra updates to display the correct value '(.*)' as set in EISSA")]
        public void ThenVerifyThatTheParameterInEdcentraUpdatesToDisplayTheCorrectValueAsSetInEISSA(string parameter, string value)
        {
            deviceExplorerNavigationPage.ParameterStatus(parameter);
        }

        [When(@"Using EISSA, change the device status SEV Status field: '(.*)'")]
        public void WhenUsingEISSAChangeTheDeviceStatusSEVStatusField(string status)
        {
            Thread.Sleep(1000);
            simulator.RestoreWindow();
            Thread.Sleep(1000);
            simulator.SetDeviceStatus(status);
            simulator.MinimizeWindow();
        }

        [When(@"I stop the EISSA Stimulator")]
        public void WhenIStopTheEISSAStimulator()
        {
            simulator.RestoreWindow();
            Thread.Sleep(1000);
            simulator.StopSimulator();
            simulator.MinimizeWindow();
            Thread.Sleep(2000);
        }

        [When(@"I start the EISSA Stimulator with device '(.*)'")]
        public void WhenIStartTheEISSAStimulatorWithDevice(string deviceType)
        {
            Thread.Sleep(1000);
            simulator.RestoreWindow();
            Thread.Sleep(1000);

            simulator.SelectEquipment(deviceType);
            simulator.MinimizeWindow();
        }

        [When(@"I Clear the alert for the parameter '(.*)'")]
        public void WhenIClearTheAlertForTheParameter(string parameter)
        {
            Thread.Sleep(2000);
            simulator.RestoreWindow();
            Thread.Sleep(2000);
            simulator.ClearAlert(parameter);
            Thread.Sleep(2000);
            simulator.PressTab();
            simulator.MinimizeWindow();
        }

        [When(@"navigated to Device Explorer-> Overview tab")]
        public void WhenNavigatedToDeviceExplorer_OverviewTab()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkRealTimeMonitoring);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkDeviceExplorer);
        }

        [Then(@"The SEV updates to show the warning alert as '(.*)' and alarm alert as '(.*)' in the overview tab")]
        public void ThenTheSEVUpdatesToShowTheWarningAlertAsAndAlarmAlertAsInTheOverviewTab(string warningCount, string alarmCount)
        {
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblWarningCount, warningCount), "Verified Correct number of Warning alerts displayed in overview");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblAlarmCount, alarmCount), "Verified Correct number of Alaram alerts displayed in overview");
            Waits.Wait(driver, 1000);

        }

        [When(@"Create an '(.*)' Alert for a parameter '(.*)' with alert code '(.*)'")]
        public void WhenCreateAnAlertForAParameterWithAlertCode(string alert, string parameter, string alertCode)
        {
            Waits.Wait(driver, 2000);
            simulator.RestoreWindow();
            Thread.Sleep(1000);
            simulator.RaiseAlert(parameter, alert, alertCode);
            simulator.MinimizeWindow();
        }

        [Then(@"SEV of selected device displayed status selected in the EISSA is updated to '(.*)' and displayed correctly in the Edcentra Device Explorer SEV")]
        public void ThenSEVOfSelectedDeviceDisplayedStatusSelectedInTheEISSAIsUpdatedToAndDisplayedCorrectlyInTheEdcentraDeviceExplorerSEV(string deviceStatus)
        {
           Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblStatus, deviceStatus));
        }

        [Then(@"SEV of selected device displayed\.Each status selected in the EISSA is updated and displayed correctly in the Edcentra Device Explorer SEV")]
        public void ThenSEVOfSelectedDeviceDisplayed_EachStatusSelectedInTheEISSAIsUpdatedAndDisplayedCorrectlyInTheEdcentraDeviceExplorerSEV()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LblStatus.Text.Contains("Network Fault"), "Verified Each status selected in the EISSA is updated and displayed correctly in the Edcentra Device Explorer SEV");
            Waits.Wait(driver, 1000);
        }


        [When(@"Navigate to the SEV view of a valid device")]
        public void WhenNavigateToTheSEVViewOfAValidDevice()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSEVPage);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSEVPage.Displayed, "Verified Navigate to the SEV view of a valid device");
            Waits.Wait(driver, 1000);
        }

        [Then(@"SEV Overview tab displayed")]
        public void ThenSEVOverviewTabDisplayed()
        {
            bool res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.TabOverview);
            Assert.IsTrue(res, "Verified Overview tab is displayed by default");
        }

        [When(@"Select the Serial Number dropdown control and verify that it contains a list of values")]
        public void WhenSelectTheSerialNumberDropdownControlAndVerifyThatItContainsAListOfValues()
        {
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.DrpdwnSerialNumber);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Dropdown control contains a list of values'(.*)' '(.*)' '(.*)'")]
        public void ThenDropdownControlContainsAListOfValues(string value1, string value2, string value3)
        {
            Assert.IsTrue(deviceExplorerNavigationPage.IsDropdownListedParameterValues(value1), "Dropdown control contains a list of values");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.IsDropdownListedParameterValues(value2), "Dropdown control contains a list of values");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.IsDropdownListedParameterValues(value3), "Dropdown control contains a list of values");
            Waits.Wait(driver, 1000);
        }

        [Then(@"each value '(.*)'  '(.*)'  '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' with associate serial number  data is displayed in the serial number field")]
        public void ThenEachValueWithAssociateSerialNumberDataIsDisplayedInTheSerialNumberField(string Parameter1, string serialNum1, string Parameter2, string serialNum2, string Parameter3, string serialNum3, string Parameter4, string serialNum4)
        {
            deviceExplorerNavigationPage.SelectSingleValue(Parameter1);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyAttributeValue(deviceExplorerNavigationPage.TxtBoxSerialNumber, serialNum1), "Verified serial number text");
            Waits.Wait(driver, 1000);

            deviceExplorerNavigationPage.SelectSingleValue(Parameter2);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyAttributeValue(deviceExplorerNavigationPage.TxtBoxSerialNumber, serialNum2), "Verified serial number text");
            Waits.Wait(driver, 1000);

            deviceExplorerNavigationPage.SelectSingleValue(Parameter3);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyAttributeValue(deviceExplorerNavigationPage.TxtBoxSerialNumber, serialNum3), "Verified serial number text");
            Waits.Wait(driver, 1000);
        }

        [When(@"Open a device in SEV and view the Overview Tab")]
        public void WhenOpenADeviceInSEVAndViewTheOverviewTab()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Overview Tab displayed")]
        public void ThenOverviewTabDisplayed()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.TabOverview);
            Assert.IsTrue(deviceExplorerNavigationPage.TabOverview.Displayed, "Verified Overview tab is displayed by default");
        }

        [Then(@"Updates to default parameters displayed correctly")]
        public void ThenUpdatesToDefaultParametersDisplayedCorrectly()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblParameterStatusValue);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblParameterStatusValue, "off"), "Verified Updates to default parameters displayed correctly");
            Waits.Wait(driver, 1000);
        }

        [When(@"Open a device in Single Equipment View Overview Tab")]
        public void WhenOpenADeviceInSingleEquipmentViewOverviewTab()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSEVPage);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSEVPage.Displayed, "Verified Navigate to the SEV view of a valid device");
            Waits.Wait(driver, 1000);
        }

        [When(@"Navigated to '(.*)' tab")]
        public void WhenNavigatedToTab(string tabName)
        {
            if (tabName.Equals(SevTab.Guages.ToString()))
            {
                Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkGuages);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblTemperature);
            }
            else if (tabName.Equals(SevTab.Graph.ToString()))
            {
                Waits.Wait(driver, 2000);
                Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkGraph);
                Waits.Wait(driver, 2000);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.BtnAddGraph);
            }
            else if (tabName.Equals(SevTab.Parameters.ToString()))
            {
                Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkParameters);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblTemperature);
            }
            else if (tabName.Equals(SevTab.Overview.ToString()))
            {
                Waits.WaitAndClick(driver, deviceExplorerNavigationPage.TabOverview);
            }
            else if (tabName.Equals(SevTab.Diagram.ToString()))
            {
                Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkDiagram);
                Waits.Wait(driver,3000);
            }
            else
            {
                Assert.Fail("No tab is there by this name" + tabName);
            }
        }

        [Then(@"Overview tab opened displaying connected device '(.*)'")]
        public void ThenOverviewTabOpenedDisplayingConnectedDevice(string equipmentName)
        {
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblStatus);
            Assert.IsTrue(deviceExplorerNavigationPage.TabOverview.Displayed, "Verified Overview tab is not diplayed");
            Assert.IsTrue(deviceExplorerNavigationPage.LblEquipmentOverview.Text.Contains(equipmentName), "Connected device not displayed in Overview tab");
            Waits.Wait(driver, 2000);
        }

        [When(@"In EISSA, create an advisory alert")]
        public void WhenInEISSACreateAnAdvisoryAlert()
        {
            simulator.RestoreWindow();
            simulator.RaiseAlert("13          (Seals Purge)", "Advisory");
            simulator.MinimizeWindow();
        }

        [Then(@"verify that the display in the device overview updates to show the correct number of alerts")]
        public void WhenVerifyThatTheDisplayInTheDeviceOverviewUpdatesToShowTheCorrectNumberOfAlerts()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LnkAdvisoryCount, "1"), "Verified Correct number of Advisory alerts displayed in overview");
        }

        [Then(@"Then adivisory alert is created, the Overview alert count icon object and the tab background change to lilac")]
        public void ThenThenAdivisoryAlertIsCreatedTheOverviewAlertCountIconObjectAndTheTabBackgroundChangeToLilac()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyBackgroundColor(deviceExplorerNavigationPage.TabOverviewDiv, "rgba(204, 204, 255, 1)"), "Tab Background colour changed to Lilac");
        }

        [Then(@"When a Low Warning alert is created, the Overview alert count object and tab background colour change to yellow")]
        public void ThenWhenALowWarningAlertIsCreatedTheOverviewAlertCountObjectAndTabBackgroundColourChangeToYellow()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyBackgroundColor(deviceExplorerNavigationPage.TabOverviewDiv, "rgba(233, 227, 135, 1)"), "Tab Background colour changed to Yellow");
        }

        [When(@"In EISSA, create Low Warning Alert")]
        public void WhenInEISSACreateLowWarningAlert()
        {
            simulator.RestoreWindow();
            simulator.RaiseAlert("12          (Booster Control)", "LowWarning");
            simulator.PressTab();
            simulator.MinimizeWindow();
        }

        [When(@"Repeat this test for both high and low warning alterts\.")]
        public void WhenRepeatThisTestForBothHighAndLowWarningAlterts_()
        {
            simulator.RestoreWindow();
            Waits.Wait(driver, 2000);
            simulator.RaiseAlert("11          (Dry Pump Control)", "LowWarning");
            simulator.MinimizeWindow();
        }

        [Then(@"SEV updates correctly for both high and low warning alerts\.")]
        public void ThenSEVUpdatesCorrectlyForBothHighAndLowWarningAlerts_()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblWarningCount, "2"), "Verified Correct number of Warning alerts displayed in overview");
        }

        [Then(@"Overview alert icon shows correct alert type and number")]
        public void ThenOverviewAlertIconShowsCorrectAlertTypeAndNumber()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblWarningCount, "1"), "Verified Correct number of Warning alerts displayed in overview");
            Waits.Wait(driver, 1000);
        }

        [When(@"Create an low Alarm Alert on a device")]
        public void WhenCreateAnLowAlarmAlertOnADevice()
        {
            simulator.RestoreWindow();
            simulator.RaiseAlert("9          (MB MotorTemperature)", "LowAlarm");
            simulator.PressTab();
            Thread.Sleep(1000);
            simulator.MinimizeWindow();
        }

        [Then(@"The SEV updates to show the correct number of alerts and alert type")]
        public void ThenTheSEVUpdatesToShowTheCorrectNumberOfAlertsAndAlertType()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblAlarmCount, "1"), "Verified Low alarm count is not displayed correcty");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Alarm Alert is created, the SEV alert count object and tab background colour changes to RED")]
        public void ThenAlarmAlertIsCreatedTheSEVAlertCountObjectAndTabBackgroundColourChangesToRED()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyBackgroundColor(deviceExplorerNavigationPage.TabOverviewDiv, "rgba(255, 153, 153, 1)"), "Tab Background colour changed to Red");
        }

        [Then(@"high alarm alert is created, the diagram tab background colour change to red")]
        public void ThenHighAlarmAlertIsCreatedTheDiagramTabBackgroundColourChangeToYellow()
        {
            Waits.Wait(driver, 4000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyBackgroundColor(deviceExplorerNavigationPage.DiagramTabBody, "rgba(255, 153, 153, 1)"), "Tab Background colour not changed to Red");
        }

        [Then(@"high warning alert is created, the diagram tab background colour change to yellow")]
        public void ThenHighWarningAlertIsCreatedTheDiagramTabBackgroundColourChangeToYellow()
        {
            Waits.Wait(driver, 4000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyBackgroundColor(deviceExplorerNavigationPage.DiagramTabBody, "rgba(233, 227, 135, 1)"), "Tab Background colour not changed to Yellow");
        }


        [Then(@"the image should be visible with non alert status")]
        public void ThenTheImageShouldBeVisibleWithNonAlertStatus()
        {
            Waits.Wait(driver, 6000);
            Assert.IsTrue(deviceExplorerNavigationPage.DiagramImage.Displayed, "In Diagram tab, image not displayed");
        }

        [When(@"Create an High Alarm Alert on a device")]
        [When(@"Repeat this test on both low and high alarm alerts")]
        public void WhenRepeatThisTestOnBothLowAndHighAlarmAlerts()
        {
            Waits.Wait(driver, 2000);
            simulator.RestoreWindow();
            Thread.Sleep(1000);
            simulator.RaiseAlert("8          (Booster Power)", "HighAlarm");
            simulator.MinimizeWindow();
        }

        [When(@"Create an High Warning Alert on a device")]
        public void When()
        {
            Waits.Wait(driver, 2000);
            simulator.RestoreWindow();
            Thread.Sleep(1000);
            simulator.RaiseAlert("8          (Booster Power)", "HighWarning");
            simulator.MinimizeWindow();
        }

        [Then(@"SEV updates correctly for both high and low alarm alerts")]
        public void ThenSEVUpdatesCorrectlyForBothHighAndLowAlarmAlerts()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblAlarmCount, "2"), "Verified Correct number of Alaram alerts not displayed in overview");
        }

        [When(@"Add alerts of each type to a number of attached machines")]
        public void WhenAddAlertsOfEachTypeToANumberOfAttachedMachines()
        {
            simulator.LaunchSimulator();
            simulator.RaiseAllTypeOfAlerts();
        }

        [Then(@"The alert icons display the correct number of alerts of each type")]
        public void ThenTheAlertIconsDisplayTheCorrectNumberOfAlertsOfEachType()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblAdvisoryCount, "1"), "Verified Correct number of Advisory alerts displayed in overview");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblWarningCount, "2"), "Verified Correct number of Warning alerts displayed in overview");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblAlarmCount, "2"), "Verified Correct number of Alaram alerts displayed in overview");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Clear the alert for Booster Power")]
        [When(@"Update the number and type of alerts of each type and verify that the alert icons correctly dislplay the updated numbers")]
        public void WhenUpdateTheNumberAndTypeOfAlertsOfEachTypeAndVerifyThatTheAlertIconsCorrectlyDislplayTheUpdatedNumbers()
        {
            Thread.Sleep(2000);
            simulator.RestoreWindow();
            Thread.Sleep(2000);
            simulator.ClearAlert("8          (Booster Power)");
            Thread.Sleep(2000);
            simulator.PressTab();
            simulator.MinimizeWindow();
        }

        [Then(@"The alert icons correctly dislplay the updated numbers")]
        public void ThenTheAlertIconsCorrectlyDislplayTheUpdatedNumbers()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblAdvisoryCount, "1"), "Verified Correct number of Advisory alerts displayed in overview");
            Waits.Wait(driver, 2000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblWarningCount, "1"), "Verified Correct number of Warning alerts displayed in overview");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblAlarmCount, "1"), "Verified Correct number of Alaram alerts displayed in overview");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click each alert icon and verify that when one ore more alerts exist, the alert list is opened")]
        public void WhenClickEachAlertIconAndVerifyThatWhenOneOreMoreAlertsExistTheAlertListIsOpened()
        {
            deviceExplorerNavigationPage.LblAlarmCount.Click();
            Waits.Wait(driver, 4000);
        }

        [Then(@"When one ore more alerts exist and an alert icon is clicked, the alert list is opened")]
        public void ThenWhenOneOreMoreAlertsExistAndAnAlertIconIsClickedTheAlertListIsOpened()
        {
            Assert.AreEqual(4, liveAlertsListPage.GetAlertsNumber(), "Verified When one ore more alerts exist and an alert icon is clicked, the alert list is not opened");
        }

        [When(@"Ensure that the alert colour updates according to the highest existing alert type")]
        public void WhenEnsureThatTheAlertColourUpdatesAccordingToTheHighestExistingAlertType()
        {
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkRealTimeMonitoring);
            Waits.WaitAndClick(driver, liveAlertsListPage.LnkDeviceExplorer);
            Waits.Wait(driver, 2000);
        }

        [Then(@"The alert colour updates according to the highest existing alert type")]
        public void ThenTheAlertColourUpdatesAccordingToTheHighestExistingAlertType()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyBackgroundColor(deviceExplorerNavigationPage.TabOverviewDiv, "rgba(255, 153, 153, 1)"), "Alert colour changed according to Alarm");
            simulator.RestoreWindow();
            Thread.Sleep(1000);
            simulator.ClearAlert("9          (MB MotorTemperature)");
            Thread.Sleep(1000);
            simulator.PressTab();
                simulator.MinimizeWindow();
            Waits.Wait(driver, 3000);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyBackgroundColor(deviceExplorerNavigationPage.TabOverviewDiv, "rgba(233, 227, 135, 1)"), "Alert colour changed according to Warning");
            Waits.Wait(driver, 1000);
            simulator.RestoreWindow();
            Thread.Sleep(1000);
            simulator.ClearAlert("11          (Dry Pump Control)");
            Thread.Sleep(1000);
            simulator.ClearAlert("12          (Booster Control)");
            Thread.Sleep(2000);
            simulator.PressTab();
            Thread.Sleep(2000);
            simulator.MinimizeWindow();
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyBackgroundColor(deviceExplorerNavigationPage.TabOverviewDiv, "rgba(204, 204, 255, 1)"), "Alert colour changed according to Warning");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select an iXH device and open it in Single Equipement View and then selecte the Parameters tab")]
        public void WhenSelectAnIXHDeviceAndOpenItInSingleEquipementViewAndThenSelecteTheParametersTab()
        {
            //Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSEVPage);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSEVPage.Displayed, "Verified Navigate to the SEV view of a valid device");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkParameters);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Device parameters displayed in SEV Parameters tab")]
        public void ThenDeviceParametersDisplayedInSEVParametersTab()
        {
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

        [When(@"I entered Equipment name, selected equipmentType'(.*)', Cliked Find Equipment button, selected one equipmentName'(.*)' and clicked Add button")]
        public void WhenIEnteredEquipmentNameSelectedEquipmentTypeClikedFindEquipmentButtonSelectedOneEquipmentNameAndClickedAddButton(string equipmentType, string equipmentName)
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            //Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkAddDevice);
           // Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.AddEquipmentToSystem(equipmentType, equipmentName);
            Waits.Wait(driver, 90000);
        }

        [When(@"Select a Facilities Controller device and view its parameters in Single Eqiupment View")]
        public void WhenSelectAFacilitiesControllerDeviceAndViewItsParametersInSingleEqiupmentView()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblFolderDivison);
            Assert.IsTrue(deviceExplorerNavigationPage.LblFolderDivison.GetAttribute("title").Contains("FACILITYCONTROLLER"), "Verified Select a Facilities Controller device");
            Waits.Wait(driver, 3000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            bool res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSEVPage);
            Assert.IsTrue(res, "Verified Navigate to the SEV view of a valid device");
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkParameters);
        }

        [Then(@"Selected device parameters displayed")]
        public void ThenSelectedDeviceParametersDisplayed()
        {
            bool res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblInletThermocouple);
            Assert.IsTrue(res, "Verified Inlet Thermocouple parameter is not displayed");
            Waits.Wait(driver, 1000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblAbatementGreenMode);
            res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblAbatementGreenMode);
            Assert.IsTrue(res, "Verified Abatement Green Mode parameter is not displayed");
            Waits.Wait(driver, 1000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblEZenithPowerExclPumps);
            res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblEZenithPowerExclPumps);
            Assert.IsTrue(res, "Verified EZenith Power Excl. Pumps parameter is not displayed");
            Waits.Wait(driver, 1000);
        }

        [When(@"In Edcentra, select and Atlas Abatement device and open it in SEV Parameters tab")]
        public void WhenInEdcentraSelectAndAtlasAbatementDeviceAndOpenItInSEVParametersTab()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblFolderDivison);
            Assert.IsTrue(deviceExplorerNavigationPage.LblFolderDivison.GetAttribute("title").Contains("ATLAS"), "Verified Select a Atlas Abatement device");
            Waits.Wait(driver, 3000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            bool res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSEVPage);
            Assert.IsTrue(res, "Verified Navigate to the SEV view of a valid device");
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkParameters);
            Waits.Wait(driver, 1000);
        }

        [Then(@"SEV Parameters tab opens and displays selected device parameters")]
        public void ThenSEVParametersTabOpensAndDisplaysSelectedDeviceParameters()
        {
            bool res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblTE406CombustorTemperature);
            Assert.IsTrue(res, "Verified TE406 Combustor Temperatur is not displayed");
            res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblPT306SystemPressure);
            Assert.IsTrue(res, "Verified PT306 System Pressure parameter is not displayed");
            res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblBypassValve1);
            Assert.IsTrue(res, "Verified Bypass Valve 1 parameter is not displayed");
            Waits.Wait(driver, 1000);
        }


        [When(@"Select a equipmentName '(.*)' equipmentType '(.*)' iPAdress '(.*)' device iPPortNumber'(.*)' and open it in SEV, then click on the Parameters tab")]
        public void WhenSelectAEquipmentNameEquipmentTypeIPAdressDeviceIPPortNumberAndOpenItInSEVThenClickOnTheParametersTab(string equipmentName, string equipmentType, string iPAdress, string iPPortNumber)
        {
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            Waits.Wait(driver, 1000);
        }

        [When(@"Turbo Pump device open it in SEV, then click on the Parameters tab")]
        public void WhenTurboPumpDeviceOpenItInSEVThenClickOnTheParametersTab()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSEVPage.Displayed, "Verified Navigate to the SEV view of a valid device");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkParameters);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Device parameters displayed on the Parameters tab")]
        public void ThenDeviceParametersDisplayedOnTheParametersTab()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblTemperature);
            Assert.IsTrue(deviceExplorerNavigationPage.LblTemperature.Displayed, "Verified Selected device parameters displayed");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select an iHX device and open it in the SEV Guages tab")]
        public void WhenSelectAnIHXDeviceAndOpenItInTheSEVGuagesTab()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSEVPage.Displayed, "Verified Navigate to the SEV view of a valid device");
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkGuages);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Guages tab opened displaying selected device parameters")]
        public void ThenGuagesTabOpenedDisplayingSelectedDeviceParameters()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblMBTempGuages);
            Assert.IsTrue(deviceExplorerNavigationPage.LblMBTempGuages.Displayed, "Verified Guages tab opened displaying selected device parameters");
        }

        [Then(@"The guages needle '(.*)'and number displays update to show the correct value '(.*)' set in EISSA for parameter '(.*)'")]
        public void ThenTheGuagesNeedleAndNumberDisplaysUpdateToShowTheCorrectValueSetInEISSAForParameter(string rotation, string value, string parameter)
        {
            Waits.Wait(driver, 1000);
            Assert.AreEqual(value, deviceExplorerNavigationPage.GetGuageValue(parameter, value), "Parameter" + parameter + " changed by Eissa is not displayed correctly on Guage tab");
            Assert.AreEqual(rotation, deviceExplorerNavigationPage.GetGuageNeedlePosition(parameter, rotation), "Parameter" + parameter + " changed by Eissa is not displayed  by needle correctly on Guage tab"
                + "Expected was:" + rotation + "Actual was : " + deviceExplorerNavigationPage.GetGuageNeedlePosition(parameter, rotation));
        }


        [When(@"Select a Facilites Controller device and navigate to the SEV Guages tab")]
        public void WhenSelectAFacilitesControllerDeviceAndNavigateToTheSEVGuagesTab()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblFolderDivison);
            Assert.IsTrue(deviceExplorerNavigationPage.LblFolderDivison.GetAttribute("title").Contains("FACILITYCONTROLLER"), "Verified Select a Facilities Controller device");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
        }

        [Then(@"Guages tab opened displaying patameters of selected device")]
        public void ThenGuagesTabOpenedDisplayingPatametersOfSelectedDevice()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSEVPage);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSEVPage.Displayed, "Verified Navigate to the SEV view of a valid device");
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LinkGuages);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkGuages);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblInletThermocouple1);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblInletThermocouple1);
            Assert.IsTrue(deviceExplorerNavigationPage.LblInletThermocouple1.Displayed, "Inlet Thermocouple 1 is not displayed on screen");
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblPCWInPressureSystem);
            Assert.IsTrue(deviceExplorerNavigationPage.LblPCWInPressureSystem.Displayed, "PCW In Pressure System is not displayed on screen");
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblFT460PumpFrameN2Flow);
            Assert.IsTrue(deviceExplorerNavigationPage.LblFT460PumpFrameN2Flow.Displayed, "FT460 Pump Frame N2 Flow is not displayed on screen");
        }


        [When(@"Select an Atlas Abatement device and navigate to the SEV Guages tab")]
        public void WhenSelectAnAtlasAbatementDeviceAndNavigateToTheSEVGuagesTab()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LblFolderDivison.GetAttribute("title").Contains("ATLAS"), "Verified Select an Atlas Abatement device");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSEVPage);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSEVPage.Displayed, "Verified Navigate to the SEV view of a valid device");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkGuages);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Guages tab opened displaying the parameters for the selected device")]
        public void ThenGuagesTabOpenedDisplayingTheParametersForTheSelectedDevice()
        {
            Waits.Wait(driver, 8000);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LblTemperature);
            Assert.IsTrue(deviceExplorerNavigationPage.LblTE406CombustorTemperature.Displayed, "TE406 Combustor Temperature is not displayed on screen");
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LblPressure);
            Waits.Wait(driver, 5000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblPT306SystemPressure);
            Assert.IsTrue(deviceExplorerNavigationPage.LblPT306SystemPressure.Displayed, "PT306 System Pressure is not displayed on screen");

        }

        [When(@"Select an Atlas Abatement device and open it in SEV Pages Graph Tab and verify that the Select Parameter dropdown control contains the device parameters")]
        public void WhenSelectAnAtlasAbatementDeviceAndOpenItInSEVPagesGraphTabAndVerifyThatTheSelectParameterDropdownControlContainsTheDeviceParameters()
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(deviceExplorerNavigationPage.LblFolderDivison.GetAttribute("title").Contains("ATLAS"), "Verified Select an Atlas Abatement device");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkGraph);
            Waits.Wait(driver, 3000);
            Assert.AreEqual(45, deviceExplorerNavigationPage.GraphParameterDropDown(), "Verified graph parameters count");
            Waits.Wait(driver, 5000);
        }

        [Then(@"Select Parameter'(.*)' dropdown control contains the device parameters")]
        public void ThenSelectParameterDropdownControlContainsTheDeviceParameters(string Parameter)
        {
            Assert.IsTrue(deviceExplorerNavigationPage.ISDropdowndownListedParameters(Parameter), "Verified Select Parameter dropdown control contains the device parameters");
            Waits.Wait(driver, 3000);
        }

        [When(@"refreshed page")]
        public void WhenRefreshedPage()
        {
            driver.Navigate().Refresh();
            Waits.Wait(driver, 8000);
        }

        [When(@"Select a parameter'(.*)' from the dropdown control, click the Add button and verify that the parameter is added to the graph")]
        public void WhenSelectAParameterFromTheDropdownControlClickTheAddButtonAndVerifyThatTheParameterIsAddedToTheGraph(string parameter)
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.BtnAddGraph);
            deviceExplorerNavigationPage.SelectSingleParameterfromDropdown(parameter);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnAddSeries);
            Waits.Wait(driver, 3000);
        }

        [Then(@"The parameter'(.*)' is added to the graph and displayed correctly as '(.*)'\.")]
        public void ThenTheParameterIsAddedToTheGraphAndDisplayedCorrectlyAs_(string parameter, string value)
        {
            Waits.Wait(driver, 30000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter), "Verified the parameter is added to the graph and displayed correctly for parameter " + parameter);
            string tooltip = deviceExplorerNavigationPage.GetToolTipTextWhenAddedMultipleParameters(parameter);
            Assert.AreEqual(value, tooltip, "Parameter graph is not diplayed correctly" + "Expected Value: " + value + "Actual Value: " + tooltip);
        }

        [Then(@"The parameter'(.*)' is added to the graph and displayed correctly as '(.*)'")]
        public void ThenTheParameterIsAddedToTheGraphAndDisplayedCorrectlyAs(string parameter, string value)
        {
            Waits.Wait(driver, 30000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter), "Verified the parameter is added to the graph and displayed correctly for parameter " + parameter);
            string tooltip = deviceExplorerNavigationPage.GetToolTipText(parameter);
            Assert.AreEqual(value, tooltip, "Parameter graph is not diplayed correctly" + "Expected Value: " + value + "Actual Value: " + tooltip);
        }

        [When(@"I clicked reset Graph")]
        public void WhenIClickedResetGraph()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnResetGraph);
            Waits.Wait(driver, 5000);
        }

        [When(@"I clicked legend '(.*)'")]
        public void WhenIClickedLegend(string legend)
        {
            Waits.Wait(driver, 3000);
            deviceExplorerNavigationPage.ClickOnAddedParameterLegend(legend);
            Waits.Wait(driver, 3000);
        }

        [Then(@"corresponding chart data line become invisible")]
        public void ThenCorrespondingChartDataLineBecomeInvisible()
        {
            Assert.IsFalse(deviceExplorerNavigationPage.IsGraphPlotted(), "Chart data line is visible");
        }

        [Then(@"corresponding chart data line become visible")]
        public void ThenCorrespondingChartDataLineBecomeVisible()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.IsGraphPlotted(), "Chart data line is not visible");
        }

        [Then(@"corresponding chart data line become visible\.")]
        public void ThenCorrespondingChartDataLineBecomeVisible_()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.IsGraphPlottedForMultipleParameter(), "Chart data line is invisible");
        }

        [Then(@"corresponding chart data line become invisible\.")]
        public void ThenCorrespondingChartDataLineBecomeInvisible_()
        {
            Assert.IsFalse(deviceExplorerNavigationPage.IsGraphPlottedForMultipleParameter(), "Chart data line is visible");
        }

        [When(@"Select added device and open it in SEV Graph tab")]
        public void WhenSelectAddedDeviceAndOpenItInSEVGraphTab()
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(deviceExplorerNavigationPage.LblFolderDivison.GetAttribute("title").Contains("ATLAS"), "Verified Select an Atlas Abatement device");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkGraph);
            Waits.Wait(driver, 3000);
        }

        [When(@"Selected added '(.*)' device and open it in SEV Graph tab")]
        public void WhenSelectedAddedDeviceAndOpenItInSEVGraphTab(string device)
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblFolderDivison);
            Assert.IsTrue(deviceExplorerNavigationPage.LblFolderDivison.GetAttribute("title").Contains("FACILITYCONTROLLER"), "Verified Select a Facilities Controller device");
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkGraph);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkGraph);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.BtnAddGraph);
        }

        [Then(@"verify that the dropdown control contains the device parameters for device '(.*)'")]
        public void ThenVerifyThatTheDropdownControlContainsTheDeviceParametersForDevice(string device)
        {
            if (device.Equals("NEW0001AC1"))
            {
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkDropdownParameters);
                Assert.AreEqual(56, deviceExplorerNavigationPage.GraphParameterDropDown(), "Verified graph parameters count");
                Waits.Wait(driver, 3000);
            }
            else if (device.Equals("NEW0001FC"))
            {
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkDropdownParameters);
                //  Assert.AreEqual(26, deviceExplorerNavigationPage.GraphParameterDropDown(), "Verified graph parameters count");
                Waits.Wait(driver, 3000);
            }
            else if (device.Equals("NEW0001PM1"))
            {
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkDropdownParameters);
                Assert.AreEqual(15, deviceExplorerNavigationPage.GraphParameterDropDown(), "Verified graph parameters count");
                Waits.Wait(driver, 3000);
            }
        }

        [When(@"Select a parameter'(.*)' from the dropdown control and click the Add button to add the parameter to the graph")]
        public void WhenSelectAParameterFromTheDropdownControlAndClickTheAddButtonToAddTheParameterToTheGraph(string parameter)
        {
            deviceExplorerNavigationPage.SelectSingleParameterfromDropdown(parameter);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnAddSeries);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Parameter'(.*)' added to the graph")]
        public void ThenParameterAddedToTheGraph(string parameter)
        {
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter), "Verified the parameter is added to the graph and displayed correctly");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select an iXH device and navigate to the SEV Graph tab")]
        public void WhenSelectAnIXHDeviceAndNavigateToTheSEVGraphTab()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSEVPage);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSEVPage.Displayed, "Verified Navigate to the SEV view of a valid device");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkGraph);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.BtnAddGraph);
        }

        [When(@"Select a parameter'(.*)' from the dropdown control, click the Add button")]
        public void WhenSelectAParameterFromTheDropdownControlClickTheAddButton(string parameter)
        {
            deviceExplorerNavigationPage.SelectSingleParameterfromDropdown(parameter);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnAddSeries);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Graph tab opened displaying the Select Paramater dropdown and the Add button")]
        public void ThenGraphTabOpenedDisplayingTheSelectParamaterDropdownAndTheAddButton()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblGraphParameters);
            Assert.IsTrue(deviceExplorerNavigationPage.LblGraphParameters.Displayed, "Graph tab opened displaying the Select Paramater dropdown");
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.BtnAddSeries);
            Assert.IsTrue(deviceExplorerNavigationPage.BtnAddSeries.Displayed, "Graph tab opened displaying the Add button");
            Waits.Wait(driver, 2000);
        }

        [When(@"Select a parameter'(.*)' from the dropdown control, click the Add button and verify that the data values for the selected parameter are plotted in a horizontal line with circles representing each data point")]
        public void WhenSelectAParameterFromTheDropdownControlClickTheAddButtonAndVerifyThatTheDataValuesForTheSelectedParameterArePlottedInAHorizontalLineWithCirclesRepresentingEachDataPoint(string parameter)
        {
            deviceExplorerNavigationPage.SelectSingleParameterfromDropdown(parameter);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.BtnAddSeries);
            deviceExplorerNavigationPage.BtnAddSeries.Click();
            Waits.Wait(driver, 1000);
        }

        [Then(@"The selected parameter'(.*)' is added to graph and plotted in a horizontal line with circles representing each data point")]
        public void ThenTheSelectedParameterIsAddedToGraphAndPlottedInAHorizontalLineWithCirclesRepresentingEachDataPoint(string parameter)
        {
            Waits.Wait(driver, 5000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter), "Verified the selected parameter is added to the graph and displayed correctly");
            Waits.Wait(driver, 2000);
        }

        [Then(@"the devices are removed '(.*)' and '(.*)'")]
        public void ThenTheDevicesAreRemovedAnd(string parameter1, string parameter2)
        {
            Waits.Wait(driver, 5000);
            Assert.IsTrue(!deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter1), "Verified the parameter " + parameter1 + " is displayed after clicking reset button");
            Assert.IsTrue(!deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter1), "Verified the parameter " + parameter2 + " is displayed after clicking reset button");
            Assert.AreEqual(false, ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.BtnResetGraph), "Button reset is displayed on screen");
        }

        [When(@"Select an active device and add multiple parameters'(.*)' '(.*)' '(.*)' to the graph and verify that each parameter is added to the graph")]
        public void WhenSelectAnActiveDeviceAndAddMultipleParametersToTheGraphAndVerifyThatEachParameterIsAddedToTheGraph(string parameter1, string parameter2, string parameter3)
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkDropdownParameters);
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter1);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkDropdownParameters);
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter2);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkDropdownParameters);
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter3);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Each paramater '(.*)' '(.*)' '(.*)'  is added to the graph")]
        public void ThenEachParamaterIsAddedToTheGraph(string parameter1, string parameter2, string parameter3)
        {
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter1), "Verified the selected parameter is added to the graph and displayed correctly");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter2), "Verified the selected parameter is added to the graph and displayed correctly");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter3), "Verified the selected parameter is added to the graph and displayed correctly");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select an equipmentName '(.*)' equipmentType '(.*)' iPAdress '(.*)' device iPPortNumber'(.*)' and open it in SEV, then click on the Graph tab")]
        public void WhenSelectAnEquipmentNameEquipmentTypeIPAdressDeviceIPPortNumberAndOpenItInSEVThenClickOnTheGraphTab(string equipmentName, string equipmentType, string iPAdress, string iPPortNumber)
        {
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            Waits.Wait(driver, 1000);
        }

        [When(@"Select on Turbo Pump device and open it in SEV Graph tab")]
        public void WhenSelectOnTurboPumpDeviceAndOpenItInSEVGraphTab()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSEVPage);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSEVPage.Displayed, "Verified Navigate to the SEV view of Turbo device");
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkGraph);
            Waits.Wait(driver, 5000);
        }

        [Then(@"Then Dropdown control contains the Turbo device Turbo parameters '(.*)' '(.*)' '(.*)'")]
        public void ThenThenDropdownControlContainsTheTurboDeviceTurboParameters(string parameter1, string parameter2, string parameter3)
        {
            Assert.IsTrue(deviceExplorerNavigationPage.ISDropdowndownListedParameters(parameter1), "Verified Dropdown control contains the Turbo device Turbo parameters");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISDropdowndownListedParameters(parameter2), "Verified Dropdown control contains the Turbo device Turbo parameters");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISDropdowndownListedParameters(parameter3), "Verified Dropdown control contains the Turbo device Turbo parameters");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select an Turbo device and add multiple parameters '(.*)' '(.*)' '(.*)' to the graph and verify that each parameter is added to the graph")]
        public void WhenSelectAnTurboDeviceAndAddMultipleParametersToTheGraphAndVerifyThatEachParameterIsAddedToTheGraph(string parameter1, string parameter2, string parameter3)
        {
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter1);
            Waits.Wait(driver, 1000);
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter2);
            Waits.Wait(driver, 1000);
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter3);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Each Turbo paramater '(.*)' '(.*)' '(.*)' is added to the graph")]
        public void ThenEachTurboParamaterIsAddedToTheGraph(string parameter1, string parameter2, string parameter3)
        {
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter1), "Verified the selected parameter is added to the graph and displayed correctly");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter2), "Verified the selected parameter is added to the graph and displayed correctly");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter3), "Verified the selected parameter is added to the graph and displayed correctly");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select an FC device and add multiple parameters '(.*)' '(.*)' '(.*)' to the graph and verify that each parameter is added to the graph")]
        public void WhenSelectAnFCDeviceAndAddMultipleParametersToTheGraphAndVerifyThatEachParameterIsAddedToTheGraph(string parameter1, string parameter2, string parameter3)
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkGraph);
            Waits.Wait(driver, 5000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.BtnAddSeries);
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter1);
            Waits.Wait(driver, 1000);
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter2);
            Waits.Wait(driver, 1000);
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter3);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Each FC parameter '(.*)' '(.*)' '(.*)' is added to the graph")]
        public void ThenEachFCParameterIsAddedToTheGraph(string parameter1, string parameter2, string parameter3)
        {
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter1), "Verified FC parameter is added to the graph");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter2), "Verified FC parameter is added to the graph");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter3), "Verified FC parameter is added to the graph");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select an Atlas Abatement device and add multiple parameters '(.*)' '(.*)' '(.*)' to the graph and verify that each parameter is added to the graph")]
        public void WhenSelectAnAtlasAbatementDeviceAndAddMultipleParametersToTheGraphAndVerifyThatEachParameterIsAddedToTheGraph(string parameter1, string parameter2, string parameter3)
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkGraph);
            Waits.Wait(driver, 5000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.BtnAddSeries);
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter1);
            Waits.Wait(driver, 1000);
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter2);
            Waits.Wait(driver, 1000);
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter3);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Each Atlas Abatement parameter '(.*)' '(.*)' '(.*)' is added to the graph")]
        public void ThenEachAtlasAbatementParameterIsAddedToTheGraph(string parameter1, string parameter2, string parameter3)
        {
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter1), "Verified FC parameter is added to the graph");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter2), "Verified FC parameter is added to the graph");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter3), "Verified FC parameter is added to the graph");
            Waits.Wait(driver, 1000);
        }


        [When(@"Add one or more parameters '(.*)' '(.*)' to the Graph")]
        public void WhenAddOneOrMoreParametersToTheGraph(string parameter1, string parameter2)
        {
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter1);
            Waits.Wait(driver, 1000);
            deviceExplorerNavigationPage.SelectSingleParameterfromListed(parameter2);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Paramters '(.*)' '(.*)' added and graph display updated correctly")]
        public void ThenParamtersAddedAndGraphDisplayUpdatedCorrectly(string parameter1, string parameter2)
        {
            deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter1);
            Waits.Wait(driver, 1000);
            deviceExplorerNavigationPage.ISGraphDisplayedParameterNew(parameter1);
            Waits.Wait(driver, 1000);
        }
        [When(@"selected parameter  '(.*)'")]
        public void WhenSelectedParameter(string parameter)
        {
            simulator.RestoreWindow();
            Thread.Sleep(3000);
            simulator.SelectParameter(parameter);
            Waits.Wait(driver, 2000);
        }

        [When(@"each default parameter displayed on the Overview tab, using EISSA, change value to '(.*)'")]
        public void WhenEachDefaultParameterDisplayedOnTheOverviewTabUsingEISSAChangeValueTo(string value)
        {
            simulator.RestoreWindow();
            simulator.SetParameterValue(value);
            simulator.MinimizeWindow();
        }

        [When(@"Raised alert High Alarm on Booster Power, Low alarm on MB Motor Temperature, High Warning on Dry Pump Control,low warning on  Booster Control, Advisory on Seals Purge")]
        public void WhenRaisedAlertHighAlarmOnBoosterPowerLowAlarmOnMBMotorTemperatureHighWarningOnDryPumpControlLowWarningOnBoosterControlAdvisoryOnSealsPurge()
        {
            simulator.RestoreWindow();
            simulator.StopSimulator();
            simulator.RaiseAllTypeOfAlerts();
            Thread.Sleep(1000);
            simulator.MinimizeWindow();
        }

        [Then(@"this updated '(.*)' parameters status to '(.*)'")]
        public void ThenThisUpdatedParametersStatusTo(string parameter, string paramStatus)
        {
            if (parameter.Contains("Dry Pump Control"))
            {
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblDryPumpControlValue, paramStatus), "Paremater status " + paramStatus + " is not displaying correcly");
            }
            else if (parameter.Contains("Booster Control"))
            {
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblBoosterControlValue, paramStatus), "Paremater status " + paramStatus + " is not displaying correcly");
            }
        }

        [Then(@"this has updated '(.*)' parameters status to '(.*)'")]
        public void ThenThisHasUpdatedParametersStatusTo(string parameter, string value)
        {
            Waits.Wait(driver, 7000);
            if (parameter.Contains("Inlet Thermocouple 1"))
            {

                JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblInletThermocouple);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblInletThermocoupleValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblInletThermocoupleValue, value), "Displayed value is not correct for Inlet Thermocouple 1");
            }
            else if (parameter.Contains("Abatement Green Mode"))
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblAbatementGreenMode);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblAbatementGreenModeValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblAbatementGreenModeValue, value), "Displayed value is not correct for Abatement Green Mode");
            }
            else if (parameter.Contains("Active Gauge Pressure"))
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblActiveGaugePressure);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblActiveGaugePressureValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblActiveGaugePressureValue, value), "Displayed value is not correct for Active Gauge Pressure");
            }
            else if (parameter.Contains("HAPS 1 Status"))
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblHAPS1StatusValue);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblHAPS1StatusValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblHAPS1StatusValue, value), "Displayed value is not correct for HAPS 1 Status");
            }
            else if (parameter.Contains("MB Temp"))
            {
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblMBTempValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblMBTempValue, value), "Displayed value is not correct for MB Temperature");
            }
            else if (parameter.Contains("Exhaust Pressure"))
            {
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblExhaustPressureValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblExhaustPressureValue, value), "Displayed value is not correct for Exhaust Pressure Status");
            }
            else if (parameter.Contains("Dry Pump Power"))
            {
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblDryPumpPowerValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblDryPumpPowerValue, value), "Displayed value is not correct for Dry Pump Power");
            }
            else if (parameter.Contains("Dry Pump Current"))
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblDryPumpCurrent);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblDryPumpPowerValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblDryPumpCurrentValue, value), "Displayed value is not correct for Dry Pump Current");
            }
            else if (parameter.Contains("MB Inverter Speed"))
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblMBInverterSpeed);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblMBInverterSpeedValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblMBInverterSpeedValue, value), "Displayed value is not correct for MB Inverter Speed");
            }
            else if (parameter.Contains("Combustor Temperature"))
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblTE406CombustorTemperature);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblTE406CombustorTemperatureValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblTE406CombustorTemperatureValue, value), "Displayed value is not correct for TE406 Combustor Temperature");
            }
            else if (parameter.Contains("System Pressure"))
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblPT306SystemPressure);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblPT306SystemPressureValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblPT306SystemPressureValue, value),
                        "Displayed value is not correct for PT306 System Pressure Actual value is: " + deviceExplorerNavigationPage.LblPT306SystemPressureValue.Text + "Expected value is " + value);
            }
            else if (parameter.Contains("Bypass Valve"))
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblBypassValve1);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblBypassValve1Value);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblBypassValve1Value, value), "Displayed value is not correct for Bypass Valve 1");
            }
            else if (parameter.Contains("EMO"))
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblEMO);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblEMOValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblEMOValue, value), "Displayed value is not correct for EMO");
            }
            else if (parameter.Contains("Quench Water Flow"))
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblFT615QuenchWaterFlow);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblFT615QuenchWaterFlowValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblFT615QuenchWaterFlowValue, value), "Displayed value is not correct for FT615 Quench Water Flow");
            }
            else if (parameter.Contains("Number of Inlets"))
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblNumberOfInlets);
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblNumberOfInletsValue);
                Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(deviceExplorerNavigationPage.LblNumberOfInletsValue, value), "Displayed value is not correct for Number of Inlets");
            }
        }


        [When(@"Choose a turbo device with following details  '(.*)', '(.*)', '(.*)'")]
        public void WhenChooseATurboDeviceWithFollowingDetails(string equipmentType, string iPAdress, string iPPortNumber)
        {
            deviceExplorerNavigationPage.DeleteAllEquipments(driver);
            Waits.Wait(driver, 3000);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            Waits.Wait(driver, 3000);
            string equipmentName = ElementExtensions.GetRandomAlphabeticalString(6);
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            Waits.Wait(driver, 3000);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 5000);
        }

        [When(@"Launched Turbo simulator")]
        public void WhenLaunchedTurboSimulator()
        {
            simulator.LaunchTurboWindow();
            Waits.Wait(driver, 2000);
            simulator.StartTurboCommunication();
            Waits.Wait(driver, 2000);
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"Configure Turbo Simulator")]
        public void WhenConfigureTurboSimulator()
        {
            simulator.RestoreWindow("TURBO");
            simulator.ConfigureSimulator();
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"Select an equipmentName '(.*)' equipmentType '(.*)' device iPPortNumber'(.*)'\.")]
        public void WhenSelectAnEquipmentNameEquipmentTypeDeviceIPPortNumber_(string equipmentName, string equipmentType, string iPPortNumber)
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkNavigate);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.TxtBoxEquipmentName);
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            Waits.Wait(driver, 3000);
        }

        [When(@"Choose a turbo device and navigate to the SEV page")]
        public void WhenChooseATurboDeviceAndNavigateToTheSEVPage()
        {
            Waits.Wait(driver, 140000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.Wait(driver, 1000);
        }

        [Then(@"There should be a \[Measure Tab] visible")]
        public void ThenThereShouldBeAMeasureTabVisible()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LnkMeasure.Displayed, "Verified there should ba a measure tab visibled");
            Waits.Wait(driver, 1000);
        }

        [When(@"Add some non turbo pump devices '(.*)', '(.*)', '(.*)'")]
        public void WhenAddSomeNonTurboPumpDevices(string equipmentType, string iPPortNumber)
        {
            deviceExplorerNavigationPage.NavigateToTopLevel();
            deviceExplorerNavigationPage.ClickFindEquipment(testFolderName);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            string equipmentName = ElementExtensions.GetRandomAlphabeticalString(6);
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 8000);
            deviceExplorerNavigationPage.AddEquipmentToSystem();
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 5000);
        }

        [Then(@"Choose a non turbo device '(.*)' and navigate to the SEV page")]
        public void ThenChooseANonTurboDeviceAndNavigateToTheSEVPage(string equipment)
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(deviceExplorerNavigationPage.LblFolderDivison.GetAttribute("title").Contains(equipment), "Verified Select a Facilities Controller device");
            Waits.Wait(driver, 3000);
            deviceExplorerNavigationPage.LblCreatedFolder.Click();
            Waits.Wait(driver, 1000);
        }

        [Then(@"Choose a non Turbo device and navigate to the SEV view")]
        public void ThenChooseANonTurboDeviceAndNavigateToTheSEVView()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LblCreatedFolder);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The Measure tab will not be visible")]
        public void ThenTheMeasureTabWillNotBeVisible()
        {
            Assert.IsFalse(ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LnkMeasure), "Verified there should ba a measure tab Invisible");
            Waits.Wait(driver, 2000);
        }

        [When(@"Choose a turbo device and navigate to the SEV page\. Click on the Measure tab")]
        public void WhenChooseATurboDeviceAndNavigateToTheSEVPage_ClickOnTheMeasureTab()
        {
            for (int i = 1; i <= 30; i++)
            {
                deviceExplorerNavigationPage.LnkMeasure.Click();
                Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblMotorSpeedMeasureTab);
                if (ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LblMotorSpeedMeasureTab))
                {
                    break;
                }
                else
                {
                    Waits.Wait(driver, 2000);
                    continue;
                }
            }
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LblMotorSpeedMeasureTab), "Verified Graph is not visible on Measure tab");
        }

        [Then(@"displays the measure view as per turbo measure view non alert status\.png")]
        public void ThenDisplaysTheMeasureViewAsPerTurboMeasureViewNonAlertStatus_Png()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblMotorSpeedMeasureTab, 240);
            Assert.AreEqual(4, deviceExplorerNavigationPage.GraphChartMeasureCount(), "All graph images are not visible, please check");
            Waits.Wait(driver, 2000);
        }

        [When(@"Using the simualator trigger a warning using alert code '(.*)' at port '(.*)'")]
        public void WhenUsingTheSimualatorTriggerAWarningUsingAlertCodeAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }

        [Then(@"After a short interval, the view will be updated and the motor speed chart will change colour to the warning colour and the motor speed parameter box will change background colour to the warning colour and dispaly the warning icon warning image")]
        public void ThenAfterAShortIntervalTheViewWillBeUpdatedAndTheMotorSpeedChartWillChangeColourToTheWarningColourAndTheMotorSpeedParameterBoxWillChangeBackgroundColourToTheWarningColourAndDispalyTheWarningIconWarningImage()
        {
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 4000);
                if (ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LblMototSpeedMeasureByClassName))
                {
                    break;
                }
            }
            if (deviceExplorerNavigationPage.LblMototSpeedMeasureByClassName.GetCssValue("background-color").Contains("rgba(255, 255, 0, 1)"))
            {
                Assert.IsTrue(true, "Verified the motor speed parameter box will change background colour to the warning colour");
                Waits.Wait(driver, 2000);
            }
            else
            {
                Assert.Fail("Verified the motor speed parameter box will change background colour to the warning colour");
            }
        }
        [Then(@"After a short interval, the view will be updated and the motor temperature chart will change colour to the red colour and the motor temperature parameter box will change background colour to the red colour and dispaly the red icon warning image")]
        public void ThenAfterAShortIntervalTheViewWillBeUpdatedAndTheMotorTemperatureChartWillChangeColourToTheRedColourAndTheMotorTemperatureParameterBoxWillChangeBackgroundColourToTheRedColourAndDispalyTheRedIconWarningImage()
        {
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 4000);
                if (ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.lblMotorTemperatureMeasureTab))
                {
                    break;
                }
            }
            if (deviceExplorerNavigationPage.lblMotorTemperatureMeasureTab.GetCssValue("background-color").Contains("rgba(223, 0, 0, 1)"))
            {
                Assert.IsTrue(true, "Verified the motor temperature parameter box will change background colour to the red colour");
                Waits.Wait(driver, 2000);
            }
            else
            {
                Assert.Fail("Verified the motor temperature parameter box will change background colour to the red colour");
            }
        }

        [When(@"clear the simualator alert in port '(.*)'")]
        public void WhenClearTheSimualatorAlertInPort(string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.ClearEquimentAlertTurbo(port);
            simulator.MinimizeWindow("TURBO");
        }
        [Then(@"The display will revert to the non alert status")]
        public void ThenTheDisplayWillRevertToTheNonAlertStatus()
        {
            Waits.Wait(driver, 4000);
            Assert.IsTrue(deviceExplorerNavigationPage.LblMotorSpeedMeasureWithoutWarning.GetCssValue("background-color").Contains("rgba(0, 204, 102, 1)"));
            Waits.Wait(driver, 2000);

            //for (int i = 0; i < 30; i++)
            //{
            //    Waits.Wait(driver, 2000);
            //    if (ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LblMotorSpeedMeasureWithoutWarning))
            //    {
            //        break;
            //    }
            //}
            //if (deviceExplorerNavigationPage.LblMotorSpeedMeasureWithoutWarning.GetCssValue("background-color").Contains("rgba(0, 204, 102, 1)"))
            //{
            //    Waits.Wait(driver, 2000);
            //}
            //else
            //{
            //    Assert.Fail("Verified The display will not revert to the non alert status");
            //}
        }

        [When(@"Create an alert code (.*) - Motor Speed at port '(.*)'")]
        public void WhenCreateAnAlertCode_MotorSpeedAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }

        [Then(@"the parameter box will indicate the '(.*)' alert status and the motor speed chart will reflect the alert")]
        public void ThenTheParameterBoxWillIndicateTheAlertStatusAndTheMotorSpeedChartWillReflectTheAlert(string para)
        {
            Waits.Wait(driver, 6000);
            string aclass = deviceExplorerNavigationPage.LblMotorSpeedMeasureTab.GetAttribute("class");
            Assert.IsTrue(deviceExplorerNavigationPage.LblMotorSpeedMeasureTab.GetAttribute("class").Contains("parameter_status_alarm"), "Verified the parameter box will indicate the alert status");
            Waits.Wait(driver, 2000);
        }

        [When(@"Create an alert code (.*) - Motor Temperature overheat at port '(.*)'")]
        public void WhenCreateAnAlertCode_MotorTemperatureOverheatAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }

        [Then(@"the parameter box will indicate the '(.*)' alert status")]
        public void ThenTheParameterBoxWillIndicateTheAlertStatus(string param)
        {
            Waits.Wait(driver, 6000);
            Assert.IsTrue(deviceExplorerNavigationPage.AlertStatusNew(param), "Verfied the TMS Temperature parameter box will indicate the alert status");
            Waits.Wait(driver, 2000);
        }

        [When(@"Create an alert code (.*) - TMS Temperature at port '(.*)'")]
        public void WhenCreateAnAlertCode_TMSTemperatureAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"Create an alert code (.*) - DC Link Voltage at port '(.*)'")]
        public void WhenCreateAnAlertCode_DCLinkVoltageAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }


        [When(@"Create an alert code (.*) - Motor Current at port '(.*)'")]
        public void WhenCreateAnAlertCode_MotorCurrentAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"Create an alert code (.*) - PosXH at port '(.*)'")]
        public void WhenCreateAnAlertCode_PosXHAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"Create an alert code (.*) - PosYH at port '(.*)'")]
        public void WhenCreateAnAlertCode_PosYHAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"Create an alert code (.*) - PosXB at port '(.*)'")]
        public void WhenCreateAnAlertCode_PosXBAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"Create an alert code (.*) - PosYB at port '(.*)'")]
        public void WhenCreateAnAlertCode_PosYBAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"Create an alert code (.*) - PosZ at port '(.*)'")]
        public void WhenCreateAnAlertCode_PosZAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"Create an alert code (.*) - Vibration H at port '(.*)'")]
        public void WhenCreateAnAlertCode_VibrationHAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"Create an alert code (.*) - Vibration B at port '(.*)'")]
        public void WhenCreateAnAlertCode_VibrationBAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"Create an alert code (.*) - Vibration Z at port '(.*)'")]
        public void WhenCreateAnAlertCode_VibrationZAtPort(string alertCode, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alertCode, port);
            simulator.MinimizeWindow("TURBO");
        }


        [AfterScenario]
        public void AfterScenario()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            try
            {
                deviceExplorerNavigationPage.LinkHomePage.Click();
                homePage.ClickOnDeviceExplorer();
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