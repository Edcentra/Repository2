using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;


namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    //Namespaces

    public class PageBase
    {
        private IWebDriver driver;

        /// <summary>
        /// Ctor for Initializing the page
        /// </summary>
        /// <param name="driver"></param>
        protected PageBase(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
     
        /// <summary>
        /// Wait methods for webelements and pages
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return true;
                return false;
            });
        }

        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;
            });
        }
        ////MEthod to wait for webdrivers
        //public static WebDriverWait GetWebdriverWait(TimeSpan timeout)
        //{
        //    ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        //    WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout)
        //    {
        //        PollingInterval = TimeSpan.FromMilliseconds(500),
        //    };
        //    wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
        //    return wait;

        //}
        //method to check if element is present on webpage or not
        public static bool IsElemetPresent(IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
        public static IWebElement GetElement(IWebDriver driver, By locator)
        {
            if (IsElemetPresent(driver,locator))
                return driver.FindElement(locator);
            else
                throw new NoSuchElementException("Element Not Found : " + locator.ToString());
        }
       
    }
}
