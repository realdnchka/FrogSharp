using System;
using System.Collections.Generic;

namespace FrogSharp.Drivers;

public class DriverManagerFactory
{
    private List<DriverManager> driverManagers = new ();

    public DriverManager GetDriverManager(BrowserType browserType)
    {
        DriverManager driverManager;
        
        switch (browserType)
        {
            case BrowserType.Chrome:
                driverManager = new ChromeDriverManager();
                driverManagers.Add(driverManager);
                break;
            case BrowserType.Firefox:
                driverManager = new FirefoxDriverManager();
                driverManagers.Add(driverManager);
                break;
            default:
                throw new Exception("Incorrect browser type");
        }
        return driverManager;
    }

    public void CloseAllDrivers()
    {
        foreach (var manager in driverManagers)
        {
            manager.CloseDriver();
        }
    }
}

public enum BrowserType
{
    IE,
    Chrome,
    Firefox,
    Safari
}