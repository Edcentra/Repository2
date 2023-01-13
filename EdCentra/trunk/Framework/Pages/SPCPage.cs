using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class SPCPage : PageBase
    {

        private IWebDriver driver;
        public SPCPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for Historian page
        #region 
        [FindsBy(How = How.XPath, Using = ".//a//span[text()='SPC']")]
        private IWebElement lnkSPC;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtFilterDateFrom')]")]
        private IWebElement txtStartDate;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtFilterDateTo')]")]
        private IWebElement txtEndDate;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlAggregationPeriod')]")]
        private IWebElement ddlAggregation;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnApplyFilter')]")]
        private IWebElement btnApplyFilter;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblClearAll')][contains(.,'Clear')]")]
        private IWebElement lnkClearAll;

        //[FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnApplyFilter')]")]
        //private IWebElement btnApplyFilter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkGraph")]
        private IWebElement lnkGraphTab;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkBoxPlot")]
        private IWebElement lnkBoxPlot;

        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'ctl00$UserOptions$rptOptions$ctl05$ddlValue')]")]
        private IWebElement lnkTemperatureUnit;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$UserOptions$btnApply')]")]
        private IWebElement btnUserOptionsApply;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ctl00_ctl00_cphContent_cphContent_ddlMetric')]")]
        private IWebElement lstMetric;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ctl00_ctl00_cphContent_cphContent_ddlControlLimit')]")]
        private IWebElement lstControlLimit;

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$ctl00$cphContent$cphContent$txtSystemName_Commission'][contains(@id,'Commission')]")]
        private IWebElement txtBoxEquipmentName;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_txtIPAddress_Commission']")]
        private IWebElement txtBoxIPAddress;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlSystemType_Commission")]
        private IWebElement drpDownSelectEquipmentType;

        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement btnAddOnCommissionPopUp;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Parameters')]")]
        private IWebElement lnkParameters;

        #endregion

        //Properties
        #region
        public IWebElement LnkSPC
        {
            get { return lnkSPC; }
            set { lnkSPC = value; }
        }

        public IWebElement LnkBoxPlot
        {
            get { return lnkBoxPlot; }
            set { lnkBoxPlot = value; }
        }

        public IWebElement LnkGraphTab
        {
            get { return lnkGraphTab; }
            set { lnkGraphTab = value; }
        }

        public IWebElement LnkClearAll
        {
            get { return lnkClearAll; }
            set { lnkClearAll = value; }
        }

        public IWebElement LnkParameters
        {
            get { return lnkParameters; }
            set { lnkParameters = value; }
        }

        #endregion

        //Methods of SPC

        /// <summary>
        /// To Update DateRange
        /// </summary>
        public void SelectDateRange()
        {
            Waits.WaitForElementVisible(driver, txtStartDate);
            txtStartDate.Clear();
            Waits.Wait(driver, 500);
            txtStartDate.SendKeys(DateTime.Now.ToString("yyyy/MM/dd"));
            Waits.Wait(driver, 500);
            Waits.WaitForElementVisible(driver, txtEndDate);
            txtEndDate.Clear();
            Waits.Wait(driver, 500);
            txtEndDate.SendKeys(DateTime.Now.ToString("yyyy/MM/dd"));
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, btnApplyFilter);
        }

        /// <summary>
        /// To change Temperature unit 
        /// </summary>
        public void ChangeUserPreference()
        {
            Waits.WaitForElementVisible(driver, lnkTemperatureUnit);
            ElementExtensions.SelectByValue(lnkTemperatureUnit, "203");
            Waits.WaitAndClick(driver, btnUserOptionsApply);
        }

        /// <summary>
        ///  Moves move to expected element
        /// </summary>
        public void MouseMove()
        {
            IWebElement ele = driver.FindElement(By.XPath("//g[contains(@class,'highcharts-markers highcharts-series-0 highcharts-line-series highcharts-color-0 highcharts-tracker']"));
            //Create object 'action' of an Actions class
            Actions action = new Actions(driver);
            //Mouseover on an element
            action.MoveToElement(ele).Perform();
        }

        /// <summary>
        /// To get Tooltip Range text 
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="index"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public string GetToolTipRangeText(string parameter, int index, int point)
        {
            bool flag = false;
            string tooltipText = string.Empty;
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    if (flag)
                    {
                        break;
                    }
                    Waits.Wait(driver, 3000);
                    IWebElement svgGraph = driver.FindElement(By.ClassName("highcharts-root"));
                    Waits.Wait(driver, 2000);
                    List<IWebElement> lstSVG = new List<IWebElement>(svgGraph.FindElements(By.TagName("g")));
                    Actions action = new Actions(driver);
                    action.ClickAndHold(lstSVG[point]).Build().Perform();
                    Waits.Wait(driver, 300);
                    List<IWebElement> lstPath = new List<IWebElement>(lstSVG[index].FindElements(By.TagName("path")));

                    Waits.Wait(driver, 3000);
                    if (lstPath.Count > 0)
                        action.DoubleClick(lstPath.Last()).Build().Perform();
                    IWebElement ele = lstSVG.Last().FindElement(By.TagName("text"));
                    List<IWebElement> eleLst = new List<IWebElement>(ele.FindElements(By.TagName("tspan")));
                    if (eleLst[1].Text.Contains(parameter))
                    {
                        tooltipText = eleLst[3].Text;
                        Waits.Wait(driver, 1000);
                        flag = true;
                        Waits.Wait(driver, 1000);
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    //Waits.WaitAndClick(driver, btnClear);
                    GetToolTipRangeText(parameter, index, point);
                }
                catch (ArgumentOutOfRangeException)
                {
                    GetToolTipRangeText(parameter, index, point);
                }
                catch (StaleElementReferenceException)
                {
                    GetToolTipRangeText(parameter, index, point);
                }
            }
            return tooltipText;
        }

        /// <summary>
        /// To select metric from dropdown
        /// </summary>
        /// <param name="text"></param>
        public void SelectMetric(string text)
        {
            Waits.WaitForElementVisible(driver, lstMetric);
            SelectElement element = new SelectElement(lstMetric);
            element.SelectByText(text);
        }

        /// <summary>
        /// To select control limit from dropdown
        /// </summary>
        /// <param name="value"></param>
        public void SelectControlLimit(string value = "2")
        {
            Waits.WaitForElementVisible(driver, lstControlLimit);
            SelectElement element = new SelectElement(lstControlLimit);
            element.SelectByValue(value);
        }

        /// <summary>
        /// Verify selected parameter
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="index"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool SelectedParameter(string parameter, int index, int point)
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
                    Waits.Wait(driver, 3000);
                    IWebElement svgGraph = driver.FindElement(By.ClassName("highcharts-root"));
                    Waits.Wait(driver, 2000);
                    List<IWebElement> lstSVG = new List<IWebElement>(svgGraph.FindElements(By.TagName("g")));
                    Actions action = new Actions(driver);
                    action.ClickAndHold(lstSVG[point]).Build().Perform();
                    List<IWebElement> lstPath = new List<IWebElement>(lstSVG[index].FindElements(By.TagName("path")));

                    Waits.Wait(driver, 3000);
                    if (lstPath.Count > 0)
                        action.DoubleClick(lstPath.Last()).Build().Perform();
                    IWebElement ele = lstSVG.Last().FindElement(By.TagName("text"));
                    List<IWebElement> eleLst = new List<IWebElement>(ele.FindElements(By.TagName("tspan")));
                    if (eleLst[1].Text.Contains(parameter))
                    {
                        flag = true;
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    GetToolTipRangeText(parameter, index, point);
                }
                catch (ArgumentOutOfRangeException)
                {
                    GetToolTipRangeText(parameter, index, point);
                }
                catch (StaleElementReferenceException)
                {
                    GetToolTipRangeText(parameter, index, point);
                }
            }
            return flag;
        }

        /// <summary>
        /// Verify parameter displayed on Graph
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public bool IsGraphDisplayedParameter(string Parameter)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 4000);
                List<IWebElement> lstEle = new List<IWebElement>(driver.FindElements(By.XPath("//div[@id='chart_container']//*[name()='svg']//*[name()='text']//*[name()='tspan']")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(Parameter))
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
            }
            return flag;
        }

        /// <summary>
        /// Verify parameter displayed in Box Plot
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public bool IsBoxPlotDisplayedParameter(string Parameter)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 4000);
                List<IWebElement> lstEle = new List<IWebElement>(driver.FindElements(By.XPath("//div[@id='chart_container']//*[name()='svg']//*[name()='g'][@class='highcharts-axis-labels highcharts-xaxis-labels ']//*[name()='text']//*[name()='tspan']")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(Parameter))
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
            }
            return flag;
        }       

    }
}
