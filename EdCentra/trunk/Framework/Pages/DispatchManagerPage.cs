using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class DispatchManagerPage : PageBase
    {
        IWebDriver driver;
        string HourFrom;
        string MinuteFrom;
        string HourTo;
        string MinuteTo;

        public DispatchManagerPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for dispatch manager page
        #region 

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Page Destinations']")]
        private IWebElement lnkPageDestinations;

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Scheduler']")]
        private IWebElement lnkScheduler;

        [FindsBy(How = How.XPath, Using = "//span[text()='New Page Destination']")]
        private IWebElement btnNewPageDestination;

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Inhibit Settings']")]
        private IWebElement lnkInhibitSettings;

        [FindsBy(How = How.XPath, Using = "//div[@class='settingstabs']//li//a[text()='SMTP']")]
        private IWebElement tabSMTPSetting;

        [FindsBy(How = How.XPath, Using = "//div[@class='settingstabs']//li//a[text()='SMTPAuth']")]
        private IWebElement tabSMTPAuthSetting;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtFrom_SMTP')]")]
        private IWebElement txtFromEmail_SMTP;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtSMTPServer_SMTP')]")]
        private IWebElement txtSMTPServer_SMTP;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtToAddress_SMTP')]")]
        private IWebElement txtToAddressEMail_SMTP;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtFrom_SMTPAuth')]")]
        private IWebElement txtFromEmail_SMTPAuth;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtSMTPServer_SMTPAuth')]")]
        private IWebElement txtSMTPServer_SMTPAuth;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtToAddress_SMTPAuth')]")]
        private IWebElement txtToAddressEMail_SMTPAuth;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnCreate')]")]
        private IWebElement btnCreateDestination;

        [FindsBy(How = How.XPath, Using = "//span[@class='infomessage']")]
        private IWebElement lblMessage;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnDelete')]")]
        private IWebElement btnDeleteDestination;

        [FindsBy(How = How.XPath, Using = "//div[@class='boxlist']")]
        private IWebElement lstPageDestination;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnNew')]")]
        private IWebElement btnNewSchedule;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlPageDestination')]")]
        private IWebElement dropdownListPageDestination;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlAlternativeDestination')]")]
        private IWebElement dropdownListAlternativePageDestination;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'chkWeekDays_lnkCheckbox')]//img")]
        private IWebElement chkBoxWeekDay;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'chkWeekends_lnkCheckbox')]//img")]
        private IWebElement chkBoxWeekendDay;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'chkAllDay_lnkCheckbox')]//img")]
        private IWebElement chkBoxAllDay;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'chkAlarm_lnkCheckbox')]//img")]
        private IWebElement chkAlarm;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnAddEquipment')]")]
        private IWebElement btnAddEquipment;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnGetSystems')]")]
        private IWebElement btnFindEquipment;

        [FindsBy(How = How.XPath, Using = "//div[@id='divFoundsystems']//div/table/tbody[@class='clist']")]
        private IWebElement lstEquipmentListtable;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnEquipmentModalAdd')]")]
        private IWebElement btnAddSelectedEquipment;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnAddAlert')]")]
        private IWebElement btnAddAlert;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnGetAlerts')]")]
        private IWebElement btnSearchAlerts;

        [FindsBy(How = How.XPath, Using = "//div[@id='divFoundAlerts']//div[contains(@id,'clAlerts')]//table//tbody[@class='clist']")]
        private IWebElement lstAlerts;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_btnAlertsModalAdd']")]
        private IWebElement btnAddSelectedAlerts;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlHourFrom")]
        private IWebElement dropdownHourFrom;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlMinuteFrom")]
        private IWebElement dropdownMinuteFrom;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlHourTo")]
        private IWebElement dropdownHourTo;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlMinuteTo")]
        private IWebElement dropdownMinuteTo;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnApply')]")]
        private IWebElement btnApply;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'gvSchedules')]/tbody")]
        private IWebElement lstScheduler;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Delete')]")]
        private IWebElement btnDelete;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnOKDelete')]")]
        private IWebElement btnOkDeleteConformation;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtSiteName")]
        private IWebElement txtSiteName;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_chkIncludeAlertMessage_imgCheckBox')]")]
        private IWebElement chkBoxIncludeAlertMsg;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtMessageBody")]
        private IWebElement txtAreaMsgBodyPrefix;

        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'imgBtnSmall')]")]
        private IWebElement btnServiceStatus;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblServiceStatus')]")]
        private IWebElement lblServiceStatus;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_rdoSendBulk_imgRadioButton")]
        private IWebElement rdBtnSendBulkAlert;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_rdoSendIndividual_imgRadioButton")]
        private IWebElement rdBtnSendIndividualAlert;

        [FindsBy(How = How.ClassName, Using = "infomessage")]
        private IWebElement lblSuccessMessage;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtFrom_SMTP")]
        private IWebElement txtFrom;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtFrom_SMTPAuth")]
        private IWebElement txtFromSMTPAuth;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtSMTPServer_SMTPAuth")]
        private IWebElement txtSMTPAuthServer;

        [FindsBy(How = How.Name, Using = "ctl00$ctl00$cphContent$cphContent$txtSNPPServer_SNPP")]
        private IWebElement txtSNPPServer;

        [FindsBy(How = How.Name, Using = "ctl00$ctl00$cphContent$cphContent$txtPagerNumber_SNPP")]
        private IWebElement txtPagerNumber;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtSMTPServer_SMTP")]
        private IWebElement txtSMTPServer;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtSMTPPort_SMTP")]
        private IWebElement txtSMTPPort;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtToAddress_SMTP")]
        private IWebElement txtToAddress;


        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtToAddress_SMTPAuth")]
        private IWebElement txtToAddressSMTPAuth;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtSMTPPort_SMTPAuth")]
        private IWebElement txtSMTPAuthPort;

        [FindsBy(How = How.XPath, Using = "//input[@value='Create']")]
        private IWebElement btnCreate;

        [FindsBy(How = How.Name, Using = "ctl00$ctl00$cphContent$cphContent$btnTest")]
        private IWebElement btnTest;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_UpdatePanel1")]
        private IWebElement panelSMTPPageDestination;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphSubMenuBar_lnkGeneral")]
        private IWebElement lnkGeneralSettings;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnManualPage")]
        private IWebElement btnManualPage;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Send a Page Message')]")]
        private IWebElement popUpSendMsg;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtMessage")]
        private IWebElement txtAreaMsg;

        [FindsBy(How = How.XPath, Using = "//input[@value='Send']")]
        private IWebElement btnSend;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblManualPageFeedback')]")]
        private IWebElement lblSuccessMsgManualPage;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkSMTPAuth")]
        private IWebElement lnkSMTPAuth;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlEngineer")]
        private IWebElement drpDwnEngineer;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlPageDestination")]
        private IWebElement drpdwnPageDestination;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_lblTitle_SMTP')]")]
        private IWebElement lblTitle_SMTP;

        [FindsBy(How = How.XPath, Using = "//span[@id='ctl00_ctl00_cphContent_cphContent_lblSettingsTitle']")]
        private IWebElement lblSettingsTitle;

        [FindsBy(How = How.XPath, Using = "//div[@class='settingsbody']//span[text()='New Schedule']")]
        private IWebElement lblNewSchedule;

        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ctl00_cphContent_cphContent_gvSchedules_divScrollContainer']")]
        private IWebElement lstPagedestination;

        [FindsBy(How = How.XPath, Using = "//tr[@class = 'alertRow selected']")]
        private IWebElement lnkScheduleEntry;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlAlternativeDestination")]
        private IWebElement drpdwnAlternativeDestination;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$txtAlternativeDelay')]")]
        private IWebElement txtAlternativeDelay;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_Image111')]")]
        private IWebElement imgExpandEquipment;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_clSelectedSystems_divListControl')]")]
        private IWebElement lstSelectedEquipment;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnRemoveEquipment')]")]
        private IWebElement btnRemoveEquipment;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_imgDownArrow')]")]
        private IWebElement imgExpandAlert;

        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'ctl00$ctl00$cphContent$cphContent$ddlAlertsSystemTypeFilter')]")]
        private IWebElement lstAlertsSystemTypeFilter;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Restrict Alert:')]")]
        private IWebElement lnkRestrictAlert;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_clSelectedAlerts_divListControl')]")]
        private IWebElement lstSelectedAlerts;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_lblSettingsTitle')]")]
        private IWebElement lblInhibitSettingsTitle;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnManualPageClose')]")]
        private IWebElement btnManualPageClose;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkSNPP")]
        private IWebElement lnkSNPP;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkPagemate")]
        private IWebElement lnkPagemate;

        [FindsBy(How = How.Name, Using = "ctl00$ctl00$cphContent$cphContent$txtPageNumber_Pagemate")]
        private IWebElement txtPageNumber;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkDerdack")]
        private IWebElement lnkDerdack;

        [FindsBy(How = How.Name, Using = "ctl00$ctl00$cphContent$cphContent$txtUserLogin_Derdack")]
        private IWebElement txtUserLogin;

        [FindsBy(How = How.Name, Using = "ctl00$ctl00$cphContent$cphContent$txtServerSoapURL_Derdack")]
        private IWebElement txtServerSoapURL;

        [FindsBy(How = How.Name, Using = "ctl00$ctl00$cphContent$cphContent$txtProviderName_Derdack")]
        private IWebElement txtProviderName;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnAddDestination')]")]
        private IWebElement btnAddDestination;

        [FindsBy(How = How.XPath, Using = "//a[conatins(@id,'ctl00_ctl00_cphContent_cphContent_ucPage_lnkSMTP')]")]
        private IWebElement lnkSMTPPage;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$ucPage$txtFrom_SMTP')]")]
        private IWebElement txtSMTPFrom_SMTP;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$ucPage$txtSMTPServer_SMTP')]")]
        private IWebElement txtServer_SMTP;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$ucPage$txtToAddress_SMTP')]")]
        private IWebElement txtToAddress_SMTP;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl01_lblLinkText")]
        private IWebElement lnkHome;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Apply')]")]
        private IWebElement btnApplySchedular;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'New Schedule has been created')]")]
        private IWebElement lblScheduleCreatedMsg;

        #endregion
        //Properties
        #region

        public IWebElement BtnApplySchedular
        {
            get
            {
                return btnApplySchedular;
            }
            set
            {
                btnApplySchedular = value;
            }
        }

        public IWebElement LnkHome
        {
            get
            {
                return lnkHome;
            }
            set
            {
                lnkHome = value;
            }
        }

        public IWebElement LnkScheduleEntry
        {
            get { return lnkScheduleEntry; }
            set { lnkScheduleEntry = value; }
        }

        public IWebElement LblScheduleCreatedMsg
        {
            get { return lblScheduleCreatedMsg; }
            set { lblScheduleCreatedMsg = value; }
        }

        public IWebElement PopUpSendMsg
        {
            get
            {
                return popUpSendMsg;
            }
            set
            {
                popUpSendMsg = value;
            }
        }

        public IWebElement DrpDwnEngineer
        {
            get
            {
                return drpDwnEngineer;
            }
            set
            {
                drpDwnEngineer = value;
            }
        }

        public IWebElement DrpdwnPageDestination
        {
            get
            {
                return drpdwnPageDestination;
            }
            set
            {
                drpdwnPageDestination = value;
            }
        }

        public IWebElement BtnAddDestination
        {
            get { return btnAddDestination; }
            set { btnAddDestination = value; }
        }

        public IWebElement TxtSMTPAuthServer
        {
            get
            {
                return txtSMTPAuthServer;
            }
            set
            {
                txtSMTPAuthServer = value;
            }
        }

        public IWebElement TxtSNPPServer
        {
            get { return txtSNPPServer; }
            set { txtSNPPServer = value; }
        }

        public IWebElement TxtPagerNumber
        {
            get { return txtPagerNumber; }
            set { txtPagerNumber = value; }
        }

        public IWebElement TxtAreaMsg
        {
            get
            {
                return txtAreaMsg;
            }
            set
            {
                txtAreaMsg = value;
            }
        }

        public IWebElement TxtToAddressSMTPAuth
        {
            get
            {
                return txtToAddressSMTPAuth;
            }
            set
            {
                txtToAddressSMTPAuth = value;
            }
        }

        public IWebElement ChkBoxAllDay
        {
            get
            {
                return chkBoxAllDay;
            }
            set
            {
                chkBoxAllDay = value;
            }
        }
        public IWebElement TxtSMTPAuthPort
        {
            get
            {
                return txtSMTPAuthPort;
            }
            set
            {
                txtSMTPAuthPort = value;
            }
        }


        public IWebElement TxtFromSMTPAuth
        {
            get
            {
                return txtFromSMTPAuth;
            }
            set
            {
                txtFromSMTPAuth = value;
            }
        }

        public IWebElement LblInhibitSettingsTitle
        {
            get
            {
                return lblInhibitSettingsTitle;
            }
            set
            {
                lblInhibitSettingsTitle = value;
            }
        }

        public IWebElement BtnSend
        {
            get
            {
                return btnSend;
            }
            set
            {
                btnSend = value;
            }
        }

        public IWebElement TxtSiteName
        {
            get
            {
                return txtSiteName;
            }
            set
            {
                txtSiteName = value;
            }
        }

        public IWebElement ChkBoxIncludeAlertMsg
        {
            get
            {
                return chkBoxIncludeAlertMsg;
            }
            set
            {
                chkBoxIncludeAlertMsg = value;
            }
        }

        public IWebElement BtnServiceStatus
        {
            get
            {
                return btnServiceStatus;
            }
            set
            {
                btnServiceStatus = value;
            }
        }

        public IWebElement LblSuccessMsgManualPage
        {
            get
            {
                return lblSuccessMsgManualPage;
            }
            set
            {
                lblSuccessMsgManualPage = value;
            }
        }

        public IWebElement TxtAreaMsgBodyPrefix
        {
            get
            {
                return txtAreaMsgBodyPrefix;
            }
            set
            {
                txtAreaMsgBodyPrefix = value;
            }
        }

        public IWebElement LblServiceStatus
        {
            get
            {
                return lblServiceStatus;
            }
            set
            {
                lblServiceStatus = value;
            }
        }

        public IWebElement RdBtnSendBulkAlert
        {
            get
            {
                return rdBtnSendBulkAlert;
            }
            set
            {
                rdBtnSendBulkAlert = value;
            }
        }

        public IWebElement LnkSMTPAUTH
        {
            get
            {
                return lnkSMTPAuth;
            }
            set
            {
                lnkSMTPAuth = value;
            }

        }

        public IWebElement RdBtnSendIndividualAlert
        {
            get
            {
                return rdBtnSendIndividualAlert;
            }
            set
            {
                rdBtnSendIndividualAlert = value;
            }
        }

        public IWebElement LblSuccessMessage
        {
            get
            {
                return lblSuccessMessage;
            }
            set
            {
                lblSuccessMessage = value;
            }
        }

        public IWebElement LnkPageDestinations
        {
            get
            {
                return lnkPageDestinations;
            }
            set
            {
                lnkPageDestinations = value;
            }
        }

        public IWebElement LstPagedestination
        {
            get { return lstPagedestination; }
            set { lstPagedestination = value; }
        }

        public IWebElement DrpdwnAlternativeDestination
        {
            get { return drpdwnAlternativeDestination; }
            set { drpdwnAlternativeDestination = value; }
        }

        public IWebElement TxtAlternativeDelay
        {
            get { return txtAlternativeDelay; }
            set { txtAlternativeDelay = value; }
        }

        public IWebElement ImgExpandEquipment
        {
            get { return imgExpandEquipment; }
            set { imgExpandEquipment = value; }
        }

        public IWebElement TxtFrom
        {
            get
            {
                return txtFrom;
            }
            set
            {
                txtFrom = value;
            }
        }

        public IWebElement TxtSMTPServer
        {
            get
            {
                return txtSMTPServer;
            }
            set
            {
                txtSMTPServer = value;
            }
        }

        public IWebElement TxtSMTPPort
        {
            get
            {
                return txtSMTPPort;
            }
            set
            {
                txtSMTPPort = value;
            }
        }

        public IWebElement TxtToAddress
        {
            get
            {
                return txtToAddress;
            }
            set
            {
                txtToAddress = value;
            }
        }

        public IWebElement BtnCreate
        {
            get
            {
                return btnCreate;
            }
            set
            {
                btnCreate = value;
            }
        }

        public IWebElement BtnTest
        {
            get
            {
                return btnTest;
            }
            set
            {
                btnTest = value;
            }
        }

        public IWebElement PanelSMTPPageDestination
        {
            get
            {
                return panelSMTPPageDestination;
            }
            set
            {
                panelSMTPPageDestination = value;
            }
        }

        public IWebElement LnkGeneralSettings
        {
            get
            {
                return lnkGeneralSettings;
            }
            set
            {
                lnkGeneralSettings = value;
            }
        }

        public IWebElement LnkInhibitSettings
        {
            get
            {
                return lnkInhibitSettings;
            }
            set
            {
                lnkInhibitSettings = value;
            }
        }

        public IWebElement BtnManualPage
        {
            get
            {
                return btnManualPage;
            }
            set
            {
                btnManualPage = value;
            }
        }

        public IWebElement LblSettingsTitle
        {
            get
            {
                return lblSettingsTitle;
            }
            set
            {
                lblSettingsTitle = value;
            }
        }

        public IWebElement LblTitle_SMTP
        {
            get { return lblTitle_SMTP; }
            set { lblTitle_SMTP = value; }
        }

        public IWebElement LblNewSchedule
        {
            get { return lblNewSchedule; }
            set { lblNewSchedule = value; }
        }

        public IWebElement BtnAddEquipment
        {
            get { return btnAddEquipment; }
            set { btnAddEquipment = value; }
        }

        public IWebElement BtnAddAlert
        {
            get { return btnAddAlert; }
            set { btnAddAlert = value; }
        }

        public IWebElement ImgExpandAlert
        {
            get { return imgExpandAlert; }
            set { imgExpandAlert = value; }
        }

        public IWebElement LnkRestrictAlert
        {
            get { return lnkRestrictAlert; }
            set { lnkRestrictAlert = value; }
        }

        public IWebElement BtnNewPageDestination
        {
            get { return btnNewPageDestination; }
            set { btnNewPageDestination = value; }
        }

        public IWebElement BtnManualPageClose
        {
            get { return btnManualPageClose; }
            set { btnManualPageClose = value; }
        }

        public IWebElement LnkSNPP
        {
            get { return lnkSNPP; }
            set { lnkSNPP = value; }
        }

        public IWebElement LnkPagemate
        {
            get { return lnkPagemate; }
            set { lnkPagemate = value; }
        }

        public IWebElement TxtPageNumber
        {
            get { return txtPageNumber; }
            set { txtPageNumber = value; }
        }

        public IWebElement LnkDerdack
        {
            get { return lnkDerdack; }
            set { lnkDerdack = value; }
        }

        public IWebElement TxtUserLogin
        {
            get { return txtUserLogin; }
            set { txtUserLogin = value; }
        }

        public IWebElement TxtServerSoapURL
        {
            get { return txtServerSoapURL; }
            set { txtServerSoapURL = value; }
        }

        public IWebElement TxtProviderName
        {
            get { return txtProviderName; }
            set { txtProviderName = value; }
        }

        public IWebElement LnkSMTPPage
        {
            get { return lnkSMTPPage; }
            set { lnkSMTPPage = value; }
        }

        public IWebElement TxtSMTPFrom_SMTP
        {
            get { return txtSMTPFrom_SMTP; }
            set { txtSMTPFrom_SMTP = value; }
        }

        public IWebElement TxtServer_SMTP
        {
            get { return txtServer_SMTP; }
            set { txtServer_SMTP = value; }
        }

        public IWebElement TxtToAddress_SMTP
        {
            get { return txtToAddress_SMTP; }
            set { txtToAddress_SMTP = value; }
        }

        public IWebElement ChkBoxWeekDay
        {
            get { return chkBoxWeekDay; }
            set { chkBoxWeekDay = value; }
        }

        public IWebElement ChkBoxWeekendDay
        {
            get { return chkBoxWeekendDay; }
            set { chkBoxWeekendDay = value; }
        }

        #endregion
        //Methods
        #region

        /// <summary>
        /// To Create Page destination for SMTP
        /// </summary>
        /// <param name="FromEmail_SMTP"></param>
        /// <param name="SMTP_Server"></param>
        /// <param name="ToAddressEmail_SMTP"></param>
        public void CreateNewSMTPDestination(string FromEmail_SMTP, string SMTP_Server, string ToAddressEmail_SMTP)
        {
            NavigateToPageDestinationLink();
            if (!IS_SMTP_PageDestination_Exist())
            {
                ClickOnNewPageDestinationButton();
                SwitchToSMTP_Tab();
                EnterFromEmail_SMTP(FromEmail_SMTP);
                EnterSMTPServer(SMTP_Server);
                EnterToAddress_SMTP(ToAddressEmail_SMTP);
                ClickOnCreateDestination();
            }
        }

        /// <summary>
        /// To Create Page destination for SMTPAuth
        /// </summary>
        /// <param name="FromEmail_SMTPAuth"></param>
        /// <param name="SMTPAuth_Server"></param>
        /// <param name="ToAddressEmail_SMTPAuth"></param>
        public void CreateNewSMTPAuthDestination(string FromEmail_SMTPAuth, string SMTPAuth_Server, string ToAddressEmail_SMTPAuth)
        {
            NavigateToPageDestinationLink();
            if (!IS_SMTPAuth_PageDestination_Exist())
            {
                ClickOnNewPageDestinationButton();
                SwitchToSMTPAuth_Tab();
                EnterFromEmail_SMTPAuth(FromEmail_SMTPAuth);
                EnterSMTPAuthServer(SMTPAuth_Server);
                EnterToAddress_SMTPAuth(ToAddressEmail_SMTPAuth);
                ClickOnCreateDestination();
            }
        }

        /// <summary>
        /// Delete already created schedule
        /// </summary>
        public void DeleteSchedule()
        {
            SelectCreatedSchedule();
            Thread.Sleep(1000);
            ElementExtensions.ClickOnButton(btnDelete);
            Thread.Sleep(2000);
            ElementExtensions.ClickOnButton(btnOkDeleteConformation);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// To Verify the SMTP pagedestination Is Exist
        /// </summary>
        /// <returns></returns>
        public bool IS_SMTP_PageDestination_Exist()
        {
            IWebElement baseTable = lstPageDestination;

            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));

            if (list.Count() > 0)
            {
                if (IsElemetPresent(driver, By.XPath("//img[@alt='SMTP']")))
                {
                    if (baseTable.FindElement(By.XPath("//img[@alt='SMTP']")).GetAttribute("alt") == "SMTP")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// To Verify the SMTPAuth pagedestination Is Exist
        /// </summary>
        /// <returns></returns>
        public bool IS_SMTPAuth_PageDestination_Exist()
        {
            IWebElement baseTable = lstPageDestination;

            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));

            if (list.Count() > 0)
            {
                if (IsElemetPresent(driver, By.XPath("//img[@alt='SMTPAUTH']")))
                {
                    if (baseTable.FindElement(By.XPath("//img[@alt='SMTPAUTH']")).GetAttribute("alt") == "SMTPAUTH")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// To Selected the Needed equipment
        /// </summary>
        public void SelectEquipments()
        {
            try
            {
                var elemTable = lstEquipmentListtable;
                var rows = elemTable.FindElements(By.TagName("tr"));
                Actions builder = new Actions(driver);
                builder.Click(rows[1]).KeyDown(Keys.Shift).Click(rows[4]).KeyUp(Keys.Shift).Build().Perform();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// To Select the Required Alert
        /// </summary>
        public void SelectAlerts()
        {
            var elemTable = lstAlerts;
            var rows = elemTable.FindElements(By.TagName("tr"));
            Actions builder = new Actions(driver);
            builder.Click(rows[1]).KeyDown(Keys.Shift).Click(rows[4]).KeyUp(Keys.Shift).Build().Perform();
        }

        /// <summary>
        /// To Select Single Equipment
        /// </summary>
        /// <param name="Equipment"></param>
        public void AddEquipments(string Equipment)
        {
            Waits.WaitAndClick(driver, btnAddEquipment);
            Waits.WaitAndClick(driver, btnFindEquipment);
            SelectSingleEquipment(Equipment);
            Waits.WaitAndClick(driver, btnAddSelectedEquipment);
            Waits.Wait(driver, 2000);
        }

        /// <summary>
        /// To Select the Single Alert
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Alert"></param>
        public void AddAlerts(string Value, string Alert)
        {
            Waits.Wait(driver, 4000);
            SelectAlertSystem(Value);
            Waits.WaitAndClick(driver, btnSearchAlerts);
            Waits.Wait(driver, 4000);
            SelectSingleAlert(Alert);
            Waits.Wait(driver, 4000);
            Waits.WaitAndClick(driver, btnAddSelectedAlerts);
            Waits.Wait(driver, 4000);
        }

        /// <summary>
        /// To Choose already created Schedule
        /// </summary>
        public void SelectCreatedSchedule()
        {
            IWebElement listTable = lstScheduler;
            List<string> schedulerlist = new List<string>();
            ICollection<IWebElement> list = listTable.FindElements(By.TagName("tr"));
            Waits.WaitAndClick(driver, driver.FindElement(By.XPath("//table[contains(@id,'gvSchedules')]/tbody/tr[" + list.Count() + "]")));
        }

        /// <summary>
        /// To Click the Page Destination Tab
        /// </summary>
        public void NavigateToPageDestinationLink()
        {
            Waits.WaitAndClick(driver, lnkPageDestinations);
        }

        /// <summary>
        /// To Click New Page Destination button
        /// </summary>
        public void ClickOnNewPageDestinationButton()
        {
            Waits.WaitAndClick(driver, btnNewPageDestination);
        }

        /// <summary>
        /// To Switch to SMTP Tab
        /// </summary>
        public void SwitchToSMTP_Tab()
        {
            Waits.WaitAndClick(driver, tabSMTPSetting);
        }

        /// <summary>
        /// To Enter the SMTP From Email Address
        /// </summary>
        /// <param name="Email_SMTP"></param>
        public void EnterFromEmail_SMTP(String Email_SMTP)
        {
            Waits.WaitForElementVisible(driver, txtFromEmail_SMTP);
            ElementExtensions.ClearTextValue(txtFromEmail_SMTP);
            ElementExtensions.EnterTextValue(txtFromEmail_SMTP, Email_SMTP);
        }

        /// <summary>
        /// To Enter the SMTP Server
        /// </summary>
        /// <param name="SMTPServer"></param>
        public void EnterSMTPServer(string SMTPServer)
        {
            Waits.WaitForElementVisible(driver, txtSMTPServer_SMTP);
            ElementExtensions.ClearTextValue(txtSMTPServer_SMTP);
            ElementExtensions.EnterTextValue(txtSMTPServer_SMTP, SMTPServer);
        }

        /// <summary>
        /// To Enter the SMTP To Email Address
        /// </summary>
        /// <param name="ToAddressEmail_SMTP"></param>
        public void EnterToAddress_SMTP(string ToAddressEmail_SMTP)
        {
            Waits.WaitForElementVisible(driver, txtToAddressEMail_SMTP);
            ElementExtensions.ClearTextValue(txtToAddressEMail_SMTP);
            ElementExtensions.EnterTextValue(txtToAddressEMail_SMTP, ToAddressEmail_SMTP);
        }

        /// <summary>
        /// To click Destination Create button 
        /// </summary>
        public void ClickOnCreateDestination()
        {
            Waits.WaitAndClick(driver, btnCreateDestination);
        }

        /// <summary>
        /// To Click the SMTP Auth Tab
        /// </summary>
        public void SwitchToSMTPAuth_Tab()
        {
            Waits.WaitAndClick(driver, tabSMTPAuthSetting);
        }

        /// <summary>
        /// To Enter the SMTPAuth From Email Address
        /// </summary>
        /// <param name="Email_SMTPAuth"></param>
        public void EnterFromEmail_SMTPAuth(String Email_SMTPAuth)
        {
            Waits.WaitForElementVisible(driver, txtFromEmail_SMTPAuth);
            ElementExtensions.ClearTextValue(txtFromEmail_SMTPAuth);
            ElementExtensions.EnterTextValue(txtFromEmail_SMTPAuth, Email_SMTPAuth);
        }

        /// <summary>
        /// To Enter the SMTPAuth Server
        /// </summary>
        /// <param name="SMTPAuthServer"></param>
        public void EnterSMTPAuthServer(string SMTPAuthServer)
        {
            Waits.WaitForElementVisible(driver, txtSMTPServer_SMTPAuth);
            ElementExtensions.ClearTextValue(txtSMTPServer_SMTPAuth);
            ElementExtensions.EnterTextValue(txtSMTPServer_SMTPAuth, SMTPAuthServer);
        }

        /// <summary>
        /// To Enter the SMTPAuth To Email Address
        /// </summary>
        /// <param name="ToAddressEmail_SMTPAuth"></param>
        public void EnterToAddress_SMTPAuth(string ToAddressEmail_SMTPAuth)
        {
            Waits.WaitForElementVisible(driver, txtToAddressEMail_SMTPAuth);
            ElementExtensions.ClearTextValue(txtToAddressEMail_SMTPAuth);
            ElementExtensions.EnterTextValue(txtToAddressEMail_SMTPAuth, ToAddressEmail_SMTPAuth);
        }

        /// <summary>
        /// To Switch the tab to Scheduler
        /// </summary>
        public void SwitchToSchedulerTab()
        {
            Waits.WaitAndClick(driver, lnkScheduler);
        }

        /// <summary>
        /// To Click the New Schedule Button If Schedule not present
        /// </summary>
        public void ClickOnNewScheduleNew()
        {
            if (!IsElemetPresent(driver, By.XPath("//div[@class='settingsbody']//span[text()='New Schedule']")))
            {
                Waits.WaitAndClick(driver, btnNewSchedule);
            }
        }

        /// <summary>
        /// To Click the New Schedule Button
        /// </summary>
        public void ClickOnNewSchedule()
        {
            Waits.WaitAndClick(driver, btnNewSchedule);
        }

        /// <summary>
        /// To Check the WeekDays Checkbox
        /// </summary>
        public void SelectWeekDaysCheckBox()
        {
            Waits.WaitForElementVisible(driver, chkBoxWeekDay);
            if (chkBoxWeekDay.GetAttribute("src").Contains("chk_off"))
            {
                Waits.WaitAndClick(driver, chkBoxWeekDay);
            }
        }

        /// <summary>
        /// To Check the AllDay Checkbox
        /// </summary>
        public void SelectAllDayCheckBox()
        {
            Waits.WaitForElementVisible(driver, chkBoxAllDay);
            if (chkBoxAllDay.GetAttribute("src").Contains("chk_off"))
            {
                Waits.WaitAndClick(driver, chkBoxAllDay);
            }
        }

        /// <summary>
        /// To Check the Alarm Checkbox
        /// </summary>
        public void SelectAlarm()
        {
            Waits.WaitForElementVisible(driver, chkAlarm);
            if (chkAlarm.GetAttribute("src").Contains("chk_off"))
            {
                Waits.WaitAndClick(driver, chkAlarm);
            }
        }

        /// <summary>
        /// To UnCheck the WeekDays Checkbox
        /// </summary>
        public void UnSelectWeekDaysCheckbox()
        {
            Waits.WaitForElementVisible(driver, chkBoxWeekDay);
            if (chkBoxWeekDay.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, chkBoxWeekDay);
            }
        }

        /// <summary>
        /// To Check the WeekendDays Checkbox
        /// </summary>
        public void SelectWeekendDaysCheckbox()
        {
            Waits.WaitForElementVisible(driver, chkBoxWeekendDay);
            if (chkBoxWeekendDay.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, chkBoxWeekendDay);
            }
        }

        /// <summary>
        /// To Click Apply Button 
        /// </summary>
        public void ClickApply()
        {
            Waits.WaitAndClick(driver, btnApply);
        }

        /// <summary>
        /// Delete SMTP Page Destinnation if already created
        /// </summary>
        /// <param name="userName"></param>
        public void DeleteSMTPPageDestination_IfExists(string PageDestination= "administrator")
        {
            try
            {
                List<IWebElement> pageDestList = new List<IWebElement>(panelSMTPPageDestination.FindElements(By.TagName("li")));
                for (int i = pageDestList.Count; i >= 1; i--)
                {
                    pageDestList = new List<IWebElement>(panelSMTPPageDestination.FindElements(By.TagName("li")));
                    foreach (var pageDestEle in pageDestList)
                    {
                        pageDestEle.FindElement(By.TagName("div")).Text.ToLower().Contains(PageDestination.ToLower());
                        {
                            Waits.WaitAndClick(driver, pageDestEle);
                            Waits.WaitAndClick(driver, btnDelete);
                            Waits.WaitAndClick(driver, btnOkDeleteConformation);
                            break;
                        }
                    }
                    driver.Navigate().Refresh();
                }
            }
            catch (StaleElementReferenceException)
            {
                DeleteSMTPPageDestination_IfExists(PageDestination);
            }
        }

        /// <summary>
        /// Choose already created SMTPDispatcher from the dropdown list
        /// </summary>
        /// <param name="Dispatcher"></param>
        public void SelectAlreadycreatedSMTPDispatcher(string Dispatcher)
        {
            List<IWebElement> pageDestList = new List<IWebElement>(panelSMTPPageDestination.FindElements(By.TagName("li")));
            foreach (var pageDestEle in pageDestList)
            {
                pageDestEle.FindElement(By.TagName("div")).Text.ToLower().Contains(Dispatcher.ToLower());
                {
                    pageDestEle.Click();
                    Waits.Wait(driver, 2000);
                    break;
                }
            }
        }

        /// <summary>
        /// Choose already created PageDestination from the dropdown list
        /// </summary>
        /// <param name="pageDestination"></param>
        public void SelectDropDownPageDestination(string pageDestination)
        {
            Waits.WaitForElementVisible(driver, drpdwnPageDestination);
            ElementExtensions.SelectByText(drpdwnPageDestination, pageDestination);
        }

        /// <summary>
        /// Select the already created PageDestination from the dropdown list
        /// </summary>
        /// <param name="pageDestination"></param>
        public void SelectedCreatedPageDestination(string pageDestination)
        {
            Waits.WaitForElementVisible(driver, lstPagedestination);
            ElementExtensions.SelectByText(lstPagedestination, pageDestination);
            Waits.Wait(driver, 1000);
            //List<IWebElement> lstPageDest = new List<IWebElement>(lstPagedestination.FindElements(By.XPath("//table//tbody//tr//td")));

            //if (lstPageDest.Count > 0)
            //{
            //    foreach (var ele in lstPageDest)
            //    {
            //        if (ele.Text.Contains(pageDestination))
            //        {
            //            Waits.Wait(driver, 1000);
            //            ele.Click();
            //            break;
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Check the Status of Created PageDestibnation
        /// </summary>
        /// <param name="PageDestination"></param>
        /// <returns></returns>
        public bool IsSelectedPageDestinationPresence(string PageDestination)
        {
            bool flag = false;

            List<IWebElement> lstPageDest = new List<IWebElement>(lstPagedestination.FindElements(By.XPath("//table//tbody//tr//td")));

            if (lstPageDest.Count > 0)
            {
                foreach (var ele in lstPageDest)
                {
                    if (ele.Text.Contains(PageDestination))
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
        /// Select the already created Alternative Destination from the dropdown list
        /// </summary>
        /// <param name="destination"></param>
        public void SelectDropDownAlternateDestination(string destination)
        {
            Waits.WaitForElementVisible(driver, drpdwnAlternativeDestination);
            ElementExtensions.SelectByText(drpdwnAlternativeDestination, destination);
            //List<IWebElement> pageDropdownList = new List<IWebElement>(drpdwnAlternativeDestination.FindElements(By.TagName("option")));
            //if (pageDropdownList.Count > 0)
            //{
            //    foreach (var ele in pageDropdownList)
            //    {
            //        if (ele.Text.Contains(destination))
            //        {
            //            ele.Click();
            //            Waits.Wait(driver, 2000);
            //            break;
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Change the delayTime to Alternative Destination
        /// </summary>
        public void EditAfterMinutes()
        {
            Waits.WaitForElementVisible(driver, txtAlternativeDelay);
            txtAlternativeDelay.SendKeys("");
            txtAlternativeDelay.SendKeys("1");
        }

        /// <summary>
        /// Backround Colour Verification
        /// </summary>
        /// <param name="PageDestination"></param>
        /// <returns></returns>
        public string GetScheduleEntryBackroundColor()
        {
            string colour = string.Empty;
            Waits.WaitForElementVisible(driver, lstPagedestination);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, lstPagedestination);
            List<IWebElement> lstPageDest = new List<IWebElement>(lstPagedestination.FindElements(By.TagName("tr")));
            if (lstPageDest.Count > 0)
            {
                foreach (var ele in lstPageDest)
                {
                    if (ele.GetAttribute("class").Contains("alertRow selected"))
                    {
                        colour = ele.GetCssValue("background-color");
                        Waits.Wait(driver, 2000);
                    }
                }
            }
            return colour;
        }

        /// <summary>
        /// Update the StartTime to Alternative Destination
        /// </summary>
        public void EditScheduleFromTime()
        {
            DateTime HourFrom = DateTime.Now.AddHours(2);
            string hours = HourFrom.ToString("HH");
            dropdownHourFrom.SendKeys(hours);
            Waits.Wait(driver, 1000);
            MinuteFrom = DateTime.Now.ToString("mm");
            dropdownMinuteFrom.SendKeys(MinuteFrom);
            Waits.Wait(driver, 1000);
        }

        public string StartTime()
        {
            string start = (HourFrom + ":" + MinuteFrom);
            return start;
        }

        /// <summary>
        /// Update the EndTime to Alternative Destination
        /// </summary>
        public void EditScheduleToTime()
        {
            DateTime HourFrom = DateTime.Now.AddHours(3);
            string hours = HourFrom.ToString("HH");
            dropdownHourTo.SendKeys(hours);
            Waits.Wait(driver, 90000);
            MinuteTo = DateTime.Now.ToString("mm");
            dropdownMinuteTo.SendKeys(MinuteTo);
            Waits.Wait(driver, 1000);
        }

        public string EndTime()
        {
            string End = ("HourTo" + ":" + "MinuteTo");
            return End;
        }

        /// <summary>
        /// Check the status of updated start and end time 
        /// </summary>
        /// <param name="PageDestination"></param>
        /// <param name="Time"></param>
        /// <returns></returns>
        public bool ScheduleEntryTimeCheck(string PageDestination, string Time)
        {
            bool flag = false;

            List<IWebElement> lstPageDest = new List<IWebElement>(lstPagedestination.FindElements(By.TagName("tr")));

            if (lstPageDest.Count > 0)
            {
                foreach (var ele in lstPageDest)
                {
                    if (ele.Text.Contains(PageDestination))
                    {
                        List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.TagName("td")));
                        if (lstCol.Count > 0)
                        {
                            foreach (var col in lstCol)
                            {
                                if (col.Text.Contains(Time))
                                {
                                    Waits.Wait(driver, 1000);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// Select the single equipment from the listdropdown
        /// </summary>
        /// <param name="Equipment"></param>
        public void SelectSingleEquipment(string Equipment)
        {
            bool flag = false;

            Waits.WaitForElementVisible(driver, lstEquipmentListtable);
            Waits.Wait(driver, 5000);
            List<IWebElement> lstEle = new List<IWebElement>(lstEquipmentListtable.FindElements(By.TagName("tr")));

            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (flag)
                    {
                        break;
                    }
                    if (ele.Text.Contains(Equipment))
                    {
                        Waits.WaitAndClick(driver, ele);
                        Waits.Wait(driver, 1000);
                        flag = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Check the status of newly added equipment
        /// </summary>
        /// <param name="Equipment"></param>
        /// <returns></returns>
        public bool IsSelectEquipmentDisplayed(string Equipment)
        {
            bool flag = false;

            List<IWebElement> lstEle = new List<IWebElement>(lstSelectedEquipment.FindElements(By.TagName("tr")));

            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (flag)
                    {
                        break;
                    }
                    if (ele.Text.Contains(Equipment))
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
        /// Remove the selected Equipment from restriction list
        /// </summary>
        /// <param name="Equipment"></param>
        public void RemoveEquipmentFromRestrictionList(string Equipment)
        {
            List<IWebElement> lstEle = new List<IWebElement>(lstSelectedEquipment.FindElements(By.TagName("tr")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(Equipment))
                    {
                        Waits.Wait(driver, 1000);
                        ele.Click();
                        Waits.Wait(driver, 1000);
                        btnRemoveEquipment.Click();
                        Waits.Wait(driver, 1000);
                        break;

                    }
                }
            }
        }

        /// <summary>
        /// To select single alert system from system list
        /// </summary>
        /// <param name="Value"></param>
        public void SelectAlertSystem(string Value)
        {
            SelectElement element = new SelectElement(lstAlertsSystemTypeFilter);
            element.SelectByValue(Value);
        }

        public void SelectSingleAlert(string Alert)
        {
            bool flag = false;

            Waits.WaitForElementVisible(driver, lstAlerts);
            List<IWebElement> lstEle = new List<IWebElement>(lstAlerts.FindElements(By.TagName("tr")));

            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (flag)
                    {
                        break;
                    }
                    if (ele.Text.Contains(Alert))
                    {
                        Waits.WaitAndClick(driver, ele);
                        Waits.Wait(driver, 1000);
                        flag = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Is selected Alert displayed
        /// </summary>
        /// <param name="Alert"></param>
        /// <returns></returns>
        public bool IsSelectAlertDisplayed(string Alert)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstSelectedAlerts);
            List<IWebElement> lstEle = new List<IWebElement>(lstSelectedAlerts.FindElements(By.TagName("tr")));

            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (flag)
                    {
                        break;
                    }
                    if (ele.Text.Contains(Alert))
                    {
                        Waits.Wait(driver, 3000);
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }
        #endregion

    }
}
