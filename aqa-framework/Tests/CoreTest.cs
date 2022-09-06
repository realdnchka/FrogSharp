using aqaframework.Drivers;
using OpenQA.Selenium;
using NUnit.Framework;

namespace aqaframework.Tests
{
    [TestFixture]
    public abstract class CoreTest
    {
        private Configuration config = Configuration.Instance;
        private DriverManager driverManager;
        public WebDriver driver;
        private string url;

        protected CoreTest()
        {
            driverManager = config.driverManager;
            driver = driverManager.getDriver();
            url = config.url;
        }

        protected void OpenSite()
        {
            driver.Navigate().GoToUrl(url);
        }

        protected void OpenUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        protected string GetUrl()
        {
            return driver.Url;
        }
        [SetUp]
        public virtual void SetUp()
        {
            OpenSite();
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driverManager.quitDriver();
        }
    }
}