using OrangeHRM_Revised.Base;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Pages;
using OrangeHRM_Revised.Utilities;

namespace OrangeHRM_Revised.Tests
{
    public class DashboardTests : BaseTest
    {
        [Test]
        public void SideNavMenu()
        {
            WaitHelper.WaitForElement(WebDriver, DashbardPageLocators.SidePanelMenu, 10);

            List<string> SideNavMenu = WebDriver.FindElements(DashbardPageLocators.SidePanelMenu).Select(x => x.Text.Trim()).ToList();
            List<string> expectedItems = JsonHelper.GetTestData<List<string>>("Dashboard.json", "SideNavItems")!;

            Assert.That(SideNavMenu, Is.EqualTo(expectedItems), "Side navigation menu items do not match the expected list.");
        }
    }
}
