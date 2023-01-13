using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Edwards.Scada.Test.Framework.Pages
{
    using System.Threading;
    using Edwards.Scada.Test.Framework.Contract;

    //namespaces
    using Edwards.Scada.Test.Framework.GlobalHelper;

    public class GroupPage: PageBase
    {
        IWebDriver driver;
        public GroupPage(IWebDriver driver) : base(driver)
        {

          this.driver = driver;

        }

        //objects for grouppage
        #region 
        [FindsBy(How = How.XPath, Using = ".//input[contains(@id,'txtGroupName')]")]
        private IWebElement txtGroupName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//textarea[contains(@id,'txtDescription')]")]
        private IWebElement txtDescription { get; set; }

        [FindsBy(How=How.XPath, Using = ".//input[contains(@id,'btnCreate')]")]
        private IWebElement btnCreateGroup { get; set; }

        [FindsBy(How=How.XPath, Using = ".//span[@class='infomessage']" )]
        private IWebElement msgFeedback { get; set; }

        [FindsBy(How=How.XPath, Using = "//div[@class='boxlist']//ul")]
        private IWebElement lstGroupName { get; set; }


        [FindsBy(How=How.XPath, Using = ".//div[contains(@id,'btnApply')]//input[@class='imgBtnStd']")]
        private IWebElement btnApplyChange { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[contains(@id,'btnDelete')]//input[@class='imgBtnStd']")]
        private IWebElement btnDeleteGroup { get; set; }

        [FindsBy(How =How.XPath, Using = ".//div[@class='modalBody']//span[@class='exclaimmessage']")]
        private IWebElement msgPopupMessage { get; set; } 

        [FindsBy(How=How.XPath, Using = ".//div[@class='modalButtons']//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnOKDelete')]")]
        private IWebElement btnConformDelete { get; set; }


        #endregion

        public string ConformBeforeDeleteGroup()
        {
             return GetConformationMessageForDeleteGroup();
        }
        public void DeleteUserGroup(String GroupName)
        {
            ClickOnCreatedGroup(GroupName);
            ClickOnDeleteButtonToDeleteGroup();            
            ClickOnOkToConformDelete();
            Thread.Sleep(3000);
        }

        //Method to create new group
        public void CreateGroup(string GroupName, string Description)
        {
            if(IsGroupExist(GroupName))
            {
                DeleteUserGroup(GroupName);
            }
            EnterGroupName(GroupName);
            EnterGroupDescription(Description);
            ClickOnCreate();
        }
        //method to Modify the group details
        public void ModifyGroupDetails(string GroupName,string Description)
        {
            ClickOnCreatedGroup(GroupName);
            EnterGroupName(GroupName);
            EnterGroupDescription(Description);
            Thread.Sleep(2000);
            SaveChanges();
        }
        //Get conformation message once group is created or deleted
        public string GetConformationFeedback()
        {
            string Feedback = msgFeedback.Text.ToString();
            return Feedback;
        }
        //method to give group name
        public void EnterGroupName(string GroupName)
        {
            txtGroupName.SendKeys(GroupName);

        }
        //method to provide the description for group
        public void EnterGroupDescription(string Description)
        {
            txtDescription.SendKeys(Description);
        }

        //button click to create new group
        public void ClickOnCreate()
        {
            btnCreateGroup.Click();
        }

        //clicking on group name to select the group
        public void ClickOnCreatedGroup(String GroupName)
        {
            IWebElement basegrouplist = lstGroupName;            

            ICollection<IWebElement> list = basegrouplist.FindElements(By.TagName("li"));
            foreach (IWebElement listItem in list)
            {
                if (listItem.Text == GroupName)
                {
                    listItem.Click();
                }
                else
                {
                    continue;
                }
            }
        }

        public bool IsGroupExist(string GroupName)
        {
            IWebElement baseGroup = lstGroupName;
            List<string> GroupList = new List<string>();

            ICollection<IWebElement> list = baseGroup.FindElements(By.TagName("li"));
            foreach (IWebElement listItem in list)
            {
                GroupList.Add(listItem.Text);
            }
            if (GroupList.Contains(GroupName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //click on apply to save the chnages for group details
        public void SaveChanges()
        {
            btnApplyChange.Click();
        }
        //Click on Delete button to delete the existing group
        public void ClickOnDeleteButtonToDeleteGroup()
        {
            btnDeleteGroup.Click();
            
        }

        public string GetConformationMessageForDeleteGroup()
        {
            return msgPopupMessage.Text;
        }
        //Click on Ok button to conform delte
        public void ClickOnOkToConformDelete()
        {
            btnConformDelete.Click();
        }

        
    }
}
