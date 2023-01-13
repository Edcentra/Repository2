using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Configuration;
using System.Windows.Forms;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class SetUpPage : PageBase
    {
        private IWebDriver driver;
        /// <summary>
        /// Initializing page
        /// </summary>
        /// <param name="driver"></param>
        public SetUpPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        //object for ConfigureTests
        #region

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_ddlSystemType_Commission")]
        private IWebElement drpDownSelectEquipmentType;

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$ctl00$cphContent$cphContent$txtSystemName_Commission'][contains(@id,'Commission')]")]
        private IWebElement txtBoxEquipmentName;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_txtIPAddress_Commission']")]
        private IWebElement txtBoxIPAddress;

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$ctl00$cphContent$cphContent$txtIPPort_Commission'][contains(@id,'Commission')]")]
        private IWebElement txtBoxIPPortNumber;

        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement btnAddOnCommissionPopUp;

        [FindsBy(How = How.XPath, Using = "//input[@value='Find Equipment']")]
        private IWebElement btnFindEquipment;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Navigate')]")]
        private IWebElement lnkNavigate;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Manage Equipment')]")]
        private IWebElement lnkManageEquipment;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'No Equipment Found')]")]
        private IWebElement msgNoEquipmentFound;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'ctl00_ctl00_cphContent_cphContent_clstSystems_divListControl')]/table/tbody")]
        private IWebElement tblEquipment;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'btnDelete')]")]
        private IWebElement btnDelete;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnOKDelete')]")]
        private IWebElement btnOkDelete;

        [FindsBy(How = How.XPath, Using = "//input[@value='OK']")]
        private IWebElement btnOk;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalBody']//span[contains(@id,'lblPopupMessage')]")]
        private IWebElement lblMessage;

        [FindsBy(How = How.XPath, Using = "//div[@id='divAddBox']")]
        private IWebElement lnkAddDevice;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Create/Commission')]")]
        private IWebElement lnkCreateCommission;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblPopupMessage")]
        private IWebElement lblSuccessMessageAfterCreatingFolder;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_UpdatePanelLeftButtons')]")]
        private IWebElement lnkImportProfile;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_txtProfileName')]")]
        private IWebElement txtProfileName;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_uplProfile")]
        private IWebElement lnkuplProfile;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnCreate')]")]
        private IWebElement btnCreate;

        [FindsBy(How = How.Id, Using = "divLeftContainer")]
        private IWebElement lstProfiles;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'boxlist')]")]
        private IWebElement lstListedProfile;

        [FindsBy(How = How.XPath, Using = "//div[@class='settingstabs']//a[text()='Equipment']")]
        private IWebElement tabEquipment;

        [FindsBy(How = How.XPath, Using = "//div[@class='imgBtnWrapperBigger']//input[contains(@id,'btnGetSystems')]")]
        private IWebElement btnGetSystems;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnDelete')]")]
        private IWebElement btnDeleteProfile;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//input[contains(@id,'btnOKDelete')]")]
        private IWebElement btnOKDelete;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_clSelectedSystems_divListControl')]")]
        private IWebElement lnkAssignedEquipment;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnMoveSystemsFrom')]")]
        private IWebElement btnMoveSystemsFrom;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_clSystems_divListControl')]")]
        private IWebElement lnkEquipmentList;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'ctl00_ctl00_cphContent_cphContent_clSelectedSystems_divListControl')]")]
        private IWebElement lnkSlectedSytemList;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnMoveSystemsTo")]
        private IWebElement btnMoveSystemsTo;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnApply")]
        private IWebElement btnApply;

        [FindsBy(How = How.XPath, Using = "//span[@class='infomessage'][contains(.,'Changes have been applied')]")]
        private IWebElement lblSuccessMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalManualPopup']//span[contains(.,'Cannot delete profile if there is assigned equipment')]")]
        private IWebElement lblErrorDeleteProfileMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//input[contains(@id,'btnOKDeleteError')]")]
        private IWebElement btnOKDeleteError;

        [FindsBy(How = How.XPath, Using = "//div[@class ='sevbody']")]
        private IWebElement lnkSevPage;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_rfvName')]")]
        private IWebElement lblrfvName;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Profile Name Already Exists')]")]
        private IWebElement lblProfileNameAlreadyExists;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'loader')]")]
        private IWebElement lnkloader;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnMoveAllSystemsFrom')]")]
        private IWebElement btnMoveAllSystemsFrom;

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Configuration Handler']")]
        private IWebElement tabConfigurationHandler;

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Predictive Maintenance']")]
        private IWebElement tabPredictiveMaintenance;


        #endregion
        //Properties
        #region
        public IWebElement DrpDownSelectEquipmentType
        {
            get { return drpDownSelectEquipmentType; }
            set { drpDownSelectEquipmentType = value; }
        }
        public IWebElement TxtBoxEquipmentName
        {
            get { return txtBoxEquipmentName; }
            set { txtBoxEquipmentName = value; }
        }
        public IWebElement TxtBoxIPAddress
        {
            get { return txtBoxIPAddress; }
            set { txtBoxIPAddress = value; }
        }

        public IWebElement BtnFindEquipment
        {
            get { return btnFindEquipment; }
            set { btnFindEquipment = value; }
        }

        public IWebElement LblSuccessMessage
        {
            get { return lblSuccessMessage; }
            set { lblSuccessMessage = value; }
        }

        public IWebElement TxtProfileName
        {
            get { return txtProfileName; }
            set { txtProfileName = value; }
        }

        public IWebElement LnkSevPage
        {
            get { return lnkSevPage; }
            set { lnkSevPage = value; }
        }

        public IWebElement Lnkloader
        {
            get { return lnkloader; }
            set { lnkloader = value; }
        }

        public IWebElement TabEquipment
        {
            get { return tabEquipment; }
            set { tabEquipment = value; }
        }

        public IWebElement LnkImportProfile
        {
            get { return lnkImportProfile; }
            set { lnkImportProfile = value; }
        }



        #endregion
        //Methods

        /// <summary>
        /// Get confirmation message
        /// </summary>
        /// <returns></returns>
        public string GetConformationMessage()
        {
            return lblMessage.Text;
        }


        /// <summary>
        /// Enter commission details
        /// </summary>
        /// <param name="equipmentName"></param>
        /// <param name="equipmentType"></param>
        /// <param name="iPAdress"></param>
        /// <param name="iPPortNumber"></param>
        public void EnterCommissionedDetails(string equipmentName, string equipmentType, string iPAdress, string iPPortNumber)
        {
            Waits.WaitForElementVisible(driver, txtBoxEquipmentName);
            Waits.Wait(driver, 3000);
            txtBoxEquipmentName.Clear();
            txtBoxEquipmentName.SendKeys(equipmentName);
            Waits.Wait(driver, 3000);
            Waits.WaitForElementVisible(driver, drpDownSelectEquipmentType);
            ElementExtensions.SelectByText(drpDownSelectEquipmentType, equipmentType);
            Waits.WaitForElementVisible(driver, txtBoxIPAddress);
            Waits.Wait(driver, 3000);
            txtBoxIPAddress.Clear();
            txtBoxIPAddress.SendKeys(iPAdress);
            Waits.Wait(driver, 3000);
            Waits.WaitForElementVisible(driver, txtBoxIPPortNumber);
            txtBoxIPPortNumber.Clear();
            txtBoxIPPortNumber.SendKeys(iPPortNumber);
            Waits.Wait(driver, 3000);
            Waits.WaitForElementVisible(driver, btnAddOnCommissionPopUp);
            btnAddOnCommissionPopUp.Click();
            Waits.Wait(driver, 3000);
        }

        /// <summary>
        /// Delete all equipments
        /// </summary>
        /// <param name="driver"></param>
        public void DeleteAllEquipments(IWebDriver driver)
        {
            bool flag = false;
            Actions ac = new Actions(driver);
            try
            {
                lnkManageEquipment.Click();
                Waits.WaitForElementVisible(driver, btnFindEquipment);
                btnFindEquipment.Click();
                Waits.Wait(driver, 2000);
                flag = msgNoEquipmentFound.Displayed;
            }
            catch (NoSuchElementException)
            {
                Waits.Wait(driver, 3000);
                List<IWebElement> lstEquipment = new List<IWebElement>(tblEquipment.FindElements(By.TagName("tr")));
                if (lstEquipment.Count == 1)
                {
                    lstEquipment[0].Click();
                    JavaScriptExecutor.JavaScriptClick(driver, btnDelete);
                    JavaScriptExecutor.JavaScriptClick(driver, btnOkDelete);
                    GetConformationMessage().Contains("Equipment Deleted Successfully");
                    Thread.Sleep(2000);
                    JavaScriptExecutor.JavaScriptClick(driver, btnOk);
                    Thread.Sleep(2000);
                    flag = msgNoEquipmentFound.Displayed;
                }
                else if (lstEquipment.Count > 1)
                {
                    lstEquipment[0].Click();
                    ac.SendKeys(OpenQA.Selenium.Keys.Shift).Perform();
                    JavaScriptExecutor.JavaScriptScrollToElement(driver, lstEquipment.Last());
                    lstEquipment.Last().Click();
                    JavaScriptExecutor.JavaScriptClick(driver, btnDelete);
                    JavaScriptExecutor.JavaScriptClick(driver, btnOkDelete);
                    GetConformationMessage().Contains("Equipment Deleted Successfully");
                    Thread.Sleep(2000);
                    JavaScriptExecutor.JavaScriptClick(driver, btnOk);
                    Thread.Sleep(2000);
                    flag = msgNoEquipmentFound.Displayed;
                }
            }
            finally
            {
                if (flag)
                    ac.Click(lnkNavigate).Build().Perform();
            }
        }

        /// <summary>
        /// Add Equipment
        /// </summary>
        /// <param name="equipmentName"></param>
        /// <param name="equipmentType"></param>
        /// <param name="iPAdress"></param>
        /// <param name="iPPortNumber"></param>
        public void AddEquipment(string equipmentName, string equipmentType, string iPAdress, string iPPortNumber)
        {
            Waits.WaitAndClick(driver, lnkAddDevice);
            Waits.WaitAndClick(driver, lnkCreateCommission);
            EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
            Waits.WaitForElementVisible(driver, lblSuccessMessageAfterCreatingFolder);
            Assert.IsTrue(lblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.EquipmentAddedMsg), "Verifying 'Equipment Added Successfully' message");
            Waits.WaitAndClick(driver, btnOk);
            Waits.Wait(driver, 2000);
        }

        /// <summary>
        /// Import File Creation
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="model"></param>
        public void ImportFile(string profile, string model)
        {
            if (IsProfileExist(profile))
            {
                DeleteProfile(profile);
            }
            Waits.WaitForElementVisible(driver, txtProfileName);
            txtProfileName.Clear();
            txtProfileName.SendKeys(profile);
            if (ElementExtensions.isDisplayed(driver, lblrfvName))
            {
                txtProfileName.Clear();
                txtProfileName.SendKeys(profile);
            }
            ImportModel(model);
            for (int i = 0; i < 15; i++)
            {
                Waits.Wait(driver, 1000);
                if (!ElementExtensions.isDisplayed(driver, lnkloader))
                {
                    Waits.Wait(driver, 1000);
                    break;
                }
                else
                {
                    Waits.Wait(driver, 1000);
                    continue;
                }

            }
            for (int j = 0; j < 15; j++)
            {
                Waits.Wait(driver, 1000);
                if (IsProfileExist(profile))
                {
                    Waits.Wait(driver, 1000);
                    break;
                }
                else
                {
                    Waits.Wait(driver, 1000);
                    Waits.WaitAndClick(driver, tabConfigurationHandler);
                    Waits.Wait(driver, 1000);
                    Waits.WaitAndClick(driver, tabPredictiveMaintenance);
                    Waits.Wait(driver, 1000);
                    if (IsProfileExist(profile))
                    {
                        Waits.Wait(driver, 1000);
                        break;
                    }
                    continue;
                }
            }
        }

        /// <summary>
        /// To Import Model
        /// </summary>
        /// <param name="model"></param>
        public void ImportModel(string model)
        {
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, lnkuplProfile);
            Waits.Wait(driver, 4000);
            System.Windows.Forms.SendKeys.SendWait(model);
            Waits.Wait(driver, 4000);
            System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
            Waits.Wait(driver, 4000);
            Waits.WaitAndClick(driver, btnCreate);
            Waits.WaitForElementVisible(driver, lnkloader);
            for (int i = 0; i < 5; i++)
            {
                if (ElementExtensions.isDisplayed(driver, lblProfileNameAlreadyExists))
                {
                    Waits.WaitAndClick(driver, lnkuplProfile);
                    Waits.Wait(driver, 1000);
                    System.Windows.Forms.SendKeys.SendWait(model);
                    Waits.Wait(driver, 1000);
                    System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
                    Waits.WaitAndClick(driver, btnCreate);
                }
            }

        }


        /// <summary>
        /// Profile if exists
        /// </summary>
        /// <param name="profile"></param>
        public bool IsProfileExist(string profile)
        {
            bool flag = false;
            try
            {
                Waits.WaitForElementVisible(driver, lstProfiles);
                List<IWebElement> importProfileList = new List<IWebElement>(lstProfiles.FindElements(By.XPath("//div//ul//li//div")));
                if (importProfileList.Count() > 0)
                {
                    foreach (IWebElement listItem in importProfileList)
                    {
                        if (listItem.Text.Contains(profile))
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
                }
                if (flag == false)
                {
                    List<IWebElement> newLoggingProfileList = new List<IWebElement>(lstListedProfile.FindElements(By.XPath("//a//div")));
                    Waits.Wait(driver, 2000);
                    if (newLoggingProfileList.Count() > 0)
                    {
                        foreach (IWebElement listItem in newLoggingProfileList)
                        {
                            if (listItem.Text.ToLower().Contains(profile.ToLower()))
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
                    }
                }
            }
            catch (StaleElementReferenceException)
            {
                driver.Navigate().Refresh();
                Waits.Wait(driver, 3000);
            }
            catch (NullReferenceException)
            {
                Waits.Wait(driver, 3000);
            }
            return flag;
        }

        /// <summary>
        /// Delete the already created profile 
        /// </summary>
        /// <param name="profile"></param>
        public void DeleteProfile(string profile)
        {
            SelectCreatedProfile(profile);
            Waits.WaitAndClick(driver, btnDeleteProfile);
            Waits.WaitAndClick(driver, btnOKDelete);
            Waits.Wait(driver, 1000);
            if (ElementExtensions.isDisplayed(driver, lblErrorDeleteProfileMessage))
            {
                Waits.WaitAndClick(driver, btnOKDeleteError);
                SelectCreatedProfile(profile);
                Waits.WaitAndClick(driver, tabEquipment);
                Waits.WaitAndClick(driver, btnMoveAllSystemsFrom);
                Waits.WaitAndClick(driver, btnDeleteProfile);
                Waits.WaitAndClick(driver, btnOKDelete);
                Waits.Wait(driver, 2000);
                if (ElementExtensions.isDisplayed(driver, lblSuccessMessage))
                {
                    Waits.WaitAndClick(driver, lnkImportProfile);
                    Waits.Wait(driver, 1000);
                }
            }
        }


        /// <summary>
        /// Select already Craeted Profile
        /// </summary>
        /// <param name="profile"></param>
        public void SelectCreatedProfile(string profile)
        {
            bool flag = false;
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    Waits.WaitForElementVisible(driver, lstProfiles);
                    if(flag)
                    {
                        break;
                    }
                    IWebElement baseTable = lstProfiles;
                    List<string> ProfileList = new List<string>();
                    ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));
                    foreach (IWebElement listItem in list)
                    {
                        if(listItem.Text.ToLower().Contains(profile.ToLower()))
                        {
                            Waits.WaitAndClick(driver, listItem);
                            flag = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                catch (StaleElementReferenceException)
                {
                    driver.Navigate().Refresh();
                    Waits.Wait(driver, 3000);
                }
                catch (NullReferenceException)
                {
                    Waits.Wait(driver, 3000);
                }
            }
        }

        /// <summary>
        /// Select Sytem device
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="device"></param>
        public void SelectSystem(string profile, string device)
        {
            SelectCreatedProfile(profile);
            Waits.WaitAndClick(driver, tabEquipment);
            Waits.WaitForElementVisible(driver, btnGetSystems);
            Waits.WaitAndClick(driver, btnGetSystems);
            Thread.Sleep(2000);
            MoveEquipment(device);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, btnMoveSystemsTo);
            Waits.Wait(driver, 1000);
            Waits.WaitAndClick(driver, btnApply);
        }

        /// <summary>
        /// Select Equipment
        /// </summary>
        /// <param name="device"></param>
        public void MoveEquipment(string device)
        {
            Waits.WaitForElementVisible(driver, lnkEquipmentList);
            List<IWebElement> EquipmentList = new List<IWebElement>(lnkEquipmentList.FindElements(By.TagName("td")));
            if (EquipmentList.Count > 0)
            {
                foreach (var list in EquipmentList)
                {
                    if (list.Text.Contains(device))
                    {
                        list.Click();
                        break;
                    }
                }
            }

        }

        /// <summary>
        /// To Verify Selected System Available
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool IsSystemExist(string device)
        {
            bool flag = false;
            Waits.WaitForElementVisible(driver, lnkSlectedSytemList);
            List<IWebElement> SystemList = new List<IWebElement>(lnkSlectedSytemList.FindElements(By.TagName("td")));
            if (SystemList.Count > 0)
            {
                foreach (var system in SystemList)
                {
                    if (system.Text.Contains(device))
                    {
                        Waits.Wait(driver, 1000);
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// Click to Enter the Folder
        /// </summary>
        /// <param name="folderName"></param>
        public void ClickOnFolder(string folderName)
        {
            try
            {
                folderName = folderName.Trim('"');
                IWebElement element = driver.FindElement(By.XPath("//div[@id='divBoxHead'][contains(.,'" + folderName + "')]"));
                string id = driver.FindElement(By.XPath("//span[@title = '" + folderName + "']")).GetAttribute("id");
                id = id.Remove(id.Length - 8);
                JavaScriptExecutor.JavaScriptScrollToElement(driver, element);
                string equipmentId = id + "hypSEV";
                Thread.Sleep(8000);
                driver.FindElement(By.Id(equipmentId)).Click();
                Waits.Wait(driver, 1000);
            }
            catch (StaleElementReferenceException)
            {
                ClickOnFolder(folderName);
            }
        }


        /// <summary>
        /// Read data
        /// </summary>
        public bool ReadData()
        {
            bool flag = false;
            try
            {
                string serverName = @".\FABWORKS";
                serverName = serverName.Replace(@"\", @"/");
                var connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "EXEC fsp_DART_ReadAvailability @strSystemID = N'AvailabilitySystemTesting',  @dtmStart = '2019-09-02 00:00:00', @dtmEnd = '2019-09-03 00:00:00', @lngUserID = 1, @intPageNumber = 1";
                        con.Open();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        int count = dt.Rows.Count;
                        if (count >= 1)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                var data = row.ItemArray;

                            }
                        }
                        else
                        {
                            flag = false;
                        }


                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                //connection.Close();
            }
            return flag;
        }
    }
}