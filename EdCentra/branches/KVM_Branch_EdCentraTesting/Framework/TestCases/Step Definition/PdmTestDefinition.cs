using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class PdmTestDefinition
    {
        string testFolderName = ElementExtensions.GetRandomString(4);
        private IWebDriver driver;
        HomePage homePage;
        LoginPage loginPage;
        PdMPage pdMPage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        PDMLicenseGenerator pdmLicenseGenerator = new PDMLicenseGenerator();
        string activationCode = string.Empty;


        public PdmTestDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            pdMPage = new PdMPage(driver);
        }

        [Given(@"Opened the EDCENTRA application url in browser")]
        public void GivenOpenedTheEDCENTRAApplicationUrlInBrowser()
        {
            PageInitialization();
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);
        }

        [When(@"I Enter the username as '(.*)' and password as '(.*)' and Clicked login button")]
        public void WhenIEnterTheUsernameAsAndPasswordAsAndClickedLoginButton(string username, string password)
        {
            loginPage.SignIn(username, password);
        }

        [Then(@"I Should be Navigated to the home page")]
        public void ThenIShouldBeNavigatedToTheHomePage()
        {
            Waits.WaitForElementVisible(driver, homePage.LnkDeviceManager);
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, homePage.LnkDeviceManager), "Verifying User should be navigated to Home page");
        }

        [When(@"Clicked on PDM link")]
        public void WhenClickedOnPDMLink()
        {
            Waits.WaitAndClick(driver, homePage.LnkPdM);
        }

        [Then(@"I should be navigated to PDM page")]
        public void ThenIShouldBeNavigatedToPDMPage()
        {
            bool isDisplayed = Waits.WaitForElementVisible(driver, pdMPage.PDMMenuImage);
            Assert.IsTrue(isDisplayed, "Verified user is not navigaed to PDM page on clicking PDM link");
        }

        [Then(@"copied site activation key available in the clipboard")]
        public void ThenCopiedSiteActivationKeyAvailableInTheClipboard()
        {
            Waits.Wait(driver, 5000);
            activationCode = pdMPage.ActivationCode();
        }

        [Given(@"Launched License Genrator")]
        public void GivenLaunchedLicenseGenrator()
        {
            pdmLicenseGenerator.LaunchPdMLicenseGeneratorApp();
        }

        [Given(@"Selected latest database")]
        public void GivenSelectedLatestDatabase()
        {
            pdmLicenseGenerator.SetDatabase();
        }


        [When(@"entered general settings fields i\.e\. Max Assignment Count '(.*)',Equipment Type '(.*)' & Author Name '(.*)'")]
        public void WhenEnteredGeneralSettingsFieldsI_E_MaxAssignmentCountEquipmentTypeAuthorName(int maxAssignmentCount, string equipmentName, string authorName)
        {
            pdmLicenseGenerator.EnterGeneralSettingsDataInLicenseGenerator(activationCode, maxAssignmentCount, equipmentName, authorName);
        }

        [When(@"filled algorithmName '(.*)', algTypeCode '(.*)', Max Assignment Count '(.*)', algorithm File '(.*)' & visualization File '(.*)'")]
        public void WhenFilledAlgorithmNameAlgTypeCodeMaxAssignmentCountAlgorithmFileVisualizationFile(string algorithmName, string algTypeCode, int count, string algorithmFile, string visualizationFile)
        {
            pdmLicenseGenerator.UploadAlgorithmDetails(algorithmName, algTypeCode, count, algorithmFile, visualizationFile);
        }


        [When(@"filled algorithmName MultiAlgo(.*), algorithmTypeCode Noz(.*), Max Assignment Count (.*), Algorithm File MdxN(.*)Compressed_VG(.*)_Alarm\.xml and Visualization File VisualisationXML_Algorithm\.txt")]
        public void WhenFilledAlgorithmNameMultiAlgoAlgorithmTypeCodeNozMaxAssignmentCountAlgorithmFileMdxNCompressed_VG_Alarm_XmlAndVisualizationFileVisualisationXML_Algorithm_Txt(string algorithmName, string algTypeCode, int count, string algorithmFile, string visualizationFile)
        {
            pdmLicenseGenerator.UploadAlgorithmDetails(algorithmName, algTypeCode, count, algorithmFile, visualizationFile);
        }


        [When(@"clicked Generate License button")]
        public void WhenClickedGenerateLicenseButton()
        {
            Thread.Sleep(1000);
            pdmLicenseGenerator.ClickGenerateLicense();
        }

        [Then(@"License should be generated for '(.*)'")]
        public void ThenLicenseShouldBeGeneratedFor(string licenseFileName)
        {
            pdmLicenseGenerator.SaveGenratedLicenseFile(licenseFileName);
        }


        [When(@"Give App Name '(.*)' and select license file generated in previous test and upload the license file")]
        public void WhenGiveAppNameAndSelectLicenseFileGeneratedInPreviousTestAndUploadTheLicenseFile(string appname)
        {
            //pdMPage.LnkImportApp.Click();
            pdMPage.EnterAppName(appname);
        }


        [AfterScenario]
        public void CleanUp()
        {
            pdmLicenseGenerator.KillProcess();
        }
    }
}
