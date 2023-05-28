using NUnit.Framework;
using SpecFlowDemoQA.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowDemoQA.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinition
    {
        protected LoginPage loginPage;

        [Given(@"I navigate to Login Page")]
        public void GivenINavigateToLoginPage()
        {
            loginPage = new LoginPage();
            loginPage.NavigateToLogin();
        }

        [When(@"I click New User button to register new user")]
        public void WhenIClickNewUserButtonToRegisterNewUser()
        {
            loginPage.ClickNewUser();
        }

        [When(@"I register with user details")]
        public void WhenIRegisterWithUserDetails()
        {
            loginPage.Register();
        }

        [Then(@"User is successfuly registered")]
        public void ThenUserIsSuccessfulyRegistered()
        {
            Assert.IsTrue(loginPage.IsUserRegistered());
        }

        [When(@"I go back to login page")]
        public void WhenIGoBackToLoginPage()
        {
            loginPage.ClickBackToLogin();
        }

        [When(@"I login with user details")]
        public void WhenILoginWithUserDetails()
        {
            loginPage.Login();
        }

        [Then(@"User profile is displayed")]
        public void ThenUserProfileIsDisplayed()
        {
            Assert.IsTrue(loginPage.ProfileIsDisplayed());
        }

    }
}
