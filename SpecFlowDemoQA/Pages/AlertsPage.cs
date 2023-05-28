using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SpecFlowDemoQA.Pages
{
    public class AlertsPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "tabButton")]
        private IWebElement _tabButton;
        [FindsBy(How = How.Id, Using = "windowButton")]
        private IWebElement _windowButton;
        [FindsBy(How = How.Id, Using = "promtButton")]
        private IWebElement _promtButtonn;
        [FindsBy(How = How.Id, Using = "promptResult")]
        private IWebElement _promptResult;

        public AlertsPage() : base()
        {

        }

        public void NavigateToBrowserWindows()
        {
            driver.Navigate().GoToUrl(util.Url + "browser-windows");
        }

        public void NavigateToAlerts()
        {
            driver.Navigate().GoToUrl(util.Url + "alerts");
        }

        public void ClickNewTab()
        {
            _tabButton.Click();
        }

        public void ClickNewWindow()
        {
            _windowButton.Click();
        }

        public bool NewTabOpened()
        {
            var browserTabs = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabs[1]);
            return driver.Url.Equals(util.Url + "sample");
        }

        public bool NewWindowOpened()
        {
            var newWindow = driver.WindowHandles.Last();
            driver.SwitchTo().Window(newWindow);
            return driver.Url.Equals(util.Url + "sample");
        }

        public void ClickPromptBox()
        {
            _promtButtonn.Click();
        }

        public void EnterTextInPromptBox(string text)
        {
            driver.SwitchTo().Alert().SendKeys(text);
            driver.SwitchTo().Alert().Accept();
        }

        public void DismissAlert()
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public bool PropmtResultIsDisplayed()
        {
            return IsElementVisible(_promptResult);
        }

    }
}
