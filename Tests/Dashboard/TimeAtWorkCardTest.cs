using OrangeHRM_Revised.Base;
using OrangeHRM_Revised.Pages.Dashboard;
using OrangeHRM_Revised.Pages.Dashboard.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM_Revised.Tests.Dashboard
{
    [TestFixture]
    public class TimeAtWorkCardTest : BaseAuthenticatedTest  // Uses [OneTimeSetUp] - fast!
    {
        private DashboardPage dashboardPage;

        [SetUp]
        public void Setup()
        {
            dashboardPage = new DashboardPage(WebDriver);
        }

        [Test]
        public void TAWCard_isVisible()
        {
           
        }
    }
}
