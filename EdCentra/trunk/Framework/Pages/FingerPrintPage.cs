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
    public class FingerPrintPage : PageBase
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializing page
        /// </summary>
        /// <param name="driver"></param>
        public FingerPrintPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for FingerPrintPage
        #region

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl03_lblLinkText")]
        private IWebElement lnkDiagnostics;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphSubMenuBar_lnkFingerprint")]
        private IWebElement lnkFingerprintMenu;

        [FindsBy(How = How.XPath, Using = "//a//span[text()='Fingerprint']")]
        private IWebElement lnkFingerprint;

        [FindsBy(How = How.Id, Using = "divFingerprintMessage")]
        private IWebElement fingerprintMsg;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Add a fingerprint to begin')]")]
        private IWebElement fingerprintPageDisplayed;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblFingerprints")]
        private IWebElement headingSecondPanel;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphSubMenuBar_lnkFingerprint')]")]
        private IWebElement lnkFingerprintTab;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnNewFingerprint")]
        private IWebElement btnNewFingerprint;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_lblNewFingerprint')")]
        private IWebElement lblNewFingerprint;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtFingerprintName")]
        private IWebElement txtFingerprintName;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtNote")]
        private IWebElement txtNote;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnSaveFingerprint")]
        private IWebElement btnSaveFingerprint;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnCloseAdd")]
        private IWebElement btnCancelFingerprint;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'divSettingsBody')]")]
        private IWebElement divCompareSection;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_divBox")]
        private IWebElement lnkFingerprintlist;

        [FindsBy(How = How.XPath, Using = "//*[@id='divSettingsMain']/table[1]")]
        private IWebElement lnkFingerprintDetailslist;

        [FindsBy(How = How.XPath, Using = "//*[@id='divSettingsMain']/table[2]")]
        private IWebElement lnkFingerprintParameterList;

        [FindsBy(How = How.XPath, Using = "//*[@id='divAddPopup']/div[2]/span")]
        private IWebElement popUpMsg;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_UpdatePanelFingerprints")]
        private IWebElement lblFingerprints;

        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'ctl00$UserOptions$rptOptions$ctl05$ddlValue')]")]
        private IWebElement lnkTemperatureUnit;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_UserOptions_btnClose")]
        private IWebElement btnClose;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnDelete")]
        private IWebElement btnDelete;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnOkDelete")]
        private IWebElement btnOkDelete;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnCancelDelete")]
        private IWebElement btnCancelDelete;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkExport")]
        private IWebElement lnkExport;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblClearAll")]
        private IWebElement lnkClear;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$UserOptions$btnApply')]")]
        private IWebElement btnUserOptionsApply;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_lblDelta')]")]
        private IWebElement lblDelta;

        [FindsBy(How = How.Id, Using = "divSettingsBody")]
        private IWebElement divParameterlist;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clFingerprints_divListControl")]
        private IWebElement divFingerprints;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl01_lblLinkText")]
        private IWebElement lnkHome;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl02_hypLink")]
        private IWebElement lnkRealTimeMonitoring;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_rptMenu_ctl02_rptSubMenu_ctl01_hypLink")]
        private IWebElement lnkDeviceExplorer;

        private ReadOnlyCollection<IWebElement> FingerprintHeaderColumns => this.lnkFingerprintDetailslist.FindElements(By.TagName("th"));

        private ReadOnlyCollection<IWebElement> FingerprintDetailRows => this.lnkFingerprintDetailslist.FindElements(By.ClassName("alertRow"));

        private ReadOnlyCollection<IWebElement> FingerprintParameterHeaderColumns => this.lnkFingerprintParameterList.FindElements(By.TagName("th"));

        private ReadOnlyCollection<IWebElement> FingerprintParameterDetailRows => this.lnkFingerprintParameterList.FindElements(By.ClassName("alertRow"));

        #endregion

        //Properties
        #region

        public List<string> GetFingerprintHeaderDetails
        {
            get { return FingerprintHeaderColumns.Select(x => x.Text).Where(x => !string.IsNullOrWhiteSpace(x)).ToList(); }
        }

        public List<FingerprintDetails> FingerprintDetailsList
        {
            get
            {
                var tCollection = new List<FingerprintDetails>();
                var rowCounts = FingerprintDetailRows.Count();
                for (int i = 0; i < rowCounts; i++)
                {
                    tCollection.Add(this[i]);
                }
                return tCollection;
            }
        }

        public FingerprintDetails this[int i]
        {
            get
            {
                var rowCells = FingerprintDetailRows[i].FindElements(By.TagName("td"));
                return new FingerprintDetails
                {
                    SystemName = rowCells[1].Text,
                    FingerprintName = rowCells[2].Text,
                    Type = rowCells[3].Text,
                    Date = rowCells[4].Text,
                    SerialNumber = rowCells[5].Text,
                    Note = rowCells[6].FindElement(By.TagName("img")).GetAttribute("title")
                };
            }
           
        }

        public List<string> GetFingerprintParameterHeaderDetails
        {
            get { return FingerprintParameterHeaderColumns.Select(x => x.Text).Where(x => !string.IsNullOrWhiteSpace(x)).ToList(); }
        }

        public List<FingerprintParameterDetails> FingerprintParameterDetailsList
        {
            get
            {
                var tCollection = new List<FingerprintParameterDetails>();
                var rowCounts = FingerprintParameterDetailRows.Count();
                for (int i = 0; i < rowCounts; i++)
                {
                    var rowCells = FingerprintParameterDetailRows[i].FindElements(By.TagName("td"));
                    if (rowCells.Count() > 4)
                    {
                        tCollection.Add(new FingerprintParameterDetails
                        {
                            ParameterName = rowCells[0].Text,
                            FingerprintParameterValue = rowCells[1].Text,
                            Delta = rowCells[2].Text,
                            Fingerprint2ParameterValue = rowCells[3].Text,                            
                            Unit = rowCells[4].Text,
                        });
                    }
                    else if (rowCells.Count() < 4)
                    {
                            tCollection.Add(new FingerprintParameterDetails
                            {
                                ParameterName = rowCells[0].Text,
                                FingerprintParameterValue = rowCells[1].Text,
                                Unit = rowCells[2].Text,
                            });

                        }
                }
                return tCollection;
            }
        }



        public IWebElement LnkDiagnostics
        {
            get { return lnkDiagnostics; }
            set { lnkDiagnostics = value; }
        }

        public IWebElement LnkFingerprint
        {
            get { return lnkFingerprint; }
            set { lnkFingerprint = value; }
        }
        public IWebElement LnkFingerprintParameterList
        {
            get { return lnkFingerprintParameterList; }
            set { lnkFingerprintParameterList = value; }
        }

        public IWebElement LnkFingerprintTab
        {
            get { return lnkFingerprintTab; }
            set { lnkFingerprintTab = value; }
        }

        public string PopUpMsg
        {
            get { return popUpMsg.Text; }
        }

        public IWebElement BtnNewFingerprint
        {
            get { return btnNewFingerprint; }
            set { btnNewFingerprint = value; }
        }

        public IWebElement LblNewFingerprint
        {
            get { return lblNewFingerprint; }
            set { lblNewFingerprint = value; }
        }


        public IWebElement LnkFingerprintMenu
        {
            get { return lnkFingerprintMenu; }
        }

        public IWebElement BtnSaveFingerprint
        {
            get { return btnSaveFingerprint; }
            set { btnSaveFingerprint = value; }
        }

        public IWebElement LnkFingerprintlist
        {
            get { return lnkFingerprintlist; }
            set { lnkFingerprintlist = value; }
        }

        public bool IsCompareSectionExists
        {
            get
            {
                try { return divCompareSection.Displayed; }
                catch(Exception ex) { return false; }
            }

        }

        public IWebElement BtnCancelFingerprint
        {
            get { return btnCancelFingerprint; }

        }

        public string FingerprintMsg
        {
            get { return fingerprintMsg.Text; }

        }

        public string HeadingSecondPanel
        {
            get { return headingSecondPanel.Text; }

        }

        public bool IsFingerprintPageMessageDisplayed
        {
            get { return fingerprintPageDisplayed.Displayed; }

        }

        public IWebElement LnkTemperatureUnit
        {
            get { return lnkTemperatureUnit; }
            set { lnkTemperatureUnit = value; }
        }

        public IWebElement BtnClose
        {
            get { return btnClose; }
            set { btnClose = value; }
        }

        public IWebElement BtnDelete
        {
            get { return btnDelete; }
            set { btnDelete = value; }
        }

        public IWebElement BtnOkDelete
        {
            get { return btnOkDelete; }
            set { btnOkDelete = value; }
        }

        public IWebElement BtnCancelDelete
        {
            get { return btnCancelDelete; }
            set { btnCancelDelete = value; }
        }

        public IWebElement LnkExport
        {
            get { return lnkExport; }
            set { lnkExport = value; }
        }

        public IWebElement LnkClear
        {
            get { return lnkClear; }
            set { lnkClear = value; }
        }

        public IWebElement LblDelta
        {
            get { return lblDelta; }
            set { lblDelta = value; }
        }

        public IWebElement LnkHome
        {
            get { return lnkHome; }
            set { lnkHome = value; }
        }

        #endregion

        //Methods

        /// <summary>
        /// To Create New Fingerprint
        /// </summary>
        /// <param name="fpName"></param>
        /// <param name="fpMessage"></param>
        public void CreateFingerprint(string fpName, string fpMessage)
        {
            //Waits.WaitForElementVisible(driver, txtFingerprintName);
            JavaScriptExecutor.JavaScriptLinkClick(driver, txtFingerprintName);
            txtFingerprintName.SendKeys("");
            txtFingerprintName.SendKeys(fpName);
            Waits.Wait(driver, 2000);
            JavaScriptExecutor.JavaScriptLinkClick(driver, txtNote);
            txtNote.SendKeys("");
            txtNote.SendKeys(fpMessage);
            Waits.Wait(driver, 2000);
            JavaScriptExecutor.JavaScriptLinkClick(driver, btnSaveFingerprint);
            Waits.Wait(driver, 2000);
        }

        /// <summary>
        /// To get the Finger print deatils
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool FigerPrintDetails(string parameter, string value, int rownum = 1)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lnkFingerprintlist);
            List<IWebElement> lstEle = new List<IWebElement>(lnkFingerprintlist.FindElements(By.TagName("th")));
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
                        if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrEmpty(value))
                        {
                            rownum = rownum + 1;
                            List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.XPath($"//tr[{rownum}]//td")));
                            if (lstCol.Count > 0)
                            {
                                foreach (var col in lstCol)
                                {
                                    if (col.Text.Contains(value))
                                    {
                                        flag = true;
                                        Waits.Wait(driver, 1000);
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// To get the Finger print deatils
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool FingerPrintParameterDetails(string parameter, string value, int rownum = 1)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, LnkFingerprintParameterList);
            List<IWebElement> lstEle = new List<IWebElement>(LnkFingerprintParameterList.FindElements(By.TagName("th")));
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
                        if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrEmpty(value))
                        {
                            rownum = rownum + 1;
                            List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.XPath($"//tr[{rownum}]//td")));
                            if (lstCol.Count > 0)
                            {
                                foreach (var col in lstCol)
                                {
                                    if (col.Text.Contains(value))
                                    {
                                        flag = true;
                                        Waits.Wait(driver, 1000);
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// Is Fingerprint Listed
        /// </summary>
        /// <param name="fingerprintName"></param>
        /// <returns></returns>
        public bool IsFingerprintListPresent(string fingerprintName)
        {
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                List<IWebElement> lstEle = new List<IWebElement>(lblFingerprints.FindElements(By.TagName("td")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        Waits.Wait(driver, 1000);
                        if (ele.Text.Contains(fingerprintName))
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
        /// Selecte created Fingerprint
        /// </summary>
        /// <param name="fingerprintName"></param>
        public void SelectFingerprint(string fingerprintName)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.WaitForElementVisible(driver, lblFingerprints);
                List<IWebElement> lstEle = new List<IWebElement>(lblFingerprints.FindElements(By.TagName("td")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Contains(fingerprintName))
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

        /// <summary>
        /// Delete if folder is exists
        /// </summary>
        public void DeleteFolderExists()
        {

            DirectoryInfo di = new DirectoryInfo(GlobalConstants.CSVFilePath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        /// <summary>
        /// CSV file exists
        /// </summary>
        /// <returns></returns>
        public bool CSVFileExist()
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                if (flag)
                {
                    break;
                }
                var csvFileName = "Export";
                Waits.Wait(driver, 1000);
                DirectoryInfo di = new DirectoryInfo(GlobalConstants.CSVFilePath);

                foreach (FileInfo file in di.GetFiles())
                {                    
                    if (file.Name.Contains(csvFileName))
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
        /// Gets parameter section details for single fingerprint
        /// </summary>
        /// <returns></returns>
        public List<FingerprintParameterDetails> GetSingleFingerprintParameterDetailsFromCSVFile()
        {
            string[] filePaths = Directory.GetFiles(GlobalConstants.CSVFilePath);
            var fingerprintdetailsList = new List<FingerprintParameterDetails>();
            foreach (string p in filePaths)
            {
                var csvFileName = "Export";
                if (p.Contains(csvFileName))
                {
                    fingerprintdetailsList = File.ReadLines(p)
                    .Select(x => x.Split(',')).Where(z => z.LongLength == 3)
                    .Skip(1)
                    .Select(x =>
                        new FingerprintParameterDetails
                        {
                            ParameterName = x[0].Replace("\0", "").Replace("\"", ""),
                            FingerprintParameterValue = x[1].Replace("\0", "").Replace("\"", ""),
                            Unit = x[2].Replace("\0", "").Replace("\"", "")

                        }).ToList();
                    return fingerprintdetailsList;
                }
            }
            return fingerprintdetailsList;
        }

        /// <summary>
        /// Gets parameter section details for multiple fingerprint with  comparison
        /// </summary>
        /// <returns></returns>
        public List<FingerprintParameterDetails> GetMultipleFingerprintParameterDetailsFromCSVFile()
        {
            string[] filePaths = Directory.GetFiles(GlobalConstants.CSVFilePath);
            var fingerprintdetailsList = new List<FingerprintParameterDetails>();
            foreach (string p in filePaths)
            {
                var csvFileName = "Export";
                if (p.Contains(csvFileName))
                {
                    fingerprintdetailsList = File.ReadLines(p)
                    .Select(x => x.Split(',')).Where(z => z.LongLength == 5)
                    .Skip(1)
                    .Select(x =>
                        new FingerprintParameterDetails
                        {
                            ParameterName = x[0].Replace("\0", "").Replace("\"", ""),
                            FingerprintParameterValue = x[1].Replace("\0", "").Replace("\"", ""),
                            Delta= x[2].Replace("\0", "").Replace("\"", ""),
                            Fingerprint2ParameterValue = x[3].Replace("\0", "").Replace("\"", ""),
                            Unit = x[4].Replace("\0", "").Replace("\"", "")

                        }).ToList();
                    return fingerprintdetailsList;
                }
            }
            return fingerprintdetailsList;
        }

        /// <summary>
        /// Get fingerprint header details from CSV
        /// </summary>
        /// <returns></returns>
        public List<FingerprintDetails> GetFingerprintDetailsFromCSVFile()
        {
            string[] filePaths = Directory.GetFiles(GlobalConstants.CSVFilePath);
            var fingerprintdetailsList = new List<FingerprintDetails>();
            foreach (string p in filePaths)
            {
                var csvFileName = "Export";
                if (p.Contains(csvFileName))
                {

                    fingerprintdetailsList = File.ReadLines(p).Skip(1)
                    .Select(x => x.Split(',')).Where(z => z.LongLength > 5)
                    .Take(2)
                    .Select(x =>
                        new FingerprintDetails
                        {
                            SystemName =  x[0].Replace("\0", "").Replace("\"", ""),
                            FingerprintName =  x[1].Replace("\0", "").Replace("\"", ""),
                            Type = x[2].Replace("\0", "").Replace("\"", ""),
                            Date =  x[3].Replace("\0", "").Replace("\"", ""),
                            SerialNumber =  x[4].Replace("\0", "").Replace("\"", ""),
                            Note =  x[5].Replace("\0", "").Replace("\"", "")

                        }).ToList();
                    return fingerprintdetailsList;
                }
            }

            return fingerprintdetailsList;
        }

        /// <summary>
        /// Fingerprint serial number
        /// </summary>
        /// <param name="fingerprintName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool FingerprintNumber(string fingerprintName, string value)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.WaitForElementVisible(driver, lblFingerprints);
                List<IWebElement> lstEle = new List<IWebElement>(divParameterlist.FindElements(By.XPath("//td//img")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.GetAttribute("src").Contains(value))
                        {
                            List<IWebElement> lstCol = new List<IWebElement>(divFingerprints.FindElements(By.TagName("td")));
                            if (lstCol.Count > 0)
                            {
                                foreach (var col in lstCol)
                                {
                                    if (col.Text.Contains(fingerprintName))
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// Verify the Delta details
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="sysmbol"></param>
        /// <returns></returns>
        public bool DeltaDeatils(string parameter, string sysmbol)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                Waits.WaitForElementVisible(driver, lblFingerprints);
                List<IWebElement> lstEle = new List<IWebElement>(divParameterlist.FindElements(By.TagName("td")));
                if (flag)
                {
                    break;
                }
                if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if (ele.Text.Equals(parameter))
                        {
                            Waits.Wait(driver, 1000);
                            List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.XPath("//td")));
                            if (lstCol.Count > 0)
                            {
                                foreach (var col in lstCol)
                                {
                                    if (col.Text.Contains(sysmbol))
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// Change user Temperature preference value
        /// </summary>
        public void ChangeUserPreference()
        {
            Waits.WaitForElementVisible(driver, lnkTemperatureUnit);
            ElementExtensions.SelectByValue(lnkTemperatureUnit, "203");
            Waits.WaitAndClick(driver, btnUserOptionsApply);
        }

    }
}
