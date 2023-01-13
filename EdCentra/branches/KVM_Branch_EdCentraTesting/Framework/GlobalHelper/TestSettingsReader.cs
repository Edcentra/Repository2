using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Edwards.Scada.Test.Framework.GlobalHelper
{


    //namespace list 
    using Edwards.Scada.Test.Framework.Contract;
    using System.Reflection;


    #region "TestSettingsReader Class"
    public class TestSettingsReader
    {

        private static TestSettingsReader _Instance = null;
        private static string EnvironmentVariable = "ScadaEnvURL";

        /// <summary>
        /// property indicating the active Evironment. 
        /// </summary>
        public string ActiveEnvironment { get; set; }

        /// <summary>
        /// property indicating the active Browser. 
        /// </summary>
        public BrowserType ActiveBrowser { get; set; }

        /// <summary>
        /// settings section represents the global settings. values in this section will be shared among all the supported environments. 
        /// </summary>
        public List<SettingsEntry> Settings { get; set; }

        /// <summary>
        /// settings block list of all supported environment settings. 
        /// </summary>
        public List<SettingsBlock> EnvironmentalSettings { get; set; }

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

        public static string path = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\"));
        public static string settingsFileName = Path.Combine(Path.Combine(path, @"Setup\EdwardsScadaTestSettings.xml"));

        /// <summary>
        /// get the deserialized instance of the test settingsReader instance.
        /// </summary>
        public static TestSettingsReader Instance  
        {
            get
            {
                if (_Instance == null)
                {
                    if (!File.Exists(settingsFileName))
                    {
                        throw new Exception(string.Format("settings file '{0}' doesn't exist under the test binary folder.", settingsFileName));
                    }

                    _Instance =
                        (TestSettingsReader)
                        (new XmlSerializer(typeof(TestSettingsReader))).Deserialize(
                            new StreamReader(settingsFileName));

                    if (EnvironmentVariableTestEnvironment != null)
                    {
                        _Instance.ActiveEnvironment = EnvironmentVariableTestEnvironment;
                    }
                }

                return _Instance;
            }

        }

        public static string EnvironmentVariableTestEnvironment
        {
            get
            {
                string env = System.Environment.GetEnvironmentVariable(TestSettingsReader.EnvironmentVariable, EnvironmentVariableTarget.User);
                return env;
            }
        }

        public static string EnvUrl
        {
            get
            {
                string envUrl = TestSettingsReader.GetSettingsValue(GlobalConstants.EnvironmentUrl);
                return envUrl;
            }
        }

        public static string Browser
        {
            get
            {
                string browser = TestSettingsReader.Instance.ActiveBrowser.ToString();
                return browser;
            }
        }

        public static string UserName
        {
            get
            {
                string userName = TestSettingsReader.GetSettingsValue(GlobalConstants.Username);
                return userName;
            }
        }

        public static string Password
        {
            get
            {
                string password = TestSettingsReader.GetSettingsValue(GlobalConstants.Password);
                return password;
            }
        }         
                                                  
              
        /// <summary>
        /// function to fetch setting value from the configuration file by the keyName specificed. 
        /// So the logic to fetch the settings will be - 
        /// 1. search thru the configuration file and see if the environmental settings block with the EnvironmentName matching the active environment value exists, if it does try to fetch the value of the settings with the key matching the name asked . 
        /// 2. if the above attempt is a NO GO, we will search the key from the default settings which is non-environment specific. 
        /// </summary>
        /// <param name="settingsName"></param>
        /// <returns></returns>
        public static string GetSettingsValue(string settingsName)
        {
            // step 1 we try to find the active environment settings block. 
            var environmentalSettings =
                Instance.EnvironmentalSettings.FirstOrDefault(settings => System.String.Compare(settings.EnvironmentName, Instance.ActiveEnvironment,
                                                                                                System.StringComparison.OrdinalIgnoreCase) == 0);
            if (environmentalSettings != null)
            {
                var settings =
                    environmentalSettings.Settings.FirstOrDefault(
                        setting => System.String.Compare(setting.Key, settingsName,
                                                         System.StringComparison
                                                               .OrdinalIgnoreCase) == 0);
                if (settings != null)
                    return settings.Value;
            }

            // step 2 if the environment or the key is not find, we try the default global settings section. 
            var returnVal = Instance.Settings.FirstOrDefault(
                        setting => System.String.Compare(setting.Key, settingsName,
                                                         System.StringComparison
                                                               .OrdinalIgnoreCase) == 0);
            return returnVal != null ? returnVal.Value : null;

        }






        /// <summary>
        /// data structure of the Settings block.
        /// </summary>
        public class SettingsBlock
        {
            public string EnvironmentName { get; set; }
            public List<SettingsEntry> Settings { get; set; }


        }

        /// <summary>
        /// data structure of the settings entry object. Have to make this defincation to let the object pass thru the serializer. 
        /// </summary>
        public class SettingsEntry
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public SettingsEntry() { }
            public SettingsEntry(string key, string value)
            {
                this.Key = key;
                this.Value = value;
            }
        }
        #endregion
    }
}
