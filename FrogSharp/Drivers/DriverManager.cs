using OpenQA.Selenium;

namespace FrogSharp.Drivers;

public abstract class DriverManager
{
    protected WebDriver driver;

    protected virtual void CreateDriver() { }

    public WebDriver GetDriver()
    {
        if (driver == null)
        {
            CreateDriver();
        }
        return driver;
    }

    public void OpenUrl(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    public void OpenSite()
    {
        OpenUrl(Configuration.Instance.url);
    }

    public string GetUrl()
    {
        return driver.Url;
    }

    public void CloseDriver()
    {
        if (driver != null)
        {
            driver.Quit();
        }
    }
}