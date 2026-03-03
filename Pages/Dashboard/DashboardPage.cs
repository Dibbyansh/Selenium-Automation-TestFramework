using System.Linq;
using OpenQA.Selenium;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Utilities;

namespace OrangeHRM_Revised.Pages.Dashboard
{
    public class DashboardPage
    {
        protected readonly IWebDriver _driver;

        public DashboardPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void WaitForCardToBeReady(string title)
        {
            WaitHelper.WaitUntil(_driver, driver =>
            {
                var card = driver.FindElement(DashbardPageLocators.CardsByTitle(title));
                var spinners = card.FindElements(DashbardPageLocators.CardSpinner);
                return spinners.Count == 0 || spinners.All(s => !s.Displayed);
            });
        }
    }
}