using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class DataExtractionPage : PageBase
    {

        private IWebDriver driver;
        string extractionFileName = string.Empty;
        string ExtendedFilePath = string.Empty;
        string fileName = string.Empty;
        public DataExtractionPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for DataExtractionPage
        #region 

        [FindsBy(How = How.XPath, Using = "//div[@id='divHistoricExtractions']//div[contains(@id,'btnCreateExtraction')]//input[@type='button']")]
        private IWebElement btnDataExtract;

        [FindsBy(How = How.XPath, Using = "//div[@class='rawDataContainer']//div//a[contains(@id,'chkStatus')]")]
        private IWebElement chkboxStatus_RowData;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtDescription')]")]
        private IWebElement txtDescription;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtDateSelectionFrom')]")]
        private IWebElement txtStartDate;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtDateSelectionTo')]")]
        private IWebElement txtEndDate;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnChangeGroups')]")]
        private IWebElement btnChangesSelectionGroups;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnChangeSystems')]")]
        private IWebElement btnChangesSelectionSystems;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'DataExtractionGroups_treePTCs')]//table/tbody/tr/td//input[contains(@id,'DataExtractionGroups_treePTCsn0CheckBox')]")]
        private IWebElement checkboxPTCs;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'DataExtractionGroups_treeUserFolders')]//table[1]//tbody/tr/td//input[contains(@id,'treeUserFoldersn1CheckBox')]")]
        private IWebElement checkboxUserFolder;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'DataExtractionGroups_treeEquipmentTypesn0Nodes')]")]
        private IWebElement checkboxEquipmentList;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'DataExtractionGroups_treeEquipmentTypesn27Nodes')]//table/tbody/tr/td/input[contains(@id,'treeEquipmentTypesn28CheckBox')]")]
        private IWebElement checkboxEquipmentChildList;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'treeEquipmentTypes')]//table[1]/tbody/tr/td/input[contains(@id,'treeEquipmentTypesn0CheckBox')]")]
        private IWebElement checkboxEquipmentType;

        [FindsBy(How = How.XPath, Using = "//div[@class='dataExtractionButtons']//input[contains(@id,'btnApply')]")]
        private IWebElement btnApply;

        [FindsBy(How = How.XPath, Using = "//div[@class='dataExtractionButtons']//input[contains(@id,'DataExtractionSettings_btnSave')]")]
        private IWebElement lnkbtnSave;

        [FindsBy(How = How.Name, Using = "ctl00$ctl00$cphContent$cphContent$DataExtractionSystems$btnCancel")]
        private IWebElement btnCancel;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_DataExtractionSystems_btnSearch")]
        private IWebElement btnSearchSystem;

        [FindsBy(How = How.XPath, Using = "//div[@class='section unassignedSystemsSection']//select[@class='systemsList']")]
        private IWebElement lstSystems;

        [FindsBy(How = How.XPath, Using = "//div[@class='section selectedSystemsSection']//select[@class='systemsList']")]
        private IWebElement lstSelectedSystem;

        [FindsBy(How = How.XPath, Using = "//div[@class='systemListActions']//input[contains(@id,'btnMoveAllSystemsTo')]")]
        private IWebElement btnMoveAllSystems;

        [FindsBy(How = How.XPath, Using = "//div[@class='systemListActions']//input[contains(@id,'btnMoveSystemsTo')]")]
        private IWebElement btnMoveSystemsTo;

        [FindsBy(How = How.XPath, Using = "//div[@class='systemListActions']//input[contains(@id,'btnMoveAllSystemsFrom')]")]
        private IWebElement btnMoveAllSystemsFrom;

        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cphContent_cphContent_lblExtractionInProgressMessage']")]
        private IWebElement lblMessage;

        [FindsBy(How = How.XPath, Using = "//div[@id='divScrollContainer']//table[@class='mGrid']//tbody/tr[1]/td/span")]
        private IWebElement lblFileDetails;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ExtractionUpdatePanel")]
        private IWebElement lblDailyExtraction;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl01_lblLinkText")]
        private IWebElement linkHome;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphSubMenuBar_lnkDataExtraction')]")]
        private IWebElement lnkDataExtraction;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_chkDailyExtractionEnabled_imgCheckBox')]")]
        private IWebElement lnkDailyExtractionEnabled;

        [FindsBy(How = How.Name, Using = "ctl00$ctl00$cphContent$cphContent$btnChangeDailySettings")]
        private IWebElement btnChangeDailySettings;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblPopupTitle')][contains(.,'Daily Extraction')]")]
        private IWebElement lblTitleDailyextraction;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblPopupTitle")]
        private IWebElement lnkPnlExtractionSettings;

        [FindsBy(How = How.XPath, Using = "//div[@class='section searchOptionSection']")]
        private IWebElement lnkPnlDataExtractionSystems;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_DataExtractionSettings_chkStatus_imgCheckBox')]")]
        private IWebElement lnkStatusCheckBox;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_DataExtractionSettings_chkParameters_imgCheckBox')]")]
        private IWebElement lnkParametersCheckBox;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_DataExtractionSettings_chkStatistical_imgCheckBox')]")]
        private IWebElement lnkStatisticalCheckBox;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_DataExtractionSettings_chkAlerts_imgCheckBox')]")]
        private IWebElement lnkAlertsCheckBox;

        [FindsBy(How = How.XPath, Using = "//div[@class='section selectedSystemsSection']//select[@class='systemsList']")]
        private IWebElement lstselectedSystemsSection;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_DataExtractionSystems_pnlExtractionSystemSettings")]
        private IWebElement pnlExtractionSystemSettings;

        [FindsBy(How = How.XPath, Using = "//div[@class='section selectedGroupsSection']")]
        private IWebElement lstSelectedGroup;

        [FindsBy(How = How.XPath, Using = "//div[@class='section currentSystemsSection']")]
        private IWebElement lstcurrentSystems;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnCreateExtraction')]")]
        private IWebElement btnCreateExtraction;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblExtractionInProgressMessage")]
        private IWebElement lblExtractionMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='dataExtractionButtons']//input[contains(@id,'DataExtractionSettings_btnRun')]")]
        private IWebElement btnHistoricDataExtract;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'The Historic Extraction Utility is currently extracting data')]")]
        private IWebElement lblExtractingData;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_imgRunning")]
        private IWebElement lblWaitIcon;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'DataExtractionGroups_treePTCs')]//table//tbody//tr//td[2]//a//img")]
        private IWebElement lnkCheckboxPTCs;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'DataExtractionGroups_treeUserFolders')]//table//tbody//tr//td[2]//a//img")]
        private IWebElement lnkCheckboxUserFolder;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'DataExtractionGroups_treeEquipmentTypes')]//table//tbody//tr//td[2]//a//img")]
        private IWebElement lnkCheckboxEquipmentList;


        #endregion

        //Properties  
        #region
        public IWebElement LblDailyExtraction
        {
            get
            {
                return lblDailyExtraction;
            }
            set
            {
                lblDailyExtraction = value;
            }
        }

        public IWebElement LblExtractionMessage
        {
            get
            {
                return lblExtractionMessage;
            }
        }


        public IWebElement BtnCancel
        {
            get
            {
                return btnCancel;
            }
            set
            {
                btnCancel = value;
            }
        }

        public IWebElement LinkHome
        {
            get
            {
                return linkHome;
            }
            set
            {
                linkHome = value;
            }
        }

        public IWebElement LnkDataExtraction
        {
            get { return lnkDataExtraction; }
            set { lnkDataExtraction = value; }
        }

        public IWebElement LnkDailyExtractionEnabled
        {
            get { return lnkDailyExtractionEnabled; }
            set { lnkDailyExtractionEnabled = value; }
        }

        public IWebElement BtnChangeDailySettings
        {
            get { return btnChangeDailySettings; }
            set { btnChangeDailySettings = value; }
        }

        public IWebElement LnkPnlExtractionSettings
        {
            get { return lnkPnlExtractionSettings; }
            set { lnkPnlExtractionSettings = value; }
        }

        public IWebElement LnkPnlDataExtractionSystems
        {
            get { return lnkPnlDataExtractionSystems; }
            set { lnkPnlDataExtractionSystems = value; }
        }

        public IWebElement BtnChangesSelectionGroups
        {
            get { return btnChangesSelectionGroups; }
            set { btnChangesSelectionGroups = value; }
        }

        public IWebElement LnkStatusCheckBox
        {
            get { return lnkStatusCheckBox; }
            set { lnkStatusCheckBox = value; }
        }

        public IWebElement LnkParametersCheckBox
        {
            get { return lnkParametersCheckBox; }
            set { lnkParametersCheckBox = value; }
        }

        public IWebElement LnkAlertsCheckBox
        {
            get { return lnkAlertsCheckBox; }
            set { lnkAlertsCheckBox = value; }
        }

        public IWebElement PnlExtractionSystemSettings
        {
            get { return pnlExtractionSystemSettings; }
            set { pnlExtractionSystemSettings = value; }
        }

        public IWebElement ChkboxStatus_RowData
        {
            get { return chkboxStatus_RowData; }
            set { chkboxStatus_RowData = value; }
        }

        public IWebElement BtnDataExtract
        {
            get { return btnDataExtract; }
            set { btnDataExtract = value; }
        }

        public IWebElement BtnCreateExtraction
        {
            get { return btnCreateExtraction; }
            set { btnCreateExtraction = value; }
        }

        public IWebElement BtnHistoricDataExtract
        {
            get { return btnHistoricDataExtract; }
            set { btnHistoricDataExtract = value; }
        }

        public IWebElement LblExtractingData
        {
            get { return lblExtractingData; }
            set { lblExtractingData = value; }
        }

        public IWebElement LblWaitIcon
        {
            get { return lblWaitIcon; }
            set { lblWaitIcon = value; }
        }

        public IWebElement LnkbtnSave
        {
            get { return lnkbtnSave; }
            set { lnkbtnSave = value; }
        }

        public IWebElement LstSystems
        {
            get { return lstSystems; }
            set { lstSystems = value; }
        }

        public IWebElement BtnSearchSystem
        {
            get { return btnSearchSystem; }
            set { btnSearchSystem = value; }
        }

        #endregion


        /// <summary>
        /// Check the system already present 
        /// </summary>
        /// <returns></returns>
        public bool IsSystemItemPresent()
        {
            IWebElement baseSystemList = lstSystems;
            SelectElement selectList = new SelectElement(baseSystemList);
            IList<IWebElement> options = selectList.Options;
            if (options.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Move selected System
        /// </summary>
        public void MoveSystems()
        {
            if (IsSystemItemPresent())
            {
                ClickOnMoveAllSystem();
            }
        }

        /// <summary>
        /// Go to DataExtraction page
        /// </summary>
        public void ClickOnDataExtraction()
        {
            Waits.WaitAndClick(driver, btnDataExtract);
        }

        /// <summary>
        /// Row data status
        /// </summary>
        public void SelectStatusFromDataRow()
        {
            try
            {
                if (ChkboxStatus_RowData.Enabled)
                {
                    ChkboxStatus_RowData.Click();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// to set the description value
        /// </summary>
        /// <param name="Description"></param>
        public void EnterDescriptionValue(String Description)
        {
            Waits.WaitForElementVisible(driver, txtDescription);
            txtDescription.Clear();
            txtDescription.SendKeys(Description);
        }

        /// <summary>
        /// To Update the Extraction DateRange
        /// </summary>
        public void ExtractSystemDate()
        {
            Waits.WaitForElementVisible(driver, txtStartDate);
            txtStartDate.Clear();
            Waits.Wait(driver, 500);
            txtStartDate.SendKeys(Convert.ToDateTime(DateTime.Now).Subtract(TimeSpan.FromDays(15)).ToString("yyyy/MM/dd"));
            Waits.WaitForElementVisible(driver, txtEndDate);
            Waits.Wait(driver, 500);
            txtEndDate.Clear();
            Waits.Wait(driver, 500);
            txtEndDate.SendKeys(DateTime.Now.ToString("yyyy/MM/dd"));
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// Click the change selection group button
        /// </summary>
        public void ClickOnChangeSelection_SelectedGroups()
        {
            Waits.WaitAndClick(driver, btnChangesSelectionGroups);
        }

        /// <summary>
        /// Click the change selection System button
        /// </summary>
        public void ClickOnChangeSelection_SelectedSystems()
        {
            Waits.WaitAndClick(driver, btnChangesSelectionSystems);
        }

        /// <summary>
        /// Select the Needed Equipment
        /// </summary>
        public void SelectEquipmentType()
        {
            Waits.WaitForElementVisible(driver, checkboxEquipmentType);
            Waits.WaitAndClick(driver, checkboxEquipmentType);
        }

        /// <summary>
        /// To select the Apply Button
        /// </summary>
        public void ClickOnApply()
        {
            Waits.WaitAndClick(driver, btnApply);
        }

        /// <summary>
        /// To select the Save Button
        /// </summary>
        public void ClickOnSave()
        {
            Waits.WaitAndClick(driver, lnkbtnSave);
        }

        /// <summary>
        /// To Click the search system button
        /// </summary>
        public void ClickOnSearchSystem()
        {
            Waits.WaitAndClick(driver, btnSearchSystem);
        }

        /// <summary>
        /// To Move All selected system
        /// </summary>
        public void ClickOnMoveAllSystem()
        {
            Waits.WaitAndClick(driver, btnMoveAllSystems);
        }

        /// <summary>
        /// To Get All selected system 
        /// </summary>
        public void ClickOnMoveBackAllSystem()
        {
            Waits.WaitAndClick(driver, btnMoveAllSystemsFrom);
        }

        /// <summary>
        /// To Move the selected single system
        /// </summary>
        public void CliclkOnMoveSingleSystem()
        {
            Waits.WaitAndClick(driver, btnMoveSystemsTo);
        }

        /// <summary>
        /// Check the selected system status
        /// </summary>
        /// <returns></returns>
        public bool IsSelectedSystemsPresent(string system)
        {
            bool flag = false;
            IWebElement baseTable = lstselectedSystemsSection;
            // gets all table rows
            ICollection<IWebElement> rows = baseTable.FindElements(By.TagName("option"));
            if (rows.Count > 0)
            {
                foreach (var ele in rows)
                {
                    if (ele.Text.Contains(system))
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
            return flag;
        }

        /// <summary>
        /// Check the selected system listed in the selectedlist
        /// </summary>
        /// <param name="System"></param>
        /// <returns></returns>
        public bool IsCurrentSelectedSystemsPresent(string System)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 1000);
                IWebElement baseTable = lstcurrentSystems;
                if (flag)
                {
                    break;
                }
                // gets all table rows
                ICollection<IWebElement> rows = baseTable.FindElements(By.TagName("li"));
                if (rows.Count() > 0)
                {
                    foreach (var ele in rows)
                    {
                        if (ele.Text.Contains(System))
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
        ///  Check selected group presence 
        /// </summary>
        /// <param name="Group"></param>
        /// <returns></returns>
        public bool IsSelectedGroupPresent(string Group)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 1000);
                IWebElement baseTable = lstSelectedGroup;
                if (flag)
                {
                    break;
                }
                // gets all table rows
                ICollection<IWebElement> rows = baseTable.FindElements(By.TagName("li"));
                if (rows.Count() > 0)
                {
                    foreach (var ele in rows)
                    {
                        if (ele.Text.Contains(Group))
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
        /// Select Single system from the list
        /// </summary>
        /// <param name="System"></param>
        public void SelectSingleSystem(string system)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 1000);
                List<IWebElement> lstEle = new List<IWebElement>(lstSystems.FindElements(By.TagName("option")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(system))
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

        public bool IsSystemExist(string system)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.Wait(driver, 1000);
                List<IWebElement> lstEle = new List<IWebElement>(lstSelectedSystem.FindElements(By.TagName("options")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(system))
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
        /// Raw Data Checkbox Selection
        /// </summary>
        public void RawDataCheckboxSelection()
        {
            Waits.WaitForElementVisible(driver, lnkStatusCheckBox);
            if (!lnkAlertsCheckBox.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, lnkStatusCheckBox);
            }
            Waits.WaitForElementVisible(driver, lnkParametersCheckBox);
            if (!lnkAlertsCheckBox.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, lnkParametersCheckBox);
            }
            Waits.WaitForElementVisible(driver, lnkStatisticalCheckBox);
            if (!lnkAlertsCheckBox.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, lnkStatisticalCheckBox);
            }
            Waits.WaitForElementVisible(driver, lnkAlertsCheckBox);
            if (!lnkAlertsCheckBox.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, lnkAlertsCheckBox);
            }
        }

        /// <summary>
        /// To select Group Checkbox
        /// </summary>
        public void GroupCheckboxSelection()
        {
            Waits.WaitForElementVisible(driver, lnkCheckboxPTCs);
            if (!lnkCheckboxPTCs.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, lnkCheckboxPTCs);
            }
            Waits.WaitForElementVisible(driver, lnkCheckboxUserFolder);
            if (!lnkCheckboxUserFolder.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, lnkCheckboxUserFolder);
            }
            Waits.WaitForElementVisible(driver, lnkCheckboxEquipmentList);
            if (!lnkCheckboxEquipmentList.GetAttribute("src").Contains("chk_on"))
            {
                Waits.WaitAndClick(driver, lnkCheckboxEquipmentList);
            }
        }

        /// <summary>
        ///  Delete Folder Exist
        /// </summary>
        public void DeleteFolderExists()
        { 
            for (int i = 0; i < 30; i++)
            {
                if (Directory.Exists(GlobalConstants.ExtractionPath))
                {
                    Directory.Delete(GlobalConstants.ExtractionPath, true);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// To Check Folder Exist 
        /// </summary>
        /// <returns></returns>
        public bool isFolderExist()
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                if(flag)
                {
                    break;
                }
                string extractionFileName = DateTime.Now.ToString("yyyy-MM-dd") + "(Test Data Historic Extraction)";
                Waits.Wait(driver, 1000);
                ExtendedFilePath = GlobalConstants.ExtractionPath + @"\" + extractionFileName;
                if (Directory.Exists(ExtendedFilePath))
                {
                    flag = true;
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
        /// To Check File Exist 
        /// </summary>
        /// <returns></returns>
        public bool ZipFileExist()
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                if(flag)
                {
                    break;
                }
                DirectoryInfo di = new DirectoryInfo(ExtendedFilePath);
                fileName = DateTime.Now.ToString("yyyy-MM-dd") + "(Test Data Historic Extraction).zip";
                Waits.Wait(driver, 1000);
                FileInfo[] TXTFiles = di.GetFiles(fileName);
                if (TXTFiles.Length != 0)
                {
                    flag = true;
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
        /// Extracts existing Zip file
        /// </summary>
        /// <returns></returns>
        public bool ExtractFileExist()
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                var zipFilePath = ExtendedFilePath + @"\" + fileName;
                string dir = Directory.GetDirectories(@"G:\", "Edwards\\Scada\\Historic Extraction").FirstOrDefault();
                if (Directory.Exists(dir))
                {
                    if (flag)
                    {
                        break;
                    }
                    using (ZipArchive zip = ZipFile.OpenRead(zipFilePath))
                    {
                        foreach (ZipArchiveEntry entry in zip.Entries)
                        {
                            var csvFileName = "Alert" + Convert.ToDateTime(DateTime.Now).Subtract(TimeSpan.FromDays(15)).ToString("yyyyMMdd") + "-0.csv";
                            if (entry.Name.Equals(csvFileName))
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
        /// To check File is exist
        /// </summary>
        /// <returns></returns>
        public bool FileExist()
        {
            bool flag = false;
            DirectoryInfo di = new DirectoryInfo(GlobalConstants.CDIFilePath);
            Waits.Wait(driver, 1000);
            FileInfo[] TXTFiles = di.GetFiles(GlobalConstants.CDIFileName);
            if (TXTFiles.Length != 0)
            {
                flag = true;
            }
            return flag;
        }

    }
}