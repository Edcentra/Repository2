using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using FlaUI.UIA3;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;

namespace Edwards.Scada.Test.Framework.Pages
{

    class DeviceExplorerNavigationPage : PageBase
    {

        IWebDriver driver;
        public DeviceExplorerNavigationPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for DeviceExplorerpage
        #region 
        [FindsBy(How = How.XPath, Using = "//div[@class='fabbox additem']")]
        private IWebElement lnkAddFolder { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@id='imgDiagram']")]
        private IWebElement diagramImage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='sevbody']")]
        private IWebElement diagramTabBody { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='txtAddFolderName']")]
        private IWebElement txtFolderName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id ='txtRename']")]
        private IWebElement txtRenameFolderName { get; set; }

        [FindsBy(How = How.Id, Using = "txtNotes")]
        private IWebElement txtNotes { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'btnOKAdd')]//input[@class='imgBtnStd']")]
        private IWebElement btnAdd { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'btnCloseAdd')]//input[@class='imgBtnStd'][contains(@id,'btnCloseAdd')]")]
        private IWebElement btnCancel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modalBody']//span[contains(@id,'lblPopupMessage')]")]
        private IWebElement lblMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='OK']")]
        private IWebElement btnOk;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnOKDelete')]")]
        private IWebElement btnOkDelete;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnOKDelete")]
        private IWebElement btnOkOnDecommissionPopUP;

        [FindsBy(How = How.XPath, Using = "//span[@id='spnDeleteGroupMenuItem']//a[text()='Delete']")]
        private IWebElement popUpDeleteFolderOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='spnRenameGroupMenuItem']//a[text()='Rename']")]
        private IWebElement popUpRenameFolderOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnOKDelete')]")]
        private IWebElement btnConformDelete { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnCloseDelete')]")]
        private IWebElement btnCloseDelete { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divBox']")]
        private IWebElement lblCreatedFolderHeader1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divBox']//a//div[@class='fabbox_foot system']")]
        private IWebElement lblCreatedFolder;

        [FindsBy(How = How.XPath, Using = "//div[@id='divBox']//span//div[@id='divBoxHead']//img")]
        private IWebElement lblIXHFolder;

        [FindsBy(How = How.XPath, Using = "//div[@id='divBox']//span//div[text()='TestFolder']")]
        private IWebElement lblCreatedFolderHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divBox']//span//div[text()='IXH_Device_Folder']")]
        private IWebElement lblCreatedFolderHeaderForGraph { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='divBoxHead'][text()='IXH_Device_Folder']//..//..//div[@class='fabbox_main']")]
        private IWebElement lblCreatedFolderMain { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='divBoxHead'][text()='TestFolder']//..//..//div[@class='fabbox_main']")]
        private IWebElement lblCreatedFolderMain1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='divBoxHead'][text()='VI Testing']//..//..//div[@class='fabbox_main']")]
        private IWebElement lblCreatedFolderMainVITesting { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divAddBox']")]
        private IWebElement lnkAddDevice { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='imgBtnWrapperBigger']//input[contains(@id,'btnGetSystem')]")]
        private IWebElement btnGetEquipment { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='ctl00_ctl00_cphContent_cphContent_ddlSystemTypeFilter']")]
        private IWebElement dropdownlistEquipmentType { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divFoundsystems']//div/table")]
        private IWebElement lstEquipmentListtable { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divBox']//span[@class='popupMenuSpan']//div")]
        private IWebElement equipmentList { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnOKAdd')]")]
        private IWebElement btnAddEquipment { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divBox'][1]//div[@id='divBoxHead']")]
        private IWebElement lblEquipment;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalBody']//span[@id='spnDeleteMessage']")]
        private IWebElement deleteEquipmentMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='popupMenuSystem']//span[@id='spnRemoveSystemMenuItem']//a[1]")]
        private IWebElement popUpRemoveFromFolder { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Top Level']")]
        private IWebElement LnkTopLevelNavigation { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='logo']//a//img")]
        private IWebElement lnkHomePage { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblPopupMessage")]
        private IWebElement lblSuccessMessageAfterCreatingFolder;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'hypRenameGroup')]")]
        private IWebElement linkRenameFolder { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphContent_cphContent_hypDeleteGroup')]")]
        private IWebElement linkDeleteFolder { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@action,'deletesystem')]")]
        private IWebElement linkDeleteEquipment;

        [FindsBy(How = How.XPath, Using = "//input[@id ='btnOKRename']")]
        private IWebElement btnApply;

        [FindsBy(How = How.XPath, Using = "//input[@id ='btnOKEditNotes']")]
        private IWebElement btnApplyEditNotes;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Top Level')]")]
        private IWebElement linktTopLevel;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnCloseDelete')]")]
        private IWebElement btnCancelOnDeleteWindow;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'spnDeleteHeader')]")]
        private IWebElement windowDelete;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'OK')]")]
        private IWebElement btnOK;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl01_lblLinkText")]
        private IWebElement linkHomePage;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Share Folder')]")]
        private IWebElement linkShareFolder;
        
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Edit Notes/Location')]")]
        private IWebElement linkEditNotesLocation;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_lblSharing')]")]
        private IWebElement popUpShareFolder;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_pnlEditNotes')]")]
        private IWebElement popUpEditLocation;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnMoveTo')]")]
        private IWebElement btnMoveTo;

        [FindsBy(How = How.XPath, Using = ".//input[contains(@id,'btnApply')]")]
        private IWebElement btnApplyChange;

        [FindsBy(How = How.XPath, Using = ".//input[contains(@value,'Apply')]")]
        private IWebElement btnApplyShare;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clstSystems_td0")]
        private IWebElement drpdownItemSelectEquipment;

        [FindsBy(How = How.XPath, Using = "//div[@title='Alarms']")]
        private IWebElement iconAlarm;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'fabbox_main system')]")]
        private IWebElement txtAreaEquipment;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_SEV1_updSEV')]")]
        private IWebElement lblSEVPage;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Overview')]")]
        private IWebElement tabOverview;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@id,'spnStatus')])[2]")]
        private IWebElement lblstatus;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlSerial')]")]
        private IWebElement drpDownserialNumber;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Parameters')]")]
        private IWebElement lnkParameters;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Diagram')]")]
        private IWebElement lnkDiagram;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'lnkGauges')]")]
        private IWebElement lnkGuages;

        [FindsBy(How = How.XPath, Using = "//select[@name='ctl00$ctl00$cphContent$cphContent$SEV1$ddlSerial']")]
        private IWebElement drpdwnSerialNumber;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$SEV1$txtSerial')]")]
        private IWebElement txtBoxSerialNumber;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Temperature')]")]
        private IWebElement lblTemperature;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Pressure')]")]
        private IWebElement lblPressure;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Flow')]")]
        private IWebElement lblFlow;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Power')]")]
        private IWebElement lblPower;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Current')]")]
        private IWebElement lblCurrent;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Master Flow')]")]
        private IWebElement lblMasterFlow;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Channel A Temperatures')]")]
        private IWebElement lblChannelTemperatures;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Rotational Speed')]")]
        private IWebElement lblRotationalSpeed;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@class,'sev_status_value')])[1]")]
        private IWebElement txtBoxMBTempParameters;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'MB Temp')]")]
        private IWebElement lblBoxMBTempGuages;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Graph')]")]
        private IWebElement lnkGraph;

        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement btnAddGraph;

        [FindsBy(How = How.XPath, Using = "//tspan[contains(.,':MB Temp (ºC) (54)')]")]
        private IWebElement lblMBTempGraph;

        [FindsBy(How = How.XPath, Using = "//input[@value='Reset Graph']")]
        private IWebElement btnResetGraph;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ctl00_ctl00_cphContent_cphContent_SEV1_ddlParameters')]")]
        private IWebElement drpDwnSelectParameters;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Decommission')]")]
        private IWebElement lnkDecommission;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Map SECS/GEM VIDs')]")]
        private IWebElement lnkMapSecsGemVID;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Commission')]")]
        private IWebElement lnkCommission;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkAddSystem")]
        private IWebElement lnkAddEquipment;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Create/Commission')]")]
        private IWebElement lnkCreateCommission;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlSystemType_Commission")]
        private IWebElement drpDownSelectEquipmentType;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlProtocol_Commission")]
        private IWebElement drpDownSelectProtocol;
   
        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$ctl00$cphContent$cphContent$txtSystemName_Commission'][contains(@id,'Commission')]")]
        private IWebElement txtBoxEquipmentName;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_txtIPAddress_Commission']")]
        private IWebElement txtBoxIPAddress;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_txtSerialNumber_Commission']")]
        private IWebElement txtSerialNumber;

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$ctl00$cphContent$cphContent$txtIPPort_Commission'][contains(@id,'Commission')]")]
        private IWebElement txtBoxIPPortNumber;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_uplSecsGemVidMapping_Commission']")]
        private IWebElement btnMappingFile;

        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement btnAddOnCommissionPopUp;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Uncomissioned')]")]
        private IWebElement lblUncommissioned;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Manage Equipment')]")]
        private IWebElement lnkManageEquipment;

        [FindsBy(How = How.XPath, Using = "//input[@value='Find Equipment']")]
        private IWebElement btnFindEquipment;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'No Equipment Found')]")]
        private IWebElement msgNoEquipmentFound;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Navigate')]")]
        private IWebElement lnkNavigate;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'ctl00_ctl00_cphContent_cphContent_clstSystems_divListControl')]/table/tbody")]
        private IWebElement tblEquipment;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'btnDelete')]")]
        private IWebElement btnDelete;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkMaintenanceOn")]
        private IWebElement lnkSetMaintenanceOn;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkMaintenanceOff")]
        private IWebElement lnkSetMaintenanceOff;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'deletefolder')]")]
        private IWebElement lnkDelete;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_cphContent_cphContent_clItemsShared_divListControl']")]
        private IWebElement listBoxGrantedList;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clItemsShared_divListControl")]
        private IWebElement lstGranted;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'sev_status_value')")]
        private IWebElement lblParameterStatusValue;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divInfoCount')]")]
        private IWebElement lblAdvisoryCount;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_SEV1_divBox")]
        private IWebElement lblBackroundColour;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_SEV1_divWarningCount")]
        private IWebElement lblWarningCount;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_SEV1_divAlarmCount")]
        private IWebElement lblAlarmCount;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphSubMenuBar_lnkActiveAlerts')]")]
        private IWebElement lnkActiveAlerts;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Real-Time Monitoring')]")]
        private IWebElement lnkRealTimeMonitoring;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Device Explorer')]")]
        private IWebElement lnkDeviceExplorer;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Live Alerts List')]")]
        private IWebElement lnkLiveAlertsList;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Diagnostics')]")]
        private IWebElement lnkDiagnostics;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Data Extraction Utility')]")]
        private IWebElement lnkDataExtractionUtility;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Historian')]")]
        private IWebElement lnkHistorian;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'SPC')]")]
        private IWebElement lnkSPC;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Reports')]")]
        private IWebElement lnkReports;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Advanced Data Analytics')]")]
        private IWebElement lnkAdvancedSataAnalytics;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'PTM')]")]
        private IWebElement lnkPDM;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Predictive Maintenance')]")]
        private IWebElement lnkPredictiveMaintenance;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'PTM')]")]
        private IWebElement lnkPTM;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_SEV1_divAdvisoryCount")]
        private IWebElement lnkAdvisoryCount;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'sevbody')]//h2")]
        private IWebElement lblEquipmentOverview;

        [FindsBy(How = How.XPath, Using = "//li[contains(@class,'parameter_status_none')]")]
        private IWebElement lblParametersTemperature;

        [FindsBy(How = How.XPath, Using = "//div[@id='divBox']//span//div[@id='divBoxHead']//img")]
        private IWebElement lblFolderDivison;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_SEV1_lblGraphParameters")]
        private IWebElement lblGraphParameters;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_SEV1_ddlParameters")]
        private IWebElement lnkDropdownParameters;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_SEV1_btnAddSeries')]")]
        private IWebElement btnAddSeries;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'administrator')]")]
        private IWebElement lnkadministrator;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Preferences')]")]
        private IWebElement lnkPreferences;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'User Preferences')]")]
        private IWebElement lnkUserPreferences;

        [FindsBy(How = How.Id, Using = "ctl00_UserOptions_rptOptions_ctl01_ddlValue")]
        private IWebElement lnkFlowUnit;

        [FindsBy(How = How.Id, Using = "ctl00_UserOptions_rptOptions_ctl02_ddlValue")]
        private IWebElement lnkPowerUnit;

        [FindsBy(How = How.Id, Using = "ctl00_UserOptions_rptOptions_ctl03_ddlValue")]
        private IWebElement lnkPressureUnit;

        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'ctl00$UserOptions$rptOptions$ctl05$ddlValue')]")]
        private IWebElement lnkTemperatureUnit;

        [FindsBy(How = How.Name, Using = "ctl00$UserOptions$rptOptions$ctl04$ddlValue")]
        private IWebElement lnkRotationalSpeedUnit;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$UserOptions$btnApply')]")]
        private IWebElement btnUserOptionsApply;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@class,'sev_status_value')])[2]")]
        private IWebElement lblDryPumpControlValue;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@class,'sev_status_value')])[3]")]
        private IWebElement lblBoosterControlValue;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_SEV1_updParameter")]
        private IWebElement tblParameter { get; set; }

        [FindsBy(How = How.ClassName, Using = "sevbody")]
        private IWebElement tabOverviewDiv;

        [FindsBy(How = How.XPath, Using = "(//span[@class='sev_status_label'])[1]")]
        private IWebElement lblInletThermocouple;

        [FindsBy(How = How.XPath, Using = "(//span[@class='sev_status_label'])[40]")]
        private IWebElement lblAbatementGreenMode;

        [FindsBy(How = How.XPath, Using = "(//span[@class='sev_status_label'])[434]")]
        private IWebElement lblEZenithPowerExclPumps;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@class,'value')])[447]")]
        private IWebElement lblHAPS1StatusValue;

        [FindsBy(How = How.XPath, Using = "(//span[@class='sev_status_label'])[447]")]
        private IWebElement lblHAPS1Status;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@class,'sev_status_value')])[1]")]
        private IWebElement lblInletThermocoupleValue;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Abatement Green Mode:')]//following::span[1]")]
        private IWebElement lblAbatementGreenModeValue;

        [FindsBy(How = How.XPath, Using = "(//span[@class='sev_status_value'])[434]")]
        private IWebElement lblEZenithPowerExclPumpsValue;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Active Gauge Pressure:')]")]
        private IWebElement lblActiveGaugePressure;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Active Gauge Pressure:')]//following::span[1]")]
        private IWebElement lblActiveGaugePressureValue;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'MB Temp:')]")]
        private IWebElement lblMBTemp;

        [FindsBy(How = How.XPath, Using = "(//span[@class='sev_status_value'])[1]")]
        private IWebElement lblMBTempValue;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Exhaust Pressure:')]")]
        private IWebElement lblExhaustPressure;

        [FindsBy(How = How.XPath, Using = "(//span[@class='sev_status_value'])[10]")]
        private IWebElement lblExhaustPressureValue;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Dry Pump Power:')]")]
        private IWebElement lblDryPumpPower;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Pump N2 Flow')]")]
        private IWebElement lblPumpN2Flow;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_SEV1_lnkMeasure")]
        private IWebElement lnkMeasure;

        [FindsBy(How = How.XPath, Using = "(//li[@class='parameter_status_none'])[13]")]
        private IWebElement lblDryPumpPowerValue;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Dry Pump Current:')]")]
        private IWebElement lblDryPumpCurrent;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Dry Pump Current:')]//following::span[1]")]
        private IWebElement lblDryPumpCurrentValue;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'MB Inverter Speed:')]")]
        private IWebElement lblMBInverterSpeed;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'MB Inverter Speed:')]//following::span[1]")]
        private IWebElement lblMBInverterSpeedValue;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'TE406 Combustor Temperature')]")]
        private IWebElement lblTE406CombustorTemperature;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'TE406 Combustor Temperature')]//following::span[1]")]
        private IWebElement lblTE406CombustorTemperatureValue;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'PT306 System Pressure')]")]
        private IWebElement lblPT306SystemPressure;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'PT306 System Pressure')]//following::span[1]")]
        private IWebElement lblPT306SystemPressureValue;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Bypass Valve 1:')]")]
        private IWebElement lblBypassValve1;

        [FindsBy(How = How.XPath, Using = "(//span[@class='sev_status_value'])[33]")]
        private IWebElement lblBypassValve1Value;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'EMO:')]")]
        private IWebElement lblEMO;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'EMO')]//following::span[1]")]
        private IWebElement lblEMOValue;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Number of Inlets:')]")]
        private IWebElement lblNumberOfInlets;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Number of Inlets:')]//following::span[1]")]
        private IWebElement lblNumberOfInletsValue;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'FT615 Quench Water Flow')]")]
        private IWebElement lblFT615QuenchWaterFlow;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'GE703 Oxygen Concentration')]")]
        private IWebElement lblGE702OxygenConcentration;

        [FindsBy(How = How.XPath, Using = "(//span[@class='sev_status_value'])[140]")]
        private IWebElement lblFT615QuenchWaterFlowValue;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_SEV1_rptGauges_ctl00_GaugeControl1_lblTitle")]
        private IWebElement lblMBTempGuages;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Inlet Thermocouple 1')]")]
        private IWebElement lblInletThermocouple1;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'PCW In Pressure System')]")]
        private IWebElement lblPCWInPressureSystem;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'FT460 Pump Frame N2 Flow')]")]
        private IWebElement lblFT460PumpFrameN2Flow;

        [FindsBy(How = How.ClassName, Using = "highcharts-root")]
        private IWebElement svgGraph { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='fabbox_head menucursor']")]
        private IWebElement lblFolderHeader;

        [FindsBy(How = How.ClassName, Using = "highcharts-background")]
        private IList<IWebElement> graphChartMeasure;

        [FindsBy(How = How.Id, Using = "divBox")]
        private IWebElement txtAreaEquipmentFolder;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_SEV1_MeasureView1_liSpeedPulse")]
        private IWebElement lblMotorSpeedMeasureTab;

        [FindsBy(How = How.ClassName, Using = "parameter_status_warning")]
        private IWebElement lblMototSpeedMeasureByClassName;

        [FindsBy(How = How.ClassName, Using = "parameter_status_none")]
        private IWebElement lblMotorSpeedMeasureWithoutWarning;

        [FindsBy(How = How.XPath, Using = "//*[@id='rpm_chart_container']/div/svg/g[5]/g[1]/rect")]
        private IWebElement graphMotorSpeed;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'sev_parameterboxes smallbox')]")]
        private IWebElement lnkParameterStatus;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Network Layout')]")]
        private IWebElement lnkNetworkLayout;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'sev_parameterboxes smallbox')]")]
        private IWebElement lnkMultipleParameterStatus;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblCreateFolder")]
        private IWebElement lblCreateFolder;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblAddFolderError")]
        private IWebElement lblNameCannotBeBlank;

        [FindsBy(How = How.ClassName, Using = "sevbody")]
        private IWebElement lnksevpagebox;

        [FindsBy(How = How.XPath, Using = "//div[@class,'sev_parameterboxes smallbox']")]
        private IWebElement lblParameterAlert;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_cphContent_cphContent_SEV1_div1']//div//div[3]//div[1]//div//ul//li")]
        private IList<IWebElement> lnkAlertStatus;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_cphContent_cphContent_SEV1_div1']//div//div[1]//div[3]//div//ul//li")]
        private IList<IWebElement> lnkParameterAlertStatus;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnCloseAdd")]
        private IWebElement btnCancelAddEquipment;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'#1-1 Inlet Pressure:')]")]
        private IWebElement lblInletfirstPressure;

        //testFolderName//ctl00_ctl00_cphContent_cphContent_lnkAdd
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkAdd")]
        private IWebElement clickfolder;

        //chooselinkedsystem
        //ctl00_ctl00_cphContent_cphContent_btnLinkSystem
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnLinkSystem")]
        private IWebElement btnChooseLinkedSystemMQTT;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Invalid IP Address')]")]
        private IWebElement errormsgInvalidIPAddress;

        #endregion

        //properties

        #region

        public IWebElement BtnCancelAddEquipment
        {
            get
            {
                return btnCancelAddEquipment;
            }
            set
            {
                btnCancelAddEquipment = value;
            }
        }

        public IWebElement BtnChooseLinkedSystemMQTT
        {
            get { return btnChooseLinkedSystemMQTT; }
            set { btnChooseLinkedSystemMQTT = value; }
        }

        public IWebElement ClickFolder
        {
            get { return clickfolder; }
            set { clickfolder = value; }
        }
      

        public IWebElement LblInletfirstPressure
        {
            get { return lblInletfirstPressure; }
            set { lblInletfirstPressure = value; }
        }
        public IWebElement LinkDeleteEquipment
        {
            get
            {
                return linkDeleteEquipment;
            }
            set
            {
                linkDeleteEquipment = value;
            }

        }

        public IWebElement LblMotorSpeedMeasureWithoutWarning
        {
            get
            {
                return lblMotorSpeedMeasureWithoutWarning;
            }
            set
            {
                lblMotorSpeedMeasureWithoutWarning = value;
            }
        }

        public IWebElement LblMototSpeedMeasureByClassName
        {
            get
            {
                return lblMototSpeedMeasureByClassName;
            }
            set
            {
                lblMototSpeedMeasureByClassName = value;
            }
        }

        public IWebElement GraphMotorSpeed
        {
            get
            {
                return graphMotorSpeed;
            }
        }

        public IWebElement Lnksevpagebox
        {
            get { return lnksevpagebox; }
            set { lnksevpagebox = value; }
        }

        public IWebElement LblMotorSpeedMeasureTab
        {
            get
            {
                return lblMotorSpeedMeasureTab;
            }
            set
            {
                lblMotorSpeedMeasureTab = value;
            }
        }

        public IList<IWebElement> GraphChartMeasure
        {
            get
            {
                return graphChartMeasure;
            }
            set
            {
                graphChartMeasure = value;
            }
        }

        public IWebElement LblFolderHeader
        {
            get
            {
                return lblFolderHeader;
            }
            set
            {
                lblFolderHeader = value;
            }
        }

        public IWebElement LnkMeasure
        {
            get
            {
                return lnkMeasure;
            }
            set
            {
                lnkMeasure = value;
            }
        }

        public IWebElement LblPT306SystemPressureValue
        {
            get
            {
                return lblPT306SystemPressureValue;
            }
            set
            {
                lblPT306SystemPressureValue = value;
            }
        }

        public IWebElement LblFT460PumpFrameN2Flow
        {
            get
            {
                return lblFT460PumpFrameN2Flow;
            }
            set
            {
                lblFT460PumpFrameN2Flow = value;
            }
        }

        public IWebElement LblPCWInPressureSystem
        {
            get
            {
                return lblPCWInPressureSystem;
            }
            set
            {
                lblPCWInPressureSystem = value;
            }
        }

        public IWebElement TxtBoxEquipmentName
        {
            get
            {
                return txtBoxEquipmentName;
            }
            set
            {
                txtBoxEquipmentName = value;
            }
        }

        public IWebElement LblInletThermocouple1
        {
            get
            {
                return lblInletThermocouple1;
            }
            set
            {
                lblInletThermocouple1 = value;
            }
        }

        public IWebElement LblMBTempGuages
        {
            get
            {
                return lblMBTempGuages;
            }
            set
            {
                lblMBTempGuages = value;
            }
        }

        public IWebElement LblFT615QuenchWaterFlow
        {
            get
            {
                return lblFT615QuenchWaterFlow;
            }
            set
            {
                lblFT615QuenchWaterFlow = value;
            }
        }

        public IWebElement LblFT615QuenchWaterFlowValue
        {
            get
            {
                return lblFT615QuenchWaterFlowValue;
            }
            set
            {
                lblFT615QuenchWaterFlowValue = value;
            }
        }


        public IWebElement LblBypassValve1Value
        {
            get
            {
                return lblBypassValve1Value;
            }
            set
            {
                lblBypassValve1Value = value;
            }
        }

        public IWebElement LblBypassValve1
        {
            get
            {
                return lblBypassValve1;
            }
            set
            {
                lblBypassValve1 = value;
            }
        }

        public IWebElement LblNumberOfInlets
        {
            get
            {
                return lblNumberOfInlets;
            }
            set
            {
                lblNumberOfInlets = value;
            }
        }

        public IWebElement LblNumberOfInletsValue
        {
            get
            {
                return lblNumberOfInletsValue;
            }
            set
            {
                lblNumberOfInletsValue = value;
            }
        }

        public IWebElement LblEMOValue
        {
            get
            {
                return lblEMOValue;
            }
            set
            {
                lblEMOValue = value;
            }
        }

        public IWebElement LblEMO
        {
            get
            {
                return lblEMO;
            }
            set
            {
                lblEMO = value;
            }
        }

        public IWebElement LblPT306SystemPressure
        {
            get
            {
                return lblPT306SystemPressure;
            }
            set
            {
                lblPT306SystemPressure = value;
            }
        }

        public IWebElement LblTE406CombustorTemperature
        {
            get
            {
                return lblTE406CombustorTemperature;
            }
            set
            {
                lblTE406CombustorTemperature = value;
            }
        }

        public IWebElement LblTE406CombustorTemperatureValue
        {
            get
            {
                return lblTE406CombustorTemperatureValue;
            }
            set
            {
                lblTE406CombustorTemperatureValue = value;
            }
        }

        public IWebElement LblMBInverterSpeed
        {
            get
            {
                return lblMBInverterSpeed;
            }
            set
            {
                lblMBInverterSpeed = value;
            }
        }

        public IWebElement LblMBInverterSpeedValue
        {
            get
            {
                return lblMBInverterSpeedValue;
            }
            set
            {
                lblMBInverterSpeedValue = value;
            }
        }

        public IWebElement LblDryPumpCurrent
        {
            get
            {
                return lblDryPumpCurrent;
            }
            set
            {
                lblDryPumpCurrent = value;
            }
        }

        public IWebElement LblDryPumpCurrentValue
        {
            get
            {
                return lblDryPumpCurrentValue;
            }
            set
            {
                lblDryPumpCurrentValue = value;
            }
        }

        public IWebElement LblDryPumpPower
        {
            get
            {
                return lblDryPumpPower;
            }
            set
            {
                lblDryPumpPower = value;
            }
        }

        public IWebElement LblDryPumpPowerValue
        {
            get
            {
                return lblDryPumpPowerValue;
            }
            set
            {
                lblDryPumpPowerValue = value;
            }
        }

        public IWebElement LblExhaustPressure
        {
            get
            {
                return lblExhaustPressure;
            }
            set
            {
                lblExhaustPressure = value;
            }
        }

        public IWebElement DiagramImage
        {

            get
            {
                return diagramImage;
            }
            set
            {
                diagramImage = value;
            }
        }

        public IWebElement DiagramTabBody
        {

            get
            {
                return diagramTabBody;
            }
            set
            {
                diagramTabBody = value;
            }
        }

        public IWebElement LblExhaustPressureValue
        {
            get
            {
                return lblExhaustPressureValue;
            }
            set
            {
                lblExhaustPressureValue = value;
            }
        }
        public IWebElement LblMBTemp
        {
            get
            {
                return lblMBTemp;
            }
            set
            {
                lblMBTemp = value;
            }
        }

        public IWebElement LblMBTempValue
        {
            get
            {
                return lblMBTempValue;
            }
            set
            {
                lblMBTempValue = value;
            }
        }

        public IWebElement LblHAPS1StatusValue
        {
            get
            {
                return lblHAPS1StatusValue;
            }
            set
            {
                lblHAPS1StatusValue = value;
            }
        }

        public IWebElement LblActiveGaugePressureValue
        {
            get
            {
                return lblActiveGaugePressureValue;
            }
            set
            {
                lblActiveGaugePressureValue = value;
            }
        }


        public IWebElement LblActiveGaugePressure
        {
            get
            {
                return lblActiveGaugePressure;
            }
            set
            {
                lblActiveGaugePressure = value;
            }
        }

        public IWebElement LblEZenithPowerExclPumpsValue
        {
            get
            {
                return lblEZenithPowerExclPumpsValue;
            }
            set
            {
                lblEZenithPowerExclPumpsValue = value;
            }
        }

        public IWebElement LblAbatementGreenModeValue
        {
            get
            {
                return lblAbatementGreenModeValue;
            }
            set
            {
                lblAbatementGreenModeValue = value;
            }
        }

        public IWebElement LblInletThermocoupleValue
        {
            get
            {
                return lblInletThermocoupleValue;
            }
            set
            {
                lblInletThermocoupleValue = value;
            }
        }

        public IWebElement LblHAPS1Status
        {
            get
            {
                return lblHAPS1Status;
            }
            set
            {
                lblHAPS1Status = value;
            }
        }

        public IWebElement LblEZenithPowerExclPumps
        {
            get
            {
                return lblEZenithPowerExclPumps;
            }
            set
            {
                lblEZenithPowerExclPumps = value;
            }
        }

        public IWebElement LblAbatementGreenMode
        {
            get
            {
                return lblAbatementGreenMode;
            }
            set
            {
                lblAbatementGreenMode = value;
            }
        }

        public IWebElement LblInletThermocouple
        {
            get
            {
                return lblInletThermocouple;
            }
            set
            {
                lblInletThermocouple = value;
            }
        }

        public IWebElement TabOverviewDiv
        {
            get
            {
                return tabOverviewDiv;
            }
            set
            {
                tabOverviewDiv = value;
            }
        }
        public IWebElement LblBoosterControlValue
        {
            get
            {
                return lblBoosterControlValue;
            }
            set
            {
                lblBoosterControlValue = value;
            }

        }

        public IWebElement LblDryPumpControlValue
        {
            get
            {
                return lblDryPumpControlValue;
            }
            set
            {
                lblDryPumpControlValue = value;
            }

        }

        public IWebElement LblMessage
        {
            get
            {
                return lblMessage;
            }
            set
            {
                lblMessage = value;
            }
        }

        public IWebElement LblEquipmentOverview
        {
            get
            {
                return lblEquipmentOverview;
            }
            set
            {
                lblEquipmentOverview = value;
            }
        }

        public IWebElement LnkAdvisoryCount
        {
            get
            {
                return lnkAdvisoryCount;
            }
            set
            {
                lnkAdvisoryCount = value;
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

        public IWebElement LnkLiveAlertsList
        {
            get
            {
                return lnkLiveAlertsList;
            }
            set
            {
                lnkLiveAlertsList = value;
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

        public IWebElement LnkHistorian
        {
            get
            {
                return lnkHistorian;
            }
            set
            {
                lnkHistorian = value;
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


        public IWebElement LnkPTM
        {
            get
            {
                return lnkPTM;
            }
            set
            {
                lnkPTM = value;
            }
        }

        public IWebElement LnkPredictiveMaintenance
        {
            get
            {
                return lnkPredictiveMaintenance;
            }
            set
            {
                lnkPredictiveMaintenance = value;
            }
        }

        public IWebElement LnkAdvancedSataAnalytics
        {
            get
            {
                return lnkAdvancedSataAnalytics;
            }
            set
            {
                lnkAdvancedSataAnalytics = value;
            }
        }

        public IWebElement LnkReports
        {
            get
            {
                return lnkReports;
            }
            set
            {
                lnkReports = value;
            }
        }

        public IWebElement LnkSPC
        {
            get
            {
                return lnkSPC;
            }
            set
            {
                lnkSPC = value;
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

        public IWebElement BtnDelete
        {
            get
            {
                return btnDelete;
            }
            set
            {
                btnDelete = value;
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

        public IWebElement MsgNoEquipmentFound
        {
            get
            {
                return msgNoEquipmentFound;
            }
            set
            {
                msgNoEquipmentFound = value;
            }
        }

        public IWebElement TblEquipment
        {
            get
            {
                return tblEquipment;
            }
            set
            {
                tblEquipment = value;
            }
        }

        public IWebElement LnkNavigate
        {
            get
            {
                return lnkNavigate;
            }
            set
            {
                lnkNavigate = value;
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

        public IWebElement BtnAddOnCommissionPopUp
        {
            get
            {
                return btnAddOnCommissionPopUp;
            }
            set
            {
                btnAddOnCommissionPopUp = value;
            }
        }

        public IWebElement LstGranted
        {
            get
            {
                return lstGranted;
            }
            set
            {
                lstGranted = value;
            }
        }

        public IWebElement ListBoxGrantedList
        {
            get
            {
                return listBoxGrantedList;
            }
            set
            {
                listBoxGrantedList = value;
            }
        }

        public IWebElement LinktTopLevel
        {
            get
            {
                return linktTopLevel;
            }
            set
            {
                linktTopLevel = value;
            }
        }
        public IWebElement LblSuccessMessageAfterCreatingFolder
        {
            get
            {
                return lblSuccessMessageAfterCreatingFolder;
            }
            set
            {
                lblSuccessMessageAfterCreatingFolder = value;
            }
        }

        public IWebElement LblCreatedFolder
        {
            get { return lblCreatedFolder; }
            set { lblCreatedFolder = value; }
        }

        public IWebElement LblIXHFolder
        {
            get { return lblIXHFolder; }
            set { lblIXHFolder = value; }
        }

        public IWebElement LblSEVPage
        {
            get { return lblSEVPage; }
            set { lblSEVPage = value; }
        }


        public IWebElement LnkAddFolder
        {
            get
            {
                return lnkAddFolder;
            }
            set
            {
                lnkAddFolder = value;
            }
        }

        public IWebElement BtnCancelOnDeleteWindow
        {
            get
            {
                return btnCancelOnDeleteWindow;
            }
            set
            {
                btnCancelOnDeleteWindow = value;
            }
        }

        public IWebElement WindowDelete
        {
            get
            {
                return windowDelete;
            }
            set
            {
                windowDelete = value;
            }
        }

        public IWebElement BtnOK
        {
            get
            {
                return btnOK;
            }
            set
            {
                btnOK = value;
            }
        }

        public IWebElement LinkHomePage
        {
            get
            {
                return linkHomePage;
            }
            set
            {
                linkHomePage = value;
            }
        }
        public string DropDownProtocolSelectedText
        {
            get
            {
                SelectElement ele = new SelectElement(drpDownSelectProtocol);
                return ele.SelectedOption.Text;
            }
           
        }
        
        public IWebElement LinkShareFolder
        {
            get
            {
                return linkShareFolder;
            }
            set
            {
                linkShareFolder = value;
            }
        }

        public IWebElement LinkEditNotesLocation
        {
            get
            {
                return linkEditNotesLocation;
            }
            set
            {
                linkEditNotesLocation = value;
            }
        }
        public IWebElement PopUpShareFolder
        {
            get
            {
                return popUpShareFolder;
            }
            set
            {
                popUpShareFolder = value;
            }
        }

        public IWebElement PopUpEditLocation
        {
            get
            {
                return popUpEditLocation;
            }
            set
            {
                popUpEditLocation = value;
            }
        }

        public IWebElement TxtAreaEquipment
        {
            get
            {
                return txtAreaEquipment;
            }
            set
            {
                txtAreaEquipment = value;
            }
        }

        public IWebElement TabOverview
        {
            get
            {
                return tabOverview;
            }
            set
            {
                tabOverview = value;
            }
        }

        public IWebElement LblStatus
        {
            get
            {
                return lblstatus;
            }
        }

        public IWebElement IconAlarm
        {
            get
            {
                return iconAlarm;
            }
            set
            {
                iconAlarm = value;
            }
        }

        public IWebElement DrpDownserialNumber
        {
            get
            {
                return drpDownserialNumber;
            }
            set
            {
                drpDownserialNumber = value;
            }
        }

        public IWebElement LinkParameters
        {
            get
            {
                return lnkParameters;
            }
            set
            {
                lnkParameters = value;
            }
        }

        public IWebElement LinkDiagram
        {
            get
            {
                return lnkDiagram;
            }
            set
            {
                lnkDiagram = value;
            }
        }
        public IWebElement LinkGuages
        {
            get
            {
                return lnkGuages;
            }
            set
            {
                lnkGuages = value;
            }
        }

        public IWebElement DrpdwnSerialNumber
        {
            get
            {
                return drpdwnSerialNumber;
            }
            set
            {
                drpdwnSerialNumber = value;
            }
        }

        public IWebElement TxtBoxSerialNumber
        {
            get
            {
                return txtBoxSerialNumber;
            }
            set
            {
                txtBoxSerialNumber = value;
            }
        }

        public IWebElement LblTemperature
        {
            get
            {
                return lblTemperature;
            }
            set
            {
                lblTemperature = value;
            }
        }

        public IWebElement LblPressure
        {
            get
            {
                return lblPressure;
            }
            set
            {
                lblPressure = value;
            }
        }

        public IWebElement LblFlow
        {
            get
            {
                return lblFlow;
            }
            set
            {
                lblFlow = value;
            }
        }

        public IWebElement LblPower
        {
            get
            {
                return lblPower;
            }
        }

        public IWebElement LblCurrent
        {
            get
            {
                return lblCurrent;
            }
            set
            {
                lblCurrent = value;
            }
        }

        public IWebElement LblRotationalSpeed
        {
            get
            {
                return lblRotationalSpeed;
            }
            set
            {
                lblRotationalSpeed = value;
            }
        }

        public IWebElement TxtBoxMBTempParameters
        {
            get
            {
                return txtBoxMBTempParameters;
            }
            set
            {
                txtBoxMBTempParameters = value;
            }
        }

        public IWebElement LblBoxMBTempGuages
        {
            get
            {
                return lblBoxMBTempGuages;
            }
            set
            {
                lblBoxMBTempGuages = value;
            }
        }

        public IWebElement BtnOk
        {
            get
            {
                return btnOk;
            }
            set
            {
                btnOk = value;
            }
        }

        public IWebElement LnkGraph
        {
            get
            {
                return lnkGraph;
            }
            set
            {
                lnkGraph = value;
            }
        }

        public IWebElement BtnAddGraph
        {
            get
            {
                return btnAddGraph;
            }
            set
            {
                btnAddGraph = value;
            }
        }

        public IWebElement LblMBTempGraph
        {
            get
            {
                return lblMBTempGraph;
            }
            set
            {
                lblMBTempGraph = value;
            }
        }

        public IWebElement BtnResetGraph
        {
            get
            {
                return btnResetGraph;
            }
            set
            {
                btnResetGraph = value;
            }
        }

        public IWebElement DrpDwnSelectParameters
        {
            get
            {
                return drpDwnSelectParameters;
            }
            set
            {
                drpDwnSelectParameters = value;
            }
        }

        public IWebElement LnkDecommission
        {
            get
            {
                return lnkDecommission;
            }
            set
            {
                lnkDecommission = value;
            }
        }
        public IWebElement LnkMapSecsGemVID
        {
            get
            {
                return lnkMapSecsGemVID;
            }
            set
            {
                lnkMapSecsGemVID = value;
            }
        }
        
        public IWebElement LnkDropdownParameters
        {
            get
            {
                return lnkDropdownParameters;
            }
            set
            {
                lnkDropdownParameters = value;
            }
        }

        public IWebElement BtnOkOnDecommissionPopUP
        {
            get
            {
                return btnOkOnDecommissionPopUP;
            }
            set
            {
                btnOkOnDecommissionPopUP = value;
            }
        }

        public IWebElement BtnOkDelete
        {
            get
            {
                return btnOkDelete;
            }
            set
            {
                btnOkDelete = value;
            }
        }

        public IWebElement LblUncommissioned
        {
            get
            {
                return lblUncommissioned;
            }
            set
            {
                lblUncommissioned = value;
            }
        }

        public IWebElement LnkCommission
        {
            get
            {
                return lnkCommission;
            }
            set
            {
                lnkCommission = value;
            }
        }

        public IWebElement LnkAddDevice
        {
            get
            {
                return lnkAddDevice;
            }
            set
            {
                lnkAddDevice = value;
            }
        }

        public IWebElement LnkCreateCommission
        {
            get
            {
                return lnkCreateCommission;
            }
            set
            {
                lnkCreateCommission = value;
            }
        }

        public IWebElement LnkSetMaintenanceOn
        {
            get
            {
                return lnkSetMaintenanceOn;
            }
            set
            {
                lnkSetMaintenanceOn = value;
            }
        }

        public IWebElement LnkSetMaintenanceOff
        {
            get
            {
                return lnkSetMaintenanceOff;
            }
            set
            {
                lnkSetMaintenanceOff = value;
            }
        }

        public IWebElement LnkDelete
        {
            get
            {
                return lnkDelete;
            }
            set
            {
                lnkDelete = value;
            }
        }

        public IWebElement LblParameterStatusValue
        {
            get { return lblParameterStatusValue; }
            set { lblParameterStatusValue = value; }
        }

        public IWebElement LblAdvisoryCount
        {
            get { return lblAdvisoryCount; }
            set { lblAdvisoryCount = value; }
        }

        public IWebElement LblBackroundColour
        {
            get { return lblBackroundColour; }
            set { lblBackroundColour = value; }
        }

        public IWebElement LblWarningCount
        {
            get { return lblWarningCount; }
            set { lblWarningCount = value; }
        }

        public IWebElement LblAlarmCount
        {
            get { return lblAlarmCount; }
            set { lblAlarmCount = value; }
        }

        public IWebElement LnkActiveAlerts
        {
            get { return lnkActiveAlerts; }
            set { lnkActiveAlerts = value; }
        }

        public IWebElement LblParametersTemperature
        {
            get { return lblParametersTemperature; }
            set { lblParametersTemperature = value; }
        }

        public IWebElement LblFolderDivison
        {
            get { return lblFolderDivison; }
            set { lblFolderDivison = value; }
        }

        public IWebElement LblGraphParameters
        {
            get { return lblGraphParameters; }
            set { lblGraphParameters = value; }
        }

        public IWebElement BtnAddSeries
        {
            get { return btnAddSeries; }
            set { btnAddSeries = value; }
        }

        public IWebElement Lnkadministrator
        {
            get { return lnkadministrator; }
            set { lnkadministrator = value; }
        }

        public IWebElement LnkPreferences
        {
            get { return lnkPreferences; }
            set { lnkPreferences = value; }
        }

        public IWebElement LnkUserPreferences
        {
            get { return lnkUserPreferences; }
            set { lnkUserPreferences = value; }
        }

        public IWebElement LnkParameterStatus
        {
            get { return lnkParameterStatus; }
            set { lnkParameterStatus = value; }
        }

        public IWebElement LblMasterFlow
        {
            get { return lblMasterFlow; }
            set { lblMasterFlow = value; }
        }

        public IWebElement LblChannelTemperatures
        {
            get { return lblChannelTemperatures; }
            set { lblChannelTemperatures = value; }
        }

        public IWebElement LnkNetworkLayout
        {
            get { return lnkNetworkLayout; }
            set { lnkNetworkLayout = value; }
        }

        public IWebElement LnkManageEquipment
        {
            get { return lnkManageEquipment; }
            set { lnkManageEquipment = value; }
        }

        public IWebElement LnkPDM
        {
            get { return lnkPDM; }
            set { lnkPDM = value; }
        }

        public IWebElement ErrormsgInvalidIPAddress
        {
            get { return errormsgInvalidIPAddress; }
            set { errormsgInvalidIPAddress = value; }
        }

        public IWebElement TxtBoxIPAddress
        {
            get { return txtBoxIPAddress; }
            set { txtBoxIPAddress = value; }
        }

        #endregion

        public string CreateFolder(string FolderName)
        {

            if (IsFolderExist(FolderName))
            {
                DeleteCreatedFolder(FolderName);
            }
            ClickOnPlusToAddFolder();
            EnterFolderName(FolderName);
            ClickOkAfterConformationMessage();
            Thread.Sleep(1000);
            return FolderName;
        }
        public string CreateFolderForGraph(string FolderName)
        {

            if (IsFolderExistForEquipmentData(FolderName))
            {
                DeleteCreatedFolderForGraph(FolderName);
            }
            ClickOnPlusToAddFolder();
            EnterFolderName(FolderName);
            ClickOkAfterConformationMessage();
            Thread.Sleep(1000);
            return FolderName;
        }


        public void DeleteCreatedFolder(string FolderName)
        {

            if (IsFolderExist(FolderName))
            {

                NavigateToTopLevel();
                Thread.Sleep(1000);
                ClickOnCreatedFolderNameHeader(FolderName);
                Thread.Sleep(1000);
                ClickOnDeleteFolderOption();
                Thread.Sleep(1000);
                ClickOnConformDelete();
                Thread.Sleep(1000);
                ClickOkAfterConformationMessage();
            }
        }

        /// <summary>
        /// Delete created folder for graph
        /// </summary>
        /// <param name="FolderName"></param>
        public void DeleteCreatedFolderForGraph(string FolderName)
        {

            if (IsFolderExistForEquipmentData(FolderName))
            {

                NavigateToTopLevel();
                Thread.Sleep(1000);
                ClickOnCreatedFolderNameHeaderForGraph(FolderName);
                Thread.Sleep(1000);
                ClickOnDeleteFolderOption();
                Thread.Sleep(1000);
                ClickOnConformDelete();
                Thread.Sleep(1000);
                ClickOkAfterConformationMessage();
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        ///  Enter Notes and click Apply button
        /// </summary>
        /// <param name="noteText"></param>
        public void EnterNotesAndClickApply(string noteText)
        {
            Waits.WaitForElementVisible(driver, txtNotes);
            txtNotes.SendKeys(noteText);
            btnApplyEditNotes.Click();
        }

        /// <summary>
        /// Selects user to share folder
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userName"></param>
        public void selectUserToshareFolder(string firstName, string lastName, string userName)
        {
            //Waits.Wait(driver, 2000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//td[contains(@title,'" + lastName + ", " + firstName + " (" + userName + ")')]"))).Click();
            //IWebElement user = driver.FindElement(By.XPath("//td[contains(@title,'" + lastName + ", " + firstName + " (" + userName + ")')]"));
            //user.Click();
            Waits.Wait(driver, 2000);
            btnMoveTo.Click();
            for (int i = 0; i <= 20; i++)
            {
                bool flag = isUserAddedInGrantedList(firstName, lastName, userName);
                if (flag == false)
                {
                    Waits.Wait(driver, 1000);
                }
                else if (flag == true)
                {
                    break;
                }
            }
            btnApplyShare.Click();
            Waits.Wait(driver, 2000);
        }

        /// <summary>
        /// Checks if user added in Granted list
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool isUserAddedInGrantedList(string firstName, string lastName, string userName)
        {
            bool flag = false;
            try
            {
                string user = lastName + ", " + firstName + " (" + userName + ")";
                List<IWebElement> lstrows = new List<IWebElement>(lstGranted.FindElements(By.XPath("table//tbody//tr")));
                if (lstrows.Count > 0)
                {
                    foreach (var row in lstrows)
                    {
                        string title = row.FindElement(By.XPath("td[2]")).GetAttribute("title");
                        if (user.ToLower().Equals(title.ToLower()))
                        {
                            flag = true;
                           
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught" + ex.Message);
            }
            return flag;
        }

        /// <summary>
        /// Selects Group to share folder
        /// </summary>
        /// <param name="grpName"></param>
        public void selectGroupToshareFolder(string grpName)
        {
            Waits.Wait(driver, 1000);
            JavaScriptExecutor.JavaScriptClick(driver, driver.FindElement(By.XPath("//td[contains(@title,'" + grpName + "')]")));
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, btnMoveTo);
            for (int i = 0; i <= 20; i++)
            {
                bool flag = isUserAddedInGrantedList(grpName);
                if (flag == false)
                {
                    Waits.Wait(driver, 1000);
                }
                else if (flag == true)
                {
                    break;
                }
            }
            Waits.WaitAndClick(driver, btnApplyShare);
        }


        /// <summary>
        /// Checks if group added in Granted list
        /// </summary>
        /// <param name="grpName"></param>
        /// <returns></returns>
        public bool isUserAddedInGrantedList(string grpName)
        {
            bool flag = false;
            try
            {
                string title = lstGranted.FindElement(By.XPath("table//tbody//tr//td[2]")).GetAttribute("title");
                if (grpName.ToLower().Equals(title.ToLower()))
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught" + ex.Message);
            }
            return flag;
        }

        /// <summary>
        /// Add equipment to system
        /// </summary>
        public void AddEquipmentToSystem(string equipmentType = "All", string equipmentName = "NEW0001PM1")
        {
            ClickOnAddDevice();
            Waits.WaitAndClick(driver, lnkAddEquipment);
            SelectSystemEquipmentType(equipmentType);
            ClickOnGetEquipment();
            Waits.Wait(driver, 2000);
            for (int i = 0; i <= 30; i++)
            {
                if (ElementExtensions.isDisplayed(driver, msgNoEquipmentFound))
                {
                    Waits.Wait(driver, 2000);
                    ClickOnGetEquipment();
                    continue;
                }
                else
                {
                    break;
                }
            }
            //Waits.Wait(driver, 2000);
            SelectEquipment(equipmentName);
            Waits.WaitAndClick(driver, btnAddEquipment);
        }

        /// <summary>
        /// Add all equipments to system
        /// </summary>
        public void AddAllEquipmentsToSystem(string equipmentType = "All")
        {
            ClickOnAddDevice();
            Waits.WaitAndClick(driver, lnkAddEquipment);
            SelectSystemEquipmentType(equipmentType);
            ClickOnGetEquipment();
            Waits.Wait(driver, 7000);
            for (int i = 0; i <= 30; i++)
            {
                if (ElementExtensions.isDisplayed(driver, msgNoEquipmentFound))
                {
                    ClickOnGetEquipment();
                    Waits.Wait(driver, 2000);
                    continue;
                }
                else
                {
                    break;
                }
            }
            Actions ac = new Actions(driver);
            IWebElement ele = driver.FindElement(By.XPath("//div[contains(@id, 'ctl00_ctl00_cphContent_cphContent_clstSystems_divListControl')]//tbody"));
            List<IWebElement> lstEquipment = new List<IWebElement>(ele.FindElements(By.TagName("tr")));
            ac.Click(lstEquipment[0]).KeyDown(Keys.Shift).Click(lstEquipment.Last()).KeyUp(Keys.Control).Build().Perform();
            //lstEquipment[0].Click();
            //Waits.Wait(driver, 2000);
            //ac.SendKeys(Keys.Shift).Perform();
            //JavaScriptExecutor.JavaScriptScrollToElement(driver, lstEquipment.Last());
            //Waits.Wait(driver, 2000);
            //lstEquipment.Last().Click();
            Waits.Wait(driver, 2000);
            Waits.WaitAndClick(driver, btnAddEquipment);
            Waits.Wait(driver, 2000);
        }


        /// <summary>
        /// Selects system to equipment type
        /// </summary>
        public void SelectSystemEquipmentType(string text = "All")
        {
            Waits.Wait(driver, 5000);
            SelectElement element = new SelectElement(dropdownlistEquipmentType);
            element.SelectByText(text);
        }

        /// <summary>
        /// Remove equipment from system
        /// </summary>
        public void RemoveEquipmentFromSystemWithConformDelete()
        {
            ClickOnEquipmentHeader();
            ClickOnPopupRemoveFromFolder();
            ClickOnConformDelete();
        }

        /// <summary>
        /// Remove equipment from system 
        /// </summary>
        /// <returns></returns>
        public string RemoveEquipmentFromSystemWithCancelDelete()
        {
            ClickOnEquipmentHeader();
            ClickOnPopupRemoveFromFolder();
            return GetDeleteEquipmentMessage();
        }

        /// <summary>
        /// Select Folder Main
        /// </summary>
        /// <param name="FolderName"></param>
        public void SelectFolderMain(String FolderName)
        {
            try
            {
                if (FolderName == "IXH_Device_Folder")
                {

                    lblCreatedFolderMain.Click();
                }
                else if (FolderName == "TestFolder")
                {
                    lblCreatedFolderMain1.Click();
                }
                else if (FolderName == "VI Testing")
                {
                    lblCreatedFolderMainVITesting.Click();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Is Folder exist
        /// </summary>
        /// <param name="FolderName"></param>
        /// <returns></returns>
        public bool IsFolderExist(String FolderName)
        {
            if (IsElemetPresent(driver, By.XPath("//div[@id='divBox']//span//div[text()='TestFolder']")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Is Folder Exisr For Equipment Data
        /// </summary>
        /// <param name="FolderName"></param>
        /// <returns></returns>
        public bool IsFolderExistForEquipmentData(String FolderName)
        {
            if (IsElemetPresent(driver, By.XPath("//div[@id='divBox']//span//div[text()='IXH_Device_Folder']")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Click on created Folder Header Name Header
        /// </summary>
        /// <param name="FolderName"></param>
        public void ClickOnCreatedFolderNameHeader(string FolderName)
        {
            Waits.WaitAndClick(driver, lblCreatedFolderHeader);
        }

        /// <summary>
        /// Click on created Folder Name Header for graph
        /// </summary>
        /// <param name="FolderName"></param>
        public void ClickOnCreatedFolderNameHeaderForGraph(string FolderName)
        {
            Waits.WaitAndClick(driver, lblCreatedFolderHeaderForGraph);
        }

        /// <summary>
        /// Select Equipment
        /// </summary>
        /// <param name="equipmentTitle"></param>
        public void SelectEquipment(string equipmentTitle = "NEW0001PM1")
        {
            Waits.Wait(driver, 2000);
            driver.FindElement(By.XPath("//td[contains(@title,'" + equipmentTitle + "')]")).Click();

        }

        /// <summary>
        /// Read all added equipments
        /// </summary>
        /// <returns></returns>
        public string ReadAllAddedEquipment()
        {
            var elemTable = equipmentList;
            var rows = elemTable.FindElements(By.XPath("//img"));
            List<String> NewList = new List<String>();
            foreach (var item in rows)
            {
                NewList.Add(item.Text);
            }
            return NewList.ToString();
        }

        /// <summary>
        /// Click on Plus to add folder
        /// </summary>
        public void ClickOnPlusToAddFolder()
        {
            JavaScriptExecutor.JavaScriptLinkClick(driver, lnkAddFolder);
            //Waits.WaitAndClick(driver, lnkAddFolder);
        }

        /// <summary>
        /// Enter folder name
        /// </summary>
        /// <param name="FolderName"></param>
        public void EnterFolderName(string FolderName)
        {
            Thread.Sleep(2000);
            Waits.WaitForElementVisible(driver, txtFolderName);
            JavaScriptExecutor.JavaScriptLinkClick(driver, txtFolderName);
            //JavaScriptExecutor.JavaScriptScrollToElement(driver, txtFolderName);
            txtFolderName.SendKeys(FolderName);
            txtFolderName.SendKeys(Keys.Tab);
            // Waits.Wait(driver, 2000);
            JavaScriptExecutor.JavaScriptLinkClick(driver, btnAdd);
            //Waits.WaitAndClick(driver, btnAdd);
           // Waits.Wait(driver, 2000);

            if (ElementExtensions.isDisplayed(driver, lblNameCannotBeBlank))
            {
                JavaScriptExecutor.JavaScriptLinkClick(driver, txtFolderName);
                txtFolderName.SendKeys(FolderName);
                txtFolderName.SendKeys(Keys.Tab);
                JavaScriptExecutor.JavaScriptLinkClick(driver, btnAdd);
               // Waits.WaitAndClick(driver, btnAdd);
              
            }
        }

        ///// <summary>
        ///// Click on Add to create folder
        ///// </summary>
        //public void ClickOnAddToCreateFolder(string FolderName)
        //{


        //}

        /// <summary>
        /// Get confirmation message
        /// </summary>
        /// <returns></returns>
        public string GetConformationMessage()
        {
            return lblMessage.Text;
        }

        /// <summary>
        /// Click on after confirmation message
        /// </summary>
        public void ClickOkAfterConformationMessage()
        {
            JavaScriptExecutor.JavaScriptLinkClick(driver, BtnOK);
            //Waits.WaitAndClick(driver, BtnOK);
        }

        /// <summary>
        /// Click on Delete folder option
        /// </summary>
        public void ClickOnDeleteFolderOption()
        {
            Waits.WaitAndClick(driver, popUpDeleteFolderOption);
        }

        /// <summary>
        /// Click on  confirm Delete
        /// </summary>
        public void ClickOnConformDelete()
        {
            JavaScriptExecutor.JavaScriptLinkClick(driver, btnConformDelete);
            //Waits.WaitAndClick(driver, btnConformDelete);
        }

        /// <summary>
        /// Click on Add device
        /// </summary>
        public void ClickOnAddDevice()
        {
            JavaScriptExecutor.JavaScriptLinkClick(driver, lnkAddDevice);
            //Waits.WaitAndClick(driver, lnkAddDevice);
        }

        /// <summary>
        /// Click on Get Equipment
        /// </summary>
        public void ClickOnGetEquipment()
        {
            JavaScriptExecutor.JavaScriptLinkClick(driver, btnGetEquipment);
            //Waits.WaitAndClick(driver, btnGetEquipment);
        }

        /// <summary>
        /// Click on Equipment Header
        /// </summary>
        public void ClickOnEquipmentHeader()
        {
            JavaScriptExecutor.JavaScriptLinkClick(driver, lblEquipment);
            //Waits.WaitAndClick(driver, lblEquipment);
        }

        /// <summary>
        /// Get Equipment title
        /// </summary>
        /// <returns></returns>
        public string GetEquipmentTitle()
        {
            return lblEquipment.Text;
        }

        /// <summary>
        /// Get Delete Equipment message
        /// </summary>
        /// <returns></returns>
        public string GetDeleteEquipmentMessage()
        {
            return deleteEquipmentMessage.Text;
        }

        /// <summary>
        /// Click on pop up Remove from folder
        /// </summary>
        public void ClickOnPopupRemoveFromFolder()
        {
            Waits.WaitAndClick(driver, popUpRemoveFromFolder);
        }

        /// <summary>
        /// Click on cancel confirmation
        /// </summary>
        public void ClickOnCancelConformation()
        {
            Waits.WaitAndClick(driver, btnCloseDelete);
        }

        /// <summary>
        /// Navigate to Top Level
        /// </summary>
        public void NavigateToTopLevel()
        {
            Waits.WaitAndClick(driver, LnkTopLevelNavigation);
        }

        /// <summary>
        /// Navigate to home page
        /// </summary>
        public void NavigateToHomePage()
        {
            Waits.WaitAndClick(driver, lnkHomePage);
        }

        /// <summary>
        /// Click on Folder header
        /// </summary>
        /// <param name="folderName"></param>
        public void ClickOnFolderHeader(string folderName)
        {
            Waits.Wait(driver, 2000);
            folderName = folderName.Trim('"');
            IWebElement element = driver.FindElement(By.XPath("//div[@id='divBoxHead'][contains(.,'" + folderName + "')]"));
            JavaScriptExecutor.JavaScriptScrollToElement(driver, element);
            Waits.WaitAndClick(driver, element);
        }

        /// <summary>
        /// Click Rename
        /// </summary>
        /// <param name="newFolderName"></param>
        public void ClickRename(string newFolderName)
        {
            Waits.WaitAndClick(driver, linkRenameFolder);
            txtRenameFolderName.SendKeys(newFolderName);
        }

        /// <summary>
        /// Click Find Equipment
        /// </summary>
        /// <param name="folderName"></param>
        public void ClickFindEquipment(string folderName)
        {
            try
            {
                //driver.Navigate().Refresh();
                folderName = folderName.Trim('"');
                Waits.Wait(driver, 6000);
                IWebElement element = driver.FindElement(By.XPath("//div[@id='divBoxHead'][contains(.,'" + folderName + "')]"));
                string id = driver.FindElement(By.XPath("//span[@title = '" + folderName + "']")).GetAttribute("id");
                id = id.Remove(id.Length - 8);
                JavaScriptExecutor.JavaScriptScrollToElement(driver, element);
                string equipmentId = id + "hypNavigate";
                Thread.Sleep(8000);
                Waits.WaitAndClick(driver, driver.FindElement(By.Id(equipmentId)));
            }
            catch (StaleElementReferenceException)
            {
                ClickFindEquipment(folderName);
            }
        }

        /// <summary>
        /// Clicks delete button
        /// </summary>
        public void ClickDelete()
        {
            JavaScriptExecutor.JavaScriptLinkClick(driver, linkDeleteFolder);
        }

        /// <summary>
        /// Is folder hidden
        /// </summary>
        /// <param name="newFolderName"></param>
        /// <returns></returns>
        public bool IsFolderHidden(string newFolderName)
        {
            bool flag;
            String type = driver.FindElement(By.XPath("//input[@value='" + newFolderName + "']")).GetAttribute("type");
            flag = type.Contains("hidden");
            return flag;
        }

        /// <summary>
        /// Is folder present
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public bool IsFolderPresent(string folderName)
        {
            bool flag;
            folderName = folderName.Trim('"');
            driver.Navigate().Refresh();
            IWebElement element = driver.FindElement(By.XPath("//div[@id='divBoxHead'][contains(.,'" + folderName + "')]"));
            JavaScriptExecutor.JavaScriptScrollToElement(driver, element);
            flag = element.Displayed;
            return flag;
        }

        /// <summary>
        /// Clecked Decommission
        /// </summary>
        /// <param name="equipmentName"></param>
        /// <param name="equipmentType"></param>
        /// <param name="iPAdress"></param>
        /// <param name="iPPortNumber"></param>
        public void ClickDecommision(string equipmentName, string equipmentType, string iPAdress, string iPPortNumber)
        {
            try
            {
                lnkDecommission.Click();
            }
            catch (System.Reflection.TargetInvocationException)
            {
                Waits.WaitAndClick(driver, lnkCommission);
                Waits.Wait(driver, 3000);
                lnkAddEquipment.Click();
                lnkCreateCommission.Click();
                Thread.Sleep(1000);
                txtBoxEquipmentName.SendKeys(equipmentName);
                ElementExtensions.SelectByText(drpDownSelectEquipmentType, equipmentType);
                txtBoxIPAddress.SendKeys(iPAdress);
                txtBoxIPPortNumber.Clear();
                txtBoxIPPortNumber.SendKeys(iPPortNumber);
                Waits.WaitAndClick(driver, btnAddOnCommissionPopUp);
                GetConformationMessage().Contains("Equipment Added Successfully");
                Waits.WaitAndClick(driver, btnOk);
                Waits.WaitAndClick(driver, lblEquipment);
                Waits.WaitAndClick(driver, lnkDecommission);
            }
        }

        /// <summary>
        /// Enter commission details
        /// </summary>
        /// <param name="equipmentName"></param>
        /// <param name="equipmentType"></param>
        /// <param name="iPAdress"></param>
        /// <param name="iPPortNumber"></param>
        public void EnterCommissionedDetails(string equipmentName, string equipmentType, string iPAdress, string iPPortNumber, string protocol="WEB")
        {
            Waits.WaitForElementVisible(driver, txtBoxEquipmentName);
            txtBoxEquipmentName.SendKeys("");
            txtBoxEquipmentName.SendKeys(equipmentName);
            Waits.WaitForElementVisible(driver, drpDownSelectEquipmentType);
            ElementExtensions.SelectByText(drpDownSelectEquipmentType, equipmentType);
            Waits.Wait(driver, 1000);
            txtBoxIPAddress.Clear();
            txtBoxIPAddress.SendKeys(iPAdress);
            Waits.WaitForElementVisible(driver, txtBoxIPPortNumber);
            txtBoxIPPortNumber.Clear();
            txtBoxIPPortNumber.SendKeys(iPPortNumber);
            Waits.WaitForElementVisible(driver, btnAddOnCommissionPopUp);            
            Waits.WaitAndClick(driver, btnAddOnCommissionPopUp);
        }

        public void EnterMQTTCommissionDetails(string equipmentName, string equipmentType, string serial)
        {
            Waits.WaitForElementVisible(driver, txtBoxEquipmentName);
            txtBoxEquipmentName.SendKeys("");
            txtBoxEquipmentName.SendKeys(equipmentName);
            Waits.WaitForElementVisible(driver, drpDownSelectEquipmentType);
            ElementExtensions.SelectByText(drpDownSelectEquipmentType, equipmentType);
            Waits.Wait(driver, 5000);
            txtSerialNumber.Clear();
            txtSerialNumber.SendKeys(serial);
            Waits.WaitForElementVisible(driver, btnAddOnCommissionPopUp);
            Waits.WaitAndClick(driver, btnAddOnCommissionPopUp);
        }

        public void EnterMQTTCommissionDetailsLinkedSystem(string equipmentName, string equipmentType, string serial)
        {
            Waits.WaitForElementVisible(driver, txtBoxEquipmentName);
            txtBoxEquipmentName.SendKeys("");
            txtBoxEquipmentName.SendKeys(equipmentName);
            Waits.WaitForElementVisible(driver, drpDownSelectEquipmentType);
            ElementExtensions.SelectByText(drpDownSelectEquipmentType, equipmentType);
            Waits.Wait(driver, 5000);

            //linked system
            BtnChooseLinkedSystemMQTT.Click();

            //Equipment type = turbo pump
            SelectSystemEquipmentType("Turbo Pump");

            bool flag = false;
            try
            {
                JavaScriptExecutor.JavaScriptLinkClick(driver, btnFindEquipment);
                Waits.Wait(driver, 2000);
                // Waits.WaitForElementVisible(driver, msgNoEquipmentFound);
                flag = msgNoEquipmentFound.Displayed;
            }
            catch
            {

            }


            txtSerialNumber.Clear();
            txtSerialNumber.SendKeys(serial);
            Waits.WaitForElementVisible(driver, btnAddOnCommissionPopUp);
            Waits.WaitAndClick(driver, btnAddOnCommissionPopUp);
        }

        /// <summary>
        /// Enter commission details
        /// </summary>
        /// <param name="equipmentName"></param>
        /// <param name="equipmentType"></param>
        /// <param name="iPAdress"></param>
        /// <param name="iPPortNumber"></param>
        public void EnterCommissionedDetailsWithMappingFile(string equipmentName, string equipmentType, string iPAdress, string iPPortNumber, string protocol = "WEB")
        {
            Waits.WaitForElementVisible(driver, txtBoxEquipmentName);
            txtBoxEquipmentName.SendKeys("");
            txtBoxEquipmentName.SendKeys(equipmentName);
            Waits.WaitForElementVisible(driver, drpDownSelectEquipmentType);
            ElementExtensions.SelectByText(drpDownSelectEquipmentType, equipmentType);
            Waits.Wait(driver, 1000);
            txtBoxIPAddress.Clear();
            txtBoxIPAddress.SendKeys(iPAdress);
            Waits.WaitForElementVisible(driver, txtBoxIPPortNumber);
            txtBoxIPPortNumber.Clear();
            txtBoxIPPortNumber.SendKeys(iPPortNumber);
            btnMappingFile.SendKeys(GlobalConstants.MappingFilePath);
          
            Waits.Wait(driver, 3000);
            Waits.WaitForElementVisible(driver, btnAddOnCommissionPopUp);
            Waits.WaitAndClick(driver, btnAddOnCommissionPopUp);
            
        }

        /// <summary>
        /// Delete all equipments
        /// </summary>
        /// <param name="driver"></param>
        public void DeleteAllEquipments(IWebDriver driver)
        {
            bool flag = false;
            Actions ac = new Actions(driver);
            try
            {
                JavaScriptExecutor.JavaScriptLinkClick(driver, lnkManageEquipment);
                JavaScriptExecutor.JavaScriptLinkClick(driver, btnFindEquipment);
                //Waits.WaitAndClick(driver, lnkManageEquipment);
                //Waits.WaitAndClick(driver, btnFindEquipment);
                Waits.Wait(driver, 2000);
               // Waits.WaitForElementVisible(driver, msgNoEquipmentFound);
                flag = msgNoEquipmentFound.Displayed;
               
            }
            catch (NoSuchElementException)
            {
                Waits.Wait(driver, 2000);
                List<IWebElement> lstEquipment = new List<IWebElement>(tblEquipment.FindElements(By.TagName("tr")));
                if (lstEquipment.Count == 1)
                {
                    lstEquipment[0].Click();
                    Waits.Wait(driver, 1000);
                    JavaScriptExecutor.JavaScriptLinkClick(driver, btnDelete);
                    JavaScriptExecutor.JavaScriptLinkClick(driver, btnOkDelete);
                    GetConformationMessage().Contains("Equipment Deleted Successfully");
                    Thread.Sleep(1000);
                    JavaScriptExecutor.JavaScriptLinkClick(driver, btnOk);
                    Thread.Sleep(2000);
                    flag = msgNoEquipmentFound.Displayed;
                    Thread.Sleep(2000);
                }
                else if (lstEquipment.Count > 1)
                {
                    int totalcount = lstEquipment.Count;
                    ac.Click(lstEquipment[0]).KeyDown(Keys.Shift).Click(lstEquipment.Last()).KeyUp(Keys.Control).Build().Perform();
                    JavaScriptExecutor.JavaScriptClick(driver, btnDelete);
                    JavaScriptExecutor.JavaScriptClick(driver, btnOkDelete);
                    GetConformationMessage().Contains("Equipment Deleted Successfully");
                    JavaScriptExecutor.JavaScriptLinkClick(driver, btnOk);
                    Thread.Sleep(2000);
                    flag = msgNoEquipmentFound.Displayed;
                    Thread.Sleep(2000);
                }
            }
            catch (TargetInvocationException)
            {
                Waits.Wait(driver, 3000);
                List<IWebElement> lstEquipment = new List<IWebElement>(tblEquipment.FindElements(By.TagName("tr")));
                int totalcount = lstEquipment.Count;
                ac.Click(lstEquipment[0]).KeyDown(Keys.Shift).Click(lstEquipment.Last()).KeyUp(Keys.Control).Build().Perform();
                Waits.Wait(driver, 1000);
                JavaScriptExecutor.JavaScriptLinkClick(driver, btnDelete);
                JavaScriptExecutor.JavaScriptLinkClick(driver, btnOkDelete);
                GetConformationMessage().Contains("Equipment Deleted Successfully");
                JavaScriptExecutor.JavaScriptLinkClick(driver, btnOk);
                Thread.Sleep(2000);
                flag = msgNoEquipmentFound.Displayed;
                Thread.Sleep(2000);
            }
            catch (StaleElementReferenceException)
            {
                Waits.Wait(driver, 3000);
                List<IWebElement> lstEquipment = new List<IWebElement>(tblEquipment.FindElements(By.TagName("tr")));
                int totalcount = lstEquipment.Count;
                ac.Click(lstEquipment[0]).KeyDown(Keys.Shift).Click(lstEquipment.Last()).KeyUp(Keys.Control).Build().Perform();
                Waits.Wait(driver, 1000);
                JavaScriptExecutor.JavaScriptLinkClick(driver, btnDelete);
                JavaScriptExecutor.JavaScriptLinkClick(driver, btnOkDelete);
                GetConformationMessage().Contains("Equipment Deleted Successfully");
                JavaScriptExecutor.JavaScriptLinkClick(driver, btnOk);
                Thread.Sleep(2000);
                flag = msgNoEquipmentFound.Displayed;
                Thread.Sleep(2000);
            }
            finally
            { 

                if (flag)
                {
                }
                else
                {
                    //Waits.Wait(driver, 3000);
                    //List<IWebElement> lstEquipment = new List<IWebElement>(tblEquipment.FindElements(By.TagName("tr")));
                    //int totalcount = lstEquipment.Count;
                    //ac.Click(lstEquipment[0]).KeyDown(Keys.Shift).Click(lstEquipment.Last()).KeyUp(Keys.Control).Build().Perform();
                    //Waits.Wait(driver, 1000);
                    //JavaScriptExecutor.JavaScriptClick(driver, btnDelete);
                    //JavaScriptExecutor.JavaScriptClick(driver, btnOkDelete);
                    //GetConformationMessage().Contains("Equipment Deleted Successfully");
                    //JavaScriptExecutor.JavaScriptClick(driver, btnOk);
                    //Thread.Sleep(2000);
                    //flag = msgNoEquipmentFound.Displayed;
                    //Thread.Sleep(2000);
                }
            }
        }

        /// <summary>
        /// Click link Equipment Maintenance On
        /// </summary>
        /// <param name="operation"></param>
        public void ClickLinkEquipmentMaintenanceOn(string operation)
        {
            if (operation.ToLower().Contains("on"))
                Waits.WaitAndClick(driver, lnkSetMaintenanceOn);
            else if (operation.ToLower().Contains("off"))
                Waits.WaitAndClick(driver, lnkSetMaintenanceOff);
        }

        /// <summary>
        /// Delete Folder
        /// </summary>
        /// <param name="testFolderName"></param>
        public void DeleteFolder(string testFolderName)
        {
            ClickOnFolderHeader(testFolderName);
            ClickDelete();
            Assert.IsTrue(WindowDelete.Displayed, "Verified Delete window");
            Waits.WaitAndClick(driver, btnOkDelete);
            Waits.Wait(driver, 2000);
        }

        /// <summary>
        /// Delete added folder
        /// </summary>
        public void DeleteAddedFolder(string testFolderName)
        {
            try
            {
                Waits.WaitAndClick(driver, LinktTopLevel);
                Waits.Wait(driver, 2000);
                DeleteFolder(testFolderName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught " + ex.Message);
            }
        }

        /// <summary>
        /// Check and Delete added folder
        /// </summary>
        public void CheckAndDeleteFolder(string testFolderName)
        {
            try
            {
                Waits.WaitAndClick(driver, LinktTopLevel);
                Waits.Wait(driver, 2000);
                ClickOnFolderHeader(testFolderName);
                ClickDelete();
                Waits.WaitAndClick(driver, btnOkDelete);
                Waits.Wait(driver, 2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught " + ex.Message);
            }
        }

        /// <summary>
        /// Check Dropdown list have Parameters
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public bool ISDropdowndownListedParameters(string Parameter)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lnkDropdownParameters);
            List<IWebElement> lstParameters = new List<IWebElement>(lnkDropdownParameters.FindElements(By.TagName("option")));
            if (lstParameters.Count > 0)
            {
                foreach (var param in lstParameters)
                {
                    if (param.Text.Contains(Parameter))
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
        /// Check Dropdown list Parameter Count
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public int GraphParameterDropDown()
        {
            Waits.WaitForElementVisible(driver, lnkDropdownParameters);
            List<IWebElement> lstParameters = new List<IWebElement>(lnkDropdownParameters.FindElements(By.TagName("option")));
            return lstParameters.Count;
        }

        /// <summary>
        /// Add Single parameters from list of parameters
        /// </summary>
        /// <param name="Parameter"></param>
        public void SelectSingleParameterfromListed(string Parameter)
        {
            SelectSingleParameterfromDropdown(Parameter);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, btnAddSeries);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// Select Single parameters from list of parameters
        /// </summary>
        /// <param name="Parameter"></param>
        public void SelectSingleParameterfromDropdown(string Parameter)
        {
            Waits.WaitForElementVisible(driver, lnkDropdownParameters);
            List<IWebElement> lstParameters = new List<IWebElement>(lnkDropdownParameters.FindElements(By.TagName("option")));
            if (lstParameters.Count > 0)
            {
                foreach (var param in lstParameters)
                {
                    if (param.Text.Contains(Parameter))
                    {
                        Waits.Wait(driver, 1000);
                        param.Click();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Check Dropdown listed selected Parameters
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsDropdownListedParameterValues(string value)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, drpdwnSerialNumber);
            List<IWebElement> lstval = new List<IWebElement>(drpdwnSerialNumber.FindElements(By.TagName("option")));
            if (lstval.Count > 0)
            {
                foreach (var param in lstval)
                {
                    if (param.Text.Contains(value))
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
        /// To Select single Parameter from listed
        /// </summary>
        /// <param name="Parameter"></param>
        public void SelectSingleValue(string Parameter)
        {
            Waits.WaitForElementVisible(driver, drpDownserialNumber);
            List<IWebElement> lstval = new List<IWebElement>(drpDownserialNumber.FindElements(By.TagName("option")));
            if (lstval.Count > 0)
            {
                foreach (var param in lstval)
                {
                    if (param.Text.Contains(Parameter))
                    {
                        Waits.Wait(driver, 1000);
                        param.Click();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// to check selected parameters displayed in graph
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public bool ISGraphDisplayedParameterNew(string Parameter)
        {
            bool flag = false;
            for (int i = 1; i <= 30; i++)
            {
               // Waits.Wait(driver, 1000);
                List<IWebElement> lstEle = new List<IWebElement>(driver.FindElements(By.XPath("//div[@id='chart_container']//*[name()='svg']//*[name()='g'][@class='highcharts-legend']//*[name()='text']//*[name()='tspan']")));

                foreach (var ele in lstEle)
                {
                    if (flag)
                    {
                        break;
                    }
                    if (ele.Text.Contains(Parameter))
                    {
                        Waits.Wait(driver, 1000);
                        JavaScriptExecutor.JavaScriptScrollToElement(driver, ele);
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            return flag;
        }

        /// <summary>
        /// click on added parameter legend in Graph tab
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public void ClickOnAddedParameterLegend(string Parameter)
        {
            List<IWebElement> lstEle = new List<IWebElement>(driver.FindElements(By.XPath("//div[@id='chart_container']//*[name()='svg']//*[name()='g'][@class='highcharts-legend']//*[name()='text']//*[name()='tspan']")));

            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(Parameter))
                    {
                        ele.Click();
                    }
                }
            }
        }

        /// <summary>
        /// Chnage the preference of Units
        /// </summary>
        public void UpdateUserPreference()
        {
            Waits.WaitForElementVisible(driver, lnkFlowUnit);
            ElementExtensions.SelectByValue(lnkFlowUnit, "14");
            Waits.WaitForElementVisible(driver, lnkPowerUnit);
            ElementExtensions.SelectByValue(lnkPowerUnit, "20");
            Waits.WaitForElementVisible(driver, lnkPressureUnit);
            ElementExtensions.SelectByValue(lnkPressureUnit, "21");
            Waits.WaitForElementVisible(driver, lnkTemperatureUnit);
            ElementExtensions.SelectByValue(lnkTemperatureUnit, "24");
            //Waits.WaitForElementVisible(driver, lnkRotationalSpeedUnit);
            //ElementExtensions.SelectByValue(lnkRotationalSpeedUnit, "214");
            Waits.WaitAndClick(driver, btnUserOptionsApply);
        }

        /// <summary>
        /// Chnage the preference of Temperature Units
        /// </summary>
        public void UpdateUserPreferenceTemperatureUnit(string temperatureValue)
        {

            Waits.WaitForElementVisible(driver, lnkTemperatureUnit);
            ElementExtensions.SelectByValue(lnkTemperatureUnit, temperatureValue);
            Waits.WaitAndClick(driver, btnUserOptionsApply);
        }

        /// <summary>
        /// Parameter status
        /// </summary>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public string ParameterStatus(string paramter)
        {
            string status = string.Empty;
            Waits.WaitForElementVisible(driver, tblParameter);
            List<IWebElement> lstParameter = new List<IWebElement>(tblParameter.FindElements(By.TagName("li")));
            for (int i = 1; i <= lstParameter.Count; i++)
            {
                try
                {
                    List<IWebElement> lstParam = new List<IWebElement>(tblParameter.FindElements(By.TagName("li")));
                    foreach (var par in lstParam)
                    {
                        List<IWebElement> param = new List<IWebElement>(par.FindElements(By.TagName("span")));

                        if (param.First().Text.Contains(paramter))
                        {
                            status = param.Last().Text;
                        }
                    }
                }
                catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                }

            }
            return status;
        }


        /// <summary>
        /// Gets Needle position
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string GetGuageNeedlePosition(string parameter, string value)
        {
            string needlePosition = string.Empty;
            for (int i = 1; i <= 20; i++)
            {
                Waits.Wait(driver, 3000);
                List<IWebElement> lstRotation = new List<IWebElement>(driver.FindElements(By.ClassName("highcharts-series-group")));

                if (parameter.Equals("MB Temp"))
                {
                    JavaScriptExecutor.JavaScriptScrollToElement(driver, LblTemperature);
                    needlePosition = lstRotation[0].FindElement(By.TagName("path")).GetAttribute("transform");
                }
                else if (parameter.Equals("Pump N2 Flow"))
                {
                    JavaScriptExecutor.JavaScriptScrollToElement(driver, LblFlow);
                    needlePosition = lstRotation[7].FindElement(By.TagName("path")).GetAttribute("transform");
                }
                else if (parameter.Equals("Dry Pump Power"))
                {
                    JavaScriptExecutor.JavaScriptScrollToElement(driver, lblPower);
                    needlePosition = lstRotation[9].FindElement(By.TagName("path")).GetAttribute("transform");
                }
                else if (parameter.Equals("Inlet Thermocouple 1"))
                {
                    JavaScriptExecutor.JavaScriptScrollToElement(driver, LblTemperature);
                    needlePosition = lstRotation[0].FindElement(By.TagName("path")).GetAttribute("transform");
                }
                else if (parameter.Equals("PCW In Pressure System"))
                {
                    JavaScriptExecutor.JavaScriptScrollToElement(driver, LblPressure);
                    needlePosition = lstRotation[8].FindElement(By.TagName("path")).GetAttribute("transform");
                }
                else if (parameter.Equals("FT460 Pump Frame N2 Flow"))
                {
                    JavaScriptExecutor.JavaScriptScrollToElement(driver, lblFlow);
                    needlePosition = lstRotation[12].FindElement(By.TagName("path")).GetAttribute("transform");
                }
                else if (parameter.Equals("TE406 Combustor Temperature"))
                {
                    JavaScriptExecutor.JavaScriptScrollToElement(driver, LblTemperature);
                    needlePosition = lstRotation[0].FindElement(By.TagName("path")).GetAttribute("transform");
                }
                else if (parameter.Equals("PT306 System Pressure"))
                {
                    JavaScriptExecutor.JavaScriptScrollToElement(driver, LblPressure);
                    needlePosition = lstRotation[8].FindElement(By.TagName("path")).GetAttribute("transform");
                }
                else if (parameter.Equals("FT615 Quench Water Flow"))
                {
                    JavaScriptExecutor.JavaScriptScrollToElement(driver, lblFlow);
                    needlePosition = lstRotation[25].FindElement(By.TagName("path")).GetAttribute("transform");
                }
                else if (parameter.Equals("GE703 Oxygen Concentration"))
                {
                    JavaScriptExecutor.JavaScriptScrollToElement(driver, lblGE702OxygenConcentration);
                    needlePosition = lstRotation[41].FindElement(By.TagName("path")).GetAttribute("transform");
                }

                if (needlePosition.Contains(value))
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            return needlePosition;
        }

        /// <summary>
        /// Get Guage value
        /// </summary>
        /// <returns></returns>
        public string GetGuageValue(string parameter, string value)
        {
            string text = string.Empty;
            for (int i = 1; i <= 60; i++)
            {
                Waits.Wait(driver, 1000);
                List<IWebElement> lstValue = new List<IWebElement>(driver.FindElements(By.ClassName("highcharts-text-outline")));

                if (parameter.Equals("MB Temp"))
                {
                    text = lstValue[0].Text;
                }
                else if (parameter.Equals("Pump N2 Flow"))
                {
                    text = lstValue[7].Text;
                }
                else if (parameter.Equals("Dry Pump Power"))
                {
                    text = lstValue[9].Text;
                }
                else if (parameter.Equals("Inlet Thermocouple 1"))
                {
                    Waits.Wait(driver, 3000);
                    text = lstValue[0].Text;
                }
                else if (parameter.Equals("PCW In Pressure System"))
                {
                    text = lstValue[8].Text;
                }
                else if (parameter.Equals("FT460 Pump Frame N2 Flow"))
                {
                    text = lstValue[12].Text;
                }
                else if (parameter.Equals("TE406 Combustor Temperature"))
                {
                    text = lstValue[0].Text;
                }
                else if (parameter.Equals("PT306 System Pressure"))
                {
                    text = lstValue[8].Text;
                }
                else if (parameter.Equals("FT615 Quench Water Flow"))
                {
                    text = lstValue[25].Text;
                }
                else if (parameter.Equals("GE703 Oxygen Concentration"))
                {
                    text = lstValue[41].Text;
                }
                if (text.Contains(value))
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            return text;
        }

        /// <summary>
        /// Get Tool Tip Text
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string GetToolTipText(string parameter)
        {
            string tooltipText = string.Empty;
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    Waits.Wait(driver, 3000);
                    IWebElement svgGraph = driver.FindElement(By.ClassName("highcharts-root"));
                    List<IWebElement> lstSVG = new List<IWebElement>(svgGraph.FindElements(By.TagName("g")));
                    List<IWebElement> lstPath = new List<IWebElement>(lstSVG[6].FindElements(By.TagName("path")));
                    Actions action = new Actions(driver);
                    action.DoubleClick(lstPath.Last()).Build().Perform();
                    IWebElement ele = lstSVG.Last().FindElement(By.TagName("text"));
                    List<IWebElement> eleLst = new List<IWebElement>(ele.FindElements(By.TagName("tspan")));
                    if (eleLst[2].Text.Contains(parameter))
                    {
                        tooltipText = eleLst[3].Text;
                        break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    GetToolTipText(parameter);
                }
                catch (StaleElementReferenceException)
                {
                    GetToolTipText(parameter);
                }
            }
            return tooltipText;
        }

        /// <summary>
        /// Get Tool Tip Text
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string GetToolTipTextWhenAddedMultipleParameters(string parameter)
        {
            string tooltipText = string.Empty;
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    Waits.Wait(driver, 3000);
                    IWebElement svgGraph = driver.FindElement(By.ClassName("highcharts-root"));
                    List<IWebElement> lstSVG = new List<IWebElement>(svgGraph.FindElements(By.TagName("g")));
                    List<IWebElement> lstPath = new List<IWebElement>(lstSVG[10].FindElements(By.TagName("path")));
                    Actions action = new Actions(driver);
                    action.DoubleClick(lstPath.Last()).Build().Perform();
                    IWebElement ele = lstSVG.Last().FindElement(By.TagName("text"));
                    List<IWebElement> eleLst = new List<IWebElement>(ele.FindElements(By.TagName("tspan")));
                    if (eleLst[2].Text.Contains(parameter))
                    {
                        tooltipText = eleLst[3].Text;
                        break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    GetToolTipTextWhenAddedMultipleParameters(parameter);
                }
                catch (StaleElementReferenceException)
                {
                    GetToolTipTextWhenAddedMultipleParameters(parameter);
                }
            }
            return tooltipText;
        }

        /// <summary>
        /// Get Tool Tip Text
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string GetToolTipTextForRangeGraph(string parameter)
        {
            bool flag = false;
            string tooltipText = string.Empty;
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    if (flag)
                        break;
                    Waits.Wait(driver, 3000);
                    IWebElement svgGraph = driver.FindElement(By.ClassName("highcharts-root"));
                    Waits.Wait(driver, 2000);
                    List<IWebElement> lstSVG = new List<IWebElement>(svgGraph.FindElements(By.TagName("g")));
                    Actions action = new Actions(driver);
                    Point point = lstSVG[30].Location;
                    int xcord = point.X;
                    int ycord = point.Y;
                    action.ClickAndHold(lstSVG[30]).Build().Perform();
                    List<IWebElement> lstPath = new List<IWebElement>(lstSVG[30].FindElements(By.TagName("path")));
                    
                    Waits.Wait(driver, 3000);
                    if(lstPath.Count>0)
                    action.DoubleClick(lstPath.Last()).Build().Perform();
                    IWebElement ele = lstSVG.Last().FindElement(By.TagName("text"));
                    List<IWebElement> eleLst = new List<IWebElement>(ele.FindElements(By.TagName("tspan")));
                    if (eleLst[1].Text.Contains(parameter))
                    {
                        tooltipText = eleLst[3].Text;
                        flag = true;
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    GetToolTipTextForRangeGraph(parameter);
                }
                catch (ArgumentOutOfRangeException)
                {
                    GetToolTipTextForRangeGraph(parameter);
                }
                catch (StaleElementReferenceException)
                {
                    GetToolTipTextForRangeGraph(parameter);
                }
            }
            return tooltipText;
        }

        /// <summary>
        /// Checks Graph plotting 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool IsGraphPlotted()
        {
            bool flag = true;
            try
            {
                IWebElement svgGraph = driver.FindElement(By.ClassName("highcharts-root"));
                List<IWebElement> lstSVG = new List<IWebElement>(svgGraph.FindElements(By.TagName("g")));
                string visibility = lstSVG[8].GetAttribute("visibility");
                if (visibility.Equals("hidden"))
                {
                    flag = false;
                }
            }
            catch (NullReferenceException ex)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// Checks Graph plotting For Multiple Parameter
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool IsGraphPlottedForMultipleParameter()
        {
            bool flag = true;
            try
            {
                IWebElement svgGraph = driver.FindElement(By.ClassName("highcharts-root"));
                List<IWebElement> lstSVG = new List<IWebElement>(svgGraph.FindElements(By.TagName("g")));
                string visibility = lstSVG[10].GetAttribute("visibility");
                if (visibility.Equals("hidden"))
                {
                    flag = false;
                }
            }
            catch (NullReferenceException ex)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// Checks Measure tab graph charts
        /// </summary>
        /// <returns></returns>
        public int GraphChartMeasureCount()
        {
            IList<IWebElement> lstChart = graphChartMeasure;
            return lstChart.Count;
        }

        /// <summary>
        /// Clicks Equipment
        /// </summary>
        /// <param name="equipmentName"></param>
        public void ClickEquipment(string equipmentName)
        {
            Waits.WaitForElementVisible(driver, txtAreaEquipmentFolder);
            string id = txtAreaEquipmentFolder.FindElement(By.XPath("//span[contains(@desc, '" + equipmentName + "')]")).GetAttribute("id");
            id = id.Remove(id.Length - 8);
            string equipmentId = id + "hypSEV";
            Waits.Wait(driver, 2000);
            driver.FindElement(By.Id(equipmentId)).Click();
        }

        /// <summary>
        /// Parameter status Verify
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool AlertStatus(string status = "parameter_status_alarm")
        {
            bool flag = false;
            IList<IWebElement> lstAlertRows = lnkAlertStatus;
            for (int i = 1; i <= lstAlertRows.Count - 1; i++)
            {
                try
                {
                    Waits.Wait(driver, 2000);
                    IList<IWebElement> lstParamAlertRows = lnkAlertStatus;
                    lstParamAlertRows[i].Text.Contains(status);
                    flag = true;
                    Waits.Wait(driver, 1000);
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                    i--;
                }
            }
            return flag;
        }

        public bool AlertStatusNew(string parameter, string status = "parameter_status_alarm")
        {
            bool flag = false;
            IList<IWebElement> lstAlertRows = lnkAlertStatus;
            for (int i = 1; i <= lstAlertRows.Count - 1; i++)
            {
                try
                {
                    Waits.Wait(driver, 2000);
                    IList<IWebElement> lstParamAlertRows = lnkAlertStatus;
                    if (lstParamAlertRows[i].Text.Contains(status))
                        Waits.Wait(driver, 2000);
                    lstParamAlertRows[i].Text.Contains(parameter);
                    flag = true;
                    Waits.Wait(driver, 1000);
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                    i--;
                }
            }
            return flag;
        }


        /// <summary>
        /// Verify value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public bool VerifyText(IWebElement element, string value)
        {
            bool flag = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(element, value));

                if (element.Text.Contains(value))
                {
                    flag = true;

                }
                Waits.Wait(driver, 1000);
                return flag;
            }
            catch(Exception ex)
            {
                return flag;
            }
            
        }

        /// <summary>
        /// Verify value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public bool VerifyAttributeValue(IWebElement element, string value)
        {
  
            bool flag = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(element, value));

                if (element.GetAttribute("value").Contains(value))
                {
                    flag = true;
                   
                }
                Waits.Wait(driver, 1000);
                return flag;
            }
            catch (Exception ex)
            {
                return flag;
            }
        }
          

        /// <summary>
        /// Verify CSS value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public bool VerifyBackgroundColor(IWebElement element, string value)
        {
            bool flag = false;

            for (int i = 1; i < 150; i++) //150
            {
                //Waits.Wait(driver, 1000);
                if (element.GetCssValue("background-color").Contains(value))
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
    }
}

