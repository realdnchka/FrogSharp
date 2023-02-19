using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FrogSharp.Drivers;

public class ChromeDriverManager: DriverManager
{
    protected override void CreateDriver()
    {
        driver = new ChromeDriver();
        var options = new ChromeOptions();
        options.AddArgument("no-sandbox");
        driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
    }
}