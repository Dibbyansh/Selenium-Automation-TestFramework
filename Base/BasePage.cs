using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OrangeHRM_Revised.Base
{
    public class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver _driver)
        {
            this._driver = _driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        protected void Click(By locator)
        {
            wait.Until(d => d.FindElement(locator).Displayed);
            _driver.FindElement(locator).Click();
        }

        protected void SendKeys(By locator, string text)
        {
            _driver.FindElement(locator).Clear();
            _driver.FindElement(locator).SendKeys(text);
        }
    }
}
