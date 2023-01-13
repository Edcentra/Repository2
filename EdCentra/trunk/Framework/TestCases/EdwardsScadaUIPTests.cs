//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using log4net;


//namespace Edwards.Scada.Test.Framework.TestCases
//{
//    using System.IO;
//    using System.Reflection;
//    using System.Threading;
//    using Edwards.Scada.Test.Framework.Contract;
//    namespaces
//    using Edwards.Scada.Test.Framework.GlobalHelper;
//    using Edwards.Scada.Test.Framework.Pages;
//    using OpenQA.Selenium;
//    using OpenQA.Selenium.Support.UI;

//    [TestFixture]
//    public class EdwardsScadaUIPTests : ApplicationBase
//    {

//        private static readonly ILog Logger = LoggerManager.GetLogger(typeof(EdwardsScadaUIPTests));
//        public const string Category = "Edwards.Scada.Test.Framework.TestCases.UIP";

//        [Test, Category(Category)]
//        public void UserLogin()
//        {

//            try
//            {
//            ARRANGE:
//                LoginPage loginpage = new LoginPage(driver);
//            ACT:
//                loginpage.SignIn(TestSettingsReader.UserName, TestSettingsReader.Password);
//                string LoggedInUser = loginpage.DisplayedUser();
//                Logger.Info("Getting logged in user name displayed at right bottom corner");

//            ASSERT:
//                Assert.That(LoggedInUser.Equals(TestSettingsReader.UserName));
//                Logger.Info("Verifying the logged in user name displayed on at right bottom corner");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(String.Concat(ex.StackTrace, ex.Message));

//                if (ex.InnerException != null)
//                {
//                    Console.WriteLine("Inner Exception");
//                    Console.WriteLine(String.Concat(ex.InnerException.StackTrace,
//                    ex.InnerException.Message));
//                }
//            }
//        }


//        [Test, Category(Category)]
//        public void CreateAndDeleteUserGroup()
//        {
//            HomePage homepage = new HomePage(driver);
//            CurrentUserPage currentuserpage = new CurrentUserPage(driver);
//            GroupPage grouppage = new GroupPage(driver);
//            string GroupName = "TestGroup_" + Guid.NewGuid().ToString();
//            string Description = "Description_" + Guid.NewGuid().ToString();
//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();


//            ACT:
//                homepage.NavigateToCurrentUserPage();
//                Logger.Info("navigate to current user page");
//                currentuserpage.ClickOnMaintainGroupTab();
//                Logger.Info("Click on main group option tab");
//                grouppage.CreateGroup(GroupName, Description);
//                string feedbackMessage = grouppage.GetConformationFeedback();

//            ASSERT:
//                Assert.That(feedbackMessage.Equals("New Group Has Been Created"));
//                Logger.Info("Verifiesd the message displayed once the group is created successfully");
//            }

//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }

//            finally
//            {
//                grouppage.DeleteUserGroup(GroupName);
//                Logger.Info("The group has been deleted");
//            }

//        }


//        [Test, Category(Category)]
//        public void EditGroupDetails()
//        {


//            GroupPage grouppage = new GroupPage(driver);
//            HomePage homepage = new HomePage(driver);
//            CurrentUserPage currentuserpage = new CurrentUserPage(driver);
//            string GroupName = "TestGroup_" + Guid.NewGuid().ToString();
//            string Description = "Description_" + Guid.NewGuid().ToString();

//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                Logger.Info("logging in application first to perform next action..");
//            ACT:
//                homepage.NavigateToCurrentUserPage();
//                Logger.Info("navigate to current user page");
//                currentuserpage.ClickOnMaintainGroupTab();
//                Logger.Info("Click on main group option tab");
//                grouppage.CreateGroup(GroupName, Description);
//                Thread.Sleep(2000);
//                string feedbackMessage = grouppage.GetConformationFeedback();

//            ASSERT:
//                Assert.That(feedbackMessage.Equals("New Group Has Been Created"));

