using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class HistorianTestsStepDefinition
    {
        string testFolderName = string.Empty;//ElementExtensions.GetRandomString(4);

        string renameFolder = ElementExtensions.GetRandomString(4);
        LoginPage loginPage;
        HomePage homePage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        LoggingPage loggingPage;
        HistorianPage historianPage;
        DataExtractionPage dataExtractionPage;
        ReportPage reportPage;
        UserPage userPage;
        Simulator simulator = new Simulator();
        private IWebDriver driver;

        public HistorianTestsStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            loggingPage = new LoggingPage(driver);
            historianPage = new HistorianPage(driver);
            dataExtractionPage = new DataExtractionPage(driver);
            reportPage = new ReportPage(driver);
            userPage = new UserPage(driver);
        }

        [When(@"I selected the equipment type, entered equipmentName'(.*)' '(.*)' '(.*)', Cliked Find Equipment button, selected one equipment and clicked Add button")]
        public void WhenISelectedTheEquipmentTypeEnteredEquipmentNameClikedFindEquipmentButtonSelectedOneEquipmentAndClickedAddButton(string equipmentName, string equipmentName1, string equipmentName2)
        {
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            Waits.WaitForElementVisible(driver, loggingPage.LnkAddDevice);
            loggingPage.AddEquipment(equipmentName);
            Waits.Wait(driver, 1000);
            loggingPage.ClickOkAfterConformationMessage();
            Waits.WaitForElementVisible(driver, loggingPage.LnkAddDevice);
            loggingPage.AddEquipment(equipmentName1);
            Waits.Wait(driver, 1000);
            loggingPage.ClickOkAfterConformationMessage();
            Waits.WaitForElementVisible(driver, loggingPage.LnkAddDevice);
            loggingPage.AddEquipment(equipmentName2);
            Waits.Wait(driver, 2000);
        }
        
        [When(@"I Within the \[Configure \\/] menu, click the Logging option")]
        public void WhenIWithinTheConfigureMenuClickTheLoggingOption()
        {
            Waits.Wait(driver, 7000);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkHomePage);
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnConfiguration();
            homePage.ClickOnLogging();
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            loggingPage.ClickOnLoggingLink();
        }

        [Then(@"the Logging tab is opened")]
        public void ThenTheLoggingTabIsOpened()
        {
            Waits.Wait(driver, 1000);
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            Waits.WaitForElementVisible(driver, loggingPage.LnkCreateProfile);
            Assert.IsTrue(loggingPage.LnkCreateProfile.Displayed, "Verifying User should be navigated to logging page");
        }

        [When(@"I Click on Create Profile button")]
        public void WhenIClickOnCreateProfileButton()
        {
            Waits.Wait(driver, 1000);
            loggingPage.ClickOnCreateProfileOption();
        }

        [Then(@"the Create Profile form is displayed")]
        public void ThenTheCreateProfileFormIsDisplayed()
        {
            Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, loggingPage.BtnCreateProfile);
            Assert.IsTrue(loggingPage.BtnCreateProfile.Displayed, "Verified Create Profile form is displayed");
        }

        [When(@"Provide a name'(.*)' and select an equipment type'(.*)' for the profile\. Click Create\.")]
        public void WhenProvideANameAndSelectAnEquipmentTypeForTheProfile_ClickCreate_(string profileName, string text)
        {
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, loggingPage.BtnCreateProfile);
            Waits.Wait(driver, 1000);
            loggingPage.CreateProfile(profileName, text);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The form expand and shows detail tab which lists parameter for the equipment type")]
        public void ThenTheFormExpandAndShowsDetailTabWhichListsParameterForTheEquipmentType()
        {
            Waits.WaitForElementVisible(driver, loggingPage.LblDetailTab);
            Assert.IsTrue(loggingPage.LblDetailTab.Displayed, "Verified the form expand and shows detail tab which lists parameter for the equipment type");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '(.*)' '(.*)' '(.*)' '(.*)'\.Click Apply\.")]
        public void WhenIMakeANumberOfSelectionsFromTheListOfAvailableParametersAndChangeTheValuesForTheNormalAlertAndDelta_ClickApply_(string Parameter, string TimeintervalforNormal, string TimeintervalforAlert, string TimeintervalforDelta)
        {
            loggingPage.ParameterSelection(Parameter, TimeintervalforNormal, TimeintervalforAlert, TimeintervalforDelta);
            loggingPage.ClickApplyChanges();
        }

        [When(@"I Make a number of selections from the list of available parameters and change the values for the Normal, Alert, and Delta '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'\.Then Click Apply\.")]
        public void WhenIMakeANumberOfSelectionsFromTheListOfAvailableParametersAndChangeTheValuesForTheNormalAlertAndDelta_ThenClickApply_(string Parameter, string TimeintervalforNormal, string TimeintervalforAlert, string TimeintervalforDelta, string Parameter1, string TimeintervalforNormal1, string TimeintervalforAlert1, string TimeintervalforDelta1)
        {
            Waits.Wait(driver, 7000);
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            loggingPage.ParameterSelection(Parameter, TimeintervalforNormal, TimeintervalforAlert, TimeintervalforDelta);
            Waits.Wait(driver, 1000);
            loggingPage.ParameterSelection(Parameter1, TimeintervalforNormal1, TimeintervalforAlert1, TimeintervalforDelta1);
            Waits.Wait(driver, 1000);
            loggingPage.ClickApplyChanges();
        }

        [Then(@"The screen will show applied values for Normal / Alert and Delta fields for the parameter\.The screen will only list parameters'(.*)' added in profile")]
        public void ThenTheScreenWillShowAppliedValuesForNormalAlertAndDeltaFieldsForTheParameter_TheScreenWillOnlyListParametersAddedInProfile(string parameter)
        {
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
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
                    Assert.IsTrue(loggingPage.SelectedParameterListed(parameter), "Screen present only the selected parameters");
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        [When(@"I adding more parameter unmark Show only parameters in profile button")]
        public void WhenIAddingMoreParameterUnmarkShowOnlyParametersInProfileButton()
        {
            Waits.WaitAndClick(driver, loggingPage.ShowOnlyParameterChkBox);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The Show only parameters in profile button unmark and all the parameters Param'(.*)' listed")]
        public void ThenTheShowOnlyParametersInProfileButtonUnmarkAndAllTheParametersParamListed(string param)
        {
            for (int i = 0; i < 5; i++)
            {
                Waits.Wait(driver, 1000);
                if (loggingPage.ShowOnlyParameterChkBox.GetAttribute("src").Contains("chk_off"))
                {
                    Assert.IsTrue(loggingPage.SelectedParameterListed(param), "Screen present all parameters");
                    break;
                }
                else
                {
                    continue;
                }
            }
            Assert.IsTrue(loggingPage.ShowOnlyParameterChkBox.GetAttribute("src").Contains("chk_off"), "Show only parameters in profile button unmarked");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Check the checkbox entitled Show only parameters in profile")]
        public void WhenICheckTheCheckboxEntitledShowOnlyParametersInProfile()
        {
            for (int i = 1; i <= 10; i++)
            {
                Waits.Wait(driver, 1000);
                if (loggingPage.ShowOnlyParameterChkBox.GetAttribute("src").Contains("chk_off"))
                {
                    Waits.WaitAndClick(driver, loggingPage.ShowOnlyParameterChkBox);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        [Then(@"The Only parameters '(.*)' selected as present in the profile should be present")]
        public void ThenTheOnlyParametersSelectedAsPresentInTheProfileShouldBePresent(string parameter)
        {
            for (int i = 0; i < 5; i++)
            {
                Waits.Wait(driver, 1000);
                if (loggingPage.ShowOnlyParameterChkBox.GetAttribute("src").Contains("chk_on"))
                {
                    Assert.IsTrue(loggingPage.SelectedParameterListed(parameter), "Screen present only the selected parameters");
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        [When(@"I click on Equipments tab")]
        public void WhenIClickOnEquipmentsTab()
        {
            loggingPage.NavigateToEquipmentTab();
            Waits.Wait(driver, 1000);
        }

        [Then(@"I should be navigated to Equipments tab")]
        public void ThenIShouldBeNavigatedToEquipmentsTab()
        {
            Waits.WaitForElementVisible(driver, loggingPage.LnkEquipmentTabNew);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, loggingPage.LnkEquipmentTabNew), "Verifying User should be navigated to EquipmentsTab");
            Waits.Wait(driver, 3000);
        }

        [When(@"I Find equipment using equipment description and add Equipments '(.*)' to Assigned Equipment list using > and >> button then Click Apply")]
        public void WhenIFindEquipmentUsingEquipmentDescriptionAndAddEquipmentsToAssignedEquipmentListUsingAndButtonThenClickApply(string equipment)
        {
            loggingPage.SelectSingleEquipmentAndMoveToAssign(equipment);
        }

        [Then(@"the Changes have been applied message will be displayed on the screen")]
        public void ThenTheChangesHaveBeenAppliedMessageWillBeDisplayedOnTheScreen()
        {
            Waits.Wait(driver, 3000);
            Waits.WaitForElementVisible(driver, loggingPage.LblSuccessMessageAfterAddingEquipment);
            Assert.IsTrue(loggingPage.LblSuccessMessageAfterAddingEquipment.Text.Contains(GlobalConstants.ChangesApplied), "Verified the Changes have been applied message is displayed on the screen");
        }

        [When(@"I delete the ProfileName'(.*)' if profilename exist")]
        public void WhenIDeleteTheProfileNameIfProfilenameExist(string ProfileName)
        {
            Waits.WaitForElementVisible(driver, loggingPage.LblCreateProfile);
            loggingPage.DeleteIfProfileExist(ProfileName);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Ensure the ProfileName '(.*)' is deleted")]
        public void ThenEnsureTheProfileNameIsDeleted(string ProfileName)
        {
            //Latest code Rel1.11
            Assert.IsTrue(loggingPage.IsProfileExist(ProfileName), "Verified Profile shouldn't be present after delete action");
            Waits.Wait(driver, 1000);
        }

        [When(@"Expand the folder and Select single Equipment in the tree")]
        public void WhenExpandTheFolderAndSelectSingleEquipmentInTheTree()
        {
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            testFolderName = (string)ScenarioContext.Current["TestFolderName"];
            string equipmentName = (string)ScenarioContext.Current["EquipmentName"];
            historianPage.ExpandSystemsParameter(testFolderName);
            Waits.Wait(driver, 1000);
            historianPage.SelectSingleParameterEquipment(equipmentName);
            Waits.Wait(driver, 3000);
        }

        [When(@"I Select already created test data logging profile ProfileName'(.*)'")]
        public void WhenISelectAlreadyCreatedTestDataLoggingProfileProfileName(string ProfileName)
        {
            homePage.ClickOnConfiguration();
            homePage.ClickOnLogging();
            loggingPage.SelectCreatedProfile(ProfileName);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The Profile detail will be displayed ProfileName '(.*)'")]
        public void ThenTheProfileDetailWillBeDisplayedProfileName(string ProfileName)
        {
            Waits.WaitForElementVisible(driver, loggingPage.BtnApplyChanges);
            Assert.IsTrue(loggingPage.TxtProfileName.GetAttribute("value").ToLower().Contains(ProfileName.ToLower()), "Verified profile name");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Change the name of the profile Newprofilename '(.*)' and click apply")]
        public void WhenIChangeTheNameOfTheProfileNewprofilenameAndClickApply(string Newprofilename)
        {
            Waits.WaitForElementVisible(driver, loggingPage.TxtProfileName);
            Waits.Wait(driver, 1000);
            loggingPage.TxtProfileName.Clear();
            Waits.Wait(driver, 1000);
            loggingPage.TxtProfileName.SendKeys(Newprofilename);
            loggingPage.ClickApplyChanges();
        }

        [Then(@"The changes should be saved and Newprofilename '(.*)'")]
        public void ThenTheChangesShouldBeSavedAndNewprofilename(string Newprofilename)
        {
            Waits.WaitForElementVisible(driver, loggingPage.LblSuccessMessageAfterAddingEquipment);
            Assert.IsTrue(loggingPage.LblSuccessMessageAfterAddingEquipment.Text.Contains(GlobalConstants.ChangesApplied), "Verified changes saved message");
            Waits.Wait(driver, 1000);
            loggingPage.SelectCreatedProfile(Newprofilename);
            Waits.WaitForElementVisible(driver, loggingPage.TxtProfileName);
            Assert.IsTrue(loggingPage.TxtProfileName.GetAttribute("value").ToLower().Contains(Newprofilename.ToLower()), "Verified profile got Renamed successfully");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Select a Logging profile '(.*)'and click the Duplicate button")]
        public void WhenISelectALoggingProfileAndClickTheDuplicateButton(string ProfileName)
        {
            loggingPage.SelectCreatedProfile(ProfileName);
            Waits.WaitForElementVisible(driver, loggingPage.BtnApplyChanges);
            loggingPage.ClickOnDuplicateButton();
        }

        [Then(@"A dialog is opened displaying the profile name with Copy of prefixing the profile name, OK and Cancel buttons")]
        public void ThenADialogIsOpenedDisplayingTheProfileNameWithCopyOfPrefixingTheProfileNameOKAndCancelButtons()
        {
            bool duplicateWin = Waits.WaitForElementVisible(driver, loggingPage.Duplicatewindow);
            Assert.IsTrue(duplicateWin, "Verified screen present Duplicate window");
        }

        [When(@"I Click cancel")]
        public void WhenIClickCancel()
        {
            Waits.WaitAndClick(driver, loggingPage.BtnCancelDuplicateWindow);
            Waits.Wait(driver, 1000);
        }

        [Then(@"verify that the copy dialog is closed and the profile is not copied")]
        public void ThenVerifyThatTheCopyDialogIsClosedAndTheProfileIsNotCopied()
        {
            Assert.IsFalse(ElementExtensions.isDisplayed(driver, loggingPage.Duplicatewindow), "Verified screen not present Duplicate window");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Click the Duplicate button again")]
        public void WhenIClickTheDuplicateButtonAgain()
        {
            loggingPage.ClickOnDuplicateButton();
        }

        [Then(@"I get a dialog is opened displaying the profile name with Copy of prefixing the profile name")]
        public void ThenIGetADialogIsOpenedDisplayingTheProfileNameWithCopyOfPrefixingTheProfileName()
        {
            Waits.WaitForElementVisible(driver, loggingPage.Duplicatewindow);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, loggingPage.Duplicatewindow), "Verified screen present Duplicate window");
        }

        [When(@"I click OK on the copy profile dialog and delete ProfileName'(.*)' already exist")]
        public void WhenIClickOKOnTheCopyProfileDialogAndDeleteProfileNameAlreadyExist(string ProfileName)
        {
            Waits.WaitAndClick(driver, loggingPage.BtnOkDuplicateWindow);
            Waits.Wait(driver, 1000);
            loggingPage.DeleteProfile(ProfileName);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Verify that a new profile duplicatename '(.*)' is created with the same parameter'(.*)' attributes as the original")]
        public void ThenVerifyThatANewProfileDuplicatenameIsCreatedWithTheSameParameterAttributesAsTheOriginal(string duplicatename, string parameter)
        {
             loggingPage.SelectCreatedProfile(duplicatename);
             Waits.WaitForElementVisible(driver, loggingPage.BtnApplyChanges);
             Assert.IsTrue(loggingPage.TxtProfileName.GetAttribute("value").ToLower().Contains(duplicatename.ToLower()), "Verified profile name changed successfully");
            Waits.Wait(driver, 6000);
            //The assert is returning false in run mode.
             Assert.IsTrue(loggingPage.SelectedParameterListed(parameter), "Screen present only the selected parameters");
           //  Waits.Wait(driver, 1000);
        }

        [When(@"I Click the delete button")]
        public void WhenIClickTheDeleteButton()
        {
            loggingPage.ClickOnDeleteButton();
        }

        [Then(@"Verify that the delete profile dialog is opened with OK and Cancel buttons")]
        public void ThenVerifyThatTheDeleteProfileDialogIsOpenedWithOKAndCancelButtons()
        {
            for (int i = 0; i < 15; i++)
            {
                Waits.Wait(driver, 1000);
                if (Waits.WaitForElementVisible(driver, loggingPage.BtnCancelDeleteWindow))
                {
                    Assert.IsTrue(ElementExtensions.isDisplayed(driver, loggingPage.BtnCancelDeleteWindow), "Verified screen present Delete window");
                    break;
                }
                else
                {
                    loggingPage.ClickOnDeleteButton();
                }
            }
        }

        [When(@"Click the Cancel button")]
        public void WhenClickTheCancelButton()
        {
            Waits.WaitAndClick(driver, loggingPage.BtnCancelDeleteWindow);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Verify that the delete dialog is closed and the profile is not deleted")]
        public void ThenVerifyThatTheDeleteDialogIsClosedAndTheProfileIsNotDeleted()
        {
            Assert.IsFalse(ElementExtensions.isDisplayed(driver, loggingPage.BtnCancelDeleteWindow), "Verified screen not present Delete window");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Click the delete button again")]
        public void WhenIClickTheDeleteButtonAgain()
        {
            loggingPage.ClickOnDeleteButton();
        }

        [Then(@"verify that the delete profile dialog is opened")]
        public void ThenVerifyThatTheDeleteProfileDialogIsOpened()
        {
            if (ElementExtensions.isDisplayed(driver, loggingPage.BtnCancelDeleteWindow))
            {
                Assert.IsTrue(ElementExtensions.isDisplayed(driver, loggingPage.BtnCancelDeleteWindow), "Verified screen present Delete window");
            }
            else
            {
                loggingPage.ClickOnDeleteButton();
            }

        }

        [When(@"I click OK on the delete dialog")]
        public void WhenIClickOKOnTheDeleteDialog()
        {
            Waits.WaitAndClick(driver, loggingPage.BtnOkDeleteWindow);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Ensure the profile profilename '(.*)' is deleted")]
        public void ThenEnsureTheProfileProfilenameIsDeleted(string ProfileName)
        {
            //Assert.IsFalse(loggingPage.BtnCancelDeleteWindow.Displayed, "Verified screen present Delete window");
            //Waits.Wait(driver, 1000);
            Assert.IsFalse(loggingPage.IsProfileExist(ProfileName), "Verified Profile shouldn't be present after delete action");
            Waits.Wait(driver, 1000);
        }

        [Then(@"I Click Apply")]
        public void ThenIClickApply()
        {
            loggingPage.ClickApplyChanges();
            Waits.Wait(driver, 1000);
        }

        [When(@"I Navigate to the details tab of a Data Logging profile")]
        public void WhenINavigateToTheDetailsTabOfADataLoggingProfile()
        {
            Waits.WaitAndClick(driver, loggingPage.TabDetails);
        }

        [Then(@"The details tab of a Data Logging profile displayed")]
        public void ThenTheDetailsTabOfADataLoggingProfileDisplayed()
        {
            Waits.WaitForElementVisible(driver, loggingPage.LblDetailTab);
            Assert.IsTrue(loggingPage.LblDetailTab.Displayed, "Verified screen present Detail tab");
            Waits.Wait(driver, 5000);
        }

        [When(@"Select a parameter from the list for logging by checking the Log Parameter'(.*)' check box")]
        public void WhenSelectAParameterFromTheListForLoggingByCheckingTheLogParameterCheckBox(string Parameter)
        {
            Waits.Wait(driver, 5000);
            loggingPage.SelectParametersCheckBoxes(Parameter);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Green tick appears in checkbox")]
        public void ThenGreenTickAppearsInCheckbox()
        {
            Assert.IsTrue(loggingPage.ImagecheckBox.GetAttribute("src").Contains("on"), "Verified Green tick appears in checkbox");
            Waits.Wait(driver, 1000);
        }

        [When(@"Without clicking the apply button, navigate to another logging profile or another Edcentra window such as the Device Explorer, navigate back to the previous data logging profile'(.*)'")]
        public void WhenWithoutClickingTheApplyButtonNavigateToAnotherLoggingProfileOrAnotherEdcentraWindowSuchAsTheDeviceExplorerNavigateBackToThePreviousDataLoggingProfile(string profile)
        {
            ElementExtensions.ClickOnButton(loggingPage.BtnAssignments);
            Waits.Wait(driver, 1000);
            loggingPage.SelectCreatedProfile(profile);
        }

        [Then(@"verify that the selected Parameter'(.*)' Check box no longer ticked")]
        public void ThenVerifyThatTheSelectedParameterCheckBoxNoLongerTicked(string Parameter)
        {
            Waits.WaitForElementVisible(driver, loggingPage.BtnApplyChanges);
            Waits.Wait(driver, 1000);
            Assert.IsFalse(loggingPage.IsParametersCheckBoxSelected(Parameter), "Verify that the selected parameter has not been saved");
            Waits.Wait(driver, 1000);
        }

        [When(@"I select the same Parameter'(.*)'")]
        public void WhenISelectTheSameParameter(string Parameter)
        {
            loggingPage.SelectParametersCheckBoxes(Parameter);
            Waits.Wait(driver, 1000);
        }

        [Then(@"I click the Apply button")]
        public void ThenIClickTheApplyButton()
        {
            loggingPage.ClickApplyChanges();
            Waits.Wait(driver, 1000);
        }

        [When(@"Navigate away and back again to the selection Profile'(.*)'")]
        public void WhenNavigateAwayAndBackAgainToTheSelectionProfile(string Profile)
        {
            Waits.WaitForElementVisible(driver, loggingPage.BtnAssignments);
            Waits.WaitAndClick(driver, loggingPage.BtnAssignments);
            Waits.Wait(driver, 1000);
            loggingPage.SelectCreatedProfile(Profile);
        }

        [Then(@"Verify that the selection Parameter'(.*)' has been remembered")]
        public void ThenVerifyThatTheSelectionParameterHasBeenRemembered(string Parameter)
        {
            Waits.WaitForElementVisible(driver, loggingPage.BtnApplyChanges);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(loggingPage.IsParametersCheckBoxSelected(Parameter), "Verify that the selection has been remembered");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Click the Assignments button within Logging")]
        public void WhenIClickTheAssignmentsButtonWithinLogging()
        {
            loggingPage.ClickOnLoggingLink();
            Waits.Wait(driver, 1000);
            loggingPage.ClickOnBtnAssignments();
            Waits.Wait(driver, 1000);
        }

        [Then(@"The tab Logging is displayed showing a list of all equipment with logging profiles")]
        public void ThenTheTabLoggingIsDisplayedShowingAListOfAllEquipmentWithLoggingProfiles()
        {
            Waits.WaitForElementVisible(driver, loggingPage.LblAssignmentsGrid);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(loggingPage.IsListedequipment(), "Verify tab displayed showing a list of all equipment with logging profiles");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click the Not Logging tab and All tab")]
        public void WhenClickTheNotLoggingTabAndAllTab()
        {
            Waits.WaitAndClick(driver, loggingPage.LnkNotLoggingAssignedTab);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, loggingPage.LnkAllTab);
        }

        [Then(@"The logging profiles should appear in black \(when they have applied\) or blue \(when they are ‘in process’ just before they have been processed by the relevant agent\)\. Keep monitoring this page to check that the profile ‘goes black’\.")]
        public void ThenTheLoggingProfilesShouldAppearInBlackWhenTheyHaveAppliedOrBlueWhenTheyAreInProcessJustBeforeTheyHaveBeenProcessedByTheRelevantAgent_KeepMonitoringThisPageToCheckThatTheProfileGoesBlack_()
        {
            ElementExtensions.ClickOnLink(loggingPage.LnkLoggingAssignedTab);
            Waits.Wait(driver, 5000);
            Assert.IsTrue(loggingPage.VerifyTextColor(loggingPage.LnkEquipmentType, GlobalConstants.CommonTextColour), "Verified EquipmentName Text colour is black");
            Assert.IsTrue(loggingPage.VerifyTextColor(loggingPage.LnkEquipment, GlobalConstants.CommonTextColour), "Verified Equipment Text colour is black");
            Assert.IsTrue(loggingPage.VerifyTextColor(loggingPage.LnkLoggingProfile, GlobalConstants.CommonTextColour), "Verified LoggingProfile Text colour is black");
            loggingPage.ClickOnRefreshIcon();
            Waits.Wait(driver, 100);
            Assert.IsTrue(loggingPage.VerifyTextColor(loggingPage.LnkEquipmentType, GlobalConstants.RefreshTextColour), "Verified EquipmentName Text colour is blue");
            loggingPage.ClickOnRefreshIcon();
            Waits.Wait(driver, 100);
            Assert.IsTrue(loggingPage.VerifyTextColor(loggingPage.LnkEquipment, GlobalConstants.RefreshTextColour), "Verified Equipment Text colour is blue");
            loggingPage.ClickOnRefreshIcon();
            Waits.Wait(driver, 100);
            Assert.IsTrue(loggingPage.VerifyTextColor(loggingPage.LnkLoggingProfile, GlobalConstants.RefreshTextColour), "Verified LoggingProfile Text colour is blue");
            Waits.Wait(driver, 5000);
            Assert.IsTrue(loggingPage.VerifyTextColor(loggingPage.LnkEquipmentType, GlobalConstants.CommonTextColour), "Verified EquipmentName Text colour is black");
            Assert.IsTrue(loggingPage.VerifyTextColor(loggingPage.LnkEquipment, GlobalConstants.CommonTextColour), "Verified Equipment Text colour is black");
            Assert.IsTrue(loggingPage.VerifyTextColor(loggingPage.LnkLoggingProfile, GlobalConstants.CommonTextColour), "Verified LoggingProfile Text colour is black");
        }

        [When(@"Click on the Display effective logging on this equipment icon \(looks like a piece of paper with writting on it\)")]
        public void WhenClickOnTheDisplayEffectiveLoggingOnThisEquipmentIconLooksLikeAPieceOfPaperWithWrittingOnIt()
        {
            loggingPage.ClickOnLoggingLink();
            loggingPage.ClickOnBtnAssignments();
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, loggingPage.LnkEffectiveIcon);
            ElementExtensions.ClickOnLink(loggingPage.LnkEffectiveIcon);
            Waits.Wait(driver, 1000);
        }

        [Then(@"After a few moments, a form will show detailing the logging regime applied")]
        public void ThenAfterAFewMomentsAFormWillShowDetailingTheLoggingRegimeApplied()
        {
            Waits.WaitForElementVisible(driver, loggingPage.LnkDetailingEffectiveLogging);
            Assert.IsTrue(loggingPage.LnkDetailingEffectiveLogging.Displayed, "Verfied a form will show detailing the logging regime applied");
            loggingPage.ClickonBtnCloseEffectiveWinodow();
        }

        [When(@"Choose a profile and click on the refresh icon \(two green arrows\)")]
        public void WhenChooseAProfileAndClickOnTheRefreshIconTwoGreenArrows()
        {
            loggingPage.ClickOnRefreshIcon();
            Waits.Wait(driver, 100);
        }

        [Then(@"The entry should display blue with an animated refresh gif in place of the green tick")]
        public void ThenTheEntryShouldDisplayBlueWithAnAnimatedRefreshGifInPlaceOfTheGreenTick()
        {
            Assert.IsTrue(loggingPage.VerifyTextColor(loggingPage.LnkEquipmentType, GlobalConstants.RefreshTextColour), "Verified EquipmentName Text colour is blue");
            loggingPage.ClickOnRefreshIcon();
            Waits.Wait(driver, 100);
            Assert.IsTrue(loggingPage.VerifyTextColor(loggingPage.LnkEquipment, GlobalConstants.RefreshTextColour), "Verified Equipment Text colour is blue");
            loggingPage.ClickOnRefreshIcon();
            Waits.Wait(driver, 100);
            Assert.IsTrue(loggingPage.VerifyTextColor(loggingPage.LnkLoggingProfile, GlobalConstants.RefreshTextColour), "Verified LoggingProfile Text colour is blue");
            loggingPage.ClickOnRefreshIcon();
            Waits.Wait(driver, 100);
            for (int i = 0; i < 5; i++)
            {
                if (ElementExtensions.isDisplayed(driver, loggingPage.LnkRefresh))
                {
                    Assert.IsTrue(loggingPage.LnkRefresh.GetAttribute("src").Contains("img/ajax_loader_refresh.gif"), "Verify the entry should display blue with an animated refresh gif in place of the green tick");
                    break;
                }
                else
                {
                    loggingPage.ClickOnRefreshIcon();
                    continue;
                }
            }
        }

        [Then(@"Alerts raised against a Parameter '(.*)' AlertType '(.*)' AlertCode '(.*)'")]
        public void ThenAlertsRaisedAgainstAParameterAlertTypeAlertCode(string Parameter, string AlertType, string AlertCode)
        {
            simulator.RestoreWindow();
            simulator.RaiseAlert(Parameter, AlertType, AlertCode);
            simulator.MinimizeWindow();
        }

        [When(@"Click Historian ->Equipment Data tab")]
        public void WhenClickHistorian_EquipmentDataTab()
        {
            loggingPage.NavigateToHomePage();
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkHistorian);
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            Waits.WaitAndClick(driver, historianPage.LnkHistorianEquipmentData);
        }

        [Then(@"Equipment Data tab should be shown")]
        public void ThenEquipmentDataTabShouldBeShown()
        {
            Waits.WaitForElementVisible(driver, historianPage.LnkHistorianEquipmentData);
            Assert.IsTrue(historianPage.LnkHistorianEquipmentData.Displayed, "Verified screen presence the Equipment Data tab");
            Waits.Wait(driver, 1000);
        }

        [When(@"hover on the folder name")]
        public void WhenHoverOnTheFolderName()
        {
            Waits.Wait(driver, 1000);
            testFolderName = (string)ScenarioContext.Current["TestFolderName"];
            ElementExtensions.MouseHover(driver, historianPage.FolderName);
        }

        [Then(@"the note ""(.*)"" should be displayed while hover on the folder name on the Historian page")]
        public void ThenTheNoteShouldBeDisplayedWhileHoverOnTheFolderNameOnTheHistorianPage(string note)
        {
            Assert.IsTrue(historianPage.VerifyTooltipText(note));
        }

        [When(@"I Select date range StartDate and mark only Parameter Data check box\.Ummark Alerts and Equipment Status\.Click Apply")]
        public void WhenISelectDateRangeStartDateAndMarkOnlyParameterDataCheckBox_UmmarkAlertsAndEquipmentStatus_ClickApply()
        {
            historianPage.SelectDateRange();
            Waits.Wait(driver, 1000);
            if (historianPage.EquptParametercheckbox.GetAttribute("src").Contains("chk_off"))
            {
                Waits.WaitAndClick(driver, historianPage.EquptParametercheckbox);
            }
            Assert.IsTrue(historianPage.EquptParametercheckbox.GetAttribute("src").Contains("chk_on"), "Verified Parameter Data check box marked");
            Waits.Wait(driver, 1000);
            if (historianPage.EquptAlertcheckbox.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, historianPage.EquptAlertcheckbox);
            }
            Assert.IsTrue(historianPage.EquptAlertcheckbox.GetAttribute("src").Contains("chk_off"), "Verified Alerts and Equipment Status unmarked");
            Waits.WaitAndClick(driver, historianPage.BtnApplyFilter);
            Waits.Wait(driver, 3000);
        }

        [Then(@"Select Device Explorer folder on Systems list")]
        public void ThenSelectDeviceExplorerFolderOnSystemsList()
        {
             testFolderName = (string)ScenarioContext.Current["TestFolderName"];
            historianPage.ExpandSystemsParameter(testFolderName);
            Waits.Wait(driver, 1000);
        }

        [When(@"Expand the folder and Select single Equipment '(.*)' in the tree")]
        public void WhenExpandTheFolderAndSelectSingleEquipmentInTheTree(string equipmentName)
        {
             testFolderName = (string)ScenarioContext.Current["TestFolderName"];

            Assert.IsTrue(historianPage.ExpandSystemsParameterCheck(testFolderName), "Verified Systems Parameter Expanded");
            Waits.Wait(driver, 1000);
            historianPage.SelectSingleParameterEquipment(equipmentName);
            Waits.Wait(driver, 2000);
        }

        [Then(@"The Parameter'(.*)' for that equipment'(.*)' will be displayed in the parameter's list")]
        public void ThenTheParameterForThatEquipmentWillBeDisplayedInTheParameterSList(string parameter1, string equipmentName)
        {
            for (int i = 0; i < 15; i++)
            {
                Waits.Wait(driver, 1000);
                if (historianPage.IsParameterListPresent(parameter1))
                {
                    Assert.IsTrue(historianPage.IsParameterListPresent(parameter1), "Verified The parameters for that equipment will be displayed");
                    break;
                }
                else
                {
                    driver.Navigate().Refresh();
                    historianPage.SelectSingleParameterEquipment(equipmentName);
                }
            }
        }

        [When(@"Click on of the parameter'(.*)' and click Add button at the bottom of the parameter list")]
        public void WhenClickOnOfTheParameterAndClickAddButtonAtTheBottomOfTheParameterList(string parameter2)
        {
            historianPage.SelectSingleParameter(parameter2);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, historianPage.BtnAddParameter);
        }

        [Then(@"Grid tab should display values for selected equipment'(.*)' and selected parameter'(.*)'")]
        public void ThenGridTabShouldDisplayValuesForSelectedEquipmentAndSelectedParameter(string equipmentName, string parameterName1)
        {
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, historianPage.LnkGridTab);
            Assert.IsTrue(historianPage.IsSelectParaMeter_EquipmentStatus(equipmentName), "Verified Grid tab should display values for selected equipment");
            Assert.IsTrue(historianPage.IsSelectParaMeter_EquipmentStatus(parameterName1), "Verified Grid tab should display values for selected parameter");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click on the Graph tab")]
        public void WhenClickOnTheGraphTab()
        {
            Waits.WaitAndClick(driver, historianPage.LnkGraphTab);
        }

        [Then(@"The Graph tab should display graph of selected parameter'(.*)' values against date and time")]
        public void ThenTheGraphTabShouldDisplayGraphOfSelectedParameterValuesAgainstDateAndTime(string parameterName3)
        {
            Waits.WaitForElementVisible(driver, historianPage.LnkGraphTab);
            Assert.IsTrue(historianPage.ISGraphDisplayedParameterNew(parameterName3), "Verified the Graph tab should display graph of selected parameter values against date and time");
            Waits.Wait(driver, 1000);
        }

        [When(@"Mark the Alerts and Equipment Status check box on top and click \[Apply]")]
        public void WhenMarkTheAlertsAndEquipmentStatusCheckBoxOnTopAndClickApply()
        {
            if (historianPage.EquptAlertcheckbox.GetAttribute("src").Contains("chk_off"))
            {
                Waits.WaitAndClick(driver, historianPage.EquptAlertcheckbox);
            }
            Waits.WaitAndClick(driver, historianPage.BtnApplyFilter);
        }

        [Then(@"Both the Grid and Graph tabs should display values of Alerts Message'(.*)' and Equipment status")]
        public void ThenBothTheGridAndGraphTabsShouldDisplayValuesOfAlertsMessageAndEquipmentStatus(string message)
        {
            Waits.Wait(driver, 25000);
            Waits.WaitAndClick(driver, historianPage.BtnApplyFilter);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, historianPage.LnkGridTab);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(historianPage.IsAlertHistoryDataPresent(message), "Verified Grid tabs should display values of Alerts");
            Waits.Wait(driver, 1000);
        }

        [When(@"Clear alert against a Parameter '(.*)'")]
        public void ThenClearAlertAgainstAParameter(string parameter)
        {
            simulator.RestoreWindow();
            simulator.ClearAlert(parameter);
            simulator.MinimizeWindow();
        }

        [When(@"Add one more parameter'(.*)'to the list")]
        public void WhenAddOneMoreParameterToTheList(string parameter1)
        {
            historianPage.SelectSingleParameter(parameter1);
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, historianPage.BtnAddParameter);
            Waits.WaitAndClick(driver, historianPage.BtnAddParameter);
            Waits.Wait(driver, 2000);
        }
        
        [Then(@"Both the Grid and Graph tabs should display values of newly added parameter as well as previously added parameter'(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void ThenBothTheGridAndGraphTabsShouldDisplayValuesOfNewlyAddedParameterAsWellAsPreviouslyAddedParameter(string equipmentName, string parameterName1, string parameterName2, string parameterName3, string parameterName4)
        {
            Waits.WaitAndClick(driver, historianPage.LnkGridTab);
            Assert.IsTrue(historianPage.IsSelectParaMeter_EquipmentStatus(equipmentName), "Verified Grid tab should display values for selected equipment");
            Assert.IsTrue(historianPage.IsSelectParaMeter_EquipmentStatus(parameterName1), "Verified Grid tab should display values for selected parameter");
            Assert.IsTrue(historianPage.IsSelectParaMeter_EquipmentStatus(parameterName2), "Verified Grid tab should display values for selected parameter");
            Waits.WaitAndClick(driver, historianPage.LnkGraphTab);
            Assert.IsTrue(historianPage.ISGraphDisplayedParameterNew(parameterName3), "Verified the Graph tab should display graph of selected parameter values against date and time");
            Assert.IsTrue(historianPage.ISGraphDisplayedParameterNew(parameterName4), "Verified the Graph tab should display graph of selected parameter values against date and time");
            Waits.Wait(driver, 1000);
        }

        [When(@"Go to Historian->Data Extraction Utility")]
        public void WhenGoToHistorian_DataExtractionUtility()
        {
            loggingPage.NavigateToHomePage();
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, homePage.LnkDataExtractionUtility);
            Waits.WaitAndClick(driver, homePage.LnkDataExtractionUtility);
        }

        [Then(@"The Data Extraction Utility tab should be shown")]
        public void ThenTheDataExtractionUtilityTabShouldBeShown()
        {
            if (dataExtractionPage == null)
                dataExtractionPage = new DataExtractionPage(driver);
            bool res = Waits.WaitForElementVisible(driver, dataExtractionPage.LnkDataExtraction);
            Assert.IsTrue(res, "Verified screen presence the Data Extraction Utility tab");
        }

        [When(@"Click on Enable Daily Extraction Utility")]
        public void WhenClickOnEnableDailyExtractionUtility()
        {
            Waits.WaitForElementVisible(driver, dataExtractionPage.LnkDailyExtractionEnabled);
            if (dataExtractionPage.LnkDailyExtractionEnabled.GetAttribute("src").Contains("chk_off"))
            {
                Waits.WaitAndClick(driver, dataExtractionPage.LnkDailyExtractionEnabled);
            }
        }

        [Then(@"Click Settings button and check some filtering option dialogs")]
        public void ThenClickSettingsButtonAndCheckSomeFilteringOptionDialogs()
        {
            Waits.WaitAndClick(driver, dataExtractionPage.BtnChangeDailySettings);
            for (int i = 0; i < 5; i++)
            {
                Waits.Wait(driver, 1000);
                if (!ElementExtensions.isDisplayed(driver, dataExtractionPage.LnkPnlExtractionSettings))
                {
                    Waits.WaitAndClick(driver, dataExtractionPage.BtnChangeDailySettings);
                    break;
                }
                else
                {
                    continue;
                }
            }
            Waits.WaitForElementVisible(driver, dataExtractionPage.LnkPnlExtractionSettings);
            Assert.IsTrue(dataExtractionPage.LnkPnlExtractionSettings.Displayed, "Verifed screen presence extract setting tab");
            dataExtractionPage.RawDataCheckboxSelection();
            Waits.Wait(driver, 3000);
        }

        [When(@"I click on \[Save]")]
        public void WhenIClickOnSave()
        {
            dataExtractionPage.ClickOnSave();
            Waits.Wait(driver, 1000);
        }

        [Then(@"The settings screen shall hide, later tests will verify the settings have been made")]
        public void ThenTheSettingsScreenShallHideLaterTestsWillVerifyTheSettingsHaveBeenMade()
        {
            for (int i = 0; i < 5; i++)
            {
                Waits.Wait(driver, 1000);
                if (!ElementExtensions.isDisplayed(driver, dataExtractionPage.BtnChangeDailySettings))
                {
                    dataExtractionPage.ClickOnSave();
                    continue;
                }
                else
                {
                    break;
                }
            }
            Waits.WaitForElementVisible(driver, dataExtractionPage.BtnChangeDailySettings);
            Assert.IsTrue(!ElementExtensions.isDisplayed(driver, dataExtractionPage.LnkPnlExtractionSettings), "Verifed screen hide extract setting tab");

            Waits.WaitAndClick(driver, dataExtractionPage.BtnChangeDailySettings);
            Waits.Wait(driver, 8000);
            for (int i = 0; i < 5; i++)
            {
                Waits.Wait(driver, 1000);
                if (!ElementExtensions.isDisplayed(driver, dataExtractionPage.LnkPnlExtractionSettings))
                {
                    Waits.WaitAndClick(driver, dataExtractionPage.BtnChangeDailySettings);
                    continue;
                }
                else
                {
                    break;
                }
            }
            Waits.Wait(driver, 1000);
            Assert.IsTrue(dataExtractionPage.LnkStatusCheckBox.GetAttribute("src").Contains("on"), "Verified settings have been made");
        }

        [When(@"Select some equipment via Change Selection button on under Selected Systems list")]
        public void WhenSelectSomeEquipmentViaChangeSelectionButtonOnUnderSelectedSystemsList()
        {
            dataExtractionPage.ClickOnChangeSelection_SelectedSystems();
        }

        [Then(@"Search Equipments using a variety of search conditions")]
        public void ThenSearchEquipmentsUsingAVarietyOfSearchConditions()
        {
            for (int i = 0; i < 5; i++)
            {
                if (!ElementExtensions.isDisplayed(driver, dataExtractionPage.BtnSearchSystem))
                {
                    dataExtractionPage.ClickOnChangeSelection_SelectedSystems();
                    continue;
                }
                else
                {
                    break;
                }
            }
            dataExtractionPage.ClickOnSearchSystem();
            Waits.Wait(driver, 1000);
        }

        [When(@"some System'(.*)' are selected, click on the move button \(either \[>] or \[>>]\)")]
        public void WhenSomeSystemAreSelectedClickOnTheMoveButtonEitherOr(string system)
        {
            for (int i = 0; i < 2; i++)
            {
                if (!dataExtractionPage.IsSystemExist(system))
                {
                    dataExtractionPage.ClickOnSearchSystem();
                    continue;
                }
                else
                {
                    break;
                }
            }
            dataExtractionPage.SelectSingleSystem(system);
            Waits.Wait(driver, 1000);
            dataExtractionPage.CliclkOnMoveSingleSystem();
            Waits.Wait(driver, 1000);
        }

        [Then(@"The selected equipment'(.*)' should appear in the ride hand pane")]
        public void ThenTheSelectedEquipmentShouldAppearInTheRideHandPane(string equipment)
        {
            for (int i = 0; i < 5; i++)
            {
                if (dataExtractionPage.IsSelectedSystemsPresent(equipment))
                {
                    Assert.IsTrue(dataExtractionPage.IsSelectedSystemsPresent(equipment), "Verified selected equipment should appear in the ride hand pane");
                    break;
                }
                else
                {
                    dataExtractionPage.SelectSingleSystem(equipment);
                    Waits.Wait(driver, 1000);
                    dataExtractionPage.CliclkOnMoveSingleSystem();
                    Waits.Wait(driver, 1000);
                    continue;
                }
            }
        }

        [When(@"click on the Apply Button")]
        public void WhenClickOnTheApplyButton()
        {
            dataExtractionPage.ClickOnApply();
        }

        [Then(@"Extraction system settings screen shall hide")]
        public void ThenExtractionSystemSettingsScreenShallHide()
        {
            Waits.Wait(driver, 20000);
            Waits.WaitForElementVisible(driver, dataExtractionPage.BtnChangesSelectionGroups);
            Assert.IsFalse(ElementExtensions.isDisplayed(driver, dataExtractionPage.LnkPnlDataExtractionSystems), "Verified DataExtraction system settings not presence in the screen");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select some Groups via Change Selection button on under Selected Groups list")]
        public void WhenSelectSomeGroupsViaChangeSelectionButtonOnUnderSelectedGroupsList()
        {
            dataExtractionPage.ClickOnChangeSelection_SelectedGroups();
            Waits.Wait(driver, 5000);
        }

        [When(@"Mark groups under either PTCs, User folders and Equipment Type node")]
        public void ThenMarkGroupsUnderEitherPTCsUserFoldersAndEquipmentTypeNode()
        {
            dataExtractionPage.GroupCheckboxSelection();
            Waits.Wait(driver, 2000);
        }

        [When(@"Click on the Apply Button")]
        public void ThenClickOnTheApplyButton()
        {
            dataExtractionPage.ClickOnApply();
            Waits.Wait(driver, 2000);
        }

        [When(@"I Click on the Save Button")]
        public void WhenIClickOnTheSaveButton()
        {
            Waits.WaitForElementVisible(driver, dataExtractionPage.LnkbtnSave);
            dataExtractionPage.ClickOnSave();
            Waits.Wait(driver, 2000);
        }

        [Then(@"The Extraction system settings screen shall hide")]
        public void ThenTheExtractionSystemSettingsScreenShallHide()
        {
            Waits.WaitForElementVisible(driver, dataExtractionPage.BtnChangeDailySettings);
            Assert.IsFalse(ElementExtensions.isDisplayed(driver, dataExtractionPage.LnkPnlDataExtractionSystems), "Verified DataExtraction system settings not presence in the screen");
            Waits.Wait(driver, 1000);
        }

        [When(@"Return to the EdCentra Home screen, then return to daily extraction utility \(specifically the Daily Extraction Settings button\.\)")]
        public void WhenReturnToTheEdCentraHomeScreenThenReturnToDailyExtractionUtilitySpecificallyTheDailyExtractionSettingsButton_()
        {
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            loggingPage.NavigateToHomePage();
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.NavigateToDataExtractionPage();
            Waits.Wait(driver, 8000);
            if (dataExtractionPage == null)
                dataExtractionPage = new DataExtractionPage(driver);
            Waits.WaitForElementVisible(driver, dataExtractionPage.BtnChangeDailySettings);
            Waits.WaitAndClick(driver, dataExtractionPage.BtnChangeDailySettings);
            Waits.WaitForElementVisible(driver, dataExtractionPage.LnkPnlExtractionSettings);
        }

        [Then(@"The settings previously made System'(.*)' and Group '(.*)' '(.*)'should be shown")]
        public void ThenTheSettingsPreviouslyMadeSystemAndGroupShouldBeShown(string System, string Group1, string Group2)
        {
            Waits.WaitForElementVisible(driver, dataExtractionPage.LnkStatusCheckBox);
            Assert.IsTrue(dataExtractionPage.LnkStatusCheckBox.GetAttribute("src").Contains("on"), "Verified settings have been made");
            Assert.IsTrue(dataExtractionPage.IsCurrentSelectedSystemsPresent(System), "Verified selected systems available");
            Assert.IsTrue(dataExtractionPage.IsSelectedGroupPresent(Group1), "Verified selected group availale");
            Assert.IsTrue(dataExtractionPage.IsSelectedGroupPresent(Group2), "Verified selected group availale");
            dataExtractionPage.ClickOnSave();
        }

        [When(@"Check some filtering option for Row data\. Type in Description and select start and End date\.")]
        public void WhenCheckSomeFilteringOptionForRowData_TypeInDescriptionAndSelectStartAndEndDate_()
        {
            if (dataExtractionPage == null)
                dataExtractionPage = new DataExtractionPage(driver);
            dataExtractionPage.DeleteFolderExists();
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            loggingPage.NavigateToHomePage();
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkDataExtractionUtility);
            if (dataExtractionPage == null)
                dataExtractionPage = new DataExtractionPage(driver);
            ElementExtensions.DoubleClick(driver, dataExtractionPage.BtnCreateExtraction);
            for (int i = 0; i < 5; i++)
            {
                Waits.Wait(driver, 1000);
                if (!ElementExtensions.isDisplayed(driver, dataExtractionPage.LnkPnlExtractionSettings))
                {
                    Waits.WaitAndClick(driver, dataExtractionPage.BtnCreateExtraction);
                    continue;
                }
                else
                {
                    break;
                }
            }
            dataExtractionPage.RawDataCheckboxSelection();
            Waits.Wait(driver, 1000);
            dataExtractionPage.EnterDescriptionValue(GlobalConstants.DataExtractionDescription);
            Waits.Wait(driver, 1000);
            dataExtractionPage.ExtractSystemDate();
        }

        [Then(@"The changes previously made should be shown")]
        public void ThenTheChangesPreviouslyMadeShouldBeShown()
        {
            Waits.WaitForElementVisible(driver, dataExtractionPage.LnkParametersCheckBox);
            Assert.IsTrue(dataExtractionPage.LnkParametersCheckBox.GetAttribute("src").Contains("on"), "Verified changes previously made should shown");
        }

        [When(@"I Click on the Apply Button")]
        public void WhenIClickOnTheApplyButton()
        {
            dataExtractionPage.ClickOnApply();
        }

        [Then(@"The selected equipment should appear in Selected System'(.*)' list The selected Group'(.*)' '(.*)' should appear in the selected groups list")]
        public void ThenTheSelectedEquipmentShouldAppearInSelectedSystemListTheSelectedGroupShouldAppearInTheSelectedGroupsList(string System, string Group1, string Group2)
        {
            for (int i = 0; i < 5; i++)
            {
                if (!ElementExtensions.isDisplayed(driver, dataExtractionPage.BtnHistoricDataExtract))
                {
                    Waits.Wait(driver, 1000);
                    dataExtractionPage.ClickOnApply();
                    continue;
                }
                else
                {
                    break;
                }
            }
            Assert.IsTrue(dataExtractionPage.IsCurrentSelectedSystemsPresent(System), "Verified The selected equipment should appear in Selected System list");
            Assert.IsTrue(dataExtractionPage.IsSelectedGroupPresent(Group1), "Verified The selected Group should appear in the selected groups list");
            Assert.IsTrue(dataExtractionPage.IsSelectedGroupPresent(Group2), "Verified The selected Group should appear in the selected groups list");
        }

        [When(@"press \[Extract]")]
        public void WhenPressExtract()
        {
            Waits.WaitAndClick(driver, dataExtractionPage.BtnHistoricDataExtract);
        }

        [Then(@"A message stating The Historic Extraction Utility is currently extracting should display with a wait icon")]
        public void ThenAMessageStatingTheHistoricExtractionUtilityIsCurrentlyExtractingShouldDisplayWithAWaitIcon()
        {
            Waits.WaitForElementVisible(driver, dataExtractionPage.LblExtractionMessage);
            Assert.IsTrue(dataExtractionPage.LblExtractionMessage.Text.Contains("The Historic Extraction Utility is currently extracting data"), "Verified the historic extraction utility is currently extracting With a wait icon");
            bool res = Waits.WaitForElementVisible(driver, dataExtractionPage.LblWaitIcon);
            Assert.IsTrue(res, "Verified loading icon");
        }

        [When(@"Once the extraction is complete, look on the local file system of the server under path")]
        public void WhenOnceTheExtractionIsCompleteLookOnTheLocalFileSystemOfTheServerUnderPath()
        {
            Assert.IsTrue(dataExtractionPage.isFolderExist(), "verified extraction folder Exists under the server");
        }

        [Then(@"There should be a folder named yyyy-mm-dd inside of which should be a ZIP file with the same filename and its contains CSV files")]
        public void ThenThereShouldBeAFolderNamedYyyy_Mm_DdInsideOfWhichShouldBeAZIPFileWithTheSameFilenameAndItsContainsCSVFiles()
        {
            Assert.IsTrue(dataExtractionPage.ZipFileExist(), "Verified There should be a folder named yyyy-mm-dd inside of which should be a ZIP file with the same filename ");
            Assert.IsTrue(dataExtractionPage.ExtractFileExist(), "Verified There should be ZIP file  and its contains CSV files");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select the Equipment Software Survey report from the list of reports")]
        public void WhenSelectTheEquipmentSoftwareSurveyReportFromTheListOfReports()
        {
            loggingPage.NavigateToHomePage();
            homePage.ClickOnReports();
            if (reportPage == null)
                reportPage = new ReportPage(driver);
            Waits.WaitAndClick(driver, reportPage.LnkEquipmentSoftwareSurveyReport);
        }

        [Then(@"A tree showing the current groups and folders to be displayed")]
        public void ThenATreeShowingTheCurrentGroupsAndFoldersToBeDisplayed()
        {
            if (reportPage == null)
                reportPage = new ReportPage(driver);
            Waits.WaitForElementVisible(driver, reportPage.LblEquipmentSoftwareSurveyReport);
            Assert.IsTrue(reportPage.LblEquipmentSoftwareSurveyReport.Displayed, "Verified screen presence the Equipment software survey reports");
            Waits.WaitForElementVisible(driver, reportPage.LnkSystemList);
            Assert.IsTrue(reportPage.LnkSystemList.Displayed, "Verified A tree showing the current groups and folders to be displayed");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select the node containing the EISSA simulated devices System'(.*)'")]
        public void WhenSelectTheNodeContainingTheEISSASimulatedDevicesSystem(string system)
        {
            testFolderName = (string)ScenarioContext.Current["TestFolderName"];
            reportPage.SelectSimulatedSystem(testFolderName, system);
        }

        [Then(@"A swirling icon indicating that the graph is running")]
        public void ThenASwirlingIconIndicatingThatTheGraphIsRunning()
        {
            Waits.WaitForElementVisible(driver, reportPage.LnkswirlingIcon);
            Assert.IsTrue(reportPage.LnkswirlingIcon.Displayed, "Verified A swirling icon indicating that the graph is running");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Wait for the swiling icon to disappear")]
        public void WhenWaitForTheSwilingIconToDisappear()
        {
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 1000);
                if (ElementExtensions.isDisplayed(driver, reportPage.BtnExportExcel))
                {
                    Assert.IsTrue(ElementExtensions.isDisplayed(driver, reportPage.BtnExportExcel), "Verified Wait for the swiling icon to disappear");
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        [Then(@"The report to show with serial number'(.*)' details of the various EISSA devices")]
        public void ThenTheReportToShowWithSerialNumberDetailsOfTheVariousEISSADevices(string number)
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnReports();
            if (reportPage == null)
                reportPage = new ReportPage(driver);
            Waits.WaitAndClick(driver, reportPage.LnkEquipmentSoftwareSurveyReport);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, reportPage.BtnExportExcel);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(reportPage.VerifySerialNumber(number), "Verified");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(reportPage.LblParameterSerialNumber.Text.Contains("Test:AIM Software0 151,11"), "verified");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Find equipment using equipment description and add Equipment'(.*)' to Assigned Equipment list using > and >> button then Click Apply")]
        public void WhenIFindEquipmentUsingEquipmentDescriptionAndAddEquipmentToAssignedEquipmentListUsingAndButtonThenClickApply(string equipment)
        {
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            historianPage.ClickOnFindEquipment();
            Waits.Wait(driver, 1000);
            for (int i = 0; i < 2; i++)
            {
                if (historianPage.IsUnAssignedEquipmentPresent(equipment))
                {
                    Waits.WaitAndClick(driver, historianPage.BtnMoveAllSystemsTo);
                    break;
                }
                else
                {
                    historianPage.ClickOnFindEquipment();
                    continue;
                }
            }
        }

        [Then(@"The assigned Equipment'(.*)' should appear in the ride hand pane and I click apply button")]
        public void ThenTheAssignedEquipmentShouldAppearInTheRideHandPaneAndIClickApplyButton(string equipment)
        {
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            Assert.IsTrue(historianPage.IsAssignedEquipmentPresent(equipment), "Verified assigned equipment should appear in the ride hand pane");
            historianPage.ClickOnApply();
            Waits.Wait(driver, 2000);
        }

        [When(@"Navigate to Historian -> Equipment Data Select a piece of System and Equipment '(.*)' that is logging data \(and also of which you have another of this exact equipment type\)")]
        public void WhenNavigateToHistorian_EquipmentDataSelectAPieceOfSystemAndEquipmentThatIsLoggingDataAndAlsoOfWhichYouHaveAnotherOfThisExactEquipmentType(string Equipment)
        {
            testFolderName = (string)ScenarioContext.Current["TestFolderName"];

            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            loggingPage.NavigateToHomePage();
            Waits.Wait(driver, 1000);
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.NavigateToHistorianPage();
            Waits.Wait(driver, 1000);
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            historianPage.ExpandSystemsParameter(testFolderName);
            Waits.Wait(driver, 1000);
            historianPage.SelectSingleParameterEquipment(Equipment);
            Waits.Wait(driver, 12000);
        }

        [When(@"I select '(.*)' option from the filter dropdown")]
        public void WhenISelectOptionFromTheFilterDropdown(string text)
        {
            ElementExtensions.SelectByText(historianPage.DrpDownFilterType, text);
            Waits.Wait(driver, 1000);
        }

        [When(@"I enter the value '(.*)' in the filter text box and click apply button")]
        public void WhenIEnterTheValueInTheFilterTextBoxAndClickApplyButton(string filterText)
        {
            Waits.Wait(driver, 80000);
            historianPage.TxtFilter.SendKeys(filterText);
            Waits.Wait(driver, 1000);
            historianPage.LnkApply.Click();
            Waits.Wait(driver, 3000);
        }

        [Then(@"the search serial number grid will appear with the data filtered")]
        public void ThenTheSearchSerialNumberGridWillAppearWithTheDataFiltered()
        {
            bool flag = false;
            for (int i = 1; i <= 10; i++)
            {
                if (!historianPage.IsDivSerialNumberExists)
                {          
                    historianPage.TxtFilter.Clear();
                    historianPage.LnkApply.Click();
                    Waits.Wait(driver, 80000);
                    historianPage.TxtFilter.SendKeys("Test");
                    Waits.Wait(driver, 2000);
                    historianPage.LnkApply.Click();
                    Waits.Wait(driver,3000);
                    flag = historianPage.IsDivSerialNumberExists;
                }
                if (flag)
                    break;
            }
            Assert.IsTrue(flag);
                
        }

        [When(@"I select any single system on the filtered serial number data and click Apply button")]
        public void WhenISelectAnySingleSystemOnTheFilteredSerialNumberDataAndClickApplyButton()
        {
            historianPage.ApplySerialNumberFilterForSingleSystem();
        }

        [Then(@"the filtered system should alone appear under Systems folder")]
        public void ThenTheFilteredSystemShouldAloneAppearUnderSystemsFolder()
        {
            Assert.AreEqual(1,historianPage.NumberOfSystemsDisplayed());
        }


        [Then(@"Parameter'(.*)'listed of which we have data to plot for Equipment'(.*)'")]
        public void ThenParameterListedOfWhichWeHaveDataToPlotForEquipment(string Parameter, string Equipment)
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

        //[Then(@"Parameter'(.*)'listed of which we have data to plot")]
        //public void ThenParameterListedOfWhichWeHaveDataToPlot(string Parameter)
        //{
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        Waits.Wait(driver, 1000);
        //        if (historianPage.IsSelectedParameterListPresent(Parameter))
        //        {
        //            Assert.IsTrue(historianPage.IsSelectedParameterListPresent(Parameter), "Verified The parameters for that equipment will be displayed");
        //            break;
        //        }
        //        else
        //        {
        //            driver.Navigate().Refresh();
        //            historianPage.SelectSingleParameterEquipment(Equipment);
        //            Waits.Wait(driver, 1000);
        //            continue;
        //        }
        //    }
        //}

        [When(@"Select at least one Parameter'(.*)' that has logged data, preferably an analogue parameter such as Temperature, Power, Speed etc\. You can multi-select by holding the ctrl key down while selecting")]
        public void WhenSelectAtLeastOneParameterThatHasLoggedDataPreferablyAnAnalogueParameterSuchAsTemperaturePowerSpeedEtc_YouCanMulti_SelectByHoldingTheCtrlKeyDownWhileSelecting(string Parameter)
        {
            historianPage.SelectSingleParameter(Parameter);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Click the lock button when you selection is complete \(the one with the closed padlock symbol\)")]
        public void ThenClickTheLockButtonWhenYouSelectionIsCompleteTheOneWithTheClosedPadlockSymbol()
        {
            historianPage.LockParaMeters();
            Waits.Wait(driver, 1000);
        }

        [When(@"Data for all selected Parameter'(.*)' is shown in the data grid")]
        public void WhenDataForAllSelectedParameterIsShownInTheDataGrid(string Parameter)
        {
            Waits.WaitAndClick(driver, historianPage.LnkGridTab);
            Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, historianPage.LnkGridTab);
            Waits.Wait(driver, 3000);
            Assert.IsTrue(historianPage.IsSelectParaMeter_EquipmentStatus(Parameter), "Verified Data for all selected parameters is shown in the data grid");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Lock icon turns to an unlock icon \(with an open padlock icon\)")]
        public void ThenLockIconTurnsToAnUnlockIconWithAnOpenPadlockIcon()
        {
            Waits.WaitForElementVisible(driver, historianPage.BtnUnLockParaMeters);
            Assert.IsTrue(historianPage.BtnUnLockParaMeters.GetAttribute("title").Contains("Unlock"), "Verified UnLock icon turns to an lock icon");
            Waits.Wait(driver, 1000);
        }

        [When(@"I click  the Graph tab")]
        public void WhenIClickTheGraphTab()
        {
            Waits.WaitAndClick(driver, historianPage.LnkGraphTab);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Graph is displayed with your selection of Parameter'(.*)' plot against each other")]
        public void ThenGraphIsDisplayedWithYourSelectionOfParameterPlotAgainstEachOther(string parameter)
        {
            Waits.WaitForElementVisible(driver, historianPage.LnkGraphTab);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(historianPage.ISGraphDisplayedParameterNew(parameter), "Verified Graph is displayed with your selection of parameters plot against each other");
            Waits.Wait(driver, 1000);
        }
                
        [When(@"Choose another System'(.*)' of the same type from the system tree")]
        public void WhenChooseAnotherSystemOfTheSameTypeFromTheSystemTree(string system)
        {
            historianPage.SelectSingleParameterEquipment(system);
            Waits.Wait(driver, 3000);
        }

        [Then(@"if you have previously plot parameters from a Turbo device, you musts select a different Turbo device Parameter'(.*)'")]
        public void ThenIfYouHavePreviouslyPlotParametersFromATurboDeviceYouMustsSelectADifferentTurboDeviceParameter(string parameter)
        {
            historianPage.SelectSingleParameter(parameter);
            Waits.Wait(driver, 3000);
            historianPage.Add_EquipmentStatus_ParaMeter();
            Waits.Wait(driver, 4000);
        }

        [When(@"Graph is redrawn but with Parameter'(.*)' substituted in from the newly selected system")]
        public void WhenGraphIsRedrawnButWithParameterSubstitutedInFromTheNewlySelectedSystem(string parameter)
        {
            Assert.IsTrue(historianPage.ISGraphDisplayedParameterNew(parameter), "Verified Graph is displayed with your selection of parameters plot against each other");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Click the unlock button \(with an open padlock icon\)")]
        public void ThenClickTheUnlockButtonWithAnOpenPadlockIcon()
        {
            historianPage.UnLockParaMeters();
            Waits.WaitForElementVisible(driver, historianPage.BtnLockParaMeters);
            Assert.IsTrue(historianPage.BtnLockParaMeters.GetAttribute("title").Contains("Lock"), "Verified Lock icon turns to an Unlock icon");
            Waits.Wait(driver, 1000);
        }

        [When(@"select any other System'(.*)'from the system tree")]
        public void WhenSelectAnyOtherSystemFromTheSystemTree(string system)
        {
            historianPage.SelectSingleParameterEquipment(system);
            Waits.Wait(driver, 3000);
        }


        [When(@"allow you from any other System'(.*)' to add any others Parameter'(.*)'")]
        public void WhenAllowYouFromAnyOtherSystemToAddAnyOthersParameter(string system, string parameter)
        {
            Waits.Wait(driver, 3000);
            historianPage.SingleEquipment(system);
            Waits.Wait(driver, 3000);
            historianPage.SelectSingleParameter(parameter);
            Waits.Wait(driver, 3000);
            historianPage.Add_EquipmentStatus_ParaMeter();
            Waits.Wait(driver, 3000);
        }

        [Then(@"Graph should not refresh and substitute parameters'(.*)' as before\. It should keep whatever parameters were previously selected")]
        public void ThenGraphShouldNotRefreshAndSubstituteParametersAsBefore_ItShouldKeepWhateverParametersWerePreviouslySelected(string parameter)
        {
            Assert.IsTrue(historianPage.ISGraphDisplayedParameterNew(parameter), "Verified Graph is displayed with your selection of parameters plot against each other");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Graph should redrawn with Parameter'(.*)' substituted in from the newly selected system")]
        public void ThenGraphShouldRedrawnWithParameterSubstitutedInFromTheNewlySelectedSystem(string parameter)
        {
            Assert.IsTrue(historianPage.ISGraphDisplayedParameterNew(parameter), "Verified Graph is displayed with your selection of parameters plot against each other");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click the Edit Parameters button below the graph")]
        public void WhenClickTheEditParametersButtonBelowTheGraph()
        {
            Waits.WaitTillElementIsClickable(driver, historianPage.LnkEditParaMeters);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Edit parameters box opens with a remove option for each parameter and an editor for the Lower and Upper limit of each unit type")]
        public void ThenEditParametersBoxOpensWithARemoveOptionForEachParameterAndAnEditorForTheLowerAndUpperLimitOfEachUnitType()
        {
            Waits.WaitForElementVisible(driver, historianPage.LnkEditParameterBox);
            Assert.IsTrue(historianPage.LnkEditParameterBox.Displayed, "Verified Edit parameters box opens");
            Waits.WaitForElementVisible(driver, historianPage.LnkParameterRemoveOption);
            Assert.IsTrue(historianPage.LnkParameterRemoveOption.Displayed, "Verified remove option for each parameter");
            Waits.Wait(driver, 1000);
        }

        [When(@"Change the lower LowerValue'(.*)' and/or upper UpperValue'(.*)' limit for a unit then click the Apply button")]
        public void WhenChangeTheLowerLowerValueAndOrUpperUpperValueLimitForAUnitThenClickTheApplyButton(string LowerValue, string UpperValue)
        {
            historianPage.ModifyParaMeters(LowerValue, UpperValue);
            Waits.Wait(driver, 4000);
        }

        [When(@"Click the clear button underneath the graph")]
        public void WhenClickTheClearButtonUnderneathTheGraph()
        {
            historianPage.ClearGraph();
            Waits.Wait(driver, 3000);
        }

        [Then(@"All your parameters selections are removed and graph is hidden")]
        public void ThenAllYourParametersSelectionsAreRemovedAndGraphIsHidden()
        {
            Assert.IsFalse(ElementExtensions.isDisplayed(driver, historianPage.LnkGraphTab), "Verified The graph are is cleared");
            Waits.Wait(driver, 2000);
        }

        [When(@"Select a System '(.*)' which has Equipment Events")]
        public void WhenSelectASystemWhichHasEquipmentEvents(string system)
        {
            historianPage.SingleEquipment(system);
            Waits.Wait(driver, 3000);
        }


        [Then(@"The parameter list, an entry called Parameter '(.*)' should appear, along with any other parameters that have been logging")]
        public void ThenTheParameterListAnEntryCalledParameterShouldAppearAlongWithAnyOtherParametersThatHaveBeenLogging(string Parameter)
        {
            Assert.IsTrue(historianPage.IsSelectedParameterListPresent(Parameter), "The parameter list, an entry called Equipment Status should appear, along with any other parameters that have been logging");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Choose Parameter '(.*)' and click the Add button")]
        public void WhenIChooseParameterAndClickTheAddButton(string Parameter)
        {
            historianPage.SelectSingleParameter(Parameter);
            Waits.Wait(driver, 3000);
            historianPage.Add_EquipmentStatus_ParaMeter();
            Waits.Wait(driver, 20000);
        }

        [Then(@"Graph should show with equipment statuses Parameter'(.*)' plot on it\. If the values tab is selected instead of the graph, click the Graph tab to show it\. Also the Equipment Status checkbox at the top should automatically be ticked when you added the Equipmentt Status item\.")]
        public void ThenGraphShouldShowWithEquipmentStatusesParameterPlotOnIt_IfTheValuesTabIsSelectedInsteadOfTheGraphClickTheGraphTabToShowIt_AlsoTheEquipmentStatusCheckboxAtTheTopShouldAutomaticallyBeTickedWhenYouAddedTheEquipmenttStatusItem_(string Parameter)
        {
            Waits.WaitForElementVisible(driver, historianPage.LnkGraphTab);
            Waits.Wait(driver, 10000);
            Assert.IsTrue(historianPage.ISGraphDisplayedParameterNew(Parameter), "Verified Graph should show with equipment statuses Parameter");
            Waits.Wait(driver, 1000);
        }

        [When(@"Log into EdCentra with an account that has acess to historian\. Click on the Historian icon")]
        public void WhenLogIntoEdCentraWithAnAccountThatHasAcessToHistorian_ClickOnTheHistorianIcon()
        {
            loggingPage.NavigateToHomePage();
            homePage.NavigateToHistorianPage();
            Waits.Wait(driver, 1000);
        }

        [Then(@"The historian page will appear\. Thre will be a button \[Load Saved Graph] on the toolbar\. This button will be disabled if there are not already some graphs saved for the current user")]
        public void ThenTheHistorianPageWillAppear_ThreWillBeAButtonLoadSavedGraphOnTheToolbar_ThisButtonWillBeDisabledIfThereAreNotAlreadySomeGraphsSavedForTheCurrentUser()
        {
            Waits.Wait(driver, 8000);
            if (dataExtractionPage == null)
                dataExtractionPage = new DataExtractionPage(driver);
            Waits.WaitForElementVisible(driver, dataExtractionPage.LnkDataExtraction);
            Assert.IsTrue(dataExtractionPage.LnkDataExtraction.Displayed, "Verified The historian page will appear");
            Waits.Wait(driver, 8000);
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            if (historianPage.BtnLoadSavedGrpah.Enabled)
            {
                Assert.IsFalse(historianPage.BtnLoadSavedGrpah.Enabled, "Verified Load Saved Graph button will be disabled");
            }
            Waits.Wait(driver, 1000);
        }

        [When(@"Choose a System and plot some Equipment'(.*)'")]
        public void WhenChooseASystemAndPlotSomeEquipment(string Equipment)
        {
            testFolderName = (string)ScenarioContext.Current["TestFolderName"];
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            historianPage.ExpandSystemsParameter(testFolderName);
            Waits.Wait(driver, 1000);
            historianPage.SelectSingleParameterEquipment(Equipment);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The Equipment'(.*)' Parameter'(.*)' listed of which we have data to plot")]
        public void ThenTheEquipmentParameterListedOfWhichWeHaveDataToPlot(string equipment, string parameter)
        {
            for (int i = 0; i < 15; i++)
            {
                if (historianPage.IsSelectedParameterListPresent(parameter))
                {
                    Assert.IsTrue(historianPage.IsSelectedParameterListPresent(parameter), "Verified The parameters for that equipment will be displayed");
                    Waits.Wait(driver, 1000);
                    break;
                }
                else
                {
                    driver.Navigate().Refresh();
                    Waits.Wait(driver, 8000);
                    historianPage.SelectSingleParameterEquipment(equipment);
                    continue;
                }
            }
        }

        [When(@"Select at least one Parameter'(.*)' data")]
        public void WhenSelectAtLeastOneParameterData(string Parameter)
        {
            historianPage.SelectSingleParameter(Parameter);
            Waits.Wait(driver, 1000);
            historianPage.Add_EquipmentStatus_ParaMeter();
            Waits.Wait(driver, 1000);
        }

        [Then(@"The button \[Save Graph] will appear at the bottom of the graph next to the \[Clear Button]")]
        public void ThenTheButtonSaveGraphWillAppearAtTheBottomOfTheGraphNextToTheClearButton()
        {
            bool res = Waits.WaitForElementVisible(driver, historianPage.LblSaveGraph);
            Assert.IsTrue(historianPage.LblSaveGraph.Displayed, "Verified The Save Graph button appeared");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click the \[Save Graph] button")]
        public void WhenClickTheSaveGraphButton()
        {
            Waits.WaitAndClick(driver, historianPage.LblSaveGraph);
        }

        [Then(@"The save graph modal dialog will appear\. The comments box will be populated with the system id and the parameters previosuly selected")]
        public void ThenTheSaveGraphModalDialogWillAppear_TheCommentsBoxWillBePopulatedWithTheSystemIdAndTheParametersPreviosulySelected()
        {
            Waits.WaitForElementVisible(driver, historianPage.LnkSaveGraphModalDialog);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, historianPage.LnkSaveGraphModalDialog), "Verified the save graph modal dialog appeared");
        }

        [When(@"Click \[Cance] in the save graph modal dialog")]
        public void WhenClickCanceInTheSaveGraphModalDialog()
        {
            Waits.WaitAndClick(driver, historianPage.BtnSaveGraphCancel);
        }

        [Then(@"The modal dialog is hidden")]
        public void ThenTheModalDialogIsHidden()
        {
            Assert.IsTrue(!ElementExtensions.isDisplayed(driver, historianPage.LnkSaveGraphModalDialog), "Verified the save graph modal dialog hiddened");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click the \[Save Graph] button and click \[OK] without entering a name in the Name field")]
        public void WhenClickTheSaveGraphButtonAndClickOKWithoutEnteringANameInTheNameField()
        {
            Waits.WaitAndClick(driver, historianPage.LblSaveGraph);
            Waits.WaitAndClick(driver, historianPage.BtnSaveGraphOK);
        }

        [Then(@"Message'(.*)' is displayed")]
        public void ThenMessageIsDisplayed(string Message)
        {
            Waits.WaitForElementVisible(driver, historianPage.LblSaveGraphMessage);
            Assert.IsTrue(historianPage.LblSaveGraphMessage.Text.Contains(Message), "Verified Name Cannot be blank message is displayed");
            Waits.Wait(driver, 1000);
        }

        [When(@"Enter a name in the GraphName '(.*)' field and click \[OK]")]
        public void WhenEnterANameInTheGraphNameFieldAndClickOK(string graphName)
        {
            historianPage.EnterGraphName(graphName);
            Waits.WaitAndClick(driver, historianPage.BtnSaveGraphOK);
        }

        [Then(@"The Message '(.*)'is displayed in the toolbar next to the Load Saved Graph button/ The Load Saved Graph button is now enabled")]
        public void ThenTheMessageIsDisplayedInTheToolbarNextToTheLoadSavedGraphButtonTheLoadSavedGraphButtonIsNowEnabled(string message)
        {
            Waits.WaitForElementVisible(driver, historianPage.LblFilterMessage);
            Assert.IsTrue(historianPage.LblFilterMessage.Text.Contains(message), "Verified The message graph name : Save was successful is displayed");
        }

        [When(@"Click \[Clear] to clear the graph")]
        public void WhenClickClearToClearTheGraph()
        {
            Waits.WaitAndClick(driver, historianPage.LblClearAll);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The graph are is cleared")]
        public void ThenTheGraphAreIsCleared()
        {
            bool res = false;
            for (int i = 1; i <= 15; i++)
            {
                if (ElementExtensions.isDisplayed(driver, historianPage.LnkGraphTab))
                {
                    Waits.Wait(driver, 1000);
                    continue;
                }
                else
                {
                    res = true;
                    break;
                }
            }
            Assert.IsTrue(res, "Graph is not cleared");
        }

        [When(@"Click \[Load Saved Graph]")]
        public void WhenClickLoadSavedGraph()
        {
            Waits.WaitAndClick(driver, historianPage.BtnLoadSavedGrpah);
        }

        [Then(@"The load saved graph modal dialog is displayed")]
        public void ThenTheLoadSavedGraphModalDialogIsDisplayed()
        {
            Waits.Wait(driver, 5000);
            Waits.WaitForElementVisible(driver, historianPage.LnkLoadSaveGraphModalDialog);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, historianPage.LnkLoadSaveGraphModalDialog), "Verified The load saved graph modal dialog is displayed");
        }

        [When(@"Click \[Cancel]")]
        public void WhenClickCancel()
        {
            Waits.WaitAndClick(driver, historianPage.BtnLoadSavedGraphCancel);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The modal dialog is closed")]
        public void ThenTheModalDialogIsClosed()
        {
            Assert.IsFalse(ElementExtensions.isDisplayed(driver, historianPage.LnkLoadSaveGraphModalDialog), "Verified The load saved graph modal dialog is displayed");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click the \[Load Saved Graph] button and choose the GraphName'(.*)' in the dropdown box\. Click \[OK]")]
        public void WhenClickTheLoadSavedGraphButtonAndChooseTheGraphNameInTheDropdownBox_ClickOK(string graphName)
        {
            Waits.WaitAndClick(driver, historianPage.BtnLoadSavedGrpah);
            historianPage.SelectSavedGraph(graphName);
            Waits.WaitAndClick(driver, historianPage.BtnLoadSavedGraphOK);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The modal dialog is closed and the graph is displayed using the start date, end date, Parameter '(.*)' '(.*)', zoom level and axis and systems previously saved")]
        public void ThenTheModalDialogIsClosedAndTheGraphIsDisplayedUsingTheStartDateEndDateParameterZoomLevelAndAxisAndSystemsPreviouslySaved(string equipment, string parameter)
        {
            Assert.IsFalse(ElementExtensions.isDisplayed(driver, historianPage.LnkLoadSaveGraphModalDialog), "Verified The load saved graph modal dialog is displayed");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(historianPage.ISGraphDisplayedParameterNew(equipment), "Verified Graph is displayed with previously selection of equipment plot");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(historianPage.ISGraphDisplayedParameterNew(parameter), "Verified Graph is displayed with previously selection of parameters plot");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click \[Save Graph] and \[OK]")]
        public void WhenClickSaveGraphAndOK()
        {
            Waits.WaitAndClick(driver, historianPage.LblSaveGraph);
            Waits.WaitAndClick(driver, historianPage.BtnSaveGraphOK);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The Message'(.*)' is displayed\. Yes and No buttons are displayed")]
        public void ThenTheMessageIsDisplayed_YesAndNoButtonsAreDisplayed(string Message)
        {
            Waits.WaitForElementVisible(driver, historianPage.LblSaveGraphMessage);
            Assert.IsTrue(historianPage.LblSaveGraphMessage.Text.Contains(Message), "Verified Unable to save graph, the name already exists. Would you like to overwrite the existing graph ? is displayed");
            Waits.WaitForElementVisible(driver, historianPage.BtnSaveGraphYes);
            Assert.IsTrue(historianPage.BtnSaveGraphYes.Displayed, "Verified Yes button is displayed");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Click No")]
        public void WhenIClickNo()
        {
            Waits.WaitAndClick(driver, historianPage.BtnSaveGraphNo);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The buttons are reverted to their previous state of OK and Cancel")]
        public void ThenTheButtonsAreRevertedToTheirPreviousStateOfOKAndCancel()
        {
            Waits.WaitForElementVisible(driver, historianPage.BtnSaveGraphCancel);
            Assert.IsTrue(historianPage.BtnSaveGraphCancel.Displayed, "Verified The buttons are reverted to their previous state of OK and Cancel");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Click \[OK] and \[Yes]")]
        public void WhenIClickOKAndYes()
        {
            Waits.WaitAndClick(driver, historianPage.BtnSaveGraphOK);
            Waits.WaitAndClick(driver, historianPage.BtnSaveGraphYes);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The modal dialog is closed and the success Message'(.*)' is displayed")]
        public void ThenTheModalDialogIsClosedAndTheSuccessMessageIsDisplayed(string Message)
        {
            Assert.IsTrue(!ElementExtensions.isDisplayed(driver, historianPage.LnkLoadSaveGraphModalDialog), "Verified The load saved graph modal dialog is closed");
            Waits.WaitForElementVisible(driver, historianPage.LblFilterMessage);
            Assert.IsTrue(historianPage.LblFilterMessage.Text.Contains(Message), "Verified The message graph name : Save was successful is displayed");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Click the \[Save Graph] button and choose a GraphName '(.*)' field")]
        public void WhenIClickTheSaveGraphButtonAndChooseAGraphNameField(string graphName)
        {
            Waits.WaitAndClick(driver, historianPage.BtnLoadSavedGrpah);
            historianPage.SelectSavedGraph(graphName);
            Waits.Wait(driver, 1000);
        }

        [When(@"I Click \[Delete graph]")]
        public void ThenIClickDeleteGraph()
        {
            Waits.WaitAndClick(driver, historianPage.BtnLoadSavedGraphDelete);
            Waits.WaitAndClick(driver, historianPage.LblClearAll);
            Waits.Wait(driver, 1000);
        }

        [When(@"Create and save some more graphs using different System '(.*)' and Parameter'(.*)'")]
        public void WhenCreateAndSaveSomeMoreGraphsUsingDifferentSystemAndParameter(string system, string parameter)
        {
            historianPage.SingleEquipment(system);
            Waits.Wait(driver, 1000);
            historianPage.SelectSingleParameter(parameter);
            Waits.Wait(driver, 1000);
            historianPage.Add_EquipmentStatus_ParaMeter();
        }

        [When(@"Click the \[Save Graph] button and Enter a name in the GraphName '(.*)' field and click \[OK]")]
        public void ThenClickTheSaveGraphButtonAndEnterANameInTheGraphNameFieldAndClickOK(string graphName)
        {
            Waits.WaitAndClick(driver, historianPage.LblSaveGraph);
            historianPage.EnterGraphName(graphName);
            Waits.WaitAndClick(driver, historianPage.BtnSaveGraphOK);
        }

        [When(@"Click \[Load Saved Graph] and choose a GraphName'(.*)' from the list\. Click \[Delete graph]")]
        public void WhenClickLoadSavedGraphAndChooseAGraphNameFromTheList_ClickDeleteGraph(string GraphName)
        {
            Waits.WaitAndClick(driver, historianPage.BtnLoadSavedGrpah);
            historianPage.SelectSavedGraph(GraphName);
            Waits.WaitAndClick(driver, historianPage.BtnLoadSavedGraphDelete);
            Waits.WaitAndClick(driver, historianPage.LblClearAll);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The message Graph deleted successfully is displayed\. The item is removed from the list\. If the item was the last item in the list the modal dialog is closed\. The \[Load Saved Graph] button will be disabled if all of the saved graphs have been removed")]
        public void ThenTheMessageGraphDeletedSuccessfullyIsDisplayed_TheItemIsRemovedFromTheList_IfTheItemWasTheLastItemInTheListTheModalDialogIsClosed_TheLoadSavedGraphButtonWillBeDisabledIfAllOfTheSavedGraphsHaveBeenRemoved()
        {
            Assert.IsFalse(ElementExtensions.isDisplayed(driver, historianPage.LnkLoadSaveGraphModalDialog), "Verified The load saved graph modal dialog is closed");
            Waits.Wait(driver, 1000);
            Assert.IsFalse(historianPage.BtnLoadSavedGrpah.Enabled, "Verified Load Saved Graph button will be disabled");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Opened the User Manager application, and click on the ‘Maintain Users’ tab\.Click on Create User link")]
        public void WhenIOpenedTheUserManagerApplicationAndClickOnTheMaintainUsersTab_ClickOnCreateUserLink()
        {
            loggingPage.NavigateToHomePage();
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            Waits.WaitAndClick(driver, userPage.LnkMaintainUser);
            Waits.WaitAndClick(driver, userPage.LinkCreateUser);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Create User form is displayed")]
        public void ThenCreateUserFormIsDisplayed()
        {
            Waits.WaitForElementVisible(driver, userPage.LblCreateUser);
            Assert.IsTrue(userPage.LblCreateUser.Displayed, "Verified Create User Label on Create User form");
        }

        [When(@"I Clicked Create")]
        public void WhenIClickedCreate()
        {
            Waits.WaitAndClick(driver, userPage.BtnCreateUser);
        }

        [Then(@"The Required Field text should appear besides User Name, Password, confirm, First Name, Last Name and e-mail field")]
        public void ThenTheRequiredFieldTextShouldAppearBesidesUserNamePasswordConfirmFirstNameLastNameAndE_MailField()
        {
            Assert.IsTrue(userPage.MsgUserNameRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for User name");
            Assert.IsTrue(userPage.MsgPasswordRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for Password");
            Assert.IsTrue(userPage.MsgCfmPasswordRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for Confirm Passowrd");
            Assert.IsTrue(userPage.MsgFirstNameRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for First name");
            Assert.IsTrue(userPage.MsgLastNameRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for Last name");
            Assert.IsTrue(userPage.MsgEmailRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for Email");
        }

        [When(@"added new User with details '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' and '(.*)' in Create user form")]
        public void WhenAddedNewUserWithDetailsAndInCreateUserForm(string userName, string pwd, string confirmPwd, string question, string ans, string firstName, string lastName, string email)
        {
            Waits.Wait(driver, 2000);
            userPage.CreateNewUser(userName, pwd, confirmPwd, question, ans, firstName, lastName, email);
            Waits.Wait(driver, 2000);
        }

        [Then(@"I Provided all application permissions")]
        public void ThenIProvidedAllApplicationPermissions()
        {
            userPage.ClickOnApplyChanges();
            Waits.WaitAndClick(driver, userPage.LnkPermission);
            Waits.WaitAndClick(driver, userPage.SelectAllCheckBox);
            Waits.WaitAndClick(driver, userPage.BtnApplyChange);
            Waits.WaitForElementVisible(driver, userPage.LblChangesApplied);
            Assert.IsTrue(userPage.LblChangesApplied.Text.Contains("Changes have been applied"), "Verified 'Changes have been applied' message");
        }

        [When(@"I got logged out")]
        public void WhenIGotLoggedOut()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkHomePage);
            Waits.Wait(driver, 1000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, homePage.LnkLoginUser);
            Waits.WaitAndClick(driver, homePage.LnkLoginUser);
            Waits.WaitAndClick(driver, homePage.LinkLogout);
        }

        [Then(@"I logon as the newly created user userName '(.*)' and password '(.*)'")]
        public void ThenILogonAsTheNewlyCreatedUserUserNameAndPassword(string username, string password)
        {
            loginPage.SignIn(username, password);
            Waits.Wait(driver, 1000);
        }

        [When(@"I navigate to the historian page")]
        public void WhenINavigateToTheHistorianPage()
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.NavigateToHistorianPage();
            Waits.Wait(driver, 1000);
        }

        [Then(@"The Load Saved Graph Button will be disabled")]
        public void ThenTheLoadSavedGraphButtonWillBeDisabled()
        {
            Assert.IsFalse(historianPage.BtnLoadSavedGrpah.Enabled, "Verified Load Saved Graph button will be disabled");
            Waits.Wait(driver, 2000);
        }

        [Then(@"I enter Administrator login again username as '(.*)' and password as '(.*)' and clicked login button")]
        public void ThenIEnterAdministratorLoginAgainUsernameAsAndPasswordAsAndClickedLoginButton(string username, string password)
        {
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LinkHomePage);
            Waits.Wait(driver, 2000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, homePage.LnkLoginUser);
            homePage.LnkLoginUser.Click();
            homePage.LinkLogout.Click();
            Waits.Wait(driver, 1000);
            loginPage.SignIn(username, password);
            Waits.Wait(driver, 3000);
        }

        [When(@"Ensure that simulators are running which result in some alerts evident for Parameter '(.*)' '(.*)' '(.*)'AlertType '(.*)' '(.*)' '(.*)' in Live alerts List")]
        public void WhenEnsureThatSimulatorsAreRunningWhichResultInSomeAlertsEvidentForParameterAlertTypeInLiveAlertsList(string Parameter1, string Parameter2, string Parameter3, string AlertType1, string AlertType2, string AlertType3)
        {
            simulator.RestoreWindow();
            Waits.Wait(driver, 2000);
            simulator.RaiseAlert(Parameter1, AlertType1);
            Waits.Wait(driver, 1000);
            simulator.RaiseAlert(Parameter2, AlertType2);
            Waits.Wait(driver, 1000);
            simulator.RaiseAlert(Parameter3, AlertType3);
            Waits.Wait(driver, 1000);
            simulator.MinimizeWindow();
            Waits.Wait(driver, 1000);
        }

        [Then(@"Live alerts present for x number of devices")]
        public void ThenLiveAlertsPresentForXNumberOfDevices()
        {
            if (reportPage == null)
                reportPage = new ReportPage(driver);
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(reportPage.LblAdvisoryCount, "1"), "Verified Advisory alerts present for number of devices");
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(reportPage.LblWarningCount, "1"), "Verified Warning alerts present for number of devices");
            Assert.IsTrue(deviceExplorerNavigationPage.VerifyText(reportPage.LblAlarmCount, "1"), "Verified Alaram alerts present for number of devices");
            Assert.IsTrue(reportPage.LblAdvisoryCount.Text.Contains("1"), "Verified Advisory alerts present for number of devices");
            Waits.Wait(driver, 2000);
        }

        [When(@"Navigate to reports")]
        public void WhenNavigateToReports()
        {
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            deviceExplorerNavigationPage.NavigateToHomePage();
            Waits.Wait(driver, 1000);
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnReports();
            Waits.Wait(driver, 2000);
        }

        [Then(@"execute the Alert report for Equipment'(.*)' you know has alerts against it")]
        public void ThenExecuteTheAlertReportForEquipmentYouKnowHasAlertsAgainstIt(string equipment)
        {
            testFolderName = (string)ScenarioContext.Current["TestFolderName"];
            if (reportPage == null)
                reportPage = new ReportPage(driver);
            Assert.IsTrue(driver.Url.Contains("Historian/ReportDashboard.aspx"), "Verified user navigated to ReportPage");
            Waits.WaitAndClick(driver, reportPage.LnkAlertReport);
            reportPage.SelectSimulatedSystem(testFolderName, equipment);
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 1000);
                if (ElementExtensions.isDisplayed(driver, reportPage.BtnExportExcel))
                {
                    Waits.WaitAndClick(driver, reportPage.BtnExportExcel);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        [Then(@"Ensure the Equipment'(.*)' is not in maintenance mode")]
        public void WhenEnsureTheEquipmentIsNotInMaintenanceMode(string equipment)
        {
            testFolderName = (string)ScenarioContext.Current["TestFolderName"];
            if (reportPage == null)
                reportPage = new ReportPage(driver);
            Waits.WaitAndClick(driver, reportPage.LnkHomePage);
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnDeviceExplorer();
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            Waits.WaitAndClick(driver, historianPage.LnkTopLevel);
            Waits.Wait(driver, 1000);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            deviceExplorerNavigationPage.ClickFindEquipment(testFolderName);
            Waits.Wait(driver, 1000);
            Assert.IsFalse(deviceExplorerNavigationPage.VerifyText(reportPage.LnkMaintenance, "0"), "Verified Ensure the Equipment is not in maintenance mode");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Report should return data matching the number of alerts present for any one device in Live alerts list")]
        public void ThenReportShouldReturnDataMatchingTheNumberOfAlertsPresentForAnyOneDeviceInLiveAlertsList()
        {
            if (reportPage == null)
                reportPage = new ReportPage(driver);
            reportPage.SelectSummaryData();
            Waits.Wait(driver, 1000);
        }
    }
}