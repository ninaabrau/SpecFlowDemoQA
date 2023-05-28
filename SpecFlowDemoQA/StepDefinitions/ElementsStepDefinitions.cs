using NUnit.Framework;
using SpecFlowDemoQA.Helper;
using SpecFlowDemoQA.Pages.Elements;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowDemoQA.StepDefinitions
{
    [Binding]
    public class ElementsStepDefinitions
    {
        protected Utilities util;
        protected ElementsPage elementsPage;
        protected TextBoxPage textBox;
        protected CheckBoxPage checkBox;
        protected WebTablesPage webTablesPage;
        protected ButtonsPage buttonsPage;
        protected DownloadPage downloadPage;

        private static Table _userDataTable;

        [Given(@"I navigate to Elements")]
        public void GivenINavigateElements()
        {
            elementsPage = new ElementsPage();
            elementsPage.NavigateToElements();
        }

        [When(@"I click on Text Box subcategory")]
        public void WhenIClickOnTextBoxSubcategory()
        {
            textBox = elementsPage.clickOnTextBox();
        }

        [When(@"I fill in details in the fields")]
        public void WhenIFillInDetailsInTheFields(Table table)
        {
            textBox.EnterValueToFields(table);
        }

        [When(@"I click Submit")]
        public void WhenIClickSubmit()
        {
            textBox.ClickSubmit();
        }

        [Then(@"Below details are listed in the result")]
        public void ThenBelowDetailsAreListedInTheResult(Table table)
        {
            dynamic output = table.CreateDynamicInstance(); 
            Assert.AreEqual(textBox.GetOutputName(), output.FullName);
            Assert.AreEqual(textBox.GetOutputEmail(), output.Email);
            Assert.AreEqual(textBox.GetOutputCurrentAddress(), output.CurrentAddress);
            Assert.AreEqual(textBox.GetOutputPermanentAddress(), output.PermanentAddress);
        }

        [When(@"I enter (.*) in email address field")]
        public void WhenIEnterInvalidInEmailAddressField(string email)
        {
            textBox.EnterEmailAddress(email);
        }

        [Then(@"Email address field should be displayed in red border")]
        public void ThenEmailAddressFieldShouldBeDisplayedInRedBorder()
        {
            Assert.IsTrue(textBox.IsEmailInvalid());
        }

        [When(@"I click on Check Box subcategory")]
        public void WhenIClickOnCheckBoxSubcategory()
        {
            checkBox = elementsPage.clickOnCheckBox();
        }

        [When(@"I click expand all to show all")]
        public void WhenIClickExpandAllToShowAll()
        {
            checkBox.ClickExpandAll();
        }

        [When(@"I check Home checkbox")]
        public void WhenICheckHomeCheckbox()
        {
            checkBox.CheckRootFolder();
        }

        [Then(@"Output should list all selected items")]
        public void ThenOutputShouldListAllSelectedItems()
        {
            var selected = checkBox.GetSelectedCheckBoxes();
            var output = checkBox.GetOutput();
            Assert.IsTrue(selected.SequenceEqual(output, StringComparer.OrdinalIgnoreCase));
        }

        [When(@"I select the following checkboxes")]
        public void WhenISelectTheFollowingCheckboxes(Table table)
        {
            dynamic items = table.CreateDynamicSet();
            foreach (var item in items)
            {
                checkBox.SelectCheckBoxes(item.CheckBox);
            }
        }

        [When(@"I click on Web Tables subcategory")]
        public void WhenIClickOnWebTablesSubcategory()
        {
            webTablesPage = elementsPage.clickOnWebTables();
        }

        [When(@"I click edit on entry number (.*)")]
        public void WhenIClickEditOnEntryNumber(int index)
        {
            webTablesPage.EditEntry(index-1);
        }

        [Then(@"Registration form is displayed")]
        public void ThenRegistrationFormIsDisplayed()
        {
            Assert.IsTrue(webTablesPage.RegistrationFormIsDisplayed());
        }

        [When(@"I edit details in the form to below values")]
        public void WhenIEditDetailsInTheFormToBelowValues(Table table)
        {
            webTablesPage.FillInRegistrationForm(table);
            _userDataTable = table;
        }

        [Then(@"Details should be updated for entry number (.*)")]
        public void ThenDetailsShouldBeUpdatedForEntryNumber(int index)
        {
            Assert.True(webTablesPage.VerifyEntryDetails(index-1, _userDataTable));
        }

        [When(@"I click on Buttons subcategory")]
        public void WhenIClickOnButtonsSubcategory()
        {
            buttonsPage = elementsPage.clickOnButtons();
        }

        [When(@"I (.*) on (.*) button")]
        public void WhenIClickOnClickMeButton(string action, string button)
        {
            buttonsPage.ClickButton(action,button);
        }

        [Then(@"(.*) click message (.*) displayed")]
        public void ThenDoubleClickMessageIsDisplayed(string action, string flag)
        {
            bool expected = flag == "is" ? true : false;
            switch (action)
            {
                case "Double":
                    Assert.AreEqual(buttonsPage.IsDoubleClickMessageDisplayed(), expected);
                    break;

                case "Right":
                    Assert.AreEqual(buttonsPage.IsRightClickMessageDisplayed(), expected);
                    break;
                case "Dynamic":
                    Assert.AreEqual(buttonsPage.IsDynamicClickMessageDisplayed(), expected);
                    break;
                default:
                    throw new NotImplementedException();

            }
        }

        [When(@"I click on Download and Upload subcategory")]
        public void WhenIClickOnDownloadAndUploadSubcategory()
        {
            downloadPage = elementsPage.clickDownloadUpload();
        }

        [When(@"I click Download button")]
        public void WhenIClickDownloadButton()
        {
            downloadPage.ClickDownloadButton();
        }

        [Then(@"File is downloaded")]
        public void ThenFileIsDownloaded()
        {
            Assert.IsTrue(downloadPage.VerifyFileIsDownloaded());
        }

        [When(@"I upload file")]
        public void WhenIUploadFile()
        {
            downloadPage.UploadFile();
        }

        [Then(@"File is uploaded")]
        public void ThenFileIsUploaded()
        {
            Assert.IsTrue(downloadPage.UploadFilePathIsDisplayed());
        }


    }
}
