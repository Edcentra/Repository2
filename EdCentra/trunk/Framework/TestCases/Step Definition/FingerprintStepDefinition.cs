using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class FingerprintStepDefinition
    {
        string testFolderName = ElementExtensions.GetRandomString(4);
        string unitText = string.Empty;
        Simulator simulator = new Simulator();
        FingerPrintPage fingerPrintPage;
        HistorianPage historianPage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        HomePage homePage;
        string iPAdress = SpecflowHooks.HostIpAddress();
        string fpName = "";
        private IWebDriver driver;

        public FingerprintStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            fingerPrintPage = new FingerPrintPage(driver);
            historianPage = new HistorianPage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            homePage = new HomePage(driver);
        }

        [Then(@"Fingerprint page should be visible")]
        [Then(@"I Should be navigated to the Fingerprint page")]
        public void ThenIShouldBeNavigatedToThefingerPrintPage()
        {
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            Waits.Wait(driver, 2000);
            Assert.IsTrue(fingerPrintPage.IsFingerprintPageMessageDisplayed);
        }

        [Then(@"the Fingerprint option should appear in the menu bar")]
        public void ThenTheFingerprintOptionShouldAppearInTheMenuBar()
        {
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            Assert.IsTrue(fingerPrintPage.LnkFingerprintMenu.Displayed);
        }

        [When(@"I click Fingerprint menu on the historian page")]
        public void WhenIClickFingerprintMenuOnTheHistorianPage()
        {
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            Waits.WaitAndClick(driver, fingerPrintPage.LnkFingerprintMenu);
        }

        [Then(@"the heading of the second panel should be ""(.*)""")]
        public void ThenTheHeadingOnTheSecondPanelShouldBe(string message)
        {
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            Assert.IsTrue(fingerPrintPage.HeadingSecondPanel.Contains(message));
        }

        [Then(@"a message ""(.*)"" should appear on the fingerprint section")]
        public void ThenAMessageShouldAppearOnTheFingerprintSection(string message)
        {
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            Assert.AreEqual(message, fingerPrintPage.FingerprintMsg, @"Expected message {message} does not appear in Fingerprint section");
        }

        [When(@"I click a new button on the fingerprint page")]
        public void WhenIClickANewButtonOnTheFingerprintPage()
        {
            JavaScriptExecutor.JavaScriptLinkClick(driver, fingerPrintPage.BtnNewFingerprint);
        }

        [When(@"I enter a name as '(.*)' and notes as '(.*)'and then click Add")]
        public void WhenIEnterANameAsAndNotesAsAndThenClickAdd(string fingerPrintName, string fpNotes)
        {
            Waits.Wait(driver, 1000);
            fingerPrintPage.CreateFingerprint(fingerPrintName, fpNotes);
            Waits.Wait(driver, 60000);
        }

        [Then(@"after (.*) seconds a message ""(.*)"" will appear\.")]
        public void ThenAfterSecondsAMessageWillAppear_(int seconds, string message)
        {
            Assert.AreEqual(message, fingerPrintPage.PopUpMsg, "No data available message not appear in the screen");
            JavaScriptExecutor.JavaScriptLinkClick(driver, fingerPrintPage.BtnCancelFingerprint);
        }

        [When(@"I navigate to Fingerprint module by clicking via Diagnostics -> Fingerprint option")]
        [When(@"I navigate to Fingerprint module")]
        public void WhenINavigateToFingerprintModule()
        {
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            Waits.WaitAndClick(driver, fingerPrintPage.LnkDiagnostics);
            Waits.WaitAndClick(driver, fingerPrintPage.LnkFingerprint);
        }

        [When(@"Go to the Diagnostics -> Fingerprint section\.")]
        public void WhenGoToTheDiagnostics_FingerprintSection_()
        {
            Waits.Wait(driver, 1000);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            JavaScriptExecutor.JavaScriptLinkClick(driver, deviceExplorerNavigationPage.LinkHomePage);
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkFingerprint);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Fingerprint page launches\.")]
        public void ThenFingerprintPageLaunches_()
        {
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            bool res = Waits.WaitForElementVisible(driver, fingerPrintPage.LnkFingerprintTab);
            Assert.IsTrue(res, "Verified screen presence the Fingerprint tab");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select a communicating system '(.*)' \(recommend iXH\) on the left hand side and click the New button\.")]
        public void WhenSelectACommunicatingSystemRecommendIXHOnTheLeftHandSideAndClickTheNewButton_(string equipmentName)
        {
            testFolderName = (string)ScenarioContext.Current["TestFolderName"];
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            historianPage.ExpandSystemsParameter(testFolderName);
            Waits.Wait(driver, 1000);
            historianPage.SelectSingleParameterEquipment(equipmentName);
            Waits.Wait(driver, 2000);
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            Waits.Wait(driver, 1000);
            JavaScriptExecutor.JavaScriptLinkClick(driver, fingerPrintPage.BtnNewFingerprint);
            Waits.Wait(driver, 2000);
        }

        [Then(@"New Fingerprint panel is displayed")]
        public void ThenNewFingerprintPanelIsDisplayed()
        {
            bool res = Waits.WaitForElementVisible(driver, fingerPrintPage.LnkFingerprintTab);
            Assert.IsTrue(res, "Verified Fingerprint panel is not displayed");
        }

        [When(@"Enter a name '(.*)' and then enter thousand characters in the notes field then click Add\.")]
        public void WhenEnterANameAndThenEnterThousandCharactersInTheNotesFieldThenClickAdd_(string fingerprintName1)
        {
            Waits.Wait(driver, 1000);
            string fpNotes = GlobalConstants.FingerprintNotes;
            fingerPrintPage.CreateFingerprint(fingerprintName1, fpNotes);
            Waits.Wait(driver, 2000);
        }

        [Then(@"The time it takes to add the fingerprint '(.*)' should be sixtyseconds as it gathers the parameter data\.")]
        public void ThenTheTimeItTakesToAddTheFingerprintShouldBeSixtysecondsAsItGathersTheParameterData_(string fingerprintName1)
        {
            Waits.Wait(driver, 120000);
            Assert.IsTrue(fingerPrintPage.IsFingerprintListPresent(fingerprintName1), "Verified The parameters for that equipment will be displayed");
        }

        [When(@"Click the new fingerprint '(.*)' in the list\.")]
        public void WhenClickTheNewFingerprintInTheList_(string fingerprintName1)
        {
            fingerPrintPage.SelectFingerprint(fingerprintName1);
            Waits.Wait(driver, 1000);
        }

        [Then(@"the Fingerprint Details columns are displayed in the following order")]
        public void ThenTheFingerprintDetailsColumnsAreDisplayedInTheFollowingOrder(Table table)
        {
            var expectedColumnHeaders = table.Rows.Select(x => x["Columns"]).ToList();
            var actualColumnHeaders = fingerPrintPage.GetFingerprintHeaderDetails;
            var list = fingerPrintPage.FingerprintDetailsList;
            CollectionAssert.AreEqual(expectedColumnHeaders, actualColumnHeaders);
        }

        [Then(@"the details of parameter section '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' appears on the (.*) row\.")]
        public void ThenTheDetailsOfParameterSectionAppearsOnTheRow_(string parameter1, string value1, string parameter2, string value2, string parameter3, string value3, int rownum)
        {
            Assert.IsTrue(fingerPrintPage.FingerPrintParameterDetails(parameter1, value1, rownum), "Verify screen not present Details of Fingerprint");
            Assert.IsTrue(fingerPrintPage.FingerPrintParameterDetails(parameter2, value2, rownum), "Verify screen not present Details of Fingerprint");
            Assert.IsTrue(fingerPrintPage.FingerPrintParameterDetails(parameter3, value3, rownum), "Verify screen not present Details of Fingerprint");

        }

        [When(@"Hover over the note icon for the new fingerprint\.")]
        public void WhenHoverOverTheNoteIconForTheNewFingerprint_()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(fingerPrintPage.LnkFingerprintlist).MoveToElement(driver.FindElement(By.TagName("th"))).Click().Build().Perform();
            Waits.Wait(driver, 5000);
        }

        [When(@"Fingerprint ""(.*)"" selected in the list")]
        public void WhenFingerprintSelectedInTheList(string fingerPrintName)
        {
            Waits.Wait(driver, 1000);
            fingerPrintPage.SelectFingerprint(fingerPrintName);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Compare Section appears")]
        public void ThenCompareSectionAppears()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(fingerPrintPage.IsCompareSectionExists, "Compare Section does not exist");
        }

        [When(@"A fingerprint ""(.*)"" selected in the list, click the Delete button\.")]
        public void WhenAFingerprintSelectedInTheListClickTheDeleteButton_(string fingerPrintName)
        {

            fingerPrintPage.SelectFingerprint(fingerPrintName);
            Waits.WaitAndClick(driver, fingerPrintPage.BtnDelete);

        }

        [Then(@"Fingerprint ""(.*)"" is deleted and removed from the list\.")]
        public void ThenFingerprintIsDeletedAndRemovedFromTheList_(string fingerPrintName)
        {
            Assert.IsFalse(fingerPrintPage.IsFingerprintListPresent(fingerPrintName), "Verified Fingerprint is not deleted and not removed from the list");

        }
        [Then(@"A tooltip should show containing what you entered earlier\.")]
        public void ThenATooltipShouldShowContainingWhatYouEnteredEarlier_()
        {
            Actions action = new Actions(driver);
            IWebElement lst = fingerPrintPage.LnkFingerprintlist;
            action.MoveToElement(lst).Perform();
            IWebElement notes = lst.FindElement(By.XPath("//tr[2]//td[7]//img"));
            string actualtext = notes.GetAttribute("title");
            Waits.Wait(driver, 2000);
            Assert.AreEqual(GlobalConstants.FingerprintNotes, actualtext);
            Waits.Wait(driver, 2000);
        }

        [When(@"Open the User Preferences panel")]
        public void WhenOpenTheUserPreferencesPanel()
        {
            Waits.WaitAndClick(driver, homePage.LnkLoginUser);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkPreferences);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkPreferences);
            Assert.IsTrue(deviceExplorerNavigationPage.LnkUserPreferences.Displayed, "Verfied User Preference window Open successfully");
            Waits.Wait(driver, 2000);
        }

        [When(@"Observe the unit preference that Temperature is set to and close the panel\.")]
        public void WhenObserveTheUnitPreferenceThatTemperatureIsSetToAndCloseThePanel_()
        {
            Waits.WaitForElementVisible(driver, fingerPrintPage.LnkTemperatureUnit);
            unitText = fingerPrintPage.LnkTemperatureUnit.Text;
            Waits.WaitAndClick(driver, fingerPrintPage.BtnClose);
            Waits.Wait(driver, 2000);
        }

        [Then(@"Any parameters that are Temperatures should be displayed with the unit that is set in the User Preferences\.")]
        public void ThenAnyParametersThatAreTemperaturesShouldBeDisplayedWithTheUnitThatIsSetInTheUserPreferences_()
        {
            Actions action = new Actions(driver);
            IWebElement lst = fingerPrintPage.LnkFingerprintlist;
            action.MoveToElement(lst).Perform();
            IWebElement unit = lst.FindElement(By.XPath("//tr[12]//td[5]"));
            string actualtext = unit.Text;
            Waits.Wait(driver, 2000);
            Assert.IsTrue(unitText.Contains(actualtext), "Verify the parameter temperature unit should not be match with user preference unit");
            Waits.Wait(driver, 2000);
        }

        [When(@"Click the Export button")]
        public void WhenClickTheExportButton()
        {
            fingerPrintPage.DeleteFolderExists();
            Waits.Wait(driver, 2000);
            JavaScriptExecutor.JavaScriptLinkClick(driver, fingerPrintPage.LnkExport);
            Waits.Wait(driver, 2000);
        }

        [Then(@"The browser should download a \.csv file")]
        public void ThenTheBrowserShouldDownloadA_CsvFile()
        {
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            Assert.IsTrue(fingerPrintPage.CSVFileExist(), "Verified There should be a csv file with the same filename ");
            Waits.Wait(driver, 1000);
        }

        [Then(@"Open the csv file and check the following values are displayed in the parameter detail section")]
        public void ThenOpenTheCsvFileAndCheckTheFollowingValuesAreDisplayedInTheParameterDetailSection(Table table)
        {
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            var expectedFingerprintParameterDetail = table.CreateInstance<FingerprintParameterDetails>();
            var actualFingerprintParameterDetailsList = fingerPrintPage.GetSingleFingerprintParameterDetailsFromCSVFile();
            Assert.AreEqual(expectedFingerprintParameterDetail.ParameterName, actualFingerprintParameterDetailsList[10].ParameterName);
            Assert.AreEqual(expectedFingerprintParameterDetail.FingerprintParameterValue, actualFingerprintParameterDetailsList[10].FingerprintParameterValue);
            Assert.IsTrue(actualFingerprintParameterDetailsList[10].Unit.Contains(expectedFingerprintParameterDetail.Unit));
          
        }

        [When(@"Open the User Preferences panel again")]
        public void WhenOpenTheUserPreferencesPanelAgain()
        {
            Waits.WaitAndClick(driver, homePage.LnkLoginUser);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkPreferences);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkPreferences);
            Assert.IsTrue(deviceExplorerNavigationPage.LnkUserPreferences.Displayed, "Verfied User Preference window Open successfully");
            Waits.Wait(driver, 2000);
        }

        [When(@"change the Temperature unit to something else and click Apply\.")]
        public void WhenChangeTheTemperatureUnitToSomethingElseAndClickApply_()
        {
            fingerPrintPage.ChangeUserPreference();
            Waits.Wait(driver, 1000);
        }

        [When(@"using EISSA, change the parameters '(.*)' value to '(.*)' '(.*)' value to '(.*)' '(.*)' value to '(.*)'")]
        public void WhenUsingEISSAChangeTheParametersValueToValueToValueTo(string parameter, string value, string parameter1, string value1, string parameter2, string value2)
        {
            simulator.RestoreWindow();
            Thread.Sleep(1000);
            simulator.SelectParameter(parameter);
            Thread.Sleep(2000);
            simulator.SetParameterValue(value);
            Thread.Sleep(2000);
            simulator.SelectParameter(parameter1);
            Thread.Sleep(2000);
            simulator.SetParameterValue(value1);
            Thread.Sleep(2000);
            simulator.SelectParameter(parameter2);
            Thread.Sleep(2000);
            simulator.SetParameterValue(value2);
            Thread.Sleep(5000);
            simulator.MinimizeWindow();
        }

        [When(@"Create another fingerprint '(.*)', using system '(.*)' of the same type")]
        public void WhenCreateAnotherFingerprintUsingSystemOfTheSameType(string fingerPrintName, string equipmentName)
        {
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            Waits.Wait(driver, 2000);
            historianPage.SelectSingleParameterEquipment(equipmentName);
            Waits.Wait(driver, 2000);
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            JavaScriptExecutor.JavaScriptLinkClick(driver, fingerPrintPage.BtnNewFingerprint);
            Waits.Wait(driver, 2000);
            string fpNotes = GlobalConstants.FingerprintNotes;
            fingerPrintPage.CreateFingerprint(fingerPrintName, fpNotes);
            Waits.Wait(driver, 2000);
        }

        [Then(@"After sixty seconds where it gathers the parameters a new fingerprint '(.*)' is created\.")]
        public void ThenAfterSixtySecondsWhereItGathersTheParametersANewFingerprintIsCreated_(string fingerPrintName)
        {
            Waits.Wait(driver, 120000);
            Assert.IsTrue(fingerPrintPage.IsFingerprintListPresent(fingerPrintName), "Verified The parameters for that equipment will be displayed");
            Waits.Wait(driver, 1000);
        }

        [When(@"If you don`t currently have the first fingerprint selected please click on it\. Then select the second fingerprint '(.*)' by clicking it too\.")]
        public void WhenIfYouDonTCurrentlyHaveTheFirstFingerprintSelectedPleaseClickOnIt_ThenSelectTheSecondFingerprintByClickingItToo_(string fingerprintName1)
        {
            fingerPrintPage.SelectFingerprint(fingerprintName1);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Fingerprints '(.*)' '(.*)' '(.*)' are marked with '(.*)' and show their details and parameters in the main right-hand pane\.")]
        public void ThenFingerprintsAreMarkedWithAndShowTheirDetailsAndParametersInTheMainRight_HandPane_(string fingerprintName1, string number1, string fingerprintName2, string number2)
        {
            Waits.Wait(driver, 1000);
            Assert.IsTrue(fingerPrintPage.FingerprintNumber(fingerprintName1, number1), "Verified fingerprints are marked as order with number ");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(fingerPrintPage.FingerprintNumber(fingerprintName2, number2), "Verified fingerprints are marked as order with number ");
            Waits.Wait(driver, 1000);
        }

        [Then(@"the Parameter Details columns are displayed in the following order")]
        public void ThenTheParameterDetailsColumnsAreDisplayedInTheFollowingOrder(Table table)
        {
            var expectedColumnHeaders = table.Rows.Select(x => x["Columns"]).ToList();
            var actualColumnHeaders = fingerPrintPage.GetFingerprintParameterHeaderDetails;
            //var list = fingerPrintPage.FingerprintParameterDetailsList;
            CollectionAssert.AreEqual(expectedColumnHeaders, actualColumnHeaders);
        }

        [Then(@"the following parameter details are displayed in the compare section")]
        public void ThenTheFollowingParameterDetailsAreDisplayedInTheCompareSection(Table table)
        {
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            var expectedFingerprintParameterDetailsList = table.CreateSet<FingerprintParameterDetails>().ToList();
            var actualFingerprintParameterDetailsList = fingerPrintPage.FingerprintParameterDetailsList;
            
            for (int i = 0; i < expectedFingerprintParameterDetailsList.Count(); i++)
            {
                var actualFilteredList = actualFingerprintParameterDetailsList.Where(x => x.ParameterName == expectedFingerprintParameterDetailsList[i].ParameterName && x.FingerprintParameterValue==expectedFingerprintParameterDetailsList[i].FingerprintParameterValue).ToList();
                if (actualFilteredList.Count==1)
                {
                    Assert.AreEqual(expectedFingerprintParameterDetailsList[i].ParameterName, actualFilteredList[0].ParameterName);
                    Assert.AreEqual(expectedFingerprintParameterDetailsList[i].FingerprintParameterValue, actualFilteredList[0].FingerprintParameterValue);
                    Assert.AreEqual(expectedFingerprintParameterDetailsList[i].Fingerprint2ParameterValue, actualFilteredList[0].Fingerprint2ParameterValue);
                    Assert.AreEqual(expectedFingerprintParameterDetailsList[i].Delta, actualFilteredList[0].Delta);
                    Assert.AreEqual(expectedFingerprintParameterDetailsList[i].Unit, actualFilteredList[0].Unit);

                }
            }
            
        }

        [Then(@"There is also now a Delta column that shows any differences between parameters in fingerprints")]
        public void ThenThereIsAlsoNowADeltaColumnThatShowsAnyDifferencesBetweenParametersInFingerprints()
        {
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, fingerPrintPage.LblDelta), "Verified There is no Delta column");
            Waits.Wait(driver, 2000);
        }
        
        [Then(@"Delete confirmation box shows\.")]
        public void ThenDeleteConfirmationBoxShows_()
        {
            Waits.WaitForElementVisible(driver, fingerPrintPage.BtnCancelDelete);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, fingerPrintPage.BtnCancelDelete), "Verified screen not present Delete confirmation box shows");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click Cancel")]
        public void WhenClickCancel()
        {
            Waits.Wait(driver, 1000);            
            Waits.WaitAndClick(driver, fingerPrintPage.BtnCancelDelete);
        }

        [Then(@"Delete confirmation box closes and fingerprint is NOT deleted\.")]
        public void ThenDeleteConfirmationBoxClosesAndFingerprintIsNOTDeleted_()
        {
            Waits.Wait(driver, 1000);
            Assert.IsFalse(ElementExtensions.isDisplayed(driver, fingerPrintPage.BtnCancelDelete), "Verified Delete confirmation box not present ");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click the Delete button again\.")]
        public void WhenClickTheDeleteButtonAgain_()
        {
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, fingerPrintPage.BtnDelete);
        }

        [When(@"Click Ok")]
        public void WhenClickOk()
        {
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, fingerPrintPage.BtnOkDelete);
        }

        [Then(@"Fingerprint ""(.*)"" is deleted and removed from the list")]
        public void ThenFingerprintIsDeletedAndRemovedFromTheList(string fingerPrintName)
        {
            Waits.Wait(driver, 2000);
            Assert.IsFalse(fingerPrintPage.IsFingerprintListPresent(fingerPrintName), "Verified Fingerprint is not deleted and not removed from the list");
            Waits.Wait(driver, 2000);
        }

        [When(@"I Click Clear Button")]
        public void WhenIClickClearButton()
        {
            JavaScriptExecutor.JavaScriptLinkClick(driver, fingerPrintPage.LnkClear);
        }

        [Then(@"Compare section disappears and Add a fingerprint to begin message appears")]
        public void ThenCompareSectionDisappearsAndAddAFingerprintToBeginMessageAppears()
        {
            Waits.Wait(driver, 2000);
            Assert.IsFalse(fingerPrintPage.IsCompareSectionExists, "Compare Section exists");
            Assert.IsTrue(fingerPrintPage.IsFingerprintPageMessageDisplayed);
        }

        [When(@"I open the csv file then following details should be displayed in the header of the compare section")]
        public void WhenIOpenTheCsvFileThenFollowingDetailsShouldBeDisplayedInTheHeaderOfTheCompareSection(Table table)
        {
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            var expectedFingerprintDetailsList = table.CreateSet<FingerprintDetails>().ToList();
            var actualFingerprintDetailsList=fingerPrintPage.GetFingerprintDetailsFromCSVFile();
            for(int i=0; i < expectedFingerprintDetailsList.Count(); i++)
            {
                Assert.AreEqual(expectedFingerprintDetailsList[i].SystemName,actualFingerprintDetailsList[i].SystemName);
                Assert.AreEqual(expectedFingerprintDetailsList[i].FingerprintName, actualFingerprintDetailsList[i].FingerprintName);
                Assert.IsTrue(actualFingerprintDetailsList[i].Date.Contains(expectedFingerprintDetailsList[i].Date));
                Assert.AreEqual(expectedFingerprintDetailsList[i].SerialNumber, actualFingerprintDetailsList[i].SerialNumber);
                Assert.AreEqual(expectedFingerprintDetailsList[i].Type, actualFingerprintDetailsList[i].Type);
                Assert.AreEqual(expectedFingerprintDetailsList[i].Note, actualFingerprintDetailsList[i].Note);
            }

        }

        [Then(@"the following fingerprint Details are displayed in the Compare Section")]
        public void ThenTheFollowingFingerprintDetailsAreDisplayedInTheCompareSection(Table table)
        {
            if (fingerPrintPage == null)
                fingerPrintPage = new FingerPrintPage(driver);
            var expectedFingerprintDetailsList = table.CreateSet<FingerprintDetails>().ToList();
            var actualFingerprintDetailsList = fingerPrintPage.FingerprintDetailsList;
            for (int i = 0; i < expectedFingerprintDetailsList.Count(); i++)
            {
                Assert.AreEqual(expectedFingerprintDetailsList[i].SystemName, actualFingerprintDetailsList[i].SystemName);
                Assert.AreEqual(expectedFingerprintDetailsList[i].FingerprintName, actualFingerprintDetailsList[i].FingerprintName);
                Assert.IsTrue(actualFingerprintDetailsList[i].Date.Contains(expectedFingerprintDetailsList[i].Date));
                Assert.AreEqual(expectedFingerprintDetailsList[i].SerialNumber, actualFingerprintDetailsList[i].SerialNumber);
                Assert.AreEqual(expectedFingerprintDetailsList[i].Type, actualFingerprintDetailsList[i].Type);
                if (expectedFingerprintDetailsList[i].Note == "1000Characters")
                    expectedFingerprintDetailsList[i].Note = GlobalConstants.FingerprintNotes;
                Assert.AreEqual(expectedFingerprintDetailsList[i].Note, actualFingerprintDetailsList[i].Note);
            }
        }
    }
}
