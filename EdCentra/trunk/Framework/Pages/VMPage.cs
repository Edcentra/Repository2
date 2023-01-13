using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class VMPage : PageBase
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializing page
        /// </summary>
        /// <param name="driver"></param>
        public VMPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for userpage
        #region
        [FindsBy(How = How.Id, Using = "username-label")]
        private IWebElement lblUserName { get; set; }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement btnLogin { get; set; }

        [FindsBy(How = How.Id, Using = "details-button")]
        private IWebElement btnAdvanced { get; set; }

        [FindsBy(How = How.Id, Using = "proceed-link")]
        private IWebElement lnkProceed { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@src='images/esxi.png']")]
        private IWebElement imgVmware;

        [FindsBy(How = How.XPath, Using = "//span[contains(@title, 'SSISINAS172')]")]
        private IWebElement vmName;

        [FindsBy(How = How.XPath, Using = "//p[contains(@title,'Microsoft Windows Server 2016 (64-bit)')]")]
        private IWebElement lnkActions;

        [FindsBy(How = How.XPath, Using = "//a[@ng-if='!d.divider'][contains(.,'Snapshots')]")]
        private IWebElement lnkSnapshots;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Manage snapshots')]")]
        private IWebElement lnkManageSnapshots;

        [FindsBy(How = How.XPath, Using = "//span[contains(@title, 'Manage snapshots - SSISINAS172')]")]
        private IWebElement manageSnapshotsPopUpTitle;

        [FindsBy(How = How.XPath, Using = "(//span[contains(.,'Restore VM')])")]
        private IWebElement lblRestoreVM;

        [FindsBy(How = How.XPath, Using = "//span[@ng-if='action.label'][contains(.,'Restore snapshot')]")]
        private IWebElement lnkRestoreSnapshot;

        [FindsBy(How = How.XPath, Using = "//button[@type='button'][contains(.,'Restore')]")]
        private IWebElement btnRestore;

        [FindsBy(How = How.XPath, Using = "//button[contains(@ng-click,'vuiDialog.onOk()')]")]
        private IWebElement btnClose;

        [FindsBy(How = How.XPath, Using = "(//em[contains(@class,'esx-icon-task')])[1]")]
        private IWebElement iconRecentTasks;

        [FindsBy(How = How.XPath, Using = "//th[contains(@data-title, 'Queued')]")]
        private IWebElement lblQueued;
       
        [FindsBy(How = How.XPath, Using = "//span[@class='k-link'][contains(.,'Sort descending')]")]
        private IWebElement lblSortDescending;

        [FindsBy(How = How.XPath, Using = "(//i[@class='task-icon-succeeded'][contains(.,'Completed successfully')])[1]")]
        private IWebElement lblResult;

        [FindsBy(How =How.Id, Using = "openConsoleButton")]
        private IWebElement lnkConsole;

        [FindsBy(How =How.XPath, Using = "//span[contains(.,'Open browser console')]")]
        private IWebElement lnkOpenBrowserConsole;

        [FindsBy(How =How.XPath, Using = "//a[contains(.,'Guest OS')]")]
        private IWebElement lnkGuestOS;

        [FindsBy(How =How.XPath, Using = "//span[contains(.,'Send keys')]")]
        private IWebElement lnkSendKeys;

        [FindsBy(How =How.XPath, Using = "//span[contains(.,'Ctrl-Alt-Delete')]")]
        private IWebElement unlockScreenKey;

        [FindsBy(How =How.Id, Using = "mainCanvas")]
        private IWebElement txtBoxPassword;

        [FindsBy(How = How.XPath, Using = "//em[contains(@title, 'Close')]")]
        private IWebElement btnCloseConsole;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'vui-panel app-panel-side left')]")]
        private IWebElement lstVMName;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'esx-main-content')]")]
        private IWebElement lstAllVMName;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'vui-popup vui-dialog ui-resizable ui-draggable')]")]
        private IWebElement lblmanageSnapshotsPopUpTitle;

        [FindsBy(How = How.XPath, Using = "//div[@vui-tree-view='treeViewOptions']")]
        private IWebElement lstSnapShot;

        [FindsBy(How = How.XPath, Using = "//span[contains(@title, 'Virtual Machines')]")]
        private IWebElement lnkVirtualMachines;

        #endregion

        //Properties
        #region
        public IWebElement LblUserName
        {
            get
            {
                return lblUserName;
            }
            set
            {
                lblUserName = value;
            }
        }

        public IWebElement TxtBoxPassword
        {
            get
            {
                return txtBoxPassword;
            }
            set
            {
                txtBoxPassword = value;
            }
        }

        public IWebElement UnlockScreenKey
        {
            get
            {
                return unlockScreenKey;
            }
            set
            {
                unlockScreenKey = value;
            }
        }

        public IWebElement BtnCloseConsole
        {
            get
            {
                return btnCloseConsole;
            }
            set
            {
                btnCloseConsole = value;
            }
        }
        public IWebElement LnkSendKeys
        {
            get
            {
                return lnkSendKeys;
            }
            set
            {
                lnkSendKeys = value;
            }
        }

        public IWebElement LnkGuestOS
        {
            get
            {
                return lnkGuestOS;
            }
            set
            {
                lnkGuestOS = value;
            }
        }
        public IWebElement LnkOpenBrowserConsole
        {
            get
            {
                return lnkOpenBrowserConsole;
            }
            set
            {
                lnkOpenBrowserConsole = value;
            }
        }
        public IWebElement LblResult
        {
            get
            {
                return lblResult;
            }
            set
            {
                lblResult = value;
            }
        }

        public IWebElement LnkConsole
        {
            get
            {
                return lnkConsole;
            }
            set
            {
                lnkConsole = value;
            }
        }

        public IWebElement LblQueued
        {
            get
            {
                return lblQueued;
            }
            set
            {
                lblQueued = value;
            }
        }

        public IWebElement LblSortDescending
        {
            get
            {
                return lblSortDescending;
            }
            set
            {
                lblSortDescending = value;
            }
        }

        public IWebElement TxtUserName
        {
            get
            {
                return txtUserName;
            }
            set
            {
                txtUserName = value;
            }
        }

        public IWebElement TxtPassword
        {
            get
            {
                return txtPassword;
            }
            set
            {
                txtPassword = value;
            }
        }

        public IWebElement IconRecentTasks
        {
            get
            {
                return iconRecentTasks;
            }
            set
            {
                iconRecentTasks = value;
            }
        }

        public IWebElement BtnLogin
        {
            get
            {
                return btnLogin;
            }
            set
            {
                btnLogin = value;
            }
        }

        public IWebElement BtnAdvanced
        {
            get
            {
                return btnAdvanced;
            }
            set
            {
                btnAdvanced = value;
            }
        }

        public IWebElement ProceedLink
        {
            get
            {
                return lnkProceed;
            }
            set
            {
                lnkProceed = value;
            }
        }

        public IWebElement ImgVmware
        {
            get
            {
                return imgVmware;
            }
            set
            {
                imgVmware = value;
            }
        }

        public IWebElement VmName
        {
            get
            {
                return vmName;
            }
            set
            {
                vmName = value;
            }
        }

        public IWebElement LnkActions
        {
            get
            {
                return lnkActions;
            }
            set
            {
                lnkActions = value;
            }
        }

        public IWebElement LnkSnapshots
        {
            get
            {
                return lnkSnapshots;
            }
            set
            {
                lnkSnapshots = value;
            }
        }

        public IWebElement LnkManageSnapshots
        {
            get
            {
                return lnkManageSnapshots;
            }
            set
            {
                lnkManageSnapshots = value;
            }
        }

        public IWebElement ManageSnapshotsPopUpTitle
        {
            get
            {
                return manageSnapshotsPopUpTitle;
            }
            set
            {
                manageSnapshotsPopUpTitle = value;
            }
        }

        public IWebElement LblRestoreVM
        {
            get
            {
                return lblRestoreVM;
            }
            set
            {
                lblRestoreVM = value;
            }
        }

        public IWebElement LnkRestoreSnapshot
        {
            get
            {
                return lnkRestoreSnapshot;
            }
            set
            {
                lnkRestoreSnapshot = value;
            }
        }

        public IWebElement BtnRestore
        {
            get
            {
                return btnRestore;
            }
            set
            {
                btnRestore = value;
            }
        }

        public IWebElement BtnClose
        {
            get
            {
                return btnClose;
            }
            set
            {
                btnClose = value;
            }
        }

        public IWebElement LnkVirtualMachines
        {
            get
            {
                return lnkVirtualMachines;
            }
            set
            {
                lnkVirtualMachines = value;
            }
        }

        #endregion

        //Method
        #region

        /// <summary>
        /// Restore Selected VM
        /// </summary>
        /// <param name="vmName"></param>
        /// <param name="snapShotName"></param>
        public void RestoreVM(string vmName, string snapShotName)
        {
            GetVM(vmName);
            SelectManageSnapshot();
            SelectSnapshot(snapShotName);
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, lnkRestoreSnapshot);
            Waits.Wait(driver, 2000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, btnRestore);
            Waits.WaitForElementVisible(driver, btnRestore);
            btnRestore.Click();
            Waits.WaitAndClick(driver, btnClose);
        }

        /// <summary>
        /// To Select the VM under list
        /// </summary>
        /// <param name="vmName"></param>
        public void GetVM(string vmName)
        {
            Waits.WaitForElementVisible(driver, lstVMName);
            List<IWebElement> VMList = new List<IWebElement>(lstAllVMName.FindElements(By.XPath("//table//tbody//tr//td//div//a")));
            if (VMList.Count > 0)
            {
                foreach (var machinename in VMList)
                {
                    if (machinename.Text.Contains(vmName))
                    {
                        Waits.WaitAndClick(driver, machinename);
                        Waits.Wait(driver, 3000);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Select Manage Snopshot Option
        /// </summary>
        public void SelectManageSnapshot()
        {
            try
            {
                ElementExtensions.RightClick(driver, lnkActions);
                Waits.WaitForElementVisible(driver, lnkSnapshots);
                lnkSnapshots.Click();
                ElementExtensions.MouseHover(driver, lnkManageSnapshots);
                lnkManageSnapshots.Click();
                Waits.Wait(driver, 2000);
            }
            catch (Exception ex)
            {
                SelectManageSnapshot();
            }
        }

        /// <summary>
        /// Verify the Snapshot PopUp
        /// </summary>
        /// <param name="snapName"></param>
        /// <returns></returns>
        public bool SnapShotPopUp(string snapName)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lblmanageSnapshotsPopUpTitle);
            List<IWebElement> snapList = new List<IWebElement>(lblmanageSnapshotsPopUpTitle.FindElements(By.XPath("//div//span")));
            if (snapList.Count > 0)
            {
                foreach (var snapshot in snapList)
                {
                    if (snapshot.Text.Contains(snapName))
                    {
                        flag = true;
                        Waits.Wait(driver, 1000);
                        break;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// To Select SnapShot
        /// </summary>
        /// <param name="snapshotName"></param>
        public void SelectSnapshot(string snapshotName)
        {
            Waits.WaitForElementVisible(driver, lstSnapShot);
            List<IWebElement> snapList = new List<IWebElement>(lstSnapShot.FindElements(By.XPath("//ul//li//div//span")));
            if (snapList.Count > 0)
            {
                foreach (var snapshot in snapList)
                {
                    if (snapshot.Text.Contains(snapshotName))
                    {
                        Waits.WaitAndClick(driver, snapshot);
                        Waits.Wait(driver, 1000);
                        break;
                    }
                }
            }
        }

        #endregion
    }
}
