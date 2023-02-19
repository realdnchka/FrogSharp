using FrogSharp.Drivers;
using NUnit.Framework;

namespace FrogSharp.Tests
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