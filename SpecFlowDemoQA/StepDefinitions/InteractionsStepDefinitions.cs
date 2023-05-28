using NUnit.Framework;
using SpecFlowDemoQA.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowDemoQA.StepDefinitions
{
    [Binding]
    public sealed class InteractionsStepDefinitions
    {
        protected InteractionsPage interactions;

        [Given(@"I navigate to droppable page")]
        public void GivenINavigateToDroppablePage()
        {
            interactions = new InteractionsPage();
            interactions.NavigateToDroppable();
        }

        [When(@"I drag Drag me box to Drop here box")]
        public void WhenIDragDragMeBoxToDropHereBox()
        {
            interactions.DragToDropbox();
        }

        [Then(@"""([^""]*)"" is displayed in the drop box")]
        public void ThenIsDisplayedInTheDropBox(string message)
        {
            Assert.AreEqual(message, interactions.GetDropBoxText());
        }

        [Given(@"I navigate to sortable page")]
        public void GivenINavigateToSortablePage()
        {
            interactions = new InteractionsPage();
            interactions.NavigateToSortable();
        }

        [When(@"I sort the list to descending order")]
        public void WhenISortTheListToDescendingOrder()
        {
            interactions.SortToDescendingOrder();
        }

        [Then(@"List is sorted in descending order")]
        public void ThenListIsSortedInDescendingOrder()
        {
            Assert.IsTrue(interactions.ListIsSortedInDescendingOrder());
        }


    }
}