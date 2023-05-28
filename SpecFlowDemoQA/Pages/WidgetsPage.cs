using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SpecFlowDemoQA.Pages
{
    public class WidgetsPage : BasePage
    {
        //Auto Complete Elements
        [FindsBy(How = How.Id, Using = "autoCompleteMultipleInput")]
        private IWebElement _multipleColorField;

        [FindsBy(How = How.Id, Using = "autoCompleteSingleInput")]
        private IWebElement _singleColorField;

        [FindsBy(How = How.ClassName, Using = "auto-complete__single-value")]
        private IWebElement _singleColorFieldText;

        [FindsBy(How = How.ClassName, Using = "auto-complete__multi-value__label")]
        private IList<IWebElement> _multipleColorFieldText;

        //Date Picker Elements
        [FindsBy(How = How.Id, Using = "datePickerMonthYearInput")]
        private IWebElement _selectedDateField;

        [FindsBy(How = How.ClassName, Using = "react-datepicker__month-container")]
        private IWebElement _datePicker;
        [FindsBy(How = How.ClassName, Using = "react-datepicker__month-select")]
        private IWebElement _datePickerMonthDropdown;
        [FindsBy(How = How.ClassName, Using = "react-datepicker__year-select")]
        private IWebElement _datePickerYearDropdown;

        [FindsBy(How = How.Id, Using = "dateAndTimePickerInput")]
        private IWebElement _dateTimeField;

        [FindsBy(How = How.ClassName, Using = "react-datepicker__month-read-view")]
        private IWebElement _dateTimePickerMonthDropdown;
        [FindsBy(How = How.ClassName, Using = "react-datepicker__year-read-view")]
        private IWebElement _dateTimePickerYearDropdown;


        //Tooltip Elements
        [FindsBy(How = How.Id, Using = "toolTipButton")]
        private IWebElement _toolTipButton;

        [FindsBy(How = How.Id, Using = "toolTipTextField")]
        private IWebElement _toolTipTextField;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Contrary')]")]
        private IWebElement _toolTipContrary;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), '1.10.32')]")]
        private IWebElement _toolTipSection;

        [FindsBy(How = How.XPath, Using = "//div[@id,'textFieldToolTip']/div[@class,'tooltip-inner']")]
        private IWebElement _textFieldToolTip;
        [FindsBy(How = How.Id, Using = "buttonToolTip")]
        private IWebElement _buttonToolTip;
        [FindsBy(How = How.Id, Using = "contraryTexToolTip")]
        private IWebElement _contratyToolTip;
        [FindsBy(How = How.Id, Using = "sectionToolTip")]
        private IWebElement _sectionnToolTip;


        public WidgetsPage() : base()
        {

        }

        public void NavigateToAutoComplete()
        {
            driver.Navigate().GoToUrl(util.Url + "auto-complete");
        }

        public void EnterTextToField(string text, string element)
        {
            IWebElement field = element.Contains("multiple") ? _multipleColorField : _singleColorField;
            field.SendKeys(text);

        }

        public void PressEnterKeyToField(string element)
        {
            IWebElement field = element.Contains("multiple") ? _multipleColorField : _singleColorField;
            field.SendKeys(Keys.Enter);
        }


        public bool IsColorInSingleField(string color)
        {
            if (IsElementVisible(_singleColorFieldText))
            {
                return color.Equals(_singleColorFieldText.Text, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public bool IsColorInMultipleField(string color)
        {
            if (_multipleColorFieldText.Count > 0)
            {
                foreach(var label in _multipleColorFieldText)
                {
                    if(label.Text.Equals(color, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        public void NavigateToDatePicker()
        {
            driver.Navigate().GoToUrl(util.Url + "date-picker");
        }

        public void ClickSelectDateField()
        {
            _selectedDateField.Click();
        }
        public void ClickDateTimeField()
        {
            _dateTimeField.Click();
        }

        public bool IsDatePickerDisplayed()
        {
            return IsElementVisible(_datePicker);
        }

        public void SelectDateInDatePicker(DateTime date)
        {
            var month = date.Month - 1;
            new SelectElement(_datePickerMonthDropdown).SelectByValue(month.ToString());
            new SelectElement(_datePickerYearDropdown).SelectByValue(date.Year.ToString());

            var day = date.Day.ToString("D3");
            //select day
            driver.FindElement(By.XPath("//*[contains(@class, 'react-datepicker__day--" + day + "') and not(contains(@class, 'react-datepicker__day--outside-month'))]")).Click();
        }

        public DateTime GetSelectedDate()
        {
            return DateTime.Parse(_selectedDateField.GetAttribute("value"));
        }

        public void SelectDateTimeInDateTimePicker(DateTime date)
        {
            //Select month
            var month = date.Month-1;
            _dateTimePickerMonthDropdown.Click();
            ClickOnElement(driver.FindElements(By.XPath("//div[contains(@class,'react-datepicker__month-option')]"))[month]);

            //Select year
            _dateTimePickerYearDropdown.Click();
            var locator = "//div[contains(@class,'react-datepicker__year-option')]";
            var yearOptions = driver.FindElements(By.XPath(locator));
            
            //If year is not in the options
            while (int.Parse(yearOptions[1].Text) < date.Year)
            {
                ClickOnElement(yearOptions[0]);
                yearOptions = driver.FindElements(By.XPath(locator));
            }
            while (int.Parse(yearOptions[11].Text) > date.Year)
            {
                ClickOnElement(yearOptions[12]);
                yearOptions = driver.FindElements(By.XPath(locator));
            }

            for (var i = 1; i < 12; i++)
            {
                if (int.Parse(yearOptions[i].Text) == date.Year)
                {
                    ClickOnElement(yearOptions[i]);
                    break;
                }
            }

            //Select day
            var day = date.Day.ToString("D3");
            ClickOnElement(driver.FindElement(By.XPath("//*[contains(@class, 'react-datepicker__day--" + day + "') and not(contains(@class, 'react-datepicker__day--outside-month'))]")));


            //Select time
            var time = string.Format("{0}:{1}", date.Hour, date.Minute);
            ClickOnElement(driver.FindElement(By.XPath("//*[contains(@class,'react-datepicker__time-list-item') and contains(text(), '" + time +"')]")));
        }

        public DateTime GetSelectedDateTime()
        {
            return DateTime.Parse(_dateTimeField.GetAttribute("value"));
        }

        public void NavigateToTooltips()
        {
            driver.Navigate().GoToUrl(util.Url + "tool-tips");
        }

        public void HoverOnElement(string element)
        {
            switch (element)
            {
                case "button":
                    MouseHoverOnElement(_toolTipButton);
                    break;
                case "text field":
                    MouseHoverOnElement(_toolTipTextField);
                    break;
                case "contrary":
                    MouseHoverOnElement(_toolTipContrary);
                    break;
                case "section":
                    MouseHoverOnElement(_toolTipSection);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public bool IsTooltipDisplayed(string tooltipText)
        {
            try
            {
                var tooltip = driver.FindElement(By.XPath("//div[contains(text(),'" + tooltipText + "')]"));
                return tooltip != null;
            }
            catch
            {
                return false;
            }
        }


    }
}
