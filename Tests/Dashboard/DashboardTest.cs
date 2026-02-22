using OrangeHRM_Revised.Base;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Pages.Dashboard;
using OrangeHRM_Revised.Pages.Dashboard.Components;
using OrangeHRM_Revised.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void cardloading_TimeAtWork()
        {
            dashboardPage.waitforCardToLoad("Time At Work");
            bool hah = WebDriver.FindElement(DashbardPageLocators.CardContent).Displayed;
            Assert.IsTrue(hah);

        }
    }
}
