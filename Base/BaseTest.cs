using OpenQA.Selenium;
using OrangeHRM_Revised.Drivers;
using OrangeHRM_Revised.Utilities;
using NUnit.Framework.Interfaces;

namespace OrangeHRM_Revised.Base
{
    public class BaseTest
    {
        protected IWebDriver WebDriver;

        [SetUp]
        public void Setup()
        {
            WebDriver = DriverFactory.InitDriver();
            WebDriver.Navigate().GoToUrl(ConfigManager.BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;

                if (status == TestStatus.Failed)
                {
                    ScreenshotHelper.CaptureScreenshot(WebDriver);
                }
                
            }
            finally
            {
                WebDriver.Quit(); 
                WebDriver.Dispose(); 
            }
        }
    }
}
