using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace aqaframework
{
    public class Configuration
    {
        public string url = TestContext.Parameters["url"];
        public string apiProfileUrl = TestContext.Parameters["apiProfileUrl"];
        
        //private Browser browser = Browser.Chrome;
        public WebDriver driver;

        // Implementing Singleton pattern
        private static Configuration instance = null;
        private static Object syncRoot = new();
        private Configuration() {
            driver = new ChromeDriver();
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
        }

        public static Configuration Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Configuration();
                        }
                    }
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

