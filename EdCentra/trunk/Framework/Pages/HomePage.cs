using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Edwards.Scada.Test.Framework.Pages
{
    using Edwards.Scada.Test.Framework.Contract;
    //namespaces
    using Edwards.Scada.Test.Framework.GlobalHelper;

    public class HomePage : PageBase
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for home page
        #region 

        [FindsBy(How = How.XPath, Using = ".//span[text()='PdM']")]
        private IWebElement lnkPdM;

        [FindsBy(How = How.XPath, Using = ".//span[text()='Configure']")]
        private IWebElement lnkConfigure;

        [FindsBy(How = How.Id, Using = "ctl00_cphContent_rptModules_ctl00_lblModuleTitle")]
        private IWebElement lblRealTimeMonitoring;

        [FindsBy(How = How.XPath, Using = ".//span[text()='User Manager']")]
        private IWebElement lnkUserManager;

        [FindsBy(How = How.XPath, Using = "//div[@class='footermenu']//a//span[text()='Logging']")]
        private IWebElement lnkLogging;

        [FindsBy(How = How.XPath, Using = "//div[@class='footermenu']//a//span[text()='VI Management']")]
        private IWebElement lnkVIManagement;

        [FindsBy(How = How.XPath, Using = "//div[@class='footermenu']//a//span[text()='Dispatch Manager']")]
        private IWebElement lnkDispacthManager;

        [FindsBy(How = How.XPath, Using = ".//a//span[text()='Device Explorer']")]
        private IWebElement lnkDeviceManager;

        [FindsBy(How = How.Id, Using = "ctl00_cphContent_rptModules_ctl00_rptComponents_ctl01_lblLinkText")]
        private IWebElement lnkLiveAlerts;

        [FindsBy(How = How.XPath, Using = "//a//span[text()='Reports']")]
        private IWebElement lnkReports;

        [FindsBy(How = How.Id, Using = "ctl00_cphContent_lnkSecsGemAgentDisabled")]
        private IWebElement lnkSecGemHost;

        [FindsBy(How = How.Id, Using = "ctl00_cphContent_lnkSecsGemDisabled")]
        private IWebElement lnkSecGemService;

        [FindsBy(How = How.XPath, Using = "//div[@class='leftmenu']//a[@class='bigicon']//span[text()='Data Extraction Utility']")]
        private IWebElement lnkDataExtractionUtility;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'PTM')]")]
        private IWebElement lnkPTM;

        [FindsBy(How = How.XPath, Using = "//a//span[text()='Predictive Maintenance']")]
        private IWebElement lnkPredictiveMaintenance;

        [FindsBy(How = How.XPath, Using = "//a//span[text()='Fingerprint']")]
        private IWebElement lnkFingerprint;

        //ctl00_cphContent_rptModules_ctl01_rptComponents_ctl04_imgIcon
        //ctl00_cphContent_rptModules_ctl01_rptUnlicensedComponents_ctl03_imgIcon 
        [FindsBy(How = How.Id, Using = "ctl00_cphContent_rptModules_ctl01_rptComponents_ctl04_lblLinkText")]
        public IWebElement SeeFingerprintImage;

        [FindsBy(How = How.XPath, Using = "//a//span[text()='Historian']")]
        private IWebElement lnkHistorian;

        [FindsBy(How = How.XPath, Using = "//a//span[text()='SPC']")]
        private IWebElement lnkSPC;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblUserName')]")]
        private IWebElement lnkLoginUser;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Logout')]")]
        private IWebElement lnkLogOut;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Configuration Handler')]")]
        private IWebElement lnkConfiguarationHandler;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblLinkText')][contains(.,'Device Explorer')]")]
        private IWebElement lnkDeviceExplorer;

        //[FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblLinkText')][contains(.,'Predictive Maintenance')]")]
        //private IWebElement lnkPredictiveMaintenance;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblLinkText')][contains(.,'PdM')]")]
        private IWebElement lnkPDM;

        [FindsBy(How = How.Id, Using = "ctl00_lnkAbout")]
        private IWebElement lnkAbout;

        [FindsBy(How = How.Id, Using = "//table[contains(@id, 'ctl00_ctl00_popAbout_txtActivationKey')]")]
        private IWebElement txtActivationKey; 

        [FindsBy(How = How.Id, Using = "ctl00_lnkOptions")]
        private IWebElement lnkOptions;

        [FindsBy(How = How.Id, Using = "ctl00_lnkHelp")]
        private IWebElement lnkHelp;

        [FindsBy(How = How.Id, Using = "ctl00_popGeneralOptions_lnkTraceMode")]
        private IWebElement lblTraceMode;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id, 'ctl00_popGeneralOptions_rptOptions_ctl01_ddlValue')]//option[contains(@selected, 'selected')]")]
        private IWebElement ddlAutoAddChileSystems;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id, 'ctl00_popGeneralOptions_rptOptions_ctl06_ddlValue')]//option[contains(@selected, 'selected')]")]
        private IWebElement ddlEnableGreenMode;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id, 'ctl00_popGeneralOptions_rptOptions_ctl16_ddlValue')]//option[contains(@selected, 'selected')]")]
        private IWebElement ddlPasswordExpiry;

        [FindsBy(How = How.Id, Using = "ctl00_popGeneralOptions_rptOptions_ctl17_txtValue")]
        private IWebElement txtPasswordExpiryDays;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Close')]")]
        private IWebElement btnClose;

        [FindsBy(How = How.Id, Using = "ctl00_cphContent_lblAuthorizationCode")]
        private IWebElement lblAuthorizationCode;

        [FindsBy(How = How.Id, Using = "ctl00_cphContent_lnkActivate")]
        private IWebElement lnkActivate;

        [FindsBy(How = How.Id, Using = "module3_checkbox")]
        private IWebElement chkUniversalConnectivity;

        [FindsBy(How = How.Id, Using = "module1_checkbox")]
        private IWebElement chkDiagnostics;

        [FindsBy(How = How.Id, Using = "module2_checkbox")]
        private IWebElement chkAdvancedDataAnalytics;

        [FindsBy(How = How.Id, Using = "module2_row0_checkbox")]
        private IWebElement chkPTM;

        [FindsBy(How = How.Id, Using = "module2_row1_checkbox")]
        private IWebElement chkEADS;

        [FindsBy(How = How.Id, Using = "module3_row2_checkbox")]
        private IWebElement chkSecGemService;

        [FindsBy(How = How.Id, Using = "module3_row3_checkbox")]
        private IWebElement chkSecGemAgent;

        [FindsBy(How = How.Id, Using = "module3_row4_checkbox")]
        private IWebElement chkEbara;

        [FindsBy(How = How.Id, Using = "module1_row1_checkbox")]
        private IWebElement chkFingerprint;

        [FindsBy(How = How.Id, Using = "module1_row2_checkbox")]
        private IWebElement chkReports;

        [FindsBy(How = How.Id, Using = "module1_row3_checkbox")]
        private IWebElement chkEquipmentSurveyReport;

        [FindsBy(How = How.Id, Using = "module1_row7_checkbox")]
        private IWebElement chkAlertReport;

        [FindsBy(How = How.Id, Using = "module1_row9_checkbox")]
        private IWebElement chkConsumptionReport;

        [FindsBy(How = How.Id, Using = "requestCode")]
        private IWebElement txtRequestCode;

        [FindsBy(How = How.Id, Using = "codes")]
        private IWebElement txtCodes;

        [FindsBy(How = How.Id, Using = "EdcentraVersion")]
        private IWebElement ddlEdcentraVersion;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Generate Authorization Codes')]")]
        private IWebElement btnGenerateAuthorizationCode;

        [FindsBy(How = How.XPath, Using = "//a//span[text()='Edwards IO Controller Settings']")]
        private IWebElement lnkEdwardsIOControllerSettings;
        #endregion

        //Properties
        #region

        public IWebElement LnkPdM
        {
            get
            {
                return lnkPdM;
            }
            set
            {
                lnkPdM = value;
            }
        }

        public IWebElement TxtActivationKey
        {
            get { return txtActivationKey; }
            set { txtActivationKey = value; }
        }

        public IWebElement LnkActivate
        {
            get
            {
                return lnkActivate;
            }
            set
            {
                lnkActivate = value;
            }
        }

        public IWebElement LblRealTimeMonitoring
        {
            get
            {
                return lblRealTimeMonitoring;
            }
            set
            {
                lblRealTimeMonitoring = value;
            }
        }

        public IWebElement LblAuthorizationCode
        {
            get
            {
                return lblAuthorizationCode;
            }
            set
            {
                lblAuthorizationCode = value;
            }
        }

        public IWebElement LnkDeviceManager
        {
            get
            {
                return lnkDeviceManager;
            }
        }

        public IWebElement LblTraceMode
        {
            get
            {
                return lblTraceMode;
            }
            set
            {
                lblTraceMode = value;
            }
        }

        public IWebElement DdlAutoAddChileSystems
        {
            get
            {
                return ddlAutoAddChileSystems;
            }
            set
            {
                ddlAutoAddChileSystems = value;
            }
        }

        public IWebElement DdlEnableGreenMode
        {
            get
            {
                return ddlEnableGreenMode;
            }
            set
            {
                ddlEnableGreenMode = value;
            }
        }

        public IWebElement TxtPasswordExpiryDays
        {
            get
            {
                return txtPasswordExpiryDays;
            }
            set
            {
                txtPasswordExpiryDays = value;
            }
        }

        public IWebElement DdlPasswordExpiry
        {
            get
            {
                return ddlPasswordExpiry;
            }
            set
            {
                ddlPasswordExpiry = value;
            }
        }

        public IWebElement LnkConfiguarationHandler
        {
            get
            {
                return lnkConfiguarationHandler;
            }
            set
            {
                LnkConfiguarationHandler = value;
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

        public IWebElement LnkHistorian
        {
            get
            {
                return lnkHistorian;
            }
            set
            {
                lnkHistorian = value;
            }
        }

        public IWebElement LnkPTM
        {
            get
            {
                return lnkPTM;
            }
            set
            {
                lnkPTM = value;
            }
        }

        public IWebElement LnkPredictiveMaintenance
        {
            get { return lnkPredictiveMaintenance; }
            set { lnkPredictiveMaintenance = value; }
        }

        public IWebElement LnkFingerprint
        {
            get { return lnkFingerprint; }
            set { lnkFingerprint = value; }
        }
        public IWebElement LnkLoginUser
        {
            get
            {
                return lnkLoginUser;
            }
        }

        public IWebElement LinkLogout
        {
            get
            {
                return lnkLogOut;
            }
        }

        public IWebElement LnkDispacthManager
        {
            get
            {
                return lnkDispacthManager;
            }
        }

        public IWebElement LnkUserManager
        {
            get
            {
                return lnkUserManager;
            }
        }

        public IWebElement LnkLogging
        {
            get
            {
                return lnkLogging;
            }
        }

        public IWebElement LnkVIManagement
        {
            get
            {
                return lnkVIManagement;
            }
        }

        public IWebElement LnkReports
        {
            get
            {
                return lnkReports;
            }
            set
            {
                lnkReports = value;
            }
        }

        public IWebElement LnkSecGemHost
        {
            get
            {
                return lnkSecGemHost;
            }
            set
            {
                lnkSecGemHost = value;
            }
        }

        public IWebElement LnkSecGemService
        {
            get
            {
                return lnkSecGemService;
            }
            set
            {
                lnkSecGemService = value;
            }
        }

        public IWebElement LnkCTIEquipment
        {
            get
            {
                return lnkSecGemService;
            }
            set
            {
                lnkSecGemService = value;
            }
        }
        public IWebElement LnkLiveAlerts
        {
            get
            {
                return lnkLiveAlerts;
            }
            set
            {
                LnkLiveAlerts = value;
            }
        }

        public IWebElement LnkDeviceExplorer
        {
            get
            {
                return lnkDeviceExplorer;
            }
            set
            {
                lnkDeviceExplorer = value;
            }
        }

        public IWebElement LnkDataExtractionUtility
        {
            get
            {
                return lnkDataExtractionUtility;
            }
            set
            {
                lnkDataExtractionUtility = value;
            }
        }

        //public IWebElement LnkPredictiveMaintenance
        //{
        //    get
        //    {
        //        return lnkPredictiveMaintenance;
        //    }
        //    set
        //    {
        //        lnkPredictiveMaintenance = value;
        //    }
        //}

        public IWebElement LnkPDM
        {
            get
            {
                return lnkPDM;
            }
            set
            {
                lnkPDM = value;
            }
        }

        public IWebElement LnkAbout
        {
            get
            {
                return lnkAbout;
            }
            set
            {
                lnkAbout = value;
            }
        }

        public IWebElement LnkOptions
        {
            get
            {
                return lnkOptions;
            }
            set
            {
                lnkOptions = value;
            }
        }

        public IWebElement LnkHelp
        {
            get
            {
                return lnkHelp;
            }
            set
            {
                lnkHelp = value;
            }
        }

        public IWebElement LnkConfigure
        {
            get
            {
                return lnkConfigure;
            }
            set
            {
                lnkConfigure = value;
            }
        }
        #endregion
        //Methods
        #region

        public DispatchManagerPage NavigateToDispatchManagerPage()
        {
            ClickOnConfiguration();
            ClickOnDispatchManager();
            return new DispatchManagerPage(driver);
        }
        public PTMPage NavigateToPTMPage()
        {
            ClickOnParameterThreasholdMonitoring();
            return new PTMPage(driver);
        }

        public DataExtractionPage NavigateToDataExtractionPage()
        {
            ClickOnDataExtractionUtility();
            return new DataExtractionPage(driver);
        }

        public HistorianPage NavigateToHistorianPage()
        {
            ElementExtensions.ClickOnLink(lnkHistorian);
            return new HistorianPage(driver);
        }

        public HistorianPage NavigateToSPC()
        {
            ElementExtensions.ClickOnLink(lnkSPC);
            return new HistorianPage(driver);
        }

        public void ClickOnConfiguration()
        {
            Waits.Wait(driver, 2000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, lnkConfigure);
            lnkConfigure.Click();
        }

        public void ClickOnEdwardsIOControllerSettings()
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, lnkEdwardsIOControllerSettings);
            Waits.WaitAndClick(driver, lnkEdwardsIOControllerSettings);
        }

        public void ClickOnUserManager()
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, lnkUserManager);
            lnkUserManager.Click();
        }
        public void ClickOnDeviceExplorer()
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, lnkDeviceManager);
            JavaScriptExecutor.JavaScriptLinkClick(driver, lnkDeviceManager);
            //Waits.WaitAndClick(driver, lnkDeviceManager);
        }

        public void ClickOnLiveAlertsList()
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, lnkLiveAlerts);
            JavaScriptExecutor.JavaScriptLinkClick(driver, lnkLiveAlerts);
            //Waits.WaitAndClick(driver, lnkLiveAlerts);
        }

        public void ClickOnReports()
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, lnkReports);
            Waits.WaitAndClick(driver, lnkReports);
        }

        public void ClickOnLogging()
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, lnkLogging);
            Waits.WaitAndClick(driver, lnkLogging);
        }

        public void ClickOnVIManagement()
        {           
             JavaScriptExecutor.JavaScriptScrollToElement(driver, lnkVIManagement);
             Waits.WaitAndClick(driver, lnkVIManagement);
             
        }

        public void ClickOnParameterThreasholdMonitoring()
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, lnkPTM);
            Waits.WaitAndClick(driver, lnkPTM);
        }

        public void ClickOnDataExtractionUtility()
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, lnkDataExtractionUtility);
            Waits.WaitAndClick(driver, lnkDataExtractionUtility);
        }

        public void ClickOnDispatchManager()
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, lnkDispacthManager);
            Waits.WaitAndClick(driver, lnkDispacthManager);
        }

        /// <sum    mary>
        /// Launches CodeGeneratorUrl
        /// </summary>
        public void LaunchCodeGeneratorWebUrl()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open()");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Navigate().GoToUrl(GlobalConstants.CodeGeneratorWebUrl);
            ElementExtensions.SelectByText(ddlEdcentraVersion, "1.9+");
            Waits.Wait(driver, 2000);
        }

        public string GenerateLicenseCodeForSecGemServiceAndAgent(string authCode)
        {
            Waits.WaitAndClick(driver, chkDiagnostics);
            Waits.WaitAndClick(driver, chkFingerprint);
            Waits.WaitAndClick(driver, chkReports);
            Waits.WaitAndClick(driver, chkEquipmentSurveyReport);
            Waits.WaitAndClick(driver, chkAlertReport);
            Waits.WaitAndClick(driver, chkConsumptionReport);
            Waits.WaitAndClick(driver, chkAdvancedDataAnalytics);
            Waits.WaitAndClick(driver, chkPTM);
            Waits.WaitAndClick(driver, chkEADS);
            Waits.WaitAndClick(driver, chkUniversalConnectivity);
            Waits.WaitAndClick(driver, chkSecGemService);
            Waits.WaitAndClick(driver, chkSecGemAgent);
            Waits.WaitAndClick(driver, chkEbara);
            Waits.WaitForElementVisible(driver,txtRequestCode);
            txtRequestCode.SendKeys(authCode);
            Waits.WaitAndClick(driver, btnGenerateAuthorizationCode);
            Waits.Wait(driver,2000);
            string code = txtCodes.Text;
            return code;
        }

        #endregion
    }
}