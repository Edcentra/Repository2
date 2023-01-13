using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    public static class LoggerManager
    {
        #region Field

        public static ILog Logger;
        public static ConsoleAppender _consoleAppender;
        public static FileAppender _fileAppender;
        public static RollingFileAppender _rollingFileAppender;
        public static string _layout = "%date{dd-MMM-yyyy-HH:mm:ss} [%class] [%level] [%method] - %message%newline";

        #endregion

        #region Property

        public static string Layout
        {
            set { _layout = value; }
        }

        #endregion

        #region Private

        public static PatternLayout GetPatternLayout()
        {
            var patterLayout = new PatternLayout()
            {
                ConversionPattern = _layout
            };
            patterLayout.ActivateOptions();
            return patterLayout;
        }

        public static ConsoleAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.Error
            };
            consoleAppender.ActivateOptions();
            return consoleAppender;
        }

        public static FileAppender GetFileAppender()
        {
            var fileAppender = new FileAppender()
            {
                Name = "FileAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = "FileLogger.log",
            };
            fileAppender.ActivateOptions();
            return fileAppender;
        }

        public static RollingFileAppender GetRollingFileAppender()
        {
            var rollingAppender = new RollingFileAppender()
            {
                Name = "Rolling File Appender",
                AppendToFile = true,
                File = "RollingFile.log",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                MaximumFileSize = "1MB",
                MaxSizeRollBackups = 15 //file1.log,file2.log.....file15.log
            };
            rollingAppender.ActivateOptions();
            return rollingAppender;
        }

        #endregion

        #region Public

        public static ILog GetLogger(Type type)
        {
            if (_consoleAppender == null)
                _consoleAppender = GetConsoleAppender();

            if (_fileAppender == null)
                _fileAppender = GetFileAppender();

            if (_rollingFileAppender == null)
                _rollingFileAppender = GetRollingFileAppender();

            if (Logger != null)
                return Logger;

            BasicConfigurator.Configure(_consoleAppender, _fileAppender, _rollingFileAppender);
            Logger = LogManager.GetLogger(type);
            return Logger;

        }
             

        #endregion


    }


}
