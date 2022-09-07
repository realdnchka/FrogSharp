using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;

namespace aqaframework.Drivers;

public class DriverManagerFactory
{
    private static DriverManagerFactory instance;
    private static Object syncRoot = new();
    private List<DriverManager> driverManagers = new ();

    private DriverManagerFactory() {}

    public static DriverManagerFactory Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new DriverManagerFactory();
                    }
                }
            }
            return instance;
        }
    }
    
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