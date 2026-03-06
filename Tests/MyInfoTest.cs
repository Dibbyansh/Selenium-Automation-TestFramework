using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Internal;
using OrangeHRM_Revised.Base;
using OrangeHRM_Revised.Locators;
using OrangeHRM_Revised.Pages;
using OrangeHRM_Revised.Pages.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM_Revised.Tests
{
    [TestFixture]
    public class MyInfoTest : BaseAuthenticatedTest
    {
        private MyInfoPage myInfoPage;

        [SetUp]
        public void Setup()
        {
            myInfoPage = new MyInfoPage(_driver);
        }

        [Test]
        public void MyInfo_VerifyPage()
        {
            // verify that the url conatians PersonalDetails
            WaitHelper.WaitUntil(_driver, d => d.Url.Contains("PersonalDetails"));

            // verify title of the page is Personal Details
            var title = WaitHelper.WaitForElement(_driver, MyInfoPageLocators.PersonalDetailsTitle).Text;
            Assert.That(title, Is.EqualTo("Personal Details"), "Page title is not as expected");

            myInfoPage.VerifyName();
        }

        [Test]
        public void MyInfo_EditPertionalDetails()
        {
            // clear the input and enter new name
            myInfoPage.ClearAndEnterInput(MyInfoPageLocators.EmployeeFirstNameInput, "User07");

            myInfoPage.ClearAndEnterInput(MyInfoPageLocators.EmployeeLastNameInput, "Anna");

            // click on save button
            WaitHelper.ClickWhenReady(_driver, MyInfoPageLocators.FormUpdateSubmitBtn);
            
            string message = WaitHelper.WaitForElement(_driver, MyInfoPageLocators.ToastMessage).Text;
            Assert.That(message, Is.EqualTo("Successfully Updated"), "Toast message is not as expected");

            _driver.Navigate().Refresh();

            myInfoPage.VerifyName();
        }

        [Test]
        public void MyInfo_ProfilePictureUpdate()
        {
            // click profile picture
            WaitHelper.ClickWhenReady(_driver, MyInfoPageLocators.EmployeeImg);

            // click on upload button
            WaitHelper.WaitForElement(_driver, MyInfoPageLocators.EmployeeImgUI);
            MyInfoPage.UploadFile(_driver, MyInfoPageLocators.EmployeeImgInput, "profilepic.jpg");

            WaitHelper.ClickWhenReady(_driver, MyInfoPageLocators.ProfilePicUpdateSubmitBtn);

            string message = WaitHelper.WaitForElement(_driver, MyInfoPageLocators.ToastMessage).Text;
            Assert.That(message, Is.EqualTo("Successfully Updated"), "Toast message is not as expected");
        }
    }
}
