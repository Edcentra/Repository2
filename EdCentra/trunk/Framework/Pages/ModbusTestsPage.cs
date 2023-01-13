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
    class ModbusTestPage : PageBase
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializing page
        /// </summary>
        /// <param name="driver"></param>
        public ModbusTestPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects ModbusTestsPage
        #region

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'#1 Water Tank Flow Temp.:')]")]
        private IWebElement lblWaterTankFlowTemp;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'#2-1 Inlet Pressure:')]")]
        private IWebElement lblInletPressure;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'#2 Oxidizer Flow Rate:')]")]
        private IWebElement lblOxidizerFlowRate;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@class,'value')])[57]")]
        private IWebElement lblInletPressurervalue;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@id,'spnStatus')])[2]")]
        private IWebElement lblStatus;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_SEV1_divWarningCount")]
        private IWebElement lblWarningCount;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_SEV1_divAlarmCount")]
        private IWebElement lblAlarmCount;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_lblMessage")]
        private IWebElement lblAlertDetailsMsg;

        [FindsBy(How = How.XPath, Using = "//a[@id='ctl00_ctl00_cphContent_cphContent_AlertDetails_hypParameter']")]
        private IWebElement lblhypParameter;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Close')]")]
        private IWebElement btnClose;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'BP Power:')]")]
        private IWebElement lblBPPower;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Pump N2 Flow:')]")]
        private IWebElement lblPumpN2Flow;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'BP Status:')]")]
        private IWebElement lblBPStatus;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@class,'value')])[4]")]
        private IWebElement lblBPPowervalue;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Software Version:')]")]
        private IWebElement lblSoftwareVersion;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Heartbeat Counter:')]")]
        private IWebElement lblHeartbeatCounter;

        [FindsBy(How = How.XPath, Using = "//div[@class='footermenu']//a//span[text()='Edwards IO Controller Settings']")]
        private IWebElement lnkEdwardsIOControllerSettings;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_gvParameters_divScrollContainer')]")]
        private IWebElement parameterTable;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtOverrideParameterName')]")]
        private IWebElement txtOverrideParameterName;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnApply')]")]
        private IWebElement btnApply;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@class,'value')])[2]")]
        private IWebElement lblAnalogueInputValue;

        #endregion

        //Property

        public IWebElement LblWaterTankFlowTemp
        {
            get { return lblWaterTankFlowTemp; }
            set { lblWaterTankFlowTemp = value; }
        }

        public IWebElement LblInletPressure
        {
            get { return lblInletPressure; }
            set { lblInletPressure = value; }
        }

        public IWebElement LblInletPressurervalue
        {
            get { return lblInletPressurervalue; }
            set { lblInletPressurervalue = value; }
        }

        public IWebElement LblOxidizerFlowRate
        {
            get { return lblOxidizerFlowRate; }
            set { lblOxidizerFlowRate = value; }
        }

        public IWebElement LblStatus
        {
            get { return lblStatus; }
            set { lblStatus = value; }
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

        public IWebElement LblAlertDetailsMsg
        {
            get { return lblAlertDetailsMsg; }
            set { lblAlertDetailsMsg = value; }
        }

        public IWebElement LblhypParameter
        {
            get { return lblhypParameter; }
            set { lblhypParameter = value; }
        }

        public IWebElement BtnClose
        {
            get { return btnClose; }
            set { btnClose = value; }
        }

        public IWebElement LblBPPower
        {
            get { return lblBPPower; }
            set { lblBPPower = value; }
        }

        public IWebElement LblPumpN2Flow
        {
            get { return lblPumpN2Flow; }
            set { lblPumpN2Flow = value; }
        }

        public IWebElement LblBPStatus
        {
            get { return lblBPStatus; }
            set { lblBPStatus = value; }
        }

        public IWebElement LblBPPowervalue
        {
            get { return lblBPPowervalue; }
            set { lblBPPowervalue = value; }
        }

        public IWebElement LblSoftwareVersion
        {
            get { return lblSoftwareVersion; }
            set { lblSoftwareVersion = value; }
        }

        public IWebElement LblHeartbeatCounter
        {
            get { return lblHeartbeatCounter; }
            set { lblHeartbeatCounter = value; }
        }

        public IWebElement LblAnalogueInputValue
        {
            get { return lblAnalogueInputValue; }
            set { lblAnalogueInputValue = value; }
        }

        //Methods of Modbus testing 
        /// <summary>
        ///  To select IOC settings from list
        /// </summary>
        public void ClickOnEdwardsIOControllerSettings()
        {
            JavaScriptExecutor.JavaScriptScrollToElement(driver, lnkEdwardsIOControllerSettings);
            Waits.WaitAndClick(driver, lnkEdwardsIOControllerSettings);
        }

        /// <summary>
        /// To select the system under list
        /// </summary>
        public void ClickOnSystemfromList(string systemName)
        {
            // find the System table
            IWebElement systable = driver.FindElement(By.XPath("//div[@id='ctl00_ctl00_cphContent_cphContent_gvProfiles_divScrollContainer']/table"));
            // find the row
            IWebElement System = systable.FindElement(By.XPath($"//tr/td[contains(text(), {systemName})]"));
            // click on the row
            System.Click();
        }

        /// <summary>
        /// Select the IO parameter 
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="overrideDescription"></param>
        public void ParameterSelection(string parameter, string overrideDescription)
        {
            Waits.WaitForElementVisible(driver, parameterTable);
            SelectParametersCheckBoxes(parameter);
            Waits.WaitForElementVisible(driver, txtOverrideParameterName);
            Waits.Wait(driver, 1000);
            txtOverrideParameterName.SendKeys("");
            txtOverrideParameterName.SendKeys(overrideDescription);
            Waits.Wait(driver, 3000);
            Waits.WaitAndClick(driver, btnApply);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// Select Permission CheckBoxes
        /// </summary>
        /// <param name="feature"></param>
        public void SelectParametersCheckBoxes(string parameter)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, parameterTable);
            List<IWebElement> lstEle = new List<IWebElement>(parameterTable.FindElements(By.TagName("tr")));
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

    }
}
