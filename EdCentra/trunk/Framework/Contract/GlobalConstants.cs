using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Edwards.Scada.Test.Framework.Contract
{
    /// <summary>
    /// All constants go here.
    /// </summary>
    public static class GlobalConstants
    {
        public const string ActiveEnvironment = "ActiveEnvironment";
        public const string WebDriverPath = "WebDriverPath";
        public const string ActiveBrowser = "ActiveBrowser";
        public const string Username = "Username";
        public const string Password = "Password";
        public const string EnvironmentUrl = "ScadaEnvURL";
        public const string RequiredFieldValidationMessage = "Required Field";
        public const string TurnMaintenanceModeOn = "Maintenance for NEW0001 set to ON";
        public const string TurnMaintenanceModeOff = "Maintenance for NEW0001 set to OFF";
        public const string ChangesApplied = "Changes have been applied";
        public const string NoteAddedMsg = "Note attached successfully.";
        public const string EquipmentRemovedMsg = "Equipment Removed Successfully";
        public const string EquipmentAddedMsg = "Equipment Added Successfully";
        public const string FolderRenamedMsg = "Folder Renamed Successfully";
        public const string PasswordNotMatch = "Passwords do not match";
        public const string PasswordReset = "Password has been set to password123. Please change this as soon as possible";
        public const string PasswordChanged = "Your Password was changed successfully";
        public const string InvalidLogin=  "Invalid login details entered";
        public const string PageDestinationCreated = "Page Destination Created";
        public const string RenameHighlightedSet = "Rename Highlighted Set";
        public const string TitlePastePopUp = "Paste Configuration Set";
        public const string TitleComparePopUp = "Compare Configuration Sets";
        public const string DefaultsApplied = "Defaults Applied";
        public const string FilterApplied = "Filter Applied";
        public const string FilterChangedButNotApplied = "Filter Changed But Not Applied";
        public const string AlertMajorWarning = "Major Warning";
        public const string AlertMinorAlarm = "Minor Alarm";
        public const string AlertAdvisory = "Advisory";
        public const string AlertMajorAlarm = "Major Alarm";
        public const string AlertMinorWarning = "Minor Warning";
        public const string TurboWarningParameter = "CAUTION: CNT heat 2 Indicator (64)";
        public const string TurboAlarmParameter = "Motor Temperature (3)";
        public const string RaiseEquipmentAlertTurbo = "1";
        public const string ClearEquipmentAlertTurbo = "2";
        public const string ViSimulatorConnection = "3";
        public const string ViSimulatorStartUp = "5";
        public const string TurboCommunicationCode = "7";
        public const string FirstPortTurbo = "4000";
        public const string LastPortTurbo = "4005";
        public const string Equipment = "NEW0001PM1";
        public const string DeviceDecommissioned= "The equipment has been decommissioned successfully.";
        public const string TurboWindow = @"G:\Simulators\TMP\v2020.02\SoftwareSimulator.exe";
        public const string ViSimulatorWindow = @"G:\Simulators\_LatestVersion\VisionSim.exe";
        public const string ModbusWindow = @"G:\Simulators\Modbus\EasyModbusServerSimulator.exe";        
        public const string EissaWindowName = "EISSA";
        public const string ModbusWindowName = "EasyModbusTCP Server Simulator";
        public const string EissaWindowPath = @"G:\Simulators\EISSA\2.0.203 (Simulate CTi)\Edwards.EISSA.App.exe";
        public const string EissaWinProPath = @"C:\Simulators\EISSA\2.0.203 (Simulate CTi)\Edwards.EISSA.App.exe";
        public const string CodeGeneratorPath = @"G:\Simulators\CodeGenerator_4.5+\Edwards.Scada.Protection.CodeGenerator.exe";
        public const string CodeGeneratorSuperUser = @"G:\Simulators\CodeGenerator_Latest\Edwards.Scada.Protection.CodeGenerator.exe";
        public const string EdcentraInstallerLauncherPath = @"C:\Build\Edwards.Installer.Launcher.exe";
        public const string VirtualMachineUrl = "https://10.91.26.130/ui/#/host/vms/69";
        public const string TipOfTheDayManagerUrl = "http://160.100.28.72/tipofthedaymanager";
        public const string CodeGeneratorWebUrl = "http://ineextbt_adm:k6gs&9iyT7UA3!ez@160.100.28.7:81/?handler=GenerateAuthorizationCodes";
        public const string ExtractionPath = @"G:\Edwards\Scada\Historic Extraction";
        public const string ExtractionPath_Split = @"\\160.100.28.82\g$\Edwards\Scada\Historic Extraction";
        public const string LoginPassword = "!tikloot9";
        public const string ReportDefinitionPath = @"G:\Simulators\Report\ReportDefinitionConfigTool\All_ReportDefinition\All_ReportDefinition.xml";
        public const string ModbusFilePath = @"G:\Simulators\Modbus";
        public const string ReportConfigFolder = @"G:\Simulators\Report\ReportDefinitionConfigTool\All_ReportDefinition\ReportDefinition.enc";
        public const string MappingFilePath = @"G:\Simulators\SecsGem file\TestIXHVidMapping.csv";
        public const string MappingSecondFilePath = @"G:\Simulators\SecsGem file\TestIXHVidMapping2.csv";
        public const string RefreshTextColour = "rgba(1, 128, 211, 1)";
        public const string CommonTextColour = "rgba(0, 0, 0, 1)";
        public const string ExtractFilePath = @"G:\Edwards\Scada\Historic Extraction\";
        public const string TurnOnCommsMessage = "7";
        public const string AdjustableFilepath = @"G:\Simulators\Ajustable file\EISSASystemTestConfiguration_Adjustables.adj";
        public const string LogEntry = "Served: Equipment: NEW0001, File: datalog";
        public const string ScadaDSPUWindowName = "Scada DSPU";
        public const string VersionDefine = "15";
        public const string PortSelection = "X";
        public const string ControllerVersion = "31";
        public const string PumpVersion = "33";        
        public const string ReportPath = @"G:\Simulators\Report\ReportDefinitionConfigTool\Report_Configuration.exe";
        public const string ControlPanelPath = @"C:\Users\Administrator\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\System Tools\Control Panel.lnk";
        public const string DSPUSimulatorPath = @"G:\Simulators\DSPU_New\DSPU.exe";
        public const string RemoteDesktopPath = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Accessories\Remote Desktop Connection";
        public const string RegEdit = @"C:\Windows\regedit.exe";        
        public const string PausedServiceStatus = "Autopager processing has been paused.";
        public const string RunningServiceStatus = "Autopager processing has been continued.";
        public const string EquipmentAlarm = "TURBO4002. Alarm - 18: Motor Overheat (303). AL#1 WA#0 AD#0";
        public const string EquipmentWarning = "TURBO4002. Warning - 19: CAUTION: CNT heat 2 (6404)";
        public const string ReadingExceptionSettings = "Reading exception settings";
        public const string DispatchManagerSMTPSuccessMessage = "A test message has been placed on the queue.";
        public const string AlarmMessageSuccessfullySent = "Message successfully sent to SMTP server 160.100.30.222.";
        public const string NoSchedulingFoundForThisEvent = "No scheduling found which honours this event";
        public const string BlockedAutoPagerException = "Blocked AutoPager Exception ID: 1";
        public const string AlarmSystemConfigurationFault = ".NEW0001PM1. Alarm - System configuration fault (1_0).";
        public const string DataExtractionDescription = "Test Data Historic Extraction";
        public const string ADSSytemTestScenarioWindow = @"Scada DSPU - C:\ADS_SystemTest\DSPU_scenario.xml";
        public const string PdMLicenseGeneratorAppPath = @"C:\Users\Administrator\Desktop\PDM Testing\_LatestBuild\Coordinator\PdMLicenseGeneratorApp.exe";
        public const string CustomerName = "Edwards";
        public const string DbSettingsPopUpName = "Please enter the database name on the build server to be used (scada_Production_1_9_0; scada_Production_1_8_0; scada_production_1_7_1; scada_production_1_7_0):";
        public const string FingerprintNotes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris suscipit mollis rutrum. Aenean consequat diam metus, vitae elementum ex facilisis quis. Vestibulum convallis lorem velit, eu venenatis quam rutrum nec. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed ligula tortor, volutpat id lectus accumsan, pretium blandit odio. Vestibulum ac lorem fringilla, suscipit arcu sed, volutpat magna. Duis id convallis diam, sit amet tempus nibh. Cras luctus est sed mauris fermentum scelerisque.Proin lacinia ut mi eu tincidunt. Suspendisse maximus posuere pharetra. Fusce facilisis, eros id venenatis ullamcorper, magna eros dignissim eros, pellentesque condimentum lacus odio vitae nulla. Nulla hendrerit nisi in finibus tincidunt. Proin fermentum libero nec condimentum venenatis. Ut sit amet libero sit amet velit tincidunt commodo ac et nisl. Ut auctor laoreet massa, vitae tincidunt risus mollis tincidunt. Nunc feugiat, justo ac ornare massa nunc.";
        public const string TSStoreTempLogFilePath = @"C:\TS_STORE_TEMPLATE.log";
        public const string CSVFilePath = @"C:\Users\Administrator\Downloads";
        public const string AnalogueParameterOverrideDescription = "AnalogueInput";
        public const string DigitalParameterOverrideDescription = "DigitalInput";
        public const string SecsGemClientWindowPath = @"D:\Edwards\Scada\EdwardsSecsGem\Client\Edwards.Scada.SecsGem.Client.exe";
        public const string UnlockPin = "9110";
        public const string SecsGemClientWindowName = "SECS/GEM Support Host";
        public const string ImportProfileMsg = "You must enter a profile name";
        public const string ImportFileMsg = "No file selected";
        public const string ProfileNameExist = "Profile Name Already Exists";
        public const string CDIWindowPath = @"D:\Edwards\Packages\CDI_Win.exe";
        public const string CDIWindowName = "Login";
        public const string CDIFilePath = @"D:\Edwards\Packages";
        public const string CDIFileName = "CDI_Win.exe";
        public const string ErrorMessage = "You must enter a profile name";
        public const string CmdPromptPath = @"C:\Windows\System32\cmd.exe";
        public const string AssemblyBuildFileSource = @"‪G:\ScanAssemblyBuildType.exe";
        public const string AssemblyBuildFileDest = @"D:\Edwards";
        public const string AssemblyBuildfileName = "ScanAssemblyBuildType.exe";
        public const string AssemblyExpectedtxtPath = @"G:\Expected.txt";
        public const string installationLogPath = @"D:\Edwards\Scada\Database - Installation 4.1.0\schema.manifest.log";
        public const string dllFilePath = @"C:\Program Files (x86)\Edwards\DataLogger\TsStorePlugins\Edwards.TsStore.Plugin.Cumulocity.dll";
        public const string TemplateDllFilePath = @"C:\Program Files (x86)\Edwards\DataLogger\TsStorePlugins\TsStorePluginTemplate.dll.DISABLED";
        public const string ConfigFilePath = @"C:\Temp\localstorage_equipment.config";
        public const string targetDLL = @"C:\Program Files (x86)\Edwards\DataLogger\TsStorePlugins\Edwards.TsStore.Plugin.Cumulocity.dll.DISABLED";
        public const string targetTemplateDll = @"C:\Program Files (x86)\Edwards\DataLogger\TsStorePlugins\TsStorePluginTemplate.dll";
        public const string DataDifferenceErrorText = "UNEXPECTED : Static Data fst_LNG_Message";
        public const string SSMSExePath = @"G:\SSMS 17.1 -Setup-ENU.exe";
        public const string ConnectionErrMsg = "Cannot connect to";
        public const string SqlLoginUserName = "Sa";
        public const string SqlLoginPassword = "!Tat00ine";
        public const string ServerPropertyTex = "Latin1_General_CI_AS";
        public const string ScadaProductionFilePath1 = @"E:\MSSQLData\MSSQL$Scada\Data";
        public const string ScadaProductionFile1 = "scada_Production.mdf";
        public const string ScadaProductionFilePath2 = @"F:\MSSQLData\MSSQL$Scada\TransactionLog";
        public const string ScadaProductionFile2 = "scada_Production.ldf";
        public const string BackupScadaProductionFilePath1 = @"G:\fs_Maintenance\Backup";
        public const string BackupScadaProductionFile1 = "scada_Production.bak";
        public const string BackupScadaProductionFilePath2 = @"G:\fs_Maintenance\Backup";
        public const string BackupScadaProductionFile2 = "master.bak";
        public const string BackupFilePath1 = @"G:\fs_Maintenance\Backup\scada_Production.bak";
        public const string BackupFilePath2 = @"G:\fs_Maintenance\Backup\master.bak";
        public const string CDIFolderPath = @"G:\fs_maintenance\CDI\";
        public const string ImportFolderName = "CDI_Import";
        public const string sourceDir = @"G:\fs_maintenance\CDI\CDI_Export";
        public const string targetDir = @"G:\fs_maintenance\CDI\CDI_Import";
        public const string PackagePath = @"D:\Edwards\Packages";
        public const string FolderName = "2008R2";
    }
}




        
        
       
        




