using aqaframework.Drivers;
using NUnit.Framework;

namespace aqaframework.Tests
{
    [TestFixture]
    public class CoreTest
    {
        protected DriverManager driverManager;

        protected DriverManager InitDriverManager()
        {
            return DriverManagerFactory.Instance.GetDriverManager(Configuration.Instance.browserType);
        }
        
        [SetUp]
        public void SetUp()
        {
            driverManager = InitDriverManager();
        }

        [TearDown]
        public void TearDown()
        {
            // driverManager.CloseDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DriverManagerFactory.Instance.CloseAllDrivers();
        }
    }
}