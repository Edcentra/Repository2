using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{

    //name spaces
    using Edwards.Scada.Test.Framework.Contract;

    public class JavaScriptPopupHelper
    {

        public static bool IsAlertPresent()
        {
            
            try
            {
                ObjectRepository.Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public static string GetAlertText()
        {
            if (!IsAlertPresent())
                return "";
             return ObjectRepository.Driver.SwitchTo().Alert().Text;
        }

        public static void ClickOkOnAlert()
        {
            if (!IsAlertPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().Accept();
        }

        public static void ClickCancelOnAlert()
        {
            if (!IsAlertPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().Dismiss();
        }

        public static void SendKeys(string text)
        {
            if (!IsAlertPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().SendKeys(text);
        }
    }
}
