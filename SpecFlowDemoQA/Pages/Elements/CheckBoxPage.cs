using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Text.RegularExpressions;

namespace SpecFlowDemoQA.Pages.Elements
{
    public class CheckBoxPage : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "rct-option-expand-all")]
        private IWebElement _expandAllButton;
        [FindsBy(How = How.Id, Using = "tree-node-home")]
        private IWebElement _homeCheckBox;
        [FindsBy(How = How.CssSelector, Using = "input[type='checkbox']")]
        private IList<IWebElement> _checkboxes;
        [FindsBy(How = How.ClassName, Using = "text-success")]
        private IList<IWebElement> _output;

        public CheckBoxPage() : base()
        {

        }

        public void CheckRootFolder()
        {
            GetParentElement(_homeCheckBox).Click();
        }

        public List<string> GetSelectedCheckBoxes()
        {
            List<string> SelectedItems = new List<string>();
            foreach (var item in _checkboxes)
            {
                if (item.Selected)
                {
                    var label = GetParentElement(item).Text;
                    if (label.Contains(".doc"))
                    {
                        label = Regex.Replace(label, @"\s+", "").Split('.')[0];
                    }
                    SelectedItems.Add(label);
                }
            }
            return SelectedItems;
        }

        public void SelectCheckBoxes(string label)
        {
            foreach (var item in _checkboxes)
            {
                var itemLabel = GetParentElement(item);
                if (itemLabel.Text.Contains(label))
                {
                    ClickOnElement(itemLabel);
                    return;
                }
            }
        }

        public List<string> GetOutput()
        {
            List<string> output = new List<string>();
            foreach (IWebElement item in _output)
            {
                output.Add(item.Text);
            }
            return output;
        }

        public void ClickExpandAll()
        {
            _expandAllButton.Click();
        }
    }
}
