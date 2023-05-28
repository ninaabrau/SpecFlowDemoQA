using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowDemoQA.Pages.Elements
{
    public class WebTablesPage : BasePage
    {

        [FindsBy(How = How.XPath, Using = "//*[@title='Edit']")]
        private IList<IWebElement> _editButtons;

        [FindsBy(How = How.XPath, Using = "//div[@class='rt-tbody']/div/div[(contains(@class, 'rt-tr')and not(contains(@class,'-padRow')))]")]
        private IList<IWebElement> _entries;

        [FindsBy(How = How.Id, Using = "userForm")]
        private IWebElement _userForm;

        //Form fields
        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement _firstName;
        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement _lastName;
        [FindsBy(How = How.Id, Using = "userEmail")]
        private IWebElement _userEmail;
        [FindsBy(How = How.Id, Using = "age")]
        private IWebElement _age;
        [FindsBy(How = How.Id, Using = "salary")]
        private IWebElement _salary;
        [FindsBy(How = How.Id, Using = "department")]
        private IWebElement _department;

        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement _submitButton;

        public WebTablesPage() : base()
        {

        }

        public bool RegistrationFormIsDisplayed()
        {
            return _userForm.Displayed;
        }

        public void EditEntry(int index)
        {
            _editButtons[index].Click();
            WaitForElement(By.Id("userForm"));

        }

        public void FillInRegistrationForm(Table table)
        {
            dynamic entry = table.CreateDynamicInstance();
            _firstName.Clear();
            _firstName.SendKeys(entry.FirstName);
            _lastName.Clear();
            _lastName.SendKeys(entry.LastName);
            _age.Clear();
            _age.SendKeys(entry.Age.ToString());
            _userEmail.Clear();
            _userEmail.SendKeys(entry.Email);
            _salary.Clear();
            _salary.SendKeys(entry.Salary.ToString());
            _department.Clear();
            _department.SendKeys(entry.Department);
            ClickOnElement(_submitButton);
        }

        public bool VerifyEntryDetails(int index, Table table)
        {
            var flag = true;
            
            IList<IWebElement> rowData = _entries[index].FindElements(By.XPath(".//div[@class='rt-td']"));
            dynamic entry = table.CreateDynamicInstance();
            flag &= rowData[0].Text.Equals(entry.FirstName);
            flag &= rowData[1].Text.Equals(entry.LastName);
            flag &= rowData[2].Text.Equals(entry.Age.ToString());
            flag &= rowData[3].Text.Equals(entry.Email);
            flag &= rowData[4].Text.Equals(entry.Salary.ToString());
            flag &= rowData[5].Text.Equals(entry.Department);

            return flag;

        }
    }
}
