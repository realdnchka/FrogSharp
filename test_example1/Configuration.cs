using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace aqaframework
{
    public class Configuration
    {
        public string url = "https://www.onliner.by/";
        public string apiProfileUrl = "https://profile.onliner.by/sdapi/user.api/";
        //private Browser browser = Browser.Chrome;
        public WebDriver driver;

        // Implementing Singleton pattern
        private Configuration() {
            driver = new ChromeDriver();
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
        }

        private static Configuration instance = null;

        public static Configuration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Configuration();
                }
                return instance;
            }
        }
    }

    public enum Browser
    {
        Chrome,
        Firefox,
        InternetExplorer,
        Safari
    }
}

