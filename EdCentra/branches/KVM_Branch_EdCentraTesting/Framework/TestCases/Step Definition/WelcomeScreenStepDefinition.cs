using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases
{
    [Binding]
    public sealed class WelcomeScreenStepDefinition
    {
        private IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;
        UserPage userPage;

        public WelcomeScreenStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }


        public void PageInitialization()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            userPage = new UserPage(driver);
        }

        [Given(@"I opened EDCENTRA url")]
        public void GivenIOpenedEDCENTRAUrl()
        {
            PageInitialization();
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);
        }

        [When(@"I entered wrong '(.*)' and '(.*)' and clicked login button")]
        public void WhenIEnteredWrongAndAndClickedLoginButton(string username, string password)
        {
            loginPage.SignIn(username, password);
        }

        [Then(@"A message stating '(.*)' should be displayed on the Welcome screen")]
        public void ThenAMessageStatingShouldBeDisplayedOnTheWelcomeScreen(string msg)
        {
            Assert.True(loginPage.DisplayedInvalidCredentialsErrorMessage().Contains(msg), "Invalid login details entered");
        }

        [When(@"I Launched browser and visited the URL \[SERVER IP]/EdwardsScada")]
        public void WhenILaunchedBrowserAndVisitedTheURLSERVERIPEdwardsScada()
        {
            PageInitialization();
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);
        }

        [Then(@"The EdCentra Welcome Screen should be displayed")]
        public void ThenTheEdCentraWelcomeScreenShouldBeDisplayed()
        {
            Assert.IsTrue(loginPage.TxtLoginUserName.Displayed, "Verified UserName text box on Welcome screen");
            Assert.IsTrue(loginPage.TxtPassword.Displayed, "Verified Password text box on Welcome screen");
        }

        [When(@"On the welcome screen, click on \[Help]")]
        public void WhenOnTheWelcomeScreenClickOnHelp()
        {
            loginPage.LnkHelp.Click();
        }

        [Then(@"The help screen should be displayed\.")]
        public void ThenTheHelpScreenShouldBeDisplayed_()
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(loginPage.LblHelp.Displayed, "Verified Help label in Help Screen");
        }

        [When(@"On the welcome screen, clicked on license agreement")]
        public void WhenOnTheWelcomeScreenClickedOnLicenseAgreement()
        {
            loginPage.LnkLicenseAgreement.Click();
        }

        [Then(@"The license agreement screen should be displayed\.")]
        public void ThenTheLicenseAgreementScreenShouldBeDisplayed_()
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(loginPage.LnkLicenseAgreement.Displayed, "Verified Software License and Support Agreement label in License agreement Screen");
        }

        [When(@"On the welcome screen, click on \[About]")]
        public void WhenOnTheWelcomeScreenClickOnAbout()
        {
            loginPage.LnkAbout.Click();
        }

        [Then(@"The about screen should be displayed\.")]
        public void ThenTheAboutScreenShouldBeDisplayed_()
        {
            Assert.IsTrue(loginPage.LblAbout.Displayed, "Verified About label button on About Screen");
            Assert.IsTrue(loginPage.BtnActivate.Displayed, "Verified Activate button on About Screen");
        }

        [Then(@"I should be navigated to home page\.")]
        public void ThenIShouldBeNavigatedToHomePage_()
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, homePage.LnkDeviceManager), "Verified User should be navigated to Home page");
        }

        [When(@"clicked forget password link")]
        public void WhenClickedForgetPasswordLink()
        {
            loginPage.LinkForgotPassword.Click();
        }

        [Then(@"Forgotten Password pop up should open")]
        public void ThenForgottenPasswordPopUpShouldOpen()
        {
            Assert.IsTrue(loginPage.LinkForgotPassword.Displayed, "Verified Forgotton PAssword pop up");
        }

        [When(@"Entered an invalid Memorable Answer '(.*)' and click \[Apply]")]
        public void WhenEnteredAnInvalidMemorableAnswerAndClickApply(string ans)
        {
            loginPage.TxtMemorableAns.SendKeys(ans);
            loginPage.BtnApply.Click();
        }

        [Then(@"The message '(.*)' should be displayed\.")]
        public void ThenTheMessageShouldBeDisplayed_(string msg)
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(loginPage.LblForgotErrorMessage.Text.Contains(msg), "'Failed to reset password, check your memorable answer' not displayed on screen");
        }

        [Then(@"message '(.*)' should be displayed\.")]
        public void ThenMessageShouldBeDisplayed_(string msg)
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(loginPage.LblConfirmationMessage.Text.Contains(msg), "'Password has been set to password123. Please change this as soon as possible' not displayed on screen");
        }

        [When(@"Entered a valid Memorable Answer '(.*)' and click \[Apply]")]
        public void WhenEnteredAValidMemorableAnswerAndClickApply(string ans)
        {
            loginPage.TxtMemorableAns.Clear();
            loginPage.TxtMemorableAns.SendKeys(ans);
            loginPage.BtnApply.Click();
        }

        [When(@"Clicked \[Ok]")]
        public void WhenClickedOk()
        {
            Waits.Wait(driver, 2000);
            loginPage.BtnOk.Click();
        }

        [Then(@"The Welcome Screen should be displayed\.")]
        public void ThenTheWelcomeScreenShouldBeDisplayed_()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(loginPage.TxtLoginUserName.Displayed, "Verified UserName text box on Welcome screen");
            Assert.IsTrue(loginPage.TxtPassword.Displayed, "Verified Password text box on Welcome screen");
        }

        [When(@"Opened the User Manager application")]
        public void WhenOpenedTheUserManagerApplication()
        {
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
        }

        [When(@"In User Manager application click on Current User tab\.")]
        public void WhenInUserManagerApplicationClickOnCurrentUserTab_()
        {
            userPage.LnkCurrentUser.Click();
        }

        [Then(@"User details displayed with details '(.*)', '(.*)', '(.*)'\.")]
        public void ThenUserDetailsDisplayedWithDetails_(string userName, string lastName, string email)
        {
            Waits.Wait(driver, 1000);
            Assert.IsTrue(userPage.LblUserNameCurrentUserTab.Text.Contains(userName), "Verified User name details on current user page");
            Assert.IsTrue(userPage.TxtLastNameCurrentUserTab.GetAttribute("value").Contains(lastName), "Verified Last name details on current user page");
            Assert.IsTrue(userPage.TxtEmailIdCurrentUserTab.GetAttribute("value").Contains(email), "Verified email details on current user page ");
        }

        [When(@"I click Change Password Link\.")]
        public void WhenIClickChangePasswordLink_()
        {
            userPage.LnkChangePassword.Click();
        }

        [Then(@"The '(.*)' dialog should be displayed\.")]
        public void ThenTheDialogShouldBeDisplayed_(string lblName)
        {
            Assert.IsTrue(userPage.LblChangePassword.Text.Contains(lblName), "Verified Changed Password label on pop -up");
        }

        [When(@"entered current password '(.*)', new password '(.*)', confirm new password '(.*)' fields and clicked Apply button\.")]
        public void WhenEnteredCurrentPasswordNewPasswordConfirmNewPasswordFieldsAndClickedApplyButton_(string currentPwd, string newPwd, string confirmPwd)
        {
            userPage.TxtCurrentPassword.SendKeys(currentPwd);
            userPage.TxtNewPassword.SendKeys(newPwd);
            userPage.TxtConfirmNewPassword.SendKeys(confirmPwd);
            userPage.BtnApplyOnChangePwdPopUp.Click();
        }

        [Then(@"the message '(.*)' will display\.")]
        public void ThenTheMessageWillDisplay_(string msg)
        {
            Waits.Wait(driver, 1000);
            Assert.IsTrue(userPage.LblErrorChangePasswordMsg.Text.Contains(msg), "Verified 'Failed to update, check your password' msg");
        }

        [When(@"If the '(.*)' and '(.*)' do not match, then the message 'The following problems were found:")]
        public void WhenIfTheAndDoNotMatchThenTheMessageTheFollowingProblemsWereFound(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"'(.*)' will display\.")]
        public void ThenWillDisplay_(string msg)
        {
            Waits.Wait(driver, 1000);
            Assert.IsTrue(userPage.LblErrorMismatchNewandCfmPwd.Text.Contains(msg), "Verified 'The following problems were found:Passwords do not match' msg");
        }

        [Then(@"the message '(.*)' should display\.")]
        public void ThenTheMessageShouldDisplay_(string msg)
        {
            Assert.IsTrue(userPage.LblconfirmationMessage.Text.Contains(msg), "Verified 'Your Password was changed successfully' msg");
        }
        [When(@"logged out\.")]
        public void WhenLoggedOut_()
        {
            JavaScriptExecutor.JavaScriptClick(driver, userPage.LinkHomePage);
            Waits.Wait(driver, 2000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, homePage.LnkLoginUser);
            homePage.LnkLoginUser.Click();
            homePage.LinkLogout.Click();
        }
       
        [When(@"Login with updated password '(.*)' and '(.*)'\.")]
        public void WhenLoginWithUpdatedPasswordAnd_(string userName, string pwd)
        {
            loginPage.SignIn(userName, pwd);
        }

        [Then(@"Logon successful\.")]
        public void ThenLogonSuccessful_()
        {
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, homePage.LnkDeviceManager), "Verifying User should be navigated to Home page");
        }


    }
}
