using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OrangeHRM_Revised.Base
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        protected void Click(By locator)
        {
            wait.Until(d => d.FindElement(locator).Displayed);
            driver.FindElement(locator).Click();
        }

        protected void SendKeys(By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }
    }
}
