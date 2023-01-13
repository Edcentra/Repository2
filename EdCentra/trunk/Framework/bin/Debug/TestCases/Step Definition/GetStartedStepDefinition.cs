using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class GetStartedStepDefinition
    {
        private IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;
        UserPage userPage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        LiveAlertsListPage liveAlertsListPage;
        DataExtractionPage dataExtractionPage;
        HistorianPage historianPage;
        ReportPage reportPage;
        PTMPage ptmPage;
        Simulator simulator = new Simulator();
        string AuthorizationCode = string.Empty;
        string SuperuserCode = string.Empty;

        public GetStartedStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            userPage = new UserPage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            liveAlertsListPage = new LiveAlertsListPage(driver);
            dataExtractionPage = new DataExtractionPage(driver);
            ptmPage = new PTMPage(driver);
            historianPage = new HistorianPage(driver);
            reportPage = new ReportPage(driver);
        }

        [Given(@"opened EDCENTRA app")]
        public void GivenOpenedEDCENTRAApp()
        {
            PageInitialization();
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);
        }

        [When(@"entered username as '(.*)' and password as '(.*)'")]
        public void WhenEnteredUsernameAsAndPasswordAs(string userName, string password)
        {
            Waits.Wait(driver, 3000);
            loginPage.SignIn(userName, password);
        }

        [Then(@"should be navigated to home page\.")]
        public void ThenShouldBeNavigatedToHomePage_()
        {
            Assert.IsTrue(driver.Url.Contains("EdwardsScada"), "Not navigated to home page");
            Assert.IsTrue(homePage.LnkDeviceManager.Displayed, "Device manager link is not displayed");
        }

        [When(@"added new User with details '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' and '(.*)' in Create user form\.")]
        public void WhenAddedNewUserWithDetailsAndInCreateUserForm_(string userName, string pwd, string confirmPwd, string question, string ans, string firstName, string lastName, string email)
        {
            Waits.Wait(driver, 8000);
            userPage.CreateNewUser(userName, pwd, confirmPwd, question, ans, firstName, lastName, email);
            userPage.LinkHomePage.Click();
            Waits.Wait(driver, 4000);
        }

        [When(@"Opened the User Manager application, and click on the ‘Maintain Users’ tab\.Click on Create User link\.")]
        public void WhenOpenedTheUserManagerApplicationAndClickOnTheMaintainUsersTab_ClickOnCreateUserLink_()
        {
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, homePage.LnkConfigure);
            homePage.ClickOnConfiguration();
            Waits.WaitForElementVisible(driver, homePage.LnkUserManager);
            homePage.ClickOnUserManager();
            userPage.LnkMaintainUser.Click();
            userPage.LinkCreateUser.Click();
        }


        [When(@"I logged out\.")]
        public void WhenILoggedOut_()
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.Wait(driver, 7000);
            homePage.LnkLoginUser.Click();
            Waits.Wait(driver, 2000);
            homePage.LinkLogout.Click();
            Waits.Wait(driver, 2000);
        }


        [Then(@"Login screen should be displayed")]
        public void ThenLoginScreenShouldBeDisplayed()
        {
            Assert.IsTrue(loginPage.TxtLoginUserName.Displayed, "Login screen is not displayed");
        }

        [When(@"entered an invalid username '(.*)' and password '(.*)'")]
        public void WhenEnteredAnInvalidUsernameAndPassword(string userName, string password)
        {
            loginPage.SignIn(userName, password);
        }

        [When(@"clicked login button")]
        public void WhenClickedLoginButton()
        {
            loginPage.ClickOnLoginButton();
        }

        [Then(@"The message '(.*)' should be displayed")]
        public void ThenTheMessageShouldBeDisplayed(string msg)
        {
            string errMsg = loginPage.DisplayedInvalidCredentialsErrorMessage();
            Assert.IsTrue(errMsg.Contains(msg), "invalid credential error message not displayed");
        }

        [When(@"entered a valid username '(.*)' and password '(.*)'")]
        public void WhenEnteredAValidUsernameAndPassword(string userName, string pwd)
        {
            loginPage.SignIn(userName, pwd);
        }

        [When(@"If the memorable question and answer screen is shown, entered the details '(.*)' '(.*)' '(.*)' and continued")]
        public void WhenIfTheMemorableQuestionAndAnswerScreenIsShownEnteredTheDetailsAndContinued(string question, string ans, string pwd)
        {
            Assert.IsTrue(loginPage.LblsetMemorableInformation.Displayed, "Set Memorable Information pop up is displayed");
            loginPage.TxtMemorableQuestion.SendKeys(question);
            loginPage.TxtMemorableAnswer.SendKeys(ans);
            loginPage.TxtReEnterPassword.SendKeys(pwd);
            loginPage.BtnApply.Click();
        }

        [Then(@"Your details should be stored and you should continue through the login process and should login in\.")]
        public void ThenYourDetailsShouldBeStoredAndYouShouldContinueThroughTheLoginProcessAndShouldLoginIn_()
        {
            loginPage.BtnOk.Click();
            driver.Url.Contains("EdwardsScada/default.aspx");
        }

        [Then(@"After successfull log-in, currently logged in user will be displayed on bottom right corner of the screen '(.*)'")]
        public void ThenAfterSuccessfullLog_InCurrentlyLoggedInUserWillBeDisplayedOnBottomRightCornerOfTheScreen(string userName)
        {
            Assert.IsTrue(homePage.LnkLoginUser.Text.Contains(userName), "logged in user name is not visible on screen");
        }

        [When(@"Hover over user name")]
        public void WhenHoverOverUserName()
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            ElementExtensions.MouseHover(driver, homePage.LnkLoginUser);
        }

        [Then(@"A Logout link should be displayed on hover menu\.")]
        public void ThenALogoutLinkShouldBeDisplayedOnHoverMenu_()
        {
            Assert.IsTrue(homePage.LinkLogout.Displayed, "Log out link is not displayed");
        }

        [When(@"clicked over it")]
        public void WhenClickedOverIt()
        {
            homePage.LinkLogout.Click();
        }

        [Then(@"it results in logging out for the current user\.")]
        public void ThenItResultsInLoggingOutForTheCurrentUser_()
        {
            Assert.IsTrue(loginPage.TxtLoginUserName.Displayed, "user is not logged out");
        }

        [When(@"checked the Home Screen")]
        public void WhenCheckedTheHomeScreen()
        {

        }

        [Then(@"It should show a list of Applications along with the options at the foot of the screen : About,Options, Logged in User Name\(Log Off should display as Hover menu on Logged in User\)")]
        public void ThenItShouldShowAListOfApplicationsAlongWithTheOptionsAtTheFootOfTheScreenAboutOptionsLoggedInUserNameLogOffShouldDisplayAsHoverMenuOnLoggedInUser()
        {
            Assert.IsTrue(homePage.LnkDeviceExplorer.Displayed, "Device explorer link is not visible");
            Assert.IsTrue(homePage.LnkLiveAlerts.Displayed, "Live alerts list link is not visible");
            Assert.IsTrue(homePage.LnkHistorian.Displayed, "Historian link is not visible");
            Assert.IsTrue(homePage.LnkDataExtractionUtility.Displayed, "Data Extrction Utility link is not visible");
            Assert.IsTrue(homePage.LnkPredictiveMaintenance.Displayed, "Predictive Maintenance link is not visible");
            Assert.IsTrue(homePage.LnkPTM.Displayed, "PTM link is not displayed");
            // Assert.IsTrue(homePage.LnkPDM.Displayed, "PDM link is not displayed");
            Assert.IsTrue(homePage.LnkAbout.Displayed, "About link is not displayed");
            Assert.IsTrue(homePage.LnkHelp.Displayed, "Help link is not displayed");
            Assert.IsTrue(homePage.LnkConfigure.Displayed, "Configure link is not displayed");
            Assert.IsTrue(homePage.LnkLoginUser.Text.Contains("administrator"), "logged in user Link is displayed");
        }

        [When(@"Go to Configure ->User Manager->Current User tab")]
        public void WhenGoToConfigure_UserManager_CurrentUserTab()
        {
            Waits.Wait(driver, 3000);
            homePage.ClickOnConfiguration();
            Waits.Wait(driver, 2000);
            //homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
        }

        [Then(@"A window should show containing information about the current user '(.*)','(.*)', '(.*)'")]
        public void ThenAWindowShouldShowContainingInformationAboutTheCurrentUser(string firstName, string lastName, string email)
        {
            Waits.Wait(driver, 3000);
            //Assert.IsFalse(userPage.TxtFirstNameCurrentUser.GetAttribute("value").Contains(firstName), "First name is displayed");
             Assert.IsTrue(userPage.TxtFirstNameCurrentUser.GetAttribute("value").Contains(firstName), "First name is not displayed");
            Assert.IsTrue(userPage.TxtLastNameCurrentUserTab.GetAttribute("value").Contains(lastName), "Last Name is not displayed");
            Assert.IsTrue(userPage.TxtEmailIdCurrentUserTab.GetAttribute("value").Contains(email), "email is not displayed");
        }

        [When(@"If logged in as administrator and clicked on Options")]
        public void WhenIfLoggedInAsAdministratorAndClickedOnOptions()
        {
            userPage.LinkHomePage.Click();
            Waits.Wait(driver, 3000);
            homePage.LnkOptions.Click();
        }

        [Then(@"The current gambit of General Options should be displayed")]
        public void ThenTheCurrentGambitOfGeneralOptionsShouldBeDisplayed()
        {

            Waits.Wait(driver, 3000);
            Assert.IsTrue(homePage.LblTraceMode.Text.Contains("Turn On"), "Trace mode settings is not correctly displayed");
            Assert.IsTrue(homePage.DdlAutoAddChileSystems.Text.Contains("Off"), "AutoAddChildSystems dropdown is not displaying correct selected value");
            Assert.IsTrue(homePage.DdlEnableGreenMode.Displayed, "Enable Green mode dropdown is not showing correct selected value");
            Assert.IsTrue(homePage.DdlPasswordExpiry.Text.Contains("Off"), "Password expiry Dropdown is not showing correct selected value");
            Assert.IsTrue(homePage.TxtPasswordExpiryDays.GetAttribute("value").Contains("90"), "Password Expiry Days textbox not displaying correct value");
            homePage.BtnClose.Click();
        }

        [When(@"Selected Any single application\.")]
        public void WhenSelectedAnySingleApplication_()
        {
            Waits.Wait(driver, 3000);
            homePage.ClickOnDeviceExplorer();
        }

        [Then(@"The Selected application screen should display and other select applications should display at top of the page as horizontal list\.")]
        public void ThenTheSelectedApplicationScreenShouldDisplayAndOtherSelectApplicationsShouldDisplayAtTopOfThePageAsHorizontalList_()
        {
            Waits.Wait(driver, 5000);
            Assert.IsTrue(deviceExplorerNavigationPage.LnkAddFolder.Displayed, "Selected device explorer screen displayed");
            deviceExplorerNavigationPage.LnkRealTimeMonitoring.Click();
            Waits.Wait(driver, 3000);
            Assert.IsTrue(deviceExplorerNavigationPage.LnkDeviceExplorer.Displayed, "Link Device explorer is not displayed");
            Assert.IsTrue(deviceExplorerNavigationPage.LnkLiveAlertsList.Displayed, "Link live alerts list is not displayed");
            deviceExplorerNavigationPage.LnkDiagnostics.Click();
            Waits.Wait(driver, 3000);
            Assert.IsTrue(deviceExplorerNavigationPage.LnkHistorian.Displayed, "Link Historian is not displayed");
            Assert.IsTrue(deviceExplorerNavigationPage.LnkDataExtractionUtility.Displayed, "Link Data Extraction Utility is not displayed");
            Assert.IsTrue(deviceExplorerNavigationPage.LnkSPC.Displayed, "Link SPC is not displayed");
            Assert.IsTrue(deviceExplorerNavigationPage.LnkReports.Displayed, "Link Reports is not displayed");
            deviceExplorerNavigationPage.LnkAdvancedSataAnalytics.Click();
            Waits.Wait(driver, 3000);
            Assert.IsTrue(deviceExplorerNavigationPage.LnkPredictiveMaintenance.Displayed, "Link Predictive Maintenance is not displayed");
            Assert.IsTrue(deviceExplorerNavigationPage.LnkPTM.Displayed, "Link PTM is not displayed");
        }

        [Then(@"The user should able to switch between certain other applications without going to the Home screen of the EdCentra\.")]
        public void ThenTheUserShouldAbleToSwitchBetweenCertainOtherApplicationsWithoutGoingToTheHomeScreenOfTheEdCentra_()
        {
            Waits.Wait(driver, 3000);
            deviceExplorerNavigationPage.LnkRealTimeMonitoring.Click();
            deviceExplorerNavigationPage.LnkLiveAlertsList.Click();
            Waits.Wait(driver, 7000);
            Assert.IsTrue(liveAlertsListPage.BtnShowFilter.Displayed, "not navigated to live alerts list page ");
        }

        [When(@"Login to Ed Centra with a correct user '(.*)', But Incorrect password\t'(.*)'")]
        public void WhenLoginToEdCentraWithACorrectUserButIncorrectPassword(string userName, string pwd)
        {
            WhenEnteredUsernameAsAndPasswordAs(userName, pwd);
        }

        [Then(@"Red message denying access will display '(.*)' and Forgotten Passwork Link")]
        public void ThenRedMessageDenyingAccessWillDisplayAndForgottenPassworkLink(string msg)
        {
            ThenTheMessageShouldBeDisplayed(msg);
            Assert.IsTrue(loginPage.LinkForgotPassword.Displayed, "Link forgotten password is not displayed");
        }

        [When(@"Click on the Forgotten Password Link Request for memorable password")]
        public void WhenClickOnTheForgottenPasswordLinkRequestForMemorablePassword()
        {
            loginPage.LinkForgotPassword.Click();
        }

        [When(@"Answer the users memorable question '(.*)'")]
        public void WhenAnswerTheUsersMemorableQuestion(string ans)
        {
            Waits.WaitForElementVisible(driver, loginPage.TxtMemorableAnswer);
            loginPage.TxtMemorableAnswer.SendKeys(ans);
            Waits.Wait(driver, 2000);
            loginPage.BtnApply.Click();
        }

        [Then(@"The App Select screen\(Home Screen\) should be shown again")]
        public void ThenTheAppSelectScreenHomeScreenShouldBeShownAgain()
        {
            Waits.Wait(driver, 3000);
            driver.Url.Contains("EdwardsScada/Default.aspx");
            Assert.IsTrue(homePage.LnkDeviceExplorer.Displayed, "Device explorer link is displayed");
        }

        [When(@"mouse hover on the Logged-in Username displayed at the bottom-right cornor of the page\.")]
        public void WhenMouseHoverOnTheLogged_InUsernameDisplayedAtTheBottom_RightCornorOfThePage_()
        {
            ElementExtensions.MouseHover(driver, homePage.LnkLoginUser);
        }

        [Then(@"This should then reset your password\.\(The message displayed is '(.*)'\)")]
        public void ThenThisShouldThenResetYourPassword_TheMessageDisplayedIs(string msg)
        {
            Assert.IsTrue(loginPage.LblConfirmationMessage.Text.Contains(msg), " " + msg + " is not displayed");
        }

        [When(@"Repeated the App selection for different applications")]
        public void WhenRepeatedTheAppSelectionForDifferentApplications()
        {
            Waits.Wait(driver, 8000);
            liveAlertsListPage.LnkDiagnostics.Click();
            liveAlertsListPage.LnkDataExtractionUtility.Click();
        }

        [Then(@"Each selected application should display")]
        public void ThenEachSelectedApplicationShouldDisplay()
        {
            Waits.Wait(driver, 8000);
            Assert.IsTrue(dataExtractionPage.LblDailyExtraction.Displayed, "Daily Extraction label is not displayed");
            dataExtractionPage.LinkHome.Click();
            Waits.Wait(driver, 5000);
        }

        [When(@"I logged out")]
        public void WhenILoggedOut()
        {
            homePage.LinkLogout.Click();
        }

        [When(@"Retry to login with the reset password '(.*)'\.")]
        public void WhenRetryToLoginWithTheResetPassword_(string pwd)
        {
            Waits.Wait(driver, 3000);
            loginPage.BtnOk.Click();
            loginPage.TxtPassword.SendKeys(pwd);
            loginPage.ClickOnLoginButton();
        }

        [Then(@"Login possible WITH CORRECT DETAILS")]
        public void ThenLoginPossibleWITHCORRECTDETAILS()
        {
            Assert.IsTrue(driver.Url.Contains("EdwardsScada/default.aspx"), "Login is not successful");
            Waits.Wait(driver, 3000);
        }

        [Given(@"Review the Activation Days Remaining information displayed on top of the page\.")]
        public void GivenReviewTheActivationDaysRemainingInformationDisplayedOnTopOfThePage_()
        {
            loginPage.LnkActivate.Click();
            Waits.Wait(driver, 2000);
            string authCode = loginPage.LblAuthorizationCode.Text;
            simulator.LaunchCodeGenerator();
            simulator.EnterCustomerActivationCode(authCode);
        }

        [When(@"If an INSTALL, then choose '(.*)' from the App to license drop down list and Activate EdCentra to have '(.*)' devices\.")]
        public void WhenIfAnINSTALLThenChooseFromTheAppToLicenseDropDownListAndActivateEdCentraToHaveDevices_(string appName, string deviceNumber)
        {
            simulator.SelectAppToLicense(appName);
            simulator.DeviceLimit(deviceNumber);
            simulator.CopyToClipboard();
            simulator.MinimizeCodeGenerator();
        }

        [Then(@"'(.*)' message should display\.")]
        public void ThenMessageShouldDisplay_(string msg)
        {
            loginPage.LnkActivationKey.Click();
            ElementExtensions.PasteShortCut(driver);
            loginPage.BtnActivate.Click();
            Waits.Wait(driver, 2000);
            Assert.IsTrue(loginPage.LblConfirmationMessage.Text.Contains(msg), "Message has not been displayed");
            loginPage.BtnOk.Click();
            Waits.Wait(driver, 1000);
        }

        [When(@"Selected '(.*)' application and activate the license")]
        public void WhenSelectedApplicationAndActivateTheLicense(string feature)
        {
            string licenseActivationCode = string.Empty;
            if (homePage == null)
                homePage = new HomePage(driver);
            if (feature.Equals("Historian"))
            {
                licenseActivationCode = (string)ScenarioContext.Current["HistorianCode"];
                driver.SwitchTo().Window(driver.WindowHandles.First());
            }
            else if (feature.Equals("PTM"))
            {
                Waits.WaitAndClick(driver, homePage.LnkPTM);
                licenseActivationCode = (string)ScenarioContext.Current["PTMCode"];
            }
            else if (feature.Equals("Reports"))
            {
                Waits.WaitAndClick(driver, homePage.LnkReports);
                licenseActivationCode = (string)ScenarioContext.Current["ReportsCode"];

            }
            else if (feature.Equals("Predictive Maintenance"))
            {
                Waits.WaitAndClick(driver, homePage.LnkPredictiveMaintenance);
                licenseActivationCode = (string)ScenarioContext.Current["EADSCode"];
            }
            else if (feature.Equals("Fingerprint"))
            {
                Waits.WaitAndClick(driver, homePage.LnkFingerprint);
                licenseActivationCode = (string)ScenarioContext.Current["FingerprintCode"];
            }            
            else if(feature.Equals("SECS/GEM Agent (Host)"))
            {
                Waits.WaitAndClick(driver, homePage.LnkSecGemHost);
                licenseActivationCode = (string)ScenarioContext.Current["SecsGemAgentCode"];
            }
            else if (feature.Equals("SECS/GEM Service (Equipment)"))
            {
                Waits.WaitAndClick(driver, homePage.LnkSecGemService);
                licenseActivationCode = (string)ScenarioContext.Current["SecsGemServiceCode"];
            }
            else if (feature.Equals("CTI EQUIPMENT"))
            {
                Waits.WaitAndClick(driver, homePage.LnkSecGemService);
                licenseActivationCode = (string)ScenarioContext.Current["SecsGemServiceCode"];
            }
            if (feature!="Historian")
            Waits.WaitAndClick(driver, homePage.LnkActivate);
            Waits.WaitAndClick(driver, loginPage.LnkActivationKey);
            loginPage.LnkActivationKey.SendKeys(licenseActivationCode);
            if (ElementExtensions.isDisplayed(driver, loginPage.BtnActivate))
            {
                Waits.WaitAndClick(driver, loginPage.BtnActivate);
            }
            else
            {
                Waits.WaitAndClick(driver, loginPage.BtnRenew);
            }
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, loginPage.BtnOk);
            Waits.Wait(driver, 1000);
        }


        [When(@"Selected '(.*)' application and copy the Authorization code and Launch the Code generator on the Application server and choose corresponding feature and then copy the license to the clipboard\.")]
        public void WhenSelectedApplicationAndOpyTheAuthorizationCodeAndLaunchTheCodeGeneratorOnTheApplicationServerAndChooseCorrespondingFeatureAndThenCopyTheLicenseToTheClipboard_(string feature)
        {
            Waits.Wait(driver, 3000);
            if (feature.Equals("PTM"))
            {
               Waits.WaitAndClick(driver, homePage.LnkPTM);
            }
            else if (feature.Equals("Historian"))
            {
               Waits.WaitAndClick(driver, homePage.LnkHistorian);
            }
            else if (feature.Equals("Reports"))
            {
                Waits.WaitAndClick(driver, homePage.LnkReports);
            }
            else if (feature.Equals("Predictive Maintenance"))
            {
                Waits.WaitAndClick(driver, homePage.LnkPredictiveMaintenance);
            }
            else if (feature.Equals("Fingerprint"))
            {
                Waits.WaitAndClick(driver, homePage.LnkFingerprint);
            }
            Waits.WaitAndClick(driver, homePage.LnkActivate);
         
            Waits.WaitAndClick(driver, loginPage.LnkActivationKey);
            ElementExtensions.PasteShortCut(driver);
            if (ElementExtensions.isDisplayed(driver, loginPage.BtnActivate))
            {
                Waits.WaitAndClick(driver, loginPage.BtnActivate);
            }
            else
            {
                Waits.WaitAndClick(driver, loginPage.BtnRenew);
            }
            Waits.Wait(driver, 2000);
           Waits.WaitAndClick(driver, loginPage.BtnOk);
            Waits.Wait(driver, 1000);
        }

        [When(@"Log out of EdCentra and then use activate to license the application chosen above")]
        public void WhenLogOutOfEdCentraAndThenUseActivateToLicenseTheApplicationChosenAbove()
        {
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LinkHomePage);
            Waits.Wait(driver, 2000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, homePage.LnkLoginUser);
            homePage.LnkLoginUser.Click();
            homePage.LinkLogout.Click();
        }

        [When(@"I click on SECS/GEM Agent \(Host\) item and activate the License")]
        public void WhenIClickOnSECSGEMAgentHostItemAndActivateTheLicense()
        {
            string secsGemAgentCode = string.Empty;
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkSecGemHost);
            Waits.WaitAndClick(driver, homePage.LnkActivate);
            secsGemAgentCode = (string)ScenarioContext.Current["SecsGemAgentCode"];
            Waits.WaitAndClick(driver, loginPage.LnkActivationKey);
            loginPage.LnkActivationKey.SendKeys(secsGemAgentCode);
            if (ElementExtensions.isDisplayed(driver, loginPage.BtnActivate))
            {
                Waits.WaitAndClick(driver, loginPage.BtnActivate);
            }
            else
            {
                Waits.WaitAndClick(driver, loginPage.BtnRenew);
            }
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, loginPage.BtnOk);
            Waits.Wait(driver, 1000);
        }

        [When(@"I launch the Code Generator and activate license for all required modules")]
        public void WhenILaunchTheCodeGeneratorAndActivateLicenseForAllRequiredModules()
        { 
            string secsGemAgentCode = string.Empty;
            string secsGemServiceCode = string.Empty;
            string ebaraCode = string.Empty;
            string historianCode = string.Empty;
            string fingerprintCode = string.Empty;
            string PTMCode = string.Empty;
            string reportsCode = string.Empty;
            string eadsCode = string.Empty;
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkHistorian);
            Waits.WaitAndClick(driver, homePage.LnkActivate);
            if (loginPage == null)
                loginPage = new LoginPage(driver);
            string authCode = loginPage.LblAuthorizationCode.Text;
            Waits.Wait(driver, 1000);
            homePage.LaunchCodeGeneratorWebUrl();
            string licenseCodes = homePage.GenerateLicenseCodeForSecGemServiceAndAgent(authCode);

            string[] stringSeparators = new string[] { "\r\n" };
            string[] code = licenseCodes.Split(stringSeparators, StringSplitOptions.None);
            if (code.Length > 1)
            {
                foreach (string s in code)
                {
                    if (s.ToLower().Contains("historian"))
                    {
                        string[] historianLic = s.Split('.');
                        if (historianLic.Length > 2)
                            historianCode = historianLic[2].ToString();
                        ScenarioContext.Current.Add("HistorianCode", historianCode);
                    }
                    else if (s.ToLower().Contains("reports"))
                    {
                        string[] reportLic = s.Split('.');
                        if (reportLic.Length > 2)
                            reportsCode = reportLic[2].ToString();
                        ScenarioContext.Current.Add("ReportsCode", reportsCode);
                    }
                    else if (s.ToLower().Contains("fingerprint"))
                    {
                        string[] fingerprintLic = s.Split('.');
                        if (fingerprintLic.Length > 2)
                            fingerprintCode = fingerprintLic[2].ToString();
                        ScenarioContext.Current.Add("FingerprintCode", fingerprintCode);
                    }
                    else if (s.ToLower().Contains("ptm"))
                    {
                        string[] ptmLic = s.Split('.');
                        if (ptmLic.Length > 2)
                            PTMCode = ptmLic[2].ToString();
                        ScenarioContext.Current.Add("PTMCode", PTMCode);
                    }
                    else if (s.ToLower().Contains("eads"))
                    {
                        string[] eadsLic = s.Split('.');
                        if (eadsLic.Length > 2)
                            eadsCode = eadsLic[2].ToString();
                        ScenarioContext.Current.Add("EADSCode", eadsCode);
                    }
                    else if (s.ToLower().Contains("secs/gem agent"))
                    {
                        string[] agentLic = s.Split('.');
                        if (agentLic.Length > 2)
                            secsGemAgentCode = agentLic[2].ToString();
                        ScenarioContext.Current.Add("SecsGemAgentCode", secsGemAgentCode);
                        if (s.ToLower().Contains("ebara"))
                         ScenarioContext.Current.Add("EbaraCode", secsGemAgentCode);

                    }
                    else if (s.ToLower().Contains("secs/gem service"))
                    {
                        string[] serviceLic = s.Split('.');
                        if (serviceLic.Length > 2)
                            secsGemServiceCode = serviceLic[2].ToString();
                        ScenarioContext.Current.Add("SecsGemServiceCode", secsGemServiceCode);

                    }
                }
            }
        }

        [When(@"I click on SECS/GEM Service \(Equipment\) item and activate the License")]
        public void WhenIClickOnSECSGEMServiceEquipmentItemAndActivateTheLicense()
        {
            string secsGemServiceCode = string.Empty;
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkSecGemService);
            Waits.WaitAndClick(driver, homePage.LnkActivate);
     
            secsGemServiceCode = (string)ScenarioContext.Current["SecsGemServiceCode"];

            Waits.WaitAndClick(driver, loginPage.LnkActivationKey);
            loginPage.LnkActivationKey.SendKeys(secsGemServiceCode);
            if (ElementExtensions.isDisplayed(driver, loginPage.BtnActivate))
            {
                Waits.WaitAndClick(driver, loginPage.BtnActivate);
            }
            else
            {
                Waits.WaitAndClick(driver, loginPage.BtnRenew);
            }
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, loginPage.BtnOk);
            Waits.Wait(driver, 1000);
        }

        [Then(@"Reports fields should be displayed")]
        public void ThenReportsFieldsShouldBeDisplayed()
        {
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, reportPage.LnkAddReport);
            Assert.IsTrue(reportPage.LnkAddReport.Displayed, "Add Report is not displayed in Report page");
        }

        [When(@"Activated all reports")]
        public void WhenActivatedAllReports()
        {
            //reportPage.LnkAbout.Click();
            //Waits.Wait(driver, 5000);
            //string authCode = reportPage.LnkActivationKey.Text;
            //reportPage.BtnClose.Click();
            //simulator.LaunchReport(authCode);
            reportPage.ActivateReport();
            Waits.WaitAndClick(driver, reportPage.BtnApply);
            Waits.Wait(driver, 2000);
        }

        [Then(@"I should be able to see all reports under Report page")]
        public void ThenIShouldBeAbleToSeeAllReportsUnderReportPage()
        {
            Waits.WaitForElementVisible(driver, reportPage.LnkActivateReport);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, reportPage.LnkActivateReport), "Alert Report is visible");
            reportPage.NavigateToHomePage();
        }


        [When(@"Navigated to '(.*)' page")]
        public void WhenNavigatedToPage(string link)
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            if (link.Equals("Historian"))
            {
                homePage.LnkHistorian.Click();
                Waits.Wait(driver, 6000);
            }
            else if (link.Equals("Reports"))
            {
                homePage.LnkReports.Click();
                Waits.Wait(driver, 6000);
            }
            else if (link.Equals("PTM"))
            {
                homePage.LnkPTM.Click();
                Waits.Wait(driver, 6000);
            }
            else if (link.Equals("Predictive Maintenance"))
            {
                homePage.LnkPredictiveMaintenance.Click();
                Waits.Wait(driver, 6000);
            }
            else if (link.Equals("Fingerprint"))
            {
                homePage.LnkFingerprint.Click();
                Waits.Wait(driver, 6000);
            }
        }

        [Then(@"PTM fields should be displayed")]
        public void ThenPTMFieldsShouldBeDisplayed()
        {
            Waits.WaitForElementVisible(driver, ptmPage.TxtProfileName);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, ptmPage.TxtProfileName), "PTM page is not activated");
        }


        [Then(@"Historian fields should be displayed")]
        public void ThenHistorianFieldsShouldBeDisplayed()
        {
            Waits.WaitForElementVisible(driver, historianPage.LnkHistorianEquipmentData);
            Assert.IsTrue(historianPage.LnkHistorianEquipmentData.Displayed, "Equipment Data link is not displayed in Historian page");
            historianPage.LnkHome.Click();
            Waits.Wait(driver, 3000);
            Waits.WaitForElementVisible(driver, homePage.LnkDeviceExplorer);

        }

        [When(@"Selected Accept the agreement chcekbox and click Ok button")]
        public void WhenSelectedAcceptTheAgreementChcekboxAndClickOkButton()
        {
            loginPage.CheckBoxAcceptTheAgreement.Click();
            loginPage.BtnOkLicense.Click();
        }

        [Then(@"user should be navigated to Login page")]
        public void ThenUserShouldBeNavigatedToLoginPage()
        {
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, loginPage.TxtLoginUserName), "Login page has not opened after accepting license");
        }

        [When(@"I entered Memorable question '(.*)', Memorable answer '(.*)' and Reentered password '(.*)'\.")]
        public void WhenIEnteredMemorableQuestionMemorableAnswerAndReenteredPassword_(string memorableQuestion, string memorableAnswer, string reEnterPassword)
        {
            Waits.Wait(driver, 5000);
            loginPage.TxtMemorableQuestion.SendKeys(memorableQuestion);
            loginPage.TxtMemorableAnswer.SendKeys(memorableAnswer);
            loginPage.TxtReEnterPassword.SendKeys(reEnterPassword);
        }

        [When(@"I clicked Apply button\.")]
        public void WhenIClickedApplyButton_()
        {

            Waits.Wait(driver, 1000);
            if (ElementExtensions.isDisplayed(driver, loginPage.BtnApply))
            {
                loginPage.BtnApply.Click();
            }
        }

        [Then(@"Successful message '(.*)' should appear on screen\.")]
        public void ThenSuccessfulMessageShouldAppearOnScreen_(string message)
        {
            Assert.IsTrue(loginPage.LblConfirmationMessage.Text.Contains(message), "Verifying 'Your Memorable Question has been updated' message");
        }

        [When(@"clicked '(.*)' link on home page\.")]
        public void WhenClickedLinkOnHomePage_(string featureName)
        {
            if (featureName.Equals("Historian"))
            {
                homePage.LnkHistorian.Click();
            }
        }

        //==Enable fingerprint for administrator==//

        [When(@"I click About link and copy the authorization code")]
        public void WhenIClickAboutLinkAndCopyTheAuthorizationCode()
        {
            loginPage.LnkActivate.Click();
            Waits.Wait(driver, 2000);
            AuthorizationCode = loginPage.LblAuthorizationCode.Text;

            //close and logout
            loginPage.BtnClose.Click();
            //homePage.LnkAbout.Click();

            ////Get the authorization code
            //AuthorizationCode = homePage.TxtActivationKey.Text;
            //close and logout as administrator
        }

        [Then(@"I open codegenerator and get the superuser password code")]
        public void ThenIOpenCodegeneratorAndGetTheSuperuserPasswordCode()
        {
            //Open code gen and give the code
            SuperuserCode = simulator.SuperuserCodeGenerator(AuthorizationCode);
        }

        [When(@"I login as superuser")]
        public void WhenILoginAsSuperuser()
        {
            loginPage.SignIn("superuser", SuperuserCode);
            
        }

        [Then(@"I navigate to Configure - User Manager, enable fingerprint for admin user and logout")]
        public void ThenINavigateToConfigure_UserManagerEnableFingerprintForAdminUserAndLogout()
        {
            //configure - usermanager
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, homePage.LnkConfigure);
            homePage.ClickOnConfiguration();
            Waits.WaitForElementVisible(driver, homePage.LnkUserManager);
            homePage.ClickOnUserManager();
            userPage.LnkMaintainUser.Click();
            Waits.Wait(driver, 2000);
            userPage.AdminEdCentra.Click();
            Waits.Wait(driver, 2000);
            userPage.ClickPermissionTab.Click();
            Waits.Wait(driver, 2000);
            userPage.SelectAllCheckBox.Click();
            Waits.Wait(driver, 2000);
            userPage.BtnApplyOnPermTab.Click();
            Waits.Wait(driver, 2000);
            userPage.LinkHomePage.Click();
            Waits.Wait(driver, 2000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, homePage.LnkLoginUser);
            Waits.WaitAndClick(driver, homePage.LnkLoginUser);
            Waits.WaitAndClick(driver, homePage.LinkLogout);
        }

        [When(@"I login username as '(.*)' and password as '(.*)'")]
        public void WhenILoginUsernameAsAndPasswordAs(string username, string pwd)
        {
            loginPage.SignIn(username, pwd);
        }

        [Then(@"fingerprint is displayed in home page")]
        public void ThenFingerprintIsDisplayedInHomePage()
        {
            Assert.IsTrue(homePage.SeeFingerprintImage.Displayed, "Fingerprint image is not seen in admin homepage!");
        }

    }
}