//                Thread.Sleep(3000);
//                string GroupNameUpdated = "TestGroup_UPdated" + Guid.NewGuid().ToString();
//                string DescriptionUpdated = "Description_Updated" + Guid.NewGuid().ToString();

//            ACT:
//                grouppage.ModifyGroupDetails(GroupNameUpdated, DescriptionUpdated);
//                Thread.Sleep(2000);
//                var feebackMessageForDetailsUpdate = grouppage.GetConformationFeedback();

//            ASSERT:
//                Assert.That(feebackMessageForDetailsUpdate.Equals("Changes have been applied"));
//                Logger.Info("The User group details has been updated");

//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }

//            finally
//            {

//                grouppage.DeleteUserGroup(GroupName);
//                Logger.Info("The group has been deleted");
//            }
//        }
//        [Test, Category(Category)]
//        public void CreatAndDeleteUser()
//        {
//            UserPage userpage = new UserPage(driver);
//            HomePage homepage = new HomePage(driver);
//            CurrentUserPage currentuserpage = new CurrentUserPage(driver);
//        ARRANGE:
//            string UserName = "TestUser";
//            string Password = "Pa$$word@123";
//            string ConformPassword = Password;
//            string FirstName = "FN_Test";
//            string LastName = "LN_User";
//            string Email = UserName + "@mail.com";
//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                homepage.NavigateToCurrentUserPage();
//                Logger.Info("navigate to current user page");
//                currentuserpage.ClickOnMaintainUsersTab();


//            ACT:
//                userpage.CreateNewUser(UserName, Password, ConformPassword, FirstName, LastName, Email);
//                var CreateUSerConformationMessage = userpage.ConformationMessage();

//            ASSERT:
//                Assert.That(CreateUSerConformationMessage.Equals("New User Has Been Created"));
//                Logger.Info("New User has been created");
//            }

//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            finally
//            {
//                userpage.DeleteUser(UserName);
//                Logger.Info("The User has been deleted");
//            }

//        }

//        [Test, Category(Category)]
//        public void EditUserDetails()
//        {
//            UserPage userpage = new UserPage(driver);
//            HomePage homepage = new HomePage(driver);
//            CurrentUserPage currentuserpage = new CurrentUserPage(driver);
//        ARRANGE:
//            string UserName = "TestUser";
//            string Password = "Pa$$word@123";
//            string ConformPassword = Password;
//            string FirstName = "FN_Test";
//            string LastName = "LN_User";
//            string Email = UserName + "@mail.com";
//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();


//            ACT:
//                homepage.NavigateToCurrentUserPage();
//                Logger.Info("navigate to current user page");
//                currentuserpage.ClickOnMaintainUsersTab();
//                userpage.CreateNewUser(UserName, Password, ConformPassword, FirstName, LastName, Email);
//                var CreateUSerConformationMessage = userpage.ConformationMessage();

//            ASSERT:
//                Assert.That(CreateUSerConformationMessage.Equals("New User Has Been Created"));

//                ARRANGE for Edit detail
//                string FirstNameUpdated = "Updated_FN";
//                string LastNameUPdated = "Updated_LN";
//                string EmailUpdated = FirstNameUpdated + "@gmail.com";

//            ACT:
//                userpage.EditUSerDetails(UserName, FirstNameUpdated, LastNameUPdated, EmailUpdated);
//                Thread.Sleep(3000);
//                string ConformationMessage = userpage.ConformationMessage();

//            ASSERT:
//                Assert.That(ConformationMessage.Equals("Changes have been applied"));
//                Logger.Info("The User details has been updated");
//                Thread.Sleep(2000);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            finally
//            {
//                userpage.DeleteUser(UserName);
//                Logger.Info("The User has been deleted");
//            }

//        }
//        [Test, Category(Category)]
//        public void CreateAndDeleteFolder()
//        {

//            HomePage homepage = new HomePage(driver);
//            DeviceExplorerNavigationPage deviceexplorerpage = new DeviceExplorerNavigationPage(driver);

//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                homepage.NavigateToDeviceExplorerPage();
//                string FolderName = "TestFolder";

