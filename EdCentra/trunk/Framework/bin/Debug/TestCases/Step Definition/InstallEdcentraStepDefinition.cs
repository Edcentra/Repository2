using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class InstallEdcentraStepDefinition
    {
        Simulator simulator = new Simulator();
        private IWebDriver driver;
        VMPage vmPage;
        ConfigurationHandlerPage configurationHandlerPage;

        public InstallEdcentraStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            vmPage = new VMPage(driver);
            configurationHandlerPage = new ConfigurationHandlerPage(driver);
        }

        [Given(@"Go to Installer folder and Launch Edwards\.Installer\.Launcher\.exe file")]
        public void GivenGoToInstallerFolderAndLaunchEdwards_Installer_Launcher_ExeFile()
        {
            driver.Close();
            simulator.LaunchEdcentraInstaller();
        }

        [When(@"Scroll down to accept the software license and support agreement and click on “I Accept”\.")]
        public void WhenScrollDownToAcceptTheSoftwareLicenseAndSupportAgreementAndClickOnIAccept_()
        {
            simulator.ClickDownArrowEdcentraInstaller();
            simulator.ClickIAcceptButton();
        }
        [When(@"Select all three servers option like Agent PC, Application and Database server and Click on Install")]
        public void WhenSelectAllThreeServersOptionLikeAgentPCApplicationAndDatabaseServerAndClickOnInstall()
        {
            // simulator.InstallLatestDotNetFramework();
            Thread.Sleep(4000);
            simulator.SelectServerToInstallSingleServerApplication();
        }

        [Given(@"Launch Agent '(.*)'")]
        public void GivenLaunchAgent(string configuration)
        {
            simulator.LaunchAgent();
            Waits.Wait(driver, 1000);
        }

        //[When(@"Selected Server and clicked on Apply button")]
        //public void WhenSelectedServerAndClickedOnApplyButton()
        //{
        //    simulator.EnterServerDetails();
        //}

        [Given(@"connected to remote agent")]
        public void GivenConnectedToRemoteAgent()
        {
            try
            {
                driver.Close();
                simulator.StartRemoteConnection();
                
            }
            catch(Exception ex)
            {
                Assert.Fail("Error Occured " + ex.Message);
            }
        }

        [Given(@"Go to VM url")]
        public void GivenGoToVMUrl()
        {
            try
            {
                PageInitialization();
                driver.Navigate().GoToUrl(GlobalConstants.VirtualMachineUrl);
                Waits.Wait(driver, 5000);
                if (ElementExtensions.isDisplayed(driver, vmPage.BtnAdvanced))
                {
                    vmPage.BtnAdvanced.Click();
                    vmPage.ProceedLink.Click();
                    Waits.Wait(driver, 5000);
                }
            }
            catch(Exception ex)
            {
                Assert.Fail("Execption occurred" + ex.Message);
            }
        }

        [When(@"Logged in by username '(.*)' and password '(.*)'")]
        public void WhenLoggedInByUsernameAndPassword(string userName, string pwd)
        {
            try
            {
            Waits.WaitForElementVisible(driver, vmPage.LblUserName);
            vmPage.TxtUserName.SendKeys(userName);
            Waits.Wait(driver, 2000);
            vmPage.TxtPassword.SendKeys(pwd);
            vmPage.BtnLogin.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Execption occurred" + ex.Message);
            }

        }

        [When(@"I selected Slave VM")]
        public void WhenISelectedSlaveVM()
        {
            Waits.Wait(driver, 10000);
            try
            {
                Waits.WaitForElementVisible(driver, vmPage.VmName);
                vmPage.VmName.Click();
                Waits.Wait(driver, 5000);
            }
            catch (Exception ex)
            {
                Assert.Fail("Execption occurred" + ex.Message);
            }
        }


        [When(@"Selected Manage Snapshot option under Snapshots")]
        public void WhenSelectedManageSnapshotOptionUnderSnapshots()
        {
            try
            {                
                ElementExtensions.RightClick(driver, vmPage.LnkActions);
                Waits.Wait(driver, 15000);
                Waits.WaitForElementVisible(driver, vmPage.LnkSnapshots);
                vmPage.LnkSnapshots.Click();
                ElementExtensions.MouseHover(driver, vmPage.LnkManageSnapshots);
                vmPage.LnkManageSnapshots.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Execption occurred" + ex.Message);
            }
        }

        [Then(@"I should be navigated to VMWare ESXi page")]
        public void ThenIShouldBeNavigatedToVMWareESXiPage()
        {
            try
            {
                Waits.WaitForElementVisible(driver, vmPage.ImgVmware);
                Assert.IsTrue(vmPage.ImgVmware.Displayed, "VMWare image is not displayed");
                Waits.Wait(driver, 3000);
            }
            catch (Exception ex)
            {
                Assert.Fail("Execption occurred" + ex.Message);
            }
        }

        [Then(@"Manage snapshots pop up should be opened '(.*)'")]
        public void ThenManageSnapshotsPopUpShouldBeOpened(string text)
        {
            try
            {
            Waits.WaitForElementVisible(driver, vmPage.ManageSnapshotsPopUpTitle);
            Assert.AreEqual(text, vmPage.ManageSnapshotsPopUpTitle.Text, "Verified Manage Snapshots pop -up Title");
            Waits.Wait(driver, 3000);
            }
            catch (Exception ex)
            {
                Assert.Fail("Execption occurred" + ex.Message);
            }
}

        [When(@"clicked Restore snapshot")]
        public void WhenClickedRestoreSnapshot()
        {
            try
            {
                vmPage.LnkRestoreSnapshot.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Execption occurred" + ex.Message);
            }
        }

        [When(@"Selected Restore VM")]
        public void WhenSelectedRestoreVM()
        {
            try
            {
                vmPage.LblRestoreVM.Click();
                Waits.Wait(driver, 2000);
            }
            catch (Exception ex)
            {
                Assert.Fail("Execption occurred" + ex.Message);
            }
        }

        [When(@"clicked Restore button")]
        public void WhenClickedRestoreButton()
        {
            try
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, vmPage.BtnRestore);
                Waits.WaitForElementVisible(driver, vmPage.BtnRestore);
                vmPage.BtnRestore.Click();
                Waits.Wait(driver, 2000);
            }
            catch (Exception ex)
            {
                Assert.Fail("Execption occurred" + ex.Message);
            }
        }

        [When(@"clicked close button")]
        public void WhenClickedCloseButton()
        {
            try
            {
            vmPage.BtnClose.Click();
            Waits.Wait(driver, 2000);
            }
             catch (Exception ex)
            {
                Assert.Fail("Execption occurred" + ex.Message);
            }
        }

        [Then(@"after few minutes VM should restore")]
        public void ThenAfterFewMinutesVMShouldRestore()
        {
            try
            {
                Waits.WaitForElementVisible(driver, vmPage.IconRecentTasks);

                JavaScriptExecutor.JavaScriptScrollToElement(driver, vmPage.LblQueued);
                if (!ElementExtensions.isDisplayed(driver, vmPage.LblQueued))
                {
                    ElementExtensions.DoubleClick(driver, vmPage.IconRecentTasks);
                }
                ElementExtensions.RightClick(driver, vmPage.LblQueued);
                JavaScriptExecutor.JavaScriptScrollToElement(driver, vmPage.LblSortDescending);
                vmPage.LblSortDescending.Click();
                Waits.Wait(driver, 10000);
                Waits.WaitForElementVisible(driver, vmPage.LblResult, 120);
                Assert.IsTrue(vmPage.LblResult.Displayed, "Verified VM is reset");
            }
            catch (Exception ex)
            {
                Assert.Fail("Execption occurred" + ex.Message);
            }
        }

        [When(@"Open browser Console")]
        public void WhenOpenBrowserConsole()
        {
            Waits.WaitAndClick(driver, vmPage.LnkConsole);
            Waits.WaitAndClick(driver, vmPage.LnkOpenBrowserConsole);
            Waits.Wait(driver, 8000);
            Waits.WaitForElementVisible(driver, vmPage.VmName);
            ElementExtensions.RightClick(driver, vmPage.VmName);
            Waits.WaitForElementVisible(driver, vmPage.LnkGuestOS);
            ElementExtensions.MouseHover(driver, vmPage.LnkGuestOS);
            ElementExtensions.MouseHover(driver, vmPage.LnkSendKeys);
            Waits.WaitAndClick(driver, vmPage.UnlockScreenKey);
            Waits.Wait(driver, 10000);
            vmPage.TxtBoxPassword.SendKeys("!tikloot9");
            vmPage.TxtBoxPassword.SendKeys(Keys.Enter);
            Waits.Wait(driver, 8000);
          //  vmPage.BtnCloseConsole.Click();
        }

        [Given(@"Find the table fst_SEC_InstalledApplication and choose edit\. Add the number to the row ApplicationID, save and close table\.")]
        public void GivenFindTheTableFst_SEC_InstalledApplicationAndChooseEdit_AddTheNumberToTheRowApplicationIDSaveAndCloseTable_()
        {
            PageInitialization();
            configurationHandlerPage.SetValueInApplicationColumn();
        }

        [When(@"Select servers option Database server and give Application ServerName '(.*)' Click on Install")]
        public void WhenSelectServersOptionDatabaseServerAndGiveApplicationServerNameClickOnInstall(string serverName)
        {
            Thread.Sleep(4000);
            simulator.SelectDataBaseServerToInstall(serverName);
        }

        [When(@"Select servers option Database server and give Application serverName '(.*)' and Database serverName '(.*)' Click on Install")]
        public void WhenSelectServersOptionDatabaseServerAndGiveApplicationServerNameAndDatabaseServerNameClickOnInstall(string appServerName, string dbServerName)
        {
            Thread.Sleep(4000);
            simulator.SelectAgentServerToInstall(appServerName, dbServerName);
        }

        [When(@"Select servers option Database server and give Database serverName '(.*)' Click on Install")]
        public void WhenSelectServersOptionDatabaseServerAndGiveDatabaseServerNameClickOnInstall(string dbServerName)
        {
            Thread.Sleep(4000);
            simulator.SelectApplicationServerToInstall(dbServerName);
        }

        [When(@"I select VMNames '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' and restore the VM's")]
        public void WhenISelectVMNamesAndRestoreTheVMS(string vmName, string snapShotName, string vmName1, string snapShotName1, string vmName2, string snapShotName2)
        {
            string[] vmNames = new string[] { vmName, vmName1, vmName2 };
            string[] snapShotNames = new string[] { snapShotName, snapShotName1, snapShotName2 };
            for (int i = 0; i < 3; i++)
            {
                Waits.Wait(driver, 5000);
                Waits.WaitAndClick(driver, vmPage.LnkVirtualMachines);
                vmPage.RestoreVM(vmNames[i], snapShotNames[i]);
                Waits.Wait(driver, 10000);
            }
        }
    }
}
