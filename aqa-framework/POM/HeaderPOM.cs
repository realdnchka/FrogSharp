using aqaframework.Drivers;
using OpenQA.Selenium;

namespace aqaframework.POM
{
    public class HeaderPOM : CorePOM
    {
        public HeaderPOM(DriverManager driverManager) : base(driverManager) { }

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