//            ACT:
//                var CreatedFolder = deviceexplorerpage.CreateFolder(FolderName);

//            ASSERT:
//                Assert.That(CreatedFolder.Equals(FolderName), "Created folder is not same");
//                Thread.Sleep(3000);
//                deviceexplorerpage.DeleteCreatedFolder(FolderName);



//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//        [Test, Category(Category)]
//        public void Find_Add_RemoveSystem()
//        {
//            HomePage homepage = new HomePage(driver);
//            DeviceExplorerNavigationPage deviceexplorerpage = new DeviceExplorerNavigationPage(driver);
//            string FolderName = "TestFolder";
//            try
//            {

//            ARRANGE:
//                LoginToEdwardsScada();
//                homepage.NavigateToDeviceExplorerPage();


//            ACT:
//                deviceexplorerpage.CreateFolder(FolderName);
//                Thread.Sleep(2000);
//                deviceexplorerpage.SelectFolderMain(FolderName);
//                Thread.Sleep(2000);
//                deviceexplorerpage.AddEquipmentToSystem();
//                Thread.Sleep(2000);
//                var ConformationForDeviceAdded = deviceexplorerpage.GetConformationMessage();
//                deviceexplorerpage.ClickOkAfterConformationMessage();

//            ASSERT:
//                Assert.That(ConformationForDeviceAdded.Equals("Equipment Added Successfully"));
//                Thread.Sleep(3000);
//                var ConformationWithCancelToDeviceRemove = deviceexplorerpage.RemoveEquipmentFromSystemWithCancelDelete();
//                deviceexplorerpage.ClickOnCancelConformation();

//                deviceexplorerpage.RemoveEquipmentFromSystemWithConformDelete();
//                var ConformationDeviceRemoved = deviceexplorerpage.GetConformationMessage();
//                Thread.Sleep(3000);
//                Assert.That(ConformationDeviceRemoved.Equals("Equipment Removed Successfully"));
//                deviceexplorerpage.ClickOkAfterConformationMessage();
//                Thread.Sleep(3000);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }

//            finally
//            {

//                deviceexplorerpage.DeleteCreatedFolder(FolderName);
//            }

//        }

//        [Test, Category(Category)]
//        public void AlertHistoryDetail()
//        {
//            HomePage homepage = new HomePage(driver);
//            LiveAlertsListPage alertpage = new LiveAlertsListPage(driver);

//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                homepage.NavigateToLiveAlertPage();
//                alertpage.GoToAlertHistoryDetailTab();
//                bool AlertData = alertpage.IsAlertHistoryDataPresent();
//                Assert.IsTrue(AlertData, "Data is not present into history");

//                alertpage.CloseAlertHistory();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }

//        }

//        [Test, Category(Category)]
//        public void LiveALerts()
//        {
//            HomePage homepage = new HomePage(driver);
//            LiveAlertsListPage alertpage = new LiveAlertsListPage(driver);

//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                homepage.NavigateToLiveAlertPage();
//                Thread.Sleep(2000);
//                Assert.That(alertpage.GetErrorTooltipText().Equals(alertpage.ActiveErrorDisplayed()), "Displaying wrong error data");
//                Thread.Sleep(2000);
//                Assert.That(alertpage.GetWarningTooltipText().Equals(alertpage.ActiveWarningDisplayed()), "Displaying wrong warning data");
//                Thread.Sleep(2000);
//                Assert.That(alertpage.GetInfoAdvisoryTooltipText().Equals(alertpage.ActiveINfoAdvisoryDisplayed()), "Displaying wrong info advisory data");
//                Thread.Sleep(2000);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//        [Test, Category(Category)]
//        public void ConsumptionReportSummary()
//        {
//            HomePage homepage = new HomePage(driver);
//            ReportPage reportpage = new ReportPage(driver);

//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                homepage.NavigateToReportPage();

//            ACT:
//                reportpage.SelectConsumptionReportForSummary();
//                Thread.Sleep(5000);

