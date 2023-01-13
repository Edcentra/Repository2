using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Edwards.Scada.Test.Framework.Pages
{
    class PdMPage : PageBase
    {
        private IWebDriver driver;

        public PdMPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for PdM page
        #region 

        [FindsBy(How = How.XPath, Using = "//*[@id='divSettingsMain']/table/tbody/tr[1]/td[2]")]
        private IWebElement lblActivationKey;

        [FindsBy(How = How.Id, Using = "btnUpload")]
        private IWebElement btnUpload;

        [FindsBy(How = How.XPath, Using = "//label[@for,'ActivationKey']")]
        private IWebElement lnkActivation;

        [FindsBy(How = How.XPath, Using = "//input[@id='newProfileName']")]
        private IWebElement textnewProfileName;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'field-validation-error')]")]
        private IWebElement lblNameValidationError;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'uploadedModelFile')]")]
        private IWebElement uploadedModelFile;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_cphSubMenuBar_rptSubMenu_ctl02_hypLink']")]
        private IWebElement tabGraph;

        [FindsBy(How = How.XPath, Using = "//img[contains(@src, 'img/icons/diagnostics_20@2x.png')]")]
        private IWebElement pdmMenuImage;

        [FindsBy(How = How.Id, Using = "newProfileName")]
        private IWebElement txtboxAppName;

        [FindsBy(How = How.XPath, Using = "//*[@id='divNewBox']")]
        private IWebElement lnkImportApp;

        [FindsBy(How = How.Id, Using = "uploadedModelFile")]
        private IWebElement btnImportApp;

        [FindsBy(How = How.XPath, Using = "//*[@id='appId']")]
        private IWebElement drpDownAppName;

        [FindsBy(How = How.XPath, Using = "//*[@id='divLeftBox']/ul")]
        private IWebElement lstAlgorithm;

        [FindsBy(How = How.ClassName, Using = "rightalignedlink")]
        private IWebElement linkViewDetails;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Delete item')]")]
        private IWebElement btnDeleteItemPopUp;

        [FindsBy(How = How.Id, Using = "divLeftContainer")]
        private IWebElement lstLicenses;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'boxlist')]")]
        private IWebElement lstLicenseprofile;

        [FindsBy(How = How.XPath, Using = "//button[contains(@data-bind, 'click: $root.save')]")]
        private IWebElement btnApply;

        [FindsBy(How = How.XPath, Using = "//button[contains(@data-bind, 'click: $root.delete')]")]
        private IWebElement btnDelete;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Delete item')]")]
        private IWebElement btnDeleteItem;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'appId')]")]
        private IWebElement lstAppName;

        [FindsBy(How = How.XPath, Using = "//div[@id ='assignedSystems_divListControl']")]
        private IWebElement lstAssignedSystems;

        [FindsBy(How = How.XPath, Using = "//button[contains(@data-bind,'click: moveTo')]")]
        private IWebElement btnMoveTo;

        [FindsBy(How = How.XPath, Using = "//button[contains(@data-bind,'click: moveFrom')]")]
        private IWebElement btnMoveFrom;

        [FindsBy(How = How.XPath, Using = "//button[contains(@data-bind,'click: moveAllFrom')]")]
        private IWebElement btnMoveAllFrom;

        [FindsBy(How = How.Id, Using = "button-ok")]
        private IWebElement btnOkRemove;

        [FindsBy(How = How.XPath, Using = "//span[@class='infomessage'][contains(.,'Changes have been applied')]")]
        private IWebElement lblApplySuccessMessage;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Close')]")]
        private IWebElement btnCloseRemove;

        [FindsBy(How = How.XPath, Using = "//span[@class='errmessage'][contains(.,'App has systems assigned to it. Please remove them first.')]")]
        private IWebElement lblRemoveFeedback;

        [FindsBy(How = How.Id, Using = "divSettingsMain")]
        private IWebElement lblApplicationName;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnid')]")]
        private IWebElement btnGo;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'unassignedSystems_divListControl')]//tbody")]
        private IWebElement lstUnAssignedSystems;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'ctl00_ctl00_cphContent_cphContent_clstSystems_divListControl')]//tbody")]
        private IWebElement divListControl;

        [FindsBy(How = How.Id, Using = "ctl00_rptMenu_ctl01_hypLink")]
        private IWebElement lnkHomePage;

        [FindsBy(How =How.XPath, Using = "//*[@id='divNewBox']/img")]
        private IWebElement imgAddApp;

        [FindsBy(How = How.XPath, Using = "//*[@id='dialog-delete']/span")]
        private IWebElement lblSuccessDeleteMessage;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Cancel')]")]
        private IWebElement btnCancel;

        [FindsBy(How = How.Id, Using = "lnkErrorCount")]
        private IWebElement lblAlarmCount;

        [FindsBy(How = How.Id, Using = "spnErrorCount")]
        private IWebElement lblErrorCount;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divWarningCount')]")]
        private IWebElement lblWarningCount;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Update')]")]
        private IWebElement btnUpdate;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Create New')]")]
        private IWebElement btnCreateNew;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Cancel')]")]
        private IWebElement btnUpdateCancel;

        [FindsBy(How = How.XPath, Using = "//*[@id='divSettingsMain']")]
        private IWebElement lnkExpiryDate;

        [FindsBy(How = How.XPath, Using = "//a[@href='Components/LiveAlertsList/Default.aspx?fal=alarm']")]
        private IWebElement lnkAlarmCount;

        [FindsBy(How = How.XPath, Using = "//button[@data-bind='click: $root.fullreset']")]
        private IWebElement btnReset;

        [FindsBy(How = How.XPath, Using = "//span[@class='ui-button-text'][contains(.,'Reset')]")]
        private IWebElement btnResetPopUp;

        [FindsBy(How = How.XPath, Using = "//div[@id='divResetMessage']//span[@class='infomessage']")]
        private IWebElement btnResetPopUpMsg;

        [FindsBy(How = How.XPath, Using = "//span[@class='ui-button-text'][contains(.,'Close')]")]
        private IWebElement btnClose;

        [FindsBy(How = How.XPath, Using ="//div[@title = 'Systems In Alarm: 0 (Total Alarms: 0)']")]
        private IWebElement lnkAlarm;
        #endregion

        //Properties
        #region

        public IWebElement ImgAddApp
        {
            get { return imgAddApp; }
            set { imgAddApp = value; }
        }

        public IWebElement DrpDownAppName
        {
            get
            {
                return drpDownAppName;
            }
            set
            {
                drpDownAppName = value;
            }
        }

        public IWebElement BtnImportApp
        {
            get
            {
                return btnImportApp;
            }
            set
            {
                btnImportApp = value;
            }
        }

        public IWebElement LblActivationKey
        {
            get
            {
                return lblActivationKey;
            }
            set
            {
                lblActivationKey = value;
            }
        }

        public IWebElement TabGraph
        {
            get { return tabGraph; }
            set { tabGraph = value; }
        }

        public IWebElement UploadedModelFile
        {
            get { return uploadedModelFile; }
            set { uploadedModelFile = value; }
        }

        public IWebElement PDMMenuImage
        {
            get
            {
                return pdmMenuImage;
            }
            set
            {
                pdmMenuImage = value;
            }
        }

        public IWebElement BtnDelete
        {
            get { return btnDelete; }
            set { btnDelete = value; }
        }

        public IWebElement LinkViewDetails
        {
            get { return linkViewDetails; }
            set { linkViewDetails = value; }
        }

        public IWebElement BtnGo
        {
            get { return btnGo; }
            set { btnGo = value; }
        }

        public IWebElement LblApplySuccessMessage
        {
            get { return lblApplySuccessMessage; }
            set { lblApplySuccessMessage = value; }
        }

        public IWebElement BtnApply
        {
            get { return btnApply; }
            set { btnApply = value; }
        }

        public IWebElement BtnMoveTo
        {
            get { return btnMoveTo; }
            set { btnMoveTo = value; }
        }

        public IWebElement BtnDeleteItem
        {
            get { return btnDeleteItem; }
            set { btnDeleteItem = value; }
        }

        public IWebElement LblSuccessDeleteMessage
        {
            get { return lblSuccessDeleteMessage; }
            set { lblSuccessDeleteMessage = value; }
        }

        public IWebElement BtnCancel
        {
            get { return btnCancel; }
            set { btnCancel = value; }
        }

        public IWebElement LblAlarmCount
        {
            get { return lblAlarmCount; }
            set { lblAlarmCount = value; }
        }

        public IWebElement LblErrorCount
        {
            get { return lblErrorCount; }
            set { lblErrorCount = value; }
        }

        public IWebElement BtnUpdate
        {
            get { return btnUpdate; }
            set { btnUpdate = value; }
        }

        public IWebElement BtnCreateNew
        {
            get { return btnCreateNew; }
            set { btnCreateNew = value; }
        }

        public IWebElement BtnUpdateCancel
        {
            get { return btnUpdateCancel; }
            set { btnUpdateCancel = value; }
        }

        public IWebElement LblWarningCount
        {
            get { return lblWarningCount; }
            set { lblWarningCount = value; }
        }

        public IWebElement LnkExpiryDate
        {
            get { return lnkExpiryDate; }
            set { lnkExpiryDate = value; }
        }

        public IWebElement LnkAlarmCount
        {
            get { return lnkAlarmCount; }
            set { lnkAlarmCount = value; }
        }

        public IWebElement BtnReset
        {
            get { return btnReset; }
            set { btnReset = value; }
        }

        public IWebElement BtnResetPopUp
        {
            get { return btnResetPopUp; }
            set { btnResetPopUp = value; }
        }

        public IWebElement BtnResetPopUpMsg
        {
            get { return btnResetPopUpMsg; }
            set { btnResetPopUpMsg = value; }
        }

        public IWebElement BtnClose
        {
            get { return btnClose; }
            set { btnClose = value; }
        }

        public IWebElement LnkAlarm
        {
            get { return lnkAlarm; }
            set { lnkAlarm = value; }
        }

        #endregion

        //Methods
        #region

        /// <summary>
        /// Get Assembly directory path
        /// </summary>
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        /// <summary>
        /// Get Activation Code
        /// </summary>
        /// <returns></returns>
        public string ActivationCode()
        {
            Waits.Wait(driver, 1000);
            driver.SwitchTo().Frame("ifmMain");
            Waits.Wait(driver, 5000);
            string text = LblActivationKey.Text;
            return text;
        }

        /// <summary>
        /// Enter App Name
        /// </summary>
        /// <param name="appname"></param>
        public void EnterAppName(string appname)
        {
            Waits.WaitForElementVisible(driver, textnewProfileName);
            textnewProfileName.SendKeys(appname);
            Waits.Wait(driver, 2000);
            textnewProfileName.SendKeys(Keys.Tab);
            if (ElementExtensions.isDisplayed(driver, lblNameValidationError))
            {
                Waits.WaitForElementVisible(driver, textnewProfileName);
                textnewProfileName.SendKeys(appname);
                Waits.Wait(driver, 2000);
                textnewProfileName.SendKeys(Keys.Tab);
            }
        }

        /// <summary>
        /// Uploads License file
        /// </summary>
        public void UploadLicense(string algorithmName)
        {
            string path = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\..\..\..\..\..\"));
            path = Path.Combine(path + algorithmName);
            if (File.Exists(path))
            {
                // If file found, Select it    
                Thread.Sleep(5000);
                System.Windows.Forms.SendKeys.SendWait(path);
                Waits.Wait(driver, 5000);
                System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
                Waits.Wait(driver, 1000);
            }
            Waits.WaitAndClick(driver, btnUpload);
            Waits.Wait(driver, 2000);
        }

        /// <summary>
        /// Gets list of Algorithm name for uploaded license
        /// </summary>
        /// <returns></returns>
        public List<string> GetAlgorithmNameFromList()
        {
            List<string> algoName = new List<string>();
            List<IWebElement> algoList = new List<IWebElement>(lstAlgorithm.FindElements(By.TagName("li")));
            foreach (var algo in algoList)
            {
                algoName.Add(algo.Text);
            }
            return algoName;
        }

        /// <summary>
        /// Is App Exists
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        public bool IsAppExists(string appName)
        {
            bool flag = false;
            for (int i = 1; i <= 10; i++)
            {
                if (flag)
                {
                    break;
                }
                Waits.WaitForElementVisible(driver, drpDownAppName);
                List<IWebElement> list = new List<IWebElement>(drpDownAppName.FindElements(By.TagName("option")));
                foreach (IWebElement listItem in list)
                {
                    if (listItem.Text.ToLower().Contains(appName.ToLower()))
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
           return flag;
        }

        /// <summary>
        /// Select already Craeted App
        /// </summary>
        /// <param name="appName"></param>
        public void SelectCreatedApp(string appName)
        {
            bool flag = false;
            for (int i = 1; i <= 10; i++)
            {
                if (flag)
                {
                    break;
                }
                Waits.WaitForElementVisible(driver, drpDownAppName);
                List<IWebElement> listAppName = new List<IWebElement>(drpDownAppName.FindElements(By.TagName("option")));
                foreach (IWebElement listItem in listAppName)
                {
                    if (listItem.Text.ToLower().Contains(appName.ToLower()))
                    {
                        flag = true;
                        listItem.Click();
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Delete Already Created App
        /// </summary>
        /// <param name="appName"></param>
        public void DeleteExistingApp(string appName)
        {
            Waits.Wait(driver, 1000);
            driver.Navigate().Refresh();
            Waits.Wait(driver, 5000);
            driver.SwitchTo().Frame("ifmMain");
            SelectCreatedApp(appName);
            Waits.WaitAndClick(driver, linkViewDetails);
            Waits.Wait(driver, 5000);
            driver.FindElement(By.XPath("//button[contains(@data-bind, 'click: $root.delete')]")).Click();
            Waits.WaitAndClick(driver, btnDeleteItemPopUp);
            if (ElementExtensions.isDisplayed(driver, lblRemoveFeedback))
            {
                MoveAssignedSystem();
                Waits.Wait(driver, 1000);
                Waits.WaitAndClick(driver, btnApply);
                Waits.WaitForElementVisible(driver, lblApplySuccessMessage, 2000);
                Waits.WaitAndClick(driver, btnDelete);
                Waits.Wait(driver, 1000);
                Waits.WaitAndClick(driver, btnDeleteItem);
            }
        }
        
        /// <summary>
        /// Is Algorithm Exists
        /// </summary>
        /// <param name="algoname"></param>
        /// <returns></returns>
        public bool IsAlgorithmExist(string algoName)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstLicenses);
            List<IWebElement> LicenseList = new List<IWebElement>(lstLicenses.FindElements(By.XPath("//ul//li//a//div//div//div[2]")));

            if (LicenseList.Count() > 0)
            {
                foreach (IWebElement listItem in LicenseList)
                {
                    if (listItem.Text.Contains(algoName))
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        flag = false;
                        continue;
                    }
                }
            }
            if (flag == false)
            {
                Waits.WaitForElementVisible(driver, lstLicenseprofile);
                List<IWebElement> newLicenseProfileList = new List<IWebElement>(lstLicenseprofile.FindElements(By.TagName("div")));
                Waits.Wait(driver, 2000);
                if (newLicenseProfileList.Count() > 0)
                {
                    foreach (IWebElement listItem in newLicenseProfileList)
                    {
                        if (listItem.Text.ToLower().Contains(algoName.ToLower()))
                        {
                            flag = true;
                            break;
                        }
                        else
                        {
                            flag = false;
                            continue;
                        }

                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// Delete the already created App 
        /// </summary>
        /// <param name="appName"></param>
        public void DeleteProfile(string appName)
        {
            SelectCreatedApp(appName);
            driver.Navigate().Refresh();
            driver.SwitchTo().Frame("ifmMain");
            Waits.WaitAndClick(driver, linkViewDetails);
            Waits.WaitAndClick(driver, btnDelete);
            Waits.WaitAndClick(driver, btnDeleteItem);
            if (ElementExtensions.isDisplayed(driver, lblRemoveFeedback))
            {
                MoveAssignedSystem();
                Waits.Wait(driver, 1000);
                Waits.WaitAndClick(driver, btnApply);
                Waits.WaitForElementVisible(driver, lblApplySuccessMessage, 2000);
                Waits.WaitAndClick(driver, btnDelete);
                Waits.Wait(driver, 1000);
                Waits.WaitAndClick(driver, btnDeleteItem);
            }
        }

        /// <summary>
        /// Move Assigned Equipments
        /// </summary>
        public void MoveAssignedSystem()
        {
            Actions ac = new Actions(driver);
            for (int i = 1; i <= 10; i++)
            {
                Waits.WaitForElementVisible(driver, lstAssignedSystems);
                List<IWebElement> lstEle = new List<IWebElement>(lstAssignedSystems.FindElements(By.TagName("tr")));
                if (lstEle.Count > 0)
                {
                    if (lstEle.Count == 1)
                    {
                        lstEle[0].Click();
                        Waits.WaitAndClick(driver, btnMoveFrom);
                        Waits.WaitAndClick(driver, btnApply);
                        Waits.WaitAndClick(driver, btnOkRemove);
                        Waits.WaitForElementVisible(driver, lblApplySuccessMessage, 2000);
                        Waits.WaitAndClick(driver, btnCloseRemove);
                        break;
                    }
                    else if (lstEle.Count > 1)
                    {
                        lstEle[0].Click();
                        ac.SendKeys(Keys.Shift).Perform();
                        JavaScriptExecutor.JavaScriptScrollToElement(driver, lstEle.Last());
                        lstEle.Last().Click();
                        Waits.WaitAndClick(driver, btnMoveAllFrom);
                        Waits.WaitAndClick(driver, btnApply);
                        Waits.WaitAndClick(driver, btnOkRemove);
                        Waits.WaitForElementVisible(driver, lblApplySuccessMessage, 2000);
                        Waits.WaitAndClick(driver, btnCloseRemove);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Is Selection Exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool SelectionIsExists(string name)
        {
            bool flag = false;
            for (int i = 1; i <= 10; i++)
            {
                if (flag)
                {
                    break;
                }
                Waits.WaitForElementVisible(driver, lblApplicationName);
                ICollection<IWebElement> list = lblApplicationName.FindElements(By.TagName("span"));
                foreach (IWebElement listItem in list)
                {
                    if (listItem.Text.ToLower().Contains(name.ToLower()))
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
             return flag;
        }

        /// <summary>
        /// Select already created algorithm
        /// </summary>
        /// <param name="algoName"></param>
        public void SelectCreatedAlgorithm(string algoName)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstLicenses);
            List<IWebElement> LicenseList = new List<IWebElement>(lstLicenses.FindElements(By.XPath("//ul//li//a//div//div//div[2]")));

            if (LicenseList.Count() > 0)
            {
                foreach (IWebElement listItem in LicenseList)
                {
                    if (listItem.Text.Contains(algoName))
                    {
                        flag = true;
                        listItem.Click();
                        break;
                    }
                    else
                    {
                        flag = false;
                        continue;
                    }
                }
            }
            if (flag == false)
            {
                Waits.WaitForElementVisible(driver, lstLicenseprofile);
                List<IWebElement> newLicenseProfileList = new List<IWebElement>(lstLicenseprofile.FindElements(By.TagName("div")));
                Waits.Wait(driver, 2000);
                if (newLicenseProfileList.Count() > 0)
                {
                    foreach (IWebElement listItem in newLicenseProfileList)
                    {
                        if (listItem.Text.ToLower().Contains(algoName.ToLower()))
                        {
                            flag = true;
                            listItem.Click();
                            break;
                        }
                        else
                        {
                            flag = false;
                            continue;
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Is UnAssignedSystem Exists
        /// </summary>
        /// <param name="eqipmentName"></param>
        /// <returns></returns>
        public bool IsListedUnAssignedSystem(string equipmentName)
        {
            bool flag = false;
            for (int i = 1; i <= 10; i++)
            {
                if (flag)
                {
                    break;
                }
                Waits.WaitForElementVisible(driver, lstUnAssignedSystems);
                List<IWebElement> lstEle = new List<IWebElement>(lstUnAssignedSystems.FindElements(By.TagName("tr")));
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(equipmentName))
                        {
                            flag = true;
                            break;
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// Select Equipment from List
        /// </summary>
        /// <param name="equipmentName"></param>
        public void SelectEquipment(string equipmentName)
        {
            bool flag = false;
            for (int i = 1; i <= 10; i++)
            {
                if (flag)
                {
                    break;
                }
                Waits.WaitForElementVisible(driver, lstUnAssignedSystems);
                List<IWebElement> lstEle = new List<IWebElement>(lstUnAssignedSystems.FindElements(By.TagName("tr")));
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(equipmentName))
                        {
                            flag = true;
                            ele.Click();
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Move Selected Equipment
        /// </summary>
        /// <param name="equipmentName"></param>
        public void MoveEquipment(string equipmentName)
        {
            SelectEquipment(equipmentName);
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, btnMoveTo);
        }

        /// <summary>
        /// Is AssignedSystem Exists
        /// </summary>
        /// <param name="eqipmentName"></param>
        /// <returns></returns>
        public bool IsListedAssignedSystem(string equipmentName)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstAssignedSystems);
            List<IWebElement> lstEle = new List<IWebElement>(lstAssignedSystems.FindElements(By.TagName("tr")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(equipmentName))
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// Move UnAssigned Equipment 
        /// </summary>
        /// <param name="appName"></param>
        public void Dissociate(string appName)
        {
            SelectCreatedApp(appName);
            Waits.WaitAndClick(driver, linkViewDetails);
            MoveAssignedSystem();
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, btnApply);
        }

        /// <summary>
        /// Is License Exists
        /// </summary>
        /// <param name="algorithmName"></param>
        /// <returns></returns>
        public bool IsLicenseExist(string licenseName)
        {
            bool flag = false;
            string path = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\..\..\..\..\..\"));
            path = Path.Combine(path + licenseName);
            if (File.Exists(path))
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// Select Equipment from List
        /// </summary>
        /// <param name="equipmentName"></param>
        public void SelectAssignedEquipment(string equipmentName)
        {
            bool flag = false;
            for (int i = 1; i <= 10; i++)
            {
                if (flag)
                {
                    break;
                }
                try
                {
                    //driver.SwitchTo().Frame("ifmMain");
                    Waits.Wait(driver, 3000);
                    IWebElement ele1 = driver.FindElement(By.XPath("//div[@id ='assignedSystems_divListControl']"));
                    List<IWebElement> lstEle = new List<IWebElement>(lstAssignedSystems.FindElements(By.TagName("tr")));
                    if (lstEle.Count > 0)
                    {
                        foreach (var ele in lstEle)
                        {
                            if (ele.Text.Contains(equipmentName))
                            {
                                flag = true;
                                ele.Click();
                                Waits.Wait(driver, 1000);
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }

                    }
                }
                catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                    Waits.Wait(driver, 3000);
                }
                catch (NullReferenceException)
                {
                    Waits.Wait(driver, 3000);
                }
            }
        }

        #endregion
    }
}
