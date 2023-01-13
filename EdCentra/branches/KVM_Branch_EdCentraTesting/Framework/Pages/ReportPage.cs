using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class ReportPage : PageBase
    {

        private IWebDriver driver;

        public ReportPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for reportpage
        #region 


        [FindsBy(How = How.XPath, Using = "//div[@class='content']//a[text()='Consumption Report']")]
        private IWebElement lnkConsumptionReport;

        [FindsBy(How = How.XPath, Using = "//div[@class='treeView']//table[1]//tbody/tr/td[3]")]
        private IWebElement lstDevice;

        [FindsBy(How = How.XPath, Using = "//div[text()='ConsumptionSummary']")]
        private IWebElement lblConsumptionReportSummary;

        [FindsBy(How = How.XPath, Using = "//iframe[@id='iframeReport']")]
        private IWebElement iFrameReport;

        [FindsBy(How = How.XPath, Using = "//div[@class='content']//a[text()='Activate Reports']")]
        private IWebElement lnkActivateReport;

        [FindsBy(How = How.XPath, Using = "//div[@class='content']//a[text()='Alert Report']")]
        private IWebElement lnkAlertReport;

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Reports']")]
        private IWebElement lnkReports;

        [FindsBy(How = How.XPath, Using = "//div[@class='reportListContainer']//a[contains(.,'Equipment Software Survey Report')]")]
        private IWebElement lblEquipmentSoftwareSurveyReport;

        [FindsBy(How = How.XPath, Using = "//div[@class='content']//a[text()='Equipment Software Survey Report']")]
        private IWebElement lnkEquipmentSoftwareSurveyReport;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_UpdatePanelTree")]
        private IWebElement lnkSystemList;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_UpdatePanelReport")]
        private IWebElement lnkswirlingIcon;

        [FindsBy(How = How.Id, Using = "Pdc635c111e8b43838dd979edbbf7f41a_1_oReportDiv")]
        private IWebElement lblEquipmentSummary;

        [FindsBy(How = How.XPath, Using = "//input[@title='Current Page']")]
        private IWebElement lnkReportViewer;

        [FindsBy(How = How.XPath, Using = "//div[@class='logo']//a//img")]
        private IWebElement lnkHomePage;

        [FindsBy(How = How.XPath, Using = "(//div[contains(.,'AIM Hardware')])[7]")]
        private IWebElement lblParameter1;

        [FindsBy(How = How.XPath, Using = "(//div[contains(.,'Booster IP Address')])[7]")]
        private IWebElement lblParameter2;

        [FindsBy(How = How.XPath, Using = "(//div[contains(.,'Dry Pump Inverter State Serial Number')])[7]")]
        private IWebElement lblParameter3;

        [FindsBy(How = How.XPath, Using = "(//div[contains(.,'Pump IP Address')])[7]")]
        private IWebElement lblParameter4;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ReportContainer')]")]
        private IWebElement lblserialNumber;

        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'A4fe50c39c90e4ab2bd79886ef61e8529112')])[2]")]
        private IWebElement lblParameterSerialNumber;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divInfoCount')]")]
        private IWebElement lblAdvisoryCount;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divWarningCount')]")]
        private IWebElement lblWarningCount;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divErrorCount')]")]
        private IWebElement lblAlarmCount;

        [FindsBy(How = How.XPath, Using = "//div[contains(@title,'In Maintenance')]")]
        private IWebElement lnkMaintenance;

        [FindsBy(How = How.XPath, Using = "//img[contains(@alt,'Add Reports')]")]
        private IWebElement lnkAddReport;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_rdoByActivationKey_lnkRadioButton")]
        private IWebElement lnkActivateReportByLicenseKey;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtActivationKey")]
        private IWebElement txtActivationKey;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnExportCustom')]")]
        private IWebElement btnExportExcel;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnApply')]")]
        private IWebElement btnApply;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ReportingTreeView1')]")]
        private IWebElement lnkEquipment;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'7iS3T0')][1]")]
        private IWebElement lnkSerialNumber;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_lnkAbout")]
        private IWebElement lnkAbout;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_popAbout_txtActivationKey")]
        private IWebElement lnkActivationKey;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_popAbout_btnClose')]")]
        private IWebElement btnClose;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$uplReportLicenceFile')]")]
        private IWebElement btnUploadFile;

        

        #endregion

        //Properties
        #region

        public IWebElement BtnApply
        {
            get
            {
                return btnApply;
            }
            set
            {
                btnApply = value;
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

        public IWebElement LnkActivationKey
        {
            get
            {
                return lnkActivationKey;
            }
            set
            {
                lnkActivationKey = value;
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

        public IWebElement LnkAddReport
        {
            get { return lnkAddReport; }
            set { lnkAddReport = value; }
        }

        public IWebElement LnkHomePage
        {
            get { return lnkHomePage; }
            set { lnkHomePage = value; }
        }

        public IWebElement LnkEquipmentSoftwareSurveyReport
        {
            get { return lnkEquipmentSoftwareSurveyReport; }
            set { lnkEquipmentSoftwareSurveyReport = value; }
        }

        public IWebElement LnkActivateReport
        {
            get { return lnkActivateReport; }
            set { lnkActivateReport = value; }
        }

        public IWebElement LnkAlertReport
        {
            get { return lnkAlertReport; }
            set { lnkAlertReport = value; }
        }
        public IWebElement LnkSystemList
        {
            get { return lnkSystemList; }
            set { lnkSystemList = value; }
        }

        public IWebElement LblEquipmentSoftwareSurveyReport
        {
            get { return lblEquipmentSoftwareSurveyReport; }
            set { lblEquipmentSoftwareSurveyReport = value; }
        }

        public IWebElement LnkswirlingIcon
        {
            get { return lnkswirlingIcon; }
            set { lnkswirlingIcon = value; }
        }

        public IWebElement LnkReportViewer
        {
            get { return lnkReportViewer; }
            set { lnkReportViewer = value; }
        }

        public IWebElement LblParameterSerialNumber
        {
            get { return lblParameterSerialNumber; }
            set { lblParameterSerialNumber = value; }
        }

        public IWebElement LblAdvisoryCount
        {
            get { return lblAdvisoryCount; }
            set { lblAdvisoryCount = value; }
        }

        public string GetWarningCountText
        {
            get { return lblWarningCount.GetAttribute("innerHTML"); }
        }

        public IWebElement LblWarningCount
        {
            get { return lblWarningCount; }
            set { lblWarningCount = value; }
        }

        public IWebElement LblAlarmCount
        {
            get { return lblAlarmCount; }
            set { lblAlarmCount = value; }
        }

        public IWebElement LnkMaintenance
        {
            get { return lnkMaintenance; }
            set { lnkMaintenance = value; }
        }

        public IWebElement BtnExportExcel
        {
            get { return btnExportExcel; }
            set { btnExportExcel = value; }
        }

        #endregion

        //Methods
        #region

        /// <summary>
        /// Click On Homepage link
        /// </summary>
        public void NavigateToHomePage()
        {
            Waits.WaitForElementVisible(driver, lnkHomePage);
            ElementExtensions.ClickOnLink(lnkHomePage);
        }

        // <summary>
        /// Navigate to Report page 
        public HistorianPage NavigateToReportPage()
        {
            Waits.WaitForElementVisible(driver, lnkReports);
            ElementExtensions.ClickOnLink(lnkReports);
            return new HistorianPage(driver);
        }

        /// <summary>
        /// Enter to Equipment software Survey Report
        public void ClickOnEquipmentSurveyReport()
        {
            Waits.WaitForElementVisible(driver, lnkEquipmentSoftwareSurveyReport);
            ElementExtensions.ClickOnLink(lnkEquipmentSoftwareSurveyReport);
            Waits.Wait(driver, 2000);
        }

        /// Expand the System Folder
        public void ExpandSystemFolder(string folderName)
        {
            Waits.WaitForElementVisible(driver, lnkSystemList);
            List<IWebElement> lstEle = new List<IWebElement>(lnkSystemList.FindElements(By.TagName("tr")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(folderName))
                    {
                        IWebElement ele1 = ele.FindElement(By.XPath("td//a//img"));
                        if (ele1.GetAttribute("alt").Contains("Expand"))
                        {
                            Waits.WaitAndClick(driver, ele1);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Select Single System
        /// </summary>
        /// <param name="system"></param>
        public void SelectSingleSystem(string system)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.WaitForElementVisible(driver, lnkEquipment);
                List<IWebElement> lstEle = new List<IWebElement>(lnkEquipment.FindElements(By.TagName("td")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(system))
                        {
                            Waits.WaitAndClick(driver, ele);
                            flag = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Select Simulated Devices
        /// </summary>
        /// <param name="feature"></param>
        /// 
        public void SelectSimulatedSystem(string folderName, string system)
        {
            ExpandSystemFolder(folderName);
            SelectSingleSystem(system);
        }

        /// <summary>
        /// To Select the Summary Data
        /// </summary>
        public void SelectSummaryData()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(lnkReportViewer).Build().Perform();
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// To verify the Serial Number
        /// </summary>
        /// <param name="SerialNumber"></param>
        /// <returns></returns>
        public bool VerifySerialNumber(string SerialNumber)
        {
            bool flag = false;

            List<IWebElement> lstEle = new List<IWebElement>(lblserialNumber.FindElements(By.TagName("//table//tbody//tr//td")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(SerialNumber))
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
        /// Activate the report
        /// </summary>
        public void ActivateReport()
        {
            Waits.Wait(driver, 5000);
            Waits.WaitAndClick(driver, lnkAddReport);
            Waits.Wait(driver, 8000);
            Waits.WaitAndClick(driver, lnkActivateReportByLicenseKey);
            Waits.Wait(driver, 2000);
            string activationKey= (string)ScenarioContext.Current["ReportsCode"];
            txtActivationKey.SendKeys(activationKey);
            ////var btnUploadFile = driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_cphContent_cphContent_uplReportLicenceFile']"));
            //Waits.WaitForElementVisible(driver, btnUploadFile);
            //Waits.WaitAndClick(driver, btnUploadFile);
            ////ElementExtensions.ClickOnLink(btnUploadFile);
            //Waits.Wait(driver, 10000);
            //System.Windows.Forms.SendKeys.SendWait(GlobalConstants.ReportConfigFolder);
            //Waits.Wait(driver, 5000);
            //System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
            //Waits.Wait(driver, 8000);
        }


        #endregion

    }
}
