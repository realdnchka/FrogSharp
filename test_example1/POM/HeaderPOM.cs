using System;
using OpenQA.Selenium;

namespace aqaframework.POM
{
    public class HeaderPOM : CorePOM
    {
        public HeaderPOM(WebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        #region selectors
        private By buttonSignIn = By.XPath("//div[contains(@class, 'auth-bar__item--text')]");

        #endregion

        #region methods
        public void buttonSignInClick()
        {
            Click(buttonSignIn);
        }

        #endregion
    }
}

