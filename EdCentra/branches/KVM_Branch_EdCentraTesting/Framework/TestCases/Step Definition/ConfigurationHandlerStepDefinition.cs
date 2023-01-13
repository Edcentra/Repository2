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
    public sealed class ConfigurationHandlerStepDefinition
    {
        LoginPage loginPage;
        HomePage homePage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        UserPage userPage;
        DispatchManagerPage dispatchManagerPage;
        ConfigurationHandlerPage configurationHandlerPage;
        HistorianPage historianPage;
        ReportPage reportPage;
        LiveAlertsListPage liveAlertsListPage;

        private static string configurationSetName = ElementExtensions.GetRandomString(6);
        private static string configurationsetParameter = "1 - Pump Node - Node";
        private string newConfigurationSetName = ElementExtensions.GetRandomString(5);
        string testFolderName = ElementExtensions.GetRandomString(4);

        private IWebDriver driver;

        public ConfigurationHandlerStepDefinition(IWebDriver _driver)
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
            configurationHandlerPage = new ConfigurationHandlerPage(driver);
            historianPage = new HistorianPage(driver);
            reportPage = new ReportPage(driver);
            liveAlertsListPage = new LiveAlertsListPage(driver);
        }

        [When(@"clicked Device Explorer link\.")]
        public void WhenClickedDeviceExplorerLink_()
        {
            homePage.ClickOnDeviceExplorer();
        }

        [Then(@"should be navigated to Device Explorer page\.")]
        public void ThenShouldBeNavigatedToDeviceExplorerPage_()
        {
            bool res = Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkAddFolder);
            Assert.IsTrue(res, "Verifying User is not navigated to Device Explorer page");
        }

        [When(@"clicked on add folder/ system icon\.")]
        public void WhenClickedOnAddFolderSystemIcon_()
        {
            deviceExplorerNavigationPage.ClickOnPlusToAddFolder();
        }

        [When(@"entered folder name and Clicked on Add button\.")]
        public void WhenEnteredFolderNameAndClickedOnAddButton_()
        {
            deviceExplorerNavigationPage.EnterFolderName(testFolderName);
        }

        [Then(@"should be able to see Folder Added Successfully message\.")]
        public void ThenShouldBeAbleToSeeFolderAddedSuccessfullyMessage_()
        {
            bool res= Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(res, "Verifying 'Folder Added Successfully' message");
        }

        [When(@"clicked OK button\.")]
        public void WhenClickedOKButton_()
        {
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [Then(@"should be able to see newly added folder\.")]
        public void ThenShouldBeAbleToSeeNewlyAddedFolder_()
        {
            Assert.IsTrue(driver.PageSource.Contains(testFolderName), "Verifying added folder");
        }

        [When(@"clicked Find Equipment\.")]
        public void WhenClickedFindEquipment_()
        {
            deviceExplorerNavigationPage.ClickFindEquipment(testFolderName);
        }

        [When(@"entered Equipment name, selected equipment type '(.*)', Clicked Find Equipment button, selected one equipment and clicked Add button")]
        public void WhenEnteredEquipmentNameSelectedEquipmentTypeClickedFindEquipmentButtonSelectedOneEquipmentAndClickedAddButton(string equipmentType)
        {
            deviceExplorerNavigationPage.AddEquipmentToSystem(equipmentType);
        }

        [Then(@"should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed\.")]
        public void ThenShouldBeAbleToSeeEquipmentAddedSuccessfullyMessageAndAfterClickingOkButtonAddedEquipmentShouldBeDisplayed_()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.EquipmentAddedMsg), "Verifying 'Equipment Added Successfully' message");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [Given(@"Opened EDCENTRA url in browser")]
        public void GivenOpenedEDCENTRAUrlInBrowser()
        {
            PageInitialization();
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);
        }

        [When(@"Entered username as '(.*)' and password  as'(.*)' and I clicked login button")]
        public void WhenEnteredUsernameAsAndPasswordAsAndIClickedLoginButton(string username, string password)
        {
            loginPage.SignIn(username, password);
        }

        [Then(@"Should be navigated to home page")]
        public void ThenShouldBeNavigatedToHomePage()
        {
            bool res = Waits.WaitForElementVisible(driver, homePage.LnkDeviceManager);
            Assert.IsTrue(res, "Verifying User should be navigated to Home page");
        }

        [Given(@"navigated to Configuration Handler page")]
        public void GivenNavigatedToConfigurationHandlerPage()
        {
            Waits.Wait(driver, 10000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, homePage.LnkConfigure);
            homePage.LnkConfigure.Click();
            //homePage.ClickOnConfiguration();
            //JavaScriptExecutor.JavaScriptScrollToElement(driver, homePage.LnkConfiguarationHandler);
            Waits.WaitAndClick(driver, homePage.LnkConfiguarationHandler);
            Waits.Wait(driver, 2000);
            Assert.IsTrue(driver.Url.Contains("Components/Configuration/Configuration.aspx"));
        }

        [When(@"selected Equipment Type in the list")]
        public void WhenSelectedEquipmentTypeInTheList()
        {
            ElementExtensions.MouseHover(driver, configurationHandlerPage.LblDryPump);
            Waits.WaitAndClick(driver, configurationHandlerPage.LblDryPump);
            Waits.Wait(driver, 2000);
        }

        [When(@"clicked Create button\.")]
        public void WhenClickedCreateButton_()
        {
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnCreate);
        }

        [Then(@"Create Configuration sdet pop-up will appear")]
        public void ThenCreateConfigurationSdetPop_UpWillAppear()
        {
            Waits.WaitForElementVisible(driver, configurationHandlerPage.LblCreateConfiguarationSet);
            Assert.IsTrue(configurationHandlerPage.LblCreateConfiguarationSet.Text.Contains("Create Configuration Set"));
        }

        [When(@"gave a unique name '(.*)' to configuration set")]
        public void WhenGaveAUniqueNameToConfigurationSet(string name)
        {
            Waits.Wait(driver, 6000);
            configurationHandlerPage.TxtBoxName.Clear();
            configurationHandlerPage.TxtBoxName.SendKeys(name);
        }

        [When(@"selected required radio button from the list and click create")]
        public void WhenSelectedRequiredRadioButtonFromTheListAndClickCreate()
        {
            Waits.Wait(driver, 3000);
            JavaScriptExecutor.JavaScriptClick(driver, configurationHandlerPage.RadioBtnPumpSet);
            Waits.WaitAndClick(driver, configurationHandlerPage.RadioBtnPumpSet);
            ElementExtensions.MouseHover(driver, configurationHandlerPage.BtnCreate);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnCreateConfigurationSetUp);
        }

        [Then(@"Configuration Set with given name '(.*)' will be created")]
        public void ThenConfigurationSetWithGivenNameWillBeCreated(string name)
        {
            for(int i=1; i<=30; i++)
            {
                if(ElementExtensions.isDisplayed(driver, configurationHandlerPage.BtnCreateWithSpinner))
                {
                    Waits.Wait(driver, 1000);
                }
                else
                {
                    break;
                }
            }  
            Assert.IsTrue(configurationHandlerPage.CheckConfigurationSetExists(name), "Configuration set created");
        }

        [When(@"Selected '(.*)'and added the parameters required '(.*)'")]
        public void WhenSelectedAndAddedTheParametersRequired(string setName, string parameterName)
        {
            configurationHandlerPage.selectConfiguarationSetParameters(parameterName);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnSave);
        }

        [Then(@"configuration set changes should be saved")]
        public void ThenConfigurationSetShouldBeSaved()
        {
            Waits.WaitForElementVisible(driver, configurationHandlerPage.LblSuccessMsg);
            Assert.IsTrue(configurationHandlerPage.LblSuccessMsg.Text.Contains(GlobalConstants.ChangesApplied), "Verified success message on save");
        }

        [When(@"selected type from the list and then select already created configuration set '(.*)'")]
        public void WhenSelectedTypeFromTheListAndThenSelectAlreadyCreatedConfigurationSet(string configurationSetName)
        {
            ElementExtensions.MouseHover(driver, configurationHandlerPage.LblDryPump);
            Waits.WaitAndClick(driver, configurationHandlerPage.LblDryPump);
            Waits.Wait(driver, 2000);
            configurationHandlerPage.SelectExistingConfigurationSet(configurationSetName);
        }

        [Then(@"its detail will be listed i\.e\. selected parameter '(.*)'")]
        public void ThenItsDetailWillBeListedI_E_SelectedParameter(string configurationsetParameter)
        {
            Waits.Wait(driver, 5000);
            Assert.IsTrue(configurationHandlerPage.isConfigurationSetParameterAdded(configurationsetParameter), "Checked added parameters"); 
        }
       
        [Then(@"A pop-up will appear")]
        public void ThenAPop_UpWillAppear()
        {
            Waits.WaitForElementVisible(driver, configurationHandlerPage.LblRenameHighlightedSetPopUP);
            Assert.IsTrue(configurationHandlerPage.LblRenameHighlightedSetPopUP.Text.Contains(GlobalConstants.RenameHighlightedSet));
        }

        [When(@"entered same name there '(.*)' and clicked confirm")]
        public void WhenEnteredSameNameThereAndClickedConfirm(string setName)
        {
            configurationHandlerPage.TxtBoxNewName.Clear();
            configurationHandlerPage.TxtBoxNewName.SendKeys(setName);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnConfirm);
        }


        [Then(@"Make sure the it prompts for '(.*)' message")]
        public void ThenMakeSureTheItPromptsForMessage(string msg)
        {
            Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, configurationHandlerPage.LblErrorNameExists);
            Assert.IsTrue(configurationHandlerPage.LblErrorNameExists.Text.Contains(msg), "Verified Name already exists message not present");
        }

        [When(@"entered unique name '(.*)'and clicked confirm  from '(.*)' and clicked '(.*)'")]
        public void WhenEnteredUniqueNameAndClickedConfirmFromAndClicked(string newConfigurationSetName, string setName, string btnName)
        {
            configurationHandlerPage.TxtBoxNewName.Clear();
            configurationHandlerPage.TxtBoxNewName.SendKeys(newConfigurationSetName);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnConfirm);
            Waits.Wait(driver, 1000);
            if (configurationHandlerPage.LblErrorNameExists.Displayed)
            {
                Waits.WaitAndClick(driver, configurationHandlerPage.BtnClose);
                Waits.Wait(driver, 1000);
                configurationHandlerPage.DeleteIfConfigrationSetExists(newConfigurationSetName);
                Waits.Wait(driver, 1000);
                configurationHandlerPage.SelectExistingConfigurationSet(setName);
                Waits.Wait(driver, 1000);
                Waits.WaitAndClick(driver, configurationHandlerPage.BtnRename);
                Waits.WaitForElementVisible(driver, configurationHandlerPage.TxtBoxNewName);
                configurationHandlerPage.TxtBoxNewName.Clear();
                configurationHandlerPage.TxtBoxNewName.SendKeys(newConfigurationSetName);
                Waits.WaitAndClick(driver, configurationHandlerPage.BtnConfirm);
            }
        }


        [When(@"entered unique name '(.*)'and clicked confirm")]
        public void WhenEnteredUniqueNameAndClickedConfirm(string newConfigurationSetName)
        {
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnClose);
            Waits.Wait(driver, 1000);
            configurationHandlerPage.DeleteIfConfigrationSetExists(newConfigurationSetName);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnRename);
            configurationHandlerPage.TxtBoxNewName.Clear();
            configurationHandlerPage.TxtBoxNewName.SendKeys(newConfigurationSetName);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnConfirm);
        }

        [Then(@"set name should be changed to '(.*)'")]
        public void ThenSetNameShouldBeChangedTo(string newConfigurationSetName)
        {
            Waits.Wait(driver, 15000);
            Assert.IsTrue(configurationHandlerPage.CheckConfigurationSetExists(newConfigurationSetName), "Verified set name not renamed");
        }

        [When(@"clicked on the entry in right hand list and clicked Edit")]
        public void WhenClickedOnTheEntryInRightHandListAndClickedEdit()
        {
            configurationHandlerPage.TxtBoxHighAlarm.SendKeys("800");
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnSaveEditPopUp);
        }

        [When(@"added few entries '(.*)', '(.*)' in the set detail and clicked Save")]
        public void WhenAddedFewEntriesInTheSetDetailAndClickedSave(string parameter1, string parameter2)
        {
            Waits.Wait(driver, 5000);
            configurationHandlerPage.selectConfiguarationSetParameters(parameter1);
            configurationHandlerPage.selectConfiguarationSetParameters(parameter2);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnSave);
        }

        [When(@"clicked on the entry in right hand list and clicked Edit '(.*)'")]
        public void WhenClickedOnTheEntryInRightHandListAndClickedEdit(string parameter)
        {
            Waits.Wait(driver, 4000);
            configurationHandlerPage.SelectAssignedConfigurationParameter(parameter);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnEdit);
        }

        [Then(@"A Edit pop-up will appear contains title '(.*)' and '(.*)'")]
        public void ThenAEditPop_UpWillAppearContainsTitleAnd(string newConfigurationSetName, string parameter)
        {
            Waits.WaitForElementVisible(driver, configurationHandlerPage.LblEditPopUp);
            Assert.IsTrue(configurationHandlerPage.LblEditPopUp.Text.Contains(newConfigurationSetName) && configurationHandlerPage.LblEditPopUp.Text.Contains(parameter), "Verified Edit pop- up title is not visible");
        }

        [When(@"made few changes i\.e edit High alarm value to '(.*)' and clicked save")]
        public void WhenMadeFewChangesI_EEditHighAlarmValueToAndClickedSave(string value)
        {
            Waits.WaitForElementVisible(driver, configurationHandlerPage.TxtBoxHighAlarm);
            configurationHandlerPage.TxtBoxHighAlarm.Clear();
            configurationHandlerPage.TxtBoxHighAlarm.SendKeys(value);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnSaveEditPopUp);
           
        }

        [Then(@"Changes made should be saved for parameter '(.*)' with new high alarm value '(.*)'")]
        public void ThenChangesMadeShouldBeSavedForParameterWithNewHighAlarmValue(string parameter, string value)
        {
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnEdit);
            Waits.WaitForElementVisible(driver, configurationHandlerPage.TxtBoxHighAlarm);
            Assert.IsTrue(configurationHandlerPage.TxtBoxHighAlarm.GetAttribute("value").Equals(value), "Verified High Alarm value is not updated");
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnCancel);

        }

        [When(@"selected the set '(.*)' and clicked '(.*)'")]
        public void WhenSelectedTheSetAndClicked(string setName, string btnName)
        {
            Waits.Wait(driver, 5000);
            if (btnName.ToLower().Equals("rename"))
            {
                Waits.WaitAndClick(driver, configurationHandlerPage.BtnRename);
            }
            if (btnName.ToLower().Equals("copy"))
            {
                configurationHandlerPage.SelectExistingConfigurationSet(setName);
                Waits.WaitAndClick(driver, configurationHandlerPage.BtnCopy);
            }
            if (btnName.ToLower().Equals("delete"))
            {
                configurationHandlerPage.SelectExistingConfigurationSet(setName);
                Waits.WaitForElementVisible(driver, configurationHandlerPage.BtnDelete);
                Waits.WaitAndClick(driver, configurationHandlerPage.BtnDelete);
                Waits.WaitForElementVisible(driver, configurationHandlerPage.BtnConfirm);
                Waits.WaitAndClick(driver, configurationHandlerPage.BtnConfirm);
                Waits.WaitForElementVisible(driver, configurationHandlerPage.TblConfiguarationSets);
            }
        }

        [When(@"deleted if Configration Set already exists with same name '(.*)'")]
        public void WhenDeletedIfConfigrationSetAlreadyExistsWithSameName(string setName)
        {
            configurationHandlerPage.DeleteIfConfigrationSetExists(setName);
        }


        [When(@"selected type from the list and then selected already created configuration set '(.*)'")]
        public void WhenSelectedTypeFromTheListAndThenSelectedAlreadyCreatedConfigurationSet(string setName)
        {
            ElementExtensions.MouseHover(driver, configurationHandlerPage.LblDryPump);
            Waits.WaitAndClick(driver, configurationHandlerPage.LblDryPump);
            Waits.Wait(driver, 4000);
            configurationHandlerPage.SelectExistingConfigurationSet(setName);
        }

        [Then(@"'(.*)' message will appear")]
        public void ThenMessageWillAppear(string msg)
        {
            Waits.WaitForElementVisible(driver, configurationHandlerPage.LblMsgCopy);
            Assert.IsTrue(configurationHandlerPage.LblMsgCopy.Text.Contains(msg), "verified message 'Current copied Configuration Set: Set2' not visisble ");
        }

      
        [When(@"selected another type or same type from list and clicked paste")]
        public void WhenSelectedAnotherTypeOrSameTypeFromListAndClickedPaste()
        {
            configurationHandlerPage.SelectExistingConfigurationSet(newConfigurationSetName);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnPaste);
        }

        [Then(@"A pop-up will appear to enter new name for the copying set")]
        public void ThenAPop_UpWillAppearToEnterNewNameForTheCopyingSet()
        {
            Waits.WaitForElementVisible(driver, configurationHandlerPage.LblTitlePastePopUp);
            Assert.IsTrue(configurationHandlerPage.LblTitlePastePopUp.Text.Contains(GlobalConstants.TitlePastePopUp), "Verified Paste pop up title not exists");
        }

        [When(@"Entered name and clicked ok")]
        public void WhenEnteredNameAndClickedOk()
        {
            Waits.WaitForElementVisible(driver, configurationHandlerPage.TxtBoxNewNamePastePopUp);
            configurationHandlerPage.TxtBoxNewNamePastePopUp.SendKeys(configurationSetName);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnPastePopUp);
        }

        [Then(@"The profile should be copied to the selected node with new name\.")]
        public void ThenTheProfileShouldBeCopiedToTheSelectedNodeWithNewName_()
        {
            Waits.Wait(driver, 20000);
            Assert.IsTrue(configurationHandlerPage.CheckConfigurationSetExists(configurationSetName), "Checked copied configuaration set not exists");
        }

        [Then(@"The set '(.*)' should be deleted")]
        public void ThenTheSetShouldBeDeleted( string setName )
        {
            Waits.Wait(driver, 8000);
            Assert.IsTrue(!(configurationHandlerPage.CheckConfigurationSetExists(setName)), "Checked selected configuaration set not deleted");
        }

        [When(@"Selected created configuaration sets and clicked compare button")]
        public void WhenSelectedCreatedConfiguarationSetsAndClickedCompareButton()
        {
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Control).Build().Perform();
            configurationHandlerPage.SelectExistingConfigurationSet("Set3");
            Waits.Wait(driver, 8000);
            JavaScriptExecutor.JavaScriptClick(driver, configurationHandlerPage.BtnCompare);
        }

        [Then(@"pop up should appear")]
        public void ThenPopUpShouldAppear()
        {
            Waits.WaitForElementVisible(driver, configurationHandlerPage.LblComparePopUpTitle);
            configurationHandlerPage.LblComparePopUpTitle.Text.Contains(GlobalConstants.TitleComparePopUp);
        }

        [When(@"clicked same radio button")]
        public void WhenClickedDifferenceRadioButton()
        {
           
           Waits.WaitAndClick(driver, configurationHandlerPage.RdoBtnSame);
        }

        [Then(@"similar parameters should shown")]
        public void ThenSimilarParametersShouldShown()
        {
            try
            {
                Waits.Wait(driver, 15000);
                Assert.IsTrue(configurationHandlerPage.CompareResults(), "Verfied result");
                Waits.WaitAndClick(driver, configurationHandlerPage.BtnClose);
            }
            finally
            {
                Waits.Wait(driver, 3000);
                configurationHandlerPage.SelectExistingConfigurationSet("Set4");
                WhenSelectedTheSetAndClicked("Set3", "Delete");
                Waits.WaitForElementVisible(driver, configurationHandlerPage.TblConfiguarationSets);
                WhenSelectedTheSetAndClicked("Set4", "Delete");
            }

        }

        [Then(@"deleted copied folder")]
        public void ThenDeletedCopiedFolder()
        {
            configurationHandlerPage.SelectExistingConfigurationSet(configurationSetName);
            Waits.WaitForElementVisible(driver, configurationHandlerPage.BtnDelete);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnDelete);
            Waits.WaitForElementVisible(driver, configurationHandlerPage.BtnConfirm);
            Waits.WaitAndClick(driver, configurationHandlerPage.BtnConfirm);
            Waits.WaitForElementVisible(driver, configurationHandlerPage.TblConfiguarationSets);
        }
    }
}
