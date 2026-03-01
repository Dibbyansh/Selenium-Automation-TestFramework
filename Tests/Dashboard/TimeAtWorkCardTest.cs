using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OrangeHRM_Revised.Base;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Pages.Dashboard;
using OrangeHRM_Revised.Utilities;

namespace OrangeHRM_Revised.Tests.Dashboard
{
    [TestFixture]
    [Order(1)]
    public class AttendanceTest : BaseAuthenticatedTest
    {
        private DashboardPage dashboardPage;

        private const string DashboardUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index";

        [OneTimeSetUp]
        public void Setup()
        {
            dashboardPage = new DashboardPage(WebDriver);
        }

        [Test, Order(1)]
        public void PunchIn()
        {
            dashboardPage.WaitForCardToBeReady("Time at Work");

            // Reset state: punch out first if already punched in
            if (GetPunchStatus() == "Punched In")
            {
                PerformPunch("Punch Out");
                NavigateToDashboardAndWait();
            }

            AssertPunchStatus("Punched Out");

            WaitHelper.WaitForElement(WebDriver, DashbardPageLocators.TimeAtWorkCard_StopWatchIcon).Click();
            WaitHelper.WaitForSpinnerToDisappear(WebDriver, DashbardPageLocators.CardSpinner);

            AssertDialogTitle("Punch In");
            var CurrentTime = DateTime.Now.ToString("hh:mm tt");
            SubmitAndAssertSuccess();
            WaitHelper.WaitForSpinnerToDisappear(WebDriver, DashbardPageLocators.CardSpinner);

            var punchInTime = WaitHelper.WaitForElement(WebDriver, By.CssSelector("form.oxd-form p.oxd-text--subtitle-2"));
            Assert.That(punchInTime.Text, Does.Contain(CurrentTime));
        }

        [Test, Order(2)]
        public void PunchOut()
        {
            AssertDialogTitle("Punch Out");
            var CurrentTime = DateTime.Now.ToString("hh:mm tt");
            SubmitAndAssertSuccess();

            NavigateToDashboardAndWait();
            AssertPunchStatus("Punched Out");

            var statusDetail = WaitHelper.WaitForElement(
                WebDriver,
                By.CssSelector("div.orangehrm-attendance-card-profile-record p.orangehrm-attendance-card-details"));
            Assert.That(statusDetail.Text, Does.Contain(CurrentTime));
        }

        // --- Helpers ---

        private string GetPunchStatus() =>
            WaitHelper.WaitForElement(WebDriver, DashbardPageLocators.TimeAtWorkCard_PunchStatus).Text;

        private void AssertPunchStatus(string expected) =>
            Assert.That(GetPunchStatus(), Is.EqualTo(expected));

        private void AssertDialogTitle(string expected) =>
            Assert.That(
                WaitHelper.WaitForElement(WebDriver, TimePageLocators.Attendance_PunchInPunchOut_Title).Text,
                Is.EqualTo(expected));

        private void SubmitAndAssertSuccess()
        {
            WaitHelper.WaitForElement(WebDriver, TimePageLocators.Attendance_PunchInPunchOut_SubmitBtn).Click();
            Assert.That(
                WaitHelper.WaitForElement(WebDriver, By.CssSelector("div.oxd-toast-container p.oxd-text--toast-message"), 10).Text,
                Is.EqualTo("Successfully Saved"));
        }

        private void PerformPunch(string expectedDialog)
        {
            WaitHelper.WaitForElement(WebDriver, DashbardPageLocators.TimeAtWorkCard_StopWatchIcon).Click();
            WaitHelper.WaitForSpinnerToDisappear(WebDriver, DashbardPageLocators.CardSpinner);
            AssertDialogTitle(expectedDialog);
            SubmitAndAssertSuccess();
        }

        private void NavigateToDashboardAndWait()
        {
            WebDriver.Navigate().GoToUrl(DashboardUrl);
            dashboardPage.WaitForCardToBeReady("Time at Work");
        }
    }
}