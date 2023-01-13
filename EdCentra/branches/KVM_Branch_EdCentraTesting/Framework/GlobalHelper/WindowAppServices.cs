using FlaUI.UIA3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using System.Threading;
using FlaUI.UIA2;
using TestStack.White;
using TestStack.White.UIItems;
using System.Diagnostics;
using System.IO;
using TestStack.White.UIItems.Finders;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;
using Edwards.Scada.Test.Framework.Contract;
using System.Windows.Automation;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    public class WindowAppServices
    {
        #region fields
        Window winApp;
        Window IISWindow;
        Window serverManagerWindow;
        Window eventViewer;
        Window cmdWindow;
        Window ssmsWindow;
        Window recycleWindow;
        Window cdiWindow;
        Window ScheduleEditWin;
        Window SqlJobScheduleWin;
        ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
        bool found = false;
        int pid = 0;
        System.Diagnostics.Process ctrlProcess;
        ListViewRows rowsEdwards;
        #endregion


        public void OpenControlPanelPF()
        {
            var ctrlPanel = System.IO.Path.Combine(Environment.SystemDirectory, "control.exe");
            ctrlProcess = System.Diagnostics.Process.Start(ctrlPanel, "/name Microsoft.ProgramsAndFeatures");

            pid = ctrlProcess.Id;
            Thread.Sleep(5000);
            //Window connectWindow = application.GetWindows().FirstOrDefault(w => w.Name == "Connect to Server");
            //////Get window
            ////List<TestStack.White.UIItems.WindowItems.Window> windowList = Desktop.Instance.Windows();
            ////foreach (var win in windowList)
            ////{
            ////    if (win.Name.Equals("Programs and Features"))//("Control Panel"))
            ////    {
            ////        TestStack.White.UIItems.UIItemCollection itemsContainer = win.Items; //.Find(x => x.Name.Equals("Folder View"));
                    
            ////        ListView listView = win.Items.Find(x => x.Name.Equals("Folder View")) as ListView;
            ////        if (listView.Rows.Exists(r => r.Name.Equals("Microsoft XML Parser and SDK")))
            ////        {
            ////             found = true;
            ////        }
            ////        break;
            ////        //itemsContainer.Contains()
            ////    }
            ////}

            //    //FLA UI
            //    string control = "C:\\Windows\\System32\\control.exe";
            //var ctrlPF = FlaUI.Core.Application.Launch(control);
            //var automation = new UIA3Automation();
            ////winApp = ctrlPF.GetMainWindow(automation);//System.Exception: 'Could not find process with id: 26716'
            //winApp = ctrlPF.GetAllTopLevelWindows(automation)[0];//Index was outside the bounds of array
            //Thread.Sleep(5000);
        }

        


        /// <summary>
        /// Verify if component is installed in Control panel - programs and features
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
            public List<string> InstalledComponents(List<string> components)
        {
            //bool status = false;
            List<string> actualInstalled = new List<string>();

            //Get window
            List<TestStack.White.UIItems.WindowItems.Window> windowList = Desktop.Instance.Windows();
            foreach (var win in windowList)
            {
                if (win.Name.Equals("Programs and Features"))
                {
                    foreach (var component in components)
                    {
                        TestStack.White.UIItems.UIItemCollection itemsContainer = win.Items; //.Find(x => x.Name.Equals("Folder View"));

                        ListView listView = win.Items.Find(x => x.Name.Equals("Folder View")) as ListView;
                        if (listView.Rows.Exists(r => r.Name.Equals(component)) || listView.Rows.Exists(r => r.Name.Contains(component)))//("Microsoft XML Parser and SDK")))
                        {
                            actualInstalled.Add(component);
                            //status = true;
                        }
                        //break;
                        //itemsContainer.Contains()
                    }
                    break;
                }
            }

            return actualInstalled;
        }

        /// <summary>
        /// To kill Control panel
        /// </summary>
        public void KillControlPanel()
        {
            List<TestStack.White.UIItems.WindowItems.Window> windowList = Desktop.Instance.Windows();
            foreach (var win in windowList)
            {
                if (win.Name.Contains("Programs and Features") || win.Name.Contains("Windows Firewall with Advanced Security"))
                {
                    win.Close();
                    Thread.Sleep(1000);
                    break;
                }
            }
        }

        /// <summary>
        /// Delete the control panel instance
        /// </summary>
        public void ProcessKill()
        {
            Process proc = Process.GetProcessById(pid);
            proc.Kill();
        }
        
        /// <summary>
        /// Firewall Inbound rules
        /// </summary>
        /// <returns></returns>
        public List<string> OpenWindowsFireWallAdvSettingsInbound()
        {
            List<string> listActual = new List<string>();
            Application fire = Application.Launch(new System.Diagnostics.ProcessStartInfo("wf.msc"));
            Thread.Sleep(3000);
            Process process = fire.Process;
            pid = process.Id;
            Thread.Sleep(1000);
            //List<TestStack.White.UIItems.WindowItems.Window> fireWindow = fire.GetWindows();// "Windows Firewall with Advanced Security");
            //Get window
            List<TestStack.White.UIItems.WindowItems.Window> windowList = Desktop.Instance.Windows();
            foreach (var win in windowList)
            {
                if (win.Name.Equals("Windows Firewall with Advanced Security"))
                {
                    TestStack.White.UIItems.TreeItems.Tree tree = win.Get<TestStack.White.UIItems.TreeItems.Tree>(SearchCriteria.ByAutomationId("12785"));
                    tree.Nodes[0].Nodes[0].Click();
                    Thread.Sleep(1000);

                    TestStack.White.UIItems.ListView  lstInbound= win.Get<TestStack.White.UIItems.ListView>(SearchCriteria.ByAutomationId("12786"));
                    int count = lstInbound.Rows.Count;
                    rowsEdwards = lstInbound.Rows;

                    listActual = rowsEdwards.Select(x => x.Name).ToList();

                    ////Check atleast two rows for Edwards
                    //var con = lstInbound.Rows[0].Name.Contains("Edwards");
                    //var con1 = lstInbound.Rows[1].Name.Contains("Edwards");
                    //if (con == true && con1 == true)
                    //{
                    //    stat = true;
                    //}   
                    break;
                }
            }
            //Process proc = Process.GetProcessById(pid);
            //proc.Kill();
            return listActual;
        }

        public Dictionary<string, bool> GetEdwardsAllowedAppsList()
        {
            Dictionary<string, bool> lstEnabled1 = new Dictionary<string, bool>();
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.LWIN);
            Keyboard.Instance.Enter("R");
            Keyboard.Instance.LeaveKey(KeyboardInput.SpecialKeys.LWIN);
            Thread.Sleep(1000);
            Keyboard.Instance.Enter("Firewall.Cpl");
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(8000);
            //Get process
            //Process[] processList = Process.GetProcesses();
            Process _explorerProcess = Process.GetProcessesByName("explorer")[0];

            Application app = Application.Attach(_explorerProcess.Id);// ("explorer.exe");
            TestStack.White.UIItems.WindowItems.Window win = app.GetWindow("Windows Firewall");
            var items = win.Items;
            foreach (var item in items)
            {
                if (item.Name.Equals("Allow an app or feature through Windows Firewall"))
                {
                    item.Click();
                    break;
                }
            }

            //Allowed apps
            // Get process
            //Process[] processList = Process.GetProcesses();
            Process _explorerProcess1 = Process.GetProcessesByName("explorer")[0];

            Application app1 = Application.Attach(_explorerProcess1.Id);// ("explorer.exe");
            TestStack.White.UIItems.WindowItems.Window win1 = app.GetWindow("Allowed apps");
            var items1 = win1.Items;
            var ele = win1.Get(SearchCriteria.ByClassName("ShellTabWindowClass"));
            //System.Windows.Automation.AutomationElement rootElement = System.Windows.Automation.AutomationElement.RootElement;
            //var winCollection = rootElement.FindAll(TreeScope.Children, Condition.TrueCondition);
            for (int i = 0; i < 11; i++)
            {
                IUIItem[] items17 = win1.GetMultiple(SearchCriteria.All);
                foreach (var item in items17)
                {
                    try
                    {
                        //Name may be null or empty = avoid exception
                        if (item.Name != null && item.Name != string.Empty)
                        {
                            if (item.Name.Contains("Edwards"))
                            {
                                //checked --> All Edwards, Edwards - Private and Edwards - Public
                                //if (!item.Enabled || item.Enabled)
                                {
                                    if (lstEnabled1.ContainsKey(item.Name))
                                    {
                                        continue;
                                    }
                                    //if (item is TestStack.White.UIItems.CheckBox)
                                    //add to list and report
                                    lstEnabled1.Add(item.Name, ((TestStack.White.UIItems.CheckBox)item).Checked);
                                }
                            }
                        }
                    }
                    catch
                    {
                        //exception for Name when is not present in item
                        continue;
                    }
                }
                Thread.Sleep(5000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.PAGEDOWN);
                Thread.Sleep(5000);
            }
            pid = _explorerProcess1.Id;
            ProcessKill();
            return lstEnabled1;
        }

        //var application1 = FlaUI.Core.Application.Attach("explorer.exe");
        //Thread.Sleep(5000);
        //var automation1 = new UIA3Automation();
        ////serverManagerWindow = application.GetMainWindow(automation);

        //var hhh1 = application1.GetAllTopLevelWindows(automation1)[0];
        //hhh1.FindFirstDescendant(cf.ByAutomationId("SearchEditBox")).AsTextBox().Enter("Allow an app");

        //Thread.Sleep(1000);
        //Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
        //Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
        //Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

        //var allowedApps1 = application1.GetAllTopLevelWindows(automation1);
        //Thread.Sleep(3000);

        //var gridElements2 = (allowedApps1[0].FindFirstDescendant(cf.ByAutomationId("allowedProgramsList"))).FindAllChildren();
        //var hg = gridElements2[3].AsCheckBox().IsChecked;

        //Thread.Sleep(3000);

        //Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.LWIN);
        //Keyboard.Instance.Enter("R");
        //Keyboard.Instance.LeaveKey(KeyboardInput.SpecialKeys.LWIN);
        //Thread.Sleep(1000);
        //Keyboard.Instance.Enter("Firewall.Cpl");
        //Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
        //Thread.Sleep(8000);
        //var application = FlaUI.Core.Application.Attach("explorer.exe");
        //Thread.Sleep(5000);
        //var automation = new UIA3Automation();
        ////serverManagerWindow = application.GetMainWindow(automation);



        //var hhh = application.GetAllTopLevelWindows(automation)[0];
        //hhh.FindFirstDescendant(cf.ByAutomationId("SearchEditBox")).AsTextBox().Enter("Allow an app");



        //Thread.Sleep(1000);
        //Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
        //Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
        //Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);



        //var allowedApps = application.GetAllTopLevelWindows(automation);
        //Thread.Sleep(3000);

        ////Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.PAGEDOWN);

        //for (int i = 0; i < 11; i++)
        //{
        //    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.PAGEDOWN);
        //    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.PAGEDOWN);
        //    Thread.Sleep(1000);
        //    var gridElements = (allowedApps[0].FindFirstDescendant(cf.ByAutomationId("allowedProgramsList"))).FindAllChildren();

        //    //var ge = gridElements.Select(x => x.Name.Contains("Edwards")).ToList();

        //    foreach (var lstname in gridElements)
        //    {
        //        if (lstname.Name.Contains("Edwards"))
        //        {
        //            //get public and private
        //            var scope = lstname.FindAllChildren();

        //            //public
        //            var isPublicChecked = scope[1].AsCheckBox().IsChecked;

        //            //private
        //            var isPrivateChecked = scope[0].AsCheckBox().IsChecked;

        //            if (isPrivateChecked == true && isPublicChecked == true)
        //            {
        //                if (lstEnabled.ContainsKey(lstname.Name))
        //                {
        //                    break;
        //                }
        //                lstEnabled.Add(lstname.Name, true);
        //            }
        //            else
        //            {
        //                lstEnabled.Add(lstname.Name, false);
        //            }
        //        }
        //    }               
        //    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.PAGEDOWN);

        //} 
        //return lstEnabled;  
        //}

        /// <summary>
        /// Process is running or not
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        public bool IsProcessRunning(string proc)
        {
            bool status = false;
            Process[] pname = Process.GetProcessesByName(proc);
          
            if (pname.Length > 0)
            {
                status = true;
            }
            return status;
        }


        /// <summary>
        /// Launching Server Manager Window
        /// </summary>
        public void LaunchServerManager()
        {
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.LWIN);
            Keyboard.Instance.Enter("R");
            Keyboard.Instance.LeaveKey(KeyboardInput.SpecialKeys.LWIN);
            Thread.Sleep(1000);
            Keyboard.Instance.Enter("ServerManager.exe");
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(15000);
            var application = FlaUI.Core.Application.Attach("ServerManager.exe");
            Thread.Sleep(5000);
            var automation = new UIA3Automation();
            serverManagerWindow = application.GetMainWindow(automation);

            Thread.Sleep(3000);

        }

        public void ClickAddRolesAndFeatures()
        {
            serverManagerWindow.FindFirstDescendant(cf.ByAutomationId("WelcomeTileQuickStartAddRoles")).AsButton().WaitUntilClickable(TimeSpan.FromSeconds(20)).Invoke();
            Thread.Sleep(2000);
            serverManagerWindow.FindFirstDescendant(cf.ByAutomationId("WizardMoveForwardButton")).AsButton().Invoke();
            Thread.Sleep(1000);
            serverManagerWindow.FindFirstDescendant(cf.ByAutomationId("WizardMoveForwardButton")).AsButton().Invoke();
            Thread.Sleep(1000);
            serverManagerWindow.FindFirstDescendant(cf.ByAutomationId("WizardMoveForwardButton")).AsButton().Invoke();
        }

        public void ExpandTillApplicationDevelopment()
        {
            serverManagerWindow.FindFirstDescendant(cf.ByAutomationId("Web-Server")).AsTreeItem().Expand();
            serverManagerWindow.FindFirstDescendant(cf.ByName("Web Server")).AsTreeItem().Expand();
            serverManagerWindow.FindFirstDescendant(cf.ByName("Application Development")).AsTreeItem().Expand();
        }

        public bool CheckComponentsInstalled(string comp)
        {
            bool flag = false;
            if (serverManagerWindow.FindFirstDescendant(cf.ByName(comp)).AsTreeItem().HelpText.Trim() == "(Installed)")
                flag = true;
            return flag;
        }

        public void ClickCancelButtonInTheWizard()
        {
            serverManagerWindow.FindFirstDescendant(cf.ByAutomationId("WizardCancelButton")).AsButton().Invoke();
        }

        public void CheckToolsMenu(string text)
        {
            bool flag = serverManagerWindow.FindFirstDescendant(cf.ByName("Tools")).AsButton().IsAvailable;
            Thread.Sleep(3000);


        }

        public void LaunchIIS()
        {
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.LWIN);
            Keyboard.Instance.Enter("R");
            Keyboard.Instance.LeaveKey(KeyboardInput.SpecialKeys.LWIN);
            Thread.Sleep(1000);
            Keyboard.Instance.Enter("InetMgr.exe");
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(12000);
            var application = FlaUI.Core.Application.Attach("InetMgr.exe");
            Thread.Sleep(5000);
            var automation = new UIA3Automation();
            IISWindow = application.GetMainWindow(automation);

            Thread.Sleep(3000);

        }

        public void ExpandDefaultWebSite()
        {
            LaunchIIS();
            string hostName = SpecflowHooks.HostName();
            string text = hostName + " (" + hostName + "\\Administrator)";
            IISWindow.FindFirstDescendant(cf.ByName(text)).AsTreeItem().Expand();
            IISWindow.FindFirstDescendant(cf.ByName("Sites")).AsTreeItem().Expand();
            Thread.Sleep(2000);
            IISWindow.FindFirstDescendant(cf.ByName("Default Web Site")).AsTreeItem().Focus();
            IISWindow.FindFirstDescendant(cf.ByName("Content View")).AsButton().Invoke();
            IISWindow.FindFirstDescendant(cf.ByName("Default Web Site")).AsTreeItem().Focus();
            IISWindow.FindFirstDescendant(cf.ByAutomationId("ListViewSubItem-0")).AsTextBox().DoubleClick();
        }

        public void CloseIIS()
        {
            IISWindow.Close();
        }

        public void CloseServerManager()
        {
            serverManagerWindow.Close();
        }

        public bool IsVirtualDirectoryExistsInIIS(string dirName)
        {
            bool flag = false;
            Thread.Sleep(2000);
            if (IISWindow.FindFirstDescendant(cf.ByName(dirName)).AsTextBox().Name == dirName)
                flag = true;
            return flag;

        }

        public void LaunchEventViewer()
        {
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.LWIN);
            Keyboard.Instance.Enter("R");
            Keyboard.Instance.LeaveKey(KeyboardInput.SpecialKeys.LWIN);
            Thread.Sleep(1000);
            Keyboard.Instance.Enter("eventvwr.msc");
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(2000);
            var application = FlaUI.Core.Application.Attach("mmc.exe");
            Thread.Sleep(5000);
            var automation = new UIA3Automation();
            eventViewer = application.GetMainWindow(automation, TimeSpan.FromSeconds(20));

            Thread.Sleep(3000);
        }

        public void GetEventLog()
        {
            Thread.Sleep(1000);
            eventViewer.FindFirstDescendant(cf.ByName("Applications and Services Logs")).AsTreeItem().Expand();
            Thread.Sleep(1000);
            eventViewer.FindFirstDescendant(cf.ByName("Scada")).AsTreeItem().Select();
            Thread.Sleep(1000);
            eventViewer.FindFirstDescendant(cf.ByName("Open")).AsButton().Click();          
            Thread.Sleep(5000);
        }

        /// <summary>
        /// To verify Event log window is exist
        /// </summary>
        /// <returns></returns>
        public bool ScadaEventLogWindowIsExist()
        {
            bool flag = false;
            flag=eventViewer.FindFirstDescendant(cf.ByName("Applications and Services Logs")).AsTreeItem().IsAvailable;
            return flag;
        }

        /// <summary>
        /// Verify Deferred Text 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool DeferredTextExists(string text)
        {
            bool flag = false;
            try
            {
                var grid = eventViewer.FindFirstDescendant(cf.ByAutomationId("mainListView")).AsGrid();
                Thread.Sleep(2000);
                var gridRows=grid.GetRowsByValue(0, "Information");
                foreach (var row in gridRows)
                {
                    row.ScrollIntoView();

                    if ((row.Cells[2].AsTextBox().Name == "Agent Framework ") && row.Cells[3].AsTextBox().Name == "1")
                    {
                        row.Select();
                        Thread.Sleep(5000);
                        var txtValue = eventViewer.FindFirstDescendant(cf.ByAutomationId("messageRichTextBox")).AsTextBox().Text;
                        if (txtValue.Contains(text))
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                eventViewer.Close();                
            }
            catch(Exception ex)
            {
                eventViewer.Close();
            }
            return flag;
        }

        /// <summary>
        /// Delete Scan Assembly File Exist
        /// </summary>
        public void DeleteFileExist()
        {
            if (File.Exists(@"D:\Edwards\ScanAssemblyBuildType.exe"))
            {
                File.Delete(@"D:\Edwards\ScanAssemblyBuildType.exe");
            }
        }

        /// <summary>
        /// To Copy Scan Assemply Exe
        /// </summary>
        public void CopyFile()
        {
            string[] files = Directory.GetFiles(@"G:\", "ScanAssemblyBuildType.exe");
            foreach (string file in files)
            {
                File.Copy(file, Path.Combine(GlobalConstants.AssemblyBuildFileDest, Path.GetFileName(file)), true);
            }
        }

        /// <summary>
        /// Launch Cmd Prompt
        /// </summary>
        public void LaunchCmdPrompt()
        {
            var application = FlaUI.Core.Application.Launch(GlobalConstants.CmdPromptPath);
            var automation = new UIA3Automation();
            cmdWindow = application.GetMainWindow(automation);
            Thread.Sleep(5000);
        }

        /// <summary>
        /// To Run Assembly Build Type Exe
        /// </summary>
        public void RunExe()
        {
            cmdWindow.AsTextBox().Enter(@"D:\Edwards\ScanAssemblyBuildType.exe");
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(3000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(3000);
            cmdWindow.AsTextBox().Enter("exit");
        }

        /// <summary>
        /// Get Assembly Text
        /// </summary>
        public void getexpectedText()
        {
            string strCmdText = @"D:\Edwards\ScanAssemblyBuildType.exe>> g:\Expected.txt";
            System.Diagnostics.ProcessStartInfo procStartInfo =
                               new System.Diagnostics.ProcessStartInfo("cmd", "/c" + strCmdText);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            Thread.Sleep(120000);
        }

        /// <summary>
        /// Expand Sql Server tree
        /// </summary>
        /// <param name="text"></param>
        public void ExpandSqlServerTrees(string text)
        {
            var application = FlaUI.Core.Application.Attach("Ssms.exe");
            Thread.Sleep(5000);
            var automation = new UIA3Automation();
            Thread.Sleep(1000);
            ssmsWindow = application.GetMainWindow(automation, TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
            ssmsWindow.FindFirstDescendant(cf.ByName(text)).AsTreeItem().Expand();
        }

        /// <summary>
        /// Enable VI Management in SSMS
        /// </summary>
        /// <param name="text"></param>
        public void EnableVIManagmentInSSMS(string text)
        {
            string cmd = "INSERT INTO [dbo].[fst_SEC_GroupPermission] ([GroupID] , [OperationID]) VALUES (1, 160)";
            Thread.Sleep(2000);
            ssmsWindow.FindFirstDescendant(cf.ByName(text)).Click();
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter("N");
            Keyboard.Instance.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(2000);
            ssmsWindow.FindFirstDescendant(cf.ByAutomationId("WpfTextView")).AsTextBox().Enter(cmd);
            Thread.Sleep(5000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.F5);

        }

        /// <summary>
        /// Verify File is Exist
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool FileExist(string fileName)
        {
            bool flag = false;
            if (File.Exists(fileName))
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// Verify Directory is Exist
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool DiretoryExists(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// Sql Login
        /// </summary>
        public void SQLLogging()
        {
            List<TestStack.White.UIItems.WindowItems.Window> lstwindow = Desktop.Instance.Windows();
            foreach (var winSSMS in lstwindow)
            {
                if (winSSMS.Name.Equals("Microsoft SQL Server Management Studio (Administrator)"))
                {
                    Thread.Sleep(1000);
                    winSSMS.Get(SearchCriteria.ByText("Login:")).Click();
                    Thread.Sleep(1000);
                    winSSMS.Get(SearchCriteria.ByText("Login:")).Enter(GlobalConstants.SqlLoginUserName);
                    Thread.Sleep(1000);
                    winSSMS.Get(SearchCriteria.ByAutomationId("password")).Enter(GlobalConstants.SqlLoginPassword);
                    Thread.Sleep(1000);
                    winSSMS.Get(SearchCriteria.ByAutomationId("connect")).Click();
                    Thread.Sleep(2000);
                }
            }
        }

        /// <summary>
        /// Scada Database text verification
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool ScadaDatabaseVerification(string text)
        {
            bool flag = false;
            if (ssmsWindow.FindFirstDescendant(cf.ByName(text)).AsTreeItem().IsAvailable)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// To Select Windows Authentication Login
        /// </summary>
        public void SelectAuthenticationWindowsLogin()
        {
            List<TestStack.White.UIItems.WindowItems.Window> lstwindow = Desktop.Instance.Windows();
            foreach (var winSSMS in lstwindow)
            {
                if (winSSMS.Name.Equals("Microsoft SQL Server Management Studio (Administrator)"))
                {
                    Thread.Sleep(2000);
                    winSSMS.Get(SearchCriteria.ByAutomationId("comboBoxAuthentication")).Click();
                    Thread.Sleep(2000);
                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.UP);
                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                    Thread.Sleep(2000);
                    winSSMS.Get(SearchCriteria.ByAutomationId("connect")).Click();
                    Thread.Sleep(2000);
                }
            }
        }

        /// <summary>
        /// To Verify the Expected Error Message
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool ErrorMessageVerification(string text)
        {
            bool flag = false;
            List<TestStack.White.UIItems.WindowItems.Window> lstwindow = Desktop.Instance.Windows();
            foreach (var winSSMS in lstwindow)
            {
                if (winSSMS.Name.Equals("Microsoft SQL Server Management Studio (Administrator)"))
                {
                    var txtValue = winSSMS.Get(SearchCriteria.ByAutomationId("lblTopMessage")).ToString();
                    if (txtValue.Contains(text))
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// To select Confirm Ok Button
        /// </summary>
        public void SelectConfirmOkError()
        {
            List<TestStack.White.UIItems.WindowItems.Window> lstwindow = Desktop.Instance.Windows();
            foreach (var winSSMS in lstwindow)
            {
                if (winSSMS.Name.Equals("Microsoft SQL Server Management Studio (Administrator)"))
                {
                    Thread.Sleep(2000);
                    winSSMS.Get(SearchCriteria.ByAutomationId("button1")).Click();
                    Thread.Sleep(2000);
                }
            }
        }

        /// <summary>
        /// To Select SQl Authentication Login
        /// </summary>
        public void SelectAuthenticationSQLLogin()
        {
            List<TestStack.White.UIItems.WindowItems.Window> lstwindow = Desktop.Instance.Windows();
            foreach (var winSSMS in lstwindow)
            {
                if (winSSMS.Name.Equals("Microsoft SQL Server Management Studio (Administrator)"))
                {
                    Thread.Sleep(2000);
                    winSSMS.Get(SearchCriteria.ByAutomationId("comboBoxAuthentication")).Click();
                    Thread.Sleep(2000);
                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                    Thread.Sleep(2000);
                }
            }
        }     

        /// <summary>
        /// To Expand the Server Agent Tree
        /// </summary>
        public void ExpandServerAgentTable()
        {
            ssmsWindow.FindFirstDescendant(cf.ByName("SQL Server Agent")).AsTreeItem().Expand();
        }

        /// <summary>
        /// To Enhance the Server Tree
        /// </summary>
        /// <param name="hostName"></param>
        public void OpenServerProperty(string hostName)
        {
            string selectServer = hostName + @"\" + "FABWORKS";
            var parentTree = ssmsWindow.FindFirstDescendant(cf.ByName("Databases")).Parent;
            if (parentTree.Name.Contains(selectServer))
            {
                parentTree.AsTreeItem().Collapse();
            }
            Thread.Sleep(1000);
            parentTree.RightClick();
            Thread.Sleep(1000);
            ssmsWindow.FindFirstDescendant(cf.ByName("Properties")).Click();
            Thread.Sleep(3000);
        }

        /// <summary>
        /// To get Server Property Text
        /// </summary>
        /// <returns></returns>
        public string GetServerPropertyText()
        {
            var application = FlaUI.Core.Application.Attach("Ssms.exe");
            Thread.Sleep(5000);
            var automation = new UIA3Automation();
            var serverPropertyWindow = application.GetAllTopLevelWindows(automation)[0];
            Thread.Sleep(1000);
            string ExpectedText = serverPropertyWindow.FindFirstDescendant(cf.ByName("Server Collation")).AsTextBox().Text;
            Thread.Sleep(2000);
            string serverCollationText = ExpectedText;
            serverPropertyWindow.FindFirstDescendant(cf.ByAutomationId("okButton")).AsButton().Click();
            Thread.Sleep(1000);
            return serverCollationText;
        }

        /// <summary>
        /// To close SSMS Window
        /// </summary>
        public void CloseSSMS()
        {
            var application = FlaUI.Core.Application.Attach("Ssms.exe");
            Thread.Sleep(5000);
            var automation = new UIA3Automation();
            Thread.Sleep(1000);
            ssmsWindow = application.GetMainWindow(automation, TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
            ssmsWindow.Close();
        }

        /// <summary>
        /// To close SSMS Window
        /// </summary>
        public void CloseSSMSWithoutSave()
        {
            ssmsWindow.Close();
            ssmsWindow.FindFirstDescendant(cf.ByAutomationId("7")).AsButton().Click();
        }

        /// <summary>
        /// To Launch SSMS
        /// </summary>
        public void LaunchSSMS()
        {
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.LWIN);
            Keyboard.Instance.Enter("R");
            Keyboard.Instance.LeaveKey(KeyboardInput.SpecialKeys.LWIN);
            Thread.Sleep(1000);
            Keyboard.Instance.Enter("Ssms.exe");
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(60000);
            var application = FlaUI.Core.Application.Attach("Ssms.exe");
            Thread.Sleep(5000);
            var automation = new UIA3Automation();
            ssmsWindow = application.GetMainWindow(automation, TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
        }

        public void AttachCDIWindow()
        {
            var application = FlaUI.Core.Application.Attach("CDI_Win.exe");
            Thread.Sleep(5000);
            var automation = new UIA3Automation();
            cdiWindow = application.GetMainWindow(automation, TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
        }

        public void ClickDailyEquipmentFilter()
        {
            cdiWindow.FindFirstDescendant(cf.ByName("Daily Equipment Filter")).Click();
        }

        public void ClickAdhocEquipmentFilter()
        {
            cdiWindow.FindFirstDescendant(cf.ByName("Adhoc Equipment Filter")).Click();
        }

        public void ClickDailyDataExport()
        {
            cdiWindow.FindFirstDescendant(cf.ByName("Daily Data Export")).Click();
        }

        public void ClickCreateDataExport()
        {
            Thread.Sleep(2000);
            cdiWindow.FindFirstDescendant(cf.ByName("Create Data Export")).AsButton().Invoke();
            Thread.Sleep(2000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

        }

        public void SelectApplicationId()
        {
            cdiWindow.FindFirstDescendant(cf.ByAutomationId("comboBoxApps")).AsComboBox().Select("002 | AdHoc Data Export");
        }

        public void ClickAdhocDataExport()
        {
            cdiWindow.FindFirstDescendant(cf.ByName("Adhoc Data Export")).Click();
        }

        public int GetDailyDataExportRowsCount()
        {
           return cdiWindow.FindFirstDescendant(cf.ByAutomationId("listView1")).AsGrid().RowCount;

        }

        public bool RefreshDataRowInExport()
        {
            bool result = false;
            var grid = cdiWindow.FindFirstDescendant(cf.ByAutomationId("listView1")).AsGrid();
            var gridRows = grid.Rows;
            gridRows[0].Select();
            
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(2000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.F5);
                Thread.Sleep(3000);
                var rows = cdiWindow.FindFirstDescendant(cf.ByAutomationId("listView1")).AsGrid().Rows;
                if (rows[0].Cells[7].AsTextBox().Name == "Finished")
                    result = true;
            }
            return result;
        }

        public void ClickRemoveAllFilterButton()
        {
            cdiWindow.FindFirstDescendant(cf.ByAutomationId("buttonRemoveFilterAll")).AsButton().Click();
        }

        public void ClickAddAllFilterButton()
        {
            cdiWindow.FindFirstDescendant(cf.ByAutomationId("buttonFilterAll")).AsButton().Click();
        }

        public void CloseCDI()
        {
            cdiWindow.Close();
        }

        public void RunJobManuallyInDatabase(string JobName)
        {
            ssmsWindow.FindFirstDescendant(cf.ByName(JobName)).AsTreeItem().DoubleClick();
            Thread.Sleep(5000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
        }

        public void RunJobManuallyInDatabase(string JobName, string menuItem)
        {
            Thread.Sleep(2000);
            ssmsWindow.FindFirstDescendant(cf.ByName(JobName)).AsTreeItem().Focus();
            ssmsWindow.FindFirstDescendant(cf.ByName(JobName)).AsTreeItem().RightClick();
            Thread.Sleep(2000);
            ssmsWindow.FindFirstDescendant(cf.ByName(menuItem)).AsMenuItem().Invoke();
            Thread.Sleep(2000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(20000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

        }

        /// <summary>
        /// To read Database property Text
        /// </summary>
        /// <returns></returns>
        public string GetDatabasePropertyText()
        {
            Thread.Sleep(2000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT);
            Thread.Sleep(2000);
            var application = FlaUI.Core.Application.Attach("Ssms.exe");
            Thread.Sleep(1000);
            var automation = new UIA3Automation();
            Thread.Sleep(1000);
            ssmsWindow.FindFirstDescendant(cf.ByName("scada_Production")).RightClick();
            Thread.Sleep(2000);
            ssmsWindow.FindFirstDescendant(cf.ByName("Properties")).Click();
            Thread.Sleep(2000);
            var DBPropertyWindow = application.GetAllTopLevelWindows(automation)[0];
            Thread.Sleep(1000);
            string ExpectedText = DBPropertyWindow.FindFirstDescendant(cf.ByName("Collation")).AsTextBox().Text;
            Thread.Sleep(3000);
            string dBCollationText = ExpectedText;
            DBPropertyWindow.FindFirstDescendant(cf.ByAutomationId("okButton")).AsButton().Click();
            Thread.Sleep(1000);
            return dBCollationText;
        }

        /// <summary>
        /// To Verify file property access
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool VerifyFilePropertiesAccess(string filePath, string fileName)
        {
            DirectoryInfo di = new DirectoryInfo(filePath);
            FileSystemSecurity security;
            Thread.Sleep(1000);
            FileInfo[] TXTFiles = di.GetFiles();
            bool result = false;
            foreach (var file in TXTFiles)
            {
                if (file.Name.Contains(fileName))
                {
                    security = file.GetAccessControl();
                    var rules = security.GetAccessRules(true, true, typeof(NTAccount));

                    foreach(FileSystemAccessRule rule in rules)
                    {
                        if(rule.IdentityReference.Value.Contains("MSSQL$FABWORKS") && (rule.FileSystemRights==FileSystemRights.FullControl)&&(rule.AccessControlType==AccessControlType.Allow))
                        {
                            result = true;
                            break;
                        }
                    }                 
                    break;
                }              
            }
            return result;            
        }

        public void GetJobSchedule()
        {
            cdiWindow.FindFirstDescendant(cf.ByName("Config")).AsTreeItem().RightClick();
            Thread.Sleep(2000);
            cdiWindow.FindFirstDescendant(cf.ByName("Job Schedule")).AsMenuItem().Invoke();
            Thread.Sleep(2000);
        }

        public bool SqlJobWindowIsExist()
        {
            bool flag = false;
            var application = FlaUI.Core.Application.Attach("CDI_Win.exe");
            Thread.Sleep(1000);
            var automation = new UIA3Automation();
            Thread.Sleep(1000);
            SqlJobScheduleWin = application.GetAllTopLevelWindows(automation)[0];
            Thread.Sleep(1000);
            if (SqlJobScheduleWin.FindFirstDescendant(cf.ByAutomationId("btnEdit")).AsButton().IsAvailable)
            {
                flag = true;
            }
            return flag;
        }
                
        public void JobSchedulerText(string jobName, string schedule)
        {
            var application = FlaUI.Core.Application.Attach("CDI_Win.exe");
            Thread.Sleep(1000);
            var automation = new UIA3Automation();
            Thread.Sleep(1000);
            SqlJobScheduleWin = application.GetAllTopLevelWindows(automation)[0];
            Thread.Sleep(1000);
            SqlJobScheduleWin.FindFirstDescendant(cf.ByAutomationId("cmbJobs")).AsComboBox().Click();
            Thread.Sleep(2000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(2000);
            var lstSchedules = SqlJobScheduleWin.FindFirstDescendant(cf.ByAutomationId("lstSchedules")).AsGrid().Rows;
            if (lstSchedules.Count() > 0)
            {
                for (int i = 0; i < lstSchedules.Count(); i++)
                {
                    lstSchedules[i].Select();
                    SqlJobScheduleWin.FindFirstDescendant(cf.ByAutomationId("btnDelete")).AsButton().Click();
                    Thread.Sleep(1000);
                    SqlJobScheduleWin.FindFirstDescendant(cf.ByAutomationId("6")).AsButton().Click();
                    Thread.Sleep(3000);
                }
            }
            Thread.Sleep(1000);
            SqlJobScheduleWin.FindFirstDescendant(cf.ByAutomationId("btnNew")).AsButton().Click();
            Thread.Sleep(1000);
            ScheduleEditWin = application.GetAllTopLevelWindows(automation)[0];
            Thread.Sleep(1000);
            var enterName = ScheduleEditWin.FindFirstDescendant(cf.ByAutomationId("txtName")).AsTextBox();
            enterName.DoubleClick();
            enterName.Enter(schedule);
            Thread.Sleep(1000);
            ScheduleEditWin.FindFirstDescendant(cf.ByAutomationId("btnOk")).AsButton().Click();
            Thread.Sleep(3000);
            var lstSchedules1 = SqlJobScheduleWin.FindFirstDescendant(cf.ByAutomationId("lstSchedules")).AsGrid().Rows;
            lstSchedules1[0].Select();
            Thread.Sleep(60000);
            SqlJobScheduleWin.FindFirstDescendant(cf.ByAutomationId("btnEdit")).AsButton().Click();
            Thread.Sleep(1000);
        }

        public bool SqlJobEditWindowIsExist()
        {
            bool flag = false;
            var application = FlaUI.Core.Application.Attach("CDI_Win.exe");
            Thread.Sleep(1000);
            var automation = new UIA3Automation();
            Thread.Sleep(1000);
            ScheduleEditWin = application.GetAllTopLevelWindows(automation)[0];
            Thread.Sleep(1000);
            if (ScheduleEditWin.FindFirstDescendant(cf.ByAutomationId("txtName")).AsTextBox().IsAvailable)
            {
                flag = true;
            }
            return flag;
        }

        public void EditSchedule(string scheduleName)
        {
            var application = FlaUI.Core.Application.Attach("CDI_Win.exe");
            Thread.Sleep(1000);
            var automation = new UIA3Automation();
            Thread.Sleep(1000);
            ScheduleEditWin = application.GetAllTopLevelWindows(automation)[0];
            Thread.Sleep(1000);
            var enterName = ScheduleEditWin.FindFirstDescendant(cf.ByAutomationId("txtName")).AsTextBox();
            enterName.DoubleClick();
            enterName.Enter(scheduleName);
            Thread.Sleep(1000);
            ScheduleEditWin.FindFirstDescendant(cf.ByAutomationId("cmbFrequencyOccurs")).AsComboBox().Select("Daily");
            Thread.Sleep(1000);
            var numFrequencyRecurs = ScheduleEditWin.FindFirstDescendant(cf.ByAutomationId("numFrequencyRecurs")).AsTextBox();
            Thread.Sleep(1000);
            numFrequencyRecurs.DoubleClick();
            numFrequencyRecurs.Enter("3");
            Thread.Sleep(1000);
            var DateCheckbox = ScheduleEditWin.FindFirstDescendant(cf.ByAutomationId("grpFrequency")).FindAllChildren();
            Thread.Sleep(1000);
            for (int i = 2; i < 7; i++)
            {
                DateCheckbox[i].Click();
            }
            Thread.Sleep(1000);
            ScheduleEditWin.FindFirstDescendant(cf.ByAutomationId("btnOk")).AsButton().Click();
            Thread.Sleep(1000);
        }

        public void DeleteFolderExists()
        {
            string path = GlobalConstants.CDIFolderPath + GlobalConstants.ImportFolderName;
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        public void CreateCDIIMportFolder()
        {
            if (!Directory.Exists(GlobalConstants.CDIFolderPath + GlobalConstants.ImportFolderName))
            {
                Directory.CreateDirectory(GlobalConstants.CDIFolderPath + GlobalConstants.ImportFolderName);
            }
        }

        public void MoveSingleFile(string sourceFileName)
        {
            string destfileName = Path.GetFileNameWithoutExtension(sourceFileName);

            File.Move(sourceFileName, Path.Combine(GlobalConstants.targetDir, destfileName));
        }

        public void MoveFiles()
        {
            IEnumerable<FileInfo> files = Directory.GetFiles(GlobalConstants.sourceDir).Select(f => new FileInfo(f));
            foreach (var file in files)
            {
                File.Move(file.FullName, Path.Combine(GlobalConstants.targetDir, file.Name));
            }
        }

        public void MoveAllFiles()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(GlobalConstants.targetDir);
            List<String> MyMusicFiles = Directory
                              .GetFiles(GlobalConstants.sourceDir).ToList();

            foreach (string file in MyMusicFiles)
            {
                FileInfo mFile = new FileInfo(file);
                // to remove name collisions
                if (new FileInfo(dirInfo + "\\" + mFile.Name).Exists == false)
                {
                    mFile.MoveTo(dirInfo + "\\" + mFile.Name);
                }
            }
        }

        public void FolderExists()
        {
            if (Directory.Exists(GlobalConstants.PackagePath + GlobalConstants.FolderName))
            {

                Thread.Sleep(1000);
            }
        }

        public void AttachCmdWindow()
        {
            var application = FlaUI.Core.Application.Attach("cmd.exe");
            Thread.Sleep(5000);
            var automation = new UIA3Automation();
            cdiWindow = application.GetMainWindow(automation, TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
        }

        public void LaunchCmdPrmbt()
        {
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.WorkingDirectory = @"D:\";
            processStartInfo.FileName = "cmd.exe";
            Thread.Sleep(3000);
            // set additional properties     
            Process proc = Process.Start(processStartInfo);
            Thread.Sleep(3000);
            var application = FlaUI.Core.Application.Attach("cmd.exe");
            Thread.Sleep(1000);
            var automation = new UIA3Automation();
            Thread.Sleep(1000);
            cmdWindow = application.GetMainWindow(automation, TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
            cmdWindow.AsTextBox().Enter(@"cd Edwards\Packages\2008R2");
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);
            cmdWindow.AsTextBox().Enter(@" .\Edwards.Scada.Cdi.CompressTool.exe --extract --folder G:\fs_Maintenance\CDI\CDI_Import");
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(3000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(3000);
        }

        public void RunRecycleAgent()
        {
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.WorkingDirectory = @"G:\";
            processStartInfo.FileName = "cmd.exe";
            Thread.Sleep(3000);
            // set additional properties     
            Process proc = Process.Start(processStartInfo);
            Thread.Sleep(3000);
            var application = FlaUI.Core.Application.Attach("cmd.exe");
            Thread.Sleep(1000);
            var automation = new UIA3Automation();
            Thread.Sleep(1000);
            cmdWindow = application.GetMainWindow(automation, TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
            cmdWindow.AsTextBox().Enter(@" \recycleAgent.cmd");
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(3000);
        }
    }
}
