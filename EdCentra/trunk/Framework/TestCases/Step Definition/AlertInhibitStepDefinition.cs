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
    public sealed class AlertInhibitStepDefinition
    {
        string testFolderName = ElementExtensions.GetRandomString(4);
        private IWebDriver driver;
        HomePage homePage;
        LoginPage loginPage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        LoggingPage loggingPage;
        DispatchManagerPage dispatchManagerPage;
        AlertInhibitPage alertInhibitPage;
        Simulator simulator = new Simulator();

        public AlertInhibitStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            loggingPage = new LoggingPage(driver);
            dispatchManagerPage = new DispatchManagerPage(driver);
            alertInhibitPage = new AlertInhibitPage(driver);
        }

        
        [When(@"Go to Dispatch Manager->Inhibit Settings tab and Click on the \[New] button")]
        public void WhenGoToDispatchManager_InhibitSettingsTabAndClickOnTheNewButton()
        {
            if (alertInhibitPage == null)
                alertInhibitPage = new AlertInhibitPage(driver);
            Waits.WaitTillElementIsClickable(driver, alertInhibitPage.LnkInhibitSettings);
            Waits.WaitTillElementIsClickable(driver, alertInhibitPage.BtnNew);
        }

        [Then(@"A new Inhibit form should be visible and delete already created alert inhibit'(.*)'")]
        public void ThenANewInhibitFormShouldBeVisibleAndDeleteAlreadyCreatedAlertInhibit(string inhibit)
        {
            alertInhibitPage.DeleteAlertInhibit_IfExists(inhibit);
            Waits.WaitForElementVisible(driver, alertInhibitPage.LblSettingsTitle);
            Waits.WaitTillElementIsClickable(driver, alertInhibitPage.LblSettingsTitle);
            Assert.IsTrue(alertInhibitPage.LblSettingsTitle.Text.Contains("New Inhibit"), "Verified A new Inhibit form should be visible");
        }

        [When(@"Search Equipment System'(.*)' Using Type\. And Select the Equipment'(.*)'")]
        public void WhenSearchEquipmentSystemUsingType_AndSelectTheEquipment(string system, string equipment)
        {
            alertInhibitPage.SelectSingleSystem(system);
            Waits.WaitTillElementIsClickable(driver, alertInhibitPage.BtnGetSystems);
            Waits.WaitForElementVisible(driver, alertInhibitPage.DivEquipmentListControl);
            alertInhibitPage.SelectSingleEquipment(equipment);
        }

        [Then(@"List of Parameters'(.*)' should be displayed in parameter list")]
        public void ThenListOfParametersShouldBeDisplayedInParameterList(string parameter)
        {
            Waits.WaitForElementVisible(driver, alertInhibitPage.DivParametersListControl);
            Waits.Wait(driver, 8000);
            Assert.IsTrue(alertInhibitPage.IsParametersListPresent(parameter), "Verified List of Parameters should be displayed in parameter list ");
            Waits.Wait(driver, 2000);
        }

        [When(@"Choose Parameters '(.*)'")]
        public void WhenChooseParameters(string parameter)
        {
            Waits.WaitForElementVisible(driver, alertInhibitPage.DivParametersListControl);
            Waits.Wait(driver, 1000);
            alertInhibitPage.SelectParameter(parameter);
            Waits.Wait(driver, 4000);
        }

        [Then(@"A list of possible Alerts'(.*)' shall be displayed in Alert List")]
        public void ThenAListOfPossibleAlertsShallBeDisplayedInAlertList(string alerts)
        {
            Waits.WaitForElementVisible(driver, alertInhibitPage.DivAlertsListControl);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(alertInhibitPage.IsAlertsListPresent(alerts), "Verified A list of possible Alerts shall be displayed in Alert List");
            Waits.Wait(driver, 2000);
        }

        [When(@"Click on an appropriate Alert'(.*)' entry")]
        public void WhenClickOnAnAppropriateAlertEntry(string alert)
        {
            Waits.WaitForElementVisible(driver, alertInhibitPage.DivAlertsListControl);
            Waits.Wait(driver, 1000);
            alertInhibitPage.SelectSingleAlert(alert);
            Waits.WaitForElementVisible(driver, alertInhibitPage.BtnMoveAlertsTo);
            Waits.WaitTillElementIsClickable(driver, alertInhibitPage.BtnMoveAlertsTo);
        }

        [When(@"Mark Alert Level as All in Options section")]
        public void ThenMarkAlertLevelAsAllInOptionsSection()
        {
            Waits.WaitForElementVisible(driver, alertInhibitPage.ImgAlertLevelRadioButton);
            if (!alertInhibitPage.ImgAlertLevelRadioButton.GetAttribute("src").Contains("rdo_on"))
            {
                Waits.WaitForElementVisible(driver, alertInhibitPage.ImgAlertLevelRadioButton);
                ElementExtensions.ClickOnRadioButton(alertInhibitPage.ImgAlertLevelRadioButton);
            }
        }

        [When(@"Mark This Alert will not Expire check box")]
        public void WhenMarkThisAlertWillNotExpireCheckBox()
        {
            Waits.WaitForElementVisible(driver, alertInhibitPage.ImgAlertExpireCheckBox);
            if (!alertInhibitPage.ImgAlertExpireCheckBox.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitForElementVisible(driver, alertInhibitPage.ImgAlertExpireCheckBox);
                ElementExtensions.CheckedCheckBox(alertInhibitPage.ImgAlertExpireCheckBox);
            }
        }

        [When(@"I Select Inhibit Pages Only")]
        public void ThenSelectInhibitPagesOnly()
        {
            Waits.WaitForElementVisible(driver, alertInhibitPage.ImgAlertScopeRadioButton);
            if (!alertInhibitPage.ImgAlertScopeRadioButton.GetAttribute("src").Contains("rdo_on"))
            {
                Waits.WaitForElementVisible(driver, alertInhibitPage.ImgAlertScopeRadioButton);
                ElementExtensions.ClickOnRadioButton(alertInhibitPage.ImgAlertScopeRadioButton);
            }
        }

        [When(@"I Enter Comment'(.*)' and click Apply")]
        public void WhenEnterCommentAndClickApply(string comment)
        {
            alertInhibitPage.EnterAlertComment(comment);
            Waits.WaitAndClick(driver, alertInhibitPage.BtnApplyChanges);
        }

        [Then(@"Inhibit Settings should be saved and new entry '(.*)' entry should be added on the top list")]
        public void ThenInhibitSettingsShouldBeSavedAndNewEntryEntryShouldBeAddedOnTheTopList(string entry)
        {
            var res = Waits.WaitForElementVisible(driver, alertInhibitPage.LblInhibitCreatedMsg);
            Assert.IsTrue(res, "Verified New inhibit has not been created");
            Waits.WaitForElementVisible(driver, alertInhibitPage.DivScrollContainer);
            Assert.IsTrue(alertInhibitPage.IsNewlyCreatedInhibitPresent(entry), "Verified Inhibit Settings should be saved and new entry should be added on the top list");
        }

        [When(@"I Create an alert which matches the inhibit just created Parameter '(.*)' AlertType '(.*)' AlertCode '(.*)'")]
        public void WhenCreateAnAlertWhichMatchesTheInhibitJustCreatedParameterAlertTypeAlertCode(string parameter, string alertType, string alertCode)
        {
            simulator.RestoreWindow();
            simulator.RaiseAlert(parameter, alertType, alertCode);
            simulator.MinimizeWindow();
        }

        [Then(@"No page should arrive\. The message '(.*)' should be displayed in the Autopager console window\.")]
        public void ThenNoPageShouldArrive_TheMessageShouldBeDisplayedInTheAutopagerConsoleWindow_(string message)
        {
            Waits.Wait(driver, 10000);
            string autopagerText = simulator.GetAutopagerText();
            var text = autopagerText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.IsTrue(text[2].Contains(message), "Autopager console not showing log for message " + message);
        }

        [When(@"I Create an alert which does not match the inhibit just created Parameter '(.*)' AlertType '(.*)' AlertCode '(.*)'")]
        public void WhenCreateAnAlertWhichDoesNotMatchTheInhibitJustCreatedParameterAlertTypeAlertCode(string parameter, string alertType, string alertCode)
        {
            if (simulator == null)
                simulator = new Simulator();
            simulator.RestoreWindow();
            simulator.RaiseAlert(parameter, alertType, alertCode);
            simulator.MinimizeWindow();
        }

        [Then(@"A page should arrive")]
        public void ThenAPageShouldArrive()
        {
            string autopagerText = simulator.GetAutopagerText();
            Assert.IsTrue(autopagerText.Contains("Responding to event in response to schedule ID"), "Autopager console not showing log for message ");
            
            //Close autopager
            simulator.CloseAutoPager();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (alertInhibitPage == null)
                alertInhibitPage = new AlertInhibitPage(driver);
            try
            {
                alertInhibitPage.LinkHomePage.Click();
                homePage.ClickOnDeviceExplorer();
                deviceExplorerNavigationPage.DeleteAddedFolder(testFolderName);
                //simulator.KillProcess();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught " + ex.Message);
            }
        }

    }
}
