using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class ConfugireTestsStepDefinition
    {
        string testFolderName = ElementExtensions.GetRandomString(4);
        string renameFolder = ElementExtensions.GetRandomString(4);
        LoginPage loginPage;
        HomePage homePage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        LoggingPage loggingPage;
        HistorianPage historianPage;
        ConfigurePage configurePage;
        PTMPage ptmPage;
        Simulator simulator = new Simulator();
        private IWebDriver driver;

        public ConfugireTestsStepDefinition(IWebDriver _driver)
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
            configurePage = new ConfigurePage(driver);
            ptmPage = new PTMPage(driver);
        }

        [When(@"Create a new XNIM ProfileName'(.*)' with Add Button")]
        public void WhenCreateANewXNIMProfileNameWithAddButton(string profileName)
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, homePage.LnkConfigure);
            homePage.LnkConfigure.Click();
            if (configurePage == null)
                configurePage = new ConfigurePage(driver);
            configurePage.ClickOnXNIMConfiguration();
            bool res = Waits.WaitForElementVisible(driver, configurePage.LblXNIMConfigurationPage);
            Assert.IsTrue(res, "Verifying User should be navigated to XNIMConfiguration page");
            configurePage.CreateXNIMProfile(profileName);
            Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, configurePage.BtnAddProfile);
            Waits.WaitAndClick(driver, configurePage.BtnAddProfile);
        }

        [Then(@"The Profile'(.*)' should create and added in the list of Profiles")]
        public void ThenTheProfileShouldCreateAndAddedInTheListOfProfiles(string Profile)
        {
            Assert.IsTrue(configurePage.IsProfileExist(Profile), "Verified The profile created and added in the list of profiles");
            Waits.Wait(driver, 2000);
        }

        [When(@"I Select newly created Profile'(.*)' and add a Parameter'(.*)' and some boolean logic Operator '(.*)' using New Parameter panel's add button")]
        public void WhenISelectNewlyCreatedProfileAndAddAParameterAndSomeBooleanLogicOperatorUsingNewParameterPanelSAddButton(string Profile, string ParameterName, string Operator)
        {
            configurePage.SelectCreatedProfile(Profile);
            Waits.WaitForElementVisible(driver, configurePage.LblParametersPanel);
            Assert.IsTrue(configurePage.LblParametersPanel.Text.Contains(Profile), "Verified screen presence selected newly created Profile");
            configurePage.EnterParameterName(ParameterName);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, configurePage.BtnParameterFunction);
            Waits.WaitForElementVisible(driver, configurePage.LblFunctionTitle);
            Assert.IsTrue(configurePage.LblFunctionTitle.Text.Contains("XNIM Function"), "Verfied screen presence XNIMFuctionPanel");
            configurePage.SelectBooleanOperator(Operator);
            configurePage.SelectSection();
            Waits.WaitAndClick(driver, configurePage.BtnAddParameter);
        }

        [Then(@"A new Parameter'(.*)' should be created and added in the list of Parameters for the selected profile")]
        public void ThenANewParameterShouldBeCreatedAndAddedInTheListOfParametersForTheSelectedProfile(string Parameter)
        {
            Assert.IsTrue(configurePage.IsParameterExist(Parameter), "Verified a new parameter created and added in the list of parameters for the selected profile");
        }

        [When(@"Select newly created Parameter'(.*)' and add a Alert'(.*)' and some boolean logic Operator'(.*)'using New Alert panel's add button")]
        public void WhenSelectNewlyCreatedParameterAndAddAAlertAndSomeBooleanLogicOperatorUsingNewAlertPanelSAddButton(string Parameter, string Alert, string Operator)
        {
            configurePage.SelectCreatedParameter(Parameter);
            Waits.WaitForElementVisible(driver, configurePage.LblAlertsPanel);
            Assert.IsTrue(configurePage.LblAlertsPanel.Text.Contains(Parameter), "Verified screen presence selected newly created Alert");
            configurePage.EnterAlertMessage(Alert);
            Waits.WaitAndClick(driver, configurePage.BtnAlertListFunction);
            Waits.WaitForElementVisible(driver, configurePage.LblFunctionTitle);
            Assert.IsTrue(configurePage.LblFunctionTitle.Text.Contains("XNIM Function"), "Verfied screen presence XNIMFuctionPanel");
            configurePage.SelectBooleanOperator(Operator);
            configurePage.SelectSection();
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, configurePage.BtnAddAlert);
        }

        [Then(@"A new Alert'(.*)' should be created and added in the list of Alerts for the selecte parameter")]
        public void ThenANewAlertShouldBeCreatedAndAddedInTheListOfAlertsForTheSelecteParameter(string Alert)
        {
            Assert.IsTrue(configurePage.IsAlertExist(Alert), "Verified a new alert created and added in the list of alerts for the selected parameter");
            Waits.Wait(driver, 2000);
        }

        [When(@"Select Profile'(.*)' Parameter'(.*)' and Alert'(.*)' in the respective list and try to update detail from Edit panel of respective entry")]
        public void WhenSelectProfileParameterAndAlertInTheRespectiveListAndTryToUpdateDetailFromEditPanelOfRespectiveEntry(string Profile, string Parameter, string Alert)
        {
            configurePage.EnterProfileName(Profile);
            Waits.WaitAndClick(driver, configurePage.BtnAddProfile);
            configurePage.EnterParameterName(Parameter);
            Waits.WaitAndClick(driver, configurePage.BtnAddParameter);
            configurePage.EnterAlertMessage(Alert);
            Waits.WaitAndClick(driver, configurePage.BtnAddAlert);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Profile'(.*)' Parameter'(.*)' and Alert'(.*)' Detail should be updated and saved")]
        public void ThenProfileParameterAndAlertDetailShouldBeUpdatedAndSaved(string Profile, string Parameter, string Alert)
        {
            configurePage.SelectCreatedProfile(Profile);
            Assert.IsTrue(configurePage.IsProfileExist(Profile), "Verified the Profile detail should be updated and saved");
            configurePage.SelectCreatedParameter(Parameter);
            Assert.IsTrue(configurePage.IsParameterExist(Parameter), "Verified the Parameter detail should be updated and saved");
            configurePage.SelectCreatedAlert(Alert);
            Assert.IsTrue(configurePage.IsAlertExist(Alert), "Verified the Alert detail should be updated and saved");
        }

        [When(@"Select already created Profile'(.*)' from the list and click Copy button")]
        public void WhenSelectAlreadyCreatedProfileFromTheListAndClickCopyButton(string Profile)
        {
            configurePage.SelectCreatedProfile(Profile);
            Waits.WaitAndClick(driver, configurePage.BtnProfileCopy);
        }

        [Then(@"Copy of Profile'(.*)' should be created and added in the profile list\.")]
        public void ThenCopyOfProfileShouldBeCreatedAndAddedInTheProfileList_(string Profile)
        {
            configurePage.SelectCreatedProfile(Profile);
            Assert.IsTrue(configurePage.IsProfileExist(Profile), "Verified the copy of Profile should be created and added in the profile list");
            Waits.Wait(driver, 2000);
        }

        [When(@"Make sure copied profile has all related Parameter'(.*)' and Alert'(.*)' entries as the original profile")]
        public void WhenMakeSureCopiedProfileHasAllRelatedParameterAndAlertEntriesAsTheOriginalProfile(string Parameter, string Alert)
        {
            configurePage.SelectCreatedParameter(Parameter);
            Assert.IsTrue(configurePage.IsParameterExist(Parameter), "Verified the copied profile has all related parameter entries as the original profile");
            configurePage.SelectCreatedAlert(Alert);
            Assert.IsTrue(configurePage.IsAlertExist(Alert), "Verified the copied profile has all related alert entries as the original profile");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Delete the Already created Profile'(.*)'")]
        public void ThenDeleteTheAlreadyCreatedProfile(string Profile)
        {
            configurePage.DeleteProfile(Profile);
        }

        [When(@"Select Newly Copied Profile'(.*)' Parameter'(.*)' and Alert'(.*)' in the respective list and try to delete it from lis's respective Delete button")]
        public void WhenSelectNewlyCopiedProfileParameterAndAlertInTheRespectiveListAndTryToDeleteItFromLisSRespectiveDeleteButton(string Profile, string Parameter, string Alert)
        {
            configurePage.SelectCreatedProfile(Profile);
            configurePage.SelectCreatedParameter(Parameter);
            configurePage.SelectCreatedAlert(Alert);
            Waits.WaitAndClick(driver, configurePage.BtnDeleteAlert);
            Waits.WaitForElementVisible(driver, configurePage.LblProfiles);
            Waits.WaitAndClick(driver, configurePage.BtnDeleteParameter);
            Waits.WaitForElementVisible(driver, configurePage.LblProfiles);
            Waits.WaitAndClick(driver, configurePage.BtnDeleteProfile);
            Waits.WaitAndClick(driver, configurePage.BtnOKDelete);
            Waits.WaitForElementVisible(driver, configurePage.LblProfiles);
        }

        [Then(@"The entry should be deleted Profile'(.*)'")]
        public void ThenTheEntryShouldBeDeletedProfile(string Profile)
        {
            Assert.IsFalse(configurePage.IsProfileExist(Profile), "Verified The entry should be deleted");
            Waits.Wait(driver, 2000);
        }

        [When(@"Within Configuration, click the tab parameter Threshold Monitoring")]
        public void WhenWithinConfigurationClickTheTabParameterThresholdMonitoring()
        {
            Waits.Wait(driver, 2000);
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.ClickOnConfiguration();
            Waits.WaitAndClick(driver, homePage.LnkConfiguarationHandler);
            if (configurePage == null)
                configurePage = new ConfigurePage(driver);
            Waits.WaitAndClick(driver, configurePage.LnkParameterThresholdMonitor);
        }

        [Then(@"PTM tab is opened")]
        public void ThenPTMTabIsOpened()
        {
            Waits.Wait(driver, 1000);
            Assert.IsTrue(driver.Url.Contains("PTM.aspx"), "Verified PTM tab is opened");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click on Create profileName'(.*)'\. Select Value'(.*)' Turbo pump in Type dropdown and give appropriate name to PTM Turbo profile and click Create button")]
        public void WhenClickOnCreateProfileName_SelectValueTurboPumpInTypeDropdownAndGiveAppropriateNameToPTMTurboProfileAndClickCreateButton(string profileName, string Value)
        {
            if (ptmPage == null)
                ptmPage = new PTMPage(driver);
            ptmPage.CreateProfile(profileName, Value);
            Waits.Wait(driver, 2000);
        }

        [Then(@"New profile will be created and its details tab will be displayed")]
        public void ThenNewProfileWillBeCreatedAndItsDetailsTabWillBeDisplayed()
        {
            bool res = Waits.WaitForElementVisible(driver, ptmPage.LnkDetailsTab);
            Assert.IsTrue(res, "Verified New profile will be created and its details tab will be displayed");
            Waits.Wait(driver, 1000);
        }

        [When(@"Entered details tab, Make a number of selections from the list of available in parameters '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' and Click Apply Button")]
        public void WhenEnteredDetailsTabMakeANumberOfSelectionsFromTheListOfAvailableInParametersAndClickApplyButton(string Parameter, string LowValue, string HighValue, string SetValue, string ClearValue, string Parameter1, string LowValue1, string HighValue1, string SetValue1, string ClearValue1)
        {
            ptmPage.SelectParameters(Parameter);
            ptmPage.EnterLowValue(LowValue);
            ptmPage.EnterHighValue(HighValue);
            ptmPage.EnterSetValue(SetValue);
            ptmPage.EnterClearValue(ClearValue);
            Waits.Wait(driver, 2000);
            ptmPage.SelectParameters(Parameter1);
            ptmPage.EnterLowValue(LowValue1);
            ptmPage.EnterHighValue(HighValue1);
            ptmPage.EnterSetValue(SetValue1);
            ptmPage.EnterClearValue(ClearValue1);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, ptmPage.BtnApply);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The profile will display assigned Parameter'(.*)' with its values LowValue'(.*)' and  HighValue'(.*)'\(high-Low etc\.\) updated")]
        public void ThenTheProfileWillDisplayAssignedParameterWithItsValuesLowValueAndHighValueHigh_LowEtc_Updated(string Parameter, string LowValue, string HighValue)
        {
            Waits.WaitForElementVisible(driver, ptmPage.TxtParameterLowValue);
            Assert.IsTrue(ptmPage.TxtParameterLowValue.GetAttribute("value").Equals(LowValue), "The profile will display assigned parameter with updated Low Values");
            Waits.WaitForElementVisible(driver, ptmPage.TxtParameterHighValue);
            Assert.IsTrue(ptmPage.TxtParameterHighValue.GetAttribute("value").Equals(HighValue), "The profile will display assigned parameter with updated Low Values");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click on Equipments tab")]
        public void WhenClickOnEquipmentsTab()
        {
            ptmPage.NavigateToEquipmentTab();
            Waits.Wait(driver, 2000);
        }

        [Then(@"I should be navigated to the Equipments tab")]
        public void ThenIShouldBeNavigatedToTheEquipmentsTab()
        {
            bool res = Waits.WaitForElementVisible(driver, ptmPage.LnkEquipmentTab);
            Assert.IsTrue(res, "Verifying screen should be navigated to the Equipments tab");
        }

        [When(@"I find equipment using equipment description and add Equipment'(.*)' to Assigned Equipment list using > and >> button then Click Apply")]
        public void WhenIFindEquipmentUsingEquipmentDescriptionAndAddEquipmentToAssignedEquipmentListUsingAndButtonThenClickApply(string Equipment)
        {
            ptmPage.FindEquipmentSystems();
            Waits.Wait(driver, 2000);
            ptmPage.SelectSingleEquipment(Equipment);
            Waits.Wait(driver, 2000);
            ptmPage.CliclkOnMoveSingleSystem();
            Waits.WaitAndClick(driver, ptmPage.BtnApply);
            Waits.Wait(driver, 2000);
        }

        [Then(@"Changes have been applied message will be displayed on the screen")]
        public void ThenChangesHaveBeenAppliedMessageWillBeDisplayedOnTheScreen()
        {
            Waits.WaitForElementVisible(driver, ptmPage.LblFeedback);
            Assert.IsTrue(ptmPage.LblFeedback.Text.Contains(GlobalConstants.ChangesApplied), "Verifying 'Changes have been applied' message will be displayed on the screen");
        }

        [When(@"Select a newly created profile from profileName'(.*)' listed on left hand side of the PTM screen")]
        public void WhenSelectANewlyCreatedProfileFromProfileNameListedOnLeftHandSideOfThePTMScreen(string profileName)
        {
            ptmPage.ClickOnPTMLink();
            ptmPage.SelectCreatedProfile(profileName);
        }

        [Then(@"Details tab of selected profile will be displayed")]
        public void ThenDetailsTabOfSelectedProfileWillBeDisplayed()
        {
            Waits.WaitForElementVisible(driver, ptmPage.LnkDetailsTab);
            Assert.IsTrue(ptmPage.LnkDetailsTab.Displayed, "Verified Details tab of selected profile will be displayed");
            Waits.Wait(driver, 1000);
        }

        [When(@"Change profileName'(.*)' on details tab and click Apply")]
        public void WhenChangeProfileNameOnDetailsTabAndClickApply(string profileName)
        {
            Waits.Wait(driver, 1000);
            ptmPage.EnterProfileName(profileName);
            Waits.WaitAndClick(driver, ptmPage.BtnApply);
        }

        [Then(@"The profileName'(.*)' Changes should be saved")]
        public void ThenTheProfileNameChangesShouldBeSaved(string profileName)
        {
            Waits.WaitForElementVisible(driver, ptmPage.TxtProfileName);
            Assert.IsTrue(ptmPage.TxtProfileName.GetAttribute("value").ToLower().Contains(profileName.ToLower()), "Verified profile name successfully changed");
            Waits.Wait(driver, 2000);
        }

        [When(@"Delete the ProfileName'(.*)' if profilename exist")]
        public void WhenDeleteTheProfileNameIfProfilenameExist(string ProfileName)
        {
            Assert.IsTrue(ptmPage.LnkDetailsTab.Displayed, "Verified Details tab of selected profile will be displayed");
            Waits.Wait(driver, 1000);
            ptmPage.DeletePTMProfile(ProfileName);
        }

        [Then(@"Ensure ProfileName '(.*)' is deleted")]
        public void ThenEnsureProfileNameIsDeleted(string ProfileName)
        {
            Assert.IsFalse(ptmPage.IsPTMProfileExist(ProfileName), "Verified Profile shouldn't be present after delete action");
            Waits.Wait(driver, 1000);
        }

        [When(@"Delete the newly created folder")]
        public void WhenDeleteTheNewlyCreatedFolder()
        {
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            historianPage.DeleteFolder(testFolderName);
            Waits.Wait(driver, 2000);
        }

        [Then(@"I ensure the folder is deleted")]
        public void ThenIEnsureTheFolderIsDeleted()
        {
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            Assert.IsTrue(historianPage.IsFolderHidden(testFolderName), "Verified folder shouldn't be present after delete action");
            Waits.Wait(driver, 1000);
        }

        [Then(@"I close EISAA Aplication")]
        public void ThenICloseEISAAAplication()
        {
            simulator.RestoreWindow();
            Waits.Wait(driver, 1000);
            simulator.KillProcess();
            Waits.Wait(driver, 1000);
        }

        [When(@"Ensure EdCentra (.*)\.(.*) is installed and working correctly")]
        public void WhenEnsureEdCentra_IsInstalledAndWorkingCorrectly(Decimal p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"I run the SQL query against the scada_producttion database which will return the counts of PTM parameters available to be logged for each device type\.")]
        public void WhenIRunTheSQLQueryAgainstTheScada_ProducttionDatabaseWhichWillReturnTheCountsOfPTMParametersAvailableToBeLoggedForEachDeviceType_()
        {
            if (ptmPage == null)
                ptmPage = new PTMPage(driver);
            var dt = ptmPage.SetValueInApplicationColumn();
            List<PTMParameterDetails> lstActualPTM = new List<PTMParameterDetails>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PTMParameterDetails paramDetails = new PTMParameterDetails();
                paramDetails.Description = dt.Rows[i]["Description"].ToString();
                paramDetails.SystemTypeId = dt.Rows[i]["SystemTypeId"].ToString();
                paramDetails.Total = dt.Rows[i]["Total"].ToString();
                lstActualPTM.Add(paramDetails);
            }
            ScenarioContext.Current.Add("ActualPTMParameterList", lstActualPTM);

            Waits.Wait(driver, 1000);
        }

        [Then(@"the total no\.of parameters available for PTM is (.*)")]
        public void ThenTheTotalNo_OfParametersAvailableForPTMIs(int expectedParameterCount)
        {
            var actualList = (List<PTMParameterDetails>)ScenarioContext.Current["ActualPTMParameterList"];
            Assert.AreEqual(expectedParameterCount, actualList.Count, "No.Of PTM parameters count are not matching");
        }

        [Then(@"the following PTM parameters details should be present in database")]
        public void ThenTheFollowingPTMParametersDetailsShouldBePresentInDatabase(Table table)
        {
            var expectedPTMList = table.CreateSet<PTMParameterDetails>().ToList();
            var actualPTMList = (List<PTMParameterDetails>)ScenarioContext.Current["ActualPTMParameterList"];


            for (int i = 0; i < expectedPTMList.Count(); i++)
            {
                var actualFilteredList = actualPTMList.Where(x => x.Description == expectedPTMList[i].Description).ToList();
                if (actualFilteredList.Count == 1)
                {
                    Assert.AreEqual(expectedPTMList[i].Description, actualFilteredList[0].Description);
                    Assert.AreEqual(expectedPTMList[i].SystemTypeId, actualFilteredList[0].SystemTypeId);
                    Assert.AreEqual(expectedPTMList[i].Total, actualFilteredList[0].Total);

                }
            }
        }

    }
}