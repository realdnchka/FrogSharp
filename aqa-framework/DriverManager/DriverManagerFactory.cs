using System;

namespace aqaframework.Drivers;

public class DriverManagerFactory
{
    public static DriverManager getDriverManager(BrowserType browserType)
    {
        DriverManager driverManager;
        
        switch (browserType)
        {
            case BrowserType.Chrome:
                driverManager = new ChromeDriverManager();
                break;
            case BrowserType.Firefox:
                driverManager = new FirefoxDriverManager();
                break;
            default:
                driverManager = null;
                throw new Exception();
        }
        return driverManager;
    }
}

public enum BrowserType
{
    IE,
    Chrome,
    Firefox,
    Safari
}