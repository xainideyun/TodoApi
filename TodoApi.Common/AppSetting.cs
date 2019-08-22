using System.IO;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace TodoApi.Common
{
    public class AppSetting
    {
        public static ILoggerRepository LogRepository { get; }
        static AppSetting()
        {
            LogRepository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(LogRepository, new FileInfo("log4net.config"));
        }
    }
}