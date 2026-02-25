using System.Linq;
using OpenQA.Selenium;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Utilities;

namespace OrangeHRM_Revised.Pages.Dashboard
{
    public class DashboardPage
    {
        private readonly IWebDriver WebDriver;
        public DashboardPage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
            // Use configured default timeout
            WaitHelper.WaitForElement(WebDriver, DashbardPageLocators.DashboardTitle);
        }

        public void WaitForCardToBeReady(string title)
        {
            WaitHelper.WaitUntil(WebDriver, driver =>
            {
                var card = driver.FindElement(DashbardPageLocators.CardsByTitle(title));
                var spinners = card.FindElements(DashbardPageLocators.CardSpinner);

                return spinners.Count == 0 || spinners.All(s => !s.Displayed);
            });
        }
    }
}