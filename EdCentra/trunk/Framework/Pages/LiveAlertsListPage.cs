using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class LiveAlertsListPage : PageBase
    {
        private IWebDriver driver;

        public LiveAlertsListPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for Alertpage
        #region

        [FindsBy(How = How.XPath, Using = "//div[@class='modalTabs']//a[text()='Alert History']")]
        private IWebElement alertHistoryTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'historyScrollBox')]//table[contains(@class,'alertHistory')]/tbody")]
        private IWebElement tblHistory { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'btnCloseDetails')]//input[@class='imgBtnStd']")]
        private IWebElement btnCloseAlertHistory { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='lnkErrorCount']")]
        private IWebElement lnkError { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='lnkWarningCount']")]
        private IWebElement lnkWarning { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='lnkInfoCount']")]
        private IWebElement lnkInfo_Advisory { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divErrorCount']")]
        private IWebElement tooltipError { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divWarningCount']")]
        private IWebElement tooltipWarning { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divInfoCount']")]
        private IWebElement tooltipInfoAdvisory { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ctl00_cphContent_cphContent_gvAlerts']/tbody")]
        private IWebElement lstAlarm { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ctl00_cphContent_cphContent_gvAlerts']/tbody")]
        private IWebElement lstWarning { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ctl00_cphContent_cphContent_gvAlerts']/tbody")]
        private IWebElement lstInfoAdvisory { get; set; }

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Active:')]")]
        private IWebElement lblActive;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphSubMenuBar_lnkActiveAlerts")]
        private IWebElement lnkActive;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_Image1")]
        private IWebElement imgLoadingIndicator;

        //[FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ctl00_cphContent_cphContent_gvAlerts']/tbody")]
        //private IWebElement tableAlarm { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_gvAlerts")]
        private IWebElement tableAlarm;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnApplyFilter")]
        private IWebElement btnApplyFilter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnShowFilter")]
        private IWebElement btnShowFilter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterALAdvisory_imgCheckBox")]
        private IWebElement chkBoxAdvisory;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterALMinorWarning_imgCheckBox")]
        private IWebElement chkBoxMinorWarning;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterALMajorWarning_imgCheckBox")]
        private IWebElement chkboxMajorWarning;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterALMinorAlarm_imgCheckBox")]
        private IWebElement chkBoxMinorAlarm;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterALMajorAlarm_imgCheckBox")]
        private IWebElement chkBoxMajorAlarm;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_lblSeverity")]
        private IWebElement lblSeverityValue;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_hypParameter")]
        private IWebElement lnkParameterValue;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_lblParameter")]
        private IWebElement lblParameterValue;
        
        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Close')]")]
        private IWebElement btnClose;

        [FindsBy(How = How.Id, Using = "lnkErrorCount")]
        private IWebElement lnkAlarmCount;

        [FindsBy(How = How.Id, Using = "lnkWarningCount")]
        private IWebElement lnkWarningCount;

        [FindsBy(How = How.Id, Using = "lnkInfoCount")]
        private IWebElement lnkInfoCount;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnManualAlert")]
        private IWebElement btnCreateAlert;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ManualAlert_lblPopupManualAlertTitle")]
        private IWebElement titleCreateAlertPopUp;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ManualAlert_ddlAssignedUser")]
        private IWebElement drpDwnAssignedUser;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ManualAlert_ddlSeverity")]
        private IWebElement drpDwnSeverity;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ManualAlert_txtMessage")]
        private IWebElement txtAreaMessage;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ManualAlert_btnCreate")]
        private IWebElement btnCreateAlertPopUp;

        [FindsBy(How = How.XPath, Using = "//img[contains(@src, '/EdwardsScada/img/busy/ajax_loader_smallgrey.gif')]")]
        private IWebElement imgLoader;

        [FindsBy(How = How.ClassName, Using = "infomessage")]
        private IWebElement infoMessage;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_lblMessage")]
        private IWebElement lblAlertDetailsMsg;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_lblAlertCreated")]
        private IWebElement lblAlertCreated { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkFilterMaintenanceStatus")]
        private IWebElement lblMaintenanceStatus;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlFilterAssignedUser")]
        private IWebElement drpDwnAssignedUserFilter;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id, 'ctl00_ctl00_cphContent_cphContent_AlertDetails_ddlAssignedUser')]//option[contains(@selected, 'selected')]")]
        private IWebElement drpDwnSelectedAssignedUserAlertDetails;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_ddlAssignedUser")]
        private IWebElement drpDwnAssignedUserAlertDetails;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtFilterMessage")]
        private IWebElement txtBoxMessage;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtFilterSystemName")]
        private IWebElement txtBoxSystemName;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_lblEquipment")]
        private IWebElement lblEquipmentAlertDetails;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ManualAlert_txtSystemNameFilter")]
        private IWebElement txtBoxSearch;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ManualAlert_ddlSystemTypeFilter")]
        private IWebElement drpDwnEquipmentType;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Find Equipment')]")]
        private IWebElement btnFindEquipment;

        [FindsBy(How = How.XPath, Using = "//td[contains(@title,'NEW0001')]")]
        private IWebElement lblEquipment;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ManualAlert_txtComments")]
        private IWebElement txtBoxComment;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_ddlMaintenanceStatus")]
        private IWebElement drpDwnMaintenanceStatus;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_btnApplyDetails")]
        private IWebElement btnApply;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_lnkDetails")]
        private IWebElement lnkAlertDetails;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_txtComments")]
        private IWebElement txtBoxCommentAlertDetails;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id, 'ctl00_ctl00_cphContent_cphContent_AlertDetails_ddlMaintenanceStatus')]//option[contains(@selected, 'selected')]")]
        private IWebElement drpDwnSelectedMaintenanceStatusAlertDetails { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@id, 'ctl00_ctl00_cphContent_cphContent_ddlFilterAssignedUser')]//option[contains(@selected, 'selected')]")]
        private IWebElement drpdwnSelectedAssignedUser;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id, 'ctl00_ctl00_cphContent_cphContent_ddlFilterGroup')]//option[contains(@selected, 'selected')]")]
        private IWebElement drpdwnSelectedGroupOption;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_lnkHistory")]
        private IWebElement lnkAlertHistory;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Add')]")]
        private IWebElement btnAdd;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_txtNewComment")]
        private IWebElement txtBoxAddComment;

        [FindsBy(How = How.ClassName, Using = "alertHistory")]
        private IWebElement tblAlertHistory { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_lblLastUpdate")]
        private IWebElement lblLastUpdated;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ManualAlert_ddlMaintenanceStatus")]
        private IWebElement drpDwnMaintenanceStatusCreateAlert;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Hide Filter')]")]
        private IWebElement btnHideFilter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterMSUnacknowledged_imgCheckBox")]
        private IWebElement chkBoxUnacknowledged;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterMSAcknowledged_imgCheckBox")]
        private IWebElement chkBoxAcknowledged;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterMSAssigned_imgCheckBox")]
        private IWebElement chkBoxAssigned;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterMSWorkinProgress_imgCheckBox")]
        private IWebElement chkBoxWorkInProgress;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterMSPending_imgCheckBox")]
        private IWebElement chkBoxPending;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterMSClosed_imgCheckBox")]
        private IWebElement chkBoxClosed;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterDateRange_imgCheckBox")]
        private IWebElement chkBoxFilterDateRange;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtFilterDateFrom")]
        private IWebElement txtBoxFromDate;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtFilterDateTo")]
        private IWebElement txtBoxToDate;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ibtFilterDateFrom")]
        private IWebElement calendarFromDate;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ibtFilterDateTo")]
        private IWebElement calendarToDate;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'title')][@class='ajax__calendar_title']")]
        private IWebElement datePickerCalender;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'prevArrow')][@class='ajax__calendar_prev']")]
        private IWebElement btnPrevious;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'nextArrow')][@class='ajax__calendar_next']")]
        private IWebElement btnNext;

        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ctl00_cphContent_cphContent_CalendarExtender1_day_0_4']")]
        private IWebElement lblFromDate;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_CalendarExtender2_day_4_5')]")]
        private IWebElement lblToDate;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Reset Filter')]")]
        private IWebElement btnResetFilter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlFilterGroup")]
        private IWebElement drpDwnGrpFilter;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Apply Filter')]")]
        private IWebElement buttonApplyFilter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl03_lblLinkText")]
        private IWebElement lnkDiagnostics;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl03_rptSubMenu_ctl04_lblLinkText")]
        private IWebElement lnkDataExtractionUtility;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_lnkInhibit")]
        private IWebElement lnkInhibitSettings;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_btnAddInhibit")]
        private IWebElement btnDoNotPageThisAlert;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_txtReason")]
        private IWebElement txtAreaReason;

        [FindsBy(How = How.Id, Using = "txtUserDetail")]
        private IWebElement txtBoxCreatedBy;

        [FindsBy(How = How.Id, Using = "txtInhibitDetail")]
        private IWebElement txtBoxInhibitEnd;

        [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rdlDurationType_1')]")]
        private IWebElement lblHoursInhibitSettings;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterESEquipment_imgCheckBox")]
        private IWebElement chkBoxEquipment;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterESPredictiveDiagnostics_imgCheckBox")]
        private IWebElement chkBoxPdM;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterESParameterThresholdMonitoring_imgCheckBox")]
        private IWebElement chkBoxPTM;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterESNetwork_imgCheckBox")]
        private IWebElement chkBoxNetwork;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterESSystemHealthMonitor_imgCheckBox")]
        private IWebElement chkBoxSysHealthMonitor;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterESStatusMonitor_imgCheckBox")]
        private IWebElement chkBoxStatusMonitor;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterESManuallyCreated_imgCheckBox")]
        private IWebElement chkBoxManuallyCreated;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphSubMenuBar_lnkAllAlerts")]
        private IWebElement lnkAllAlerts;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_lblActualStatus")]
        private IWebElement lblActualStatus;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl01_lblLinkText")]
        private IWebElement lnkHome;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl02_hypLink")]
        private IWebElement lnkRealTimeMonitoring;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl02_rptSubMenu_ctl01_hypLink")]
        private IWebElement lnkDeviceExplorer;
        #endregion

        //Properties
        #region

        public IWebElement LnkDeviceExplorer
        {
            get
            {
                return lnkDeviceExplorer;
            }
            set
            {
                lnkDeviceExplorer = value;
            }
        }

        public IWebElement LnkRealTimeMonitoring
        {
            get
            {
                return lnkRealTimeMonitoring;
            }
            set
            {
                lnkRealTimeMonitoring = value;
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
        public IWebElement LblActualStatus
        {
            get
            {
                return lblActualStatus;
            }
            set
            {
                lblActualStatus = value;
            }
        }

        public IWebElement LnkAllAlerts
        {
            get
            {
                return lnkAllAlerts;
            }
            set
            {
                LnkAllAlerts = value;
            }
        }

        public IWebElement LnkActive
        {
            get
            {
                return lnkActive;
            }
            set
            {
                lnkActive = value;
            }
        }

        public IWebElement ChkBoxManuallyCreated
        {
            get
            {
                return chkBoxManuallyCreated;
            }
            set
            {
                chkBoxManuallyCreated = value;
            }
        }

        public IWebElement ChkBoxStatusMonitor
        {
            get
            {
                return chkBoxStatusMonitor;
            }
            set
            {
                chkBoxStatusMonitor = value;
            }
        }

        public IWebElement ChkBoxSysHealthMonitor
        {
            get
            {
                return chkBoxSysHealthMonitor;
            }
            set
            {
                chkBoxSysHealthMonitor = value;
            }
        }

        public IWebElement ChkBoxNetwork
        {
            get
            {
                return chkBoxNetwork;
            }
            set
            {
                chkBoxNetwork = value;
            }
        }

        public IWebElement ChkBoxPTM
        {
            get
            {
                return chkBoxPTM;
            }
            set
            {
                chkBoxPTM = value;
            }
        }

        public IWebElement ChkBoxPdM
        {
            get
            {
                return chkBoxPdM;
            }
            set
            {
                chkBoxPdM = value;
            }
        }

        public IWebElement ChkBoxEquipment
        {
            get
            {
                return chkBoxEquipment;
            }
            set
            {
                chkBoxEquipment = value;
            }
        }

        public IWebElement LblHoursInhibitSettings
        {
            get
            {
                return lblHoursInhibitSettings;
            }
            set
            {
                lblHoursInhibitSettings = value;
            }
        }

        public IWebElement TxtBoxInhibitEnd
        {
            get
            {
                return txtBoxInhibitEnd;
            }
            set
            {
                txtBoxInhibitEnd = value;
            }
        }

        public IWebElement TxtBoxCreatedBy
        {
            get
            {
                return txtBoxCreatedBy;
            }
            set
            {
                txtBoxCreatedBy = value;
            }
        }

        public IWebElement TxAreaReason
        {
            get
            {
                return txtAreaReason;
            }
            set
            {
                txtAreaReason = value;
            }
        }

        public IWebElement BtnDoNotPageThisAlert
        {
            get
            {
                return btnDoNotPageThisAlert;
            }
            set
            {
                btnDoNotPageThisAlert = value;
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

        public IWebElement LblEquipmentAlertDetails
        {
            get
            {
                return lblEquipmentAlertDetails;
            }
            set
            {
                lblEquipmentAlertDetails = value;
            }
        }

        public IWebElement LblSeverityValue
        {
            get
            {
                return lblSeverityValue;
            }
            set
            {
                lblSeverityValue = value;
            }
        }

        public IWebElement LblAlertDetailsMsg
        {
            get
            {
                return lblAlertDetailsMsg;
            }
            set
            {
                lblAlertDetailsMsg = value;
            }
        }
        public IWebElement LnkDiagnostics
        {
            get
            {
                return lnkDiagnostics;
            }
            set
            {
                lnkDiagnostics = value;
            }
        }

        public IWebElement LnkDataExtractionUtility
        {
            get
            {
                return lnkDataExtractionUtility;
            }
            set
            {
                lnkDataExtractionUtility = value;
            }
        }

        public IWebElement TxtBoxToDate
        {
            get
            {
                return txtBoxToDate;
            }
            set
            {
                txtBoxToDate = value;
            }
        }

        public IWebElement BtnNext
        {
            get
            {
                return btnNext;
            }
            set
            {
                btnNext = value;
            }
        }

        public IWebElement LblFromDate
        {
            get
            {
                return lblFromDate;
            }
            set
            {
                lblFromDate = value;
            }
        }

        public IWebElement LblToDate
        {
            get
            {
                return lblToDate;
            }
            set
            {
                lblToDate = value;
            }
        }
        public IWebElement BtnPrevious
        {
            get
            {
                return btnPrevious;
            }
            set
            {
                btnPrevious = value;
            }
        }

        public IWebElement BtnResetFilter
        {
            get
            {
                return btnResetFilter;
            }
            set
            {
                btnResetFilter = value;
            }
        }

        public IWebElement TxtBoxFromDate
        {
            get
            {
                return txtBoxFromDate;
            }
            set
            {
                txtBoxFromDate = value;
            }
        }

        public IWebElement CalendarFromDate
        {
            get
            {
                return calendarFromDate;
            }
            set
            {
                calendarFromDate = value;
            }
        }

        public IWebElement DatePickerCalender
        {
            get
            {
                return datePickerCalender;
            }
            set
            {
                datePickerCalender = value;
            }
        }

        public IWebElement CalendarToDate
        {
            get
            {
                return calendarToDate;
            }
            set
            {
                calendarToDate = value;
            }
        }

        public IWebElement ChkBoxUnacknowledged
        {
            get
            {
                return chkBoxUnacknowledged;
            }
            set
            {
                chkBoxUnacknowledged = value;
            }
        }

        public IWebElement ChkBoxAcknowledged
        {
            get
            {
                return chkBoxAcknowledged;
            }
            set
            {
                chkBoxAcknowledged = value;
            }
        }

        public IWebElement ChkBoxFilterDateRange
        {
            get
            {
                return chkBoxFilterDateRange;
            }
            set
            {
                chkBoxFilterDateRange = value;
            }
        }

        public IWebElement ChkBoxAssigned
        {
            get
            {
                return chkBoxAssigned;
            }
            set
            {
                chkBoxAssigned = value;
            }
        }

        public IWebElement DrpDwnGrpFilter
        {
            get
            {
                return drpDwnGrpFilter;
            }
            set
            {
                drpDwnGrpFilter = value;
            }
        }

        public IWebElement ChkBoxWorkInProgress
        {
            get
            {
                return chkBoxWorkInProgress;
            }
            set
            {
                chkBoxWorkInProgress = value;
            }
        }

        public IWebElement ChkBoxPending
        {
            get
            {
                return chkBoxPending;
            }
            set
            {
                chkBoxPending = value;
            }
        }

        public IWebElement ChkBoxClosed
        {
            get
            {
                return chkBoxClosed;
            }
            set
            {
                chkBoxClosed = value;
            }
        }

        public IWebElement ButtonApplyFilter
        {
            get
            {
                return buttonApplyFilter;
            }
            set
            {
                buttonApplyFilter = value;
            }
        }

        public IWebElement ImgLoadingIndicator
        {
            get
            {
                return imgLoadingIndicator;
            }
            set
            {
                imgLoadingIndicator = value;
            }
        }

        public IWebElement LblEquipment
        {
            get
            {
                return lblEquipment;
            }
            set
            {
                lblEquipment = value;
            }
        }

        public IWebElement LnkAlarmCount
        {
            get
            {
                return lnkAlarmCount;
            }
            set
            {
                lnkAlarmCount = value;
            }
        }

        public IWebElement TxtBoxSearch
        {
            get
            {
                return txtBoxSearch;
            }
            set
            {
                txtBoxSearch = value;
            }
        }

        public IWebElement DrpdwnSelectedAssignedUser
        {
            get
            {
                return drpdwnSelectedAssignedUser;
            }
            set
            {
                drpdwnSelectedAssignedUser = value;
            }
        }

        public IWebElement BtnAdd
        {
            get
            {
                return btnAdd;
            }
            set
            {
                btnAdd = value;
            }
        }

        public IWebElement TxtBoxAddComment
        {
            get
            {
                return txtBoxAddComment;
            }
            set
            {
                txtBoxAddComment = value;
            }
        }

        public IWebElement DrpDwnAssignedUserAlertDetails
        {
            get
            {
                return drpDwnAssignedUserAlertDetails;
            }
            set
            {
                drpDwnAssignedUserAlertDetails = value;
            }
        }

        public IWebElement DrpdwnSelectedGroupOption
        {
            get
            {
                return drpdwnSelectedGroupOption;
            }
            set
            {
                drpdwnSelectedGroupOption = value;
            }
        }

        public IWebElement DrpDwnMaintenanceStatusCreateAlert
        {
            get
            {
                return drpDwnMaintenanceStatusCreateAlert;
            }
            set
            {
                drpDwnMaintenanceStatusCreateAlert = value;
            }
        }

        public IWebElement BtnHideFilter
        {
            get
            {
                return btnHideFilter;
            }
            set
            {
                btnHideFilter = value;
            }
        }

        public IWebElement DrpDwnSelectedAssignedUserAlertDetails
        {
            get
            {
                return drpDwnSelectedAssignedUserAlertDetails;
            }
            set
            {
                drpDwnSelectedAssignedUserAlertDetails = value;
            }
        }

        public IWebElement LnkAlertHistory
        {
            get
            {
                return lnkAlertHistory;
            }
            set
            {
                lnkAlertHistory = value;
            }
        }

        public IWebElement LnkAlertDetails
        {
            get
            {
                return lnkAlertDetails;
            }
            set
            {
                lnkAlertDetails = value;
            }
        }

        public IWebElement DrpDwnMaintenanceStatus
        {
            get
            {
                return drpDwnMaintenanceStatus;
            }
            set
            {
                drpDwnMaintenanceStatus = value;
            }
        }

        public IWebElement DrpDwnSelectedMaintenanceStatusAlertDetails
        {
            get
            {
                return drpDwnSelectedMaintenanceStatusAlertDetails;
            }
            set
            {
                drpDwnSelectedMaintenanceStatusAlertDetails = value;
            }
        }

        public IWebElement TxtBoxComment
        {
            get
            {
                return txtBoxComment;
            }
            set
            {
                txtBoxComment = value;
            }
        }

        public IWebElement BtnApply
        {
            get
            {
                return btnApply;
            }
            set
            {
                btnApply = value;
            }
        }

        public IWebElement DrpDwnEquipmentType
        {
            get
            {
                return drpDwnEquipmentType;
            }
            set
            {
                drpDwnEquipmentType = value;
            }
        }

        public IWebElement TxtBoxCommentAlertDetails
        {
            get
            {
                return txtBoxCommentAlertDetails;
            }
            set
            {
                txtBoxCommentAlertDetails = value;
            }
        }

        public IWebElement BtnFindEquipment
        {
            get
            {
                return btnFindEquipment;
            }
            set
            {
                btnFindEquipment = value;
            }
        }

        public IWebElement LblLastUpdated
        {
            get
            {
                return lblLastUpdated;
            }
            set
            {
                lblLastUpdated = value;
            }

        }
        public IWebElement LnkWarningCount
        {
            get
            {
                return lnkWarningCount;
            }
            set
            {
                lnkWarningCount = value;
            }
        }

        public IWebElement BtnClose
        {
            get
            {
                return btnClose;
            }
            set
            {
                btnClose = value;
            }
        }

        public IWebElement TxtBoxMessage
        {
            get
            {
                return txtBoxMessage;
            }
            set
            {
                txtBoxMessage = value;
            }
        }

        public IWebElement TxtBoxSystemName
        {
            get
            {
                return txtBoxSystemName;
            }
            set
            {
                txtBoxSystemName = value;
            }
        }

        public IWebElement DrpDwnAssignedUser
        {
            get
            {
                return drpDwnAssignedUser;
            }
            set
            {
                drpDwnAssignedUser = value;
            }
        }

        public IWebElement DrpDwnAssignedUserFilter
        {
            get
            {
                return drpDwnAssignedUserFilter;
            }
            set
            {
                drpDwnAssignedUserFilter = value;
            }
        }

        public IWebElement ImgLoader
        {
            get
            {
                return imgLoader;
            }
            set
            {
                imgLoader = value;
            }
        }

        public IWebElement LblMaintenanceStatus
        {
            get
            {
                return lblMaintenanceStatus;
            }
            set
            {
                lblMaintenanceStatus = value;
            }
        }

        public IWebElement InfoMessage
        {
            get
            {
                return infoMessage;
            }
            set
            {
                infoMessage = value;
            }
        }

        public IWebElement DrpDwnSeverity
        {
            get
            {
                return drpDwnSeverity;
            }
            set
            {
                drpDwnSeverity = value;
            }
        }

        public IWebElement TxtAreaMessage
        {
            get
            {
                return txtAreaMessage;
            }
            set
            {
                txtAreaMessage = value;
            }
        }

        public IWebElement BtnCreateAlertPopUp
        {
            get
            {
                return btnCreateAlertPopUp;
            }
            set
            {
                btnCreateAlertPopUp = value;
            }
        }

        public IWebElement TitleCreateAlertPopUp
        {
            get
            {
                return titleCreateAlertPopUp;
            }
            set
            {
                titleCreateAlertPopUp = value;
            }
        }

        public IWebElement LnkInfoCount
        {
            get
            {
                return lnkInfoCount;
            }
            set
            {
                lnkInfoCount = value;
            }
        }

        public IWebElement LblActive
        {
            get
            {
                return lblActive;
            }
        }

        public IWebElement TableAlarm
        {
            get
            {
                return tableAlarm;
            }
            set
            {
                tableAlarm = value;
            }
        }

        public IWebElement ChkBoxAdvisory
        {
            get
            {
                return chkBoxAdvisory;
            }
            set
            {
                chkBoxAdvisory = value;
            }
        }

        public IWebElement BtnCreateAlert
        {
            get
            {
                return btnCreateAlert;
            }
            set
            {
                btnCreateAlert = value;
            }
        }

        public IWebElement ChkBoxMinorWarning
        {
            get
            {
                return chkBoxMinorWarning;
            }
        }

        public IWebElement ChkboxMajorWarning
        {
            get
            {
                return chkboxMajorWarning;
            }
        }

        public IWebElement ChkBoxMinorAlarm
        {
            get
            {
                return chkBoxMinorAlarm;
            }
        }

        public IWebElement ChkBoxMajorAlarm
        {
            get
            {
                return chkBoxMajorAlarm;
            }
        }

        public IWebElement BtnApplyFilter
        {
            get
            {
                return btnApplyFilter;
            }
        }

        public IWebElement BtnShowFilter
        {
            get
            {
                return btnShowFilter;
            }
        }
        #endregion

        /// <summary>
        /// Wait till loading indicator displayed
        /// </summary>
        public void WaitTillLoadingIndicatorDisplayed(IWebElement imgLoadingIndicator)
        {
            for (int i = 1; i <= 20; i++)
            {
                if (Waits.WaitForElementVisible(driver, imgLoadingIndicator))
                {
                    Waits.Wait(driver, 1000);
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Raised All Alerts
        /// </summary>
        /// <param name="advisoryParameter"></param>
        /// <param name="majorAlarmParameter"></param>
        /// <param name="minorAlarmParameter"></param>
        /// <param name="majorWarningParameter"></param>
        /// <param name="minorWarningParameter"></param>
        /// <param name="equipmentName"></param>
        /// <returns></returns>
        public bool IsAllAlertsRaised(string advisoryParameter, string majorAlarmParameter, string minorAlarmParameter, string majorWarningParameter, string minorWarningParameter, string equipmentName)
        {
            bool flag = false;
            List<bool> statusLst = new List<bool>();
            for (int i = 1; i <= 5; i++)
            {
                try
                {
                    Waits.WaitForElementVisible(driver, tableAlarm);
                    List<IWebElement> lstAlarmRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                    lstAlarmRows[i].Click();
                    Waits.Wait(driver, 15000);
                    Waits.WaitForElementVisible(driver, lblSeverityValue);
                    if (lnkParameterValue.Text.Equals(majorAlarmParameter) && lblSeverityValue.Text.Contains(GlobalConstants.AlertMajorAlarm))
                    {
                        statusLst.Add(true);
                    }
                    else if (lnkParameterValue.Text.Equals(minorAlarmParameter) && lblSeverityValue.Text.Contains(GlobalConstants.AlertMinorAlarm))
                    {
                        statusLst.Add(true);
                    }
                    else if (lnkParameterValue.Text.Equals(minorWarningParameter) && lblSeverityValue.Text.Contains(GlobalConstants.AlertMinorWarning))
                    {
                        statusLst.Add(true);
                    }
                    else if (lnkParameterValue.Text.Equals(majorWarningParameter) && lblSeverityValue.Text.Contains(GlobalConstants.AlertMajorWarning))
                    {
                        statusLst.Add(true);
                    }
                    else if (lnkParameterValue.Text.Equals(advisoryParameter) && lblSeverityValue.Text.Contains(GlobalConstants.AlertAdvisory))
                    {
                        statusLst.Add(true);
                    }
                    else
                    {
                        statusLst.Add(false);
                    }

                    btnClose.Click();
                    Waits.Wait(driver, 8000);
                }

                catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                   
                }
            }
            foreach (var status in statusLst)
            {
                if (status.Equals(false))
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// Raised All Alerts
        /// </summary>
        /// <param name="advisoryParameter"></param>
        /// <param name="majorAlarmParameter"></param>
        /// <param name="minorAlarmParameter"></param>
        /// <param name="majorWarningParameter"></param>
        /// <param name="minorWarningParameter"></param>
        /// <param name="equipmentName"></param>
        /// <returns></returns>
        public bool IsAllAlertsRaisedForUserNotHavingHistorianPermission(string advisoryParameter, string majorAlarmParameter, string minorAlarmParameter, string majorWarningParameter, string minorWarningParameter, string equipmentName)
        {
            bool flag = false;
            List<bool> statusLst = new List<bool>();
            for (int i = 1; i <= 6; i++)
            {
                try
                {
                    Waits.WaitForElementVisible(driver, tableAlarm);
                    List<IWebElement> lstAlarmRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                    if (lstAlarmRows.Count > 1)
                    {
                        lstAlarmRows[i].Click();
                        Waits.Wait(driver, 15000);
                        Waits.WaitForElementVisible(driver, lblSeverityValue);
                        if (lblParameterValue.Text.Equals(majorAlarmParameter) && lblSeverityValue.Text.Contains(GlobalConstants.AlertMajorAlarm))
                        {
                            statusLst.Add(true);
                        }
                        else if (lblParameterValue.Text.Equals(minorAlarmParameter) && lblSeverityValue.Text.Contains(GlobalConstants.AlertMinorAlarm))
                        {
                            statusLst.Add(true);
                        }
                        else if (lblParameterValue.Text.Equals(minorWarningParameter) && lblSeverityValue.Text.Contains(GlobalConstants.AlertMinorWarning))
                        {
                            statusLst.Add(true);
                        }
                        else if (lblParameterValue.Text.Equals(majorWarningParameter) && lblSeverityValue.Text.Contains(GlobalConstants.AlertMajorWarning))
                        {
                            statusLst.Add(true);
                        }
                        else if (lblParameterValue.Text.Equals(advisoryParameter) && lblSeverityValue.Text.Contains(GlobalConstants.AlertAdvisory))
                        {
                            statusLst.Add(true);
                        }
                        else
                        {
                            statusLst.Add(false);
                        }

                        btnClose.Click();
                        Waits.Wait(driver, 8000);
                    }
                }

                catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                    //WaitTillLoadingIndicatorDisplayed(imgLoadingIndicator);
                }
            }
            foreach (var status in statusLst)
            {
                if (status.Equals(false))
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// Raised All Alerts
        /// </summary>
        /// <param name="advisoryParameter"></param>
        /// <param name="majorAlarmParameter"></param>
        /// <param name="minorAlarmParameter"></param>
        /// <param name="majorWarningParameter"></param>
        /// <param name="minorWarningParameter"></param>
        /// <param name="equipmentName"></param>
        /// <returns></returns>
        public bool IsAllTurboAlertsDisplayed()
        {
            bool flag = false;
            List<bool> statusLst = new List<bool>();
            try
            {
                for (int i = 1; i <= 2; i++)
                {
                    Waits.WaitForElementVisible(driver, tableAlarm);
                    List<IWebElement> lstAlarmRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                    lstAlarmRows[i].Click();
                    Waits.Wait(driver, 15000);
                    Waits.WaitForElementVisible(driver, lblSeverityValue);
                    if (lnkParameterValue.Text.Equals(GlobalConstants.TurboWarningParameter) && lblSeverityValue.Text.Contains(GlobalConstants.AlertMajorWarning))
                    {
                        statusLst.Add(true);
                    }
                    else if (lnkParameterValue.Text.Equals(GlobalConstants.TurboAlarmParameter) && lblSeverityValue.Text.Contains(GlobalConstants.AlertMinorAlarm))
                    {
                        statusLst.Add(true);
                    }
                    else
                    {
                        statusLst.Add(false);
                    }

                    btnClose.Click();
                    Waits.Wait(driver, 8000);
                }
                foreach (var status in statusLst)
                {
                    if (status.Equals(false))
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
            catch (StaleElementReferenceException)
            {
                driver.Navigate().Refresh();
                WaitTillLoadingIndicatorDisplayed(imgLoadingIndicator);
            }
            return flag;
        }

        /// <summary>
        /// Checks created alert displayed on alert screen
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="alertType"></param>
        /// <returns></returns>
        public bool IsCreatedAlertDisplayed(string msg, string alertType = "Advisory")
        {
            bool flag = false;
            List<bool> statusLst = new List<bool>();
            Waits.Wait(driver, 6000);
            Waits.WaitForElementVisible(driver, tableAlarm);
            List<IWebElement> lstAlarmRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
            for (int i = 1; i <= lstAlarmRows.Count; i++)
            {
                try
                {
                    List<IWebElement> lstRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                    lstRows[1].Click();
                    Waits.Wait(driver, 8000);
                    Waits.WaitForElementVisible(driver, lblSeverityValue);
                    if (lblSeverityValue.Text.Equals(alertType) && lblAlertDetailsMsg.Text.Contains(msg))
                    {
                        flag = true;
                        JavaScriptExecutor.JavaScriptLinkClick(driver, btnClose);
                        //Waits.WaitAndClick(driver,  btnClose);
                        break;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                   // WaitTillLoadingIndicatorDisplayed(imgLoadingIndicator);
                }
            }
            return flag;
        }

        /// <summary>
        /// Click newly created alert
        /// </summary>
        public void ClickNewlyCreatedAlert()
        {
            List<bool> statusLst = new List<bool>();
            try
            {
                Waits.WaitForElementVisible(driver, tableAlarm);
                List<IWebElement> lstAlarmRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                lstAlarmRows.ElementAt(1).Click();
            }
            catch (StaleElementReferenceException)
            {
                driver.Navigate().Refresh();
                //WaitTillLoadingIndicatorDisplayed(imgLoadingIndicator);
            }
        }

        /// <summary>
        /// Checks Alert Filtered By Message
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool IsAlertFilteredByMessage(string msg)
        {

            bool flag = false;
            List<bool> statusLst = new List<bool>();
            Waits.WaitForElementVisible(driver, tableAlarm);
            List<IWebElement> lstAlertRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
            for (int i = 1; i <= lstAlertRows.Count - 1; i++)
            {
                try
                {
                    List<IWebElement> lstAlarmRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                    lstAlarmRows[i].Click();
                    Waits.Wait(driver, 10000);
                    Waits.WaitForElementVisible(driver, lblSeverityValue);
                    if (lblAlertDetailsMsg.Text.Contains(msg))
                    {
                        statusLst.Add(true);
                    }
                    else
                    {
                        statusLst.Add(false);
                    }
                    btnClose.Click();
                    Waits.Wait(driver, 8000);
                }
                catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                    WaitTillLoadingIndicatorDisplayed(imgLoadingIndicator);
                }
            }
            foreach (var status in statusLst)
            {
                if (status.Equals(false))
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }


        /// <summary>
        /// close previous active alerts
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public void ClosePreviousActiveAlerts()
        {
            try
            {
                List<bool> statusLst = new List<bool>();
                Waits.Wait(driver, 1000);
                JavaScriptExecutor.JavaScriptLinkClick(driver, tableAlarm);
                //Waits.WaitAndClick(driver, tableAlarm);
                List <IWebElement> lstAlertRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                for (int i = 1; i <= lstAlertRows.Count - 1; i++)
                {
                    try
                    {
                        List<IWebElement> lstRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                        lstRows[1].Click();
                        Waits.Wait(driver, 10000);
                        Waits.WaitForElementVisible(driver, lblSeverityValue);
                        drpDwnMaintenanceStatus.Click();
                        ElementExtensions.SelectByText(drpDwnMaintenanceStatus, "Closed");
                        BtnApply.Click();
                        Waits.Wait(driver, 2000);
                        btnClose.Click();
                        Waits.Wait(driver, 13000);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        break;
                    }

                }
            }
            catch (StaleElementReferenceException)
            {
                driver.Navigate().Refresh();
            }
            catch (TargetInvocationException ex)
            {
                List<IWebElement> lstRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                lstRows[1].Click();
                Waits.Wait(driver, 10000);
                Waits.WaitForElementVisible(driver, lblSeverityValue);
                drpDwnMaintenanceStatus.Click();
                ElementExtensions.SelectByText(drpDwnMaintenanceStatus, "Closed");
                BtnApply.Click();
                Waits.Wait(driver, 2000);
                btnClose.Click();
                Waits.Wait(driver, 13000);
            }

        }

        /// <summary>
        /// Checks Alert Filtered By Date
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public bool IsAlertFilteredByDate(DateTime startDate, DateTime endDate)
        {
            bool flag = false;
            List<bool> statusLst = new List<bool>();
            Waits.WaitForElementVisible(driver, tableAlarm);
            List<IWebElement> lstAlertRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
            for (int i = 1; i <= lstAlertRows.Count - 1; i++)
            {
                try
                {
                    Waits.Wait(driver, 8000);
                    List<IWebElement> lstAlarmRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                    lstAlarmRows[i].Click();
                    Waits.Wait(driver, 10000);
                    Waits.WaitForElementVisible(driver, lblSeverityValue);
                    string alertCreatedDate = lblAlertCreated.Text;
                    string [] alertCreated  = alertCreatedDate.Split(' ');
                    DateTime date = DateTime.ParseExact(alertCreated[0], "dd/MM/yyyy", null);// InvariantCulture);
                    //DateTime date = DateTime.ParseExact(alertCreated[0], "yyyy/MM/dd", CultureInfo.InvariantCulture);

                    if ((startDate <= date.Date) && (date.Date <= endDate))
                    {
                        statusLst.Add(true);
                    }
                    else
                    {
                        statusLst.Add(false);
                    }
                    btnClose.Click();
                   
                }
                catch(StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                    i--;
                }
                catch(TargetInvocationException)
                {
                    driver.Navigate().Refresh();
                    i--;
                }
                
                foreach (var status in statusLst)
                {
                    if (status.Equals(false))
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// Checks Severity filter
        /// </summary>
        /// <param name="severiry"></param>
        /// <returns></returns>
        public bool IsAlertFilteredBySeverity(string severiry)
        {
            bool flag = false;
            List<bool> statusLst = new List<bool>();
            Waits.WaitForElementVisible(driver, tableAlarm);
            List<IWebElement> lstAlertRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
            for (int i = 1; i <= lstAlertRows.Count - 1; i++)
            {
                try
                {
                    List<IWebElement> lstAlarmRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                    lstAlarmRows[i].Click();
                    Waits.Wait(driver, 10000);
                    Waits.WaitForElementVisible(driver, lblSeverityValue);
                    if (lblSeverityValue.Equals(severiry))
                    {
                        statusLst.Add(true);
                    }
                    else
                    {
                        statusLst.Add(false);
                    }
                    btnClose.Click();
                    Waits.Wait(driver, 8000);
                }
                catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                    //WaitTillLoadingIndicatorDisplayed(imgLoadingIndicator);
                }
            }
            foreach (var status in statusLst)
            {
                if (status.Equals(false))
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }


        /// <summary>
        /// Checks Alert Filtered By System Name
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool CheckSystemAlerts(string systemName)
        {
            bool flag = false;
            List<bool> statusLst = new List<bool>();
            Waits.WaitForElementVisible(driver, tableAlarm);
            List<IWebElement> lstAlertRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
            for (int i = 1; i <= lstAlertRows.Count - 1; i++)
            {
                try
                {
                    List<IWebElement> lstAlarmRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                    lstAlarmRows[i].Click();
                    Waits.Wait(driver, 10000);
                    Waits.WaitForElementVisible(driver, lblSeverityValue);
                    if (lblEquipmentAlertDetails.Text.Contains(systemName))
                    {
                        statusLst.Add(true);
                    }
                    else
                    {
                        statusLst.Add(false);
                    }
                    btnClose.Click();
                    Waits.Wait(driver, 8000);
                }
                catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                   // WaitTillLoadingIndicatorDisplayed(imgLoadingIndicator);
                }
            }
            foreach (var status in statusLst)
            {
                if (status.Equals(false))
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// Returns alert number
        /// </summary>
        /// <returns></returns>
        public int GetAlertsNumber()
        {
            Waits.WaitForElementVisible(driver, tableAlarm);
            List<IWebElement> lstAlarmRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
            return (lstAlarmRows.Count - 1);
        }

        /// <summary>
        /// Checks All Alerts Except Advisory Raised
        /// </summary>
        /// <param name="majorAlarmParameter"></param>
        /// <param name="minorAlarmParameter"></param>
        /// <param name="majorWarningParameter"></param>
        /// <param name="minorWarningParameter"></param>
        /// <param name="equipmentName"></param>
        /// <returns></returns>
        public bool IsAllAlertsExceptAdvisoryRaised(string majorAlarmParameter, string minorAlarmParameter, string majorWarningParameter, string minorWarningParameter, string equipmentName)
        {
            bool flag = false;
            List<bool> statusLst = new List<bool>();

            for (int i = 1; i <= 4; i++)
            {
                try
                {
                    Waits.WaitForElementVisible(driver, tableAlarm);
                    List<IWebElement> lstAlarmRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                    lstAlarmRows[i].Click();
                    Waits.Wait(driver, 10000);
                    Waits.WaitForElementVisible(driver, lblSeverityValue);
                    if (lblParameterValue.Text.Equals(majorAlarmParameter) && lblSeverityValue.Text.ToLower().Contains("major alarm"))
                    {
                        statusLst.Add(true);
                    }
                    else if (lblParameterValue.Text.Equals(minorAlarmParameter) && lblSeverityValue.Text.ToLower().Contains("minor alarm"))
                    {
                        statusLst.Add(true);
                    }
                    else if (lblParameterValue.Text.Equals(minorWarningParameter) && lblSeverityValue.Text.ToLower().Contains("minor warning"))
                    {
                        statusLst.Add(true);
                    }
                    else if (lblParameterValue.Text.Equals(majorWarningParameter) && lblSeverityValue.Text.ToLower().Contains("major warning"))
                    {
                        statusLst.Add(true);
                    }
                    else
                    {
                        statusLst.Add(false);
                    }
                    btnClose.Click();
                    Waits.Wait(driver, 8000);
                foreach (var status in statusLst)
                {
                    if (status.Equals(false))
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
            catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                   // WaitTillLoadingIndicatorDisplayed(imgLoadingIndicator);
                    i = i - 1;
                }
            }
            return flag;
        }


        /// <summary>
        /// checks Assigned user filter
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsAlertsDisplayedAssignedtoFilteredUser(string user)
        {
            bool flag = false;
            List<bool> statusLst = new List<bool>();
            List<IWebElement> lstAlert = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
            for (int i = 1; i <= lstAlert.Count - 1; i++)
            {
                try
                {
                    List<IWebElement> lstAlertRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                    lstAlertRows[i].Click();
                    Waits.Wait(driver, 10000);
                    Waits.WaitForElementVisible(driver, lblSeverityValue);
                    if (drpDwnSelectedAssignedUserAlertDetails.Text.Contains(user))
                    {
                        statusLst.Add(true);
                        JavaScriptExecutor.JavaScriptLinkClick(driver, btnClose);
                        //Waits.WaitAndClick(driver, btnClose);
                    }
                    else
                    {
                        statusLst.Add(false);
                    }
                }
                catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                   // WaitTillLoadingIndicatorDisplayed(imgLoadingIndicator);
                }
            }
            foreach (var status in statusLst)
            {
                if (status.Equals(false))
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }

        public void GoToAlertHistoryDetailTab()
        {
            ClickOnAlertHistoryTab();
        }

        /// <summary>
        /// Clicks On Alert Item
        /// </summary>
        /// <param name="row"></param>
        public void ClickOnAlertItem(int row)
        {
            for (int i = 1; i <= 15; i++)
            {
                try
                {
                    List<IWebElement> lstAlertRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                    Waits.WaitAndClick(driver, lstAlertRows[row]);
                    //Waits.WaitAndClick(driver, lstAlertRows[row]);
                    break;
                }
                catch(ArgumentOutOfRangeException)
                {
                    Waits.Wait(driver, 2000);
                }
                catch(StaleElementReferenceException)
                {
                    Waits.Wait(driver, 2000);
                }
            }
        }

        /// <summary>
        /// Clicks on Alert history tab
        /// </summary>
        public void ClickOnAlertHistoryTab()
        {
            JavaScriptExecutor.JavaScriptLinkClick(driver, alertHistoryTab);
            //Waits.WaitAndClick(driver, alertHistoryTab);
        }

        public void ClickOnCloseButton()
        {
            JavaScriptExecutor.JavaScriptLinkClick(driver, btnCloseAlertHistory);
            //Waits.WaitAndClick(driver, btnCloseAlertHistory);
        }

        /// <summary>
        /// Gets Alert History Data
        /// </summary>
        /// <returns></returns>
        public List<string> GetAlertHistoryData()
        {
            List<string> Cellvalue = new List<string>();
            try
            {
                // gets all table rows
                Waits.WaitForElementVisible(driver, tblHistory);
                List<IWebElement> rows = new List<IWebElement>(tblHistory.FindElements(By.TagName("tr")));
                // for every row
                foreach (IWebElement row in rows)
                {
                    List<IWebElement> columns = new List<IWebElement>(tblHistory.FindElements(By.TagName("td")));
                    foreach (var col in columns)
                    {
                        Cellvalue.Add(col.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return Cellvalue;
        }

        /// <summary>
        /// Checks Alert data presence
        /// </summary>
        /// <returns></returns>
        public bool IsAlertHistoryDataPresent()
        {
            IWebElement baseTable = tblHistory;
            // gets all table rows
            ICollection<IWebElement> rows = baseTable.FindElements(By.TagName("tr"));
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
        /// Closes history data
        /// </summary>
        public void CloseAlertHistory()
        {
            ClickOnCloseButton();
        }

        public bool IsErrorPresent()
        {

            if (lnkError.GetAttribute("href").Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsWarningPresent()
        {

            if (lnkWarning.GetAttribute("href").Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsInfo_AdvisoryPresent()
        {

            if (lnkInfo_Advisory.GetAttribute("href").Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetErrorTooltipText()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(lnkError).Build().Perform();
            // Get the Tool Tip Text
            String toolTipTxt = tooltipError.GetAttribute("title");
            System.Text.RegularExpressions.Regex nonnumeric = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string totalError = nonnumeric.Replace(toolTipTxt, String.Empty).Remove(0, 1);


            return Convert.ToInt32(totalError);
        }

        public int GetWarningTooltipText()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(lnkWarning).Build().Perform();
            // Get the Tool Tip Text
            String toolTipTxt = tooltipWarning.GetAttribute("title");

            System.Text.RegularExpressions.Regex nonnumeric = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string totalWarning = nonnumeric.Replace(toolTipTxt, String.Empty).Remove(0, 1);


            return Convert.ToInt32(totalWarning);
        }

        public int GetInfoAdvisoryTooltipText()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(lnkInfo_Advisory).Build().Perform();
            // Get the Tool Tip Text
            string toolTipTxt = tooltipInfoAdvisory.GetAttribute("title");
            System.Text.RegularExpressions.Regex nonnumeric = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string totalInfoAdvisory = nonnumeric.Replace(toolTipTxt, String.Empty).Remove(0, 1);


            return Convert.ToInt32(totalInfoAdvisory);
        }

        public int ActiveErrorDisplayed()
        {
            int totalActiveAlarm = 0;
            if (IsErrorPresent())
            {
                ElementExtensions.ClickOnLink(lnkError);
                IWebElement BaseElement = lstAlarm;

                ICollection<IWebElement> ActiveAlert = BaseElement.FindElements(By.TagName("tr"));

                if (IsElemetPresent(driver, By.XPath("//table[@id='ctl00_ctl00_cphContent_cphContent_gvAlerts']/tbody")))
                {
                    totalActiveAlarm = ActiveAlert.Count() - 1;
                }
                else
                {
                    throw new Exception("No alert are present");
                }
            }

            return totalActiveAlarm;
        }

        public int ActiveWarningDisplayed()
        {
            int totalActiveWarning = 0;
            if (IsWarningPresent())
            {
                ElementExtensions.ClickOnLink(lnkWarning);
                IWebElement BaseElement = lstWarning;

                ICollection<IWebElement> ActiveWarning = BaseElement.FindElements(By.TagName("tr"));

                if (IsElemetPresent(driver, By.XPath("//table[@id='ctl00_ctl00_cphContent_cphContent_gvAlerts']/tbody")))
                {
                    totalActiveWarning = ActiveWarning.Count() - 1;
                }
                else
                {
                    throw new Exception("No warning are present");
                }
            }

            return totalActiveWarning;
        }

        public int ActiveINfoAdvisoryDisplayed()
        {
            int totalActiveInfoAdvisory = 0;
            if (IsInfo_AdvisoryPresent())
            {
                ElementExtensions.ClickOnLink(lnkInfo_Advisory);
                IWebElement BaseElement = lstInfoAdvisory;

                ICollection<IWebElement> ActiveInfoAdvisory = BaseElement.FindElements(By.TagName("tr"));

                if (IsElemetPresent(driver, By.XPath("//table[@id='ctl00_ctl00_cphContent_cphContent_gvAlerts']/tbody")))
                {
                    totalActiveInfoAdvisory = ActiveInfoAdvisory.Count() - 1;
                }
                else
                {
                    throw new Exception("No alert are present");
                }
            }
            return totalActiveInfoAdvisory;
        }


    }
}
