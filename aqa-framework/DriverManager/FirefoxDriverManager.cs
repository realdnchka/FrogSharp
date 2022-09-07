using OpenQA.Selenium.Firefox;

namespace aqaframework.Drivers;

public class FirefoxDriverManager: DriverManager
{
    protected override void CreateDriver()
    {
        driver = new FirefoxDriver();
        var options = new FirefoxOptions();
        options.AddArgument("no-sandbox");
        base.CreateDriver();
    }
}