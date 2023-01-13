using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class HistorianPerformanceTestsStepDefinition
    {

        private IWebDriver driver;
        Excel excel = new Excel();
        LoginPage loginPage;
        HomePage homePage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        LoggingPage loggingPage;
        HistorianPage historianPage;
        DataExtractionPage dataExtractionPage;
        ReportPage reportPage;
        UserPage userPage;
        Stopwatch parameterLoadListtimer = new Stopwatch();
        Stopwatch addingParameterTime = new Stopwatch();

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


        public HistorianPerformanceTestsStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
            excel.CreateNewFile();
        }

        public void PageInitialization()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            loggingPage = new LoggingPage(driver);
            historianPage = new HistorianPage(driver);
            dataExtractionPage = new DataExtractionPage(driver);
            reportPage = new ReportPage(driver);
            userPage = new UserPage(driver);
        }

        [Given(@"I Opened EDCENTRA app url in browser\.")]
        public void GivenIOpenedEDCENTRAAppUrlInBrowser_()
        {
            PageInitialization();
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);
        }

        [When(@"I enter username as '(.*)' and password as '(.*)' and clicked login button\.")]
        public void WhenIEnterUsernameAsAndPasswordAsAndClickedLoginButton_(string username, string password)
        {
            loginPage.SignIn(username, password);
        }

        [When(@"expanded system '(.*)', selected '(.*)'")]
        public void WhenExpandedSystemSelected(string system, string paramter)
        {
            Waits.WaitAndClick(driver, homePage.LnkHistorian);
            Waits.WaitAndClick(driver, historianPage.LnkHistorianEquipmentData);
            Waits.WaitForElementVisible(driver, historianPage.LnkHistorianEquipmentData);
            Assert.IsTrue(historianPage.LnkHistorianEquipmentData.Displayed, "Verified screen presence the Equipment Data tab");
            historianPage.ExpandSystemsParameter("Combuster");
            Waits.Wait(driver, 3000);
            historianPage.SelectSingleParameterEquipment("OlympiaPerf1");
            Waits.Wait(driver, 1000);
        }

        [Then(@"calculated '(.*)' paramter list loading time for '(.*)'\.")]
        public void ThenCalculatedParamterListLoadingTimeFor_(string system, string dateRange)
        {

            string time = "";
            historianPage.DateRangeSelection(dateRange);
            Waits.Wait(driver, 3000);
            Waits.WaitAndClick(driver, historianPage.BtnApplyFilter);
            if (dateRange.ToLower().Equals("1 week"))
            {
                Stopwatch parameterLoadListtimer = new Stopwatch();
                parameterLoadListtimer.Start();
                historianPage.CheckElement(historianPage.ImgCombusterTempForAWeek);
                parameterLoadListtimer.Stop();
                excel.WriteToCell(1, 1, "Sheet1", "Paramter list loading time for " + system + " (" + dateRange + ")");
                time = parameterLoadListtimer.Elapsed.ToString();
                excel.WriteToCell(1, 2, "Sheet1", time);
            }
            else if (dateRange.ToLower().Equals("1 month"))
            {
                Stopwatch parameterLoadListtimer = new Stopwatch();
                parameterLoadListtimer.Start();
                historianPage.CheckElement(historianPage.ImgCombusterTempForAMonth);
                parameterLoadListtimer.Stop();
                excel.WriteToCell(2, 1, "Sheet1", "Paramter list loading time for " + system + " (" + dateRange + ")");
                time = parameterLoadListtimer.Elapsed.ToString();
                excel.WriteToCell(2, 2, "Sheet1", time);
            }
            else if (dateRange.ToLower().Equals("3 months"))
            {
                Stopwatch parameterLoadListtimer = new Stopwatch();
                parameterLoadListtimer.Start();
                historianPage.CheckElement(historianPage.ImgCombusterTempForThreeMonths);
                parameterLoadListtimer.Stop();
                excel.WriteToCell(3, 1, "Sheet1", "Paramter list loading time for " + system + " (" + dateRange + ")");
                time = parameterLoadListtimer.Elapsed.ToString();
                excel.WriteToCell(3, 2, "Sheet1", time);
            }
            else if (dateRange.ToLower().Equals("1 year"))
            {
                Stopwatch parameterLoadListtimer = new Stopwatch();
                parameterLoadListtimer.Start();
                historianPage.CheckElement(historianPage.ImgCombusterTempForAYear);
                parameterLoadListtimer.Stop();
                excel.WriteToCell(4, 1, "Sheet1", "Paramter list loading time for " + system + " (" + dateRange + ")");
                time = parameterLoadListtimer.Elapsed.ToString();
                excel.WriteToCell(4, 2, "Sheet1", time);
            }
            Waits.WaitAndClick(driver, historianPage.LnkHome);
            Waits.WaitAndClick(driver, homePage.LnkHistorian);
            Waits.WaitAndClick(driver, historianPage.LnkHistorianEquipmentData);
        }


        [Then(@"calculated paramter list loading time for '(.*)'\.")]
        public void ThenCalculatedParamterListLoadingTimeFor_(string dateRange)
        {
        }

        [Then(@"calculated adding parameter '(.*)' in graph timing for '(.*)'\.")]
        public void ThenCalculatedAddingParameterInGraphTimingFor_(string parameter, string dateRange)
        {

            string time = "";
            historianPage.DateRangeSelection(dateRange);
            Waits.Wait(driver, 3000);
            Waits.WaitAndClick(driver, historianPage.BtnApplyFilter);
            Waits.Wait(driver, 3000);
            if (dateRange.ToLower().Equals("1 week"))
            {
                historianPage.SelectParameter(historianPage.ImgCombusterTempForAWeek);
                Waits.Wait(driver, 10000);
                Waits.WaitForElementVisible(driver, historianPage.BtnAddParameter);
                Waits.WaitAndClick(driver, historianPage.BtnAddParameter);
                Stopwatch parameterLoadListtimer = new Stopwatch();
                parameterLoadListtimer.Start();
                historianPage.CheckParamterAddedInGraph(parameter);
                parameterLoadListtimer.Stop();
                excel.WriteToCell(6, 1, "Sheet1", "Adding " + parameter + " parameter time " + "(" + dateRange + ")");
                time = parameterLoadListtimer.Elapsed.ToString();
                excel.WriteToCell(6, 2, "Sheet1", time);
            }
            else if (dateRange.ToLower().Equals("1 month"))
            {
                historianPage.SelectParameter(historianPage.ImgCombusterTempForAMonth);
                Waits.Wait(driver, 10000);
                Waits.WaitAndClick(driver, historianPage.BtnAddParameter);
                Stopwatch parameterLoadListtimer = new Stopwatch();
                parameterLoadListtimer.Start();
                historianPage.CheckParamterAddedInGraph(parameter);
                parameterLoadListtimer.Stop();
                excel.WriteToCell(7, 1, "Sheet1", "Adding " + parameter + " parameter time " + "(" + dateRange + ")");
                time = parameterLoadListtimer.Elapsed.ToString();
                excel.WriteToCell(7, 2, "Sheet1", time);
            }
            else if (dateRange.ToLower().Equals("3 months"))
            {
                historianPage.SelectParameter(historianPage.ImgCombusterTempForThreeMonths);
                Waits.Wait(driver, 10000);
                Waits.WaitAndClick(driver, historianPage.BtnAddParameter);
                Stopwatch parameterLoadListtimer = new Stopwatch();
                parameterLoadListtimer.Start();
                historianPage.CheckParamterAddedInGraph(parameter);
                parameterLoadListtimer.Stop();
                excel.WriteToCell(8, 1, "Sheet1", "Adding " + parameter + " parameter time " + "(" + dateRange + ")");
                time = parameterLoadListtimer.Elapsed.ToString().Substring(0, 8);
                excel.WriteToCell(8, 2, "Sheet1", time);
            }
            else if (dateRange.ToLower().Equals("1 year"))
            {
                historianPage.SelectParameter(historianPage.ImgCombusterTempForAYear);
                Waits.Wait(driver, 10000);
                Waits.WaitAndClick(driver, historianPage.BtnAddParameter);
                Stopwatch parameterLoadListtimer = new Stopwatch();
                parameterLoadListtimer.Start();
                historianPage.CheckParamterAddedInGraph(parameter);
                parameterLoadListtimer.Stop();
                excel.WriteToCell(9, 1, "Sheet1", "Adding " + parameter + " parameter time " + "(" + dateRange + ")");
                time = parameterLoadListtimer.Elapsed.ToString();
                excel.WriteToCell(9, 2, "Sheet1", time);
            }
            historianPage.ClearGraph();
            Waits.WaitAndClick(driver, historianPage.LnkHome);
            Waits.WaitAndClick(driver, homePage.LnkHistorian);
            Waits.WaitAndClick(driver, historianPage.LnkHistorianEquipmentData);
        }

        [Then(@"saved  data in excel sheet '(.*)'")]
        public void ThenSavedDataInExcelSheet(string fileName)
        {

            string path = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\..\..\..\..\..\"));
            path = Path.Combine(path + fileName);
            ElementExtensions.DeleteFile(path);
            excel.SaveAs(path);
        }


    }
}
