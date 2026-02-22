using OpenQA.Selenium;
using OrangeHRM_Revised.Base;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Tests.Dashboard;
using OrangeHRM_Revised.Utilities;

namespace OrangeHRM_Revised.Pages.Dashboard
{
    public class DashboardPage
    {
        private readonly IWebDriver WebDriver;
        public DashboardPage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
            WaitHelper.WaitForElement(WebDriver, DashbardPageLocators.DashboardTitle, 30);
        }

        public IWebElement GetCardByTitle(string title)
        {
            return WebDriver.FindElement(DashbardPageLocators.Cards(title));
        }

        public void waitforCardToLoad(string title)
        {
            var card = GetCardByTitle(title);
            By spinnerLocator =  (By)card.FindElement(DashbardPageLocators.CardSpinner);
            WaitHelper.WaitForSpinnerToDisappear(WebDriver, spinnerLocator, 30);
        }
    }
}