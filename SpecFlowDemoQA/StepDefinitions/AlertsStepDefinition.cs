using NUnit.Framework;
using SpecFlowDemoQA.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowDemoQA.StepDefinitions
{
    [Binding]
    public sealed class AlertsStepDefinition
    {
        protected AlertsPage alertsPage;

        [Given(@"I navigate to Browser Windows")]
        public void GivenINavigateToBrowserWindows()
        {
            alertsPage = new AlertsPage();
            alertsPage.NavigateToBrowserWindows();
        }

        [When(@"I Click on New Tab")]
        public void WhenIClickOnNewTab()
        {
            alertsPage.ClickNewTab();
        }

        [Then(@"New tab is opened")]
        public void ThenNewTabIsOpened()
        {
            Assert.IsTrue(alertsPage.NewTabOpened());
        }

        [When(@"I Click on New Window")]
        public void WhenIClickOnNewWindow()
        {
            alertsPage.ClickNewWindow();
        }

        [Then(@"New window is opened")]
        public void ThenNewWindowIsOpened()
        {
            Assert.IsTrue(alertsPage.NewWindowOpened());
        }

        [Given(@"I navigate to Alerts")]
        public void GivenINavigateToAlerts()
        {
            alertsPage = new AlertsPage();
            alertsPage.NavigateToAlerts();
        }

        [When(@"I click on prompt box click me")]
        public void WhenIClickOnPromptBoxClickMe()
        {
            alertsPage.ClickPromptBox();
        }

        [When(@"I enter ""([^""]*)"" in the prompt box")]
        public void WhenIEnterInThePromptBox(string text)
        {
            alertsPage.EnterTextInPromptBox(text);
        }

        [Then(@"Prompt output (.*) displayed")]
        public void ThenPromptOutputShouldBeDisplayed(string flag)
        {
            bool expected = flag == "is" ? true: false;
            Assert.AreEqual(alertsPage.PropmtResultIsDisplayed(), expected);
        }

        [When(@"I dismiss the prompt")]
        public void WhenIDismissThePrompt()
        {
            alertsPage.DismissAlert();
        }


    }
}