using Edwards.Scada.Test.Framework.Contract;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    class PDMLicenseGenerator
    {
        Application application;
        Window adaAppLicenseGeneratorWindow;
        static int pid;
        static Process process;


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
        /// Launches PdMLicenseGeneratorApp
        /// </summary>
        public void LaunchPdMLicenseGeneratorApp()
        {
            string licenseFilePath = System.Configuration.ConfigurationManager.AppSettings["PDMLicenseGenrataor"];
            application = Application.Launch(licenseFilePath);
            TechTalk.SpecFlow.ScenarioContext.Current.Add("Application", application);
            process = application.Process;
            pid = process.Id;
            adaAppLicenseGeneratorWindow = application.GetWindow("ADA Application License Generator");
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
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Launches PdMLicenseGeneratorApp
        /// </summary>
        public void SetDatabase()
        {
            Thread.Sleep(8000);
            bool flag = false;
            for (int i = 1; i <= 30; i++)
            {

                if (flag)
                {
                    break;
                }
                Thread.Sleep(1000);
                List<Window> winList = Desktop.Instance.Windows();
                foreach (Window win in winList)

                    if (win.Name.Contains("Please enter the database name on the build server to be"))
                    {
                        flag = true;
                        win.Get(SearchCriteria.ByAutomationId("button2")).Click();                        
                        break;
                    }
            }

        }

        /// <summary>
        /// SetUp General Settings
        /// </summary>
        /// <param name="code"></param>
        /// <param name="count"></param>
        /// <param name="equipmentType"></param>
        /// <param name="authorName"></param>
        public void SetGeneralSettings(string code, int count, string equipmentType, string authorName)
        {
            application = (Application)TechTalk.SpecFlow.ScenarioContext.Current["Application"];

            if (adaAppLicenseGeneratorWindow == null)
                adaAppLicenseGeneratorWindow = application.GetWindow("ADA Application License Generator");
            adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByAutomationId("_applicationActivationCode")).SetValue(code);
            Thread.Sleep(1000);
            adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByAutomationId("_applicationCustomerName")).SetValue(GlobalConstants.CustomerName);
            Thread.Sleep(1000);
            adaAppLicenseGeneratorWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("_selectEquipmentType")).Select(equipmentType);
            Thread.Sleep(2000);
            adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByAutomationId("_applicationAuthor")).SetValue(authorName);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// SetUp Algorithm General Settings
        /// </summary>
        /// <param name="algorithmName"></param>
        /// <param name="algTypeCode"></param>
        /// <param name="count"></param>
        public void SetAlgorithmGeneralSetttings(string algorithmName, string algTypeCode, int count)
        {
            try
            {
                Button addAlgorithmButton = adaAppLicenseGeneratorWindow.Get<Button>(SearchCriteria.ByAutomationId("_doAddAlgorithm"));
                addAlgorithmButton.Click();
                Thread.Sleep(8000);
                var modalWindows = adaAppLicenseGeneratorWindow.ModalWindows();
                foreach (Window win in modalWindows)
                {
                    if (win.Name.Equals("Please enter new algorithm name ..."))
                    {
                        win.Get(SearchCriteria.ByAutomationId("_response")).SetValue(algorithmName);
                        win.Get<Button>(SearchCriteria.ByAutomationId("button2")).Click();
                    }
                }

                adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByAutomationId("tabControl1")).Click();
                adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByText("STEP 3.1: Set Algorithm General Settings")).Click();
                adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByAutomationId("_algorithmTypeCode")).SetValue(algTypeCode);
                Thread.Sleep(5000);

                AutomationElement ele = adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByText("STEP 3.1: Set Algorithm General Settings")).GetElement(SearchCriteria.ByText("Spinner"));

                AutomationElementCollection elecoll = FindElementFromAutomationID(ele, "Max Assignments ...");
                double x = ele.Current.BoundingRectangle.X;
                double y = ele.Current.BoundingRectangle.Y;
                System.Windows.Point p = new System.Windows.Point((int)x, (int)y);
                Mouse.Instance.Click(p);

                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DELETE);
                Thread.Sleep(1000);
                Keyboard.Instance.Enter(count.ToString());
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception occured " + ex.Message);
            }
        }

        private AutomationElementCollection FindElementFromAutomationID(AutomationElement targetApp, string name)
        {
            return targetApp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, name));
        }

        /// <summary>
        /// Load Model Config File
        /// </summary>
        public void LoadModelConfigFile(string modelFilePath)
        {
            try
            {

                adaAppLicenseGeneratorWindow.Get<Tab>(SearchCriteria.ByAutomationId("tabControl1")).Click();
                adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByText("STEP 3.2: Upload Algorithm Configuration")).Click();
                adaAppLicenseGeneratorWindow.Get<Button>(SearchCriteria.ByAutomationId("_doLoadModelConfigFile")).Click();
                Thread.Sleep(5000);
                string file = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\"));
                string filePath = Path.Combine(file + "Input Files\\Algorithm Files\\");
                string algoPath = Path.Combine(filePath + modelFilePath);
                adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByClassName("Edit")).SetValue(algoPath);
                Thread.Sleep(1000);
                adaAppLicenseGeneratorWindow.Get<Button>(SearchCriteria.ByAutomationId("1")).Click();

                Thread.Sleep(4000);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception occured " + ex);
            }
        }

        /// <summary>
        /// Load Visualisation Config File
        /// </summary>
        public void LoadVisualisationConfigFile(string visualisationFilePath)
        {
            try
            {
                adaAppLicenseGeneratorWindow.Get<Tab>(SearchCriteria.ByAutomationId("tabControl1")).Click();
                adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByText("STEP 3.3: Upload Algorithm Visualisation Configuration")).Click();
                Thread.Sleep(1000);
                adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByAutomationId("_doLoadVisualisationConfigFile")).Click();
                Thread.Sleep(1000);
                string file = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\"));
                string filePath = Path.Combine(file + "Input Files\\Visualization Files\\");
                string visualizationPath = Path.Combine(filePath + visualisationFilePath);
                adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByClassName("Edit")).SetValue(visualizationPath);
                Thread.Sleep(1000);
                adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByAutomationId("1")).Click();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Genereate Single algorithm
        /// </summary>
        /// <param name="code"></param>
        /// <param name="count"></param>
        /// <param name="equipmentType"></param>
        /// <param name="authorName"></param>
        /// <param name="algorithmName"></param>
        /// <param name="algTypeCode"></param>
        public void EnterGeneralSettingsDataInLicenseGenerator(string code, int count, string equipmentType, string authorName)
        {
            try
            {
                SetGeneralSettings(code, count, equipmentType, authorName);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UploadAlgorithmDetails(string algorithmName, string algTypeCode, int count, string algorithmFile, string visualizationFile)
        {
            SetAlgorithmGeneralSetttings(algorithmName, algTypeCode, count);
            LoadModelConfigFile(algorithmFile);
            LoadVisualisationConfigFile(visualizationFile);
        }

        /// <summary>
        /// Clicks on Genrate license 
        /// </summary>
        public void ClickGenerateLicense()
        {
            adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByAutomationId("doGenerateLicense")).Click();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Saves genrated license file
        /// </summary>
        public void SaveGenratedLicenseFile(string fileName)
        {
            try
            {
                var modalWindows = adaAppLicenseGeneratorWindow.ModalWindows();
                foreach (var win in modalWindows)
                {
                    Thread.Sleep(3000);
                    if (win.Name.Equals("LicenseFileViewer"))
                    {
                        win.DisplayState = DisplayState.Maximized;
                        win.Get(SearchCriteria.ByAutomationId("doSave")).Click();
                        Thread.Sleep(1000);
                        string path = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\..\..\..\..\..\"));
                        path = Path.Combine(path + fileName);
                        if (File.Exists(path))
                        {
                            // If file found, delete it    
                            File.Delete(path);
                        }
                        Thread.Sleep(1000);
                        adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByClassName("Edit")).SetValue(path);
                        adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByText("Save")).Click();
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception occured " + ex.Message);
            }
        }

        /// <summary>
        /// Generate single algo license
        /// </summary>
        /// <param name="activationCode"></param>
        /// <param name="maxAssignmentCount"></param>
        /// <param name="equipmentType"></param>
        /// <param name="authorName"></param>
        /// <param name="algorithmName"></param>
        /// <param name="algTypeCode"></param>
        /// <param name="algorithmFile"></param>
        /// <param name="visualizationFile"></param>
        /// <param name="licensefileName"></param>
        public void GenerateSingleAlgoLicense(string activationCode, int maxAssignmentCount = 25, string equipmentType = "Atlas Abatement", string authorName = "PdmTestUser",
            string algorithmName = "SingleAlgorithm", string algTypeCode = "Noz1", string algorithmFile = "MdxN3Compressed_VG04_Alarm.xml",
            string visualizationFile = "VisualisationXML_Algorithm.txt", string licensefileName = "SingleAlgorithm.alf")
        {
            LaunchPdMLicenseGeneratorApp();
            SetDatabase();
            EnterGeneralSettingsDataInLicenseGenerator(activationCode, maxAssignmentCount, equipmentType, authorName);
            UploadAlgorithmDetails(algorithmName, algTypeCode, maxAssignmentCount, algorithmFile, visualizationFile);
            Thread.Sleep(1000);
            ClickGenerateLicense();
            SaveGenratedLicenseFile(licensefileName);
            KillProcess();
        }

        /// <summary>
        /// Generate Multi algo license
        /// </summary>
        /// <param name="activationCode"></param>
        /// <param name="maxAssignmentCount"></param>
        /// <param name="equipmentType"></param>
        /// <param name="authorName"></param>
        /// <param name="algorithmName"></param>
        /// <param name="algTypeCode"></param>
        /// <param name="algorithmFile"></param>
        /// <param name="visualizationFile"></param>
        /// <param name="licensefileName"></param>
        public void GenerateMultiAlgoLicense(string activationCode, int maxAssignmentCount = 25, string equipmentType = "Atlas Abatement", string authorName = "PdmTestUser",
            string firstAlgoName = "MultiAlgo1", string secondAlgoName = "MultiAlgo2", string algTypeCode = "Noz1", string firstAlgoFile = "MdxN3Compressed_VG04_Alarm.xml",
            string secondAlgoFile = "MdxN3Compressed_VG04_Warning.xml", string visualizationFile = "VisualisationXML_Algorithm.txt", string licensefileName = "MultipleAlgorithm.alf")
        {
            LaunchPdMLicenseGeneratorApp();
            SetDatabase();
            EnterGeneralSettingsDataInLicenseGenerator(activationCode, maxAssignmentCount, equipmentType, authorName);
            UploadAlgorithmDetails(firstAlgoName, algTypeCode, maxAssignmentCount, firstAlgoFile, visualizationFile);
            UploadAlgorithmDetails(secondAlgoName, algTypeCode, maxAssignmentCount, secondAlgoFile, visualizationFile);
            Thread.Sleep(1000);
            ClickGenerateLicense();
            SaveGenratedLicenseFile(licensefileName);
            KillProcess();
        }
        
        /// <summary>
        /// Update the XML File
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="algorithmFile"></param>
        public void UpdateXML(string algorithmFile, string fileName)
        {
            UpdateExpiryDate();
            Thread.Sleep(1000);
            LoadModelConfigFile(algorithmFile);
            Thread.Sleep(1000);
            ClickGenerateLicense();
            Thread.Sleep(1000);
            SaveGenratedLicenseFile(fileName);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// To Open Already created License
        /// </summary>
        /// <param name="fileName"></param>
        public void OpenLicense(string fileName)
        {
            adaAppLicenseGeneratorWindow.Get<Button>(SearchCriteria.ByAutomationId("_doOpenLicense")).Click();
            Thread.Sleep(2000);
            string file = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\..\..\..\..\..\"));
            string algoPath = Path.Combine(file + fileName);
            Thread.Sleep(2000);
            adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByClassName("Edit")).SetValue(algoPath);
            Thread.Sleep(3000);
            adaAppLicenseGeneratorWindow.Get<Button>(SearchCriteria.ByAutomationId("1")).Click();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// To Update the Expiry date
        /// </summary>
        public void UpdateExpiryDate()
        {
            adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByAutomationId("_applicationExpiresAt")).Click();
            Thread.Sleep(2000);
            for (int i = 0; i < 2; i++)
            {
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.LEFT);
            }
            Thread.Sleep(2000);
            for (int i = 0; i < 5; i++)
            {
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.UP);
            }
            Thread.Sleep(2000);
        }

        /// <summary>
        /// To get the Unique ID
        /// </summary>
        /// <returns></returns>
        public string UniqueID()
        {
            string id = adaAppLicenseGeneratorWindow.Get(SearchCriteria.ByAutomationId("_uniqueId")).Name;
            return id;
        }

        /// <summary>
        /// get the Expiry Date
        /// </summary>
        /// <returns></returns>
        public string ExpiryDate()
        {
            var dateTimePicker = adaAppLicenseGeneratorWindow.Get<DateTimePicker>(SearchCriteria.ByAutomationId("_applicationExpiresAt"));
            var tempDate = dateTimePicker.Date;
            var expiryDate = tempDate.Value.ToString("MM/dd/yyyy");
            return expiryDate;
        }
    }
}

