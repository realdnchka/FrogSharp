using OpenQA.Selenium.Chrome;

namespace aqaframework.Drivers;

public class ChromeDriverManager: DriverManager
{
    public override void createDriver()
    {
        driver = new ChromeDriver();
        var options = new ChromeOptions();
        options.AddArgument("no-sandbox");
        driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
    }
}