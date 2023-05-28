using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SpecFlowDemoQA.Helper;

namespace SpecFlowDemoQA.Pages.Elements
{
    public class DownloadPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "downloadButton")]
        private IWebElement _downloadButton;
        [FindsBy(How = How.Id, Using = "uploadFile")]
        private IWebElement _uploadButton;
        [FindsBy(How = How.Id, Using = "uploadedFilePath")]
        private IWebElement _uploadFilePath;

        public DownloadPage(): base()
        {

        }

        public void ClickDownloadButton()
        {
            _downloadButton.Click();
        }

        public bool VerifyFileIsDownloaded()
        {
            bool fileExists = false;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(x => fileExists = File.Exists(new Utilities().GetDownloadedFilePath()));
        }

        public void UploadFile()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = dir.Replace("bin\\Debug\\net6.0", "Data\\uploadFile.jpeg");
            _uploadButton.SendKeys(filePath.TrimEnd('\\'));
        }

        public bool UploadFilePathIsDisplayed()
        {
            return IsElementVisible(_uploadFilePath);
        }

    }
}
