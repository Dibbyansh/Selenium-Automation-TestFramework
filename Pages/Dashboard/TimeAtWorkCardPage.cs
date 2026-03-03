using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V142.Page;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Pages.Dashboard;
using OrangeHRM_Revised.Utilities;
using System.Globalization;

namespace OrangeHRM_Revised.Pages.Dashboard
{
    public class TimeAtWorkCardPage : DashboardPage
    {
        private readonly IWebDriver WebDriver;
        private readonly DashboardPage dashboardPage;
        private string punchtime;

        public TimeAtWorkCardPage(IWebDriver WebDriver) : base(WebDriver)
        {
            this.WebDriver = WebDriver;
            dashboardPage = new DashboardPage(WebDriver);
        }

        public void EnsureState(string expectedState)
        {
            dashboardPage.WaitForCardToBeReady("Time at Work");
            var punchStatus = WebDriver.FindElement(DashbardPageLocators.TimeAtWorkCard_PunchStatus).Text;

            // if else loop to check if the expectedstate is equal to the punchstatus and if not then call perform punch method
            if (punchStatus.Equals(expectedState))
            {
                return; // Already in the expected state, no action needed
            }
            else
            {
                PerformPunch();
                PerformSubmit();
                VerifyToastMessage();

            }
        }

        public void PerformPunch()
        {
            dashboardPage.WaitForCardToBeReady("Time at Work");
            WebDriver.FindElement(DashbardPageLocators.TimeAtWorkCard_StopWatchIcon).Click();

        }

        public void PerformSubmit(bool needCurrenttime = false)
        {
            WaitHelper.WaitForSpinnerToDisappear(WebDriver, DashbardPageLocators.CardSpinner);
            WaitHelper.ClickWhenReady(WebDriver, TimePageLocators.Attendance_PunchInPunchOut_SubmitBtn);
            if (needCurrenttime == true)
            {
                punchtime = GetPunchTime();
            }
        }

        public string GetPunchTime()
        {
            return DateTime.Now.ToString("hh:mm tt");
        }

        public void PerformPunchFunc(string expecteTitleBefore, string expectedTitleAfter)
        {
            navigateToDashboard();
            PerformPunch();
            AssertTitle(expecteTitleBefore);
            PerformSubmit(true);
            VerifyToastMessage();
            WaitHelper.WaitForSpinnerToDisappear(WebDriver, DashbardPageLocators.CardSpinner);
            AssertTitle(expectedTitleAfter);
        }

        public void AssertTitle(string expectedTitle)
        {
            var title = WaitHelper.WaitForElement(WebDriver, TimePageLocators.Attendance_PunchInPunchOut_Title).Text;
            Assert.That(title, Does.Contain(expectedTitle), $"Expected title should contain '{expectedTitle}' but was not.");
        }

        public void AssertTimeDisplayed(By locator, bool isNavigateToDashboard = false)
        {
            if (isNavigateToDashboard == true)
            {
                navigateToDashboard();
            }
            string expectedTime = WaitHelper.WaitForElement(WebDriver, locator).Text;
            Assert.That(expectedTime, Does.Contain(punchtime), $"Expected time should contain '{punchtime}' but was not.");
        }

        public void navigateToDashboard()
        {
            WebDriver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index");
        }

        public void VerifyToastMessage()
        {
            var toastMessage = WaitHelper.WaitForElement(WebDriver, TimePageLocators.Attendance_ToastMessage).Text;
            Assert.That(toastMessage, Does.Contain("Successfully Saved"), $"Expected toast message did not appear.");
        }
    }
}