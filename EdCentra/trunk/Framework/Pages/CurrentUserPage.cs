using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Edwards.Scada.Test.Framework.GlobalHelper;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class CurrentUserPage : PageBase
    {
        private IWebDriver driver;

        public CurrentUserPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }


        //objects for currentuser page
        #region 

        [FindsBy(How = How.XPath, Using = ".//a[text()='Maintain Groups']")]
        private IWebElement lnkMaintainGroup  { get; set; }

        [FindsBy(How=How.XPath , Using = ".//a[text()='Maintain Users']")]
        private IWebElement lnkMaintainUser { get; set; }
        #endregion


        public GroupPage NavigateToGroupPage()
        {
            ClickOnMaintainGroupTab();
            return new GroupPage(driver);
        }

        public void ClickOnMaintainGroupTab()
        {
            lnkMaintainGroup.Click();
        }

        public UserPage NavigateToUserPage()
        {
            ClickOnMaintainUsersTab();
            return new UserPage(driver);
        }

        public void ClickOnMaintainUsersTab()
        {
            lnkMaintainUser.Click();
        }
    }


}
