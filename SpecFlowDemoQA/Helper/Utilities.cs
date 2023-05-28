using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using SpecFlowDemoQA.Variables;
using System.Collections.Specialized;
using System.Configuration;
using TechTalk.SpecFlow;

namespace SpecFlowDemoQA.Helper
{
    public class Utilities
    {
        private string _url;
        static string _configSettingPath = Directory.GetParent(@"../../../").FullName +
            Path.DirectorySeparatorChar + "Configuration/configsetting.json";
        static ConfigSettings _config;

        public Utilities()
        {
            _config = new ConfigSettings();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(_configSettingPath);

            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(_config);
            Url = _config.appUrl;
        }

        public void takeSnapshot(IWebDriver driver, string filename)
        {
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(filename);
        }

        public string GenerateScreenshotFileName(string path, string screenshotName)
        {
            return path + @"\images\" + screenshotName + generateLocalTimeFingerprint() + ".png";
        }

        private string generateLocalTimeFingerprint()
        {
            return DateTime.Now.ToLocalTime().ToString().Replace('/', '-').Replace(':', '_');
        }

        public string Url
        {
            get
            {
                return _url;
            }

            set
            {
                _url = value;
            }
        }

        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public string GetDownloadedFilePath()
        {
            return Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads\\sampleFile.jpeg";

        }

    }
}