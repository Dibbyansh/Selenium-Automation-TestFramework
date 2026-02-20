using OrangeHRM_Revised.Utilities;
using OrangeHRM_Revised.Base;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Pages;


namespace OrangeHRM_Revised.Tests
{
    public class LoginTests : BaseTest
    {
        [Test]
        public void SuccessfulLoginTest()
        {
            LoginPage loginPage = new LoginPage(WebDriver);

            //get testdata from login testdata file
            string username = JsonHelper.GetTestData<string>("LoginData.json", "ValidUser.Username");
            string password = JsonHelper.GetTestData<string>("LoginData.json", "ValidUser.Password");
            loginPage.Login(username, password);

            Assert.IsTrue(WebDriver.Url.Contains("dashboard"));
        }

        [Test]
        public void FailedLoginTest()
        {
            LoginPage loginPage = new LoginPage(WebDriver);

            string username = JsonHelper.GetTestData<string>("LoginData.json", "InvalidUser.Username");
            string password = JsonHelper.GetTestData<string>("LoginData.json", "InvalidUser.Password");
            loginPage.Login(username, password);

            WaitHelper.WaitForElement(WebDriver, LoginPageLocators.InvalidCredentialMsg, 10);
            Assert.IsTrue(WebDriver.FindElement(LoginPageLocators.InvalidCredentialMsg).Displayed);
        }
    }
}