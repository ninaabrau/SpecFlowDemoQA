using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowDemoQA.Pages.Elements
{
    public class TextBoxPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "userName")]
        private IWebElement _fullName;

        [FindsBy(How = How.Id, Using = "userEmail")]
        private IWebElement _email;

        [FindsBy(How = How.Id, Using = "currentAddress")]
        private IWebElement _currentAddress;

        [FindsBy(How = How.Id, Using = "permanentAddress")]
        private IWebElement _permanentAddress;

        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement _submitButton;

        [FindsBy(How = How.Id, Using = "output")]
        private IWebElement _output;

        [FindsBy(How = How.XPath, Using = "//p[@id='name']")]
        private IWebElement _outputName;

        [FindsBy(How = How.XPath, Using = "//p[@id='email']")]
        private IWebElement _outputEmail;

        [FindsBy(How = How.XPath, Using = "//p[@id='currentAddress']")]
        private IWebElement _outputCurrentAddress;

        [FindsBy(How = How.XPath, Using = "//p[@id='permanentAddress']")]
        private IWebElement _outputPermanentAddress;

        public TextBoxPage() : base()
        {

        }

        public void EnterValueToFields(Table table)
        {
            dynamic entry = table.CreateDynamicInstance();
            _fullName.SendKeys(entry.FullName);
            _email.SendKeys(entry.Email);
            _currentAddress.SendKeys(entry.CurrentAddress);
            _permanentAddress.SendKeys(entry.PermanentAddress);
        }

        public void EnterEmailAddress(string email)
        {
            _email.SendKeys(email);
        }

        public void ClickSubmit()
        {
            ClickOnElement(_submitButton);
        }

        public bool IsEmailInvalid()
        {
            return HasClass(_email, "field-error");
        }

        public string GetOutputName()
        {
            if (IsElementVisible(_outputName))
            {
                return _outputName.Text.Split(':', 2)[1];
            }
            return "";
        }

        public string GetOutputEmail()
        {
            if (IsElementVisible(_outputEmail))
            {
                return _outputEmail.Text.Split(':', 2)[1];
            }
            return "";
        }

        public string GetOutputCurrentAddress()
        {
            if (IsElementVisible(_outputCurrentAddress))
            {
                return _outputCurrentAddress.Text.Split(':', 2)[1];
            }
            return "";
        }

        public string GetOutputPermanentAddress()
        {
            if (IsElementVisible(_outputPermanentAddress))
            {
                return _outputPermanentAddress.Text.Split(':', 2)[1];
            }
            return "";
        }


    }
}
