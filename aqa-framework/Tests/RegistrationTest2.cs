using aqaframework.DataObjects;
using NUnit.Framework;
using aqaframework.Helpers;
using aqaframework.POM;

namespace aqaframework.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class RegistrationTest2: CoreTest
    {
        UserRegistration userRegistration = new();

        [Test]
        public void RegistrationWeb()
        {
            //Arrange
            MainPagePOM mainPagePOM = new(driverManager);
            SignInPagePOM signInPagePOM = new(driverManager);
            WebUserRegistration webReg = new(driverManager);
            User user = new RandomUser();

            //Act
            driverManager.GetDriver();
            driverManager.OpenSite();
            mainPagePOM.headerPOM.buttonSignInClick();
            signInPagePOM.linkRegistrtionClick();

            userRegistration.SetStrategy(webReg);
            userRegistration.Registration(user);

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
            User user = new RandomUser();
            APIUserRegistration apiReg = new APIUserRegistration();
            
            //Act
            userRegistration.SetStrategy(apiReg);
            userRegistration.Registration(user);
            
            //Actual
            int curStatusCode = apiReg.statusCode;
            
            //Assert
            Assert.IsTrue(curStatusCode == 201);
        }
    }
}