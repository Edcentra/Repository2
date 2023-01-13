using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class SecsGemStepDefinition
    {
        string testFolderName = ElementExtensions.GetRandomString(4);
        string unitText = string.Empty;
        Simulator simulator = new Simulator();
        HistorianPage historianPage;
        SecsGemPage secsGemPage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        HomePage homePage;
        string iPAdress = SpecflowHooks.HostIpAddress();
        string fpName = "";
        private IWebDriver driver;
        SecsGemSimulator secsGemSimulator = new SecsGemSimulator();

        public SecsGemStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            historianPage = new HistorianPage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            homePage = new HomePage(driver);
            secsGemPage = new SecsGemPage(driver);
        }

        [When(@"I click on SECS/GEM Agent \(Host\) item")]
        public void WhenIClickOnSECSGEMAgentHostItem()
        {
            if (secsGemPage == null)
                secsGemPage = new SecsGemPage(driver);
            Waits.WaitAndClick(driver, secsGemPage.LnkSecGemAgentHost);
        }

        [Then(@"the panel shows with description and a View Network link")]
        public void ThenThePanelShowsWithDescriptionAndAViewNetworkLink()
        {
            if (secsGemPage == null)
                secsGemPage = new SecsGemPage(driver);
            Assert.IsTrue(secsGemPage.LnkSecsGemHostViewNetworks.Displayed);
        }


        [When(@"I Click on the View Networks link")]
        public void WhenIClickOnTheViewNetworksLink()
        {
            if (secsGemPage == null)
                secsGemPage = new SecsGemPage(driver);
            Waits.WaitAndClick(driver, secsGemPage.LnkSecsGemHostViewNetworks);
        }

        [Then(@"I should see the SecsGem section in Network layout screen")]
        public void ThenIShouldSeeTheSecsGemSectionInNetworkLayoutScreen()
        {
            if (secsGemPage == null)
                secsGemPage = new SecsGemPage(driver);
            Assert.IsTrue(secsGemPage.IsSecsGemSectionAvailableInNetworkLayout, "Secs/Gem section not available in Network Layout Screen");
        }

        [Then(@"VIDs are displayed for each parameter starting from '(.*)'")]
        public void ThenVIDsAreDisplayedForEachParameterStartingAt(string vidStartingValue)
        {
            if (secsGemPage == null)
                secsGemPage = new SecsGemPage(driver);
            Assert.IsTrue(secsGemPage.IsSecsGemVIDTableWithParameterExist, "Parameter with VID value does not exist");
            Assert.AreEqual(vidStartingValue, secsGemPage.GetStartingVIDValueForParameter);
        }

        [When(@"I upload the second file in Map Secs/Gem VID's popup")]
        public void WhenIUploadTheSecondFileInMapSecsGemVIDSPopup()
        {
            if (secsGemPage == null)
                secsGemPage = new SecsGemPage(driver);
            secsGemPage.MapSecondSecsGemFile();
        }

        [When(@"I edit the VID value for a parameter and click Apply button")]
        public void WhenIEditTheVIDValueForAParameterAndClickApplyButton()
        {
            if (secsGemPage == null)
                secsGemPage = new SecsGemPage(driver);
            secsGemPage.EditVidValueForParameterAndClickApply("30001");
            secsGemPage.ClickOKConfirmationMessage();
            Waits.Wait(driver, 10000);
        }

        [Then(@"the updated value should reflect in the corresponding parameters VID")]
        public void ThenTheUpdatedValueShouldReflectInTheCorrespondingParametersVID()
        {
            if (secsGemPage == null)
                secsGemPage = new SecsGemPage(driver);
            Assert.AreEqual("30001", secsGemPage.GetStartingVIDValueForParameter);
        }

        [When(@"Connect to the SECS/GEM Service with the SECS/GEM Support Host\.")]
        public void WhenConnectToTheSECSGEMServiceWithTheSECSGEMSupportHost_()
        {
            secsGemSimulator.LaunchSecsGemHost();
            secsGemSimulator.ConnectHost();
        }

        [Then(@"the pannel open and tab activation")]
        public void ThenThePannelOpenAndTabActivation()
        {
            secsGemSimulator.OpenTabUnlock();
            secsGemSimulator.SelectCheckBoxs();
            secsGemSimulator.CloseTabUnlock();
            Thread.Sleep(1000);
        }

        [When(@"Send '(.*)' message '(.*)'\.")]
        public void WhenSendMessage_(string version, string message)
        {
            secsGemSimulator.SelectTab();
            secsGemSimulator.SelectQueryMessage(version, message);
            secsGemSimulator.SendQuery();
        }

        [Then(@"The SECS/GEM Service will respond with an '(.*)' message\. The format will be:")]
        public void ThenTheSECSGEMServiceWillRespondWithAnMessage_TheFormatWillBe(string version, Table table)
        {
            Assert.AreEqual(table.Rows[0]["ListNodecount"].ToString(), secsGemSimulator.ListCount(), "Query not listed as per expectation");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(secsGemSimulator.ReadQueyText().Contains(table.Rows[0]["COMMACK"].ToString()), "Query not listed as per expectation");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(secsGemSimulator.ReadQueyText().Contains(table.Rows[0]["MDLN"].ToString()), "Query not listed as per expectation");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(secsGemSimulator.ReadQueyText().Contains(table.Rows[0]["SOFTREV"].ToString()), "Query not listed as per expectation");
            Waits.Wait(driver, 1000);
        }

        [When(@"Update the registry key IsSecsGemAgentCompatible to '(.*)'\.")]
        public void WhenUpdateTheRegistryKeyIsSecsGemAgentCompatibleTo_(string value)
        {
            secsGemSimulator.MinimizeWindow();
            secsGemSimulator.LaunchRegEdit();
            secsGemSimulator.ChangeRegEditValue(value);
            secsGemSimulator.RestoreWindow();
        }

        [When(@"Connect to the SECS/GEM Service '(.*)' with the SECS/GEM Support Host\. Send an '(.*)' message\.")]
        public void WhenConnectToTheSECSGEMServiceWithTheSECSGEMSupportHost_SendAnMessage_(string version, string message)
        {
            secsGemSimulator.SelectQueryMessage(version, message);
            secsGemSimulator.SendQuery();
        }

        [Then(@"The SECS/GEM Service will respond with an '(.*)' message\.Then the format will be:")]
        public void ThenTheSECSGEMServiceWillRespondWithAnMessage_ThenTheFormatWillBe(string p0, Table table)
        {
            Assert.AreEqual(table.Rows[0]["ListNodeNewcount"].ToString(), secsGemSimulator.ListCount(), "Query not listed as per expectation");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(secsGemSimulator.ReadQueyText().Contains(table.Rows[0]["COMMACK"].ToString()), "Query not listed as per expectation");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(secsGemSimulator.ReadQueyText().Contains(table.Rows[0]["MDLN"].ToString()), "Query not listed as per expectation");
            Waits.Wait(driver, 1000);
            Assert.IsTrue(secsGemSimulator.ReadQueyText().Contains(table.Rows[0]["SOFTREV"].ToString()), "Query not listed as per expectation");
            Waits.Wait(driver, 1000);
            secsGemSimulator.KillSecsGemHost();
            secsGemSimulator.LaunchRegEdit();
            secsGemSimulator.ChangeRegEditValue();
        }


    }
}
