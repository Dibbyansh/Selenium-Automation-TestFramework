using OrangeHRM_Revised.Utilities;
using OrangeHRM_Revised.Base;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Pages;

namespace OrangeHRM_Revised.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest  // Uses [SetUp] - fresh state each time
    {
        [Test]
        public void SuccessfulLoginTest()
        {
            LoginPage loginPage = new LoginPage(WebDriver);
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