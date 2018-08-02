using System;

namespace BLL.Interface
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogError(string message, Exception ex);
        void LogFatal(string message, Exception ex);
    }
}
