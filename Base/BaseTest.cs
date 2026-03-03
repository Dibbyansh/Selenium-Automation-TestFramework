using OpenQA.Selenium;
using OrangeHRM_Revised.Drivers;
using OrangeHRM_Revised.Utilities;
using NUnit.Framework.Interfaces;

namespace OrangeHRM_Revised.Base
{
    public class BaseTest
    {
        protected IWebDriver _driver;

        [SetUp]  // Each test gets fresh state - REQUIRED for login tests
        public void Setup()
        {
            _driver = DriverFactory.InitDriver();
            _driver.Navigate().GoToUrl(ConfigManager.BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                if (status == TestStatus.Failed)
                {
                    ScreenshotHelper.CaptureScreenshot(_driver);
                }
            }
            finally
            {
                _driver?.Quit();
                _driver?.Dispose();
            }
        }
    }
}