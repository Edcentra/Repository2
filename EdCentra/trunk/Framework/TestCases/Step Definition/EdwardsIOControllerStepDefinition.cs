using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class EdwardsIOControllerStepDefinition
    {
        string testFolderName = string.Empty;//ElementExtensions.GetRandomString(4);
        string equipmentName = ElementExtensions.GetRandomAlphabeticalString(6);
        string renameFolder = ElementExtensions.GetRandomString(4);
        LoginPage loginPage;
        HomePage homePage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        LoggingPage loggingPage;
        EdwardsIOControllerPage edwardsIOControllerPage;
        string iPAdress = SpecflowHooks.HostIpAddress();
        private IWebDriver driver;

        public EdwardsIOControllerStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            loggingPage = new LoggingPage(driver);
        }

        [Then(@"I commissioned device with following details '(.*)', '(.*)'")]
        public void ThenICommissionedDeviceWithFollowingDetails(string equipmentType, string iPPortNumber)
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
            ScenarioContext.Current.Add("EquipmentName", equipmentName);
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }


        [When(@"Go to the Configure -> Edwards IO Controller Settings section")]
        public void WhenGoToTheConfigure_EdwardsIOControllerSettingsSection()
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnConfiguration();
            homePage.ClickOnEdwardsIOControllerSettings();
        }

        [Then(@"Page loads and shows Create new profile dialog if there are no existing profiles")]
        public void ThenPageLoadsAndShowsCreateNewProfileDialogIfThereAreNoExistingProfiles()
        {
            if (edwardsIOControllerPage == null)
                edwardsIOControllerPage = new EdwardsIOControllerPage(driver);
            if (!ElementExtensions.isDisplayed(driver, edwardsIOControllerPage.LblProfileDialoguebox))
            {
                Assert.IsFalse(ElementExtensions.isDisplayed(driver, edwardsIOControllerPage.LblProfileDialoguebox), "Page loads and shows Create new profile dialog");
                Waits.Wait(driver, 1000);
            }
            else
            {
                Assert.IsTrue(ElementExtensions.isDisplayed(driver, edwardsIOControllerPage.LblProfileDialoguebox), "Page loads and not shown Create new profile dialog");
                Waits.Wait(driver, 1000);
            }
        }

        [When(@"New dialog is not showing if there are existing profiles then click the New button, enter a unique name '(.*)' and click the create button\.")]
        public void WhenNewDialogIsNotShowingIfThereAreExistingProfilesThenClickTheNewButtonEnterAUniqueNameAndClickTheCreateButton_(string profileName)
        {
            if (!ElementExtensions.isDisplayed(driver, edwardsIOControllerPage.LblProfileDialoguebox))
            {
                edwardsIOControllerPage.DeleteExistingProfile(profileName);
            }
            edwardsIOControllerPage.CreateProfile(profileName);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Profile is created and shown - you can see the details with tabs: Parameters, Functions, Alerts and assignments\.")]
        public void ThenProfileIsCreatedAndShown_YouCanSeeTheDetailsWithTabsParametersFunctionsAlertsAndAssignments_()
        {
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, edwardsIOControllerPage.TabParameters), "Profile is created and not shown tab Parameters");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, edwardsIOControllerPage.TabAssignments), "Profile is created and not shown tab assignments");
            Waits.Wait(driver, 1000);
        }

        [Then(@"the profiles list at the top you can see the new profile'(.*)' selected and showing (.*) assignments\.")]
        public void ThenTheProfilesListAtTheTopYouCanSeeTheNewProfileSelectedAndShowingAssignments_(string profile, string value)
        {
            Assert.IsTrue(edwardsIOControllerPage.VerifyAssignmentValue(profile, value), "Verified assigned value not match");
            Waits.Wait(driver, 1000);
        }

        [When(@"Edit some parameters by clicking the checkboxes and entering values then click Apply\.")]
        public void WhenEditSomeParametersByClickingTheCheckboxesAndEnteringValuesThenClickApply_(Table table)
        {
            edwardsIOControllerPage.ParameterSelection(table.Rows[0]["Parameter"], table.Rows[0]["Description"], table.Rows[0]["CustomScaling"], table.Rows[0]["DefaultOffset"], table.Rows[0]["OffsetUnit"]);
            edwardsIOControllerPage.ClickOnApply();
            Waits.Wait(driver, 1000);
        }

        [Then(@"Changes are applied\.")]
        public void ThenChangesAreApplied_()
        {
            Waits.WaitForElementVisible(driver, edwardsIOControllerPage.LblFeedback);
            Assert.IsTrue(edwardsIOControllerPage.LblFeedback.Text.Contains(GlobalConstants.ChangesApplied), "Verifying 'Changes have been applied' message will not be displayed on the screen");
        }

        [When(@"Click the Functions tab then edit some functions by selecting a function in the Boolean Operation drop-down select different first and second input parameters\.Click Apply\.")]
        public void WhenClickTheFunctionsTabThenEditSomeFunctionsBySelectingAFunctionInTheBooleanOperationDrop_DownSelectDifferentFirstAndSecondInputParameters_ClickApply_(Table table)
        {
            Waits.WaitAndClick(driver, edwardsIOControllerPage.TabFunction);
            Waits.Wait(driver, 2000);
            edwardsIOControllerPage.FunctionBooleanOperation(table.Rows[0]["Function"], table.Rows[0]["BooleanOperation"], table.Rows[0]["FirstInputParameter"], table.Rows[0]["SecondInputParameter"]);
            edwardsIOControllerPage.ClickOnApply();
            Waits.Wait(driver, 1000);
        }

        [When(@"Click the Alerts tab and create an alert, making sure to enter something into the Alert Message and click Add again\.")]
        public void WhenClickTheAlertsTabAndCreateAnAlertMakingSureToEnterSomethingIntoTheAlertMessageAndClickAddAgain_(Table table)
        {
            Waits.WaitAndClick(driver, edwardsIOControllerPage.TabAlerts);
            Waits.Wait(driver, 2000);
            edwardsIOControllerPage.AlertCreation(table.Rows[0]["Parameter"], table.Rows[0]["Alert"], table.Rows[0]["AlertMessage"]);
        }

        [Then(@"New Alert entry appears in list\.")]
        public void ThenNewAlertEntryAppearsInList_(Table table)
        {
            Assert.IsTrue(edwardsIOControllerPage.Alertlistverification(table.Rows[0]["Parameter"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.Alertlistverification(table.Rows[0]["Alert"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.Alertlistverification(table.Rows[0]["AlertMessage"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click the Apply button\.")]
        public void WhenClickTheApplyButton_()
        {
            edwardsIOControllerPage.ClickOnApply();
            Waits.Wait(driver, 1000);
        }

        [When(@"the profile '(.*)' that you created selected, click the Export button\.")]
        public void WhenTheProfileThatYouCreatedSelectedClickTheExportButton_(string profileName)
        {
            edwardsIOControllerPage.DeleteFolderExists();
            edwardsIOControllerPage.SelectCreatedProfile(profileName);
            edwardsIOControllerPage.ClickOnExport();
        }

        [Then(@"The File '(.*)' saved locally\.")]
        public void ThenTheFileSavedLocally_(string fileName)
        {
            Waits.Wait(driver, 8000);
            Assert.IsTrue(edwardsIOControllerPage.CSVFileExist(fileName), "Verified The should not be saved locally");
            Waits.Wait(driver, 1000);
        }

        [When(@"click the Import button\.")]
        public void WhenClickTheImportButton_()
        {
            edwardsIOControllerPage.ClickOnImport();
            Waits.Wait(driver, 1000);
        }

        [Then(@"Import panel appears\.")]
        public void ThenImportPanelAppears_()
        {
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, edwardsIOControllerPage.LblImportProfile), "Verified Import panel not appears");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click the Import button on the newly shown panel\.")]
        public void WhenClickTheImportButtonOnTheNewlyShownPanel_()
        {
            edwardsIOControllerPage.ClickConfirmImport();
        }

        [Then(@"A message appears You must enter a profile name\.")]
        public void ThenAMessageAppearsYouMustEnterAProfileName_()
        {
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.LblImportMessage.Text.Contains(GlobalConstants.ImportProfileMsg), "Verified Notes added message");
        }


        [When(@"Enter a profile name '(.*)' and click Import again\.")]
        public void WhenEnterAProfileNameAndClickImportAgain_(string profileName)
        {
            ElementExtensions.EnterTextValue(edwardsIOControllerPage.TxtImportName, profileName);
            edwardsIOControllerPage.ClickConfirmImport();
            Waits.Wait(driver, 1000);
        }

        [Then(@"A Message Shows No file selected\.")]
        public void ThenAMessageShowsNoFileSelected_()
        {
            Assert.IsTrue(edwardsIOControllerPage.LblImportMessage.Text.Contains(GlobalConstants.ImportFileMsg), "Verified Message not Shows No file selected");
            Waits.Wait(driver, 1000);
        }

        [When(@"Enter the name of an existing profile '(.*)' e\.g\. the one you created earlier and select the file that you downloaded earlier then click Import\.")]
        public void WhenEnterTheNameOfAnExistingProfileE_G_TheOneYouCreatedEarlierAndSelectTheFileThatYouDownloadedEarlierThenClickImport_(string profileName)
        {
            edwardsIOControllerPage.TxtImportName.Clear();
            ElementExtensions.EnterTextValue(edwardsIOControllerPage.TxtImportName, profileName);
            Waits.Wait(driver, 1000);
            edwardsIOControllerPage.UploadFile(profileName);
            edwardsIOControllerPage.ClickConfirmImport();
            Waits.Wait(driver, 1000);
        }

        [Then(@"A Message Shows Profile Name Already Exists\.")]
        public void ThenAMessageShowsProfileNameAlreadyExists_()
        {
            Assert.IsTrue(edwardsIOControllerPage.LblImportMessage.Text.Contains(GlobalConstants.ProfileNameExist), "Verified Message not Shows Profile Name Already Exists");
            Waits.Wait(driver, 1000);
        }

        [When(@"Enter a unique name '(.*)' then select the file'(.*)' that you downloaded earlier then click Import\.")]
        public void WhenEnterAUniqueNameThenSelectTheFileThatYouDownloadedEarlierThenClickImport_(string profileName, string fileName)
        {
            edwardsIOControllerPage.TxtImportName.Clear();
            ElementExtensions.EnterTextValue(edwardsIOControllerPage.TxtImportName, profileName);
            Waits.Wait(driver, 1000);
            edwardsIOControllerPage.UploadFile(fileName);
            edwardsIOControllerPage.ClickConfirmImport();
            Waits.Wait(driver, 1000);
        }

        [Then(@"Profile '(.*)' is imported and selected\.")]
        public void ThenProfileIsImportedAndSelected_(string profile)
        {
            Assert.IsTrue(edwardsIOControllerPage.IsProfileExist(profile), "Verified profile is not imported and selected");
            Waits.Wait(driver, 1000);
        }

        [When(@"Check that the parameters, functions and alerts match the profile that was exported\.")]
        public void WhenCheckThatTheParametersFunctionsAndAlertsMatchTheProfileThatWasExported_(Table table)
        {
            Assert.IsTrue(edwardsIOControllerPage.Alertlistverification(table.Rows[0]["Parameter"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.Alertlistverification(table.Rows[0]["Alert"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.Alertlistverification(table.Rows[0]["AlertMessage"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
        }

        [Then(@"assignments are not exported/imported '(.*)' so these will always be empty '(.*)' for the newly imported profile\.")]
        public void ThenAssignmentsAreNotExportedImportedSoTheseWillAlwaysBeEmptyForTheNewlyImportedProfile_(string profile, string value)
        {
            Assert.IsTrue(edwardsIOControllerPage.VerifyAssignmentValue(profile, value), "Verified assigned value not match");
            Waits.Wait(driver, 1000);
            edwardsIOControllerPage.DeleteExistingProfile(profile);
        }

        [When(@"Click the New button and leave the name field blank then click Create\.")]
        public void WhenClickTheNewButtonAndLeaveTheNameFieldBlankThenClickCreate_()
        {
            Waits.WaitAndClick(driver,edwardsIOControllerPage.BtnNew);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, edwardsIOControllerPage.BtnOKNew);
            Waits.Wait(driver, 1000);
        }

        [Then(@"A Message Shows to enter a profile name\.")]
        public void ThenAMessageShowsToEnterAProfileName_()
        {
            Assert.IsTrue(edwardsIOControllerPage.LblNewMessage.Text.Contains(GlobalConstants.ErrorMessage), "Verified A Message not Shows to enter a profile name");
            Waits.Wait(driver, 1000);
        }

        [When(@"enter exactly the same name as the current profile '(.*)' then click Create\.")]
        public void WhenEnterExactlyTheSameNameAsTheCurrentProfileThenClickCreate_(string profileName)
        {
            edwardsIOControllerPage.EnterProfileName(profileName);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, edwardsIOControllerPage.BtnOKNew);
        }

        [Then(@"Message Shows Profile Name Already Exists\.")]
        public void ThenMessageShowsProfileNameAlreadyExists_()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(edwardsIOControllerPage.LblNewMessage.Text.Contains(GlobalConstants.ProfileNameExist), "Verified Message not Shows Profile Name Already Exists");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click Cancel\.")]
        public void WhenClickCancel_()
        {
            Waits.WaitAndClick(driver, edwardsIOControllerPage.BtnCloseNew);
            Waits.Wait(driver, 1000);
        }

        [Then(@"New Dialog closes\.")]
        public void ThenNewDialogCloses_()
        {
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, edwardsIOControllerPage.BtnCloseNew), "Verified New Dialog not closes");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click the Assignments tab then Find Equipment\.")]
        public void WhenClickTheAssignmentsTabThenFindEquipment_()
        {
            Waits.WaitAndClick(driver, edwardsIOControllerPage.TabAssignments);
            Waits.Wait(driver, 2000);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, edwardsIOControllerPage.BtnGetSystems), "Verified Assignments tab not open");
        }

        [Then(@"The IO Controller devices that you added in the preparation steps should be listed\.")]
        public void ThenTheIOControllerDevicesThatYouAddedInThePreparationStepsShouldBeListed_()
        {
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            Waits.Wait(driver, 1000);
            loggingPage.SelectSingleEquipmentAndMoveToAssign(equipmentName);
        }

        [When(@"Select a device in the list and move it over with the single right arrow or by double clicking it\. Click Apply\.")]
        public void WhenSelectADeviceInTheListAndMoveItOverWithTheSingleRightArrowOrByDoubleClickingIt_ClickApply_()
        {
            Assert.IsTrue(edwardsIOControllerPage.IsEquipmentExist(equipmentName),"Verified equipment not listed on selected Side");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Changes are applied and persist when leaving and returning to the page\.")]
        public void ThenChangesAreAppliedAndPersistWhenLeavingAndReturningToThePage_()
        {

            if (edwardsIOControllerPage == null)
                edwardsIOControllerPage = new EdwardsIOControllerPage(driver);
            Waits.WaitForElementVisible(driver, edwardsIOControllerPage.LblFeedback);
            Assert.IsTrue(edwardsIOControllerPage.LblFeedback.Text.Contains(GlobalConstants.ChangesApplied), "Verifying 'Changes have been applied' message will not be displayed on the screen");
        }

        [Then(@"Notice the Assignments count in the profile '(.*)' list at the top show '(.*)' for this profile\.")]
        public void ThenNoticeTheAssignmentsCountInTheProfileListAtTheTopShowForThisProfile_(string profile, string value)
        {
            Assert.IsTrue(edwardsIOControllerPage.VerifyAssignmentValue(profile, value), "Verified assigned value not match");
            Waits.Wait(driver, 1000);
        }

        [When(@"With the profile'(.*)' that you created selected")]
        public void WhenWithTheProfileThatYouCreatedSelected(string profile)
        {
            edwardsIOControllerPage.SelectCreatedProfile(profile);
            Waits.Wait(driver, 1000);
        }

        [When(@"click duplicate button, leave the new name field blank then click Duplicate\.")]
        public void WhenClickDuplicateButtonLeaveTheNewNameFieldBlankThenClickDuplicate_()
        {
            Waits.WaitAndClick(driver, edwardsIOControllerPage.BtnDuplicate);
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, edwardsIOControllerPage.BtnOkConfirm);
            Waits.Wait(driver, 2000);
        }

        [Then(@"Message Shows to enter a profile name\.")]
        public void ThenMessageShowsToEnterAProfileName_()
        {
            Assert.IsTrue(edwardsIOControllerPage.LblConfirmMessage.Text.Contains(GlobalConstants.ErrorMessage), "Verified A Message not Shows to enter a profile name");
            Waits.Wait(driver, 1000);
        }

        [When(@"enter exactly the same name as the current profile '(.*)' then click Duplicate\.")]
        public void WhenEnterExactlyTheSameNameAsTheCurrentProfileThenClickDuplicate_(string profile)
        {
            ElementExtensions.EnterTextValue(edwardsIOControllerPage.TxtConfirm, profile);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, edwardsIOControllerPage.BtnOkConfirm);
            Waits.Wait(driver, 2000);
        }

        [Then(@"A Message Shows that this Profile name already exists\.")]
        public void ThenAMessageShowsThatThisProfileNameAlreadyExists_()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(edwardsIOControllerPage.LblConfirmMessage.Text.Contains(GlobalConstants.ProfileNameExist), "Verified Message not Shows Profile Name Already Exists");
            Waits.Wait(driver, 2000);
        }

        [When(@"Now enter a unique name '(.*)' and click Duplicate\.")]
        public void WhenNowEnterAUniqueNameAndClickDuplicate_(string profile)
        {
            edwardsIOControllerPage.TxtConfirm.Clear();
            Waits.Wait(driver, 1000);
            ElementExtensions.EnterTextValue(edwardsIOControllerPage.TxtConfirm, profile);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, edwardsIOControllerPage.BtnOkConfirm);
            Waits.Wait(driver, 2000);
        }

        [Then(@"Profile '(.*)' is duplicated, appears in the list of profiles and is selected\.")]
        public void ThenProfileIsDuplicatedAppearsInTheListOfProfilesAndIsSelected_(string profile)
        {
            if (edwardsIOControllerPage == null)
                edwardsIOControllerPage = new EdwardsIOControllerPage(driver);
            edwardsIOControllerPage.SelectCreatedProfile(profile);
            Waits.Wait(driver, 1000);
        }

        [When(@"Compare the parameters, functions and alerts for the duplicated profile with the original\.")]
        public void WhenCompareTheParametersFunctionsAndAlertsForTheDuplicatedProfileWithTheOriginal_(Table table)
        {
            Waits.WaitAndClick(driver, edwardsIOControllerPage.TabParameters);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.VerifyParameterValue(table.Rows[0]["Description"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.VerifyParameterValue(table.Rows[0]["CustomScaling"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.VerifyParameterValue(table.Rows[0]["OffsetUnit"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, edwardsIOControllerPage.TabFunction);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.VerifySelectedFuction(table.Rows[0]["Description"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.VerifySelectedFuction(table.Rows[0]["BooleanOperation"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.VerifySelectedFuction(table.Rows[0]["SecondInputParameter"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, edwardsIOControllerPage.TabAlerts);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.Alertlistverification(table.Rows[0]["Description"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.Alertlistverification(table.Rows[0]["Alert"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(edwardsIOControllerPage.Alertlistverification(table.Rows[0]["AlertMessage"]), "Verified New Alert entry not appears in list");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Note duplicate profile '(.*)' that assignments are NOT duplicated and this should read '(.*)'\.")]
        public void ThenNoteDuplicateProfileThatAssignmentsAreNOTDuplicatedAndThisShouldRead_(string profile, string value)
        {
            Assert.IsTrue(edwardsIOControllerPage.VerifyAssignmentValue(profile,value), "Verified that assignments are duplicated and this should read");
        }

        [When(@"With a profile '(.*)' selected, click the Rename button and enter the name of the profile '(.*)' that is not currently selected then click Rename\.")]
        public void WhenWithAProfileSelectedClickTheRenameButtonAndEnterTheNameOfTheProfileThatIsNotCurrentlySelectedThenClickRename_(string profileName1, string profileName2)
        {
            edwardsIOControllerPage.SelectCreatedProfile(profileName1);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, edwardsIOControllerPage.BtnRename);
            Waits.Wait(driver, 2000);
            edwardsIOControllerPage.TxtConfirm.Clear();
            Waits.Wait(driver, 1000);
            ElementExtensions.EnterTextValue(edwardsIOControllerPage.TxtConfirm, profileName2);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, edwardsIOControllerPage.BtnOkConfirm);
            Waits.Wait(driver, 1000);
        }

        [When(@"Now enter a unique name '(.*)' and click Rename\.")]
        public void WhenNowEnterAUniqueNameAndClickRename_(string profileName2)
        {
            edwardsIOControllerPage.TxtConfirm.Clear();
            Waits.Wait(driver, 1000);
            ElementExtensions.EnterTextValue(edwardsIOControllerPage.TxtConfirm, profileName2);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, edwardsIOControllerPage.BtnOkConfirm);
            Waits.Wait(driver, 1000);
        }


        [Then(@"Profile is renamed '(.*)' as seen in the profile list and label at the top of the details/editing view below\.")]
        public void ThenProfileIsRenamedAsSeenInTheProfileListAndLabelAtTheTopOfTheDetailsEditingViewBelow_(string profileName)
        {
            Assert.IsTrue(edwardsIOControllerPage.IsProfileExist(profileName), "Verified renamed is not seen in the profile list");
            Waits.Wait(driver, 1000);
            edwardsIOControllerPage.DeleteExistingProfile(profileName);
            Waits.Wait(driver, 1000);
        }

        [When(@"Navigate to Device Explorer and to the Manage Equipment Tab and search for the IO Controller you added at the begining of this test\. Highlight and delete this piece of equipment")]
        public void WhenNavigateToDeviceExplorerAndToTheManageEquipmentTabAndSearchForTheIOControllerYouAddedAtTheBeginingOfThisTest_HighlightAndDeleteThisPieceOfEquipment()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            deviceExplorerNavigationPage.NavigateToHomePage();
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnDeviceExplorer();
            Waits.Wait(driver, 1000);
        }

        [Then(@"The IO Controller is removed and confirmed")]
        public void ThenTheIOControllerIsRemovedAndConfirmed()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            deviceExplorerNavigationPage.DeleteAllEquipments(driver);
            Waits.Wait(driver, 1000);
        }

        [When(@"Navigate back to the IO Controller Settings page")]
        public void WhenNavigateBackToTheIOControllerSettingsPage()
        {
            deviceExplorerNavigationPage.NavigateToHomePage();
            Waits.Wait(driver, 1000);
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnConfiguration();
            Waits.Wait(driver, 1000);
            homePage.ClickOnEdwardsIOControllerSettings();
            Waits.Wait(driver, 1000);
        }

        [Then(@"The device is not present in the profile '(.*)' and the Assignments count '(.*)' is reduced accordingly")]
        public void ThenTheDeviceIsNotPresentInTheProfileAndTheAssignmentsCountIsReducedAccordingly(string profileName, string value)
        {
            if (edwardsIOControllerPage == null)
                edwardsIOControllerPage = new EdwardsIOControllerPage(driver);
            edwardsIOControllerPage.SelectCreatedProfile(profileName);
            Waits.Wait(driver, 1000);
            edwardsIOControllerPage.VerifyAssignmentValue(profileName, value);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, edwardsIOControllerPage.TabAssignments);
            Waits.Wait(driver, 1000);
            Assert.IsFalse(edwardsIOControllerPage.IsEquipmentExist(equipmentName), "Verified the device is present");
        }

        [When(@"a profile '(.*)' selected, click the Delete button then click Cancel\.")]
        public void WhenAProfileSelectedClickTheDeleteButtonThenClickCancel_(string profileName)
        {
            edwardsIOControllerPage.SelectCreatedProfile(profileName);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, edwardsIOControllerPage.BtnDeleteProfile);
            Waits.WaitAndClick(driver, edwardsIOControllerPage.BtnCancelConfirm);
        }

        [Then(@"The profile '(.*)' is NOT deleted\.")]
        public void ThenTheProfileIsNOTDeleted_(string profileName)
        {
            Assert.IsTrue(edwardsIOControllerPage.IsProfileExist(profileName), "Verified renamed is not seen in the profile list");
            Waits.Wait(driver, 1000);
        }

        [When(@"a profile '(.*)' selected, click the Delete button again then click Delete\.")]
        public void WhenAProfileSelectedClickTheDeleteButtonAgainThenClickDelete_(string profileName)
        {
            edwardsIOControllerPage.DeleteExistingProfile(profileName);
        }

        [Then(@"The profile '(.*)' is deleted \(a message is shown confirming this\), the details/edit area is hidden as no profiles are currently selected\.")]
        public void ThenTheProfileIsDeletedAMessageIsShownConfirmingThisTheDetailsEditAreaIsHiddenAsNoProfilesAreCurrentlySelected_(string profileName)
        {
            Assert.IsFalse(edwardsIOControllerPage.IsProfileExist(profileName), "Verified renamed is seen in the profile list");
            Waits.Wait(driver, 1000);
        }
    }
}
