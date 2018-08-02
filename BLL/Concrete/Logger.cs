using BLL.Interface;
using System;

namespace BLL
{
    public sealed class Logger : ILogger
    {
        NLog.Logger logger;

        public Logger()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();

            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "log.txt" };

            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
        }

        public void LogError(string message, Exception ex)
        {
            logger.Error(ex.StackTrace, message);
        }

        public void LogFatal(string message, Exception ex)
        {
            logger.Fatal(ex.StackTrace, message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
