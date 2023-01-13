using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Edwards.Scada.Test.Framework.Pages
{
    class AlertInhibitPage : PageBase
    {
        IWebDriver driver;
        public AlertInhibitPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for AlertInhibitPage
        #region
        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Inhibit Settings']")]
        private IWebElement lnkInhibitSettings;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnNew')]")]
        private IWebElement btnNew;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_lblSettingsTitle')]")]
        private IWebElement lblSettingsTitle;

        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'ctl00$ctl00$cphContent$cphContent$ddlSystemTypeFilter')]")]
        private IWebElement lnkSystemTypeFilter;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnGetSystems')]")]
        private IWebElement btnGetSystems;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_clEquipment_divListControl')]")]
        private IWebElement divEquipmentListControl;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_clParameters_divListControl')]")]
        private IWebElement divParametersListControl;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_clAlerts_divListControl')]")]
        private IWebElement divAlertsListControl;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnMoveAlertsTo')]")]
        private IWebElement btnMoveAlertsTo;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_rdoAll_imgRadioButton')]")]
        private IWebElement imgAlertLevelRadioButton;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_chkNoExpire_imgCheckBox')]")]
        private IWebElement imgAlertExpireCheckBox;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_rdoInhibitPages_imgRadioButton')]")]
        private IWebElement imgAlertScopeRadioButton;

        [FindsBy(How = How.XPath, Using = "//textarea[contains(@name,'ctl00$ctl00$cphContent$cphContent$txtComments')]")]
        private IWebElement txtAlertComments;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnApply')]")]
        private IWebElement btnApplyChanges;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'New Inhibit has been created')]")]
        private IWebElement lblInhibitCreatedMsg;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divScrollContainer')]")]
        private IWebElement divScrollContainer;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_UpdatePanelGrid')]")]
        private IWebElement divScrollContainerNew;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnDelete')]")]
        private IWebElement btnDelete;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnOKDelete')]")]
        private IWebElement btnDeleteConfirmation;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl01_lblLinkText")]
        private IWebElement linkHomePage;

        #endregion

        //Property for AlertInhibitPage
        #region

        public IWebElement LnkInhibitSettings
        {
            get { return lnkInhibitSettings; }
            set { lnkInhibitSettings = value; }
        }

        public IWebElement BtnNew
        {
            get { return btnNew; }
            set { btnNew = value; }
        }

        public IWebElement LblSettingsTitle
        {
            get { return lblSettingsTitle; }
            set { lblSettingsTitle = value; }
        }
         public IWebElement BtnGetSystems
        {
            get { return btnGetSystems; }
            set { btnGetSystems = value; }
        }

        public IWebElement BtnMoveAlertsTo
        {
            get { return btnMoveAlertsTo; }
            set { btnMoveAlertsTo = value; }
        }

        public IWebElement ImgAlertLevelRadioButton
        {
            get { return imgAlertLevelRadioButton; }
            set { imgAlertLevelRadioButton = value; }
        }

        public IWebElement ImgAlertExpireCheckBox
        {
            get { return imgAlertExpireCheckBox; }
            set { imgAlertExpireCheckBox = value; }
        }
         public IWebElement ImgAlertScopeRadioButton
        {
            get { return imgAlertScopeRadioButton; }
            set { imgAlertScopeRadioButton = value; }
        }

        public IWebElement BtnApplyChanges
        {
            get { return btnApplyChanges; }
            set { btnApplyChanges = value; }
        }

        public IWebElement LblInhibitCreatedMsg
        {
            get { return lblInhibitCreatedMsg; }
            set { lblInhibitCreatedMsg = value; }
        }

        public IWebElement DivScrollContainerNew
        {
            get { return divScrollContainerNew; }
            set { divScrollContainerNew = value; }
        }

        public IWebElement DivEquipmentListControl
        {
            get { return divEquipmentListControl; }
            set { divEquipmentListControl = value; }
        }

        public IWebElement DivParametersListControl
        {
            get { return divParametersListControl; }
            set { divParametersListControl = value; }
        }

        public IWebElement DivAlertsListControl
        {
            get { return divAlertsListControl; }
            set { divAlertsListControl = value; }
        }

        public IWebElement DivScrollContainer
        {
            get { return divScrollContainer; }
            set { divScrollContainer = value; }
        }

        public IWebElement LinkHomePage
        {
            get  {  return linkHomePage; }
            set  {  linkHomePage = value; }
        }
        #endregion


        //Methods
        #region

        /// <summary>
        /// Select single System from list
        /// </summary>
        /// <param name="system"></param>
        public void SelectSingleSystem(string system)
        {
            Waits.WaitForElementVisible(driver, lnkSystemTypeFilter);
            ElementExtensions.SelectByText(lnkSystemTypeFilter, system);
        }

        /// <summary>
        /// Select single Equipment from list
        /// </summary>
        /// <param name="equipment"></param>
        public void SelectSingleEquipment(string equipment)
        {
            List<IWebElement> lstEle = new List<IWebElement>(divEquipmentListControl.FindElements(By.TagName("tr")));
            if(lstEle.Count>0)
            {
                foreach(var ele in lstEle)
                {
                    if(ele.Text.Contains(equipment))
                    {
                        ele.Click();
                        break;
                    }
                }

            }
            
        }

            /// <summary>
            /// Select single parameter from list
            /// </summary>
            /// <param name="Parameter"></param>
            public void SelectParameter(string Parameter)
            {
            List<IWebElement> lstPar = new List<IWebElement>(divParametersListControl.FindElements(By.TagName("tr")));
            if(lstPar.Count>0)
            {
                foreach(var par in lstPar)
                {
                    if(par.Text.Contains(Parameter))
                    {
                        Waits.Wait(driver, 1000);
                        par.Click();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Verify the Selected Parameter presence
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public bool IsParametersListPresent(string Parameter)
        {
            bool flag = false;
            List<IWebElement> lstPar = new List<IWebElement>(divParametersListControl.FindElements(By.XPath("//table//tbody//tr/td")));
                       try
            {
                if (lstPar.Count > 0)
                {
                    foreach (var par in lstPar)
                    {
                        if (flag)
                        {
                            break;
                        }
                        if (par.Text.Contains(Parameter))
                        {
                            Waits.Wait(driver, 1000);
                            flag = true;
                            break;
                        }
                    }
                }
            }
            catch(StaleElementReferenceException)
            {
               IsParametersListPresent(Parameter);
            }
            return flag;
        }

        /// <summary>
        /// Verify Alert Listed
        /// </summary>
        /// <param name="Alert"></param>
        /// <returns></returns>
        public bool IsAlertsListPresent(string Alert)
        {
            bool flag = false;
            List<IWebElement> lstAlrt = new List<IWebElement>(divAlertsListControl.FindElements(By.TagName("tr")));
            if(lstAlrt.Count>0)
            {
                foreach(var alrt in lstAlrt)
                {
                    if(flag)
                    {
                        break;
                    }
                    if(alrt.Text.Contains(Alert))
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
        /// Select Alert from list
        /// </summary>
        /// <param name="Alert"></param>
        public void SelectSingleAlert(string Alert)
        {
            List<IWebElement> lstAlrt = new List<IWebElement>(divAlertsListControl.FindElements(By.TagName("tr")));
            if(lstAlrt.Count>0)
            {
                foreach(var alrt in lstAlrt)
                {
                    if(alrt.Text.Contains(Alert))
                    {
                        Waits.Wait(driver, 1000);
                        alrt.Click();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// To Enter the alert comment 
        /// </summary>
        /// <param name="Comment"></param>
        public void EnterAlertComment(string Comment)
        {
            Waits.WaitForElementVisible(driver, txtAlertComments);
            txtAlertComments.SendKeys("");
            txtAlertComments.SendKeys(Comment);
        }

        /// <summary>
        /// Check the created parameter presents
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public bool IsNewlyCreatedInhibitPresent(string Parameter)
        {
            bool flag = false;
            List<IWebElement> lstInhib = new List<IWebElement>(divScrollContainer.FindElements(By.XPath("//table//tbody/tr/td")));
            if(lstInhib.Count>0)
            {
                foreach(var inhib in lstInhib)
                {
                    if(inhib.Text.Contains(Parameter))
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
        /// Delete AlertInhibt if already created
        /// </summary>
        /// <param name="AlertInhibt"></param>
        public void DeleteAlertInhibit_IfExists(string AlertInhibt)
        {
            List<IWebElement> elements = new List<IWebElement>(divScrollContainerNew.FindElements(By.XPath("//table//tbody//tr")));
            foreach (IWebElement element in elements)
            {
                if (element.Text.ToLower().Contains(AlertInhibt.ToLower()))
                {
                    element.Click();
                    Waits.WaitAndClick(driver, btnDelete);
                    Waits.WaitAndClick(driver, btnDeleteConfirmation);
                    break;
                }
            }
        }
        #endregion
    }
}