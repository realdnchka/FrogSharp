using System;
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

        public void Registration(string email, string password)
        {
            this.strategy.UserRegistration(email, password);
        }
    }

    public interface IUserRegistration
    {
        void UserRegistration(string email, string password);
    }

    public class WebUserRegistration: IUserRegistration
    {
        private RegistrationPOM registrationPOM;
        public void UserRegistration(string email, string password)
        {
            registrationPOM.textEmailInput(email)
                .textPasswordInput(password)
                .textRepeatPasswordInput(password)
                .checkboxAcceptRulesClick()
                .buttonRegistrationClick();
        }
    }

    public class APIUserRegistration : IUserRegistration
    {
        public int statusCode;
        public void UserRegistration(string email, string password)
        {
            ApiHelper apiHelper = new ApiHelper();
            RestClient client = apiHelper.client;
            RestRequest request = apiHelper.createPostRequest("registration");

            var userCreds = new
            {
                email = email,
                password = password,
                repeat_password = password
            };
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(userCreds);
            var response = client.Execute(request);
            statusCode = (int)response.StatusCode;
        }   
    }
}

