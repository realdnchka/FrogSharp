using System;
using System.Collections.Generic;
using NUnit.Framework;
using aqaframework.Helpers;
using aqaframework.POM;

namespace aqaframework.Tests
{
    [TestFixture]
    public class Tests: CoreTest
    {
        MainPagePOM mainPagePOM;
        SignInPagePOM signInPagePOM;
        UserRegistration userRegistration = new();

        [Test]
        public void RegistrationWeb()
        {
            OpenSite();
            //Arrange
            string email = new RandomString(10).result + "@test.com";
            string passwd = new RandomString(8).result;

            //Act
            mainPagePOM.headerPOM.buttonSignInClick();
            signInPagePOM.linkRegistrtionClick();

            userRegistration.SetStrategy(new WebUserRegistration());
            userRegistration.Registration(email, passwd);

            //Actual

            //Assert
            Assert.IsTrue(true);
        }

        [Test]
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

            //Assert
            Console.WriteLine(apiReg.statusCode);
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