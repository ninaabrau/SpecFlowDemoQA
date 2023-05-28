using NUnit.Framework;
using SpecFlowDemoQA.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowDemoQA.StepDefinitions
{
    [Binding]
    public class WidgetsStepDefinitions
    {
        WidgetsPage widgetsPage;
        private static DateTime selectedDate;

        [Given(@"I navigate to Auto Complete")]
        public void GivenINavigateToAutoComplete()
        {
            widgetsPage = new WidgetsPage();
            widgetsPage.NavigateToAutoComplete();
        }

        [When(@"I start to type '([^']*)' single color name field")]
        public void WhenIStartToTypeSingleColorNameField(string input)
        {
            widgetsPage.EnterTextToField(input, "single");
        }

        [Then(@"Color ""([^""]*)"" should be added in the single color name field")]
        public void ThenColorShouldBeAddedInTheSingleColorNameField(string color)
        {
            Assert.IsTrue(widgetsPage.IsColorInSingleField(color));
        }

        [When(@"I start to type '([^']*)' multiple color name field")]
        public void WhenIStartToTypeMultipleColorNameField(string input)
        {
            widgetsPage.EnterTextToField(input, "multiple");
        }

        [Then(@"Color ""([^""]*)"" should be added in the multiple color name field")]
        public void ThenColorShouldBeAddedInTheMultipleColorNameField(string color)
        {
            Assert.IsTrue(widgetsPage.IsColorInMultipleField(color));
        }

        [When(@"I press enter key to (.*) color name field to autocomplete")]
        public void WhenIPressEnterKeyToAutocomplete(string field)
        {
            widgetsPage.PressEnterKeyToField(field);
        }

        [Given(@"I navigate to Date Picker")]
        public void GivenINavigateToDatePicker()
        {
            widgetsPage = new WidgetsPage();
            widgetsPage.NavigateToDatePicker();
        }

        [When(@"I click on Select Date field")]
        public void WhenIClickOnSelectDateField()
        {
            widgetsPage.ClickSelectDateField();
        }

        [Then(@"Calendar picker is displayed")]
        public void ThenCalendarPickerIsDisplayed()
        {
            Assert.IsTrue(widgetsPage.IsDatePickerDisplayed());
        }

        [When(@"I select date ""([^""]*)""")]
        public void WhenISelectDate(string date)
        {
            selectedDate = DateTime.Parse(date);
            widgetsPage.SelectDateInDatePicker(selectedDate);
        }

        [Then(@"Date is displayed in the selected date field")]
        public void ThenDateIsDisplayedInTheSelectedDateField()
        {
            Assert.AreEqual(selectedDate, widgetsPage.GetSelectedDate());
        }

        [When(@"I click on Date and Time field")]
        public void WhenIClickOnDateAndTimeField()
        {
            widgetsPage.ClickDateTimeField();
        }

        [When(@"I select date time ""([^""]*)""")]
        public void WhenISelectDateTime(string date)
        {
            selectedDate = DateTime.Parse(date);
            widgetsPage.SelectDateTimeInDateTimePicker(selectedDate);
        }

        [Then(@"Date is displayed in the date time field")]
        public void ThenDateIsDisplayedInTheDateTimeField()
        {
            Assert.AreEqual(selectedDate, widgetsPage.GetSelectedDateTime());
        }

        [Given(@"I navigate to Tooltips")]
        public void GivenINavigateToTooltips()
        {
            widgetsPage = new WidgetsPage();
            widgetsPage.NavigateToTooltips();
        }

        [When(@"I hover over the (.*)")]
        public void WhenIHoverOverTheButton(string element)
        {
            widgetsPage.HoverOnElement(element);
        }

        [Then(@"Tooltip ""([^""]*)"" is displayed")]
        public void ThenTooltipIsDisplayed(string tooltip)
        {
            Assert.IsTrue(widgetsPage.IsTooltipDisplayed(tooltip));
        }



    }
}
