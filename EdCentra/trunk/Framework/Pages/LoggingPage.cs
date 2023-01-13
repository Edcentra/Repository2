using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using NUnit.Framework;
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
    public class LoggingPage : PageBase
    {

        private IWebDriver driver;

        public LoggingPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for LoggingPage
        #region 
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblNew")]
        private IWebElement lnkCreateProfile;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtProfileName')]")]
        private IWebElement txtProfileName;

        [FindsBy(How = How.XPath, Using = "//h2//span[contains(@id,'lblTitle')]")]
        private IWebElement lblProfileTitle;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlSystemType')]")]
        private IWebElement lstSystemDropdownList;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnCreate')]")]
        private IWebElement btnCreateProfile;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_lblTitle')]")]
        private IWebElement lblCreateProfile;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//input[contains(@id,'btnOKDelete')]")]
        private IWebElement btnOKDelete;

        [FindsBy(How = How.Id, Using = "divLeftContainer")]
        private IWebElement lstProfiles;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'UpdatePanelLeftItems')]")]
        private IWebElement lstProfileName;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'boxlist')]")]
        private IWebElement lstListedProfileName;

        //Latest code Rel1.11
        //[FindsBy(How = How.XPath, Using = "//li[contains(@id,'ctl00_ctl00_cphContent_cphContent_rptItems_ctl07_liEdit')]//a/div/div/div[2]")]
        //private IWebElement createdProfile;

        //Latest code Rel1.11
        [FindsBy(How = How.XPath, Using = "//li[contains(@id,'ctl00_ctl00_cphContent_cphContent_rptItems_ctl08_liEdit')]//a/div/div/div[2]")]
        private IWebElement renamedProfile;

        [FindsBy(How = How.XPath, Using = "//li[contains(@id,'liEdit')]//a/div/div/div[2]")]
        private IWebElement createdProfile;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnDelete')]")]
        private IWebElement btnDeleteProfile;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnDuplicate')]")]
        private IWebElement btnDuplicateProfile;

        [FindsBy(How = How.XPath, Using = "//div[@class='settingstabs']//a[text()='Equipment']")]
        private IWebElement tabEquipment;

        [FindsBy(How = How.XPath, Using = "//div[@class='settingstabs']//a[text()='Details']")]
        private IWebElement tabDetails;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Find Equipment')]")]
        private IWebElement btnFindEquipment;

        [FindsBy(How = How.XPath, Using = "//div[@id='divAddSystemMessage']/span")]
        private IWebElement lblSystemMessage;

        [FindsBy(How = How.XPath, Using = "//div[@id='divFoundsystems']//table/tbody[@class='clist']")]
        private IWebElement tblEquipmentListTable;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'gvLoggingParameters')]//tbody/tr[20]//a//img")]
        private IWebElement checkListLoggingParameter;
        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlNormal')]")]
        private IWebElement dropdownlistNormal;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlAlert')]")]
        private IWebElement dropdownlistAlert;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtDelta')]")]
        private IWebElement listDeltaValue;

       [FindsBy(How = How.XPath, Using = "//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnApply')]")]
        //[FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnApply")]
        private IWebElement btnApplyChanges; 

        [FindsBy(How = How.XPath, Using = "//span[@id='lblFeedback']")]
        private IWebElement lblMessage;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'gvLoggingParameters')]//tbody//tr//a//img[contains(@src,'chk_on')]")]
        private IWebElement checkedParameter;

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Logging']")]
        private IWebElement lnkLogging;

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Predictive Maintenance']")]
        private IWebElement lnkPredictiveMaintenance;

        [FindsBy(How = How.XPath, Using = "//div[@class='logo']//a//img")]
        private IWebElement lnkHomePage;

        [FindsBy(How = How.XPath, Using = "//div[@id='divAddBox']")]
        private IWebElement lnkAddDevice;

        [FindsBy(How = How.Id, Using = "//span[contains(@id,'lblLinkText')][contains(.,'Home')]")]
        private IWebElement lnkHome;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnMoveSystemsTo")]
        private IWebElement btnMoveSystemTo;

        //ctl00_ctl00_cphContent_cphContent_clSelectedSystems_tr0
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clSystems_td0")]
        private IWebElement lblAssignedEquipments;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnMoveAllSystemsTo")]
        private IWebElement lblAllAssignedEquipments;
        
        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphSubMenuBar_lnkLogging')]")]
        private IWebElement lblLoggingPage;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_gvLoggingParameters_ctl02_chkSelectedParameter_imgCheckBox")]
        private IWebElement imagecheckBox;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphContent_cphContent_lnkDetails')]")]
        private IWebElement lblDetailTab;

        [FindsBy(How = How.XPath, Using = " //img[contains(@id,'ctl00_ctl00_cphContent_cphContent_chkShowProfileParametersOnly_imgCheckBox')]")]
        private IWebElement showOnlyParameterChkBox;

        [FindsBy(How = How.XPath, Using = "//*[@id= 'ctl00_ctl00_cphContent_cphContent_gvLoggingParameters']")]
        private IWebElement parameterTable;

        [FindsBy(How = How.Name, Using = "ctl00$ctl00$cphContent$cphContent$gvLoggingParameters$ctl02$ddlNormal")]
        private IWebElement normalParameter;

        [FindsBy(How = How.XPath, Using = "//a[contains,(.,'lnkEquipment')]")]
        private IWebElement lnkEquipmentTab;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkEquipment")]
        private IWebElement lnkEquipmentTabNew;

        [FindsBy(How = How.XPath, Using = "//span[@class='infomessage'][contains(.,'Changes have been applied')]")]
        private IWebElement lblSuccessMessageAfterAddingEquipment;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_pnlDuplicate")]
        private IWebElement duplicatewindow;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//input[contains(@id,'btnCloseDuplicate')]")]
        private IWebElement btnCancelDuplicateWindow;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//input[contains(@id,'btnOKDuplicate')]")]
        private IWebElement btnOkDuplicateWindow;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_pnlDelete")]
        private IWebElement deletewindow;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//input[contains(@id,'btnCloseDelete')]")]
        private IWebElement btnCancelDeleteWindow;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//input[contains(@id,'btnOKDelete')]")]
        private IWebElement btnOkDeleteWindow;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnAssignments')]")]
        private IWebElement btnAssignments;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphContent_cphContent_lnkLogging')]")]
        private IWebElement lnkLoggingAssignedTab;

        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ctl00_cphContent_cphContent_UpdatePanelAssignmentsGrid']")]
        private IWebElement lblAssignmentsGrid;

        [FindsBy(How = How.XPath, Using = "//td[contains(.,'iXH')]")]
        private IWebElement lnkEquipmentType;

        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ctl00_cphContent_cphContent_UpdatePanelAssignmentsGrid']//div//table//tbody//tr//td//img")]
        private IWebElement lnkRefresh;

        [FindsBy(How = How.XPath, Using = "//td[contains(.,'NEW0001PM1')]")]
        private IWebElement lnkEquipment;

        [FindsBy(How = How.XPath, Using = "//td[contains(.,'LoggingTest')]")]
        private IWebElement lnkLoggingProfile;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphContent_cphContent_lnkNotLogging')]")]
        private IWebElement lnkNotLoggingAssignedTab;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphContent_cphContent_lnkAll')]")]
        private IWebElement lnkAllTab;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnEffective')]")]
        private IWebElement lnkEffectiveIcon;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_lblEffectiveSystem')]")]
        private IWebElement lnkDetailingEffectiveLogging;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnCloseEffective')]")]
        private IWebElement btnCloseEffectiveWinodow;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnRefresh')]")]
        private IWebElement btnRefreshIcon;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$gvAssignments$ctl03$btnRefresh')]")]
        private IWebElement lnkRefreshIcon;

        [FindsBy(How = How.XPath, Using = "//a//span[text()='Historian']")]
        private IWebElement lnkHistorian;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Equipment Data')]")]
        private IWebElement lnkHistorianEquipmentData;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Data Extraction Utility')]")]
        private IWebElement lnkHistorianDataExtraction;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_chkShowParameterData_imgCheckBox')]")]
        private IWebElement equptParametercheckbox;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_chkShowAlerts_imgCheckBox')]")]
        private IWebElement equptAlertcheckbox;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divctl00_ctl00_cphContent_cphContent_btnApplyFilter')]")]
        private IWebElement btnApplyFilter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_UpdatePanelTree")]
        private IWebElement lnkExpandSystem;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clParameters_divListControl")]
        private IWebElement lnkListedParameters;

        [FindsBy(How = How.Id, Using = "divctl00_ctl00_cphContent_cphContent_btnAddParameter")]
        private IWebElement btnAddParameter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkGraph")]
        private IWebElement lnkGraphTab;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkValues")]
        private IWebElement lnkGridTab;

        [FindsBy(How = How.XPath, Using = "//div[@id='chart_container']//*[name()='svg']//*[name()='g'][@class='highcharts-legend']//*[name()='text']//*[name()='tspan']")]
        private IWebElement lblGraphParaMeter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtFilterDateFrom")]
        private IWebElement lblFilterDateFrom;

        [FindsBy(How = How.XPath, Using = "//div[contains(@title,'Friday, March 01, 2019')]")]
        private IWebElement lblFilterFromDate;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtFilterDateTo")]
        private IWebElement lblFilterDateTo;

        [FindsBy(How = How.XPath, Using = "//div[@class='settingsbody']//table//tbody")]
        private IWebElement lblTableGrid;

        [FindsBy(How = How.XPath, Using = "//div[@class='settingsbody']//table//tbody//tr[@class='alertRow alarm_active']")]
        private IWebElement tblGridAlertHistory;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clSystems_divListControl")]
        private IWebElement lstEquipmentType;

        [FindsBy(How = How.XPath, Using = "//div[@class='logo']//a[3]//img")]
        private IWebElement lnkDiagnostics;

        [FindsBy(How = How.XPath, Using = "//select[@id='ctl00_ctl00_cphContent_cphContent_ddlSystemTypeFilter']")]
        private IWebElement dropdownlistEquipmentType;

        [FindsBy(How = How.XPath, Using = "//div[@class='imgBtnWrapperBigger']//input[contains(@id,'btnGetSystem')]")]
        private IWebElement btnGetEquipment;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnOKAdd')]")]
        private IWebElement btnOKAdd;

        [FindsBy(How = How.XPath, Using = "//input[@value='OK']")]
        private IWebElement btnOk;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphContent_cphContent_lnkAddSystem')]")]
        private IWebElement lnkAddSystem;

        [FindsBy(How = How.XPath, Using = ".//a//span[text()='Device Explorer']")]
        private IWebElement lnkDeviceManager;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'breadcrumb')]")]
        private IWebElement lnkTopLevel;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphContent_cphContent_hypDeleteGroup')]")]
        private IWebElement linkDeleteFolder;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnOKMessage')]")]
        private IWebElement btnOKMessage;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clstSystems_divListControl")]
        private IWebElement lstElementList;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'No Equipment Found')]")]
        private IWebElement msgNoEquipmentFound;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_AccordionControl')]")]
        private IWebElement lnkAccordionControl;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_AccordionPanelContent_211')]")]
        private IWebElement lnkAgent;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_AccordionPanelContent_210')]")]
        private IWebElement lnkEcoAgent;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'accordionHeader')]")]
        private IWebElement lnkAgentHeader;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnMoveAllSystemsTo')]")]
        private IWebElement btnMoveAllSystemsTo;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'lnkOptions')][@class='footer_link'][contains(.,'Options')]")]
        private IWebElement lnkOptions;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_popGeneralOptions_pnlSettings')]")]
        private IWebElement lnkOptionPnlSetting;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ctl00_popGeneralOptions_rptOptions_ctl06_ddlValue')]")]
        private IWebElement lnkRptOption;

        [FindsBy(How = How.Id, Using = "lblFeedback")]
        private IWebElement lblFeedback;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_popGeneralOptions_btnClose')]")]
        private IWebElement btnClose;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Network Layout')]")]
        private IWebElement lnkNetworkLayout;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblPopupMessage")]
        private IWebElement lblSuccessMessageAfterCreatingFolder;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkAddSystem")]
        private IWebElement lnkAddEquipment;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnOKAdd')]")]
        private IWebElement btnAddEquipment;

        #endregion

        //Properties
        #region
        public IWebElement LblLoggingPage
        {
            get { return lblLoggingPage; }
            set { lblLoggingPage = value; }
        }

        public IWebElement LblCreateProfile
        {
            get { return lblCreateProfile; }
            set { lblCreateProfile = value; }
        }

        public IWebElement BtnCreateProfile
        {
            get { return btnCreateProfile; }
            set { btnCreateProfile = value; }
        }

        public IWebElement LblDetailTab
        {
            get { return lblDetailTab; }
            set { lblDetailTab = value; }
        }

        public IWebElement LnkEquipmentTabNew
        {
            get { return lnkEquipmentTabNew; }
            set { lnkEquipmentTabNew = value; }
        }

        public IWebElement LnkLoggingAssignedTab
        {
            get { return lnkLoggingAssignedTab; }
            set { lnkLoggingAssignedTab = value; }
        }

        public IWebElement LnkNotLoggingAssignedTab
        {
            get { return lnkNotLoggingAssignedTab; }
            set { lnkNotLoggingAssignedTab = value; }
        }

        public IWebElement LnkAllTab
        {
            get { return lnkAllTab; }
            set { lnkAllTab = value; }
        }

        public IWebElement LnkEffectiveIcon
        {
            get { return lnkEffectiveIcon; }
            set { lnkEffectiveIcon = value; }
        }

        public IWebElement BtnRefreshIcon
        {
            get { return btnRefreshIcon; }
            set { btnRefreshIcon = value; }
        }

        public IWebElement LnkDetailingEffectiveLogging
        {
            get { return lnkDetailingEffectiveLogging; }
            set { lnkDetailingEffectiveLogging = value; }
        }

        public IWebElement BtnAssignments
        {
            get { return btnAssignments; }
            set { btnAssignments = value; }
        }

        public IWebElement LnkEquipmentType
        {
            get { return lnkEquipmentType; }
            set { lnkEquipmentType = value; }
        }

        public IWebElement LnkEquipment
        {
            get { return lnkEquipment; }
            set { lnkEquipment = value; }
        }

        public IWebElement LnkLoggingProfile
        {
            get { return lnkLoggingProfile; }
            set { lnkLoggingProfile = value; }
        }

        public IWebElement LnkRefresh
        {
            get { return lnkRefresh; }
            set { lnkRefresh = value; }
        }

        public IWebElement LblAssignmentsGrid
        {
            get { return lblAssignmentsGrid; }
            set { lblAssignmentsGrid = value; }
        }

        public IWebElement ShowOnlyParameterChkBox
        {
            get { return showOnlyParameterChkBox; }
            set { showOnlyParameterChkBox = value; }
        }

        public IWebElement ListDeltaValue
        {
            get { return listDeltaValue; }
            set { listDeltaValue = value; }
        }

        public IWebElement NormalParameter
        {
            get { return normalParameter; }
            set { normalParameter = value; }
        }

        public IWebElement LblSuccessMessageAfterAddingEquipment
        {
            get { return lblSuccessMessageAfterAddingEquipment; }
            set { lblSuccessMessageAfterAddingEquipment = value; }
        }

        public IWebElement ImagecheckBox
        {
            get { return imagecheckBox; }
            set { imagecheckBox = value; }
        }

     //   public IWebElement TxtProfileName
        public IWebElement TxtProfileName
        {
            get { return txtProfileName; }
            set { txtProfileName = value; }
        }

        public IWebElement Duplicatewindow
        {
            get { return duplicatewindow; }
            set { duplicatewindow = value; }
        }

        public IWebElement BtnCancelDuplicateWindow
        {
            get { return btnCancelDuplicateWindow; }
            set { btnCancelDuplicateWindow = value; }
        }

        public IWebElement BtnOkDuplicateWindow
        {
            get { return btnOkDuplicateWindow; }
            set { btnOkDuplicateWindow = value; }
        }

        public IWebElement Deletewindow
        {
            get { return deletewindow; }
            set { deletewindow = value; }
        }

        public IWebElement BtnCancelDeleteWindow
        {
            get { return btnCancelDeleteWindow; }
            set { btnCancelDeleteWindow = value; }
        }

        
        public IWebElement LblAllAssignedEquipments
        {
            get { return lblAllAssignedEquipments; }
            set { lblAllAssignedEquipments = value; }
        }
        public IWebElement BtnOkDeleteWindow
        {
            get { return btnOkDeleteWindow; }
            set { btnOkDeleteWindow = value; }
        }

        public IWebElement BtnCloseEffectiveWinodow
        {
            get { return btnCloseEffectiveWinodow; }
            set { btnCloseEffectiveWinodow = value; }
        }

        public IWebElement BtnApplyChanges
        {
            get { return btnApplyChanges; }
            set { btnApplyChanges = value; }
        }

        public IWebElement LnkAddDevice
        {
            get { return lnkAddDevice; }
            set { lnkAddDevice = value; }
        }

        public IWebElement LnkCreateProfile
        {
            get { return lnkCreateProfile; }
            set { lnkCreateProfile = value; }
        }

        public IWebElement BtnFindEquipment
        {
            get { return btnFindEquipment; }
            set { btnFindEquipment = value; }
        }

        public IWebElement TabDetails
        {
            get { return tabDetails; }
            set { tabDetails = value; }
        }

        public IWebElement LblFeedback
        {
            get { return lblFeedback; }
            set { lblFeedback = value; }
        }

        public IWebElement BtnClose
        {
            get { return btnClose; }
            set { btnClose = value; }
        }

        public IWebElement LnkNetworkLayout
        {
            get { return lnkNetworkLayout; }
            set { lnkNetworkLayout = value; }
        }

        #endregion

        //Methods
        #region

        /// <summary>
        /// Create new user profile
        /// </summary>
        /// <param name="ProfileName"></param>
        public void CreateProfile(string ProfileName, string Text)
        {
            if (IsProfileExist(ProfileName))
            {
                DeleteProfile(ProfileName);
            }
            ClickOnCreateProfileOption();
            EnterProfileName(ProfileName);
            Waits.Wait(driver, 1000);
            SelectSystemDevice(Text);
            ClickOnCreateButton();
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// Profile if exists
        /// </summary>
        /// <param name="ProfileName"></param>
        public bool IsProfileExist(string ProfileName)
        {
            //Latest code Rel1.11
            bool flag = false;
            try
            {
                if (createdProfile.Displayed)
                {
                    //Latest code Rel1.11
                    if (ProfileName.Equals("LoggingTest"))
                    {
                        //check the 7th element
                        Waits.WaitAndClick(driver, createdProfile);
                        flag = true;
                    }
                    else
                    {
                        //check the 8th element - RenamedTest
                        Waits.WaitAndClick(driver, createdProfile);// renamedProfile);
                        flag = true;
                    }

                    //Check if profile name is LoggingTest
                    Waits.WaitForElementVisible(driver, txtProfileName);
                    Waits.WaitAndClick(driver, txtProfileName);
                }
            }
            catch
            {
                //do nothing
            }
            //Waits.WaitForElementVisible(driver, lstProfiles);
            //List<IWebElement> LoggingProfileList = new List<IWebElement>(lstProfiles.FindElements(By.XPath("//a//div//span")));

            //if (LoggingProfileList.Count() > 0)
            //{
            //    foreach (IWebElement listItem in LoggingProfileList)
            //    {
            //        if (listItem.Text.Contains(ProfileName))
            //        {
            //            flag = true;
            //            break;
            //        }
            //        else
            //        {
            //            flag = false;
            //            continue;
            //        }
            //    }
            //}
            //if (flag == false)
            //{
            //    Waits.WaitForElementVisible(driver, lstListedProfileName);
            //    List<IWebElement> newLoggingProfileList = new List<IWebElement>(lstListedProfileName.FindElements(By.TagName("div")));
            //    Waits.Wait(driver, 2000);
            //    if (newLoggingProfileList.Count() > 0)
            //    {
            //        foreach (IWebElement listItem in newLoggingProfileList)
            //        {
            //            if (listItem.Text.ToLower().Contains(ProfileName.ToLower()))
            //            {
            //                flag = true;
            //                break;
            //            }
            //            else
            //            {
            //                flag = false;
            //                continue;
            //            }

            //        }
            //    }
            //}
            return flag;
        }

        /// <summary>
        /// Click on Create Profile link
        /// </summary>
        public void ClickOnCreateProfileOption()
        {
            Waits.WaitAndClick(driver, lnkCreateProfile);
        }
        /// <summary>
        /// Click on Assignments Button
        /// </summary>
        public void ClickOnBtnAssignments()
        {
            Waits.WaitForElementVisible(driver, BtnAssignments);
            Waits.WaitAndClick(driver, BtnAssignments);
        }

        /// <summary>
        /// Enter text in ProfileName textbox
        /// </summary>
        /// <param name="ProfileName"></param>
        public void EnterProfileName(string ProfileName)
        {
            Waits.WaitForElementVisible(driver, txtProfileName);
            Waits.WaitAndClick(driver, txtProfileName);
            txtProfileName.SendKeys(ProfileName);
        }

        /// <summary>
        /// Path to Historian link
        /// </summary>
        public void LinkHistorian()
        {
            Waits.WaitAndClick(driver, lnkDiagnostics);
        }

        /// <summary>
        /// Enter value to select systemdevice
        /// </summary>
        /// <param name="value"></param>
        public void SelectSystemDevice(string text)
        {
            Waits.WaitForElementVisible(driver, lstSystemDropdownList);
            SelectElement element = new SelectElement(lstSystemDropdownList);
            element.SelectByText(text);
        }

        /// <summary>
        /// Click on EquipmentTab link
        /// </summary>
        public void NavigateToEquipmentTab()
        {
            Waits.WaitAndClick(driver, tabEquipment);
        }

        /// <summary>
        /// Check Equipment list 
        /// </summary>
        public bool IsEquipmentPresent()
        {
            Waits.WaitForElementVisible(driver, tblEquipmentListTable);
            IList<IWebElement> rows = tblEquipmentListTable.FindElements(By.TagName("tr"));
            if (rows.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Delete the already created profile 
        /// </summary>
        /// <param name="ProfileName"></param>
        public void DeleteProfile(string ProfileName)
        {
            SelectCreatedProfile(ProfileName);
            Waits.Wait(driver, 2000);
            ClickOnDeleteButton();
            Waits.Wait(driver, 1000);
            if (!ElementExtensions.isDisplayed(driver, btnOKDelete))
            {
                ClickOnDeleteButton();
            }
            Waits.WaitAndClick(driver, btnOKDelete);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// Get Craeted Profile list
        /// </summary>
        public string GetProfileList()
        {
            IWebElement baseTable = lstProfiles;
            List<string> ProfileList = new List<string>();
            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));
            foreach (IWebElement listItem in list)
            {
                ProfileList.Add(listItem.Text);
            }
            return ProfileList.ToString();
        }

        /// <summary>
        /// Select already Craeted Profile
        /// </summary>
        /// <param name="ProfileName"></param>
        public void SelectCreatedProfile(string ProfileName)
        {
            //Latest code Rel1.11
            if (ProfileName.Equals("LoggingTest"))
                //check the 7th element
                Waits.WaitAndClick(driver, createdProfile);
            else
                //check the 8th element - RenamedTest
                Waits.WaitAndClick(driver, createdProfile);// renamedProfile);

            //bool flag = false;
            //for (int i = 1; i <= 10; i++)
            //{
            //    if(flag)
            //    {
            //        break;
            //    }
            //    try
            //    {
            //        Waits.WaitForElementVisible(driver, lstProfiles);
            //        IWebElement baseTable = lstProfiles;
            //        List<string> ProfileList = new List<string>();
            //        ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));
            //        foreach (IWebElement listItem in list)
            //        {
            //            if (listItem.Text.ToLower().Equals(ProfileName.ToLower()))
            //            {
            //                listItem.Click();
            //                flag = true;
            //                break;
            //            }
            //            else
            //            {
            //                continue;
            //            }
            //        }
            //    }
            //    catch (StaleElementReferenceException)
            //    {
            //        driver.Navigate().Refresh();
            //        Waits.Wait(driver, 1000);
            //    }
            //    catch (NullReferenceException)
            //    {
            //        Waits.Wait(driver, 1000);
            //    }
            //}
        }

        /// <summary>
        /// Click on Add device
        /// </summary>
        public void ClickOnAddDevice()
        {
            Waits.WaitAndClick(driver, lnkAddDevice);
        }

        /// <summary>
        /// Click on after confirmation message
        /// </summary>
        public void ClickOkAfterConformationMessage()
        {
            Waits.WaitAndClick(driver, btnOk);
        }

        /// <summary>
        /// Selected Equipment to Move
        /// </summary>
        public void SelectSingleEquipmentAndMoveToAssign(string equipment)
        {
            Waits.Wait(driver, 5000);
            Waits.WaitForElementVisible(driver, btnFindEquipment);
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, btnFindEquipment);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, LblAllAssignedEquipments);
            Waits.Wait(driver, 2000);
            //SelectSingleEquipment(equipment);
            //Waits.WaitAndClick(driver, btnMoveSystemTo);
            //Waits.Wait(driver, 5000);
            //Waits.WaitForElementVisible(driver, lblAssignedEquipments);
            Waits.WaitAndClick(driver, btnApplyChanges);
        }

        /// <summary>
        /// Click Confirm Create profile
        /// </summary>
        public void ClickOnCreateButton()
        {
            Waits.WaitForElementVisible(driver, btnCreateProfile);
            Waits.WaitAndClick(driver, btnCreateProfile);
        }

        /// <summary>
        /// Click On Delete button
        /// </summary>
        public void ClickOnDeleteButton()
        {
            Waits.WaitForElementVisible(driver, btnDeleteProfile);
            Waits.WaitAndClick(driver, btnDeleteProfile);
        }


        /// <summary>
        /// Click On Duplicate button
        /// </summary>
        public void ClickOnDuplicateButton()
        {
            Waits.WaitForElementVisible(driver, btnDuplicateProfile);
            Waits.WaitAndClick(driver, btnDuplicateProfile);
        }

        /// <summary>
        /// Click On close button for effective window
        /// </summary>
        public void ClickonBtnCloseEffectiveWinodow()
        {
            Waits.WaitForElementVisible(driver, btnCloseEffectiveWinodow);
            Waits.WaitAndClick(driver, btnCloseEffectiveWinodow);
        }

        /// <summary>
        /// Click On Apply Changes button
        /// </summary>
        public void ClickApplyChanges()
        {
            Waits.WaitForElementVisible(driver, btnApplyChanges);
            Waits.WaitAndClick(driver, btnApplyChanges);
        }

        /// <summary>
        /// Click On Logging link
        /// </summary>
        public void ClickOnLoggingLink()
        {
            Waits.WaitForElementVisible(driver, lnkLogging);
            Waits.WaitAndClick(driver, lnkLogging);
        }

        /// <summary>
        /// Click On Refresh Icon
        /// </summary>
        public void ClickOnRefreshIcon()
        {
            Waits.WaitForElementVisible(driver, btnRefreshIcon);
            Waits.WaitAndClick(driver, btnRefreshIcon);
        }

        /// <summary>
        /// Click On Homepage link
        /// </summary>
        public void NavigateToHomePage()
        {
            Waits.WaitForElementVisible(driver, lnkHomePage);
            Waits.WaitAndClick(driver, lnkHomePage);
        }

        /// <summary>
        /// Confirm Delete profile if exists
        /// </summary>
        /// <param name="profileName"></param>
        public void DeleteIfProfileExist(string ProfileName)
        {
            if (IsProfileExist(ProfileName))
            {
                SelectCreatedProfile(ProfileName);
                Waits.Wait(driver, 1000);
                ClickOnDeleteButton();
                if (!ElementExtensions.isDisplayed(driver, btnOKDelete))
                {
                    ClickOnDeleteButton();
                }
                Waits.WaitForElementVisible(driver, btnOKDelete);
                Waits.WaitAndClick(driver, btnOKDelete);
            }
        }

        /// <summary>
        /// To Select Parameter and Update the Time interval values
        /// </summary>
        /// <param name="Parameter"></param>
        /// <param name="TimeintervalforNormal"></param>
        /// <param name="TimeintervalforAlerts"></param>
        /// <param name="TimeintervalforDelta"></param>
        public void ParameterSelection(string parameter, string timeintervalforNormal, string timeintervalforAlerts, string timeintervalforDelta)
        {
            Waits.WaitForElementVisible(driver, parameterTable);
            SelectParametersCheckBoxes(parameter);
            Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, dropdownlistNormal);
            ElementExtensions.SelectByText(dropdownlistNormal, timeintervalforNormal);
            Waits.WaitForElementVisible(driver, dropdownlistAlert);
            ElementExtensions.SelectByText(dropdownlistAlert, timeintervalforAlerts);
            Waits.WaitForElementVisible(driver, listDeltaValue);
            Waits.Wait(driver, 1000);
            listDeltaValue.Clear();
            ElementExtensions.EnterTextValue(listDeltaValue, timeintervalforDelta);
            listDeltaValue.SendKeys(Keys.Tab);
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

        /// <summary>
        ///  Check given checkbox inside Parameter table is selected 
        /// </summary>
        /// <param name="Parameter"></param>
        public bool IsParametersCheckBoxSelected(string parameter)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, parameterTable);
            List<IWebElement> lstEle = new List<IWebElement>(parameterTable.FindElements(By.TagName("tr")));

            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(parameter))
                    {
                        List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.XPath("//table//tbody//tr//td//img")));
                        if (lstCol.Count > 0)
                        {
                            foreach (var col in lstCol)
                            {
                                if (col.GetAttribute("src").Contains("chk_on"))
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
        /// Check the presence of selected Equipment
        /// </summary>
        /// <returns></returns>
        public bool IsListedequipment()
        {
            bool flag = false;
            for (int i = 1; i <= 30; i++)
            {
                Waits.Wait(driver, 1000);
                try
                {
                    Waits.WaitForElementVisible(driver, LblAssignmentsGrid);
                    IWebElement ele = LblAssignmentsGrid.FindElement(By.XPath("//table//tbody//tr//td//img"));
                    flag = ele.GetAttribute("src").Contains("greentick");
                }
                catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                    Waits.Wait(driver, 1000);
                }
                catch (NullReferenceException)
                {
                    Waits.Wait(driver, 1000);
                }
            }
            return flag;
        }

        /// <summary>
        /// To check presence of Selcted Parameter
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public bool SelectedParameterListed(string parameter)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, parameterTable);
            List<IWebElement> lstEle = new List<IWebElement>(parameterTable.FindElements(By.TagName("tr")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(parameter))
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
        /// Select assigned Equipment
        /// </summary>
        /// <param name="Equipment"></param>
        public void SelectSingleEquipment(string equipment)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lstEquipmentType);
            List<IWebElement> lstEle = new List<IWebElement>(lstEquipmentType.FindElements(By.TagName("tr")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (flag)
                    {
                        break;
                    }
                    if (ele.Text.Contains(equipment))
                    {
                        List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.TagName("td")));
                        if (lstCol.Count > 0)
                        {
                            foreach (var col in lstCol)
                            {
                                flag = true;
                                col.Click();
                                Waits.Wait(driver, 1000);
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Verify CSS value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public bool VerifyTextColor(IWebElement element, string value)
        {
            bool flag = false;
            for (int i = 1; i < 90; i++)
            {
                Waits.Wait(driver, 1000);
                if (element.GetCssValue("color").Contains(value))
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                    continue;
                }
            }
            return flag;
        }


        /// <summary>
        /// Add equipment to system
        /// </summary>
        public void AddEquipment(string equipmentName)
        {
            Waits.Wait(driver, 3000);
            Waits.WaitAndClick(driver, lnkAddDevice);
            Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, lnkAddSystem);
            Waits.WaitAndClick(driver, lnkAddSystem);
            Waits.Wait(driver, 2000);
            SelectSystemEquipmentType();
            Waits.Wait(driver, 5000);
            ClickOnGetEquipment();
            Waits.Wait(driver, 2000);
            for (int i = 0; i <= 30; i++)
            {
                if (ElementExtensions.isDisplayed(driver, msgNoEquipmentFound))
                {
                    Waits.Wait(driver, 5000);
                    ClickOnGetEquipment();                    
                    continue;
                }
                else
                {
                    break;
                }
            }
            Waits.Wait(driver, 2000);
            SelectEquipment(equipmentName);
            Waits.WaitForElementVisible(driver, btnOKAdd);
            Waits.WaitAndClick(driver, btnOKAdd);
        }

        /// <summary>
        /// Click on Get Equipment
        /// </summary>
        public void ClickOnGetEquipment()
        {
            Waits.WaitAndClick(driver, btnGetEquipment);
        }

        /// <summary>
        /// Selects system to equipment type
        /// </summary>
        public void SelectSystemEquipmentType(string text = "All")
        {
            Waits.WaitForElementVisible(driver, dropdownlistEquipmentType);
            SelectElement element = new SelectElement(dropdownlistEquipmentType);
            element.SelectByText(text);
        }

        /// <summary>
        /// Select Equipment
        /// </summary>
        /// <param name="equipmentTitle"></param>
        public void SelectEquipment(string equipmentTitle)
        {
            bool flag = false;
            try
            {
                for (int i = 0; i < 30; i++)
                {
                    IWebElement elementname = driver.FindElement(By.XPath("//td[contains(@title,'" + equipmentTitle + "')]"));
                    if (flag)
                    {
                        break;
                    }
                    if (elementname.Text.Contains(equipmentTitle))
                    {                      
                        Waits.WaitAndClick(driver, elementname);
                        flag = true;
                        break;
                    }
                    else
                    {
                        Waits.WaitAndClick(driver, btnGetEquipment);
                        Waits.Wait(driver, 1000);
                    }
                }
            }
            catch (NoSuchElementException)
            {
                SelectEquipment(equipmentTitle);
            }
        }

        /// <summary>
        /// Clicks delete button
        /// </summary>
        public void ClickDelete()
        {
            Waits.WaitAndClick(driver, linkDeleteFolder);
        }

        /// <summary>
        /// Click on Folder header
        /// </summary>
        /// <param name="folderName"></param>
        public void ClickOnFolderHeader(string folderName)
        {
            folderName = folderName.Trim('"');
            driver.Navigate().Refresh();
            IWebElement element = driver.FindElement(By.XPath("//div[@id='divBoxHead'][contains(.,'" + folderName + "')]"));
            JavaScriptExecutor.JavaScriptScrollToElement(driver, element);
            element.Click();
        }

        /// <summary>
        /// To Delete Created Folder
        /// </summary>
        /// <param name="folderName"></param>
        public void DeleteNewlyCreatedFolder(string folderName)
        {
            Waits.WaitAndClick(driver, lnkHomePage);
            Waits.WaitAndClick(driver, lnkDeviceManager);
            Waits.WaitAndClick(driver, lnkTopLevel);
            Waits.WaitAndClick(driver, lnkTopLevel);
            ClickOnFolderHeader(folderName);
            Waits.Wait(driver, 1000);
            ClickDelete();
            Waits.WaitAndClick(driver, btnOKDelete);
            Waits.WaitAndClick(driver, btnOKMessage);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// To Select the Agent
        /// </summary>
        /// <param name="agent"></param>
        public void SelectAgentServer(string agent)
        {
            Waits.WaitForElementVisible(driver, lnkAgentHeader);
            List<IWebElement> lstEle = new List<IWebElement>(lnkAgentHeader.FindElements(By.XPath("//font")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(agent))
                    {
                        Waits.Wait(driver, 1000);
                        ele.Click();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// To select the System Id
        /// </summary>
        /// <param name="type"></param>
        public string SelectSystemId()
        {
            string[] equipment = new string[] { "NEW0001PM1", "NEW0001PM2", "NEW0001PM3", "NEW0001PM4", "NEW0001PM5", "NEW0001PM6" };
            string systemID = "";
            Waits.WaitForElementVisible(driver, lnkEcoAgent);
            List<IWebElement> lstEle = new List<IWebElement>(lnkEcoAgent.FindElements(By.TagName("tr")));
            string a = "";
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    for (int i = 0; i < equipment.Length; i++)
                    {
                        if (ele.Text.Contains(equipment[i]))
                        {
                            IList<IWebElement> tableCols = ele.FindElements(By.TagName("td"));
                            string ID = tableCols[4].Text;
                            a = a + "|" + ID;

                        }
                    }
                    systemID = a.TrimStart('|');
                }
            }
        return systemID;
        }

        /// <summary>
        /// To Add All Equipment 
        /// </summary>
        public void AddAllListedEquipment()
        {
            Waits.WaitForElementVisible(driver, btnFindEquipment);
            Waits.WaitAndClick(driver, btnFindEquipment);
            Waits.WaitForElementVisible(driver, btnMoveAllSystemsTo);
            Waits.WaitAndClick(driver, btnMoveAllSystemsTo);
            Waits.WaitForElementVisible(driver, btnApplyChanges);
            Waits.WaitAndClick(driver, btnApplyChanges);
        }

        /// <summary>
        /// Green Mode Enable
        /// </summary>
        public void EnableGreenMode()
        {
            Waits.WaitForElementVisible(driver, lnkOptions);
            Waits.WaitAndClick(driver, lnkOptions);
            Waits.WaitForElementVisible(driver, lnkOptionPnlSetting);
            Waits.Wait(driver, 1000);
            lnkRptOption.SendKeys("On");
            Waits.WaitForElementVisible(driver, btnApplyChanges);
            Waits.WaitAndClick(driver, btnApplyChanges);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// Check message Status  
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public bool EquipmentStatus(string Message)
        {
            bool flag = false;
            for (int i = 0; i < 15; i++)
            {
                Waits.Wait(driver, 1000);
                if (flag)
                {
                    break;
                }
                List<IWebElement> lstEle = new List<IWebElement>(lblTableGrid.FindElements(By.TagName("tr")));
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(Message))
                        {
                            Waits.Wait(driver, 1000);
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
        /// Add Single equipment
        /// </summary>
        /// <param name="equipmentName"></param>
        public void AddSingleEquipment(string equipmentName)
        {
            AddEquipment(equipmentName);
            Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, lblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(lblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.EquipmentAddedMsg), "Verifying 'Equipment Added Successfully' message");
            Waits.WaitForElementVisible(driver, btnOk);
            ClickOkAfterConformationMessage();
            Waits.Wait(driver, 4000);
        }
    }
}
#endregion