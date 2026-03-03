using OpenQA.Selenium;
using OrangeHRM_Revised.Base;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Pages.Dashboard;

namespace OrangeHRM_Revised.Tests.Dashboard
{
    [TestFixture]
    public class DashboardTest : BaseAuthenticatedTest
    {
        private DashboardPage dashboardPage;

        [SetUp]
        public void Setup()
        {
            dashboardPage = new DashboardPage(_driver);
        }

        [Test]
        public void DashboardTitle_isVisible()
        {
            bool isVisible = WaitHelper.WaitForElement(_driver, DashbardPageLocators.DashboardTitle).Displayed;
            Assert.That(isVisible, Is.True, "Dashboard Title did not appear.");
        }

        [Test]
        public void AllDashboardCards_LoadSuccessfully()
        {
            var cards = _driver.FindElements(DashbardPageLocators.Cards);

            foreach (var card in cards)
            {
                var title = card.FindElement(By.TagName("p")).Text.Trim();

                if (string.IsNullOrEmpty(title))
                    continue;

                dashboardPage.WaitForCardToBeReady(title);

                var refreshedCard = WaitHelper.WaitForElement(_driver, DashbardPageLocators.CardContent);
                Assert.That(refreshedCard.Displayed, $"Dashboard card '{title}' did not load properly.");
            }
        }

        [Test]
        public void SideNavMenuDisplaysCorrectly()
        {
            var sideNavMenu = _driver.FindElements(DashbardPageLocators.SidePanelMenu).Select(x => x.Text.Trim()).ToList();

            var expectedItems = JsonHelper.GetTestData<List<string>>("Dashboard.json", "SideNavItems")!;

            Assert.That(sideNavMenu, Is.EqualTo(expectedItems));
        }
    }
}