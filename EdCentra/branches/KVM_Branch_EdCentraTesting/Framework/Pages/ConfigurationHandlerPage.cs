using Edwards.Scada.Test.Framework.GlobalHelper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class ConfigurationHandlerPage : PageBase
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializing page
        /// </summary>
        /// <param name="driver"></param>
        public ConfigurationHandlerPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for userpage
        #region
        [FindsBy(How = How.XPath, Using = " //div[@class='treeTitle'][contains(.,'Equipment Types & Configurations')]")]
        private IWebElement lblEquipmentTypesAndConfiguarations;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'iXH DryPump')]")]
        private IWebElement labelDryPump;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Create')]")]
        private IWebElement btnCreate;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSetCreate_lblTitle")]
        private IWebElement lblCreateConfiguarationSet;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSetCreate_txtName")]
        private IWebElement txtBoxName;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id, 'VariantOption_PUMP-SET')]//tbody//img")]
        private IWebElement radioBtnPumpSet;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSetCreate_btnCreate")]
        private IWebElement btnCreateConfigurationSetUp;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'configurationView')]/div")]
        private IWebElement lblCreatedConfigurationSet;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationGroup_clConfigurationSets_divListControl")]
        private IWebElement tblConfiguarationSets { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSet_lstUnassignedParameters")]
        private IWebElement lstBoxConfiguarationSetParameters { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSet_btnMoveTo")]
        private IWebElement btnMoveTo;

        [FindsBy(How = How.Id, Using = "lstAssignedParameters")]
        private IWebElement lstAssignedParameters { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Save')]")]
        private IWebElement btnSave;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSet_lblFeedback")]
        private IWebElement lblSuccessMsg;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Rename')]")]
        private IWebElement btnRename;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Copy')]")]
        private IWebElement btnCopy;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSetRename_lblTitle")]
        private IWebElement lblRenameHighlightedSetPopUP;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSetRename_txtName")]
        private IWebElement txtBoxNewName;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Confirm')]")]
        private IWebElement btnConfirm;

        [FindsBy(How = How.Id, Using = "lblError")]
        private IWebElement lblErrorNameExists;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Edit')]")]
        private IWebElement btnEdit;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSetEdit_rptParameters_ctl01_ParamValue_1")]
        private IWebElement txtBoxHighAlarmEditPopUP;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSetEdit_btnSave")]
        private IWebElement btnSaveEditPopUp;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSetEdit_lblTitle")]
        private IWebElement lblEditPopUp;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Cancel')]")]
        private IWebElement btnCancel;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationGroup_lblCopyData")]
        private IWebElement lblMsgCopy;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Paste')]")]
        private IWebElement btnPaste;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'btnCreate')][@class='busyButton']")]
        private IWebElement btnCreateWithSpinner;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSetPaste_txtNewName")]
        private IWebElement txtBoxNewNamePastePopUp;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSetPaste_lblTitle")]
        private IWebElement lblTitlePastePopUp;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSetPaste_btnPaste")]
        private IWebElement btnPastePopUp;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Delete')]")]
        private IWebElement btnDelete;

        [FindsBy(How = How.Name, Using = "ctl00$ctl00$cphContent$cphContent$ConfigurationGroup$btnCompare")]
        private IWebElement btnCompare;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ConfigurationSetCompare_lblTitle")]
        private IWebElement lblComparePopUpTitle;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id, 'ctl00_ctl00_cphContent_cphContent_ConfigurationSetCompare_rdlOptions')]//td[3]//a")]
        private IWebElement rdoBtnSame;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'compareResults')]//tr[3]")]
        private IWebElement compareResults;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Close')]")]
        private IWebElement btnClose;

        [FindsBy(How =How.XPath, Using = "//div[contains(@id,'btnConfirm')][@class='busyButton']")]
        private IWebElement btnConfirmBusy;
        #endregion

        //Properties
        #region

        public IWebElement BtnConfirmBusy
        {
            get
            {
                return btnConfirmBusy;
            }
            set
            {
                btnConfirmBusy = value;
            }
        }

        public IWebElement TblConfiguarationSets
        {
            get
            {
                return tblConfiguarationSets;
            }
            set
            {
                tblConfiguarationSets = value;
            }
        }

        public IWebElement LblEquipmentTypesAndConfiguarations
        {
            get
            {
                return lblEquipmentTypesAndConfiguarations;
            }
            set
            {
                lblEquipmentTypesAndConfiguarations = value;
            }
        }

        public IWebElement BtnCreateWithSpinner
        {
            get
            {
            return btnCreateWithSpinner;
           }
            set
            {
                btnCreateWithSpinner = value;
            }
        }

        public IWebElement LblDryPump
        {
            get
            {
                return labelDryPump;
            }
            set
            {
                labelDryPump = value;
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

        public IWebElement BtnCompare
        {
            get
            {
                return btnCompare;
            }
            set
            {
                btnCompare = value;
            }
        }

        public IWebElement BtnCopy
        {
            get
            {
                return btnCopy;
            }
            set
            {
                btnCopy = value;
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
        

        public IWebElement LblCreateConfiguarationSet
        {
            get
            {
                return lblCreateConfiguarationSet;
            }
            set
            {
                lblCreateConfiguarationSet = value;
            }
        }

        public IWebElement TxtBoxName
        {
            get
            {
                return txtBoxName;
            }
            set
            {
                txtBoxName = value;
            }
        }

        public IWebElement RadioBtnPumpSet
        {
            get
            {
                return radioBtnPumpSet;
            }
            set
            {
                radioBtnPumpSet = value;
            }
        }

        public IWebElement BtnCreateConfigurationSetUp
        {
            get
            {
                return btnCreateConfigurationSetUp;
            }
            set
            {
                btnCreateConfigurationSetUp = value;
            }
        }

        public IWebElement LblCreatedConfigurationSet
        {
            get
            {
                return lblCreatedConfigurationSet;
            }
            set
            {
                lblCreatedConfigurationSet = value;
            }
        }

        public IWebElement BtnMoveTo
        {
            get
            {
                return btnMoveTo;
            }
            set
            {
                btnMoveTo = value;
            }
        }

        public IWebElement BtnSave
        {
            get
            {
                return btnSave;
            }
            set
            {
                btnSave = value;
            }
        }

        public IWebElement LblSuccessMsg
        {
            get
            {
                return lblSuccessMsg;
            }
            set
            {
                lblSuccessMsg = value;
            }
        }

        public IWebElement BtnRename
        {
            get
            {
                return btnRename;
            }
            set
            {
                btnRename = value;
            }
        }

        public IWebElement LblRenameHighlightedSetPopUP
        {
            get
            {
                return lblRenameHighlightedSetPopUP;
            }
            set
            {
                lblRenameHighlightedSetPopUP = value;
            }
        }

        public IWebElement TxtBoxNewName
        {
            get
            {
                return txtBoxNewName;
            }
            set
            {
                txtBoxNewName = value;
            }
        }

        public IWebElement BtnConfirm
        {
            get
            {
                return btnConfirm;
            }
            set
            {
                btnConfirm = value;
            }
        }

        public IWebElement LblErrorNameExists
        {
            get
            {
                return lblErrorNameExists;
            }
            set
            {
                lblErrorNameExists = value;
            }
        }

        public IWebElement BtnEdit
        {
            get
            {
                return btnEdit;
            }
            set
            {
                btnEdit = value;
            }
        }

        public IWebElement TxtBoxHighAlarm
        {
            get
            {
                return txtBoxHighAlarmEditPopUP;
            }
            set
            {
                txtBoxHighAlarmEditPopUP = value;
            }
        }

        public IWebElement BtnSaveEditPopUp
        {
            get
            {
                return btnSaveEditPopUp;
            }
            set
            {
                btnSaveEditPopUp = value;
            }
        }

        public IWebElement LblEditPopUp
        {
            get
            {
                return lblEditPopUp;
            }
            set
            {
                lblEditPopUp = value;
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

        public IWebElement LblMsgCopy
        {
            get
            {
                return lblMsgCopy;
            }
            set
            {
                lblMsgCopy = value;
            }
        }

        public IWebElement BtnPaste
        {
            get
            {
                return btnPaste;
            }
            set
            {
                btnPaste = value;
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

        public IWebElement TxtBoxNewNamePastePopUp
        {
            get
            {
                return txtBoxNewNamePastePopUp;
            }
            set
            {
                txtBoxNewNamePastePopUp = value;
            }
        }

        public IWebElement LblTitlePastePopUp
        {
            get
            {
                return lblTitlePastePopUp;
            }
            set
            {
                lblTitlePastePopUp = value;
            }
        }

        public IWebElement BtnPastePopUp
        {
            get
            {
                return btnPastePopUp;
            }
            set
            {
                btnPastePopUp = value;
            }
        }

        public IWebElement LblComparePopUpTitle
        {
            get
            {
                return lblComparePopUpTitle;
            }
            set
            {
                lblComparePopUpTitle = value;
            }
        }

        public IWebElement RdoBtnSame
        {
            get
            {
                return rdoBtnSame;
            }
            set
            {
                rdoBtnSame = value;
            }
        }
        #endregion

        #region
        /// <summary>
        /// Checks created configuaration set name in list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckConfigurationSetExists( string name )
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, tblConfiguarationSets);
            List<IWebElement> lstConfiguarationSet= new List<IWebElement>(tblConfiguarationSets.FindElements(By.TagName("tr")));
            foreach(var set in lstConfiguarationSet)
            {
               if(set.Text.Equals(name))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        /// <summary>
        /// Selects configuaration paramters
        /// </summary>
        public void selectConfiguarationSetParameters( string text )
        {
            Waits.WaitForElementVisible(driver, lstBoxConfiguarationSetParameters);
            ElementExtensions.SelectByText(lstBoxConfiguarationSetParameters, text);
            BtnMoveTo.Click();
            for (int i = 0; i <= 20; i++)
            {
                bool flag = isConfigurationSetParameterAdded(text);
                if (flag == false)
                {
                    Waits.Wait(driver, 1000);
                }
                else if (flag == true)
                {
                    break;
                }
            }
        }
        
        /// <summary>
        /// Checks Configuaration Set Parameter Added
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool isConfigurationSetParameterAdded( string text )
        {
            bool flag = false;
            try
            {
               Waits.WaitForElementVisible(driver, lstAssignedParameters);
               List <IWebElement> lstParameters = new List<IWebElement>(lstAssignedParameters.FindElements(By.TagName("option")));
                foreach(var par in lstParameters)
                {
                   if(par.Text.Contains(text))
                   {
                        flag = true;
                        break;
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
        /// Select Assigned Configuration Parameter
        /// </summary>
        /// <param name="text"></param>
        public void SelectAssignedConfigurationParameter( string text )
        {
            bool flag = false;
            try
            {
                Waits.WaitForElementVisible(driver, lstAssignedParameters);
                List<IWebElement> lstParameters = new List<IWebElement>(lstAssignedParameters.FindElements(By.TagName("option")));
                foreach (var par in lstParameters)
                {
                    if (par.Text.Contains(text))
                    {
                        Waits.Wait(driver, 1000);
                        par.Click();
                        for (int i = 1; i <= 5; i++)
                        {
                            if (par.Selected)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught" + ex.Message);
            }
        }

        /// <summary>
        /// Select already created configuaration set from list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public void SelectExistingConfigurationSet( string name )
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, tblConfiguarationSets);
            List<IWebElement> lstConfiguarationSet = new List<IWebElement>(tblConfiguarationSets.FindElements(By.TagName("tr")));
            foreach (var set in lstConfiguarationSet)
            {
                if (set.Text.Equals(name))
                {
                    set.Click();
                    break;
                }
            }
        }

        /// <summary>
        /// Veirfy Configuration Set exists
        /// </summary>
        /// <param name="name"></param>
        public void DeleteIfConfigrationSetExists(string name)
        {

            bool flag = false;
            Waits.WaitForElementVisible(driver, tblConfiguarationSets);
            List<IWebElement> lstConfiguarationSet = new List<IWebElement>(tblConfiguarationSets.FindElements(By.TagName("tr")));
            foreach (var set in lstConfiguarationSet)
            {
                if (set.Text.Equals(name))
                {
                    Waits.WaitAndClick(driver, set);
                    Waits.WaitAndClick(driver, BtnDelete);
                    Waits.WaitForElementVisible(driver, BtnConfirm);
                    Waits.WaitAndClick(driver,BtnConfirm);
                    Waits.WaitForElementVisible(driver, TblConfiguarationSets);
                    break;
                }
            }
        }

        /// <summary> 
        /// compare  result of configuration sets
        /// </summary>
        public bool CompareResults()
        {
          bool flag = false;
          Waits.WaitForElementVisible(driver, compareResults);
          List<IWebElement> resultLst = new List<IWebElement>(compareResults.FindElements(By.TagName("td")));
          if(resultLst.ElementAt(0).Text.Contains("Max log time norm.") && resultLst.ElementAt(1).Text.Equals("43200") && resultLst.ElementAt(2).Text.Equals("43200"))
            {
                flag = true;
            }
            return flag;
        }


        /// <summary>
        /// Set Value In Application Column
        /// </summary>
        public void SetValueInApplicationColumn()
        {
            try
            {
                string serverName = @".\FABWORKS";
                serverName = serverName.Replace(@"\", @"/");
                var connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO dbo.fst_SEC_InstalledApplication(ApplicationID) VALUES (17)";
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected != 1)
                        {
                            Assert.IsTrue(false, "Value 17 is not added in fst_SEC_InstalledApplication table");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion
    }
    }





