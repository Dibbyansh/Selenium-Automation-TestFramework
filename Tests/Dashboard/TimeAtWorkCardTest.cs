using OrangeHRM_Revised.Base;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Pages.Dashboard;

namespace OrangeHRM_Revised.Tests.Dashboard
{
    [TestFixture]
    public class TimeAtWorkCardTest : BaseAuthenticatedTest
    {
        private TimeAtWorkCardPage timeAtWorkCardPage;

        [SetUp]
        public void Setup()
        {
            timeAtWorkCardPage = new TimeAtWorkCardPage(WebDriver);
        }

        [Test]
        public void PunchIn()
        {
            timeAtWorkCardPage.EnsureState("Punched Out");
            timeAtWorkCardPage.PerformPunchFunc("Punch In", "Punch Out");
            timeAtWorkCardPage.AssertTimeDisplayed(TimePageLocators.Attendance_PunchedInTimeLabel);
        }

        [Test]
        public void PunchOut()
        {
            timeAtWorkCardPage.EnsureState("Punched In");
            timeAtWorkCardPage.PerformPunchFunc("Punch Out", "Punch In");
            timeAtWorkCardPage.AssertTimeDisplayed(DashbardPageLocators.TimeAtWorkCard_PunchInTimeLabel, true);
        }
    }
}