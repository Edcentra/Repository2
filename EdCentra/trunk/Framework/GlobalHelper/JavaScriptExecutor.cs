using System;
using System.Threading;
using Edwards.Scada.Test.Framework.Contract;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{

    public static class JavaScriptExecutor
    {

        public static object ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            return executor.ExecuteScript(script);
        }
        public static void ScrollToAndClick(IWebElement element)
        {
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(30);
            element.Click();
        }

        public static void ScrollToAndClick(IWebDriver driver, By locator)
        {
            IWebElement element = PageBase.GetElement(driver, locator);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(30);
            element.Click();
        }
        public static void JavaScriptClick(IWebDriver driver, IWebElement element)
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].click();", element);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught " + ex.Message);
            }
        }

        public static void JavaScriptScrollToElement(IWebDriver driver, IWebElement element)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", element);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught " + ex.Message);
            }
        }

        /// <summary>
        /// To Click Link 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static void JavaScriptLinkClick(IWebDriver driver, IWebElement element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(110));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].setAttribute('target','_self')", element);
                Thread.Sleep(30);
                executor.ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught " + ex.Message);
            }
        }

    }
}
