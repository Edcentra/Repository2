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
    public class ConfigurePage : PageBase
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializing page
        /// </summary>
        /// <param name="driver"></param>
        public ConfigurePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //object for ConfigureTests
        #region

        [FindsBy(How = How.XPath, Using = "//div[@class='footermenu']//a//span[text()='XNIM Configuration']")]
        private IWebElement lnkXNIMConfiguration;

        [FindsBy(How = How.XPath, Using = "//div[@class='mainmenutitle'][contains(.,'XNIM Configuration')]")]
        private IWebElement lblXNIMConfigurationPage;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_ProfileList_txtName')]")]
        private IWebElement txtXNIMProfileName;

        [FindsBy(How = How.Id, Using = "divctl00_ctl00_cphContent_cphContent_ProfileList_btnAddProfile")]
        private IWebElement btnAddProfile;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_ProfileList_ProfileUpdatePanel')]")]
        private IWebElement lstProfilePanel;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ProfileList_btnDeleteProfile")]
        private IWebElement btnDeleteProfile;

        [FindsBy(How = How.Id, Using = "divctl00_ctl00_cphContent_cphContent_ProfileList_btnOKDelete")]
        private IWebElement btnOKDelete;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_ParameterUpdatePanel')]")]
        private IWebElement lblParametersPanel;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_ParameterList_txtName']")]
        private IWebElement txtParameterName;

        [FindsBy(How = How.Id, Using = "divctl00_ctl00_cphContent_cphContent_ParameterList_btnFunction")]
        private IWebElement btnParameterFunction;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_FormulaPopup_lblTitle')]")]
        private IWebElement lblFunctionTitle;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'operator_1')]")]
        private IWebElement listSetOperator;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'B')]")]
        private IWebElement setSectionCheckbox;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'R')]")]
        private IWebElement lineDividerCheckbox;

        [FindsBy(How = How.Id, Using = "divctl00_ctl00_cphContent_cphContent_FormulaPopup_btnApply")]
        private IWebElement btnApply;

        [FindsBy(How = How.Id, Using = "divctl00_ctl00_cphContent_cphContent_ParameterList_btnAddParameter")]
        private IWebElement btnAddParameter;

        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ctl00_cphContent_cphContent_AlertsUpdatePanel']")]
        private IWebElement lblAlertsPanel;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_AlertList_txtName']")]
        private IWebElement txtAlertName;

        [FindsBy(How = How.Id, Using = "divctl00_ctl00_cphContent_cphContent_AlertList_btnFunction")]
        private IWebElement btnAlertListFunction;

        [FindsBy(How = How.Id, Using = "divctl00_ctl00_cphContent_cphContent_AlertList_btnAddAlert")]
        private IWebElement btnAddAlert;

        [FindsBy(How = How.Id, Using = "divctl00_ctl00_cphContent_cphContent_ProfileList_btnCopy")]
        private IWebElement btnProfileCopy;

        [FindsBy(How = How.Id, Using = "divctl00_ctl00_cphContent_cphContent_AlertList_btnDeleteAlert")]
        private IWebElement btnDeleteAlert;

        [FindsBy(How = How.Id, Using = "divctl00_ctl00_cphContent_cphContent_ParameterList_btnDeleteParameter")]
        private IWebElement btnDeleteParameter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphSubMenuBar_lnkPTM")]
        private IWebElement lnkParameterThresholdMonitor;

        [FindsBy(How =How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ProfileList_lblHeader")]
        private IWebElement lblProfiles;
        #endregion


        //properties
        #region

        public IWebElement LnkParameterThresholdMonitor
        {
            get
            {
                return lnkParameterThresholdMonitor;
            }
            set
            {
                lnkParameterThresholdMonitor = value;
            }
        }

        public IWebElement LblProfiles
        {
            get
            {
                return lblProfiles;
            }
            set
            {
                lblProfiles = value;
            }
        }
        public IWebElement LblXNIMConfigurationPage
        {
            get { return lblXNIMConfigurationPage; }
            set { lblXNIMConfigurationPage = value; }
        }

        public IWebElement BtnAddProfile
        {
            get { return btnAddProfile; }
            set { btnAddProfile = value; }
        }

        public IWebElement LblParametersPanel
        {
            get { return lblParametersPanel; }
            set { lblParametersPanel = value; }
        }

        public IWebElement BtnParameterFunction
        {
            get { return btnParameterFunction; }
            set { btnParameterFunction = value; }
        }

        public IWebElement LblFunctionTitle
        {
            get { return lblFunctionTitle; }
            set { lblFunctionTitle = value; }
        }

        public IWebElement BtnAddParameter
        {
            get { return btnAddParameter; }
            set { btnAddParameter = value; }
        }

        public IWebElement LblAlertsPanel
        {
            get { return lblAlertsPanel; }
            set { lblAlertsPanel = value; }
        }

        public IWebElement BtnAlertListFunction
        {
            get { return btnAlertListFunction; }
            set { btnAlertListFunction = value; }
        }

        public IWebElement BtnAddAlert
        {
            get { return btnAddAlert; }
            set { btnAddAlert = value; }
        }

        public IWebElement BtnProfileCopy
        {
            get { return btnProfileCopy; }
            set { btnProfileCopy = value; }
        }

        public IWebElement BtnDeleteProfile
        {
            get { return btnDeleteProfile; }
            set { btnDeleteProfile = value; }
        }

        public IWebElement BtnOKDelete
        {
            get { return btnOKDelete; }
            set { btnOKDelete = value; }
        }

        public IWebElement BtnDeleteParameter
        {
            get { return btnDeleteParameter; }
            set { btnDeleteParameter = value; }
        }

        public IWebElement BtnDeleteAlert
        {
            get { return btnDeleteAlert; }
            set { btnDeleteAlert = value; }
        }

        #endregion

        //Method
        #region

        /// <summary>
        /// Click on XNIM Configuration link
        /// </summary>
        public void ClickOnXNIMConfiguration()
        {
            Waits.WaitAndClick(driver, lnkXNIMConfiguration);
        }

        /// <summary>
        /// Create a New Profile
        /// </summary>
        /// <param name="profileName"></param>
        public void CreateXNIMProfile(string profileName)
        {
            if (IsProfileExist(profileName))
            {
                DeleteProfile(profileName);
            }
            EnterProfileName(profileName);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// Check selected profile available in the list of profiles
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public bool IsProfileExist(string profile)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstProfilePanel);
            List<IWebElement> lstEle = new List<IWebElement>(lstProfilePanel.FindElements(By.XPath("//table//tbody//tr")));

            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Equals(profile))
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
        /// Delete profile function
        /// </summary>
        /// <param name="profileName"></param>
        public void DeleteProfile(string profileName)
        {
                SelectCreatedProfile(profileName);
                Waits.WaitAndClick(driver, btnDeleteProfile);
                Waits.WaitAndClick(driver, btnOKDelete);
                Waits.WaitForElementVisible(driver, lblProfiles);
        }

        /// <summary>
        /// Enter XNIM Profile name
        /// </summary>
        /// <param name="profileName"></param>
        public void EnterProfileName(string profileName)
        {
            Waits.WaitForElementVisible(driver, txtXNIMProfileName);
            txtXNIMProfileName.Clear();
            txtXNIMProfileName.SendKeys(profileName);
        }

        /// <summary>
        /// Selected already created profile
        /// </summary>
        /// <param name="profileName"></param>
        public void SelectCreatedProfile(string profileName)
        {
            List<string> ProfileList = new List<string>();
            Waits.WaitForElementVisible(driver, lstProfilePanel);
            ICollection<IWebElement> list = lstProfilePanel.FindElements(By.XPath("//table//tbody//tr//td"));
            foreach (IWebElement listItem in list)
            {
                if (listItem.Text.ToLower().Equals(profileName.ToLower()))
                {
                    Waits.WaitAndClick(driver, listItem);
                    break;
                }
                else
                {
                    continue;
                }
            }

        }

        /// <summary>
        /// Create a new parameter 
        /// </summary>
        /// <param name="parameterName"></param>
        public void EnterParameterName(string parameterName)
        {
            Waits.WaitForElementVisible(driver, txtParameterName);
            txtParameterName.Clear();
            txtParameterName.SendKeys(parameterName);
        }

        /// <summary>
        /// Select the Boolean operator
        /// </summary>
        /// <param name="operatorvalue"></param>
        public void SelectBooleanOperator(string operatorvalue)
        {
            Waits.WaitForElementVisible(driver, listSetOperator);
            ElementExtensions.SelectByText(listSetOperator, operatorvalue);
        }

        /// <summary>
        /// Select the needed Sections
        /// </summary>
        public void SelectSection()
        {
            Waits.WaitAndClick(driver, setSectionCheckbox);
            Waits.WaitAndClick(driver, lineDividerCheckbox);
            Waits.WaitAndClick(driver, btnApply);
        }

        /// <summary>
        /// Check selected Parameter available in the list of Parameters
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool IsParameterExist(string parameter)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lblParametersPanel);
            List<IWebElement> lstEle = new List<IWebElement>(lblParametersPanel.FindElements(By.XPath("//table//tbody//tr")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(parameter))
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
        /// Selected already created parameter
        /// </summary>
        /// <param name="parameter"></param>
        public void SelectCreatedParameter(string parameter)
        {
            Waits.WaitForElementVisible(driver, lblParametersPanel);
            IList<IWebElement> list = lblParametersPanel.FindElements(By.XPath("//table//tbody//tr//td"));
            foreach (IWebElement listItem in list)
            {
                if (listItem.Text.ToLower().Contains(parameter.ToLower()))
                {
                    Waits.WaitAndClick(driver, listItem);
                    break;
                }
                else
                {
                    continue;
                }
            }

        }

        /// <summary>
        /// Enter Alert Message 
        /// </summary>
        /// <param name="alert"></param>
        public void EnterAlertMessage(string alert)
        {
            Waits.WaitForElementVisible(driver, txtAlertName);
            txtAlertName.Clear();
            txtAlertName.SendKeys(alert);
        }

        /// <summary>
        /// Check selected Alert available in the list of Alerts
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        public bool IsAlertExist(string alert)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lblAlertsPanel);
            List<IWebElement> lstEle = new List<IWebElement>(lblAlertsPanel.FindElements(By.XPath("//table//tbody//tr")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(alert))
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
        /// To Select the Created Alert 
        /// </summary>
        /// <param name="alert"></param>
        public void SelectCreatedAlert(string alert)
        {
            IWebElement baseTable = lblAlertsPanel;
            List<string> ProfileList = new List<string>();
            ICollection<IWebElement> list = baseTable.FindElements(By.XPath("//table//tbody//tr//td"));
            foreach (IWebElement listItem in list)
            {
                if (listItem.Text.ToLower().Contains(alert.ToLower()))
                {
                    listItem.Click();
                    break;
                }
                else
                {
                    continue;
                }
            }

        }

        #endregion
    }
}
