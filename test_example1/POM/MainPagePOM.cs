using System;
using OpenQA.Selenium;

namespace aqaframework.POM
{
    public class MainPagePOM : CorePOM
    {
        public HeaderPOM headerPOM;
        public MainPagePOM(WebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
    }
}

