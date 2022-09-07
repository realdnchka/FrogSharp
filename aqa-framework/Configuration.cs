using System;
using aqaframework.Drivers;
using NUnit.Framework;

namespace aqaframework;
public class Configuration
    {
        public string url = TestContext.Parameters["url"];
        public string apiProfileUrl = TestContext.Parameters["apiProfileUrl"];
        public BrowserType browserType;

        // Implementing Singleton pattern
        private static Configuration instance;
        private static Object syncRoot = new();

        private Configuration()
        {
            bool isTryParseOk = Enum.TryParse<BrowserType>(TestContext.Parameters["browser"], true, out browserType);
            if (!isTryParseOk)
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

