using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SpecFlowDemoQA.Helper;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;

namespace SpecFlowDemoQA.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected Utilities util;
        WebDriverWait wait;

        public BasePage()
        {
            driver = WebDriverFactory.Driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            PageFactory.InitElements(driver, this);

            util = new Utilities();

        }

        protected IWebElement WaitForElement(By element)
        {
            return wait.Until((driver) => driver.FindElement(element));
        }

        protected IWebElement WaitUntil(Func<IWebDriver, IWebElement> condition)
        {
            return wait.Until(condition);
        }

        protected void WaitForPageLoad()
        {
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        protected void WaitForCondition(Func<IWebDriver, bool> condtition)
        {
            wait.Until(condtition);
        }

        protected void ScrollToElement(IWebElement element)
        {
            driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);
        }

        protected void ClickOnElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }

        protected bool HasClass (IWebElement element, string className)
        {
            return element.GetAttribute("class").Contains(className);
        }

        public bool IsElementVisible(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }

        public IWebElement GetParentElement(IWebElement element)
        {
            return element.FindElement(By.XPath(".."));
        }

        public void DoubleClickElement(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.DoubleClick(element).Perform();
        }

        public void RightClickElement(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.ContextClick(element).Perform();
        }

        public void MouseHoverOnElement(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }
    }
}
