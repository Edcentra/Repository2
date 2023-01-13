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
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class UserManagementStepDefinition
    {
        string testFolderName = ElementExtensions.GetRandomString(4);
        string renameFolder = ElementExtensions.GetRandomString(4);
        LoginPage loginPage;
        HomePage homePage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        UserPage userPage;
        DispatchManagerPage dispatchManagerPage;
        ConfigurationHandlerPage configuarationHandlerPage;
        HistorianPage historianPage;
        ReportPage reportPage;
        LiveAlertsListPage liveAlertsListPage;
        private IWebDriver driver;
        Simulator simulator = new Simulator();

        public UserManagementStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            userPage = new UserPage(driver);
            dispatchManagerPage = new DispatchManagerPage(driver);
            configuarationHandlerPage = new ConfigurationHandlerPage(driver);
            historianPage = new HistorianPage(driver);
            reportPage = new ReportPage(driver);
            liveAlertsListPage = new LiveAlertsListPage(driver);
        }

        [Given(@"I opened EDCENTRA app url in browser")]
        public void GivenIOpenedEDCENTRAAppUrlInBrowser()
        {
            PageInitialization();
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);
        }

        [When(@"I entered username as '(.*)' and password as '(.*)' and clicked login button")]
        public void WhenIEnteredUsernameAsAndPasswordAsAndClickedLoginButton(string username, string password)
        {
            loginPage.SignIn(username, password);
        }

        [Then(@"I should be navigated to home page")]
        public void ThenIShouldBeNavigatedToHomePage()
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.Wait(driver, 3000);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, homePage.LnkDeviceManager), "Verifying User should be navigated to Home page");
        }

        [When(@"Launched and started Eissa simulator")]
        public void WhenLaunchedAndStartedEissaSimulator()
        {
            simulator.LaunchSimulator();
            simulator.SelectEquipment();
            simulator.MinimizeWindow();
        }

        [When(@"Opened the User Manager application, and click on the ‘Maintain Users’ tab\.Click on Create User link")]
        public void WhenOpenTheUserManagerApplicationAndClickOnTheMaintainUsersTab_ClickOnCreateUserLink()
        {
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            Waits.WaitAndClick(driver, userPage.LnkMaintainUser);
            Waits.WaitForElementVisible(driver, userPage.LinkCreateUser);
            Waits.WaitAndClick(driver, userPage.LinkCreateUser);
        }

        [Then(@"Create User form is displayed\.")]
        public void ThenCreateUserFormIsDisplayed_()
        {
            Waits.WaitForElementVisible(driver, userPage.LblCreateUser);
            Assert.IsTrue(userPage.LblCreateUser.Displayed, "Verified Create User Label on Create User form");
        }

        [When(@"Clicked Create")]
        public void WhenClickedCreate()
        {
            Waits.WaitForElementVisible(driver, userPage.BtnCreateUser);
            Waits.Wait(driver, 2000);
            userPage.BtnCreateUser.Click();
        }

        [Then(@"Required Field text should appear besides User Name, Password, confirm, First Name, Last Name and e-mail field")]
        public void ThenRequiredFieldTextShouldAppearBesidesUserNamePasswordConfirmFirstNameLastNameAndE_MailField()
        {
            Waits.Wait(driver, 5000);
            Assert.IsTrue(userPage.MsgUserNameRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for User name");
            Assert.IsTrue(userPage.MsgPasswordRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for Password");
            Assert.IsTrue(userPage.MsgCfmPasswordRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for Confirm Passowrd");
            Assert.IsTrue(userPage.MsgFirstNameRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for First name");
            Assert.IsTrue(userPage.MsgLastNameRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for Last name");
            Assert.IsTrue(userPage.MsgEmailRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for Email");
        }

        [When(@"Fill in the following fields one by one username '(.*)' password '(.*)', First Name '(.*)', clicking ‘Create’ in between entering them: User Name, Password/confirm, First Name, Last Name, e-mail")]
        public void WhenFillInTheFollowingFieldsOneByOneUsernamePasswordFirstNameClickingCreateInBetweenEnteringThemUserNamePasswordConfirmFirstNameLastNameE_Mail(string userName, string pwd, string fN)
        {
            Waits.Wait(driver, 1000);
            userPage.EnterUserName(userName);
            Waits.Wait(driver, 2000);
            userPage.EnterPassword(pwd);
            Waits.Wait(driver, 1000);
            userPage.EnterFirstName(fN);
            Waits.Wait(driver, 1000);
            userPage.BtnCreateUser.Click();
            Waits.Wait(driver, 1000);
        }

        [Then(@"Required Field is displayed each time besides empty required field until all of the fields have been entered correctly")]
        public void ThenRequiredFieldIsDisplayedEachTimeBesidesEmptyRequiredFieldUntilAllOfTheFieldsHaveBeenEnteredCorrectly()
        {
            Assert.IsTrue(userPage.MsgCfmPasswordRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for Confirm Passowrd");
            Assert.IsTrue(userPage.MsgLastNameRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for Last name");
            Assert.IsTrue(userPage.MsgEmailRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage), "Verified 'Required Field' validation message for Email");
        }

        [Then(@"Newly created user '(.*)' '(.*)' '(.*)' should appear as Link\(User name as link text\) on left hand side\.User detail tab should be displayed for newly created user")]
        public void ThenNewlyCreatedUserShouldAppearAsLinkUserNameAsLinkTextOnLeftHandSide_UserDetailTabShouldBeDisplayedForNewlyCreatedUser(string fN, string lN, string uN)
        {
            Assert.IsTrue(userPage.IsUserExist(fN, lN, uN), "Verfied created user displayed on left side");
            userPage.SelectCreatedUser(uN, fN, lN);
            userPage.TabUSerDetails.Click();
            Waits.Wait(driver, 2000);
            Assert.IsTrue(userPage.LblCreateUser.Text.Contains(uN), "Verified user details tab");
        }


        [When(@"logged out")]
        public void WhenLoggedOut()
        {
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LinkHomePage);
            Waits.Wait(driver, 4000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, homePage.LnkLoginUser);
            homePage.LnkLoginUser.Click();
            Waits.WaitAndClick(driver, homePage.LinkLogout);
        }

        [When(@"logon as the newly created user userName '(.*)' and password '(.*)'")]
        public void WhenLogonAsTheNewlyCreatedUserUserNameAndPassword(string username, string password)
        {
            Waits.Wait(driver, 1000);
            loginPage.SignIn(username, password);
        }

        [Then(@"The new user should be able to logon")]
        public void ThenTheNewUserShouldBeAbleToLogon()
        {
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, homePage.LnkDeviceManager), "Verifying User should be navigated to Home page");
        }


        [Then(@"Passwords do not match text should appear besides conform filed")]
        public void ThenPasswordsDoNotMatchTextShouldAppearBesidesConformFiled()
        {
            Assert.IsTrue(userPage.MsgPasswordDoNotMatch.Text.Contains(GlobalConstants.PasswordNotMatch), "Verified 'Password Do Not Match' validation message for Confirm Passowrd");
        }

        [When(@"I added new User with details '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' and '(.*)' in Create user form")]
        public void WhenIAddedNewUserWithDetailsAndInCreateUserForm(string userName, string pwd, string confirmPwd, string question, string ans, string firstName, string lastName, string email)
        {
            Waits.WaitForElementVisible(driver, userPage.TxtFirstName);
            userPage.CreateNewUser(userName, pwd, confirmPwd, question, ans, firstName, lastName, email);
        }

        [When(@"Provided all application permissions")]
        public void WhenProvidedAllApplicationPermissions()
        {
            userPage.ClickOnApplyChanges();
            Waits.WaitForElementVisible(driver, userPage.LnkPermission);
            Waits.WaitAndClick(driver, userPage.LnkPermission);
            Waits.WaitAndClick(driver, userPage.SelectAllCheckBox);
            Waits.Wait(driver, 5000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, userPage.BtnApplyChange);
            Waits.Wait(driver, 5000);
            Waits.WaitAndClick(driver, userPage.BtnApplyChange);
            Waits.WaitForElementVisible(driver, userPage.LblChangesApplied);
            Assert.IsTrue(userPage.LblChangesApplied.Text.Contains("Changes have been applied"), "Verified 'Changes have been applied' message");
        }


        [When(@"I entered user with details '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' and '(.*)' in Create user form")]
        public void WhenIEnteredUserWithDetailsAndInCreateUserForm(string userName, string pwd, string confirmPwd, string question, string ans, string firstName, string lastName, string email)
        {
            userPage.CreateNewUser(userName, pwd, confirmPwd, question, ans, firstName, lastName, email);
        }


        [Then(@"I should see Set Memorable Information window")]
        public void ThenIShouldSeeSetMemorableInformationWindow()
        {
            Assert.IsTrue(loginPage.LblsetMemorableInformation.Displayed, "Verified  Set Memorable Information label ");
        }

        [When(@"I entered Memorable question '(.*)', Memorable answer '(.*)' and Reentered password '(.*)'")]
        public void WhenIEnteredMemorableQuestionMemorableAnswerAndReconfirmedPassword(string memorableQuestion, string memorableAnswer, string reEnterPwd)
        {
            userPage.TxtMemorableQuestion.SendKeys(memorableQuestion);
            userPage.TxtMemorableAnswer.SendKeys(memorableAnswer);
            userPage.TxtReEnterPassword.SendKeys(reEnterPwd);
        }

        [When(@"I clicked Apply button")]
        public void WhenIClickedApplyButton()
        {
            Waits.WaitForElementVisible(driver, loginPage.BtnApplySetMemorableInfoPopUp);
            loginPage.BtnApplySetMemorableInfoPopUp.Click();
        }

        [Then(@"Successful message '(.*)' should appear on screen")]
        public void ThenSuccessfulMessageShouldAppearOnScreen(string message)
        {
            Assert.IsTrue(userPage.LblconfirmationMessage.Text.Contains(message), "Verifying 'Your Memorable Question has been updated' message");
        }

        [When(@"clicked on OK button")]
        public void WhenClickedOnOKButton()
        {
            userPage.BtnOk.Click();
        }

        [When(@"In User Manager application click on Current User tab")]
        public void WhenInUserManagerApplicationClickOnCurrentUserTab()
        {
            Waits.Wait(driver, 1000);
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            userPage.LnkCurrentUser.Click();
        }

        [Then(@"User details displayed with details '(.*)', '(.*)', '(.*)'")]
        public void ThenUserDetailsDisplayedWithDetails(string userName, string lastName, string email)
        {
            Waits.WaitForElementVisible(driver, userPage.LblUserNameCurrentUserTab);
            Assert.IsTrue(userPage.LblUserNameCurrentUserTab.Text.Contains(userName), "Verified User name details on current user page");
            Assert.IsTrue(userPage.TxtLastNameCurrentUserTab.GetAttribute("value").Contains(lastName), "Verified Last name details on current user page");
            Assert.IsTrue(userPage.TxtEmailIdCurrentUserTab.GetAttribute("value").Contains(email), "Verified email details on current user page ");
        }


        [When(@"clicked Forgot Password")]
        public void WhenClickedForgotPassword()
        {
            Waits.WaitForElementVisible(driver, loginPage.LinkForgotPassword);
            loginPage.LinkForgotPassword.Click();
        }

        [Then(@"Forgotten password dialog opened displaying memorable Question: '(.*)'")]
        public void ThenForgottenPasswordDialogOpenedDisplayingMemorableQuestion(string question)
        {
            Waits.WaitForElementVisible(driver, loginPage.LblMemorableQuestion);
            loginPage.LblMemorableQuestion.Text.Contains(question);
        }

        [When(@"Supply memorable answer: '(.*)' and click the apply button")]
        public void WhenSupplyMemorableAnswerAndClickTheApplyButton(string answer)
        {
            Waits.WaitForElementVisible(driver, loginPage.TxtMemorableAnswer);
            loginPage.TxtMemorableAnswer.SendKeys(answer);
            loginPage.BtnApply.Click();
        }

        [Then(@"Password Reset dialog '(.*)' opened displaying message Password has been reset Please change this as soon as possible")]
        public void ThenPasswordResetDialogOpenedDisplayingMessagePasswordHasBeenResetPleaseChangeThisAsSoonAsPossible(string title)
        {
            Waits.WaitForElementVisible(driver, loginPage.LblConfirmationTitle);
            Assert.IsTrue(loginPage.LblConfirmationTitle.Text.Contains(title), "Verified Reset Password Title");
            Assert.IsTrue(loginPage.LblConfirmationMessage.Text.Contains(GlobalConstants.PasswordReset), "Verified password confirmation message");
        }

        [When(@"Login with updated password '(.*)' and '(.*)'")]
        public void WhenLoginWithUpdatedPasswordAnd(string userName, string pwd)
        {
            loginPage.SignIn(userName, pwd);
        }

        [Then(@"Logon successful")]
        public void ThenLogonSuccessful()
        {
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, homePage.LnkConfigure);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, homePage.LnkConfigure), "Verifying User should be navigated to Home page");
        }

        [When(@"I click Set Memorable Information Link")]
        public void WhenIClickSetMemorableInformationLink()
        {
            Waits.WaitForElementVisible(driver, userPage.LnkSetMemorableInformation);
            userPage.LnkSetMemorableInformation.Click();
        }

        [When(@"I click Change Password Link")]
        public void WhenIClickChangePasswordLink()
        {
            Waits.WaitForElementVisible(driver, userPage.LnkChangePassword);
            userPage.LnkChangePassword.Click();
        }

        [Then(@"'(.*)' window should open")]
        public void ThenWindowShouldOpen(string lblName)
        {
            Waits.WaitForElementVisible(driver, userPage.LblChangePassword);
            Assert.IsTrue(userPage.LblChangePassword.Text.Contains(lblName), "Verified Changed Password label on pop -up");
        }

        [When(@"entered current password '(.*)', new password '(.*)', confirm new password '(.*)' fields and clicked Apply button")]
        public void WhenEnteredCurrentPasswordNewPasswordConfirmNewPasswordFieldsAndClickedApplyButton(string currentPwd, string newPwd, string confirmPwd)
        {
            userPage.TxtCurrentPassword.SendKeys(currentPwd);
            userPage.TxtNewPassword.SendKeys(newPwd);
            userPage.TxtConfirmNewPassword.SendKeys(confirmPwd);
            userPage.BtnApplyOnChangePwdPopUp.Click();
        }


        [Then(@"New password applied")]
        public void ThenNewPasswordApplied()
        {
            Assert.IsTrue(userPage.LblconfirmationMessage.Text.Contains(GlobalConstants.PasswordChanged), "Verfied your Password was changed successfully");
        }

        [When(@"Login with old password '(.*)' and '(.*)'")]
        public void WhenLoginWithOldPasswordAnd(string userName, string password)
        {
            loginPage.SignIn(userName, password);
        }

        [Then(@"error message should display on login page")]
        public void ThenErrorMessageShouldDisplayOnLoginPage_()
        {
            loginPage.DisplayedInvalidCredentialsErrorMessage();
            Assert.AreEqual(loginPage.DisplayedInvalidCredentialsErrorMessage(), GlobalConstants.InvalidLogin);
        }


        [When(@"Added user in group with details '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' and '(.*)' and group details '(.*)' and '(.*)'")]
        public void WhenAddedUserInGroupWithDetailsAndAndGroupDetailsAnd(string userName, string pwd, string confirmPwd, string question, string ans, string firstName, string lastName, string email, string groupName, string groupDescripton)
        {
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            userPage.LnkMaintainUser.Click();
            userPage.CreateNewUser(userName, pwd, confirmPwd, question, ans, firstName, lastName, email);
            userPage.ClickOnApplyChanges();
            userPage.LnkMaintainGroup.Click();
            userPage.CreateNewGroup(groupName, groupDescripton);
            userPage.AddUserInGroup(firstName, lastName, userName);
        }


        [When(@"created new group with group name '(.*)' and Description '(.*)'")]
        public void WhenCreatedNewGroupWithGroupNameAndDescription(string groupName, string groupDescripton)
        {
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            Waits.WaitAndClick(driver, userPage.LnkMaintainGroup);
            userPage.CreateNewGroup(groupName, groupDescripton);
            Waits.Wait(driver, 1000);
        }
        [When(@"Clicked on newly created Group link on left hand side on the Maintain Groups tab , Select group detail tab is displayed and added created user '(.*)' '(.*)' '(.*)'")]
        public void WhenClickedOnNewlyCreatedGroupLinkOnLeftHandSideOnTheMaintainGroupsTabSelectGroupDetailTabIsDisplayedAndAddedCreatedUser(string firstName, string lastName, string userName)
        {
            Waits.Wait(driver, 5000);
            userPage.AddUserInGroup(firstName, lastName, userName);
        }

        [Then(@"'(.*)' text appears on Users tab\.Changes should be saved while navigating to other groups\.")]
        public void ThenTextAppearsOnUsersTab_ChangesShouldBeSavedWhileNavigatingToOtherGroups_(string confirmationMsg)
        {
            Waits.WaitForElementVisible(driver, userPage.LblconfimationMessage);
            Assert.IsTrue(userPage.LblconfimationMessage.Text.Contains(confirmationMsg), "Verified confirmation message 'Changed have been applied'");
        }

        [When(@"Selected created group '(.*)'")]
        public void WhenSelectedCreatedGroup(string groupName)
        {
            driver.Navigate().Refresh();
            userPage.SelectCreatedGroup(groupName);
        }

        [Then(@"Group details should displayed  group name '(.*)' and Description '(.*)'")]
        public void ThenGroupDetailsShouldDisplayedGroupNameAndDescription(string grpName, string groupDiscription)
        {
            Waits.WaitForElementVisible(driver, userPage.TxtGroupName);
            Waits.Wait(driver, 5000);
            Assert.IsTrue(userPage.TxtGroupName.GetAttribute("value").ToLower().Contains(grpName.ToLower()), "Verified group name");
            Assert.IsTrue(userPage.TxtGroupDescription.GetAttribute("value").ToLower().Contains(groupDiscription.ToLower()), "Verfied group discripsion");
        }

        [When(@"updated Group Name to '(.*)', Group Description to '(.*)' and clicked Apply button")]
        public void WhenUpdatedGroupNameToGroupDescriptionToAndClickedApplyButton(string grpName, string description)
        {
            Waits.WaitForElementVisible(driver, userPage.TxtGroupName);
            userPage.TxtGroupName.Clear();
            Waits.Wait(driver, 500);
            userPage.TxtGroupName.SendKeys(grpName);
            Waits.WaitForElementVisible(driver, userPage.TxtGroupDescription);
            userPage.TxtGroupDescription.Clear();
            Waits.Wait(driver, 500);
            userPage.TxtGroupDescription.SendKeys(description);
            Waits.WaitAndClick(driver, userPage.BtnApplyChange);
        }

        [Then(@"'(.*)' text will be displayed on the detail tab\.")]
        public void ThenTextWillBeDisplayedOnTheDetailTab_(string confirmationMsg)
        {
            Waits.WaitForElementVisible(driver, userPage.LblconfimationMessage);
            Assert.IsTrue(userPage.LblconfimationMessage.Text.Contains(confirmationMsg), "Verified confirmation message 'Changed have been applied'");
        }

        [When(@"Clicked the user link on left hand side created '(.*)', '(.*)', '(.*)'")]
        public void WhenClickedTheUserLinkOnLeftHandSideCreated(string userName, string firstName, string lastName)
        {
            driver.Navigate().Refresh();
            Waits.Wait(driver, 3000);
            userPage.SelectCreatedUser(userName, firstName, lastName);
            Waits.Wait(driver, 5000);
        }

        [Then(@"Users details tab displayed with details '(.*)' '(.*)' and '(.*)'")]
        public void ThenUsersDetailsTabDisplayedWithDetailsAnd(string firstName, string lastName, string email)
        {
            Waits.Wait(driver, 8000);
            Assert.IsTrue(userPage.TxtFirstName.GetAttribute("value").ToLower().Contains(firstName.ToLower()), "Verified firstName name");
            Assert.IsTrue(userPage.TxtLastName.GetAttribute("value").ToLower().Contains(lastName.ToLower()), "Verfied lastName");
            Assert.IsTrue(userPage.TxtEmail.GetAttribute("value").ToLower().Contains(email.ToLower()), "email");
        }

        [When(@"altered field First Name '(.*)', '(.*)','(.*)' and clicked Apply button")]
        public void WhenAlteredFieldFirstNameAndClickedApplyButton(string firstName, string lastName, string email)
        {
            userPage.TxtFirstName.Clear();
            userPage.TxtFirstName.SendKeys(firstName);
            userPage.TxtLastName.Clear();
            userPage.TxtLastName.SendKeys(lastName);
            userPage.TxtEmail.Clear();
            userPage.TxtEmail.SendKeys(email);
            Waits.Wait(driver, 3000);
            Waits.WaitAndClick(driver, userPage.BtnApplyChange);
            Waits.WaitForElementVisible(driver, userPage.LblconfimationMessage);
        }

        [When(@"clicked Delete button")]
        public void WhenClickedDeleteButton()
        {
            Waits.ImplicitWait(driver, 60);
            userPage.BtnDeleteGroup.Click();
        }

        [Then(@"'(.*)' pop-up is displayed")]
        public void ThenPop_UpIsDisplayed(string confirmationMsg)
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, userPage.LblDeleteConfirmationMsg);
            Assert.IsTrue(userPage.LblDeleteConfirmationMsg.Displayed, "Verified 'Are you sure you wish to delete the Group ?' message");
        }

        [When(@"Press the Cancel button on the popup")]
        public void WhenPressTheCancelButtonOnThePopup()
        {
            userPage.BtnCancel.Click();
        }

        [Then(@"The pop-up should disappear leaving the group intact '(.*)'")]
        public void ThenThePop_UpShouldDisappearLeavingTheGroupIntact(string grpName)
        {
            Assert.IsTrue(userPage.IsGroupExist(grpName), "Verified group exists");
        }

        [When(@"answer Ok to the popup box")]
        public void WhenAnswerOkToThePopupBox()
        {
            userPage.BtnOk.Click();
        }

        [Then(@"The group disappears from the links on the left and an empty Create Group form is displayed '(.*)'\.")]
        public void ThenTheGroupDisappearsFromTheLinksOnTheLeftAndAnEmptyCreateGroupFormIsDisplayed_(string grpName)
        {
            Assert.IsFalse(userPage.IsGroupExist(grpName), "Verified group doesn't exist");
        }

        [When(@"Selected created user '(.*)' '(.*)' '(.*)'")]
        public void WhenSelectedCreatedUser(string userName, string firstName, string lastName)
        {
            driver.Navigate().Refresh();
            userPage.SelectCreatedUser(userName, firstName, lastName);
        }

        [When(@"Clicked Delete")]
        public void WhenClickedDelete()
        {
            userPage.ClickOnDeleteUser();
        }

        [Then(@"'(.*)' pop-up message displayed")]
        public void ThenPop_UpMessageDisplayed(string msg)
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, userPage.LblDeleteConfirmationMsg);
            Assert.IsTrue(userPage.LblDeleteConfirmationMsg.Text.Contains(msg), "Verified 'Are you sure you wish to delete the Group ?' message");
        }

        [When(@"Clicked Check that the ‘Cancel’ button on the same popup cancels the delete request")]
        public void WhenClickedCheckThatTheCancelButtonOnTheSamePopupCancelsTheDeleteRequest()
        {
            userPage.BtnCancel.Click();
        }


        [Then(@"The request is cancelled and the existing details remain displayed '(.*)' '(.*)' '(.*)'")]
        public void ThenTheRequestIsCancelledAndTheExistingDetailsRemainDisplayed(string firstName, string lastName, string userName)
        {
            Assert.IsTrue(userPage.IsUserExist(firstName, lastName, userName), "Verified user exists on clicking cancel button");
        }

        [Then(@"User details form cleared and blank form displayed '(.*)' '(.*)' '(.*)'")]
        public void ThenUserDetailsFormClearedAndBlankFormDisplayed(string userName, string firstName, string lastName)
        {
            Assert.IsTrue(!userPage.IsUserExist(userName, firstName, lastName), "Verified user exists on clicking cancel button");
        }

        [Then(@"User details displayed with details '(.*)', '(.*)', '(.*)' on maintain user tab")]
        public void ThenUserDetailsDisplayedWithDetailsOnMaintainUserTab(string userName, string lastName, string email)
        {
            Waits.Wait(driver, 6000);
            Waits.WaitForElementVisible(driver, userPage.LblUserNameMaintainUserTab);
            Assert.IsTrue(userPage.LblUserNameMaintainUserTab.Text.Contains(userName), "Verified User name details on Maintain user page");
            Assert.IsTrue(userPage.TxtLastNameMaintainUserTab.GetAttribute("value").Contains(lastName), "Verified Last name details on Maintain user page");
            Assert.IsTrue(userPage.TxtEmailMaintainUserTab.GetAttribute("value").Contains(email), "Verified email details on Maintain user page ");
        }

        [When(@"Clicked on the Maintain Groups tab")]
        public void WhenClickedOnTheMaintainGroupsTab()
        {
            Waits.WaitAndClick(driver, userPage.LnkMaintainGroup);
        }

        [Then(@"The Create Group form should show")]
        public void ThenTheCreateGroupFormShouldShow()
        {
            bool res = Waits.WaitForElementVisible(driver, userPage.TxtGroupName);
            Assert.IsTrue(res, "Verifieid Group name textbox on Create Group page");
        }

        [Then(@"New group created with group name '(.*)'")]
        public void ThenNewGroupCreatedWithGroupName(string grpName)
        {
            userPage.DeleteGroupIfExist(grpName);
            Waits.WaitTillElementIsClickable(driver, userPage.TxtGroupName);
            userPage.CreateNewGroup(grpName, "Testing Group");

        }

        [When(@"Clicked '(.*)' tab selected for '(.*)' application and kept '(.*)' checkbox and clicked Apply")]
        public void WhenClickTabSelectedForApplicationAndKeptCheckboxAndClickedApply(string permission, string feature, string column)
        {
            Waits.WaitAndClick(driver, userPage.LnkPermission);
            userPage.SelectPermissionCheckBoxes(permission, feature, column);
            Waits.Wait(driver, 5000);
            Waits.WaitAndClick(driver, userPage.BtnApplyChange);
            Waits.WaitForElementVisible(driver, userPage.LblconfimationMessage);
        }

        [When(@"added newly created user '(.*)' '(.*)' '(.*)' in group")]
        public void WhenAddedNewlyCreatedUserInGroup(string firstName, string lastName, string userName)
        {
            userPage.AddUserInGroup(firstName, lastName, userName);
        }

        [Then(@"Only Dispatch Manager application should be available to select\.User should only able to view the diffferent forms")]
        public void ThenOnlyDispatchManagerApplicationShouldBeAvailableToSelect_UserShouldOnlyAbleToViewTheDiffferentForms()
        {
            homePage.ClickOnConfiguration();
            ElementExtensions.MouseHover(driver, homePage.LnkDispacthManager);
            Assert.IsTrue(homePage.LnkDispacthManager.Displayed, "Verified Dispatch Manager application is not visible to user");
        }

        [When(@"clicked dispatch manager link")]
        public void WhenClickedDispatchManagerLink()
        {
            homePage.LnkDispacthManager.Click();
            Waits.Wait(driver, 3000);
        }

        [Then(@"I should be able to view but shouldn't be allow to edit")]
        public void ThenIShouldBeAbleToViewButShouldnTBeAllowToEdit()
        {
            Assert.IsTrue(!dispatchManagerPage.TxtSiteName.Enabled, "Verified Site Name text box is not disabled");
            Assert.IsTrue(!dispatchManagerPage.TxtAreaMsgBodyPrefix.Enabled, "Verified Message Body Prefix is not disabled");
        }

        [Then(@"Only Dispatch Manager application should be available to select and User should able to edit different forms in Dispatch Manager")]
        public void ThenOnlyDispatchManagerApplicationShouldBeAvailableToSelectAndUserShouldAbleToEditDifferentFormsInDispatchManager()
        {
            homePage.ClickOnConfiguration();
            ElementExtensions.MouseHover(driver, homePage.LnkDispacthManager);
            Assert.IsTrue(homePage.LnkDispacthManager.Displayed, "Verified Dispatch Manager application is not visible to user");
            homePage.LnkDispacthManager.Click();
            Waits.Wait(driver, 4000);
            Assert.IsTrue(dispatchManagerPage.TxtSiteName.Enabled, "Verified Site Name text box is not enabled");
            Assert.IsTrue(dispatchManagerPage.TxtAreaMsgBodyPrefix.Enabled, "Verified Message Body Prefix is not enabled");
            dispatchManagerPage.TxtSiteName.SendKeys(ElementExtensions.GetRandomString(6));
            dispatchManagerPage.TxtAreaMsgBodyPrefix.SendKeys(ElementExtensions.GetRandomString(6));
        }

        [When(@"Opened the User Manager application, and click on the ‘Maintain Groups’ tab")]
        public void WhenOpenedTheUserManagerApplicationAndClickOnTheMaintainGroupsTab()
        {
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            userPage.LnkMaintainGroup.Click();
        }

        [When(@"Open the User Manager application, and click on the ‘Maintain Groups’ tab\.Click on ""(.*)"" link")]
        public void WhenOpenTheUserManagerApplicationAndClickOnTheMaintainGroupsTab_ClickOnLink(string p0)
        {
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            userPage.LnkMaintainGroup.Click();
            userPage.LinkCreateGroup.Click();
            Waits.Wait(driver, 1000);
        }

        [Then(@"Required Field text should appear besides GroupName")]
        public void ThenRequiredFieldTextShouldAppearBesidesGroupName()
        {
            Assert.IsTrue(userPage.MsgGroupNameRequiredField.Text.Contains(GlobalConstants.RequiredFieldValidationMessage),
                 "Verified 'Required Field' validation message for Group name not displayed");
        }

        [Then(@"newly created group '(.*)' should be shown in left side group list")]
        public void ThenNewlyCreatedGroupShouldBeShownInLeftSideGroupList(string grpName)
        {
            Waits.Wait(driver, 5000);
            userPage.IsGroupExist(grpName);
        }

        [When(@"Clicked Alerts and set Auto Alerts as Yes")]
        public void WhenClickedAlertsAndSetAutoAlertsAsYes()
        {
            userPage.LnkAlerts.Click();
            Waits.WaitUntillImageIsSelected(driver, userPage.RadioBtnAutoAlerts);
            userPage.BtnApplyChange.Click();
        }

        [When(@"Clicked users tab")]
        public void WhenClickedUsersTab()
        {
            Waits.Wait(driver, 1000);
            userPage.LnkGroup.Click();
        }

        [Then(@"selected group should be displayed '(.*)'")]
        public void ThenSelectedGroupShouldBeDisplayed(string grpName)
        {
            userPage.isGroupAddded(grpName);
        }

        [When(@"clicked on permission")]
        public void WhenClickedOnPermission()
        {
            Waits.Wait(driver, 1000);
            userPage.LnkPermission.Click();
        }

        [Then(@"In '(.*)' table '(.*)' feature, '(.*)' checkbox should be selected")]
        public void ThenInTableFeatureCheckboxShouldBeSelected(string table, string feature, string column)
        {
            Waits.Wait(driver, 2000);
            userPage.IsPermissionCheckBoxesSelected(table, feature, column);
        }

        [When(@"clicked on Alerts")]
        public void WhenClickedOnAlerts()
        {
            Waits.WaitAndClick(driver, userPage.LnkAlerts);
        }

        [Then(@"Auto Alerts should be selected in user permission")]
        public void ThenAutoAlertsShouldBeSelectedInUserPermission()
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(userPage.RadioBtnAutoAlerts.GetAttribute("src").Contains("on"), "Auto Alert radio button is not selected");
        }

        [Then(@"Only '(.*)' link should be visible under configure dropdown list")]
        public void ThenOnlyLinkShouldBeVisibleUnderConfigureDropdownList(string link)
        {
            homePage.ClickOnConfiguration();
            ElementExtensions.MouseHover(driver, homePage.LnkConfiguarationHandler);
            Assert.IsTrue(homePage.LnkConfiguarationHandler.Displayed, "Configuaration Handler link is not visible");
            Assert.IsTrue(!ElementExtensions.isDisplayed(driver, homePage.LnkLogging), "Logging link is visible");
        }

        [When(@"clicked Configuration Handler link")]
        public void WhenClickedConfigurationHandlerLink()
        {
            homePage.ClickOnConfiguration();
            ElementExtensions.MouseHover(driver, homePage.LnkConfiguarationHandler);
            homePage.LnkConfiguarationHandler.Click();
        }

        [Then(@"I should be able to view Configuration Handler page but shouldn't be allow to edit")]
        public void ThenIShouldBeAbleToViewConfigurationHandlerPageButShouldnTBeAllowToEdit()
        {
            Waits.Wait(driver, 1000);
            Assert.IsTrue(driver.Url.Contains("Configuration.aspx"), "User is not navigated to Configuaration page");
            Assert.IsTrue(configuarationHandlerPage.LblEquipmentTypesAndConfiguarations.Displayed, "Equipment Types & Configurations is not displayed");
        }

        [When(@"Unchecked all selected permissions")]
        public void WhenUncheckedAllSelectedPermissions()
        {
            Waits.Wait(driver, 3000);
            userPage.LnkPermission.Click();
            Waits.Wait(driver, 6000);
            userPage.SelectAllCheckBox.Click();
            Waits.Wait(driver, 6000);
            userPage.SelectAllCheckBox.Click();
            Waits.Wait(driver, 10000);
        }

        [When(@"Raised alert High Alarm on Booster Power, Low alarm on MB Motor Temperature, High Warning on Dry Pump Control,low warning on  Booster Control, Advisory on Seals Purge\.")]
        public void GivenRaisedAlertHighAlarmOnBoosterPowerLowAlarmOnMBMotorTemperatureHighWarningOnDryPumpControlLowWarningOnBoosterControlAdvisoryOnSealsPurge_()
        {
            Waits.Wait(driver, 3000);
            simulator.LaunchSimulator();
            simulator.RaiseAllTypeOfAlerts();
            simulator.MinimizeWindow();
        }
        

        [When(@"Commissioned EZenith device with details  '(.*)', '(.*)'")]
        public void GivenCommissionedEZenithDeviceWithDetails(string equipmentType, string iPPortNumber)
        {
            deviceExplorerNavigationPage.DeleteAllEquipments(driver);
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkNavigate);
            var tabs = driver.WindowHandles;
            if (tabs.Count > 1)
            {
                int totalCount = tabs.Count;
                driver.SwitchTo().Window(tabs[totalCount - 1]);
            }
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            Waits.Wait(driver, 2000);
            string equipmentName = ElementExtensions.GetRandomAlphabeticalString(6);
            string iPAdress = SpecflowHooks.HostIpAddress();
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            Waits.Wait(driver, 3000);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 2000);
        }

        [Then(@"Only '(.*)' should be available to select")]
        public void ThenOnlyShouldBeAvailableToSelect(string link)
        {
            bool res = false;
            if (link.ToLower().Equals("historian"))
            {
                res = Waits.WaitForElementVisible(driver, homePage.LnkHistorian);
                Assert.IsTrue(res, "Historian link is not visible on home page");
            }
            else if (link.ToLower().Equals("device explorer"))
            {
                res = Waits.WaitForElementVisible(driver, homePage.LnkDeviceManager);
                Assert.IsTrue(res, "Device manager link is not visible on home page");
            }
            else if (link.ToLower().Equals("reports"))
            {
                res = Waits.WaitForElementVisible(driver, homePage.LnkReports);
                Assert.IsTrue(res, "Reports link is not visible on home page");
            }
            else if (link.ToLower().Equals("live alerts list"))
            {
                res = Waits.WaitForElementVisible(driver, homePage.LnkLiveAlerts);
                Assert.IsTrue(res, "Live Alerts link is not visible on home page");
            }
        }

        [When(@"clicked '(.*)' link on home page")]
        public void WhenClickedLinkOnHomePage(string link)
        {
            if (link.ToLower().Equals("historian"))
            {
                Waits.WaitAndClick(driver, homePage.LnkHistorian);
            }
            else if (link.ToLower().Equals("device explorer"))
            {
                Waits.WaitAndClick(driver, homePage.LnkDeviceManager);
            }
            else if (link.ToLower().Equals("reports"))
            {
                Waits.WaitAndClick(driver, homePage.LnkReports);
            }
            else if (link.ToLower().Equals("live alerts list"))
            {
                Waits.WaitAndClick(driver, homePage.LnkLiveAlerts);
            }
        }

        [Then(@"I should be able to view '(.*)' page but shouldn't be allow to edit")]
        public void ThenIShouldBeAbleToViewPageButShouldnTBeAllowToEdit(string page)
        {
            if (page.ToLower().Contains("configuaration"))
            {
                Waits.Wait(driver, 1000);
                Assert.IsTrue(driver.Url.Contains("Configuration.aspx"), "User is not navigated to Configuaration page");
                Assert.IsTrue(configuarationHandlerPage.LblEquipmentTypesAndConfiguarations.Displayed, "Equipment Types & Configurations is not displayed");
            }
            if (page.ToLower().Contains("historian"))
            {
                driver.Url.Contains("Historian");
                Assert.IsTrue(historianPage.LblParameterData.Displayed, "Parameter data is not displayed on Historian page");
            }
            else if (page.ToLower().Contains("device explorer"))
            {
                driver.Url.Contains("Explorer");
                Assert.IsTrue(deviceExplorerNavigationPage.LinktTopLevel.Displayed, "Add folder link is not displayed on Device Explorer page");
                Assert.IsTrue(!ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LnkAddFolder),
                    "Add folder link is displayed on Device Explorer page even though user has View permission only");
            }
            else if (page.ToLower().Contains("reports"))
            {
                driver.Url.Contains("ReportDashboard");
                Assert.IsTrue(reportPage.LnkActivateReport.Displayed, "Alert report is not displayed on Report page");
            }
            else if (page.ToLower().Contains("live alerts list"))
            {
                driver.Url.Contains("LiveAlertsList");
                Assert.IsTrue(liveAlertsListPage.LblActive.Displayed, "Active lable is not displayed on Live Alert List page");
            }
        }

        [Then(@"Alerts tab details displayed")]
        public void ThenAlertsTabDetailsDisplayed()
        {
            bool res = Waits.WaitForElementVisible(driver, userPage.RadioBtnAutoAlerts);
            Assert.IsTrue(res, "Auto Alert Radio button is not displayed");
        }

        [When(@"Click on the ‘Advisory’ checkbox")]
        public void WhenClickOnTheAdvisoryCheckbox()
        {
            Waits.WaitForElementVisible(driver, userPage.ChkBoxAdvisory);
            if (userPage.ChkBoxAdvisory.GetAttribute("src").Contains("off"))
            {
                Waits.WaitAndClick(driver, userPage.ChkBoxAdvisory);
            }
            else if (userPage.ChkBoxAdvisory.GetAttribute("src").Contains("on"))
            {
                Waits.WaitAndClick(driver, userPage.RadioButtonViewAlerts_No);
                Waits.WaitAndClick(driver, userPage.ChkBoxAdvisory);
                Waits.Wait(driver, 2000);
            }
        }

        [Then(@"The Advisory checkbox and all checkboxes below should be checked")]
        public void ThenTheAdvisoryCheckboxAndAllCheckboxesBelowShouldBeChecked()
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(userPage.ChkBoxMajorAlarm.GetAttribute("src").Contains("on"), "Check Box Major Alarm is not selected");
            Assert.IsTrue(userPage.ChkBoxMinorAlarm.GetAttribute("src").Contains("on"), "Check Box Minor Alarm is not selected");
            Assert.IsTrue(userPage.ChkBoxMajorWarning.GetAttribute("src").Contains("on"), "Check Box Major warning is not selected");
            Assert.IsTrue(userPage.ChkBoxMinorWarning.GetAttribute("src").Contains("on"), "Check Box Minor warning is not selected");
        }

        [Then(@"Events of all selected severities for the user should be displayed\.")]
        public void ThenEventsOfAllSelectedSeveritiesForTheUserShouldBeDisplayed_()
        {
            //    Waits.Wait(driver, 30000);
            //    liveAlertsListPage.WaitTillLoadingIndicatorDisplayed(liveAlertsListPage.ImgLoadingIndicator);
            Assert.IsTrue(liveAlertsListPage.IsAllAlertsRaisedForUserNotHavingHistorianPermission("Seals Purge (13)", "Booster Power (8)", "MB MotorTemperature (9)", "Dry Pump Control (11)", "Booster Control (12)", "NEW0001PM1"));
        }

        [Then(@"The alerts shown in Live Alerts List '(.*)', '(.*)', '(.*)', '(.*)' for device '(.*)' should be restricted accroding to the Alert Viewing Level set for the test\.")]
        public void ThenTheAlertsShownInLiveAlertsListForDeviceShouldBeRestrictedAccrodingToTheAlertViewingLevelSetForTheTest_
            (string majorAlarmParameter, string minorAlarmParameter, string majorWarningParameter, string minorWarningParameter, string equipmentName)
        {

            Waits.Wait(driver, 30000);
            Assert.IsTrue(liveAlertsListPage.IsAllAlertsExceptAdvisoryRaised(majorAlarmParameter, minorAlarmParameter, majorWarningParameter, minorWarningParameter, equipmentName));
        }

        [When(@"clicked Apply")]
        public void WhenClickedApply()
        {
            if (userPage == null)
                userPage = new UserPage(driver);
            Waits.WaitAndClick(driver, userPage.BtnApplyChange);
            Waits.WaitForElementVisible(driver, userPage.LblconfimationMessage);
        }

        [When(@"clicked on home link")]
        public void WhenClickedOnHomeLink()
        {
            Waits.WaitAndClick(driver, userPage.LinkHomePage);
        }

        [Then(@"should be navigated to Home page")]
        public void ThenShouldBeNavigatedToHomePage()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(driver.Url.Contains("EdwardsScada"), "Not navigated to home page");
        }

        [When(@"clicked Device Explorer link")]
        public void WhenClickedDeviceExplorerLink()
        {
            homePage.ClickOnDeviceExplorer();
        }

        [Then(@"should be navigated to Device Explorer page")]
        public void ThenShouldBeNavigatedToDeviceExplorerPage()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(driver.Url.Contains("Components/Explorer/Navigate.aspx"), "Not navigated to home page");
        }

        [When(@"clicked on add folder/ system icon")]
        public void WhenClickedOnAddFolderSystemIcon()
        {
            deviceExplorerNavigationPage.ClickOnPlusToAddFolder();
        }

        [When(@"Entered folder name and Clicked on Add button")]
        public void WhenEnteredFolderNameAndClickedOnAddButton()
        {
            Waits.Wait(driver, 1000);
            deviceExplorerNavigationPage.EnterFolderName(testFolderName);
            Waits.Wait(driver, 1000);
        }

        [Then(@"should be able to see Folder Added Successfully message")]
        public void ThenShouldBeAbleToSeeFolderAddedSuccessfullyMessage()
        {
            Waits.Wait(driver, 5000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains("Folder Added Successfully"), "Verifying 'Folder Added Successfully' message");
        }

        [When(@"clicked OK button")]
        public void WhenClickedOKButton()
        {
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [Then(@"should be able to see newly added folder")]
        public void ThenShouldBeAbleToSeeNewlyAddedFolder()
        {
            Assert.IsTrue(driver.PageSource.Contains(testFolderName), "Verifying added folder");
        }

        [When(@"clicked Find Equipment")]
        public void WhenClickedFindEquipment()
        {
            Waits.Wait(driver, 7000);
            deviceExplorerNavigationPage.ClickFindEquipment(testFolderName);
        }

        [When(@"entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button")]
        public void WhenEnteredEquipmentNameSelectedEquipmentTypeClikedFindEquipmentButtonSelectedOneEquipmentAndClickedAddButton()
        {
            Waits.Wait(driver, 8000);
            deviceExplorerNavigationPage.AddEquipmentToSystem();
        }

        [Then(@"should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed")]
        public void ThenShouldBeAbleToSeeEquipmentAddedSuccessfullyMessageAndAfterClickingOkButtonAddedEquipmentShouldBeDisplayed()
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.EquipmentAddedMsg), "Verifying 'Equipment Added Successfully' message");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [When(@"I clicked the header of the folder and choose Share Folder")]
        public void WhenIClickedTheHeaderOfTheFolderAndChooseShareFolder()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinktTopLevel);
        }

        [Then(@"Share Folder Foldername pop-up should be displayed with available and granted list")]
        public void ThenShareFolderFoldernamePop_UpShouldBeDisplayedWithAvailableAndGrantedList()
        {
            Waits.Wait(driver, 5000);
            deviceExplorerNavigationPage.ClickOnFolderHeader(testFolderName);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkShareFolder);
        }

        [Then(@"selected previously created Group '(.*)' '(.*)' and '(.*)' from available list and transfered it to granted list and pressed Apply")]
        public void ThenSelectedPreviouslyCreatedGroupAndFromAvailableListAndTransferedItToGrantedListAndPressedApply(string firstName, string lastName, string userName)
        {
            Waits.Wait(driver, 3000);
            deviceExplorerNavigationPage.selectUserToshareFolder(firstName, lastName, userName);
        }

        [Then(@"Changes should be saved")]
        public void ThenChangesShouldBeSaved()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.ChangesApplied), "Verified changes saved message");
        }

        [When(@"clicked on Home Icon in top navigation menubar")]
        public void WhenClickedOnHomeIconInTopNavigationMenubar()
        {
            Waits.Wait(driver, 4000);
            driver.Url.Contains("EdwardsScada/Default.aspx");
        }

        [Then(@"I selected previously created Group '(.*)' from available list and transfered it to granted list and pressed Apply")]
        public void ThenISelectedPreviouslyCreatedGroupFromAvailableListAndTransferedItToGrantedListAndPressedApply(string grpName)
        {
            Waits.Wait(driver, 3000);
            deviceExplorerNavigationPage.selectGroupToshareFolder(grpName);
        }

        [When(@"Click on the ‘Use Group’ radio button")]
        public void WhenClickOnTheUseGroupRadioButton()
        {
            string status = userPage.RadioButtonUseGroupViewAlerts.GetAttribute("src");
            if (status.Contains("off"))
            {
                Waits.WaitAndClick(driver, userPage.RadioButtonUseGroupViewAlerts);
            }
        }

        [Then(@"All checkboxes below should now be unchecked\.")]
        public void ThenAllCheckboxesBelowShouldNowBeUnchecked_()
        {
            Waits.Wait(driver, 5000);
            Assert.IsTrue(userPage.ChkBoxMajorAlarm.GetAttribute("src").Contains("off"), "Check Box Major Alarm is checked");
            Assert.IsTrue(userPage.ChkBoxMinorAlarm.GetAttribute("src").Contains("off"), "Check Box Minor Alarm is checked");
            Assert.IsTrue(userPage.ChkBoxMajorWarning.GetAttribute("src").Contains("off"), "Check Box Major warning is checked");
            Assert.IsTrue(userPage.ChkBoxMinorWarning.GetAttribute("src").Contains("off"), "Check Box Minor warning is checked");
        }

        [When(@"applied changes")]
        public void WhenAppliedChanges()
        {
            userPage.BtnApplyOnAlertTab.Click();
            Waits.Wait(driver, 5000);
        }

        [When(@"Click on the ‘Minor Warning’ checkbox")]
        public void WhenClickOnTheMinorWarningCheckbox()
        {
            Waits.Wait(driver, 5000);
            string status = userPage.RadioButtonViewAlerts_No.GetAttribute("src");
            if (status.Contains("off"))
            {
                userPage.RadioButtonViewAlerts_No.Click();
            }
            Waits.Wait(driver, 3000);
            userPage.ChkBoxMinorWarning.Click();
        }

        [Then(@"except Advisory checkbox and all checkboxes below should be checked")]
        public void ThenExceptAdvisoryCheckboxAndAllCheckboxesBelowShouldBeChecked()
        {
            Waits.Wait(driver, 5000);
            Assert.IsTrue(userPage.ChkBoxAdvisory.GetAttribute("src").Contains("off"), "Check Box Major Alarm is checked");
            Assert.IsTrue(userPage.ChkBoxMajorAlarm.GetAttribute("src").Contains("on"), "Check Box Major Alarm is not checked");
            Assert.IsTrue(userPage.ChkBoxMinorAlarm.GetAttribute("src").Contains("on"), "Check Box Minor Alarm is not checked");
            Assert.IsTrue(userPage.ChkBoxMajorWarning.GetAttribute("src").Contains("on"), "Check Box Major warning is not checked");
            Assert.IsTrue(userPage.ChkBoxMinorWarning.GetAttribute("src").Contains("on"), "Check Box Minor warning is not checked");

        }
    }
}
