using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OrangeHRM_Revised.Utilities
{
    public static class WaitHelper
    {
        public static void WaitForElement(IWebDriver driver, By locator, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(d => d.FindElement(locator).Displayed);
        }
    }
}
