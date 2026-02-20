using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OrangeHRM_Revised.Base
{
    public class BasePage
    {
        protected IWebDriver WebDriver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
            wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(20));
        }

        protected void Click(By locator)
        {
            wait.Until(d => d.FindElement(locator).Displayed);
            WebDriver.FindElement(locator).Click();
        }

        protected void SendKeys(By locator, string text)
        {
            WebDriver.FindElement(locator).Clear();
            WebDriver.FindElement(locator).SendKeys(text);
        }
    }
}
