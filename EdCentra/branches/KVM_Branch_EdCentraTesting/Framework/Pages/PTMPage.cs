using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Edwards.Scada.Test.Framework.Pages
{
    

    //namespaces
    using Edwards.Scada.Test.Framework.GlobalHelper;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class PTMPage:PageBase 
    {

        private IWebDriver driver;

        public PTMPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for PTMPage
        #region 
        [FindsBy(How = How.XPath, Using = "//div[@class='addbox selectedbox']//span[text()='Create Profile']")]
        private IWebElement lnkCreateProfile;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtProfileName')]")]
        private IWebElement txtProfileName;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblTitle")]
        private IWebElement lblPTMTest;

        [FindsBy(How = How.XPath, Using = "//div[@id='divLeftBox']//ul")]
        private IWebElement lstProfiles;

        [FindsBy(How = How.XPath, Using = "//li[contains(@id,'liEdit')]//a/div/div/div[2]")]
        private IWebElement createdProfile;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnCreate')]")]
        private IWebElement btnCreateProfile;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlSystemType')]")]
        private IWebElement lstSystemDropdownList;

        [FindsBy(How = How.XPath, Using = "//div[@class='settingstabs']//a[text()='Equipment']")]
        private IWebElement tabEquipment;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'btnGetSystems')]//input[contains(@id,'btnGetSystems')]")]
        private IWebElement btnFindEquipment;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnDelete')]")]
        private IWebElement btnDeleteProfile;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//input[contains(@id,'btnOKDelete')]")]
        private IWebElement btnOKDelete;

        [FindsBy(How = How.XPath, Using = "//h2//span[contains(@id,'lblTitle')]")]
        private IWebElement lblProfileTitle;

        [FindsBy(How = How.XPath, Using = "//div[@id='divFoundsystems']//table/tbody[@class='clist']")]
        private IWebElement tblEquipmentListTable;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'gvLoggingParameters')]//tbody/tr[1]//a//img")]
        private IWebElement checkListLoggingParameter;

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Predictive Maintenance']")]
        private IWebElement lnkPredictiveMaintenance;

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Parameter Threshold Monitoring']")]
        private IWebElement lnkParameterThreasholdMonitoring;

        [FindsBy(How = How.XPath, Using = "//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnApply')]")]
        private IWebElement btnApplyChanges;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'gvLoggingParameters')]//tbody//tr//a//img[contains(@src,'chk_on')]")]
        private IWebElement checkedParameter;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphSubMenuBar_lnkPTM')]")]
        private IWebElement lnkPTMPage;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphContent_cphContent_lnkDetails')]")]
        private IWebElement lnkDetailsTab;

        [FindsBy(How = How.XPath, Using = "//*[@id= 'ctl00_ctl00_cphContent_cphContent_gvLoggingParameters_divScrollContainer']")]
        private IWebElement ParameterTable;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtLow')]")]
        private IWebElement txtLowValue;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtHigh')]")]
        private IWebElement txtHighValue;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtSet')]")]
        private IWebElement txtSetValue;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtClear')]")]
        private IWebElement txtClearValue;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphContent_cphContent_lnkEquipment')]")]
        private IWebElement lnkEquipmentTab;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnMoveSystemsTo')]")]
        private IWebElement btnMoveSystemsTo;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnApply')]")]
        private IWebElement btnApply;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblFeedback')]")]
        private IWebElement lblFeedback;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$gvLoggingParameters$ctl02$txtLow')]")]
        private IWebElement txtParameterLowValue;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$gvLoggingParameters$ctl02$txtHigh')]")]
        private IWebElement txtParameterHighValue;

        [FindsBy(How = How.XPath, Using = "//div[@class='logo']//a//img")]
        private IWebElement lnkHomePage;

        #endregion

        //Property
        #region
        
        public IWebElement LblPTMTest
        {
            get
            {
                return lblPTMTest;
            }
            set
            {
                lblPTMTest = value;
            }
        }

        public IWebElement LnkPTMPage
        {
            get { return lnkPTMPage; }
            set { lnkPTMPage = value; }
        }

        public IWebElement LnkDetailsTab
        {
            get { return lnkDetailsTab; }
            set { lnkDetailsTab = value; }
        }

        public IWebElement LnkEquipmentTab
        {
            get { return lnkEquipmentTab; }
            set { lnkEquipmentTab = value; }
        }

        public IWebElement LnkCreateProfile
        {
            get { return lnkCreateProfile; }
            set { lnkCreateProfile = value; }
        }

        public IWebElement BtnApply
        {
            get { return btnApply; }
            set { btnApply = value; }
        }

        public IWebElement LblFeedback
        {
            get { return lblFeedback; }
            set { lblFeedback = value; }
        }

        public IWebElement TxtProfileName
        {
            get { return txtProfileName; }
            set { txtProfileName = value; }
        }

        public IWebElement TxtParameterLowValue
        {
            get { return txtParameterLowValue; }
            set { txtParameterLowValue = value; }
        }

        public IWebElement TxtParameterHighValue
        {
            get { return txtParameterHighValue; }
            set { txtParameterHighValue = value; }
        }
        #endregion

        //Methods
        #region

        /// <summary>
        /// Create New PTM profile
        /// </summary>
        /// <param name="ProfileName"></param>
        /// <param name="Value"></param>
        public void CreateProfile(string ProfileName,string Value)
        {
           
            if (IsPTMProfileExist(ProfileName))
            {
                DeletePTMProfile(ProfileName);                
            }

            ClickOnCreateProfileOption();
            Waits.Wait(driver, 1000);
            EnterProfileName(ProfileName);
            Waits.Wait(driver, 1000);
            SelectSystemDevice(Value);
            ClickOnCreateButton();
            Waits.Wait(driver,3000);
        }

        /// <summary>
        /// Delete the selected profile
        /// </summary>
        /// <param name="ProfileName"></param>
        public void DeletePTMProfile(string ProfileName)
        {
                SelectCreatedProfile(ProfileName);
                ClickOnDeleteButton();
                ClickOkDeleteButton();
        }

        /// <summary>
        /// To get the list of profiles already created 
        /// </summary>
        /// <returns></returns>
        public string GetPTMProfileList()
        {
            List<string> PTMProfileList = new List<string>();
            Waits.WaitForElementVisible(driver, lstProfiles);
            ICollection<IWebElement> list = lstProfiles.FindElements(By.TagName("li"));

            foreach (IWebElement listItem in list)
            {
                PTMProfileList.Add(listItem.Text);
            }
            return PTMProfileList.ToString();
        }

        /// <summary>
        /// Check profilename already exist 
        /// </summary>
        /// <param name="ProfileName"></param>
        /// <returns></returns>
        public bool IsPTMProfileExist(string ProfileName)
        {
            List<string> PTMProfileList = new List<string>();
            Waits.WaitForElementVisible(driver, lstProfiles);
            ICollection<IWebElement> list = lstProfiles.FindElements(By.TagName("li"));
            foreach (IWebElement listItem in list)
            {
                PTMProfileList.Add(listItem.Text);
            }
            if (PTMProfileList.Contains(ProfileName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// check Equipment status
        /// </summary>
        /// <returns></returns>
        public bool IsEquipmentPresent()
        {
            Waits.WaitForElementVisible(driver, tblEquipmentListTable);
            // gets all table rows
            ICollection<IWebElement> rows = tblEquipmentListTable.FindElements(By.TagName("tr"));
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
        /// Select already created profile
        /// </summary>
        /// <param name="ProfileName"></param>
        public void SelectCreatedProfile(String ProfileName)
        {
            Waits.WaitForElementVisible(driver, lstProfiles);
            ICollection<IWebElement> list = lstProfiles.FindElements(By.TagName("li"));
            foreach (IWebElement listItem in list)
            {
                if (listItem.Text.Equals(ProfileName))
                {
                    Waits.WaitAndClick(driver, listItem);
                    break;
                }
                else
                {
                    continue;
                }
            }            

        }

        /// <summary>
        /// Click on create profile link
        /// </summary>
        public void ClickOnCreateProfileOption()
        {
            Waits.WaitForElementVisible(driver, lnkCreateProfile);
            Waits.WaitAndClick(driver, lnkCreateProfile);
            Waits.Wait(driver, 3000);
        }

        /// <summary>
        /// Enter profile name in profile text box
        /// </summary>
        /// <param name="ProfileName"></param>
        public void EnterProfileName(string ProfileName)
        {
            Waits.Wait(driver, 1000);
            txtProfileName.Clear();
            txtProfileName.SendKeys(ProfileName);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// To select device from the device list 
        /// </summary>
        /// <param name="Value"></param>
        public void SelectSystemDevice(string Value)
        {
            Waits.Wait(driver, 1000);
            SelectElement element = new SelectElement(lstSystemDropdownList);
            element.SelectByValue(Value);
        }

        /// <summary>
        /// move to equipment tab
        /// </summary>
        public void NavigateToEquipmentTab()
        {
            Waits.WaitAndClick(driver, tabEquipment);
        }

        /// <summary>
        /// Click the find equipment button to search the equipment
        /// </summary>
        public void FindEquipmentSystems()
        {
           Waits.WaitAndClick(driver, btnFindEquipment);
        }

        /// <summary>
        /// Click plus sign button to create a profile
        /// </summary>
        public void ClickOnCreateButton()
        {
            Waits.WaitAndClick(driver, btnCreateProfile);
        }

        /// <summary>
        /// Delete button to delete the profile 
        /// </summary>
        public void ClickOnDeleteButton()
        {
           Waits.WaitAndClick(driver, btnDeleteProfile);
            Waits.WaitForElementVisible(driver, btnOKDelete);
        }

        /// <summary>
        /// confirmation for delete action
        /// </summary>
        public void ClickOkDeleteButton()
        {
            Waits.WaitAndClick(driver, btnOKDelete);
            Waits.WaitForElementVisible(driver, btnCreateProfile);
        }

        /// <summary>
        /// get the already created PTMProfileTitle
        /// </summary>
        /// <returns></returns>
        public string GetPTMProfileTitle()
        {
            return lblProfileTitle.Text;
        }


        public void CheckedProfileParameter()
        {
            Waits.WaitAndClick(driver, checkListLoggingParameter);
        }

        /// <summary>
        /// click apply button to apply the changes
        /// </summary>
        public void ClickApplyChanges()
        {
            Waits.WaitAndClick(driver, btnApplyChanges);
        }

        /// <summary>
        /// check the parameter selection status
        /// </summary>
        /// <returns></returns>
        public bool IsProfileParameterSelected()
        {
            return checkListLoggingParameter.Selected;
        }


        public bool IsProfileParameterOn()
        {
            return checkedParameter.Displayed;
        }

        /// <summary>
        /// click the link on PredictiveMaintanance
        /// </summary>
        public void ClickOnPredictiveMaintenanceLink()
        {
            Waits.WaitAndClick(driver, lnkPredictiveMaintenance);
        }

        /// <summary>
        /// click PTM link 
        /// </summary>
        public void ClickOnPTMLink()
        {
            Waits.WaitAndClick(driver, lnkParameterThreasholdMonitoring);
        }


        /// <summary>
        /// Select Needed Parameter from parameter list
        /// </summary>
        /// <param name="Parameter"></param>
        public void SelectParameters(string Parameter)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, ParameterTable);
            List<IWebElement> lstEle = new List<IWebElement>(ParameterTable.FindElements(By.XPath("//table//tbody//tr")));

            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (flag)
                    {
                        break;
                    }
                    if (ele.Text.Contains(Parameter))
                    {
                        List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.TagName("td")));
                        if (lstCol.Count > 0)
                        {
                            foreach (var col in lstCol)
                            {
                                col.Click();
                                Waits.Wait(driver, 1000);
                                flag = true;
                                break;
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Enter Low Value
        /// </summary>
        /// <param name="LowValue"></param>
        public void EnterLowValue(string LowValue)
        {
            Waits.Wait(driver, 1000);
            Waits.WaitForElementVisible(driver, txtLowValue);
            txtLowValue.Clear();
            Waits.Wait(driver, 1000);
            txtLowValue.SendKeys(LowValue);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// Enter High Value
        /// </summary>
        /// <param name="HighValue"></param>
        public void EnterHighValue(string HighValue)
        {
            txtHighValue.Clear();
            Waits.Wait(driver, 1000);
            txtHighValue.SendKeys(HighValue);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// Enter Set Value
        /// </summary>
        /// <param name="SetValue"></param>
        public void EnterSetValue(string SetValue)
        {
            txtSetValue.Clear();
            Waits.Wait(driver, 1000);
            txtSetValue.SendKeys(SetValue);
            Waits.Wait(driver, 1000);
        }

        /// <summary>
        /// Enter Clear Value
        /// </summary>
        /// <param name="ClearValue"></param>
        public void EnterClearValue(string ClearValue)
        {
            txtClearValue.Clear();
            Waits.Wait(driver, 1000);
            txtClearValue.SendKeys(ClearValue);
            Waits.Wait(driver, 1000);
        }


        /// <summary>
        /// Selects Single Equipment
        /// </summary>
        /// <param name="Equipment"></param>
        public void SelectSingleEquipment(string Equipment)
        {
            List<IWebElement> lstEle = new List<IWebElement>(tblEquipmentListTable.FindElements(By.TagName("tr")));

            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                    if (ele.Text.Contains(Equipment))
                    {
                        List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.TagName("td")));
                        if (lstCol.Count > 0)
                        {
                            foreach (var col in lstCol)
                            {
                                col.Click();
                                Waits.Wait(driver, 3000);
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Move selected system
        /// </summary>
        public void CliclkOnMoveSingleSystem()
        {
           Waits.WaitAndClick(driver, btnMoveSystemsTo);
           Waits.Wait(driver, 12000);
        }


        /// <summary>
        /// Click On Homepage link
        /// </summary>
        public void NavigateToHomePage()
        {
            Waits.WaitAndClick(driver, lnkHomePage);
        }

        public DataTable SetValueInApplicationColumn()
        {
            try
            {
                string serverName = @".\FABWORKS";
                serverName = serverName.Replace(@"\", @"/");
                var connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    string query = @"select st.Description, ParameterType.SystemTypeID, count(*) as 'Total'
                                    from
                                    fst_GEN_ParameterType ParameterType
                                            inner
                                    join fst_LCR_BenchmarkDefault BD on BD.ParameterNumber = ParameterType.ParameterNumber

                                    and BD.SystemTypeID = ParameterType.SystemTypeID
                                           and BD.BenchmarkName = 'PERIOD'
                                    inner join fsf_GEN_UnitConversionByUserId(1) U ON U.SIUnitID = ParameterType.SIUnitID
                                    inner join fsv_GEN_SystemType st on st.SystemTypeID = ParameterType.SystemTypeID
                                    LEFT OUTER JOIN fst_GEN_ParameterTypeDescription PTO ON PTO.SystemTypeID = ParameterType.SystemTypeID
                                          AND PTO.ParameterNumber = ParameterType.ParameterNumber
                                     where ParameterType.Analogue = 1
                                    Group by st.Description, ParameterType.SystemTypeID";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    con.Open();
                    sda.Fill(dt);
                    return dt;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
#endregion