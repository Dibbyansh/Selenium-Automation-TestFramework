using System.Linq;
using OpenQA.Selenium;
using OrangeHRM_Revised.Base;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Pages.Dashboard;
using OrangeHRM_Revised.Utilities;

namespace OrangeHRM_Revised.Tests.Dashboard
{
    public class DashboardTest : BaseAuthenticatedTest  // Uses [OneTimeSetUp] - fast!
    {
        private DashboardPage dashboardPage;

        [SetUp]
        public void Setup()
        {
            dashboardPage = new DashboardPage(WebDriver);
        }

        [Test]
        public void DashboardTitle_isVisible()
        {
            bool isVisible = WebDriver.FindElement(DashbardPageLocators.DashboardTitle).Displayed;
            Assert.IsTrue(isVisible);
        }

        [Test]
        public void AllDashboardCards_LoadSuccessfully()
        {
            var cards = WebDriver.FindElements(DashbardPageLocators.Cards);

            // Each cards take different time to load, so not using global wait for all cards, but waiting for each card to be ready before asserting
            foreach (var card in cards)
            {
                var title = card.FindElement(By.TagName("p")).Text.Trim();

                if (string.IsNullOrEmpty(title))
                    continue;

                dashboardPage.WaitForCardToBeReady(title);

                var refreshedCard = WaitHelper.WaitForElement(WebDriver, DashbardPageLocators.CardContent);

                Assert.IsTrue(refreshedCard.Displayed, $"Dashboard card '{title}' did not load properly.");
            }
        }

        [Test]
        public void SideNavMenuDisplaysCorrectly()
        {
            List<string> SideNavMenu = WebDriver.FindElements(DashbardPageLocators.SidePanelMenu).Select(x => x.Text.Trim()).ToList();
            List<string> expectedItems = JsonHelper.GetTestData<List<string>>("Dashboard.json", "SideNavItems")!;

            Assert.That(SideNavMenu, Is.EqualTo(expectedItems));
        }
    }
}