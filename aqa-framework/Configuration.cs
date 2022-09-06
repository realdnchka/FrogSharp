using System;
using aqaframework.Drivers;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace aqaframework;
public class Configuration
    {
        public string url = TestContext.Parameters["url"];
        public string apiProfileUrl = TestContext.Parameters["apiProfileUrl"];
        public DriverManager driverManager;

        // Implementing Singleton pattern
        private static Configuration instance = null;
        private static Object syncRoot = new();

        private Configuration()
        {
            bool isTryParseOk = Enum.TryParse<BrowserType>(TestContext.Parameters["browser"], true, out var browserType);
            if (isTryParseOk)
            {
                driverManager = DriverManagerFactory.getDriverManager(browserType);
            }
            else
            {
                throw new Exception($"Incorrect browser found in config");
            }

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

