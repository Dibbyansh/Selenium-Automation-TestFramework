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
            LoginPage loginPage = new LoginPage(driver);

            //get testdata from login testdata file
            string username = JsonHelper.GetTestData("LoginData.json", "ValidUser.Username");
            string password = JsonHelper.GetTestData("LoginData.json", "ValidUser.Password");
            loginPage.Login(username, password);

            Assert.IsTrue(driver.Url.Contains("dashboard"));
        }

        [Test]
        public void FailedLoginTest()
        {
            LoginPage loginPage = new LoginPage(driver);

            string username = JsonHelper.GetTestData("LoginData.json", "InvalidUser.Username");
            string password = JsonHelper.GetTestData("LoginData.json", "InvalidUser.Password");
            loginPage.Login(username, password);

            WaitHelper.WaitForElement(driver, LoginPageLocators.InvalidCredentialMsg, 10);
            Assert.IsTrue(driver.FindElement(LoginPageLocators.InvalidCredentialMsg).Displayed);
        }
    }
}