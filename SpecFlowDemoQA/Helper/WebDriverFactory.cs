using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowDemoQA.Helper
{
    public class WebDriverFactory
    {
        private WebDriverFactory() { }

        private static readonly object Obj = new object();
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                ChromeOptions options = new ChromeOptions();

                options.AddArgument("start-maximized");
                if (_driver == null) _driver = new ChromeDriver(options);

                return _driver;
            }
        }

        public static void CloseBrowser()
        {
            Driver.Close();
            Driver.Quit();
            _driver = null;
        }
    }
}
