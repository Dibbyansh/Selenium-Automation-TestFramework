using OpenQA.Selenium;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Utilities;

namespace OrangeHRM_Revised.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver WebDriver;


        public LoginPage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
            WaitHelper.WaitForElement(WebDriver, LoginPageLocators.LoginTitle, 10);
        }

        public void Login(string username, string password)
        {
            WebDriver.FindElement(LoginPageLocators.UsernameField).SendKeys(username);
            WebDriver.FindElement(LoginPageLocators.PasswordField).SendKeys(password);
            WebDriver.FindElement(LoginPageLocators.LoginButton).Click();
        }
    }
}
