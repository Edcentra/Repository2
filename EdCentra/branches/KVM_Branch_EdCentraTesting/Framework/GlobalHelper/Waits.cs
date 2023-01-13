using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras;
using OpenQA.Selenium.Support.UI;


namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    public static class Waits
    {
        /// <summary>
        /// Implicit Wait
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="time"></param>
        public static void ImplicitWait(IWebDriver driver, double time)
        {
             driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(time);
        }

        /// <summary>
        /// Make webdriver to wait
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="miliseconds"></param>
        /// <param name="maxTimeOutSeconds"></param>
        public static void Wait(IWebDriver driver, int miliseconds, int maxTimeOutSeconds = 90)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, maxTimeOutSeconds));
            var delay = new TimeSpan(0, 0, 0, 0, miliseconds);
            var timestamp = DateTime.Now;
            wait.Until(webDriver => (DateTime.Now - timestamp) > delay);
        }

        /// <summary>
        /// wait Till Element is clicked
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static void WaitTillElementisclicked(IWebDriver driver, IWebElement element)
        {
            try
            {
                int timeoutInSeconds = 120;
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element)).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught" + ex.Message);

            }
        }

        /// <summary>
        /// Wait Until Page Loaded
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="time"></param>
        public static void WaitUntilPageLoaded(IWebDriver driver, int time)
        {
            driver.Manage().Timeouts().PageLoad= TimeSpan.FromMinutes(time);
        }
        
        /// <summary>
        /// wait Till Element is Displayed
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static void WaitUntillImageIsSelected(IWebDriver driver, IWebElement element)
        {
            int timeoutInSeconds = 90;
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                try
                {
                    if (timeoutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                        wait.Until(drv => element);

                        if (element.Displayed)
                        {
                            element.Click();
                            Wait(driver, 1000);
                            if (element.GetAttribute("src").Contains("on"))
                            {
                                break;
                            }
                            continue;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught" + ex.Message);

                }
            }
        }


        /// <summary>
        /// wait Till Element is clickable
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static void WaitTillElementIsClickable(IWebDriver driver, IWebElement element)
        {
            int timeoutInSeconds = 90;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element)).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught" + ex.Message);

            }
        
        }

        public static bool WaitTillElementDisplayed(IWebDriver driver, IWebElement element)
        {
            bool flag = false;
            for (int i = 1; i <= 120; i++)
            {
                if (ElementExtensions.isDisplayed(driver, element))
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
        /// Waits and Click
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="webelement"></param>
        public static bool WaitAndClick(this IWebDriver driver, IWebElement webelement)
        {
            bool flag = false;
           
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webelement)).Click();
                    flag = true;    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Element not visible" + webelement);
                    flag = false;
                }
           
                return flag;
           
        }


        /// <summary>
        /// Wait For Element Visible
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="webelement"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool WaitForElementVisible(this IWebDriver driver, IWebElement webelement, int timeout = 120)
        {
            bool flag = false;
            var fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            fluentWait.Until(webDriver =>
            {
                try
                {
                    flag = webelement.Displayed;
                    Waits.Wait(driver, 2000);
                    Wait(driver, 2000);
                }
                catch (Exception ex)
                {
                    if (ex is TargetInvocationException ||
                        ex is NoSuchElementException ||
                        ex is InvalidOperationException ||
                        ex is TargetInvocationException ||
                        ex is StaleElementReferenceException)
                    {
                        Console.WriteLine("Element not visible " + webelement);
                        return false; //By returning false, wait will still rerun the func.
                    }
                }
                return true;
            });
            return flag;
        }
    }
    
}
