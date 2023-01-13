using Edwards.Scada.Test.Framework.Contract;
using FlaUI.UIA3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WPFUIItems;
using TestStack.White.WindowsAPI;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    public class Simulator
    {
        Application application;
        Window AgentWin;
        Window simulatorWindow;
        Window codeGeneratorWindow;
        Window scadaDSPUWindow;
        Window agentConfiguration;
        Window eula;
        Window swapoutGeneratorWindow;
        Window sqlWindow;
        Window ModbussimulatorWindow;
        Window secsGemClientWindow;
        Window loginCDIWindow;
        Window cmdWindow;
        Window scadaagetframework;
        static int pid;
        static Process process;
        Application applicationCDI;

        private const int SW_RESTORE = 9;
        private const int SW_SHOWMINIMIZED = 2;

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        /// <summary>
        /// Restores window
        /// </summary>
        public void RestoreWindow(string windowName = "EISSA")
        {
            IntPtr hwnd = new IntPtr(0);
            if (windowName.Equals("EISSA"))
            {
                hwnd = FindWindowByCaption(IntPtr.Zero, GlobalConstants.EissaWindowName);
            }
            else if (windowName.Equals("TURBO"))
            {
                hwnd = FindWindowByCaption(IntPtr.Zero, GlobalConstants.TurboWindow);
            }
            else if(windowName.Equals("Modbus"))
            {
                hwnd = FindWindowByCaption(IntPtr.Zero, GlobalConstants.ModbusWindowName);
            }
            else if (windowName.Equals("VISim"))
            {
                hwnd = FindWindowByCaption(IntPtr.Zero, GlobalConstants.ViSimulatorWindow);
            }
            Thread.Sleep(2000);
            ShowWindow(hwnd, SW_RESTORE);
        }

        /// <summary>
        /// Minimize Window
        /// </summary>
        public void MinimizeWindow(string windowName = "EISSA")
        {
            IntPtr hwnd = new IntPtr(0);
            if (windowName.Equals("EISSA"))
            {
                hwnd = FindWindowByCaption(IntPtr.Zero, GlobalConstants.EissaWindowName);
            }
            else if (windowName.Equals("TURBO"))
            {
                hwnd = FindWindowByCaption(IntPtr.Zero, GlobalConstants.TurboWindow);
            }
            else if (windowName.Equals("Modbus"))
            {
                hwnd = FindWindowByCaption(IntPtr.Zero, GlobalConstants.ModbusWindow);
            }
            else if (windowName.Equals("VISim"))
            {
                hwnd = FindWindowByCaption(IntPtr.Zero, GlobalConstants.ViSimulatorWindow);
            }
            Thread.Sleep(2000);
            ShowWindow(hwnd, SW_SHOWMINIMIZED);
        }

        /// <summary>
        /// Launches simulator
        /// </summary>
        public void LaunchSimulator(string equipmentType = "eZenith")
        {
            application = Application.Launch(GlobalConstants.EissaWindowPath);
            Thread.Sleep(2000);
            TechTalk.SpecFlow.ScenarioContext.Current.Add("Application", application);
            Thread.Sleep(1000);
            process = application.Process;
            pid = process.Id;
            simulatorWindow = application.GetWindow("EISSA");
            simulatorWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("comboBoxType")).Click();
            Thread.Sleep(1000);
            simulatorWindow.Get(SearchCriteria.ByText(equipmentType)).Click();
            Thread.Sleep(2000);

        }
        public void LaunchSimulatorinWinPro(string equipmentType = "eZenith")
        {
            application = Application.Launch(GlobalConstants.EissaWinProPath);
            Thread.Sleep(2000);
            TechTalk.SpecFlow.ScenarioContext.Current.Add("Application", application);
            Thread.Sleep(1000);
            process = application.Process;
            pid = process.Id;
            simulatorWindow = application.GetWindow("EISSA");
            simulatorWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("comboBoxType")).Click();
            Thread.Sleep(1000);
            simulatorWindow.Get(SearchCriteria.ByText(equipmentType)).Click();
            Thread.Sleep(2000);

        }


        public void KillEISSASimulator()
        {
            List<Window> windowList = Desktop.Instance.Windows();
            foreach (var win in windowList)
            {
                if (win.Name.Equals("EISSA"))
                {
                    win.Close();
                    Thread.Sleep(10000);
                }
            }
        }

        /// <summary>
        /// Get Autopager Text
        /// </summary>
        public string GetAutopagerText()
        {
            bool flag = false;
            string text = string.Empty;
            Thread.Sleep(5000);
            for (int i = 0; i <= 5; i++)
            {
                if (flag)
                {
                    break;
                }
                Helper.OpenAutopagerConsole();
                Thread.Sleep(4000);
                List<Window> windowList = Desktop.Instance.Windows();
                foreach (var win in windowList)
                {
                    if (win.Name.Equals("Autopager Console -- Running") || win.Name.Equals("Autopager Console -- Paused"))
                    {
                        flag = true;
                        text = win.Get<TextBox>(SearchCriteria.ByAutomationId("LogFileContents")).Text;
                        //win.Get(SearchCriteria.ByText("Close")).Click();
                        break;
                    }
                }
            }
            return text;
        }

        /// <summary>
        /// Close Autopager Window
        /// </summary>
        public void CloseAutoPager()
        {
            Thread.Sleep(1000);
            List<Window> windowList = Desktop.Instance.Windows();
            foreach (var win in windowList)
            {
                if (win.Name.Equals("Autopager Console -- Running") || win.Name.Equals("Autopager Console -- Paused"))
                {
                    win.Get(SearchCriteria.ByText("Close")).Click();
                }
            }
        }

        /// <summary>
        /// Get Assembly directory path
        /// </summary>
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }


        /// <summary>
        /// Launches Agent
        /// </summary>
        public void LaunchAgent()
        {
            string path = string.Empty;
            string dir = string.Empty;
            Directory.SetCurrentDirectory(@"D:\Edwards");
            dir = Directory.GetCurrentDirectory();
            path = Path.Combine(dir, @"Scada\Agent Service\Edwards.Scada.AgentFrameworkConfig.exe");
            application = Application.Launch(path);
            process = application.Process;
            pid = process.Id;
            agentConfiguration = application.GetWindow("Agent Configuration");
        }
        public void LaunchAgentonWinPro()
        {
            string path = string.Empty;
            string dir = string.Empty;
            Directory.SetCurrentDirectory(@"C:\Program Files (x86)\Edwards");
            dir = Directory.GetCurrentDirectory();
            path = Path.Combine(dir, @"Agent Service\Edwards.Scada.AgentFrameworkConfig.exe");
            application = Application.Launch(path);
            process = application.Process;
          process.StartInfo.RedirectStandardOutput = true;
           pid = process.Id;
         List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
                if (win.Name.Equals("Agent Configuration"))
                {
                    AgentWin = win;
                    Thread.Sleep(2000);
                }
            }
       //    AgentWin = application.GetWindow("Agent Configuration");
        }


        /// <summary>
        /// Set Pin to Unlock Agent Configuration
        /// </summary>
        /// <param name="pin"></param>
        public void SetPin(int pin)
        {
            List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
                {
                    AgentWin = win;
                  Thread.Sleep(2000);
                    var file = AgentWin.MenuBar;
                   string[] filepath = { "File", "Admin Mode" };

                    Thread.Sleep(1000);
                    file.MenuItem(filepath).Click();
              
                    Thread.Sleep(15000);
                    AgentWin.Get(SearchCriteria.ByAutomationId("textBoxPIN")).Enter(Convert.ToString(pin));
                    Thread.Sleep(1000);
                }
            }
           
            Thread.Sleep(1000);
            //  if(AgentWin == null)
             //  AgentWin = application.GetWindow("Agent Configuration");
            
        }

        /// <summary>
        /// Launches Agent
        /// </summary>
        public void StartRemoteConnection()
        {

            application = Application.Launch(GlobalConstants.RemoteDesktopPath);
            process = application.Process;
            pid = process.Id;
            Thread.Sleep(5000);
            List<Window> winList1 = Desktop.Instance.Windows();
            foreach (var win1 in winList1)
            {
                if (win1.Name.Equals("Remote Desktop Connection"))
                {
                    win1.Get(SearchCriteria.ByText("Computer:")).SetValue("10.91.26.176");
                    Thread.Sleep(60000);
                    win1.Get(SearchCriteria.ByText("Connect")).Click();
                    Thread.Sleep(70000);
                    break;
                }
            }
        }

        /// <summary>
        /// Enter Space
        /// </summary>
        public void EnterSpace()
        {
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
        }

        /// <summary>
        /// Enter Server Details
        /// </summary>
        /// <param name="serverName"></param>
        public void EnterServerDetails()
        {
            agentConfiguration.Get(SearchCriteria.ByAutomationId("optSvrLocal")).Click();
            Thread.Sleep(3000);            
        }

        public void EnterSplitServerDetails(string agentName ,string serverName)
        {
            agentConfiguration.Get(SearchCriteria.ByAutomationId("txtAgentName")).SetValue(agentName);
            Thread.Sleep(1000);
            agentConfiguration.Get(SearchCriteria.ByAutomationId("optSvrRemote")).Click();
            Thread.Sleep(1000);
            agentConfiguration.Get(SearchCriteria.ByAutomationId("txtSvrAddress")).SetValue(serverName);
            Thread.Sleep(1000);
            agentConfiguration.Get(SearchCriteria.ByAutomationId("btnLookupIP")).Click();
            Thread.Sleep(1000);            
            agentConfiguration.Get(SearchCriteria.ByAutomationId("btnSvrSelect")).Click();
            Thread.Sleep(1000);            
            //////if (agentConfiguration.Get(SearchCriteria.ByAutomationId("btnApply")).Visible)
            //////{
            //////    agentConfiguration.Get(SearchCriteria.ByAutomationId("btnApply")).Click();
            //////    Thread.Sleep(1000);
            //////}            
        }

        ///// <summary>
        ///// Enable the Agent Option
        ///// </summary>
        ///// <param name="agentName"></param>
        ///// <param name="networkCard"></param>
        ///// <param name="netName"></param>
        ///// <param name="hostName"></param>
        //public void AgentOptionStatus(string agentName, string networkCard, string netName , string hostName)
        //{
        //    Thread.Sleep(1000);
        //    UpdatedAgent(agentName);
        //    Thread.Sleep(1000);
        //    SelectPCNetworkInterfaceCard(networkCard);            
        //    Thread.Sleep(80000);
         //   CheckAgentsUnderNetworkTab(netName, hostName);
        //    Thread.Sleep(1000);
        //}

        /// <summary>
        /// Select PC Network Interface Card
        /// </summary>
        /// <param name="networkCard"></param>
        public void SelectPCNetworkInterfaceCard()
        {
            Thread.Sleep(5000);
            agentConfiguration.Get(SearchCriteria.ByText("Relay")).DoubleClick();
            Thread.Sleep(3000);
            agentConfiguration.Get(SearchCriteria.ByAutomationId("cmbNIC")).Click();
            Thread.Sleep(5000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.PAGEUP);
            Thread.Sleep(2000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.PAGEDOWN);
            Thread.Sleep(2000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            //agentConfiguration.Get(SearchCriteria.ByText(networkCard)).Click();
            Thread.Sleep(2000);
            agentConfiguration.Get(SearchCriteria.ByText("Apply")).Click();
            if (agentConfiguration.Get(SearchCriteria.ByText("Yes")).Visible)
            {
                agentConfiguration.Get(SearchCriteria.ByText("Yes")).Click();
            }
        }

         /// <summary>
        /// Add Agent
        /// </summary>
        /// <param name="agentName"></param>
        public void UpdatedAgent(string agentName)
        {
            Thread.Sleep(3000);
            if(agentConfiguration==null)
                agentConfiguration = application.GetWindow("Agent Configuration");
            agentConfiguration.Get(SearchCriteria.ByText("Agents")).Click();
            Thread.Sleep(3000);
            if (agentName.Equals("Turbo"))
            {
                agentConfiguration.Get(SearchCriteria.ByText("Turbo Molecular Pumps")).DoubleClick();
            }
            else if (agentName.Equals("Web"))
            {
                agentConfiguration.Get(SearchCriteria.ByText("Web")).DoubleClick();
            }
            else if (agentName.Equals("Modbus"))
            {
                agentConfiguration.Get(SearchCriteria.ByText("Modbus")).DoubleClick();
            }
            else if (agentName.Equals("MQTT"))
            {
                agentConfiguration.Get(SearchCriteria.ByText("MQTT")).DoubleClick();
            }
            Thread.Sleep(2000);
            var EnableChckbox = agentConfiguration.Get<CheckBox>(SearchCriteria.ByAutomationId("chkEnabled"));
            Thread.Sleep(1000);
            if (!EnableChckbox.IsSelected)
            {
                Thread.Sleep(1000);
                agentConfiguration.Get(SearchCriteria.ByAutomationId("chkEnabled")).Click();
                Thread.Sleep(1000);
                agentConfiguration.Get(SearchCriteria.ByText("Apply")).Click();
                Thread.Sleep(2000);
            }
            agentConfiguration.Get(SearchCriteria.ByAutomationId("btnOK")).Click();
            Thread.Sleep(4000);
        }

        ///// <summary>
        ///// Check added Agents under Network Tab
        ///// </summary>
        //public void CheckAgentsUnderNetworkTab(string agentName ,string hostName)
        //{
        //    Thread.Sleep(2000);
        //    agentConfiguration.Get(SearchCriteria.ByText("Networks")).Click();
        //    Thread.Sleep(2000);
        //    if (agentName.Equals("Web"))
        //    {
        //        agentConfiguration.Get(SearchCriteria.ByText("NET_" + hostName.ToUpper() + "_WEB")).Click();
        //        Thread.Sleep(1000);
        //    }
        //    if (agentName.Equals("Turbo"))
        //    {
        //        agentConfiguration.Get(SearchCriteria.ByText("NET_" + hostName.ToUpper() + "_TMP")).Click();
        //        Thread.Sleep(1000);
        //    }
        //    if (agentName.Equals("Modbus"))
        //    {
        //        agentConfiguration.Get(SearchCriteria.ByText("NET_" + hostName.ToUpper() + "_MODBUS")).Click();
        //        Thread.Sleep(1000);
        //    }

        //}

        /// <summary>
        /// Launches Edcentra Installer
        /// </summary>
        public void LaunchEdcentraInstaller()
        {
            string path = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\..\..\..\..\"));
            path = Path.Combine(path, "Build");
            Directory.SetCurrentDirectory(path);
            path = Path.Combine(path, "Setup.exe");
            //path = Path.Combine(path, "Edwards.Installer.Launcher.exe");
            application = Application.Launch(path);
            process = application.Process;
            pid = process.Id;
            eula = application.GetWindow("EULA");
        }


        public void LaunchStandAloneAgentInstaller()
        {
            string path = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\..\..\..\..\"));
            path = Path.Combine(path, "Build");
            Directory.SetCurrentDirectory(path);
            path = Path.Combine(path, "Installer");
            path = Path.Combine(path, "Standalone Agent Setup");
            application = Application.Launch(path);
          /*  process = application.Process;
            pid = process.Id;
            List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
                if (win.Name.Equals("Scada Agent Framework Setup"))
                {
                    Thread.Sleep(1000);
                    WaitForInstallation();
                }
            }
         //   scadaagetframework = application.GetWindow("Scada Agent Framework Setup");
       */
   }

        public void WaitForInstallation()
        {
            bool flag = false;
            try
            {
                for (int i = 0; i <= 60; i++)
                {
                    if (flag == true)
                    {
                        break;
                    }
                    List<Window> winList = Desktop.Instance.Windows();
                    foreach (var win in winList)
                    {
                        if (win.Name.Equals("Scada Agent Framework"))
                        {
                            flag = true;
                          //  win.Get(SearchCriteria.ByAutomationId("1")).Click();
                          //  break;
                        }
                     
                        else
                        {
                            Thread.Sleep(5000);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Assert.Fail("Failed", ex.Message);
            }
        }
        public void LaunchStandaloneAgent()
        {
            //C:\Program Files (x86)\Edwards\Agent Service
            string path = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\..\..\..\..\"));
            path = Path.Combine(path, "Program Files (x86)");
            Directory.SetCurrentDirectory(path);
            path = Path.Combine(path, "Edwards");
            path = Path.Combine(path, "Agent Service");
            path = Path.Combine(path, "Edwards.Scada.AgentFrameworkConfig");
            application = Application.Launch(path);
            process = application.Process;
            pid = process.Id;
            agentConfiguration = application.GetWindow("Agent Configuration");
        }


        /// <summary>
        /// Launches Turbo Simulator
        /// </summary>
        public void LaunchTurboWindow()
        {
            application = Application.Launch(GlobalConstants.TurboWindow);
            process = application.Process;
            pid = process.Id;
            simulatorWindow = application.GetWindow(SearchCriteria.ByClassName("ConsoleWindowClass"), InitializeOption.NoCache);
            Keyboard.Instance.Enter(GlobalConstants.FirstPortTurbo);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Keyboard.Instance.Enter(GlobalConstants.LastPortTurbo);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Launches will default start VISimulator
        /// </summary>
        public void LaunchandStartVISimulator()
        {
            application = Application.Launch(GlobalConstants.ViSimulatorWindow);
            process = application.Process;
            process.StartInfo.RedirectStandardOutput = true;
            pid = process.Id;
            Thread.Sleep(2000);
            List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
                if (win.Name.Equals(GlobalConstants.ViSimulatorWindow))
                {
                    simulatorWindow = win;
                    Thread.Sleep(2000);
                }
            }
            //simulatorWindow = application.GetWindows().FirstOrDefault(w => w.Name == GlobalConstants.ViSimulatorWindow);
            //simulatorWindow = application.GetWindow(GlobalConstants.ViSimulatorWindow, InitializeOption.NoCache);// SearchCriteria.ByAutomationId("TitleBar"), InitializeOption.NoCache);
            Thread.Sleep(2000);
            Keyboard.Instance.Enter(GlobalConstants.ViSimulatorStartUp);
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            
            Thread.Sleep(2000);

            ////Press 2 and wait for 30 secs 
            //Thread.Sleep(2000);
            //Keyboard.Instance.Enter("2");
            //Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            //Thread.Sleep(30000);
            //Keyboard.Instance.Enter("2");
            //Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            //string output = process.StandardOutput.ReadToEnd();
            //Thread.Sleep(1000);

        }

        /// <summary>
        /// Launches Modbus Simulator
        /// </summary>
        /// <param name="portNumber"></param>
        public void LaunchModbusWindow(string portNumber)
        {
            application = Application.Launch(GlobalConstants.ModbusWindow);
            process = application.Process;
            pid = process.Id;
            ModbussimulatorWindow = application.GetWindow("EasyModbusTCP Server Simulator");
            var NumPort = ModbussimulatorWindow.Get(SearchCriteria.ByAutomationId("numPorts"));
            NumPort.Click();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE);
            Keyboard.Instance.Enter(portNumber);
            ModbussimulatorWindow.Get(SearchCriteria.ByAutomationId("buttonStart")).Click();
        }

        /// <summary>
        /// Click down arrow button in Edcentra installer
        /// </summary>
        public void ClickDownArrowEdcentraInstaller()
        {
            eula.Get(SearchCriteria.ByAutomationId("rtbEula")).Click();

            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            for (int i = 0; i <= 15; i++)
            {
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.PAGEDOWN);
            }
            Thread.Sleep(6000);
        }

        /// <summary>
        /// Select Server to install Single server installation
        /// </summary>
        public void SelectServerToInstallSingleServerApplication()
        {
            List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
               if (win.Name.Equals("Welcome to the Edwards Scada Installer"))
                {
                    win.Get(SearchCriteria.ByAutomationId("pictureBoxAgent")).Click();
                    Thread.Sleep(2000);
                    win.Get(SearchCriteria.ByAutomationId("pictureBoxApp")).Click();
                    Thread.Sleep(2000);
                    win.Get(SearchCriteria.ByAutomationId("pictureBoxDB")).Click();
                    Thread.Sleep(2000);
                    win.Get(SearchCriteria.ByAutomationId("buttonInstall")).Click();
                    Thread.Sleep(150000);
                    HandleSqlServerDialog();
                    SelectDVDDrive();
                    Thread.Sleep(50000);
                    //ClickYesInScadaDatabaseSetUp();

                    ClickOkInInformationDialog();
                }
            }
        }

        /// <summary>
        /// Clicks Ok button in Information Dialog
        /// </summary>
        public void HandleSqlServerDialog()
        {
            bool flag = false;
            try
            {
                for (int i = 0; i <= 60; i++)
                {
                    if (flag == true)
                    {
                        break;
                    }
                    List<Window> winList = Desktop.Instance.Windows();
                    foreach (var win in winList)
                    {
                        if (win.Name.Equals("SQL Server 2016 Setup"))
                        {
                            flag = true;
                            win.Get(SearchCriteria.ByAutomationId("1")).Click();
                            break;
                        }
                        else
                        {
                            Thread.Sleep(5000);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Assert.Fail("Failed", ex.Message);
            }
        }        

        /// <summary>
        /// Handle DotNet Framwork PopUp
        /// </summary>
        public void HandleDotNetFramworkPopUp()
        {
            bool flag = false;
            try
            {
                for (int i = 0; i <= 60; i++)
                {
                    if (flag == true)
                    {
                        break;
                    }
                    List<Window> winList = Desktop.Instance.Windows();
                    foreach (var win in winList)
                    {
                        if (win.Name.Equals("Microsoft .NET Framework"))
                        {
                            flag = true;
                            win.Get(SearchCriteria.ByAutomationId("104")).Click();
                            Thread.Sleep(1000);
                            win.Get(SearchCriteria.ByAutomationId("12324")).Click();
                            Thread.Sleep(40000);
                            break;
                        }
                        else
                        {
                            Thread.Sleep(5000);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Assert.Fail("Failed", ex.Message);
            }
        }

        /// <summary>
        /// Install DotNetFramework
        /// </summary>
        public void InstallDotNetFramework()
        {
            bool flag = false;
            try
            {
                List<Window> winList = Desktop.Instance.Windows();
                foreach (var win in winList)
                {
                    if (win.Name.Equals("Microsoft .NET Framework"))
                    {
                        for (int i = 0; i <= 120; i++)
                        {
                            if (flag == true)
                            {
                                break;
                            }

                            try
                            {
                                bool res = win.Get(SearchCriteria.ByText("Cancel")).Visible;
                                if (res == true)
                                {
                                    Thread.Sleep(5000);
                                }
                            }
                            catch (Exception ex)
                            {
                                if (win.Get(SearchCriteria.ByText("Finish")).Visible)
                                {
                                    win.Get(SearchCriteria.ByText("Finish")).Click();
                                    Thread.Sleep(10000);
                                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

                                    List<Window> windowList = Desktop.Instance.Windows();
                                    foreach (var w in windowList)
                                    {
                                        if (w.Name.Equals("Microsoft .NET Framework"))
                                        {
                                            w.Get(SearchCriteria.ByAutomationId("102")).Click();
                                            flag = true;
                                            break;
                                        }
                                    }

                                }

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Failed", ex.Message);
            }

        }

        /// <summary>
        /// Selectes DVD Drive
        /// </summary>
        public void SelectDVDDrive()
        {
            bool flag = false;
            try
            {
                for (int i = 0; i <= 15; i++)
                {
                    if (flag == true)
                    {
                        break;
                    }
                    List<Window> updatedWinList = Desktop.Instance.Windows();
                    foreach (var window in updatedWinList)
                    {
                        if (window.Name.Equals("Select DVD drive"))
                        {
                            flag = true;
                            window.Get(SearchCriteria.ByClassName("ComboBox")).Click();
                            // window.Get(SearchCriteria.ByClassName("ComboBox")).SetValue("h");
                            // Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.END);
                            Thread.Sleep(3000);
                            for (int j = 1; j <= 5; j++)
                            {
                                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);

                            }
                            Thread.Sleep(10000);
                            window.Get(SearchCriteria.ByAutomationId("10")).Click();
                            Thread.Sleep(5000);
                            break;
                        }
                        else
                        {
                            Thread.Sleep(2000);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Failed", ex.Message);
            }

        }

        /// <summary>
        /// Clicks Ok button in Information Dialog
        /// </summary>
        public void ClickOkInInformationDialog()
        {
            bool flag = false;
            try
            {
                for (int i = 0; i <= 500; i++)
                {

                    if (flag == true)
                    {
                        break;
                    }
                    List<Window> winList = Desktop.Instance.Windows();
                    foreach (var win in winList)
                    {

                        try
                        {
                            if (win.Name.Equals("Information"))
                            {
                                flag = true;
                                win.Get(SearchCriteria.ByAutomationId("2")).Click();
                                break;
                            }
                            else
                            {
                                Thread.Sleep(10000);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Failed", ex.Message);
            }
        }


        ///// <summary>
        ///// Clicks Ok button in Information Dialog
        ///// </summary>
        //public void ClickYesInScadaDatabaseSetUp()
        //{
        //    for (int i = 0; i <= 50; i++)
        //    {
        //        try
        //        {
        //            List<Window> winList = Desktop.Instance.Windows();
        //            foreach (var win in winList)
        //            {
        //                if (win.Name.Equals("Scada Database Set-up"))
        //                {
        //                    win.Get(SearchCriteria.ByAutomationId("6")).Click();
        //                    Thread.Sleep(2000);
        //                    break;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ClickYesInScadaDatabaseSetUp();
        //        }
        //    }
        //}

        /// <summary>
        /// Click I Accept button
        /// </summary>
        public void ClickIAcceptButton()
        {
            eula.Get(SearchCriteria.ByAutomationId("btnAccept")).Click();
            Thread.Sleep(12000);
        }

        /// <summary>
        /// Launch code generator and return superuser code
        /// </summary>
        public string SuperuserCodeGenerator(string code)
        {
            string returnCode = string.Empty;
            application = Application.Launch(GlobalConstants.CodeGeneratorSuperUser);
            process = application.Process;
            codeGeneratorWindow = application.GetWindow(SearchCriteria.ByText("Scada Activation Code Generator"), InitializeOption.NoCache);
            codeGeneratorWindow.Get(SearchCriteria.ByAutomationId("textBoxCode1")).SetValue(code);
            Thread.Sleep(1000);
            codeGeneratorWindow.Get(SearchCriteria.ByAutomationId("buttonGetPin")).Click();
            Thread.Sleep(1000);
            //Copy the generated code
            returnCode = codeGeneratorWindow.Get(SearchCriteria.ByAutomationId("labelPin")).Name;
            Thread.Sleep(1000);
            codeGeneratorWindow.Get(SearchCriteria.ByAutomationId("btnClose")).Click();
            Thread.Sleep(1000);
            //close code generator
            codeGeneratorWindow.Get(SearchCriteria.ByAutomationId("Close")).Click();
            return returnCode;
        }

        /// <summary>
        /// Launches Turbo Simulator
        /// </summary>
        public void LaunchCodeGenerator()
        {
            application = Application.Launch(GlobalConstants.CodeGeneratorPath);
            process = application.Process;
            codeGeneratorWindow = application.GetWindow(SearchCriteria.ByText("Scada Activation Code Generator"), InitializeOption.NoCache);
        }

        /// <summary>
        /// Enter Customer Activation Code
        /// </summary>
        /// <param name="code"></param>
        public void EnterCustomerActivationCode(string code)
        {
            codeGeneratorWindow.Get(SearchCriteria.ByAutomationId("textBoxCode1")).SetValue(code);
        }

       
        /// <summary>
        /// Set Device Limit
        /// </summary>
        /// <param name="limit"></param>
        public void DeviceLimit(string limit)
        {
            codeGeneratorWindow.Get(SearchCriteria.ByAutomationId("textBoxDeviceLimit")).SetValue(limit);
        }

        /// <summary>
        /// Select App To License
        /// </summary>
        /// <param name="appName"></param>
        public void SelectAppToLicense(string appName)
        {
            codeGeneratorWindow.Get(SearchCriteria.ByAutomationId("comboBoxMainApp")).Click();
            Thread.Sleep(1000);
            codeGeneratorWindow.Get(SearchCriteria.ByText(appName)).Click();
        }

        /// <summary>
        /// Copy To Clipboard
        /// </summary>
        public void CopyToClipboard()
        {
            codeGeneratorWindow.Get(SearchCriteria.ByText("Copy to Clipboard")).Click();
        }

        /// <summary>
        /// Minimize Code Generator
        /// </summary>
        public void MinimizeCodeGenerator()
        {
            codeGeneratorWindow.Get(SearchCriteria.ByText("Minimize")).Click();
        }

        /// <summary>
        /// Raises Turbo alert
        /// </summary>
        /// <param name="alertCode"></param>
        /// <param name="port"></param>
        public void RaiseEquipmentAlertTurbo(string alertCode, string port)
        {
            RestoreWindow("TURBO");
            Keyboard.Instance.Enter(GlobalConstants.RaiseEquipmentAlertTurbo);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Keyboard.Instance.Enter(port);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Keyboard.Instance.Enter(alertCode);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

        }

        /// <summary>
        /// Connect or Disconnect VISimulator from EdCentra
        /// </summary>
        public void VISimulatorConnectivity()
        {
            RestoreWindow("VISim");
            Keyboard.Instance.Enter(GlobalConstants.ViSimulatorConnection);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            Thread.Sleep(1000);
        }

        /// <summary>
        /// Clear Turbo alerts
        /// </summary>
        /// <param name="port"></param>
        public void ClearEquimentAlertTurbo(string port)
        {
            Keyboard.Instance.Enter(GlobalConstants.ClearEquipmentAlertTurbo);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Keyboard.Instance.Enter(port);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
        }

        /// <summary>
        /// Start communication in turbo
        /// </summary>
        /// <param name="port"></param>
        public void StartTurboCommunication()
        {
            Keyboard.Instance.Enter(GlobalConstants.TurboCommunicationCode);
            Thread.Sleep(2000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(5000);
        }

        /// <summary>
        /// Kill Process
        /// </summary>
        /// <param name="pid"></param>
        public void KillProcess()
        {
            try
            {
                Process[] processList = Process.GetProcesses();

                foreach (Process prs in processList)
                {
                    if (prs.Id == pid)
                    {
                        prs.Kill();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Raise all type of alerts
        /// </summary>
        public void RaiseAllTypeOfAlerts()
        {
            //Clicks Start button
            simulatorWindow.Get<Button>(SearchCriteria.ByAutomationId("buttonGo")).Click();
            Thread.Sleep(3000);
            //Selects Equipment
            simulatorWindow.Get(SearchCriteria.ByText("Equipment")).DoubleClick();
            simulatorWindow.Get(SearchCriteria.ByText("NEW0001")).DoubleClick();
            Thread.Sleep(1000);
            simulatorWindow.Get(SearchCriteria.ByText("NEW0001PM1")).DoubleClick();
            //Raises Low Alarm on 8 (Booster Power) parameter
            simulatorWindow.Get(SearchCriteria.ByText("8          (Booster Power)")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("8          (Booster Power)")).RightClick();
            simulatorWindow.Get(SearchCriteria.ByText("Raise Alert")).DoubleClick();
            simulatorWindow.Get(SearchCriteria.ByAutomationId("comboBoxAlert")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("IDS_25_ALERT_1_7 (Power interrupt)")).Click();
            simulatorWindow.Get(SearchCriteria.ByAutomationId("comboBoxLevel")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("HighAlarm")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("Add")).Click();
            Thread.Sleep(2000);
            //Raises Low Alarm on 9 (MB MotorTemperature) parameter
            simulatorWindow.Get(SearchCriteria.ByText("9          (MB MotorTemperature)")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("9          (MB MotorTemperature)")).RightClick();
            simulatorWindow.Get(SearchCriteria.ByText("Raise Alert")).DoubleClick();
            simulatorWindow.Get(SearchCriteria.ByAutomationId("comboBoxLevel")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("LowAlarm")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("Add")).Click();
            Thread.Sleep(2000);
            //Raises High Warning on 11 (Dry Pump Control) parameter
            simulatorWindow.Get(SearchCriteria.ByText("11          (Dry Pump Control)")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("11          (Dry Pump Control)")).RightClick();
            simulatorWindow.Get(SearchCriteria.ByText("Raise Alert")).DoubleClick();
            simulatorWindow.Get(SearchCriteria.ByAutomationId("comboBoxAlert")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("IDS_25_ALERT_1_7 (Power interrupt)")).Click();
            simulatorWindow.Get(SearchCriteria.ByAutomationId("comboBoxLevel")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("HighWarning")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("Add")).Click();
            Thread.Sleep(2000);
            //Raises Low Warning on 12 (Booster Control) parameter
            simulatorWindow.Get(SearchCriteria.ByText("12          (Booster Control)")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("12          (Booster Control)")).RightClick();
            simulatorWindow.Get(SearchCriteria.ByText("Raise Alert")).DoubleClick();
            simulatorWindow.Get(SearchCriteria.ByAutomationId("comboBoxLevel")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("LowWarning")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("Add")).Click();
            Thread.Sleep(2000);
            //Raises Advisory on 13(Seals Purge)) parameter
            simulatorWindow.Get(SearchCriteria.ByText("13          (Seals Purge)")).Click();
            Thread.Sleep(2000);
            simulatorWindow.Get(SearchCriteria.ByText("13          (Seals Purge)")).RightClick();
            simulatorWindow.Get(SearchCriteria.ByText("Raise Alert")).DoubleClick();
            simulatorWindow.Get(SearchCriteria.ByAutomationId("comboBoxLevel")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("Advisory")).Click();
            simulatorWindow.Get(SearchCriteria.ByText("Add")).Click();
            Thread.Sleep(5000);
        }

        /// <summary>
        /// Minimizes Simulator
        /// </summary>
        public void MinimizeSimulator()
        {
            simulatorWindow.Get(SearchCriteria.ByText("Minimize")).Click();
            Thread.Sleep(8000);
        }

        /// <summary>
        /// Select Equipment
        /// </summary>
        public void SelectEquipment(string equipmentType = "NEW0001PM1")
        {
            //Clicks Start button
            simulatorWindow.Get<Button>(SearchCriteria.ByAutomationId("buttonGo")).Click();
            Thread.Sleep(3000);
            //Selects Equipment
            simulatorWindow.Get(SearchCriteria.ByText("Equipment")).DoubleClick();
            simulatorWindow.Get(SearchCriteria.ByText("NEW0001")).DoubleClick();
            Thread.Sleep(1000);
            simulatorWindow.Get(SearchCriteria.ByText(equipmentType)).DoubleClick();
        }

        public void SelectETXEquipment(string equipmentType = "ETX0001AC1")
        {
            //Clicks Start button
            simulatorWindow.Get<Button>(SearchCriteria.ByAutomationId("buttonGo")).Click();
            Thread.Sleep(3000);
            //Selects Equipment
            simulatorWindow.Get(SearchCriteria.ByText("Equipment")).DoubleClick();
            simulatorWindow.Get(SearchCriteria.ByText("ETX0001")).DoubleClick();
            Thread.Sleep(1000);
            simulatorWindow.Get(SearchCriteria.ByText(equipmentType)).DoubleClick();
        }
        /// <summary>
        /// Stop Simulator
        /// </summary>
        public void StopSimulator()
        {
            //Clicks Stop button
            simulatorWindow.Get<Button>(SearchCriteria.ByAutomationId("buttonStop")).Click();
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Raise alert
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="alerType"></param>
        /// <param name="alertCode"></param>
        /// <param name="text"></param>
        public void RaiseAlert(string parameter, string alerType = "HighAlarm", string alertCode = "IDS_16403_ALERT_3513 (TE406 Combustor Temperature Sensor Error)")
        {
            application = (Application)TechTalk.SpecFlow.ScenarioContext.Current["Application"];

            if (simulatorWindow == null)
                simulatorWindow = application.GetWindow("EISSA");
            simulatorWindow.Get(SearchCriteria.ByText(parameter)).Click();
            simulatorWindow.Get(SearchCriteria.ByText(parameter)).RightClick();
            simulatorWindow.Get(SearchCriteria.ByText("Raise Alert")).DoubleClick();
            simulatorWindow.Get(SearchCriteria.ByAutomationId("comboBoxAlert")).Click();
            simulatorWindow.Get(SearchCriteria.ByText(alertCode)).Click();
            simulatorWindow.Get(SearchCriteria.ByAutomationId("comboBoxLevel")).Click();
            simulatorWindow.Get(SearchCriteria.ByText(alerType)).Click();
            simulatorWindow.Get(SearchCriteria.ByText("Add")).Click();
        }

        /// <summary>
        /// Select Parameter
        /// </summary>
        /// <param name="parameter"></param>
        public void SelectParameter(string parameter)
        {
            application = (Application)TechTalk.SpecFlow.ScenarioContext.Current["Application"];

            if (simulatorWindow == null)
                simulatorWindow = application.GetWindow("EISSA");
            Thread.Sleep(2000);
            simulatorWindow.Get(SearchCriteria.ByText(parameter)).Click();
        }

        /// <summary>
        /// Set Parameter Value
        /// </summary>
        /// <param name="value"></param>
        public void SetParameterValue(string value)
        {
            try
            {
                application = (Application)TechTalk.SpecFlow.ScenarioContext.Current["Application"];

                if (simulatorWindow == null)
                    simulatorWindow = application.GetWindow("EISSA");
                simulatorWindow.Get(SearchCriteria.ByText("Value")).Click();
              //  simulatorWindow.Get(SearchCriteria.ByName("Value")).Click();
                Thread.Sleep(2000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE);
                Keyboard.Instance.Enter(value);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                simulatorWindow.Get(SearchCriteria.ByText("Static")).Click();
            }
        }

        /// <summary>
        /// Clear Alert
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="alerType"></param>
        /// <param name="alertCode"></param>
        /// <param name="text"></param>
        public void ClearAlert(string parameter)
        {
            simulatorWindow.Get(SearchCriteria.ByText(parameter)).Click();
            simulatorWindow.Get(SearchCriteria.ByText(parameter)).RightClick();
            simulatorWindow.Get(SearchCriteria.ByText("Clear Alert")).DoubleClick();
            Thread.Sleep(2000);
            simulatorWindow.Get(SearchCriteria.ByText("Clear")).Click();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Press Tab Key
        /// </summary>
        public void PressTab()
        {
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
        }

        /// <summary>
        /// Closes Simulator
        /// </summary>
        public void CloseSimulator()
        {
            simulatorWindow.Get(SearchCriteria.ByText("Close")).Click();
        }

        /// <summary>
        /// Set Device status
        /// </summary>
        /// <param name="status"></param>
        public void SetDeviceStatus(string status)
        {
            Thread.Sleep(2000);
            simulatorWindow.Get(SearchCriteria.ByText("Status")).Click();
            Thread.Sleep(1000);
            simulatorWindow.Get(SearchCriteria.ByText("Open")).Click();

            for (int i = 0; i < 6; i++)
            {
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.UP);
            }
            if (status.Contains("Stop"))
            {
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            }
            else if (status.Contains("Stopping"))
            {
                for (int i = 1; i < 3; i++)
                {
                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
                }
            }
            else if (status.Contains("Starting"))
            {
                for (int i = 1; i < 4; i++)
                {
                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
                }
            }
            else if (status.Contains("Running"))
            {
                for (int i = 1; i < 5; i++)
                {
                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
                }
            }
            else if (status.Contains("Comms_Fail"))
            {
                for (int i = 1; i < 6; i++)
                {
                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
                }
            }
            else if (status.Contains("Network_Fault"))
            {
                for (int i = 1; i < 7; i++)
                {
                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
                }
            }
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            Thread.Sleep(1000);
        }

        /// <summary>
        /// Add the different types of reports
        /// </summary>
        public void LaunchReport(string authCode)
        {
            application = Application.Launch(GlobalConstants.ReportPath);
            process = application.Process;
            pid = process.Id;
            Window loginWindow = application.GetWindow("Support Login");
            loginWindow.Get(SearchCriteria.ByAutomationId("txtPassword")).SetValue(GlobalConstants.LoginPassword);
            Thread.Sleep(5000);
            Button enterButton = loginWindow.Get<Button>(SearchCriteria.ByAutomationId("btnGo"));
            Thread.Sleep(2000);
            enterButton.Click();
            Thread.Sleep(2000);
            Window configureWindow = application.GetWindow("Report Configuration");
            var fileMenu = configureWindow.MenuBar;
            string[] filePath = { "File", "Open Report Definition template" };
            Thread.Sleep(2000);
            fileMenu.MenuItem(filePath).Click();
            Thread.Sleep(2000);
            configureWindow.Get(SearchCriteria.ByClassName("Edit")).SetValue(GlobalConstants.ReportDefinitionPath);
            Button openButton = configureWindow.Get<Button>(SearchCriteria.ByAutomationId("1"));
            openButton.Click();
            Thread.Sleep(2000);
            var optionMenu = configureWindow.MenuBar;
            string[] optPath = { "Options", "Show Advanced Reports" };
            Thread.Sleep(2000);
            optionMenu.MenuItem(optPath).Click();
            Thread.Sleep(2000);
            var listBox = configureWindow.Get<ListBox>(SearchCriteria.ByAutomationId("ChklstReport"));
            Thread.Sleep(2000);
            //Selecting Reports
            listBox.Select("ALERT REPORT");
            listBox.Select("EQUIPMENT SOFTWARE SURVEY REPORT");
            listBox.Select("CONSUMPTION REPORT");
            Thread.Sleep(2000);
            configureWindow.Get(SearchCriteria.ByAutomationId("txtActivationCode")).SetValue(authCode);
            Thread.Sleep(2000);
            var saveText = configureWindow.Get(SearchCriteria.ByText("Save"));
            saveText.Click();
            Thread.Sleep(1000);
            Button saveButton = configureWindow.Get<Button>(SearchCriteria.ByAutomationId("1"));
            Thread.Sleep(1000);
            saveButton.Click();
            Thread.Sleep(1000);
            configureWindow.Get(SearchCriteria.ByText("Yes")).Click();
            Thread.Sleep(15000);
            configureWindow.Get(SearchCriteria.ByText("Close")).Click();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// verify the Window Availability
        /// </summary>
        public void VerifyWindow()
        {
            agentConfiguration = application.GetWindow(SearchCriteria.ByAutomationId("FrameworkConfig"), InitializeOption.NoCache);
        }

        /// <summary>
        /// Minimize Agent ConfigurationWindow
        /// </summary>
        public void MinimizeAgentConfiguration()
        {
            agentConfiguration.Get(SearchCriteria.ByText("Minimize")).Click();
        }

        /// <summary>
        /// Disable the Internet Connection
        /// </summary>
        public void InternetConnection()
        {
            application = Application.Launch(GlobalConstants.ControlPanelPath);
            process = application.Process;
            pid = process.Id;
            Window controlPanelWindow = application.GetWindow("Control Panel");
            controlPanelWindow = application.GetWindow(SearchCriteria.ByClassName("CabinetWClass"), InitializeOption.NoCache);
            var internetlink = controlPanelWindow.Get(SearchCriteria.ByText("Network and Internet"));
            internetlink.Click();
            Thread.Sleep(200);
            var sharingLink = controlPanelWindow.Get(SearchCriteria.ByText("Network and Sharing Center"));
            sharingLink.Click();
            Thread.Sleep(200);
            var changeSettings = controlPanelWindow.Get(SearchCriteria.ByText("Change adapter settings"));
            changeSettings.Click();
            Thread.Sleep(200);
            var ethernetList = controlPanelWindow.Get(SearchCriteria.ByText("Ethernet0"));
            ethernetList.DoubleClick();
            Thread.Sleep(200);
        }

        /// <summary>
        /// Select Various Equipment and Equipment type
        /// </summary>
        public void SelectOtherEquipment(string Type, string equipmentType)
        {
            try
            {
                //Click various EquipmentType
                simulatorWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("comboBoxType")).Click();
                Thread.Sleep(1000);
                simulatorWindow.Get(SearchCriteria.ByText(Type)).Click();
                Thread.Sleep(2000);
                //Clicks Start button
                simulatorWindow.Get<Button>(SearchCriteria.ByAutomationId("buttonGo")).Click();
                Thread.Sleep(3000);
                //Select Equipment
                simulatorWindow.Get(SearchCriteria.ByText("Equipment")).DoubleClick();
                simulatorWindow.Get(SearchCriteria.ByText("NEW0001")).DoubleClick();
                Thread.Sleep(1000);
                //select Equipment Type
                simulatorWindow.Get(SearchCriteria.ByText(equipmentType)).DoubleClick();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Set Number Of System
        /// </summary>
        /// <param name="Count"></param>
        public void NumberofSystem(string Count = "10")
        {
            try
            {
                Thread.Sleep(2000);
                simulatorWindow.Get(SearchCriteria.ByText("Number Of Systems")).SetValue(Count);
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Select the simulator BaseName
        /// </summary>
        /// <param name="equipmentType"></param>
        public void SelectBaseName(string Name = "NEW")
        {
            try
            {
                simulatorWindow.Get(SearchCriteria.ByAutomationId("textBoxBaseName")).SetValue(Name);
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Select the Simulator Device Type
        /// </summary>
        /// <param name="equipmentType"></param>
        public void SelectDeviceEquipmentType(string equipmentType = "eZenith")
        {
            try
            {
                simulatorWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("comboBoxType")).Click();
                simulatorWindow.Get(SearchCriteria.ByText(equipmentType)).DoubleClick();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Launch DSPU Simulator 
        /// </summary>
        public void LaunchScadaDSPU()
        {
            try
            {
                application = Application.Launch(GlobalConstants.DSPUSimulatorPath);
                process = application.Process;
                pid = process.Id;
                scadaDSPUWindow = application.GetWindow("Scada DSPU");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// To Select different DSPU Scenario
        /// </summary>
        /// <param name="Path"></param>
        public void SelectDSPUScenario(string Path)
        {
            try
            {
                var fileMenu = scadaDSPUWindow.MenuBar;
                Thread.Sleep(1000);
                string[] selectFileOpen = { "File", "Open" };
                Thread.Sleep(100);
                fileMenu.MenuItem(selectFileOpen).Click();
                Thread.Sleep(100);
                scadaDSPUWindow.Get(SearchCriteria.ByClassName("Edit")).SetValue(Path);
                Button openButton = scadaDSPUWindow.Get<Button>(SearchCriteria.ByAutomationId("1"));
                openButton.Click();
                Thread.Sleep(1000);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Set Property Value
        /// </summary>
        /// <param name="ID"></param>
        public void SetPropertyValue(string ID)
        {
            try
            {
                scadaDSPUWindow.Get(SearchCriteria.ByText("DPD to systems A")).DoubleClick();
                scadaDSPUWindow.Get(SearchCriteria.ByText("Value")).DoubleClick();
                Thread.Sleep(1000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE);
                Thread.Sleep(1000);
                Keyboard.Instance.Enter(ID);
                Thread.Sleep(4000);
                scadaDSPUWindow.Get(SearchCriteria.ByText("DPD to systems B")).DoubleClick();
                Thread.Sleep(4000);
                scadaDSPUWindow.Get(SearchCriteria.ByText("Properties Window")).DoubleClick();
                scadaDSPUWindow.Get(SearchCriteria.ByText("Value")).DoubleClick();
                Thread.Sleep(1000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE);
                Thread.Sleep(1000);
                Keyboard.Instance.Enter(ID);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Execute the DSPU scenario
        /// </summary>
        public void ExecuteDSPU()
        {
            try
            {
                Button validationButton = scadaDSPUWindow.Get<Button>(SearchCriteria.ByAutomationId("btnValidate"));
                validationButton.Click();
                Thread.Sleep(1000);
                Button okConfirmation = scadaDSPUWindow.Get<Button>(SearchCriteria.ByAutomationId("2"));
                okConfirmation.Click();
                Thread.Sleep(1000);
                StartDSPUScenario();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Status checking 
        /// </summary>
        /// <param name="status"></param>
        public void SetDeviceStatusNew(string status)
        {
            try
            {
                simulatorWindow.Get(SearchCriteria.ByText("Properties Window")).GetElement(SearchCriteria.ByText("Status"));
                Thread.Sleep(8000);
                simulatorWindow.Get(SearchCriteria.ByText("Status")).Click();
                Thread.Sleep(1000);
                simulatorWindow.Get(SearchCriteria.ByText("Browse...")).Click();
                Thread.Sleep(5000);
                for (int i = 0; i < 6; i++)
                {
                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.UP);
                }
                if (status.Contains("Stop"))
                {
                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
                }
                else if (status.Contains("Running"))
                {
                    for (int i = 1; i < 5; i++)
                    {
                        Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Set Parameter Value
        /// </summary>
        /// <param name="value"></param>
        public void SetParameterValueNew(string value)
        {
            Thread.Sleep(5000);
            try
            {
                simulatorWindow.Get(SearchCriteria.ByText("Properties Window")).GetElement(SearchCriteria.ByText("Value"));
                Thread.Sleep(5000);
                simulatorWindow.Get(SearchCriteria.ByText("Value")).Click();
                Thread.Sleep(5000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE);
                Keyboard.Instance.Enter(value);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Select Required Single Equipment
        /// </summary>
        /// <param name="Equipment"></param>
        public void SelectSingleEquipment(string Equipment)
        {
            try
            {
                simulatorWindow.Get(SearchCriteria.ByText(Equipment)).DoubleClick();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Start the simulator
        /// </summary>
        public void StartSimulator()
        {
            try
            {
                //Clicks Start button
                simulatorWindow.Get<Button>(SearchCriteria.ByAutomationId("buttonGo")).Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Verify the Checkbox status 
        /// </summary>
        /// <returns></returns>
        public void CheckboxStatus()
        {
            try
            {
                var logCheckbox = simulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBoxLog"));
                if (!logCheckbox.IsSelected)
                {
                    simulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBoxLog")).Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Verify the Checkbox status 
        /// </summary>
        /// <returns></returns>
        public void UnCheckboxStatus()
        {
            bool flag = false;
            try
            {
                var logCheckbox = simulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBoxLog"));
                if (logCheckbox.IsSelected)
                {
                    simulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBoxLog")).Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Unselect the CheckBox
        /// </summary>
        public void CheckboxUnSelect()
        {
            try
            {
                var logCheckbox = simulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBoxLog"));
                if (logCheckbox.IsSelected)
                {
                    logCheckbox.Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Selct the Edit Child Menu
        /// </summary>
        public void EditMenuSelection()
        {
            try
            {
                var editMenu = simulatorWindow.MenuBar;
                Thread.Sleep(1000);
                string[] selectAdjustable = { "Edit", "Adjustables" };
                Thread.Sleep(100);
                editMenu.MenuItem(selectAdjustable).Click();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// verify the Window Availability
        /// </summary>
        public bool VerifyAdjustableWindow()
        {
            bool flag = false;
            try
            {
                Button loadButton = simulatorWindow.Get<Button>(SearchCriteria.ByAutomationId("buttonLoad"));
                if (loadButton.Visible)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flag;
        }

       
        /// <summary>
        /// Adjustable file Load
        /// </summary>
        public void LoadAdjustableFile(string adjustableFileName)
        {
            try
            {
                Button loadButton = simulatorWindow.Get<Button>(SearchCriteria.ByAutomationId("buttonLoad"));
                Thread.Sleep(1000);
                loadButton.Click();
                Thread.Sleep(1000);
                simulatorWindow.Get(SearchCriteria.ByClassName("Edit")).SetValue(adjustableFileName);
                Button openButton = simulatorWindow.Get<Button>(SearchCriteria.ByAutomationId("1"));
                openButton.Click();
                Thread.Sleep(1000);
                Button ConfirmationButton = simulatorWindow.Get<Button>(SearchCriteria.ByAutomationId("2"));
                ConfirmationButton.Click();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Verify the Log Entries Status
        /// </summary>
        /// <returns></returns>
        public bool LogEntriesStatus()
        {
            bool flag = false;
            // simulatorWindow.Get<CheckBox>(SearchCriteria.ByText("Log?")
            for (int i = 0; i < 25; i++)
            {
                Thread.Sleep(1000);
                application = (Application)TechTalk.SpecFlow.ScenarioContext.Current["Application"];

                if (simulatorWindow == null)
                    simulatorWindow = application.GetWindow("EISSA");
                if (simulatorWindow.Get<TextBox>(SearchCriteria.ByAutomationId("textBoxMonitor")).Text.Contains(GlobalConstants.LogEntry))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        // <summary>
        /// Verify the Grid List Element Status
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public bool GridListedElements(string Parameter)
        {
            bool flag = false;
            try
            {
                ListView grid = simulatorWindow.Get<ListView>(SearchCriteria.ByAutomationId("listViewAdjustables"));
                Thread.Sleep(1000);
                grid.GetElement(SearchCriteria.ByText(Parameter));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flag;
        }
               
        /// <summary>
        /// Data Grid Status verification
        /// </summary>
        /// <returns></returns>
        public bool DataGridViewVisible(string Text, int cell)
        {
            bool flag = false;
            try
            {
                Thread.Sleep(5000);
                Table grid = scadaDSPUWindow.Get<Table>(SearchCriteria.ByAutomationId("sequenceDgr"));
                var lists = grid.Rows;
                foreach (var list in lists)
                {
                    if (list.Cells[1].Value.ToString().Contains(Text))
                    {
                        flag = true;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flag;
        }

        /// <summary>
        /// Verify Graph Exists
        /// </summary>
        /// <returns></returns>
        public bool IsGraphExist()
        {
            bool flag = false;
            try
            {
                Window graphWindow = application.GetWindow("System Id: ADSSystemTesting  Parameter Number: 0");
                Thread.Sleep(1000);
                if (graphWindow.Visible)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flag;
        }

        /// <summary>
        /// Start DSPU Scenario
        /// </summary>
        public void StartDSPUScenario()
        {
            Button executeButton = scadaDSPUWindow.Get<Button>(SearchCriteria.ByAutomationId("btnExecute"));
            executeButton.Click();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Stop DSPU Scenario
        /// </summary>
        public void StopDSPUScenario()
        {
            Button stopScenarioButton = scadaDSPUWindow.Get<Button>(SearchCriteria.ByAutomationId("btnStop"));
            stopScenarioButton.Click();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Configure the Simulator
        /// </summary>
        public void ConfigureSimulator()
        {
            Keyboard.Instance.Enter(GlobalConstants.VersionDefine);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(2000);
            Keyboard.Instance.Enter(GlobalConstants.PortSelection);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);
            Keyboard.Instance.Enter(GlobalConstants.ControllerVersion);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);
            Keyboard.Instance.Enter(GlobalConstants.PumpVersion);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);
            Keyboard.Instance.Enter("Y");
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);
            Keyboard.Instance.Enter("Y");
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// To verify the Swapout Genereator is Exist
        /// </summary>
        /// <returns></returns>
        public bool IsExistSwapoutGenerator()
        {
            bool flag = false;
            Thread.Sleep(5000);
            swapoutGeneratorWindow = application.GetWindow("Swap Out Generator");
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            if (swapoutGeneratorWindow.Visible)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// To Swapout Elements
        /// </summary>
        /// <param name="Equipment"></param>
        public void SwapoutElement(string Equipment)
        {
            ComboBox sysId = swapoutGeneratorWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("editSystemType"));
            Thread.Sleep(500);
            sysId.Click();
            Thread.Sleep(1000);
            var listbox = swapoutGeneratorWindow.Get<ListBox>(SearchCriteria.ByClassName("ComboLBox"));
            var listitems = listbox.Items;
            foreach (var ele in listitems)
            {
                if (ele.Text.Contains(Equipment))
                {
                    ele.Click();
                    Thread.Sleep(1000);
                    break;
                }
            }
            Button swapoutButton = swapoutGeneratorWindow.Get<Button>(SearchCriteria.ByAutomationId("doSwapout"));
            Thread.Sleep(500);
            swapoutButton.Click();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// to Launch the SQL Server
        /// </summary>
        public void LaunchSQL()
        {
            //  application = Application.Launch(GlobalConstants.SQLServerPath);
            process = application.Process;
            pid = process.Id;
            sqlWindow = application.GetWindow("Microsoft SQL Server Management Studio (Administrator)");
            Thread.Sleep(1000);
        }

        /// <summary>
        /// SQL Server Logging 
        /// </summary>
        public void SQLLogging()
        {
            TextBox userName = sqlWindow.Get<TextBox>(SearchCriteria.ByText("Login:"));
            Thread.Sleep(100);
            // userName.SetValue(GlobalConstants.SQLUserName);
            Thread.Sleep(1000);
            TextBox password = sqlWindow.Get<TextBox>(SearchCriteria.ByAutomationId("password"));
            Thread.Sleep(100);
            // password.SetValue(GlobalConstants.SQLPassword);
            Thread.Sleep(1000);
            Button connectButton = sqlWindow.Get<Button>(SearchCriteria.ByAutomationId("connect"));
            Thread.Sleep(500);
            connectButton.Click();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Create a New SQL Query
        /// </summary>
        public void CreateNewQuery()
        {
            Tree dataBase = sqlWindow.Get<Tree>(SearchCriteria.ByText("Databases"));
            Thread.Sleep(1000);
            dataBase.DoubleClick();
            Thread.Sleep(1000);
            Tree scadaDataBase = sqlWindow.Get<Tree>(SearchCriteria.ByText("scada_Production"));
            Thread.Sleep(1000);
            scadaDataBase.RightClick();
        }

        /// <summary>
        /// To Verify the Agen Configuration Window Is Exists
        /// </summary>
        /// <returns></returns>
        public bool AgentConfigurationWindowIsExist()
        {
            bool flag = false;
            {
                agentConfiguration = application.GetWindow("Agent Configuration");
                if (agentConfiguration.Visible)
                {
                    flag = true;
                    Thread.Sleep(1000);
                }
            }
            return flag;
        }

        /// <summary>
        /// Set Property Value
        /// </summary>
        /// <param name="ID"></param>
        public void SetSystemID(string ID)
        {
            try
            {
                scadaDSPUWindow.Get(SearchCriteria.ByText("TriangleWave1")).DoubleClick();
                Thread.Sleep(3000);
                scadaDSPUWindow.Get(SearchCriteria.ByText("Properties Window")).GetElement(SearchCriteria.ByText("EquipmentEventDetails"));
                Thread.Sleep(5000);
                scadaDSPUWindow.Get(SearchCriteria.ByText("EquipmentEventDetails")).DoubleClick();
                Thread.Sleep(1000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE);
                Thread.Sleep(1000);
                Keyboard.Instance.Enter(ID);
                Thread.Sleep(4000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Returns DSPU Input Files
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string ScenarioAtributePath(string name)
        {
            string file = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\"));
            string filePath = Path.Combine(file +@"Input Files\DSPU Scenario Files\");
            //string destinationFile = Path.Combine(filePath + name).Replace("\\","\");
            string path = Path.Combine(filePath + name);
            string path1 = Regex.Replace(path, @"\\", @"\");
            return path1;
        }

        /// <summary>
        /// Returns Maintain Module Scenario Path
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string MaintainModuleScenarioFilePath(string name)
        {
            string file = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\"));
            string filePath = Path.Combine(file + "Input Files\\Maintain Module\\");
            string path = Path.Combine(filePath + name);
            return path;
        }
        
        /// <summary>
        /// Returns ADS_SystemTest Scenario Path
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string ADS_SystemTestFilePath(string name)
        {
            string file = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\"));
            string filePath = Path.Combine(file + "Input Files\\ADS_SystemTest\\");
            string path = Path.Combine(filePath + name);
            return path;
        }

        /// <summary>
        /// Returns AdjustableFile Path
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string AdjustableFile(string fileName)
        {
            string file = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\"));
            string filePath = Path.Combine(file + "Input Files\\AdjustableFile\\");
            string path = Path.Combine(filePath + fileName);
            return path;
        }

        /// <summary>
        /// Returns Availability System Scenario Path
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string AvailabilitySystemFilePath(string name)
        {
            string file = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\"));
            string filePath = Path.Combine(file + "Input Files\\Availability Data System\\");
            string path = Path.Combine(filePath + name);
            return path;
        }

        /// <summary>
        /// Set DSPU Values
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="outputPath"></param>
        /// <param name="value"></param>
        public void SetDSPUAtributes(string inputPath, string outputPath, string value)
        {
            try
            {
                AutomationElement ele = scadaDSPUWindow.Get(SearchCriteria.ByText("SOURCE")).GetElement(SearchCriteria.ByText("CSV"));
                double x = ele.Current.BoundingRectangle.X;
                double y = ele.Current.BoundingRectangle.Y;
                System.Windows.Point p = new System.Windows.Point((int)x, (int)y);
                Mouse.Instance.Click(p);
                Thread.Sleep(1000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
                Thread.Sleep(1000);
                System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
                Thread.Sleep(1000);
                scadaDSPUWindow.Get(SearchCriteria.ByText("Properties Window")).DoubleClick();
                Thread.Sleep(1000);
                scadaDSPUWindow.Get(SearchCriteria.ByText("CSVFileName")).DoubleClick();
                Thread.Sleep(1000);
                scadaDSPUWindow.Get(SearchCriteria.ByText("Browse...")).Click();
                Thread.Sleep(1000);
                System.Windows.Forms.SendKeys.SendWait(inputPath);
                Thread.Sleep(1000);
                System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
                Thread.Sleep(1000);
                AutomationElement ele1 = scadaDSPUWindow.Get(SearchCriteria.ByText("DESTINATION")).GetElement(SearchCriteria.ByText("CSV"));
                double x1 = ele1.Current.BoundingRectangle.X;
                double y1 = ele1.Current.BoundingRectangle.Y;
                System.Windows.Point q = new System.Windows.Point((int)x1, (int)y1);
                Mouse.Instance.Click(q);
                Thread.Sleep(1000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
                Thread.Sleep(1000);
                System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
                Thread.Sleep(1000);
                scadaDSPUWindow.Get(SearchCriteria.ByText("Properties Window")).DoubleClick();
                Thread.Sleep(1000);
                scadaDSPUWindow.Get(SearchCriteria.ByText("Output CSVFileName")).DoubleClick();
                Thread.Sleep(1000);
                scadaDSPUWindow.Get(SearchCriteria.ByText("Browse...")).Click();
                Thread.Sleep(1000);
                System.Windows.Forms.SendKeys.SendWait(outputPath);
                Thread.Sleep(1000);
                System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
                Thread.Sleep(1000);
                scadaDSPUWindow.Get(SearchCriteria.ByAutomationId("CommandButton_6")).Click();
                Thread.Sleep(1000);
                scadaDSPUWindow.Get(SearchCriteria.ByText("MassSpawner")).Click();
                Thread.Sleep(1000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
                Thread.Sleep(1000);
                System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
                Thread.Sleep(1000);
                scadaDSPUWindow.Get(SearchCriteria.ByText("Properties Window")).DoubleClick();
                Thread.Sleep(1000);
                scadaDSPUWindow.Get(SearchCriteria.ByText("Number of Items")).DoubleClick();
                Thread.Sleep(1000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE);
                Thread.Sleep(1000);
                Keyboard.Instance.Enter(value);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Minimize Scada DSPU Graph
        /// </summary>
        public void MinimizeDSPUGraph()
        {
            List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
                try
                {
                    if (win.Name.Contains("System Id"))
                    {
                        win.Get(SearchCriteria.ByText("Minimize")).Click();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Failed", ex.Message);
                }
            }
        }

        /// <summary>
        /// Minimize Scada DSPU
        /// </summary>
        public void MinimizeDSPU()
        {
            List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
                try
                {
                    if (win.Name.Contains("Scada DSPU"))
                    {
                        win.Get(SearchCriteria.ByText("Minimize")).Click();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Failed", ex.Message);
                }
            }
        }

        /// <summary>
        /// Restore Scada
        /// </summary>
        public void RestoreScada(string path)
        {
            IntPtr hwnd = new IntPtr(0);
            List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
                try
                {
                    if (win.Name.Contains("Scada DSPU"))
                    {

                        hwnd = FindWindowByCaption(IntPtr.Zero, path);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Failed", ex.Message);
                }
            }
            Thread.Sleep(2000);
            ShowWindow(hwnd, SW_RESTORE);
        }

        /// <summary>
        /// Restore ADSSystemScada
        /// </summary>
        public void RestoreADSScada(string scenarioName)
        {
            IntPtr hwnd = new IntPtr(0);
            List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
                try
                {
                    if (win.Name.Contains("Scada DSPU"))
                    {

                        hwnd = FindWindowByCaption(IntPtr.Zero, scenarioName);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Failed", ex.Message);
                }
            }
            Thread.Sleep(2000);
            ShowWindow(hwnd, SW_RESTORE);
        }


        /// <summary>
        /// Install Build on DataBase Server
        /// </summary>
        /// <param name="serverName"></param>
        public void SelectDataBaseServerToInstall(string serverName)
        {
            List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
                if (win.Name.Equals("Welcome to the Edwards Scada Installer"))
                {
                    win.Get(SearchCriteria.ByAutomationId("pictureBoxDB")).Click();
                    Thread.Sleep(2000);
                    win.Get(SearchCriteria.ByAutomationId("txtApplicationServer")).SetValue(serverName);
                    Thread.Sleep(2000);
                    win.Get(SearchCriteria.ByAutomationId("buttonInstall")).Click();
                    Thread.Sleep(150000);
                    HandleSqlServerDialog();
                    SelectDVDDrive();
                    Thread.Sleep(50000);
                    ClickOkInInformationDialog();
                }
            }
        }

        /// <summary>
        /// Install Build on Agent Server
        /// </summary>
        /// <param name="appServerName"></param>
        /// <param name="dbServerName"></param>
        public void SelectAgentServerToInstall(string appServerName, string dbServerName)
        {
            List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
                if (win.Name.Equals("Welcome to the Edwards Scada Installer"))
                {
                    win.Get(SearchCriteria.ByAutomationId("pictureBoxAgent")).Click();
                    Thread.Sleep(2000);
                    win.Get(SearchCriteria.ByAutomationId("txtApplicationServer")).SetValue(appServerName);
                    Thread.Sleep(2000);
                    win.Get(SearchCriteria.ByAutomationId("txtDatabaseServer")).SetValue(dbServerName);
                    Thread.Sleep(2000);
                    win.Get(SearchCriteria.ByAutomationId("buttonInstall")).Click();
                    Thread.Sleep(15000);
                    ClickOkInInstallDialog();
                }
            }
        }

        /// <summary>
        /// Clicks Ok button in Information Dialog
        /// </summary>
        public void ClickOkInInstallDialog()
        {
            bool flag = false;
            try
            {
                for (int i = 0; i <= 500; i++)
                {

                    if (flag == true)
                    {
                        break;
                    }
                    List<Window> winList = Desktop.Instance.Windows();
                    foreach (var win in winList)
                    {

                        try
                        {
                            if (win.Name.Equals("Information"))
                            {
                                flag = true;
                                win.Get(SearchCriteria.ByAutomationId("1")).Click();
                                break;
                            }
                            else
                            {
                                Thread.Sleep(10000);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Failed", ex.Message);
            }
        }

        /// <summary>
        /// Install Build on Application Server
        /// </summary>
        /// <param name="dbServerName"></param>
        public void SelectApplicationServerToInstall(string dbServerName)
        {
            List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
                if (win.Name.Equals("Welcome to the Edwards Scada Installer"))
                {
                    win.Get(SearchCriteria.ByAutomationId("pictureBoxApp")).Click();
                    Thread.Sleep(2000);
                    win.Get(SearchCriteria.ByAutomationId("2")).Click();
                    Thread.Sleep(2000);
                    win.Get(SearchCriteria.ByAutomationId("txtDatabaseServer")).SetValue(dbServerName);
                    Thread.Sleep(2000);
                    win.Get(SearchCriteria.ByAutomationId("buttonInstall")).Click();
                    Thread.Sleep(150000);
                    ClickOkInInformationDialog();
                }
            }
        }

        /// <summary>
        /// To Restore Modbus
        /// </summary>
        public void RestoreModbus()
        {
            IntPtr hwnd = new IntPtr(0);
            List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
                try
                {
                    if (win.Name.Contains(GlobalConstants.ModbusWindowName))
                    {
                        win.DisplayState = DisplayState.Maximized;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Failed", ex.Message);
                }
            }            
        }
        
        /// <summary>
        /// To Minimize modbus
        /// </summary>
        public void MinimizeModbus()
        {
            IntPtr hwnd = new IntPtr(0);
            List<Window> winList = Desktop.Instance.Windows();
            foreach (var win in winList)
            {
                try
                {
                    if (win.Name.Contains(GlobalConstants.ModbusWindowName))
                    {
                        win.DisplayState = DisplayState.Minimized;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Failed", ex.Message);
                }
            }
        }

        /// <summary>
        /// To check Functional code checkbox 
        /// </summary>
        public void CheckFunctionCodecheckbox()
        {
            try
            {
                var functionCodeCheckbox = ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox4"));
                if (!functionCodeCheckbox.IsSelected)
                {
                    ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox4")).Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// To Uncheck Functional code checkbox 
        /// </summary>
        public void UnCheckFunctionCodecheckbox()
        {
            try
            {
                var functionCodeCheckbox = ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox4"));
                if (functionCodeCheckbox.IsSelected)
                {
                    ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox4")).Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// To check the RandomParameter checkbox
        /// </summary>
        public void CheckRandomParameterCheckbox()
        {
            try
            {
                var RandomparameterCheckbox = simulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBoxRandomParameterGeneration"));
                if (!RandomparameterCheckbox.IsSelected)
                {
                    simulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBoxRandomParameterGeneration")).Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// To Uncheck the RandomParameter checkbox
        /// </summary>
        public void UnCheckRandomParameterCheckbox()
        {
            try
            {
                var RandomparameterCheckbox = simulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBoxRandomParameterGeneration"));
                if (RandomparameterCheckbox.IsSelected)
                {
                    simulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBoxRandomParameterGeneration")).Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Open modbus rgr file 
        /// </summary>
        /// <param name="fileName"></param>
        public void OpenRgrFile(string fileName)
        {
            ModbussimulatorWindow.Get(SearchCriteria.ByClassName("Edit")).SetValue(fileName);
            Button openButton = ModbussimulatorWindow.Get<Button>(SearchCriteria.ByAutomationId("1"));
            openButton.Click();
        }

        /// <summary>
        /// Change register value 
        /// </summary>
        /// <param name="regType"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        public void ChangeRegisterValue(string regType, string address, string value)
        {
            if (ModbussimulatorWindow == null)
                ModbussimulatorWindow = application.GetWindow(GlobalConstants.ModbusWindowName);
            try
            {
                var MovetoAddress = ModbussimulatorWindow.Get(SearchCriteria.ByAutomationId("numericUpDown1"));
                MovetoAddress.DoubleClick();
                Thread.Sleep(100);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE);
                Thread.Sleep(100);
                Keyboard.Instance.Enter(address);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
                Thread.Sleep(1000);
                if (regType.Contains("Holding Register"))
                {
                    Table text = ModbussimulatorWindow.Get<Table>(SearchCriteria.ByAutomationId("dataGridView4"));
                    var val = text.Rows[0].Cells[1];
                    val.Click();
                    Thread.Sleep(100);
                }
                else if (regType.Contains("Input Register"))
                {
                    Table text = ModbussimulatorWindow.Get<Table>(SearchCriteria.ByAutomationId("dataGridView3"));
                    var val = text.Rows[0].Cells[1];
                    val.Click();
                    Thread.Sleep(100);
                }

                Keyboard.Instance.Enter(value);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Change to Input Register Tab
        /// </summary>
        public void SelectInputRegisterTab()
        {
            if (ModbussimulatorWindow == null)
                ModbussimulatorWindow = application.GetWindow(GlobalConstants.ModbusWindowName);
            ModbussimulatorWindow.Get(SearchCriteria.ByText("Input Registers")).Click();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// To Uncheck the functional code checkboxes
        /// </summary>
        public void UncheckActivateFuctionalCheckboxes()
        {
            if (ModbussimulatorWindow == null)
                ModbussimulatorWindow = application.GetWindow(GlobalConstants.ModbusWindowName);
            var readCoilsCheckbox = ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox2"));
            if (readCoilsCheckbox.IsSelected)
            {
                ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox2")).Click();
            }
            var readDiscreteInputsCheckbox = ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox3"));
            if (readDiscreteInputsCheckbox.IsSelected)
            {
                ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox3")).Click();
            }
            var readHoldingRegistersCheckbox = ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox4"));
            if (readHoldingRegistersCheckbox.IsSelected)
            {
                ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox4")).Click();
            }
            var readInputRegistersCheckbox = ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox5"));
            if (readInputRegistersCheckbox.IsSelected)
            {
                ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox5")).Click();
            }
        }

        /// <summary>
        /// To Recheck the functional code checkboxes
        /// </summary>
        public void RecheckActivateFuctionalCheckboxes()
        {
            if (ModbussimulatorWindow == null)
                ModbussimulatorWindow = application.GetWindow(GlobalConstants.ModbusWindowName);
            var readCoilsCheckbox = ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox2"));
            if (!readCoilsCheckbox.IsSelected)
            {
                ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox2")).Click();
            }
            var readDiscreteInputsCheckbox = ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox3"));
            if (!readDiscreteInputsCheckbox.IsSelected)
            {
                ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox3")).Click();
            }
            var readHoldingRegistersCheckbox = ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox4"));
            if (!readHoldingRegistersCheckbox.IsSelected)
            {
                ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox4")).Click();
            }
            var readInputRegistersCheckbox = ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox5"));
            if (!readInputRegistersCheckbox.IsSelected)
            {
                ModbussimulatorWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("checkBox5")).Click();
            }
        }

        /// <summary>
        /// To select Coils Tab
        /// </summary>
        public void SelectCoilsTab()
        {
            if (ModbussimulatorWindow == null)
                ModbussimulatorWindow = application.GetWindow(GlobalConstants.ModbusWindowName);
            ModbussimulatorWindow.Get(SearchCriteria.ByText("Coils")).Click();
            Thread.Sleep(2000);
        }

        public void MovetoAddress(string address)
        {
            if (ModbussimulatorWindow == null)
                ModbussimulatorWindow = application.GetWindow(GlobalConstants.ModbusWindowName);
            var MovetoAddress = ModbussimulatorWindow.Get(SearchCriteria.ByAutomationId("numericUpDown1"));
            MovetoAddress.DoubleClick();
            Thread.Sleep(100);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE);
            Thread.Sleep(100);
            Keyboard.Instance.Enter(address);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// To change Coil Register Value
        /// </summary>
        public void ChangeValue()
        {
            if (ModbussimulatorWindow == null)
                ModbussimulatorWindow = application.GetWindow(GlobalConstants.ModbusWindowName);
            Table text = ModbussimulatorWindow.Get<Table>(SearchCriteria.ByAutomationId("dataGridView2"));
            var val = text.Rows[0].Cells[1];
            val.DoubleClick();
            Thread.Sleep(100);
        }

        public void LaunchCDI()
        {
            applicationCDI = Application.Launch(GlobalConstants.CDIWindowPath);
            //TechTalk.SpecFlow.ScenarioContext.Current.Add("Application", application);
            process = applicationCDI.Process;
            pid = process.Id;
            loginCDIWindow = applicationCDI.GetWindow("Login");
        }

        public void LoginDetails(string userName, string password)
        {
            if (loginCDIWindow == null)
                loginCDIWindow = applicationCDI.GetWindow(GlobalConstants.CDIWindowName);
            var userNameBox = loginCDIWindow.Get(SearchCriteria.ByAutomationId("textBoxUserName"));
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE);
            Thread.Sleep(100);
            Keyboard.Instance.Enter(userName);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Thread.Sleep(1000);
            var passwordBox = loginCDIWindow.Get(SearchCriteria.ByAutomationId("textBoxPassword"));
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE);
            Thread.Sleep(100);
            Keyboard.Instance.Enter(password);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Thread.Sleep(1000);
            var loginbutton = loginCDIWindow.Get(SearchCriteria.ByAutomationId("buttonLogin"));
            loginbutton.Click();
            Thread.Sleep(1000);
        }

        
        /// <summary>
        /// To Verify CDI Login window exist
        /// </summary>
        /// <returns></returns>
        public bool CDILoginWindowsIsExist()
        {
            bool flag = false;
            {
                List<Window> windowList = Desktop.Instance.Windows();
                foreach (var win in windowList)
                {
                    if (win.Name.Contains("Login") || win.Name.Contains("Incremental CDI"))
                    {
                        flag = true;
                        Thread.Sleep(1000);
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// To kill CDI Window 
        /// </summary>
        public void KillCDIWIndow()
        {
            List<Window> windowList = Desktop.Instance.Windows();
            foreach (var win in windowList)
            {
                if (win.Name.Contains("Incremental CDI"))
                {
                    win.Close();
                    Thread.Sleep(1000);
                }

            }
        }

        /// <summary>
        /// To kill CDI Window 
        /// </summary>
        public void KillCommandPromptWIndow()
        {
            List<Window> windowList = Desktop.Instance.Windows();
            foreach (var win in windowList)
            {
                if (win.Name.Contains("cmd.exe"))
                {
                    win.Close();
                    Thread.Sleep(1000);
                }

            }
        }
        //test reference

        public void LaunchSimulator1()
        {
            application = Application.Launch(GlobalConstants.EissaWindowPath);
            Thread.Sleep(2000);
            TechTalk.SpecFlow.ScenarioContext.Current.Add("Application", application);
            Thread.Sleep(1000);
            process = application.Process;
            pid = process.Id;
            simulatorWindow = application.GetWindow("EISSA");
            simulatorWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("comboBoxType")).Click();
            Thread.Sleep(1000);
            // simulatorWindow.Get(SearchCriteria.ByText(equipmentType)).Click();
            Thread.Sleep(2000);
        }
        /// <summary>
        ///  Confirm Login Failed 
        /// </summary>
        public void ConfirmLoginFailed()
        {
            if (loginCDIWindow.Get(SearchCriteria.ByAutomationId("2")).Visible)
            {
                var okButton = loginCDIWindow.Get(SearchCriteria.ByAutomationId("2"));
                okButton.Click();
                Thread.Sleep(1000);
            }
        }
    }
}
