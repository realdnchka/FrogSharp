using System;
using System.Collections.Generic;
using NUnit.Framework;
using aqaframework.Helpers;
using aqaframework.POM;
using OpenQA.Selenium;

namespace aqaframework.Tests
{
    [TestFixture]
    public class Tests: CoreTest
    {
        MainPagePOM mainPagePOM;
        SignInPagePOM signInPagePOM;
        UserRegistration userRegistration = new();
        
        [Test]
        [Parallelizable]
        public void RegistrationWeb()
        {
            // OpenSite();
            //Arrange
            string email = new RandomString(10).result + "@dot.com";
            string passwd = new RandomString(8).result;
            WebUserRegistration webReg = new();
            //Act
            mainPagePOM.headerPOM.buttonSignInClick();
            signInPagePOM.linkRegistrtionClick();

            userRegistration.SetStrategy(webReg);
            userRegistration.Registration(email, passwd);

            //Actual
            bool succesReg = webReg.registrationPOM.textConfirmEmailExist();
            
            //Assert
            Assert.IsTrue(succesReg);
        }
        
        [Test]
        [Parallelizable]
        public void RegistrationApi()
        {
            //Arrange
            string email = new RandomString(10).result + "@dot.com";
            string passwd = new RandomString(8).result;
            APIUserRegistration apiReg = new APIUserRegistration();
            
            //Act
            userRegistration.SetStrategy(apiReg);
            userRegistration.Registration(email, passwd);
            
            //Actual
            int curStatusCode = apiReg.statusCode;
            
            //Assert
            Assert.IsTrue(curStatusCode == 201);
        }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            mainPagePOM = new MainPagePOM(driver);
            signInPagePOM = new SignInPagePOM(driver);
        }
    }
}