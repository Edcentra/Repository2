using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    public static class ElementExtensions
    {
        private static SelectElement select;
        private static readonly ILog Logger = LoggerManager.GetLogger(typeof(ElementExtensions));
        private static Random random = new Random();

        /// <summary>
        /// Delete existing file
        /// </summary>
        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
              // If file found, delete it    
              File.Delete(path);
             }
           
         }

        /// <summary>
        /// Extension method to enter text input
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        public static void EnterTextValue(IWebElement element, string text)
        {

            element.SendKeys(text);
           // Logger.Info($"Type text value in Textbox @ {element} : value : {text}");
        }

        /// <summary>
        /// Extension method to clear text values
        /// </summary>
        /// <param name="locator"></param>
        public static void ClearTextValue(IWebElement element)
        {
            element.Clear();
            //Logger.Info($" Clear the Textbox @ {element}");
        }

        /// <summary>
        /// Extension method to click on Button
        /// </summary>
        /// <param name="locator"></param>
        public static void ClickOnButton(IWebElement element)
        {
            element.Click();
            Logger.Info(" Button Click @ " + element);
        }

        /// <summary>
        /// Extension method to check whether button is enabled or not
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static bool IsButtonEnabled(IWebElement element)
        {
           // Logger.Info(" Checking Is Button Enabled ");
            return element.Enabled;
        }

        /// <summary>
        /// Extension method to get button text value
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static string GetButtonTextValue(IWebElement element)
        {
            if (element.GetAttribute("value") == null)
                return string.Empty;
            return element.GetAttribute("value");
        }
        public static string GetLabelTextValue(IWebElement element)
        {
            if (element.Text == null)
                return string.Empty;
            return element.Text;
        }

        /// <summary>
        /// Extension method to check the chekcbox button
        /// </summary>
        /// <param name="locator"></param>
        public static void CheckedCheckBox(IWebElement element)
        {

            element.Click();
            //Logger.Info(" Click on Check box : " + element);
        }

        /// <summary>
        /// Extension method to check whether chekcbox is checked or not
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static bool IsCheckBoxChecked(IWebElement element)
        {

            string flag = element.GetAttribute("checked");
            Logger.Info(" Is CheckBox Checked : " + element);
            if (flag == null)
                return false;
            else
                return flag.Equals("true") || flag.Equals("checked");
        }

        /// <summary>
        /// Extension method to click on radio button
        /// </summary>
        /// <param name="locator"></param>
        public static void ClickOnRadioButton(IWebElement element)
        {

            element.Click();
            Logger.Info(" Click on Radio button : " + element);
        }

        /// <summary>
        /// Extension method to check whether radio is button is selected or not
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static bool IsRadioButtonSelected(IWebElement element)
        {

            string flag = element.GetAttribute("checked");
            Logger.Info(" Is Radio Button Selected : " + element);
            if (flag == null)
                return false;
            else
                return flag.Equals("true") || flag.Equals("checked");

        }

        /// <summary>
        /// Extension method to select the dropdown values by index number
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="index"></param>
        public static void SelectByIndex(IWebElement element, int index)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(index);
            Logger.Info(" Select dropdown option by index : " + element);
        }

        /// <summary>
        /// Extension method to select the dropdown value by visible text values
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="visibletext"></param>
        public static void SelectByText(IWebElement element, string visibletext)
        {
            select = new SelectElement(element);
            select.SelectByText(visibletext);
            Logger.Info(" Select dropdown value by visible text : " + element);
        }

        /// <summary>
        /// Extension method to select dropdown value by value option
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="value"></param>
        public static void SelectByValue(IWebElement element, string value)
        {
            select = new SelectElement(element);
            select.SelectByValue(value);
            Logger.Info(" Select dropdown option by values : " + element);
        }

        public static string GetSelectedDrpdwnText(IWebElement element)
        {
            select = new SelectElement(element);
            return select.SelectedOption.Text;
      }

        /// <summary>
        /// Extension method to select all the dropdown option into list
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static IList<string> GetAllItem(IWebElement element)
        {
            select = new SelectElement(element);
            Logger.Info("Select dropdown list values : " + element);
            return select.Options.Select((x) => x.Text).ToList();

        }

         /// <summary>
        /// Extension method to click on link
        /// </summary>
        /// <param name="Locator"></param>
        public static void ClickOnLink(IWebElement element)
        {
            element.Click();
            Logger.Info(" Clicking on link : " + element);
        }


        /// <summary>
        /// Generates random string
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
               .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Checks element is displayed on UI
        /// </summary>
        /// <param name="webElement"></param>
        /// <returns></returns>
        public static bool isDisplayed(IWebDriver driver, IWebElement webElement)
        {
            bool flag = false;
            try
            {
                JavaScriptExecutor.JavaScriptScrollToElement(driver, webElement);
                flag = webElement.Displayed;

            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Exception Caught " + ex.Message);
            }
            return flag;
        }

        /// <summary>
        /// Generates random string
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomAlphabeticalString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
               .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Mouse hover on element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static void MouseHover(IWebDriver driver, IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
        }

        /// <summary>
        /// Paste short cut
        /// </summary>
        /// <param name="driver"></param>
        public static void PasteShortCut(IWebDriver driver)
        {
            Actions paste = new Actions(driver);
            paste.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control);
            paste.Perform();
        }

        /// <summary>
        /// Copy short cut
        /// </summary>
        /// <param name="driver"></param>
        public static void CopyShortCut(IWebDriver driver)
        {
            Actions cut = new Actions(driver);
            cut.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control);
            cut.Perform();
        }


        /// <summary>
        /// Right Click on Element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static void RightClick(IWebDriver driver, IWebElement element)
        {
            Actions action = new Actions(driver);
            action.ContextClick(element).Perform();
        }

        public static void DoubleClick(IWebDriver driver, IWebElement element)
        {
            Actions action = new Actions(driver);
            action.DoubleClick(element).Perform();
        }

        /// <summary>
        /// Verify value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static bool VerifyText(IWebDriver driver, IWebElement element, string value)
        {
            bool flag = false;

            for (int i = 1; i < 90; i++)
            {
                Waits.Wait(driver, 1000);
                if (element.Text.Contains(value))
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                    continue;
                }
            }
            return flag;
        }

        /// <summary>
        /// Verify value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static bool VerifyAttributeValue(IWebDriver driver, IWebElement element, string value)
        {
            bool flag = false;

            for (int i = 1; i < 90; i++)
            {
                Waits.Wait(driver, 1000);
                if (element.GetAttribute("value").Contains(value))
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                    continue;
                }
            }
            return flag;
        }

        /// <summary>
        /// Verify CSS value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static bool VerifyBackgroundColor(IWebDriver driver, IWebElement element, string value)
        {
            bool flag = false;

            for (int i = 1; i < 90; i++)
            {
                Waits.Wait(driver, 1000);
                if (element.GetCssValue("background-color").Contains(value))
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                    continue;
                }
            }
            return flag;
        }

        /// <summary>
        /// Verify value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static bool VerifyAttributeSRCValue(IWebDriver driver, IWebElement element, string value)
        {
            bool flag = false;

            for (int i = 1; i < 30; i++)
            {
                Waits.Wait(driver, 1000);
                if (element.GetAttribute("src").Contains(value))
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                    continue;
                }
            }
            return flag;
        }        
    }
}
