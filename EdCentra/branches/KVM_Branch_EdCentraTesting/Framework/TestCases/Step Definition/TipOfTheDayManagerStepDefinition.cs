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
    public sealed class TipOfTheDayManagerStepDefinition
    {
        string testFolderName = ElementExtensions.GetRandomString(4);
        private IWebDriver driver;
        HomePage homePage;
        LoginPage loginPage;
        LoggingPage loggingPage;
        TipOfTheDayManagerPage tipOfTheManagerPage;

        public TipOfTheDayManagerStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            loggingPage = new LoggingPage(driver);
            tipOfTheManagerPage = new TipOfTheDayManagerPage(driver);
        }

        [Given(@"I navigated to Tip of the Day Manager tool")]
        public void GivenINavigatedToTipOfTheDayManagerTool()
        {
            if (tipOfTheManagerPage == null)
                tipOfTheManagerPage = new TipOfTheDayManagerPage(driver);
            tipOfTheManagerPage.NavigateToTipOfTheManagerTool();
        }

        [When(@"I Click on the Add Tip button")]
        public void WhenIClickOnTheAddTipButton()
        {
            Waits.WaitAndClick(driver, tipOfTheManagerPage.BtnAddTip);
        }

        [When(@"I enter Tip title as '(.*)' and Tip content as '(.*)' and click on Add New Tip button")]
        public void WhenIEnterTipTitleAsAndTipContentAsAndClickOnAddNewTipButton(string tipTitle, string tipContent)
        {
            Waits.WaitForElementVisible(driver, tipOfTheManagerPage.TxtTipTitle);
            tipOfTheManagerPage.TxtTipTitle.SendKeys(tipTitle);
            tipOfTheManagerPage.TxtTipContent.SendKeys(tipContent);
            tipOfTheManagerPage.BtnAddNewTip.Click();

        }

        [Then(@"the tip '(.*)' should be added successfully")]
        public void ThenTheTipShouldBeAddedSuccessfully(string tipTitle)
        {
            Waits.Wait(driver, 2000);
            Assert.AreEqual(tipTitle, tipOfTheManagerPage.GetTipTitleText(tipOfTheManagerPage.TipTableRowsCount-1));
        }

        [When(@"I select the checkbox against the added tip '(.*)' and click on the Edit Tip button")]
        public void WhenISelectTheCheckboxAgainstTheAddedTipAndClickOnTheEditTipButton(string tipTitle)
        {
            tipOfTheManagerPage.SelectTipForEditOrDelete(tipTitle);
            Waits.WaitAndClick(driver, tipOfTheManagerPage.BtnEditTip);          
        }

        [When(@"I edit the tip title as '(.*)' and click on Save Changes button")]
        public void WhenIEditTheTipTitleAsAndClickOnSaveChangesButton(string editText)
        {
            Waits.WaitForElementVisible(driver, tipOfTheManagerPage.TxtEditTipTitle);
            tipOfTheManagerPage.TxtEditTipTitle.Clear();
            tipOfTheManagerPage.TxtEditTipTitle.SendKeys(editText);
            tipOfTheManagerPage.BtnSaveChanges.Click();
        }

        [Then(@"the tip should be edited successfully and the new text '(.*)' should reflect in the table")]
        public void ThenTheTipShouldBeEditedSuccessfullyAndTheNewTextShouldReflectInTheTable(string tipTitle)
        {
            Waits.Wait(driver, 2000);
            Assert.AreEqual(tipTitle, tipOfTheManagerPage.GetTipTitleText(tipOfTheManagerPage.TipTableRowsCount - 1));
        }

        [When(@"I select a tip '(.*)' and click the second left most sign in the move rank column")]
        public void WhenISelectATipAndClickTheSecondLeftMostSignInTheMoveRankColumn(string tipTitle)
        {
            tipOfTheManagerPage.ClickSecondLeftMostSignButton(tipTitle);   
        }

        [Then(@"the selected tip '(.*)' should move one rank up in the table")]
        public void ThenTheSelectedTipShouldMoveOneRankUpInTheTable(string tipTitle)
        {
            Assert.AreEqual(tipTitle, tipOfTheManagerPage.GetTipTitleText(tipOfTheManagerPage.TipTableRowsCount - 2));
        }

        [When(@"I select a tip '(.*)' and click the third left most sign in the move rank column")]
        public void WhenISelectATipAndClickTheThirdLeftMostSignInTheMoveRankColumn(string tipTitle)
        {
            tipOfTheManagerPage.ClickThirdLeftMostSignButton(tipTitle);
        }

        [Then(@"the selected tip '(.*)' should move one rank down in the table")]
        public void ThenTheSelectedTipShouldMoveOneRankDownInTheTable(string tipTitle)
        {
            Assert.AreEqual(tipTitle, tipOfTheManagerPage.GetTipTitleText(tipOfTheManagerPage.TipTableRowsCount - 1));

        }

        [When(@"I select a tip '(.*)' and click the left most sign in the move rank column")]
        public void WhenISelectATipAndClickTheLeftMostSignInTheMoveRankColumn(string tipTitle)
        {
            tipOfTheManagerPage.ClickFirstLeftMostSignButton(tipTitle);
        }

        [Then(@"the selected tip '(.*)' should move to the top of the table")]
        public void ThenTheSelectedTipShouldMoveToTheTopOfTheTable(string tipTitle)
        {
            Assert.AreEqual(tipTitle, tipOfTheManagerPage.GetTipTitleText(1));

        }

        [When(@"I select a tip '(.*)' and click the fourth left most sign in the move rank column")]
        public void WhenISelectATipAndClickTheFourthLeftMostSignInTheMoveRankColumn(string tipTitle)
        {
            tipOfTheManagerPage.ClickFourthLeftMostSignButton(tipTitle);
        }

        [Then(@"the selected tip '(.*)' should move to the bottom of the table")]
        public void ThenTheSelectedTipShouldMoveToTheBottomOfTheTable(string tipTitle)
        {
            Assert.AreEqual(tipTitle, tipOfTheManagerPage.GetTipTitleText(tipOfTheManagerPage.TipTableRowsCount - 1));
        }

        [When(@"I select a tip '(.*)' and click on the Delete Tip button")]
        public void WhenISelectATipAndClickOnTheDeleteTipButton(string tipTitle)
        {
            tipOfTheManagerPage.SelectTipForEditOrDelete(tipTitle);
            Waits.WaitAndClick(driver, tipOfTheManagerPage.BtnDeleteTip);
        }

        [Then(@"a confirmation popup will appear stating '(.*)'")]
        public void ThenAConfirmationPopupWillAppearStating(string text)
        {
            Waits.Wait(driver, 2000);
            Assert.AreEqual(text, tipOfTheManagerPage.DeleteTipConfirmText);
        }

        [When(@"I click Delete Tip button on the pop up")]
        public void WhenIClickDeleteTipButtonOnThePopUp()
        {
            tipOfTheManagerPage.BtnDeleteTipDialog.Click();
        }

        [Then(@"the tip '(.*)' will be deleted successfully from the table")]
        public void ThenTheTipWillBeDeletedSuccessfullyFromTheTable(string tipTitle)
        {
            Assert.IsFalse(tipOfTheManagerPage.IsTipExistsInTable(tipTitle));
        }

        [Given(@"I Insert tips in the database")]
        public void GivenIInsertTipsInTheDatabase()
        {
            if (tipOfTheManagerPage == null)
                tipOfTheManagerPage = new TipOfTheDayManagerPage(driver);
            tipOfTheManagerPage.DeleteTipsFromTable();
            tipOfTheManagerPage.InsertNewValueToTable();
        }

        [Then(@"the Tip of the day popup should appear with Next and Close button")]
        public void ThenTheTipOfTheDayPopupShouldAppearWithNextAndCloseButton()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(tipOfTheManagerPage.IsDivLLTrainingExists);
            Assert.IsTrue(tipOfTheManagerPage.BtnNext.Displayed);
            Assert.IsTrue(tipOfTheManagerPage.BtnClose.Displayed);
        }

        [Then(@"the Tip of the day popup should disappear")]
        public void ThenTheTipOfTheDayPopupShouldDisappear()
        {
            Assert.IsFalse(tipOfTheManagerPage.IsDivLLTrainingExists);
        }

        [Then(@"the tip content '(.*)' should appear")]
        public void ThenTheTipContentShouldAppear(string tipContent)
        {
            Assert.AreEqual(tipContent, tipOfTheManagerPage.TipLLContent);
        }

        [Then(@"the tip header '(.*)' should appear")]
        public void ThenTheTipHeaderShouldAppear(string tipHeader)
        {
            Assert.AreEqual(tipHeader, tipOfTheManagerPage.TipLLHeader);
        }

        [When(@"I click on the Next button")]
        public void WhenIClickOnTheNextButton()
        {
            tipOfTheManagerPage.BtnNext.Click();
        }

        [When(@"I Click on the previous button")]
        public void WhenIClickOnThePreviousButton()
        {
            tipOfTheManagerPage.BtnPrevious.Click();
        }

        [When(@"I click on the Next button twice")]
        public void WhenIClickOnTheNextButtonTwice()
        {
            tipOfTheManagerPage.BtnNext.Click();
            Waits.Wait(driver, 1000);
            tipOfTheManagerPage.BtnNext.Click();
        }

        [When(@"I Click on the close button")]
        public void WhenIClickOnTheCloseButton()
        {
            tipOfTheManagerPage.BtnClose.Click();
        }

        [When(@"I click on the don't show this tip again checkbox")]
        public void WhenIClickOnTheDonTShowThisTipAgainCheckbox()
        {
            tipOfTheManagerPage.ChkDontShowTipBox.Click();
        }



    }
}
