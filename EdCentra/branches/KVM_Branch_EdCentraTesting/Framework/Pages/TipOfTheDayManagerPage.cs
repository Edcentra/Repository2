using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class TipOfTheDayManagerPage:PageBase
    {
        IWebDriver driver;
        public TipOfTheDayManagerPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for TipOfTheDayManagerPage
        #region
        [FindsBy(How = How.XPath, Using = "//button[text()='Save changes']")]
        private IWebElement btnSaveChanges;

        [FindsBy(How = How.XPath, Using = "//button[text()='Add New Tip']")]
        private IWebElement btnAddNewTip;

        [FindsBy(How = How.XPath, Using = "//button[text()='Delete Tip']")]
        private IWebElement btnDeleteTipDialog;

        [FindsBy(How = How.Id, Using = "AddTipLoad")]
        private IWebElement btnAddTip;

        [FindsBy(How = How.Id, Using = "EditTipLoad")]
        private IWebElement btnEditTip;

        [FindsBy(How = How.Id, Using = "DeleteTipLoad")]
        private IWebElement btnDeleteTip;

        [FindsBy(How = How.Id, Using = "TipTitle")]
        private IWebElement txtTipTitle;

        [FindsBy(How = How.Id, Using = "TipContent")]
        private IWebElement txtTipContent;

        [FindsBy(How = How.Id, Using = "NewTipTitle")]
        private IWebElement txtEditTipTitle;

        [FindsBy(How = How.Id, Using = "TipTable")]
        private IWebElement tipTable;

        [FindsBy(How = How.Id, Using = "ctl00_tips_tipContents")]
        private IWebElement divLLTraining;

        [FindsBy(How = How.Id, Using = "ctl00_tips_btnNextTip")]
        private IWebElement btnNext;

        [FindsBy(How = How.Id, Using = "ctl00_tips_btnClose")]
        private IWebElement btnClose;

        [FindsBy(How = How.Id, Using = "ctl00_tips_btnPreviousTip")]
        private IWebElement btnPrevious;

        [FindsBy(How = How.Id, Using = "ctl00_tips_CheckBoxTips_imgCheckBox")]
        private IWebElement chkDontShowTipBox;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_tips_tipContents']/h2")]
        private IWebElement tipLLHeader;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_tips_tipContents']/p")]
        private IWebElement tipLLContent;

        [FindsBy(How = How.XPath, Using = "//*[@id='exampleModalDelete']/div/div/div[2]/p")]
        private IWebElement deleteConfirmText;

        private ReadOnlyCollection<IWebElement> tipTableRows => this.tipTable.FindElements(By.TagName("tr"));

        #endregion

        //Property for TipOfTheDayManagerPage
        #region
        public int TipTableRowsCount
        {
            get { return tipTableRows.Count(); }
        }

        public bool IsDivLLTrainingExists
        {
            get
            {
                try
                {
                    return divLLTraining.Displayed;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public string DeleteTipConfirmText
        {
            get { return deleteConfirmText.Text; }
        }

        public string TipLLContent
        {
            get { return tipLLContent.Text; }
        }

        public string TipLLHeader
        {
            get { return tipLLHeader.Text; }
        }

        public IWebElement ChkDontShowTipBox
        {
            get { return chkDontShowTipBox; }
            set { chkDontShowTipBox = value; }
        }

        public IWebElement BtnClose
        {
            get { return btnClose; }
            set { btnClose = value; }
        }

        public IWebElement BtnPrevious
        {
            get { return btnPrevious; }
            set { btnPrevious = value; }
        }

        public IWebElement BtnNext
        {
            get { return btnNext; }
            set { btnNext = value; }
        }

        public IWebElement BtnSaveChanges
        {
            get { return btnSaveChanges; }
            set { btnSaveChanges = value; }
        }

        public IWebElement BtnAddNewTip
        {
            get { return btnAddNewTip; }
            set { btnAddNewTip = value; }
        }

        public IWebElement BtnDeleteTipDialog
        {
            get { return btnDeleteTipDialog; }
            set { btnDeleteTipDialog = value; }
        }

        public IWebElement BtnAddTip
        {
            get { return btnAddTip; }
            set { btnAddTip = value; }
        }

        public IWebElement BtnEditTip
        {
            get { return btnEditTip; }
            set { btnEditTip = value; }
        }

        public IWebElement BtnDeleteTip
        {
            get { return btnDeleteTip; }
            set { btnDeleteTip = value; }
        }

        public IWebElement TxtTipTitle
        {
            get { return txtTipTitle; }
            set { txtTipTitle = value; }
        }

        public IWebElement TxtTipContent
        {
            get { return txtTipContent; }
            set { txtTipContent = value; }
        }

        public IWebElement TxtEditTipTitle
        {
            get { return txtEditTipTitle; }
            set { txtEditTipTitle = value; }
        }

        public IWebElement TipTable
        {
            get { return tipTable; }
            set { tipTable = value; }
        }
        #endregion


        //Methods
        #region
        public void NavigateToTipOfTheManagerTool()
        {
            driver.Navigate().GoToUrl(GlobalConstants.TipOfTheDayManagerUrl);
        }

        public string GetTipTitleText(int index)
        {
            string text = string.Empty;
             text = (tipTableRows[index].FindElements(By.TagName("td")))[2].Text.ToString();
            return text;
        }

        public bool IsTipExistsInTable(string tipTitle)
        {
            bool flag = false;
            var count = tipTableRows.Count();
            for (int i = 1; i < count; i++)
            {
                var text = (tipTableRows[i].FindElements(By.TagName("td")))[2].Text.ToString();
                if (text.ToLower().Equals(tipTitle.ToLower()))
                {
                    flag = true;
                    break;
                }

            }
            return flag;
        }

        public void SelectTipForEditOrDelete(string tipTitle)
        {
            var count = tipTableRows.Count();
            for(int i=1; i<count; i++)
            {
                var text = (tipTableRows[i].FindElements(By.TagName("td")))[2].Text.ToString();
                if (text.ToLower().Equals(tipTitle.ToLower()))
                    tipTableRows[i].FindElement(By.Name("CheckedTipIds")).Click();
            }
        }

        public void ClickSecondLeftMostSignButton(string tipTitle)
        {
            var count = tipTableRows.Count();
            for (int i = 1; i < count; i++)
            {
                var text = (tipTableRows[i].FindElements(By.TagName("td")))[2].Text.ToString();
                if (text.ToLower().Equals(tipTitle.ToLower()))
                {
                    tipTableRows[i].FindElement(By.Id("MoveTipUpButton")).Click();
                    break;
                }
            }
        }

        public void ClickThirdLeftMostSignButton(string tipTitle)
        {
            var count = tipTableRows.Count();
            for (int i = 1; i < count; i++)
            {
                var text = (tipTableRows[i].FindElements(By.TagName("td")))[2].Text.ToString();
                if (text.ToLower().Equals(tipTitle.ToLower()))
                {
                    tipTableRows[i].FindElement(By.Id("MoveTipDownButton")).Click();
                    break;
                }
            }
        }

        public void ClickFirstLeftMostSignButton(string tipTitle)
        {
            var count = tipTableRows.Count();
            for (int i = 1; i < count; i++)
            {
                var text = (tipTableRows[i].FindElements(By.TagName("td")))[2].Text.ToString();
                if (text.ToLower().Equals(tipTitle.ToLower()))
                {
                    tipTableRows[i].FindElement(By.Id("SetTipTopRankButton")).Click();
                    break;
                }

            }
        }

        public void ClickFourthLeftMostSignButton(string tipTitle)
        {
            var count = tipTableRows.Count();
            for (int i = 1; i < count; i++)
            {
                var text = (tipTableRows[i].FindElements(By.TagName("td")))[2].Text.ToString();
                if (text.ToLower().Equals(tipTitle.ToLower()))
                {
                    (((tipTableRows[i].FindElements(By.TagName("td")))[6]).FindElements(By.TagName("button")))[3].Click();
                    break;
                }

            }
        }

        /// <summary>
        /// Insert tips In Table fst_GEN_Tips
        /// </summary>
        public void InsertNewValueToTable()
        {
            try
            {
                string serverName = @".\FABWORKS";
                serverName = serverName.Replace(@"\", @"/");
                var connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                string sqlText = "SET IDENTITY_INSERT [dbo].[fst_GEN_Tips] ON;";
                sqlText += "INSERT [dbo].[fst_GEN_Tips] ([TipId], [TipTitle], [TipOfTheDay], [TipRank]) VALUES (10, N'LL Training', N'Did you know Edwards offers LL Training ? ', 1);";
                sqlText += "INSERT [dbo].[fst_GEN_Tips] ([TipId], [TipTitle], [TipOfTheDay], [TipRank]) VALUES (11, N'Tuesday Training ', N'Did you know Edwards offers Tuesday training ...', 2);";
                sqlText += "INSERT [dbo].[fst_GEN_Tips] ([TipId], [TipTitle], [TipOfTheDay], [TipRank]) VALUES (12, N'Wednesday Training', N'More training on Wednesdays ...', 3);";
                sqlText += "INSERT [dbo].[fst_GEN_Tips] ([TipId], [TipTitle], [TipOfTheDay], [TipRank]) VALUES (15, N'Lorum Ipsum Training ', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 4);";
                sqlText += "INSERT [dbo].[fst_GEN_Tips] ([TipId], [TipTitle], [TipOfTheDay], [TipRank]) VALUES (16, N'Friday Training', N'Training on Friday ...', 5);";
                sqlText += "INSERT [dbo].[fst_GEN_Tips] ([TipId], [TipTitle], [TipOfTheDay], [TipRank]) VALUES (17, N'Saturday Training', N'There is no training on Saturday ...', 6);";
                sqlText += "INSERT [dbo].[fst_GEN_Tips] ([TipId], [TipTitle], [TipOfTheDay], [TipRank]) VALUES (18, N'Sundays are holidays', N'Have fun on Sundays ... ', 7);";
                sqlText += "SET IDENTITY_INSERT [dbo].[fst_GEN_Tips] OFF;";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sqlText;
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected <= 0)
                        {
                            Assert.IsTrue(false, "Tips are not added in fst_GEN_Tips table");
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

        /// <summary>
        /// Delete tips from Table fst_GEN_Tips
        /// </summary>
        public void DeleteTipsFromTable()
        {
            try
            {
                string serverName = @".\FABWORKS";
                serverName = serverName.Replace(@"\", @"/");
                var connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

                string sqlText = "DELETE FROM [dbo].[fst_GEN_Tips];";
                sqlText += "Delete from [dbo].[fst_GEN_Tips_SEC_User] where UserId=1;";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sqlText;
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                       
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
