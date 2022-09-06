using OpenQA.Selenium.Firefox;

namespace aqaframework.Drivers;

public class FirefoxDriverManager: DriverManager
{
    public override void createDriver()
    {
        driver = new FirefoxDriver();
        var options = new FirefoxOptions();
        options.AddArgument("no-sandbox");
        base.createDriver();
    }
}