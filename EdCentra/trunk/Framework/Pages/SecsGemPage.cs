using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class SecsGemPage:PageBase
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializing page
        /// </summary>
        /// <param name="driver"></param>
        public SecsGemPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for SecsGemPage
        #region Objects

        [FindsBy(How = How.Id, Using = "ctl00_cphContent_lnkSecsGemAgent")]
        private IWebElement lnkSecGemHostActivated;

        [FindsBy(How = How.Id, Using = "ctl00_cphContent_lnkSecsGem")]
        private IWebElement lnkSecGemServiceActivated;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_cphContent_divSecsGemAgentNetworkLinks']/a")]
        private IWebElement lnkViewNetworks;

        [FindsBy(How = How.XPath, Using = "//td[contains(.,'SECSGEM')]")]
        private IWebElement divSecsGEmSection;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_gvSecsGemVidMappings_tableScrollHead")]
        private IWebElement tblParameterWithVidMapping;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_gvSecsGemVidMappings_ctl02_txtVID")]
        private IWebElement vidStartingValueForParameter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_uplSecsGemVidMapping")]
        private IWebElement btnMappingChooseFile;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnUploadSecsGemVidMapping")]
        private IWebElement btnUpload;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnApplySecsGemVidMappings")]
        private IWebElement btnApply;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnOKMessage")]
        private IWebElement btnOK;
        
        #endregion

        #region Properties

        public IWebElement LnkSecsGemHostViewNetworks
        {
            get
            {
                return lnkViewNetworks;
            }
            set
            {
                lnkViewNetworks = value;
            }
        }

        public bool IsSecsGemSectionAvailableInNetworkLayout
        {
            get { return divSecsGEmSection.Displayed; }
        }

        public bool IsSecsGemVIDTableWithParameterExist
        {
            get { return tblParameterWithVidMapping.Displayed; }
        }

        public string GetStartingVIDValueForParameter
        {
            get { return vidStartingValueForParameter.GetAttribute("value").ToString(); }
        }

        public IWebElement LnkSecGemAgentHost
        {
            get
            {
                return lnkSecGemHostActivated;
            }
            set
            {
                lnkSecGemHostActivated = value;
            }
        }

        public IWebElement LnkSecGemServiceEquipment
        {
            get
            {
                return lnkSecGemServiceActivated;
            }
            set
            {
                lnkSecGemServiceActivated = value;
            }
        }
        #endregion

        #region Methods
        public void MapSecondSecsGemFile()
        {
            Waits.WaitForElementVisible(driver, btnMappingChooseFile);
            btnMappingChooseFile.SendKeys(GlobalConstants.MappingSecondFilePath);

            Waits.Wait(driver, 3000);
            Waits.WaitAndClick(driver, btnUpload);
            Waits.Wait(driver, 8000);
        }

        public void EditVidValueForParameterAndClickApply(string updatedValue)
        {
            vidStartingValueForParameter.Clear();
            vidStartingValueForParameter.SendKeys(updatedValue);
            Waits.WaitAndClick(driver, btnApply);
        }

        public void ClickOKConfirmationMessage()
        {
            Waits.WaitAndClick(driver, btnOK);
        }
        #endregion
    }
}
