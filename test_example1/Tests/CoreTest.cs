using OpenQA.Selenium;
using NUnit.Framework;

namespace aqaframework.Tests
{
    [TestFixture]
    public abstract class CoreTest
    {
        private Configuration config = Configuration.Instance;
        public WebDriver driver;
        private string url;

        protected CoreTest()
        {
            this.driver = config.driver;
            this.url = config.url;
        }

        protected void OpenSite()
        {
            driver.Navigate().GoToUrl(url);
        }
        
        [SetUp]
        public virtual void SetUp()
        {
            //OpenSite();
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}