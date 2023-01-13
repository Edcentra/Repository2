using Edwards.Scada.Test.Framework.Contract;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    class SecsGemSimulator
    {
       Window secsGemWindow;
        Window serverManagerWindow;
        ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
        string Txtdata = string.Empty;
        Window RegEditWindow;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWMINIMIZED = 2;

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);



        public void LaunchSecsGemHost()
        {           
            var application = FlaUI.Core.Application.Launch(GlobalConstants.SecsGemClientWindowPath);
            var automation = new UIA3Automation();
            secsGemWindow = application.GetMainWindow(automation);
            Thread.Sleep(5000);
        }
       
        public void ConnectHost()
        {
            secsGemWindow.FindFirstDescendant(cf.ByName("Connection (127.0.0.1/5000) ▾")).AsMenu().Items["Connect"].Invoke();
            Thread.Sleep(1000);
        }

        public void OpenTabUnlock()
        {
            secsGemWindow.FindFirstDescendant(cf.ByAutomationId("pnlUnlock")).WaitUntilClickable(TimeSpan.FromSeconds(20)).Click();
            secsGemWindow.FindFirstDescendant(cf.ByAutomationId("txtPin")).AsTextBox().Enter(GlobalConstants.UnlockPin);
            Thread.Sleep(3000);
            secsGemWindow.FindFirstDescendant(cf.ByAutomationId("btnUnlock")).AsButton().Click();
            Thread.Sleep(3000);
        }

      
        public void SelectCheckBoxs()
        {
            secsGemWindow.FindFirstDescendant(cf.ByName("Activation Row 1")).Click();
            Thread.Sleep(1000);
            secsGemWindow.FindFirstDescendant(cf.ByName("Activation Row 2")).Click();
            Thread.Sleep(1000);
        }

        public void CloseTabUnlock()
        {
            secsGemWindow.FindFirstDescendant(cf.ByAutomationId("btnClose")).AsButton().WaitUntilClickable(TimeSpan.FromSeconds(20)).Click();
            Thread.Sleep(1000);
        }

        public void SelectTab()
        {
            secsGemWindow.FindFirstDescendant(cf.ByAutomationId("tabMainWindow")).FindFirstChild(cf.ByName("SECS/GEM")).Click();
            Thread.Sleep(1000);
        }

        public void SelectQueryMessage(string version, string message)
        {            
            secsGemWindow.FindFirstDescendant(cf.ByName("Query")).AsMenu().Items[version].Items[message].Invoke();
            Thread.Sleep(1000);
        }

        public void SendQuery()
        {
            secsGemWindow.FindFirstDescendant(cf.ByName("Send")).Click();
            Thread.Sleep(1000);
        }

        public string ReadQueyText()
        {
            Txtdata = secsGemWindow.FindFirstDescendant(cf.ByAutomationId("txtResponseData")).AsTextBox().Text;
            Thread.Sleep(1000);
            return Txtdata;
        }

        public string ListCount()
        {
            ReadQueyText();
            var regex = new Regex(string.Format(@"{0}", "<list>"),
                                    RegexOptions.IgnoreCase);
            var lstCntint = regex.Matches(Txtdata).Count;
            string lstCnt = lstCntint.ToString();
            return lstCnt;
        }

        public void RestoreWindow(string windowName = "SECS/GEM Support Host")
        {
            IntPtr hwnd = new IntPtr(0);
            if (windowName.Equals("SECS/GEM Support Host"))
            {
                hwnd = FindWindowByCaption(IntPtr.Zero, GlobalConstants.SecsGemClientWindowName);
            }
            Thread.Sleep(2000);
            ShowWindow(hwnd, SW_RESTORE);
        }

        /// <summary>
        /// Minimize Window
        /// </summary>
        public void MinimizeWindow(string windowName = "SECS/GEM Support Host")
        {
            IntPtr hwnd = new IntPtr(0);
            if (windowName.Equals("SECS/GEM Support Host"))
            {
                hwnd = FindWindowByCaption(IntPtr.Zero, GlobalConstants.SecsGemClientWindowName);
            }
            Thread.Sleep(2000);
            ShowWindow(hwnd, SW_SHOWMINIMIZED);
        }

        public void LaunchRegEdit()
        {
            var application = FlaUI.Core.Application.Launch(GlobalConstants.RegEdit);
            var automation = new UIA3Automation();
             RegEditWindow = application.GetMainWindow(automation);
            Thread.Sleep(5000);
        }

        public void ChangeRegEditValue(string value = "false")
        {
            RegistryKey keyvalue = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Edwards\Scada\SecsGem\Gem", true);
            keyvalue.SetValue("IsSecsGemAgentCompatible", value, RegistryValueKind.String);
            Thread.Sleep(3000);
            RegEditWindow.Close();
        }

        public void KillSecsGemHost()
        {
            secsGemWindow.Close();
        }
            
    }
}
