using System;
using NLog;

namespace aqaframework.Helpers;

public class LoggerHelper
{
    private static LoggerHelper _instance; 
    private readonly Logger logger = LogManager.GetLogger("TEST");
    private static readonly object _lock = new object();
    
    private LoggerHelper()
    {
        LogManager.Setup().LoadConfiguration(builder => {
            builder.ForLogger().WriteToFile(fileName: "${basedir}/last-run-log.txt");
        });
    }
    
    public static LoggerHelper Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LoggerHelper();
                    }
                }
            }

            return _instance;
        }
    }
    public void WriteInfoMessage(string message)
    {
        logger.Info(message);
    }
}