using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class SPCTestsStepDefinition
    {
        string testFolderName = string.Empty;//ElementExtensions.GetRandomString(4);
        string parentHandle = string.Empty;
        string renameFolder = ElementExtensions.GetRandomString(4);
        string equipmentName = ElementExtensions.GetRandomAlphabeticalString(4);
        LoginPage loginPage;
        HomePage homePage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        LoggingPage loggingPage;
        HistorianPage historianPage;
        LiveAlertsListPage liveAlertsListPage;
        DataExtractionPage dataExtractionPage;
        ReportPage reportPage;
        UserPage userPage;
        SPCPage spcPage;
        Simulator simulator = new Simulator();
        private IWebDriver driver;

        public SPCTestsStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [When(@"Launched Eissa, started simulator Check Randomparameter and selected device type '(.*)'\.")]
        public void WhenLaunchedEissaStartedSimulatorCheckRandomparameterAndSelectedDeviceType_(string deviceType)
        {
            simulator.LaunchSimulator();
            simulator.CheckRandomParameterCheckbox();
            simulator.SelectEquipment(deviceType);
            simulator.MinimizeWindow();
        }

        [When(@"I selected the equipment type, entered equipmentName'(.*)' '(.*)' '(.*)' '(.*)',Cliked Find Equipment button, selected one equipment and clicked Add button")]
        public void WhenISelectedTheEquipmentTypeEnteredEquipmentNameClikedFindEquipmentButtonSelectedOneEquipmentAndClickedAddButton(string equipmentName, string equipmentName1, string equipmentName2, string equipmentName3)
        {
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            Waits.WaitForElementVisible(driver, loggingPage.LnkAddDevice);
            loggingPage.AddEquipment(equipmentName);
            Waits.Wait(driver, 1000);
            loggingPage.ClickOkAfterConformationMessage();
            Waits.WaitForElementVisible(driver, loggingPage.LnkAddDevice);
            loggingPage.AddEquipment(equipmentName1);
            Waits.Wait(driver, 1000);
            loggingPage.ClickOkAfterConformationMessage();
            Waits.WaitForElementVisible(driver, loggingPage.LnkAddDevice);
            loggingPage.AddEquipment(equipmentName2);
            Waits.Wait(driver, 1000);
            loggingPage.ClickOkAfterConformationMessage();
            Waits.WaitForElementVisible(driver, loggingPage.LnkAddDevice);
            loggingPage.AddEquipment(equipmentName3);
            Waits.Wait(driver, 1000);
            loggingPage.ClickOkAfterConformationMessage();
        }

        [When(@"I Change User Preference")]
        public void WhenIChangeUserPreference()
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkLoginUser);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkPreferences);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkPreferences);
            Assert.IsTrue(deviceExplorerNavigationPage.LnkUserPreferences.Displayed, "Verfied User Preference window Open successfully");
            deviceExplorerNavigationPage.UpdateUserPreference();
            Waits.Wait(driver, 2000);
        }

        [When(@"I Change Temperature User Preference\.")]
        public void WhenIChangeTemperatureUserPreference_()
        {
            if (homePage == null)
                homePage = new HomePage(driver);
            Waits.WaitAndClick(driver, homePage.LnkLoginUser);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LnkPreferences);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkPreferences);
            Assert.IsTrue(deviceExplorerNavigationPage.LnkUserPreferences.Displayed, "Verfied User Preference window Open successfully");
            if (spcPage == null)
                spcPage = new SPCPage(driver);
            spcPage.ChangeUserPreference();
            Waits.Wait(driver, 1000);
        }

        [When(@"Go into Historian - SPC section and select a parameter '(.*)' from a system with logged data\.")]
        public void WhenGoIntoHistorian_SPCSectionAndSelectAParameterFromASystemWithLoggedData_(string parameter)
        {
            testFolderName = (string)ScenarioContext.Current["TestFolderName"];
            if (loggingPage == null)
                loggingPage = new LoggingPage(driver);
            loggingPage.NavigateToHomePage();
            Waits.Wait(driver, 1000);
            if (homePage == null)
                homePage = new HomePage(driver);
            homePage.NavigateToSPC();
            if (spcPage == null)
                spcPage = new SPCPage(driver);
            spcPage.SelectDateRange();
            Waits.Wait(driver, 1000);
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            historianPage.ExpandSystemsParameter(testFolderName);
            Waits.Wait(driver, 1000);
            historianPage.SelectSingleParameterEquipment(parameter);
            Waits.Wait(driver, 1000);
        }

        [When(@"select the parameter '(.*)' from the list of available parameters")]
        public void WhenSelectTheParameterFromTheListOfAvailableParameters(string parameter)
        {
            Waits.Wait(driver, 1000);
            historianPage.DateRangeSelection("today");
            Waits.Wait(driver, 3000);
            historianPage.SetAggregation("120");
            historianPage.ClickOnApply();
           // Waits.WaitAndClick(driver, historianPage.BtnApplyFilter);
            Waits.Wait(driver, 140000);
            historianPage.SelectSingleParameter(parameter);
            
        }

        [Then(@"the graph should be displayed on the right side and the range graph should display non negative numbers")]
        public void ThenTheGraphShouldBeDisplayedOnTheRightSideAndTheRangeGraphShouldDisplayNonNegativeNumbers()
        {
            bool negativeNumber;
            string parameter = "Mean Range";
            
            Waits.Wait(driver, 3000);
            if (deviceExplorerNavigationPage == null)
                deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            string tooltip = deviceExplorerNavigationPage.GetToolTipTextForRangeGraph(parameter);
             negativeNumber = tooltip.Contains("-") ? true : false;
            Assert.IsFalse(negativeNumber,"Mean Range graph contains negative numbers");
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            historianPage.UpdateMetric("Minimum");//Metric Value-Minimum
            Waits.Wait(driver, 5000);
            string minimumRangetooltip = deviceExplorerNavigationPage.GetToolTipTextForRangeGraph(parameter);
             negativeNumber = minimumRangetooltip.Contains("-") ? true : false;
            Assert.IsFalse(negativeNumber, "Minimum Range graph contains negative numbers");
            historianPage.UpdateMetric("Maximum");//Metric Value-Maximum
            Waits.Wait(driver, 5000);
            string maximumRangetooltip = deviceExplorerNavigationPage.GetToolTipTextForRangeGraph(parameter);
            negativeNumber = maximumRangetooltip.Contains("-") ? true : false;
            Assert.IsFalse(negativeNumber, "Minimum Range graph contains negative numbers");
        }

        [Then(@"Parameter'(.*)' listed")]
        public void ThenParameterListed(string parameter)
        {
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            for (int i = 1; i <= 10; i++)
            {
                Waits.Wait(driver, 1000);
                if (historianPage.IsSelectedParameterListPresent(parameter))
                {
                    Assert.IsTrue(historianPage.IsSelectedParameterListPresent(parameter), "Verified The parameters for that equipment will be displayed");
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        [When(@"SPC section and select a parameter '(.*)' from a system with logged data\.")]
        public void WhenSPCSectionAndSelectAParameterFromASystemWithLoggedData_(string parameter)
        {
            if (historianPage == null)
                historianPage = new HistorianPage(driver);
            historianPage.SelectSingleParameter(parameter);
            Waits.Wait(driver, 140000);
            JavaScriptExecutor.JavaScriptClick(driver, spcPage.LnkClearAll);
            Waits.Wait(driver, 2000);
            historianPage.SelectSingleParameter(parameter);
            Waits.Wait(driver, 1000);
        }

        [Then(@"SPC graph should show with the '(.*)' value in the top graph and '(.*)' value below")]
        public void ThenSPCGraphShouldShowWithTheValueInTheTopGraphAndValueBelow(string parameter1, string parameter2)
        {
            if (spcPage == null)
                spcPage = new SPCPage(driver);
            Waits.Wait(driver, 1000);
            int mean = 22;
            int point = 19;
            string Meantooltip = spcPage.GetToolTipRangeText(parameter1, mean, point);
            Assert.IsTrue(Meantooltip != null, "SPC graph is not displayed Mean value");
            Waits.Wait(driver, 3000);
            int mean1 = 27;
            int point1 = 22;
            string MeanRangetooltip = spcPage.GetToolTipRangeText(parameter1, mean1, point1);
            Assert.IsTrue(MeanRangetooltip != null, "SPC graph is not displayed Mean Range value");
            Waits.Wait(driver, 3000);
        }

        [When(@"Choose a different metric '(.*)' from the drop down below the charts\.")]
        public void WhenChooseADifferentMetricFromTheDropDownBelowTheCharts_(string metric)
        {
            spcPage.SelectMetric(metric);
            Waits.Wait(driver, 4000);
        }

        [Then(@"The chart should re-draw the parameter '(.*)' and the top chart should now show the Maximum value '(.*)' at a given time\.")]
        public void ThenTheChartShouldRe_DrawTheParameterAndTheTopChartShouldNowShowTheMaximumValueAtAGivenTime_(string parameter, string value)
        {
            Waits.Wait(driver, 1000);
            JavaScriptExecutor.JavaScriptClick(driver, spcPage.LnkClearAll);
            Waits.Wait(driver, 2000);
            historianPage.SelectSingleParameter(parameter);
            Waits.Wait(driver, 3000);
            int mean = 22;
            int point = 21;
            string Maximumtooltip = spcPage.GetToolTipRangeText(value, mean, point);
            Assert.IsTrue(Maximumtooltip != null, "SPC graph is not redraw & displayed Maximum value");
        }

        [When(@"Change the control limit drop-down below the chart\.")]
        public void WhenChangeTheControlLimitDrop_DownBelowTheChart_()
        {
            spcPage.SelectControlLimit();
            Waits.Wait(driver, 1000);
        }

        [Then(@"The chart should re-draw the parameter '(.*)' and the red control limit '(.*)' lines should reflect the option selected in the drop-down")]
        public void ThenTheChartShouldRe_DrawTheParameterAndTheRedControlLimitLinesShouldReflectTheOptionSelectedInTheDrop_Down(string parameter, string value)
        {
            Waits.Wait(driver, 1000);
            JavaScriptExecutor.JavaScriptClick(driver, spcPage.LnkClearAll);
            Waits.Wait(driver, 2000);
            historianPage.SelectSingleParameter(parameter);
            Waits.Wait(driver, 3000);
            int index = 24;
            int point = 23;
            Assert.IsTrue(spcPage.SelectedParameter(value, index, point), "Verified The chart should not re-draw and the red control limit");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select another parameter '(.*)' on the same system by clicking it in the list\.")]
        public void WhenSelectAnotherParameterOnTheSameSystemByClickingItInTheList_(string parameter)
        {
            historianPage.SelectSingleParameter(parameter);
            Waits.Wait(driver, 3000);
        }

        [Then(@"Chart should re-draw with the selected parameter '(.*)' now show instead of the previous one\.")]
        public void ThenChartShouldRe_DrawWithTheSelectedParameterNowShowInsteadOfThePreviousOne_(string parameter)
        {
            Assert.IsTrue(spcPage.IsGraphDisplayedParameter(parameter), "Verified Selected another parameter on the same system is not listed");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select another system '(.*)' of the same type in the Systems tree\.")]
        public void WhenSelectAnotherSystemOfTheSameTypeInTheSystemsTree_(string system)
        {
            historianPage.SelectSingleParameterEquipment(system);
            Waits.Wait(driver, 3000);
        }

        [Then(@"Chart should re-draw with the equivalent parameter now plotted from the newly selected system '(.*)'\.")]
        public void ThenChartShouldRe_DrawWithTheEquivalentParameterNowPlottedFromTheNewlySelectedSystem_(string parameter)
        {
            Assert.IsTrue(spcPage.IsGraphDisplayedParameter(parameter), "Verified Selected another parameter on the same system is not listed");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select another system '(.*)' of a different type from the Systems tree\.")]
        public void WhenSelectAnotherSystemOfADifferentTypeFromTheSystemsTree_(string system)
        {
            historianPage.SelectSingleParameterEquipment(system);
            Waits.Wait(driver, 3000);
        }

        [Then(@"Parameters '(.*)' are loaded from the selected system but the graph is not changed and retains its current system/parameter '(.*)'\.")]
        public void ThenParametersAreLoadedFromTheSelectedSystemButTheGraphIsNotChangedAndRetainsItsCurrentSystemParameter_(string parameter1, string parameter2)
        {
            for (int i = 1; i <= 10; i++)
            {
                Waits.Wait(driver, 1000);
                if (historianPage.IsSelectedParameterListPresent(parameter1))
                {
                    Assert.IsTrue(historianPage.IsSelectedParameterListPresent(parameter1), "Verified The parameters are loaded from the selected system");
                    break;
                }
                else
                {
                    continue;
                }
            }

            Assert.IsTrue(spcPage.IsGraphDisplayedParameter(parameter2), "Verified graph is not changed and retains its current system/parameter");
            Waits.Wait(driver, 1000);
        }

        [When(@"Click the Box Plot tab\.")]
        public void WhenClickTheBoxPlotTab_()
        {
            Waits.WaitAndClick(driver, spcPage.LnkBoxPlot);
            Waits.Wait(driver, 3000);
        }

        [Then(@"Box plot graph will show with the previously selected paramter '(.*)' now rendered as a box plot\.")]
        public void ThenBoxPlotGraphWillShowWithThePreviouslySelectedParamterNowRenderedAsABoxPlot_(string parameter)
        {
            Assert.IsTrue(spcPage.IsBoxPlotDisplayedParameter(parameter), "Verified Box plot graph will not show the previously selected paramter");
            Waits.Wait(driver, 1000);
        }

        [When(@"I Select another system '(.*)' of the same type in the Systems tree\.")]
        public void WhenISelectAnotherSystemOfTheSameTypeInTheSystemsTree_(string system)
        {
            historianPage.SelectSingleParameterEquipment(system);
            Waits.Wait(driver, 3000);
        }

        [Then(@"Another box plot is added to the graph showing the equivalent parameters '(.*)' '(.*)' from the newly selected system")]
        public void ThenAnotherBoxPlotIsAddedToTheGraphShowingTheEquivalentParametersFromTheNewlySelectedSystem(string parameter1, string parameter2)
        {
            Assert.IsTrue(spcPage.IsBoxPlotDisplayedParameter(parameter1), "Verified Box plot graph will not show the equivalent parameter newly selected system");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(spcPage.IsBoxPlotDisplayedParameter(parameter2), "Verified Box plot graph will not show the equivalent parameter newly selected system");
            Waits.Wait(driver, 1000);
        }

        [When(@"Select the Graph tab")]
        public void WhenSelectTheGraphTab()
        {
            Waits.WaitAndClick(driver, spcPage.LnkGraphTab);
            Waits.Wait(driver, 1000);
        }

        [Then(@"SPC graph is one again shown for the last system'(.*)' selected\.")]
        public void ThenSPCGraphIsOneAgainShownForTheLastSystemSelected_(string parameter)
        {
            Assert.IsTrue(spcPage.IsGraphDisplayedParameter(parameter), "Verified SPC graph is one again not shown for the last system selected");
            Waits.Wait(driver, 1000);
            simulator.RestoreWindow();
            Waits.Wait(driver, 1000);
            simulator.StopSimulator();
            simulator.UnCheckRandomParameterCheckbox();
            Waits.Wait(driver, 1000);
            simulator.KillProcess();
        }
    }
}
