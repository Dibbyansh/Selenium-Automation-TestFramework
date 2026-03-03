using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRM_Revised.Utilities;

namespace OrangeHRM_Revised.Base
{
    public class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver _driver)
        {
            this._driver = _driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(ConfigManager.ExplicitWait));
        }

        protected void Click(By locator)
        {
            var element = wait.Until(d =>
            {
                var el = d.FindElement(locator);
                return el.Displayed ? el : null;
            });
            element!.Click();
        }

        protected void SendKeys(By locator, string text)
        {
            var element = wait.Until(d =>
            {
                var el = d.FindElement(locator);
                return el.Displayed ? el : null;
            });
            element!.Clear();
            element.SendKeys(text);
        }
    }
}