//                Assert.That(reportpage.IsConsumptionSummaryPresent(), "Report having issue to load...");
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }

//        }

//        [Test, Category(Category)]
//        public void CreateAndDeleteLoggingProfile()
//        {
//            HomePage homepage = new HomePage(driver);
//            LoggingPage loggingpage = new LoggingPage(driver);
//            string ProfileName = "TestProfile";
//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                homepage.NavigateToLoggingPage();


//                loggingpage.CreateProfile(ProfileName);
//                string ProfileTitle = loggingpage.GetProfileTitle();
//                Thread.Sleep(2000);
//                Assert.That(ProfileTitle.Equals(ProfileName), "Profile Title is not present..");
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.InnerException.Message);
//            }
//            finally
//            {
//                loggingpage.DeleteProfile(ProfileName);
//            }

//        }

//        [Test, Category(Category)]
//        public void LoggingProfile()
//        {
//            HomePage homepage = new HomePage(driver);
//            LoggingPage loggingpage = new LoggingPage(driver);
//            string ProfileName = "TestProfile";
//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                homepage.NavigateToLoggingPage();


//                loggingpage.CreateProfile(ProfileName);
//                string ProfileTitle = loggingpage.GetProfileTitle();
//                Assert.That(ProfileTitle.Equals(ProfileName), "Profile Title is not present..");
//                loggingpage.NavigateToEquipmentTab();
//                Thread.Sleep(2000);
//                loggingpage.FindEquipmentSystems();
//                Thread.Sleep(2000);
//                Assert.That(loggingpage.IsEquipmentPresent(), "No Equipment Found");
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            finally
//            {
//                loggingpage.DeleteProfile(ProfileName);
//            }
//        }

//        [Test, Category(Category)]
//        public void ApplyParameterSelection_LoggingProfile()
//        {
//            HomePage homepage = new HomePage(driver);
//            LoggingPage loggingpage = new LoggingPage(driver);

//            string ProfileName = "TestProfile";
//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                homepage.NavigateToLoggingPage();


//                loggingpage.CreateProfile(ProfileName);
//                Thread.Sleep(3000);
//                string ProfileTitle = loggingpage.GetProfileTitle();
//                Assert.That(ProfileTitle.Equals(ProfileName), "Profile Title is not present..");
//                Thread.Sleep(2000);
//                loggingpage.CheckedProfileParameter();
//                Thread.Sleep(2000);
//                loggingpage.ClickOnPredictiveMaintenanceLink();
//                loggingpage.ClickOnLoggingLink();
//                loggingpage.SelectCreatedProfile(ProfileName);
//                Assert.IsFalse(loggingpage.IsProfileParameterSelected(), "Profile parameter is selected");
//                Thread.Sleep(2000);
//                loggingpage.CheckedProfileParameter();
//                Thread.Sleep(2000);
//                loggingpage.ClickApplyChanges();
//                Thread.Sleep(2000);
//                loggingpage.ClickOnPredictiveMaintenanceLink();
//                loggingpage.ClickOnLoggingLink();
//                Thread.Sleep(2000);
//                loggingpage.SelectCreatedProfile(ProfileName);
//                Thread.Sleep(2000);
//                bool b = loggingpage.IsProfileParameterOn();
//                Assert.IsTrue(b, "Profile parameter is not selected");

//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            finally
//            {
//                loggingpage.DeleteProfile(ProfileName);
//            }
//        }

//        [Test, Category(Category)]
//        public void CreateAndDeletePTMProfile()
//        {
//            HomePage homepage = new HomePage(driver);
//            PTMPage ptmpage = new PTMPage(driver);
//            string ProfileName = "TestProfile";
//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                homepage.NavigateToPTMPage();
//            ACT:
//                ptmpage.CreateProfile(ProfileName);
//                Thread.Sleep(3000);
//                string ptmProfileTitle = ptmpage.GetPTMProfileTitle();

//                Thread.Sleep(2000);
//            ASSERT:
//                Assert.That(ptmProfileTitle.Equals(ProfileName), "Something wrong getting ptm profile title");

