using System;
using OpenQA.Selenium;

namespace aqaframework.POM
{
    public class RegistrationPOM: CorePOM
    {
        private WebDriver driver;

        public RegistrationPOM(WebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        #region selectors
        private By textEmail = By.XPath("//input[@type='email']");

        private By textPassword = By.XPath("(//input[@type='password'])[1]");

        private By textRepeatPassword = By.XPath("(//input[@type='password'])[2]");

        private By checkboxAcceptRules = By.XPath("//span[@class='i-checkbox__faux']");

        private By buttonRegistration = By.XPath("//button[@type='submit']");

        #endregion

        #region methods
        public RegistrationPOM textEmailInput(string email)
        {
            SetText(textEmail, email);
            return this;
        }

        public RegistrationPOM textPasswordInput(string password)
        {
            SetText(textEmail, password);
            return this;
        }

        public RegistrationPOM textRepeatPasswordInput(string password)
        {
            SetText(textEmail, password);
            return this;
        }

        public RegistrationPOM checkboxAcceptRulesClick()
        {
            Click(checkboxAcceptRules);
            return this;
        }

        public void buttonRegistrationClick()
        {
            Click(buttonRegistration);
        }
        #endregion
    }
}

