using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using SpecFlowDemoQA.Helper;
using SpecFlowDemoQA.Variables;

namespace SpecFlowDemoQA.Pages
{
    public class LoginPage :BasePage
    {
        [FindsBy(How = How.Id, Using = "userName")]
        private IWebElement _usernameField;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _passwordField;
        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement _loginButton;
        [FindsBy(How = How.Id, Using = "newUser")]
        private IWebElement _newUserButton;

        //Register elements
        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement _firstNameField;
        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement _lastNameField;
        [FindsBy(How = How.Id, Using = "gotologin")]
        private IWebElement _backToLogin;
        [FindsBy(How = How.Id, Using = "register")]
        private IWebElement _registerButton;


        [FindsBy(How = How.XPath, Using = "//iframe[@title='reCAPTCHA']")]
        private IWebElement _reCaptchaFrame;


        [FindsBy(How = How.Id, Using = "userName-value")]
        private IWebElement _userNameProfile;

        User user;
        public LoginPage() : base()
        {
            user = DataFactory.GetUserData();
        }

        public void NavigateToLogin()
        {
            driver.Navigate().GoToUrl(util.Url + "login");
        }

        public void Register()
        {
            _firstNameField.SendKeys(user.FirstName);
            _lastNameField.SendKeys(user.LastName);
            _usernameField.SendKeys(user.UserName);
            _passwordField.SendKeys(user.Password);

            CheckReCAPTCHA();

            ClickOnElement(_registerButton);
        }

        public void Login()
        {
            _usernameField.SendKeys(user.UserName);
            _passwordField.SendKeys(user.Password);
            _loginButton.Click();
        }

        public bool IsUserRegistered()
        {
            try
            {
                var alert = driver.SwitchTo().Alert();
                if(alert.Text.Contains("Register Successfully"))
                {
                    alert.Accept();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            
        }

        public bool ProfileIsDisplayed()
        {
            return _userNameProfile.Equals(user.UserName);
        }

        public void ClickNewUser()
        {
            ClickOnElement(_newUserButton);
        }

        public void ClickBackToLogin()
        {
            ClickOnElement(_backToLogin);
        }


        public void CheckReCAPTCHA()
        {
            //ExpectedConditions.FrameToBeAvailableAndSwitchToIt(
            //        By.XPath("//iframe[contains(@title, 'reCAPTCHA') and starts-with(@src, 'https://www.google.com/recaptcha')]"));
            driver.SwitchTo().Frame(_reCaptchaFrame);
            ClickOnElement(WaitUntil(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='recaptcha-checkbox-border']"))));
            driver.SwitchTo().ParentFrame();
        }
    }
}