//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            finally
//            {
//                ptmpage.DeletePTMProfile(ProfileName);
//            }

//        }
//        [Test, Category(Category)]
//        public void ParameterThreasholdMonitoringProfile()
//        {
//            HomePage homepage = new HomePage(driver);
//            PTMPage ptmpage = new PTMPage(driver);
//            string ProfileName = "TestProfile";
//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                homepage.NavigateToPTMPage();


//                ptmpage.CreateProfile(ProfileName);
//                Thread.Sleep(2000);
//                string ProfileTitle = ptmpage.GetPTMProfileTitle();
//                Assert.That(ProfileTitle.Equals(ProfileTitle), "PTM Profile Title is not present..");
//                ptmpage.NavigateToEquipmentTab();
//                ptmpage.FindEquipmentSystems();
//                Thread.Sleep(2000);
//                Assert.That(ptmpage.IsEquipmentPresent(), "No Equipment Found");
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            finally
//            {
//                ptmpage.DeletePTMProfile(ProfileName);
//            }
//        }
//        [Test, Category(Category)]
//        public void Historic_Data_Extraction()
//        {
//            HomePage homepage = new HomePage(driver);
//            DataExtractionPage dataextractionpage = new DataExtractionPage(driver);

//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                string Description = "Report_Historic_Extraction";
//                string StartDate = DateTime.Today.AddDays(-2).ToString("yyyy/MM/dd");
//                string EndDate = DateTime.Today.ToString("yyyy/MM/dd");

//            ACT:
//                homepage.NavigateToDataExtractionPage();
//                dataextractionpage.ExtractSystemData(Description, StartDate, EndDate);

//            ASSERT:
//                Assert.That(dataextractionpage.IsDownloadingInProgress().Contains("The Historic Extraction Utility is currently extracting data"), "Issue with extracting the data");

//                dataextractionpage.WaitForCompleteting_DataExtraction();

//                Assert.That(dataextractionpage.FileDownloadedPath().Contains("\\Edwards\\Scada\\Historic Extraction\\"), "Dat aExtract File doesn't exist.. ");


//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }

//        }
//        [Test, Category(Category)]
//        public void Configure_Scheduling()
//        {
//            HomePage homepage = new HomePage(driver);
//            DispatchManagerPage dispatchmanagerpage = new DispatchManagerPage(driver);

//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                homepage.NavigateToDispatchManagerPage();

//                string FromMail = "sample.email@mail.com";
//                string Server = "127.0.0.1";
//                string ToAddress = "sample.email@mail.com";
//                dispatchmanagerpage.CreateNewSMTPDestination(FromMail, Server, ToAddress);
//                dispatchmanagerpage.CreateNewSMTPAuthDestination(FromMail, Server, ToAddress);
//                dispatchmanagerpage.SwitchToSchedulerTab();
//                dispatchmanagerpage.CreateNewSchedule();
//                Thread.Sleep(10000);

//                Assert.That(dispatchmanagerpage.GetConformationMessage().Contains("New Schedule has been created"), "Issue with creating schedule");

//                dispatchmanagerpage.SelectCreatedSchedule();
//                Thread.Sleep(2000);
//                dispatchmanagerpage.ModifySchedule();
//                Thread.Sleep(6000);
//                Assert.That(dispatchmanagerpage.GetConformationMessage().Contains("Changes have been applied"), "Issue with apply changes");
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            finally
//            {
//                dispatchmanagerpage.DeleteSchedule();
//            }
//        }

//        [Test, Category(Category)]
//        public void Graphing_EquipmentData()
//        {
//            HomePage homepage = new HomePage(driver);
//            LoggingPage loggingpage = new LoggingPage(driver);
//            HistorianPage historianpage = new HistorianPage(driver);

