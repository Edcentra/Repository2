using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class HistorianPage : PageBase
    {

        private IWebDriver driver;
        public HistorianPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for Historian page
        #region 
        [FindsBy(How = How.XPath, Using = "//div[@class='treeView']/table//tbody")]
        private IWebElement lstFolder;

        [FindsBy(How = How.XPath, Using = "//div[@id='divParameters']")]
        private IWebElement lstParaMeters;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl01_lblLinkText")]
        private IWebElement lnkHome;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlFilterType")]
        private IWebElement ddlFilterType;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtFilter")]
        private IWebElement txtFilter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkApplyTreeFilter")]
        private IWebElement lnkApply;

        [FindsBy(How = How.Id, Using = "divSerialNumberSearchPopup")]
        private IWebElement divSerialNumberSearch;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnApplySerialNumberSearch")]
        private IWebElement btnSerialNumberApply;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_cphContent_cphContent_gvSerialNumberSearch']/tbody/tr[1]")]
        private IWebElement tblSerialnumberSearchLineItem;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_btnLockParameters']")]
        private IWebElement btnLockParaMeters;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_btnUnlockParameters']")]
        private IWebElement btnUnLockParaMeters;

        [FindsBy(How = How.XPath, Using = "//div[@id='chart_container']//*[name()='svg']//*[name()='g'][@class='highcharts-legend']//*[name()='text']//*[name()='tspan']")]
        private IWebElement lblGraphParaMeter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkEditParameters")]
        private IWebElement lnkEditParaMeters;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_rptAxis_ctl00_txtMin")]
        private IWebElement txtLowerLimit;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_rptAxis_ctl00_txtMax")]
        private IWebElement txtUpperLimit;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnApplyParameters")]
        private IWebElement btnApplyParaMeters;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkClearAll")]
        private IWebElement btnClear;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnAddParameter")]
        private IWebElement btnAddParaMeter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkShowParameterData_lblText")]
        private IWebElement lblParameterData;

        [FindsBy(How = How.XPath, Using = "//a//span[text()='Historian']")]
        private IWebElement lnkHistorian;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Equipment Data')]")]
        private IWebElement lnkHistorianEquipmentData;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtFilterDateFrom")]
        private IWebElement lblFilterDateFrom;

        [FindsBy(How = How.XPath, Using = "//div[contains(@title,'Friday, March 01, 2019')]")]
        private IWebElement lblFilterFromDate;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtFilterDateTo")]
        private IWebElement lblFilterDateTo;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_chkShowParameterData_imgCheckBox')]")]
        private IWebElement equptParametercheckbox;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_chkShowAlerts_imgCheckBox')]")]
        private IWebElement equptAlertcheckbox;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divctl00_ctl00_cphContent_cphContent_btnApplyFilter')]")]
        private IWebElement btnApplyFilter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_UpdatePanelTree")]
        private IWebElement lnkExpandSystem;

        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ctl00_cphContent_cphContent_SystemTreeView1_TreeView1']//table//tbody//tr//td[2]")]
        private IWebElement folderName;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clParameters_divListControl")]
        private IWebElement lnkListedParameters;

        [FindsBy(How = How.Id, Using = "divctl00_ctl00_cphContent_cphContent_btnAddParameter")]
        private IWebElement btnAddParameter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkGraph")]
        private IWebElement lnkGraphTab;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divSettingsMain')]/table")]
        private IWebElement lnkGridParameterList;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divSettingsMain')]/table")]
        private IWebElement lnkGridParameterrows;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkValues")]
        private IWebElement lnkGridTab;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'ctl00_ctl00_cphContent_cphContent_gvValues')]")]
        private IWebElement tableGridValues;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'ctl00_ctl00_cphContent_cphContent_gvValues']//tbody//tr]")]
        private IWebElement tableGridAlertHistory;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtFilterDateFrom')]")]
        private IWebElement txtStartDate;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtFilterDateTo')]")]
        private IWebElement txtEndDate;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlAggregationPeriod')]")]
        private IWebElement ddlAggregation;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblParameters')][contains(.,'NEW0001PM1 Parameters')]")]
        private IWebElement lblParameters;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnGetSystems')]")]
        private IWebElement btnFindEquipment;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlMetric")]
        private IWebElement ddlMetric;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clSystems_divListControl")]
        private IWebElement lstEquipmentType;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnMoveSystemsTo')]")]
        private IWebElement btnMoveSystemsTo;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnMoveAllSystemsTo')]")]
        private IWebElement btnMoveAllSystemsTo;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clSelectedSystems_divListControl")]
        private IWebElement lstAssignedEquipment;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnApply')]")]
        private IWebElement btnApply;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_SystemTreeView1_TreeView1")]
        private IWebElement lnkSingleSystem;

        [FindsBy(How = How.Id, Using = "divctl00_ctl00_cphContent_cphContent_btnLockParameters")]
        private IWebElement lnkUnlockButton;

        [FindsBy(How = How.XPath, Using = "//span[@class='modalHeader prefs'][contains(.,'Assigned Parameters')]")]
        private IWebElement lnkEditParameterBox;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_divEditParameters")]
        private IWebElement lnkEditParameters;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$rptParameters$ctl00$imgDelete')]")]
        private IWebElement lnkParameterRemoveOption;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnLoadGraph')]")]
        private IWebElement btnLoadSavedGrpah;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_lblSaveGraph')]")]
        private IWebElement lblSaveGraph;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_lblClearAll')]")]
        private IWebElement lblClearAll;

        [FindsBy(How = How.XPath, Using = "//span[@class='modalHeader prefs'][contains(.,'Save Graph')]")]
        private IWebElement lnkSaveGraphModalDialog;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnSaveGraphCancel')]")]
        private IWebElement btnSaveGraphCancel;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnSaveGraphOK')]")]
        private IWebElement btnSaveGraphOK;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_lblSaveGraphMessage')]")]
        private IWebElement lblSaveGraphMessage;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_txtGraphName')]")]
        private IWebElement txtGraphName;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblFilterMessage')]")]
        private IWebElement lblFilterMessage;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Load Graph Settings')]")]
        private IWebElement lnkLoadSaveGraphModalDialog;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnLoadGraphOK')]")]
        private IWebElement btnLoadSavedGraphOK;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnLoadGraphCancel')]")]
        private IWebElement btnLoadSavedGraphCancel;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnLoadGraphDelete')]")]
        private IWebElement btnLoadSavedGraphDelete;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ctl00_ctl00_cphContent_cphContent_lstSavedGraphs')]")]
        private IWebElement lstSavedGraphs;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnSaveGraphYes')]")]
        private IWebElement btnSaveGraphYes;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnSaveGraphNo')]")]
        private IWebElement btnSaveGraphNo;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphContent_cphContent_hypDeleteGroup')]")]
        private IWebElement linkDeleteFolder;

        [FindsBy(How = How.XPath, Using = "//div[@class='logo']//a//img")]
        private IWebElement lnkHomePage;

        [FindsBy(How = How.XPath, Using = ".//a//span[text()='Device Explorer']")]
        private IWebElement lnkDeviceManager;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'breadcrumb')]")]
        private IWebElement lnkTopLevel;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnOKDelete')]")]
        private IWebElement btnOKDelete;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnOKMessage')]")]
        private IWebElement btnOKMessage;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblPopupMessage")]
        private IWebElement lblSuccessMessageAfterCreatingFolder;

        [FindsBy(How = How.XPath, Using = "//a[text()='Manage Equipment']")]
        private IWebElement lnkManageEquipment;

        [FindsBy(How = How.XPath, Using = "//div[@class='imgBtnWrapperBigger']//input[contains(@id,'btnGetSystems')]")]
        private IWebElement btnGetSystems;

        [FindsBy(How = How.XPath, Using = "div[contains(@id,'ctl00_ctl00_cphContent_cphContent_clstSystems_divListControl')")]
        private IWebElement lnkDivListControl;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'footermenu']//a[contains(@id,'ctl00_lnkAbout')]")]
        private IWebElement lnkAbout;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divContent')//table//tboby//tr[8]//td[2]//span")]
        private IWebElement lnkActivationCode;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_uplReportLicenceFile")]
        private IWebElement btnUploadFile;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_btnApply']")]
        private IWebElement btnApplyUploadFile;

        [FindsBy(How = How.XPath, Using = "//div[@id='divAddBox']")]
        private IWebElement lnkAddDevice;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Create/Commission')]")]
        private IWebElement lnkCreateCommission;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_txtSystemName_Commission')]")]
        private IWebElement txtBoxEquipmentName;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ctl00_ctl00_cphContent_cphContent_ddlSystemType_Commission')]")]
        private IWebElement drpDownSelectEquipmentType;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_txtIPAddress_Commission']")]
        private IWebElement txtBoxIPAddress;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_txtIPPort_Commission')]")]
        private IWebElement txtBoxIPPortNumber;

        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement btnAddOnCommissionPopUp;

        [FindsBy(How = How.XPath, Using = "//input[@value='OK']")]
        private IWebElement btnOk;

        [FindsBy(How = How.XPath, Using = "//div[@id='chart_container']//*[name()='svg']//*[name()='g'][@class='highcharts-button highcharts-contextbutton highcharts-button-normal']")]
        private IWebElement lnkHandburger;

        [FindsBy(How = How.XPath, Using = "//div[@class='highcharts-contextmenu']")]
        private IWebElement lnkHandburgerNew;

        [FindsBy(How =How.XPath, Using = "//img[contains(@title, 'StDev: 6.13')]")]
        private IWebElement imgCombusterTempForAWeek;

        [FindsBy(How = How.XPath, Using = "//img[contains(@title, 'StDev: 6.15')]")]
        private IWebElement imgCombusterTempForAMonth;

        [FindsBy(How = How.XPath, Using = "//img[contains(@title, 'StDev: 6.17')]")]
        private IWebElement imgCombusterTempForThreeMonths;

        [FindsBy(How = How.XPath, Using = "//img[contains(@title, 'StDev: 6.17')]")]
        private IWebElement imgCombusterTempForAYear;

        [FindsBy(How = How.XPath, Using = "//div[@id='chart_container']")]
        private IWebElement lblLegend;

        [FindsBy(How =How.XPath, Using = "(//img[@src='/EdwardsScada/img/busy/ajax_loader_smallgrey.gif'])[1]")]
        private IWebElement imgLoadingIndicatorOnApplyButton;

        [FindsBy(How = How.XPath, Using = "(//img[@src='/EdwardsScada/img/busy/ajax_loader_smallgrey.gif'])[4]")]
        private IWebElement imgLoadingIndicatorOnAddButton;

        private ReadOnlyCollection<IWebElement> GridParameterHeaderColumns => this.lnkGridParameterList.FindElements(By.TagName("th"));

        //private ReadOnlyCollection<IWebElement> GridParameterDetailRows => this.lnkGridParameterrows.FindElements(By.ClassName("alertRow"));
       
        #endregion

        //Properties
        #region

        public List<string> GetGridParameterHeaderDetails
        {
            get { return GridParameterHeaderColumns.Select(x => x.Text).Where(x => !string.IsNullOrWhiteSpace(x)).ToList(); }
        }

        public List<GridParameterDetails> GridParameterDetails
        {
            get
            {
                var tCollection = new List<GridParameterDetails>();
                //IWebElement test = lnkGridParameterList;                
                ReadOnlyCollection<IWebElement> rowcount = new ReadOnlyCollection<IWebElement>(driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphContent_cphContent_gvValues']/tbody/tr")));
                rowcount.Select(x => x.Text).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                var rowCounts = rowcount.Count();
                for (int i = 1; i < rowCounts; i++)
                {
                    tCollection.Add(this[i]);
                }
                return tCollection;
            }
        }

        public GridParameterDetails this[int i]
        {
            get
            {
                ReadOnlyCollection<IWebElement> rowDetails = new ReadOnlyCollection<IWebElement>(driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphContent_cphContent_gvValues']/tbody/tr")));

                var rowCells = rowDetails[i].FindElements(By.TagName("td"));
                rowCells.Select(x => x.Text).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                return new GridParameterDetails
                {
                    System = rowCells[2].Text,
                    Parameter = rowCells[3].Text,
                    Value = rowCells[4].Text,
                    Unit = rowCells[5].Text,
                    Code = rowCells[6].Text,
                    Message = rowCells[7].Text,
                };
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

        public IWebElement DrpDownFilterType
        {
            get
            {
                return ddlFilterType;
            }
            set
            {
                ddlFilterType = value;
            }
        }

        public IWebElement TxtFilter
        {
            get
            {
                return txtFilter;
            }
            set
            {
                txtFilter = value;
            }
        }

        public IWebElement LnkApply
        {
            get
            {
                return lnkApply;
            }
            set
            {
                lnkApply = value;
            }
        }

        public bool IsDivSerialNumberExists
        {
            get
            {
                try
                {
                    return divSerialNumberSearch.Displayed;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            
        }

        public IWebElement FolderName
        {
            get { return folderName; }
        }

        public IWebElement ImgCombusterTempForAWeek
        {
            get
            {
                return imgCombusterTempForAWeek;
            }
            set
            {
                imgCombusterTempForAWeek = value;
            }
        }

        public IWebElement ImgCombusterTempForAMonth
        {
            get
            {
                return imgCombusterTempForAMonth;
            }
            set
            {
                imgCombusterTempForAMonth = value;
            }
        }

        public IWebElement ImgCombusterTempForThreeMonths
        {
            get
            {
                return imgCombusterTempForThreeMonths;
            }
            set
            {
                imgCombusterTempForThreeMonths = value;
            }
        }

        public IWebElement ImgCombusterTempForAYear
        {
            get
            {
                return imgCombusterTempForAYear;
            }
            set
            {
                imgCombusterTempForAYear = value;
            }
        }

       
        public IWebElement LblParameterData
        {
            get { return lblParameterData; }
            set { lblParameterData = value; }
        }

        public IWebElement LnkHistorian
        {
            get { return lnkHistorian; }
            set { lnkHistorian = value; }
        }

        public IWebElement LnkHistorianEquipmentData
        {
            get { return lnkHistorianEquipmentData; }
            set { lnkHistorianEquipmentData = value; }
        }

        public IWebElement LblFilterFromDate
        {
            get { return lblFilterFromDate; }
            set { lblFilterFromDate = value; }
        }

        public IWebElement LblFilterDateFrom
        {
            get { return lblFilterDateFrom; }
            set { lblFilterDateFrom = value; }
        }

        public IWebElement LblFilterDateTo
        {
            get { return lblFilterDateTo; }
            set { lblFilterDateTo = value; }
        }

        public IWebElement EquptParametercheckbox
        {
            get { return equptParametercheckbox; }
            set { equptParametercheckbox = value; }
        }

        public IWebElement EquptAlertcheckbox
        {
            get { return equptAlertcheckbox; }
            set { equptAlertcheckbox = value; }
        }

        public IWebElement BtnApplyFilter
        {
            get { return btnApplyFilter; }
            set { btnApplyFilter = value; }
        }

        public IWebElement BtnAddParameter
        {
            get { return btnAddParameter; }
            set { btnAddParameter = value; }
        }

        public IWebElement LnkGraphTab
        {
            get { return lnkGraphTab; }
            set { lnkGraphTab = value; }
        }

        public IWebElement LnkGridTab
        {
            get { return lnkGridTab; }
            set { lnkGridTab = value; }
        }

        public IWebElement TableGridValues
        {
            get { return tableGridValues; }
            set { tableGridValues = value; }
        }

        public IWebElement LblParameters
        {
            get { return lblParameters; }
            set { lblParameters = value; }
        }

        public IWebElement BtnLockParaMeters
        {
            get { return btnLockParaMeters; }
            set { btnLockParaMeters = value; }
        }

        public IWebElement BtnUnLockParaMeters
        {
            get { return btnUnLockParaMeters; }
            set { btnUnLockParaMeters = value; }
        }

        public IWebElement LblGraphParaMeter
        {
            get { return lblGraphParaMeter; }
            set { lblGraphParaMeter = value; }
        }

        public IWebElement LnkEditParameterBox
        {
            get { return lnkEditParameterBox; }
            set { lnkEditParameterBox = value; }
        }

        public IWebElement LnkEditParaMeters
        {
            get { return lnkEditParaMeters; }
            set { lnkEditParaMeters = value; }
        }

        public IWebElement LnkParameterRemoveOption
        {
            get { return lnkParameterRemoveOption; }
            set { lnkParameterRemoveOption = value; }
        }

        public IWebElement BtnLoadSavedGrpah
        {
            get { return btnLoadSavedGrpah; }
            set { btnLoadSavedGrpah = value; }
        }

        public IWebElement LblSaveGraph
        {
            get { return lblSaveGraph; }
            set { lblSaveGraph = value; }
        }

        public IWebElement LblClearAll
        {
            get { return lblClearAll; }
            set { lblClearAll = value; }
        }

        public IWebElement LnkSaveGraphModalDialog
        {
            get { return lnkSaveGraphModalDialog; }
            set { lnkSaveGraphModalDialog = value; }
        }

        public IWebElement BtnSaveGraphCancel
        {
            get { return btnSaveGraphCancel; }
            set { btnSaveGraphCancel = value; }
        }

        public IWebElement BtnSaveGraphOK
        {
            get { return btnSaveGraphOK; }
            set { btnSaveGraphOK = value; }
        }

        public IWebElement LblSaveGraphMessage
        {
            get { return lblSaveGraphMessage; }
            set { lblSaveGraphMessage = value; }
        }

        public IWebElement LblFilterMessage
        {
            get { return lblFilterMessage; }
            set { lblFilterMessage = value; }
        }

        public IWebElement LnkLoadSaveGraphModalDialog
        {
            get { return lnkLoadSaveGraphModalDialog; }
            set { lnkLoadSaveGraphModalDialog = value; }
        }

        public IWebElement BtnLoadSavedGraphOK
        {
            get { return btnLoadSavedGraphOK; }
            set { btnLoadSavedGraphOK = value; }
        }

        public IWebElement BtnLoadSavedGraphCancel
        {
            get { return btnLoadSavedGraphCancel; }
            set { btnLoadSavedGraphCancel = value; }
        }

        public IWebElement BtnLoadSavedGraphDelete
        {
            get { return btnLoadSavedGraphDelete; }
            set { btnLoadSavedGraphDelete = value; }
        }

        public IWebElement BtnSaveGraphYes
        {
            get { return btnSaveGraphYes; }
            set { btnSaveGraphYes = value; }
        }

        public IWebElement BtnSaveGraphNo
        {
            get { return btnSaveGraphNo; }
            set { btnSaveGraphNo = value; }
        }

        public IWebElement LblSuccessMessageAfterCreatingFolder
        {
            get { return lblSuccessMessageAfterCreatingFolder; }
            set { lblSuccessMessageAfterCreatingFolder = value; }
        }

        public IWebElement BtnApplyUploadFile
        {
            get { return btnApplyUploadFile; }
            set { btnApplyUploadFile = value; }
        }

        public IWebElement BtnMoveAllSystemsTo
        {
            get { return btnMoveAllSystemsTo; }
            set { btnMoveAllSystemsTo = value; }
        }

        public IWebElement LnkTopLevel
        {
            get { return lnkTopLevel; }
            set { lnkTopLevel = value; }
        }

        public IWebElement LnkHandburger
        {
            get { return lnkHandburger; }
            set { lnkHandburger = value; }
        }

        public IWebElement LnkHandburgerNew
        {
            get { return lnkHandburgerNew; }
            set { lnkHandburgerNew = value; }
        }


        #endregion

        /// <summary>
        /// To Lock the button under parameters tab
        /// </summary>
        public void LockParaMeters()
        {
            Waits.WaitAndClick(driver, btnLockParaMeters);
        }

        /// <summary>
        /// to clear the Graph
        /// </summary>
        public void ClearGraph()
        {
            Waits.WaitAndClick(driver, btnClear);
        }

        /// <summary>
        /// Click on Add Button
        /// </summary>
        public void Add_EquipmentStatus_ParaMeter()
        {
            Waits.WaitAndClick(driver, btnAddParaMeter);
        }

        /// <summary>
        /// To change the LockButton status
        /// </summary>
        public void UnLockParaMeters()
        {
            Waits.WaitAndClick(driver, btnUnLockParaMeters);
        }

        public void ApplySerialNumberFilterForSingleSystem()
        {
            Waits.WaitForElementVisible(driver, tblSerialnumberSearchLineItem);
            tblSerialnumberSearchLineItem.Click();
            Waits.Wait(driver, 2000);
            btnSerialNumberApply.Click();
        }

        /// <summary>
        /// Change the Parameter Lower and Upper Limit 
        /// </summary>
        /// <param name="LowerValue"></param>
        /// <param name="UpperValue"></param>
        public void ModifyParaMeters(string LowerValue, string UpperValue)
        {
            Waits.WaitForElementVisible(driver, txtLowerLimit);
            ElementExtensions.ClearTextValue(txtLowerLimit);
            ElementExtensions.EnterTextValue(txtLowerLimit, LowerValue);
            Waits.WaitForElementVisible(driver, txtUpperLimit);
            ElementExtensions.ClearTextValue(txtUpperLimit);
            ElementExtensions.EnterTextValue(txtUpperLimit, UpperValue);
            Waits.WaitForElementVisible(driver, btnApplyParaMeters);
            Waits.WaitAndClick(driver, btnApplyParaMeters);
        }

        /// <summary>
        /// Enter a name in the GraphName Text Column
        /// </summary>
        /// <param name="GraphName"></param>
        public void EnterGraphName(string GraphName)
        {
            Waits.WaitForElementVisible(driver, txtGraphName);
            ElementExtensions.ClearTextValue(txtGraphName);
            Waits.Wait(driver, 1000);
            ElementExtensions.EnterTextValue(txtGraphName, GraphName);
            Waits.Wait(driver, 1000);
        }

        public bool VerifyTooltipText(string note)
        { bool flag = false;
            var element = driver.FindElement(By.XPath("//div[@id='ctl00_ctl00_cphContent_cphContent_SystemTreeView1_TreeView1']//table//tbody//tr//td[3]//a"));
            if (element.GetAttribute("title").Contains(note))
                flag = true;
            return flag;
        }

        /// <summary>
         /// Expand the System Folder  
         /// </summary>
         /// <param name="folderName"></param>
        public void ExpandSystemsParameter(string folderName)
        {
            //Waits.Wait(driver, 2000);
            Waits.WaitForElementVisible(driver, lnkExpandSystem);
            List<IWebElement> lstEle = new List<IWebElement>(lnkExpandSystem.FindElements(By.TagName("tr")));
            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(folderName))
                    {
                        IWebElement ele1 = ele.FindElement(By.XPath("td//a//img"));
                        if (ele1.GetAttribute("alt").Contains("Expand"))
                        {
                            Waits.WaitAndClick(driver, ele1);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Check Expand status of System Parameter
        /// </summary>
        /// <returns></returns>
        public bool ExpandSystemsParameterCheck(string folderName)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 1000);
                if (flag)
                {
                    break;
                }
                List<IWebElement> lstEle = new List<IWebElement>(lnkExpandSystem.FindElements(By.TagName("tr")));
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(folderName))
                        {
                            IWebElement ele1 = ele.FindElement(By.XPath("td//a//img"));
                            if (ele1.GetAttribute("alt").Contains("Collapse"))
                            {

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
            }
            return flag;
        }

        /// <summary>
        /// Single Equipment Selection
        /// </summary>
        /// <param name="Equipment"></param>
        public void SelectSingleParameterEquipment(string Equipment)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 1000);
                Waits.WaitForElementVisible(driver, lnkSingleSystem);
                List<IWebElement> lstEle = new List<IWebElement>(lnkSingleSystem.FindElements(By.TagName("span")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(Equipment))
                        {
                            Waits.WaitAndClick(driver, ele);
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
        }

        /// <summary>
        /// Check Selected parameter Status
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool IsParameterListPresent(string parameter)
        {
            bool flag = false;
            for (int i = 0; i < 15; i++)
            {
                if (flag)
                {
                    break;
                }
                IWebElement ListedParameters = lnkListedParameters;
                // gets all table rows
                ICollection<IWebElement> rows = ListedParameters.FindElements(By.TagName("td"));
                if (rows.Count() > 0)
                {
                    foreach (var ele in rows)
                    {
                        if (ele.Text.Contains(parameter))
                        {
                            flag = true;
                            break;
                        }
                        else
                        {

                            Waits.Wait(driver, 1000);
                            continue;
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// To select the assigned parameter
        /// </summary>
        /// <param name="Parameter"></param>
        public void SelectSingleParameter(string Parameter)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.WaitForElementVisible(driver, lnkListedParameters);
                List<IWebElement> lstEle = new List<IWebElement>(lnkListedParameters.FindElements(By.TagName("tr")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(Parameter))
                        {
                            Waits.WaitAndClick(driver, ele);
                            flag = true;
                            break;
                        }
                        else
                        {
                            Waits.Wait(driver, 1000);
                            continue;
                        }
                    }
                }
            }
        }

        public int NumberOfSystemsDisplayed()
        {
            int count = 0;
            Waits.WaitForElementVisible(driver, lnkListedParameters);
            List<IWebElement> lstEle = new List<IWebElement>(lnkListedParameters.FindElements(By.TagName("tr")));
            if(lstEle.Count>0)
            count = lstEle.Count;
            return count;
        }

        public void SelectSingleSystemEquipment(string parameter)
        {
            bool flag = false;
            List<IWebElement> parameters = new List<IWebElement>(lnkListedParameters.FindElements(By.TagName("tr")));
            var rowCounts = parameters.Count();
            for (int i = 0; i < rowCounts; i++)
            {
                var rowCells = parameters[i].FindElements(By.TagName("td"));
                if (flag)
                {
                    break;
                }
                foreach (var ele in rowCells)
                {
                    if (ele.Text.Contains(parameter))
                    {
                        ele.Click();
                        flag = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// To select metric value
        /// </summary>
        /// <param name="Parameter"></param>
        public void UpdateMetric(string metricValue)
        {
            Waits.WaitForElementVisible(driver, ddlMetric);
            ElementExtensions.SelectByText(ddlMetric, metricValue);
        }


        /// <summary>
        /// To selected equipment from the equipment list
        /// </summary>
        /// <param name="Equipment"></param>
        public void SingleEquipment(string equipment)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.WaitForElementVisible(driver, lnkSingleSystem);
                List<IWebElement> lstEle = new List<IWebElement>(lnkSingleSystem.FindElements(By.TagName("tr")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(equipment))
                        {
                            ele.Click();
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
        }

        /// <summary>
        /// To select assigned equipment  
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool IsSelectParaMeter_EquipmentStatus(string parameter)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.WaitForElementVisible(driver, tableGridValues);
                List<IWebElement> lstEle = new List<IWebElement>(tableGridValues.FindElements(By.TagName("tr")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(parameter))
                        {
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
        /// To Check Selected Parameter available in Graph
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public bool ISGraphDisplayedParameterNew(string Parameter)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 4000);
                List<IWebElement> lstEle = new List<IWebElement>(driver.FindElements(By.XPath("//div[@id='chart_container']//*[name()='svg']//*[name()='g'][@class='highcharts-legend']//*[name()='text']//*[name()='tspan']")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(Parameter))
                        {
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
        /// Checking Alert message presence
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public bool IsAlertHistoryDataPresent(string Message)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 1000);
                List<IWebElement> lstEle = new List<IWebElement>(tableGridValues.FindElements(By.TagName("tr")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(Message))
                        {
                            List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.TagName("td")));
                            if (lstCol.Count > 0)
                            {
                                foreach (var col in lstCol)
                                {
                                    flag = true;
                                    break;
                                }
                            }
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
        /// To Update the Extraction DateRange
        /// </summary>
        public void SelectDateRange()
        {
            Waits.WaitForElementVisible(driver, txtStartDate);
            txtStartDate.Clear();
            Waits.Wait(driver, 500);
            txtStartDate.SendKeys(Convert.ToDateTime(DateTime.Now).Subtract(TimeSpan.FromDays(20)).ToString("yyyy/MM/dd"));
            Waits.Wait(driver, 500);
            Waits.WaitForElementVisible(driver, txtEndDate);
            txtEndDate.Clear();
            Waits.Wait(driver, 500);
            txtEndDate.SendKeys(DateTime.Now.ToString("yyyy/MM/dd"));
            Waits.Wait(driver, 1000);
        }
        
        /// <summary>
        /// Select Date Range
        /// </summary>
        /// <param name="range"></param>
        public void DateRangeSelection(string range)
        {
            string startDate = "";
            string endDate = "";

            if (range.ToLower().Equals("1 week"))
            {
                startDate = "2020/02/01";
                endDate = "2020/02/07";
            }
            else if (range.ToLower().Equals("1 month"))
            {
                startDate = "2020/01/07";
                endDate = "2020/02/07";
            }
            else if (range.ToLower().Equals("3 months"))
            {
                startDate = "2019/11/07";
                endDate = "2020/02/07";
            }
            else if (range.ToLower().Equals("1 year"))
            {
                startDate = "2019/02/07";
                endDate = "2020/02/07";
            }
            else if(range.ToLower().Equals("today"))
            {
                startDate = DateTime.Now.ToString("yyyy/MM/dd");
                endDate = DateTime.Now.ToString("yyyy/MM/dd");
            }
            Waits.WaitForElementVisible(driver, txtStartDate);
            txtStartDate.Clear();
            Waits.Wait(driver, 500);
            txtStartDate.SendKeys(startDate);
            Waits.Wait(driver, 500);
            Waits.WaitForElementVisible(driver, txtEndDate);
            txtEndDate.Clear();
            Waits.Wait(driver, 500);
            txtEndDate.SendKeys(endDate);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// Select Aggregation
        /// </summary>
        /// <param name="seconds"></param>
        public void SetAggregation(string seconds)
        {
            Waits.WaitForElementVisible(driver,ddlAggregation);
            ElementExtensions.SelectByValue(ddlAggregation, seconds);
        }

        /// <summary>
        /// Clcik equipment find button
        /// </summary>
        public void ClickOnFindEquipment()
        {
            Waits.WaitAndClick(driver, btnFindEquipment);
        }

        /// <summary>
        /// Select assigned Equipment
        /// </summary>
        /// <param name="equipment"></param>
        public void SelectSingleEquipment(string equipment)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 1000);
                List<IWebElement> lstEle = new List<IWebElement>(lstEquipmentType.FindElements(By.TagName("tr")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(equipment))
                        {
                            List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.TagName("td")));
                            if (lstCol.Count > 0)
                            {
                                foreach (var col in lstCol)
                                {
                                    Waits.WaitAndClick(driver, col);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Clcik to Move selected system 
        /// </summary>
        public void CliclkOnMoveSingleSystem()
        {
            Waits.WaitForElementVisible(driver, btnMoveSystemsTo);
            Waits.WaitAndClick(driver, btnMoveSystemsTo);
        }

        /// <summary>
        /// To check Assigned Equipment Exist 
        /// </summary>
        /// <param name="equipmentName"></param>
        /// <returns></returns>
        public bool IsAssignedEquipmentPresent(string equipmentName)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                if (flag)
                {
                    break;
                }
                Waits.Wait(driver, 1000);
                IWebElement baseTable = lstAssignedEquipment;
                // gets all table rows
                ICollection<IWebElement> rows = baseTable.FindElements(By.TagName("td"));
                if (rows.Count() > 0)
                {
                    foreach (var ele in rows)
                    {
                        if (ele.Text.Contains(equipmentName))
                        {
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
        /// To check UnAssigned Equipment Exist
        /// </summary>
        /// <returns></returns>
        public bool IsUnAssignedEquipmentPresent(string equipmentName)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                if (flag)
                {
                    break;
                }
                Waits.Wait(driver, 1000);
                IWebElement baseTable = lstEquipmentType;
                // gets all table rows
                ICollection<IWebElement> rows = baseTable.FindElements(By.TagName("td"));
                if (rows.Count() > 0)
                {
                    foreach (var ele in rows)
                    {
                        if (ele.Text.Contains(equipmentName))
                        {
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
        /// Click on changes Apply 
        /// </summary>
        public void ClickOnApply()
        {
            Waits.WaitAndClick(driver, btnApply);
        }

        /// <summary>
        /// If selected Parameter present from the parameter list
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public bool IsSelectedParameterListPresent(string Parameter)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                List<IWebElement> lstEle = new List<IWebElement>(lnkListedParameters.FindElements(By.TagName("tr")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        Waits.Wait(driver, 2000);
                        if (ele.Text.Contains(Parameter))
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
        /// To Select Saved Graph
        /// </summary>
        /// <param name="GraphName"></param>
        public void SelectSavedGraph(string GraphName)
        {
            bool flag = false;
            for (int i = 0; i < 15; i++)
            {
                Waits.Wait(driver, 1000);
                if (flag)
                {
                    break;
                }
                List<IWebElement> lstEle = new List<IWebElement>(lstSavedGraphs.FindElements(By.XPath("option")));
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(GraphName))
                        {
                            Waits.WaitAndClick(driver, ele);
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
        public void DeleteFolder(string folderName)
        {
            Waits.WaitAndClick(driver, lnkHomePage);
            Waits.WaitAndClick(driver, lnkDeviceManager);
            Waits.WaitAndClick(driver, lnkTopLevel);
            ClickOnFolderHeader(folderName);
            ClickDelete();
            Waits.WaitAndClick(driver, btnOKDelete);
            Waits.WaitAndClick(driver, btnOKMessage);
            Waits.Wait(driver, 1000);
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
        /// Enter commission details
        /// </summary>
        /// <param name="equipmentName"></param>
        /// <param name="equipmentType"></param>
        /// <param name="iPAdress"></param>
        /// <param name="iPPortNumber"></param>
        public void EnterCommissionedDetails(string equipmentName, string equipmentType, string iPAdress, string iPPortNumber)
        {
            Waits.WaitForElementVisible(driver, txtBoxEquipmentName);
            Waits.Wait(driver, 1000);
            txtBoxEquipmentName.Clear();
            txtBoxEquipmentName.SendKeys(equipmentName);
            Waits.WaitForElementVisible(driver, drpDownSelectEquipmentType);
            Waits.Wait(driver, 1000);
            ElementExtensions.SelectByText(drpDownSelectEquipmentType, equipmentType);
            Waits.WaitForElementVisible(driver, txtBoxIPAddress);
            Waits.Wait(driver, 2000);
            txtBoxIPAddress.Clear();
            txtBoxIPAddress.SendKeys(iPAdress);
            Waits.WaitForElementVisible(driver, txtBoxIPPortNumber);
            Waits.Wait(driver, 1000);
            txtBoxIPPortNumber.Clear();
            txtBoxIPPortNumber.SendKeys(iPPortNumber);
            Waits.WaitForElementVisible(driver, btnAddOnCommissionPopUp);
            ElementExtensions.ClickOnButton(btnAddOnCommissionPopUp);
        }

        /// <summary>
        /// System Parameter Expand 
        /// </summary>
        public void ExpandSystemsParameter()
        {
            //Waits.Wait(driver, 2000);
            IWebElement ele = lnkExpandSystem.FindElement(By.XPath("//table//tbody//tr//td//a//img"));
            if (ele.GetAttribute("alt").Contains("Expand"))
            {
                ele.Click();
            }
        }

        /// <summary>
        /// Check Expand status of System Parameter
        /// </summary>
        /// <returns></returns>
        public bool ExpandSystemsParameterCheck()
        {
            bool flag = false;
            IWebElement ele = lnkExpandSystem.FindElement(By.XPath("//table//tbody//tr//td//a//img"));

            if (ele.GetAttribute("alt").Contains("Collapse"))
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// Check Element
        /// </summary>
        /// <param name="ele"></param>
        public void CheckElement(IWebElement ele)
        {
            for (int i = 1; i <= 120; i++)
            {
                bool res = ElementExtensions.isDisplayed(driver, ele);
                if (!res)
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
        /// Select Parameter
        /// </summary>
        /// <param name="ele"></param>
        public void SelectParameter(IWebElement ele)
        {
            for (int i = 1; i <= 120; i++)
            {
                bool res = ElementExtensions.isDisplayed(driver, ele);
                if (!res)
                {
                    Waits.Wait(driver, 1000);
                }
                else
                {
                    ele.Click();
                    break;
                }
            }

        }

        /// <summary> 
        /// Checks Parameter Added in Graph
        /// </summary>
        /// <param name="parameter"></param>
        public void CheckParamterAddedInGraph(string parameter)
        {
            bool flag = false;
            for (int i = 1; i <= 30; i++)
            {
                Waits.WaitForElementVisible(driver, lblLegend);

                List<IWebElement> lstEle = new List<IWebElement>(driver.FindElements(By.XPath("//div[@id='chart_container']//*[name()='svg']//*[name()='g'][@class='highcharts-legend']//*[name()='text']//*[name()='tspan']")));

                foreach (var ele in lstEle)
                {
                    if (flag)
                    {
                        break;
                    }
                    if (ele.Text.Contains(parameter))
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

        }

    }
}
