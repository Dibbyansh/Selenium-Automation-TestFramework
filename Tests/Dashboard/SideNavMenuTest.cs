using OrangeHRM_Revised.Base;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Pages.Dashboard;
using OrangeHRM_Revised.Utilities;

namespace OrangeHRM_Revised.Tests.Dashboard
{
    [TestFixture]
    public class SideNavMenuTest : BaseAuthenticatedTest  // Uses [OneTimeSetUp] - fast!
    {
        private DashboardPage DashboardPage;

        [SetUp]
        public void Setup()
        {
            DashboardPage = new DashboardPage(WebDriver); 
        }

        [Test]
        public void SideNavMenuDisplaysCorrectly()
        {
            List<string> SideNavMenu = WebDriver.FindElements(DashbardPageLocators.SidePanelMenu)
                .Select(x => x.Text.Trim())
                .ToList();
            List<string> expectedItems = JsonHelper.GetTestData<List<string>>("Dashboard.json", "SideNavItems")!;

            Assert.That(SideNavMenu, Is.EqualTo(expectedItems));
        }
    }
}