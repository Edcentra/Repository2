using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edwards.Scada.Test.Framework.Pages
{
    class EdwardsIOControllerPage : PageBase
    {
        IWebDriver driver;
        public EdwardsIOControllerPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for EdwardsIOControllerPage
        #region

        [FindsBy(How = How.XPath, Using = "//div[@class='modalManualPopup']//span[contains(.,'Create a new profile')]")]
        private IWebElement lblProfileDialoguebox;

        [FindsBy(How = How.Id, Using = "divProfiles")]
        private IWebElement lstProfiles;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnDelete')]")]
        private IWebElement btnDeleteProfile;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnOkConfirm')]")]
        private IWebElement btnOkConfirm;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnOKMessage')]")]
        private IWebElement btnOKMessage;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnNew')]")]
        private IWebElement btnNew;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_txtNewName']")]
        private IWebElement txtNewName;       

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'lnkParameters')]")]
        private IWebElement tabParameters;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'lnkFunctions')]")]
        private IWebElement tabFunction;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'lnkAlerts')]")]
        private IWebElement tabAlerts;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'lnkAssignments')]")]
        private IWebElement tabAssignments;

        [FindsBy(How = How.XPath, Using = "//*[@id= 'ctl00_ctl00_cphContent_cphContent_gvParameters']")]
        private IWebElement lstprofileParameters;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_gvParameters_ctl02_txtOverrideParameterName')]")]
        private IWebElement txtOverrideParameterName1;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_gvParameters_ctl03_txtOverrideParameterName')]")]
        private IWebElement txtOverrideParameterName2;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtOverrideScaling')]")]
        private IWebElement txtOverrideScaling;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtOverrideOffset')]")]
        private IWebElement txtOverrideOffset;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlUnit')]")]
        private IWebElement dropdownlistUnit;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnApply')]")]
        private IWebElement btnApply;

        [FindsBy(How = How.XPath, Using = "//span[@id='lblFeedback']")]
        private IWebElement lblFeedback;

        [FindsBy(How = How.XPath, Using = "//*[@id= 'ctl00_ctl00_cphContent_cphContent_gvFunctions']")]
        private IWebElement lstFuctions;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlBooleanOperations')]")]
        private IWebElement ddlBooleanOperations;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlInputParameter1')]")]
        private IWebElement ddlInputParameter1;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlInputParameter2')]")]
        private IWebElement ddlInputParameter2;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlAlertParameter')]")]
        private IWebElement ddlAlertParameter;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlAlertPriority')]")]
        private IWebElement ddlAlertPriority;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtAlertMessage')]")]
        private IWebElement txtAlertMessage;

        [FindsBy(How = How.XPath, Using = "//*[@id= 'ctl00_ctl00_cphContent_cphContent_gvAlerts_ctl02_lnkAdd']")]
        private IWebElement lnkAdd;

        [FindsBy(How = How.XPath, Using = "//*[@id= 'ctl00_ctl00_cphContent_cphContent_gvAlerts']")]
        private IWebElement lstAlerts;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnExport')]")]
        private IWebElement btnExport;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnImport')]")]
        private IWebElement btnImport;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalManualPopup']//span[contains(.,'Import Profile')]")]
        private IWebElement lblImportProfile;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnOkImport')]")]
        private IWebElement btnOkImport;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblImportMessage")]
        private IWebElement lblImportMessage;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtImportName')]")]
        private IWebElement txtImportName;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'uplProfile')]")]
        private IWebElement uplProfile;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnGetSystems")]
        private IWebElement btnGetSystems;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnOKNew')]")]
        private IWebElement btnOKNew; 

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblNewMessage')]")]
        private IWebElement lblNewMessage;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnCloseNew')]")]
        private IWebElement btnCloseNew;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clSelectedSystems_divListControl")]
        private IWebElement lstSelectedEquipmentType;
         
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnDuplicate')]")]
        private IWebElement btnDuplicate;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtConfirm')]")]
        private IWebElement txtConfirm;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnCancelConfirm')]")]
        private IWebElement btnCancelConfirm;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblConfirmMessage')]")]
        private IWebElement lblConfirmMessage;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnRename')]")]
        private IWebElement btnRename;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl01_lblLinkText")]
        private IWebElement lnkHome;


        #endregion

        //Property for EdwardsIOControllerPage
        #region
        public IWebElement LnkHome
        {
            get
            {
                return lnkHome;
            }
            set
            {
                lnkHome = value;
            }
        }
        public IWebElement LblProfileDialoguebox
        {
            get { return lblProfileDialoguebox; }
            set { lblProfileDialoguebox = value; }
        }

        public IWebElement BtnDeleteProfile
        {
            get { return btnDeleteProfile; }
            set { btnDeleteProfile = value; }
        }

        public IWebElement TxtNewName
        {
            get { return txtNewName; }
            set { txtNewName = value; }
        }

        public IWebElement BtnNew
        {
            get { return btnNew; }
            set { btnNew = value; }
        }        

        public IWebElement TabParameters
        {
            get { return tabParameters; }
            set { tabParameters = value; }
        }

        public IWebElement TabFunction
        {
            get { return tabFunction; }
            set { tabFunction = value; }
        }

        public IWebElement TabAlerts
        {
            get { return tabAlerts; }
            set { tabAlerts = value; }
        }

        public IWebElement TabAssignments
        {
            get { return tabAssignments; }
            set { tabAssignments = value; }
        }

        public IWebElement LblFeedback
        {
            get { return lblFeedback; }
            set { lblFeedback = value; }
        }

        public IWebElement LblImportProfile
        {
            get { return lblImportProfile; }
            set { lblImportProfile = value; }
        }

        public IWebElement LblImportMessage
        {
            get { return lblImportMessage; }
            set { lblImportMessage = value; }
        }

        public IWebElement TxtImportName
        {
            get { return txtImportName; }
            set { txtImportName = value; }
        }

        public IWebElement TxtOverrideParameterName1
        {
            get { return txtOverrideParameterName1; }
            set { txtOverrideParameterName1 = value; }
        }

        public IWebElement TxtOverrideParameterName2
        {
            get { return txtOverrideParameterName2; }
            set { txtOverrideParameterName2 = value; }
        }

        public IWebElement DdlAlertParameter
        {
            get { return ddlAlertParameter; }
            set { ddlAlertParameter = value; }
        }

        public IWebElement BtnGetSystems
        {
            get { return btnGetSystems; }
            set { btnGetSystems = value; }
        }

        public IWebElement BtnOKNew
        {
            get { return btnOKNew; }
            set { btnOKNew = value; }
        }

        public IWebElement LblNewMessage
        {
            get { return lblNewMessage; }
            set { lblNewMessage = value; }
        }

        public IWebElement BtnCloseNew
        {
            get { return btnCloseNew; }
            set { btnCloseNew = value; }
        }

        public IWebElement BtnDuplicate
        {
            get { return btnDuplicate; }
            set { btnDuplicate = value; }
        }

        public  IWebElement TxtConfirm
        {
            get { return txtConfirm; }
            set { txtConfirm = value; }
        }

        public IWebElement BtnCancelConfirm
        {
            get { return btnCancelConfirm; }
            set { btnCancelConfirm = value; }
        }

        public IWebElement BtnOkConfirm
        {
            get { return btnOkConfirm; }
            set { btnOkConfirm = value; }
        }

        public IWebElement LblConfirmMessage
        {
            get { return lblConfirmMessage; }
            set { lblConfirmMessage = value; }
        }

        public IWebElement BtnRename
        {
            get { return btnRename; }
            set { btnRename = value; }
        }

        #endregion

        //Methods
        #region
        /// <summary>
        /// To create profile
        /// </summary>
        /// <param name="ProfileName"></param>
        public void CreateProfile(string ProfileName)
        {
            EnterProfileName(ProfileName);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, btnOKNew);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// Delete Already created profile
        /// </summary>
        /// <param name="ProfileName"></param>
        public void DeleteExistingProfile(string ProfileName)
        {
            SelectCreatedProfile(ProfileName);
            Waits.Wait(driver, 2000);
            ClickOnDeleteButton();
            Waits.Wait(driver, 1000);
            if (!ElementExtensions.isDisplayed(driver, btnOkConfirm))
            {
                ClickOnDeleteButton();
            }
            Waits.WaitAndClick(driver, btnOkConfirm);
            Waits.WaitAndClick(driver, btnOKMessage);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// To select already created profile
        /// </summary>
        /// <param name="ProfileName"></param>
        public void SelectCreatedProfile(string ProfileName)
        {
            try
            {
                Waits.WaitForElementVisible(driver, lstProfiles);
                IWebElement baseTable = lstProfiles;
                List<string> ProfileList = new List<string>();
                ICollection<IWebElement> list = baseTable.FindElements(By.TagName("td"));
                foreach (IWebElement listItem in list)
                {
                    if (listItem.Text.ToLower().Equals(ProfileName.ToLower()))
                    {
                        listItem.Click();
                    }
                }
            }
            catch (StaleElementReferenceException)
            {
                driver.Navigate().Refresh();
                Waits.Wait(driver, 1000);
            }
            catch (NullReferenceException)
            {
                Waits.Wait(driver, 1000);
            }
        }

        /// <summary>
        /// Click delete button
        /// </summary>
        public void ClickOnDeleteButton()
        {
            Waits.WaitForElementVisible(driver, btnDeleteProfile);
            Waits.WaitAndClick(driver, btnDeleteProfile);
        }

        /// <summary>
        /// Enter profileName
        /// </summary>
        /// <param name="ProfileName"></param>
        public void EnterProfileName(string ProfileName)
        {
            Waits.WaitForElementVisible(driver, txtNewName);
            Waits.WaitAndClick(driver, txtNewName);
            txtNewName.SendKeys(ProfileName);
        }

        /// <summary>
        /// To select paraemeter
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="customsDescription"></param>
        /// <param name="customsScaling"></param>
        /// <param name="customsOffSet"></param>
        /// <param name="unit"></param>
        public void ParameterSelection(string parameter, string customsDescription, string customsScaling, string customsOffSet, string unit)
        {
            Waits.WaitForElementVisible(driver, lstprofileParameters);
            SelectParametersCheckBoxes(parameter);
            Waits.Wait(driver, 2000);
            ElementExtensions.EnterTextValue(txtOverrideParameterName1, customsDescription);
            Waits.Wait(driver, 1000);
            ElementExtensions.EnterTextValue(txtOverrideScaling, customsScaling);
            Waits.Wait(driver, 1000);
            ElementExtensions.EnterTextValue(txtOverrideOffset, customsOffSet);
            Waits.Wait(driver, 1000);
            ElementExtensions.SelectByText(dropdownlistUnit, unit);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// To click the checkbox for selected parameter
        /// </summary>
        /// <param name="parameter"></param>
        public void SelectParametersCheckBoxes(string parameter)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstprofileParameters);
            List<IWebElement> lstEle = new List<IWebElement>(lstprofileParameters.FindElements(By.TagName("tr")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (flag == true)
                    {
                        break;
                    }
                    if (ele.Text.Contains(parameter))
                    {
                        List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.TagName("td")));
                        if (lstCol.Count > 0)
                        {
                            foreach (var col in lstCol)
                            {
                                flag = true;
                                JavaScriptExecutor.JavaScriptScrollToElement(driver, col);
                                col.Click();
                                Waits.Wait(driver, 1000);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public bool VerifyParameterValue(string value)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstprofileParameters);
            List<IWebElement> lstEle = new List<IWebElement>(lstprofileParameters.FindElements(By.TagName("tr")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (flag == true)
                    {
                        break;
                    }
                    List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.TagName("span")));
                    if (lstCol.Count > 0)
                    {
                        foreach (var col in lstCol)
                        {
                            if (col.Text.Contains(value))
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// To click apply button
        /// </summary>
        public void ClickOnApply()
        {
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, btnApply);
        }

        /// <summary>
        /// Assignment Value Verification
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool VerifyAssignmentValue(string parameter, string value)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstProfiles);
            List<IWebElement> lstEle = new List<IWebElement>(lstProfiles.FindElements(By.TagName("tr")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (flag == true)
                    {
                        break;
                    }
                    if (ele.Text.Contains(parameter))
                    {
                        List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.TagName("td")));
                        if (lstCol.Count > 0)
                        {
                            foreach (var col in lstCol)
                            {
                                if (col.Text.Contains(value))
                                {
                                    Waits.Wait(driver, 1000);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return flag;
        }


        /// <summary>
        /// To Create Boolean Function
        /// </summary>
        /// <param name="function"></param>
        /// <param name="boolean"></param>
        /// <param name="firstInput"></param>
        /// <param name="secondInput"></param>
        public void FunctionBooleanOperation(string function, string boolean, string firstInput, string secondInput)
        {
            Waits.WaitForElementVisible(driver, lstFuctions);
            SelectFuction(function);
            Waits.Wait(driver, 2000);
            ElementExtensions.SelectByText(ddlBooleanOperations, boolean);
            Waits.Wait(driver, 1000);
            ElementExtensions.SelectByText(ddlInputParameter1, firstInput);
            Waits.Wait(driver, 1000);
            ElementExtensions.SelectByText(ddlInputParameter2, secondInput);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        ///  To select function 
        /// </summary>
        /// <param name="function"></param>
        public void SelectFuction(string function)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstFuctions);
            List<IWebElement> lstEle = new List<IWebElement>(lstFuctions.FindElements(By.TagName("td")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(function))
                    {
                        Waits.Wait(driver, 1000);
                        flag = true;
                        break;
                    }
                }
            }
        }

        public bool VerifySelectedFuction(string expectedText)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstFuctions);
            List<IWebElement> lstEle = new List<IWebElement>(lstFuctions.FindElements(By.TagName("tr")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (flag == true)
                    {
                        break;
                    }
                    List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.TagName("select")));
                    if (lstCol.Count > 0)
                    {
                        for (int i = 0; i < lstCol.Count; i++)
                        {
                            var ret = ElementExtensions.GetSelectedDrpdwnText(lstCol[i]);
                            if (ret.Equals(expectedText))
                            {
                                flag = true;
                            }
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// To Create Alert
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="alertType"></param>
        /// <param name="alertMessage"></param>
        public void AlertCreation(string parameter, string alertType, string alertMessage)
        {
            ElementExtensions.SelectByText(ddlAlertParameter, parameter);
            Waits.Wait(driver, 1000);
            ElementExtensions.SelectByText(ddlAlertPriority, alertType);
            Waits.Wait(driver, 1000);
            ElementExtensions.EnterTextValue(txtAlertMessage, alertMessage);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, lnkAdd);
            Waits.Wait(driver, 1000);
        }

        public bool Alertlistverification(string value)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstAlerts);
            List<IWebElement> lstEle = new List<IWebElement>(lstAlerts.FindElements(By.TagName("td")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(value))
                    {
                        Waits.Wait(driver, 1000);
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        ///  To Click Export Button
        /// </summary>
        public void ClickOnExport()
        {
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, btnExport);
        }

        /// <summary>
        /// Delete if folder is exists
        /// </summary>
        public void DeleteFolderExists()
        {

            DirectoryInfo di = new DirectoryInfo(GlobalConstants.CSVFilePath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        /// <summary>
        /// CSV file exists
        /// </summary>
        /// <returns></returns>
        public bool CSVFileExist(string fileName)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                if (flag)
                {
                    break;
                }
                Waits.Wait(driver, 1000);
                DirectoryInfo di = new DirectoryInfo(GlobalConstants.CSVFilePath);

                foreach (FileInfo file in di.GetFiles())
                {
                    if (file.Name.Contains(fileName))
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
        ///  To Click Import Button
        /// </summary>
        public void ClickOnImport()
        {
            Waits.WaitAndClick(driver, btnImport);
        }

        /// <summary>
        /// Click on  Import confirmation button
        /// </summary>
        public void ClickConfirmImport()
        {
            Waits.WaitAndClick(driver, btnOkImport);
        }

        public void UploadFile(string profileName)
        {
            Waits.WaitAndClick(driver, uplProfile);
            Waits.Wait(driver, 4000);
            string filename = GlobalConstants.CSVFilePath + @"\" + "IOController_Profile_" + profileName + ".csv";
            Waits.Wait(driver, 1000);
            System.Windows.Forms.SendKeys.SendWait(filename);
            Waits.Wait(driver, 1000);
            System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
            Waits.Wait(driver, 4000);
        }

        public bool IsProfileExist(string ProfileName)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstProfiles);
            IWebElement baseTable = lstProfiles;
            List<string> ProfileList = new List<string>();
            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("td"));
            foreach (IWebElement listItem in list)
            {
                if (listItem.Text.ToLower().Equals(ProfileName.ToLower()))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public bool IsEquipmentExist(string equipment)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstSelectedEquipmentType);
            List<IWebElement> lstEle = new List<IWebElement>(lstSelectedEquipmentType.FindElements(By.TagName("tr")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(equipment))
                    {
                        flag = true;
                        Waits.Wait(driver, 1000);
                        break;
                    }
                }
            }
            return flag;
        }

    }
}
#endregion