using System;
using OpenQA.Selenium;

namespace aqaframework.POM
{
    public class SignInPagePOM: CorePOM
    {
        public SignInPagePOM(WebDriver driver): base(driver)
        {
            this.driver = driver;
        }

        #region selectors
        private By linkRegistration = By.XPath("(//a[contains(@class, 'auth-form__link')])[1]");

        #endregion

        #region methods
        public void linkRegistrtionClick()
        {
            Click(linkRegistration);
        }

        #endregion
    }
}

