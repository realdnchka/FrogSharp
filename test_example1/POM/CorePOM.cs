using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace test_example1.POM
{
    public abstract class CorePOM
    {
        protected WebDriver driver;
        private WebDriverWait _wait;

        public CorePOM(WebDriver driver)
        {
            this.driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.0));
        }
        /// <summary>
        /// Check for JS loaded on page
        /// </summary>
        protected void WaitForLoadJs()
        {
            _wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        protected void WaitForElementExist(By selector)
        {
            try
            {
                WaitForLoadJs();
                _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(selector));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected bool IsElementExist(By selector)
        {
            try
            {
                WaitForElementExist(selector);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            
        }

        protected void Click(By selector)
        {
            WaitForElementExist(selector);
            driver.FindElement(selector).Click();
        }

        protected string GetText(By selector)
        {
            WaitForElementExist(selector);
            return driver.FindElement(selector).Text;
        }

        protected void SetText(By selector, string text)
        {
            WaitForElementExist(selector);
            driver.FindElement(selector).SendKeys(text);
        }

        protected IList<IWebElement> FindElements(By selector)
        {
            WaitForElementExist(selector);
            return driver.FindElements(selector);
        }
    }
}