using System;
using aqaframework.DataObjects;
using aqaframework.Drivers;
using RestSharp;
using aqaframework.POM;
using Newtonsoft.Json;

namespace aqaframework.Helpers
{
    //User Registration with Strategy pattern
    public class UserRegistration
    {
        private IUserRegistration strategy;
        public UserRegistration() { }

        public UserRegistration(IUserRegistration strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(IUserRegistration strategy)
        {
            this.strategy = strategy;
        }

        public void Registration(User user)
        {
            strategy.UserRegistration(user);
        }
    }

    public interface IUserRegistration
    {
        void UserRegistration(User user);
    }

    public class WebUserRegistration: IUserRegistration
    {
        public RegistrationPOM registrationPOM;
        public WebUserRegistration(DriverManager driverManager)
        {
            registrationPOM = new(driverManager);
        }
    
        public void UserRegistration(User user)
        {
            registrationPOM.textEmailInput(user.email)
                .textPasswordInput(user.password)
                .textRepeatPasswordInput(user.password)
                .checkboxAcceptRulesClick()
                .buttonRegistrationClick();
        }
    }

    public class APIUserRegistration : IUserRegistration
    {
        public int statusCode;
        public void UserRegistration(User user)
        {
            ApiHelper apiHelper = new ApiHelper();
            RestClient client = apiHelper.client;
            RestRequest request = apiHelper.createPostRequest("registration");

            var userCreds = new
            {
                email = user.email,
                password = user.password,
                repeat_password = user.password
            };
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(userCreds);
            var response = client.Execute(request);
            statusCode = (int)response.StatusCode;
        }   
    }
}

