using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OrangeHRM_Revised.Drivers;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Pages;
using OrangeHRM_Revised.Utilities;

namespace OrangeHRM_Revised.Base
{
    public class BaseAuthenticatedTest
    {
        protected static IWebDriver _driver;  // Static = shared across all tests

        [OneTimeSetUp]  // Runs ONCE - login happens once
        public void OneTimeSetup()
        {
            // Initialize browser ONCE
            _driver = DriverFactory.InitDriver();
            _driver.Navigate().GoToUrl(ConfigManager.BaseUrl);

            // Login ONCE - stay logged in for all tests in this class
            LoginPage loginPage = new LoginPage(_driver);
            string username = JsonHelper.GetTestData<string>("LoginData.json", "ValidUser.Username");
            string password = JsonHelper.GetTestData<string>("LoginData.json", "ValidUser.Password");
            loginPage.Login(username, password);
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
            catch { }
        }

        [OneTimeTearDown]  // Cleanup ONCE after all tests
        public void OneTimeTearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}