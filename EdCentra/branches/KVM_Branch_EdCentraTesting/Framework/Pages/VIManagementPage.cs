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
    public class VIManagementPage : PageBase
    {
        private IWebDriver driver;

        public VIManagementPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }


        //objects for LoggingPage
        #region
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_viConfig_lnkDetails")]
        private IWebElement lnkDetailsTab;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_viConfig_lnkAdminister")]
        private IWebElement lnkAdministerTab;    

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clSystems_td0")]
        private IWebElement lnkVIsionBoxes;

        //Assigned Equipment - Label
        //div - id= ctl00_ctl00_cphContent_cphContent_viConfig_divSingleSelectionOnlyFunctions
        //[FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_viConfig_divSingleSelectionOnlyFunctions')]//label")]
        [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'TURBO_4001')]")]
        private IWebElement lblAssignedEquipment;

        //ctl00_ctl00_cphContent_cphContent_viConfig_clstSystems_td0
        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_viConfig_clstSystems_divListControl')]//table//tbody/tr[contains(@id, 'ctl00_ctl00_cphContent_cphContent_viConfig_clstSystems_tr0')]")]
        private IWebElement sltEquipment;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divctl00_ctl00_cphContent_cphContent_viConfig_btnGetSystems')]")]
        private IWebElement btnFindEquipment;

        //divctl00_ctl00_cphContent_cphContent_viConfig_btnOkLink
        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divctl00_ctl00_cphContent_cphContent_viConfig_btnOkLink')]")]
        private IWebElement applyEquipment;

        //ctl00_ctl00_cphContent_cphContent_viConfig_btnOkLink


        //divctl00_ctl00_cphContent_cphContent_viConfig_btnOKMessage
        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divctl00_ctl00_cphContent_cphContent_viConfig_btnOKMessage')]")]
        private IWebElement btnChangesAppliedOk;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'No Equipment Found')]")]
        private IWebElement msgNoEquipmentFound;

        [FindsBy(How = How.XPath, Using = "//div[@class='imgBtnWrapperBigger']//input[contains(@id,'btnGetSystem')]")]
        private IWebElement btnGetEquipment;

        //ctl00_ctl00_cphContent_cphContent_viConfig_lblSerialNumber
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_viConfig_lblSerialNumber")]
        private IWebElement txtSerialNumber;

        //ctl00_ctl00_cphContent_cphContent_viConfig_lblPartNumber
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_viConfig_lblPartNumber")]
        private IWebElement txtPartNumber;

        //ctl00_ctl00_cphContent_cphContent_viConfig_lblUnitUptime
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_viConfig_lblUnitUptime")]
        private IWebElement txtUnitUpTime;

        //Assigned Equipment - Choose button
        //ctl00_ctl00_cphContent_cphContent_viConfig_btnChooseEquipment
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_viConfig_btnChooseEquipment")]
        private IWebElement btnChooseAssignedEquipment;

        //src="../../img/equipment/Turbo Pump/icon_20@2x.png"
        [FindsBy(How = How.XPath, Using = "//img[@src='../../img/equipment/Turbo Pump/icon_20@2x.png']")] //'http://localhost/EdwardsScada/img/equipment/Turbo Pump/icon_20@2x.png']")]
        public IWebElement EquptTurboImage;

        //div[@class='imgBtnWrapperBigger']
        //[FindsBy(How = How.XPath, Using = "//label[contains(@for, 'TURBO4001')]")]
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ctl00_cphContent_cphContent_viConfig_divAssignedEquipment']//label[contains(text(), 'TURBO4001')]")]
        public IWebElement LblTurboAssingedEquipment;

        //ctl00_ctl00_rptMenu_ctl01_lblLinkText
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl01_lblLinkText")]
        private IWebElement linkHomePage;
        #endregion

        public IWebElement LnkVIsionBoxes
        {
            get { return lnkVIsionBoxes; }
            set { lnkVIsionBoxes = value; }
        }
        public IWebElement LinkHomePage
        {
            get  {return linkHomePage;}
            set  {linkHomePage = value;}
        }
        public IWebElement TxtSerialNumber
        {
            get { return txtSerialNumber; }
            set { txtSerialNumber = value; }
        }
        public IWebElement TxtPartNumber
        {
            get { return txtPartNumber; }
            set { txtPartNumber = value; }
        }
        public IWebElement TxtUnitUpTime
        {
            get { return txtUnitUpTime; }
            set { txtUnitUpTime = value; }
        }
        public IWebElement SltEquipment
        {
            get { return sltEquipment; }
            set { sltEquipment = value; }
        }
        public IWebElement ApplyEquipment
        {
            get { return applyEquipment; }
            set { applyEquipment = value; }
        }
        public IWebElement LblAssignedEquipment
        {
            get { return lblAssignedEquipment; }
            set { lblAssignedEquipment = value; }
        }
        public IWebElement BtnChooseAssignedEquipment
        {
            get { return btnChooseAssignedEquipment; }
            set { btnChooseAssignedEquipment = value; }
        }
        public IWebElement BtnChangesAppliedOk
        {
            get { return btnChangesAppliedOk; }
            set { btnChangesAppliedOk = value; }
        }
        public IWebElement BtnFindEquipment
        {
            get { return btnFindEquipment; }
            set { btnFindEquipment = value; }
        }
        public IWebElement MsgNoEquipmentFound
        {
            get { return msgNoEquipmentFound; }
            set { msgNoEquipmentFound = value; }
        }
        public IWebElement LnkAdministerTab
        {
            get { return lnkAdministerTab; }
            set { lnkAdministerTab = value; }
        }

        public IWebElement LnkDetailsTab
        {
            get { return lnkDetailsTab; }
            set { lnkDetailsTab = value; }
        }

        /// <summary>
        /// Click on Get Equipment
        /// </summary>
        public void ClickOnGetEquipment()
        {
            Waits.WaitAndClick(driver, btnGetEquipment);
        }
        
        /// <summary>
        /// Check Assigned Equipment has label
        /// </summary>
        /// <returns></returns>
        public bool VerifyAssignedEquipment()
        {
            bool status = false;
            //if (lblAssignedEquipment.ToString().Contains("TURBO4001"))
                if(EquptTurboImage.Displayed)// || LblTurboAssingedEquipment.Enabled)
                status = true;
            return status;
        }

        /// <summary>
        /// Click on VIsionBox
        /// </summary>
        public void ClickOnCreateProfileOption()
        {
            Waits.WaitAndClick(driver, lnkVIsionBoxes);
        }
    }
}
