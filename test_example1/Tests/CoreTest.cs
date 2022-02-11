using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace test_example1
{
    [TestFixture]
    public abstract class CoreTest
    {
        protected static WebDriver driver;
        private static string url = "https://www.w3schools.com/sql/trysql.asp?filename=trysql_asc";

        protected void OpenSite()
        {
            driver.Navigate().GoToUrl(url);
        }
        
        [SetUp]
        public virtual void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}