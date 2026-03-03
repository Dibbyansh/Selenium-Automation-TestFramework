using NUnit.Framework;
using OpenQA.Selenium;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Utilities;

namespace OrangeHRM_Revised.Pages.Dashboard
{
    public class TimeAtWorkCardPage : DashboardPage
    {
        private string _punchTime;

        // Only one instance — base(driver) initialises _driver in DashboardPage.
        public TimeAtWorkCardPage(IWebDriver driver) : base(driver) { }

        public void EnsureState(string expectedState)
        {
            NavigateToDashboard();
            WaitForCardToBeReady("Time at Work");

            var punchStatus = _driver.FindElement(DashbardPageLocators.TimeAtWorkCard_PunchStatus).Text;
            if (punchStatus.Equals(expectedState))
                return;

            PerformPunch();
            PerformSubmit();
            VerifyToastMessage();
        }

        public void PerformPunch()
        {
            WaitForCardToBeReady("Time at Work");
            _driver.FindElement(DashbardPageLocators.TimeAtWorkCard_StopWatchIcon).Click();
        }

        public void PerformSubmit(bool captureTime = false)
        {
            WaitHelper.WaitForSpinnerToDisappear(_driver, DashbardPageLocators.CardSpinner);
            WaitHelper.ClickWhenReady(_driver, TimePageLocators.Attendance_PunchInPunchOut_SubmitBtn);

            if (captureTime)
                _punchTime = DateTime.Now.ToString("hh:mm tt");
        }

        public void PerformPunchFunc(string titleBefore, string titleAfter)
        {
            NavigateToDashboard();
            PerformPunch();
            AssertTitle(titleBefore);
            PerformSubmit(captureTime: true);
            VerifyToastMessage();
            WaitHelper.WaitForSpinnerToDisappear(_driver, DashbardPageLocators.CardSpinner);
            AssertTitle(titleAfter);
        }

        public void AssertTitle(string expectedTitle)
        {
            var title = WaitHelper.WaitForElement(_driver, TimePageLocators.Attendance_PunchInPunchOut_Title).Text;
            Assert.That(title, Does.Contain(expectedTitle),
                $"Expected title to contain '{expectedTitle}' but got '{title}'.");
        }

        public void AssertTimeDisplayed(By locator, bool navigateToDashboardFirst = false)
        {
            if (navigateToDashboardFirst)
                NavigateToDashboard();

            var displayedTime = WaitHelper.WaitForElement(_driver, locator).Text;
            Assert.That(displayedTime, Does.Contain(_punchTime),
                $"Expected displayed time '{displayedTime}' to contain '{_punchTime}'.");
        }

        public void VerifyToastMessage()
        {
            var toast = WaitHelper.WaitForElement(_driver, TimePageLocators.Attendance_ToastMessage).Text;
            Assert.That(toast, Does.Contain("Successfully Saved"),
                "Expected 'Successfully Saved' toast message did not appear.");
        }

        private void NavigateToDashboard()
        {
            _driver.Navigate().GoToUrl(
                "https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index");
        }
    }
}