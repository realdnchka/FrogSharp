using aqaframework.Drivers;
using NUnit.Framework;

namespace aqaframework.Tests
{
    [TestFixture]
    public class CoreTest
    {
        protected DriverManager driverManager;
        private DriverManagerFactory driverManagerFactory = new();

        private DriverManager InitDriverManager()
        {
            return driverManagerFactory.GetDriverManager(Configuration.Instance.browserType);
        }

        [SetUp]
        public void SetUp()
        {
            driverManager = InitDriverManager();
        }

        [TearDown]
        public void TearDown()
        {
            driverManager.CloseDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driverManagerFactory.CloseAllDrivers();
        }
    }
}