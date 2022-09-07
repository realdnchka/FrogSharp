using aqaframework.Drivers;

namespace aqaframework.POM
{
    public class MainPagePOM : CorePOM
    {
        public HeaderPOM headerPOM;
        public MainPagePOM(DriverManager driverManager) : base(driverManager)
        {
            headerPOM = new HeaderPOM(driverManager);
        }
    }
}

