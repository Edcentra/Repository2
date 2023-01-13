using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class DispatchManagertStepDefinition
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
        Simulator simulator = new Simulator();
        private IWebDriver driver;
        static string dateTime;

        public DispatchManagertStepDefinition(IWebDriver _driver)
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

        [Given(@"opened EDCENTRA url in browser")]
        public void GivenOpenedEDCENTRAUrlInBrowser()
        {
            PageInitialization();
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);
        }

        [When(@"entered Username as '(.*)' and Password  as'(.*)' and I clicked login button")]
        public void WhenEnteredUsernameAsAndPasswordAsAndIClickedLoginButton(string username, string password)
        {
            loginPage.SignIn(username, password);
            Waits.Wait(driver, 5000);
        }

        [Then(@"should be navigated to home page")]
        public void ThenShouldBeNavigatedToHomePage()
        {
            bool res=  Waits.WaitForElementVisible(driver, homePage.LblRealTimeMonitoring);
            Assert.IsTrue(res, "Verifying User should be navigated to Home page");
        }

        [When(@"I click Device Explorer link")]
        public void WhenIClickDeviceExplorerLink()
        {
            dispatchManagerPage.LnkHome.Click();
            Waits.WaitForElementVisible(driver, homePage.LnkDeviceExplorer);
            homePage.LnkDeviceExplorer.Click();
        }

        [Then(@"I should navigated to Device Explorer page")]
        public void ThenIShouldNavigatedToDeviceExplorerPage()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkAddFolder);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LnkAddFolder), "Verifying User should be navigated to Device Explorer page");
        }

        [When(@"I clicked on add folder/system icon")]
        public void WhenIClickedOnAddFolderSystemIcon()
        {
            deviceExplorerNavigationPage.ClickOnPlusToAddFolder();
        }

        [When(@"I entered folder name and Clicked on Add button")]
        public void WhenIEnteredFolderNameAndClickedOnAddButton()
        {
            deviceExplorerNavigationPage.EnterFolderName(testFolderName);
            Waits.Wait(driver, 2000);
        }

        [Then(@"I should be able to see Folder Added Successfully Message")]
        public void ThenIShouldBeAbleToSeeFolderAddedSuccessfullyMessage()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder), "Verifying 'Folder Added Successfully' message");
        }

        [When(@"I click OK button")]
        public void WhenIClickOKButton()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.BtnOk);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 3000);
        }

        [Then(@"I should able to see newly added folder")]
        public void ThenIShouldAbleToSeeNewlyAddedFolder()
        {
            Waits.Wait(driver, 8000);
            Assert.IsTrue(driver.PageSource.Contains(testFolderName), "Verifying added folder");
        }

        [When(@"I click Find Equipment")]
        public void WhenIClickFindEquipment()
        {
            Waits.Wait(driver, 2000);
            deviceExplorerNavigationPage.ClickFindEquipment(testFolderName);
        }

        [When(@"Deleted all equipments")]
        public void WhenDeletedAllEquipments()
        {
            deviceExplorerNavigationPage.DeleteAllEquipments(driver);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkNavigate);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            deviceExplorerNavigationPage.ClickOnGetEquipment();
            Waits.Wait(driver, 7000);
            if (!ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.MsgNoEquipmentFound))
            {
                deviceExplorerNavigationPage.DeleteAllEquipments(driver);
            }
            else
            {
                Waits.WaitAndClick(driver, deviceExplorerNavigationPage.BtnCancelAddEquipment);
            }
        }

        [When(@"Launch Turbo simulator")]
        public void WhenLaunchTurboSimulator()
        {
            simulator.LaunchTurboWindow();
            simulator.StartTurboCommunication();
            simulator.MinimizeWindow("TURBO");
        }

        [When(@"Select an equipmentName '(.*)', equipmentType '(.*)' and iPPortNumber'(.*)'")]
        public void WhenSelectAnEquipmentNameEquipmentTypeAndIPPortNumber(string equipmentName, string equipmentType, string iPPortNumber)
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkNavigate);
            deviceExplorerNavigationPage.LnkNavigate.Click();
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkAddDevice);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LnkCreateCommission);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.TxtBoxEquipmentName);
            string iPAdress = SpecflowHooks.HostIpAddress();
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 5000);
        }

        [Then(@"I should be able to see Equipment added successfully message and after clicking Ok button, added Equipment should be displayed")]
        public void ThenIShouldBeAbleToSeeEquipmentAddedSuccessfullyMessageAndAfterClickingOkButtonAddedEquipmentShouldBeDisplayed()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.EquipmentAddedMsg), "Verifying 'Equipment Added Successfully' message");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Waits.Wait(driver, 2000);
        }

        [When(@"selected dispatch manager option under Configure drop down")]
        public void WhenSelectedDispatchManagerOptionUnderConfigureDropDown()
        {
            try
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, homePage.LnkConfigure);
                //Waits.Wait(driver, 5000);
                ElementExtensions.MouseHover(driver, homePage.LnkConfigure);
                //homePage.LnkConfigure.Click();
                //homePage.ClickOnConfiguration();
                //Waits.Wait(driver, 2000);
                ElementExtensions.MouseHover(driver, homePage.LnkDispacthManager);
                homePage.LnkDispacthManager.Click();
                Waits.WaitForElementVisible(driver, dispatchManagerPage.TxtSiteName);
            }
            catch (TargetInvocationException)
            {
                WhenSelectedDispatchManagerOptionUnderConfigureDropDown();
            }
        }

        [When(@"Configure the options on the Dispatch Manager General Settings screen '(.*)'")]
        public void WhenConfigureTheOptionsOnTheDispatchManagerGeneralSettingsScreen(string siteName)
        {
            dispatchManagerPage.BtnServiceStatus.Click();
            dispatchManagerPage.TxtSiteName.Clear();
            dispatchManagerPage.TxtSiteName.SendKeys(siteName);
            Waits.Wait(driver, 5000);

            if (dispatchManagerPage.RdBtnSendBulkAlert.GetAttribute("src").Contains("off"))
            {
                JavaScriptExecutor.JavaScriptClick(driver, dispatchManagerPage.RdBtnSendBulkAlert);
                Waits.Wait(driver, 10000);
                dispatchManagerPage.RdBtnSendBulkAlert.GetAttribute("src").Contains("on");
            }
            else
            {
                JavaScriptExecutor.JavaScriptClick(driver, dispatchManagerPage.RdBtnSendIndividualAlert);
                Waits.Wait(driver, 10000);
                dispatchManagerPage.RdBtnSendIndividualAlert.GetAttribute("src").Contains("on");
            }
            Waits.Wait(driver, 5000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, dispatchManagerPage.ChkBoxIncludeAlertMsg);
            string isSelected = dispatchManagerPage.ChkBoxIncludeAlertMsg.GetAttribute("src");
            if (isSelected.Contains("_on_"))
            {
                JavaScriptExecutor.JavaScriptClick(driver, dispatchManagerPage.ChkBoxIncludeAlertMsg);
                Waits.Wait(driver, 5000);
                dispatchManagerPage.ChkBoxIncludeAlertMsg.GetAttribute("src").Contains("off");
            }
            else
            {
                JavaScriptExecutor.JavaScriptClick(driver, dispatchManagerPage.ChkBoxIncludeAlertMsg);
                Waits.Wait(driver, 5000);
                dispatchManagerPage.ChkBoxIncludeAlertMsg.GetAttribute("src").Contains("on");
            }

        }

        [When(@"Apply is used")]
        public void WhenApplyIsUsed()
        {
            dispatchManagerPage.ClickApply();
        }

        [Then(@"the settings should be saved")]
        public void ThenTheSettingsShouldBeSaved()
        {
            Waits.Wait(driver, 5000);
            Assert.IsTrue(dispatchManagerPage.LblSuccessMessage.Text.Contains("Changes have been applied"), "Changes haven't been saved");
        }

        [When(@"navigated to SMTP tab under Page Settings tab\.")]
        public void WhenNavigatedToSMTPTabUnderPageSettingsTab_()
        {
            Waits.WaitAndClick(driver, deviceExplorerNavigationPage.LinkHomePage);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, homePage.LnkConfigure);
            Waits.WaitAndClick(driver, homePage.LnkConfigure);
            Waits.WaitAndClick(driver, homePage.LnkDispacthManager);
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkPageDestinations);
            Waits.WaitForElementVisible(driver, dispatchManagerPage.TxtFrom);
        }


        [When(@"navigated to SMTP tab under Page Settings tab")]
        public void WhenNavigatedToSMTPTabinderPageSettingsTab()
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkConfigure);
            Waits.WaitAndClick(driver, homePage.LnkDispacthManager);
            if (dispatchManagerPage == null)
                dispatchManagerPage = new DispatchManagerPage(driver);
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkPageDestinations);
            Waits.WaitForElementVisible(driver, dispatchManagerPage.TxtFrom);
        }

        [When(@"Navigated to Page Destinations Tab")]
        public void WhenNavigatedToPageDestinationsTab()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkPageDestinations);
        }

        [When(@"login user '(.*)' created new SMTP page From as '(.*)' destination with SMTP IP of '(.*)', port number as '(.*)' and To address as '(.*)'")]
        public void WhenCreatedNewSMTPPageFromAsDestinationWithSMTPIPOfPortNumberAsAndToAddressAs(string userName, string from, string smtpServer, string smtpPort, string toAddress)
        {
            dispatchManagerPage.DeleteSMTPPageDestination_IfExists(userName);
            dispatchManagerPage.TxtFrom.Clear();
            dispatchManagerPage.TxtFrom.SendKeys(from);
            dispatchManagerPage.TxtSMTPServer.Clear();
            dispatchManagerPage.TxtSMTPServer.SendKeys(smtpServer);
            dispatchManagerPage.TxtSMTPPort.Clear();
            dispatchManagerPage.TxtSMTPPort.SendKeys(smtpPort);
            dispatchManagerPage.TxtToAddress.Clear();
            dispatchManagerPage.TxtToAddress.SendKeys(toAddress);
            Waits.WaitAndClick(driver, dispatchManagerPage.BtnCreate);
            Waits.WaitForElementVisible(driver, dispatchManagerPage.LblSuccessMessage);
            Assert.IsTrue(dispatchManagerPage.LblSuccessMessage.Text.Contains(GlobalConstants.PageDestinationCreated), "Page Destination Created message not appeared on clicking create button");
        }

        [When(@"Clicked Test button")]
        public void WhenClickedTestButton()
        {
            Waits.WaitForElementVisible(driver, dispatchManagerPage.BtnTest);
            Waits.WaitAndClick(driver, dispatchManagerPage.BtnTest);
            Waits.Wait(driver, 2000);
            dateTime = DateTime.Now.ToString("yyyy-MM-dd");
        }

        [Then(@"A message '(.*)' should be displayed\.")]
        public void ThenAMessageShouldBeDisplayed_(string message)
        {
            Waits.WaitForElementVisible(driver, dispatchManagerPage.LblSuccessMessage);
            Assert.IsTrue(dispatchManagerPage.LblSuccessMessage.Text.Contains(message), "Success message not appeared on clicking Test button");
            Waits.Wait(driver, 1000);
        }

        [Then(@"message '(.*)'dispayed in Autopager console with fields set to Subject as '(.*)' From as'(.*)' To as '(.*)', content as '(.*)'")]
        public void ThenMessageDispayedInAutopagerConsoleWithFieldsSetToSubjectAsFromAsToAsContentAs(string message, string subject, string from, string to, string content)
        {
            string autopagerText = simulator.GetAutopagerText();
            var text = autopagerText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.IsTrue(text[33].Contains(message), "Autopager console not showing log for message 'Dispatching message [Test message] via SMTP'");
            Assert.IsTrue(text[11].Contains(subject), "Autopager console not showing log for 'Subject: Test message'");
            Assert.IsTrue(text[12].Contains(from), "Autopager console not showing log for 'From: support@edwardsvacuum.com'");
            Assert.IsTrue(text[13].Contains(to), "Autopager console not showing log for 'To: shalu.gupta@edwardsvacuum.com'");
            //Assert.IsTrue(text[4].Contains(content), "Autopager console not showing log for 'Test message. Test message.'");
            Assert.IsTrue(text[33].Contains(dateTime), "Autopager console not showing log for datetime" + dateTime);
        }

        [When(@"navigated to General Settings page")]
        public void WhenNavigatedToGeneralSettingsPage()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkGeneralSettings);
            Assert.IsTrue(driver.Url.Contains("DispatchManager/General.aspx"), "not navigated to General settings oage on clicking link");
        }

        [Then(@"General settings page should display")]
        public void ThenGeneralSettingsPageShouldDisplay()
        {
            Waits.WaitForElementVisible(driver, dispatchManagerPage.BtnServiceStatus);
            Assert.IsTrue(dispatchManagerPage.BtnServiceStatus.Displayed, "Service Status button is not displayed");
            Assert.IsTrue(dispatchManagerPage.TxtSiteName.Displayed, "Site Name text box is not displayed");
        }

        [When(@"Clicked on manual page")]
        public void WhenClickedOnManualPage()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.BtnManualPage);
        }

        [Then(@"'(.*)' pop-up will appear")]
        public void ThenPop_UpWillAppear(string msg)
        {
            Waits.WaitForElementVisible(driver, dispatchManagerPage.PopUpSendMsg);
            ElementExtensions.MouseHover(driver, dispatchManagerPage.PopUpSendMsg);
            Assert.IsTrue(dispatchManagerPage.PopUpSendMsg.Text.Contains(msg), "Send A message pop -up not opened");
        }

        [When(@"Typed in Message '(.*)' and clicked Send button")]
        public void WhenTypedInMessageAndClickedSendButton(string msg)
        {
            Waits.Wait(driver, 2000);
            JavaScriptExecutor.JavaScriptClick(driver, dispatchManagerPage.TxtAreaMsg);
            dispatchManagerPage.TxtAreaMsg.SendKeys(msg);
            Waits.WaitAndClick(driver, dispatchManagerPage.BtnSend);
        }

        [Then(@"'(.*)' message should be displayed")]
        public void ThenMessageShouldBeDisplayed(string msg)
        {
            Waits.WaitForElementVisible(driver, dispatchManagerPage.LblSuccessMsgManualPage);
            Assert.IsTrue(dispatchManagerPage.LblSuccessMsgManualPage.Text.Contains(msg), "Success message 'Page has been submitted' not displayed after clicking Send button");
            Waits.WaitAndClick(driver, dispatchManagerPage.BtnManualPageClose);
        }

        [When(@"navigate to SNPP tab Under Page Settings tab")]
        public void WhenNavigateToSNPPTabUnderPageSettingsTab()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkPageDestinations);
            Waits.Wait(driver, 1000);
        }

        [When(@"Clicked SNPP")]
        public void WhenClickedSNPP()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkSNPP);
            Waits.Wait(driver, 1000);
        }

        [When(@"login user '(.*)' created new SNPP page with SNPP IP of '(.*)', page number as '(.*)'")]
        public void WhenLoginUserCreatedNewSNPPPageWithSNPPIPOfPageNumberAs(string userName, string snppServer, string page)
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkSNPP);
            Waits.WaitAndClick(driver, dispatchManagerPage.TxtSNPPServer);
            dispatchManagerPage.TxtSNPPServer.Clear();
            dispatchManagerPage.TxtSNPPServer.SendKeys(snppServer);
            dispatchManagerPage.TxtPagerNumber.Clear();
            dispatchManagerPage.TxtPagerNumber.SendKeys(page);
            Waits.WaitAndClick(driver, dispatchManagerPage.BtnCreate);
            Waits.WaitForElementVisible(driver, dispatchManagerPage.LblSuccessMessage);
            Assert.IsTrue(dispatchManagerPage.LblSuccessMessage.Text.Contains(GlobalConstants.PageDestinationCreated), "Page Destination Created message appeared");
        }

        [When(@"navigate to PageMate tab Under Page Settings tab")]
        public void WhenNavigateToPageMateTabUnderPageSettingsTab()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkPageDestinations);
        }

        [When(@"Clicked PageMate")]
        public void WhenClickedPageMate()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkPagemate);
        }

        [When(@"login user '(.*)' created new PageMate page with page number as '(.*)'")]
        public void WhenLoginUserCreatedNewPageMatePageWithPageNumberAs(string userName, string page)
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkPagemate);
            Waits.WaitAndClick(driver, dispatchManagerPage.TxtPageNumber);
            dispatchManagerPage.TxtPageNumber.SendKeys(page);
            dispatchManagerPage.TxtPageNumber.SendKeys(Keys.Tab);
            Waits.WaitAndClick(driver, dispatchManagerPage.BtnCreate);
        }

        [When(@"navigated to Derdack tab under Page Settings tab")]
        public void WhenNavigatedToDerdackTabUnderPageSettingsTab()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkPageDestinations);
        }

        [When(@"Clicked Derdack")]
        public void WhenClickedDerdack()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkDerdack);
            
        }

        [When(@"login user '(.*)' created new Derdack page with DerdackUserLogin of '(.*)', Server SOAP URL as '(.*)' and Provider Name as '(.*)'")]
        public void WhenLoginUserCreatedNewDerdackPageWithDerdackUserLoginOfServerSOAPURLAsAndProviderNameAs(string userName, string Login, string URL, string Name)
        {
            Waits.WaitForElementVisible(driver, dispatchManagerPage.TxtUserLogin);
            dispatchManagerPage.TxtUserLogin.Clear();
            dispatchManagerPage.TxtUserLogin.SendKeys(Login);
            dispatchManagerPage.TxtServerSoapURL.Clear();
            dispatchManagerPage.TxtServerSoapURL.SendKeys(URL);
            dispatchManagerPage.TxtProviderName.Clear();
            dispatchManagerPage.TxtProviderName.SendKeys(Name);
            Waits.WaitAndClick(driver, dispatchManagerPage.BtnCreate);
            Waits.WaitForElementVisible(driver, dispatchManagerPage.LblSuccessMessage);
            Assert.IsTrue(dispatchManagerPage.LblSuccessMessage.Text.Contains(GlobalConstants.PageDestinationCreated), "Page Destination Created message appeared");
        }

        [When(@"Press the Service status button")]
        public void WhenPressTheServiceStatusButton()
        {
            string title = dispatchManagerPage.BtnServiceStatus.GetAttribute("title");
            if (title.Equals("Pause the Paging Service"))
            {
                dispatchManagerPage.BtnServiceStatus.Click();
                dateTime = DateTime.Now.ToString("yyyy-MM-dd");
                Waits.Wait(driver, 8000);
            }
            else if (title.Equals("Start the Paging Service"))
            {
                dispatchManagerPage.BtnServiceStatus.Click();
                dateTime = DateTime.Now.ToString("yyyy-MM-dd");
                Waits.Wait(driver, 8000);
            }
        }

        [Then(@"The service status should display accordingly action taken")]
        public void ThenTheServiceStatusShouldDisplayAccordinglyActionTaken()
        {
            string title = dispatchManagerPage.BtnServiceStatus.GetAttribute("title");
            if (title.Equals("Pause the Paging Service"))
            {
                dispatchManagerPage.LblServiceStatus.Text.Contains("Running");
                Waits.Wait(driver, 4000);
            }
            else if (title.Equals("Start the Paging Service"))
            {
                dispatchManagerPage.LblServiceStatus.Text.Contains("Paused");
                Waits.Wait(driver, 4000);
            }
        }

        [Then(@"Check the AAP console utility in the Taskbar and observe the text")]
        public void ThenCheckTheAAPConsoleUtilityInTheTaskbarAndObserveTheText()
        {
            Waits.Wait(driver, 6000);
            string autopagerText = simulator.GetAutopagerText();
            var text = autopagerText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            if (dispatchManagerPage.LblServiceStatus.Text.Contains("Paused"))
            {
                Assert.IsTrue(text[0].Contains(GlobalConstants.PausedServiceStatus) && simulator.GetAutopagerText().Contains(dateTime), "Verified AAP console utility in the Taskbar and observe the text");
            }
            else if (dispatchManagerPage.LblServiceStatus.Text.Contains("Running"))
            {
                Assert.IsTrue(text[0].Contains(GlobalConstants.RunningServiceStatus) && simulator.GetAutopagerText().Contains(dateTime), "Verified AAP console utility in the Taskbar and observe the text");
            }
        }

        [Then(@"Check the AAP console application and ensure there'(.*)'Autopager processing has been continued\.'")]
        public void ThenCheckTheAAPConsoleApplicationAndEnsureThereAutopagerProcessingHasBeenContinued_(string text)
        {

            Assert.IsTrue(simulator.GetAutopagerText().Contains(text), "Verified AAP console utility in the Taskbar and observe the text");
            Waits.Wait(driver, 1000);
        }

        [When(@"Clicked SMTP auth")]
        public void WhenClickedSMTPAuth()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkSMTPAUTH);
        }

        [When(@"login user '(.*)' created new SMTP Auth page From as '(.*)' destination with SMTP IP of '(.*)', port number as '(.*)' and To address as '(.*)'")]
        public void WhenLoginUserCreatedNewSMTPAuthPageFromAsDestinationWithSMTPIPOfPortNumberAsAndToAddressAs(string userName, string from, string smtpServer, string smtpPort, string toAddress)
        {
            dispatchManagerPage.DeleteSMTPPageDestination_IfExists(userName);
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkSMTPAUTH);
            Waits.WaitForElementVisible(driver, dispatchManagerPage.TxtFromSMTPAuth);
            dispatchManagerPage.TxtFromSMTPAuth.Clear();
            dispatchManagerPage.TxtFromSMTPAuth.SendKeys(from);
            dispatchManagerPage.TxtSMTPAuthServer.Clear();
            dispatchManagerPage.TxtSMTPAuthServer.SendKeys(smtpServer);
            dispatchManagerPage.TxtSMTPAuthPort.Clear();
            dispatchManagerPage.TxtSMTPAuthPort.SendKeys(smtpPort);
            dispatchManagerPage.TxtToAddressSMTPAuth.Clear();
            dispatchManagerPage.TxtToAddressSMTPAuth.SendKeys(toAddress);
            Waits.WaitAndClick(driver, dispatchManagerPage.BtnCreate);
            Waits.WaitForElementVisible(driver, dispatchManagerPage.LblSuccessMessage);
            Assert.IsTrue(dispatchManagerPage.LblSuccessMessage.Text.Contains(GlobalConstants.PageDestinationCreated), "Page Destination Created");
        }

        [When(@"Clicked to General Settings link")]
        public void WhenClickedToGeneralSettingsLink()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkGeneralSettings);
        }

        [Then(@"General Settings detail page should be displayed\.")]
        public void ThenGeneralSettingsDetailPageShouldBeDisplayed_()
        {
            Waits.Wait(driver, 3000);
            Assert.IsTrue(driver.Url.Contains("General.aspx"), "General settings page not opened");
        }

        [When(@"Clicked on manual page\.")]
        public void WhenClickedOnManualPage_()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.BtnManualPage);
        }

        [When(@"Selected Engineer and Select SMTP in Page Destination\.")]
        public void WhenSelectedEngineerAndSelectSMTPInPageDestination_()
        {
            Waits.Wait(driver, 1000);
            ElementExtensions.SelectByValue(dispatchManagerPage.DrpDwnEngineer, "1");
            ElementExtensions.SelectByText(dispatchManagerPage.DrpdwnPageDestination, "SMTPAuth");
        }

        [When(@"Go to Dispatch Manager-> Page Destinations -> Some SMTP Dispatcher'(.*)'")]
        public void WhenGoToDispatchManager_PageDestinations_SomeSMTPDispatcher(string Dispatcher)
        {
            homePage.NavigateToDispatchManagerPage();
            Waits.WaitForElementVisible(driver, dispatchManagerPage.LnkPageDestinations);
            dispatchManagerPage.SelectAlreadycreatedSMTPDispatcher(Dispatcher);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The dispatcher details should display along with \[Test], \[Apply] and \[Delete] buttons")]
        public void ThenTheDispatcherDetailsShouldDisplayAlongWithTestApplyAndDeleteButtons()
        {
            Assert.IsTrue(dispatchManagerPage.LblTitle_SMTP.Text.Contains("Edit SMTP Destination"), "Verified user on The dispatcher details tab");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(dispatchManagerPage.BtnTest.Displayed, "The dispatcher details should display along with Test button");
            Waits.Wait(driver, 1000);
        }

        [When(@"Press the \[Test] button")]
        public void WhenPressTheTestButton()
        {
            Waits.WaitTillElementIsClickable(driver, dispatchManagerPage.BtnTest);
        }

        [Then(@"A test message has been placed on the queue message")]
        public void ThenATestMessageHasBeenPlacedOnTheQueueMessage()
        {
            Waits.WaitForElementVisible(driver, dispatchManagerPage.LblSuccessMessage);
            Assert.IsTrue(dispatchManagerPage.LblSuccessMessage.Text.Contains(GlobalConstants.DispatchManagerSMTPSuccessMessage), "Verified screen presence A test message has been placed on the queue");
        }

        [When(@"navigated to Dispatch Manager->Scheduler\.")]
        public void WhenNavigatedToDispatchManager_Scheduler_()
        {
            dispatchManagerPage.SwitchToSchedulerTab();
            Waits.WaitForElementVisible(driver, dispatchManagerPage.LblSettingsTitle);
            Assert.IsTrue(dispatchManagerPage.LblSettingsTitle.Text.Contains("New Schedule"), "Verified user on The Scheduler tab");
            Waits.Wait(driver, 1000);
        }

        [When(@"Clicked Week days check box, All Day Check box and selected previously created PageDestination'(.*)'\.")]
        public void WhenClickedWeekDaysCheckBoxAllDayCheckBoxAndSelectedPreviouslyCreatedPageDestination_(string PageDestination)
        {
            dispatchManagerPage.SelectDropDownPageDestination(PageDestination);
            dispatchManagerPage.SelectWeekDaysCheckBox();
            dispatchManagerPage.SelectWeekendDaysCheckbox();
            dispatchManagerPage.SelectAllDayCheckBox();
        }

        [Then(@"clicked Apply")]
        public void ThenClickedApply()
        {
            dispatchManagerPage.ClickApply();
            Waits.WaitForElementVisible(driver, dispatchManagerPage.LblScheduleCreatedMsg);
        }

        [Then(@"The changes made in scheduling entry should be displayed and new PageDestination'(.*)' entry added in the list\.")]
        public void ThenTheChangesMadeInSchedulingEntryShouldBeDisplayedAndNewPageDestinationEntryAddedInTheList_(string PageDestination)
        {
            Assert.IsTrue(dispatchManagerPage.IsSelectedPageDestinationPresence(PageDestination), "Verified the changes made in scheduling entry should be displayed and new entry added in the list");
        }

        [Then(@"the new schedule window isn't shown, click on New Button to create new schedule\.New Schedule form will be displayed\.")]
        public void ThenTheNewScheduleWindowIsnTShownClickOnNewButtonToCreateNewSchedule_NewScheduleFormWillBeDisplayed_()
        {
            Assert.IsFalse(dispatchManagerPage.LblSettingsTitle.Text.Contains("New Schedule"), "Verified the new schedule window isn't shown");
            dispatchManagerPage.ClickOnNewSchedule();
            Waits.WaitForElementVisible(driver, dispatchManagerPage.LblSettingsTitle);
            Assert.IsTrue(dispatchManagerPage.LblSettingsTitle.Text.Contains("New Schedule"), "Verified New Schedule form will be displayed");
        }

        [When(@"Created an alert'(.*)' from a piece of equipment'(.*)'")]
        public void WhenCreatedAnAlertFromAPieceOfEquipment(string alert, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alert, port);
            dateTime = DateTime.Now.ToString("yyyy-MM-dd");
            simulator.MinimizeWindow("TURBO");
        }

        [Then(@"The alert should arrive via the dispatch method selected")]
        public void ThenTheAlertShouldArriveViaTheDispatchMethodSelected()
        {
            Waits.Wait(driver, 30000);
            string autopagerText = simulator.GetAutopagerText();
            var text = autopagerText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.IsTrue(text[0].Contains(GlobalConstants.EquipmentAlarm), "Verified The alert should arrive via the dispatch method selected");
            Waits.Wait(driver, 2000);
        }

        [Then(@"The alert should arrive via the dispatch method selected\.")]
        public void ThenTheAlertShouldArriveViaTheDispatchMethodSelected_()
        {
            Waits.Wait(driver, 30000);
            string autopagerText = simulator.GetAutopagerText();
            var text = autopagerText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.IsTrue(text[0].Contains(GlobalConstants.AlarmMessageSuccessfullySent) && text[1].Contains(dateTime), "Verified The alert should arrive via the dispatch method selected");
            Waits.Wait(driver, 2000);
        }

        [When(@"Cleared alert from '(.*)'")]
        public void GivenClearedAlertFrom(string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.ClearEquimentAlertTurbo(port);
            simulator.MinimizeSimulator();
        }

        [When(@"Edited the previous schedule PageDestination'(.*)' entry\(Select the scheduler entry in the list to edit it\) edit with  SMTP page From as '(.*)' destination with SMTP IP of '(.*)' and To address as '(.*)' and add an Alternative Destination'(.*)' with an After Minutes value of one")]
        public void WhenEditedThePreviousSchedulePageDestinationEntrySelectTheSchedulerEntryInTheListToEditItEditWithSMTPPageFromAsDestinationWithSMTPIPOfAndToAddressAsAndAddAnAlternativeDestinationWithAnAfterMinutesValueOfOne(string PageDestination, string from, string smtpServer, string toAddress, string Destination)
        {
            dispatchManagerPage.SelectedCreatedPageDestination(PageDestination);
            Waits.Wait(driver, 2000);
            dispatchManagerPage.BtnAddDestination.Click();
            Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, dispatchManagerPage.TxtSMTPFrom_SMTP);
            dispatchManagerPage.TxtSMTPFrom_SMTP.Clear();
            dispatchManagerPage.TxtSMTPFrom_SMTP.SendKeys(from);
            Waits.Wait(driver, 1000);
            dispatchManagerPage.TxtServer_SMTP.Clear();
            dispatchManagerPage.TxtServer_SMTP.SendKeys(smtpServer);
            Waits.Wait(driver, 1000);
            dispatchManagerPage.TxtToAddress_SMTP.Clear();
            dispatchManagerPage.TxtToAddress_SMTP.SendKeys(toAddress);
            Waits.Wait(driver, 1000);
            dispatchManagerPage.BtnCreate.Click();
            Waits.Wait(driver, 8000);
            dispatchManagerPage.SelectDropDownAlternateDestination(Destination);
            Waits.Wait(driver, 2000);
            dispatchManagerPage.EditAfterMinutes();
            Waits.Wait(driver, 2000);
            //dispatchManagerPage.ChkBoxWeekendDay.Click();
            //Waits.Wait(driver, 4000);
            //dispatchManagerPage.ChkBoxWeekDay.Click();
            //Waits.Wait(driver, 2000);
            dispatchManagerPage.ClickApply();
            Waits.Wait(driver, 2000);
        }

        [Then(@"The scheduling PageDestination'(.*)' entry should be displayed with a blue pointer indicating that escalation has been established")]
        public void ThenTheSchedulingPageDestinationEntryShouldBeDisplayedWithABluePointerIndicatingThatEscalationHasBeenEstablished(string PageDestination)
        {
            Assert.IsTrue(dispatchManagerPage.GetScheduleEntryBackroundColor().Contains("rgba(0, 153, 255, 1)"), "Verified the scheduling entry should be displayed with a blue pointer indicating that escalation has been established");
            Waits.Wait(driver, 1000);
        }

        [When(@"Create an alert '(.*)' from a piece of equipment'(.*)' and wait for two minutes")]
        public void WhenCreateAnAlertFromAPieceOfEquipmentAndWaitForTwoMinutes(string alert, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alert, port);
            dateTime = DateTime.Now.ToString("yyyy-MM-dd");
            simulator.MinimizeWindow("TURBO");
        }

        [Then(@"The alert should arrive via the dispatch method selected\. After a minute the alternative page destination should be used \(escalated\)")]
        public void ThenTheAlertShouldArriveViaTheDispatchMethodSelected_AfterAMinuteTheAlternativePageDestinationShouldBeUsedEscalated()
        {
            Waits.Wait(driver, 20000);
            string autoPagerText = simulator.GetAutopagerText();
            Assert.IsTrue(autoPagerText.Contains(GlobalConstants.EquipmentWarning), "Verified The alert should arrive via the dispatch method selected");
            Waits.Wait(driver, 2000);
        }

        [When(@"Edit the previous schedule entry and add a time \(Between \[____] And \[____] \(Leave blank for all day\) which is two hours from now")]
        public void WhenEditThePreviousScheduleEntryAndAddATimeBetween____And____LeaveBlankForAllDayWhichIsTwoHoursFromNow()
        {
            Waits.Wait(driver, 3000);
            dispatchManagerPage.EditScheduleFromTime();
            Waits.Wait(driver, 1000);
            dispatchManagerPage.EditScheduleToTime();
            Waits.Wait(driver, 1000);
            Assert.IsFalse(dispatchManagerPage.ChkBoxAllDay.GetAttribute("src").Contains("chk_on"), "Verifed blank for all day");
            Waits.Wait(driver, 1000);
            dispatchManagerPage.ClickApply();
            Waits.Wait(driver, 2000);
        }

        [Then(@"The schedule'(.*)' entry should display with the Start and End columns set")]
        public void ThenTheScheduleEntryShouldDisplayWithTheStartAndEndColumnsSet(string PageDestination)
        {
            string startTime = dispatchManagerPage.StartTime();
            // Assert.IsTrue(dispatchManagerPage.ScheduleEntryTimeCheck(PageDestination, startTime), "Verified the scheduling entry should display with the StartTime in column set");
            Waits.Wait(driver, 1000);
            string endTime = dispatchManagerPage.EndTime();
            // Assert.IsTrue(dispatchManagerPage.ScheduleEntryTimeCheck(PageDestination, endTime), "Verified the scheduling entry should display with the EndTime in column set");
            Waits.Wait(driver, 1000);
        }

        [When(@"Create an alert '(.*)' from a piece of equipment '(.*)'")]
        public void WhenCreateAnAlertFromAPieceOfEquipment(string alert, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.RaiseEquipmentAlertTurbo(alert, port);
            dateTime = DateTime.Now.ToString("yyyy-MM-dd");
            simulator.MinimizeWindow("TURBO");
        }

        [Then(@"The alert should NOT arrive via the dispatch method selected")]
        public void ThenTheAlertShouldNOTArriveViaTheDispatchMethodSelected()
        {
            Waits.Wait(driver, 12000);
            string autopagerText = simulator.GetAutopagerText();
            var text = autopagerText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.IsTrue(text[0].Contains(GlobalConstants.ReadingExceptionSettings) && text[1].Contains(dateTime), "Verified The alert should arrive via the dispatch method selected");
            Waits.Wait(driver, 2000);
        }

        [When(@"Created an alert '(.*)' from a piece of equipment'(.*)'\.")]
        public void WhenCreatedAnAlertFromAPieceOfEquipment_(string alert, string port)
        {
            simulator.RestoreWindow("TURBO");
            simulator.EnterSpace();
            simulator.RaiseEquipmentAlertTurbo(alert, port);
            dateTime = DateTime.Now.ToString("yyyy-MM-dd");
            simulator.MinimizeWindow("TURBO");
        }

        [Then(@"The alert should NOT arrive via the dispatch method selected\.")]
        public void ThenTheAlertShouldNOTArriveViaTheDispatchMethodSelected_()
        {
            Waits.Wait(driver, 15000);
            string autopagerText = simulator.GetAutopagerText();
            var text = autopagerText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.IsTrue(text[1].Contains(GlobalConstants.NoSchedulingFoundForThisEvent), "Verified The alert should not arrive via the dispatch method selected");
            Waits.Wait(driver, 2000);
        }

        [When(@"Edit the previous schedule PageDestination'(.*)' entry and make a selection of other changes \(excluding Equipment and Alets tab\)")]
        public void WhenEditThePreviousSchedulePageDestinationEntryAndMakeASelectionOfOtherChangesExcludingEquipmentAndAletsTab(string PageDestination)
        {
            dispatchManagerPage.SelectedCreatedPageDestination(PageDestination);
            Waits.Wait(driver, 2000);
            dispatchManagerPage.UnSelectWeekDaysCheckbox();
            Waits.Wait(driver, 2000);
            dispatchManagerPage.SelectWeekendDaysCheckbox();
            Waits.Wait(driver, 2000);
            dispatchManagerPage.SelectAllDayCheckBox();
            Waits.Wait(driver, 2000);
            dispatchManagerPage.ClickApply();
            Waits.Wait(driver, 2000);
        }

        [Then(@"Delete the previously created PageDestination'(.*)'")]
        public void ThenDeleteThePreviouslyCreatedPageDestination(string userName)
        {
            dispatchManagerPage.NavigateToPageDestinationLink();
            Waits.Wait(driver, 1000);
            dispatchManagerPage.DeleteSMTPPageDestination_IfExists(userName);
            Waits.Wait(driver, 2000);
        }

        [When(@"Click on previously created schedule PageDestination'(.*)' entry in the list on Scheduler\.On the Schedule Detail click on Equipment tab\.")]
        public void WhenClickOnPreviouslyCreatedSchedulePageDestinationEntryInTheListOnScheduler_OnTheScheduleDetailClickOnEquipmentTab_(string PageDestination)
        {
            dispatchManagerPage.SelectedCreatedPageDestination(PageDestination);
            Waits.Wait(driver, 2000);

        }

        [Then(@"The Equipment tab should display")]
        public void ThenTheEquipmentTabShouldDisplay()
        {
            Assert.IsTrue(dispatchManagerPage.BtnAddEquipment.Displayed, "Verified The Equipment tab should display");
            Waits.Wait(driver, 2000);
        }

        [When(@"Add a singlie piece of Equipment'(.*)', searching by either Equipment type or name or both in Find Equipment to add panel")]
        public void WhenAddASingliePieceOfEquipmentSearchingByEitherEquipmentTypeOrNameOrBothInFindEquipmentToAddPanel(string Equipment)
        {
            dispatchManagerPage.AddEquipments(Equipment);
            Waits.Wait(driver, 2000);
        }

        [Then(@"The Equipment'(.*)' discovered and added should be displayed in Restrict Pages to this Equipment:\(NB: If empty then all equipment is allowed\) :")]
        public void ThenTheEquipmentDiscoveredAndAddedShouldBeDisplayedInRestrictPagesToThisEquipmentNBIfEmptyThenAllEquipmentIsAllowed(string Equipment)
        {
            dispatchManagerPage.ImgExpandEquipment.Click();
            Waits.Wait(driver, 1000);
            Assert.IsTrue(dispatchManagerPage.IsSelectEquipmentDisplayed(Equipment), "Verified The Equipment discovered and added should be displayed in Restrict Pages ");
            Waits.WaitAndClick(driver, dispatchManagerPage.BtnApplySchedular);
            Waits.Wait(driver, 2000);
        }


        [When(@"Remove the Equipment'(.*)' restriction")]
        public void WhenRemoveTheEquipmentRestriction(string Equipment)
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.ImgExpandEquipment);
            dispatchManagerPage.RemoveEquipmentFromRestrictionList(Equipment);
            Waits.Wait(driver, 3000);
        }

        [Then(@"The schedule screen should no longer report a certain number of Equipment'(.*)' are configured for restriction")]
        public void ThenTheScheduleScreenShouldNoLongerReportACertainNumberOfEquipmentAreConfiguredForRestriction(string Equipment)
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.ImgExpandEquipment);
            Assert.IsFalse(dispatchManagerPage.IsSelectEquipmentDisplayed(Equipment), "verified the schedule screen should no longer report a certain number of equipment are configured for restriction");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click on Alert tab in Schedule detail screen")]
        public void WhenClickOnAlertTabInScheduleDetailScreen()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.ImgExpandAlert);
            Waits.Wait(driver, 1000);
        }

        [Then(@"The Alert tab UI should display")]
        public void ThenTheAlertTabUIShouldDisplay()
        {
            Waits.WaitForElementVisible(driver, dispatchManagerPage.BtnAddAlert);
            Assert.IsTrue(dispatchManagerPage.BtnAddAlert.Displayed, "Verified the Alert tab UI should display");
            Waits.Wait(driver, 1000);
        }

        [When(@"Add a single alert  Value'(.*)' for a type of equipment Alert'(.*)' to restrict to")]
        public void WhenAddASingleAlertValueForATypeOfEquipmentAlertToRestrictTo(string Value, string Alert)
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.BtnAddAlert);
            Waits.Wait(driver, 5000);
            Waits.WaitForElementVisible(driver, dispatchManagerPage.LnkRestrictAlert);
            Assert.IsTrue(dispatchManagerPage.LnkRestrictAlert.Displayed, "Verfied restric AlertPage should be displayed");
            dispatchManagerPage.AddAlerts(Value, Alert);
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, dispatchManagerPage.BtnApplySchedular);
            Waits.Wait(driver, 2000);
        }

        [Then(@"The Alert'(.*)' should be displayed in the 'Restrict Pages to these Alerts:\(NB: If empty then all Alerts are allowed\) list\.")]
        public void ThenTheAlertShouldBeDisplayedInTheRestrictPagesToTheseAlertsNBIfEmptyThenAllAlertsAreAllowedList_(string Alert)
        {
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, dispatchManagerPage.ImgExpandAlert);
            Waits.Wait(driver, 2000);
            Assert.IsTrue(dispatchManagerPage.IsSelectAlertDisplayed(Alert), "verified the alert should be displayed in the Restrict Pages to these Alerts");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click on each mode: \[General Settings]; \[Page Destinations]; \[Scheduler]; \[Inhibit Settings]")]
        public void WhenClickOnEachModeGeneralSettingsPageDestinationsSchedulerInhibitSettings()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkGeneralSettings);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(driver.Url.Contains("DispatchManager/General.aspx"), "Verified navigated to General settings Page on clicking link");
            Waits.Wait(driver, 1000);
            dispatchManagerPage.NavigateToPageDestinationLink();
            Waits.Wait(driver, 1000);
            Assert.IsTrue(driver.Url.Contains("DispatchManager/Page.aspx"), "Verified navigated to Page Destination on clicking link");
            Waits.Wait(driver, 1000);
            dispatchManagerPage.SwitchToSchedulerTab();
            Waits.Wait(driver, 1000);
            Assert.IsTrue(driver.Url.Contains("DispatchManager/Dispatch.aspx"), "Verified navigated to Scheduler on clicking link");
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkInhibitSettings);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(driver.Url.Contains("DispatchManager/Inhibit.aspx"), "Verified navigated to Inhibit on clicking link");
            Waits.Wait(driver, 1000);
        }

        [Then(@"The appropriate settings to be displayed")]
        public void ThenTheAppropriateSettingsToBeDisplayed()
        {
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkGeneralSettings);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(dispatchManagerPage.TxtSiteName.Displayed, "verified Site Name text box is displayed then the appropriate settings to be displayed");
            Waits.Wait(driver, 1000);
            dispatchManagerPage.NavigateToPageDestinationLink();
            Waits.Wait(driver, 1000);
            Assert.IsTrue(dispatchManagerPage.BtnNewPageDestination.Displayed, "Verified New Page Destionation create button is displayed then the appropriate settings to be displayed ");
            Waits.Wait(driver, 1000);
            dispatchManagerPage.SwitchToSchedulerTab();
            Waits.Wait(driver, 1000);
            Assert.IsTrue(dispatchManagerPage.DrpdwnPageDestination.Displayed, "Verified dropdown Page Destination is displayed then the appropriate settings to be displayed");
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, dispatchManagerPage.LnkInhibitSettings);
            Waits.Wait(driver, 1000);
            Assert.IsTrue(dispatchManagerPage.LblInhibitSettingsTitle.Displayed, "Verified Inhibit settings tittle lable is displayed then the appropriate settings to be displayed");
            Waits.Wait(driver, 1000);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                dispatchManagerPage.DeleteSMTPPageDestination_IfExists();
                simulator.KillProcess();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught " + ex.Message);
            }

        }

    }
}
