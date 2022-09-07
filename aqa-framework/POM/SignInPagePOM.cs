using aqaframework.Drivers;
using OpenQA.Selenium;

namespace aqaframework.POM
{
    public class SignInPagePOM: CorePOM
    {
        public SignInPagePOM(DriverManager driverManager) : base(driverManager) { }

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

