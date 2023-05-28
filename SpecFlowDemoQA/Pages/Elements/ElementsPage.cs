using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SpecFlowDemoQA.Pages.Elements
{
    public class ElementsPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "item-0")]
        private IWebElement _textBox;
        [FindsBy(How = How.Id, Using = "item-1")]
        private IWebElement _checkBox;
        [FindsBy(How = How.Id, Using = "item-3")]
        private IWebElement _webTables;
        [FindsBy(How = How.Id, Using = "item-4")]
        private IWebElement _buttons;
        [FindsBy(How = How.Id, Using = "item-7")]
        private IWebElement _uploadDownload;
        public ElementsPage() : base()
        {

        }
        public void NavigateToElements()
        {
            driver.Navigate().GoToUrl(util.Url + "elements");
        }

        public TextBoxPage clickOnTextBox()
        {
            _textBox.Click();
            return new TextBoxPage();
        }

        public CheckBoxPage clickOnCheckBox()
        {
            _checkBox.Click();
            return new CheckBoxPage();
        }

        public WebTablesPage clickOnWebTables()
        {
            _webTables.Click();
            return new WebTablesPage();
        }

        public ButtonsPage clickOnButtons()
        {
            ClickOnElement(_buttons);
            return new ButtonsPage();
        }

        public DownloadPage clickDownloadUpload()
        {
            ClickOnElement(_uploadDownload);
            return new DownloadPage();
        }


    }
}
