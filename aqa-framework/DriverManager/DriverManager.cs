using OpenQA.Selenium;

namespace aqaframework.Drivers;

public abstract class DriverManager
{
    //TODO From config file and using multiple drivers each test
    protected WebDriver driver;

    public virtual void createDriver() { }
    
    public void quitDriver()
    {
        if (driver != null)
        {
            driver.Quit();
            driver = null;
        }
    }

    public WebDriver getDriver()
    {
        if (driver == null)
        {
            createDriver();
        }
        return driver;
    }
}