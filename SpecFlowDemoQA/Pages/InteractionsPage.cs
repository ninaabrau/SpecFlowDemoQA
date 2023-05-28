using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace SpecFlowDemoQA.Pages
{
    public class InteractionsPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "draggable")]
        private IWebElement _drag;

        [FindsBy(How = How.Id, Using = "droppable")]
        private IWebElement _drop;

        [FindsBy(How = How.XPath, Using = "//*[@id='demo-tabpane-list']/div/div")]
        private IList<IWebElement> _listElements;

        private string[] _numbers = { "One", "Two", "Three", "Four", "Five", "Six" };

        public InteractionsPage() : base()
        {

        }

        public void NavigateToDroppable()
        {
            driver.Navigate().GoToUrl(util.Url + "droppable");
        }

        public void DragToDropbox()
        {
            Actions actions = new Actions(driver);
            actions.DragAndDrop(_drag, _drop).Perform();
        }

        public string GetDropBoxText()
        {
            return _drop.Text;
        }
        public void NavigateToSortable()
        {
            driver.Navigate().GoToUrl(util.Url + "sortable");
        }

        public void SortToDescendingOrder()
        {
            var lastIndex = _listElements.Count-1;
            ScrollToElement(_listElements[lastIndex]);
            for(var i= 0; i < lastIndex; i++)
            {
                Sort(_listElements[lastIndex], _listElements[i]);
            }
        }

        public bool ListIsSortedInDescendingOrder()
        {
            _listElements = driver.FindElements(By.XPath("//*[@id='demo-tabpane-list']/div/div"));
            var flag = true;
            var j = _listElements.Count - 1;
            for (var i = 0; i < _listElements.Count; i++)
            {
                flag &= _listElements[i].Text == _numbers[j];
                j--;
            }
            return flag;
        }

        private void Sort(IWebElement eToMove, IWebElement eToReplace)
        {
            var actions = new Actions(driver);
            actions
                 .ClickAndHold(eToMove)
                 .MoveToElement(eToReplace)
                 .MoveByOffset(0, 10)
                 .Release()
                 .Perform();
        }
    }
}
