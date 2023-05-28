using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SpecFlowDemoQA.Pages.Elements
{
    public class ButtonsPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "doubleClickBtn")]
        private IWebElement _doubleClickBtn;
        [FindsBy(How = How.Id, Using = "rightClickBtn")]
        private IWebElement _rightClickBtn;
        [FindsBy(How = How.XPath, Using = "//button[text()='Click Me']")]
        private IWebElement _clickMeBtn;

        [FindsBy(How = How.Id, Using = "doubleClickMessage")]
        private IWebElement _doubleClickMessage;
        [FindsBy(How = How.Id, Using = "rightClickMessage")]
        private IWebElement _rightClickMessage;
        [FindsBy(How = How.Id, Using = "dynamicClickMessage")]
        private IWebElement _clickMessage;

        public ButtonsPage() : base()
        {

        }

        public void ClickButton(string action, string button)
        {
            IWebElement element;
            switch (button)
            {
                case "Double Click Me":
                    element = _doubleClickBtn;
                    break;
                case "Right Click Me":
                    element = _rightClickBtn;
                    break;
                case "Click Me":
                    element = _clickMeBtn;
                    break;
                default:
                    throw new NotImplementedException();
            }

            switch (action)
            {
                case "double click":
                    DoubleClickElement(element);
                    return;
                case "right click":
                    RightClickElement(element);
                    return;
                case "click":
                    ClickOnElement(element);
                    return;
                default:
                    throw new NotImplementedException();
            }

        }

        public bool IsDoubleClickMessageDisplayed()
        {
            return IsElementVisible(_doubleClickMessage);
        }

        public bool IsRightClickMessageDisplayed()
        {
            return IsElementVisible(_rightClickMessage);
        }

        public bool IsDynamicClickMessageDisplayed()
        {
            return IsElementVisible(_clickMessage);
        }
    }
}
