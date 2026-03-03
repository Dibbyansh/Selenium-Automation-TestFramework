using OpenQA.Selenium;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Utilities;

namespace OrangeHRM_Revised.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver _driver)
        {
            this._driver = _driver;
            WaitHelper.WaitForElement(_driver, LoginPageLocators.LoginTitle, 30);
        }

        public void Login(string username, string password)
        {
            _driver.FindElement(LoginPageLocators.UsernameField).SendKeys(username);
            _driver.FindElement(LoginPageLocators.PasswordField).SendKeys(password);
            _driver.FindElement(LoginPageLocators.LoginButton).Click();
        }
    }
}
