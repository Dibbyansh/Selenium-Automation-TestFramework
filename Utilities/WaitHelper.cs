using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OrangeHRM_Revised.Utilities
{
    public static class WaitHelper
    {
        public static void WaitForElement(IWebDriver WebDriver, By locator, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(d => d.FindElement(locator).Displayed);
        }

        public static void WaitForSpinnerToDisappear(IWebDriver WebDriver, By locator, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(d => !d.FindElement(locator).Displayed);
        }
    }
}