//            try
//            {
//            ARRANGE:
//                LoginToEdwardsScada();
//                string FolderName = "IXH_Device_Folder";
//                homepage.NavigateToDeviceExplorerPage();
//                AddSystemEquipmentForGraphing();
//                Thread.Sleep(2000);
//                homepage.NavigateToLoggingPage();
//                Thread.Sleep(2000);
//                CreateLoggingProfile();
//                Thread.Sleep(2000);
//                loggingpage.NavigateToHomePage();
//                Thread.Sleep(2000);
//                homepage.NavigateToHistorianPage();
//                Thread.Sleep(2000);
//                historianpage.SelectSystemFolder(FolderName);
//                Thread.Sleep(2000);
//                historianpage.SelectFirstEquipmentsFromSelectedFolder();
//                Thread.Sleep(2000);
//                historianpage.SelectParaMeter();
//                Thread.Sleep(2000);
//                historianpage.LockParaMeters();
//                Thread.Sleep(2000);
//                bool A = historianpage.ISGraphDisplayedParameter();
//                Assert.IsTrue(A, "Graph doesn't display selected Paramater....");
//                historianpage.SelectSecondEquipmentsFromSelectedFolder();
//                Thread.Sleep(2000);
//                bool B = historianpage.ISRefreshHappned();
//                Thread.Sleep(2000);
//                Assert.IsTrue(B, "Graph doesn't refresh");
//                Thread.Sleep(2000);
//                historianpage.UnLockParaMeters();
//                Thread.Sleep(2000);
//                historianpage.SelectFirstEquipmentsFromSelectedFolder();

//                bool C = historianpage.ISRefreshHappned();

//                Assert.IsFalse(C, "Graph has refreshed");

//                Thread.Sleep(2000);
//                historianpage.ModifyParaMeters();
//                Thread.Sleep(2000);
//                historianpage.ClearGraph();
//                Thread.Sleep(2000);
//                historianpage.SelectParaMeter_EquipmentStatus();
//                Thread.Sleep(2000);
//                historianpage.Add_EquipmentStatus_ParaMeter();
//                Thread.Sleep(2000);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }





//        }

//        #region Common Methods

//        private void LoginToEdwardsScada()
//        {
//            LoginPage loginPage = new LoginPage(driver);
//            Logger.Info("Logging in using credentials");
//            loginPage.SignIn(TestSettingsReader.UserName, TestSettingsReader.Password);
//        }

//        private void CreateLoggingProfile()
//        {

//            LoggingPage loggingpage = new LoggingPage(driver);
//            string ProfileName = "TestProfile";

//            loggingpage.CreateProfile(ProfileName);
//            Thread.Sleep(3000);
//            string ProfileTitle = loggingpage.GetProfileTitle();
//            Assert.That(ProfileTitle.Equals(ProfileName), "Profile Title is not present..");
//            Thread.Sleep(2000);
//            loggingpage.SelectCreatedProfile(ProfileName);
//            Thread.Sleep(2000);
//            loggingpage.CheckedProfileParameter();
//            loggingpage.SelectTimeINterval_Normal();
//            loggingpage.SelectTimeINterval_Alert();
//            Thread.Sleep(2000);
//            loggingpage.ClickApplyChanges();
//            Thread.Sleep(2000);
//            loggingpage.NavigateToEquipmentTab();
//            Thread.Sleep(2000);
//            loggingpage.SelectEquipmentAndMoveToAssign();

//        }


//        private void AddSystemEquipmentForGraphing()
//        {
//            DeviceExplorerNavigationPage deviceexplorerpage = new DeviceExplorerNavigationPage(driver);
//            string FolderName = "IXH_Device_Folder";

//            deviceexplorerpage.CreateFolderForGraph(FolderName);
//            Thread.Sleep(2000);
//            deviceexplorerpage.SelectFolderMain(FolderName);
//            Thread.Sleep(2000);
//            deviceexplorerpage.AddEquipmentToSystem();
//            Thread.Sleep(2000);
//            var ConformationForDeviceAdded = deviceexplorerpage.GetConformationMessage();
//            deviceexplorerpage.ClickOkAfterConformationMessage();

//        ASSERT:
//            Assert.That(ConformationForDeviceAdded.Equals("Equipment Added Successfully"));
//        }
//        #endregion
//    }
//}
